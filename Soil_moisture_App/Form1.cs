#define DEMO

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
    public struct cmdStruct
    {
        public byte cmd, val1, val2;
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
            public byte val1;
            public byte val2;
        } ;

        enum FormComModes : byte
        {   CaliStart,
            CaliDry,
            CaliWet,
            CaliFin,
            CaliError,
            CaliEnd
        };

        enum CMDs : byte
        {   CMD_MOIS = (byte)'A',
            CMD_VOLT = (byte)'B',
            CMD_MIN,
            CMD_MAX,
            CMD_CALI,
            CMD_DRY,
            CMD_WET,
            CMD_FIN,
            CMD_TEST,
            CMD_VERS,
            CMD_ERROR
        }

        public Form1()
        {
            InitializeComponent();
            disconBTN.Enabled = false;
            caliBTN.Enabled = false;
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
                comPort_comboBox.Items.Add(s);

            //debug code
            if (comPort_comboBox.Items.Contains("COM2"))
                comPort_comboBox.Text = "COM2";

            moisLab.Text = "55%";
            moisVoltLab.Text = "2,1V";
            minMoisLab.Text = "min: 0,82";
            maxMoisLab.Text = "max: 2,30";

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
                    Thread t = new Thread(new ThreadStart(BackgroundThread));
                    t.IsBackground = true;
                    t.Start();
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Background Thread started\n");
                    _backgroundPause = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error"); }}

            
        }

        public void send_command(byte cmd, byte val1, byte val2)
        {
            byte[] b = new byte[3];
            b[0] = cmd;
            b[1] = val1;
            b[2] = val2;
            sport.Write(b, 0, 3);

            mainThread.Send((object state) =>
            {
                txtReceiveBox.AppendText("[" + get_dtn() + "] " + "cmd: " + cmd.ToString() + "  val1: " + val1.ToString() + "  val2: " + val2.ToString() + "\n");
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
                Thread.Sleep(2000);
                #if DEMO
                CaliForm.changeContext((byte)FormComModes.CaliDry);
                #endif
            }
            else if (m == (byte)FormComModes.CaliDry)
            {
                send_command((byte)CMDs.CMD_DRY, 1, 0);
                Thread.Sleep(2000);
                #if DEMO
                CaliForm.changeContext((byte)FormComModes.CaliWet);
                #endif
            }
            else if (m == (byte)FormComModes.CaliWet)
            {
                send_command((byte)CMDs.CMD_WET, 1, 0);
                Thread.Sleep(2000);
                bool result = false;
                if (result)
                {
                    #if DEMO
                    CaliForm.changeContext((byte)FormComModes.CaliFin);
                    #endif
                    _backgroundPause = false;
                }
                else
                {
                    #if DEMO
                    CaliForm.changeContext((byte)FormComModes.CaliError);
                    #endif
                    _backgroundPause = false;
                }

            }
            else if ((m == (byte)FormComModes.CaliFin) || (m == (byte)FormComModes.CaliError))
                CaliForm.Close();

        }

        private cmdStruct decodeReceivedCmd(string str)
        {
            // Protocoll
            // |  CMD  |  val1 |  val2 |  \n  |
            // |  byte |  byte |  byte | byte |
            // 
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            cmdStruct cmdBack = new cmdStruct();
            cmdBack.cmd = bytes[0];
            cmdBack.val1 = bytes[1];
            cmdBack.val2 = bytes[2];
            return cmdBack;
        }

        private void processReceivedCmd(cmdStruct c)
        {
            switch (c.cmd)
            {
                case (byte)CMDs.CMD_MOIS:
                    moisLab.Text = Convert.ToString((c.val1 << 8) + c.val2);
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + " received MOIS" + "\n");

                    break;
                case (byte)CMDs.CMD_VOLT:
                    moisVoltLab.Text = Convert.ToString((int)((byte)((c.val1 << 8) + c.val2)) / 100);
                    break;
                case (byte)CMDs.CMD_MIN:
                    minMoisLab.Text = Convert.ToString((int)((byte)((c.val1 << 8) + c.val2))/100);
                    break;
                case (byte)CMDs.CMD_MAX:
                    maxMoisLab.Text = Convert.ToString((int)((byte)((c.val1 << 8) + c.val2)) / 100);
                    break;
                case (byte)CMDs.CMD_CALI:
                    if((byte)c.val1 == 1)
                        CaliForm.changeContext((byte)FormComModes.CaliDry);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_DRY:
                    if ((byte)c.val1 == 1)
                        CaliForm.changeContext((byte)FormComModes.CaliWet);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_WET:
                    if ((byte)c.val1 == 1)
                        CaliForm.changeContext((byte)FormComModes.CaliFin);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_TEST:
                    moisLab.Text = Convert.ToString((int)((byte)((c.val1 << 8) + c.val2)) / 100);
                    txtReceiveBox.AppendText("[" + get_dtn() + "] " + " received TEST" + "\n");
                    _backgroundPause = false;
                    break;
                    /*
                case (byte)CMDs.CMD_FIN:
                    if ((byte)c.val1 == 1)
                        CaliForm.changePic((byte)FormComModes.CaliFin);
                    else
                        CaliForm.changePic((byte)FormComModes.CaliError);
                    break;
                     * */
                default:
                    break;
            }
        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String str = sport.ReadExisting();

            cmdStruct cmdBack = decodeReceivedCmd(str);
            mainThread.Send((object state) =>
            {
                processReceivedCmd(cmdBack);
                txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Received: cmd: " + cmdBack.cmd.ToString() + "  val1: " + cmdBack.val1.ToString() + "  val2: " + cmdBack.val2.ToString() + "\n");
            }, null);
        }


        private void conBTN_Click(object sender, EventArgs e)
        {
            String port = comPort_comboBox.Text;
            int baudrate = 9600;
            Parity parity = System.IO.Ports.Parity.None;
            int databits = 8;
            StopBits stopbits = System.IO.Ports.StopBits.One;
            
            serialport_connect(port, baudrate, parity, databits, stopbits);
            byte[] c = new byte[4];
            c[0] = (byte)'t';
            c[1] = (byte)'e';
            c[2] = (byte)'s';
            c[3] = (byte)'t';

            sport.Write(c,0,c.Count());
            //send_command((byte)'A', (byte)'A', (byte)'a');
        }

        private void sendBTN_Click(object sender, EventArgs e)
        {
            String data = txtDataSendBox.Text;
            sport.Write(data);
            txtReceiveBox.AppendText("[" + get_dtn() + "] " + "Sent: " + data + "\n");
        }

        private void disconBTN_Click(object sender, EventArgs e)
        {
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
            byte[] a = new byte[1];
            a[0] = 40;
            //button1.Text = a;
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
                    Thread.Sleep(5000);
                    mainThread.Send((object state) =>
                    {
                        txtReceiveBox.AppendText("[" + get_dtn() + "] " + "background thread: working... " + runs++ + "\n");
                    }, null); 
                    send_command((byte)CMDs.CMD_MOIS, 1, 0);
                    _backgroundPause = true;
                }
                Console.WriteLine("worker thread: terminating gracefully.");
            }
        }
    }
}



