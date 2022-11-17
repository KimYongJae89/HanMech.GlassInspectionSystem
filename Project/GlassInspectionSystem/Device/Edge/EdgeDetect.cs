using Device.Edge;
using HMechUtility;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Xml;

namespace Device.Edge
{
    public static class EdgeDetect
    {
        private static int _ignoreLeftXOffsetForEdgeDetect = 100;

        public static int IgnoreLeftXOffsetForEdgeDetect
        {
            get { return _ignoreLeftXOffsetForEdgeDetect; }
            set { _ignoreLeftXOffsetForEdgeDetect = value; }
        }

        private static int _ignoreRightXOffsetForEdgeDetect = 100;

        public static int IgnoreRightXOffsetForEdgeDetect
        {
            get { return _ignoreRightXOffsetForEdgeDetect; }
            set { _ignoreRightXOffsetForEdgeDetect = value; }
        }

        private static int _distanceFromEdge = 100;

        public static int DistanceFromEdge
        {
            get { return _distanceFromEdge; }
            set { _distanceFromEdge = value; }
        }

        private static int _ignoreRealHeightForEdgeDetect = 200;

        public static int IgnoreRealHeightForEdgeDetect
        {
            get { return _ignoreRealHeightForEdgeDetect; }
            set { _ignoreRealHeightForEdgeDetect = value; }
        }

        private static double _edgeJudgeValue = 1.5F;

        public static double EdgeJudgeValue
        {
            get { return _edgeJudgeValue; }
            set { _edgeJudgeValue = value; }
        }

        public static void Save(XmlElement configElement)
        {
            XmlElement edgeDetectElement = configElement.OwnerDocument.CreateElement("", "EdgeDetect", "");
            configElement.AppendChild(edgeDetectElement);

            XmlHelper.SetValue(edgeDetectElement, "IgnoreLeftXOffsetForEdgeDetect", IgnoreLeftXOffsetForEdgeDetect.ToString());
            XmlHelper.SetValue(edgeDetectElement, "IgnoreRightXOffsetForEdgeDetect", IgnoreRightXOffsetForEdgeDetect.ToString());
            XmlHelper.SetValue(edgeDetectElement, "DistanceFromEdge", DistanceFromEdge.ToString());
            XmlHelper.SetValue(edgeDetectElement, "IgnoreRealHeightForEdgeDetect", IgnoreRealHeightForEdgeDetect.ToString());
            XmlHelper.SetValue(edgeDetectElement, "EdgeJudgeValue", EdgeJudgeValue.ToString());
        }

        public static void Load(XmlElement configElement)
        {
            XmlElement edgeDetectElement = configElement["EdgeDetect"];
            if (edgeDetectElement == null)
                return;

            IgnoreLeftXOffsetForEdgeDetect = Convert.ToInt32(XmlHelper.GetValue(edgeDetectElement, "IgnoreLeftXOffsetForEdgeDetect", IgnoreLeftXOffsetForEdgeDetect.ToString()));
            IgnoreRightXOffsetForEdgeDetect = Convert.ToInt32(XmlHelper.GetValue(edgeDetectElement, "IgnoreRightXOffsetForEdgeDetect", IgnoreRightXOffsetForEdgeDetect.ToString()));
            DistanceFromEdge = Convert.ToInt32(XmlHelper.GetValue(edgeDetectElement, "DistanceFromEdge", DistanceFromEdge.ToString()));
            IgnoreRealHeightForEdgeDetect = Convert.ToInt32(XmlHelper.GetValue(edgeDetectElement, "IgnoreRealHeightForEdgeDetect", IgnoreRealHeightForEdgeDetect.ToString()));
            EdgeJudgeValue = Convert.ToDouble(XmlHelper.GetValue(edgeDetectElement, "EdgeJudgeValue", EdgeJudgeValue.ToString()));
        }

        //bmp : Height가 1인 2차미분 이미지 
        public static unsafe int FindLeftForkIndex(Bitmap bmp)
        {
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            IntPtr ptrData = bmpData.Scan0;
            int stride = bmpData.Stride;
            byte* data = (byte*)(void*)ptrData;

            int ret = -1;
            bool searched = false;
            for (int w = 0; w < bmp.Width; w++)
            {
                int h = bmp.Height - 1;

                int index = h * stride + w;
                int value = Convert.ToInt32(data[index]);
                if (value >= 255)
                {
                    if(searched == false)
                    {
                        ret = w;
                        searched = true;
                    }
                }
            }
            bmp.UnlockBits(bmpData);

            return ret;
        }

