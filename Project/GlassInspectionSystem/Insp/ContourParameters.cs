using Device.Edge;
using GlassInspectionSystem.Class;
using HMechUtility;
using RuleAlgorithm.Contour;
using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Insp
{
    public class ContourParameters
    {
        public ContourParams LeftParams = new ContourParams(eEdgeType.Left);
        public ContourParams RightParams = new ContourParams(eEdgeType.Right);
        public ContourParams TopParams = new ContourParams(eEdgeType.Top);
        public ContourParams BottomParams = new ContourParams(eEdgeType.Bottom);

        public ContourParams GetParams(eEdgeType type)
        {
            ContourParams param = null;
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

        public ContourParameters Copy()
        {
            ContourParameters param = new ContourParameters();
            param.LeftParams = LeftParams.Copy();
            param.RightParams = RightParams.Copy();
            param.TopParams = TopParams.Copy();
            param.BottomParams = BottomParams.Copy();

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

            ReadXml(leftelement, eEdgeType.Left);

            XmlElement rightelement = configElement["Right"];
            if (rightelement == null)
                return;
            ReadXml(rightelement, eEdgeType.Right);

            XmlElement topelement = configElement["Top"];
            if (topelement == null)
                return;
            ReadXml(topelement, eEdgeType.Top);

            XmlElement bottomelement = configElement["Bottom"];
            if (bottomelement == null)
                return;
            ReadXml(bottomelement, eEdgeType.Bottom);
        }

        private void WriteXml(XmlElement paramElement, eEdgeType type)
        {
            ContourParams param = GetParams(type);

            if (param == null)
                return;

            XmlHelper.SetValue(paramElement, "Type", param.Type.ToString());
            XmlHelper.SetValue(paramElement, "Offset", param.Offset.ToString());
            XmlHelper.SetValue(paramElement, "InspectionArea", param.InspectionArea.ToString());
            XmlHelper.SetValue(paramElement, "MinSize", param.MinSize.ToString());
            XmlHelper.SetValue(paramElement, "TwoDerivativeValue", param.TwoDerivativeValue.ToString());
        }

        private ContourParams ReadXml(XmlElement paramElement, eEdgeType type)
        {
            ContourParams defaultParams = new ContourParams();

            ContourParams param = GetParams(type);

            eEdgeType edgeType = (eEdgeType)Enum.Parse(typeof(eEdgeType), XmlHelper.GetValue(paramElement, "Type", defaultParams.Type.ToString()));
            param.Type = AlgorithmManager.ConvertEdgeType(edgeType);
            param.Offset = Convert.ToInt32(XmlHelper.GetValue(paramElement, "Offset", defaultParams.Offset.ToString()));
            param.InspectionArea = Convert.ToInt32(XmlHelper.GetValue(paramElement, "InspectionArea", defaultParams.InspectionArea.ToString()));
            param.MinSize = Convert.ToDouble(XmlHelper.GetValue(paramElement, "MinSize", defaultParams.MinSize.ToString()));
            param.TwoDerivativeValue = Convert.ToInt32(XmlHelper.GetValue(paramElement, "TwoDerivativeValue", defaultParams.TwoDerivativeValue.ToString()));

            return param;
        }
    }
}
