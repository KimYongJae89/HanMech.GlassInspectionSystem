using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GlassInspectionSystem;

namespace Device.PLC
{  
    public class MELSEC_BinaryMessage
    {
        const int NUMBER_OF_DEVICE_POINTS_SIZE = 2;
        const int HEAD_DEVICE_NUMBER_SIZE = 3;

        const UInt16 WriteCommand = 0x1401;
        const UInt16 ReadCommand = 0x0401;

        // Receive Sub Header = ReceiveSubHeader1 + ReceiveSubHeader2 (Read)
        const Byte ReceiveSubHeader1 = 0xD0;
        const Byte ReceiveSubHeader2 = 0x00;


        // Request Sub Header = RequestSubHeader1 + RequestSubHeader2 (Write)
        const Byte RequestSubHeader1 = 0x50;
        const Byte RequestSubHeader2 = 0x00;

        #region Access route
        const Byte NetWork_Number = 0x00;
        const Byte PC_Number = 0xFF;
        const Byte Module_IO_Number_H = 0x03;
        const Byte Module_IO_Number_L = 0xFF;
        const Byte Module_Station_Number = 0x00;
        #endregion

        const Byte MonitoringTime_H = 0x00;
        const Byte MonitoringTime_L = 0x10;

        const Byte SubCommand_H = 0x00; // D* : 0x0000, M* : 0x0001
        const Byte SubCommand_L = 0x00; // D* : 0x0000, M* : 0x0001
        const Byte DeviceCode = 0xA8; //D*

        private UInt16 _writeRequestDataLength = 0x0000; // PLC 주소에 Write 할 시 Data Length
        private UInt16 _readRequestDataLength = 0x0000; // PLC에게 요청한 Data Length

        private string _endCode = "0000";

