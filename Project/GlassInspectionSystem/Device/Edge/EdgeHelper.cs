using RuleAlgorithm.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Device.Edge
{
    public static class EdgeHelper
    {
        public static void SetAIRoi(ref EdgeElement element, int width, int height, int distanceFromLine)
        {
            if (element.Type == eEdgeType.Top)
            {
                Rectangle rect = new Rectangle(0, element.Index - distanceFromLine, width, distanceFromLine * 2);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * height) + rect.Y);
                element.OrgImageWidth = width;
                element.OrgImageHeight = height;
            }

            if (element.Type == eEdgeType.Bottom)
            {
                Rectangle rect = new Rectangle(0, element.Index - distanceFromLine, width, distanceFromLine * 2);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * height) + rect.Y);
                element.OrgImageWidth = width;
                element.OrgImageHeight = height;
            }

            // left edge
            if (element.Type == eEdgeType.Left)
            {
                Rectangle rect = new Rectangle((element.Index - distanceFromLine), 0, distanceFromLine * 2, height);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * height) + rect.Y);
                element.OrgImageWidth = width;
                element.OrgImageHeight = height;
            }

            // right edge
            if (element.Type == eEdgeType.Right)
            {
                Rectangle rect = new Rectangle((element.Index - distanceFromLine), 0, distanceFromLine * 2, height);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * height) + rect.Y);
                element.OrgImageWidth = width;
                element.OrgImageHeight = height;
            }
        }

        public static void SetEdgeBrokenRoi(ref EdgeElement element,int inSideFromEdge, int outSideFromEdge)
        {
            if (element.Type == eEdgeType.Top)
            {
                Rectangle rect = new Rectangle(0, element.Index - outSideFromEdge, element.OrgImageWidth, (inSideFromEdge + outSideFromEdge));
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }

            if (element.Type == eEdgeType.Bottom)
            {
                Rectangle rect = new Rectangle(0, element.Index - inSideFromEdge, element.OrgImageWidth, (inSideFromEdge + outSideFromEdge));
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }

            // left edge
            if (element.Type == eEdgeType.Left)
            {
                Rectangle rect = new Rectangle((element.Index - outSideFromEdge), 0, (inSideFromEdge + outSideFromEdge), element.OrgImageHeight);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }

            // right edge
            if (element.Type == eEdgeType.Right)
            {
                Rectangle rect = new Rectangle((element.Index - inSideFromEdge), 0, (inSideFromEdge + outSideFromEdge), element.OrgImageHeight);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }
        }

        public static void SetEdgeContourRoi(ref EdgeElement element,int intervalFromEdge, int roiSize)
        {
            if (element.Type == eEdgeType.Top)
            {
                Rectangle rect = new Rectangle(0, element.Index + intervalFromEdge, element.OrgImageWidth, roiSize);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }

            if (element.Type == eEdgeType.Bottom)
            {
                Rectangle rect = new Rectangle(0, element.Index - (intervalFromEdge + roiSize), element.OrgImageWidth, roiSize);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }

            // left edge
            if (element.Type == eEdgeType.Left)
            {
                Rectangle rect = new Rectangle(element.Index + intervalFromEdge, 0, roiSize, element.OrgImageHeight);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }

            // right edge
            if (element.Type == eEdgeType.Right)
            {
                Rectangle rect = new Rectangle(element.Index - (intervalFromEdge + roiSize), 0, roiSize, element.OrgImageHeight);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }
        }

        public static void SetForkBrokenRoi(ref EdgeElement element,int inSideFromEdge, int outSideFromEdge , int startX, int endX)
        {
            if (element.Type == eEdgeType.Bottom)
            {
                int width = endX - startX;
                Rectangle rect = new Rectangle(startX, element.Index - inSideFromEdge, width, (inSideFromEdge + outSideFromEdge));
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }

        }

        public static void SetForkContourRoi(ref EdgeElement element, int intervalFromEdge, int roiSize, int startX, int endX)
        {
            if (element.Type == eEdgeType.Bottom)
            {
                int width = endX - startX;
                Rectangle rect = new Rectangle(startX, element.Index - (intervalFromEdge + roiSize), width, roiSize);
                element.CropRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                element.CropRealPoint = new Point(rect.X, (element.SubNo * element.OrgImageHeight) + rect.Y);
            }
        }
    }
}