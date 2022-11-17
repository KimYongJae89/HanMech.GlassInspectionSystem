using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMechDBLib
{
    #region Collection
    public class ResultTable
    {
        private int _Id = 0;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _glassID = "";
        public string GlassID
        {
            get { return _glassID; }
            set { _glassID = value; }
        }

        private string _result = "";
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private string _imagePath = "";
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        private DateTime _updated;
        public DateTime Updated
        {
            get { return _updated; }
            set { _updated = value; }
        }

        private int _dftCount;
        public int DftCount
        {
            get { return _dftCount; }
            set { _dftCount = value; }
        }

        private int _totalCamCount;
        public int TotalCamCount
        {
            get { return _totalCamCount; }
            set { _totalCamCount = value; }
        }

        private int _thumbnailRatio;
        public int ThumbnailRatio
        {
            get { return _thumbnailRatio; }
            set { _thumbnailRatio = value; }
        }

        public ResultTable TableCopy()
        {
            ResultTable table = new ResultTable();
            table.Id = this.Id;
            table.GlassID = this.GlassID;
            table.Result = this.Result;
            table.ImagePath = this.ImagePath;
            table.Updated = this.Updated;
            table.DftCount = this.DftCount;
            table.TotalCamCount = this.TotalCamCount;
            table.ThumbnailRatio = this.ThumbnailRatio;

            return table;
        }
    }

    public class DefectTable
    {
        private int _pid;
        public int Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }

        private int _camNo;
        public int CamNo
        {
            get { return _camNo; }
            set { _camNo = value; }
        }

        private string _dftType = "";
        public string DftType
        {
            get { return _dftType; }
            set { _dftType = value; }
        }

        private DateTime _updated;
        public DateTime Updated
        {
            get { return _updated; }
            set { _updated = value; }
        }

        private double _realPosX;
        public double RealPosX
        {
            get { return _realPosX; }
            set { _realPosX = value; }
        }

        private double _realPosY;
        public double RealPosY
        {
            get { return _realPosY; }
            set { _realPosY = value; }
        }

        private double _boundingPosX;
        public double BoundingPosX
        {
            get { return _boundingPosX; }
            set { _boundingPosX = value; }
        }

        private double _boundingPosY;
        public double BoundingPosY
        {
            get { return _boundingPosY; }
            set { _boundingPosY = value; }
        }

        private double _boundingWidth;
        public double BoundingWidth
        {
            get { return _boundingWidth; }
            set { _boundingWidth = value; }
        }

        private double _boundingHeight;
        public double BoundingHeight
        {
            get { return _boundingHeight; }
            set { _boundingHeight = value; }
        }

        private double _score;
        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private string _inspectionType = "";
        public string InspectionType
        {
            get { return _inspectionType; }
            set { _inspectionType = value; }
        }

        private int _mergeTopOffset = 0;
        public int MergeTopOffset
        {
            get { return _mergeTopOffset; }
            set { _mergeTopOffset = value; }
        }
    }

    public class DailyTable
    {
        private DateTime _updated;
        public DateTime Updated
        {
            get { return _updated; }
            set { _updated = value; }
        }

        private int _okCount;
        public int OKCount
        {
            get { return _okCount; }
            set { _okCount = value; }
        }

        private int _ngCount;
        public int NGCount
        {
            get { return _ngCount; }
            set { _ngCount = value; }
        }

        private int _warningCount;
        public int WarningCount
        {
            get { return _warningCount; }
            set { _warningCount = value; }
        }

        public DailyTable TableCopy()
        {
            DailyTable table = new DailyTable();
            table.Updated = this.Updated;
            table.OKCount = this.OKCount;
            table.NGCount = this.NGCount;
            table.WarningCount = this.WarningCount;
            return table;
        }
    }
    #endregion
}