        private byte[] _temporaryMessageArray = new byte[4096];
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameBuffer">검증할 Buffer</param>
        /// <param name="dataBuffer">Head를 제외한 순수 Data Buffer</param>
        /// <returns></returns>
        public bool ParseReceiveHeaderCommand(byte[] frameBuffer, ref byte [] dataBuffer,ref eResponseType responseType)
        {
            int index = 0;

            _endCode = "0000"; // ErrCode Reset;

            string subHeader1 = BitConverter.ToString(frameBuffer, index, 1);
            if (ReceiveSubHeader1.ToString("X2") != subHeader1)
            {
                responseType = eResponseType.ParsingError_SubHeader;
                return false;
            }
            index+= 1;

            string subHeader2 = BitConverter.ToString(frameBuffer, index, 1);
            if (ReceiveSubHeader2.ToString("X2") != subHeader2)
            {
                responseType = eResponseType.ParsingError_SubHeader;
                return false;
            }
            index += 1;

            string netWorkNumber = BitConverter.ToString(frameBuffer, index, 1);
            if (NetWork_Number.ToString("X2") != netWorkNumber)
            {
                responseType = eResponseType.ParsingError_NetWorkNumber;
                return false;
            }
            index += 1;

            string pcNumber = BitConverter.ToString(frameBuffer, index, 1);
            if (PC_Number.ToString("X2") != pcNumber)
            {
                responseType = eResponseType.ParsingError_PCNumber;
                return false;
            }
            index += 1;

            string moduleIONumber_H = BitConverter.ToString(frameBuffer, index, 1);
            if (Module_IO_Number_L.ToString("X2") != moduleIONumber_H)
            {
                responseType = eResponseType.ParsingError_ModuleIONumber;
                return false;
            }
            index += 1;

            string moduleIONumber_L = BitConverter.ToString(frameBuffer, index, 1);
            if (Module_IO_Number_H.ToString("X2") != moduleIONumber_L)
            {
                responseType = eResponseType.ParsingError_ModuleIONumber;
                return false;
            }
            index += 1;

            string mouduleStationNumber = BitConverter.ToString(frameBuffer, index, 1);
            if (Module_Station_Number.ToString("X2") != mouduleStationNumber)
            {
                responseType = eResponseType.ParsingError_ModuleStationNumber;
                return false;
            }
            index += 1;

            string requestDataLength = BitConverter.ToString(frameBuffer, index, 2);
            requestDataLength = requestDataLength.Replace("-", "");
            
            index += 2;
            string endCode = BitConverter.ToString(frameBuffer, index, 2); // byte array을 BitConvert.Tostring() 하면 배열사이에 "-"가 포함되어 변환됨
            endCode = endCode.Replace("-", "");

            if (_endCode != endCode)
            {
                _endCode = endCode;
                responseType = eResponseType.ParsingError_EndCode;
                return false;
            }
            _endCode = "0000";
            index += 2;

            if (_endCode == "0000" && requestDataLength == "0200")
                responseType = eResponseType.Write;
            else
                responseType = eResponseType.Read;

            int size = frameBuffer.Length - index;

            dataBuffer = new byte[size];
           
            
            Array.Copy(frameBuffer, index, dataBuffer, 0, size);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plcAddress">PLC Address</param>
        /// <param name="message">비트 형식으로 입력( ex>  1 -> 0001 )</param>
        /// <returns></returns>
        public byte[] GetWriteCommand(int startPlcAddress, string message)
        {
            _writeRequestDataLength = 0x0000; // 초기화
            _readRequestDataLength = 0x0000;  // 초기화

            message = message.Replace(" ", "");

            int index = 0;

            _temporaryMessageArray[index++] = RequestSubHeader1;
            _temporaryMessageArray[index++] = RequestSubHeader2;
            _temporaryMessageArray[index++] = NetWork_Number;
            _temporaryMessageArray[index++] = PC_Number;
            _temporaryMessageArray[index++] = Module_IO_Number_L; // Module_IO_Number Low
            _temporaryMessageArray[index++] = Module_IO_Number_H; // Module_IO_Number High
            _temporaryMessageArray[index++] = Module_Station_Number;

            _writeRequestDataLength = GetWriteDataLength(message);
            byte[] requestDataLengthArray = BitConverter.GetBytes(_writeRequestDataLength);

            _temporaryMessageArray[index++] = requestDataLengthArray[0]; // Request data Length Low
            _temporaryMessageArray[index++] = requestDataLengthArray[1]; // Request data Length High

            _temporaryMessageArray[index++] = MonitoringTime_L; // monitoringTime Low
            _temporaryMessageArray[index++] = MonitoringTime_H; // monitoringTime High

            byte[] command = BitConverter.GetBytes(WriteCommand);
            _temporaryMessageArray[index++] = command[0]; // Command Low
            _temporaryMessageArray[index++] = command[1]; // Command High

            _temporaryMessageArray[index++] = SubCommand_L; // SubCommand Low
            _temporaryMessageArray[index++] = SubCommand_H; // SubCommand High


            _temporaryMessageArray[index++] = (byte)((startPlcAddress >> 0) & 0xff);
            _temporaryMessageArray[index++] = (byte)((startPlcAddress >> 8) & 0xff);
            _temporaryMessageArray[index++] = (byte)((startPlcAddress >> 16) & 0xff);

            _temporaryMessageArray[index++] = DeviceCode;

            byte[] numberOfDevicePointArray = BitConverter.GetBytes((int)(message.Length / 4));
            _temporaryMessageArray[index++] = numberOfDevicePointArray[0]; // Number Of Device Point Low
            _temporaryMessageArray[index++] = numberOfDevicePointArray[1]; // Number Of Device Point High

            for (int i = 0; i < message.Length / 4; i++)
            {
                string dataString = message.Substring(i * 4, 4);

                byte[] messageArray = BitConverter.GetBytes(Convert.ToUInt16(dataString));
                _temporaryMessageArray[index++] = messageArray[0]; // messageArray Low
                _temporaryMessageArray[index++] = messageArray[1]; // messageArray High
            }

            byte[] retArray = new byte[index];

            Array.Copy(_temporaryMessageArray, retArray, index);
            return retArray;
        }

        public byte[] GetReadCommand(int startPlcAddress, int readCount)
        {
            _writeRequestDataLength = 0x0000; // 초기화
            _readRequestDataLength = 0x0000;  // 초기화

            int index = 0;

            _temporaryMessageArray[index++] = RequestSubHeader1;
            _temporaryMessageArray[index++] = RequestSubHeader2;
            _temporaryMessageArray[index++] = NetWork_Number;
            _temporaryMessageArray[index++] = PC_Number;
            _temporaryMessageArray[index++] = Module_IO_Number_L; // Module_IO_Number Low
            _temporaryMessageArray[index++] = Module_IO_Number_H; // Module_IO_Number High
            _temporaryMessageArray[index++] = Module_Station_Number;

            _readRequestDataLength = GetReadDataLength();
            byte[] requestDataLengthArray = BitConverter.GetBytes(_readRequestDataLength);

            _temporaryMessageArray[index++] = requestDataLengthArray[0]; // Request data Length Low
            _temporaryMessageArray[index++] = requestDataLengthArray[1]; // Request data Length High

            _temporaryMessageArray[index++] = MonitoringTime_L; // monitoringTime Low
            _temporaryMessageArray[index++] = MonitoringTime_H; // monitoringTime High

            byte[] command = BitConverter.GetBytes(ReadCommand);
            _temporaryMessageArray[index++] = command[0]; // Command Low
            _temporaryMessageArray[index++] = command[1]; // Command High

            _temporaryMessageArray[index++] = SubCommand_L; // SubCommand Low
            _temporaryMessageArray[index++] = SubCommand_H; // SubCommand High


            _temporaryMessageArray[index++] = (byte)((startPlcAddress >> 0) & 0xff);
            _temporaryMessageArray[index++] = (byte)((startPlcAddress >> 8) & 0xff);
            _temporaryMessageArray[index++] = (byte)((startPlcAddress >> 16) & 0xff);

            _temporaryMessageArray[index++] = DeviceCode;

            byte[] numberOfDevicePointArray = BitConverter.GetBytes(Convert.ToUInt16(readCount));
            _temporaryMessageArray[index++] = numberOfDevicePointArray[0]; // Number Of Device Point Low
            _temporaryMessageArray[index++] = numberOfDevicePointArray[1]; // Number Of Device Point High

            byte[] retArray = new byte[index];

            Array.Copy(_temporaryMessageArray, retArray, index);

            return retArray;
        }

        private UInt16 GetWriteDataLength(string message)
        {
            int writeCount = (int)(message.Length / 4);

            int dataLength =
                Marshal.SizeOf(MonitoringTime_H) + Marshal.SizeOf(MonitoringTime_L)
                + Marshal.SizeOf(WriteCommand)
                + Marshal.SizeOf(SubCommand_H) + +Marshal.SizeOf(SubCommand_L)
                + HEAD_DEVICE_NUMBER_SIZE
                + Marshal.SizeOf(DeviceCode)
                + NUMBER_OF_DEVICE_POINTS_SIZE
                + (Marshal.SizeOf(typeof(UInt16)) * writeCount);

            return Convert.ToUInt16(dataLength);
        }

        private UInt16 GetReadDataLength()
        {
            int dataLength =
                Marshal.SizeOf(MonitoringTime_H) + Marshal.SizeOf(MonitoringTime_L)
                + Marshal.SizeOf(ReadCommand)
                + Marshal.SizeOf(SubCommand_H) + +Marshal.SizeOf(SubCommand_L)
                + HEAD_DEVICE_NUMBER_SIZE
                + Marshal.SizeOf(DeviceCode)
                + NUMBER_OF_DEVICE_POINTS_SIZE;

            return Convert.ToUInt16(dataLength);
        }
    }

