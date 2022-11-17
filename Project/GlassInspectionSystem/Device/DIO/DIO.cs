using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using HMechLogLib;

namespace Device.DIO
{
    /// <summary>
    /// DIO 보드의 종류 열거형
    /// </summary>
    public enum eDIOBoardType
    {
        TMC,
        PMI
    }

    /// <summary>
    /// DIO 클래스의 생성자입니다.
    /// </summary>
    public class DIO
    {
        public eDIOBoardType AppliedBoard = eDIOBoardType.PMI;
        public ushort CARD_NO = 0;
        private uint _uModel = 0;
        private uint _uComm = 0;
        private uint _uDiNum = 0;
        private uint _uDoNum = 0;
        private int _conCounts = 0;

        public System.Threading.Thread T;
        public bool Stop;

        public const int IN_Glass_InOut = 0;
        public const int OUT_Light_OnOff = 0;
        
        public DIO()
        {

        }
        /// <summary>
        /// DIO 클래스의 생성자입니다.
        /// </summary>
        /// <param name="dioBoard">어떤 보드를 사용할지 입력합니다.</param>
        public DIO(eDIOBoardType dioBoard, int cardNo)
        {
            if (!LoadDevice(dioBoard, cardNo)) // 입력한 장치를 읽어옵니다.
                Logger.Write(eLogType.ERROR, "Failed Loading IO Device");
            else
            {
                //T = new Thread(ThreadRun); // 성공하면 스레드를 시작합니다.
                //T.Start();
            }
        }

        /// <summary>
        /// DIO 클래스의 소멸자입니다.
        /// </summary>
        ~DIO()
        {
            Stop = true;
            if (T != null)
                T.Join();

            TMCAEDLL.AIO_UnloadDevice();
        }

        /// <summary>
        /// 장치를 연결합니다.
        /// </summary>
        /// <param name="dioBoard">어떤 보드를 사용할지 입력합니다.</param>
        public bool LoadDevice(eDIOBoardType dioBoard, int cardNo)
        {
            CARD_NO = (ushort)cardNo;
            if (dioBoard == eDIOBoardType.TMC)
            {
                _conCounts = TMCAEDLL.AIO_LoadDevice();

                if (_conCounts < 0)
                    return false;

                TMCAEDLL.AIO_BoardInfo(CARD_NO, ref _uModel, ref _uComm, ref _uDiNum, ref _uDoNum);

                switch (_uModel)
                {
                    case tmcDef.TMC_AE:
                        break;

                    default:
                        break;
                }
                AppliedBoard = eDIOBoardType.TMC;
            }
            else if (dioBoard == eDIOBoardType.PMI)
            {
                pmiMApi.pmiSysLoad(pmiMApiDefs.TMC_FALSE, ref _conCounts);

                if (_conCounts < 0)
                    return false;
                else
                    _conCounts = pmiMApi.pmiConParamLoad(null);

                AppliedBoard = eDIOBoardType.PMI;
            }
            return true;
        }

        /// <summary>
        /// 해당 채널에 비트를 셋합니다.
        /// </summary>
        /// <param name="Channel">몇 채널인지 선택합니다.</param>
        /// <param name="bON">비트를 On 할 것인지 Off 할것인지 선택합니다.</param>
        public void SetOutBit(ushort channel, bool on)
        {
            ushort udata = (ushort)(on ? tmcDef.CMD_ON : tmcDef.CMD_OFF);

            if (AppliedBoard == eDIOBoardType.TMC)
                TMCAEDLL.AIO_pmiDoSetBit(CARD_NO, channel, udata);
            else
                pmiMApi.pmiDoSetBit(CARD_NO, channel, udata);
        }

        /// <summary>
        /// 해당 채널에 비트를 확인합니다.
        /// </summary>
        /// <param name="Channel">몇 채널인지 선택합니다.</param>
        public bool IsIOBit(ushort channel)
        {
            if (AppliedBoard == eDIOBoardType.TMC)
            {
                ushort udata = 0;
                TMCAEDLL.AIO_GetDIBit(CARD_NO, channel, ref udata);
                return udata == 1;
            }
            else
            {
                uint udata = 0;
                int iRet = pmiMApi.pmiDiGetData(CARD_NO, 0, ref udata);
                int temp = ((int)udata >> channel);
                return ((int)temp & 1) == 1;
            }
        }

        /// <summary>
        /// 스레드에서 실행할 함수입니다.
        /// </summary>
        public void ThreadRun()
        {
            while (!Stop)
                System.Threading.Thread.Sleep(100);
        }

        /// <summary>
        /// 클래스에서 사용하고 있는 메모리들을 해제합니다.
        /// </summary>
        public void Terminate()
        {
            Stop = true;

            if (T != null)
                T.Join();

            TMCAEDLL.AIO_UnloadDevice();
        }

        /// <summary>
        /// 메인의 DIO에서 in_glass_sensor 비트를 확인합니다.
        /// </summary>
        public bool IsTrigger()
        {
            return IsIOBit((ushort)DIO.IN_Glass_InOut);
        }
    }
}