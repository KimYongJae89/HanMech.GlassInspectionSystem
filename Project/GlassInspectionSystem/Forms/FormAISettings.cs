using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI;
using AI.Controls;

namespace GlassInspectionSystem.Forms
{
    public partial class FormAISettings : Form
    {
        private List<CtrlAIConfidence> _displayList = new List<CtrlAIConfidence>();
        public List<AIProperty> AIPropertyList = new List<AIProperty>();

        private List<AIProperty> _tempAIPropertyList = new List<AIProperty>();
        private List<AIProperty> _readNamesList = new List<AIProperty>();
        private bool _changedSelectedIndex = false;
        private int _prevSelectedIndex = -1;
        private int _tempSelectedIndex = 0;

        private string _configSelected = "";
        private string _namesSelected = "";
        private string _weightSelected = "";

        public Action<List<AIProperty>> CloseEventDelegate;
        public Action<string, string, string> ConfigDelegate;

        public FormAISettings()
        {
            InitializeComponent();
        }

        private void FormAISettings_Load(object sender, EventArgs e)
        {
            LoadConfig();

            if (AIPropertyList.Count == 0)
            {
                MessageBox.Show("AI Property is null");
                return;
            }

            LoadAIPropertyConfig(AIPropertyList);
        }

        public void LoadConfig()
        {
            string ConfigDir = System.IO.Directory.GetCurrentDirectory() + @"\AI\Config";
            string WeightsDir = System.IO.Directory.GetCurrentDirectory() + @"\AI\Weights";
            string NamesDir = System.IO.Directory.GetCurrentDirectory() + @"\AI\Names";

            if (Directory.Exists(ConfigDir))
            {
                string[] files = Directory.GetFiles(ConfigDir);
                for (int i = 0; i < files.Count(); i++)
                {
                    string fileName = Path.GetFileName(files[i]);
                    cbxConfig.Items.Add(fileName);
                }
                for (int i = 0; i < cbxConfig.Items.Count; i++)
                {
                    if (cbxConfig.Items[i].ToString() == this._configSelected)
                    {
                        cbxConfig.SelectedIndex = i;
                    }
                }
            }
            if (Directory.Exists(WeightsDir))
            {
                string[] files = Directory.GetFiles(WeightsDir);
                for (int i = 0; i < files.Count(); i++)
                {
                    string fileName = Path.GetFileName(files[i]);
                    cbxWeight.Items.Add(fileName);
                }
                for (int i = 0; i < cbxWeight.Items.Count; i++)
                {
                    if (cbxWeight.Items[i].ToString() == this._weightSelected)
                    {
                        cbxWeight.SelectedIndex = i;
                    }
                }
            }
            if (Directory.Exists(NamesDir))
            {
                string[] files = Directory.GetFiles(NamesDir);
                for (int i = 0; i < files.Count(); i++)
                {
                    string fileName = Path.GetFileName(files[i]);
                    cbxNames.Items.Add(fileName);
                }
                for (int i = 0; i < cbxNames.Items.Count; i++)
                {
                    if (cbxNames.Items[i].ToString() == this._namesSelected)
                    {
                        cbxNames.SelectedIndex = i;
                        _tempSelectedIndex = i;
                    }
                }
            }
        }

        public void SetConfig(string config, string names, string weight)
        {
            _configSelected = config;
            _namesSelected = names;
            _weightSelected = weight;
        }

        private void FormAISettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate(this.AIPropertyList);
        }

        public void SetAIPropertyList(List<AIProperty> propertyList)
        {
            if (propertyList.Count() != 0)
            {
                AIPropertyList.Clear();

                // AI Property Back Up
                AIPropertyList = propertyList.ConvertAll(AIProperty => AIProperty.Clone());


                _tempAIPropertyList = propertyList.ConvertAll(AIProperty => AIProperty.Clone());
            }
            else
            {
                MessageBox.Show("AI Property is null");
                return;
            }
        }

        private void LoadAIPropertyConfig(List<AIProperty> propertyList)
        {
            int _startpos_x = 5;
            int _startpos_y = 30;
            this.Location = new Point(100, 10);

            this.gbxClass.Height = 60;
            gbxClass.Controls.Clear();
            _displayList.Clear();

            
            foreach (AIProperty aiProperty in propertyList)
            {
                CtrlAIConfidence AIConfidence = new CtrlAIConfidence();
                AIConfidence.Setproperty(aiProperty);
                AIConfidence.Location = new Point(_startpos_x, _startpos_y);

                gbxClass.Controls.Add(AIConfidence);
                _displayList.Add(AIConfidence);
                _startpos_y += AIConfidence.Size.Height;
            }

            this.gbxClass.Height += _startpos_y - 40;
            this.Height = this.gbxClass.Height + this.groupBox1.Height + 110;
            if (this.Height > 500)
                this.Height = 500;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyConfig();
            //this.Close();
        }

        private void ApplyConfig()
        {
            //AIPropertyList.Clear();
            _tempAIPropertyList.Clear();

            for (int i = 0; i < _displayList.Count(); i++)
                //AIPropertyList.Add(_displayList[i].GetProperty(i));
                _tempAIPropertyList.Add(_displayList[i].GetProperty(i));

            if (ConfigDelegate != null)
                ConfigDelegate(cbxConfig.SelectedItem as string, cbxNames.SelectedItem as string, cbxWeight.SelectedItem as string);
        }

        public void ReadNamesFile(string namesPath)
        {
            StreamReader sr = new StreamReader(namesPath);
            string readLine = null;

            _readNamesList.Clear();
            int count = 0;
            while ((readLine = sr.ReadLine()) != null)
            {
                AIProperty property = new AIProperty();
                property.DefectIndex = count;
                property.DefectName = readLine;

                _readNamesList.Add(property);

                count++;
            }

            sr.Close();
        }

        private void cbxNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAIPropertyConfig(isChangedNamesComboBox());
        }

        private List<AIProperty> isChangedNamesComboBox()
        {
            string strPath = System.IO.Directory.GetCurrentDirectory() + "\\AI";
            string namesFile = Path.Combine(strPath, "Names", cbxNames.SelectedItem.ToString());

            if (cbxNames.Focused)
            {
                if (_tempSelectedIndex == cbxNames.SelectedIndex)
                    _tempAIPropertyList = AIPropertyList.ConvertAll(AIProperty => AIProperty.Clone());
                else
                {
                    if (namesFile != "")
                    {
                        ReadNamesFile(namesFile);
                        _tempAIPropertyList = _readNamesList.ConvertAll(AIProperty => AIProperty.Clone());
                    }
                    else
                        _tempAIPropertyList = AIPropertyList.ConvertAll(AIProperty => AIProperty.Clone());
                }
            }

            return _tempAIPropertyList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AIPropertyList = _tempAIPropertyList.ConvertAll(AIProperty => AIProperty.Clone());
            Settings.Instance().AISettings.Save();
            this.Close();
        }
    }
}