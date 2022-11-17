namespace GlassViewer.Forms
{
    partial class FormLineChart
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLineChart = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpkrToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpkrFromDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckbWarningGraph = new System.Windows.Forms.CheckBox();
            this.ckbNGGraph = new System.Windows.Forms.CheckBox();
            this.ckbOKGraph = new System.Windows.Forms.CheckBox();
            this.btnDrawGraphForAWeek = new System.Windows.Forms.Button();
            this.btnDrawGraphFor30Days = new System.Windows.Forms.Button();
            this.btnDrawGraphFor180Days = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveCSV = new System.Windows.Forms.Button();
            this.btnSaveChart = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlLineChart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1054, 591);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlLineChart
            // 
            this.pnlLineChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLineChart.Location = new System.Drawing.Point(3, 73);
            this.pnlLineChart.Name = "pnlLineChart";
            this.pnlLineChart.Size = new System.Drawing.Size(1048, 515);
            this.pnlLineChart.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 460F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1048, 64);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpkrToDate);
            this.panel1.Controls.Add(this.dtpkrFromDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 58);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "[Select Date Period]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(239, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "To";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "From";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpkrToDate
            // 
            this.dtpkrToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.dtpkrToDate.Location = new System.Drawing.Point(274, 28);
            this.dtpkrToDate.Name = "dtpkrToDate";
            this.dtpkrToDate.Size = new System.Drawing.Size(174, 21);
            this.dtpkrToDate.TabIndex = 5;
            // 
            // dtpkrFromDate
            // 
            this.dtpkrFromDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpkrFromDate.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtpkrFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.dtpkrFromDate.Location = new System.Drawing.Point(53, 27);
            this.dtpkrFromDate.Name = "dtpkrFromDate";
            this.dtpkrFromDate.Size = new System.Drawing.Size(174, 21);
            this.dtpkrFromDate.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(463, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(74, 58);
            this.panel2.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 58);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel5, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnDrawGraphForAWeek, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnDrawGraphFor30Days, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnDrawGraphFor180Days, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSaveCSV, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSaveChart, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(543, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(502, 58);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(303, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(196, 23);
            this.panel5.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, -2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "[Graph Type]";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ckbWarningGraph);
            this.panel3.Controls.Add(this.ckbNGGraph);
            this.panel3.Controls.Add(this.ckbOKGraph);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(303, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(196, 23);
            this.panel3.TabIndex = 1;
            // 
            // ckbWarningGraph
            // 
            this.ckbWarningGraph.AutoSize = true;
            this.ckbWarningGraph.Checked = true;
            this.ckbWarningGraph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbWarningGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ckbWarningGraph.Location = new System.Drawing.Point(111, 3);
            this.ckbWarningGraph.Name = "ckbWarningGraph";
            this.ckbWarningGraph.Size = new System.Drawing.Size(84, 20);
            this.ckbWarningGraph.TabIndex = 2;
            this.ckbWarningGraph.Text = "Warning";
            this.ckbWarningGraph.UseVisualStyleBackColor = true;
            this.ckbWarningGraph.CheckedChanged += new System.EventHandler(this.ckbWarningGraph_CheckedChanged);
            // 
            // ckbNGGraph
            // 
            this.ckbNGGraph.AutoSize = true;
            this.ckbNGGraph.Checked = true;
            this.ckbNGGraph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbNGGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ckbNGGraph.Location = new System.Drawing.Point(56, 3);
            this.ckbNGGraph.Name = "ckbNGGraph";
            this.ckbNGGraph.Size = new System.Drawing.Size(49, 20);
            this.ckbNGGraph.TabIndex = 1;
            this.ckbNGGraph.Text = "NG";
            this.ckbNGGraph.UseVisualStyleBackColor = true;
            this.ckbNGGraph.CheckedChanged += new System.EventHandler(this.ckbNGGraph_CheckedChanged);
            // 
            // ckbOKGraph
            // 
            this.ckbOKGraph.AutoSize = true;
            this.ckbOKGraph.Checked = true;
            this.ckbOKGraph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbOKGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ckbOKGraph.Location = new System.Drawing.Point(3, 3);
            this.ckbOKGraph.Name = "ckbOKGraph";
            this.ckbOKGraph.Size = new System.Drawing.Size(47, 20);
            this.ckbOKGraph.TabIndex = 0;
            this.ckbOKGraph.Text = "OK";
            this.ckbOKGraph.UseVisualStyleBackColor = true;
            this.ckbOKGraph.CheckedChanged += new System.EventHandler(this.ckbOKGraph_CheckedChanged);
            // 
            // btnDrawGraphForAWeek
            // 
            this.btnDrawGraphForAWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawGraphForAWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDrawGraphForAWeek.Location = new System.Drawing.Point(3, 32);
            this.btnDrawGraphForAWeek.Name = "btnDrawGraphForAWeek";
            this.btnDrawGraphForAWeek.Size = new System.Drawing.Size(94, 23);
            this.btnDrawGraphForAWeek.TabIndex = 10;
            this.btnDrawGraphForAWeek.Text = "Week";
            this.btnDrawGraphForAWeek.UseVisualStyleBackColor = true;
            this.btnDrawGraphForAWeek.Click += new System.EventHandler(this.btnDrawGraphForAWeek_Click);
            // 
            // btnDrawGraphFor30Days
            // 
            this.btnDrawGraphFor30Days.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawGraphFor30Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDrawGraphFor30Days.Location = new System.Drawing.Point(103, 32);
            this.btnDrawGraphFor30Days.Name = "btnDrawGraphFor30Days";
            this.btnDrawGraphFor30Days.Size = new System.Drawing.Size(94, 23);
            this.btnDrawGraphFor30Days.TabIndex = 11;
            this.btnDrawGraphFor30Days.Text = "30 Days";
            this.btnDrawGraphFor30Days.UseVisualStyleBackColor = true;
            this.btnDrawGraphFor30Days.Click += new System.EventHandler(this.btnDrawGraphFor30Days_Click);
            // 
            // btnDrawGraphFor180Days
            // 
            this.btnDrawGraphFor180Days.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawGraphFor180Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDrawGraphFor180Days.Location = new System.Drawing.Point(203, 32);
            this.btnDrawGraphFor180Days.Name = "btnDrawGraphFor180Days";
            this.btnDrawGraphFor180Days.Size = new System.Drawing.Size(94, 23);
            this.btnDrawGraphFor180Days.TabIndex = 12;
            this.btnDrawGraphFor180Days.Text = "180 Days";
            this.btnDrawGraphFor180Days.UseVisualStyleBackColor = true;
            this.btnDrawGraphFor180Days.Click += new System.EventHandler(this.btnDrawGraphFor180Days_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(94, 23);
            this.panel4.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-3, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "[Date Period]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveCSV
            // 
            this.btnSaveCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveCSV.Location = new System.Drawing.Point(203, 3);
            this.btnSaveCSV.Name = "btnSaveCSV";
            this.btnSaveCSV.Size = new System.Drawing.Size(94, 23);
            this.btnSaveCSV.TabIndex = 14;
            this.btnSaveCSV.Text = "Output CSV";
            this.btnSaveCSV.UseVisualStyleBackColor = true;
            this.btnSaveCSV.Click += new System.EventHandler(this.btnSaveCSV_Click);
            // 
            // btnSaveChart
            // 
            this.btnSaveChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveChart.Location = new System.Drawing.Point(103, 3);
            this.btnSaveChart.Name = "btnSaveChart";
            this.btnSaveChart.Size = new System.Drawing.Size(94, 23);
            this.btnSaveChart.TabIndex = 15;
            this.btnSaveChart.Text = "Save Chart";
            this.btnSaveChart.UseVisualStyleBackColor = true;
            this.btnSaveChart.Click += new System.EventHandler(this.btnSaveChart_Click);
            // 
            // FormLineChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 591);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormLineChart";
            this.Text = "_";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLineChart_FormClosed);
            this.Load += new System.EventHandler(this.FormLineChart_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlLineChart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpkrToDate;
        private System.Windows.Forms.DateTimePicker dtpkrFromDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ckbWarningGraph;
        private System.Windows.Forms.CheckBox ckbNGGraph;
        private System.Windows.Forms.CheckBox ckbOKGraph;
        private System.Windows.Forms.Button btnDrawGraphForAWeek;
        private System.Windows.Forms.Button btnDrawGraphFor30Days;
        private System.Windows.Forms.Button btnDrawGraphFor180Days;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveCSV;
        private System.Windows.Forms.Button btnSaveChart;
    }
}