namespace WindowsFormsApp1
{
    partial class _FrmWorkStandard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.srcPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.srcPictureBox)).BeginInit();
            this.SuspendLayout();

            this.srcPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.srcPictureBox.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.srcPictureBox.Location    = new System.Drawing.Point(0, 0);
            this.srcPictureBox.Name        = "srcPictureBox";
            this.srcPictureBox.Size        = new System.Drawing.Size(558, 359);
            this.srcPictureBox.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.srcPictureBox.TabIndex    = 1;
            this.srcPictureBox.TabStop     = false;
            this.srcPictureBox.Click      += new System.EventHandler(this.srcPictureBox_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(558, 359);
            this.Controls.Add(this.srcPictureBox);
            this.Font                = new System.Drawing.Font("Arial Narrow", 9F);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Location            = new System.Drawing.Point(-2500, 0);
            this.Name                = "_FrmWorkStandard";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.Manual;
            this.Text                = "작업표준서";

            ((System.ComponentModel.ISupportInitialize)(this.srcPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.PictureBox srcPictureBox;
    }
}
