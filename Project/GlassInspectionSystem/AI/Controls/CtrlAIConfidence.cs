using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI;
using enumType;

namespace AI.Controls
{
    public partial class CtrlAIConfidence : UserControl
    {
        private AIProperty _aiProperty = new AIProperty();
        public CtrlAIConfidence()
        {
            InitializeComponent();
        }

        private void CtrlAIConfidence_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            foreach (eDefectType type in Enum.GetValues(typeof(eDefectType)))
                cbxAlram.Items.Add(type.ToString());

            chkUseDefect.Checked = _aiProperty.UseClass;
            chkUseDefect.Text = _aiProperty.DefectName.ToString();
            txtConfidence.Text = _aiProperty.Confidence.ToString();
            SetAlarmType(_aiProperty.AlarmType);
        }

        public void Setproperty(AIProperty property)
        {
            _aiProperty.DefectName = property.DefectName;
            _aiProperty.UseClass = property.UseClass;
            _aiProperty.Confidence = property.Confidence;
            _aiProperty.AlarmType = property.AlarmType;
        }

        private void SetAlarmType(eDefectType type)
        {
            for (int i = 0; i < cbxAlram.Items.Count; i++)
            {
                eDefectType alramType = (eDefectType)Enum.Parse(typeof(eDefectType), cbxAlram.Items[i] as string);
                if (type == alramType)
                    cbxAlram.SelectedIndex = i;
            }
        }

        public AIProperty GetProperty(int index)
        {
            _aiProperty.UseClass = chkUseDefect.Checked;
            _aiProperty.DefectIndex = index;
            _aiProperty.DefectName = chkUseDefect.Text;
            _aiProperty.Confidence = Convert.ToDouble(txtConfidence.Text);
            _aiProperty.AlarmType = (eDefectType)Enum.Parse(typeof(eDefectType), cbxAlram.SelectedItem as string);

            return _aiProperty;
        }
    }
}
