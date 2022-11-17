namespace GlassInspectionSystem.Forms
{
    partial class FormSettings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.pnlDevice = new System.Windows.Forms.Panel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxCameraType = new System.Windows.Forms.ComboBox();
            this.txtCamCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDioCardNo = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.cbxDioBoardType = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txtStartGrabDelay = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtEndGrabDelay = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxInspectionTriggerType = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cbxLineRateType = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtConstantVel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxShading = new System.Windows.Forms.ComboBox();
            this.btnOpenCameraSettings = new System.Windows.Forms.Button();
            this.ckbEnableShading = new System.Windows.Forms.CheckBox();
            this.btnCameraApply = new System.Windows.Forms.Button();
            this.cbxCamNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nupdnExposure = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.gbxPLC = new System.Windows.Forms.GroupBox();
            this.btnOpenPLCAddressSetting = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPLCType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPlcPortNumber = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetLightValue = new System.Windows.Forms.Button();
            this.txtLightValue = new System.Windows.Forms.TextBox();
            this.cbxSerialLightType = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnLightOff = new System.Windows.Forms.Button();
            this.btnLightOn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxComPort = new System.Windows.Forms.ComboBox();
            this.cbxLightType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabInspection = new System.Windows.Forms.TabPage();
            this.pnlInspection = new System.Windows.Forms.Panel();
            this.btnOpenViewer = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.ckbUseForkContour = new System.Windows.Forms.CheckBox();
            this.btnForkContourProperty = new System.Windows.Forms.Button();
            this.ckbUseForkBroken = new System.Windows.Forms.CheckBox();
            this.btnForkDetect = new System.Windows.Forms.Button();
            this.btnForkBrokenProperty = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtRBCornerSize = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtRTCornerSize = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtLBCornerSize = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtLTCornerSize = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckbUseAI = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAIProperty = new System.Windows.Forms.Button();
            this.cbxAiType = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ckbUseEdgeContour = new System.Windows.Forms.CheckBox();
            this.btnEdgeContourProperty = new System.Windows.Forms.Button();
            this.ckbUseEdgeBroken = new System.Windows.Forms.CheckBox();
            this.btnEdgeDetect = new System.Windows.Forms.Button();
            this.btnEdgeBrokenProperty = new System.Windows.Forms.Button();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbxSaveMergeImageType = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtImageSavePeriod = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.ckbDrawCorner = new System.Windows.Forms.CheckBox();
            this.ckbGlassInOut = new System.Windows.Forms.CheckBox();
            this.cbxHardDisk2 = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cbxHardDisk1 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.ckbUsePLCTime = new System.Windows.Forms.CheckBox();
            this.cbxSaveAICropImageType = new System.Windows.Forms.ComboBox();
            this.ckbSaveMergeImage = new System.Windows.Forms.CheckBox();
            this.cbxSaveSubImageType = new System.Windows.Forms.ComboBox();
            this.btnDBFolderPath = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.ckbUseGrabEdgeDetect = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtLogSavePeriod = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.ckbUseByPass = new System.Windows.Forms.CheckBox();
            this.ckbUseTestMode = new System.Windows.Forms.CheckBox();
            this.ckbSaveCropImage = new System.Windows.Forms.CheckBox();
            this.ckbSaveSubImage = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ckbTwoEdge = new System.Windows.Forms.CheckBox();
            this.label53 = new System.Windows.Forms.Label();
            this.txtCameraInterval = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtThumbnailRatio = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.cbxOriginDirection = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtFov = new System.Windows.Forms.TextBox();
            this.txtGlassHeight = new System.Windows.Forms.TextBox();
            this.txtGlassWidth = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtImageFolderPath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDevice.SuspendLayout();
            this.pnlDevice.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnExposure)).BeginInit();
            this.gbxPLC.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabInspection.SuspendLayout();
            this.pnlInspection.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(815, 468);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDevice);
            this.tabControl1.Controls.Add(this.tabInspection);
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 412);
            this.tabControl1.TabIndex = 2;
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.pnlDevice);
            this.tabDevice.Location = new System.Drawing.Point(4, 24);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Size = new System.Drawing.Size(801, 384);
            this.tabDevice.TabIndex = 0;
            this.tabDevice.Text = "Device";
            this.tabDevice.UseVisualStyleBackColor = true;
            // 
            // pnlDevice
            // 
            this.pnlDevice.Controls.Add(this.groupBox9);
            this.pnlDevice.Controls.Add(this.groupBox3);
            this.pnlDevice.Controls.Add(this.groupBox8);
            this.pnlDevice.Controls.Add(this.groupBox1);
            this.pnlDevice.Controls.Add(this.gbxPLC);
            this.pnlDevice.Controls.Add(this.groupBox2);
            this.pnlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDevice.Location = new System.Drawing.Point(0, 0);
            this.pnlDevice.Name = "pnlDevice";
            this.pnlDevice.Size = new System.Drawing.Size(801, 384);
            this.pnlDevice.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.cbxCameraType);
            this.groupBox9.Controls.Add(this.txtCamCount);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(5, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(254, 110);
            this.groupBox9.TabIndex = 38;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Camera Info";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 39;
            this.label7.Text = "Cam Count";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxCameraType
            // 
            this.cbxCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCameraType.FormattingEnabled = true;
            this.cbxCameraType.Location = new System.Drawing.Point(120, 62);
            this.cbxCameraType.Name = "cbxCameraType";
            this.cbxCameraType.Size = new System.Drawing.Size(124, 26);
            this.cbxCameraType.TabIndex = 38;
            this.cbxCameraType.SelectedIndexChanged += new System.EventHandler(this.PnlDevice_SelectedIndexChanged);
            // 
            // txtCamCount
            // 
            this.txtCamCount.Enabled = false;
            this.txtCamCount.Location = new System.Drawing.Point(119, 26);
            this.txtCamCount.Name = "txtCamCount";
            this.txtCamCount.Size = new System.Drawing.Size(124, 24);
            this.txtCamCount.TabIndex = 37;
            this.txtCamCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 23);
            this.label9.TabIndex = 37;
            this.label9.Text = "Type";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDioCardNo);
            this.groupBox3.Controls.Add(this.label49);
            this.groupBox3.Controls.Add(this.cbxDioBoardType);
            this.groupBox3.Controls.Add(this.label48);
            this.groupBox3.Controls.Add(this.label45);
            this.groupBox3.Controls.Add(this.txtStartGrabDelay);
            this.groupBox3.Controls.Add(this.label46);
            this.groupBox3.Controls.Add(this.label38);
            this.groupBox3.Controls.Add(this.txtEndGrabDelay);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cbxInspectionTriggerType);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(271, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 195);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Glass In/Out Trigger";
            // 
            // txtDioCardNo
            // 
            this.txtDioCardNo.Location = new System.Drawing.Point(141, 94);
            this.txtDioCardNo.Name = "txtDioCardNo";
            this.txtDioCardNo.Size = new System.Drawing.Size(71, 24);
            this.txtDioCardNo.TabIndex = 52;
            this.txtDioCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(7, 94);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(128, 23);
            this.label49.TabIndex = 51;
            this.label49.Text = "I/O Card No :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxDioBoardType
            // 
            this.cbxDioBoardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDioBoardType.FormattingEnabled = true;
            this.cbxDioBoardType.Location = new System.Drawing.Point(121, 62);
            this.cbxDioBoardType.Name = "cbxDioBoardType";
            this.cbxDioBoardType.Size = new System.Drawing.Size(124, 26);
            this.cbxDioBoardType.TabIndex = 50;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(6, 62);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(118, 23);
            this.label48.TabIndex = 49;
            this.label48.Text = "DIOBoard Type";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(216, 124);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(30, 23);
            this.label45.TabIndex = 48;
            this.label45.Text = "ms";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStartGrabDelay
            // 
            this.txtStartGrabDelay.Location = new System.Drawing.Point(141, 123);
            this.txtStartGrabDelay.Name = "txtStartGrabDelay";
            this.txtStartGrabDelay.Size = new System.Drawing.Size(71, 24);
            this.txtStartGrabDelay.TabIndex = 46;
            this.txtStartGrabDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(7, 124);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(128, 23);
            this.label46.TabIndex = 47;
            this.label46.Text = "Start Grab Delay :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(216, 154);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(30, 23);
            this.label38.TabIndex = 45;
            this.label38.Text = "ms";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEndGrabDelay
            // 
            this.txtEndGrabDelay.Location = new System.Drawing.Point(141, 153);
            this.txtEndGrabDelay.Name = "txtEndGrabDelay";
            this.txtEndGrabDelay.Size = new System.Drawing.Size(71, 24);
            this.txtEndGrabDelay.TabIndex = 39;
            this.txtEndGrabDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(7, 154);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(118, 23);
            this.label37.TabIndex = 44;
            this.label37.Text = "End Grab Delay :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 42;
            this.label10.Text = "Type";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxInspectionTriggerType
            // 
            this.cbxInspectionTriggerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInspectionTriggerType.FormattingEnabled = true;
            this.cbxInspectionTriggerType.Location = new System.Drawing.Point(121, 26);
            this.cbxInspectionTriggerType.Name = "cbxInspectionTriggerType";
            this.cbxInspectionTriggerType.Size = new System.Drawing.Size(124, 26);
            this.cbxInspectionTriggerType.TabIndex = 43;
            this.cbxInspectionTriggerType.SelectedIndexChanged += new System.EventHandler(this.PnlDevice_SelectedIndexChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.cbxLineRateType);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Controls.Add(this.txtConstantVel);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(536, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(254, 91);
            this.groupBox8.TabIndex = 37;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Line Rate";
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(186, 58);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(58, 23);
            this.label30.TabIndex = 37;
            this.label30.Text = "mm/sec";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(6, 22);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 23);
            this.label27.TabIndex = 26;
            this.label27.Text = "Type";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxLineRateType
            // 
            this.cbxLineRateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLineRateType.FormattingEnabled = true;
            this.cbxLineRateType.Location = new System.Drawing.Point(90, 25);
            this.cbxLineRateType.Name = "cbxLineRateType";
            this.cbxLineRateType.Size = new System.Drawing.Size(136, 26);
            this.cbxLineRateType.TabIndex = 27;
            this.cbxLineRateType.SelectedIndexChanged += new System.EventHandler(this.cbxLineRateType_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(6, 58);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 23);
            this.label28.TabIndex = 32;
            this.label28.Text = "Vel";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConstantVel
            // 
            this.txtConstantVel.Location = new System.Drawing.Point(90, 57);
            this.txtConstantVel.Name = "txtConstantVel";
            this.txtConstantVel.Size = new System.Drawing.Size(90, 24);
            this.txtConstantVel.TabIndex = 35;
            this.txtConstantVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxShading);
            this.groupBox1.Controls.Add(this.btnOpenCameraSettings);
            this.groupBox1.Controls.Add(this.ckbEnableShading);
            this.groupBox1.Controls.Add(this.btnCameraApply);
            this.groupBox1.Controls.Add(this.cbxCamNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nupdnExposure);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 259);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera";
            // 
            // cbxShading
            // 
            this.cbxShading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxShading.FormattingEnabled = true;
            this.cbxShading.Location = new System.Drawing.Point(143, 114);
            this.cbxShading.Name = "cbxShading";
            this.cbxShading.Size = new System.Drawing.Size(100, 26);
            this.cbxShading.TabIndex = 42;
            this.cbxShading.SelectedIndexChanged += new System.EventHandler(this.cbxShading_SelectedIndexChanged);
            // 
            // btnOpenCameraSettings
            // 
            this.btnOpenCameraSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenCameraSettings.Location = new System.Drawing.Point(7, 150);
            this.btnOpenCameraSettings.Name = "btnOpenCameraSettings";
            this.btnOpenCameraSettings.Size = new System.Drawing.Size(236, 34);
            this.btnOpenCameraSettings.TabIndex = 4;
            this.btnOpenCameraSettings.Text = "CameraSettings";
            this.btnOpenCameraSettings.UseVisualStyleBackColor = true;
            this.btnOpenCameraSettings.Click += new System.EventHandler(this.btnOpenCameraSettings_Click);
            // 
            // ckbEnableShading
            // 
            this.ckbEnableShading.AutoSize = true;
            this.ckbEnableShading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.ckbEnableShading.Location = new System.Drawing.Point(9, 118);
            this.ckbEnableShading.Name = "ckbEnableShading";
            this.ckbEnableShading.Size = new System.Drawing.Size(128, 19);
            this.ckbEnableShading.TabIndex = 41;
            this.ckbEnableShading.Text = "Shading Enable";
            this.ckbEnableShading.UseVisualStyleBackColor = true;
            this.ckbEnableShading.CheckedChanged += new System.EventHandler(this.ckbEnableShadingEnableShading_CheckedChanged);
            // 
            // btnCameraApply
            // 
            this.btnCameraApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCameraApply.Location = new System.Drawing.Point(187, 71);
            this.btnCameraApply.Name = "btnCameraApply";
            this.btnCameraApply.Size = new System.Drawing.Size(57, 34);
            this.btnCameraApply.TabIndex = 0;
            this.btnCameraApply.Text = "Apply";
            this.btnCameraApply.UseVisualStyleBackColor = true;
            this.btnCameraApply.Click += new System.EventHandler(this.btnCameraApply_Click);
            // 
            // cbxCamNo
            // 
            this.cbxCamNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCamNo.FormattingEnabled = true;
            this.cbxCamNo.Location = new System.Drawing.Point(107, 36);
            this.cbxCamNo.Name = "cbxCamNo";
            this.cbxCamNo.Size = new System.Drawing.Size(136, 26);
            this.cbxCamNo.TabIndex = 7;
            this.cbxCamNo.SelectedIndexChanged += new System.EventHandler(this.cbxCamNo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cam No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nupdnExposure
            // 
            this.nupdnExposure.BackColor = System.Drawing.Color.White;
            this.nupdnExposure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nupdnExposure.DecimalPlaces = 3;
            this.nupdnExposure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupdnExposure.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nupdnExposure.Location = new System.Drawing.Point(107, 79);
            this.nupdnExposure.Name = "nupdnExposure";
            this.nupdnExposure.Size = new System.Drawing.Size(71, 21);
            this.nupdnExposure.TabIndex = 4;
            this.nupdnExposure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupdnExposure.ValueChanged += new System.EventHandler(this.nupdnExposure_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Exposure";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxPLC
            // 
            this.gbxPLC.Controls.Add(this.btnOpenPLCAddressSetting);
            this.gbxPLC.Controls.Add(this.label2);
            this.gbxPLC.Controls.Add(this.cbxPLCType);
            this.gbxPLC.Controls.Add(this.label5);
            this.gbxPLC.Controls.Add(this.label6);
            this.gbxPLC.Controls.Add(this.txtPlcPortNumber);
            this.gbxPLC.Controls.Add(this.txtIPAddress);
            this.gbxPLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPLC.Location = new System.Drawing.Point(271, 6);
            this.gbxPLC.Name = "gbxPLC";
            this.gbxPLC.Size = new System.Drawing.Size(254, 174);
            this.gbxPLC.TabIndex = 1;
            this.gbxPLC.TabStop = false;
            this.gbxPLC.Text = "PLC";
            // 
            // btnOpenPLCAddressSetting
            // 
            this.btnOpenPLCAddressSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenPLCAddressSetting.Location = new System.Drawing.Point(9, 135);
            this.btnOpenPLCAddressSetting.Name = "btnOpenPLCAddressSetting";
            this.btnOpenPLCAddressSetting.Size = new System.Drawing.Size(236, 34);
            this.btnOpenPLCAddressSetting.TabIndex = 43;
            this.btnOpenPLCAddressSetting.Text = "PLC Address Setting";
            this.btnOpenPLCAddressSetting.UseVisualStyleBackColor = true;
            this.btnOpenPLCAddressSetting.Click += new System.EventHandler(this.btnOpenPLCAddressSetting_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxPLCType
            // 
            this.cbxPLCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPLCType.FormattingEnabled = true;
            this.cbxPLCType.Location = new System.Drawing.Point(109, 30);
            this.cbxPLCType.Name = "cbxPLCType";
            this.cbxPLCType.Size = new System.Drawing.Size(136, 26);
            this.cbxPLCType.TabIndex = 27;
            this.cbxPLCType.SelectedIndexChanged += new System.EventHandler(this.PnlDevice_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "IP Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 23);
            this.label6.TabIndex = 33;
            this.label6.Text = "Port Number";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPlcPortNumber
            // 
            this.txtPlcPortNumber.Location = new System.Drawing.Point(109, 102);
            this.txtPlcPortNumber.Name = "txtPlcPortNumber";
            this.txtPlcPortNumber.Size = new System.Drawing.Size(136, 24);
            this.txtPlcPortNumber.TabIndex = 36;
            this.txtPlcPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(109, 67);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(136, 24);
            this.txtIPAddress.TabIndex = 35;
            this.txtIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetLightValue);
            this.groupBox2.Controls.Add(this.txtLightValue);
            this.groupBox2.Controls.Add(this.cbxSerialLightType);
            this.groupBox2.Controls.Add(this.label47);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.cbxBaudRate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnLightOff);
            this.groupBox2.Controls.Add(this.btnLightOn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbxComPort);
            this.groupBox2.Controls.Add(this.cbxLightType);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(536, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 278);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Light";
            // 
            // btnSetLightValue
            // 
            this.btnSetLightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetLightValue.Location = new System.Drawing.Point(188, 175);
            this.btnSetLightValue.Name = "btnSetLightValue";
            this.btnSetLightValue.Size = new System.Drawing.Size(60, 24);
            this.btnSetLightValue.TabIndex = 51;
            this.btnSetLightValue.Text = "Set";
            this.btnSetLightValue.UseVisualStyleBackColor = true;
            this.btnSetLightValue.Click += new System.EventHandler(this.btnSetLightValue_Click);
            // 
            // txtLightValue
            // 
            this.txtLightValue.Location = new System.Drawing.Point(111, 175);
            this.txtLightValue.Name = "txtLightValue";
            this.txtLightValue.Size = new System.Drawing.Size(71, 24);
            this.txtLightValue.TabIndex = 49;
            this.txtLightValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxSerialLightType
            // 
            this.cbxSerialLightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSerialLightType.FormattingEnabled = true;
            this.cbxSerialLightType.Location = new System.Drawing.Point(109, 60);
            this.cbxSerialLightType.Name = "cbxSerialLightType";
            this.cbxSerialLightType.Size = new System.Drawing.Size(136, 26);
            this.cbxSerialLightType.TabIndex = 45;
            this.cbxSerialLightType.SelectedIndexChanged += new System.EventHandler(this.PnlDevice_SelectedIndexChanged);
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(8, 176);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(92, 23);
            this.label47.TabIndex = 50;
            this.label47.Text = "Light Value :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(3, 60);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 23);
            this.label36.TabIndex = 44;
            this.label36.Text = "Serial Type ";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.cbxBaudRate.Location = new System.Drawing.Point(111, 137);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(136, 26);
            this.cbxBaudRate.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 23);
            this.label11.TabIndex = 42;
            this.label11.Text = "BaudRate";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLightOff
            // 
            this.btnLightOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLightOff.Location = new System.Drawing.Point(130, 215);
            this.btnLightOff.Name = "btnLightOff";
            this.btnLightOff.Size = new System.Drawing.Size(118, 34);
            this.btnLightOff.TabIndex = 41;
            this.btnLightOff.Text = "Light Off";
            this.btnLightOff.UseVisualStyleBackColor = true;
            this.btnLightOff.Click += new System.EventHandler(this.btnLightOff_Click);
            // 
            // btnLightOn
            // 
            this.btnLightOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLightOn.Location = new System.Drawing.Point(6, 215);
            this.btnLightOn.Name = "btnLightOn";
            this.btnLightOn.Size = new System.Drawing.Size(118, 34);
            this.btnLightOn.TabIndex = 40;
            this.btnLightOn.Text = "Light On";
            this.btnLightOn.UseVisualStyleBackColor = true;
            this.btnLightOn.Click += new System.EventHandler(this.btnLightOn_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxComPort
            // 
            this.cbxComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxComPort.FormattingEnabled = true;
            this.cbxComPort.Location = new System.Drawing.Point(110, 99);
            this.cbxComPort.Name = "cbxComPort";
            this.cbxComPort.Size = new System.Drawing.Size(136, 26);
            this.cbxComPort.TabIndex = 39;
            // 
            // cbxLightType
            // 
            this.cbxLightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLightType.FormattingEnabled = true;
            this.cbxLightType.Location = new System.Drawing.Point(110, 26);
            this.cbxLightType.Name = "cbxLightType";
            this.cbxLightType.Size = new System.Drawing.Size(136, 26);
            this.cbxLightType.TabIndex = 29;
            this.cbxLightType.SelectedIndexChanged += new System.EventHandler(this.PnlDevice_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 38;
            this.label8.Text = "Com Port";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabInspection
            // 
            this.tabInspection.Controls.Add(this.pnlInspection);
            this.tabInspection.Location = new System.Drawing.Point(4, 24);
            this.tabInspection.Name = "tabInspection";
            this.tabInspection.Size = new System.Drawing.Size(801, 384);
            this.tabInspection.TabIndex = 1;
            this.tabInspection.Text = "Inspection";
            this.tabInspection.UseVisualStyleBackColor = true;
            // 
            // pnlInspection
            // 
            this.pnlInspection.Controls.Add(this.btnOpenViewer);
            this.pnlInspection.Controls.Add(this.groupBox11);
            this.pnlInspection.Controls.Add(this.groupBox10);
            this.pnlInspection.Controls.Add(this.groupBox4);
            this.pnlInspection.Controls.Add(this.groupBox5);
            this.pnlInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspection.Location = new System.Drawing.Point(0, 0);
            this.pnlInspection.Name = "pnlInspection";
            this.pnlInspection.Size = new System.Drawing.Size(801, 384);
            this.pnlInspection.TabIndex = 42;
            // 
            // btnOpenViewer
            // 
            this.btnOpenViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenViewer.Location = new System.Drawing.Point(241, 328);
            this.btnOpenViewer.Name = "btnOpenViewer";
            this.btnOpenViewer.Size = new System.Drawing.Size(555, 44);
            this.btnOpenViewer.TabIndex = 46;
            this.btnOpenViewer.Text = "Open Viewer";
            this.btnOpenViewer.UseVisualStyleBackColor = true;
            this.btnOpenViewer.Click += new System.EventHandler(this.btnOpenViewer_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ckbUseForkContour);
            this.groupBox11.Controls.Add(this.btnForkContourProperty);
            this.groupBox11.Controls.Add(this.ckbUseForkBroken);
            this.groupBox11.Controls.Add(this.btnForkDetect);
            this.groupBox11.Controls.Add(this.btnForkBrokenProperty);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(241, 114);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(555, 106);
            this.groupBox11.TabIndex = 47;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Fork Detect Algorithm";
            // 
            // ckbUseForkContour
            // 
            this.ckbUseForkContour.AutoSize = true;
            this.ckbUseForkContour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUseForkContour.Location = new System.Drawing.Point(283, 23);
            this.ckbUseForkContour.Name = "ckbUseForkContour";
            this.ckbUseForkContour.Size = new System.Drawing.Size(137, 19);
            this.ckbUseForkContour.TabIndex = 45;
            this.ckbUseForkContour.Text = "Use Fork Contour";
            this.ckbUseForkContour.UseVisualStyleBackColor = true;
            // 
            // btnForkContourProperty
            // 
            this.btnForkContourProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForkContourProperty.Location = new System.Drawing.Point(280, 48);
            this.btnForkContourProperty.Name = "btnForkContourProperty";
            this.btnForkContourProperty.Size = new System.Drawing.Size(131, 44);
            this.btnForkContourProperty.TabIndex = 44;
            this.btnForkContourProperty.Text = "Contour Property";
            this.btnForkContourProperty.UseVisualStyleBackColor = true;
            this.btnForkContourProperty.Click += new System.EventHandler(this.btnForkContourProperty_Click);
            // 
            // ckbUseForkBroken
            // 
            this.ckbUseForkBroken.AutoSize = true;
            this.ckbUseForkBroken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUseForkBroken.Location = new System.Drawing.Point(146, 23);
            this.ckbUseForkBroken.Name = "ckbUseForkBroken";
            this.ckbUseForkBroken.Size = new System.Drawing.Size(132, 19);
            this.ckbUseForkBroken.TabIndex = 42;
            this.ckbUseForkBroken.Text = "Use Fork Broken";
            this.ckbUseForkBroken.UseVisualStyleBackColor = true;
            // 
            // btnForkDetect
            // 
            this.btnForkDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForkDetect.Location = new System.Drawing.Point(6, 49);
            this.btnForkDetect.Name = "btnForkDetect";
            this.btnForkDetect.Size = new System.Drawing.Size(131, 44);
            this.btnForkDetect.TabIndex = 41;
            this.btnForkDetect.Text = "Fork Detect";
            this.btnForkDetect.UseVisualStyleBackColor = true;
            this.btnForkDetect.Click += new System.EventHandler(this.btnForkDetect_Click);
            // 
            // btnForkBrokenProperty
            // 
            this.btnForkBrokenProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForkBrokenProperty.Location = new System.Drawing.Point(143, 49);
            this.btnForkBrokenProperty.Name = "btnForkBrokenProperty";
            this.btnForkBrokenProperty.Size = new System.Drawing.Size(131, 44);
            this.btnForkBrokenProperty.TabIndex = 0;
            this.btnForkBrokenProperty.Text = "Broken Property";
            this.btnForkBrokenProperty.UseVisualStyleBackColor = true;
            this.btnForkBrokenProperty.Click += new System.EventHandler(this.btnForkBrokenProperty_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.label44);
            this.groupBox10.Controls.Add(this.txtRBCornerSize);
            this.groupBox10.Controls.Add(this.label41);
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Controls.Add(this.txtRTCornerSize);
            this.groupBox10.Controls.Add(this.label39);
            this.groupBox10.Controls.Add(this.label40);
            this.groupBox10.Controls.Add(this.txtLBCornerSize);
            this.groupBox10.Controls.Add(this.label33);
            this.groupBox10.Controls.Add(this.label32);
            this.groupBox10.Controls.Add(this.txtLTCornerSize);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox10.Location = new System.Drawing.Point(5, 144);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(230, 237);
            this.groupBox10.TabIndex = 42;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Corner Size";
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(6, 132);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(110, 23);
            this.label43.TabIndex = 89;
            this.label43.Text = "RB Corner Size";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(181, 131);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(39, 23);
            this.label44.TabIndex = 87;
            this.label44.Text = "pixel";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRBCornerSize
            // 
            this.txtRBCornerSize.Location = new System.Drawing.Point(122, 131);
            this.txtRBCornerSize.Name = "txtRBCornerSize";
            this.txtRBCornerSize.Size = new System.Drawing.Size(53, 24);
            this.txtRBCornerSize.TabIndex = 88;
            this.txtRBCornerSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(6, 101);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(110, 23);
            this.label41.TabIndex = 86;
            this.label41.Text = "RT Corner Size";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(181, 100);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(39, 23);
            this.label42.TabIndex = 84;
            this.label42.Text = "pixel";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRTCornerSize
            // 
            this.txtRTCornerSize.Location = new System.Drawing.Point(122, 100);
            this.txtRTCornerSize.Name = "txtRTCornerSize";
            this.txtRTCornerSize.Size = new System.Drawing.Size(53, 24);
            this.txtRTCornerSize.TabIndex = 85;
            this.txtRTCornerSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(6, 66);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(110, 23);
            this.label39.TabIndex = 83;
            this.label39.Text = "LB Corner Size";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(181, 65);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(39, 23);
            this.label40.TabIndex = 81;
            this.label40.Text = "pixel";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLBCornerSize
            // 
            this.txtLBCornerSize.Location = new System.Drawing.Point(122, 65);
            this.txtLBCornerSize.Name = "txtLBCornerSize";
            this.txtLBCornerSize.Size = new System.Drawing.Size(53, 24);
            this.txtLBCornerSize.TabIndex = 82;
            this.txtLBCornerSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(6, 34);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(110, 23);
            this.label33.TabIndex = 80;
            this.label33.Text = "LT Corner Size";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(181, 33);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(39, 23);
            this.label32.TabIndex = 78;
            this.label32.Text = "pixel";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLTCornerSize
            // 
            this.txtLTCornerSize.Location = new System.Drawing.Point(122, 33);
            this.txtLTCornerSize.Name = "txtLTCornerSize";
            this.txtLTCornerSize.Size = new System.Drawing.Size(53, 24);
            this.txtLTCornerSize.TabIndex = 79;
            this.txtLTCornerSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckbUseAI);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.btnAIProperty);
            this.groupBox4.Controls.Add(this.cbxAiType);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(5, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 135);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AI";
            // 
            // ckbUseAI
            // 
            this.ckbUseAI.AutoSize = true;
            this.ckbUseAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUseAI.Location = new System.Drawing.Point(9, 24);
            this.ckbUseAI.Name = "ckbUseAI";
            this.ckbUseAI.Size = new System.Drawing.Size(106, 19);
            this.ckbUseAI.TabIndex = 40;
            this.ckbUseAI.Text = "Use AI.Mech";
            this.ckbUseAI.UseVisualStyleBackColor = true;
            this.ckbUseAI.CheckedChanged += new System.EventHandler(this.pnlInspection_Changed);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 23);
            this.label12.TabIndex = 39;
            this.label12.Text = "Type";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAIProperty
            // 
            this.btnAIProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAIProperty.Location = new System.Drawing.Point(13, 81);
            this.btnAIProperty.Name = "btnAIProperty";
            this.btnAIProperty.Size = new System.Drawing.Size(207, 44);
            this.btnAIProperty.TabIndex = 0;
            this.btnAIProperty.Text = "AI Property";
            this.btnAIProperty.UseVisualStyleBackColor = true;
            this.btnAIProperty.Click += new System.EventHandler(this.btnAIProperty_Click);
            // 
            // cbxAiType
            // 
            this.cbxAiType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAiType.FormattingEnabled = true;
            this.cbxAiType.Location = new System.Drawing.Point(121, 49);
            this.cbxAiType.Name = "cbxAiType";
            this.cbxAiType.Size = new System.Drawing.Size(99, 26);
            this.cbxAiType.TabIndex = 38;
            this.cbxAiType.SelectedIndexChanged += new System.EventHandler(this.PnlInspection_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ckbUseEdgeContour);
            this.groupBox5.Controls.Add(this.btnEdgeContourProperty);
            this.groupBox5.Controls.Add(this.ckbUseEdgeBroken);
            this.groupBox5.Controls.Add(this.btnEdgeDetect);
            this.groupBox5.Controls.Add(this.btnEdgeBrokenProperty);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(241, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(555, 105);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Algorithm";
            // 
            // ckbUseEdgeContour
            // 
            this.ckbUseEdgeContour.AutoSize = true;
            this.ckbUseEdgeContour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUseEdgeContour.Location = new System.Drawing.Point(283, 24);
            this.ckbUseEdgeContour.Name = "ckbUseEdgeContour";
            this.ckbUseEdgeContour.Size = new System.Drawing.Size(142, 19);
            this.ckbUseEdgeContour.TabIndex = 45;
            this.ckbUseEdgeContour.Text = "Use Edge Contour";
            this.ckbUseEdgeContour.UseVisualStyleBackColor = true;
            // 
            // btnEdgeContourProperty
            // 
            this.btnEdgeContourProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdgeContourProperty.Location = new System.Drawing.Point(280, 49);
            this.btnEdgeContourProperty.Name = "btnEdgeContourProperty";
            this.btnEdgeContourProperty.Size = new System.Drawing.Size(131, 44);
            this.btnEdgeContourProperty.TabIndex = 44;
            this.btnEdgeContourProperty.Text = "Contour Property";
            this.btnEdgeContourProperty.UseVisualStyleBackColor = true;
            this.btnEdgeContourProperty.Click += new System.EventHandler(this.btnEdgeContourProperty_Click);
            // 
            // ckbUseEdgeBroken
            // 
            this.ckbUseEdgeBroken.AutoSize = true;
            this.ckbUseEdgeBroken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUseEdgeBroken.Location = new System.Drawing.Point(146, 24);
            this.ckbUseEdgeBroken.Name = "ckbUseEdgeBroken";
            this.ckbUseEdgeBroken.Size = new System.Drawing.Size(137, 19);
            this.ckbUseEdgeBroken.TabIndex = 42;
            this.ckbUseEdgeBroken.Text = "Use Edge Broken";
            this.ckbUseEdgeBroken.UseVisualStyleBackColor = true;
            // 
            // btnEdgeDetect
            // 
            this.btnEdgeDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdgeDetect.Location = new System.Drawing.Point(6, 49);
            this.btnEdgeDetect.Name = "btnEdgeDetect";
            this.btnEdgeDetect.Size = new System.Drawing.Size(131, 44);
            this.btnEdgeDetect.TabIndex = 41;
            this.btnEdgeDetect.Text = "Edge Detect";
            this.btnEdgeDetect.UseVisualStyleBackColor = true;
            this.btnEdgeDetect.Click += new System.EventHandler(this.btnEdgeDetect_Click);
            // 
            // btnEdgeBrokenProperty
            // 
            this.btnEdgeBrokenProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdgeBrokenProperty.Location = new System.Drawing.Point(143, 49);
            this.btnEdgeBrokenProperty.Name = "btnEdgeBrokenProperty";
            this.btnEdgeBrokenProperty.Size = new System.Drawing.Size(131, 44);
            this.btnEdgeBrokenProperty.TabIndex = 0;
            this.btnEdgeBrokenProperty.Text = "Broken Property";
            this.btnEdgeBrokenProperty.UseVisualStyleBackColor = true;
            this.btnEdgeBrokenProperty.Click += new System.EventHandler(this.btnEdgeBrokenProperty_Click);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.groupBox7);
            this.tabInfo.Controls.Add(this.groupBox6);
            this.tabInfo.Location = new System.Drawing.Point(4, 24);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Size = new System.Drawing.Size(801, 384);
            this.tabInfo.TabIndex = 2;
            this.tabInfo.Text = "Info";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtImageFolderPath);
            this.groupBox7.Controls.Add(this.cbxSaveMergeImageType);
            this.groupBox7.Controls.Add(this.label50);
            this.groupBox7.Controls.Add(this.txtImageSavePeriod);
            this.groupBox7.Controls.Add(this.label51);
            this.groupBox7.Controls.Add(this.ckbDrawCorner);
            this.groupBox7.Controls.Add(this.ckbGlassInOut);
            this.groupBox7.Controls.Add(this.cbxHardDisk2);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.cbxHardDisk1);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.ckbUsePLCTime);
            this.groupBox7.Controls.Add(this.cbxSaveAICropImageType);
            this.groupBox7.Controls.Add(this.ckbSaveMergeImage);
            this.groupBox7.Controls.Add(this.cbxSaveSubImageType);
            this.groupBox7.Controls.Add(this.btnDBFolderPath);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.ckbUseGrabEdgeDetect);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.txtLogSavePeriod);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.ckbUseByPass);
            this.groupBox7.Controls.Add(this.ckbUseTestMode);
            this.groupBox7.Controls.Add(this.ckbSaveCropImage);
            this.groupBox7.Controls.Add(this.ckbSaveSubImage);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(265, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(531, 376);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Options";
            // 
            // cbxSaveMergeImageType
            // 
            this.cbxSaveMergeImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSaveMergeImageType.FormattingEnabled = true;
            this.cbxSaveMergeImageType.Location = new System.Drawing.Point(154, 110);
            this.cbxSaveMergeImageType.Name = "cbxSaveMergeImageType";
            this.cbxSaveMergeImageType.Size = new System.Drawing.Size(73, 26);
            this.cbxSaveMergeImageType.TabIndex = 67;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(216, 256);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(49, 23);
            this.label50.TabIndex = 66;
            this.label50.Text = "days";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImageSavePeriod
            // 
            this.txtImageSavePeriod.Location = new System.Drawing.Point(154, 255);
            this.txtImageSavePeriod.Name = "txtImageSavePeriod";
            this.txtImageSavePeriod.Size = new System.Drawing.Size(56, 24);
            this.txtImageSavePeriod.TabIndex = 64;
            this.txtImageSavePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(6, 255);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(142, 23);
            this.label51.TabIndex = 65;
            this.label51.Text = "Image Save Period";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbDrawCorner
            // 
            this.ckbDrawCorner.AutoSize = true;
            this.ckbDrawCorner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbDrawCorner.Location = new System.Drawing.Point(255, 27);
            this.ckbDrawCorner.Name = "ckbDrawCorner";
            this.ckbDrawCorner.Size = new System.Drawing.Size(106, 19);
            this.ckbDrawCorner.TabIndex = 63;
            this.ckbDrawCorner.Text = "Draw Corner";
            this.ckbDrawCorner.UseVisualStyleBackColor = true;
            // 
            // ckbGlassInOut
            // 
            this.ckbGlassInOut.AutoSize = true;
            this.ckbGlassInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbGlassInOut.Location = new System.Drawing.Point(255, 79);
            this.ckbGlassInOut.Name = "ckbGlassInOut";
            this.ckbGlassInOut.Size = new System.Drawing.Size(104, 19);
            this.ckbGlassInOut.TabIndex = 62;
            this.ckbGlassInOut.Text = "Glass In/Out";
            this.ckbGlassInOut.UseVisualStyleBackColor = true;
            this.ckbGlassInOut.CheckedChanged += new System.EventHandler(this.cbxGlassInOut_CheckedChanged);
            // 
            // cbxHardDisk2
            // 
            this.cbxHardDisk2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHardDisk2.FormattingEnabled = true;
            this.cbxHardDisk2.Location = new System.Drawing.Point(255, 187);
            this.cbxHardDisk2.Name = "cbxHardDisk2";
            this.cbxHardDisk2.Size = new System.Drawing.Size(73, 26);
            this.cbxHardDisk2.TabIndex = 61;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(170, 188);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(79, 23);
            this.label26.TabIndex = 60;
            this.label26.Text = "HardDisk2";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxHardDisk1
            // 
            this.cbxHardDisk1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHardDisk1.FormattingEnabled = true;
            this.cbxHardDisk1.Location = new System.Drawing.Point(91, 187);
            this.cbxHardDisk1.Name = "cbxHardDisk1";
            this.cbxHardDisk1.Size = new System.Drawing.Size(73, 26);
            this.cbxHardDisk1.TabIndex = 59;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(6, 188);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 23);
            this.label25.TabIndex = 58;
            this.label25.Text = "HardDisk1";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbUsePLCTime
            // 
            this.ckbUsePLCTime.AutoSize = true;
            this.ckbUsePLCTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUsePLCTime.Location = new System.Drawing.Point(6, 139);
            this.ckbUsePLCTime.Name = "ckbUsePLCTime";
            this.ckbUsePLCTime.Size = new System.Drawing.Size(117, 19);
            this.ckbUsePLCTime.TabIndex = 57;
            this.ckbUsePLCTime.Text = "Use PLC Time";
            this.ckbUsePLCTime.UseVisualStyleBackColor = true;
            // 
            // cbxSaveAICropImageType
            // 
            this.cbxSaveAICropImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSaveAICropImageType.FormattingEnabled = true;
            this.cbxSaveAICropImageType.Location = new System.Drawing.Point(154, 79);
            this.cbxSaveAICropImageType.Name = "cbxSaveAICropImageType";
            this.cbxSaveAICropImageType.Size = new System.Drawing.Size(73, 26);
            this.cbxSaveAICropImageType.TabIndex = 56;
            // 
            // ckbSaveMergeImage
            // 
            this.ckbSaveMergeImage.AutoSize = true;
            this.ckbSaveMergeImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSaveMergeImage.Location = new System.Drawing.Point(6, 110);
            this.ckbSaveMergeImage.Name = "ckbSaveMergeImage";
            this.ckbSaveMergeImage.Size = new System.Drawing.Size(146, 19);
            this.ckbSaveMergeImage.TabIndex = 55;
            this.ckbSaveMergeImage.Text = "Save Merge Image";
            this.ckbSaveMergeImage.UseVisualStyleBackColor = true;
            // 
            // cbxSaveSubImageType
            // 
            this.cbxSaveSubImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSaveSubImageType.FormattingEnabled = true;
            this.cbxSaveSubImageType.Location = new System.Drawing.Point(154, 48);
            this.cbxSaveSubImageType.Name = "cbxSaveSubImageType";
            this.cbxSaveSubImageType.Size = new System.Drawing.Size(73, 26);
            this.cbxSaveSubImageType.TabIndex = 54;
            // 
            // btnDBFolderPath
            // 
            this.btnDBFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBFolderPath.Location = new System.Drawing.Point(450, 286);
            this.btnDBFolderPath.Name = "btnDBFolderPath";
            this.btnDBFolderPath.Size = new System.Drawing.Size(29, 24);
            this.btnDBFolderPath.TabIndex = 53;
            this.btnDBFolderPath.Text = "...";
            this.btnDBFolderPath.UseVisualStyleBackColor = true;
            this.btnDBFolderPath.Click += new System.EventHandler(this.btnDBFolderPath_Click);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(6, 287);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(142, 23);
            this.label23.TabIndex = 51;
            this.label23.Text = "Image Folder Path";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbUseGrabEdgeDetect
            // 
            this.ckbUseGrabEdgeDetect.AutoSize = true;
            this.ckbUseGrabEdgeDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUseGrabEdgeDetect.Location = new System.Drawing.Point(6, 28);
            this.ckbUseGrabEdgeDetect.Name = "ckbUseGrabEdgeDetect";
            this.ckbUseGrabEdgeDetect.Size = new System.Drawing.Size(168, 19);
            this.ckbUseGrabEdgeDetect.TabIndex = 50;
            this.ckbUseGrabEdgeDetect.Text = "Use Grab Edge Detect";
            this.ckbUseGrabEdgeDetect.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(186, 223);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 23);
            this.label22.TabIndex = 49;
            this.label22.Text = "days";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLogSavePeriod
            // 
            this.txtLogSavePeriod.Location = new System.Drawing.Point(124, 222);
            this.txtLogSavePeriod.Name = "txtLogSavePeriod";
            this.txtLogSavePeriod.Size = new System.Drawing.Size(56, 24);
            this.txtLogSavePeriod.TabIndex = 48;
            this.txtLogSavePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLogSavePeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 223);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 23);
            this.label21.TabIndex = 48;
            this.label21.Text = "Log Save Period";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbUseByPass
            // 
            this.ckbUseByPass.AutoSize = true;
            this.ckbUseByPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUseByPass.Location = new System.Drawing.Point(6, 165);
            this.ckbUseByPass.Name = "ckbUseByPass";
            this.ckbUseByPass.Size = new System.Drawing.Size(101, 19);
            this.ckbUseByPass.TabIndex = 43;
            this.ckbUseByPass.Text = "Use ByPass";
            this.ckbUseByPass.UseVisualStyleBackColor = true;
            // 
            // ckbUseTestMode
            // 
            this.ckbUseTestMode.AutoSize = true;
            this.ckbUseTestMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUseTestMode.Location = new System.Drawing.Point(255, 54);
            this.ckbUseTestMode.Name = "ckbUseTestMode";
            this.ckbUseTestMode.Size = new System.Drawing.Size(122, 19);
            this.ckbUseTestMode.TabIndex = 42;
            this.ckbUseTestMode.Text = "Use Test Mode";
            this.ckbUseTestMode.UseVisualStyleBackColor = true;
            // 
            // ckbSaveCropImage
            // 
            this.ckbSaveCropImage.AutoSize = true;
            this.ckbSaveCropImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSaveCropImage.Location = new System.Drawing.Point(6, 80);
            this.ckbSaveCropImage.Name = "ckbSaveCropImage";
            this.ckbSaveCropImage.Size = new System.Drawing.Size(131, 19);
            this.ckbSaveCropImage.TabIndex = 41;
            this.ckbSaveCropImage.Text = "Save CropImage";
            this.ckbSaveCropImage.UseVisualStyleBackColor = true;
            // 
            // ckbSaveSubImage
            // 
            this.ckbSaveSubImage.AutoSize = true;
            this.ckbSaveSubImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSaveSubImage.Location = new System.Drawing.Point(6, 54);
            this.ckbSaveSubImage.Name = "ckbSaveSubImage";
            this.ckbSaveSubImage.Size = new System.Drawing.Size(126, 19);
            this.ckbSaveSubImage.TabIndex = 40;
            this.ckbSaveSubImage.Text = "Save SubImage";
            this.ckbSaveSubImage.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ckbTwoEdge);
            this.groupBox6.Controls.Add(this.label53);
            this.groupBox6.Controls.Add(this.txtCameraInterval);
            this.groupBox6.Controls.Add(this.label52);
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Controls.Add(this.txtThumbnailRatio);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.cbxOriginDirection);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.txtFov);
            this.groupBox6.Controls.Add(this.txtGlassHeight);
            this.groupBox6.Controls.Add(this.txtGlassWidth);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(5, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(254, 376);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "System";
            // 
            // ckbTwoEdge
            // 
            this.ckbTwoEdge.AutoSize = true;
            this.ckbTwoEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTwoEdge.Location = new System.Drawing.Point(10, 198);
            this.ckbTwoEdge.Name = "ckbTwoEdge";
            this.ckbTwoEdge.Size = new System.Drawing.Size(89, 19);
            this.ckbTwoEdge.TabIndex = 67;
            this.ckbTwoEdge.Text = "Two Edge";
            this.ckbTwoEdge.UseVisualStyleBackColor = true;
            this.ckbTwoEdge.CheckedChanged += new System.EventHandler(this.ckbTwoEdge_CheckedChanged);
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(205, 221);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(41, 23);
            this.label53.TabIndex = 71;
            this.label53.Text = "mm";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCameraInterval
            // 
            this.txtCameraInterval.Enabled = false;
            this.txtCameraInterval.Location = new System.Drawing.Point(118, 220);
            this.txtCameraInterval.Name = "txtCameraInterval";
            this.txtCameraInterval.Size = new System.Drawing.Size(84, 24);
            this.txtCameraInterval.TabIndex = 70;
            this.txtCameraInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(7, 220);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(112, 23);
            this.label52.TabIndex = 69;
            this.label52.Text = "Camera Interval";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(197, 125);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(49, 23);
            this.label35.TabIndex = 67;
            this.label35.Text = "Ratio";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtThumbnailRatio
            // 
            this.txtThumbnailRatio.Location = new System.Drawing.Point(109, 124);
            this.txtThumbnailRatio.Name = "txtThumbnailRatio";
            this.txtThumbnailRatio.Size = new System.Drawing.Size(84, 24);
            this.txtThumbnailRatio.TabIndex = 68;
            this.txtThumbnailRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtThumbnailRatio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(6, 125);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(95, 23);
            this.label34.TabIndex = 66;
            this.label34.Text = "Thumbnail";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxOriginDirection
            // 
            this.cbxOriginDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOriginDirection.FormattingEnabled = true;
            this.cbxOriginDirection.Location = new System.Drawing.Point(118, 159);
            this.cbxOriginDirection.Name = "cbxOriginDirection";
            this.cbxOriginDirection.Size = new System.Drawing.Size(128, 26);
            this.cbxOriginDirection.TabIndex = 55;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(199, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 23);
            this.label18.TabIndex = 44;
            this.label18.Text = "mm";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(199, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 23);
            this.label17.TabIndex = 43;
            this.label17.Text = "mm";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(199, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 23);
            this.label16.TabIndex = 42;
            this.label16.Text = "mm";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(5, 159);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 23);
            this.label24.TabIndex = 49;
            this.label24.Text = "Origin Direction";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFov
            // 
            this.txtFov.Location = new System.Drawing.Point(109, 91);
            this.txtFov.Name = "txtFov";
            this.txtFov.Size = new System.Drawing.Size(84, 24);
            this.txtFov.TabIndex = 41;
            this.txtFov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGlassHeight
            // 
            this.txtGlassHeight.Location = new System.Drawing.Point(109, 57);
            this.txtGlassHeight.Name = "txtGlassHeight";
            this.txtGlassHeight.Size = new System.Drawing.Size(84, 24);
            this.txtGlassHeight.TabIndex = 40;
            this.txtGlassHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGlassWidth
            // 
            this.txtGlassWidth.Location = new System.Drawing.Point(109, 23);
            this.txtGlassWidth.Name = "txtGlassWidth";
            this.txtGlassWidth.Size = new System.Drawing.Size(84, 24);
            this.txtGlassWidth.TabIndex = 37;
            this.txtGlassWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 23);
            this.label13.TabIndex = 39;
            this.label13.Text = "Glass Width";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 23);
            this.label14.TabIndex = 37;
            this.label14.Text = "Glass Height";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 23);
            this.label15.TabIndex = 6;
            this.label15.Text = "FOV";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 421);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(809, 44);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(662, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 38);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtImageFolderPath
            // 
            this.txtImageFolderPath.Location = new System.Drawing.Point(154, 287);
            this.txtImageFolderPath.Name = "txtImageFolderPath";
            this.txtImageFolderPath.Size = new System.Drawing.Size(290, 24);
            this.txtImageFolderPath.TabIndex = 68;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 468);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSettings_FormClosed);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDevice.ResumeLayout(false);
            this.pnlDevice.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnExposure)).EndInit();
            this.gbxPLC.ResumeLayout(false);
            this.gbxPLC.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabInspection.ResumeLayout(false);
            this.pnlInspection.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabInfo.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDevice;
        private System.Windows.Forms.Panel pnlDevice;
        private System.Windows.Forms.ComboBox cbxComPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxLightType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxPLCType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLightOff;
        private System.Windows.Forms.Button btnLightOn;
        private System.Windows.Forms.GroupBox gbxPLC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCameraApply;
        private System.Windows.Forms.ComboBox cbxCamNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupdnExposure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxCameraType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxInspectionTriggerType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPlcPortNumber;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCamCount;
        private System.Windows.Forms.TabPage tabInspection;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAIProperty;
        private System.Windows.Forms.ComboBox cbxAiType;
        private System.Windows.Forms.CheckBox ckbUseAI;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFov;
        private System.Windows.Forms.TextBox txtGlassHeight;
        private System.Windows.Forms.TextBox txtGlassWidth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox ckbSaveSubImage;
        private System.Windows.Forms.CheckBox ckbSaveCropImage;
        private System.Windows.Forms.CheckBox ckbUseTestMode;
        private System.Windows.Forms.CheckBox ckbUseByPass;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtLogSavePeriod;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel pnlInspection;
        private System.Windows.Forms.Button btnEdgeDetect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox ckbUseEdgeBroken;
        private System.Windows.Forms.Button btnEdgeBrokenProperty;
        private System.Windows.Forms.CheckBox ckbUseGrabEdgeDetect;
        private System.Windows.Forms.Button btnDBFolderPath;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbxSaveAICropImageType;
        private System.Windows.Forms.CheckBox ckbSaveMergeImage;
        private System.Windows.Forms.ComboBox cbxSaveSubImageType;
        private System.Windows.Forms.CheckBox ckbUsePLCTime;
        private System.Windows.Forms.ComboBox cbxOriginDirection;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbxHardDisk2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cbxHardDisk1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox ckbGlassInOut;
        private System.Windows.Forms.Button btnOpenCameraSettings;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cbxLineRateType;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtConstantVel;
        private System.Windows.Forms.CheckBox ckbEnableShading;
        private System.Windows.Forms.ComboBox cbxShading;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox ckbUseEdgeContour;
        private System.Windows.Forms.Button btnEdgeContourProperty;
        private System.Windows.Forms.CheckBox ckbDrawCorner;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtThumbnailRatio;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtRBCornerSize;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtRTCornerSize;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtLBCornerSize;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtLTCornerSize;
        private System.Windows.Forms.ComboBox cbxSerialLightType;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtEndGrabDelay;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtStartGrabDelay;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtLightValue;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button btnSetLightValue;
        private System.Windows.Forms.Button btnOpenPLCAddressSetting;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.ComboBox cbxDioBoardType;
        private System.Windows.Forms.TextBox txtDioCardNo;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtImageSavePeriod;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox txtCameraInterval;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.CheckBox ckbTwoEdge;
        private System.Windows.Forms.Button btnOpenViewer;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.CheckBox ckbUseForkContour;
        private System.Windows.Forms.Button btnForkContourProperty;
        private System.Windows.Forms.CheckBox ckbUseForkBroken;
        private System.Windows.Forms.Button btnForkDetect;
        private System.Windows.Forms.Button btnForkBrokenProperty;
        private System.Windows.Forms.ComboBox cbxSaveMergeImageType;
        private System.Windows.Forms.TextBox txtImageFolderPath;
    }
}