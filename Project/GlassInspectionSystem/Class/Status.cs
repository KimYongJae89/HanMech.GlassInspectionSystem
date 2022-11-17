using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AI;
using Device.PLC;
using enumType;
using GlassInspectionSystem.Class;
using GlassInspectionSystem.Forms;

namespace GlassInspectionSystem.Class
{
    
    public class PLCStatus
    {
        public List<PLCAddressProperty> PlcReceivePacketList = new List<PLCAddressProperty>();

        public PLCAddressProperty GetPLCPacketProperty(ePLCAddress address)
        {
            if (PlcReceivePacketList.Count <= 0)
                return null;

            return PlcReceivePacketList[(int)address];
        }

        public string GetPacketValue(ePLCAddress address)
        {
            if (PlcReceivePacketList.Count <= 0)
                return null;

            return PlcReceivePacketList[(int)address].Value;
        }

        public bool GlassIn()
        {
            PLCAddressProperty property = GetPLCPacketProperty(ePLCAddress.PLC_GLASS_INPUT);
            int intValue = Convert.ToInt16(property.Value);
            return Convert.ToBoolean(intValue);
        }
    }

    public class Status
    {
        public PLCStatus Plc = new PLCStatus();
        public Forms Forms = new Forms();

        private eProgramMode _programMode = eProgramMode.Stop;

        public eProgramMode ProgramMode
        {
            get { return _programMode; }
            set { _programMode = value; }
        }

        private DateTime _nowTime = DateTime.Now;

        public DateTime NowTime
        {
            get
            {
                if (Settings.Instance().Operation.UsePLCTime)
                    return _nowTime;

                return DateTime.Now;
            }
            set
            {
                if (Settings.Instance().Operation.UsePLCTime)
                    _nowTime = value;
                else
                    _nowTime = DateTime.Now;
            }
        }

        private int _okCount = 0;

        public int OKCount
        {
            get { return _okCount; }
            set { _okCount = value; }
        }

        private int _ngCount = 0;

        public int NGCount
        {
            get { return _ngCount; }
            set { _ngCount = value; }
        }

        private int _warningCount = 0;

        public int WarningCount
        {
            get { return _warningCount; }
            set { _warningCount = value; }
        }

        private bool _testSensor = false;

        public bool TestSensor
        {
            get { return _testSensor; }
            set { _testSensor = value; }
        }

        private eOriginDirection _cornerDirection = eOriginDirection.LeftTop;
        public eOriginDirection CornerDirection
        {
            get { return _cornerDirection; }
            set { _cornerDirection = value; }
        }

        private Point _cornerPoint = new Point();
        public Point cornerPoint
        {
            get { return _cornerPoint; }
            set { _cornerPoint = value; }
        }

        private static Status _instance = null;

        public static Status Instance()
        {
            if (_instance == null)
            {
                _instance = new Status();
            }

            return _instance;
        }

        private bool _isGlassInCheck = false;

        public bool IsGlassInCheck
        {
            get { return _isGlassInCheck; }
            set { _isGlassInCheck = value; }
        }
    }

    public class Forms
    {
        private FormAISettings _formAISettings = null;
        private FormBrokenSettings _formBrokenSettings = null;
        private FormContourSettings _formContourSettings = null;
        private FormEdgeDetect _formEdgeDetect = null;
        private FormSettings _formSettings = null;
        private FormStatus _formStatus = null;
        private FormCamEdit _formCamEdit = null;
        private FormPLCAddressSettings _formPLCAddressSettings = null;
        private FormRuleProcessImage _formRuleProcessImage = null;
        private FormForkDetect _formForkDetect = null;
        private FormDisplayDefect _formDisplayDefect = null;

        public void OpenAISettings()
        {
            if (_formAISettings == null)
            {
                _formAISettings = new FormAISettings();
                _formAISettings.SetConfig(Settings.Instance().AISettings.ConfigName, Settings.Instance().AISettings.NamesName, Settings.Instance().AISettings.WeightName);
                _formAISettings.SetAIPropertyList(Settings.Instance().AISettings.AIPropertyList);
                _formAISettings.CloseEventDelegate = AIFormClose;
                _formAISettings.ConfigDelegate = SetAiConfig;
                _formAISettings.Show();
            }
        }

        public void OpenPLCAddressSettings()
        {
            if (_formPLCAddressSettings == null)
            {
                _formPLCAddressSettings = new FormPLCAddressSettings();
                _formPLCAddressSettings.SetPLCPropertyList(Status.Instance().Plc.PlcReceivePacketList);
                _formPLCAddressSettings.CloseEventDelegate = PLCAddressFormClose;
                _formPLCAddressSettings.Show();
            }
        }

        public void OpenRuleProcessImage()
        {
            if (_formRuleProcessImage == null)
            {
                _formRuleProcessImage = new FormRuleProcessImage();
                _formRuleProcessImage.CloseEventDelegate = () => this._formRuleProcessImage = null;
                _formRuleProcessImage.Show();
            }
        }

        private void SetAiConfig(string config, string names, string weight)
        {
            Settings.Instance().AISettings.ConfigName = config;
            Settings.Instance().AISettings.NamesName = names;
            Settings.Instance().AISettings.WeightName = weight;

            if ( (config != null) && (names != null) && (weight != null))
                Inspection.Instance().MechAIInitialize();
        }

