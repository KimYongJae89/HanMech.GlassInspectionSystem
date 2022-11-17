using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace HMechUtility
{
    public class Utility
    {
        public static bool CreateDir(string strDir)
        {
            try
            {
                if (!Directory.Exists(strDir))
                {
                    Directory.CreateDirectory(strDir);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        public static bool IsFileExist(string fileName)
        {
            FileInfo info = new FileInfo(fileName);
            return info.Exists;
        }

        /// <summary>
        /// Memory 값을 구함
        /// </summary>
        /// <param name="memoryStyle"></param>
        /// <returns></returns>
        public static int GetMemoryValue(string memoryStyle)
        {
            ManagementClass cls = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection moc = cls.GetInstances();
            int mem = 0;

            foreach (ManagementObject mo in moc)
            {
                mem = int.Parse(mo[memoryStyle].ToString());
            }

            return mem;
        }

        /// <summary>
        /// HardDisk의 사용량(%)을 구함
        /// </summary>
        /// <param name="strTargetDriver"></param>
        /// <returns></returns>
        public static float GetHDDPercent(string strTargetDriver)
        {
            float nPercent = 0;

            try
            {
                // 드라이브 정보에 엑세스하여 모든 논리 드라이브의 이름을 가져옴
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    if (drive.Name == strTargetDriver)
                    {
                        // 드라이브 전체 용량
                        float maxVolume = Convert.ToSingle(drive.TotalSize / 1000000);
                        // 사용중인 용량 ( 전체 용량 - 사용 가능한 용량 )
                        float usingVolume = Convert.ToSingle((drive.TotalSize - drive.AvailableFreeSpace) / 1000000);

                        nPercent = Convert.ToSingle((float)((float)usingVolume / (float)maxVolume) * 100);
                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception : " + e.Message);
            }

            return nPercent;
        }

        /// <summary>
        /// 해당 주소의 하위 폴더와 하위 파일을 모두 제거합니다.
        /// </summary>
        /// <param name="dir">제거할 폴더(파일)의 상위 폴더를 지목합니다.</param>
        /// <param name="searchPattern">확장명을 의미합니다.</param>
        /// <param name="day">Log가 기록된 날을 인자값으로 요청합니다.</param>
        public static void DeleteFilesInDirectory(string directory, string searchPattern, int day)
        {
            DirectoryInfo di = new DirectoryInfo(directory);    // 인자값으로 들어온 절대 주소를 객체로 정의합니다.
            Dirs(di, searchPattern, day);                 // 삭제를 시작합니다.
        }

        /// <summary>
        /// 해당 주소의 하위 폴더를 검색하여 반복문을 실행합니다.
        /// </summary>
        /// <param name="dirinfo">제거할 폴더(파일)의 상위 폴더를 지목합니다.</param>
        /// <param name="searchPattern">확장명을 의미합니다.</param>
        /// <param name="day">Log가 기록된 날을 인자값으로 요청합니다.</param>
        private static void Dirs(DirectoryInfo dirinfo, string searchPattern, int day)
        {
            DirectoryInfo[] di = dirinfo.GetDirectories(); // 받은 주소의 하위 폴더 주소들을 반환합니다.

            if (di.Length < 1) // 반환받은 주소가 없을 경우 빠져나갑니다.
            {
                return;
            }

            for (int i = 0; i < di.Length; i++) // 반환받은 주소의 수 만큼 반복문을 실행시킵니다.
            {
                if (di[i].GetFiles().Count<FileInfo>() < 1 && di[i].GetDirectories().Count<DirectoryInfo>() < 1) // 하위 폴더가 빈 폴더면 삭제
                {
                    di[i].Delete();
                }
                else
                {
                    DelFiles(di[i], searchPattern, day); // 하위 폴더의 파일을 지움
                    Dirs(di[i], searchPattern, day); //  하위 폴더로 재귀호출
                }
            }
        }

        private static void DelFiles(DirectoryInfo diinfo, string searchPattern, int day)
        {
            try
            {
                DateTime dayAgoTime = DateTime.Now.AddSeconds(-(day * 3600 * 24)); // 인자로 받은 날을 객체로 정의합니다.
                DateTime agoTime = DateTime.Now.AddSeconds(-(1 * 3600 * 24)); // bmp 삭제를 위해 1일 지나면 삭제
                foreach (FileInfo fileName in diinfo.GetFiles()) // 해당 폴더에 파일 갯수 만큼 반복합니다.
                {
                    if (searchPattern.Equals(".*")) //확장명이 .*일 경우 모든 파일을 제거합니다.
                    {
                        DateTime dt = fileName.CreationTime; // 파일을 만들었던 시간을 객체로 정의합니다.

                        if (dayAgoTime > dt) // 사용자가 설정한 날보다 더 이전에 만들었을 경우
                        {
                            fileName.Delete(); // 파일을 제거합니다.
                        }
                    }
                    else if (fileName.Extension.Equals(searchPattern)) // 인자값의 확장명이 반복문의 확장명과 같을 경우 제거합니다.
                    {
                        DateTime dt = fileName.CreationTime; // 파일을 만들었던 시간을 객체로 정의합니다.
                        if (dayAgoTime > dt) // 사용자가 설정한 날보다 더 이전에 만들었을 경우
                        {
                            fileName.Delete(); // 파일을 제거합니다.
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
