using System.Drawing;

namespace MechAI.Model
{
    public class MechItem
    {
        public int Type { get; set; }
        public double Confidence { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public MechItem()
        {
        }

        public MechItem(int defectType, float confidence, int x, int y, int width, int height)
        {
            this.Type = defectType;
            this.Confidence = confidence;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public Point Center()
        {
            return new Point(X + (Width / 2), Y + Height / 2);
        }
    }
}
