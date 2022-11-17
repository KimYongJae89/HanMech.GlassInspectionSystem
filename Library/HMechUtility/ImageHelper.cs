using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HMechUtility
{
    public static class ImageHelper
    {
        public static float[] GetAvgArray(float[] array, int avergeCount)
        {
            try
            {
                // 일단 avergeCount 가 4의 배수라고 생각
                if (array.Count() % avergeCount != 0)
                {

                }
                float[] avgArray = new float[(int)(array.Count() / avergeCount)];
                int index = 0;
                for (int i = 0; i < array.Count(); i += avergeCount)
                {
                    float avgSum = 0;
                    for (int j = 0; j < avergeCount; j++)
                    {
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

        public static byte[] Convert_Image(Image image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Bmp);
                return memoryStream.ToArray();
            }
        }

        public static byte[] ConvertGrey8BitImageToArray(Bitmap bmp)
        {
            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                int size = bmpData.Stride * bmpData.Height;
                byte[] array = new byte[size];
                int startIndex = 0;

                for (int i = 0; i < bmp.Height; i++)
                {
                    IntPtr targetData = bmpData.Scan0;
                    Marshal.Copy(targetData, array, startIndex, bmpData.Stride);

                    startIndex += bmpData.Stride;
                }
                bmp.UnlockBits(bmpData);
                return array;
            }
        }

        public static Bitmap ConvertToGrey8BitBitmap(byte[] buffer, int width, int hegiht)
        {
            Bitmap bmp = new Bitmap(width, hegiht, PixelFormat.Format8bppIndexed);
            ColorPalette paletee = bmp.Palette;

            Color[] _entries = paletee.Entries;
            for (int i = 0; i < 256; i++)
            {
                Color b = new Color();
                b = Color.FromArgb((byte)i, (byte)i, (byte)i);
                _entries[i] = b;
            }
            bmp.Palette = paletee;

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);

            bmp.UnlockBits(bmpData);

            return bmp;
        }

        public static UInt64 MergeImage(ref Bitmap destBmp, Bitmap sourceBmp, UInt64 startIndex)
        {
            UInt64 lastIndex = 0;
            unsafe
            {
                BitmapData destBmpData = destBmp.LockBits(new Rectangle(0, 0, destBmp.Width, destBmp.Height), ImageLockMode.ReadWrite, destBmp.PixelFormat);
                byte* destData = (byte*)(void*)destBmpData.Scan0 + startIndex;

                BitmapData souceBmpData = sourceBmp.LockBits(new Rectangle(0, 0, sourceBmp.Width, sourceBmp.Height), ImageLockMode.ReadWrite, sourceBmp.PixelFormat);
                byte* sourceData = (byte*)(void*)souceBmpData.Scan0;

                UInt64 destLength = (UInt64)(destBmpData.Stride * destBmp.Height);
                UInt64 sourceLength = (UInt64)(souceBmpData.Stride * sourceBmp.Height);

                Buffer.MemoryCopy(sourceData, destData, destLength, sourceLength);

                lastIndex = startIndex + sourceLength;

                destBmp.UnlockBits(destBmpData);
                sourceBmp.UnlockBits(souceBmpData);
            }
            return lastIndex;
        }
        /// <summary>
        /// 8비트 이미지에 Rectangle 그리기
        /// </summary>
        /// <param name="bmp">8비트 이미지</param>
        /// <param name="rect">Rectangle</param>
        /// <param name="lineWidth">Rectangle 두께</param>
        public static void DrawRectangle(ref Bitmap bmp, Rectangle rect, int lineWidth)
        {
            try
            {
                unsafe
                {
                    BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                    IntPtr ptrData = bmpData.Scan0;
                    int stride = bmpData.Stride;
                    byte* data = (byte*)(void*)ptrData;
                    int size = stride * bmp.Height;
                    Rectangle outSideRect = GetOutSideRect(rect, lineWidth);

                    for (int x = outSideRect.X; x < outSideRect.X + outSideRect.Width; x++)
                    {
                        if (x < bmp.Width)
                        {
                            for (int i = 0; i < lineWidth; i++)
                            {
                                int startWidthIndex = outSideRect.Y + (bmp.Width * stride);

                                int topYPos = outSideRect.Y;
                                int topIndex = x + (stride * (topYPos + i));
                                if (topIndex < size && topIndex >= 0)
                                    data[topIndex] = 0;

                                int bootmYPos = outSideRect.Y + outSideRect.Height - lineWidth;
                                int bottomIndex = x + (stride * (bootmYPos + i));
                                if (bottomIndex < size && bottomIndex >= 0)
                                    data[bottomIndex] = 0;
                            }
                        }
                    }

                    for (int y = outSideRect.Y; y < outSideRect.Y + outSideRect.Height; y++)
                    {
                        if (y < bmp.Height)
                        {
                            for (int i = 0; i < lineWidth; i++)
                            {
                                int leftXPos = outSideRect.X + i;
                                if (leftXPos < bmp.Width)
                                {
                                    int leftIndex = (stride * y) + leftXPos;
                                    if (leftIndex < size && leftIndex >= 0)
                                        data[leftIndex] = 0;
                                }
                                int rightXPos = outSideRect.X + outSideRect.Width - lineWidth + i;
                                if (rightXPos < bmp.Width)
                                {
                                    int rightIndex = (stride * y) + rightXPos;
                                    if (rightIndex < size && rightIndex >= 0)
                                        data[rightIndex] = 0;
                                }
                            }
                        }
                    }
                    bmp.UnlockBits(bmpData);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                throw;
            }
        }

        private static Rectangle GetOutSideRect(Rectangle rect, int lineWidth)
        {
            int interval = (lineWidth - 1) / 2;
            return new Rectangle(rect.X - interval, rect.Y - interval, rect.Width + (interval * 2), rect.Height + (interval * 2));
        }

        public static Bitmap MoveImage(Bitmap bmp, int nowIndex, int standardIndex)
        {
            try
            {
                Bitmap newBitmap = bmp.Clone() as Bitmap;
                unsafe
                {
                  
                    int moveIndex = standardIndex - nowIndex;
                    if (moveIndex >= 0)
                    {
                        BitmapData bmpData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.ReadWrite, newBitmap.PixelFormat);
                        IntPtr ptr = bmpData.Scan0;
                        byte* data = (byte*)ptr;
                        int stride = bmpData.Stride;

                        UInt64 length = (UInt64)(bmpData.Stride * newBitmap.Height);

                        byte[] orgArray = new byte[stride];

                        Marshal.Copy(ptr, orgArray, 0, stride);

                        
                        IntPtr newPtr = new IntPtr(ptr.ToInt64() + (Int64)(moveIndex * stride));

                        UInt64 newLength = length - (UInt64)(moveIndex * stride);

                        Buffer.MemoryCopy(ptr.ToPointer(), newPtr.ToPointer(), length, newLength);

                        if (moveIndex != 0)
                        {
                            for (int i = 0; i < moveIndex; i++)
                            {
                                IntPtr targetData = bmpData.Scan0;
                                Marshal.Copy(orgArray, 0, newPtr - (stride * i), stride);
                            }
                        }

                        newBitmap.UnlockBits(bmpData);
                    }
                    else
                    {
                        //BitmapData bmpData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.ReadWrite, newBitmap.PixelFormat);
                        //IntPtr ptr = bmpData.Scan0;
                        //byte* data = (byte*)ptr;
                        //int stride = bmpData.Stride;

                        //UInt64 length = (UInt64)(bmpData.Stride * newBitmap.Height);
                     
                        //byte[] orgArray = new byte[stride];
                        //int orgLength = bmpData.Stride * newBitmap.Height;

                        //for (int h = 0; h < stride; h++)
                        //{
                        //    int index = orgLength - stride + h;
                        //    orgArray[h] = data[index];
                        //}


                        //IntPtr newPtr = new IntPtr(ptr.ToInt64() + (Int64)(moveIndex * stride));

                        //UInt64 newLength = length + (UInt64)(moveIndex * stride);

                        //Buffer.MemoryCopy(ptr.ToPointer(), newPtr.ToPointer(), length, newLength);

                        //if (moveIndex != 0)
                        //{
                        //    for (int i = 0; i < Math.Abs(moveIndex); i++)
                        //    {
                        //        IntPtr targetData = bmpData.Scan0;
                        //        int index = (int)newLength - (stride * i);
                        //        Marshal.Copy(orgArray, 0, newPtr + index, stride);
                        //    }
                        //}

                        //newBitmap.UnlockBits(bmpData);
                    }
                }
                return newBitmap;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                return null;
            }
        }
    }
}
