using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RuleAlgorithm.Broken
{
    public class BrokenParams
    {
        private eEdgeType _type;
        public eEdgeType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _outSidePixelFromEdge = 100;
        public int OutSidePixelFromEdge
        {
            get { return _outSidePixelFromEdge; }
            set { _outSidePixelFromEdge = value; }
        }

        private int _inSidePixelFromEdge = 100;
        public int InSidePixelFromEdge
        {
            get { return _inSidePixelFromEdge; }
            set { _inSidePixelFromEdge = value; }
        }

        private double _BrokenVal = 3;
        public double BrokenVal
        {
            get { return _BrokenVal; }
            set { _BrokenVal = value; }
        }

        private int _AvgCnt = 4; //
        public int AvgCnt
        {
            get { return _AvgCnt; }
            set { _AvgCnt = value; }
        }

        private int _twoDerivativeValue = 10;
        public int TwoDerivativeValue
        {
            get { return _twoDerivativeValue; }
            set { _twoDerivativeValue = value; }
        }

        private double _threshold1 = 30.0;
        public double Threshold1
        {
            get { return _threshold1; }
            set { _threshold1 = value; }
        }
        private double _threshold2 = 200.0;
        public double Threshold2
        {
            get { return _threshold2; }
            set { _threshold2 = value; }
        }

        public BrokenParams()
        {

        }

        public BrokenParams(eEdgeType type)
        {
            this.Type = type;
        }

        public BrokenParams Copy()
        {
            BrokenParams param = new BrokenParams();
            param.Type = this.Type;
            param.OutSidePixelFromEdge = this.OutSidePixelFromEdge;
            param.InSidePixelFromEdge = this.InSidePixelFromEdge;
            param.BrokenVal = this.BrokenVal;
            param.AvgCnt = this.AvgCnt;
            param.TwoDerivativeValue = this.TwoDerivativeValue;
            param.Threshold1 = this.Threshold1;
            param.Threshold2 = this.Threshold2;
            return param;
        }
    }
}
