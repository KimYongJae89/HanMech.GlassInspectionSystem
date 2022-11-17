namespace GlassInspectionSystem.Controls
{
    partial class CtrlDailyInformation
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblDailyInformation = new System.Windows.Forms.Label();
            this.lblDailyNgCount = new System.Windows.Forms.Label();
            this.lblDailyCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerDayChange = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.lblDailyInformation);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lblDailyNgCount);
            this.splitContainer.Panel2.Controls.Add(this.lblDailyCount);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Size = new System.Drawing.Size(538, 84);
            this.splitContainer.SplitterDistance = 30;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.TabStop = false;
            // 
            // lblDailyInformation
            // 
            this.lblDailyInformation.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblDailyInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDailyInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyInformation.Location = new System.Drawing.Point(0, 0);
            this.lblDailyInformation.Margin = new System.Windows.Forms.Padding(3);
            this.lblDailyInformation.Name = "lblDailyInformation";
            this.lblDailyInformation.Size = new System.Drawing.Size(538, 30);
            this.lblDailyInformation.TabIndex = 0;
            this.lblDailyInformation.Text = "Daily Information";
            this.lblDailyInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDailyNgCount
            // 
            this.lblDailyNgCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDailyNgCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyNgCount.Location = new System.Drawing.Point(404, 11);
            this.lblDailyNgCount.Name = "lblDailyNgCount";
            this.lblDailyNgCount.Size = new System.Drawing.Size(85, 23);
            this.lblDailyNgCount.TabIndex = 4;
            this.lblDailyNgCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDailyCount
            // 
            this.lblDailyCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDailyCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyCount.Location = new System.Drawing.Point(126, 11);
            this.lblDailyCount.Name = "lblDailyCount";
            this.lblDailyCount.Size = new System.Drawing.Size(85, 23);
            this.lblDailyCount.TabIndex = 3;
            this.lblDailyCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(276, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Daily NG Count";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Daily Count";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerDayChange
            // 
            this.timerDayChange.Tick += new System.EventHandler(this.timerDayChange_Tick);
            // 
            // CtrlDailyInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer);
            this.Name = "CtrlDailyInformation";
            this.Size = new System.Drawing.Size(538, 84);
            this.Load += new System.EventHandler(this.CtrlDailyInformation_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblDailyInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDailyNgCount;
        private System.Windows.Forms.Label lblDailyCount;
        private System.Windows.Forms.Timer timerDayChange;
    }
}
