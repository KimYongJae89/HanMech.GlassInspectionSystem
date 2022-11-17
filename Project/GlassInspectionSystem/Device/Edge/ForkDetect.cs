using HMechUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Device.Edge
{
    public static class ForkDetect
    {
        private static int _ignoreLeftXOffsetForForkDetect = 100;

        public static int IgnoreLeftXOffsetForForkDetect
        {
            get { return _ignoreLeftXOffsetForForkDetect; }
            set { _ignoreLeftXOffsetForForkDetect = value; }
        }

        private static int _ignoreRightXOffsetForForkDetect = 100;

        public static int IgnoreRightXOffsetForForkDetect
        {
            get { return _ignoreRightXOffsetForForkDetect; }
            set { _ignoreRightXOffsetForForkDetect = value; }
        }

        private static int _twoDerivativeValue = 10;
        public static int TwoDerivativeValue
        {
            get { return _twoDerivativeValue; }
            set { _twoDerivativeValue = value; }
        }

        public static void Save(XmlElement configElement)
        {
            XmlElement edgeDetectElement = configElement.OwnerDocument.CreateElement("", "ForkDetect", "");
            configElement.AppendChild(edgeDetectElement);

            XmlHelper.SetValue(edgeDetectElement, "IgnoreLeftXOffsetForForkDetect", IgnoreLeftXOffsetForForkDetect.ToString());
            XmlHelper.SetValue(edgeDetectElement, "IgnoreRightXOffsetForForkDetect", IgnoreRightXOffsetForForkDetect.ToString());
            XmlHelper.SetValue(edgeDetectElement, "TwoDerivativeValue", TwoDerivativeValue.ToString());
        }

        public static void Load(XmlElement configElement)
        {
            XmlElement edgeDetectElement = configElement["ForkDetect"];
            if (edgeDetectElement == null)
                return;

            IgnoreLeftXOffsetForForkDetect = Convert.ToInt32(XmlHelper.GetValue(edgeDetectElement, "IgnoreLeftXOffsetForForkDetect", IgnoreLeftXOffsetForForkDetect.ToString()));
            IgnoreRightXOffsetForForkDetect = Convert.ToInt32(XmlHelper.GetValue(edgeDetectElement, "IgnoreRightXOffsetForForkDetect", IgnoreRightXOffsetForForkDetect.ToString()));
            IgnoreRightXOffsetForForkDetect = Convert.ToInt32(XmlHelper.GetValue(edgeDetectElement, "TwoDerivativeValue", TwoDerivativeValue.ToString()));
        }
    }
}
