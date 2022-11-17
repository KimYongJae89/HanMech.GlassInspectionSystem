using HMechUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Device.PLC
{
    public class MELSEC_AsyncTcpIP
    {
        protected string HOST = "0.0.0.0";
        protected int PORT = 0;

        // Socket Protocol
        private Socket _clientSock = null;
        protected AsyncCallback AsyncConnectCallback = null;
        protected AsyncCallback AsyncRecvCallback = null;

        // Receive Data
        private const int PLC_RECV_PACKET_BUFFER_MAX = 1024;
        private byte[] _recvBuffer = new byte[PLC_RECV_PACKET_BUFFER_MAX];

        // PLC Main Thread
        private AutoResetEvent _reqAndRespFunctionEvent = new AutoResetEvent(true);
        private bool _isDataRecving = false;

        private ePLCType _plcType = ePLCType.None;
        private MELSEC_BinaryMessage _binaryMessage = new MELSEC_BinaryMessage();
        private MELSEC_AsciiMessage _asciiMessage = new MELSEC_AsciiMessage();

        //Delegate Ascii
        public Action<string> AsciiReadReceiveDelegate;
        public Action<string> AsciiWriteReceiveDelegate;
        public Action<string> ErrorMessageDelegate;
        //Delegate Binary
        public Action<byte[]> BinaryReadReceiveDelegate;
        public Action<byte[]> BinaryWriteReceiveDelegate;

        public MELSEC_AsyncTcpIP(string ipAddress, int port)
        {
            HOST = ipAddress;
            PORT = port;
        }

        public bool Initialize(ePLCType plcType)
        {
            try
            {
                _plcType = plcType;

                if (_clientSock != null)
                {
                    if (_clientSock.Connected)
                    {
                        _clientSock.Disconnect(true);
                    }
                    _clientSock = null;
                }

                _clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (AsyncConnectCallback == null)
                    AsyncConnectCallback = new AsyncCallback(ConnectCallBack);
                if (AsyncRecvCallback == null)
                    AsyncRecvCallback = new AsyncCallback(OnReceiveCallBack);

                DoConnect();

                Thread.Sleep(700);

                if (_clientSock.Connected)
                {
                    Console.WriteLine("PLC Connected.");
                    return true;
                }
                else
                {
                    Console.WriteLine("PLC DisConnected.");
                    return false;
                }
            }
            catch (Exception err)
            {
                return false;
                throw;
            }
           
        }

        public void DoConnect()
        {
            if (_clientSock == null)
                _clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.BeginConnect();
        }

        public bool IsConnected()
        {
            if (_clientSock == null)
                return false;
            return _clientSock.Connected;
        }

        private bool _isDisconnected = false;
        public void BeginConnect()
        {
            try
            {
                if (AsyncConnectCallback == null)
                    AsyncConnectCallback = new AsyncCallback(ConnectCallBack);

                IPEndPoint LocalEndPoint = _clientSock.LocalEndPoint as IPEndPoint;

                if (LocalEndPoint == null)
                {
                    _clientSock.BeginConnect(this.HOST, this.PORT, AsyncConnectCallback, _clientSock); //비동기 방식
                }
                else
                {
                    string LocalIP = LocalEndPoint.Address.ToString();
                    Console.WriteLine(LocalIP.ToString());
                    if (_isDisconnected == false)
                    {
                        _clientSock.Disconnect(true);
                        _clientSock.BeginConnect(this.HOST, this.PORT, AsyncConnectCallback, _clientSock);
                        _isDisconnected = true;
                    }
                    else
                    {
                        _clientSock.BeginConnect(this.HOST, this.PORT, AsyncConnectCallback, _clientSock); //비동기 방식
                        _isDisconnected = false;
                        Thread.Sleep(700);
                    }
                }

            }
            catch (InvalidOperationException)
            {
                _isDisconnected = false;
            }
            catch (SocketException err)
            {
                _isDisconnected = true;
                /*서버 접속 실패 */
                //this.DoConnect();
            }
        }

        private void OnReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                _isDataRecving = true;

                Socket _tempSock = (Socket)ar.AsyncState;
                if (!_tempSock.Connected)
                    return;

                int recvBufferSize = _tempSock.EndReceive(ar);
                if (recvBufferSize == 0)
                {
                    _isDataRecving = false;
                    _clientSock.Close();
                    this.DoConnect();
                    throw new Exception("PLC is Disconnected.. Because of Receive Packet Size is 0");
                }

                eResponseType responseType = eResponseType.None;
                if (_plcType == ePLCType.Binary)
                {
                    byte[] dataBuffer = null;
                    
                    if(_binaryMessage.ParseReceiveHeaderCommand(_recvBuffer, ref dataBuffer, ref responseType) == false)
                    {
                        if (ErrorMessageDelegate != null)
                            ErrorMessageDelegate("Binary PLC Parsing Error. " + responseType.ToString());
                    }
                    else
                    {
                        if (responseType == eResponseType.Write)
                        {
                            if (BinaryWriteReceiveDelegate != null)
                                BinaryWriteReceiveDelegate(dataBuffer);
                        }
                        else if (responseType == eResponseType.Read)
                        {
                            if (BinaryReadReceiveDelegate != null)
                                BinaryReadReceiveDelegate(dataBuffer);
                        }
                    }
                }
                else if(_plcType == ePLCType.ASCII)
                {
                    string readPacket = Encoding.ASCII.GetString((_recvBuffer), 0, recvBufferSize);
                    string dataBuffer = "";
                    if (_asciiMessage.ParseReceiveHeaderCommand(readPacket,ref dataBuffer, ref responseType) == false)
                    {
                        if (ErrorMessageDelegate != null)
                            ErrorMessageDelegate("ASCII PLC Parsing Error. " + responseType.ToString());
                    }
                    else
                    {
                        if (responseType == eResponseType.Write)
                        {
                            if (AsciiWriteReceiveDelegate != null)
                                AsciiWriteReceiveDelegate(dataBuffer);
                        }
                        else if (responseType == eResponseType.Read)
                        {
                            if (AsciiReadReceiveDelegate != null)
                                AsciiReadReceiveDelegate(dataBuffer);
                        }
                    }
                }
                this.BeginReceive();
            }
            catch (SocketException sock_ex)
            {
                _isDataRecving = false;
                if (sock_ex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    //Logger.log("PLC Sock Reconnecting... because of SocketError.ConnectionReset", LogType.PLC);
                    this.BeginConnect();
                }
            }
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            { 
                Socket client = (Socket)ar.AsyncState;
                IPEndPoint svrEP = (IPEndPoint)client.RemoteEndPoint;
                client.EndConnect(ar);
                _clientSock = client;
                BeginReceive();
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.NotConnected)
                {
                    //서버 연결 실패시 다시 접속 시도
                    //this.BeginConnect(); 
                }
            }
        }

        public void BeginReceive()
        {
             _clientSock.BeginReceive(this._recvBuffer, 0, _recvBuffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallBack), _clientSock);
        }

        public void ReadCommand(int startPlcAddress, int readCount)
        {
            byte[] sendCommand = null;
            if (_plcType == ePLCType.ASCII)
            {
                string command = _asciiMessage.GetReadCommand(startPlcAddress, readCount);
                sendCommand = new ASCIIEncoding().GetBytes(command);

            }
            else if (_plcType == ePLCType.Binary)
            {
                sendCommand = _binaryMessage.GetReadCommand(startPlcAddress, readCount);
            }
            else {}

            if(sendCommand != null)
            {
                RequestAndResponse(sendCommand);
            }
        }

        public void WriteCommand(int startPlcAddress, string message)
        {
            byte[] sendCommand = null;
            if (_plcType == ePLCType.ASCII)
            {
                string command = _asciiMessage.GetWriteCommand(startPlcAddress, message);
                sendCommand = new ASCIIEncoding().GetBytes(command);

            }
            else if (_plcType == ePLCType.Binary)
            {
                sendCommand = _binaryMessage.GetWriteCommand(startPlcAddress, message);
            }
            else { }

            if (sendCommand != null)
            {
                //BeginSend(sendCommand);
                RequestAndResponse(sendCommand);
            }
        }

        public bool RequestAndResponse(byte[] cmd)
        {
            _reqAndRespFunctionEvent.WaitOne(900); // 처리 중일 경우 300ms 기다림

            _reqAndRespFunctionEvent.Reset();

            _isDataRecving = false;
            if (BeginSend(cmd) == false)
            {
                _reqAndRespFunctionEvent.Set();
                return false;
            }

            if (CheckResponseTimeout(cmd) == false)
            {
                _reqAndRespFunctionEvent.Set();
                return false;
            }
            _reqAndRespFunctionEvent.Set();
            return true;
        }

        private bool CheckResponseTimeout(byte[] cmd)
        {
            HMTimer hmTimer = new HMTimer();
            int ReCnt = 0;
            const int MaxReCnt = 3;
            hmTimer.Reset();

            if (cmd == null)
            {
                return false;
            }
            // 데이터 들어오는지 확인 타임아웃
            while (_isDataRecving == false)
            {
                //5번시도
                if (hmTimer.IsTimeOut(300))
                {
                    hmTimer.Reset();
                    BeginSend(cmd);
                    ReCnt++;
                    Console.WriteLine("CheckRespTimeout() ReBeginSend Cnt : " + ReCnt);
                }
                if (ReCnt == MaxReCnt)
                {
                    Console.WriteLine("CheckRespTimeout() TimeOut! ReBeginSend Cnt " + ReCnt);
                    return false;
                }
                System.Threading.Thread.Sleep(10);
            }
            return true;
        }

        private bool BeginSend(Byte[] sendDataArray)
        {
            try
            {
                if (_clientSock != null)
                {
                    if (_clientSock.Connected)
                    {
                        SocketError errCode;
                        IAsyncResult r = _clientSock.BeginSend(sendDataArray, 0, sendDataArray.Length, SocketFlags.None, out errCode, new AsyncCallback(SendCallBack), sendDataArray);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SendCallBack(IAsyncResult IAR)
        {
        }
    }
}
