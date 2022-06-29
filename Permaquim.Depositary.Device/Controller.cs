
using System.Collections;
using System.IO.Ports;
using System.Text;

namespace Permaquim.Depositary.Device
{
    public class Controller : IDisposable
    {
        #pragma warning disable CS8602 // Dereference of a possibly null reference.
        
        #region Local variables

        //Serial port instance
        private SerialPort _counterPort;
        private SerialPort _ioboardPort;

        // Device instance
        private CommandInterface? _commandInterface = null;
        public StatesResult StateResultProperty;
        public event EventHandler<ECErrorArgs> ECError;
        #endregion

        #region Device Events

        public delegate void DeviceDataReceivedEventHandler(object sender, DeviceDataReceivedEventArgs args);

        public event DeviceDataReceivedEventHandler CounterDeviceDataReceived;
        public event DeviceDataReceivedEventHandler IOboardDeviceDataReceived;

        #endregion

        #region Constants

        public const string ACKNOWLEDGE = "ACK";
        public const string NEGATIVE_ACKNOWLEDGE = "NAK";
        public const string UNKNOWN = "UNKNOWN";
        public const string NO_DATA = "NO DATA";
        public const string START_OF_TEXT = "STX";
        public const string END_OF_TEXT = "ETX";
        public const string SYNC = "SYNC";
        public const string DEVICE_CONTROL_4 = "DC4";
        const byte STX = 0x02;
        const byte ETX = 0x03;
        const byte ACK = 0x06;
        const byte DC4 = 0x14;
        const byte NAK = 0x15;
        const byte SYN = 0x16;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="device"></param>
        public Controller(CommandInterface device)
        {
            _commandInterface = device;
            Log("FUNCTION: Counter Device initializing in COM Port: " + device.CounterComPort.PortName + ".");
            try
            {
                _counterPort = new SerialPort
                {
                    PortName = device.CounterComPort.PortName,
                    Parity = (Parity)device.CounterComPort.Parity,
                    DataBits = device.CounterComPort.DataBits,
                    ReadBufferSize = device.CounterComPort.ReadBufferSize,
                    StopBits = (StopBits)device.CounterComPort.StopBits,
                    ReadTimeout = device.CounterComPort.ReadTimeout,
                    RtsEnable = device.CounterComPort.RtsEnable,
                    Handshake = (Handshake)device.CounterComPort.Handshake
                };

                _ioboardPort = new SerialPort
                {
                    PortName = device.IOboardComPort.PortName,
                    Parity = (Parity)device.IOboardComPort.Parity,
                    DataBits = device.IOboardComPort.DataBits,
                    ReadBufferSize = device.IOboardComPort.ReadBufferSize,
                    StopBits = (StopBits)device.IOboardComPort.StopBits,
                    ReadTimeout = device.IOboardComPort.ReadTimeout,
                    RtsEnable = device.IOboardComPort.RtsEnable,
                    Handshake = (Handshake)device.IOboardComPort.Handshake,
                    BaudRate = device.IOboardComPort.BaudRate
                };

                _counterPort.DataReceived += CounterDataReceived;
                _counterPort.ErrorReceived += CounterErrorReceived;
                _counterPort.PinChanged += CounterPinChanged;
                _counterPort.Open();

                _ioboardPort.DataReceived += IoboardPortDataReceived;
                _ioboardPort.ErrorReceived += IoboardPortErrorReceived; ;
                _ioboardPort.PinChanged += IoboardPortPinChanged; ;
                _ioboardPort.Open();

                Log("FUNCTION: Port " + device.CounterComPort.PortName + " should be open.");
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }


        #endregion

        #region Events


        private void CounterPinChanged(object sender, SerialPinChangedEventArgs e)
        {
            string message = e.EventType switch
            {
                SerialPinChange.Break => "A break was detected on input.",
                SerialPinChange.CDChanged => "The Carrier Detect (CD) signal changed state. This signal is used to indicate whether a modem is connected to a working phone line and a data carrier signal is detected.",
                SerialPinChange.CtsChanged => "The Clear to Send (CTS) signal changed state. This signal is used to indicate whether data can be sent over the serial port.",
                SerialPinChange.DsrChanged => "The Data Set Ready (DSR) signal changed state. This signal is used to indicate whether the device on the serial port is ready to operate.",
                SerialPinChange.Ring => "A ring indicator was detected.",
                _ => "SerialPinChange unknown",
            };
            Log("EVENT: Counter PinChanged EVENT TYPE: " + e.EventType.ToString());
        }
        private void CounterErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            string message = e.EventType switch
            {
                SerialError.Frame => "The hardware detected a framing error.",
                SerialError.Overrun => "A character-buffer overrun has occurred. The next character is lost.",
                SerialError.RXOver => "An input buffer overflow has occurred. There is either no room in the input buffer, or a character was received after the end-of-file (EOF) character.",
                SerialError.RXParity => "The hardware detected a parity error.",
                SerialError.TXFull => "The application tried to transmit a character, but the output buffer was full.",
                _ => "SerialError unknown",
            };
            Log("EVENT: Counter ErrorReceived MESSAGE: " + message);
        }
        private void CounterDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var dataReceived = ((SerialPort)sender).ReadExisting();
            if (dataReceived.Length > 0)
            {
                if (Char.IsControl(dataReceived.ToCharArray()[0]))
                    dataReceived = dataReceived.ToCharArray()[0] switch
                    {
                        '\u0003' => END_OF_TEXT,
                        '\u0006' => ACKNOWLEDGE,
                        '\u0014' => DEVICE_CONTROL_4,
                        '\u0015' => NEGATIVE_ACKNOWLEDGE,
                        '\u0016' => SYNC,
                        _ => UNKNOWN,
                    };
            }
            else
            {
                dataReceived = NO_DATA;
            }

