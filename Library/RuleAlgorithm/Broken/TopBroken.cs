﻿using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm.Broken
{
    public class TopBroken : BrokenDetection
    {
        public override float[] LineTracking(Bitmap bmp)
        {
            float[] startYEdgeArray;

            if (bmp.Size.Width <= 0 || bmp.Size.Height <= 0)
                return null;

            startYEdgeArray = new float[bmp.Width];

            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = bmpData.Scan0;
                int stride = bmpData.Stride;
                byte* data = (byte*)(void*)ptrData;

                for (int w = 0; w < bmp.Width; w++)
                {
                    for (int h = 0; h < bmp.Height; h++)
                    {
                        int index = h * stride + w;
                        int value = Convert.ToInt32(data[index]);

                        if (value >= 255)
                        {
                            startYEdgeArray[w] = h;
                            break;
                        }
                    }
                }
                bmp.UnlockBits(bmpData);

                return startYEdgeArray;
            }
        }

        public override List<Rectangle> Run(float[] edgeIndexArray, double brokenVal, int avgCount, int imageWidth, int imageHeight)
        {
            try
            {
                if (edgeIndexArray == null)
                    return null;

                List<Rectangle> result = new List<Rectangle>();

                //AvgCnt = 4;
                //Y값이 튀는 Edge 검출
                float[] avgArray = HanMechImageHelper.GetAvgArray(edgeIndexArray, avgCount);

                float[] startXEdgeOneDerivativeArray = HanMechMathHelper.Derivative(avgArray);
                int defectStartIndex = -1;

                float min = 9999;
                for (int i = 0; i < edgeIndexArray.Count(); i++)
                {
                    if (min >= edgeIndexArray[i] && edgeIndexArray[i] != 0)
                        min = edgeIndexArray[i];
                }

                float prev = min;

                int cnt = 0;

                for (int i = 0; i < startXEdgeOneDerivativeArray.Count(); i++)
                {
                    if (brokenVal <= Math.Abs(startXEdgeOneDerivativeArray[i]))// && Math.Abs(startXEdgeOneDerivativeArray[i]) <= 10)
                    {
                        if (cnt == 0)
                        {
                            defectStartIndex = i * avgCount;
                            cnt++;
                        }
                    }

                    if (cnt != 0)
                    {
                        if (Math.Abs(startXEdgeOneDerivativeArray[i]) == 0)
                        {
                            if (defectStartIndex >= 0)
                            {
                                int startX = (int)defectStartIndex;
                                int startY = (int)edgeIndexArray[defectStartIndex];
                                int endX = (int)i * avgCount;
                                int endY = (int)edgeIndexArray[i * avgCount];

                                int minSize = 10;

                                if (startY <= 0)
                                    startY = (int)prev;

                                if (endY <= 0)
                                    endY = (int)prev;

                                int width = Math.Abs(endX - startX);
                                int height = Math.Abs(endY - startY);

                                if (width <= minSize)
                                    width = minSize;
                                if (height <= minSize)
                                    height = minSize;

                                Rectangle defect = new Rectangle(startX, startY, width, height);
                                result.Add(defect);

                                defectStartIndex = 0;
                                cnt = 0;
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                return null;
            }
        }
    }
}