        public static unsafe int FindRightForkIndex(Bitmap bmp)
        {
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            IntPtr ptrData = bmpData.Scan0;
            int stride = bmpData.Stride;
            byte* data = (byte*)(void*)ptrData;

            int ret = -1;
            bool searched = false;
            for (int w = bmp.Width - 1; w >= 0; w--)
            {
                int h = bmp.Height - 1;

                int index = h * stride + w;
                int value = Convert.ToInt32(data[index]);
                if (value >= 255)
                {
                    if (searched == false)
                    {
                        ret = w;
                        searched = true;
                    }
                }
            }


            bmp.UnlockBits(bmpData);

            return ret;
        }

        public static EdgeElement FindLeftEdgeIndex(Mat orgMat, int camNo, int subNo)
        {
            EdgeElement element = new EdgeElement();

            if (orgMat.Depth() != (int)ImreadModes.GrayScale)
                OpenCvSharp.Cv2.CvtColor(orgMat, orgMat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

            Rect cropRect = new Rect(EdgeDetect.IgnoreLeftXOffsetForEdgeDetect, 0, orgMat.Width - EdgeDetect.IgnoreLeftXOffsetForEdgeDetect, orgMat.Height);
            Mat cropMat = orgMat.Clone(cropRect);

            Rect[] roi = new Rect[3]; // 찾을 세곳의 roi
            int[] val = new int[3];

            roi[0] = new Rect(0, 0, cropMat.Width, EdgeDetect.DistanceFromEdge * 2);
            roi[1] = new Rect(0, cropMat.Height / 2 - EdgeDetect.DistanceFromEdge, cropMat.Width, EdgeDetect.DistanceFromEdge * 2);
            roi[2] = new Rect(0, cropMat.Height - EdgeDetect.DistanceFromEdge * 2, cropMat.Width, EdgeDetect.DistanceFromEdge * 2);

            for (int i = 0; i < 3; i++)
            {
                Mat roiImage = new Mat(cropMat, roi[i]);
                val[i] = FindEdgeIndex(eEdgeType.Left, roiImage);
                roiImage.Dispose();
            }

            //int max = MathHelper.GetMaxVal(val);
            int min = MathHelper.GetMinVal(val);

            //if (max != 0 && min != 0)
            if (min != 0)
            {
                element.Type = eEdgeType.Left;
                element.Index = min + EdgeDetect.IgnoreLeftXOffsetForEdgeDetect;
                element.CamNo = camNo;
                element.SubNo = subNo;

                EdgeHelper.SetAIRoi(ref element, orgMat.Width, orgMat.Height, EdgeDetect.DistanceFromEdge);
            }

            cropMat.Dispose();

            return element;
        }

        public static EdgeElement FindTopEdgeIndex(Mat orgMat, int camNo, int subNo, bool isIgnorePixel)
        {
            EdgeElement element = new EdgeElement();

            if (orgMat.Depth() != (int)ImreadModes.GrayScale)
                OpenCvSharp.Cv2.CvtColor(orgMat, orgMat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

            Rect[] roi = new Rect[3]; // 찾을 세곳의 roi
            int[] val = new int[3];

            roi[0] = new Rect(0, 0, EdgeDetect.DistanceFromEdge * 2, orgMat.Height);
            roi[1] = new Rect(orgMat.Width / 2 - EdgeDetect.DistanceFromEdge, 0, EdgeDetect.DistanceFromEdge * 2, orgMat.Height);
            roi[2] = new Rect(orgMat.Width - EdgeDetect.DistanceFromEdge * 2, 0, EdgeDetect.DistanceFromEdge * 2, orgMat.Height);

            for (int i = 0; i < 3; i++)
            {
                Mat roiImage = new Mat(orgMat, roi[i]);
                val[i] = FindEdgeIndex(eEdgeType.Top, roiImage);
                roiImage.Dispose();
            }

            int max = MathHelper.GetMaxVal(val);
            int min = MathHelper.GetMinVal(val);

            if (max != 0 && min != 0)
            //if (min != 0)
            {
                element.Type = eEdgeType.Top;
                element.CamNo = camNo;
                element.SubNo = subNo;
                element.Index = min;
                EdgeHelper.SetAIRoi(ref element, orgMat.Width, orgMat.Height, EdgeDetect.DistanceFromEdge);

                if (isIgnorePixel == true)
                {
                    if (element.CropRealPoint.Y <= EdgeDetect.IgnoreRealHeightForEdgeDetect && element.CropRealPoint.Y > 0)
                    {
                        element = new EdgeElement(); // 조명이 늦게 켜질 경우 0 번 SubImage 상단이 검정색 배경으로 나온다.
                    }
                }
            }
            return element;
        }

        public static EdgeElement FindBottomEdgeIndex(Mat orgMat, int camNo, int subNo)
        {
            EdgeElement element = new EdgeElement();

            if (orgMat.Depth() != (int)ImreadModes.GrayScale)
                OpenCvSharp.Cv2.CvtColor(orgMat, orgMat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

            Rect[] roi = new Rect[3]; // 찾을 세곳의 roi
            int[] val = new int[3];

            val = new int[3];

            roi[0] = new Rect(0, 0, EdgeDetect.DistanceFromEdge * 2, orgMat.Height);
            roi[1] = new Rect(orgMat.Width / 2 - EdgeDetect.DistanceFromEdge, 0, EdgeDetect.DistanceFromEdge * 2, orgMat.Height);
            roi[2] = new Rect(orgMat.Width - EdgeDetect.DistanceFromEdge * 2, 0, EdgeDetect.DistanceFromEdge * 2, orgMat.Height);

            for (int i = 0; i < 3; i++)
            {
                Mat roiImage = new Mat(orgMat, roi[i]);
                val[i] = FindEdgeIndex(eEdgeType.Bottom, roiImage);
                roiImage.Dispose();
            }

            int max = MathHelper.GetMaxVal(val);
            int min = MathHelper.GetMinVal(val);

            if (max != 0 || min != 0)
            {
                element.Type = eEdgeType.Bottom;
                element.CamNo = camNo;
                element.SubNo = subNo;
                element.Index = max;
                EdgeHelper.SetAIRoi(ref element, orgMat.Width, orgMat.Height, EdgeDetect.DistanceFromEdge);
            }

            return element;
        }

        public static EdgeElement FindRightEdgeIndex(Mat orgMat, int camNo, int subNo)
        {
            EdgeElement element = new EdgeElement();

            if (orgMat.Depth() != (int)ImreadModes.GrayScale)
                OpenCvSharp.Cv2.CvtColor(orgMat, orgMat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

            Rect cropRect = new Rect(0, 0, orgMat.Width - EdgeDetect.IgnoreRightXOffsetForEdgeDetect, orgMat.Height);
            Mat cropMat = orgMat.Clone(cropRect);

            Rect[] roi = new Rect[3]; // 찾을 세곳의 roi
            int[] val = new int[3];

            roi[0] = new Rect(0, 0, cropMat.Width, EdgeDetect.DistanceFromEdge * 2);
            roi[1] = new Rect(0, cropMat.Height / 2 - EdgeDetect.DistanceFromEdge, cropMat.Width, EdgeDetect.DistanceFromEdge * 2);
            roi[2] = new Rect(0, cropMat.Height - EdgeDetect.DistanceFromEdge * 2, cropMat.Width, EdgeDetect.DistanceFromEdge * 2);

            for (int i = 0; i < 3; i++)
            {
                Mat roiImage = new Mat(cropMat, roi[i]);
                val[i] = FindEdgeIndex(eEdgeType.Right, roiImage);
                roiImage.Dispose();
            }

            int max = MathHelper.GetMaxVal(val);
            //int min = MathHelper.GetMinVal(val);

            if (max != 0)// && min != 0)
            {
                element.Type = eEdgeType.Right;
                element.CamNo = camNo;
                element.SubNo = subNo;
                element.Index = max;
                EdgeHelper.SetAIRoi(ref element, orgMat.Width, orgMat.Height, EdgeDetect.DistanceFromEdge);
            }

            cropMat.Dispose();

            return element;
        }

        public static int FindEdgeIndex(eEdgeType type, Mat mat)
        {
            int index = -1;
            switch (type)
            {
                case eEdgeType.Left:
                    index = FindVerticalEdge(eEdgeType.Left, mat, EdgeDetect.EdgeJudgeValue);
                    break;

                case eEdgeType.Right:
                    index = FindVerticalEdge(eEdgeType.Right, mat, EdgeDetect.EdgeJudgeValue);
                    break;

                case eEdgeType.Top:
                    index = FindHorizontalEdge(eEdgeType.Top, mat, EdgeDetect.EdgeJudgeValue);
                    break;

                case eEdgeType.Bottom:
                    index = FindHorizontalEdge(eEdgeType.Bottom, mat, EdgeDetect.EdgeJudgeValue);
                    break;

                case eEdgeType.None:
                default:
                    break;
            }
            return index;
        }

        private static int FindVerticalEdge(eEdgeType type, Mat mat, double edgeJudgeValue)
        {
            if (mat == null)
                return -1;

            if (mat.Width <= 0 || mat.Height <= 0)
                return -1;

            // 가우시안블러
            Mat gaussianBlurMat = new Mat();
            Cv2.GaussianBlur(mat, gaussianBlurMat, new OpenCvSharp.Size(5, 1), 0, 0, BorderTypes.Reflect101);

            // 세로 평균값 구하기
            Mat columnMeanMat = new Mat();
            Cv2.Reduce(gaussianBlurMat, columnMeanMat, ReduceDimension.Row, ReduceTypes.Avg, MatType.CV_32FC1);

            // 평균값 구한 columnMeanMat 을 float[] 형으로 변환
            float[] columnAvgArray = new float[columnMeanMat.Total() * columnMeanMat.Channels()]; // mat의 width
            columnMeanMat.GetArray(0, 0, columnAvgArray);

            //float[] columnAvgArray;
            //columnMeanMat.GetArray(out columnAvgArray);

            // 1차 미분
            float[] OneDerivativeArray = Derivative(columnAvgArray);
            // 2차 미분
            float[] twoDerivativeArray = Derivative(OneDerivativeArray);

            // Edge 검색
            int edgeIndex = 0;
            if (type == eEdgeType.Right)
            {
                int idx = SearchEdgeIndex_Right(twoDerivativeArray, edgeJudgeValue, eDerivative.Two);
                edgeIndex = idx;
            }
            if (type == eEdgeType.Left)
            {
                int idx = SearchEdgeIndex_Left(twoDerivativeArray, edgeJudgeValue, eDerivative.Two);
                edgeIndex = idx;
            }

            gaussianBlurMat.Dispose();
            columnMeanMat.Dispose();

            return edgeIndex;
        }

        private static int FindHorizontalEdge(eEdgeType type, Mat mat, double edgeJudgeValue)
        {
            if (mat == null)
                return -1;

            if (mat.Width <= 0 || mat.Height <= 0)
                return -1;

            // 가우시안블러
            Mat gaussianBlurMat = new Mat();
            Cv2.GaussianBlur(mat, gaussianBlurMat, new OpenCvSharp.Size(1, 5), 0, 0, BorderTypes.Reflect101);

            // 세로 평균값 구하기
            Mat rowMeanMat = new Mat();
            Cv2.Reduce(gaussianBlurMat, rowMeanMat, ReduceDimension.Column, ReduceTypes.Avg, MatType.CV_32FC1);

            // 평균값 구한 columnMeanMat 을 float[] 형으로 변환
            float[] rowAvgArray = new float[rowMeanMat.Total() * rowMeanMat.Channels()]; // mat의 width
            rowMeanMat.GetArray(0, 0, rowAvgArray);

            //float[] rowAvgArray;
            //rowMeanMat.GetArray(out rowAvgArray);

            // 1차 미분
            float[] OneDerivativeArray = Derivative(rowAvgArray);
            // 2차 미분
            float[] twoDerivativeArray = Derivative(OneDerivativeArray);

            // Edge 검색
            int edgeIndex = 0;
            if (type == eEdgeType.Top)
                edgeIndex = SearchEdgeIndex_Top(twoDerivativeArray, edgeJudgeValue, eDerivative.Two);
            if (type == eEdgeType.Bottom)
                edgeIndex = SearchEdgeIndex_Bottom(twoDerivativeArray, edgeJudgeValue, eDerivative.Two);

            gaussianBlurMat.Dispose();
            rowMeanMat.Dispose();

            return edgeIndex;
        }

        public static float[] Derivative(float[] array)
        {
            int nSize = array.Count() - 1;
            float[] derivativeArray = new float[nSize];

            for (int i = 0; i < nSize; i++)
            {
                derivativeArray[i] = array[i + 1] - array[i];
            }
            return derivativeArray;
        }

        private static int SearchEdgeIndex_Right(float[] array, double jugmentValue, eDerivative type)
        {
            int startIndex = -1, endIndex = -1;

            for (int i = array.Count() - 1; i > 0; i--)
            {
                if (array[i] < -jugmentValue)
                {
                    endIndex = i;
                    break;
                }
            }

            if (endIndex != -1)
            {
                for (int i = endIndex; i > 0; i--)
                {
                    if (array[i] > jugmentValue)
                    {
                        startIndex = i;
                        break;
                    }
                }
            }

            if (startIndex != -1 && endIndex != -1)
            {
                switch (type)
                {
                    case eDerivative.One:
                        startIndex -= 1;
                        endIndex -= 1;
                        break;

                    case eDerivative.Two:
                        startIndex -= 2;
                        endIndex -= 2;
                        break;

                    case eDerivative.None:
                        break;

                    default:
                        break;
                }
            }
            return endIndex < 0 ? 0 : endIndex;
        }

        private static int SearchEdgeIndex_Left(float[] array, double jugmentValue, eDerivative type)
        {
            int startIndex = -1, endIndex = -1;

            for (int i = 0; i < array.Count(); i++)
            {
                if (array[i] < -jugmentValue)
                {
                    startIndex = i;
                    break;
                }
            }

            if (startIndex != -1)
            {
                for (int i = startIndex; i < array.Count(); i++)
                {
                    if (array[i] > jugmentValue)
                    {
                        endIndex = i;
                        break;
                    }
                }
            }

            if (startIndex != -1 && endIndex != -1)
            {
                switch (type)
                {
                    case eDerivative.One:
                        startIndex += 1;
                        endIndex += 1;
                        break;

                    case eDerivative.Two:
                        startIndex += 2;
                        endIndex += 2;
                        break;

                    case eDerivative.None:
                        break;

                    default:
                        break;
                }
            }
            return startIndex < 0 ? 0 : startIndex;
        }

        private static int SearchEdgeIndex_Top(float[] array, double jugmentValue, eDerivative type)
        {
            int startIndex = -1, endIndex = -3;

            for (int i = 0; i < array.Count(); i++)
            {
                if (array[i] < -jugmentValue)
                {
                    startIndex = i;
                    break;
                }
            }

            if (startIndex != -1)
            {
                for (int i = startIndex; i < array.Count(); i++)
                {
                    if (array[i] > jugmentValue)
                    {
                        endIndex = i;
                        break;
                    }
                }
            }

            if (startIndex != -1 && endIndex != -1)
            {
                switch (type)
                {
                    case eDerivative.One:
                        startIndex += 1;
                        endIndex += 1;
                        break;

                    case eDerivative.Two:
                        startIndex += 2;
                        endIndex += 2;
                        break;

                    case eDerivative.None:
                        break;

                    default:
                        break;
                }
            }
            return startIndex < 0 ? 0 : startIndex;
        }

        private static int SearchEdgeIndex_Bottom(float[] array, double jugmentValue, eDerivative type)
        {
            int startIndex = -1, endIndex = -1;

            for (int i = array.Count() - 1; i > 0; i--)
            {
                if (array[i] < -jugmentValue)
                {
                    endIndex = i;
                    break;
                }
            }

            startIndex = endIndex -= 2;

            int edgePos = endIndex;

            return edgePos < 0 ? 0 : edgePos;
        }
    }
}