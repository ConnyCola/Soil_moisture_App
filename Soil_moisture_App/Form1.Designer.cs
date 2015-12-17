namespace Soil_moisture_App
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.conBTN = new System.Windows.Forms.Button();
            this.disconBTN = new System.Windows.Forms.Button();
            this.caliBTN = new System.Windows.Forms.Button();
            this.comPort_comboBox = new System.Windows.Forms.ComboBox();
            this.sendBTN = new System.Windows.Forms.Button();
            this.txtReceiveBox = new System.Windows.Forms.TextBox();
            this.txtDataSendBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maxMoisLab = new System.Windows.Forms.Label();
            this.minMoisLab = new System.Windows.Forms.Label();
            this.moisVoltLab = new System.Windows.Forms.Label();
            this.moisLab = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // conBTN
            // 
            this.conBTN.Location = new System.Drawing.Point(12, 62);
            this.conBTN.Name = "conBTN";
            this.conBTN.Size = new System.Drawing.Size(116, 58);
            this.conBTN.TabIndex = 0;
            this.conBTN.Text = "Connect";
            this.conBTN.UseVisualStyleBackColor = true;
            this.conBTN.Click += new System.EventHandler(this.conBTN_Click);
            // 
            // disconBTN
            // 
            this.disconBTN.Location = new System.Drawing.Point(134, 62);
            this.disconBTN.Name = "disconBTN";
            this.disconBTN.Size = new System.Drawing.Size(155, 58);
            this.disconBTN.TabIndex = 1;
            this.disconBTN.Text = "Disconnect";
            this.disconBTN.UseVisualStyleBackColor = true;
            this.disconBTN.Click += new System.EventHandler(this.disconBTN_Click);
            // 
            // caliBTN
            // 
            this.caliBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.17801F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caliBTN.Location = new System.Drawing.Point(12, 126);
            this.caliBTN.Name = "caliBTN";
            this.caliBTN.Size = new System.Drawing.Size(277, 95);
            this.caliBTN.TabIndex = 2;
            this.caliBTN.Text = "Calibrate";
            this.caliBTN.UseVisualStyleBackColor = true;
            this.caliBTN.Click += new System.EventHandler(this.caliBTN_Click);
            // 
            // comPort_comboBox
            // 
            this.comPort_comboBox.FormattingEnabled = true;
            this.comPort_comboBox.Location = new System.Drawing.Point(12, 12);
            this.comPort_comboBox.Name = "comPort_comboBox";
            this.comPort_comboBox.Size = new System.Drawing.Size(277, 33);
            this.comPort_comboBox.TabIndex = 3;
            this.comPort_comboBox.DropDown += new System.EventHandler(this.comPort_comboBox_DropDown);
            this.comPort_comboBox.SelectedIndexChanged += new System.EventHandler(this.comPort_comboBox_SelectedIndexChanged);
            // 
            // sendBTN
            // 
            this.sendBTN.Location = new System.Drawing.Point(817, 185);
            this.sendBTN.Name = "sendBTN";
            this.sendBTN.Size = new System.Drawing.Size(193, 61);
            this.sendBTN.TabIndex = 4;
            this.sendBTN.Text = "SEND test ";
            this.sendBTN.UseVisualStyleBackColor = true;
            this.sendBTN.Click += new System.EventHandler(this.sendBTN_Click);
            // 
            // txtReceiveBox
            // 
            this.txtReceiveBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReceiveBox.Font = new System.Drawing.Font("Consolas", 7.916231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveBox.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtReceiveBox.Location = new System.Drawing.Point(336, 13);
            this.txtReceiveBox.Multiline = true;
            this.txtReceiveBox.Name = "txtReceiveBox";
            this.txtReceiveBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiveBox.Size = new System.Drawing.Size(674, 166);
            this.txtReceiveBox.TabIndex = 5;
            // 
            // txtDataSendBox
            // 
            this.txtDataSendBox.Location = new System.Drawing.Point(336, 185);
            this.txtDataSendBox.Name = "txtDataSendBox";
            this.txtDataSendBox.Size = new System.Drawing.Size(475, 31);
            this.txtDataSendBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.maxMoisLab);
            this.groupBox1.Controls.Add(this.minMoisLab);
            this.groupBox1.Controls.Add(this.moisVoltLab);
            this.groupBox1.Controls.Add(this.moisLab);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.916231F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 213);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Values";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar1.Location = new System.Drawing.Point(0, 201);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeftLayout = true;
            this.progressBar1.Size = new System.Drawing.Size(277, 16);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 35);
            this.label4.TabIndex = 0;
            this.label4.Text = "max:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(60, 35);
            this.label3.TabIndex = 0;
            this.label3.Text = "min:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "volt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "moist";
            // 
            // maxMoisLab
            // 
            this.maxMoisLab.AutoSize = true;
            this.maxMoisLab.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxMoisLab.Location = new System.Drawing.Point(193, 172);
            this.maxMoisLab.Name = "maxMoisLab";
            this.maxMoisLab.Size = new System.Drawing.Size(53, 35);
            this.maxMoisLab.TabIndex = 0;
            this.maxMoisLab.Text = "00 ";
            // 
            // minMoisLab
            // 
            this.minMoisLab.AutoSize = true;
            this.minMoisLab.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minMoisLab.Location = new System.Drawing.Point(75, 172);
            this.minMoisLab.Name = "minMoisLab";
            this.minMoisLab.Size = new System.Drawing.Size(45, 35);
            this.minMoisLab.TabIndex = 0;
            this.minMoisLab.Text = "00";
            // 
            // moisVoltLab
            // 
            this.moisVoltLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moisVoltLab.Font = new System.Drawing.Font("Segoe Print", 18.09424F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moisVoltLab.Location = new System.Drawing.Point(87, 88);
            this.moisVoltLab.Name = "moisVoltLab";
            this.moisVoltLab.Size = new System.Drawing.Size(178, 80);
            this.moisVoltLab.TabIndex = 0;
            this.moisVoltLab.Text = "--";
            this.moisVoltLab.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // moisLab
            // 
            this.moisLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moisLab.Font = new System.Drawing.Font("Segoe Print", 18.09424F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moisLab.Location = new System.Drawing.Point(87, 25);
            this.moisLab.Name = "moisLab";
            this.moisLab.Size = new System.Drawing.Size(178, 80);
            this.moisLab.TabIndex = 0;
            this.moisLab.Text = "--";
            this.moisLab.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(817, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 133);
            this.button1.TabIndex = 8;
            this.button1.Text = "CMD_TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(594, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(217, 133);
            this.button2.TabIndex = 9;
            this.button2.Text = "RUN/PAUSE UPDATE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(396, 344);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 43);
            this.button3.TabIndex = 10;
            this.button3.Text = "DRY";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(495, 344);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 43);
            this.button4.TabIndex = 10;
            this.button4.Text = "WET";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(396, 415);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 43);
            this.button5.TabIndex = 1;
            this.button5.Text = "min";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(495, 415);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 43);
            this.button6.TabIndex = 1;
            this.button6.Text = "max";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 227);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 30);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "expert mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "set";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "get";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Soil_moisture_App.Properties.Resources.wifi_0;
            this.pictureBox1.Location = new System.Drawing.Point(220, 226);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 503);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDataSendBox);
            this.Controls.Add(this.txtReceiveBox);
            this.Controls.Add(this.sendBTN);
            this.Controls.Add(this.comPort_comboBox);
            this.Controls.Add(this.caliBTN);
            this.Controls.Add(this.disconBTN);
            this.Controls.Add(this.conBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Soil moisture App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button conBTN;
        private System.Windows.Forms.Button disconBTN;
        private System.Windows.Forms.Button caliBTN;
        private System.Windows.Forms.ComboBox comPort_comboBox;
        private System.Windows.Forms.Button sendBTN;
        private System.Windows.Forms.TextBox txtReceiveBox;
        private System.Windows.Forms.TextBox txtDataSendBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label moisLab;
        private System.Windows.Forms.Label maxMoisLab;
        private System.Windows.Forms.Label minMoisLab;
        private System.Windows.Forms.Label moisVoltLab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

