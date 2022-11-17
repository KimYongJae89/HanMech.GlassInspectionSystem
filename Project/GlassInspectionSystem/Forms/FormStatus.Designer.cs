namespace GlassInspectionSystem.Forms
{
    partial class FormStatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gvCamInfoList = new System.Windows.Forms.DataGridView();
            this.ColumnCamNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCamAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCamStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbPCHeartBeat = new System.Windows.Forms.Label();
            this.txtWritePcHeartBeat = new System.Windows.Forms.TextBox();
            this.cbxPCJudge = new System.Windows.Forms.ComboBox();
            this.lbPCJudge = new System.Windows.Forms.Label();
            this.btnWritePcResultClear = new System.Windows.Forms.Button();
            this.lbPCInspComplete = new System.Windows.Forms.Label();
            this.btnWritePcCrack = new System.Windows.Forms.Button();
            this.lbPCBroken = new System.Windows.Forms.Label();
            this.btnWritePcChipping = new System.Windows.Forms.Button();
            this.lbPCChipping = new System.Windows.Forms.Label();
            this.btnWirtePcBroken = new System.Windows.Forms.Button();
            this.lbPCCrack = new System.Windows.Forms.Label();
            this.btnWritePcInspComplete = new System.Windows.Forms.Button();
            this.lbPCClear = new System.Windows.Forms.Label();
            this.btnWritePcJudge = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReadPCDefectType = new System.Windows.Forms.TextBox();
            this.lbPLCCVDirection = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReadPlcHeartBit = new System.Windows.Forms.TextBox();
            this.txtReadPcInspComplete = new System.Windows.Forms.TextBox();
            this.txtReadPlcGlassInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPLCHeartbeat = new System.Windows.Forms.Label();
            this.txtReadPcJudge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReadPlcDateTime = new System.Windows.Forms.TextBox();
            this.txtReadPcHeartBit = new System.Windows.Forms.TextBox();
            this.lbPLCDateTime = new System.Windows.Forms.Label();
            this.txtReadPlcGlassID = new System.Windows.Forms.TextBox();
            this.txtReadPlcCVDirection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReadPlcRealVelocity = new System.Windows.Forms.TextBox();
            this.lbPLCRealVel = new System.Windows.Forms.Label();
            this.txtReadPlcTargetVelocity = new System.Windows.Forms.TextBox();
            this.lbPLCTargetVel = new System.Windows.Forms.Label();
            this.txtReadPlcSlowVelocity = new System.Windows.Forms.TextBox();
            this.lbPLCSlowtVel = new System.Windows.Forms.Label();
            this.txtReadPlcGlassType = new System.Windows.Forms.TextBox();
            this.lbGlassType = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCamInfoList)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(555, 407);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvCamInfoList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(547, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Camera";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gvCamInfoList
            // 
            this.gvCamInfoList.AllowUserToAddRows = false;
            this.gvCamInfoList.AllowUserToDeleteRows = false;
            this.gvCamInfoList.AllowUserToResizeRows = false;
            this.gvCamInfoList.BackgroundColor = System.Drawing.Color.White;
            this.gvCamInfoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCamInfoList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCamInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvCamInfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCamNo,
            this.ColumnSerialNo,
            this.ColumnCamAddress,
            this.ColumnCamStatus});
            this.gvCamInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCamInfoList.Location = new System.Drawing.Point(3, 3);
            this.gvCamInfoList.MultiSelect = false;
            this.gvCamInfoList.Name = "gvCamInfoList";
            this.gvCamInfoList.ReadOnly = true;
            this.gvCamInfoList.RowHeadersVisible = false;
            this.gvCamInfoList.RowTemplate.Height = 23;
            this.gvCamInfoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvCamInfoList.Size = new System.Drawing.Size(541, 375);
            this.gvCamInfoList.TabIndex = 2;
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
            // ColumnSerialNo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnSerialNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnSerialNo.HeaderText = "Serial No.";
            this.ColumnSerialNo.MinimumWidth = 150;
            this.ColumnSerialNo.Name = "ColumnSerialNo";
            this.ColumnSerialNo.ReadOnly = true;
            this.ColumnSerialNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSerialNo.Width = 150;
            // 
            // ColumnCamAddress
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnCamAddress.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnCamAddress.FillWeight = 200F;
            this.ColumnCamAddress.HeaderText = "Cam Address";
            this.ColumnCamAddress.MinimumWidth = 80;
            this.ColumnCamAddress.Name = "ColumnCamAddress";
            this.ColumnCamAddress.ReadOnly = true;
            this.ColumnCamAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnCamAddress.Width = 160;
            // 
            // ColumnCamStatus
            // 
            this.ColumnCamStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnCamStatus.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnCamStatus.HeaderText = "Cam Status";
            this.ColumnCamStatus.MinimumWidth = 80;
            this.ColumnCamStatus.Name = "ColumnCamStatus";
            this.ColumnCamStatus.ReadOnly = true;
            this.ColumnCamStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(547, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PLC";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 375);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PLC Communication";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbPCHeartBeat);
            this.groupBox3.Controls.Add(this.txtWritePcHeartBeat);
            this.groupBox3.Controls.Add(this.cbxPCJudge);
            this.groupBox3.Controls.Add(this.lbPCJudge);
            this.groupBox3.Controls.Add(this.btnWritePcResultClear);
            this.groupBox3.Controls.Add(this.lbPCInspComplete);
            this.groupBox3.Controls.Add(this.btnWritePcCrack);
            this.groupBox3.Controls.Add(this.lbPCBroken);
            this.groupBox3.Controls.Add(this.btnWritePcChipping);
            this.groupBox3.Controls.Add(this.lbPCChipping);
            this.groupBox3.Controls.Add(this.btnWirtePcBroken);
            this.groupBox3.Controls.Add(this.lbPCCrack);
            this.groupBox3.Controls.Add(this.btnWritePcInspComplete);
            this.groupBox3.Controls.Add(this.lbPCClear);
            this.groupBox3.Controls.Add(this.btnWritePcJudge);
            this.groupBox3.Location = new System.Drawing.Point(3, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(530, 134);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Write Data(PC->PLC)";
            // 
            // lbPCHeartBeat
            // 
            this.lbPCHeartBeat.Location = new System.Drawing.Point(6, 17);
            this.lbPCHeartBeat.Name = "lbPCHeartBeat";
            this.lbPCHeartBeat.Size = new System.Drawing.Size(100, 23);
            this.lbPCHeartBeat.TabIndex = 20;
            this.lbPCHeartBeat.Text = "PC HeartBeat";
            this.lbPCHeartBeat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWritePcHeartBeat
            // 
            this.txtWritePcHeartBeat.Location = new System.Drawing.Point(140, 16);
            this.txtWritePcHeartBeat.Name = "txtWritePcHeartBeat";
            this.txtWritePcHeartBeat.ReadOnly = true;
            this.txtWritePcHeartBeat.Size = new System.Drawing.Size(71, 21);
            this.txtWritePcHeartBeat.TabIndex = 17;
            this.txtWritePcHeartBeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxPCJudge
            // 
            this.cbxPCJudge.FormattingEnabled = true;
            this.cbxPCJudge.Location = new System.Drawing.Point(376, 72);
            this.cbxPCJudge.Name = "cbxPCJudge";
            this.cbxPCJudge.Size = new System.Drawing.Size(71, 20);
            this.cbxPCJudge.TabIndex = 53;
            // 
            // lbPCJudge
            // 
            this.lbPCJudge.Location = new System.Drawing.Point(228, 70);
            this.lbPCJudge.Name = "lbPCJudge";
            this.lbPCJudge.Size = new System.Drawing.Size(100, 23);
            this.lbPCJudge.TabIndex = 21;
            this.lbPCJudge.Text = "PC Judge";
            this.lbPCJudge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWritePcResultClear
            // 
            this.btnWritePcResultClear.Location = new System.Drawing.Point(376, 14);
            this.btnWritePcResultClear.Name = "btnWritePcResultClear";
            this.btnWritePcResultClear.Size = new System.Drawing.Size(71, 23);
            this.btnWritePcResultClear.TabIndex = 52;
            this.btnWritePcResultClear.Text = "Set";
            this.btnWritePcResultClear.UseVisualStyleBackColor = true;
            this.btnWritePcResultClear.Click += new System.EventHandler(this.btnPCResultClear_Click);
            // 
            // lbPCInspComplete
            // 
            this.lbPCInspComplete.Location = new System.Drawing.Point(228, 43);
            this.lbPCInspComplete.Name = "lbPCInspComplete";
            this.lbPCInspComplete.Size = new System.Drawing.Size(109, 23);
            this.lbPCInspComplete.TabIndex = 22;
            this.lbPCInspComplete.Text = "PC Insp Complete";
            this.lbPCInspComplete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWritePcCrack
            // 
            this.btnWritePcCrack.Location = new System.Drawing.Point(140, 97);
            this.btnWritePcCrack.Name = "btnWritePcCrack";
            this.btnWritePcCrack.Size = new System.Drawing.Size(71, 23);
            this.btnWritePcCrack.TabIndex = 51;
            this.btnWritePcCrack.Text = "Set";
            this.btnWritePcCrack.UseVisualStyleBackColor = true;
            this.btnWritePcCrack.Click += new System.EventHandler(this.btnPCCrack_Click);
            // 
            // lbPCBroken
            // 
            this.lbPCBroken.Location = new System.Drawing.Point(6, 43);
            this.lbPCBroken.Name = "lbPCBroken";
            this.lbPCBroken.Size = new System.Drawing.Size(100, 23);
            this.lbPCBroken.TabIndex = 29;
            this.lbPCBroken.Text = "Broken";
            this.lbPCBroken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWritePcChipping
            // 
            this.btnWritePcChipping.Location = new System.Drawing.Point(140, 70);
            this.btnWritePcChipping.Name = "btnWritePcChipping";
            this.btnWritePcChipping.Size = new System.Drawing.Size(71, 23);
            this.btnWritePcChipping.TabIndex = 50;
            this.btnWritePcChipping.Text = "Set";
            this.btnWritePcChipping.UseVisualStyleBackColor = true;
            this.btnWritePcChipping.Click += new System.EventHandler(this.btnPCChipping_Click);
            // 
            // lbPCChipping
            // 
            this.lbPCChipping.Location = new System.Drawing.Point(6, 70);
            this.lbPCChipping.Name = "lbPCChipping";
            this.lbPCChipping.Size = new System.Drawing.Size(100, 23);
            this.lbPCChipping.TabIndex = 31;
            this.lbPCChipping.Text = "Chipping";
            this.lbPCChipping.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWirtePcBroken
            // 
            this.btnWirtePcBroken.Location = new System.Drawing.Point(140, 41);
            this.btnWirtePcBroken.Name = "btnWirtePcBroken";
            this.btnWirtePcBroken.Size = new System.Drawing.Size(71, 23);
            this.btnWirtePcBroken.TabIndex = 49;
            this.btnWirtePcBroken.Text = "Set";
            this.btnWirtePcBroken.UseVisualStyleBackColor = true;
            this.btnWirtePcBroken.Click += new System.EventHandler(this.btnPCBroken_Click);
            // 
            // lbPCCrack
            // 
            this.lbPCCrack.Location = new System.Drawing.Point(6, 97);
            this.lbPCCrack.Name = "lbPCCrack";
            this.lbPCCrack.Size = new System.Drawing.Size(100, 23);
            this.lbPCCrack.TabIndex = 33;
            this.lbPCCrack.Text = "Crack";
            this.lbPCCrack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWritePcInspComplete
            // 
            this.btnWritePcInspComplete.Location = new System.Drawing.Point(376, 41);
            this.btnWritePcInspComplete.Name = "btnWritePcInspComplete";
            this.btnWritePcInspComplete.Size = new System.Drawing.Size(71, 23);
            this.btnWritePcInspComplete.TabIndex = 48;
            this.btnWritePcInspComplete.Text = "Set";
            this.btnWritePcInspComplete.UseVisualStyleBackColor = true;
            this.btnWritePcInspComplete.Click += new System.EventHandler(this.btnPCInspectionComplete_Click);
            // 
            // lbPCClear
            // 
            this.lbPCClear.Location = new System.Drawing.Point(228, 17);
            this.lbPCClear.Name = "lbPCClear";
            this.lbPCClear.Size = new System.Drawing.Size(100, 23);
            this.lbPCClear.TabIndex = 35;
            this.lbPCClear.Text = "Result Clear";
            this.lbPCClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWritePcJudge
            // 
            this.btnWritePcJudge.Location = new System.Drawing.Point(453, 72);
            this.btnWritePcJudge.Name = "btnWritePcJudge";
            this.btnWritePcJudge.Size = new System.Drawing.Size(59, 23);
            this.btnWritePcJudge.TabIndex = 3;
            this.btnWritePcJudge.Text = "Set";
            this.btnWritePcJudge.UseVisualStyleBackColor = true;
            this.btnWritePcJudge.Click += new System.EventHandler(this.btnPCJudge_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtReadPCDefectType);
            this.groupBox2.Controls.Add(this.lbPLCCVDirection);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtReadPlcHeartBit);
            this.groupBox2.Controls.Add(this.txtReadPcInspComplete);
            this.groupBox2.Controls.Add(this.txtReadPlcGlassInput);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbPLCHeartbeat);
            this.groupBox2.Controls.Add(this.txtReadPcJudge);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtReadPlcDateTime);
            this.groupBox2.Controls.Add(this.txtReadPcHeartBit);
            this.groupBox2.Controls.Add(this.lbPLCDateTime);
            this.groupBox2.Controls.Add(this.txtReadPlcGlassID);
            this.groupBox2.Controls.Add(this.txtReadPlcCVDirection);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtReadPlcRealVelocity);
            this.groupBox2.Controls.Add(this.lbPLCRealVel);
            this.groupBox2.Controls.Add(this.txtReadPlcTargetVelocity);
            this.groupBox2.Controls.Add(this.lbPLCTargetVel);
            this.groupBox2.Controls.Add(this.txtReadPlcSlowVelocity);
            this.groupBox2.Controls.Add(this.lbPLCSlowtVel);
            this.groupBox2.Controls.Add(this.txtReadPlcGlassType);
            this.groupBox2.Controls.Add(this.lbGlassType);
            this.groupBox2.Location = new System.Drawing.Point(3, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 212);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Read Data(PLC->PC)";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(228, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 63;
            this.label5.Text = "PC Defect Type";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadPCDefectType
            // 
            this.txtReadPCDefectType.Location = new System.Drawing.Point(376, 154);
            this.txtReadPCDefectType.Name = "txtReadPCDefectType";
            this.txtReadPCDefectType.ReadOnly = true;
            this.txtReadPCDefectType.Size = new System.Drawing.Size(71, 21);
            this.txtReadPCDefectType.TabIndex = 62;
            this.txtReadPCDefectType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPLCCVDirection
            // 
            this.lbPLCCVDirection.Location = new System.Drawing.Point(6, 51);
            this.lbPLCCVDirection.Name = "lbPLCCVDirection";
            this.lbPLCCVDirection.Size = new System.Drawing.Size(109, 23);
            this.lbPLCCVDirection.TabIndex = 39;
            this.lbPLCCVDirection.Text = "PLC CV Direction";
            this.lbPLCCVDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(228, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 23);
            this.label7.TabIndex = 61;
            this.label7.Text = "PC Insp Complete";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadPlcHeartBit
            // 
            this.txtReadPlcHeartBit.Location = new System.Drawing.Point(137, 23);
            this.txtReadPlcHeartBit.Name = "txtReadPlcHeartBit";
            this.txtReadPlcHeartBit.ReadOnly = true;
            this.txtReadPlcHeartBit.Size = new System.Drawing.Size(74, 21);
            this.txtReadPlcHeartBit.TabIndex = 7;
            this.txtReadPlcHeartBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReadPcInspComplete
            // 
            this.txtReadPcInspComplete.Location = new System.Drawing.Point(376, 181);
            this.txtReadPcInspComplete.Name = "txtReadPcInspComplete";
            this.txtReadPcInspComplete.ReadOnly = true;
            this.txtReadPcInspComplete.Size = new System.Drawing.Size(71, 21);
            this.txtReadPcInspComplete.TabIndex = 60;
            this.txtReadPcInspComplete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReadPlcGlassInput
            // 
            this.txtReadPlcGlassInput.Location = new System.Drawing.Point(137, 160);
            this.txtReadPlcGlassInput.Name = "txtReadPlcGlassInput";
            this.txtReadPlcGlassInput.ReadOnly = true;
            this.txtReadPlcGlassInput.Size = new System.Drawing.Size(74, 21);
            this.txtReadPlcGlassInput.TabIndex = 10;
            this.txtReadPlcGlassInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(228, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 59;
            this.label3.Text = "PC Judge(OK/NG/ERR)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPLCHeartbeat
            // 
            this.lbPLCHeartbeat.Location = new System.Drawing.Point(6, 23);
            this.lbPLCHeartbeat.Name = "lbPLCHeartbeat";
            this.lbPLCHeartbeat.Size = new System.Drawing.Size(100, 23);
            this.lbPLCHeartbeat.TabIndex = 11;
            this.lbPLCHeartbeat.Text = "PLC HeartBeat";
            this.lbPLCHeartbeat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadPcJudge
            // 
            this.txtReadPcJudge.Location = new System.Drawing.Point(376, 127);
            this.txtReadPcJudge.Name = "txtReadPcJudge";
            this.txtReadPcJudge.ReadOnly = true;
            this.txtReadPcJudge.Size = new System.Drawing.Size(71, 21);
            this.txtReadPcJudge.TabIndex = 58;
            this.txtReadPcJudge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Glass Input";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(228, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 57;
            this.label2.Text = "PC HeartBit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadPlcDateTime
            // 
            this.txtReadPlcDateTime.Location = new System.Drawing.Point(376, 19);
            this.txtReadPlcDateTime.Name = "txtReadPlcDateTime";
            this.txtReadPlcDateTime.ReadOnly = true;
            this.txtReadPlcDateTime.Size = new System.Drawing.Size(137, 21);
            this.txtReadPlcDateTime.TabIndex = 36;
            this.txtReadPlcDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReadPcHeartBit
            // 
            this.txtReadPcHeartBit.Location = new System.Drawing.Point(376, 100);
            this.txtReadPcHeartBit.Name = "txtReadPcHeartBit";
            this.txtReadPcHeartBit.ReadOnly = true;
            this.txtReadPcHeartBit.Size = new System.Drawing.Size(71, 21);
            this.txtReadPcHeartBit.TabIndex = 56;
            this.txtReadPcHeartBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPLCDateTime
            // 
            this.lbPLCDateTime.Location = new System.Drawing.Point(228, 17);
            this.lbPLCDateTime.Name = "lbPLCDateTime";
            this.lbPLCDateTime.Size = new System.Drawing.Size(100, 23);
            this.lbPLCDateTime.TabIndex = 37;
            this.lbPLCDateTime.Text = "PLC DateTime";
            this.lbPLCDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadPlcGlassID
            // 
            this.txtReadPlcGlassID.Location = new System.Drawing.Point(376, 46);
            this.txtReadPlcGlassID.Name = "txtReadPlcGlassID";
            this.txtReadPlcGlassID.ReadOnly = true;
            this.txtReadPlcGlassID.Size = new System.Drawing.Size(137, 21);
            this.txtReadPlcGlassID.TabIndex = 55;
            this.txtReadPlcGlassID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReadPlcCVDirection
            // 
            this.txtReadPlcCVDirection.Location = new System.Drawing.Point(137, 52);
            this.txtReadPlcCVDirection.Name = "txtReadPlcCVDirection";
            this.txtReadPlcCVDirection.ReadOnly = true;
            this.txtReadPlcCVDirection.Size = new System.Drawing.Size(74, 21);
            this.txtReadPlcCVDirection.TabIndex = 38;
            this.txtReadPlcCVDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(228, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 54;
            this.label1.Text = "GlassID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadPlcRealVelocity
            // 
            this.txtReadPlcRealVelocity.Location = new System.Drawing.Point(137, 79);
            this.txtReadPlcRealVelocity.Name = "txtReadPlcRealVelocity";
            this.txtReadPlcRealVelocity.ReadOnly = true;
            this.txtReadPlcRealVelocity.Size = new System.Drawing.Size(74, 21);
            this.txtReadPlcRealVelocity.TabIndex = 40;
            this.txtReadPlcRealVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPLCRealVel
            // 
            this.lbPLCRealVel.Location = new System.Drawing.Point(6, 78);
            this.lbPLCRealVel.Name = "lbPLCRealVel";
            this.lbPLCRealVel.Size = new System.Drawing.Size(124, 23);
            this.lbPLCRealVel.TabIndex = 41;
            this.lbPLCRealVel.Text = "Conv. Current Vel.";
            this.lbPLCRealVel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadPlcTargetVelocity
            // 
            this.txtReadPlcTargetVelocity.Location = new System.Drawing.Point(137, 106);
            this.txtReadPlcTargetVelocity.Name = "txtReadPlcTargetVelocity";
            this.txtReadPlcTargetVelocity.ReadOnly = true;
            this.txtReadPlcTargetVelocity.Size = new System.Drawing.Size(74, 21);
            this.txtReadPlcTargetVelocity.TabIndex = 42;
            this.txtReadPlcTargetVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPLCTargetVel
            // 
            this.lbPLCTargetVel.Location = new System.Drawing.Point(6, 105);
            this.lbPLCTargetVel.Name = "lbPLCTargetVel";
            this.lbPLCTargetVel.Size = new System.Drawing.Size(122, 23);
            this.lbPLCTargetVel.TabIndex = 43;
            this.lbPLCTargetVel.Text = "Conv. Target Vel.";
            this.lbPLCTargetVel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadPlcSlowVelocity
            // 
            this.txtReadPlcSlowVelocity.Location = new System.Drawing.Point(137, 133);
            this.txtReadPlcSlowVelocity.Name = "txtReadPlcSlowVelocity";
            this.txtReadPlcSlowVelocity.ReadOnly = true;
            this.txtReadPlcSlowVelocity.Size = new System.Drawing.Size(74, 21);
            this.txtReadPlcSlowVelocity.TabIndex = 44;
            this.txtReadPlcSlowVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPLCSlowtVel
            // 
            this.lbPLCSlowtVel.Location = new System.Drawing.Point(6, 132);
            this.lbPLCSlowtVel.Name = "lbPLCSlowtVel";
            this.lbPLCSlowtVel.Size = new System.Drawing.Size(122, 23);
            this.lbPLCSlowtVel.TabIndex = 45;
            this.lbPLCSlowtVel.Text = "Conv. Slow Vel.";
            this.lbPLCSlowtVel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadPlcGlassType
            // 
            this.txtReadPlcGlassType.Location = new System.Drawing.Point(376, 73);
            this.txtReadPlcGlassType.Name = "txtReadPlcGlassType";
            this.txtReadPlcGlassType.ReadOnly = true;
            this.txtReadPlcGlassType.Size = new System.Drawing.Size(137, 21);
            this.txtReadPlcGlassType.TabIndex = 46;
            this.txtReadPlcGlassType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbGlassType
            // 
            this.lbGlassType.Location = new System.Drawing.Point(228, 72);
            this.lbGlassType.Name = "lbGlassType";
            this.lbGlassType.Size = new System.Drawing.Size(100, 23);
            this.lbGlassType.TabIndex = 47;
            this.lbGlassType.Text = "Glass Type";
            this.lbGlassType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 407);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormStatus";
            this.Text = "Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStatus_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormStatus_FormClosed);
            this.Load += new System.EventHandler(this.FormStatus_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCamInfoList)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gvCamInfoList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbPCCrack;
        private System.Windows.Forms.Label lbPCChipping;
        private System.Windows.Forms.Label lbPCBroken;
        private System.Windows.Forms.Label lbPCInspComplete;
        private System.Windows.Forms.Label lbPCJudge;
        private System.Windows.Forms.Label lbPCHeartBeat;
        private System.Windows.Forms.TextBox txtWritePcHeartBeat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPLCHeartbeat;
        private System.Windows.Forms.TextBox txtReadPlcGlassInput;
        private System.Windows.Forms.TextBox txtReadPlcHeartBit;
        private System.Windows.Forms.Label lbPLCDateTime;
        private System.Windows.Forms.TextBox txtReadPlcDateTime;
        private System.Windows.Forms.Label lbPCClear;
        private System.Windows.Forms.Label lbPLCCVDirection;
        private System.Windows.Forms.TextBox txtReadPlcCVDirection;
        private System.Windows.Forms.Label lbPLCRealVel;
        private System.Windows.Forms.TextBox txtReadPlcRealVelocity;
        private System.Windows.Forms.Label lbPLCTargetVel;
        private System.Windows.Forms.TextBox txtReadPlcTargetVelocity;
        private System.Windows.Forms.Label lbPLCSlowtVel;
        private System.Windows.Forms.TextBox txtReadPlcSlowVelocity;
        private System.Windows.Forms.Label lbGlassType;
        private System.Windows.Forms.TextBox txtReadPlcGlassType;
        private System.Windows.Forms.Button btnWritePcResultClear;
        private System.Windows.Forms.Button btnWritePcCrack;
        private System.Windows.Forms.Button btnWritePcChipping;
        private System.Windows.Forms.Button btnWirtePcBroken;
        private System.Windows.Forms.Button btnWritePcInspComplete;
        private System.Windows.Forms.Button btnWritePcJudge;
        private System.Windows.Forms.ComboBox cbxPCJudge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCamNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCamAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCamStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReadPcInspComplete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReadPcJudge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReadPcHeartBit;
        private System.Windows.Forms.TextBox txtReadPlcGlassID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReadPCDefectType;
    }
}