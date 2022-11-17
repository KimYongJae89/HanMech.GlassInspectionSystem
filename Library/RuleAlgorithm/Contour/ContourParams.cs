using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm.Contour
{
    public class ContourParams
    {
        private eEdgeType _type = eEdgeType.None;
        public eEdgeType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _offset = 10;
        public int Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        private int _inspectionArea = 20;
        public int InspectionArea
        {
            get { return _inspectionArea; }
            set { _inspectionArea = value; }
        }

        private double _minSize = 10.0;
        public double MinSize
        {
            get { return _minSize; }
            set { _minSize = value; }
        }

        private int _twoDerivativeValue = 7;
        public int TwoDerivativeValue
        {
            get { return _twoDerivativeValue; }
            set { _twoDerivativeValue = value; }
        }

        public ContourParams()
        {
            this.Type = eEdgeType.None;
        }

        public ContourParams(eEdgeType type)
        {
            this.Type = type;
        }

        public ContourParams Copy()
        {
            ContourParams param = new ContourParams();
            param.Type = this.Type;
            param.Offset = this.Offset;
            param.InspectionArea = this.InspectionArea;
            param.MinSize = this.MinSize;
            param.TwoDerivativeValue = this.TwoDerivativeValue;

            return param;
        }
    }

    public class ContourData
    {
        private double _centerX = 0;
        public double CenterX
        {
            get { return _centerX; }
            set { _centerX = value; }
        }

        private double _centerY = 0;
        public double CenterY
        {
            get { return _centerY; }
            set { _centerY = value; }
        }

        private double _perimeter = 0; // 둘레
        public double Perimeter
        {
            get { return _perimeter; }
            set { _perimeter = value; }
        }

        private double _contourArea = 0;
        public double ContourArea
        {
            get { return _contourArea; }
            set { _contourArea = value; }
        }

        private double _hullSize = 0;
        public double HullSize
        {
            get { return _hullSize; }
            set { _hullSize = value; }
        }

        private double _lineAngle = 0;
        public double LineAngle
        {
            get { return _lineAngle; }
            set { _lineAngle = value; }
        }

        private double _boundingRatio = 0;
        public double BoundingRatio
        {
            get { return _boundingRatio; }
            set { _boundingRatio = value; }
        }

        private double _boundingX = 0;
        public double BoundingX
        {
            get { return _boundingX; }
            set { _boundingX = value; }
        }

        private double _boundingY = 0;
        public double BoundingY
        {
            get { return _boundingY; }
            set { _boundingY = value; }
        }

        private double _boundingWidth = 0;
        public double BoundingWidth
        {
            get { return _boundingWidth; }
            set { _boundingWidth = value; }
        }

        private double _boundingHeight = 0;
        public double BoundingHeight
        {
            get { return _boundingHeight; }
            set { _boundingHeight = value; }
        }

        private double _boundingSize = 0;
        public double BoundingSize
        {
            get { return _boundingSize; }
            set { _boundingSize = value; }
        }

        public ContourData Copy()
        {
            ContourData data = new ContourData();
            data.CenterX = this.CenterX;
            data.CenterY = this.CenterY;
            data.Perimeter = this.Perimeter;
            data.ContourArea = this.ContourArea;
            data.HullSize = this.HullSize;
            data.LineAngle = this.LineAngle;
            data.BoundingRatio = this.BoundingRatio;
            data.BoundingX = this.BoundingX;
            data.BoundingY = this.BoundingY;
            data.BoundingWidth = this.BoundingWidth;
            data.BoundingHeight = this.BoundingHeight;
            data.BoundingSize = this.BoundingSize;

            return data;
        }
    }
}