        private void AIFormClose(List<AIProperty> aiProperty)
        {
            Settings.Instance().AISettings.AIPropertyList.Clear();

            Settings.Instance().AISettings.AIPropertyList = aiProperty.ToArray().ToList();

            this._formAISettings = null;
        }

        private void PLCAddressFormClose(List<PLCAddressProperty> plcProperty)
        {
            Status.Instance().Plc.PlcReceivePacketList.Clear();
            Status.Instance().Plc.PlcReceivePacketList = SortProperty(plcProperty.ToArray().ToList());
            this._formPLCAddressSettings = null;
        }

        public void OpenBrokenSettings(bool isForkDetect)
        {
            if (_formBrokenSettings == null)
            {
                _formBrokenSettings = new FormBrokenSettings();
                _formBrokenSettings.CloseEventDelegate = () => this._formBrokenSettings = null;
                if (isForkDetect)
                {
                    _formBrokenSettings.Text = "Fork Broken Parameters Settings";
                    _formBrokenSettings.SetParams(Settings.Instance().AlgorithmSettings.Fork.BrokenParams, true);
                }
                else
                {
                    _formBrokenSettings.Text = "Edge Broken Parameters Settings";
                    _formBrokenSettings.SetParams(Settings.Instance().AlgorithmSettings.Edge.BrokenParams, false);
                }
                _formBrokenSettings.ShowDialog();
            }
        }

        public void OpenContourSettings(bool isForkDetect)
        {
            if (_formContourSettings == null)
            {
                _formContourSettings = new FormContourSettings();
                _formContourSettings.CloseEventDelegate = () => this._formContourSettings = null;
                if (isForkDetect)
                {
                    _formContourSettings.Text = "Fork Contour Parameters Settings";
                    _formContourSettings.SetParams(Settings.Instance().AlgorithmSettings.Fork.ContourParams, true);
                }
                else
                {
                    _formContourSettings.Text = "Edge Contour Parameters Settings";
                    _formContourSettings.SetParams(Settings.Instance().AlgorithmSettings.Edge.ContourParams, false);
                }
                _formContourSettings.ShowDialog();
            }
        }

        public void OpenEdgeDetect()
        {
            if (_formEdgeDetect == null)
            {
                _formEdgeDetect = new FormEdgeDetect();
                _formEdgeDetect.CloseEventDelegate = () => this._formEdgeDetect = null;
                _formEdgeDetect.Show();
            }
        }

        public void OpenForkDetect()
        {
            if (_formForkDetect == null)
            {
                _formForkDetect = new FormForkDetect();
                _formForkDetect.SetParam(Settings.Instance().Operation.CamProp);
                _formForkDetect.CloseEventDelegate = () => this._formForkDetect = null;
                _formForkDetect.Show();
            }
        }

        public void OpenSettings()
        {
            if (_formSettings == null)
            {
                _formSettings = new FormSettings();
                _formSettings.CloseEventDelegate = () => this._formSettings = null;
                _formSettings.Show();
            }
        }

        public void UpdateDefectDisplay(string filePath, int camNo, Rectangle defectRoi)
        {
            if (_formDisplayDefect == null)
            {
                _formDisplayDefect = new FormDisplayDefect();
                _formDisplayDefect.CloseEventDelegate = () => this._formDisplayDefect = null;
                _formDisplayDefect.UpdateDisplayImage(filePath, camNo, defectRoi);
                _formDisplayDefect.Show();
            }
            else
            {
                _formDisplayDefect.UpdateDisplayImage(filePath, camNo, defectRoi);
            }
        }

        public void SetGlassInOutInSettingsForm(bool isGlassIn)
        {
            if (_formSettings != null)
            {
                _formSettings.SetGlassInOut(isGlassIn);
            }
        }

        public void OpenStatus()
        {
            if (_formStatus == null)
            {
                _formStatus = new FormStatus();
                _formStatus.CloseEventDelegate = () => this._formStatus = null;
                _formStatus.Show();
            }
        }

        public void OpenCamEdit(int camCount, bool isExistConfig)
        {
            if (_formCamEdit == null)
            {
                _formCamEdit = new FormCamEdit();
                _formCamEdit.IsExistConfig = isExistConfig;
                _formCamEdit.CloseEventDelegate = () => this._formCamEdit = null;
                _formCamEdit.SetCamCount(camCount);

                if (isExistConfig == false)
                {
                    if (_formCamEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _formSettings = new FormSettings();
                        _formSettings.IsBootingOpen = true;
                        _formSettings.CloseEventDelegate = () => this._formSettings = null;
                        if (_formSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        { }
                    }
                }
                else
                {
                    _formCamEdit.Show();
                }
            }
        }

        public List<PLCAddressProperty> SortProperty(List<PLCAddressProperty> propertyList)
        {
            List<PLCAddressProperty> sortPropertyList = new List<PLCAddressProperty>();

            foreach (ePLCAddress address in Enum.GetValues(typeof(ePLCAddress)))
            {
                foreach (PLCAddressProperty property in propertyList)
                {
                    if (address == property.AddressName)
                    {
                        PLCAddressProperty copy = property.Copy();
                        sortPropertyList.Add(copy);
                    }
                }
            }
            return sortPropertyList;
        }
    }
}