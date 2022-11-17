using Device.Edge;
using GlassInspectionSystem;
using HMechUtility;
using RuleAlgorithm;
using RuleAlgorithm.Contour;
using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Insp
{
    public class ContourDetect
    {
        private ContourAlgorithms _inspection = new ContourAlgorithms();

        public void SetParams(ContourParams param)
        {
            if (_inspection != null)
                _inspection.SetParam(param);
        }

        public List<Rectangle> Excute(Bitmap bmp, eEdgeType type)
        {
            List<Rectangle> resultList = new List<Rectangle>();

            List<ContourData> contourList = _inspection.Run(bmp, type);
            foreach (ContourData data in contourList)
            {
                Rectangle defect = new Rectangle((int)data.BoundingX, (int)data.BoundingY, (int)data.BoundingWidth, (int)data.BoundingHeight);
                resultList.Add(defect);
            }

            return resultList;
        }
    }
}
