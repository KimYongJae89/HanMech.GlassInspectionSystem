using GlassViewer.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMechDBLib;//
using GlassInspectionSystem;

namespace GlassViewer
{
    public partial class FormMain : Form
    {
        public CtrlSearchData SearchDataControl = null;
        public CtrlSearchResultRatio SearchResultRatioControl = null;
        public CtrlDataList DataListControl = null;
        public CtrlThumbnailBox ThumbnailBoxControl = null;
        public Status status = null;

        private static FormMain _instance = null;
        public static FormMain Instance()
        {
            if (_instance == null)
            {
                _instance = new FormMain();
            }

            return _instance;
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                AddControls();//Control 설정 추가

                Settings.Instance().Load();//Config 경로를 Load
                Status.Instance().DBHelper.Initialize("Data Source = (local); Initial Catalog = GIS.AI; Integrated Security = SSPI;");
                FormMain.Instance().SearchDataControl.SettingStartDate();//StartDate 설정(현재날짜 -1달)
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void AddControls()
        {
            try
            {
                SearchDataControl = new CtrlSearchData();
                SearchDataControl.Dock = DockStyle.Fill;
                pnlSearchData.Controls.Add(SearchDataControl);

                SearchResultRatioControl = new CtrlSearchResultRatio();
                SearchResultRatioControl.Dock = DockStyle.Fill;
                pnlSearchResultRatio.Controls.Add(SearchResultRatioControl);

                DataListControl = new CtrlDataList();
                DataListControl.Dock = DockStyle.Fill;
                pnlDataList.Controls.Add(DataListControl);

                ThumbnailBoxControl = new CtrlThumbnailBox();
                ThumbnailBoxControl.Dock = DockStyle.Fill;
                pnlThumbnailBox.Controls.Add(ThumbnailBoxControl);

                this.WindowState = FormWindowState.Maximized;
                this.MinimumSize = new System.Drawing.Size(1600, 1000);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
