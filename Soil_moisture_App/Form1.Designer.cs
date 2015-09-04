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
            this.conBTN = new System.Windows.Forms.Button();
            this.disconBTN = new System.Windows.Forms.Button();
            this.caliBTN = new System.Windows.Forms.Button();
            this.comPort_comboBox = new System.Windows.Forms.ComboBox();
            this.sendBTN = new System.Windows.Forms.Button();
            this.txtReceiveBox = new System.Windows.Forms.TextBox();
            this.txtDataSendBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maxMoisLab = new System.Windows.Forms.Label();
            this.minMoisLab = new System.Windows.Forms.Label();
            this.moisVoltLab = new System.Windows.Forms.Label();
            this.moisLab = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.comPort_comboBox.Location = new System.Drawing.Point(12, 13);
            this.comPort_comboBox.Name = "comPort_comboBox";
            this.comPort_comboBox.Size = new System.Drawing.Size(277, 33);
            this.comPort_comboBox.TabIndex = 3;
            // 
            // sendBTN
            // 
            this.sendBTN.Location = new System.Drawing.Point(757, 185);
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
            this.txtReceiveBox.Size = new System.Drawing.Size(614, 166);
            this.txtReceiveBox.TabIndex = 5;
            // 
            // txtDataSendBox
            // 
            this.txtDataSendBox.Location = new System.Drawing.Point(336, 185);
            this.txtDataSendBox.Name = "txtDataSendBox";
            this.txtDataSendBox.Size = new System.Drawing.Size(415, 31);
            this.txtDataSendBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.maxMoisLab);
            this.groupBox1.Controls.Add(this.minMoisLab);
            this.groupBox1.Controls.Add(this.moisVoltLab);
            this.groupBox1.Controls.Add(this.moisLab);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.916231F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 213);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Values";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.maxMoisLab.Location = new System.Drawing.Point(138, 172);
            this.maxMoisLab.Name = "maxMoisLab";
            this.maxMoisLab.Size = new System.Drawing.Size(72, 35);
            this.maxMoisLab.TabIndex = 0;
            this.maxMoisLab.Text = "max: ";
            // 
            // minMoisLab
            // 
            this.minMoisLab.AutoSize = true;
            this.minMoisLab.Font = new System.Drawing.Font("Segoe Print", 7.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minMoisLab.Location = new System.Drawing.Point(11, 172);
            this.minMoisLab.Name = "minMoisLab";
            this.minMoisLab.Size = new System.Drawing.Size(68, 35);
            this.minMoisLab.TabIndex = 0;
            this.minMoisLab.Text = "min: ";
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
            this.button1.Location = new System.Drawing.Point(666, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(286, 133);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 480);
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
            this.Name = "Form1";
            this.Text = "Soil moisture App";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

