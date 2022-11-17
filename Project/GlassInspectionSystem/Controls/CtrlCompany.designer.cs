namespace GlassInspectionSystem.Controls
{
    partial class CtrlCompany
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
            this.pbxCompanyImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCompanyImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxCompanyImage
            // 
            this.pbxCompanyImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxCompanyImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxCompanyImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxCompanyImage.InitialImage = null;
            this.pbxCompanyImage.Location = new System.Drawing.Point(0, 0);
            this.pbxCompanyImage.Name = "pbxCompanyImage";
            this.pbxCompanyImage.Size = new System.Drawing.Size(279, 139);
            this.pbxCompanyImage.TabIndex = 0;
            this.pbxCompanyImage.TabStop = false;
            // 
            // CtrlCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbxCompanyImage);
            this.Name = "CtrlCompany";
            this.Size = new System.Drawing.Size(279, 139);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCompanyImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxCompanyImage;
    }
}
