using GlassInspectionSystem.Class;
using GlassInspectionSystem.Controls;
using Device.Camera;
using Device.PLC;
using HMechUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using enumType;
using Device.DIO;

namespace GlassInspectionSystem.Forms
{
    public partial class FormSettings : Form
    {
        private FormAISettings _formAISettings = new FormAISettings();

        public Action CloseEventDelegate;
        private bool _formLoading = true;
        private bool _isCamNumChange = false;

        private bool _isBootingOpen = false;

        public bool IsBootingOpen
        {
            get { return _isBootingOpen; }
            set { _isBootingOpen = value; }
        }

        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            _formLoading = true;
            _isCamNumChange = true;

            InitializeDevice();
            LoadDeviceSettings();

            InitializeInspection();
            LoadInspectionSettings();

            InitializeInfo();
            LoadInfoSettings();

            EnableCheckDevice();
            EnableCheckInspection();

            SetBooting();

            _isCamNumChange = false;
            _formLoading = false;
        }

        private void SetBooting()
        {
            if (this._isBootingOpen)
            {
                cbxCamNo.Enabled = false;
                nupdnExposure.Enabled = false;
                btnCameraApply.Enabled = false;
                btnLightOn.Enabled = false;
                btnLightOff.Enabled = false;
                ckbEnableShading.Enabled = false;
                cbxShading.Enabled = false;
            }
        }

        private void InitializeInspection()
        {
            foreach (eAIInspectionType type in Enum.GetValues(typeof(eAIInspectionType)))
                cbxAiType.Items.Add(type.ToString());
        }

