using OpenCvSharp;
using OpenCvSharp.Extensions;
using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Device.Edge
{
    public static class CornerHelper
    {
        public static Rectangle GetCornerRectangle(System.Drawing.Point Point, int rectSize = 200)
        {
            Rectangle rect = new Rectangle(Point.X - (rectSize / 2), Point.Y - (rectSize / 2), rectSize, rectSize);
            return rect;
        }

        // 사용중
        public static EdgeElement GetFirstLeftEdgeElement(List<EdgeElement> edgeList, int camNo)
        {
            int subNo = 9999;
            EdgeElement retElement = null;
            foreach (EdgeElement element in edgeList)
            {
                if (element.Type == eEdgeType.Left)
                {
                    if (subNo >= element.SubNo && camNo == element.CamNo)
                    {
                        retElement = element.Copy();
                        subNo = element.SubNo;
                    }
                }
            }
            return retElement;
        }

        // 사용중
        public static EdgeElement GetLastLeftEdgeElement(List<EdgeElement> edgeList, int camNo)
        {
            int subNo = -9999;
            EdgeElement retElement = null;
            foreach (EdgeElement element in edgeList)
            {
                if (element.Type == eEdgeType.Left)
                {
                    if (subNo <= element.SubNo && camNo == element.CamNo)
                    {
                        retElement = element.Copy();
                        subNo = element.SubNo;
                    }
                }
            }
            return retElement;
        }

        // 사용중
        public static EdgeElement GetFirstRightEdgeElement(List<EdgeElement> edgeList, int camNo)
        {
            int subNo = 9999;
            EdgeElement retElement = null;
            foreach (EdgeElement element in edgeList)
            {
                if (element.Type == eEdgeType.Right)
                {
                    if (subNo >= element.SubNo && camNo == element.CamNo)
                    {
                        retElement = element.Copy();
                        subNo = element.SubNo;
                    }
                }
            }
            return retElement;
        }

        //사용중
        public static EdgeElement GetLastRightEdgeElement(List<EdgeElement> edgeList, int camNo)
        {
            int subNo = -9999;
            EdgeElement retElement = null;
            foreach (EdgeElement element in edgeList)
            {
                if (element.Type == eEdgeType.Right)
                {
                    if (subNo <= element.SubNo && camNo == element.CamNo)
                    {
                        retElement = element.Copy();
                        subNo = element.SubNo;
                    }
                }
            }
            return retElement;
        }

        public static EdgeElement GetTopEdgeElement(List<EdgeElement> edgeList, int camNo)
        {
            foreach (EdgeElement element in edgeList)
            {
                if (element.Type == eEdgeType.Top)
                {
                    if (element.CamNo == camNo)
                    {
                        return element;
                    }
                }
            }
            return null;
        }

        public static EdgeElement GetBottomEdgeElement(List<EdgeElement> edgeList, int camNo)
        {
            foreach (EdgeElement element in edgeList)
            {
                if (element.Type == eEdgeType.Bottom)
                {
                    if (element.CamNo == camNo)
                    {
                        return element;
                    }
                }
            }
            return null;
        }

        public static int GetFirstLeftEdgeIndex(List<EdgeElement> edgeList)
        {
            int ret = 0;
            int subNo = 9999;
            foreach (EdgeElement element in edgeList)
            {
                if (element.Type == eEdgeType.Left)
                {
                    if (subNo >= element.SubNo)
                    {
                        ret = element.Index;
                        subNo = element.SubNo;
                    }
                }
            }
            return ret;
        }

        // 사용중
        public static int GetTopEdgeIndex(Bitmap bmp, int leftEdgeIndex, int interval = 100)
        {
            try
            {
                Mat mat = BitmapConverter.ToMat(bmp);

                if (mat.Depth() != (int)ImreadModes.GrayScale)
                    OpenCvSharp.Cv2.CvtColor(mat, mat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

                Rect roi = new Rect(leftEdgeIndex + interval, 0, 100, bmp.Height);

                Mat cropMat = new Mat(mat, roi);

                int index = EdgeDetect.FindEdgeIndex(eEdgeType.Top, cropMat);

                cropMat.Dispose();
                mat.Dispose();

                return index;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                return 0;
            }
        }

        // 사용중
        public static int GetBottomEdgeIndex(Bitmap bmp, int leftEdgeIndex, int interval = 100)
        {
            try
            {
                Mat mat = BitmapConverter.ToMat(bmp);

                if (mat.Depth() != (int)ImreadModes.GrayScale)
                    OpenCvSharp.Cv2.CvtColor(mat, mat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

                Rect roi = new Rect(leftEdgeIndex + interval, 0, 100, bmp.Height);

                Mat cropMat = new Mat(mat, roi);

                int index = EdgeDetect.FindEdgeIndex(eEdgeType.Bottom, cropMat);

                cropMat.Dispose();
                mat.Dispose();

                return index;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                return 0;
            }
        }

        public static int GetMaxTopEdgeIndex(List<EdgeElement>[] edgeList)
        {
            int index = int.MinValue;

            for (int i = 0; i < edgeList.Count(); i++)
            {
                foreach (EdgeElement element in edgeList[i])
                {
                    if (element.Type == eEdgeType.Top)
                    {
                        int topIndex = (element.SubNo * element.OrgImageHeight) + element.Index;
                        if (index <= topIndex)
                        {
                            index = topIndex;
                        }
                    }
                }
            }
            
            return index;
        }

        public static int GetMinTopEdgeIndex(List<EdgeElement>[] edgeList)
        {
            int index = int.MaxValue;

            for (int i = 0; i < edgeList.Count(); i++)
            {
                foreach (EdgeElement element in edgeList[i])
                {
                    if (element.Type == eEdgeType.Top)
                    {
                        int topIndex = (element.SubNo * element.OrgImageHeight) + element.Index;
                        if (index >= topIndex)
                        {
                            index = topIndex;
                        }
                    }
                }
            }

            return index;
        }
    }
}