﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Management; //System.Management Dll 추가
using System.Timers;
using HMechUtility.Controls;
using HMechUtility;
using System.Reflection;

namespace GlassInspectionSystem.Controls
{
    public partial class CtrlSystemInformation : UserControl
    {
        public HMPercentChart HMPercentChartDriveC = null;
        public HMPercentChart HMPercentChartDriveD = null;

        public HMProgressBar HMCpuProgressBar = null;
        public HMProgressBar HMMemoryProgressBar = null;
        private delegate void InvokeHMProgressBarDele(HMProgressBar pbar, int percent);

        private PerformanceCounter _cpuCounter = null;
        private System.Threading.Timer _timer = null;

        public CtrlSystemInformation()
        {
            InitializeComponent();
        }

        private void CtrlSystemInformation_Load(object sender, EventArgs e)
        {
            AddControl();
            _timer = new System.Threading.Timer(UpdateSystemUsage, null, 0, 1000);
        }

        private void AddControl()
        {
            try
            {
                HMPercentChartDriveC = new HMPercentChart();
                HMPercentChartDriveC.Dock = DockStyle.Fill;
                pnlDriveC.Controls.Add(HMPercentChartDriveC);

                HMPercentChartDriveD = new HMPercentChart();
                HMPercentChartDriveD.Dock = DockStyle.Fill;
                pnlDriveD.Controls.Add(HMPercentChartDriveD);

                CreateProgressBar(ref HMCpuProgressBar);
                pnlCPU.Controls.Add(HMCpuProgressBar);

                CreateProgressBar(ref HMMemoryProgressBar);
                pnlMemory.Controls.Add(HMMemoryProgressBar);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void CreateProgressBar(ref HMProgressBar progressBar)
        {
            progressBar = new HMProgressBar();
            progressBar.Width = 200;                    // 너비
            progressBar.Fade = 50;                      // 투명도
            progressBar.Location = new Point(20, 0);    // 위치
        }

        public void KillTimer()
        {
            if(_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }

        private void UpdateSystemUsage(object obj)
        {
            //CPU, MEMORY
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            _cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1100);//일정 대기시간을 줘야 Counter가 제대로 출력

            int cpuUsage = Convert.ToInt32(_cpuCounter.NextValue()); // 총 CPU 사용량
            int totalMem = 0; // 총 메모리 KB 단위 
            int freeMem = 0; // 사용 가능 메모리 KB 단위
            int totalMemMB = 0; // 총 메모리 MB 단위 
            int freeMemMB = 0; // 사용 가능 메모리 MB 단위
            int usageMemMB = 0; //사용 중인 메모리 MB 단위
            int usageMemMBPercent = 0; //사용 중인 메모리 비율(%)

            totalMem = Utility.GetMemoryValue("TotalVisibleMemorySize");
            freeMem = Utility.GetMemoryValue("FreePhysicalMemory");
            totalMemMB = MathHelper.ConvertMemKBToMB(totalMem);
            freeMemMB = MathHelper.ConvertMemKBToMB(freeMem);
            usageMemMB = totalMemMB - freeMemMB;
            usageMemMBPercent = Convert.ToInt32(((float)usageMemMB / (float)totalMemMB) * (float)100);
            
            GetProgressBarPercent(HMCpuProgressBar, cpuUsage);
            GetProgressBarPercent(HMMemoryProgressBar, usageMemMBPercent);


            //Drive
            string strDriveC = Settings.Instance().Operation.SaveDisk1Type + ":\\";
            string strDriveD = Settings.Instance().Operation.SaveDisk2Type + ":\\";
            float usagePercentDriveC = Utility.GetHDDPercent(strDriveC);
            float usagePercentDriveD = Utility.GetHDDPercent(strDriveD);

            HMPercentChartDriveC.Title = strDriveC.Substring(0, 1);
            HMPercentChartDriveC.UpdateUI(usagePercentDriveC);

            HMPercentChartDriveD.Title = strDriveD.Substring(0, 1);
            HMPercentChartDriveD.UpdateUI(usagePercentDriveD);
        }

        private void GetProgressBarPercent(HMProgressBar hmPbar, int percent)
        {
            if (hmPbar.InvokeRequired)
            {
                InvokeHMProgressBarDele dele = new InvokeHMProgressBarDele(GetProgressBarPercent);
                hmPbar.BeginInvoke(dele, hmPbar, percent);
                return;
            }
            
            hmPbar.Value = percent;
            hmPbar.Text = percent.ToString();
            Font font = new Font("Microsoft Sans Serif", 7, FontStyle.Bold);
            hmPbar.Font = font;
        }
    }
}
