
namespace Knv.BHS.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Globalization;
    using System.Linq;
    using System.Net;

    public class Connection
    {
        public static Connection Instance { get; } = new Connection();
        const string GenericTimestampFormat = "yyyy.MM.dd HH:mm:ss";
        public event EventHandler ConnectionChanged;
        public event EventHandler ErrorHappened;
        public bool TracingEnable { get; set; } = false;

        public Queue<string> TraceQueue = new Queue<string>();
        public int TraceLines { get; private set; }

        SerialPort _sp;
        public bool IsOpen
        {
            get
            {
                if (_sp == null)
                    return false;
                else
                    return _sp.IsOpen;
            }
        }

        public int ReadTimeout
        {
            get { return _sp.ReadTimeout; }
            set { _sp.ReadTimeout = value; }
        }

        public static string[] GetPortNames()
        {
            return (SerialPort.GetPortNames());
        }
        static readonly object _syncObject = new object();

        /// <summary>
        /// Srosport Nyitása
        /// </summary>
        /// <param name="port">Port:COMx</param>
        public void Open(string port)
        {
            try
            {
                _sp = new SerialPort(port)
                {
                    ReadTimeout = 1000,
                    BaudRate = 115200,
                    DtrEnable = true, //RPi pico support
                    NewLine = "\r"
                };
                _sp.Open();
                _sp.DiscardInBuffer();
                Trace("Serial Port: " + port + " is Open.");
                Test();
                OnConnectionChanged();
            }
            catch (Exception ex)
            {
                _sp?.Close();
                TraceError("IO ERROR Serial Port is: " + port + " Open fail... beacuse:" + ex.Message);
                OnConnectionChanged();
            }
        }

        public void Test()
        {
            if (_sp == null || !_sp.IsOpen)
            {
                Trace("IO ERROR: port is closed.");
            }

            try
            {
                var resp = WriteRead("*OPC?");
                if (resp == null || !(resp == "*OPC" || resp == "*OPC? OK"))
                    Trace("Connection TEST ERROR");
            }
            catch (Exception ex)
            {
                TraceError("IO-ERROR:" + ex.Message);
            }
        }

        public void ExitDfuMode()
        {
            WriteRead("RST");
        }

        public void EnterDfuMode()
        {

            WriteRead("RST");
            System.Threading.Thread.Sleep(1000);


            int temp = _sp.ReadTimeout;
            _sp.ReadTimeout = 20;
            string response = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    response = WriteRead("DFU");
                    if (response == "OK")
                        break;
                }
                catch (Exception)
                {

                }
            }
            _sp.ReadTimeout = temp;

            if (response != "OK")
                throw new ApplicationException("");
        }


        internal string WriteRead(string request)
        {
            string response = string.Empty;
            Exception exception = null;
            int rxErrors = 0;
            int txErrors = 0;

            do
            {
                if (_sp == null || !_sp.IsOpen)
                {
                    var msg = $"The {_sp.PortName} Serial Port is closed. Please open it.";
                    Trace(msg);
                    OnConnectionChanged();
                    throw new ApplicationException(msg);
                }
                try
                {
                    Trace("Tx: " + request);
                    _sp.WriteLine(request);

                    try
                    {
                        response = _sp.ReadLine().Trim(new char[] { '\0', '\r', '\n' }); ;
                        Trace("Rx: " + response);
                        return response;
                    }
                    catch (Exception ex) //TODO: Nem jol van kezelve a TIMOUT
                    {
                        Trace("Rx ERROR Serial Port is:" + ex.Message);
                        exception = new TimeoutException($"Last Request: {request}", ex);
                        rxErrors++;
                        OnErrorHappened();
                    }
                }
                catch (Exception ex)
                {
                    Trace("Tx ERROR Serial Port is:" + ex.Message);
                    exception = ex;
                    txErrors++;
                    OnErrorHappened();
                }

            } while (rxErrors < 3 && txErrors < 3);

            TraceError("There were three consecutive io error. I close the connection.");
            Close();
            throw exception;
        }

        internal string WriteReadWoTracing(string request)
        {
            string response = string.Empty;
            Exception exception = null;
            int rxErrors = 0;
            int txErrors = 0;

            do
            {
                if (_sp == null || !_sp.IsOpen)
                {
                    var msg = $"The {_sp.PortName} Serial Port is closed. Please open it.";
                    Trace(msg);
                    OnConnectionChanged();
                    throw new ApplicationException(msg);
                }
                try
                {
                    _sp.WriteLine(request);
                    try
                    {
                        response = _sp.ReadLine().Trim(new char[] { '\0', '\r', '\n' }); ;
                        return response;
                    }
                    catch (Exception ex)
                    {
                        exception = new TimeoutException($"Last Request: {request}", ex);
                        rxErrors++;
                        OnErrorHappened();
                    }
                }
                catch (Exception ex)
                {
                    Trace("Tx ERROR Serial Port is:" + ex.Message);
                    exception = ex;
                    txErrors++;
                    OnErrorHappened();
                }

            } while (rxErrors < 3 && txErrors < 3);

            Trace("There were three consecutive io error. I close the connection.");
            Close();
            throw exception;
        }

        public void Close()
        {
            Trace("Serial Port is: " + "Close");
            _sp?.Close();
            OnConnectionChanged();
        }

        internal void Trace(string msg)
        {
            if (TracingEnable)
            {
                TraceLines++;
                TraceQueue.Enqueue(DateTime.Now.ToString(GenericTimestampFormat) + " " + msg);
            }
        }

        internal void TraceError(string errorMsg)
        {
            TraceLines++;
            TraceQueue.Enqueue(DateTime.Now.ToString(GenericTimestampFormat) + " " + errorMsg);
        }

        public void TraceClear()
        {
            TraceQueue.Clear();
            TraceLines = 0;
        }
        protected virtual void OnConnectionChanged()
        {
            EventHandler handler = ConnectionChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnErrorHappened()
        {
            EventHandler handler = ErrorHappened;
            handler?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Firmware Verziószáma
        /// </summary>
        /// <returns>pl. 1.0.0.0</returns>
        public string GetVersion()
        {
            var resp = WriteRead("VER?");
            if (resp == null)
                return "n/a";
            else
                return resp;
        }
        /// <summary>
        /// Processzor egyedi azonsítója, hosza nem változik
        /// </summary>
        /// <returns>pl:20001E354D501320383252</returns>
        public string UniqeId()
        {
            var resp = WriteRead("*UID?");
            if (resp == null)
                return "n/a";
            else
                return resp;
        }
        /// <summary>
        /// Bekapcsolás óta eltelt idő másodpercben
        /// </summary>
        /// <returns>másodperc</returns>
        public int GetUpTime()
        {
            if (int.TryParse(WriteRead("UPTIME?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"), out int retval))
                return retval;
            else
                return 0;
        }

        /// <summary>
        /// A panel varáció neve pl: MGUI201222V00-PCREF
        /// </summary>
        /// <returns></returns>
        public string WhoIs()
        {
            var resp = WriteRead("*IDN?");
            if (resp == null)
                return "n/a";
            else
                return resp;
        }


        public void SetClock(DateTime dt)
        {
            //TIME 2023.11.30-08:39:30
            var req = $"TIME {dt.Year}.{dt.Month}.{dt.Day}-{dt.Hour}:{dt.Minute}:{dt.Second}";
            var resp = WriteRead(req);

        }
        public DateTime GetClock() 
        {
            var req = $"TIME?";
            var resp = WriteRead(req);
            var item = resp.Split(new char[] { '.', '-', ':' });

            var dt = new DateTime(0);

            try
            {
                //TIME 2023.11.30-08:39:30
                dt = new DateTime(int.Parse(item[0]),
                                    int.Parse(item[1]),
                                    int.Parse(item[2]),
                                    int.Parse(item[3]),
                                    int.Parse(item[4]),
                                    int.Parse(item[5]));
            }
            catch (Exception ex)
            {
                Trace($"Error: {ex.Message}" );
            }
            //public DateTime(int year, int month, int day, int hour, int minute, int second);

            return dt;
        }


        public Byte[] FlashRead(int address, int size)
        {
            /*
             * FR <Address of Block> <Size of Block> 
             * <Address of Block> <Size of Block> <Data> <crc>
             */
            string response = WriteReadWoTracing($"FR {address:X8} {size:X3}");

            if (response.Contains('!'))
            {
                Trace(response);
                throw new ApplicationException(response);
            }
            var array = response.Split(' '); //addr size data crc
            if (array.Length != 4)
                throw new ApplicationException("Flash Read Error: Expected FR ADDRESS SIZE CRC");

            int.TryParse(array[0], NumberStyles.HexNumber, CultureInfo.GetCultureInfo("en-US"), out int rx_addr);
            UInt16.TryParse(array[1], NumberStyles.HexNumber, CultureInfo.GetCultureInfo("en-US"), out UInt16 rx_bsize);
            Byte[] rx_data = Tools.StringToByteArray(array[2]);
            UInt16.TryParse(array[3], NumberStyles.HexNumber, CultureInfo.GetCultureInfo("en-US"), out UInt16 rx_crc);

            if (rx_data.Length != rx_bsize)
                new ApplicationException("Size Error:");
            if (rx_addr != address)
                new ApplicationException("Address Error");
            UInt16 calc_crc = Tools.CalcCrc16Ansi(0, rx_data);
            if (calc_crc != rx_crc)
                new ApplicationException("CRC Error");

            return rx_data;
        }


        public void FlashErase(int address)
        {
            var response = WriteReadWoTracing($"FE {address:X8} 1000");
            if (response.Contains('!'))
            {
                Trace(response);
                throw new ApplicationException(response);
            }
        }


        public void FlashWrite(int address, Byte[] data)
        {
            string response = WriteReadWoTracing($"FW {address:X8} {data.Length:X3} {Tools.ByteArrayToString(data)} {Tools.CalcCrc16Ansi(0, data):X4}");
            if (response.Contains('!'))
            {
                Trace(response);
                throw new ApplicationException(response);
            }
        }

        public void IrSendCode(int code)
        {
            var response = WriteRead($"IR:TX {code:X2}");
            if (response.Contains('!'))
            {
                Trace(response);
                throw new ApplicationException(response);
            }
        }
    }
}
