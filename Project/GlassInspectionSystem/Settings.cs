using GlassInspectionSystem.Class;
using Device.Camera;
using Device.PLC;
using GlassInspectionSystem.Params;
using HMechLogLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace GlassInspectionSystem
{
    public class Settings
    {
        private OperationSettings _operation = new OperationSettings();
        public OperationSettings Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        private AlgorithmSettings _algorithmSettings = new AlgorithmSettings();
        public AlgorithmSettings AlgorithmSettings
        {
            get { return _algorithmSettings; }
            set { _algorithmSettings = value; }
        }

        private AISettings _aiSettings = new AISettings();
        public AISettings AISettings
        {
            get { return _aiSettings; }
            set { _aiSettings = value; }
        }

        private PLCAddressSettings _plcAddressSettings = new PLCAddressSettings();
        public PLCAddressSettings PLCAddressSettings
        {
            get { return _plcAddressSettings; }
            set { _plcAddressSettings = value; }
        }

        private static Settings _instance = null;

        public static Settings Instance()
        {
            if (_instance == null)
            {
                _instance = new Settings();
            }

            return _instance;
        }

        public void Save()
        {
            _operation.Save();
            _algorithmSettings.Save();
            //_aiSettings.Save();
            _plcAddressSettings.Save();
        }

        public bool Load()
        {
            bool ret = true;
            ret = _operation.Load();
            if (ret)
            {
                _algorithmSettings.Load();
                _aiSettings.Load();
                _plcAddressSettings.Load();
            }

            return ret;
        }
    }
}
