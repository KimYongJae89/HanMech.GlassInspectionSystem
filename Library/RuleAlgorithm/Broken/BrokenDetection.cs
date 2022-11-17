using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm.Broken
{
    public class BrokenDetectionFactory
    {
        public static BrokenDetection Create(eEdgeType type)
        {
            BrokenDetection detect = null;
            switch (type)
            {
                case eEdgeType.Left:
                    detect = new LeftBroken();
                    break;

                case eEdgeType.Right:
                    detect = new RightBroken();
                    break;

                case eEdgeType.Top:
                    detect = new TopBroken();
                    break;

                case eEdgeType.Bottom:
                    detect = new BottomBroken();
                    break;

                case eEdgeType.None:
                default:
                    break;
            }
            return detect;
        }
    }

    public abstract class BrokenDetection
    {
        public static Rectangle GetDefectRoi(int left, int top, int right, int bottom, eEdgeType type, int cropIntervalFromEdge)
        {
            int interval = 20;
            if (type == eEdgeType.Left)
            {
                left = cropIntervalFromEdge;
                int width = interval;
                int height = Math.Abs(top - bottom);
                return new Rectangle(left, top, (int)width, (int)height);
            }
            else if (type == eEdgeType.Right)
            {
                left = cropIntervalFromEdge - interval;
                int width = interval;
                int height = Math.Abs(top - bottom);
                return new Rectangle(left, top, (int)width, (int)height);
            }
            else if (type == eEdgeType.Top)
            {
                top = cropIntervalFromEdge;
                int width = Math.Abs(left - right);
                int height = interval;

                return new Rectangle(left, top, (int)width, (int)height);
            }
            else if (type == eEdgeType.Bottom)
            {
                top = cropIntervalFromEdge - interval;
                int width = Math.Abs(left - right);
                int height = interval;
                return new Rectangle(left, top, (int)width, (int)height);
            }
            else
            {
                return new Rectangle();
            }
        }

        public abstract float[] LineTracking(Bitmap bmp);

        public abstract List<Rectangle> Run(float[] edgeIndexArray, double brokenVal, int avgCount, int imageWidth, int imageHeight);
    }
}