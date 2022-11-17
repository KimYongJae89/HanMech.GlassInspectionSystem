using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Device.Edge;
using GlassInspectionSystem;
using GlassInspectionSystem.Class;
using HMechLogLib;
using HMechUtility;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using RuleAlgorithm;
using RuleAlgorithm.Broken;
using RuleAlgorithm.Utility;

namespace Insp
{
    public class BrokenDetect
    {
        private BrokenAlgorithms _inspection = new BrokenAlgorithms();

        public void SetParams(BrokenParams param)
        {
            if (_inspection != null)
                _inspection.SetParam(param);
        }

        public List<Rectangle> Excute(EdgeElement element, Bitmap bmp)
        {
            eEdgeType type = AlgorithmManager.ConvertEdgeType(element.Type);

            if (element.Type == eEdgeType.None)
            {
                Logger.Write(eLogType.ERROR, "Error Occured!, Not Selected Edge Type", DateTime.Now);
                return null;
            }

            return _inspection.Run(bmp, type);
        }
    }
}