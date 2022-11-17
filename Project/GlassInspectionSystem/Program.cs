using GlassInspectionSystem.Class;
using GlassInspectionSystem.Forms;
using HMechLogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlassInspectionSystem
{
    internal static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Logger.Initialize();
            bool ret = Settings.Instance().Load();
            if (!ret)
            {
                Application.Run(new FormCamMessage());
            }

            Machine.Instance().Initialize();
            DBManager.Instance().Initialize();
            //Status.Instance().Plc.LoadPacketList(Settings.Instance().PLCAddressSettings.PLCAddressPropertyList);

            if (Settings.Instance().Operation.UseAi)
                Inspection.Instance().Initialize();

            Logger.Write(eLogType.SEQ, "=====================Program Start=====================");
            Logger.Write(eLogType.INSPECTION, "=====================Program Start=====================");
            Logger.Write(eLogType.PLC, "=====================Program Start=====================");
            Logger.Write(eLogType.DEVICE, "=====================Program Start=====================");
            Application.Run(FormMain.Instance());
        }
    }
}