            //Raises event for counter
            if (CounterDeviceDataReceived != null)
            {
                // Instantiates the DeviceDataReceivedEventArgs object.
                DeviceDataReceivedEventArgs args = new()
                {
                    ComPort = _commandInterface.CounterComPort.PortName,
                    Message = dataReceived
                };

                // Raise the event.
                CounterDeviceDataReceived(this, args);
            }

            Log("EVENT: Counter DataReceived: " + dataReceived + " EVENT TYPE: " + e.EventType.ToString());
        }


        private void IoboardPortPinChanged(object sender, SerialPinChangedEventArgs e)
        {
            string message = String.Empty;
            message = e.EventType switch
            {
                SerialPinChange.Break => "A break was detected on input.",
                SerialPinChange.CDChanged => "The Carrier Detect (CD) signal changed state. This signal is used to indicate whether a modem is connected to a working phone line and a data carrier signal is detected.",
                SerialPinChange.CtsChanged => "The Clear to Send (CTS) signal changed state. This signal is used to indicate whether data can be sent over the serial port.",
                SerialPinChange.DsrChanged => "The Data Set Ready (DSR) signal changed state. This signal is used to indicate whether the device on the serial port is ready to operate.",
                SerialPinChange.Ring => "A ring indicator was detected.",
                _ => "SerialPinChange unknown",
            };
            Log("EVENT: IO Board PinChanged EVENT TYPE: " + e.EventType.ToString());
        }

