namespace GlassInspectionSystem.Controls
{
    partial class CtrlDrawBox
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
            this.lblCameraConnected = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnView = new System.Windows.Forms.Panel();
            this.pnImage = new System.Windows.Forms.Panel();
            this.sbScroll = new System.Windows.Forms.VScrollBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnView.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCameraConnected
            // 
            this.lblCameraConnected.AutoSize = true;
            this.lblCameraConnected.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lblCameraConnected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCameraConnected.Location = new System.Drawing.Point(1, 1);
            this.lblCameraConnected.Margin = new System.Windows.Forms.Padding(1);
            this.lblCameraConnected.Name = "lblCameraConnected";
            this.lblCameraConnected.Padding = new System.Windows.Forms.Padding(3);
            this.lblCameraConnected.Size = new System.Drawing.Size(378, 33);
            this.lblCameraConnected.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblCameraConnected, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 504);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnView
            // 
            this.pnView.Controls.Add(this.pnImage);
            this.pnView.Controls.Add(this.sbScroll);
            this.pnView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnView.Location = new System.Drawing.Point(0, 35);
            this.pnView.Margin = new System.Windows.Forms.Padding(0);
            this.pnView.Name = "pnView";
            this.pnView.Size = new System.Drawing.Size(380, 469);
            this.pnView.TabIndex = 2;
            // 
            // pnImage
            // 
            this.pnImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnImage.Location = new System.Drawing.Point(0, 0);
            this.pnImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnImage.Name = "pnImage";
            this.pnImage.Size = new System.Drawing.Size(368, 469);
            this.pnImage.TabIndex = 2;
            // 
            // sbScroll
            // 
            this.sbScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbScroll.LargeChange = 1;
            this.sbScroll.Location = new System.Drawing.Point(368, 0);
            this.sbScroll.Name = "sbScroll";
            this.sbScroll.Size = new System.Drawing.Size(12, 469);
            this.sbScroll.TabIndex = 1;
            this.sbScroll.Visible = false;
            this.sbScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbScroll_Scroll);
            // 
            // CtrlDrawBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "CtrlDrawBox";
            this.Size = new System.Drawing.Size(380, 504);
            this.Load += new System.EventHandler(this.CtrlDrawBox_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblCameraConnected;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnView;
        private System.Windows.Forms.Panel pnImage;
        private System.Windows.Forms.VScrollBar sbScroll;
    }
}
