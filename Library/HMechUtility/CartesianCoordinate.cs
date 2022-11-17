using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMechUtility
{
    public class CartesianCoordinate
    {
        public enum eDirection
        {
            LeftTop,
            RightTop,
            LeftBottom,
            RightBottom,
        }

        public PointF Coordinate(PointF originpos, PointF endpos, PointF defectpos)
        {
            double theta = MathHelper.GetGradient(originpos, endpos);
            return MathHelper.RotatePoint(defectpos, theta);
        }
    }
}