using HMechDBLib;
using HMechUtility;
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
        private string _imageFolder = "";
        public string ImageFolder
        {
            get { return _imageFolder; }
            set { _imageFolder = value; }
        }

        private string _defectViewSize = "100";
        public string DefectViewSize
        {
            get { return _defectViewSize; }
            set { _defectViewSize = value; }
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

        public void Save(bool isBackup = false)
        {
            string strPath = System.IO.Directory.GetCurrentDirectory() + "\\config"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.

            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
            strPath += "\\GlassViewSetup.cfg"; // 파일 위치를 추가합니다.

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

            XmlElement configElement = xmlDocument.CreateElement("", "Config", "");//<Config>생성
            xmlDocument.AppendChild(configElement);

            XmlElement operationElement = configElement.OwnerDocument.CreateElement("", "Operation", "");//<Operation>생성
            configElement.AppendChild(operationElement);

            XmlHelper.SetValue(operationElement, "ImageDBFolderPath", Settings.Instance().ImageFolder.ToString());//<Operation>에다 ImageDBFolderPath 입력
            //XmlHelper.SetValue(operationElement, "DefectImageRatio", Settings.Instance().DefectImageRatio.ToString());

            xmlDocument.Save(strPath);//Save
        }

        public void Load()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\config"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            } // config 폴더가 있는 지 검사, 없으면 만듭니다.

            string fileName = path + "\\GlassViewSetup.cfg"; // 파일 위치를 추가합니다.

            if(!File.Exists(fileName))
            {
                Save();
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlElement configElement = xmlDocument.DocumentElement;

            XmlElement operationElement = configElement["Operation"];
            if (operationElement == null)
                return;

            //<Operation>에 있는 ImageDBFolderPath를 가져옴
            Settings.Instance().ImageFolder = XmlHelper.GetValue(operationElement, "ImageDBFolderPath", Settings.Instance().ImageFolder.ToString());
            //Settings.Instance().DefectImageRatio = XmlHelper.GetValue(operationElement, "DefectImageRatio", Settings.Instance().DefectImageRatio.ToString());
        }
    }
}
