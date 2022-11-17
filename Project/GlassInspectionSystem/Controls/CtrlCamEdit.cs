using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Device.Camera;
using System.Reflection;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlCamEdit : UserControl
    {
        private bool _isLoading = false;
        private CameraProperty _property = null;

        public CtrlCamEdit()
        {
            InitializeComponent();
        }

        private void CtrlCamEdit_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            InitializeInformation();
            LoadDeviceProperty();
            _isLoading = false;
        }

        public void SetProperty(CameraProperty property)
        {
            _property = property.Copy();
        }

        public CameraProperty GetProperty()
        {
            CameraProperty property = new CameraProperty();

            this._property.CamName = txtCamName.Text;
            this._property.CamAddress = txtCamAddress.Text;
            this._property.SerialNumber = txtSerialNumber.Text;
            this._property.Exposure = Convert.ToDouble(nupdnExposure.Text);
            this._property.Offset = Convert.ToInt32(txtOffset.Text);
            this._property.Width = Convert.ToInt32(txtWidth.Text);
            this._property.Height = Convert.ToInt32(txtHeight.Text);

            return this._property;
        }

        private void InitializeInformation()
        {
            try
            {
             
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void LoadDeviceProperty()
        {
            try
            {
                if (_property == null)
                    return;

                txtCamName.Text = _property.CamName;
                txtCamAddress.Text = _property.CamAddress;
                txtSerialNumber.Text = _property.SerialNumber;
                nupdnExposure.Value = Convert.ToDecimal(_property.Exposure.ToString("F3"));
                txtOffset.Text = _property.Offset.ToString();
                txtWidth.Text = _property.Width.ToString();
                txtHeight.Text = _property.Height.ToString();
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void Value_Changed(object sender, EventArgs e)
        {
            try
            {
                if (_isLoading)
                    return;

                _property.CamName = txtCamName.Text;
                _property.CamAddress = txtCamAddress.Text;
                _property.SerialNumber = txtSerialNumber.Text;
                _property.Exposure = Convert.ToDouble(nupdnExposure.Text);
                _property.Offset = Convert.ToInt32(txtOffset.Text);
                _property.Width = Convert.ToInt32(txtWidth.Text);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }
    }
}
