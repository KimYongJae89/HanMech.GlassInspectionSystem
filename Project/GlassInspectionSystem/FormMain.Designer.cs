namespace GlassInspectionSystem
{
    partial class FormMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCompanyLog = new System.Windows.Forms.Panel();
            this.pnlCommunicationStatus = new System.Windows.Forms.Panel();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.pnlDisplayList = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInspectionStatus = new System.Windows.Forms.Panel();
            this.pnlGlassMap = new System.Windows.Forms.Panel();
            this.pnlInspectionResult = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlGlassInspectionResult = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlDefectInformation = new System.Windows.Forms.Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pnlSystemInfo = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pnlLogDisplay = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1902, 999);
            this.splitContainer1.SplitterDistance = 1416;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlDisplayList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1416, 999);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 520F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.pnlCompanyLog, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pnlCommunicationStatus, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.pnlButton, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1410, 129);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // pnlCompanyLog
            // 
            this.pnlCompanyLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCompanyLog.Location = new System.Drawing.Point(3, 3);
            this.pnlCompanyLog.Name = "pnlCompanyLog";
            this.pnlCompanyLog.Size = new System.Drawing.Size(194, 123);
            this.pnlCompanyLog.TabIndex = 0;
            // 
            // pnlCommunicationStatus
            // 
            this.pnlCommunicationStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCommunicationStatus.Location = new System.Drawing.Point(203, 3);
            this.pnlCommunicationStatus.Name = "pnlCommunicationStatus";
            this.pnlCommunicationStatus.Size = new System.Drawing.Size(514, 123);
            this.pnlCommunicationStatus.TabIndex = 1;
            // 
            // pnlButton
            // 
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButton.Location = new System.Drawing.Point(723, 3);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(684, 123);
            this.pnlButton.TabIndex = 2;
            // 
            // pnlDisplayList
            // 
            this.pnlDisplayList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayList.Location = new System.Drawing.Point(3, 138);
            this.pnlDisplayList.Name = "pnlDisplayList";
            this.pnlDisplayList.Size = new System.Drawing.Size(1410, 858);
            this.pnlDisplayList.TabIndex = 2;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.pnlInspectionStatus, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pnlGlassMap, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.pnlInspectionResult, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.tabControl1, 0, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(482, 999);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // pnlInspectionStatus
            // 
            this.pnlInspectionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspectionStatus.Location = new System.Drawing.Point(3, 3);
            this.pnlInspectionStatus.Name = "pnlInspectionStatus";
            this.pnlInspectionStatus.Size = new System.Drawing.Size(476, 84);
            this.pnlInspectionStatus.TabIndex = 0;
            // 
            // pnlGlassMap
            // 
            this.pnlGlassMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGlassMap.Location = new System.Drawing.Point(3, 273);
            this.pnlGlassMap.Name = "pnlGlassMap";
            this.pnlGlassMap.Size = new System.Drawing.Size(476, 394);
            this.pnlGlassMap.TabIndex = 1;
            // 
            // pnlInspectionResult
            // 
            this.pnlInspectionResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspectionResult.Location = new System.Drawing.Point(3, 93);
            this.pnlInspectionResult.Name = "pnlInspectionResult";
            this.pnlInspectionResult.Size = new System.Drawing.Size(476, 174);
            this.pnlInspectionResult.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 673);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(476, 323);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlGlassInspectionResult);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(468, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Result";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlGlassInspectionResult
            // 
            this.pnlGlassInspectionResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGlassInspectionResult.Location = new System.Drawing.Point(3, 3);
            this.pnlGlassInspectionResult.Name = "pnlGlassInspectionResult";
            this.pnlGlassInspectionResult.Size = new System.Drawing.Size(462, 291);
            this.pnlGlassInspectionResult.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlDefectInformation);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(468, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Defect";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlDefectInformation
            // 
            this.pnlDefectInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefectInformation.Location = new System.Drawing.Point(3, 3);
            this.pnlDefectInformation.Name = "pnlDefectInformation";
            this.pnlDefectInformation.Size = new System.Drawing.Size(462, 291);
            this.pnlDefectInformation.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pnlSystemInfo);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(468, 297);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "System";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pnlSystemInfo
            // 
            this.pnlSystemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSystemInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlSystemInfo.Name = "pnlSystemInfo";
            this.pnlSystemInfo.Size = new System.Drawing.Size(468, 297);
            this.pnlSystemInfo.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pnlLogDisplay);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(468, 297);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pnlLogDisplay
            // 
            this.pnlLogDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlLogDisplay.Name = "pnlLogDisplay";
            this.pnlLogDisplay.Size = new System.Drawing.Size(468, 297);
            this.pnlLogDisplay.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1902, 999);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "GlassInspectionSystem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel pnlInspectionStatus;
        private System.Windows.Forms.Panel pnlGlassMap;
        private System.Windows.Forms.Panel pnlLogDisplay;
        private System.Windows.Forms.Panel pnlInspectionResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlGlassInspectionResult;
        private System.Windows.Forms.Panel pnlDefectInformation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel pnlCompanyLog;
        private System.Windows.Forms.Panel pnlCommunicationStatus;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel pnlSystemInfo;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Panel pnlDisplayList;
    }
}

