namespace GlassInspectionSystem.Controls
{
    partial class CtrlGlassMap
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblGlassMap = new System.Windows.Forms.Label();
            this.pbxMapImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMapImage)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel1.Controls.Add(this.lblGlassMap);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pbxMapImage);
            this.splitContainer.Size = new System.Drawing.Size(464, 407);
            this.splitContainer.SplitterDistance = 30;
            this.splitContainer.TabIndex = 1;
            this.splitContainer.TabStop = false;
            // 
            // lblGlassMap
            // 
            this.lblGlassMap.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblGlassMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGlassMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlassMap.Location = new System.Drawing.Point(0, 0);
            this.lblGlassMap.Margin = new System.Windows.Forms.Padding(3);
            this.lblGlassMap.Name = "lblGlassMap";
            this.lblGlassMap.Size = new System.Drawing.Size(464, 30);
            this.lblGlassMap.TabIndex = 0;
            this.lblGlassMap.Text = "Glass Map";
            this.lblGlassMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGlassMap.Paint += new System.Windows.Forms.PaintEventHandler(this.lblDailyInformation_Paint);
            // 
            // pbxMapImage
            // 
            this.pbxMapImage.BackColor = System.Drawing.Color.Black;
            this.pbxMapImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxMapImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxMapImage.Location = new System.Drawing.Point(0, 0);
            this.pbxMapImage.Name = "pbxMapImage";
            this.pbxMapImage.Size = new System.Drawing.Size(464, 373);
            this.pbxMapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxMapImage.TabIndex = 0;
            this.pbxMapImage.TabStop = false;
            // 
            // CtrlGlassMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CtrlGlassMap";
            this.Size = new System.Drawing.Size(464, 407);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMapImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblGlassMap;
        private System.Windows.Forms.PictureBox pbxMapImage;
    }
}
