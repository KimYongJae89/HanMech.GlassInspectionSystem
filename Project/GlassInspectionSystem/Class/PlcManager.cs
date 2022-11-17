using Device.PLC;
using enumType;
using GlassInspectionSystem.Class;
using HMechLogLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace GlassInspectionSystem.Class
{
    public class PLCManager //: IPLC
    {
        const int PLC_SEND_INTER_PACKET_DELAY_IN_THREAD = 5;

        private MELSEC_AsyncTcpIP _melsecTcpIP = null;
        private bool _isTerminate = false;
        private Thread _threadPLC = null;

        // PLC Heart 체크
        public bool IsPLCheartAlive = false;
        private Timer _plcAliveTimer = null;
        const int PLC_ALIVE_CHECK_TIME = 1000;
        private int _prevPLCHeartBit = 0;
        private Stopwatch _plcHeartBitSW = new Stopwatch();

        private bool _pcHeartBeat = false;
        public bool PCHeartBeat
        {
            get { return _pcHeartBeat; }
            set { _pcHeartBeat = value; }
        }

        private int _reConnectCount = 0;
        // Read Command Packet Size 계산
        private int _readStartAddress = 0;
        private int _readCount = 0;

        private UInt16 _writeResultBit = new ushort();

        public void Initialize()
        {
            try
            {
                string ipAddress = Settings.Instance().Operation.PlcIPAddress;
                int port = Settings.Instance().Operation.PlcPortNumber;
                ePLCType plcType = Settings.Instance().Operation.PlcType;

                SetStartAddressAndReadCount();

                _melsecTcpIP = new MELSEC_AsyncTcpIP(ipAddress, port);

                // Read Count, Read Address 등록
                if(plcType == ePLCType.ASCII)
                {
                    _melsecTcpIP.AsciiReadReceiveDelegate = AsciiReadReceive;
                    _melsecTcpIP.AsciiWriteReceiveDelegate = AsciiWriteReceive;
                    _melsecTcpIP.ErrorMessageDelegate = PlcErrorMessage;
                }
                else if(plcType == ePLCType.Binary)
                {
                    _melsecTcpIP.BinaryReadReceiveDelegate = BinaryReadReceive;
                    _melsecTcpIP.BinaryWriteReceiveDelegate = BinaryWriteReceive;
                    _melsecTcpIP.ErrorMessageDelegate = PlcErrorMessage;
                }

                if (_melsecTcpIP.Initialize(plcType) == false)
                {
                    Logger.Write(eLogType.ERROR, "Failed to Connecting PLC. Check PLC Connection", Status.Instance().NowTime);
                    return;
                }

                StartThread();

            }
            catch (Exception err)
            {
                _melsecTcpIP = null;
                Logger.WriteException(eLogType.ERROR, err, Status.Instance().NowTime);
                return;
            }
        }

        public void SetStartAddressAndReadCount()
        {
            int minAddress = int.MaxValue;
            int readCount = int.MinValue;
            foreach (PLCAddressProperty property in Status.Instance().Plc.PlcReceivePacketList)
            {
                if (minAddress >= property.AddressNumber && property.AddressNumber != 0)
                    minAddress = property.AddressNumber;

                int endAddress = CalcEndAddress(property);
                if (readCount <= endAddress)
                    readCount = endAddress;
            }
            _readStartAddress = minAddress;
            _readCount = readCount - _readStartAddress;
        }

        private int CalcEndAddress(PLCAddressProperty property)
        {
            ePLCType plcType = Settings.Instance().Operation.PlcType;

            int interval = 1;
            switch (plcType)
            {
                case ePLCType.Binary:
                    interval = 2;
                    break;
                case ePLCType.ASCII:
                    interval = 4;
                    break;
                case ePLCType.None:
                default:
                    break;
            }

            return property.AddressNumber + (interval * property.AddressDataLength);
        }

        private void PlcErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void AsciiReadReceive(string dataBuffer)
        {
            ePLCType plcType = Settings.Instance().Operation.PlcType;

            if (plcType != ePLCType.ASCII)
                return;

            foreach (PLCAddressProperty property in Status.Instance().Plc.PlcReceivePacketList)
            {
                int addressNumber = property.AddressNumber;
                int dataLength = property.AddressDataLength;
                string data = SplitData(dataBuffer, addressNumber, dataLength, plcType);
                if (plcType == ePLCType.ASCII)
                    property.Value = ConvertAscll(data, property.DataType);
                else
                    property.Value = "Pasing Error. PLC Type : " + plcType.ToString();
            }
        }

        private void AsciiWriteReceive(string dataBuffer)
        {
            
        }

        private void BinaryReadReceive(byte[] dataBuffer)
        {
            ePLCType plcType = Settings.Instance().Operation.PlcType;

            if (plcType != ePLCType.Binary)
                return;

            foreach (PLCAddressProperty property in Status.Instance().Plc.PlcReceivePacketList)
            {
                int addressNumber = property.AddressNumber;
                int dataLength = property.AddressDataLength;
                byte[] data = SplitData(dataBuffer, addressNumber, dataLength, plcType);
                if (plcType == ePLCType.Binary)
                    property.Value = ConvertBinary(data, property.DataType);
                else
                    property.Value = "Pasing Error. PLC Type : " + plcType.ToString();
            }
        }

        private void BinaryWriteReceive(byte[] dataBuffer)
        {
          
        }

        private void StartThread()
        {
            _isTerminate = false;
            //_routineCompleted = false;
            _threadPLC = new Thread(PLCThread);
            _threadPLC.Start();

            _plcAliveTimer = new Timer(PLCAliveCheckTimer, null, 1000, 1000);
        }

        private void PLCAliveCheckTimer(object obj)
        {
             PLCAddressProperty property = Status.Instance().Plc.GetPLCPacketProperty(ePLCAddress.PLC_HEARTBEAT);

            if(property.UseAddress)
            {
                int nowPLCHeartBit = Convert.ToInt16(property.Value);
                if(_prevPLCHeartBit != nowPLCHeartBit)
                {
                    _plcHeartBitSW.Restart();
                    _prevPLCHeartBit = nowPLCHeartBit;
                    IsPLCheartAlive = true;
                }
                if(_plcHeartBitSW.ElapsedMilliseconds >= 5000)
                {
                    IsPLCheartAlive = false;
                    FormMain.Instance().Log(eLogType.ERROR, "PLC HeartBit TimeOut(5000ms) : " + _plcHeartBitSW.ElapsedMilliseconds.ToString() + "ms", Status.Instance().NowTime, false);
                }
            }
            else
            {
                IsPLCheartAlive = false;
                _plcHeartBitSW.Restart();
            }
        }

        private void PLCThread()
        {
            try
            {
                while (_isTerminate == false)
                {
                    PLCRoutine();
                    Thread.Sleep(PLC_SEND_INTER_PACKET_DELAY_IN_THREAD);
                }
                if (_isTerminate)
                {
                    _threadPLC = null;
                }
            }
            catch (Exception err)
            {
                FormMain.Instance().Log(eLogType.ERROR, err.Message, Status.Instance().NowTime, false);
                _isTerminate = true;
                _threadPLC = null;
            }
        }
        Stopwatch sw = new Stopwatch();
        private int _loopCount = 0;
        private void PLCRoutine()
        {
            if (_melsecTcpIP.IsConnected())
            {
                
                _reConnectCount = 0;
                if (_loopCount % 3 == 0)
                {
                    sw.Restart();

                    _melsecTcpIP.ReadCommand(_readStartAddress, _readCount);

                    sw.Stop();
                    if(sw.ElapsedMilliseconds>100)
                    Console.WriteLine("PLC Read Time : " + sw.ElapsedMilliseconds.ToString());
                }

                if (_loopCount % 3 != 0 && _loopCount % 20 == 0)
                {
                    sw.Restart();

                    WritePCHeartBit();

                    sw.Stop();
                    if (sw.ElapsedMilliseconds > 100)
                        Console.WriteLine("PLC Write Time : " + sw.ElapsedMilliseconds.ToString());
                }

                if (_loopCount >= int.MaxValue)
                    _loopCount = 0;
                else
                    _loopCount++;
               
            }
            else
            {
                _reConnectCount++;
                string message = "PLC connection is Disconnected. ReTry Connect Count : " + _reConnectCount.ToString();
                FormMain.Instance().Log(eLogType.ERROR, message, Status.Instance().NowTime);
                _melsecTcpIP.DoConnect();
                Console.WriteLine(message);
                Thread.Sleep(1000);
            }
        }
        private void WritePCHeartBit()
        {
            PCHeartBeat = !PCHeartBeat;

            PLCAddressProperty property = Status.Instance().Plc.GetPLCPacketProperty(ePLCAddress.PC_HEARTBEAT);
            if (_melsecTcpIP != null)
            {
                _melsecTcpIP.WriteCommand(property.AddressNumber, PCHeartBeat ? "0001" : "0000");
            }
        }
      
        public void Terminate()
        {
            if(_plcAliveTimer != null)
                _plcAliveTimer.Dispose();
            _isTerminate = true;
        }
        public bool IsConnected()
        {
            if (_melsecTcpIP == null)
                return false;
            return _melsecTcpIP.IsConnected();
        }

        public void WriteCommand(ePLCAddress address, string message)
        {
            if (_melsecTcpIP == null)
                return;
            _melsecTcpIP.WriteCommand((int)address, message);
        }

        public void WriteCommandJudge(eResultConstant inspResult)
        {
            int index = (int)inspResult;
            string message = index.ToString("X4");

            PLCAddressProperty property = Status.Instance().Plc.GetPLCPacketProperty(ePLCAddress.PC_JUDGE);

            if (_melsecTcpIP != null)
            {
                _melsecTcpIP.WriteCommand(property.AddressNumber, message);
            }
        }

        // DefectType - Broken : 0001 / Chipping : 0010 / Crack : 0100
        public void WriteCommandDefectType(eDefectType defectType)
        {
            switch (defectType)
            {
                case eDefectType.None:
                    break;
                case eDefectType.Broken:
                    _writeResultBit += (ushort)Math.Pow(2, 0);
                    break;
                case eDefectType.Chipping:
                    _writeResultBit += (ushort)Math.Pow(2, 1);
                    break;
                case eDefectType.Crack:
                    _writeResultBit += (ushort)Math.Pow(2, 2);
                    break;
                case eDefectType.Warning:
                    break;
                default:
                    break;
            }

            PLCAddressProperty property = Status.Instance().Plc.GetPLCPacketProperty(ePLCAddress.PC_DEFECT_TYPE);

            if (_melsecTcpIP != null)
            {
                _melsecTcpIP.WriteCommand(property.AddressNumber, _writeResultBit.ToString("X4"));
            }
        }

        public void InspetionComplete()
        {
            PLCAddressProperty property = Status.Instance().Plc.GetPLCPacketProperty(ePLCAddress.PC_INSPECTION_COMPLETE);

            if (_melsecTcpIP != null)
            {
                _melsecTcpIP.WriteCommand(property.AddressNumber,"0001");
            }
        }

        public void ClearResultData()
        {
            _writeResultBit = new ushort();
            if (_melsecTcpIP == null)
                return;
            PLCAddressProperty property = Status.Instance().Plc.GetPLCPacketProperty(ePLCAddress.PC_INSPECTION_COMPLETE);

            if (_melsecTcpIP != null)
            {
                _melsecTcpIP.WriteCommand(property.AddressNumber, "0000 0000 0000");

            }
        }

        private string SplitData(string dataBuffer, int addressNumber, int length, ePLCType plcType)
        {
            string resultStr = "";
            try
            {
                int startAddress = (addressNumber - _readStartAddress) * 4;
                int addresslength = plcType == ePLCType.ASCII ? length * 4 : length * 2;
                resultStr = dataBuffer.Substring(startAddress, addresslength);
            }
            catch (Exception)
            {
                return "";
            }
            return resultStr;
        }

        private byte[] SplitData(byte[] dataBuffer, int addressNumber, int length, ePLCType plcType)
        {
            byte[] resultByte = null;
            try
            {
                int startAddress = (addressNumber - _readStartAddress) * 2;
                int addresslength = plcType == ePLCType.ASCII ? length * 4 : length * 2;
                resultByte = new byte[addresslength];
                
                Array.Copy(dataBuffer, startAddress, resultByte,0 , addresslength);
            }
            catch (Exception)
            {
                return resultByte;
            }
            return resultByte;
        }

        private string ConvertAscll(string hexBuffer, ePlcDataType dataType)
        {
            string resultStr = "";
            try
            {
                switch (dataType)
                {
                    case ePlcDataType.DEC:

                        for (int i = 0; i < hexBuffer.Length; i += 4)
                        {
                            string code = hexBuffer.Substring(i, 4);
                            int value = Convert.ToInt16(code, 16);

                            resultStr += value.ToString();
                        }

                        break;
                    case ePlcDataType.HEX:
                        for (int i = 0; i < hexBuffer.Length; i += 4)
                        {
                            string code = hexBuffer.Substring(i, 4);

                            //plc가 반대로 들어와 first, second 바꿈
                            string first = code.Substring(2, 2);
                            string second = code.Substring(0, 2);

                            byte[] resultByte = { Convert.ToByte(first, 16), Convert.ToByte(second, 16) };

                            if (resultByte[0] == 0)
                                resultByte[0] = 32;

                            if (resultByte[1] == 0)
                                resultByte[1] = 32;
                            string g = Encoding.ASCII.GetString(resultByte);
                            resultStr += Encoding.ASCII.GetString(resultByte).Trim();
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //Logger.logEx(ex);
            }
            return resultStr;
        }

        private string ConvertBinary(byte[] hexBuffer, ePlcDataType dataType)
        {
            string resultStr = "";

            switch (dataType)
            {
                case ePlcDataType.DEC:
                    for (int i = 0; i < hexBuffer.Length; i += 2)
                    {
                        byte[] dataArray = new byte[2];
                        Array.Copy(hexBuffer, i, dataArray, 0, 2);
                        int value = BitConverter.ToInt16(dataArray, 0);

                        resultStr += value.ToString();
                    }
                    break;
                case ePlcDataType.HEX:

                    string strValue = Encoding.Default.GetString(hexBuffer,0, hexBuffer.Length);
                    resultStr = strValue.Replace("\0", "");
                    break;
                default:
                    break;
            }
            return resultStr;
        }
    }
}
