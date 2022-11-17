using RuleAlgorithm.Utility;
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
    public class RightBroken : BrokenDetection
    {
        public override float[] LineTracking(Bitmap bmp)
        {
            float[] startXEdgeArray;

            startXEdgeArray = new float[bmp.Height];
            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = bmpData.Scan0;
                int stride = bmpData.Stride;
                byte* data = (byte*)(void*)ptrData;

                for (int h = 0; h < bmp.Height; h++)
                {
                    //for (int w = 0; w < bmp.Width; w++)   //--> Left
                    for (int w = bmp.Width - 1; w > 0; w--) //--> Right
                    {
                        int index = h * stride + w;
                        int value = Convert.ToInt32(data[index]);

                        if (value >= 255)
                        {
                            startXEdgeArray[h] = w;
                            break;
                        }
                    }
                }
                bmp.UnlockBits(bmpData);

                return startXEdgeArray;
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
                float[] avgArray = HanMechImageHelper.GetAvgArray(edgeIndexArray, avgCount);
                //X값이 튀는 Edge 검출
                float[] startXEdgeOneDerivativeArray = HanMechMathHelper.Derivative(avgArray);
                int defectStartIndex = -1;


                float max = -9999;

                for (int i = 0; i < edgeIndexArray.Count(); i++)
                {
                    if (max <= edgeIndexArray[i] && edgeIndexArray[i] != 0)
                        max = edgeIndexArray[i];
                }

                int cnt = 0;
                float prev = max;
                for (int i = 0; i < startXEdgeOneDerivativeArray.Count(); i++)
                {
                    if (brokenVal <= Math.Abs(startXEdgeOneDerivativeArray[i]))
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
                                int startX = (int)edgeIndexArray[defectStartIndex];
                                int startY = defectStartIndex;
                                int endX = (int)edgeIndexArray[i * avgCount];
                                int endY = (int)i * avgCount;

                                int minSize = 20;

                                if (startX <= 0)
                                    startX = (int)prev;

                                if (endX <= 0)
                                    endX = (int)prev;

                                int width = Math.Abs(endX - startX);
                                int height = Math.Abs(endY - startY);

                                if (width <= minSize)
                                    width = minSize;
                                if (height <= minSize)
                                    height = minSize;

                                if(startX >= (int)prev - minSize)
                                {

                                    Rectangle defect = new Rectangle(startX - width, startY, width, height);
                                    result.Add(defect);
                                }
                                else
                                {
                                    Rectangle defect = new Rectangle(startX, startY, width, height);
                                    result.Add(defect);
                                }

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