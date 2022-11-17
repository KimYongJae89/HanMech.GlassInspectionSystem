using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HMechUtility
{
    public static class MathHelper
    {
        public static int GetMinVal(int[] value)
        {
            int minval = 9999999;
            if (value[0] == 0 && value[1] == 0 && value[2] == 0)
                return 0;
            for (int i = 0; i < value.Count(); i++)
            {
                if (value[i] < minval && value[i] != 0)
                {
                    minval = value[i];
                }
            }
            return minval;
        }

        public static int GetMaxVal(int[] value)
        {
            int maxval = 0;
            for (int i = 0; i < value.Count(); i++)
            {
                if (value[i] > maxval)
                {
                    maxval = value[i];
                }
            }

            return maxval;
        }

        /// <summary>
        /// 메모리의 KB단위를 MB로 바꿈
        /// </summary>
        /// <param name="mem"></param>
        /// <returns></returns>
        public static int ConvertMemKBToMB(int mem)
        {
            mem = mem / 1024; //메모리 MB 단위로 변경

            return mem;
        }

        public static Double GetGradient(PointF startpos, PointF endpos)
        {
            double deltaX = endpos.X - startpos.X;
            double deltaY = endpos.Y - startpos.Y;

            double slopeValue = Math.Atan(deltaY / deltaX);

            double theta = 0;

            if (endpos.X > startpos.X)
                theta = 90.0 - slopeValue * 180.0 / Math.PI;
            else
                theta = -90.0 + Math.Abs(slopeValue * 180.0 / Math.PI);

            //Console.WriteLine("이거슨 : " + theta + "도 틀어졌다 이마리야");

            return theta;
        }

        public static PointF RotatePoint(PointF before_pos, double theta)
        {
            float posX = before_pos.X * (float)Math.Cos(theta) - before_pos.Y * (float)Math.Sin(theta);
            float posY = before_pos.X * (float)Math.Sin(theta) + before_pos.Y * (float)Math.Cos(theta);

            //Console.WriteLine("틀어진 이미지에서 불량좌표는 : " + before_pos + "이거신데");
            //Console.WriteLine("틀어진 " + theta + "도 만큼 돌리면 불량좌표가" + RealDefectPos + "이좌표다 이마리야");
            return new PointF(posX, posY);
        }
    }
}
