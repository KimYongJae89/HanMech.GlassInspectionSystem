using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm.Utility
{
    public static class HanMechImageHelper
    {
        public static Bitmap Create8BitGreyBitmap(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            ColorPalette paletee = bmp.Palette;
            Color[] _entries = paletee.Entries;
            for (int i = 0; i < 256; i++)
            {
                Color b = new Color();
                b = Color.FromArgb((byte)i, (byte)i, (byte)i);
                _entries[i] = b;
            }
            bmp.Palette = paletee;

            return bmp;
        }
        
        public static void DrawPointList(ref Bitmap bmp, List<System.Drawing.Point> pointList, int value)
        {
            unsafe
            {
                BitmapData newBmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = newBmpData.Scan0;
                int stride = newBmpData.Stride;
                byte* data = (byte*)(void*)ptrData;

                foreach (System.Drawing.Point point in pointList)
                {
                    int index = point.Y * stride + point.X;
                    data[index] = Convert.ToByte(value);
                }
                bmp.UnlockBits(newBmpData);
            }
        }

        public static Mat DirectionEnhancement(Bitmap bmp, eDirection direction)
        {
            Mat mat = BitmapConverter.ToMat(bmp);
            Mat kern;
            if (direction == eDirection.Horizon)
            {
                kern = new Mat(3, 3, MatType.CV_32F, Kernel.VerticalEdge);
            }
            else
            {
                kern = new Mat(3, 3, MatType.CV_32F, Kernel.HorizonEdge);
            }

            return mat;
        }

        public static float[] GetAvgArray(float[] array, int avergeCount)
        {
            try
            {
                float[] avgArray = null;
                // 일단 avergeCount 가 4의 배수라고 생각
                if (array.Count() % avergeCount != 0)
                {
                    int orgCount = array.Count();
                    for (int i = array.Count(); i >= 0; i--)
                    {
                        if(orgCount % avergeCount != 0)
                        {
                            orgCount--;
                        }
                        else
                        {
                            break;
                        }
                    }
                    avgArray = new float[(int)(orgCount / avergeCount)];
                }
                else
                {
                    avgArray = new float[(int)(array.Count() / avergeCount)];

                }
                int index = 0;
                for (int i = 0; i < array.Count(); i += avergeCount)
                {
                    if (avgArray.Count() <= index)
                    {
                        return avgArray;
                    }

                    float avgSum = 0;
                        
                    for (int j = 0; j < avergeCount; j++)
                    {
                        int valueIndex = (i + j);
                        avgSum += array[i + j];
                    }
                    
                    avgArray[index] = avgSum / avergeCount;
                    index++;
                }

                return avgArray;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                return null;
            }
        }

        public static Bitmap ProcessTwoDerivative(Bitmap bmp, eDirection direction, int referenceValue)
        {
            try
            {
                if (bmp == null)
                    return null;

                Bitmap newBitmap = null;
                Mat mat = BitmapConverter.ToMat(bmp);
                Cv2.GaussianBlur(mat, mat, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Reflect101);

                if (mat.Channels() != 1)
                    Cv2.CvtColor(mat, mat, ColorConversionCodes.BGR2GRAY);

                Bitmap blurBmp = BitmapConverter.ToBitmap(mat);
        
                if (direction == eDirection.Vertical) // 세로
                {
                    List<System.Drawing.Point> drawPoints = GetVerticalPointList(blurBmp, referenceValue);

                    newBitmap = HanMechImageHelper.Create8BitGreyBitmap(blurBmp.Width, blurBmp.Height);
                    HanMechImageHelper.DrawPointList(ref newBitmap, drawPoints, 255);
              
                    return newBitmap;
                }
                else if (direction == eDirection.Horizon) // 세로
                {
                    blurBmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    List<System.Drawing.Point> drawPoints = GetVerticalPointList(blurBmp, referenceValue);

                    newBitmap = HanMechImageHelper.Create8BitGreyBitmap(blurBmp.Width, blurBmp.Height);
                    HanMechImageHelper.DrawPointList(ref newBitmap, drawPoints, 255);

                    newBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    return newBitmap;
                }
                else if (direction == eDirection.All) // 가로, 세로
                {
                    List<System.Drawing.Point> drawPoints = GetVerticalPointList(blurBmp, referenceValue);

                    newBitmap = HanMechImageHelper.Create8BitGreyBitmap(blurBmp.Width, blurBmp.Height);
                    HanMechImageHelper.DrawPointList(ref newBitmap, drawPoints, 255);

                    blurBmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    newBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    drawPoints.Clear();

                    drawPoints = GetVerticalPointList(blurBmp, referenceValue);

                    HanMechImageHelper.DrawPointList(ref newBitmap, drawPoints, 255);

                    newBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    return newBitmap;
                }
                else
                { }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<System.Drawing.Point> GetHorizonPointList(Bitmap bmp, int referenceValue)
        {
            List<System.Drawing.Point> pointList = new List<System.Drawing.Point>();

            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = bmpData.Scan0;
                int stride = bmpData.Stride;
                byte* data = (byte*)(void*)ptrData;

                for (int w = 0; w < bmp.Width; w++)
                {
                    byte[] array = new byte[bmp.Height];

                    for (int h = 0; h < bmp.Height; h++)
                    {
                        int index = w + (h * stride);
                        array[h] = data[index];
                    }

                    float[] OneDerivativeArray = HanMechMathHelper.Derivative(array); // 1차 미분
                    float[] twoDerivativeArray = HanMechMathHelper.Derivative(OneDerivativeArray); // 2차 미분

                    for (int i = 0; i < twoDerivativeArray.Count(); i++)
                    {
                        if (Math.Abs(twoDerivativeArray[i]) >= referenceValue)
                        {
                            System.Drawing.Point pt = new System.Drawing.Point();
                            pt.X = w; // +2는 2차 미분해서
                            pt.Y = i;
                            pointList.Add(pt);
                        }
                    }
                }
                bmp.UnlockBits(bmpData);
            }

            return pointList;
        }

        public static List<System.Drawing.Point> GetVerticalPointList(Bitmap bmp, int referenceValue)
        {
            List<System.Drawing.Point> pointList = new List<System.Drawing.Point>();

            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = bmpData.Scan0;
                int stride = bmpData.Stride;
                byte* data = (byte*)(void*)ptrData;

                for (int h = 0; h < bmp.Height; h++)
                {
                    int index = h * stride;
                    byte[] array = new byte[bmp.Width];
                    Marshal.Copy(ptrData, array, 0, bmp.Width);

                    float[] OneDerivativeArray = HanMechMathHelper.Derivative(array); // 1차 미분
                    float[] twoDerivativeArray = HanMechMathHelper.Derivative(OneDerivativeArray); // 2차 미분

                    for (int i = 0; i < twoDerivativeArray.Count(); i++)
                    {
                        if (Math.Abs(twoDerivativeArray[i]) >= referenceValue)
                        {
                            System.Drawing.Point pt = new System.Drawing.Point();
                            pt.X = i + 2; // +2는 2차 미분해서
                            pt.Y = h;
                            pointList.Add(pt);
                        }
                    }
                    ptrData += stride;
                }
                bmp.UnlockBits(bmpData);
            }

            return pointList;
        }

        public static Bitmap ProcessCanny(Bitmap bmp, double threshold1, double threshold2)
        {
            Mat mat = BitmapConverter.ToMat(bmp);

            if (mat.Channels() != 1)
            {
                Cv2.CvtColor(mat, mat, OpenCvSharp.ColorConversionCodes.BGR2GRAY);
            }

            Cv2.Canny(mat, mat, threshold1, threshold2);

            Bitmap cannyBmp = BitmapConverter.ToBitmap(mat);
            mat.Dispose();

            return cannyBmp;
        }
    }
}
