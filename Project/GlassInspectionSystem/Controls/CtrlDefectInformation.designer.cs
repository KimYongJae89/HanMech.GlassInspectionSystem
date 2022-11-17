namespace GlassInspectionSystem.Controls
{
    partial class CtrlDefectInformation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblDefectInfo = new System.Windows.Forms.Label();
            this.gvDefectInfoList = new System.Windows.Forms.DataGridView();
            this.ColumnCamNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDefectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConfidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInspType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDefectInfoList)).BeginInit();
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
            this.splitContainer.Panel1.Controls.Add(this.lblDefectInfo);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gvDefectInfoList);
            this.splitContainer.Size = new System.Drawing.Size(504, 240);
            this.splitContainer.SplitterDistance = 30;
            this.splitContainer.TabIndex = 3;
            this.splitContainer.TabStop = false;
            // 
            // lblDefectInfo
            // 
            this.lblDefectInfo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblDefectInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectInfo.Location = new System.Drawing.Point(0, 0);
            this.lblDefectInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lblDefectInfo.Name = "lblDefectInfo";
            this.lblDefectInfo.Size = new System.Drawing.Size(504, 30);
            this.lblDefectInfo.TabIndex = 0;
            this.lblDefectInfo.Text = "Defect Information";
            this.lblDefectInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvDefectInfoList
            // 
            this.gvDefectInfoList.AllowUserToAddRows = false;
            this.gvDefectInfoList.AllowUserToDeleteRows = false;
            this.gvDefectInfoList.AllowUserToResizeRows = false;
            this.gvDefectInfoList.BackgroundColor = System.Drawing.Color.White;
            this.gvDefectInfoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDefectInfoList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDefectInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvDefectInfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCamNo,
            this.ColumnDefectType,
            this.ColumnX,
            this.ColumnY,
            this.ColumnWidth,
            this.ColumnHeight,
            this.ColumnConfidence,
            this.ColumnInspType});
            this.gvDefectInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDefectInfoList.Location = new System.Drawing.Point(0, 0);
            this.gvDefectInfoList.MultiSelect = false;
            this.gvDefectInfoList.Name = "gvDefectInfoList";
            this.gvDefectInfoList.ReadOnly = true;
            this.gvDefectInfoList.RowHeadersVisible = false;
            this.gvDefectInfoList.RowTemplate.Height = 23;
            this.gvDefectInfoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDefectInfoList.Size = new System.Drawing.Size(504, 206);
            this.gvDefectInfoList.TabIndex = 1;
            this.gvDefectInfoList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDefectInfoList_CellContentClick);
            this.gvDefectInfoList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDefectInfoList_CellContentDoubleClick);
            this.gvDefectInfoList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDefectInfoList_CellContentDoubleClick);
            // 
            // ColumnCamNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnCamNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnCamNo.HeaderText = "CamNo";
            this.ColumnCamNo.MinimumWidth = 80;
            this.ColumnCamNo.Name = "ColumnCamNo";
            this.ColumnCamNo.ReadOnly = true;
            this.ColumnCamNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnCamNo.Width = 80;
            // 
            // ColumnDefectType
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnDefectType.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnDefectType.HeaderText = "Defect Type";
            this.ColumnDefectType.MinimumWidth = 80;
            this.ColumnDefectType.Name = "ColumnDefectType";
            this.ColumnDefectType.ReadOnly = true;
            this.ColumnDefectType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDefectType.Width = 80;
            // 
            // ColumnX
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnX.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnX.HeaderText = "X";
            this.ColumnX.MinimumWidth = 80;
            this.ColumnX.Name = "ColumnX";
            this.ColumnX.ReadOnly = true;
            this.ColumnX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnX.Width = 80;
            // 
            // ColumnY
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnY.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.MinimumWidth = 80;
            this.ColumnY.Name = "ColumnY";
            this.ColumnY.ReadOnly = true;
            this.ColumnY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnY.Width = 80;
            // 
            // ColumnWidth
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnWidth.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnWidth.HeaderText = "Width";
            this.ColumnWidth.MinimumWidth = 80;
            this.ColumnWidth.Name = "ColumnWidth";
            this.ColumnWidth.ReadOnly = true;
            this.ColumnWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnWidth.Width = 80;
            // 
            // ColumnHeight
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnHeight.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnHeight.HeaderText = "Height";
            this.ColumnHeight.MinimumWidth = 80;
            this.ColumnHeight.Name = "ColumnHeight";
            this.ColumnHeight.ReadOnly = true;
            this.ColumnHeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnHeight.Width = 80;
            // 
            // ColumnConfidence
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ColumnConfidence.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnConfidence.HeaderText = "Confidence";
            this.ColumnConfidence.MinimumWidth = 80;
            this.ColumnConfidence.Name = "ColumnConfidence";
            this.ColumnConfidence.ReadOnly = true;
            this.ColumnConfidence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnConfidence.Width = 80;
            // 
            // ColumnInspType
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ColumnInspType.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnInspType.HeaderText = "InspType";
            this.ColumnInspType.MinimumWidth = 80;
            this.ColumnInspType.Name = "ColumnInspType";
            this.ColumnInspType.ReadOnly = true;
            this.ColumnInspType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnInspType.Width = 80;
            // 
            // CtrlDefectInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CtrlDefectInformation";
            this.Size = new System.Drawing.Size(504, 240);
            this.Load += new System.EventHandler(this.DefectInformationControl_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDefectInfoList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblDefectInfo;
        private System.Windows.Forms.DataGridView gvDefectInfoList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCamNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDefectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConfidence;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInspType;
    }
}