    /// Reference Document : MELSEC Communication Protocol : 479p ~ 480p ( Read / Write )
    public class MELSEC_AsciiMessage
    {
        const int NUMBER_OF_DEVICE_POINTS_SIZE = 4;
        const int HEAD_DEVICE_NUMBER_SIZE = 6;

        // Receive Sub Header = ReceiveSubHeader1 + ReceiveSubHeader2 (Read)
        const string ReceiveSubHeader = "D000";
        
        // Request Sub Header = RequestSubHeader1 + RequestSubHeader2 (Write)
        const string RequestSubHeader = "5000";

        #region Access route
        const string NetWork_Number = "00";
        const string PC_Number = "FF";
        const string Module_IO_Number = "03FF";
        const string Module_Station_Number = "00";
        #endregion

        const string MonitoringTime = "0010";

        const string WriteCommand = "1401";
        const string ReadCommand = "0401";

        const string SubCommand = "0000";
        const string DeviceCode = "D*";

        private string _writeRequestNumberOfPoint = "";// PLC 주소에 Write 할 시 Data Length
        private string _readRequestNumberOfPoint = ""; // PLC에게 요청한 Data Length

        private string _endCode = "0000";

        public bool ParseReceiveHeaderCommand(string frameBuffer, ref string dataBuffer, ref eResponseType responseType)
        {
            int index = 0;

            _endCode = "0000"; // ErrCode Reset;

            string subHeader = frameBuffer.Substring(index, 4);
            if (ReceiveSubHeader != subHeader)
            {
                responseType = eResponseType.ParsingError_SubHeader;
                return false;
            }
            index += 4;


            string netWorkNumber = frameBuffer.Substring(index, 2);
            if (NetWork_Number != netWorkNumber)
            {
                responseType = eResponseType.ParsingError_NetWorkNumber;
                return false;
            }
            index += 2;

            string pcNumber = frameBuffer.Substring(index, 2);
            if (PC_Number != pcNumber)
            {
                responseType = eResponseType.ParsingError_PCNumber;
                return false;
            }
            index += 2;

            string moduleIONumber = frameBuffer.Substring(index, 4);
            if (Module_IO_Number != moduleIONumber)
            {
                responseType = eResponseType.ParsingError_ModuleIONumber;
                return false;
            }
            index += 4;

            string mouduleStationNumber = frameBuffer.Substring(index, 2);
            if (Module_Station_Number != mouduleStationNumber)
            {
                responseType = eResponseType.ParsingError_ModuleStationNumber;
                return false;
            }
            index += 2;
            string te = frameBuffer.Substring(index, 4);
            int requestDataLength = Convert.ToInt16(frameBuffer.Substring(index, 4), 16);

            index += 4;

            string endCode = frameBuffer.Substring(index, 4);

            if (_endCode != endCode)
            {
                _endCode = endCode;
                responseType = eResponseType.ParsingError_EndCode;
                return false;
            }
            _endCode = "0000";
            index += 4;

            if (_endCode == "0000" && requestDataLength == 4)
                responseType = eResponseType.Write;
            else
                responseType = eResponseType.Read;

            int size = frameBuffer.Length - index;

            dataBuffer = frameBuffer.Substring(index, size);

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPlcAddress">PLC Address</param>
        /// <param name="message">비트 형식으로 입력( ex>  1 -> 0001 )</param>
        /// <returns></returns>
        public string GetWriteCommand(int startPlcAddress, string message)
        {
            message = message.Replace(" ", "");

            _writeRequestNumberOfPoint = ""; // 초기화
            _readRequestNumberOfPoint = ""; // 초기화
            string dataArray = "";

            dataArray += RequestSubHeader;

            string accessRoute = NetWork_Number + PC_Number + Module_IO_Number + Module_Station_Number;
            dataArray += accessRoute;

            string requestDataLength = GetWriteDataLength(message);
            dataArray += requestDataLength;

            dataArray += MonitoringTime;
            dataArray += WriteCommand;
            dataArray += SubCommand;
            dataArray += DeviceCode;

            string headDeviceNumber = String.Format("{0:000000}", startPlcAddress.GetHashCode());
            dataArray += headDeviceNumber;

            string numberOfPoint = (message.Length / 4).ToString("X4");
            _writeRequestNumberOfPoint = numberOfPoint;

            dataArray += numberOfPoint;

            dataArray += message;

            return dataArray;
        }

        public string GetReadCommand(int startPlcAddress, int readCount)
        {
            //readCount = 22;
            _writeRequestNumberOfPoint = ""; // 초기화
            _readRequestNumberOfPoint = ""; // 초기화
            string dataArray = "";

            dataArray += RequestSubHeader;

            string accessRoute = NetWork_Number + PC_Number + Module_IO_Number + Module_Station_Number;
            dataArray += accessRoute;

            string requestDataLength = GetReadDataLength();
            dataArray += requestDataLength;

            dataArray += MonitoringTime;
            dataArray += ReadCommand;
            dataArray += SubCommand;
            dataArray += DeviceCode;

            string headDeviceNumber = String.Format("{0:000000}", startPlcAddress.GetHashCode());
            dataArray += headDeviceNumber;

            string numberOfPoint = String.Format("{0:0000}", readCount);
            _readRequestNumberOfPoint = numberOfPoint;

            dataArray += numberOfPoint;

            return dataArray;
        }

        private string GetWriteDataLength(string message)
        {
            int dataLength =
                MonitoringTime.Length
                + WriteCommand.Length
                + SubCommand.Length
                + DeviceCode.Length
                + HEAD_DEVICE_NUMBER_SIZE
                + NUMBER_OF_DEVICE_POINTS_SIZE
                + message.Length;

            return dataLength.ToString("X4");
        }

        private string GetReadDataLength()
        {
            int dataLength =
                MonitoringTime.Length
                + ReadCommand.Length
                + SubCommand.Length
                + DeviceCode.Length
                + HEAD_DEVICE_NUMBER_SIZE
                + NUMBER_OF_DEVICE_POINTS_SIZE;

            return dataLength.ToString("X4");
        }
    }

  
    // Binary ResponseMessage
    public class BinaryResponseMessage
    {
        // Header                           // Sub Header = Sub Header 1 + Sub Header 2
        Byte SubHeader1 = 0xD0;             // Sub Header 1
        Byte SubHeader2 = 0x00;             // Sub Header 2

