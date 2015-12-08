namespace Soil_moisture_App
{
    partial class CalibrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationForm));
            this.continueBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.headerInstBox = new System.Windows.Forms.Label();
            this.instructionBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // continueBTN
            // 
            this.continueBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.83246F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueBTN.Location = new System.Drawing.Point(560, 751);
            this.continueBTN.Name = "continueBTN";
            this.continueBTN.Size = new System.Drawing.Size(491, 109);
            this.continueBTN.TabIndex = 1;
            this.continueBTN.Text = "Next";
            this.continueBTN.UseVisualStyleBackColor = true;
            this.continueBTN.Click += new System.EventHandler(this.continueBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(25, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 824);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // headerInstBox
            // 
            this.headerInstBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.09424F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerInstBox.Location = new System.Drawing.Point(550, 36);
            this.headerInstBox.Name = "headerInstBox";
            this.headerInstBox.Size = new System.Drawing.Size(501, 202);
            this.headerInstBox.TabIndex = 3;
            this.headerInstBox.Text = "Instruction Header";
            // 
            // instructionBox
            // 
            this.instructionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.06283F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionBox.Location = new System.Drawing.Point(553, 252);
            this.instructionBox.Name = "instructionBox";
            this.instructionBox.Size = new System.Drawing.Size(491, 481);
            this.instructionBox.TabIndex = 4;
            this.instructionBox.Text = "Instruction Box";
            // 
            // CalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 887);
            this.Controls.Add(this.instructionBox);
            this.Controls.Add(this.headerInstBox);
            this.Controls.Add(this.continueBTN);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalibrationForm";
            this.Text = "CalibrationForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalibrationForm_FormClosing);
            this.Load += new System.EventHandler(this.CalibrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button continueBTN;
        private System.Windows.Forms.Label headerInstBox;
        private System.Windows.Forms.Label instructionBox;

    }
}