namespace GlassViewer.Controls
{
    partial class CtrlThumbnailBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewLineChart = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.pnlThumbnail = new System.Windows.Forms.Panel();
            this.pbxThumbnailImage = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGrayLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFitSize = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlThumbnail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxThumbnailImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlThumbnail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 522);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFitSize);
            this.panel1.Controls.Add(this.btnViewLineChart);
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnViewLineChart
            // 
            this.btnViewLineChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewLineChart.Location = new System.Drawing.Point(90, 3);
            this.btnViewLineChart.Name = "btnViewLineChart";
            this.btnViewLineChart.Size = new System.Drawing.Size(75, 38);
            this.btnViewLineChart.TabIndex = 1;
            this.btnViewLineChart.Text = "Chart";
            this.btnViewLineChart.UseVisualStyleBackColor = true;
            this.btnViewLineChart.Click += new System.EventHandler(this.btnViewLineChart_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfig.Location = new System.Drawing.Point(9, 3);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 38);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "Configs";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // pnlThumbnail
            // 
            this.pnlThumbnail.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlThumbnail.Controls.Add(this.pbxThumbnailImage);
            this.pnlThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThumbnail.Location = new System.Drawing.Point(3, 53);
            this.pnlThumbnail.Name = "pnlThumbnail";
            this.pnlThumbnail.Size = new System.Drawing.Size(638, 426);
            this.pnlThumbnail.TabIndex = 1;
            // 
            // pbxThumbnailImage
            // 
            this.pbxThumbnailImage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxThumbnailImage.Location = new System.Drawing.Point(0, 0);
            this.pbxThumbnailImage.Name = "pbxThumbnailImage";
            this.pbxThumbnailImage.Size = new System.Drawing.Size(165, 162);
            this.pbxThumbnailImage.TabIndex = 1;
            this.pbxThumbnailImage.TabStop = false;
            this.pbxThumbnailImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbxThumbnailImage_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblGrayLevel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblY);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblX);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 485);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 34);
            this.panel2.TabIndex = 2;
            // 
            // lblGrayLevel
            // 
            this.lblGrayLevel.AutoSize = true;
            this.lblGrayLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGrayLevel.Location = new System.Drawing.Point(254, 10);
            this.lblGrayLevel.Name = "lblGrayLevel";
            this.lblGrayLevel.Size = new System.Drawing.Size(16, 16);
            this.lblGrayLevel.TabIndex = 13;
            this.lblGrayLevel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(159, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Gray Level : ";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblY.Location = new System.Drawing.Point(113, 10);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(16, 16);
            this.lblY.TabIndex = 11;
            this.lblY.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(83, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y : ";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblX.Location = new System.Drawing.Point(38, 10);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(16, 16);
            this.lblX.TabIndex = 9;
            this.lblX.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "X : ";
            // 
            // btnFitSize
            // 
            this.btnFitSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnFitSize.Location = new System.Drawing.Point(171, 3);
            this.btnFitSize.Name = "btnFitSize";
            this.btnFitSize.Size = new System.Drawing.Size(75, 38);
            this.btnFitSize.TabIndex = 2;
            this.btnFitSize.Text = "Fit Size";
            this.btnFitSize.UseVisualStyleBackColor = true;
            this.btnFitSize.Click += new System.EventHandler(this.btnFitSize_Click);
            // 
            // CtrlThumbnailBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtrlThumbnailBox";
            this.Size = new System.Drawing.Size(644, 522);
            this.Load += new System.EventHandler(this.CtrlThumbnailBox_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlThumbnail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxThumbnailImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfig;
        public System.Windows.Forms.PictureBox pbxThumbnailImage;
        private System.Windows.Forms.Button btnViewLineChart;
        private System.Windows.Forms.Panel pnlThumbnail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGrayLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFitSize;
    }
}
