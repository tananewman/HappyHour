using System.Drawing;

namespace EventAttendanceApp
{
    partial class EventAttendanceForm
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
			this.pbLogo = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.LblScanBadge = new System.Windows.Forms.Label();
			this.lblWelcome = new System.Windows.Forms.Label();
			this.acceptBtn = new System.Windows.Forms.Button();
			this.pbPicture = new EventAttendanceApp.OvalPictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// pbLogo
			// 
			this.pbLogo.Image = global::EventAttendanceApp.Properties.Resources._1800contactslogo2;
			this.pbLogo.Location = new System.Drawing.Point(404, 44);
			this.pbLogo.Name = "pbLogo";
			this.pbLogo.Size = new System.Drawing.Size(314, 50);
			this.pbLogo.TabIndex = 0;
			this.pbLogo.TabStop = false;
			// 
			// LblScanBadge
			// 
			this.LblScanBadge.AutoSize = true;
			this.LblScanBadge.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblScanBadge.Location = new System.Drawing.Point(278, 222);
			this.LblScanBadge.Name = "LblScanBadge";
			this.LblScanBadge.Size = new System.Drawing.Size(597, 73);
			this.LblScanBadge.TabIndex = 8;
			this.LblScanBadge.Text = "Please Scan Badge";
			// 
			// lblWelcome
			// 
			this.lblWelcome.AutoSize = true;
			this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWelcome.Location = new System.Drawing.Point(394, 145);
			this.lblWelcome.Name = "lblWelcome";
			this.lblWelcome.Size = new System.Drawing.Size(355, 55);
			this.lblWelcome.TabIndex = 8;
			this.lblWelcome.Text = "Welcome Label";
			// 
			// acceptBtn
			// 
	        this.acceptBtn.BackColor = System.Drawing.Color.DarkOrange;
			this.acceptBtn.Location = new System.Drawing.Point(392, 724);
			this.acceptBtn.Name = "acceptBtn";
			this.acceptBtn.Size = new System.Drawing.Size(370, 64);
			this.acceptBtn.TabIndex = 10;
			this.acceptBtn.Text = "Accept";
			this.acceptBtn.UseVisualStyleBackColor = false;
			this.acceptBtn.Click += new System.EventHandler(this.button1_Click);
	        this.acceptBtn.Font = new Font("Arial", 24, FontStyle.Bold);
	        this.acceptBtn.ForeColor = Color.White;
			// 
			// pbPicture
			// 
			this.pbPicture.BackColor = System.Drawing.Color.DarkGray;
			this.pbPicture.Location = new System.Drawing.Point(392, 298);
			this.pbPicture.Name = "pbPicture";
			this.pbPicture.Size = new System.Drawing.Size(370, 372);
			this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbPicture.TabIndex = 9;
			this.pbPicture.TabStop = false;
			// 
			// EventAttendanceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Highlight;
			this.ClientSize = new System.Drawing.Size(1293, 927);
			this.Controls.Add(this.pbPicture);
			this.Controls.Add(this.lblWelcome);
			this.Controls.Add(this.LblScanBadge);
			this.Controls.Add(this.pbLogo);
			this.Controls.Add(this.acceptBtn);
			this.Name = "EventAttendanceForm";
			this.Text = "1-800 Contacts Happy Hour Verifier";
			this.Load += new System.EventHandler(this.EventAttendanceForm_Load);
			this.Resize += new System.EventHandler(this.EventAttendanceForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LblScanBadge;
        private System.Windows.Forms.Label lblWelcome;
        private OvalPictureBox pbPicture;

		private System.Windows.Forms.Button acceptBtn;
	}
}

