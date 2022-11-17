using MechAI.Model;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;
using AI;

namespace MechAI
{
    public class MECHAIForHanmech : IDisposable
    {
        // Yolo2
        //private const string MechLibraryGPU = @"..\Dll\AIFrameWork\Darknet_Yolo2_Cuda9.2\darknet-yolo2-cuda92-opencv340.dll";
        // Yolo4
        private const string MechLibraryGPU = @"\darknet_cuda11.1_opencv4.5.1.dll";

        public const int MaxObjects = 1000;
 
        #region DllImport GPU
        [DllImport(MechLibraryGPU, EntryPoint = "init")]
        private static extern int Initialize_GPU(string configurationFilename, string weightsFilename, int gpu);

        [DllImport(MechLibraryGPU, EntryPoint = "detect_image")]
        private static extern int DetectImage_GPU(string filename, ref BboxContainer container);

        [DllImport(MechLibraryGPU, EntryPoint = "detect_mat")]
        private static extern int DetectImage_GPU(IntPtr pArray, int nSize, ref BboxContainer container);

        [DllImport(MechLibraryGPU, EntryPoint = "dispose")]
        public static extern int Dispos_GPU();
        #endregion

        public MECHAIForHanmech(string configurationFileName, string weightsFileName)
        {
            Initialize(configurationFileName, weightsFileName);
        }

        public int Initialize(string configurationFileName, string weightsFileName)
        {
            return Initialize_GPU(configurationFileName, weightsFileName, 0);
        }

        private int DetectImage(string filename, ref BboxContainer container)
        {
            return DetectImage_GPU(filename, ref container);
        }

        private int DetectImage(IntPtr pArray, int nSize, ref BboxContainer container)
        {
            return DetectImage_GPU(pArray, nSize, ref container);
        }

        private int Dispos()
        {
            return Dispos_GPU();
        }

        public List<MechItem> Process(byte[] imageData)
        {
            try
            {
                var container = new BboxContainer();
                var size = Marshal.SizeOf(imageData[0]) * imageData.Length;
                var pnt = Marshal.AllocHGlobal(size);

                Marshal.Copy(imageData, 0, pnt, imageData.Length);
                var count = DetectImage(pnt, imageData.Length, ref container);

                Marshal.FreeHGlobal(pnt);

                return Convert(container);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                return new List<MechItem>();
            }
        }

        private List<MechItem> Convert(BboxContainer container)
        {
            var mechItem = new List<MechItem>();
            foreach (var item in container.candidates.Where(o => o.h > 0 || o.w > 0))
            {
                var Item = new MechItem() { X = (int)item.x, Y = (int)item.y, Height = (int)item.h, Width = (int)item.w, Confidence = item.prob, Type = (int)item.obj_id };
                if ((int)item.w < 0 || (int)item.h < 0 || (int)item.x < 0 || (int)item.y < 0)
                    continue;
                mechItem.Add(Item);
            }
            return mechItem;
        }

        public void Terminate()
        {
            Dispos();
        }

        public void Dispose()
        {
            Terminate();
        }
    }
}