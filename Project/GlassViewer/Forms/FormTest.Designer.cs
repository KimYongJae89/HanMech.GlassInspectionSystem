namespace GlassViewer.Forms
{
    partial class FormTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnInsertResult = new System.Windows.Forms.Button();
            this.btnInsertDefect = new System.Windows.Forms.Button();
            this.btnInsertDaily = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteDaily = new System.Windows.Forms.Button();
            this.btnDeleteDefect = new System.Windows.Forms.Button();
            this.btnDeleteResult = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearchingResultByGlassID = new System.Windows.Forms.Button();
            this.btnSearchingDaily = new System.Windows.Forms.Button();
            this.btnSearchingDefect = new System.Windows.Forms.Button();
            this.btnSearchingResultByDate = new System.Windows.Forms.Button();
            this.ColumnWarningCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNGCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOKCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvDaily = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDaily)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsertResult
            // 
            this.btnInsertResult.Location = new System.Drawing.Point(21, 18);
            this.btnInsertResult.Name = "btnInsertResult";
            this.btnInsertResult.Size = new System.Drawing.Size(75, 23);
            this.btnInsertResult.TabIndex = 0;
            this.btnInsertResult.Text = "Result";
            this.btnInsertResult.UseVisualStyleBackColor = true;
            this.btnInsertResult.Click += new System.EventHandler(this.btnInsertResult_Click);
            // 
            // btnInsertDefect
            // 
            this.btnInsertDefect.Location = new System.Drawing.Point(21, 62);
            this.btnInsertDefect.Name = "btnInsertDefect";
            this.btnInsertDefect.Size = new System.Drawing.Size(75, 23);
            this.btnInsertDefect.TabIndex = 1;
            this.btnInsertDefect.Text = "Defect";
            this.btnInsertDefect.UseVisualStyleBackColor = true;
            this.btnInsertDefect.Click += new System.EventHandler(this.btnInsertDefect_Click);
            // 
            // btnInsertDaily
            // 
            this.btnInsertDaily.Location = new System.Drawing.Point(21, 105);
            this.btnInsertDaily.Name = "btnInsertDaily";
            this.btnInsertDaily.Size = new System.Drawing.Size(75, 23);
            this.btnInsertDaily.TabIndex = 2;
            this.btnInsertDaily.Text = "Daily";
            this.btnInsertDaily.UseVisualStyleBackColor = true;
            this.btnInsertDaily.Click += new System.EventHandler(this.btnInsertDaily_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInsertDaily);
            this.groupBox1.Controls.Add(this.btnInsertDefect);
            this.groupBox1.Controls.Add(this.btnInsertResult);
            this.groupBox1.Location = new System.Drawing.Point(17, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 147);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insert";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteDaily);
            this.groupBox2.Controls.Add(this.btnDeleteDefect);
            this.groupBox2.Controls.Add(this.btnDeleteResult);
            this.groupBox2.Location = new System.Drawing.Point(156, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 147);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete";
            // 
            // btnDeleteDaily
            // 
            this.btnDeleteDaily.Location = new System.Drawing.Point(21, 105);
            this.btnDeleteDaily.Name = "btnDeleteDaily";
            this.btnDeleteDaily.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDaily.TabIndex = 2;
            this.btnDeleteDaily.Text = "Daily";
            this.btnDeleteDaily.UseVisualStyleBackColor = true;
            this.btnDeleteDaily.Click += new System.EventHandler(this.btnDeleteDaily_Click);
            // 
            // btnDeleteDefect
            // 
            this.btnDeleteDefect.Location = new System.Drawing.Point(21, 62);
            this.btnDeleteDefect.Name = "btnDeleteDefect";
            this.btnDeleteDefect.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDefect.TabIndex = 1;
            this.btnDeleteDefect.Text = "Defect";
            this.btnDeleteDefect.UseVisualStyleBackColor = true;
            this.btnDeleteDefect.Click += new System.EventHandler(this.btnDeleteDefect_Click);
            // 
            // btnDeleteResult
            // 
            this.btnDeleteResult.Location = new System.Drawing.Point(21, 18);
            this.btnDeleteResult.Name = "btnDeleteResult";
            this.btnDeleteResult.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteResult.TabIndex = 0;
            this.btnDeleteResult.Text = "Result";
            this.btnDeleteResult.UseVisualStyleBackColor = true;
            this.btnDeleteResult.Click += new System.EventHandler(this.btnDeleteResult_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearchingResultByGlassID);
            this.groupBox3.Controls.Add(this.btnSearchingDaily);
            this.groupBox3.Controls.Add(this.btnSearchingDefect);
            this.groupBox3.Controls.Add(this.btnSearchingResultByDate);
            this.groupBox3.Location = new System.Drawing.Point(296, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 147);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Searching";
            // 
            // btnSearchingResultByGlassID
            // 
            this.btnSearchingResultByGlassID.Location = new System.Drawing.Point(20, 50);
            this.btnSearchingResultByGlassID.Name = "btnSearchingResultByGlassID";
            this.btnSearchingResultByGlassID.Size = new System.Drawing.Size(110, 23);
            this.btnSearchingResultByGlassID.TabIndex = 3;
            this.btnSearchingResultByGlassID.Text = "Result(GlassID)";
            this.btnSearchingResultByGlassID.UseVisualStyleBackColor = true;
            this.btnSearchingResultByGlassID.Click += new System.EventHandler(this.btnSearchingResultByGlassID_Click);
            // 
            // btnSearchingDaily
            // 
            this.btnSearchingDaily.Location = new System.Drawing.Point(21, 120);
            this.btnSearchingDaily.Name = "btnSearchingDaily";
            this.btnSearchingDaily.Size = new System.Drawing.Size(75, 23);
            this.btnSearchingDaily.TabIndex = 2;
            this.btnSearchingDaily.Text = "Daily";
            this.btnSearchingDaily.UseVisualStyleBackColor = true;
            this.btnSearchingDaily.Click += new System.EventHandler(this.btnSearchingDaily_Click);
            // 
            // btnSearchingDefect
            // 
            this.btnSearchingDefect.Location = new System.Drawing.Point(21, 85);
            this.btnSearchingDefect.Name = "btnSearchingDefect";
            this.btnSearchingDefect.Size = new System.Drawing.Size(75, 23);
            this.btnSearchingDefect.TabIndex = 1;
            this.btnSearchingDefect.Text = "Defect";
            this.btnSearchingDefect.UseVisualStyleBackColor = true;
            this.btnSearchingDefect.Click += new System.EventHandler(this.btnSearchingDefect_Click);
            // 
            // btnSearchingResultByDate
            // 
            this.btnSearchingResultByDate.Location = new System.Drawing.Point(21, 18);
            this.btnSearchingResultByDate.Name = "btnSearchingResultByDate";
            this.btnSearchingResultByDate.Size = new System.Drawing.Size(110, 23);
            this.btnSearchingResultByDate.TabIndex = 0;
            this.btnSearchingResultByDate.Text = "Result(Date)";
            this.btnSearchingResultByDate.UseVisualStyleBackColor = true;
            this.btnSearchingResultByDate.Click += new System.EventHandler(this.btnSearchingResultByDate_Click);
            // 
            // ColumnWarningCount
            // 
            this.ColumnWarningCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnWarningCount.HeaderText = "WarningCount";
            this.ColumnWarningCount.Name = "ColumnWarningCount";
            this.ColumnWarningCount.ReadOnly = true;
            // 
            // ColumnNGCount
            // 
            this.ColumnNGCount.HeaderText = "NGCount";
            this.ColumnNGCount.Name = "ColumnNGCount";
            this.ColumnNGCount.ReadOnly = true;
            // 
            // ColumnOKCount
            // 
            this.ColumnOKCount.HeaderText = "OKCount";
            this.ColumnOKCount.Name = "ColumnOKCount";
            this.ColumnOKCount.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "Updated";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 180;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 180;
            // 
            // gvDaily
            // 
            this.gvDaily.AllowUserToAddRows = false;
            this.gvDaily.AllowUserToDeleteRows = false;
            this.gvDaily.AllowUserToResizeRows = false;
            this.gvDaily.BackgroundColor = System.Drawing.Color.White;
            this.gvDaily.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDaily.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvDaily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvDaily.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.ColumnOKCount,
            this.ColumnNGCount,
            this.ColumnWarningCount});
            this.gvDaily.Location = new System.Drawing.Point(460, 16);
            this.gvDaily.MultiSelect = false;
            this.gvDaily.Name = "gvDaily";
            this.gvDaily.ReadOnly = true;
            this.gvDaily.RowHeadersVisible = false;
            this.gvDaily.RowTemplate.Height = 23;
            this.gvDaily.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDaily.Size = new System.Drawing.Size(502, 134);
            this.gvDaily.TabIndex = 8;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 289);
            this.Controls.Add(this.gvDaily);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTest_FormClosed);
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDaily)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInsertResult;
        private System.Windows.Forms.Button btnInsertDefect;
        private System.Windows.Forms.Button btnInsertDaily;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteDaily;
        private System.Windows.Forms.Button btnDeleteDefect;
        private System.Windows.Forms.Button btnDeleteResult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearchingDaily;
        private System.Windows.Forms.Button btnSearchingDefect;
        private System.Windows.Forms.Button btnSearchingResultByDate;
        private System.Windows.Forms.Button btnSearchingResultByGlassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWarningCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNGCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOKCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView gvDaily;
    }
}