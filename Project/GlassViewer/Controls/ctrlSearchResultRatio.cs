using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using HMechDBLib;

namespace GlassViewer.Controls
{
    public enum eResultConstant
    {
        None,
        OK,
        NG,
        Warning,
    }

    public partial class CtrlSearchResultRatio : UserControl
    {
        private eResultConstant _resultType = eResultConstant.None;
        //Chart를 그릴 때 필요한 변수들
        private RectangleF _DrawChartRect = new RectangleF();
        private int _axisXInterval = 80;
        private int _axisYInterval = 30;
        private int _percentCount = 4;//X축 레이블 Count
        private int _resultCount = 2;//Y축 레이블 Count
        private int _xRectInterval = 30;//Form의 우측 끝부분 부터 _DrawChartRect와의 거리
        private int _yRectInterval = 20;//Form의 하단부터 _DrawChartRect와의 거리

        public CtrlSearchResultRatio()
        {
            InitializeComponent();
        }

        public void UpdateData(bool drawRatioRect)
        {
            if (!drawRatioRect)//차트막대를 그리지 않음
            {
                Status.Instance().OkCount = 0;
                Status.Instance().NgCount = 0;
                Status.Instance().WarningCount = 0;
                Status.Instance().TotalCount = 0;
            }

            int okCount = Status.Instance().OkCount;
            int ngCount = Status.Instance().NgCount;
            int warningCount = Status.Instance().WarningCount;
            int totalCount = ngCount + okCount + warningCount;

            Status.Instance().TotalCount = totalCount;

            lblNGCount.Text = ngCount.ToString();
            lblOKCount.Text = okCount.ToString();
            lblWARNINGCount.Text = warningCount.ToString();
            lblTotalCount.Text = totalCount.ToString();
            lblNGPercent.Text = (((double)ngCount / totalCount) * 100).ToString("F2") + "%";

            DrawChart();//Chart업데이트
        }

        public DataGridView ResultConstantCount(DataGridView dataGridView)
        {
            int okCount = 0;
            int ngCount = 0;
            int warningCount = 0;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                _resultType = (eResultConstant)Enum.Parse(typeof(eResultConstant), dataGridView[1, i]/*[Column, Row]*/.Value.ToString(), true);

                switch (_resultType)
                {
                    case eResultConstant.OK:
                        okCount++;
                        break;
                    case eResultConstant.NG:
                        ngCount++;
                        break;
                    case eResultConstant.Warning:
                        warningCount++;
                        break;
                    default:
                        break;
                }
            }

            Status.Instance().OkCount = okCount;
            Status.Instance().NgCount = ngCount;
            Status.Instance().WarningCount = warningCount;