        private void IoboardPortErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            string message = e.EventType switch
            {
                SerialError.Frame => "The hardware detected a framing error.",
                SerialError.Overrun => "A character-buffer overrun has occurred. The next character is lost.",
                SerialError.RXOver => "An input buffer overflow has occurred. There is either no room in the input buffer, or a character was received after the end-of-file (EOF) character.",
                SerialError.RXParity => "The hardware detected a parity error.",
                SerialError.TXFull => "The application tried to transmit a character, but the output buffer was full.",
                _ => "SerialError unknown",
            };
            Log("EVENT: IO board ErrorReceived MESSAGE: " + message);
        }

        private void IoboardPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var dataReceived = ((SerialPort)sender).ReadExisting();

            //Raises event for counter
            if (IOboardDeviceDataReceived != null)
            {
                // Instantiates the DeviceDataReceivedEventArgs object.
                DeviceDataReceivedEventArgs args = new()
                {
                    ComPort = _commandInterface.IOboardComPort.PortName,
                    Message = dataReceived
                };

                // Raise the event.
                IOboardDeviceDataReceived(this, args);
            }

            Log("EVENT:IO Board DataReceived: " + dataReceived + " EVENT TYPE: " + e.EventType.ToString());
        }
        #endregion

        #region Properties

        public bool Isconnected()
        {
            return _counterPort.IsOpen;
        }

        #endregion

        #region Commands

        public void OpenEscrow()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: OpenEscrow");
                WriteResponselessBytes(_commandInterface.OpenEscrow);
            }
            else
            {
                Log("COMMAND NOT SENT: OpenEscrow. Port is closed.");
            }

        }
        public void CloseEscrow()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: CloseEscrow");
                WriteResponselessBytes(_commandInterface.CloseEscrow);
            }
            else
            {
                Log("COMMAND NOT SENT: CloseEscrow. Port is closed.");
            }
        }

        public byte[] Sense()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: Sense");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_commandInterface.Sense);
                _counterPort.Write(bcc, 0, bcc.Length);

                Thread.Sleep(300); //todo: 200

                int BytesRead = _counterPort.BytesToRead;

                byte[] buffer = new byte[BytesRead];

                _counterPort.Read(buffer, 0, BytesRead);
                Log("COMMAND RETURN: Sense. DATA: " + Encoding.Default.GetString(buffer));

                if (buffer.Length > 20)
                    StateResultProperty = SenseParse(buffer);


                return buffer;
            }
            else
            {
                Log("COMMAND NOT SENT: Sense. Port is closed.");
                return Array.Empty<byte>();
            }
        }

        public void Reset()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: Reset");
                WriteResponselessBytes(_commandInterface.DeviceReset);
            }
            else
            {
                Log("COMMAND NOT SENT: Reset. Port is closed.");
            }
        }
        public void RemoteCancel()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: RemoteCancel");
                WriteResponselessBytes(_commandInterface.RemoteCancel);
            }
            else
            {
                Log("COMMAND NOT SENT: RemoteCancel. Port is closed.");
            }
        }
        public byte[] CountingDataRequest()
        {
            try
            {
                byte[] bcc = GetBCC(_commandInterface.CountingDataRequest);
                int totalBytes = 0;

                _counterPort.DiscardInBuffer();
                _counterPort.Write(bcc, 0, bcc.Length);
                Thread.Sleep(300);
                totalBytes = _counterPort.BytesToRead;

                byte[] buffer = new byte[totalBytes];
                _counterPort.Read(buffer, 0, totalBytes);
                Thread.Sleep(100);
                return buffer;

            }
            catch (Exception ex)
            {
                Log(ex);

                return Array.Empty<byte>();
            }
        }

        #endregion

        #region Local methods
        private void WriteResponselessBytes(byte[] data)
        {
            try
            {
                if (_counterPort.IsOpen)
                {
                    Log("FUNCTION: WriteResponselessBytes");
                    DiscardBuffer(_counterPort);
                    Thread.Sleep(300);

                    byte[] bcc = GetBCC(data);
                    _counterPort.Write(bcc, 0, bcc.Length);
                }
                else
                {
                    Log("FUNCTION NOT SENT: Sense. Port is closed.");
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }
        /// <summary>
        /// Calculate Block Check Character
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        private static byte[] GetBCC(byte[] inputStream)
        {
            byte num = 0;
            if (inputStream != null && (uint)inputStream.Length > 0U)
            {
                for (int index = 1; index < inputStream.Length; ++index)
                    num ^= inputStream[index];
            }
            byte[] numArray = new byte[inputStream.Length];
            inputStream.CopyTo((Array)numArray, 0);
            numArray[inputStream.Length - 1] = num;
            return numArray;
        }
        public static string HextoString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }
        private bool DiscardBuffer(SerialPort port)
        {
            try
            {
                if (port.IsOpen)
                {
                    Log("FUNCTION: DiscardBuffer in port: " + port.PortName);
                    port.DiscardInBuffer();
                    port.DiscardOutBuffer();
                    return true;
                }
                else
                {
                    Log("FUNCTION NOT SENT: DiscardBuffer. Port " + port.PortName + " is closed.");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }
        }

        #endregion

        #region IO board Commands 
        public bool Open()
        {
            int millisecondsTimeout = 1800;
            try
            {
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_commandInterface.Open);
                Thread.Sleep(millisecondsTimeout);
                bool retValue = ((IEnumerable<string>)this._ioboardPort.
                    ReadExisting().Split(new char[2] { '\n', '\r' },
                    StringSplitOptions.RemoveEmptyEntries)).Last<string>().ToUpper().Trim() == "OPEN";
                return retValue;
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }
        }
        public bool Close()
        {
            int millisecondsTimeout = 1800;
            try
            {
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_commandInterface.Close);
                Thread.Sleep(millisecondsTimeout);
                return ((IEnumerable<string>)this._ioboardPort.
                    ReadExisting().Split(new char[2] { '\n', '\r' },
                    StringSplitOptions.RemoveEmptyEntries)).Last<string>().ToUpper().Trim() == "CLOSED";
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }
        }

        public bool Unlock()
        {
            int millisecondsTimeout = 1800;
            try
            {
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_commandInterface.UnLock);
                Thread.Sleep(millisecondsTimeout);

                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_commandInterface.Status);
                Thread.Sleep(millisecondsTimeout);
                string Lectura = this._ioboardPort.ReadExisting();
                Thread.Sleep(500);
                string[] strArray = Lectura.Split(new char[2] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);


                List<string[]> strArrayList = this.TranslateStatus(strArray[0]);
                this.TranslateStatus(strArray[1]);
                return ((IEnumerable<string>)strArrayList.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("LOCK")))).Last<string>().ToString() == "1";
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }
        }

        public string Status()
        {
            int millisecondsTimeout = 300;
            int[] numArray = new int[5];
            try
            {
                if (!this._ioboardPort.IsOpen)
                    return "Error: port " + _ioboardPort.PortName + " not connected!";
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_commandInterface.Status);
                Thread.Sleep(millisecondsTimeout);
                string[] strArray = this._ioboardPort.ReadExisting().Split(new char[2] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);
                List<string[]> strArrayList1 = this.TranslateStatus(strArray[0]);
                List<string[]> strArrayList2 = this.TranslateStatus(strArray[1]);
                numArray[0] = ((IEnumerable<string>)strArrayList1.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("GATE")))).Last<string>().ToString() == "3" ? 0 : 1;
                numArray[2] = ((IEnumerable<string>)strArrayList1.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("LOCK")))).Last<string>().ToString() == "1" ? 1 : 0;

                if (strArrayList1[0][1] == "02")
                    numArray[3] = 1;
                else
                    numArray[3] = 0;
                numArray[4] = 1; // (((IEnumerable<string>)strArrayList1.Find((Predicate<string[]>)(s => (IEnumerable<string>)s).Contains<string>("BAG")))).Last<string>().ToString() == "02" ? 1 : 0; // || !(((IEnumerable<string>)strArrayList2.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("BAG_STATUS")))).Last<string>().ToString() != "01") || !(((IEnumerable<string>)strArrayList1.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("BAG_APROVED")))).Last<string>().ToString() == "1") ? 1 : 0;
                return string.Join<int>("", (IEnumerable<int>)numArray);
            }
            catch (Exception ex)
            {
                return "Status Error : " + ex.Message;
            }
        }

        public void CleanError()
        {
            int millisecondsTimeout = 300;
            try
            {
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_commandInterface.Status);
                Thread.Sleep(millisecondsTimeout);
                string[] strArray = this._ioboardPort.ReadExisting().Split(new char[2] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);
                List<string[]> strArrayList = this.TranslateStatus(strArray[0]);
                this.TranslateStatus(strArray[1]);
                Thread.Sleep(500);
                if (((IEnumerable<string>)strArrayList.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("BAG")))).Last<string>().ToString() == "00")
                {
                    this.DiscardBuffer(_ioboardPort);
                    this._ioboardPort.Write(_commandInterface.Empty);
                    Thread.Sleep(millisecondsTimeout);
                }
                Thread.Sleep(500);
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_commandInterface.Approve);
                Thread.Sleep(millisecondsTimeout);
            }
            catch (Exception ex)
            {
            }
        }

        public bool ApproveBag()
        {
            int millisecondsTimeout = 300;
            try
            {
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_commandInterface.Status);
                Thread.Sleep(millisecondsTimeout);
                string[] strArray1 = this._ioboardPort.ReadExisting().Split(new char[2]
                {
          '\r',
          '\n'
                }, StringSplitOptions.RemoveEmptyEntries);
                List<string[]> strArrayList1 = this.TranslateStatus(strArray1[0]);
                List<string[]> strArrayList2 = this.TranslateStatus(strArray1[1]);
                if (((IEnumerable<string>)strArrayList1.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("BAG_APROVED")))).Last<string>().ToString() != "1" && ((IEnumerable<string>)strArrayList1.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("BAG")))).Last<string>().ToString() != "02")
                {
                    this._ioboardPort.Write(_commandInterface.Approve);
                    Thread.Sleep(millisecondsTimeout);
                }
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_commandInterface.Status);
                Thread.Sleep(millisecondsTimeout);
                string[] strArray2 = this._ioboardPort.ReadExisting().Split(new char[2]
                {
          '\r',
          '\n'
                }, StringSplitOptions.RemoveEmptyEntries);
                List<string[]> strArrayList3 = this.TranslateStatus(strArray2[0]);
                strArrayList2 = this.TranslateStatus(strArray2[1]);
                return ((IEnumerable<string>)strArrayList3.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("BAG_APROVED")))).Last<string>().ToString() == "1";
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private List<string[]> TranslateStatus(string fila)
        {
            List<string[]> strArrayList = new();
            try
            {
                string[] strArray1 = ((IEnumerable<string>)fila.Split(':')).ToList<string>()[1].TrimStart().Split(new char[1]
                {
          ' '
                }, StringSplitOptions.RemoveEmptyEntries);
                for (int index = 0; (long)index < ((IEnumerable<string>)strArray1).LongCount<string>(); ++index)
                {
                    if ((long)index <= ((IEnumerable<string>)strArray1).LongCount<string>() - 2L)
                    {
                        string[] strArray2 = new string[2]
                        {
              strArray1[index],
              strArray1[index + 1]
                        };
                        strArrayList.Add(strArray2);
                        ++index;
                    }
                    else if ((long)index <= ((IEnumerable<string>)strArray1).LongCount<string>() - 1L)
                    {
                        string[] strArray2 = new string[2]
                        {
              strArray1[index],
              string.Empty
                        };
                        strArrayList.Add(strArray2);
                        ++index;
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
            return strArrayList;
        }

        #endregion

        #region Log
        private void Log(System.Exception ex)
        {
            AppendToLogFile("MESSAGE: " + ex.Message + " STACK TRACE: " + ex.StackTrace);
        }
        private void Log(string message)
        {
            AppendToLogFile(message);
        }
        private void AppendToLogFile(string message)
        {
            string logDirectory = System.IO.Directory.GetCurrentDirectory() + @"\Logs\";
            if (!System.IO.Directory.Exists(logDirectory))
                System.IO.Directory.CreateDirectory(logDirectory);


            string filename = logDirectory + _commandInterface.DeviceName + "."
                + DateTime.Now.ToString("yyyy.MM.dd") + ".log";


            System.IO.StreamWriter file = new(filename, true);
            file.WriteLine(DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss"));
            file.WriteLine(message);
            file.WriteLine("------------------------------------------------------------------------");
            file.Close();
        }

        #endregion

        #region Base Events
        void IDisposable.Dispose()
        {
            try
            {
                Log("EVENT: Dispose ");
                if (_counterPort.IsOpen)
                    _counterPort.Close();
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }
        #endregion

        #region Legacy

        private static int BinaryToDecimal(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse((Array)charArray);
            int num = 0;
            for (int index = 0; index < charArray.Length; ++index)
            {
                if (charArray[index] == '1')
                    num += (int)Math.Pow(2.0, (double)index);
            }
            return num;
        }
        private StatesResult SenseParse(byte[] numArray)
        {
            try
            {
                StatesResult statesResult = new();


                if (_counterPort.IsOpen)
                {
                    BitArray StatusInformationBitArray = new((int)numArray[4]);
                    string StateInput = (StatusInformationBitArray[0] ? 1 : 0).ToString() + (object)(StatusInformationBitArray[1] ? 1 : 0) + (object)(StatusInformationBitArray[2] ? 1 : 0) + (object)(StatusInformationBitArray[3] ? 1 : 0) + (object)(StatusInformationBitArray[4] ? 1 : 0) + (object)(StatusInformationBitArray[5] ? 1 : 0);
                    statesResult.StatusInformation.OperatingState = (StatusInformation.State)BinaryToDecimal(StateInput);

                    BitArray EndInformationBitArray = new(new byte[1] { numArray[5] });
                    statesResult.EndInformation.CollectEnd = EndInformationBitArray[5];
                    statesResult.EndInformation.StoreEnd = EndInformationBitArray[4];
                    statesResult.EndInformation.RestorationEnd = EndInformationBitArray[3];
                    statesResult.EndInformation.BatchEnd = EndInformationBitArray[2];
                    statesResult.EndInformation.AbnormalEnd = EndInformationBitArray[1];
                    statesResult.EndInformation.CountEnd = EndInformationBitArray[0];

                    BitArray DeviceStateInformationBitArray = new(new byte[1] { numArray[6] });
                    statesResult.DeviceStateInformation.RejectFull = DeviceStateInformationBitArray[5];
                    statesResult.DeviceStateInformation.StackerFull = DeviceStateInformationBitArray[4];
                    statesResult.DeviceStateInformation.DischargingFailure = DeviceStateInformationBitArray[3];
                    statesResult.DeviceStateInformation.RejectedBillPresent = DeviceStateInformationBitArray[2];
                    statesResult.DeviceStateInformation.EscrowBillPresent = DeviceStateInformationBitArray[1];
                    statesResult.DeviceStateInformation.HopperBillPresent = DeviceStateInformationBitArray[0];

                    BitArray ErrorStateInformationBitArray = new(new byte[1] { numArray[7] });

                    statesResult.ErrorStateInformation.AbnormalStorage = ErrorStateInformationBitArray[3];
                    statesResult.ErrorStateInformation.AbnormalDevice = ErrorStateInformationBitArray[2];
                    statesResult.ErrorStateInformation.CountingError = ErrorStateInformationBitArray[1];
                    statesResult.ErrorStateInformation.Jamming = ErrorStateInformationBitArray[0];

                    BitArray ModeStateInformationBitArray = new(new byte[1] { numArray[8] });
                    string ModeInput = (ModeStateInformationBitArray[5] ? 1 : 0).ToString() + (object)(ModeStateInformationBitArray[4] ? 1 : 0) + (object)(ModeStateInformationBitArray[3] ? 1 : 0) + (object)(ModeStateInformationBitArray[2] ? 1 : 0) + (object)(ModeStateInformationBitArray[1] ? 1 : 0) + (object)(ModeStateInformationBitArray[0] ? 1 : 0);
                    statesResult.ModeStateInformation.ModeState = (ModeStateInformation.Mode)BinaryToDecimal(ModeInput);

                    BitArray DoorStateInformationBitArray = new(new byte[1] { numArray[9] });
                    statesResult.DoorStateInformation.Escrow = DoorStateInformationBitArray[5];
                    statesResult.DoorStateInformation.CassetteFull = DoorStateInformationBitArray[2];

                    BitArray CountryCodeBitArray = new(new byte[1] { numArray[10] });
                    string CurrencyInput = (CountryCodeBitArray[0] ? 1 : 0).ToString() + (object)(CountryCodeBitArray[1] ? 1 : 0) + (object)(CountryCodeBitArray[2] ? 1 : 0);
                    statesResult.CountryCode.CurrencyStateInformation = (CountryCode.Currency)BinaryToDecimal(CurrencyInput);

                    if (statesResult.ErrorStateInformation.AbnormalDevice || statesResult.ErrorStateInformation.Jamming)
                    {
                        // ISSUE: reference to a compiler-generated field
                        ECError((object)_counterPort, new ECErrorArgs()
                        {
                            Errorcode = 8
                        });
                    }
                    if (statesResult.ErrorStateInformation.AbnormalStorage)
                    {
                        // ISSUE: reference to a compiler-generated field
                        ECError((object)_counterPort, new ECErrorArgs()
                        {
                            Errorcode = 1
                        });
                    }
                    if (statesResult.ErrorStateInformation.CountingError)
                    {
                        // ISSUE: reference to a compiler-generated field
                        ECError((object)_counterPort, new ECErrorArgs()
                        {
                            Errorcode = 3
                        });
                    }

                }
                return statesResult;
            }
            catch (Exception ex)
            {
                Log(ex.Message + " " + ex.StackTrace);
                return new StatesResult();
            }
        }
        #endregion

        #pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
    #region Event classes

    public class DeviceDataReceivedEventArgs : EventArgs
    {
        // The com port
        public string ComPort = string.Empty;

        // Received message
        public string Message = string.Empty;
    }
    public class ECErrorArgs : EventArgs
    {
        public int Errorcode { get; set; }
    }


    #region Legacy Status Classes
    public class StatesResult
    {
        public StatusInformation StatusInformation { get; set; }

        public EndInformation EndInformation { get; set; }

        public DeviceStateInformation DeviceStateInformation { get; set; }

        public ErrorStateInformation ErrorStateInformation { get; set; }

        public ModeStateInformation ModeStateInformation { get; set; }

        public DoorStateInformation DoorStateInformation { get; set; }

        public CountryCode CountryCode { get; set; }

        public bool NoResult { get; set; }

        public StatesResult()
        {
            StatusInformation = new StatusInformation();
            EndInformation = new EndInformation();
            DeviceStateInformation = new DeviceStateInformation();
            ErrorStateInformation = new ErrorStateInformation();
            ModeStateInformation = new ModeStateInformation();
            DoorStateInformation = new DoorStateInformation();
            CountryCode = new CountryCode();
        }

        public string PrintStateResult()
        {
            return "" + "Status Information: \n" + "- Operating State: " + StatusInformation.OperatingState.ToString() + "\n" + "\n" + "End Information: \n" + "- Storage End: " + EndInformation.StoreEnd.ToString() + "\n" + "- Restoration End: " + EndInformation.RestorationEnd.ToString() + "\n" + "- Count End: " + EndInformation.CountEnd.ToString() + "\n" + "- Collect End: " + EndInformation.CollectEnd.ToString() + "\n" + "- Batch End: " + EndInformation.BatchEnd.ToString() + "\n" + "- Abnormal End: " + EndInformation.AbnormalEnd.ToString() + "\n" + "\n" + "Device State information: \n" + "- Discharging Failure: " + DeviceStateInformation.DischargingFailure.ToString() + "\n" + "- Escrow Bill Present: " + DeviceStateInformation.EscrowBillPresent.ToString() + "\n" + "- Hopper Bill Present: " + DeviceStateInformation.HopperBillPresent.ToString() + "\n" + "- Reject Bill Present: " + DeviceStateInformation.RejectedBillPresent.ToString() + "\n" + "- Reject Full: " + DeviceStateInformation.RejectFull.ToString() + "\n" + "- Stacker Full: " + DeviceStateInformation.StackerFull.ToString() + "\n" + "\n" + "Error State Information: \n" + "- Abnormal Device: " + ErrorStateInformation.AbnormalDevice.ToString() + "\n" + "- Abnormal Storage: " + ErrorStateInformation.AbnormalStorage.ToString() + "\n" + "- Counting error: " + ErrorStateInformation.CountingError.ToString() + "\n" + "- Jamming: " + ErrorStateInformation.Jamming.ToString() + "\n" + "\n" + "Mode State Information: \n" + "- Mode State: " + ModeStateInformation.ModeState.ToString() + "\n" + "\n" + "Door State Information: \n" + "- Escrow: " + DoorStateInformation.Escrow.ToString() + "\n" + "- Cassette Full: " + DoorStateInformation.CassetteFull.ToString() + "\n" + "\n" + "Country Code: \n" + "- Currency State information: " + CountryCode.CurrencyStateInformation.ToString() + "\n";
        }

        public bool IsPreparedForNeutralMode()
        {
            return !DeviceStateInformation.HopperBillPresent && !DeviceStateInformation.RejectedBillPresent;
        }

        public bool IsNotPreparedForBatch()
        {
            return StatusInformation.OperatingState == StatusInformation.State.Waiting && !DeviceStateInformation.HopperBillPresent;
        }

        public bool IsNormalError()
        {
            bool flag = false;
            if (ErrorStateInformation.Jamming || ErrorStateInformation.CountingError || (ErrorStateInformation.AbnormalDevice || EndInformation.AbnormalEnd)) //|| DeviceStateInformation.DischargingFailure)
                flag = true;
            return flag;
        }

        public bool IsCounting()
        {
            return !EndInformation.CountEnd && !IsNormalError();
        }
    }


    public class StatusInformation
    {
        public StatusInformation.State OperatingState { get; set; }

        public StatusInformation()
        {
            OperatingState = StatusInformation.State.Waiting;
        }

        public enum State
        {
            Waiting,
            Counting,
            CountingStartRequest,
            AbnormalDevice,
            BeingReset,
            BeingStore,
            BeingRestoration,
            BeingExchangeTheCassette,
            StoringStartRequest,
            BeingRecoverFromStoringError,
            EscrowOpenRequest,
            EscrowCloseRequest,
            EscrowOpen,
            EscrowClose,
            InitializeStartRequest,
            BeginInitialize,
            BeingSet,
            LocalOperation,
            StoringError,
            WaitingForAnEnvelopeToSet,
        }
    }


    public class ModeStateInformation
    {
        public ModeStateInformation.Mode ModeState { get; set; }

        public ModeStateInformation()
        {
            ModeState = ModeStateInformation.Mode.Neutral_SettingMode;
        }

        public enum Mode
        {
            Neutral_SettingMode = 0,
            InitialMode = 1,
            DepositMode = 2,
            ManualMode = 3,
            NormalErrorRecoveryMode = 4,
            StoringErrorRecoveryMode = 5,
            CorrectMode = 6,
            Unknow = 48, // 0x00000030
        }
    }

    public class ErrorStateInformation
    {
        public bool AbnormalStorage { get; set; }

        public bool AbnormalDevice { get; set; }

        public bool CountingError { get; set; }

        public bool Jamming { get; set; }

        public ErrorStateInformation()
        {
            AbnormalStorage = false;
            AbnormalDevice = false;
            CountingError = false;
            Jamming = false;
        }
    }

    public class EndInformation
    {
        public bool CollectEnd { get; set; }

        public bool StoreEnd { get; set; }

        public bool RestorationEnd { get; set; }

        public bool BatchEnd { get; set; }

        public bool AbnormalEnd { get; set; }

        public bool CountEnd { get; set; }

        public EndInformation()
        {
            CollectEnd = false;
            StoreEnd = false;
            RestorationEnd = false;
            BatchEnd = false;
            AbnormalEnd = false;
            CountEnd = false;
        }
    }

    public class DoorStateInformation
    {
        public bool Escrow { get; set; }

        public bool CassetteFull { get; set; }

        public DoorStateInformation()
        {
            Escrow = false;
            CassetteFull = false;
        }
    }

    public class DeviceStateInformation
    {
        public bool RejectFull { get; set; }

        public bool StackerFull { get; set; }

        public bool DischargingFailure { get; set; }

        public bool RejectedBillPresent { get; set; }

        public bool EscrowBillPresent { get; set; }

        public bool HopperBillPresent { get; set; }

        public DeviceStateInformation()
        {
            RejectFull = false;
            StackerFull = false;
            DischargingFailure = false;
            RejectedBillPresent = false;
            HopperBillPresent = false;
        }

        public bool GetBillPresentDevice()
        {
            return HopperBillPresent || RejectedBillPresent || EscrowBillPresent;
        }

        public bool GetHopperRejectBillPresent()
        {
            return HopperBillPresent || RejectedBillPresent;
        }
    }

    public class DenominationResult
    {

        SortedList<int, int> Denominations;

        public DenominationResult()
        {
            Denominations = new SortedList<int, int>();

        }

        public bool AddDenomination(int key, int cantidad)
        {


            if (!Denominations.ContainsKey(key))
            {
                Denominations.Add(key, cantidad);

            }
            else
            {

                Denominations[key] = cantidad;
            }

            return false;
        }
        public int GetByDenomination(int key)
        {
            if (!Denominations.ContainsKey(key))

                return 0;

            else
                return Denominations[key];
        }



        //public int DiezARS { get; set; }
        //public int VeinteARS { get; set; }

        //public int Mil { get; set; }

        //public int DosMil { get; set; }

        //public int CincoMil { get; set; }

        //public int DiezMil { get; set; }

        //public int VeinteMil { get; set; }

        //public long GetTotalPesos()
        //{
        //    return GetTotalDiezARS() + GetTotalVeinteARS() + GetTotalMil() + GetTotalDosMil() + GetTotalCincoMil() + GetTotalDiezMil() + GetTotalVeinteMil();
        //}

        //public long GetTotalContado()
        //{
        //    return (long)(DiezARS + VeinteARS + Mil + DosMil + CincoMil + DiezMil + VeinteMil);
        //}

        //public long GetTotalDiezARS()
        //{
        //    return (long)(DiezARS * 10);
        //}

        //public long GetTotalVeinteARS()
        //{
        //    return (long)(VeinteARS * 20);
        //}


        //public long GetTotalMil()
        //{
        //    return (long)(Mil * 50);
        //}

        //public long GetTotalDosMil()
        //{
        //    return (long)(DosMil * 100);
        //}

        //public long GetTotalCincoMil()
        //{
        //    return (long)(CincoMil * 200);
        //}

        //public long GetTotalDiezMil()
        //{
        //    return (long)(DiezMil * 500);
        //}

        //public long GetTotalVeinteMil()
        //{
        //    return (long)(VeinteMil * 1000);
        //}

        //public string PrintCLPDenominationResult()
        //{
        //    return "" + "$1.000 x " + (object)Mil + "\n" + "$2.000 x " + (object)DosMil + "\n" + "$5.000 x " + (object)CincoMil + "\n" + "$10.000 x " + (object)DiezMil + "\n" + "$20.000 x " + (object)VeinteMil + "\n" + "Total Billetes Contados = " + (object)GetTotalContado() + "\n" + "Total Pesos = $" + GetTotalPesos().ToString("n", (IFormatProvider)CultureInfo.CurrentCulture) + "\n";
        //}

        public SortedList<int, int> GetData()
        {


            return Denominations;
        }
    }

    public class CountryCode
    {
        public CountryCode.Currency CurrencyStateInformation { get; set; }

        public CountryCode()
        {
            CurrencyStateInformation = CountryCode.Currency.FirstCurrency;
        }

        public enum Currency
        {
            FirstCurrency,
            SecondCurrency,
            ThirdCurrency,
            FourthCurrency,
            FifthCurrency,
            SixthCurrency,
            SeventhCurrency,
        }
    }
    #endregion
}
#endregion

