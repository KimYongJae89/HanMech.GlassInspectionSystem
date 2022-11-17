using GlassViewer.Controls;
using HMechDBLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlassViewer.Forms
{
    public partial class FormLineChart : Form
    {
        public DoubleBufferPanel DoubleBuffering = null;
        public Action CloseEventDelegate;

        private RectInfo _selectedRect = null;
        private List<DailyTable> _dailyTableList = new List<DailyTable>();
        private RectangleF _DrawLineChartRect = new RectangleF();
        private float _axisXInterval = 120;//X축 offset
        private float _axisYInterval = 50;
        private double _maxValue = 0;//Y축 레이블 Count
        private int _xRectInterval = 70;//Form의 우측 끝부분 부터 _DrawLineChartRect와의 거리
        private bool _isDrawingOkGraph = true;
        private bool _isDrawingNgGraph = true;
        private bool _isDrawingWarningGraph = true;
        private bool _isReDraw = false;
        private List<RectInfo> _rectInfoList = new List<RectInfo>();
        private float _graphRectPointWidth = 2f;
        private float _graphRectPointHeight = 2f;

        public FormLineChart()
        {
            InitializeComponent();
        }

        private void FormLineChart_Load(object sender, EventArgs e)
        {
            AddControls();//더블버퍼링
        }

        private void AddControls()
        {
            DoubleBuffering = new DoubleBufferPanel();
            pnlLineChart.Controls.Add(DoubleBuffering);
            DoubleBuffering.Dock = DockStyle.Fill;
            DoubleBuffering.MouseMove += DoubleBuffering_MouseMove;
            DoubleBuffering.Paint += DoubleBuffering_Paint;
            DoubleBuffering.Resize += DoubleBuffering_Resize;
            DoubleBuffering.SizeChanged += DoubleBuffering_Resize;
            this.MinimumSize = new System.Drawing.Size(1070, 630);
        }

        private void DoubleBuffering_Resize(object sender, EventArgs e)
        {
            if (DoubleBuffering != null)
            {
                SetDrawChartRect();
                _rectInfoList.Clear();
                DoubleBuffering.Invalidate();
            }
        }

        private void DoubleBuffering_Paint(object sender, PaintEventArgs e)
        {
            if (_isReDraw)
                DrawGraph(e.Graphics);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataInitialize(dtpkrFromDate.Value.Date, dtpkrToDate.Value.Date);

            if (DoubleBuffering != null)
                DoubleBuffering.Invalidate();

            _isReDraw = true;
        }

        private void DataInitialize(DateTime startTime, DateTime endTime)
        {
            _rectInfoList.Clear();
            _dailyTableList.Clear();
            _dailyTableList.AddRange(SearchingDate(startTime, endTime));
            SetDrawChartRect();//차트를 그릴 범위
        }

        private void DrawGraph(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            // 클리어
            g.Clear(SystemColors.Control);
            // Base 라인 + x축 y축 축별 라벨
            DrawBaseLine(g);
            // 차트
            DrawChart(g);
            // 그래프라벨
            if (_selectedRect != null)
                DrawSelectRectInfo(g, _selectedRect);
        }

        private void btnDrawGraphForAWeek_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now.AddDays(-6);
            DateTime endTime = DateTime.Now;

            dtpkrFromDate.Value = startTime;
            dtpkrToDate.Value = endTime;

            DataInitialize(startTime, endTime);
            if (DoubleBuffering != null)
                DoubleBuffering.Invalidate();
            _isReDraw = true;
        }

        private void btnDrawGraphFor30Days_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now.AddDays(-30);
            DateTime endTime = DateTime.Now;

            dtpkrFromDate.Value = startTime;
            dtpkrToDate.Value = endTime;

            DataInitialize(startTime, endTime);
            if (DoubleBuffering != null)
                DoubleBuffering.Invalidate();
            _isReDraw = true;
        }

        private void btnDrawGraphFor180Days_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now.AddDays(-180);
            DateTime endTime = DateTime.Now;

            dtpkrFromDate.Value = startTime;
            dtpkrToDate.Value = endTime;

            DataInitialize(startTime, endTime);

            if (DoubleBuffering != null)
                DoubleBuffering.Invalidate();
            _isReDraw = true;
        }

        private void ckbOKGraph_CheckedChanged(object sender, EventArgs e)
        {
            _isDrawingOkGraph = ckbOKGraph.Checked;
            _rectInfoList.Clear();//CheckBox 상태에 따라 라벨도 제거

            if (DoubleBuffering != null)
                DoubleBuffering.Invalidate();
        }

        private void ckbNGGraph_CheckedChanged(object sender, EventArgs e)
        {
            _isDrawingNgGraph = ckbNGGraph.Checked;
            _rectInfoList.Clear();

            if (DoubleBuffering != null)
                DoubleBuffering.Invalidate();
        }

        private void ckbWarningGraph_CheckedChanged(object sender, EventArgs e)
        {
            _isDrawingWarningGraph = ckbWarningGraph.Checked;
            _rectInfoList.Clear();

            if (DoubleBuffering != null)
                DoubleBuffering.Invalidate();
        }

        private void DoubleBuffering_MouseMove(object sender, MouseEventArgs e)
        {
            RectInfo info = IsContainPoint(new PointF(e.Location.X, e.Location.Y));

            if (info == null)
                _selectedRect = null;
            else
                _selectedRect = info;

            if (DoubleBuffering != null)
                DoubleBuffering.Invalidate();
        }

        private List<DailyTable> SearchingDate(DateTime startTime, DateTime endTime)
        {
            List<DailyTable> dailyTableList = new List<DailyTable>();
            startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 00, 00, 00);//년,월,일,시,분,초 까지만 표시
            endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 23, 59, 59);//년,월,일,시,분,초 까지만 표시

            if (IsEnableDate(startTime, endTime))
            {
                if (endTime.ToLongDateString() == DateTime.Now.ToLongDateString())
                {
                    dailyTableList.AddRange(Status.Instance().DBHelper.SearchingDateByDailyTable(startTime, endTime));
                    dailyTableList.Add(Status.Instance().DBHelper.SearchingDateCountByResultTable(DateTime.Now));
                }
                else
                {
                    dailyTableList.AddRange(Status.Instance().DBHelper.SearchingDateByDailyTable(startTime, endTime.AddDays(1)));
                }

                _maxValue = GetMaxCount(dailyTableList);
            }
            else
                _maxValue = 0;

            return dailyTableList;
        }

        private bool IsEnableDate(DateTime startTime, DateTime endTime)
        {
            TimeSpan timeSpan = (endTime - startTime);//현재날짜 - 선택날짜

            if (timeSpan.Days > 180)//180일 초과
            {
                string correctDateTime = string.Format("{0:d}", endTime.AddDays(-180));
                MessageBox.Show("Set within 180 days. \n" + "Start date is : " + correctDateTime);
                return false;
            }
            else if (timeSpan.Days < 0 || timeSpan.Days == 0 && startTime > endTime)
            {
                MessageBox.Show("Set start date less than end date.");
                return false;
            }
            else if (timeSpan.Days == 0 && startTime <= endTime)
            {
                MessageBox.Show("Set the period to 2 days or more.");
                return false;
            }
            else
                return true;
        }

        private void SetDrawChartRect()
        {
            _DrawLineChartRect = new RectangleF(_axisXInterval, _axisYInterval, (pnlLineChart.Width - _axisXInterval - _xRectInterval), pnlLineChart.Height - (_axisYInterval * 2));
        }

        private void DrawBaseLine(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);//밑그림을 그릴 때 필요한 pen객체 생성
            Pen dashPen = new Pen(Color.Gray, 1);
            float[] dashValues = { 5, 5 };
            dashPen.DashPattern = dashValues;
            int arrowLength = 8;//화살표 길이

            //X축 화살표
            g.DrawLine(pen, new PointF(_DrawLineChartRect.Right, _DrawLineChartRect.Bottom), new PointF(_DrawLineChartRect.Right - arrowLength, _DrawLineChartRect.Bottom - arrowLength));
            g.DrawLine(pen, new PointF(_DrawLineChartRect.Right, _DrawLineChartRect.Bottom), new PointF(_DrawLineChartRect.Right - arrowLength, _DrawLineChartRect.Bottom + arrowLength));
            //X축 위, 중간, 아래 
            g.DrawLine(pen, new PointF(_DrawLineChartRect.Left, _DrawLineChartRect.Top), new PointF(_DrawLineChartRect.Right, _DrawLineChartRect.Top));
            g.DrawLine(dashPen, new PointF(_DrawLineChartRect.Left, _DrawLineChartRect.Top + (_DrawLineChartRect.Height / 2)), new PointF(_DrawLineChartRect.Right, _DrawLineChartRect.Top + (_DrawLineChartRect.Height / 2)));
            g.DrawLine(pen, new PointF(_DrawLineChartRect.Left, _DrawLineChartRect.Bottom), new PointF(_DrawLineChartRect.Right, _DrawLineChartRect.Bottom));
            //X축 Type
            DrawAxisXType(g);
            //Y축 Type
            DrawAxisYType(g);
            //Y축 레이블
            GetAxisYLable(g);
        }

        private void GetDrawData(DateTime startDateTime, DateTime endDateTime)
        {
            List<DailyTable> dailyTableList = new List<DailyTable>();
            //날짜별 DailyTable의 정보를 얻어옴
            GetDailyTableListInfo(startDateTime, endDateTime, dailyTableList);

            _maxValue = GetMaxCount(dailyTableList);
        }

        private void DrawChart(Graphics g)
        {
            PointF prevOkPoint = new PointF();
            PointF prevNgPoint = new PointF();
            PointF prevWarningPoint = new PointF();
            RectangleF okGraphRect = new RectangleF();
            RectangleF ngGraphRect = new RectangleF();
            RectangleF warningGraphRect = new RectangleF();

            float xAxisInterval = _DrawLineChartRect.Width / (float)(_dailyTableList.Count - 1);
            float axisXIntervalCount = _dailyTableList.Count / (float)6;
            int seriesInterval = 15;

            if (_dailyTableList.Count <= 6)//일주일 미만
                axisXIntervalCount = 1;

            //범례
            DrawChartSeries(g, new SolidBrush(Color.MediumSeaGreen), "OK", seriesInterval * 1);
            DrawChartSeries(g, new SolidBrush(Color.Red), "NG", seriesInterval * 2);
            DrawChartSeries(g, new SolidBrush(Color.Orange), "Warning", (seriesInterval * 3));

            for (int i = 0; i < _dailyTableList.Count; i++)
            {
                float x = _DrawLineChartRect.X + (i * xAxisInterval);

                YPosition position = GetYPosition(_maxValue, _dailyTableList[i]);

                //X축 레이블 설정
                GetAxisXLable(i, x, axisXIntervalCount, _dailyTableList, g);


                if (i == 0)
                {
                    prevOkPoint = new PointF(x, position.OkPosition);
                    prevNgPoint = new PointF(x, position.NgPosition);
                    prevWarningPoint = new PointF(x, position.WarningPosition);

                    if (_isDrawingOkGraph)
                    {
                        okGraphRect = GetGraphRect(prevOkPoint);
                        DrawGraphRect(g, new SolidBrush(Color.MediumSeaGreen), okGraphRect);
                        _rectInfoList.Add(GetRectInfo(_dailyTableList[i], okGraphRect));
                    }
                    if (_isDrawingNgGraph)
                    {
                        ngGraphRect = GetGraphRect(prevNgPoint);
                        DrawGraphRect(g, new SolidBrush(Color.Red), ngGraphRect);
                        _rectInfoList.Add(GetRectInfo(_dailyTableList[i], ngGraphRect));
                    }
                    if (_isDrawingWarningGraph)
                    {
                        warningGraphRect = GetGraphRect(prevWarningPoint);
                        DrawGraphRect(g, new SolidBrush(Color.Orange), warningGraphRect);
                        _rectInfoList.Add(GetRectInfo(_dailyTableList[i], warningGraphRect));
                    }
                }
                else
                {
                    PointF nowOkPoint = new PointF(x, position.OkPosition);
                    PointF nowNgPoint = new PointF(x, position.NgPosition);
                    PointF nowWarningPoint = new PointF(x, position.WarningPosition);

                    if (_isDrawingOkGraph)
                    {
                        okGraphRect = GetGraphRect(nowOkPoint);
                        DrawGraphRect(g, new SolidBrush(Color.MediumSeaGreen), okGraphRect);
                        DrawLineGraph(g, new Pen(Color.MediumSeaGreen, (float)0.3), prevOkPoint, nowOkPoint);
                        _rectInfoList.Add(GetRectInfo(_dailyTableList[i], okGraphRect));
                    }
                    if (_isDrawingNgGraph)
                    {
                        ngGraphRect = GetGraphRect(nowNgPoint);
                        DrawGraphRect(g, new SolidBrush(Color.Red), ngGraphRect);
                        DrawLineGraph(g, new Pen(Color.Red, (float)0.3), prevNgPoint, nowNgPoint);
                        _rectInfoList.Add(GetRectInfo(_dailyTableList[i], ngGraphRect));
                    }
                    if (_isDrawingWarningGraph)
                    {
                        warningGraphRect = GetGraphRect(nowWarningPoint);
                        DrawGraphRect(g, new SolidBrush(Color.Orange), warningGraphRect);
                        DrawLineGraph(g, new Pen(Color.Orange, (float)0.3), prevWarningPoint, nowWarningPoint);
                        _rectInfoList.Add(GetRectInfo(_dailyTableList[i], warningGraphRect));
                    }

                    prevOkPoint = nowOkPoint;
                    prevNgPoint = nowNgPoint;
                    prevWarningPoint = nowWarningPoint;
                }
            }
        }

        private YPosition GetYPosition(double yAxisMaxValue, DailyTable daliyTable)
        {
            YPosition yPosition = new YPosition();

            yPosition.OkPosition = _DrawLineChartRect.Bottom - (_DrawLineChartRect.Height * (float)daliyTable.OKCount / (float)yAxisMaxValue);
            yPosition.NgPosition = _DrawLineChartRect.Bottom - (_DrawLineChartRect.Height * (float)daliyTable.NGCount / (float)yAxisMaxValue);
            yPosition.WarningPosition = _DrawLineChartRect.Bottom - (_DrawLineChartRect.Height * (float)daliyTable.WarningCount / (float)yAxisMaxValue);

            return yPosition;
        }

        private int GetMaxCount(List<DailyTable> dailyTableList)
        {
            int value = int.MinValue;

            foreach (DailyTable table in dailyTableList)
            {
                if (table.OKCount >= value)
                    value = table.OKCount;
                if (table.NGCount >= value)
                    value = table.NGCount;
                if (table.WarningCount >= value)
                    value = table.WarningCount;
            }

            return value;
        }

        private RectInfo GetRectInfo(DailyTable dailyTable, RectangleF graphRect)
        {
            RectInfo info = new RectInfo();
            //info.Rect = graphRect;
            info.Rect = new RectangleF(graphRect.X - (graphRect.Width / 2), graphRect.Y - (graphRect.Height / 2), graphRect.Width * 2, graphRect.Height * 2);
            info.Time = dailyTable.Updated;
            info.OKCount = dailyTable.OKCount;
            info.NGCount = dailyTable.NGCount;
            info.WarningCount = dailyTable.WarningCount;

            return info;
        }

        private Font GetFontStyle(int fontSize, FontStyle fontStyle)
        {
            Font font = new Font("Microsoft Sans Serif", fontSize, fontStyle);

            return font;
        }

        private void DrawAxisXType(Graphics g)
        {
            string axisXString = "Range(day)";
            float axisXTypeWidth = g.MeasureString(axisXString, GetFontStyle(7, FontStyle.Regular)).Width;
            float axisXTypeHeight = g.MeasureString(axisXString, GetFontStyle(7, FontStyle.Regular)).Height;
            PointF axisXTypePoint = new PointF(_DrawLineChartRect.Right - (axisXTypeWidth / 2), _DrawLineChartRect.Bottom + (axisXTypeHeight * 2));
            g.DrawString(axisXString, GetFontStyle(7, FontStyle.Regular), Brushes.Black, axisXTypePoint);
        }

        private void DrawAxisYType(Graphics g)
        {
            string axisYString = "ResultCount";
            float axisYTypeWidth = g.MeasureString(axisYString, GetFontStyle(7, FontStyle.Regular)).Width;
            float axisYTypeHeight = g.MeasureString(axisYString, GetFontStyle(7, FontStyle.Regular)).Height;
            PointF axisYTypePoint = new PointF(_DrawLineChartRect.Left, _DrawLineChartRect.Top - (axisYTypeHeight * 2));
            g.DrawString(axisYString, GetFontStyle(7, FontStyle.Regular), Brushes.Black, axisYTypePoint);
        }

        private void GetAxisXLable(int i, float x, float axisXIntervalCount, List<DailyTable> dailyTableList, Graphics g)
        {
            if (i % (int)axisXIntervalCount == 0)
            {
                //X축 표시선
                PointF startXLablePoint = new PointF(x, _DrawLineChartRect.Bottom - 6);
                PointF endXLablePoint = new PointF(x, _DrawLineChartRect.Bottom + 6);
                g.DrawLine(new Pen(Color.Black, 2), startXLablePoint, endXLablePoint);
                //X축 라벨(날짜)
                string axisXLabel = string.Format("{0:d}", dailyTableList[i].Updated).ToString();
                float axisXLabelWidth = g.MeasureString(axisXLabel, GetFontStyle(6, FontStyle.Bold)).Width;
                float axisXLabelHeight = g.MeasureString(axisXLabel, GetFontStyle(6, FontStyle.Bold)).Height;
                PointF axisXLabelPoint = new PointF(endXLablePoint.X - (axisXLabelWidth / 2), endXLablePoint.Y + (axisXLabelHeight / 2));
                g.DrawString(axisXLabel, GetFontStyle(6, FontStyle.Bold), Brushes.Black, axisXLabelPoint);
            }
        }

        private void GetAxisYLable(Graphics g)
        {
            float markYInterval = _DrawLineChartRect.Height / (float)2;
            int axisYLableCount = 2;//Y축의 Label 갯수

            for (int i = 0; i < axisYLableCount + 1; i++)
            {
                string axisYLabel = (_maxValue / axisYLableCount * i).ToString();
                float yInterval = markYInterval / (float)axisYLableCount * (float)i;
                float axisYLabelWidth = g.MeasureString(axisYLabel, GetFontStyle(7, FontStyle.Bold)).Width;//Y축 레이블 글자의 너비
                float axisYLabelHeight = g.MeasureString(axisYLabel, GetFontStyle(7, FontStyle.Bold)).Height;//Y축 레이블 글자의 높이
                float startY = _DrawLineChartRect.Bottom - (yInterval * (float)2);
                PointF axisYLabelPoint = new PointF(_axisXInterval - (axisYLabelWidth * (float)2), startY - (axisYLabelHeight / (float)2));

                g.DrawString(axisYLabel, GetFontStyle(7, FontStyle.Bold), Brushes.Black, axisYLabelPoint);
            }
        }

        private List<DailyTable> GetDailyTableListInfo(DateTime startDateTime, DateTime endDateTime, List<DailyTable> dailyTableList)
        {
            string endDate = string.Format("{0:d}", endDateTime);
            string today = string.Format("{0:d}", DateTime.Now);

            if (endDate == today)
            {
                dailyTableList.AddRange(Status.Instance().DBHelper.SearchingDateByDailyTable(startDateTime, endDateTime));
                dailyTableList.Add(Status.Instance().DBHelper.SearchingDateCountByResultTable(DateTime.Now));
            }
            else
            {
                dailyTableList.AddRange(Status.Instance().DBHelper.SearchingDateByDailyTable(startDateTime, endDateTime.AddDays(1)));
            }

            return dailyTableList;
        }

        private void DrawChartSeries(Graphics g, SolidBrush brush, string seriesType, int seriesInterval)
        {
            RectangleF SeriesRect = new RectangleF(new PointF(_DrawLineChartRect.X / (float)3, _DrawLineChartRect.Y + seriesInterval), new Size(45, 3));
            float seriesTypeWidth = g.MeasureString(seriesType, GetFontStyle(6, FontStyle.Regular)).Width;
            float seriesTypeHeight = g.MeasureString(seriesType, GetFontStyle(6, FontStyle.Regular)).Height;

            g.FillRectangle(brush, SeriesRect);
            g.DrawString(seriesType, GetFontStyle(6, FontStyle.Regular), Brushes.Black, new PointF(SeriesRect.X - seriesTypeWidth - 5, SeriesRect.Y - (seriesTypeHeight / 4)));
        }

        private void DrawGraphRect(Graphics g, SolidBrush brush, RectangleF graphRect)
        {
            g.FillRectangle(brush, graphRect);
        }

        private void DrawLineGraph(Graphics g, Pen pen, PointF prevPoint, PointF nowPoint)
        {
            if (prevPoint.Y.Equals(float.NaN)) //Y좌표가 NaN값이면 0으로 수정
                prevPoint.Y = 0;

            g.DrawLine(pen, prevPoint, nowPoint);
        }

        private RectangleF GetGraphRect(PointF prevPoint)
        {
            RectangleF firstRect = new RectangleF(prevPoint.X - (_graphRectPointWidth / 2), prevPoint.Y - (_graphRectPointHeight / 2), _graphRectPointWidth, _graphRectPointHeight);

            return firstRect;
        }

        private RectInfo IsContainPoint(PointF point)
        {
            RectInfo ret = null;

            foreach (RectInfo info in _rectInfoList)
            {
                if (info.Rect.Contains(point))
                {
                    ret = info.Copy();
                    break;
                }
            }

            return ret;
        }

        private void DrawSelectRectInfo(Graphics g, RectInfo info)
        {
            string rectInfoTime = string.Format("{0:d}", info.Time);
            string rectInfoOKCount = "OK : " + info.OKCount.ToString();
            string rectInfoNGCount = "NG : " + info.NGCount.ToString();
            string rectInfoWarningCount = "Warning : " + info.WarningCount.ToString();
            string totalRectInfo = rectInfoTime + "\n" + rectInfoOKCount + "\n" + rectInfoNGCount + "\n" + rectInfoWarningCount;
            float totalRectWidth = g.MeasureString(totalRectInfo, GetFontStyle(7, FontStyle.Bold)).Width;
            float totalRectHeight = g.MeasureString(totalRectInfo, GetFontStyle(7, FontStyle.Bold)).Height;
            float infoStringInterval = totalRectHeight / (float)4;

            g.FillRectangle(new SolidBrush(Color.White), info.Rect.X - (totalRectWidth / 4), info.Rect.Y - (totalRectHeight / 4), totalRectWidth + (totalRectWidth / 2), totalRectHeight + (totalRectHeight / 2));
            g.DrawString(rectInfoTime, GetFontStyle(7, FontStyle.Bold), Brushes.Black, new PointF(info.Rect.X, info.Rect.Y));
            g.DrawString(rectInfoOKCount, GetFontStyle(7, FontStyle.Bold), Brushes.MediumSeaGreen, new PointF(info.Rect.X, info.Rect.Y + (infoStringInterval * 1)));
            g.DrawString(rectInfoNGCount, GetFontStyle(7, FontStyle.Bold), Brushes.Red, new PointF(info.Rect.X, info.Rect.Y + (infoStringInterval * 2)));
            g.DrawString(rectInfoWarningCount, GetFontStyle(7, FontStyle.Bold), Brushes.Orange, new PointF(info.Rect.X, info.Rect.Y + (infoStringInterval * 3)));
        }

        private void FormLineChart_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            if (_isReDraw)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "CSV File(*.csv)|*.csv;";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MakeSCV(dialog.FileName);
                }
            }
            else
                MessageBox.Show("Retry After Click Searching Button.");
        }

        private void MakeSCV(string fullPath)
        {
            try
            {
                string folderPath = Path.GetDirectoryName(fullPath);
                string fileName = Path.GetFileNameWithoutExtension(fullPath);

                string savePath = Path.Combine(folderPath, fileName +"_"+ DateTime.Now.ToShortDateString() + ".csv");

                List<DailyTable> dailyTableList = SearchingDate(dtpkrFromDate.Value, dtpkrToDate.Value);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(savePath, false, Encoding.UTF8))
                {
                    file.WriteLine("\r,Make Date : " + DateTime.Now);
                    file.WriteLine("\r,,OK,NG,Warning");

                    foreach (var item in dailyTableList)
                    {
                        file.WriteLine("," + item.Updated.ToShortDateString() + "," + item.OKCount.ToString() + "," + item.NGCount.ToString() + "," + item.WarningCount.ToString());
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private Bitmap DrawControlToBitmap(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));
                       
            return bmp;
        }

        private void btnSaveChart_Click(object sender, EventArgs e)
        {
            if (_isReDraw)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Png File(*.png)|*.png;";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap chartBmp = DrawControlToBitmap(this.pnlLineChart);
                    chartBmp.Save(dialog.FileName, ImageFormat.Png);
                    chartBmp.Dispose();
                }
            }
            else
                MessageBox.Show("Retry After Click Searching Button.");
        }
    }



    public class RectInfo
    {
        public RectangleF Rect;
        public DateTime Time;
        public int OKCount;
        public int NGCount;
        public int WarningCount;

        public RectInfo Copy()
        {
            RectInfo info = new RectInfo();
            info.Rect = this.Rect;
            info.Time = this.Time;
            info.OKCount = this.OKCount;
            info.NGCount = this.NGCount;
            info.WarningCount = this.WarningCount;

            return info;
        }
    }
}
