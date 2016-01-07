//#define DEMO

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace Soil_moisture_App
{
    public enum CMDs : byte
    {
        CMD_MOIS = (byte)'A',
        CMD_VOLT = (byte)'B',
        CMD_MIN = (byte)'C',
        CMD_MAX = (byte)'D',
        CMD_CALI = (byte)'E',
        CMD_DRY = (byte)'F',
        CMD_WET = (byte)'G',
        CMD_FIN = (byte)'H',
        CMD_TEST = (byte)'I',
        CMD_VERS = (byte)'J',
        CMD_RSSI = (byte)'K',
        CMD_ERROR = (byte)'Z'
    }


    public struct cmdStruct
    {
        public byte cmd;
        public int val1, val2;
    }

    public partial class Form1 : Form
    {
        public SynchronizationContext mainThread;
        public System.IO.Ports.SerialPort sport;
        public CalibrationForm CaliForm;

        public volatile bool _backgroundPause = true;

        public string[] CMD_array = {
            "MOIS",
            "VOLT",
            "MIN ",
            "MAX ",
            "CALI",
            "DRY ",
            "WET ",
            "FIN ",
            "TEST",
            "VERS",
            "RSSI",
            "ERROR"
        };

        public struct cmdStruct
        {
            public byte cmd;
            public int val1;
            public int val2;
        } ;

        enum FormComModes : byte
        {   CaliStart,
            CaliDry,
            CaliWet,
            CaliFin,
            CaliError,
            CaliEnd
        };

        volatile int initFlag = 0;
        volatile bool wireless_Flag = false;

        public Thread bgThread = null;

        public Form1()
        {
            InitializeComponent();
            disconBTN.Enabled = false;
            caliBTN.Enabled = false;
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
                comPort_comboBox.Items.Add(s);

            //debug code
            if (comPort_comboBox.Items.Contains("COM12"))
                comPort_comboBox.Text = "COM12";
            else
            { if (comPort_comboBox.Items.Count != 0)
                    comPort_comboBox.SelectedIndex = 0;
            }

            

            moisLab.Text = "--%";
            rssiLab.Text = "--";

            mainThread = SynchronizationContext.Current;
            if (mainThread == null) mainThread = new SynchronizationContext();

        }


        public void serialport_connect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
        {
            if (port != "") { 
                sport = new System.IO.Ports.SerialPort(
                port, baudrate, parity, databits, stopbits);

                try
                {
                    sport.Open();
                    disconBTN.Enabled = true;
                    conBTN.Enabled = false;
                    caliBTN.Enabled = true;
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Connected\n");
                    sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);

                    // Create the thread object. This does not start the thread.
                    bgThread = new Thread(new ThreadStart(BackgroundThread));

                    bgThread.IsBackground = true;
                    bgThread.Start();
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Background Thread started and Paused\n");
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error"); }}

            
        }

        public void send_command(byte cmd, byte val1, byte val2)
        {
            byte[] b = new byte[4];
            //TODO: change to Node ID

            b[0] = (byte)'1';
            b[1] = (byte)'0';
            b[2] = cmd;
            b[3] = 0x0A; // '\n'

            if (wireless_Flag == true)
            {
                //send 4 chars!
                sport.Write(b, 0, 4);
            }
            else
            {
                //send only 1 char!
                sport.Write(b, 2, 1);
            }
            

            mainThread.Send((object state) =>
            {
                //txtReceiveBox.AppendText("[" + get_dtn() + "] " + "cmd: " + Convert.ToChar(cmd) + "  val1: " + val1.ToString() + "  val2: " + val2.ToString() + "\n");
            }, null);
        }

        public String get_dtn()
        {
            DateTime dt = DateTime.Now;
            //return dt.ToShortTimeString();
            return dt.ToLongTimeString();
        }

        public void CaliFormCallback(byte m)
        {
            button1.Text = m.ToString();
            if (m == (byte)FormComModes.CaliStart)
            {
                send_command((byte)CMDs.CMD_CALI, 1, 0);
                Thread.Sleep(200);
                #if DEMO
                CaliForm.changeContext((byte)FormComModes.CaliDry);
                #endif
            }
            else if (m == (byte)FormComModes.CaliDry)
            {
                send_command((byte)CMDs.CMD_DRY, 1, 0);
                Thread.Sleep(200);
                #if DEMO
                CaliForm.changeContext((byte)FormComModes.CaliWet);
                #endif
            }
            else if (m == (byte)FormComModes.CaliWet)
            {
                send_command((byte)CMDs.CMD_WET, 1, 0);
                Thread.Sleep(200);
            }
            else if ((m == (byte)FormComModes.CaliFin) || (m == (byte)FormComModes.CaliError))
            {
                send_command((byte)CMDs.CMD_FIN, 1, 0);
                Thread.Sleep(1000);

                send_command((byte)CMDs.CMD_MIN, 0, 0);
                Thread.Sleep(300);

                send_command((byte)CMDs.CMD_MAX, 0, 0);

                Thread.Sleep(300);
                CaliForm.Close();

                
                _backgroundPause = false;

            }
            else if (m == (byte)FormComModes.CaliEnd)
            {
                _backgroundPause = false;
            }


        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String str = sport.ReadLine();

            cmdStruct cmdBack = decodeReceivedCmd(str);
            
            mainThread.Send((object state) =>
            {
                if (processReceivedCmd(cmdBack))
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "rec: cmd: " + CMD_array[Convert.ToByte(cmdBack.cmd) - 'A'] + "  val1: " + cmdBack.val1.ToString() + "  val2: " + cmdBack.val2.ToString() + "\n");
                    //if(cmdBack.cmd == (byte)CMDs.CMD_RSSI)
                      //  txtReceiveBox.AppendText("[" + get_dtn() + "] " + "rec: cmd: " + str.ToString() + "\n");

                else
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "rec: cmd: " + str.ToString() + "\n");

            }, null);
        }

        private cmdStruct decodeReceivedCmd(string str)
        {
            // Protocoll
            //   | ID | CMD | val1 |val2 | \n |
            //   | 2B | 1B  |  4B  | 4B  | 1B |
            //   9    11    12     16     20
            //   0    2     3      7      11

            cmdStruct cmdBack = new cmdStruct();

            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);

            if (wireless_Flag == true && bytes[0] != (byte)CMDs.CMD_VERS)
            {
                int node_ID = Int16.Parse(str.Substring(0, 2));
                cmdBack.cmd = bytes[2 * sizeof(char)];
                if (str.Length >= 7)
                    cmdBack.val1 = Int16.Parse(str.Substring(3, 4));
                //TODO: length is somehow 11 but no conntent
                if (str.Length >= 11)
                    cmdBack.val2 = Int16.Parse(str.Substring(7, 4));
                return cmdBack;
            }
            else
            {
                cmdBack.cmd = bytes[0];
                if (str.Length >= 5)
                    cmdBack.val1 = Int16.Parse(str.Substring(1, 4));
                if (str.Length >= 9)
                    cmdBack.val2 = Int16.Parse(str.Substring(5, 4));
                return cmdBack;
            }
            
        }

        private bool processReceivedCmd(cmdStruct c)
        {
            bool back = true;
            if (txtReceiveBox.TextLength >= 20000)
                txtReceiveBox.Text =  txtReceiveBox.Text.Substring(17000, 3000);
            switch (c.cmd)
            {
                case (byte)CMDs.CMD_MOIS:
                    moisLab.Text = c.val1.ToString() + "%";
                    progressBar1.Value = c.val1;
                    break;
                case (byte)CMDs.CMD_VOLT:
                    break;
                case (byte)CMDs.CMD_MIN:
                    minMoisLab.Text = c.val1.ToString();
                    break;
                case (byte)CMDs.CMD_MAX:
                    maxMoisLab.Text = c.val1.ToString();
                    break;
                case (byte)CMDs.CMD_CALI:
                    if(c.val1 == 1)
                        CaliForm.changeContext((byte)FormComModes.CaliDry);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_DRY:
                    if ((c.val1 >= 0) && (c.val1 <= 1024))
                        CaliForm.changeContext((byte)FormComModes.CaliWet);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_WET:
                    if ((c.val1 >= 0) && (c.val1 <= 1024))
                        CaliForm.changeContext((byte)FormComModes.CaliFin);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_TEST:
                    moisLab.Text = c.val1.ToString();
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "received TEST" + "\n");
                    _backgroundPause = false;
                    break;
                    /*
                case (byte)CMDs.CMD_FIN:
                    if ((byte)c.val1 == 1)
                        CaliForm.changeContext((byte)FormComModes.CaliFin);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                     */
                case(byte)CMDs.CMD_VERS:
                    initFlag = 1;
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Software VERSION : " + c.val1.ToString() + "\n");
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "         BUILT   : " + c.val2.ToString() + "\n");

                    if (c.val2 >= 1000)
                    {  //Veriosn with Wireless if built no. > 1000
                        pictureBox1.Visible = true;
                        wireless_Flag = true;
                    }


                    break;
                case(byte)CMDs.CMD_RSSI:
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "received RSSI :" + c.val1.ToString() +"\n");
                    rssiLab.Text = "-" + c.val1.ToString();
                    rssiLab.Show();
                    progressBarRSSI.Minimum = 0;
                    progressBarRSSI.Maximum = 40;
                    if((c.val1 <= 120) && (c.val1 >= 80))
                        progressBarRSSI.Value = 120 - c.val1;

                    if (c.val1 <= 94)
                        pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi3;
                    else if(c.val1 <= 105) 
                        pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi_2;
                    else if(c.val1 <= 110)
                        pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi_1;
                    else
                        pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi_0;
                    //start timout timer
                    timer1.Stop();
                    timer1.Start();
                    break;
                default:
                    back = false;
                    break;
            }
            return back;
        }




        private void conBTN_Click(object sender, EventArgs e)
        {
            String port = comPort_comboBox.Text;
            int baudrate = 9600;
            Parity parity = System.IO.Ports.Parity.None;
            int databits = 8;
            StopBits stopbits = System.IO.Ports.StopBits.One;
            
            serialport_connect(port, baudrate, parity, databits, stopbits);

            //check the Version to check for right Com Port
            int tout = 20;
            initFlag = 0;
            send_command((byte)CMDs.CMD_VERS, 0, 0);
            Thread.Sleep(300);
            //send a second time in case of a wirless communication
            send_command((byte)CMDs.CMD_VERS, 0, 0);


            Thread.Sleep(300);
            send_command((byte)CMDs.CMD_MIN, 0, 0);
            Thread.Sleep(300);
            send_command((byte)CMDs.CMD_MAX, 0, 0);
            Thread.Sleep(300);
            send_command((byte)CMDs.CMD_VERS, 0, 0);
            Thread.Sleep(300);

            send_command((byte)CMDs.CMD_MOIS, 0, 0);
            Thread.Sleep(300);
            //Thread.Sleep(1000);
            while (initFlag != 1)
            {
                Thread.Sleep(100);
                tout--;
                if (tout == 0)
                {
                    disconBTN_Click(null, null);
                    MessageBox.Show("Wrong Com Port!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _backgroundPause = false;


        }

        private void sendBTN_Click(object sender, EventArgs e)
        {
            String data = txtDataSendBox.Text;
            sport.Write(data);
            txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Sent: " + data + "\n");
        }

        private void disconBTN_Click(object sender, EventArgs e)
        {
            _backgroundPause = true;

            if (bgThread != null)
                bgThread.Abort();

            Thread.Sleep(500);

            if (sport != null)
            {
                if (sport.IsOpen)
                {
                    while (sport.BytesToRead != 0 && sport.BytesToRead != 0) ;
                    sport.Close();

                    disconBTN.Enabled = false;
                    caliBTN.Enabled = false;
                    conBTN.Enabled = true;
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Disconnected\n");
                }
            }

            wireless_Flag = false;
            pictureBox1.Visible = false;
        }

        private void caliBTN_Click(object sender, EventArgs e)
        {
            _backgroundPause = true;
            txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Start Calibration!\n");
            CaliForm = new CalibrationForm(this);
            CaliForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Location = new System.Drawing.Point(100, 100);
            btn.Name = "dyn_BTN";
            btn.Size = new System.Drawing.Size(193, 61);
            btn.TabIndex = 100;
            btn.Text = "dyn_BTN";
            btn.UseVisualStyleBackColor = true;
            //btn.Click += new System.EventHandler(this.dyn_BTN_Click);
            this.Controls.Add(btn);
            this.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void BackgroundThread()
        {
            int runs = 0;
            while (true)
            {
                while (!_backgroundPause)
                {
                    Thread.Sleep(250);
                    runs++;
                    mainThread.Send((object state) =>
                    {
                        //txtReceiveBox.AppendText("[" + get_dtn() + "] " + "background thread: working... " + runs + "\n");
                    
                    }, null);
                    if ((runs % 5 == 0) && (wireless_Flag == true)){
                        send_command((byte)CMDs.CMD_RSSI, 1, 0);
                        runs = 0;
                    }
                    else
                        send_command((byte)CMDs.CMD_MOIS, 1, 0);
                    //_backgroundPause = true;
                }
                Console.WriteLine("worker thread: terminating gracefully.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_backgroundPause == true)
                _backgroundPause = false;
            else
                _backgroundPause = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            send_command((byte)CMDs.CMD_DRY, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            send_command((byte)CMDs.CMD_WET, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            send_command((byte)CMDs.CMD_MIN, 0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            send_command((byte)CMDs.CMD_MAX, 0, 0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                Form.ActiveForm.Width = 525;
            else
                Form.ActiveForm.Width = 161;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form frm = sender as Form;
            frm.Width = 161;
        }

        private void Form1_FormClosing(object sender, FormClosedEventHandler e)
        {
        }

        private void comPort_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comPort_comboBox_DropDown(object sender, EventArgs e)
        {
            comPort_comboBox.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
                comPort_comboBox.Items.Add(s);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            disconBTN_Click(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi_err;
        }
    }
}