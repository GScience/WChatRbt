namespace WChatRbtLib
{
    partial class QRCode
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
            this.QRImage = new System.Windows.Forms.PictureBox();
            this.LoginState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QRImage)).BeginInit();
            this.SuspendLayout();
            // 
            // QRImage
            // 
            this.QRImage.Location = new System.Drawing.Point(12, 12);
            this.QRImage.Name = "QRImage";
            this.QRImage.Size = new System.Drawing.Size(260, 237);
            this.QRImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QRImage.TabIndex = 0;
            this.QRImage.TabStop = false;
            // 
            // LoginState
            // 
            this.LoginState.AutoSize = true;
            this.LoginState.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginState.Location = new System.Drawing.Point(31, 263);
            this.LoginState.Name = "LoginState";
            this.LoginState.Size = new System.Drawing.Size(222, 37);
            this.LoginState.TabIndex = 1;
            this.LoginState.Text = "等待扫码...";
            // 
            // QRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 312);
            this.Controls.Add(this.LoginState);
            this.Controls.Add(this.QRImage);
            this.Name = "QRCode";
            this.Text = "QRCode";
            ((System.ComponentModel.ISupportInitialize)(this.QRImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox QRImage;
        public System.Windows.Forms.Label LoginState;
    }
}