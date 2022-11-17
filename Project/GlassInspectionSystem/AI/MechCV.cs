//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GlassInspectionSystem.AI
//{
//    public class MechCV
//    {
//        Net net = null;
//        string[] outLayers = null;
//        float threshold = 0.2f;
//        List<Mat> outs = new List<Mat>();


//        Names Names = new Names();
//        object objLock = new object();

//        public void Initialize(string cfgfile, string weightsfile)
//        {
//            string cfg = System.IO.Directory.GetCurrentDirectory() + @"\AI\Config\" + cfgfile;
//            string weights = System.IO.Directory.GetCurrentDirectory() + @"\AI\Weights\" + weightsfile;
//            if (!File.Exists(cfg) || !File.Exists(weights))
//                return;

//            net = Net.ReadNetFromDarknet(cfg, weights);
//            net.SetPreferableBackend(Net.Backend.CUDA);
//            net.SetPreferableTarget(Net.Target.CUDA);

//            string[] laylerNames = net.GetLayerNames();
//            int[] outIndex = net.GetUnconnectedOutLayers();

//            outLayers = new string[outIndex.Length];
//            for (int i = 0; i < outIndex.Length; i++)
//            {
//                outLayers[i] = laylerNames[outIndex[i] - 1];
//            }
//            ///Layer 갯수 만큼 OutPut 생성 By jsKim
//            for (int i = 0; i < outLayers.Length; i++)
//            {
//                Mat mat = new Mat();
//                outs.Add(mat);
//            }

//            InitImage();
//        }

//        private void InitImage()
//        {
//            Bitmap nullBmp = new Bitmap(4096, 1024);
//            Mat mat = BitmapConverter.ToMat(nullBmp);
//            this.Process(mat);
//            mat.Dispose();
//            nullBmp.Dispose();
//        }


//        public List<MechItem> Process(Mat mat)
//        {
//            lock (objLock)
//            {
//                Mat blob = CvDnn.BlobFromImage(mat, 1 / 255.0, new OpenCvSharp.Size(416, 416), new Scalar(), true, false);
//                //OpenCvSharp.Cv2.ImShow("blob image", blob);
//                net.SetInput(blob, "data");

//                List<Rect> boxes = new List<Rect>();
//                List<float> confidences = new List<float>();
//                List<int> classes = new List<int>();
//                List<MechItem> mechItems = new List<MechItem>();

//                net.Forward(outs, outLayers);

//                foreach (Mat outItem in outs)
//                {
//                    var w = mat.Width;
//                    var h = mat.Height;

//                    const int prefix = 5;   //skip 0~4


//                    unsafe
//                    {
//                        float* data = (float*)outItem.Data;
//                        for (int i = 0; i < outItem.Rows; ++i, data += outItem.Cols)
//                        {
//                            //get classes probability
//                            double minValue = 0;
//                            double maxValue = 0;
//                            Cv2.MinMaxLoc(outItem.Row(i).ColRange(prefix, outItem.Cols), out minValue, out maxValue, out _, out OpenCvSharp.Point max);
//                            var classe = max.X;

//                            //if (maxValue > threshold)
//                            //{
//                            //    var probability = outItem.At<float>(i, classes + prefix);

//                            if (maxValue > threshold) //more accuracy
//                            {
//                                //get center and width/height
//                                var centerX = outItem.At<float>(i, 0) * w;
//                                var centerY = outItem.At<float>(i, 1) * h;
//                                var width = outItem.At<float>(i, 2) * w;
//                                var height = outItem.At<float>(i, 3) * h;

//                                var x1 = (centerX - width / 2) < 0 ? 0 : centerX - width / 2; //avoid left side over edge
//                                var y1 = (centerY - height / 2) < 0 ? 0 : centerY - height / 2; //avoid top side over edge

//                                Rect rect = new Rect(Convert.ToInt32(x1), Convert.ToInt32(y1), Convert.ToInt32(width), Convert.ToInt32(height));
//                                boxes.Add(rect);
//                                confidences.Add((float)maxValue);
//                                classes.Add(max.X);
//                            }
//                        }
//                    }
//                }

//                int[] indexs = null;
//                float scoreTh = (float)0.0;
//                float nmsTh = (float)0.4;

//                ///비최대 억제 박싱(Non Maximum Suppress) -> 중복된 박스 제거, nmsThreshold : 두 박스간 교집합 / 두 박스간 합집합 => IOU 비율  By jsKim
//                CvDnn.NMSBoxes(boxes, confidences, scoreTh, nmsTh, out indexs);

//                for (int i = 0; i < indexs.Length; i++)
//                {
//                    MechItem itm = new MechItem(classes[indexs[i]], (float)confidences[indexs[i]], (int)boxes[indexs[i]].X, (int)boxes[indexs[i]].Y, (int)boxes[indexs[i]].Width, (int)boxes[indexs[i]].Height);
//                    mechItems.Add(itm);
//                }
//                return mechItems;
//            }
//        }
//    }
//}
