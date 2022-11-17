namespace GlassInspectionSystem.Controls
{
    partial class CtrlRuleImageDisplay
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
            this.lblGrayLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pbxDisplayImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplayImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlDisplay, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(852, 457);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblGrayLevel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblY);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblX);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 24);
            this.panel1.TabIndex = 1;
            // 
            // lblGrayLevel
            // 
            this.lblGrayLevel.AutoSize = true;
            this.lblGrayLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGrayLevel.Location = new System.Drawing.Point(254, 5);
            this.lblGrayLevel.Name = "lblGrayLevel";
            this.lblGrayLevel.Size = new System.Drawing.Size(16, 16);
            this.lblGrayLevel.TabIndex = 7;
            this.lblGrayLevel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(159, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Gray Level : ";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblY.Location = new System.Drawing.Point(113, 5);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(16, 16);
            this.lblY.TabIndex = 5;
            this.lblY.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(83, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Y : ";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblX.Location = new System.Drawing.Point(38, 5);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(16, 16);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(9, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "X : ";
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.pbxDisplayImage);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(3, 3);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(846, 421);
            this.pnlDisplay.TabIndex = 2;
            // 
            // pbxDisplayImage
            // 
            this.pbxDisplayImage.Location = new System.Drawing.Point(0, 0);
            this.pbxDisplayImage.Name = "pbxDisplayImage";
            this.pbxDisplayImage.Size = new System.Drawing.Size(100, 69);
            this.pbxDisplayImage.TabIndex = 0;
            this.pbxDisplayImage.TabStop = false;
            // 
            // CtrlRuleImageDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtrlRuleImageDisplay";
            this.Size = new System.Drawing.Size(852, 457);
            this.Load += new System.EventHandler(this.CtrlRuleImageDisplay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplayImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGrayLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.PictureBox pbxDisplayImage;
    }
}
