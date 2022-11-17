using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Insp;
using RuleAlgorithm.Utility;

namespace Device.Edge
{
    public enum eDerivative
    {
        None,
        One,
        Two,
    }

    public class EdgeElement
    {
        private int _index = -1;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private int _camNo;

        public int CamNo
        {
            get { return _camNo; }
            set { _camNo = value; }
        }

        private int _subNo;

        public int SubNo
        {
            get { return _subNo; }
            set { _subNo = value; }
        }

        private int _orgImageWidth;

        public int OrgImageWidth
        {
            get { return _orgImageWidth; }
            set { _orgImageWidth = value; }
        }

        private int _orgImageHeight;

        public int OrgImageHeight
        {
            get { return _orgImageHeight; }
            set { _orgImageHeight = value; }
        }

        private eEdgeType _type = eEdgeType.None;

        public eEdgeType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // 서브 이미지에서의 위치
        public Rectangle CropRect = new Rectangle();

        //Merge한 이미지에서의 Crop 위치
        public Point CropRealPoint = new Point();

        public EdgeElement Copy()
        {
            EdgeElement element = new EdgeElement();

            element.Type = this.Type;
            element.CamNo = this.CamNo;
            element.SubNo = this.SubNo;
            element.Index = this.Index;
            element.CropRect = new Rectangle(this.CropRect.X, this.CropRect.Y, this.CropRect.Width, this.CropRect.Height);
            element.CropRealPoint = new Point(this.CropRealPoint.X, this.CropRealPoint.Y);
            element.OrgImageWidth = this.OrgImageWidth;
            element.OrgImageHeight = this.OrgImageHeight;

            return element;
        }
    }
}