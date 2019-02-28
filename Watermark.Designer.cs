namespace Caesar_TestFaker
{
    partial class Watermark
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
            this.key_checker = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // key_checker
            // 
            this.key_checker.Interval = 1;
            this.key_checker.Tick += new System.EventHandler(this.key_checker_Tick);
            // 
            // Watermark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Watermark";
            this.Text = "Watermark";
            this.Load += new System.EventHandler(this.Watermark_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer key_checker;
    }
}