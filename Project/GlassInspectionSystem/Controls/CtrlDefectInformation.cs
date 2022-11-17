using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlassInspectionSystem.Class;
using HMechLogLib;
using System.Reflection;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlDefectInformation : UserControl
    {
        public string _savePath = "";
        private string SavePath
        {
            get { return _savePath; }
            set { _savePath = value; }
        }

        public Action<string, int, Rectangle> UpdateDefectDisplayDele;

        public CtrlDefectInformation()
        {
            InitializeComponent();
        }

        private void DefectInformationControl_Load(object sender, EventArgs e)
        {
        }

        private delegate void UpdateDefectDele(List<Defect> defectList, string savePath);
        public void UpdateDefect(List<Defect> defectList, string savePath)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateDefectDele callback = UpdateDefect;
                    BeginInvoke(callback, defectList, savePath);
                    return;
                }

                gvDefectInfoList.Rows.Clear();

                _savePath = savePath;

                foreach (Defect defect in defectList)
                {
                    string camNo = defect.CamNo.ToString();
                    //string defectType = defect.DefectType.ToString();
                    string defectType = defect.DefectName;
                    string x = defect.BoundingPosX.ToString("F3");
                    string y = defect.BoundingPosY.ToString("F3");
                    string width = defect.BoundingWidth.ToString("F3");
                    string height = defect.BoundingHeight.ToString("F3");
                    string confidence = defect.Confidence.ToString("F3");
                    string inspType = defect.InspectionType.ToString();

                    string[] row = { camNo, defectType, x, y, width, height, confidence, inspType };

                    gvDefectInfoList.Rows.Add(row);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                Logger.WriteException(eLogType.ERROR, err);
            }
        }

        private void gvDefectInfoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int row = gvDefectInfoList.CurrentCell.RowIndex;
        }

        private void gvDefectInfoList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectRowIndex = gvDefectInfoList.CurrentCell.RowIndex;
            if (selectRowIndex < 0)
                return;

            int camNo = Convert.ToInt32(gvDefectInfoList.Rows[selectRowIndex].Cells[0].FormattedValue.ToString());
            double x = Convert.ToSingle(gvDefectInfoList.Rows[selectRowIndex].Cells[2].FormattedValue.ToString());
            double y = Convert.ToSingle(gvDefectInfoList.Rows[selectRowIndex].Cells[3].FormattedValue.ToString());
            double width = Convert.ToSingle(gvDefectInfoList.Rows[selectRowIndex].Cells[4].FormattedValue.ToString());
            double height = Convert.ToSingle(gvDefectInfoList.Rows[selectRowIndex].Cells[5].FormattedValue.ToString());
            //Cam DefectType x y width height
            Rectangle defectRoi = new Rectangle((int)x, (int)y, (int)width, (int)height);
            if (UpdateDefectDisplayDele != null)
                UpdateDefectDisplayDele(_savePath, camNo, defectRoi);
        }

        private delegate void ActiveDataGridViewDele(bool isActive);
        public void ActiveDataGridView(bool isActive)
        {
            if (this.InvokeRequired)
            {
                ActiveDataGridViewDele callback = ActiveDataGridView;
                BeginInvoke(callback, isActive);
                return;
            }
            gvDefectInfoList.Enabled = isActive;
        }
    }
}