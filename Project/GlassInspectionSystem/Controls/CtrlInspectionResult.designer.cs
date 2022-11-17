namespace GlassInspectionSystem.Controls
{
    partial class CtrlInspectionResult
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
            this.lblInspectionResultText = new System.Windows.Forms.Label();
            this.lblInspectionResult = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTactTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGlassID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInspectionResultText
            // 
            this.lblInspectionResultText.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblInspectionResultText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInspectionResultText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspectionResultText.Location = new System.Drawing.Point(3, 3);
            this.lblInspectionResultText.Margin = new System.Windows.Forms.Padding(3);
            this.lblInspectionResultText.Name = "lblInspectionResultText";
            this.lblInspectionResultText.Size = new System.Drawing.Size(505, 34);
            this.lblInspectionResultText.TabIndex = 0;
            this.lblInspectionResultText.Text = "Inspection Result";
            this.lblInspectionResultText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInspectionResultText.Paint += new System.Windows.Forms.PaintEventHandler(this.lblInspectionResultText_Paint);
            // 
            // lblInspectionResult
            // 
            this.lblInspectionResult.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lblInspectionResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInspectionResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspectionResult.Location = new System.Drawing.Point(3, 120);
            this.lblInspectionResult.Name = "lblInspectionResult";
            this.lblInspectionResult.Size = new System.Drawing.Size(505, 110);
            this.lblInspectionResult.TabIndex = 0;
            this.lblInspectionResult.Text = "OK";
            this.lblInspectionResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInspectionResult.Paint += new System.Windows.Forms.PaintEventHandler(this.lblInspectionResult_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblInspectionResultText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInspectionResult, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(511, 230);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTactTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblGlassID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 74);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(444, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "ms";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTactTime
            // 
            this.lblTactTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTactTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTactTime.Location = new System.Drawing.Point(117, 43);
            this.lblTactTime.Name = "lblTactTime";
            this.lblTactTime.Size = new System.Drawing.Size(321, 23);
            this.lblTactTime.TabIndex = 9;
            this.lblTactTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Insp Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGlassID
            // 
            this.lblGlassID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGlassID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlassID.Location = new System.Drawing.Point(117, 10);
            this.lblGlassID.Name = "lblGlassID";
            this.lblGlassID.Size = new System.Drawing.Size(363, 23);
            this.lblGlassID.TabIndex = 7;
            this.lblGlassID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Glass ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlInspectionResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtrlInspectionResult";
            this.Size = new System.Drawing.Size(511, 230);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblInspectionResultText;
        private System.Windows.Forms.Label lblInspectionResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTactTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGlassID;
        private System.Windows.Forms.Label label3;
    }
}
