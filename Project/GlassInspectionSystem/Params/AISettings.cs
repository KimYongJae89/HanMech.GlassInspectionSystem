using AI;
using enumType;
using GlassInspectionSystem.Class;
using HMechUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GlassInspectionSystem.Params
{

    public class AISettings
    {
        public List<AIProperty> _aIPropertyList = new List<AIProperty>();
        public List<AIProperty> AIPropertyList
        {
            get { return _aIPropertyList; }
            set { _aIPropertyList = value; }
        }

        private string _configName = " ";
        public string ConfigName
        {
            get { return _configName; }
            set { _configName = value; }
        }

        private string _namesName = " ";
        public string NamesName
        {
            get { return _namesName; }
            set { _namesName = value; }
        }
        
        private string _weightName = " ";
        public string WeightName
        {
            get { return _weightName; }
            set { _weightName = value; }
        }

        public void Save(bool isBackup = false)
        {
            string strPath = System.IO.Directory.GetCurrentDirectory() + "\\config"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.
            Utility.CreateDir(strPath); // config 폴더가 있는 지 검사, 없으면 만듭니다.
            strPath += "\\AlSettings.cfg"; // 파일 위치를 추가합니다.

            if (isBackup)
            {
                string backupPath = strPath + ".bak"; // 백업 주소를 만듭니다.

                if (File.Exists(backupPath)) // 백업 파일이 존재할 경우
                {
                    File.Delete(backupPath); // 제거합니다.
                }
                File.Move(strPath, backupPath); // 현재 세이브 파일을 백업합니다.
            }

            XmlDocument xmlDocument = new XmlDocument();

            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement configElement = xmlDocument.CreateElement("", "AlConfig", "");

            XmlHelper.SetValue(configElement, "ConfigName", ConfigName.ToString());
            XmlHelper.SetValue(configElement, "NamesName", NamesName.ToString());
            XmlHelper.SetValue(configElement, "WeightName", WeightName.ToString());

            xmlDocument.AppendChild(configElement);

            SaveParams(configElement);

            xmlDocument.Save(strPath);
        }

        public void Load()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\config"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.
            Utility.CreateDir(path); // config 폴더가 있는 지 검사, 없으면 만듭니다.
            string fileName = path + "\\AlSettings.cfg"; // 파일 위치를 추가합니다.

            CreateAIFolder();
            if (!File.Exists(fileName))
            {
                //LoadNamesFile();
                //foreach (eDefectClass defectClass in Enum.GetValues(typeof(eDefectClass)))
                //{
                //    AIProperty property = new AIProperty();
                //    property.Type = defectClass;
                //    Settings.Instance().AISettings.AIPropertyList.Add(property);
                //}
                Save();
            }
            else
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                XmlElement configElement = xmlDocument.DocumentElement;

                ConfigName = XmlHelper.GetValue(configElement, "ConfigName", ConfigName);
                NamesName = XmlHelper.GetValue(configElement, "NamesName", NamesName);
                WeightName = XmlHelper.GetValue(configElement, "WeightName", WeightName);

                LoadParams(configElement);
            }
        }

        private void SaveAIProperty(XmlElement configElement)
        {
            string name = "AIProperty";
            int count = 0;
            foreach (AIProperty aiProperty in Settings.Instance().AISettings.AIPropertyList)
            {
                string elementName = name;
                XmlElement aiPropertyElement = configElement.OwnerDocument.CreateElement("", elementName, "");
                configElement.AppendChild(aiPropertyElement);

                XmlHelper.SetValue(aiPropertyElement, "DefectIndex", aiProperty.DefectIndex.ToString());
                XmlHelper.SetValue(aiPropertyElement, "DefectName", aiProperty.DefectName.ToString());
                //XmlHelper.SetValue(aiPropertyElement, "Type", aiProperty.Type.ToString());
                XmlHelper.SetValue(aiPropertyElement, "Confidence", aiProperty.Confidence.ToString());
                XmlHelper.SetValue(aiPropertyElement, "UseClass", aiProperty.UseClass.ToString());
                XmlHelper.SetValue(aiPropertyElement, "AlarmType", aiProperty.AlarmType.ToString());
                count++;
            }
        }

        private void LoadAIProperty(XmlElement configElement)
        {
            string name = "AIProperty";
            string elementName = name;

            for (int i = 0; i < configElement.ChildNodes.Count; i++)
            {
                XmlNodeList nodeList = configElement.ChildNodes[i].ChildNodes;

                string defectIndex = XmlHelper.GetValue(nodeList, "DefectIndex", Settings.Instance().AISettings.AIPropertyList[i].DefectIndex.ToString());
                string defectName = XmlHelper.GetValue(nodeList, "DefectName", Settings.Instance().AISettings.AIPropertyList[i].DefectName.ToString());
                //string type = XmlHelper.GetValue(nodeList, "Type", Settings.Instance().AISettings.AIPropertyList[i].Type.ToString());
                string confidence = XmlHelper.GetValue(nodeList, "Confidence", Settings.Instance().AISettings.AIPropertyList[i].Confidence.ToString());
                string useClass = XmlHelper.GetValue(nodeList, "UseClass", Settings.Instance().AISettings.AIPropertyList[i].UseClass.ToString());
                string alarmType = XmlHelper.GetValue(nodeList, "AlarmType", Settings.Instance().AISettings.AIPropertyList[i].AlarmType.ToString());

                Settings.Instance().AISettings.AIPropertyList[i].DefectIndex = Convert.ToInt16(defectIndex);
                Settings.Instance().AISettings.AIPropertyList[i].DefectName = defectName;
                //Settings.Instance().AISettings.AIPropertyList[i].Type = (eDefectClass)Enum.Parse(typeof(eDefectClass), type);
                Settings.Instance().AISettings.AIPropertyList[i].Confidence = Convert.ToDouble(confidence);
                Settings.Instance().AISettings.AIPropertyList[i].UseClass = Convert.ToBoolean(useClass);
                Settings.Instance().AISettings.AIPropertyList[i].AlarmType = (eDefectType)Enum.Parse(typeof(eDefectType), alarmType);
            }
        }

        public void SaveParams(XmlElement configElement)
        {
            XmlElement AISettingsElement = configElement.OwnerDocument.CreateElement("", "Settings", "");
            configElement.AppendChild(AISettingsElement);

            SaveAIProperty(AISettingsElement);
        }

        public void LoadParams(XmlElement configElement)
        {
            XmlElement AISettingsElement = configElement["Settings"];
            if (AISettingsElement == null)
                return;

            //foreach (eDefectClass defectClass in Enum.GetValues(typeof(eDefectClass)))
            //{
            //    AIProperty property = new AIProperty();
            //    property.Type = defectClass;
            //    Settings.Instance().AISettings.AIPropertyList.Add(property);
            //}

            //foreach (AIProperty item in AISettingsElement)
            //{
            //    AIProperty property = new AIProperty();
            //    Settings.Instance().AISettings.AIPropertyList.Add(property);
            //}

            XmlNodeList propertyList = AISettingsElement.GetElementsByTagName("AIProperty");
            for (int i = 0; i < propertyList.Count; i++)
            {
                AIProperty property = new AIProperty();
                property.DefectIndex = i;
                Settings.Instance().AISettings.AIPropertyList.Add(property);
            }
            //foreach (AIProperty aiProperty in Settings.Instance().AISettings.AIPropertyList)
            //{
            //    AIProperty property = new AIProperty();
            //    Settings.Instance().AISettings.AIPropertyList.Add(property);
            //}
            LoadAIProperty(AISettingsElement);
        }

        private void CreateAIFolder()
        {
            string strPath = System.IO.Directory.GetCurrentDirectory() + "\\AI"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.
            Utility.CreateDir(strPath); // config 폴더가 있는 지 검사, 없으면 만듭니다.

            Utility.CreateDir(strPath + @"\Config");
            Utility.CreateDir(strPath + @"\Names");
            Utility.CreateDir(strPath + @"\Weights");
        }

        //public AIProperty GetAIProperty(eDefectClass type)
        public AIProperty GetAIProperty(int defectIndex)
        {
            foreach (AIProperty property in this._aIPropertyList)
            {
                //if(property.Type == type)
                if (property.DefectIndex == defectIndex)
                {
                    return property;
                }
            }
            return null;
        }
    }
}
