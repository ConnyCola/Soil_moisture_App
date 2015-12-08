using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Soil_moisture_App
{
    public partial class CalibrationForm : Form
    {
        enum FormComModes 
        {   CaliStart,
            CaliDry,
            CaliWet,
            CaliFin,
            CaliError,
            CaliEnd
        };

        public String[] headerInstArray = {
            "Click Next for calibrating the Sensor",
            "Keep the Sensor dry and click Next",
            "Put the Sensor in water and click Next",
            "You finished the calibration process!",
            "Error!"
            };
        public String[] InstArray = {
            "Start the calibration process by clicking on the Next button below",
            "Keep the Sensor dry and click Next",
            "Put the Sensor in water and click Next",
            "You finished the calibration process!",
            "An Error occurred during calibration! The values are out of range"
            };
        public byte Mode = (byte)FormComModes.CaliStart;
        private Form1 mainForm = null;
        public CalibrationForm(Form callingForm)
        {
            mainForm = callingForm as Form1; 
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.SensorGlasCali;
            headerInstBox.Text = headerInstArray[Mode];
            instructionBox.Text = InstArray[Mode];
        }

        private void continueBTN_Click(object sender, EventArgs e)
        {
            byte m = (byte)Mode;
            continueBTN.Enabled = false;
            continueBTN.Refresh();
            mainForm.CaliFormCallback( m );
        }

        public void changeContext(byte m){
            if (m == (byte)FormComModes.CaliDry)
                pictureBox1.Image = Properties.Resources.SensorNoGlas;
            else if (m == (byte)FormComModes.CaliWet)
                pictureBox1.Image = Properties.Resources.SensorGlas;
            else if (m == (byte)FormComModes.CaliFin)
            {
                continueBTN.Text = "Finish";
                pictureBox1.Image = Properties.Resources.SensorGlasFin;
            }
            else if (m == (byte)FormComModes.CaliError)
            {
                continueBTN.Text = "Close";
                pictureBox1.Image = Properties.Resources.SensorGlasError;
            }

            Mode = m;
            pictureBox1.Refresh();
            headerInstBox.Text = headerInstArray[Mode];
            instructionBox.Text = InstArray[Mode];
            continueBTN.Enabled = true;
            continueBTN.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CalibrationForm_Load(object sender, EventArgs e)
        {
        }

        private void CalibrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.CaliFormCallback((byte)FormComModes.CaliEnd);
        }


    }
}
