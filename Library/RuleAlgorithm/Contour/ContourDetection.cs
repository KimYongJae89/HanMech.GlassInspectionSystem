using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm.Contour
{
    public class ContourDetection
    {
        //public void FindContours(InputArray image, out OpenCvSharp.Point[][] contours, out HierarchyIndex[] hierarchy, RetrievalModes mode, ContourApproximationModes method, OpenCvSharp.Point? offset = null)
        //{
        //    if (image == null)
        //        throw new ArgumentNullException(nameof(image));
        //    image.ThrowIfDisposed();

        //    var offset0 = offset.GetValueOrDefault(new OpenCvSharp.Point());
        //    VectorOfVectorPoint contoursVec = new VectorOfVectorPoint();
        //    VectorOfVec4i hierarchyVec = new VectorOfVec4i();
        //    NativeMethods.imgproc_findContours1_vector(image.CvPtr, contoursVec.CvPtr, hierarchyVec.CvPtr, (int)mode, (int)method, offset0);
        //    //NativeMethods.HandleException(
        //    //    NativeMethods.imgproc_findContours1_vector(
        //    //        image.CvPtr, out contoursVec.CvPtr, out hierarchyVec.CvPtr, (int)mode, (int)method, offset0));

        //    contours = contoursVec.ToArray();
        //    var hierarchyOrg = hierarchyVec.ToArray();
        //    hierarchy = hierarchyOrg.Select(HierarchyIndex.FromVec4i).ToArray();

        //    GC.KeepAlive(image);
        //}

        public List<ContourData> Run(Bitmap bmp)
        {
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy = new HierarchyIndex[100];

            Mat mat = BitmapConverter.ToMat(bmp);

            //Mat<OpenCvSharp.Point>[]  contours123 = Cv2.FindContoursAsMat(mat, RetrievalModes.List, ContourApproximationModes.ApproxSimple);
            Cv2.FindContours(mat, out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            List<ContourData> contourDataList = new List<ContourData>();
            for (int i = 0; i < contours.Length; i++)
            {
                ContourData data = new ContourData();

               
                OpenCvSharp.Moments moments = Cv2.Moments(contours[i], true);

                if (moments.M10 == 0)
                    continue;

                if (moments.M01 == 0)
                    continue;
                if (moments.M00 == 0)
                    continue;

                data.CenterX = moments.M10 / moments.M00;
                data.CenterY = moments.M01 / moments.M00;

                data.Perimeter = Cv2.ArcLength(contours[i], false);
                data.ContourArea = Cv2.ContourArea(contours[i], false);

                OpenCvSharp.Point[] hull = Cv2.ConvexHull(contours[i], true);
                data.HullSize = hull.Count<OpenCvSharp.Point>();

                OpenCvSharp.Rect rect = Cv2.BoundingRect(contours[i]);

                data.BoundingRatio = rect.Height / rect.Width;
                data.BoundingSize = rect.Width * rect.Height;
                data.BoundingX = rect.X;
                data.BoundingY = rect.Y;
                data.BoundingWidth = rect.Width;
                data.BoundingHeight = rect.Height;

                OpenCvSharp.Line2D line = Cv2.FitLine(contours[i], OpenCvSharp.DistanceTypes.L2, 0, 0.01, 0.01);
                data.LineAngle = line.GetVectorAngle();

                contourDataList.Add(data);
            }
            return contourDataList;
        }

    }
}
