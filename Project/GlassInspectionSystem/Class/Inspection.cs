using AI;
using Device.Edge;
using Insp;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassInspectionSystem.Class
{
    public class Inspection
    {
        public Mech MechAI = new Mech();
        //public MechCV MechCVAI = new MechCV();
        public AlgorithmManager Algorithms = new AlgorithmManager();
        //public CornerAlgorithms CornerAlgorithms = new CornerAlgorithms();

        private static Inspection _instance;
        public static Inspection Instance()
        {
            if (_instance == null)
                _instance = new Inspection();

            return _instance;
        }

        public void Initialize()
        {
            MechAIInitialize();
        }

        public void MechAIInitialize()
        {
            string strPath = System.IO.Directory.GetCurrentDirectory() + "\\AI"; // 현재 폴더 위치에서 config 폴더 위치를 추가합니다.

            string configFile = Path.Combine(strPath, "Config", Settings.Instance().AISettings.ConfigName);
            string namesFile = Path.Combine(strPath, "Names", Settings.Instance().AISettings.NamesName);
            string weightFile = Path.Combine(strPath, "Weights", Settings.Instance().AISettings.WeightName);
            List<AIProperty> aiPropertyList = Settings.Instance().AISettings.AIPropertyList;

             MechAI.Initialize(configFile, namesFile, weightFile, aiPropertyList);
            //MechCVAI.Initialize(configFile, weightFile);
        }
    }
}
