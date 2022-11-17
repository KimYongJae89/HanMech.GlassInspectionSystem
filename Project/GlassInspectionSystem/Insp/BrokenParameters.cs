using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Device.Edge;
using GlassInspectionSystem.Class;
using HMechUtility;
using RuleAlgorithm.Broken;
using RuleAlgorithm.Utility;

namespace Insp
{
    public class BrokenParameters
    {
        public BrokenParams LeftParams = new BrokenParams(RuleAlgorithm.Utility.eEdgeType.Left);
        public BrokenParams RightParams = new BrokenParams(RuleAlgorithm.Utility.eEdgeType.Right);
        public BrokenParams TopParams = new BrokenParams(RuleAlgorithm.Utility.eEdgeType.Top);
        public BrokenParams BottomParams = new BrokenParams(RuleAlgorithm.Utility.eEdgeType.Bottom);

        public BrokenParams GetParams(eEdgeType type)
        {
            BrokenParams param = null;
            switch (type)
            {
                case eEdgeType.Left:
                    param = LeftParams;
                    break;
                case eEdgeType.Right:
                    param = RightParams;
                    break;
                case eEdgeType.Top:
                    param = TopParams;
                    break;
                case eEdgeType.Bottom:
                    param = BottomParams;
                    break;
                case eEdgeType.None:
                default:
                    break;
            }
            return param;
        }

        public void Save(XmlElement configElement)
        {
            XmlElement leftElement = configElement.OwnerDocument.CreateElement("", "Left", "");
            configElement.AppendChild(leftElement);

            WriteXml(leftElement, eEdgeType.Left);

            XmlElement rightElement = configElement.OwnerDocument.CreateElement("", "Right", "");
            configElement.AppendChild(rightElement);

            WriteXml(rightElement, eEdgeType.Right);

            XmlElement topElement = configElement.OwnerDocument.CreateElement("", "Top", "");
            configElement.AppendChild(topElement);

            WriteXml(topElement, eEdgeType.Top);

            XmlElement bottomElement = configElement.OwnerDocument.CreateElement("", "Bottom", "");
            configElement.AppendChild(bottomElement);

            WriteXml(bottomElement, eEdgeType.Bottom);
        }

        public void Load(XmlElement configElement)
        {
            XmlElement leftelement = configElement["Left"];
            if (leftelement == null)
                return;

            LeftParams = ReadXml(leftelement, eEdgeType.Left).Copy();

            XmlElement rightelement = configElement["Right"];
            if (rightelement == null)
                return;
            RightParams = ReadXml(rightelement, eEdgeType.Right).Copy();

            XmlElement topelement = configElement["Top"];
            if (topelement == null)
                return;
            TopParams = ReadXml(topelement, eEdgeType.Top).Copy();

            XmlElement bottomelement = configElement["Bottom"];
            if (bottomelement == null)
                return;
            BottomParams = ReadXml(bottomelement, eEdgeType.Bottom).Copy();
        }

        private void WriteXml(XmlElement paramElement, eEdgeType type)
        {
            BrokenParams param = GetParams(type);

            if (param == null)
                return;

            XmlHelper.SetValue(paramElement, "Type", param.Type.ToString());
            XmlHelper.SetValue(paramElement, "OutSizePixelFromEdge", param.OutSidePixelFromEdge.ToString());
            XmlHelper.SetValue(paramElement, "InSidePixelFromEdge", param.InSidePixelFromEdge.ToString());
            XmlHelper.SetValue(paramElement, "BrokenVal", param.BrokenVal.ToString());
            XmlHelper.SetValue(paramElement, "AvgCnt", param.AvgCnt.ToString());
            XmlHelper.SetValue(paramElement, "TwoDerivativeValue", param.TwoDerivativeValue.ToString());

            XmlHelper.SetValue(paramElement, "Threshold1", param.Threshold1.ToString());
            XmlHelper.SetValue(paramElement, "Threshold2", param.Threshold2.ToString());
        }

        private BrokenParams ReadXml(XmlElement paramElement, eEdgeType type)
        {
            BrokenParams defaultParams = new BrokenParams(RuleAlgorithm.Utility.eEdgeType.None);

            BrokenParams param = GetParams(type);

            eEdgeType edgeType = (eEdgeType)Enum.Parse(typeof(eEdgeType), XmlHelper.GetValue(paramElement, "Type", defaultParams.Type.ToString()));
            param.Type = AlgorithmManager.ConvertEdgeType(edgeType);
            param.OutSidePixelFromEdge = Convert.ToInt32(XmlHelper.GetValue(paramElement, "OutSizePixelFromEdge", defaultParams.OutSidePixelFromEdge.ToString()));
            param.InSidePixelFromEdge = Convert.ToInt32(XmlHelper.GetValue(paramElement, "InSidePixelFromEdge", defaultParams.InSidePixelFromEdge.ToString()));
            param.BrokenVal = Convert.ToDouble(XmlHelper.GetValue(paramElement, "BrokenVal", defaultParams.BrokenVal.ToString()));
            param.AvgCnt = Convert.ToInt32(XmlHelper.GetValue(paramElement, "AvgCnt", defaultParams.AvgCnt.ToString()));
            param.TwoDerivativeValue = Convert.ToInt32(XmlHelper.GetValue(paramElement, "TwoDerivativeValue", defaultParams.TwoDerivativeValue.ToString()));

            param.Threshold1 = Convert.ToDouble(XmlHelper.GetValue(paramElement, "Threshold1", defaultParams.Threshold1.ToString()));
            param.Threshold2 = Convert.ToDouble(XmlHelper.GetValue(paramElement, "Threshold2", defaultParams.Threshold2.ToString()));

            return param;
        }

        public BrokenParameters Copy()
        {
            BrokenParameters param = new BrokenParameters();
            param.LeftParams = LeftParams.Copy();
            param.RightParams = RightParams.Copy();
            param.TopParams = TopParams.Copy();
            param.BottomParams = BottomParams.Copy();

            return param;
        }
    }
}
