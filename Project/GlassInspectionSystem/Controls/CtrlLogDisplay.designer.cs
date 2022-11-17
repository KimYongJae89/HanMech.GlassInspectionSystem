namespace GlassInspectionSystem.Controls
{
    partial class CtrlLogDisplay
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
            this.lbxLogMessage = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLogMessage = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblLog = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxLogMessage
            // 
            this.lbxLogMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxLogMessage.FormattingEnabled = true;
            this.lbxLogMessage.HorizontalScrollbar = true;
            this.lbxLogMessage.ItemHeight = 12;
            this.lbxLogMessage.Location = new System.Drawing.Point(0, 0);
            this.lbxLogMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lbxLogMessage.Name = "lbxLogMessage";
            this.lbxLogMessage.Size = new System.Drawing.Size(538, 284);
            this.lbxLogMessage.TabIndex = 0;
            this.lbxLogMessage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxLogMessage_MouseDoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbxLogMessage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLogMessage, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(538, 314);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtLogMessage
            // 
            this.txtLogMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogMessage.Location = new System.Drawing.Point(0, 289);
            this.txtLogMessage.Margin = new System.Windows.Forms.Padding(0);
            this.txtLogMessage.Name = "txtLogMessage";
            this.txtLogMessage.Size = new System.Drawing.Size(538, 21);
            this.txtLogMessage.TabIndex = 1;
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
            this.splitContainer.Panel1.Controls.Add(this.lblLog);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer.Size = new System.Drawing.Size(538, 348);
            this.splitContainer.SplitterDistance = 30;
            this.splitContainer.TabIndex = 2;
            this.splitContainer.TabStop = false;
            // 
            // lblLog
            // 
            this.lblLog.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(0, 0);
            this.lblLog.Margin = new System.Windows.Forms.Padding(3);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(538, 30);
            this.lblLog.TabIndex = 0;
            this.lblLog.Text = "Log";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlLogDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CtrlLogDisplay";
            this.Size = new System.Drawing.Size(538, 348);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbxLogMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLogMessage;
    }
}
