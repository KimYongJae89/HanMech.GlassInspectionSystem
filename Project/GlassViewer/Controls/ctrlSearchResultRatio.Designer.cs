namespace GlassViewer.Controls
{
    partial class CtrlSearchResultRatio
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWARNINGCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblNGCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOKCount = new System.Windows.Forms.Label();
            this.lblNGPercent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.76068F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.23932F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlChart, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(579, 220);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblWARNINGCount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTotalCount);
            this.panel1.Controls.Add(this.lblNGCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblOKCount);
            this.panel1.Controls.Add(this.lblNGPercent);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(343, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 214);
            this.panel1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "WARNING Count";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWARNINGCount
            // 
            this.lblWARNINGCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWARNINGCount.Enabled = false;
            this.lblWARNINGCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWARNINGCount.Location = new System.Drawing.Point(146, 126);
            this.lblWARNINGCount.Name = "lblWARNINGCount";
            this.lblWARNINGCount.Size = new System.Drawing.Size(85, 19);
            this.lblWARNINGCount.TabIndex = 11;
            this.lblWARNINGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "NG / TOTAL(%)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "TOTAL Count";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCount.Enabled = false;
            this.lblTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(146, 31);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(85, 19);
            this.lblTotalCount.TabIndex = 4;
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNGCount
            // 
            this.lblNGCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNGCount.Enabled = false;
            this.lblNGCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNGCount.Location = new System.Drawing.Point(146, 95);
            this.lblNGCount.Name = "lblNGCount";
            this.lblNGCount.Size = new System.Drawing.Size(85, 19);
            this.lblNGCount.TabIndex = 9;
            this.lblNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "NG Count";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOKCount
            // 
            this.lblOKCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOKCount.Enabled = false;
            this.lblOKCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOKCount.Location = new System.Drawing.Point(146, 64);
            this.lblOKCount.Name = "lblOKCount";
            this.lblOKCount.Size = new System.Drawing.Size(85, 19);
            this.lblOKCount.TabIndex = 10;
            this.lblOKCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNGPercent
            // 
            this.lblNGPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNGPercent.Enabled = false;
            this.lblNGPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNGPercent.Location = new System.Drawing.Point(146, 158);
            this.lblNGPercent.Name = "lblNGPercent";
            this.lblNGPercent.Size = new System.Drawing.Size(85, 19);
            this.lblNGPercent.TabIndex = 8;
            this.lblNGPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "OK Count";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.label4);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(3, 3);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(334, 214);
            this.pnlChart.TabIndex = 13;
            this.pnlChart.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChart_Paint);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "[ResultRatio Chart]";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "[ResultRatio Count]";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlSearchResultRatio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "CtrlSearchResultRatio";
            this.Size = new System.Drawing.Size(579, 220);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTotalCount;
        public System.Windows.Forms.Label lblNGCount;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblOKCount;
        public System.Windows.Forms.Label lblNGPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblWARNINGCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
    }
}
