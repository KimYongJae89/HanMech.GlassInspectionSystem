namespace AI.Controls
{
    partial class CtrlAIConfidence
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxAlram = new System.Windows.Forms.ComboBox();
            this.chkUseDefect = new System.Windows.Forms.CheckBox();
            this.txtConfidence = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbxAlram
            // 
            this.cbxAlram.FormattingEnabled = true;
            this.cbxAlram.Location = new System.Drawing.Point(278, 21);
            this.cbxAlram.Name = "cbxAlram";
            this.cbxAlram.Size = new System.Drawing.Size(87, 20);
            this.cbxAlram.TabIndex = 24;
            // 
            // chkUseDefect
            // 
            this.chkUseDefect.AutoSize = true;
            this.chkUseDefect.ForeColor = System.Drawing.Color.Black;
            this.chkUseDefect.Location = new System.Drawing.Point(14, 24);
            this.chkUseDefect.Name = "chkUseDefect";
            this.chkUseDefect.Size = new System.Drawing.Size(93, 16);
            this.chkUseDefect.TabIndex = 23;
            this.chkUseDefect.Text = "DefectName";
            this.chkUseDefect.UseVisualStyleBackColor = true;
            // 
            // txtConfidence
            // 
            this.txtConfidence.Location = new System.Drawing.Point(159, 21);
            this.txtConfidence.Name = "txtConfidence";
            this.txtConfidence.Size = new System.Drawing.Size(113, 21);
            this.txtConfidence.TabIndex = 22;
            this.txtConfidence.Text = "0.0";
            // 
            // CtrlAIConfidence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxAlram);
            this.Controls.Add(this.chkUseDefect);
            this.Controls.Add(this.txtConfidence);
            this.Name = "CtrlAIConfidence";
            this.Size = new System.Drawing.Size(380, 60);
            this.Load += new System.EventHandler(this.CtrlAIConfidence_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbxAlram;
        public System.Windows.Forms.CheckBox chkUseDefect;
        public System.Windows.Forms.TextBox txtConfidence;
    }
}
