namespace GlassViewer
{
    partial class FormMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDataList = new System.Windows.Forms.Panel();
            this.pnlSearchData = new System.Windows.Forms.Panel();
            this.pnlSearchResultRatio = new System.Windows.Forms.Panel();
            this.pnlThumbnailBox = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlThumbnailBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1584, 961);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.pnlDataList, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pnlSearchData, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlSearchResultRatio, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(594, 955);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pnlDataList
            // 
            this.pnlDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataList.Location = new System.Drawing.Point(3, 343);
            this.pnlDataList.Name = "pnlDataList";
            this.pnlDataList.Size = new System.Drawing.Size(588, 609);
            this.pnlDataList.TabIndex = 1;
            // 
            // pnlSearchData
            // 
            this.pnlSearchData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchData.Location = new System.Drawing.Point(3, 3);
            this.pnlSearchData.Name = "pnlSearchData";
            this.pnlSearchData.Size = new System.Drawing.Size(588, 124);
            this.pnlSearchData.TabIndex = 0;
            // 
            // pnlSearchResultRatio
            // 
            this.pnlSearchResultRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchResultRatio.Location = new System.Drawing.Point(3, 133);
            this.pnlSearchResultRatio.Name = "pnlSearchResultRatio";
            this.pnlSearchResultRatio.Size = new System.Drawing.Size(588, 204);
            this.pnlSearchResultRatio.TabIndex = 2;
            // 
            // pnlThumbnailBox
            // 
            this.pnlThumbnailBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThumbnailBox.Location = new System.Drawing.Point(603, 3);
            this.pnlThumbnailBox.Name = "pnlThumbnailBox";
            this.pnlThumbnailBox.Size = new System.Drawing.Size(978, 955);
            this.pnlThumbnailBox.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 961);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMain";
            this.Text = "Glass Viewer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlSearchData;
        private System.Windows.Forms.Panel pnlDataList;
        private System.Windows.Forms.Panel pnlSearchResultRatio;
        private System.Windows.Forms.Panel pnlThumbnailBox;
    }
}

