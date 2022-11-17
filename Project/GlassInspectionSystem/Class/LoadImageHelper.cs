using Device.Edge;
using HMechLogLib;
using OpenCvSharp;
using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GlassInspectionSystem.Class
{
    public class LoadImageHelper
    {
        private List<EdgeElement> _edgeElementList = new List<EdgeElement>();
        
        public void LoadSearchEdge(Mat mat, int camNo, int subNo, int camCount, Queue<EdgeElement> leftRightEdgeList)
        {
           
            if (camNo == 0) // Top,Left,Bottom
            {
                EdgeElement leftElement = EdgeDetect.FindLeftEdgeIndex(mat, camNo, subNo);
                EdgeElement topElement = EdgeDetect.FindTopEdgeIndex(mat, camNo, subNo, true);
                EdgeElement bottomElement = EdgeDetect.FindBottomEdgeIndex(mat, camNo, subNo);

                if (leftElement.Index != -1)
                {
                   // if(leftElement.Index >= (mat.Width / 2))
                    //    return;

                    _edgeElementList.Add(leftElement);
                    leftRightEdgeList.Enqueue(leftElement.Copy());
                }


                if (topElement.Index != -1)
                {
                    _edgeElementList.Add(topElement);
                }

                if (bottomElement.Index != -1)
                    _edgeElementList.Add(bottomElement);
            }
            else if (camNo == (camCount - 1))// Top, Right, Bottom
            {
                EdgeElement rightElement = EdgeDetect.FindRightEdgeIndex(mat, camNo, subNo);
                EdgeElement topElement = EdgeDetect.FindTopEdgeIndex(mat, camNo, subNo, true);
                EdgeElement bottomElement = EdgeDetect.FindBottomEdgeIndex(mat, camNo, subNo);

                if (rightElement.Index != -1)
                {
                    //if (rightElement.Index <= (mat.Width / 2))
                       // return;

                    _edgeElementList.Add(rightElement);
                    leftRightEdgeList.Enqueue(rightElement.Copy());
                }

                if (topElement.Index != -1)
                    _edgeElementList.Add(topElement);

                if (bottomElement.Index != -1)
                    _edgeElementList.Add(bottomElement);
            }
            else // Top, Bottom
            {
                EdgeElement topElement = EdgeDetect.FindTopEdgeIndex(mat, camNo, subNo, true);
                EdgeElement bottomElement = EdgeDetect.FindBottomEdgeIndex(mat, camNo, subNo);

                if (topElement.Index != -1)
                    _edgeElementList.Add(topElement);

                if (bottomElement.Index != -1)
                    _edgeElementList.Add(bottomElement);
            }
        }

        public List<EdgeElement> GetFinallyEdge(int maxCamCount)
        {
            try
            {
                List<EdgeElement> list = new List<EdgeElement>();

                EdgeElement TopElement = new EdgeElement();
                TopElement.Type = eEdgeType.Top;
                TopElement.CropRealPoint = new System.Drawing.Point(0, 99999);

                EdgeElement BottomElement = new EdgeElement();
                BottomElement.Type = eEdgeType.Bottom;
                BottomElement.CropRealPoint = new System.Drawing.Point(0, 0);

                bool isTopElement = false;
                bool isBottomElement = false;
                int leftOrder = 1;
                int rightOrder = 1;

                foreach (EdgeElement element in _edgeElementList)
                {
                    if (element.Type == eEdgeType.Top)
                    {
                        if (element.CropRealPoint.Y < TopElement.CropRealPoint.Y)
                        {
                            isTopElement = true;
                            TopElement = element.Copy();
                        }
                    }
                    //Bottom 모든 Cam에 대한 Bottom Data
                    if (element.Type == eEdgeType.Bottom)
                    {
                        if (element.CropRealPoint.Y > BottomElement.CropRealPoint.Y)
                        {
                            isBottomElement = true;
                            BottomElement = element.Copy();
                        }
                    }

                    //Left Frist Cam번에 대한 Left Data
                    if (element.CamNo == 0 && element.Type == eEdgeType.Left)
                    {
                        list.Add(element.Copy());
                        leftOrder++;
                    }
                    //Right Last Cam번에 대한 Right Data
                    if (element.CamNo == maxCamCount - 1 && element.Type == eEdgeType.Right)
                    {
                        list.Add(element.Copy());
                        rightOrder++;
                    }
                }
                if (isTopElement)
                    list.Add(TopElement.Copy());
                if (isBottomElement)
                    list.Add(BottomElement.Copy());

                return list;
            }
            catch (Exception err)
            {
                Logger.WriteException(eLogType.ERROR, err);
                return null;
            }
        }

        public Bitmap GetMergeImage(List<Bitmap> subImageList, int mergeCount)
        {
            try
            {
                if (subImageList.Count <= 0)
                    return null;

                Bitmap mergeImage = new Bitmap(subImageList[0].Width, subImageList[0].Height * mergeCount, PixelFormat.Format8bppIndexed);

                Console.WriteLine(subImageList[0].Width.ToString() + "  " + (subImageList[0].Height * mergeCount).ToString());

                ColorPalette paletee = mergeImage.Palette;

                Color[] _entries = paletee.Entries;
                for (int i = 0; i < 256; i++)
                {
                    Color b = new Color();
                    b = Color.FromArgb((byte)i, (byte)i, (byte)i);
                    _entries[i] = b;
                }
                mergeImage.Palette = paletee;
                for (int i = 0; i < mergeCount; i++)
                {
                    AddImageInMerge(ref mergeImage, subImageList[i], i);
                }
            
                return (Bitmap)mergeImage.Clone();
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                return null;
            }
        }

        private void AddImageInMerge(ref Bitmap targetBmp, Bitmap sourceBmp, int subNo)
        {
            try
            {
                unsafe
                {
                    BitmapData subBmpData = sourceBmp.LockBits(new Rectangle(0, 0, sourceBmp.Width, sourceBmp.Height), ImageLockMode.ReadWrite, sourceBmp.PixelFormat);
                    byte* subData = (byte*)(void*)subBmpData.Scan0;

                    UInt64 startIndex = (UInt64)(subBmpData.Stride * sourceBmp.Height) * (UInt64)subNo;
                    UInt64 length = (UInt64)(subBmpData.Stride * sourceBmp.Height);

                    BitmapData targetBmpData = targetBmp.LockBits(new Rectangle(0, 0, targetBmp.Width, targetBmp.Height), ImageLockMode.ReadWrite, targetBmp.PixelFormat);
                    byte* targetData = (byte*)(void*)targetBmpData.Scan0 + startIndex;

                    UInt64 mergeLength = (UInt64)(targetBmpData.Stride * targetBmp.Height);

                    Buffer.MemoryCopy(subData, targetData, mergeLength, length);

                    sourceBmp.UnlockBits(subBmpData);
                    targetBmp.UnlockBits(targetBmpData);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        public void MoveImage(ref Bitmap bmp,int nowIndex, int teachingIndex)
        {
            try
            {
                unsafe
                {
                    int moveIndex = teachingIndex - nowIndex;
                    if(moveIndex >= 0)
                    {
                        BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                        IntPtr ptr = bmpData.Scan0;
                        byte* data = (byte*)ptr;
                        int stride = bmpData.Stride;
                        UInt64 length = (UInt64)(bmpData.Stride * bmp.Height);

                        byte[] orgArray = new byte[length];
                        IntPtr newPtr = new IntPtr(ptr.ToInt64() + (Int64)(moveIndex * stride));

                        UInt64 newLength = length - (UInt64)(moveIndex * stride);

                        Buffer.MemoryCopy(ptr.ToPointer(), newPtr.ToPointer(), length, newLength);

                        bmp.UnlockBits(bmpData);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }
    }
}
