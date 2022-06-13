namespace ShuffelGamePuzzel
{
    partial class ShuffelGamePuzzel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ShuffelGamePuzzel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 457);
            this.Name = "ShuffelGamePuzzel";
            this.Text = "Shuffel Game Puzzel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShuffelGamePuzzel_FormClosing);
            this.Load += new System.EventHandler(this.ShuffelGamePuzzel_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}