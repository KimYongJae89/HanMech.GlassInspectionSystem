namespace GlassInspectionSystem.Forms
{
    partial class FormDisplayDefect
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
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pbxDisplay = new System.Windows.Forms.PictureBox();
            this.pnlDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.pbxDisplay);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(800, 450);
            this.pnlDisplay.TabIndex = 0;
            // 
            // pbxDisplay
            // 
            this.pbxDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxDisplay.Location = new System.Drawing.Point(0, 0);
            this.pbxDisplay.Name = "pbxDisplay";
            this.pbxDisplay.Size = new System.Drawing.Size(800, 450);
            this.pbxDisplay.TabIndex = 0;
            this.pbxDisplay.TabStop = false;
            // 
            // FormDisplayDefect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlDisplay);
            this.Name = "FormDisplayDefect";
            this.Text = "FormDisplayDefect";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDisplayDefect_FormClosed);
            this.Load += new System.EventHandler(this.FormDisplayDefect_Load);
            this.pnlDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.PictureBox pbxDisplay;
    }
}