namespace GlassViewer.Controls
{
    partial class CtrlDataList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gvDefect = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.ColumnGlassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImagePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCamNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDftType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRealPosX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRealPosY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBoundingPosX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBoundingPosY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBoundingWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBoundingHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInspectionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDefect)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gvDefect, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 502);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gvDefect
            // 
            this.gvDefect.AllowUserToAddRows = false;
            this.gvDefect.AllowUserToDeleteRows = false;
            this.gvDefect.AllowUserToResizeRows = false;
            this.gvDefect.BackgroundColor = System.Drawing.Color.White;
            this.gvDefect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDefect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDefect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvDefect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCamNo,
            this.ColumnDftType,
            this.Updated,
            this.ColumnRealPosX,
            this.ColumnRealPosY,
            this.ColumnBoundingPosX,
            this.ColumnBoundingPosY,
            this.ColumnBoundingWidth,
            this.ColumnBoundingHeight,
            this.ColumnScore,
            this.ColumnInspectionType});
            this.gvDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDefect.Location = new System.Drawing.Point(3, 305);
            this.gvDefect.MultiSelect = false;
            this.gvDefect.Name = "gvDefect";
            this.gvDefect.ReadOnly = true;
            this.gvDefect.RowHeadersVisible = false;
            this.gvDefect.RowTemplate.Height = 23;
            this.gvDefect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDefect.Size = new System.Drawing.Size(638, 194);
            this.gvDefect.TabIndex = 5;
            this.gvDefect.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDefect_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(638, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "[Defect Status]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(638, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "[Glass Status]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gvResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 266);
            this.panel1.TabIndex = 4;
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.AllowUserToResizeRows = false;
            this.gvResult.BackgroundColor = System.Drawing.Color.White;
            this.gvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnGlassID,
            this.ColumnResult,
            this.ColumnImagePath,
            this.ColumnUpdated});
            this.gvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvResult.Location = new System.Drawing.Point(0, 0);
            this.gvResult.MultiSelect = false;
            this.gvResult.Name = "gvResult";
            this.gvResult.ReadOnly = true;
            this.gvResult.RowHeadersVisible = false;
            this.gvResult.RowTemplate.Height = 23;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(638, 266);
            this.gvResult.TabIndex = 2;
            this.gvResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResult_CellDoubleClick);
            // 
            // ColumnGlassID
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnGlassID.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColumnGlassID.HeaderText = "GlassID";
            this.ColumnGlassID.MinimumWidth = 180;
            this.ColumnGlassID.Name = "ColumnGlassID";
            this.ColumnGlassID.ReadOnly = true;
            this.ColumnGlassID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnGlassID.Width = 180;
            // 
            // ColumnResult
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnResult.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColumnResult.HeaderText = "Result";
            this.ColumnResult.MinimumWidth = 70;
            this.ColumnResult.Name = "ColumnResult";
            this.ColumnResult.ReadOnly = true;
            this.ColumnResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnResult.Width = 70;
            // 
            // ColumnImagePath
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnImagePath.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColumnImagePath.HeaderText = "ImagePath";
            this.ColumnImagePath.MinimumWidth = 150;
            this.ColumnImagePath.Name = "ColumnImagePath";
            this.ColumnImagePath.ReadOnly = true;
            this.ColumnImagePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnImagePath.Width = 150;
            // 
            // ColumnUpdated
            // 
            this.ColumnUpdated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnUpdated.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColumnUpdated.HeaderText = "Updated";
            this.ColumnUpdated.MinimumWidth = 80;
            this.ColumnUpdated.Name = "ColumnUpdated";
            this.ColumnUpdated.ReadOnly = true;
            this.ColumnUpdated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnCamNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnCamNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnCamNo.HeaderText = "CamNo";
            this.ColumnCamNo.MinimumWidth = 60;
            this.ColumnCamNo.Name = "ColumnCamNo";
            this.ColumnCamNo.ReadOnly = true;
            this.ColumnCamNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnCamNo.Width = 60;
            // 
            // ColumnDftType
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnDftType.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnDftType.HeaderText = "DftType";
            this.ColumnDftType.MinimumWidth = 80;
            this.ColumnDftType.Name = "ColumnDftType";
            this.ColumnDftType.ReadOnly = true;
            this.ColumnDftType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDftType.Width = 80;
            // 
            // Updated
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Updated.DefaultCellStyle = dataGridViewCellStyle4;
            this.Updated.HeaderText = "Updated";
            this.Updated.MinimumWidth = 180;
            this.Updated.Name = "Updated";
            this.Updated.ReadOnly = true;
            this.Updated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Updated.Width = 180;
            // 
            // ColumnRealPosX
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnRealPosX.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnRealPosX.HeaderText = "RealPosX";
            this.ColumnRealPosX.MinimumWidth = 70;
            this.ColumnRealPosX.Name = "ColumnRealPosX";
            this.ColumnRealPosX.ReadOnly = true;
            this.ColumnRealPosX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRealPosX.Width = 70;
            // 
            // ColumnRealPosY
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnRealPosY.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnRealPosY.HeaderText = "RealPosY";
            this.ColumnRealPosY.MinimumWidth = 70;
            this.ColumnRealPosY.Name = "ColumnRealPosY";
            this.ColumnRealPosY.ReadOnly = true;
            this.ColumnRealPosY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRealPosY.Width = 70;
            // 
            // ColumnBoundingPosX
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnBoundingPosX.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnBoundingPosX.HeaderText = "BoundingPosX";
            this.ColumnBoundingPosX.MinimumWidth = 95;
            this.ColumnBoundingPosX.Name = "ColumnBoundingPosX";
            this.ColumnBoundingPosX.ReadOnly = true;
            this.ColumnBoundingPosX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnBoundingPosX.Width = 95;
            // 
            // ColumnBoundingPosY
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ColumnBoundingPosY.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnBoundingPosY.HeaderText = "BoundingPosY";
            this.ColumnBoundingPosY.MinimumWidth = 95;
            this.ColumnBoundingPosY.Name = "ColumnBoundingPosY";
            this.ColumnBoundingPosY.ReadOnly = true;
            this.ColumnBoundingPosY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnBoundingPosY.Width = 95;
            // 
            // ColumnBoundingWidth
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ColumnBoundingWidth.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnBoundingWidth.HeaderText = "BoundingWidth";
            this.ColumnBoundingWidth.MinimumWidth = 100;
            this.ColumnBoundingWidth.Name = "ColumnBoundingWidth";
            this.ColumnBoundingWidth.ReadOnly = true;
            this.ColumnBoundingWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnBoundingHeight
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ColumnBoundingHeight.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColumnBoundingHeight.HeaderText = "BoundingHeight";
            this.ColumnBoundingHeight.MinimumWidth = 100;
            this.ColumnBoundingHeight.Name = "ColumnBoundingHeight";
            this.ColumnBoundingHeight.ReadOnly = true;
            this.ColumnBoundingHeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnScore
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnScore.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColumnScore.HeaderText = "Score";
            this.ColumnScore.MinimumWidth = 60;
            this.ColumnScore.Name = "ColumnScore";
            this.ColumnScore.ReadOnly = true;
            this.ColumnScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnScore.Width = 60;
            // 
            // ColumnInspectionType
            // 
            this.ColumnInspectionType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ColumnInspectionType.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColumnInspectionType.HeaderText = "InspectionType";
            this.ColumnInspectionType.MinimumWidth = 100;
            this.ColumnInspectionType.Name = "ColumnInspectionType";
            this.ColumnInspectionType.ReadOnly = true;
            // 
            // CtrlDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtrlDataList";
            this.Size = new System.Drawing.Size(644, 502);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDefect)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvDefect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGlassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnImagePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCamNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDftType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Updated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRealPosX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRealPosY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBoundingPosX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBoundingPosY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBoundingWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBoundingHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInspectionType;
    }
}
