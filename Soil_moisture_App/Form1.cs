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

        public string[] cmdArray = {
            "CMD 1",
            "CMD 2",
            "..."
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



        public Thread bgThread = null;

        public Form1()
        {
            InitializeComponent();
            disconBTN.Enabled = false;
            caliBTN.Enabled = false;
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
                comPort_comboBox.Items.Add(s);

            //debug code
            if (comPort_comboBox.Items.Contains("COM15"))
                comPort_comboBox.Text = "COM15";

            moisLab.Text = "--%";
            moisVoltLab.Text = "--V";

            mainThread = SynchronizationContext.Current;
            if (mainThread == null) mainThread = new SynchronizationContext();

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            disconBTN_Click(null, null);
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
            byte[] b = new byte[3];
            b[0] = cmd;
            b[1] = val1;
            b[2] = val2;
            //sport.Write(b, 0, 3);

            //send only 1 char!
            sport.Write(b, 0, 1);

            mainThread.Send((object state) =>
            {
                txtReceiveBox.AppendText("[" + get_dtn() + "] " + "cmd: " + Convert.ToChar(cmd) + "  val1: " + val1.ToString() + "  val2: " + val2.ToString() + "\n");
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

        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String str = sport.ReadLine();

            cmdStruct cmdBack = decodeReceivedCmd(str);
            mainThread.Send((object state) =>
            {
                processReceivedCmd(cmdBack);
                txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Received: cmd: " + Convert.ToChar(cmdBack.cmd) + "  val1: " + cmdBack.val1.ToString() + "  val2: " + cmdBack.val2.ToString() + "\n");
            }, null);
        }

        private cmdStruct decodeReceivedCmd(string str)
        {
            // Protocoll
            // |  CMD  |  val1 |  val2 |  \n  |
            // |  byte |  byte |  byte | byte |
            // 
            cmdStruct cmdBack = new cmdStruct();

            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);

            cmdBack.cmd = bytes[0];
            if (str.Length >= 6)
            cmdBack.val1 = Int16.Parse( str.Substring(1, 4));
            if(str.Length >=10)
                cmdBack.val2 = Int16.Parse( str.Substring(6, 4));
            return cmdBack;
        }

        private void processReceivedCmd(cmdStruct c)
        {
            switch (c.cmd)
            {
                case (byte)CMDs.CMD_MOIS:
                    moisLab.Text = c.val1.ToString() + "%";
                    break;
                case (byte)CMDs.CMD_VOLT:
                    moisVoltLab.Text = c.val1.ToString();
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
                    if ((c.val1 >= 0) & (c.val1 <= 1024))
                        CaliForm.changeContext((byte)FormComModes.CaliWet);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_WET:
                    if ((c.val1 >= 0) & (c.val1 <= 1024))
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
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "SoilMoisture Sensor" + "\n");
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Software VERSION : " + c.val1.ToString() + "\n");
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "         BUILT   : " + c.val2.ToString() + "\n");

                    break;
                default:
                    break;
            }
        }




        private void conBTN_Click(object sender, EventArgs e)
        {
            String port = comPort_comboBox.Text;
            int baudrate = 9600;
            Parity parity = System.IO.Ports.Parity.None;
            int databits = 8;
            StopBits stopbits = System.IO.Ports.StopBits.One;
            
            serialport_connect(port, baudrate, parity, databits, stopbits);

            send_command((byte)CMDs.CMD_VERS, 0, 0);
            Thread.Sleep(300);
            send_command((byte)CMDs.CMD_MIN, 0, 0);
            Thread.Sleep(300);
            send_command((byte)CMDs.CMD_MAX, 0, 0);
            Thread.Sleep(300);

            send_command((byte)CMDs.CMD_MOIS, 0, 0);
            Thread.Sleep(300);
            //Thread.Sleep(1000);
            //_backgroundPause = false;


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
            bgThread.Abort();

            if (sport.IsOpen)
            {
                sport.Close();
                disconBTN.Enabled = false;
                caliBTN.Enabled = false;
                conBTN.Enabled = true;
                txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Disconnected\n");
            }
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
            //_backgroundPause = true;
            send_command((byte)'I', 0, 0);
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
                    Thread.Sleep(500);
                    mainThread.Send((object state) =>
                    {
                        txtReceiveBox.AppendText("[" + get_dtn() + "] " + "background thread: working... " + runs++ + "\n");
                    }, null); 
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

    }
}



