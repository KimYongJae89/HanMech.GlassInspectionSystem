using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMechUtility
{
    public class HMTimer
    {
        private bool m_bStarted;           // 
        private DateTime m_tmStart;

        public void Reset()
        {
            m_bStarted = false;
            m_tmStart = DateTime.Now;
        }


        public bool IsTimeOut(int nInterval)
        {
            if (!m_bStarted)
            {
                m_tmStart = DateTime.Now;
                m_bStarted = true;
            }
            TimeSpan tsSpan = DateTime.Now - m_tmStart;
            if (tsSpan.TotalMilliseconds > nInterval)
            {
                m_bStarted = false;
                Reset();
                return true;
            }
            else
                return false;
        }

        public void Wait(int nMiliseconds)
        {
            if (!m_bStarted)
            {
                m_tmStart = DateTime.Now;
                m_bStarted = true;
            }
            do
            {
                System.Threading.Thread.Sleep(20);
                Application.DoEvents();
            } while (!IsTimeOut(nMiliseconds));
            Reset();
        }
    }
}

