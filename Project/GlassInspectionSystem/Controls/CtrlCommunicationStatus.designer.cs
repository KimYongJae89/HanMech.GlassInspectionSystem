namespace GlassInspectionSystem.Controls
{
    partial class CtrlCommunicationStatus
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
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPcComplete = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPlcComplete = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPlcAlive = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPlcConnection = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumOfCam = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTrigger = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInspection = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblCurrentTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlDisplay, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(516, 134);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblCurrentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTime.Location = new System.Drawing.Point(3, 0);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(510, 25);
            this.lblCurrentTime.TabIndex = 0;
            this.lblCurrentTime.Text = "2020.02.19(수) 14:00:20";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.label9);
            this.pnlDisplay.Controls.Add(this.label12);
            this.pnlDisplay.Controls.Add(this.label8);
            this.pnlDisplay.Controls.Add(this.lblPcComplete);
            this.pnlDisplay.Controls.Add(this.label7);
            this.pnlDisplay.Controls.Add(this.lblPlcComplete);
            this.pnlDisplay.Controls.Add(this.label6);
            this.pnlDisplay.Controls.Add(this.lblPlcAlive);
            this.pnlDisplay.Controls.Add(this.label5);
            this.pnlDisplay.Controls.Add(this.lblPlcConnection);
            this.pnlDisplay.Controls.Add(this.label4);
            this.pnlDisplay.Controls.Add(this.lblNumOfCam);
            this.pnlDisplay.Controls.Add(this.label3);
            this.pnlDisplay.Controls.Add(this.lblTrigger);
            this.pnlDisplay.Controls.Add(this.label2);
            this.pnlDisplay.Controls.Add(this.lblInspection);
            this.pnlDisplay.Controls.Add(this.label1);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(3, 28);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(510, 103);
            this.pnlDisplay.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(445, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "mm/sec";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Visible = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(380, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 17);
            this.label12.TabIndex = 15;
            this.label12.Text = "400";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Visible = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(251, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Conv Vel";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Visible = false;
            // 
            // lblPcComplete
            // 
            this.lblPcComplete.BackColor = System.Drawing.Color.White;
            this.lblPcComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPcComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPcComplete.Location = new System.Drawing.Point(380, 51);
            this.lblPcComplete.Name = "lblPcComplete";
            this.lblPcComplete.Size = new System.Drawing.Size(120, 17);
            this.lblPcComplete.TabIndex = 13;
            this.lblPcComplete.Text = "Complete";
            this.lblPcComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(251, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "PC Complete";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlcComplete
            // 
            this.lblPlcComplete.BackColor = System.Drawing.Color.White;
            this.lblPlcComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlcComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlcComplete.Location = new System.Drawing.Point(380, 28);
            this.lblPlcComplete.Name = "lblPlcComplete";
            this.lblPlcComplete.Size = new System.Drawing.Size(120, 17);
            this.lblPlcComplete.TabIndex = 11;
            this.lblPlcComplete.Text = "Complete";
            this.lblPlcComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(251, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "PLC Complete";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlcAlive
            // 
            this.lblPlcAlive.BackColor = System.Drawing.Color.White;
            this.lblPlcAlive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlcAlive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlcAlive.Location = new System.Drawing.Point(380, 6);
            this.lblPlcAlive.Name = "lblPlcAlive";
            this.lblPlcAlive.Size = new System.Drawing.Size(120, 17);
            this.lblPlcAlive.TabIndex = 9;
            this.lblPlcAlive.Text = "ON";
            this.lblPlcAlive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(251, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "PLC Alive";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlcConnection
            // 
            this.lblPlcConnection.BackColor = System.Drawing.Color.White;
            this.lblPlcConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlcConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlcConnection.Location = new System.Drawing.Point(129, 73);
            this.lblPlcConnection.Name = "lblPlcConnection";
            this.lblPlcConnection.Size = new System.Drawing.Size(120, 17);
            this.lblPlcConnection.TabIndex = 7;
            this.lblPlcConnection.Text = "Disconnected";
            this.lblPlcConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "PLC Connection";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumOfCam
            // 
            this.lblNumOfCam.BackColor = System.Drawing.Color.White;
            this.lblNumOfCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumOfCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfCam.Location = new System.Drawing.Point(129, 51);
            this.lblNumOfCam.Name = "lblNumOfCam";
            this.lblNumOfCam.Size = new System.Drawing.Size(120, 17);
            this.lblNumOfCam.TabIndex = 5;
            this.lblNumOfCam.Text = "8 of 8";
            this.lblNumOfCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Num of Cam";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrigger
            // 
            this.lblTrigger.BackColor = System.Drawing.Color.White;
            this.lblTrigger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrigger.Location = new System.Drawing.Point(129, 28);
            this.lblTrigger.Name = "lblTrigger";
            this.lblTrigger.Size = new System.Drawing.Size(120, 17);
            this.lblTrigger.TabIndex = 3;
            this.lblTrigger.Text = "ON";
            this.lblTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trigger";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspection
            // 
            this.lblInspection.BackColor = System.Drawing.Color.White;
            this.lblInspection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInspection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspection.Location = new System.Drawing.Point(129, 6);
            this.lblInspection.Name = "lblInspection";
            this.lblInspection.Size = new System.Drawing.Size(120, 17);
            this.lblInspection.TabIndex = 1;
            this.lblInspection.Text = "ON";
            this.lblInspection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inspection";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlCommunicationStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CtrlCommunicationStatus";
            this.Size = new System.Drawing.Size(516, 134);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlDisplay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.Label lblInspection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTrigger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlcConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumOfCam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPcComplete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPlcComplete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPlcAlive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
    }
}