        private void InitializeDevice()
        {
            foreach (eCameraType type in Enum.GetValues(typeof(eCameraType)))
                cbxCameraType.Items.Add(type.ToString());

            for (int i = 0; i < Settings.Instance().Operation.CamCount; i++)
            {
                cbxCamNo.Items.Add(i.ToString());
                cbxCamNo.SelectedIndex = 0;
            }

            foreach (eShadingType type in Enum.GetValues(typeof(eShadingType)))
                cbxShading.Items.Add(type.ToString());

            cbxShading.SelectedIndex = 0;

            foreach (ePLCType type in Enum.GetValues(typeof(ePLCType)))
                cbxPLCType.Items.Add(type.ToString());

            foreach (eLineRateType type in Enum.GetValues(typeof(eLineRateType)))
                cbxLineRateType.Items.Add(type.ToString());

            foreach (eInspectionTriggerType type in Enum.GetValues(typeof(eInspectionTriggerType)))
                cbxInspectionTriggerType.Items.Add(type.ToString());

            foreach (eDIOBoardType type in Enum.GetValues(typeof(eDIOBoardType)))
                cbxDioBoardType.Items.Add(type.ToString());

            foreach (eLightType type in Enum.GetValues(typeof(eLightType)))
                cbxLightType.Items.Add(type.ToString());

            foreach (eSerialLightType type in Enum.GetValues(typeof(eSerialLightType)))
                cbxSerialLightType.Items.Add(type.ToString());

            string[] portList = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string comPort in portList)
                cbxComPort.Items.Add(comPort);
        }

        private void InitializeInfo()
        {
            foreach (eImageType type in Enum.GetValues(typeof(eImageType)))
                cbxSaveSubImageType.Items.Add(type.ToString());

            foreach (eImageType type in Enum.GetValues(typeof(eImageType)))
                cbxSaveAICropImageType.Items.Add(type.ToString());

            foreach (eImageType type in Enum.GetValues(typeof(eImageType)))
                cbxSaveMergeImageType.Items.Add(type.ToString());

            foreach (eOriginDirection type in Enum.GetValues(typeof(eOriginDirection)))
                cbxOriginDirection.Items.Add(type.ToString());

            foreach (eDiskType type in Enum.GetValues(typeof(eDiskType)))
                cbxHardDisk1.Items.Add(type.ToString());

            foreach (eDiskType type in Enum.GetValues(typeof(eDiskType)))
                cbxHardDisk2.Items.Add(type.ToString());
        }

        private void LoadDeviceSettings()
        {
            txtCamCount.Text = Convert.ToString(Settings.Instance().Operation.CamCount);

            for (int i = 0; i < cbxCameraType.Items.Count; i++)
            {
                eCameraType type = (eCameraType)Enum.Parse(typeof(eCameraType), cbxCameraType.Items[i] as string);
                if (type == Settings.Instance().Operation.CameraType)
                    cbxCameraType.SelectedIndex = i;
            }
            if (cbxCamNo.Items.Count != 0)
                cbxCamNo.SelectedIndex = 0;
         
            nupdnExposure.Value = GetExpose(cbxCamNo.SelectedIndex);
            ckbEnableShading.Checked = IsEnableShading(cbxCamNo.SelectedIndex);

            for (int i = 0; i < cbxPLCType.Items.Count; i++)
            {
                ePLCType type = (ePLCType)Enum.Parse(typeof(ePLCType), cbxPLCType.Items[i] as string);
                if (type == Settings.Instance().Operation.PlcType)
                    cbxPLCType.SelectedIndex = i;
            }

            txtIPAddress.Text = Settings.Instance().Operation.PlcIPAddress;
            txtPlcPortNumber.Text = Convert.ToString(Settings.Instance().Operation.PlcPortNumber);

            for (int i = 0; i < cbxLineRateType.Items.Count; i++)
            {
                eLineRateType type = (eLineRateType)Enum.Parse(typeof(eLineRateType), cbxLineRateType.Items[i] as string);
                if (type == Settings.Instance().Operation.LineRateType)
                    cbxLineRateType.SelectedIndex = i;
            }

            txtConstantVel.Text = Settings.Instance().Operation.ConstantVel.ToString();

            for (int i = 0; i < cbxInspectionTriggerType.Items.Count; i++)
            {
                eInspectionTriggerType type = (eInspectionTriggerType)Enum.Parse(typeof(eInspectionTriggerType), cbxInspectionTriggerType.Items[i] as string);
                if (type == Settings.Instance().Operation.InspectionTriggerType)
                    cbxInspectionTriggerType.SelectedIndex = i;
            }

            for (int i = 0; i < cbxDioBoardType.Items.Count; i++)
            {
                eDIOBoardType type = (eDIOBoardType)Enum.Parse(typeof(eDIOBoardType), cbxDioBoardType.Items[i] as string);
                if (type == Settings.Instance().Operation.DioBoardType)
                    cbxDioBoardType.SelectedIndex = i;
            }
            txtDioCardNo.Text = Settings.Instance().Operation.DioCardNo.ToString();

            txtStartGrabDelay.Text = Settings.Instance().Operation.StartGrabDelay.ToString();
            txtEndGrabDelay.Text = Settings.Instance().Operation.EndGrabDelay.ToString();

            for (int i = 0; i < cbxLightType.Items.Count; i++)
            {
                eLightType type = (eLightType)Enum.Parse(typeof(eLightType), cbxLightType.Items[i] as string);
                if (type == Settings.Instance().Operation.LightType)
                    cbxLightType.SelectedIndex = i;
            }

            for (int i = 0; i < cbxSerialLightType.Items.Count; i++)
            {
                eSerialLightType type = (eSerialLightType)Enum.Parse(typeof(eSerialLightType), cbxSerialLightType.Items[i] as string);
                if (type == Settings.Instance().Operation.SerialLightType)
                    cbxSerialLightType.SelectedIndex = i;
            }

            for (int i = 0; i < cbxComPort.Items.Count; i++)
            {
                if (cbxComPort.Items[i] as string == Settings.Instance().Operation.ComPort)
                    cbxComPort.SelectedIndex = i;
            }

            for (int i = 0; i < cbxBaudRate.Items.Count; i++)
            {
                if (cbxBaudRate.Items[i] as string == Convert.ToString(Settings.Instance().Operation.BaudRate))
                    cbxBaudRate.SelectedIndex = i;
            }
            txtLightValue.Text = Settings.Instance().Operation.LightValue.ToString();
        }

        private void LoadInspectionSettings()
        {
            ckbUseAI.Checked = Settings.Instance().Operation.UseAi;
            for (int i = 0; i < cbxAiType.Items.Count; i++)
            {
                eAIInspectionType type = (eAIInspectionType)Enum.Parse(typeof(eAIInspectionType), cbxAiType.Items[i] as string);
                if (type == Settings.Instance().Operation.AiType)
                    cbxAiType.SelectedIndex = i;
            }

            txtLTCornerSize.Text = Settings.Instance().Operation.LeftTopCornerRectSize.ToString();
            txtLBCornerSize.Text = Settings.Instance().Operation.LeftBottomCornerRectSize.ToString();
            txtRTCornerSize.Text = Settings.Instance().Operation.RightTopCornerRectSize.ToString();
            txtRBCornerSize.Text = Settings.Instance().Operation.RightBottomCornerRectSize.ToString();

            //Edge
            ckbUseEdgeBroken.Checked = Settings.Instance().Operation.UseEdgeBrokenAlgorithm;
            ckbUseEdgeContour.Checked = Settings.Instance().Operation.UseEdgeContourAlgorithm;
            //Fork
            ckbUseForkBroken.Checked = Settings.Instance().Operation.UseForkBrokenAlgorithm;
            ckbUseForkContour.Checked = Settings.Instance().Operation.UseForkContourAlgorithm;
        }

        private void LoadInfoSettings()
        {
            txtGlassWidth.Text = Settings.Instance().Operation.GlassWidth.ToString();
            txtGlassHeight.Text = Settings.Instance().Operation.GlassHeight.ToString();
            txtFov.Text = Settings.Instance().Operation.Fov.ToString();
            txtThumbnailRatio.Text = Settings.Instance().Operation.ThumbnailRatio.ToString();

            for (int i = 0; i < cbxOriginDirection.Items.Count; i++)
            {
                eOriginDirection type = (eOriginDirection)Enum.Parse(typeof(eOriginDirection), cbxOriginDirection.Items[i] as string);
                if (type == Settings.Instance().Operation.OriginDirection)
                    cbxOriginDirection.SelectedIndex = i;
            }

            ckbTwoEdge.Checked = Settings.Instance().Operation.TwoEdge;
            txtCameraInterval.Text = Settings.Instance().Operation.CameraInterval.ToString();

            ckbUseGrabEdgeDetect.Checked = Settings.Instance().Operation.UseGrabEdgeDetect;
            ckbSaveSubImage.Checked = Settings.Instance().Operation.SaveSubImage;
            ckbSaveCropImage.Checked = Settings.Instance().Operation.SaveCropImage;
            ckbSaveMergeImage.Checked = Settings.Instance().Operation.SaveMergeImage;

            for (int i = 0; i < cbxSaveSubImageType.Items.Count; i++)
            {
                eImageType type = (eImageType)Enum.Parse(typeof(eImageType), cbxSaveSubImageType.Items[i] as string);
                if (type == Settings.Instance().Operation.SaveSubImageType)
                    cbxSaveSubImageType.SelectedIndex = i;
            }

            for (int i = 0; i < cbxSaveAICropImageType.Items.Count; i++)
            {
                eImageType type = (eImageType)Enum.Parse(typeof(eImageType), cbxSaveAICropImageType.Items[i] as string);
                if (type == Settings.Instance().Operation.SaveCropImageType)
                    cbxSaveAICropImageType.SelectedIndex = i;
            }


            for (int i = 0; i < cbxSaveMergeImageType.Items.Count; i++)
            {
                eImageType type = (eImageType)Enum.Parse(typeof(eImageType), cbxSaveMergeImageType.Items[i] as string);
                if (type == Settings.Instance().Operation.SaveMergeImageType)
                    cbxSaveMergeImageType.SelectedIndex = i;
            }

            for (int i = 0; i < cbxHardDisk1.Items.Count; i++)
            {
                eDiskType type = (eDiskType)Enum.Parse(typeof(eDiskType), cbxHardDisk1.Items[i] as string);
                if (type == Settings.Instance().Operation.SaveDisk1Type)
                    cbxHardDisk1.SelectedIndex = i;
            }

            for (int i = 0; i < cbxHardDisk2.Items.Count; i++)
            {
                eDiskType type = (eDiskType)Enum.Parse(typeof(eDiskType), cbxHardDisk2.Items[i] as string);
                if (type == Settings.Instance().Operation.SaveDisk2Type)
                    cbxHardDisk2.SelectedIndex = i;
            }

            ckbUseTestMode.Checked = Settings.Instance().Operation.UseTestMode;
            ckbDrawCorner.Checked = Settings.Instance().Operation.DrawCorner;
            ckbUseByPass.Checked = Settings.Instance().Operation.UseByPass;
            ckbUsePLCTime.Checked = Settings.Instance().Operation.UsePLCTime;

            txtLogSavePeriod.Text = Settings.Instance().Operation.LogSavePeriod.ToString();
            txtImageSavePeriod.Text = Settings.Instance().Operation.ImageSavePeriod.ToString();
            txtImageFolderPath.Text = Settings.Instance().Operation.ImageFolderPath;
        }

        private void EnableCheckDevice()
        {
            eCameraType camType = (eCameraType)Enum.Parse(typeof(eCameraType), cbxCameraType.SelectedItem as string);
            if (camType == eCameraType.None)
            {
                cbxCamNo.Enabled = false;
                nupdnExposure.Enabled = false;
                btnCameraApply.Enabled = false;
                ckbEnableShading.Enabled = false;
                cbxShading.Enabled = false;
                btnOpenCameraSettings.Enabled = false;
            }
            else
            {
                cbxCamNo.Enabled = true;
                nupdnExposure.Enabled = true;
                btnCameraApply.Enabled = true;
                ckbEnableShading.Enabled = true;
                cbxShading.Enabled = true;
                btnOpenCameraSettings.Enabled = true;
            }

            ePLCType plcType = (ePLCType)Enum.Parse(typeof(ePLCType), cbxPLCType.SelectedItem as string);
            if (plcType == ePLCType.None)
            {
                txtIPAddress.Enabled = false;
                txtPlcPortNumber.Enabled = false;
            }
            else
            {
                txtIPAddress.Enabled = true;
                txtPlcPortNumber.Enabled = true;
            }

            eLineRateType lineRateType = (eLineRateType)Enum.Parse(typeof(eLineRateType), cbxLineRateType.SelectedItem as string);
            if (lineRateType == eLineRateType.ConstantVel)
            {
                txtConstantVel.Enabled = true;
            }
            else
            {
                txtConstantVel.Enabled = false;
            }

            eLightType lightType = (eLightType)Enum.Parse(typeof(eLightType), cbxLightType.SelectedItem as string);
            if (lightType == eLightType.None)
            {
                cbxSerialLightType.Enabled = false;
                cbxComPort.Enabled = false;
                cbxBaudRate.Enabled = false;
                btnLightOn.Enabled = false;
                btnLightOff.Enabled = false;
            }
            else if (lightType == eLightType.IO)
            {
                cbxSerialLightType.Enabled = false;
                cbxComPort.Enabled = false;
                cbxBaudRate.Enabled = false;
                btnLightOn.Enabled = true;
                btnLightOff.Enabled = true;
            }
            else
            {
                cbxSerialLightType.Enabled = true;
                cbxComPort.Enabled = true;
                cbxBaudRate.Enabled = true;
                btnLightOn.Enabled = true;
                btnLightOff.Enabled = true;
            }

            eInspectionTriggerType triggerType = (eInspectionTriggerType)Enum.Parse(typeof(eInspectionTriggerType), cbxInspectionTriggerType.SelectedItem as string);
            if(triggerType == eInspectionTriggerType.SENSOR)
            {
                txtStartGrabDelay.Enabled = true;
                txtEndGrabDelay.Enabled = true;
                cbxDioBoardType.Enabled = true;
                txtDioCardNo.Enabled = true;
            }
            else
            {
                txtStartGrabDelay.Enabled = false;
                txtEndGrabDelay.Enabled = false;
                cbxDioBoardType.Enabled = false;
                txtDioCardNo.Enabled = false;
            }

            eSerialLightType serialLightType = (eSerialLightType)Enum.Parse(typeof(eSerialLightType), cbxSerialLightType.SelectedItem as string);

            if(serialLightType == eSerialLightType.CCS_RS485)
            {
                btnSetLightValue.Enabled = true;
                txtLightValue.Enabled = true;
            }
            else
            {
                btnSetLightValue.Enabled = false;
                txtLightValue.Enabled = false;
            }
        }

        private void EnableCheckInspection()
        {
            if (ckbUseAI.Checked)
            {
                cbxAiType.Enabled = true;
                btnAIProperty.Enabled = true;
            }
            else
            {
                cbxAiType.Enabled = false;
                btnAIProperty.Enabled = false;
            }
        }

        private void btnCameraApply_Click(object sender, EventArgs e)
        {
            if (cbxCamNo.SelectedIndex < -1)
                return;

            int camNo = cbxCamNo.SelectedIndex;
            double expose = Convert.ToDouble(nupdnExposure.Text);
            Settings.Instance().Operation.CamProp[camNo].Exposure = expose;
        }

        private void PnlDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formLoading)
                return;
            EnableCheckDevice();
            SetBooting();
        }

        private void PnlInspection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formLoading)
                return;
            EnableCheckInspection();
        }

        private void pnlInspection_Changed(object sender, EventArgs e)
        {
            if (_formLoading)
                return;
            EnableCheckInspection();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            MessageBox.Show("Save Completed");
        }

        private void SaveSettings()
        {
            Settings.Instance().Operation.CameraType = (eCameraType)Enum.Parse(typeof(eCameraType), cbxCameraType.SelectedItem as string);

            int camNo = Convert.ToInt32(cbxCamNo.SelectedItem as string);
            double expose = Convert.ToDouble(nupdnExposure.Value);

            if (Settings.Instance().Operation.CameraType != eCameraType.None)
            {
                Machine.Instance().CameraManager.SetExpose(camNo, expose);
                Settings.Instance().Operation.CamProp[camNo].Exposure = expose;
            }
        
            Settings.Instance().Operation.PlcType = (ePLCType)Enum.Parse(typeof(ePLCType), cbxPLCType.SelectedItem as string);
            Settings.Instance().Operation.PlcIPAddress = txtIPAddress.Text;
            Settings.Instance().Operation.PlcPortNumber = Convert.ToInt32(txtPlcPortNumber.Text);

            Settings.Instance().Operation.LineRateType = (eLineRateType)Enum.Parse(typeof(eLineRateType), cbxLineRateType.SelectedItem as string);

            Settings.Instance().Operation.ConstantVel = Convert.ToInt32(txtConstantVel.Text);

            Settings.Instance().Operation.InspectionTriggerType = (eInspectionTriggerType)Enum.Parse(typeof(eInspectionTriggerType), cbxInspectionTriggerType.SelectedItem as string);
            Settings.Instance().Operation.DioBoardType = (eDIOBoardType)Enum.Parse(typeof(eDIOBoardType), cbxDioBoardType.SelectedItem as string);

            Settings.Instance().Operation.DioCardNo = Convert.ToInt32(txtDioCardNo.Text);

            Settings.Instance().Operation.StartGrabDelay = Convert.ToInt32(txtStartGrabDelay.Text);
            Settings.Instance().Operation.EndGrabDelay = Convert.ToInt32(txtEndGrabDelay.Text);

            Settings.Instance().Operation.LightType = (eLightType)Enum.Parse(typeof(eLightType), cbxLightType.SelectedItem as string);
            Settings.Instance().Operation.LightValue = Convert.ToInt32(txtLightValue.Text);
            Settings.Instance().Operation.SerialLightType = (eSerialLightType)Enum.Parse(typeof(eSerialLightType), cbxSerialLightType.SelectedItem as string);
            Settings.Instance().Operation.ComPort = cbxComPort.SelectedItem as string;
            Settings.Instance().Operation.BaudRate = Convert.ToInt32(cbxBaudRate.SelectedItem as string);

            Settings.Instance().Operation.UseAi = ckbUseAI.Checked;
            Settings.Instance().Operation.AiType = (eAIInspectionType)Enum.Parse(typeof(eAIInspectionType), cbxAiType.SelectedItem as string);

            Settings.Instance().Operation.LeftTopCornerRectSize = Convert.ToInt32(txtLTCornerSize.Text);
            Settings.Instance().Operation.LeftBottomCornerRectSize = Convert.ToInt32(txtLBCornerSize.Text);
            Settings.Instance().Operation.RightTopCornerRectSize = Convert.ToInt32(txtRTCornerSize.Text);
            Settings.Instance().Operation.RightBottomCornerRectSize = Convert.ToInt32(txtRBCornerSize.Text);

            Settings.Instance().Operation.UseEdgeBrokenAlgorithm = ckbUseEdgeBroken.Checked;
            Settings.Instance().Operation.UseEdgeContourAlgorithm = ckbUseEdgeContour.Checked;

            Settings.Instance().Operation.UseForkBrokenAlgorithm = ckbUseForkBroken.Checked;
            Settings.Instance().Operation.UseForkContourAlgorithm = ckbUseForkContour.Checked;

            Settings.Instance().Operation.GlassWidth = Convert.ToInt32(txtGlassWidth.Text);
            Settings.Instance().Operation.GlassHeight = Convert.ToInt32(txtGlassHeight.Text);
            Settings.Instance().Operation.Fov = Convert.ToInt32(txtFov.Text);
            Settings.Instance().Operation.TwoEdge = ckbTwoEdge.Checked;
            Settings.Instance().Operation.CameraInterval = Convert.ToInt32(txtCameraInterval.Text);
            Settings.Instance().Operation.ThumbnailRatio = Convert.ToInt32(txtThumbnailRatio.Text);

            Settings.Instance().Operation.OriginDirection = (eOriginDirection)Enum.Parse(typeof(eOriginDirection), cbxOriginDirection.SelectedItem as string);

            Settings.Instance().Operation.UseGrabEdgeDetect = ckbUseGrabEdgeDetect.Checked;
            Settings.Instance().Operation.SaveSubImage = ckbSaveSubImage.Checked;
            Settings.Instance().Operation.SaveCropImage = ckbSaveCropImage.Checked;

            Settings.Instance().Operation.SaveSubImageType = (eImageType)Enum.Parse(typeof(eImageType), cbxSaveSubImageType.SelectedItem as string);
            Settings.Instance().Operation.SaveCropImageType = (eImageType)Enum.Parse(typeof(eImageType), cbxSaveAICropImageType.SelectedItem as string);
            Settings.Instance().Operation.SaveMergeImageType = (eImageType)Enum.Parse(typeof(eImageType), cbxSaveMergeImageType.SelectedItem as string);

            Settings.Instance().Operation.SaveDisk1Type = (eDiskType)Enum.Parse(typeof(eDiskType), cbxHardDisk1.SelectedItem as string);
            Settings.Instance().Operation.SaveDisk2Type = (eDiskType)Enum.Parse(typeof(eDiskType), cbxHardDisk2.SelectedItem as string);

            Settings.Instance().Operation.UseTestMode = ckbUseTestMode.Checked;
            Settings.Instance().Operation.DrawCorner = ckbDrawCorner.Checked;
            Settings.Instance().Operation.UseByPass = ckbUseByPass.Checked;
            Settings.Instance().Operation.UsePLCTime = ckbUsePLCTime.Checked;

            Settings.Instance().Operation.LogSavePeriod = Convert.ToInt32(txtLogSavePeriod.Text);
            Settings.Instance().Operation.ImageSavePeriod = Convert.ToInt32(txtImageSavePeriod.Text);
            Settings.Instance().Operation.ImageFolderPath = txtImageFolderPath.Text;

            Settings.Instance().Save();
        }

        private void btnEdgeDetect_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenEdgeDetect();
        }

        private void btnLightOn_Click(object sender, EventArgs e)
        {
            Machine.Instance().LightOn(true);
        }

        private void btnLightOff_Click(object sender, EventArgs e)
        {
            Machine.Instance().LightOn(false);
        }

        private void btnEdgeBrokenProperty_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenBrokenSettings(false);
        }

        private void btnChippingProperty_Click(object sender, EventArgs e)
        {
        }

        private void btnCrackProperty_Click(object sender, EventArgs e)
        {
        }

        private void btnDBFolderPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtImageFolderPath.Text = dialog.SelectedPath;
            }
        }

        private decimal GetExpose(int camNo)
        {
            if (Settings.Instance().Operation.CamProp.Count == 0)
                return 0;
            double expose = Settings.Instance().Operation.CamProp[camNo].Exposure;
            return Convert.ToDecimal(expose);
        }

        private void cbxCamNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isCamNumChange = true;

            nupdnExposure.Value = GetExpose(cbxCamNo.SelectedIndex);
            ckbEnableShading.Checked = IsEnableShading(cbxCamNo.SelectedIndex);

            _isCamNumChange = false;
        }

        private bool IsEnableShading(int camNo)
        {
            if (Settings.Instance().Operation.CamProp.Count == 0)
                return false;

            return Machine.Instance().CameraManager.IsEnableShading(camNo);
        }

        private void btnAIProperty_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenAISettings();
        }

        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void cbxGlassInOut_CheckedChanged(object sender, EventArgs e)
        {
            Status.Instance().TestSensor = ckbGlassInOut.Checked;
        }

        private void nupdnExposure_ValueChanged(object sender, EventArgs e)
        {
            if (_formLoading)
                return;

            int camNo = cbxCamNo.SelectedIndex;
            double expose = Convert.ToDouble(nupdnExposure.Text);
            Machine.Instance().CameraManager.SetExpose(camNo, expose);
        }

        private void ckbEnableShadingEnableShading_CheckedChanged(object sender, EventArgs e)
        {
            if (_isCamNumChange)
                return;
            if (_formLoading)
                return;

            Machine.Instance().CameraManager.SetEnableShading(cbxCamNo.SelectedIndex, ckbEnableShading.Checked);
        }

        private void cbxShading_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isCamNumChange)
                return;
            if (_formLoading)
                return;

            eShadingType selectedType = (eShadingType)Enum.Parse(typeof(eShadingType), cbxShading.SelectedItem as string);

            Machine.Instance().CameraManager.Shading(cbxCamNo.SelectedIndex, selectedType);

            for (int i = 0; i < cbxShading.Items.Count; i++)
            {
                eShadingType type = (eShadingType)Enum.Parse(typeof(eShadingType), cbxShading.Items[i] as string);
                if (type == eShadingType.Off)
                    cbxShading.SelectedIndex = i;
            }
        }

        private void btnOpenCameraSettings_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenCamEdit(Settings.Instance().Operation.CamCount, true);
        }

        private void cbxLineRateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formLoading)
                return;
            EnableCheckDevice();
        }

        private void btnEdgeContourProperty_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenContourSettings(false);
        }

        public void SetGlassInOut(bool isGlassIn)
        {
            ckbGlassInOut.Checked = isGlassIn;
        }

        private void btnSetLightValue_Click(object sender, EventArgs e)
        {
            int lightValue = Convert.ToInt32(txtLightValue.Text);
            Machine.Instance().LightManager.SetLightValue(lightValue);
        }

        private void btnOpenPLCAddressSetting_Click(object sender, EventArgs e)
        {
            //Status.Instance().Forms.OpenPLCAddressSetting();
            Status.Instance().Forms.OpenPLCAddressSettings();
        }

        private void ckbTwoEdge_CheckedChanged(object sender, EventArgs e)
        {
            txtCameraInterval.Enabled = ckbTwoEdge.Checked;
        }

        private void btnOpenViewer_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenRuleProcessImage();
        }

        private void btnForkBrokenProperty_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenBrokenSettings(true);
        }

        private void btnForkContourProperty_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenContourSettings(true);
        }

        private void btnForkDetect_Click(object sender, EventArgs e)
        {
            Status.Instance().Forms.OpenForkDetect();
        }
    }
}