        // Access Route                     // Access Route = Network Number + PC Number + Module I/O Number + Module Station Number
        Byte NetworkNumber = 0x00;          // Network Number
        Byte PCNumber = 0xFF;                  // PC Number
        UInt16 ModuleIONumber = 0x03FF;              // Module I/O Number
        Byte ModuleStationNumber = 0x00;           // Module Station Number

        // Request Data Length              // Monitoring Timer.Length ( 2Bytes ) + Read : Request Data.Length ( 10Bytes ) or Write : Request Data.Length ( 14Bytes )
        UInt16 RequestDataLength = 0x004A;  // Request Data = Command + Sub Command + Device Code + Head Device Number ( Address ) + Number of Points + ( Write Command 1 + Write Command 2 ) or ( Read Command )

        Byte EndCode = 0x0000;

        public bool ParseReceiveHeaderCommand(ref byte[] _frameBuffer)
        {
            int index = 0;

            if (SubHeader1.ToString("X2") != BitConverter.ToString(_frameBuffer, index, 1))
                return false;
            else
                index += 1;

            if (SubHeader2.ToString("X2") != BitConverter.ToString(_frameBuffer, index, 1))
                return false;
            else
                index += 1;

            if (NetworkNumber.ToString("X2") != BitConverter.ToString(_frameBuffer, index, 1))
                return false;
            else
                index += 1;

            if (PCNumber.ToString("X2") != BitConverter.ToString(_frameBuffer, index, 1))
                return false;
            else
                index += 1;

            if (BitConverter.ToString(BitConverter.GetBytes(ModuleIONumber)) != BitConverter.ToString(_frameBuffer, index, 2))
                return false;
            else
                index += 2;

            if (ModuleStationNumber.ToString("X2") != BitConverter.ToString(_frameBuffer, index, 1))
                return false;
            else
                index += 1;

            if (BitConverter.ToString(BitConverter.GetBytes(RequestDataLength)) != BitConverter.ToString(_frameBuffer, index, 2))
                return false;
            else
                index += 2;

            if (BitConverter.ToString(BitConverter.GetBytes(EndCode)) != BitConverter.ToString(_frameBuffer, index, 2))
                return false;
            else
                return true;
            /*
        accessRoute = networkNumber + pcNumber + moduleIONumber + moduleStationNumber;

        if (subHeader != _frameBuffer.Substring(index, 4))
        {
            _frameBuffer = _frameBuffer.Remove(0, 1);
            return false;
        }

        else
            index += 4;

        if (accessRoute != _frameBuffer.Substring(index, 10))
            return false;
        else
            index += 10;

        if (responseDataLength != _frameBuffer.Substring(index, 4))
            return false;
        else
            index += 4;

        if (endCode != _frameBuffer.Substring(index, 4))
            return false;

        TotalHeader = subHeader + accessRoute + responseDataLength + endCode;
        withoutEndCode = subHeader + accessRoute + responseDataLength;

        if (_frameBuffer.Length >= TotalHeader.Length)
            return true;
        else
            return false;
            */
        }
    }
}