namespace GlassViewer.Forms
{
    partial class FormGlassViewSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtImageFolderPath = new System.Windows.Forms.TextBox();
            this.btnSettingPath = new System.Windows.Forms.Button();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDefectViewSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Folder Path ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImageFolderPath
            // 
            this.txtImageFolderPath.Location = new System.Drawing.Point(139, 13);
            this.txtImageFolderPath.Name = "txtImageFolderPath";
            this.txtImageFolderPath.ReadOnly = true;
            this.txtImageFolderPath.Size = new System.Drawing.Size(247, 21);
            this.txtImageFolderPath.TabIndex = 1;
            // 
            // btnSettingPath
            // 
            this.btnSettingPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSettingPath.Location = new System.Drawing.Point(393, 13);
            this.btnSettingPath.Name = "btnSettingPath";
            this.btnSettingPath.Size = new System.Drawing.Size(30, 23);
            this.btnSettingPath.TabIndex = 2;
            this.btnSettingPath.Text = "...";
            this.btnSettingPath.UseVisualStyleBackColor = true;
            this.btnSettingPath.Click += new System.EventHandler(this.btnSettingPath_Click);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSavePath.Location = new System.Drawing.Point(348, 46);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(75, 23);
            this.btnSavePath.TabIndex = 3;
            this.btnSavePath.Text = "Save";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Defect View Size";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDefectViewSize
            // 
            this.txtDefectViewSize.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefectViewSize.Location = new System.Drawing.Point(139, 51);
            this.txtDefectViewSize.Name = "txtDefectViewSize";
            this.txtDefectViewSize.Size = new System.Drawing.Size(24, 21);
            this.txtDefectViewSize.TabIndex = 5;
            this.txtDefectViewSize.Text = "1";
            this.txtDefectViewSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDefectViewSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDefectImageRatio_KeyPress);
            // 
            // FormGlassViewSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 81);
            this.Controls.Add(this.txtDefectViewSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.btnSettingPath);
            this.Controls.Add(this.txtImageFolderPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormGlassViewSettings";
            this.Text = "Config";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGlassViewSettings_FormClosed);
            this.Load += new System.EventHandler(this.FormGlassViewSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSettingPath;
        private System.Windows.Forms.Button btnSavePath;
        public System.Windows.Forms.TextBox txtImageFolderPath;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtDefectViewSize;
    }
}