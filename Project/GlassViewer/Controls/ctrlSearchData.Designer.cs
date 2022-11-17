namespace GlassViewer.Controls
{
    partial class CtrlSearchData
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.tabSearching = new System.Windows.Forms.TabControl();
            this.tabPageByDate = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpkrToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpkrFromDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ckbChipping = new System.Windows.Forms.CheckBox();
            this.ckbCrack = new System.Windows.Forms.CheckBox();
            this.ckbBroken = new System.Windows.Forms.CheckBox();
            this.ckbAll = new System.Windows.Forms.CheckBox();
            this.tabPageByGlassID = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabSearching.SuspendLayout();
            this.tabPageByDate.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageByGlassID.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabSearching, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnTest, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(460, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(94, 144);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(3, 77);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 64);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnTest
            // 
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTest.Location = new System.Drawing.Point(3, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(88, 68);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tabSearching
            // 
            this.tabSearching.Controls.Add(this.tabPageByDate);
            this.tabSearching.Controls.Add(this.tabPageByGlassID);
            this.tabSearching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSearching.Location = new System.Drawing.Point(3, 3);
            this.tabSearching.Name = "tabSearching";
            this.tabSearching.SelectedIndex = 0;
            this.tabSearching.Size = new System.Drawing.Size(451, 144);
            this.tabSearching.TabIndex = 1;
            this.tabSearching.SelectedIndexChanged += new System.EventHandler(this.tabSearching_SelectedIndexChanged);
            // 
            // tabPageByDate
            // 
            this.tabPageByDate.Controls.Add(this.tableLayoutPanel3);
            this.tabPageByDate.Location = new System.Drawing.Point(4, 22);
            this.tabPageByDate.Name = "tabPageByDate";
            this.tabPageByDate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageByDate.Size = new System.Drawing.Size(443, 118);
            this.tabPageByDate.TabIndex = 0;
            this.tabPageByDate.Text = "By Date";
            this.tabPageByDate.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(437, 112);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpkrToDate);
            this.panel1.Controls.Add(this.dtpkrFromDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 106);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpkrToDate
            // 
            this.dtpkrToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.dtpkrToDate.Location = new System.Drawing.Point(58, 43);
            this.dtpkrToDate.Name = "dtpkrToDate";
            this.dtpkrToDate.Size = new System.Drawing.Size(174, 21);
            this.dtpkrToDate.TabIndex = 1;
            // 
            // dtpkrFromDate
            // 
            this.dtpkrFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.dtpkrFromDate.Location = new System.Drawing.Point(58, 10);
            this.dtpkrFromDate.Name = "dtpkrFromDate";
            this.dtpkrFromDate.Size = new System.Drawing.Size(174, 21);
            this.dtpkrFromDate.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.ckbChipping);
            this.panel2.Controls.Add(this.ckbCrack);
            this.panel2.Controls.Add(this.ckbBroken);
            this.panel2.Controls.Add(this.ckbAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(248, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 106);
            this.panel2.TabIndex = 3;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox2.Location = new System.Drawing.Point(92, 47);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(31, 19);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "-";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(6, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(31, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "-";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // ckbChipping
            // 
            this.ckbChipping.AutoSize = true;
            this.ckbChipping.Enabled = false;
            this.ckbChipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.ckbChipping.Location = new System.Drawing.Point(92, 27);
            this.ckbChipping.Name = "ckbChipping";
            this.ckbChipping.Size = new System.Drawing.Size(83, 19);
            this.ckbChipping.TabIndex = 3;
            this.ckbChipping.Text = "Chipping";
            this.ckbChipping.UseVisualStyleBackColor = true;
            this.ckbChipping.CheckedChanged += new System.EventHandler(this.ckbChipping_CheckedChanged);
            // 
            // ckbCrack
            // 
            this.ckbCrack.AutoSize = true;
            this.ckbCrack.Enabled = false;
            this.ckbCrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.ckbCrack.Location = new System.Drawing.Point(92, 7);
            this.ckbCrack.Name = "ckbCrack";
            this.ckbCrack.Size = new System.Drawing.Size(62, 19);
            this.ckbCrack.TabIndex = 2;
            this.ckbCrack.Text = "Crack";
            this.ckbCrack.UseVisualStyleBackColor = true;
            this.ckbCrack.CheckedChanged += new System.EventHandler(this.ckbCrack_CheckedChanged);
            // 
            // ckbBroken
            // 
            this.ckbBroken.AutoSize = true;
            this.ckbBroken.Enabled = false;
            this.ckbBroken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.ckbBroken.Location = new System.Drawing.Point(6, 27);
            this.ckbBroken.Name = "ckbBroken";
            this.ckbBroken.Size = new System.Drawing.Size(71, 19);
            this.ckbBroken.TabIndex = 1;
            this.ckbBroken.Text = "Broken";
            this.ckbBroken.UseVisualStyleBackColor = true;
            this.ckbBroken.CheckedChanged += new System.EventHandler(this.ckbBroken_CheckedChanged);
            // 
            // ckbAll
            // 
            this.ckbAll.AutoSize = true;
            this.ckbAll.Checked = true;
            this.ckbAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.ckbAll.Location = new System.Drawing.Point(6, 7);
            this.ckbAll.Name = "ckbAll";
            this.ckbAll.Size = new System.Drawing.Size(42, 19);
            this.ckbAll.TabIndex = 0;
            this.ckbAll.Text = "All";
            this.ckbAll.UseVisualStyleBackColor = true;
            this.ckbAll.CheckedChanged += new System.EventHandler(this.ckbAll_CheckedChanged);
            // 
            // tabPageByGlassID
            // 
            this.tabPageByGlassID.Controls.Add(this.label1);
            this.tabPageByGlassID.Controls.Add(this.txtSearch);
            this.tabPageByGlassID.Location = new System.Drawing.Point(4, 22);
            this.tabPageByGlassID.Name = "tabPageByGlassID";
            this.tabPageByGlassID.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageByGlassID.Size = new System.Drawing.Size(443, 118);
            this.tabPageByGlassID.TabIndex = 1;
            this.tabPageByGlassID.Text = "By GlassID";
            this.tabPageByGlassID.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Glass ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(199, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(165, 21);
            this.txtSearch.TabIndex = 0;
            // 
            // CtrlSearchData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtrlSearchData";
            this.Size = new System.Drawing.Size(557, 150);
            this.Load += new System.EventHandler(this.CtrlSearchData_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabSearching.ResumeLayout(false);
            this.tabPageByDate.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageByGlassID.ResumeLayout(false);
            this.tabPageByGlassID.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabControl tabSearching;
        private System.Windows.Forms.TabPage tabPageByDate;
        private System.Windows.Forms.TabPage tabPageByGlassID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtpkrToDate;
        private System.Windows.Forms.DateTimePicker dtpkrFromDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckbChipping;
        private System.Windows.Forms.CheckBox ckbCrack;
        private System.Windows.Forms.CheckBox ckbBroken;
        private System.Windows.Forms.CheckBox ckbAll;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnTest;
    }
}
