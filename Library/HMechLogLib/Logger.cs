﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMechLogLib
{
    public class Logger
    {
        private static string _logDir = "";
        private static object _objLock = new object();
        public static void Initialize(string filePath = "")
        {
            if (filePath == "")
                _logDir = Path.Combine(Directory.GetCurrentDirectory(), "log");
            else
                _logDir = filePath;

            if (!Directory.Exists(_logDir))
                Directory.CreateDirectory(_logDir);
        }
        public static void Write(eLogType logType, string logMessage)
        {
            string logpath = getLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(logMessage);
                }
            }
        }

        public static void Write(eLogType logType, string logMessage, DateTime tm)
        {
            string logpath = getLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
            string time = GetTimeString(tm);
            string message = "[" + time + "] " + logMessage;
            message = message.Replace("\r\n", "");

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(message);
                }
            }
        }

        private static string getLogPath(eLogType logType)
        {
            string logPath = string.Format(@"{0}\{1:00}\{2:00}\log_{3:0000}{4:00}{5:00}_" + logType.ToString() + ".log", _logDir, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return logPath;
        }

        public static void WriteException(eLogType logType, Exception exception)
        {
            string logpath = getLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
            string time = GetTimeString(DateTime.Now);
            string logMessage = "[" + time + "] " + exception.StackTrace + " : " + exception.Message;
            logMessage = logMessage.Replace("\r\n", "");
            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(logMessage);
                }
            }
        }

        public static void WriteException(eLogType logType, Exception exception, DateTime tm)
        {
            string logpath = getLogPath(logType);
            string strDir = logpath.Substring(0, logpath.LastIndexOf('\\'));
            string time = GetTimeString(tm);
            string message = "[" + time + "] " + exception.StackTrace + " : " + exception.Message;
            message = message.Replace("\r\n", "");

            if (!Directory.Exists(strDir))
                Directory.CreateDirectory(strDir);

            lock (_objLock)
            {
                StreamWriter log = new StreamWriter(logpath, true);
                using (log)
                {
                    log.WriteLine(message);
                }
            }
        }

        public static string GetTimeString(DateTime tm)
        {
            // 시간은 plc의 시간. ms는 없으므로 pc의 ms
            DateTime now = DateTime.Now;
            string strTime = string.Format(@"{0:00}{1:00} {2:00}:{3:00}:{4:00} / {5:00}:{6:00}:{7:00}.{8:000}ms", tm.Month, tm.Day, tm.Hour, tm.Minute, tm.Second,
                now.Hour, now.Minute, now.Second, now.Millisecond);
            return strTime;
        }
    }
}
