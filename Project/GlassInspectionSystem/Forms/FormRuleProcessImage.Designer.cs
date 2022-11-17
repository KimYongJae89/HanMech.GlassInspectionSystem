namespace GlassInspectionSystem.Forms
{
    partial class FormRuleProcessImage
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOriginalImage = new System.Windows.Forms.Button();
            this.btnOrizinalSize = new System.Windows.Forms.Button();
            this.btnFitSize = new System.Windows.Forms.Button();
            this.btnFilterImage = new System.Windows.Forms.Button();
            this.pnlDisplayImage = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabInspectionLogType = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbxBrokenLog = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbxContourLog = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExcute = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ckbOffset = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbxDirection = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tabInspectionType = new System.Windows.Forms.TabControl();
            this.Broken = new System.Windows.Forms.TabPage();
            this.txtBrokenThres2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBrokenThres1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBrokenTwoDerivativeValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBrokenAvgCnt = new System.Windows.Forms.TextBox();
            this.txtBrokenValue = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.Coutour = new System.Windows.Forms.TabPage();
            this.txtContourTwoDerivativeValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbDrawInspArea = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtContourInspectionOffset = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContourInspectionArea = new System.Windows.Forms.TextBox();
            this.txtContourMinSize = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Processing = new System.Windows.Forms.TabPage();
            this.cbxProcessingFilterType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nupdnTwoDerivativeValue = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.Canny = new System.Windows.Forms.TabPage();
            this.txtCannyThres2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCannyThres1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabInspectionLogType.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabInspectionType.SuspendLayout();
            this.Broken.SuspendLayout();
            this.Coutour.SuspendLayout();
            this.Processing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnTwoDerivativeValue)).BeginInit();
            this.Canny.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1325, 806);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pnlDisplayImage, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabInspectionLogType, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1039, 800);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Controls.Add(this.btnOriginalImage, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnOrizinalSize, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnFitSize, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnFilterImage, 3, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1033, 29);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // btnOriginalImage
            // 
            this.btnOriginalImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOriginalImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnOriginalImage.Location = new System.Drawing.Point(519, 3);
            this.btnOriginalImage.Name = "btnOriginalImage";
            this.btnOriginalImage.Size = new System.Drawing.Size(252, 23);
            this.btnOriginalImage.TabIndex = 3;
            this.btnOriginalImage.Text = "Original Image";
            this.btnOriginalImage.UseVisualStyleBackColor = true;
            this.btnOriginalImage.Click += new System.EventHandler(this.btnOriginalImage_Click);
            // 
            // btnOrizinalSize
            // 
            this.btnOrizinalSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOrizinalSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnOrizinalSize.Location = new System.Drawing.Point(261, 3);
            this.btnOrizinalSize.Name = "btnOrizinalSize";
            this.btnOrizinalSize.Size = new System.Drawing.Size(252, 23);
            this.btnOrizinalSize.TabIndex = 2;
            this.btnOrizinalSize.Text = "Original Size";
            this.btnOrizinalSize.UseVisualStyleBackColor = true;
            this.btnOrizinalSize.Click += new System.EventHandler(this.btnOrizinalSize_Click);
            // 
            // btnFitSize
            // 
            this.btnFitSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFitSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFitSize.Location = new System.Drawing.Point(3, 3);
            this.btnFitSize.Name = "btnFitSize";
            this.btnFitSize.Size = new System.Drawing.Size(252, 23);
            this.btnFitSize.TabIndex = 1;
            this.btnFitSize.Text = "Fit Size";
            this.btnFitSize.UseVisualStyleBackColor = true;
            this.btnFitSize.Click += new System.EventHandler(this.btnFitSize_Click);
            // 
            // btnFilterImage
            // 
            this.btnFilterImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilterImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFilterImage.Location = new System.Drawing.Point(777, 3);
            this.btnFilterImage.Name = "btnFilterImage";
            this.btnFilterImage.Size = new System.Drawing.Size(253, 23);
            this.btnFilterImage.TabIndex = 4;
            this.btnFilterImage.Text = "Filter Image";
            this.btnFilterImage.UseVisualStyleBackColor = true;
            this.btnFilterImage.Click += new System.EventHandler(this.btnFilterImage_Click);
            // 
            // pnlDisplayImage
            // 
            this.pnlDisplayImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayImage.Location = new System.Drawing.Point(3, 73);
            this.pnlDisplayImage.Name = "pnlDisplayImage";
            this.pnlDisplayImage.Size = new System.Drawing.Size(1033, 554);
            this.pnlDisplayImage.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.btnLoadImage, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtImagePath, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1033, 29);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLoadImage.Location = new System.Drawing.Point(996, 3);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(30, 23);
            this.btnLoadImage.TabIndex = 3;
            this.btnLoadImage.Text = "...";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // txtImagePath
            // 
            this.txtImagePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImagePath.Location = new System.Drawing.Point(63, 3);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(927, 21);
            this.txtImagePath.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(54, 23);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path : ";
            // 
            // tabInspectionLogType
            // 
            this.tabInspectionLogType.Controls.Add(this.tabPage1);
            this.tabInspectionLogType.Controls.Add(this.tabPage2);
            this.tabInspectionLogType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInspectionLogType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabInspectionLogType.Location = new System.Drawing.Point(3, 633);
            this.tabInspectionLogType.Name = "tabInspectionLogType";
            this.tabInspectionLogType.SelectedIndex = 0;
            this.tabInspectionLogType.Size = new System.Drawing.Size(1033, 164);
            this.tabInspectionLogType.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbxBrokenLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1025, 135);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Broken";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbxBrokenLog
            // 
            this.lbxBrokenLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxBrokenLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbxBrokenLog.FormattingEnabled = true;
            this.lbxBrokenLog.HorizontalExtent = 1500;
            this.lbxBrokenLog.HorizontalScrollbar = true;
            this.lbxBrokenLog.ItemHeight = 16;
            this.lbxBrokenLog.Location = new System.Drawing.Point(3, 3);
            this.lbxBrokenLog.Name = "lbxBrokenLog";
            this.lbxBrokenLog.Size = new System.Drawing.Size(1019, 129);
            this.lbxBrokenLog.TabIndex = 0;
            this.lbxBrokenLog.SelectedIndexChanged += new System.EventHandler(this.lbxBrokenLog_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbxContourLog);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1025, 135);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contour";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbxContourLog
            // 
            this.lbxContourLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxContourLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbxContourLog.FormattingEnabled = true;
            this.lbxContourLog.HorizontalExtent = 1500;
            this.lbxContourLog.HorizontalScrollbar = true;
            this.lbxContourLog.ItemHeight = 16;
            this.lbxContourLog.Location = new System.Drawing.Point(3, 3);
            this.lbxContourLog.Name = "lbxContourLog";
            this.lbxContourLog.Size = new System.Drawing.Size(1019, 129);
            this.lbxContourLog.TabIndex = 1;
            this.lbxContourLog.SelectedIndexChanged += new System.EventHandler(this.lbxContourLog_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnExcute, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1048, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(274, 800);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnExcute
            // 
            this.btnExcute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExcute.Location = new System.Drawing.Point(3, 768);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(268, 29);
            this.btnExcute.TabIndex = 5;
            this.btnExcute.Text = "Excute";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tabInspectionType, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(268, 759);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.txtOffset);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.ckbOffset);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.cbxDirection);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 124);
            this.panel2.TabIndex = 2;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(217, 82);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 23);
            this.label22.TabIndex = 158;
            this.label22.Text = "pixel";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOffset
            // 
            this.txtOffset.Enabled = false;
            this.txtOffset.Location = new System.Drawing.Point(146, 84);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(68, 21);
            this.txtOffset.TabIndex = 152;
            this.txtOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOffset_KeyPress);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(90, 83);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 23);
            this.label23.TabIndex = 153;
            this.label23.Text = "Offset";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckbOffset
            // 
            this.ckbOffset.AutoSize = true;
            this.ckbOffset.Location = new System.Drawing.Point(146, 53);
            this.ckbOffset.Name = "ckbOffset";
            this.ckbOffset.Size = new System.Drawing.Size(15, 14);
            this.ckbOffset.TabIndex = 157;
            this.ckbOffset.UseVisualStyleBackColor = true;
            this.ckbOffset.CheckedChanged += new System.EventHandler(this.ckbOffset_CheckedChanged);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(43, 47);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 23);
            this.label24.TabIndex = 156;
            this.label24.Text = "Offset Enable";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxDirection
            // 
            this.cbxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDirection.FormattingEnabled = true;
            this.cbxDirection.Location = new System.Drawing.Point(146, 14);
            this.cbxDirection.Name = "cbxDirection";
            this.cbxDirection.Size = new System.Drawing.Size(68, 20);
            this.cbxDirection.TabIndex = 155;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(72, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 23);
            this.label25.TabIndex = 154;
            this.label25.Text = "Direction";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabInspectionType
            // 
            this.tabInspectionType.Controls.Add(this.Broken);
            this.tabInspectionType.Controls.Add(this.Coutour);
            this.tabInspectionType.Controls.Add(this.Processing);
            this.tabInspectionType.Controls.Add(this.Canny);
            this.tabInspectionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInspectionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabInspectionType.Location = new System.Drawing.Point(3, 133);
            this.tabInspectionType.Name = "tabInspectionType";
            this.tabInspectionType.SelectedIndex = 0;
            this.tabInspectionType.Size = new System.Drawing.Size(262, 623);
            this.tabInspectionType.TabIndex = 1;
            this.tabInspectionType.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Broken
            // 
            this.Broken.Controls.Add(this.txtBrokenThres2);
            this.Broken.Controls.Add(this.label6);
            this.Broken.Controls.Add(this.txtBrokenThres1);
            this.Broken.Controls.Add(this.label5);
            this.Broken.Controls.Add(this.txtBrokenTwoDerivativeValue);
            this.Broken.Controls.Add(this.label2);
            this.Broken.Controls.Add(this.label8);
            this.Broken.Controls.Add(this.label9);
            this.Broken.Controls.Add(this.txtBrokenAvgCnt);
            this.Broken.Controls.Add(this.txtBrokenValue);
            this.Broken.Controls.Add(this.label14);
            this.Broken.Controls.Add(this.label17);
            this.Broken.Location = new System.Drawing.Point(4, 25);
            this.Broken.Name = "Broken";
            this.Broken.Padding = new System.Windows.Forms.Padding(3);
            this.Broken.Size = new System.Drawing.Size(254, 594);
            this.Broken.TabIndex = 0;
            this.Broken.Text = "Broken";
            this.Broken.UseVisualStyleBackColor = true;
            // 
            // txtBrokenThres2
            // 
            this.txtBrokenThres2.Location = new System.Drawing.Point(142, 155);
            this.txtBrokenThres2.Name = "txtBrokenThres2";
            this.txtBrokenThres2.Size = new System.Drawing.Size(68, 22);
            this.txtBrokenThres2.TabIndex = 164;
            this.txtBrokenThres2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(54, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 23);
            this.label6.TabIndex = 163;
            this.label6.Text = "Threshold2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBrokenThres1
            // 
            this.txtBrokenThres1.Location = new System.Drawing.Point(142, 118);
            this.txtBrokenThres1.Name = "txtBrokenThres1";
            this.txtBrokenThres1.Size = new System.Drawing.Size(68, 22);
            this.txtBrokenThres1.TabIndex = 162;
            this.txtBrokenThres1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(54, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 23);
            this.label5.TabIndex = 161;
            this.label5.Text = "Threshold1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBrokenTwoDerivativeValue
            // 
            this.txtBrokenTwoDerivativeValue.Location = new System.Drawing.Point(142, 85);
            this.txtBrokenTwoDerivativeValue.Name = "txtBrokenTwoDerivativeValue";
            this.txtBrokenTwoDerivativeValue.Size = new System.Drawing.Size(68, 22);
            this.txtBrokenTwoDerivativeValue.TabIndex = 160;
            this.txtBrokenTwoDerivativeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrokenTwoDerivativeValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBrokenTwoDerivativeValue_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(1, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 23);
            this.label2.TabIndex = 159;
            this.label2.Text = "TwoDerivativeValue";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(213, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 23);
            this.label8.TabIndex = 143;
            this.label8.Text = "pixel";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(33, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 23);
            this.label9.TabIndex = 142;
            this.label9.Text = "Average Count";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBrokenAvgCnt
            // 
            this.txtBrokenAvgCnt.Location = new System.Drawing.Point(142, 51);
            this.txtBrokenAvgCnt.Name = "txtBrokenAvgCnt";
            this.txtBrokenAvgCnt.Size = new System.Drawing.Size(68, 22);
            this.txtBrokenAvgCnt.TabIndex = 141;
            this.txtBrokenAvgCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBrokenValue
            // 
            this.txtBrokenValue.Location = new System.Drawing.Point(142, 16);
            this.txtBrokenValue.Name = "txtBrokenValue";
            this.txtBrokenValue.Size = new System.Drawing.Size(68, 22);
            this.txtBrokenValue.TabIndex = 138;
            this.txtBrokenValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrokenValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBrokenValue_KeyPress);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(213, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 23);
            this.label14.TabIndex = 140;
            this.label14.Text = "pixel";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(39, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 23);
            this.label17.TabIndex = 139;
            this.label17.Text = "Broken Value";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Coutour
            // 
            this.Coutour.Controls.Add(this.txtContourTwoDerivativeValue);
            this.Coutour.Controls.Add(this.label3);
            this.Coutour.Controls.Add(this.ckbDrawInspArea);
            this.Coutour.Controls.Add(this.label21);
            this.Coutour.Controls.Add(this.label19);
            this.Coutour.Controls.Add(this.txtContourInspectionOffset);
            this.Coutour.Controls.Add(this.label11);
            this.Coutour.Controls.Add(this.label12);
            this.Coutour.Controls.Add(this.txtContourInspectionArea);
            this.Coutour.Controls.Add(this.txtContourMinSize);
            this.Coutour.Controls.Add(this.label13);
            this.Coutour.Controls.Add(this.label15);
            this.Coutour.Location = new System.Drawing.Point(4, 25);
            this.Coutour.Name = "Coutour";
            this.Coutour.Padding = new System.Windows.Forms.Padding(3);
            this.Coutour.Size = new System.Drawing.Size(254, 594);
            this.Coutour.TabIndex = 1;
            this.Coutour.Text = "Contour";
            this.Coutour.UseVisualStyleBackColor = true;
            // 
            // txtContourTwoDerivativeValue
            // 
            this.txtContourTwoDerivativeValue.Location = new System.Drawing.Point(142, 16);
            this.txtContourTwoDerivativeValue.Name = "txtContourTwoDerivativeValue";
            this.txtContourTwoDerivativeValue.Size = new System.Drawing.Size(68, 22);
            this.txtContourTwoDerivativeValue.TabIndex = 162;
            this.txtContourTwoDerivativeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContourTwoDerivativeValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContourTwoDerivativeValue_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(1, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 23);
            this.label3.TabIndex = 161;
            this.label3.Text = "TwoDerivativeValue";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbDrawInspArea
            // 
            this.ckbDrawInspArea.AutoSize = true;
            this.ckbDrawInspArea.Location = new System.Drawing.Point(142, 151);
            this.ckbDrawInspArea.Name = "ckbDrawInspArea";
            this.ckbDrawInspArea.Size = new System.Drawing.Size(15, 14);
            this.ckbDrawInspArea.TabIndex = 160;
            this.ckbDrawInspArea.UseVisualStyleBackColor = true;
            this.ckbDrawInspArea.CheckedChanged += new System.EventHandler(this.ckbDrawInspArea_CheckedChanged);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(32, 145);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 23);
            this.label21.TabIndex = 159;
            this.label21.Text = "Draw InspArea";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(18, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 23);
            this.label19.TabIndex = 156;
            this.label19.Text = "Inspection Offset";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContourInspectionOffset
            // 
            this.txtContourInspectionOffset.Location = new System.Drawing.Point(142, 50);
            this.txtContourInspectionOffset.Name = "txtContourInspectionOffset";
            this.txtContourInspectionOffset.Size = new System.Drawing.Size(68, 22);
            this.txtContourInspectionOffset.TabIndex = 155;
            this.txtContourInspectionOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContourInspectionOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContourInspectionOffset_KeyPress);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(213, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 23);
            this.label11.TabIndex = 145;
            this.label11.Text = "pixel";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(26, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 23);
            this.label12.TabIndex = 144;
            this.label12.Text = "Inspection Area";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContourInspectionArea
            // 
            this.txtContourInspectionArea.Location = new System.Drawing.Point(142, 83);
            this.txtContourInspectionArea.Name = "txtContourInspectionArea";
            this.txtContourInspectionArea.Size = new System.Drawing.Size(68, 22);
            this.txtContourInspectionArea.TabIndex = 143;
            this.txtContourInspectionArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContourInspectionArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContourInspectionArea_KeyPress);
            // 
            // txtContourMinSize
            // 
            this.txtContourMinSize.Location = new System.Drawing.Point(142, 117);
            this.txtContourMinSize.Name = "txtContourMinSize";
            this.txtContourMinSize.Size = new System.Drawing.Size(68, 22);
            this.txtContourMinSize.TabIndex = 140;
            this.txtContourMinSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(213, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 23);
            this.label13.TabIndex = 142;
            this.label13.Text = "pixel";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(29, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 23);
            this.label15.TabIndex = 141;
            this.label15.Text = "Min Size (W/H)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Processing
            // 
            this.Processing.Controls.Add(this.cbxProcessingFilterType);
            this.Processing.Controls.Add(this.label4);
            this.Processing.Controls.Add(this.nupdnTwoDerivativeValue);
            this.Processing.Controls.Add(this.label7);
            this.Processing.Location = new System.Drawing.Point(4, 25);
            this.Processing.Name = "Processing";
            this.Processing.Size = new System.Drawing.Size(254, 594);
            this.Processing.TabIndex = 2;
            this.Processing.Text = "Processing";
            this.Processing.UseVisualStyleBackColor = true;
            // 
            // cbxProcessingFilterType
            // 
            this.cbxProcessingFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProcessingFilterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cbxProcessingFilterType.FormattingEnabled = true;
            this.cbxProcessingFilterType.Location = new System.Drawing.Point(141, 13);
            this.cbxProcessingFilterType.Name = "cbxProcessingFilterType";
            this.cbxProcessingFilterType.Size = new System.Drawing.Size(69, 23);
            this.cbxProcessingFilterType.TabIndex = 150;
            this.cbxProcessingFilterType.SelectedIndexChanged += new System.EventHandler(this.cbxProcessingFilterType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(59, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 149;
            this.label4.Text = "Filter Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nupdnTwoDerivativeValue
            // 
            this.nupdnTwoDerivativeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.nupdnTwoDerivativeValue.Location = new System.Drawing.Point(141, 46);
            this.nupdnTwoDerivativeValue.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nupdnTwoDerivativeValue.Name = "nupdnTwoDerivativeValue";
            this.nupdnTwoDerivativeValue.Size = new System.Drawing.Size(100, 21);
            this.nupdnTwoDerivativeValue.TabIndex = 148;
            this.nupdnTwoDerivativeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupdnTwoDerivativeValue.ValueChanged += new System.EventHandler(this.nupdnTwoDerivativeValue_ValueChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(1, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 23);
            this.label7.TabIndex = 146;
            this.label7.Text = "TwoDerivativeValue";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Canny
            // 
            this.Canny.Controls.Add(this.txtCannyThres2);
            this.Canny.Controls.Add(this.label10);
            this.Canny.Controls.Add(this.txtCannyThres1);
            this.Canny.Controls.Add(this.label16);
            this.Canny.Location = new System.Drawing.Point(4, 25);
            this.Canny.Name = "Canny";
            this.Canny.Size = new System.Drawing.Size(254, 594);
            this.Canny.TabIndex = 3;
            this.Canny.Text = "Canny";
            this.Canny.UseVisualStyleBackColor = true;
            // 
            // txtCannyThres2
            // 
            this.txtCannyThres2.Location = new System.Drawing.Point(142, 50);
            this.txtCannyThres2.Name = "txtCannyThres2";
            this.txtCannyThres2.Size = new System.Drawing.Size(68, 22);
            this.txtCannyThres2.TabIndex = 168;
            this.txtCannyThres2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(54, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 23);
            this.label10.TabIndex = 167;
            this.label10.Text = "Threshold2";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCannyThres1
            // 
            this.txtCannyThres1.Location = new System.Drawing.Point(142, 16);
            this.txtCannyThres1.Name = "txtCannyThres1";
            this.txtCannyThres1.Size = new System.Drawing.Size(68, 22);
            this.txtCannyThres1.TabIndex = 166;
            this.txtCannyThres1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(54, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 23);
            this.label16.TabIndex = 165;
            this.label16.Text = "Threshold1";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormRuleProcessImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 806);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormRuleProcessImage";
            this.Text = "FormRuleProcessImage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRuleProcessImage_FormClosed);
            this.Load += new System.EventHandler(this.FormRuleProcessImage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabInspectionLogType.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabInspectionType.ResumeLayout(false);
            this.Broken.ResumeLayout(false);
            this.Broken.PerformLayout();
            this.Coutour.ResumeLayout(false);
            this.Coutour.PerformLayout();
            this.Processing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupdnTwoDerivativeValue)).EndInit();
            this.Canny.ResumeLayout(false);
            this.Canny.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TabControl tabInspectionType;
        private System.Windows.Forms.TabPage Broken;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBrokenAvgCnt;
        private System.Windows.Forms.TextBox txtBrokenValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage Coutour;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDisplayImage;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.TabPage Processing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtContourInspectionArea;
        private System.Windows.Forms.TextBox txtContourMinSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnFitSize;
        private System.Windows.Forms.Button btnOrizinalSize;
        private System.Windows.Forms.Button btnOriginalImage;
        private System.Windows.Forms.Button btnFilterImage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtContourInspectionOffset;
        private System.Windows.Forms.CheckBox ckbDrawInspArea;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown nupdnTwoDerivativeValue;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox ckbOffset;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbxDirection;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtBrokenTwoDerivativeValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContourTwoDerivativeValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxProcessingFilterType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabInspectionLogType;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lbxBrokenLog;
        private System.Windows.Forms.TextBox txtBrokenThres2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBrokenThres1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage Canny;
        private System.Windows.Forms.TextBox txtCannyThres2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCannyThres1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox lbxContourLog;
    }
}