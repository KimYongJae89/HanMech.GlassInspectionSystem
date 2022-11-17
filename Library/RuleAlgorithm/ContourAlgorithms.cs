using OpenCvSharp;
using OpenCvSharp.Extensions;
using RuleAlgorithm.Contour;
using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm
{
    public class ContourAlgorithms
    {
        private ContourParams _param = new ContourParams();

        public ContourParams GetParam()
        {
            return _param;
        }

        public void SetParam(ContourParams param)
        {
            _param = param.Copy();
        }

        public List<ContourData> Run(Bitmap bmp)
        {
            List<System.Drawing.Rectangle> defectList = new List<Rectangle>();

            Bitmap processingImage = HanMechImageHelper.ProcessTwoDerivative(bmp, eDirection.All, _param.TwoDerivativeValue);

            ContourDetection detect = new ContourDetection();
            List<ContourData> contourResult = detect.Run(processingImage);

            processingImage.Dispose();
            return Filter(contourResult);
        }

        public List<ContourData> Run(Bitmap bmp, eEdgeType type)
        {
            List<System.Drawing.Rectangle> defectList = new List<Rectangle>();
            //left right => hor
            Bitmap processingImage = null;
            if(type == eEdgeType.Left || type == eEdgeType.Right)
            {
                processingImage = HanMechImageHelper.ProcessTwoDerivative(bmp, eDirection.Horizon, _param.TwoDerivativeValue);
            }
            else
            {
                processingImage = HanMechImageHelper.ProcessTwoDerivative(bmp, eDirection.Vertical, _param.TwoDerivativeValue);
            }
       
            ContourDetection detect = new ContourDetection();
            List<ContourData> contourResult = detect.Run(processingImage);

            processingImage.Dispose();
            return Filter(contourResult);
        }

        public List<ContourData> Filter(List<ContourData> contourDataList)
        {
            List<ContourData> filteredList = new List<ContourData>();
            foreach (ContourData data in contourDataList)
            {
                if (data.BoundingWidth <= this._param.MinSize && data.BoundingHeight <= this._param.MinSize)
                   continue;

                filteredList.Add(data.Copy());
            }
            return filteredList;
        }
    }
}
