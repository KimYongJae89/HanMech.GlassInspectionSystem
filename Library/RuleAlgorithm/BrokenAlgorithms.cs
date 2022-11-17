using OpenCvSharp;
using OpenCvSharp.Extensions;
using RuleAlgorithm.Broken;
using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm
{
    public class BrokenAlgorithms
    {
        private BrokenParams _param = new BrokenParams();

        public BrokenParams GetParam()
        {
            return _param;
        }

        public void SetParam(BrokenParams param)
        {
            _param = param.Copy();
        }

        public List<System.Drawing.Rectangle> Run(Bitmap bmp, eEdgeType type)
        {   // 라인 굵기 한번 생각하기
            if (bmp == null)
                return new List<System.Drawing.Rectangle>();
            eDirection direction = eDirection.None;

            if (type == eEdgeType.Left || type == eEdgeType.Right)
                direction = eDirection.Vertical;
            else if (type == eEdgeType.Top || type == eEdgeType.Bottom)
                direction = eDirection.Horizon;

            //Bitmap calcBmp = HanMechImageHelper.ProcessTwoDerivative(bmp, direction, _param.TwoDerivativeValue);


            Mat mat = BitmapConverter.ToMat(bmp);
            if (mat.Channels() != 1)
            {
                Cv2.CvtColor(mat, mat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);
            }
            Cv2.Canny(mat, mat, _param.Threshold1,_param.Threshold2);
            Bitmap calcBmp = BitmapConverter.ToBitmap(mat);
            BrokenDetection detect = BrokenDetectionFactory.Create(type);
            float[] lineList = detect.LineTracking(calcBmp);

            mat.Dispose();
            return detect.Run(lineList, Convert.ToInt32(_param.BrokenVal), _param.AvgCnt, bmp.Width, bmp.Height);
        }
    }
}