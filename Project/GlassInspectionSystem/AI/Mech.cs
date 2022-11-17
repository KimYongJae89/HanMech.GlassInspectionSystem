using HMechLogLib;
using MechAI;
using MechAI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class MechProperty
    {
        private string _configFile = "";
        public string ConfigFile
        {
            get { return _configFile; }
            set { _configFile = value; }
        }

        private string _weightsFile = "";
        public string WeightsFile
        {
            get { return _weightsFile; }
            set { _weightsFile = value; }
        }

        private string _namesFile = "";
        public string NamesFile
        {
            get { return _namesFile; }
            set { _namesFile = value; }
        }
       
    }

    public class Mech
    {
        List<AIProperty> _aiProperty = new List<AIProperty>();
        MECHAIForHanmech _mech = null;
        private object _objLock = new object();

        public void Initialize(string configFile, string namesFile, string weightFile, List<AIProperty> aiPropertyList)
        {
            if (_mech != null)
            {
                _mech.Terminate();
                _mech = null;
            }

            SetAIProperty(aiPropertyList);

            if(_aiProperty.Count == 0)
            {
                string message = "AI Property is null.";
                Logger.Write(eLogType.ERROR, message, DateTime.Now);
                System.Windows.Forms.MessageBox.Show(message);
                return;
            }
            if (File.Exists(configFile) == false)
            {
                string message = "AI Mech ConfigFile is not exist.";
                Logger.Write(eLogType.ERROR, message, DateTime.Now);
                System.Windows.Forms.MessageBox.Show(message);
                return;
            }

            if (File.Exists(namesFile) == false)
            {
                string message = "AI Mech NamesFile is not exist.";
                Logger.Write(eLogType.ERROR, message, DateTime.Now);
                System.Windows.Forms.MessageBox.Show(message);
                return;
            }

            if (File.Exists(weightFile) == false)
            {
                string message = "AI Mech WeightFile is not exist.";
                Logger.Write(eLogType.ERROR, message, DateTime.Now);
                System.Windows.Forms.MessageBox.Show(message);
                return;
            }

            _mech = new MECHAIForHanmech(configFile, weightFile);
        }

        public void SetAIProperty(List<AIProperty> property)
        {
            _aiProperty.Clear();
            this._aiProperty = property.ToArray().ToList();
        }

        public List<MechItem> Process(byte[] imageData)
        {
            if(_mech == null)
            {
                return null;
            }

            lock (_objLock)
            {
                return _mech.Process(imageData);
            }
        }

        public bool IsInitialized()
        {
            if (_mech == null)
                return false;
            else
                return true;
        }

        public void Dispose()
        {
            if (_mech != null)
                _mech.Dispose();
        }
    }
}
