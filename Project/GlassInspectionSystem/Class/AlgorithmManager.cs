using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Device.Edge;
using enumType;
using HMechLogLib;
using Insp;
using OpenCvSharp;
using RuleAlgorithm.Utility;

namespace GlassInspectionSystem.Class
{
    public class AlgorithmManager
    {
        public BrokenDetect Broken = new BrokenDetect();
        public ContourDetect Contour = new ContourDetect();

        public static eEdgeType ConvertEdgeType(eEdgeType type)
        {
            if (type == eEdgeType.None)
                return eEdgeType.None;
            else if (type == eEdgeType.Left)
                return eEdgeType.Left;
            else if (type == eEdgeType.Right)
                return eEdgeType.Right;
            else if (type == eEdgeType.Top)
                return eEdgeType.Top;
            else if (type == eEdgeType.Bottom)
                return eEdgeType.Bottom;
            else
                return eEdgeType.None;
        }

        public static List<EdgeElement> ForkDetect(EdgeElement element, int twoDerivateValue, int ignoreLeftPixel, int ignoreRightPixel)
        {
            return null;
        }
    }

    
}