            return dataGridView;
        }

        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            try
            {
                using (Graphics g = pnlChart.CreateGraphics())
                {
                    g.Clear(SystemColors.Control);
                    // Rectangle 그리는 영역 지정
                    SetDrawChartRect();
                    // 도형(그래프)
                    DrawRatioRectangle(g);
                    // 밑그림
                    DrawBaseLine(g);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private Font GetFontStyle(int fontSize, FontStyle fontStyle)
        {
            Font font = new Font("Microsoft Sans Serif", fontSize, fontStyle);

            return font;
        }

        private void DrawRatioRectangle(Graphics g)
        {
            try
            {
                //Y축에서 그래프간의 간격
                float rectInterval = (float)(_DrawChartRect.Height - _axisYInterval) / 7;

                float okRectTop = _DrawChartRect.Y + (float)rectInterval * 1;
                float ngRectTop = _DrawChartRect.Y + (float)rectInterval * 3;
                float warningRectTop = _DrawChartRect.Y + (float)rectInterval * 5;

                //OK, NG, WARNING 그래프 길이(나중에 가져와야할 값)
                float ok = (float)(Status.Instance().OkCount / (float)Status.Instance().TotalCount) * (float)100;
                float ng = (float)(Status.Instance().NgCount / (float)Status.Instance().TotalCount) * (float)100;
                float warning = (float)(Status.Instance().WarningCount / (float)Status.Instance().TotalCount) * (float)100;
                
                //OK
                g.FillRectangle(new SolidBrush(Color.MediumSeaGreen), new RectangleF(_DrawChartRect.X, okRectTop, GetRatioPosition(ok, _DrawChartRect.Width), rectInterval));
                //OK Graph수치 값
                string okPercentString = (Convert.ToDouble((double)Status.Instance().OkCount / (double)Status.Instance().TotalCount) * 100).ToString("F2") + "%";
                float okPercentRectTop = _DrawChartRect.Y + (float)rectInterval + ((float)rectInterval / 2);
                float okPercentHeight = g.MeasureString(okPercentString, GetFontStyle(7, FontStyle.Bold)).Height;
                PointF okPercentPoint = new PointF(_DrawChartRect.X + GetRatioPosition(ok, _DrawChartRect.Width), okPercentRectTop - (okPercentHeight / 2));
                g.DrawString(okPercentString, GetFontStyle(7, FontStyle.Bold), Brushes.Black, okPercentPoint);

                //NG
                g.FillRectangle(new SolidBrush(Color.Red), new RectangleF(_DrawChartRect.X, ngRectTop, GetRatioPosition(ng, _DrawChartRect.Width), rectInterval));
                //NG Graph수치 값
                string ngPercentString = (Convert.ToDouble((double)Status.Instance().NgCount / (double)Status.Instance().TotalCount) * 100).ToString("F2") + "%";
                float ngPercentRectTop = _DrawChartRect.Y + (float)rectInterval * 3 + ((float)rectInterval / 2);
                float ngPercentHeight = g.MeasureString(ngPercentString, GetFontStyle(7, FontStyle.Bold)).Height;
                PointF ngPercentPoint = new PointF(_DrawChartRect.X + GetRatioPosition(ng, _DrawChartRect.Width), ngPercentRectTop - (ngPercentHeight / 2));
                g.DrawString(ngPercentString, GetFontStyle(7, FontStyle.Bold), Brushes.Black, ngPercentPoint);

                //Warning
                g.FillRectangle(new SolidBrush(Color.Orange), new RectangleF(_DrawChartRect.X, warningRectTop, GetRatioPosition(warning, _DrawChartRect.Width), rectInterval));
                //Warning Graph수치 값
                string warningPercentString = (Convert.ToDouble((double)Status.Instance().WarningCount / (double)Status.Instance().TotalCount) * 100).ToString("F2") + "%";
                float warningPercentRectTop = _DrawChartRect.Y + (float)rectInterval * 5 + ((float)rectInterval / 2);
                float warningPercentHeight = g.MeasureString(warningPercentString, GetFontStyle(7, FontStyle.Bold)).Height;
                PointF warningPercentPoint = new PointF(_DrawChartRect.X + GetRatioPosition(warning, _DrawChartRect.Width), warningPercentRectTop - (warningPercentHeight / 2));
                g.DrawString(warningPercentString, GetFontStyle(7, FontStyle.Bold), Brushes.Black, warningPercentPoint);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private float GetRatioPosition(float ratio, float length)//그래프의 비율 구하기
        {
            float pos = (float)length / 100 * ratio;
            return pos;
        }

        private void DrawBaseLine(Graphics g)
        {
            try
            {
                Pen pen = new Pen(Color.Black, 2);//밑그림을 그릴 때 필요한 pen객체 생성
                int arrowLength = 4;//화살표 길이

                //X, Y축 화살표
                g.DrawLine(pen, new PointF(pnlChart.Width - _xRectInterval, pnlChart.Height - _axisYInterval), new PointF(pnlChart.Width - _xRectInterval - arrowLength, pnlChart.Height - _axisYInterval - arrowLength));
                g.DrawLine(pen, new PointF(pnlChart.Width - _xRectInterval, pnlChart.Height - _axisYInterval), new PointF(pnlChart.Width - _xRectInterval - arrowLength, pnlChart.Height - _axisYInterval + arrowLength));
                g.DrawLine(pen, new PointF(_axisXInterval, _yRectInterval), new PointF(_axisXInterval - arrowLength, _yRectInterval + arrowLength));
                g.DrawLine(pen, new PointF(_axisXInterval, _yRectInterval), new PointF(_axisXInterval + arrowLength, _yRectInterval + arrowLength));
                //X, Y축
                g.DrawLine(pen, new PointF(_axisXInterval, pnlChart.Height - _axisYInterval), new PointF(pnlChart.Width - _xRectInterval, pnlChart.Height - _axisYInterval));
                g.DrawLine(pen, new PointF(_axisXInterval, _yRectInterval), new PointF(_axisXInterval, pnlChart.Height - _axisYInterval));

                float markXInterval = (float)_DrawChartRect.Width / (float)_percentCount;
                float markYInterval = (float)_DrawChartRect.Height / (float)_resultCount;

                //X축 레이블
                for (int i = 0; i < _percentCount + 1; i++)
                {
                    string axisXLabel = (100 / _percentCount * i).ToString();//X축 레이블의 값(0, 25, 50, 75, 100)
                    float xInterval = _axisXInterval + markXInterval * (float)i;//X축 레이블의 간격
                    float height = 6;
                    float startY = pnlChart.Height - _axisYInterval - height;
                    float endY = pnlChart.Height - _axisYInterval + height;

                    //X축 표시선
                    g.DrawLine(pen, new PointF(xInterval, startY), new PointF(xInterval, endY));
                    //X축 레이블
                    float axisXLabelWidth = g.MeasureString(axisXLabel, GetFontStyle(7, FontStyle.Bold)).Width;//X축 레이블 글자의 너비
                    float axisXLabelPoint = xInterval - (axisXLabelWidth / 2);//새로운 X레이블 Point(X축 표시선의 중앙 기준으로 레이블 표시)
                    g.DrawString(axisXLabel, GetFontStyle(7, FontStyle.Bold), Brushes.Black, new PointF(axisXLabelPoint, endY));
                }

                //Y축 레이블
                float rectInterval = (float)(_DrawChartRect.Height - _axisYInterval) / 7;
                float axisYdistance = 5;//Y축 레이블과 그래프와의 거리

                //X축 Type
                string axisXString = "Ratio(%)";
                float axisXTypeWidth = g.MeasureString(axisXString, GetFontStyle(7, FontStyle.Regular)).Width;//Y축 레이블 글자의 너비
                PointF axisXTypePoint = new PointF(pnlChart.Width - _xRectInterval - arrowLength - (axisXTypeWidth / 4), pnlChart.Height - _axisYInterval + arrowLength);
                g.DrawString(axisXString, GetFontStyle(7, FontStyle.Regular), Brushes.Black, axisXTypePoint);

                //Y축 Type
                string axisYString = "Type";
                float axisYTypeWidth = g.MeasureString(axisYString, GetFontStyle(7, FontStyle.Regular)).Width;//Y축 레이블 글자의 너비
                float axisYTypeHeight = g.MeasureString(axisYString, GetFontStyle(7, FontStyle.Regular)).Height;//Y축 레이블 글자의 너비
                PointF axisYTypePoint = new PointF(_axisXInterval - arrowLength - axisYTypeWidth, _yRectInterval);
                g.DrawString(axisYString, GetFontStyle(7, FontStyle.Regular), Brushes.Black, axisYTypePoint);

                //Ok
                string okString = "OK";
                float okLabelWidth = g.MeasureString(okString, GetFontStyle(8, FontStyle.Bold)).Width;//Y축 레이블 글자의 너비
                float okLabelHeight = g.MeasureString(okString, GetFontStyle(8, FontStyle.Bold)).Height;//Y축 레이블 글자의 너비
                float okRectTop = _DrawChartRect.Y + (float)rectInterval + ((float)rectInterval / 2);
                PointF okDrawPoint = new PointF(_DrawChartRect.X - okLabelWidth - axisYdistance, okRectTop - (okLabelHeight / 2));
                g.DrawString(okString, GetFontStyle(8, FontStyle.Bold), Brushes.Black, okDrawPoint);

                //NG
                string ngString = "NG";
                float ngLabelWidth = g.MeasureString(ngString, GetFontStyle(8, FontStyle.Bold)).Width;//Y축 레이블 글자의 너비
                float ngLabelHeight = g.MeasureString(ngString, GetFontStyle(8, FontStyle.Bold)).Height;//Y축 레이블 글자의 너비
                float ngRectTop = _DrawChartRect.Y + (float)rectInterval * 3 + ((float)rectInterval / 2);
                PointF ngDrawPoint = new PointF(_DrawChartRect.X - ngLabelWidth - axisYdistance, ngRectTop - (ngLabelHeight / 2));
                g.DrawString(ngString, GetFontStyle(8, FontStyle.Bold), Brushes.Black, ngDrawPoint);

                //Warning
                string warningString = "Warning";
                float warningLabelWidth = g.MeasureString(warningString, GetFontStyle(8, FontStyle.Bold)).Width;//Y축 레이블 글자의 너비
                float warningLabelHeight = g.MeasureString(warningString, GetFontStyle(8, FontStyle.Bold)).Height;//Y축 레이블 글자의 너비
                float warningRectTop = _DrawChartRect.Y + (float)rectInterval * 5 + ((float)rectInterval / 2);
                PointF warningDrawPoint = new PointF(_DrawChartRect.X - warningLabelWidth - axisYdistance, warningRectTop - (warningLabelHeight / 2));
                g.DrawString(warningString, GetFontStyle(8, FontStyle.Bold), Brushes.Black, warningDrawPoint);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void SetDrawChartRect()
        {
            _DrawChartRect = new RectangleF(_axisXInterval, _axisYInterval, (pnlChart.Width - _axisXInterval - _xRectInterval) - _xRectInterval, pnlChart.Height - _axisYInterval);
        }
    }
}
