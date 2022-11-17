using enumType;
using GlassInspectionSystem.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    //public enum eAIFrameWork
    //{
    //    None,
    //    Darnet_Yolo2_Cuda9_2,
    //    Darnet_Yolo3_Cuda10_2,
    //}

    //public enum eDefectClass
    //{
    //    Broken_All,
    //    Broken_Part,
    //    Chpping,
    //    EdgeCrack,
    //    InnerCrack,
    //    StarCrack,
    //    Scratch,
    //    Particle,
    //    Mura,
    //    Corner,
    //    Wave,
    //    ShellCrack,
    //}
    
    public class AIProperty
    {
        private int _defectIndex = 0;
        public int DefectIndex
        {
            get { return _defectIndex; }
            set { _defectIndex = value; }
        }

        private string _defectName = "";
        public string DefectName
        {
            get { return _defectName; }
            set { _defectName = value; }
        }

        private double _confidence = 0.0;
        public double Confidence
        {
            get { return _confidence; }
            set { _confidence = value; }
        }

        private bool _useClass = false;
        public bool UseClass
        {
            get { return _useClass; }
            set { _useClass = value; }
        }

        private eDefectType _alarmType = eDefectType.None;
        public eDefectType AlarmType
        {
            get { return _alarmType; }
            set { _alarmType = value; }
        }

        public AIProperty Clone()
        {
            AIProperty copyAIProperty = new AIProperty();

            copyAIProperty.DefectIndex = this.DefectIndex;
            copyAIProperty.DefectName = this.DefectName;
            copyAIProperty.Confidence = this.Confidence;
            copyAIProperty.UseClass = this.UseClass;
            copyAIProperty.AlarmType = this.AlarmType;

            return copyAIProperty;
        }
    }
}
