using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GlassViewer.Forms;
using HMechDBLib;

namespace GlassViewer
{
    public class YPosition
    {
        public float OkPosition = 0;
        public float NgPosition = 0;
        public float WarningPosition = 0;
    }

    public class FormManager
    {
        private FormGlassViewSettings _formGlassViewSettings = null;
        private FormLineChart _formLineChart = null;
        private FormTest _formTest = null;

        public void OpenFormGlassViewSettings()
        {
            if (_formGlassViewSettings == null)
            {
                _formGlassViewSettings = new FormGlassViewSettings();
                // CloseEventDelegate 생성
                _formGlassViewSettings.CloseEventDelegate = () => this._formGlassViewSettings = null;
                _formGlassViewSettings.ShowDialog();
            }
        }

        public void OpenFormLineChart()
        {
            if(_formLineChart == null)
            {
                _formLineChart = new FormLineChart();
                _formLineChart.CloseEventDelegate = () => this._formLineChart = null;
                _formLineChart.Show();
            }
        }

        public void OpenFormFormTest()
        {
            if (_formTest == null)
            {
                _formTest = new FormTest();
                _formTest.CloseEventDelegate = () => this._formTest = null;
                _formTest.ShowDialog();
            }
        }
    }

    public class Status
    {
        public HMechDBLibaray DBHelper = new HMechDBLibaray();
        public FormManager Forms = new FormManager();

        private int _ngCount = 0;
        public int NgCount
        {
            get { return _ngCount; }
            set { _ngCount = value; }
        }

        private int _okCount = 0;
        public int OkCount
        {
            get { return _okCount; }
            set { _okCount = value; }
        }

        private int _warningCount = 0;
        public int WarningCount
        {
            get { return _warningCount; }
            set { _warningCount = value; }
        }

        private int _totalCount = 0;
        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }

        private DataGridView _getDataGridView;
        public DataGridView GetDataGridView
        {
            get { return _getDataGridView; }
            set { _getDataGridView = value; }
        }

        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        private string _searchDefectType;
        public string SearchDefectType
        {
            get { return _searchDefectType; }
            set { _searchDefectType = value; }
        }

        private double _thumbnailImageRatio;
        public double ThumbnailImageRatio
        {
            get { return _thumbnailImageRatio; }
            set { _thumbnailImageRatio = value; }
        }

        private int _totalCamCount;
        public int TotalCamCount
        {
            get { return _totalCamCount; }
            set { _totalCamCount = value; }
        }

        private int _okCountMax = 0;
        public int OCountMax
        {
            get { return _okCountMax; }
            set { _okCountMax = value; }
        }

        private static Status _instance = null;
        public static Status Instance()
        {
            if (_instance == null)
            {
                _instance = new Status();
            }

            return _instance;
        }
    }
}
