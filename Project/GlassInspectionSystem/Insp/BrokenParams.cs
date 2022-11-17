using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Device.Edge;
using HMechUtility;

namespace Insp
{
    public class BrokenParam
    {
        private eEdgeType _type;
        public eEdgeType Type
        {
            get { return _type; }
            set { _type = value; }
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

        private double _Threshold1 = 10;
        public double Threshold1
        {
            get { return _Threshold1; }
            set { _Threshold1 = value; }
        }

        private double _Threshold2 = 60;
        public double Threshold2
        {
            get { return _Threshold2; }
            set { _Threshold2 = value; }
        }
 

        public void Save(XmlElement paramElement)
        {
            XmlHelper.SetValue(paramElement, "Type", Type.ToString());
            XmlHelper.SetValue(paramElement, "BrokenVal", BrokenVal.ToString());
            XmlHelper.SetValue(paramElement, "AvgCnt", AvgCnt.ToString());
            XmlHelper.SetValue(paramElement, "Threshold1", Threshold1.ToString());
            XmlHelper.SetValue(paramElement, "Threshold2", Threshold2.ToString());
        }

        public void Load(XmlElement paramElement)
        {
            Type = (eEdgeType)Enum.Parse(typeof(eEdgeType), XmlHelper.GetValue(paramElement, "Type", Type.ToString()));
            BrokenVal = Convert.ToDouble(XmlHelper.GetValue(paramElement, "BrokenVal", BrokenVal.ToString()));
            AvgCnt = Convert.ToInt32(XmlHelper.GetValue(paramElement, "AvgCnt", AvgCnt.ToString()));
            Threshold1 = Convert.ToDouble(XmlHelper.GetValue(paramElement, "Threshold1", Threshold1.ToString()));
            Threshold2 = Convert.ToDouble(XmlHelper.GetValue(paramElement, "Threshold2", Threshold2.ToString()));
        }

        public BrokenParam Copy()
        {
            BrokenParam brkp = new BrokenParam();

            brkp.BrokenVal = this.BrokenVal;
            brkp.AvgCnt = this.AvgCnt;
            brkp.Threshold1 = this.Threshold1;
            brkp.Threshold2 = this.Threshold2;

            return brkp;
        }
    }

    public class BrokenParams
    {
        private BrokenParam _left = new BrokenParam();
        public BrokenParam Left
        {
            get { return _left; }
            set { _left = value.Copy(); }
        }

        private BrokenParam _right = new BrokenParam();
        public BrokenParam Right
        {
            get { return _right; }
            set { _right = value.Copy(); }
        }

        private BrokenParam _top = new BrokenParam();
        public BrokenParam Top
        {
            get { return _top; }
            set { _top = value.Copy(); }
        }

        private BrokenParam _bottom = new BrokenParam();
        public BrokenParam Bottom
        {
            get { return _bottom; }
            set { _bottom = value.Copy(); }
        }

        public BrokenParams()
        {
            _left.Type = eEdgeType.Left;
            _right.Type = eEdgeType.Right;
            _top.Type = eEdgeType.Top;
            _bottom.Type = eEdgeType.Bottom;
        }
            
        public BrokenParams Copy()
        {
            BrokenParams paramList = new BrokenParams();
            paramList._left = this._left.Copy();
            paramList._right = this._right.Copy();
            paramList._top = this._top.Copy();
            paramList._bottom = this._bottom.Copy();

            return paramList;
        }

        public void Save(XmlElement configElement)
        {
            XmlElement brokenDetectElement = configElement.OwnerDocument.CreateElement("", "BrokenDetect", "");
            configElement.AppendChild(brokenDetectElement);

            XmlElement leftElement = configElement.OwnerDocument.CreateElement("", "Left", "");
            brokenDetectElement.AppendChild(leftElement);

            Left.Save(leftElement);

            XmlElement rightElement = configElement.OwnerDocument.CreateElement("", "Right", "");
            brokenDetectElement.AppendChild(rightElement);

            Right.Save(rightElement);

            XmlElement topElement = configElement.OwnerDocument.CreateElement("", "Top", "");
            brokenDetectElement.AppendChild(topElement);

            Top.Save(topElement);

            XmlElement bottomElement = configElement.OwnerDocument.CreateElement("", "Bottom", "");
            brokenDetectElement.AppendChild(bottomElement);
            
            Bottom.Save(bottomElement);
        }

        public void Load(XmlElement configElement)
        {
            XmlElement brokenElement = configElement["BrokenDetect"];
            if (brokenElement == null)
                return;

            XmlElement leftelement = brokenElement["Left"];
            if (leftelement == null)
                return;

            Left.Load(leftelement);

            XmlElement rightelement = brokenElement["Right"];
            if (rightelement == null)
                return;

            Right.Load(rightelement);

            XmlElement topelement = brokenElement["Top"];
            if (topelement == null)
                return;

            Top.Load(topelement);

            XmlElement bottomelement = brokenElement["Bottom"];
            if (bottomelement == null)
                return;

            Bottom.Load(bottomelement);
        }
    }
}
