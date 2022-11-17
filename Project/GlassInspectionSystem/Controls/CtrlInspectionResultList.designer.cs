namespace GlassInspectionSystem.Controls
{
    partial class CtrlInspectionResultList
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.IblGlassInspectionResult = new System.Windows.Forms.Label();
            this.gvInspectionResultList = new System.Windows.Forms.DataGridView();
            this.ColumnNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGlassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInspResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInspectionResultList)).BeginInit();
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
            this.splitContainer.Panel1.Controls.Add(this.IblGlassInspectionResult);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gvInspectionResultList);
            this.splitContainer.Size = new System.Drawing.Size(615, 240);
            this.splitContainer.SplitterDistance = 30;
            this.splitContainer.TabIndex = 2;
            this.splitContainer.TabStop = false;
            // 
            // IblGlassInspectionResult
            // 
            this.IblGlassInspectionResult.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.IblGlassInspectionResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IblGlassInspectionResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IblGlassInspectionResult.Location = new System.Drawing.Point(0, 0);
            this.IblGlassInspectionResult.Margin = new System.Windows.Forms.Padding(3);
            this.IblGlassInspectionResult.Name = "IblGlassInspectionResult";
            this.IblGlassInspectionResult.Size = new System.Drawing.Size(615, 30);
            this.IblGlassInspectionResult.TabIndex = 0;
            this.IblGlassInspectionResult.Text = "Glass Inspection Result";
            this.IblGlassInspectionResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvInspectionResultList
            // 
            this.gvInspectionResultList.AllowUserToAddRows = false;
            this.gvInspectionResultList.AllowUserToDeleteRows = false;
            this.gvInspectionResultList.AllowUserToResizeRows = false;
            this.gvInspectionResultList.BackgroundColor = System.Drawing.Color.White;
            this.gvInspectionResultList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvInspectionResultList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvInspectionResultList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvInspectionResultList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNO,
            this.ColumnGlassID,
            this.ColumnInspResult,
            this.ColumnDateTime});
            this.gvInspectionResultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvInspectionResultList.Location = new System.Drawing.Point(0, 0);
            this.gvInspectionResultList.MultiSelect = false;
            this.gvInspectionResultList.Name = "gvInspectionResultList";
            this.gvInspectionResultList.ReadOnly = true;
            this.gvInspectionResultList.RowHeadersVisible = false;
            this.gvInspectionResultList.RowTemplate.Height = 23;
            this.gvInspectionResultList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvInspectionResultList.Size = new System.Drawing.Size(615, 206);
            this.gvInspectionResultList.TabIndex = 0;
            // 
            // ColumnNO
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnNO.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnNO.FillWeight = 30F;
            this.ColumnNO.HeaderText = "No";
            this.ColumnNO.MinimumWidth = 60;
            this.ColumnNO.Name = "ColumnNO";
            this.ColumnNO.ReadOnly = true;
            this.ColumnNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnNO.Width = 60;
            // 
            // ColumnGlassID
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnGlassID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnGlassID.FillWeight = 200F;
            this.ColumnGlassID.HeaderText = "Glass ID";
            this.ColumnGlassID.MinimumWidth = 200;
            this.ColumnGlassID.Name = "ColumnGlassID";
            this.ColumnGlassID.ReadOnly = true;
            this.ColumnGlassID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnGlassID.Width = 200;
            // 
            // ColumnInspResult
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnInspResult.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnInspResult.FillWeight = 90F;
            this.ColumnInspResult.HeaderText = "Insp Result";
            this.ColumnInspResult.MinimumWidth = 110;
            this.ColumnInspResult.Name = "ColumnInspResult";
            this.ColumnInspResult.ReadOnly = true;
            this.ColumnInspResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnInspResult.Width = 110;
            // 
            // ColumnDateTime
            // 
            this.ColumnDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnDateTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnDateTime.HeaderText = "Date Time";
            this.ColumnDateTime.MinimumWidth = 120;
            this.ColumnDateTime.Name = "ColumnDateTime";
            this.ColumnDateTime.ReadOnly = true;
            this.ColumnDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CtrlInspectionResultList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CtrlInspectionResultList";
            this.Size = new System.Drawing.Size(615, 240);
            this.Load += new System.EventHandler(this.InspectionResultListControl_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvInspectionResultList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label IblGlassInspectionResult;
        private System.Windows.Forms.DataGridView gvInspectionResultList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGlassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInspResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTime;
    }
}
