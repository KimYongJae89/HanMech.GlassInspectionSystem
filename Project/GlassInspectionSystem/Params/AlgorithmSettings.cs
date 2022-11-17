using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Device.Edge;
using Insp;
using HMechUtility;
using GlassInspectionSystem.Class;
using RuleAlgorithm.Broken;
using RuleAlgorithm.Utility;
using RuleAlgorithm.Contour;

namespace GlassInspectionSystem.Params
{
    public class EdgeParameters
    {
        public BrokenParameters BrokenParams = new BrokenParameters();
        public ContourParameters ContourParams = new ContourParameters();
    }

    public class ForkParameters
    {
        public BrokenParameters BrokenParams = new BrokenParameters();
        public ContourParameters ContourParams = new ContourParameters();
    }

    public class AlgorithmSettings
    {
        public EdgeParameters Edge = new EdgeParameters();
        public ForkParameters Fork = new ForkParameters();

        public void Save(bool isBackup = false)
        {
            string strPath = System.IO.Directory.GetCurrentDirectory() + "\\config"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.
            Utility.CreateDir(strPath); // config 폴더가 있는 지 검사, 없으면 만듭니다.
            strPath += "\\Algorithm.cfg"; // 파일 위치를 추가합니다.

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

            XmlElement configElement = xmlDocument.CreateElement("", "AlgorithmConfig", "");
            xmlDocument.AppendChild(configElement);

            SaveParams(configElement);

            xmlDocument.Save(strPath);
        }

        public void Load()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\config"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.
            Utility.CreateDir(path); // config 폴더가 있는 지 검사, 없으면 만듭니다.
            string fileName = path + "\\Algorithm.cfg"; // 파일 위치를 추가합니다.

            if (!File.Exists(fileName))
            {
                // List 관련 초기화
                Save();
            }
            else
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                XmlElement configElement = xmlDocument.DocumentElement;

                LoadParams(configElement);
            }
        }

        public void SaveParams(XmlElement configElement)
        {
            XmlElement algorithmElement = configElement.OwnerDocument.CreateElement("", "Algorithms", "");
            configElement.AppendChild(algorithmElement);

            EdgeDetect.Save(algorithmElement);

            SaveBrokenParameters(algorithmElement, Edge.BrokenParams, "EdgeBrokenDetect");
            SaveBrokenParameters(algorithmElement, Fork.BrokenParams, "ForkBrokenDetect");

            SaveContourParameters(algorithmElement, Edge.ContourParams, "EdgeContourDetect");
            SaveContourParameters(algorithmElement, Fork.ContourParams, "ForkContourDetect");
        }

        public void LoadParams(XmlElement configElement)
        {
            XmlElement algorithmElement = configElement["Algorithms"];
            if (algorithmElement == null)
                return;

            EdgeDetect.Load(algorithmElement);

            LoadBrokenParameters(algorithmElement,ref Edge.BrokenParams, "EdgeBrokenDetect");
            LoadBrokenParameters(algorithmElement, ref Fork.BrokenParams, "ForkBrokenDetect");

            LoadContourParameters(algorithmElement, ref Edge.ContourParams, "EdgeContourDetect");
            LoadContourParameters(algorithmElement, ref Fork.ContourParams, "ForkContourDetect");
        }

        public BrokenParams GetBrokenParams(eEdgeType type, bool isForkDetect)
        {
            if (isForkDetect)
            {
                return Fork.BrokenParams.GetParams(type);
            }
            else
            {
                return Edge.BrokenParams.GetParams(type);
            }
        }

        public ContourParams GetContourParams(eEdgeType type, bool isForkDetect)
        {
            if (isForkDetect)
            {
                return Fork.ContourParams.GetParams(type);
            }
            else
            {
                return Edge.ContourParams.GetParams(type);
            }
        }

        private void SaveBrokenParameters(XmlElement configElement, BrokenParameters brokenParameters, string title)
        {
            XmlElement brokenDetectElement = configElement.OwnerDocument.CreateElement("", title, "");
            configElement.AppendChild(brokenDetectElement);

            brokenParameters.Save(brokenDetectElement);
        }

        private void LoadBrokenParameters(XmlElement configElement, ref BrokenParameters brokenParameters, string title)
        {
            XmlElement brokenElement = configElement[title];
            if (brokenElement == null)
                return;
            BrokenParameters loadParmas = new BrokenParameters();
            loadParmas.Load(brokenElement);
            brokenParameters = loadParmas.Copy();
        }

        private void SaveContourParameters(XmlElement configElement, ContourParameters contourParameters, string title)
        {
            XmlElement contourElement = configElement.OwnerDocument.CreateElement("", title, "");
            configElement.AppendChild(contourElement);

            contourParameters.Save(contourElement);
        }


        private void LoadContourParameters(XmlElement configElement, ref ContourParameters contourParameters, string title)
        {
            XmlElement contourElement = configElement[title];
            if (contourElement == null)
                return;
            ContourParameters loadParmas = new ContourParameters();
            loadParmas.Load(contourElement);
            contourParameters = loadParmas.Copy();
        }
    }
}
