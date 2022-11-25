using Microsoft.Win32;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.CustomExceptions;
using System.Collections;
using System.Configuration;
using System.IO.Ports;
using System.Security.Permissions;
using System.Text;


namespace Permaquim.Depositary.UI.Desktop.Components
{
    public class CounterDevice : IDisposable
    {
        #region Local variables

        //Serial port instance
        private SerialPort _counterPort;
        private SerialPort _ioboardPort;
        /// <summary>
        /// Holds the last quantity of bytes received from counter
        /// </summary>
        private long _counterLastBytesRead = 0;
        /// <summary>
        /// Holds the last quantity of bytes received from IO Board
        /// </summary>
        private long _ioBoardLastBytesRead = 0;

        private static string _readbuffer = string.Empty;

        // Device instance
        private DEXDevice _device = null;

        private bool _deviceLogEnabled = ParameterController.DeviceLogEnabled;

        public StatusInformation.State PreviousState { get; set; }
        public StatusInformation.State CurrentStatus
        {
            get
            {
                return this.StateResultProperty.StatusInformation.OperatingState;
            }
        }

        private IoBoardStatus _ioBoardStatus;

        public IoBoardStatus IoBoardStatusProperty
        {
            get { return _ioBoardStatus; }
        }

        private StatesResult _stateResultProperty;

        public StatesResult StateResultProperty
        {
            get { return _stateResultProperty; }
        }
        public DenominationResult DenominationResultProperty { get; set; } = new DenominationResult();

        public event EventHandler<ECErrorArgs> ECError;
        public int SleepTimeout { get; set; }

        #endregion

        #region Device Events

        public delegate void DeviceDataReceivedEventHandler(object sender, DeviceDataReceivedEventArgs args);

        public event DeviceDataReceivedEventHandler CounterDeviceDataReceived;
        public event DeviceDataReceivedEventHandler IOboardDeviceDataReceived;

        public delegate void DeviceErrorReceivedEventHandler(object sender, DeviceErrorEventArgs args);

        public event DeviceErrorReceivedEventHandler DeviceErrorReceived;

        #endregion

        #region Constants

        public const string NULL = "[NULL]";
        public const string START_OF_HEADING = "[START OF HEADING]";
        public const string START_OF_TEXT = "[START OF TEXT]";
        public const string END_OF_TEXT = "[END OF TEXT]";
        public const string END_OF_TRANSMISSION = "[END OF TRANSMISSION]";
        public const string ENQUIRY = "[ENQUIRY]";
        public const string ACKNOWLEDGE = "[ACKNOWLEDGE]";

        public const string ALERT = "[ALERT]";
        public const string BACKSPACE = "[BACKSPACE]";
        public const string CHARACTER_TABULATION = "[CHARACTER TABULATION]";
        public const string DATA_LINK_ESCAPE = "[DATA LINK ESCAPE]";

        public const string DEVICE_CONTROL_1 = "[DEVICE CONTROL 1]";
        public const string DEVICE_CONTROL_2 = "[DEVICE CONTROL 2]";
        public const string DEVICE_CONTROL_3 = "[DEVICE CONTROL 3]";
        public const string DEVICE_CONTROL_4 = "[DEVICE CONTROL 4]";
        public const string NEGATIVE_ACKNOWLEDGE = "[NEGATIVE ACKNOWLEDGE]";
        public const string SYNCHRONOUS_IDLE = "[SYNCHRONOUS IDLE]";
        public const string END_OF_TRANSMISSION_BLOCK = "[END OF TRANSMISSION BLOCK]";
        public const string CANCEL = "[CANCEL]";
        public const string END_OF_MEDIUM = "[END OF MEDIUM]";
        public const string SPACE = "[SPACE]";


        public const string UNKNOWN = "UNKNOWN";
        public const string NO_DATA = "NO DATA";

        const byte NUL = 0x00; // NULL
        const byte SOH = 0x01; // START OF HEADING
        const byte STX = 0x02; // START OF TEXT
        const byte ETX = 0x03; // END OF TEXT
        const byte EOT = 0x04; // END OF TRANSMISION
        const byte ENQ = 0x05; // ENQUIRY
        const byte ACK = 0x06; // ACKNOWLEDGE
        const byte BEL = 0x07; // ALERT
        const byte BS = 0x08;  // BACKSPACE
        const byte HT = 0x09;  // CHARACTER TABULATION
        const byte DLE = 0x10; // DATA LINK ESCAPE
        const byte DC1 = 0x11; // DEVICE CONTROL 1
        const byte DC2 = 0x12; // DEVICE CONTROL 2 
        const byte DC3 = 0x13; // DEVICE CONTROL 3
        const byte DC4 = 0x14; // DEVICE CONTROL 4
        const byte NAK = 0x15; // NEGATIVE ACKNOWLEDGE
        const byte SYN = 0x16; // SYNCHRONOUS IDLE
        const byte ETB = 0x17; // END OF TRANSMISSION BLOCK
        const byte CAN = 0x18; // CANCEL
        const byte EOM = 0x19; // END OF MEDIUM
        const byte SP = 0x20;  // SPACE
        private const int MINIMUM_DATA_SIZE = 22;
        #endregion

        public List<string> Ports
        {
            get
            {
                return SerialPort.GetPortNames().ToList<string>();
            }
        }
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="device"></param>
        public CounterDevice(DEXDevice device)
        {

            _device = device;
            Log("FUNCTION: Counter Device initializing in COM Port: " + device.CounterComPort.PortName + ".");
            try
            {
                if (Ports.Exists(e => e.EndsWith(device.CounterComPort.PortName)))
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
                    _counterPort.Open();

                    DiscardBuffer(_counterPort);

                    Log("FUNCTION: Port " + device.CounterComPort.PortName + " should be open.");
                }
                else
                {
                    throw new CommPortException()
                    {
                        ExceptionMessage = "Port " + device.CounterComPort.PortName + " not present.",
                        PortName = device.CounterComPort.PortName
                    };
                }

                if (Ports.Exists(e => e.EndsWith(device.IOboardComPort.PortName)))
                {

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
                    _ioboardPort.Open();

                    DiscardBuffer(_ioboardPort);

                    Log("FUNCTION: Port " + device.IOboardComPort.PortName + " should be open.");
                }
                else
                {
                    throw new CommPortException()
                    {
                        ExceptionMessage = "Port " + device.CounterComPort.PortName + " not present.",
                        PortName = device.CounterComPort.PortName
                    };
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            var portNames = SerialPort.GetPortNames();
        }

        public CounterDevice()
        {
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
            _readbuffer = ((SerialPort)sender).ReadExisting();
            string readbufferData = string.Empty;

            foreach (var item in _readbuffer)
            {

                if (_readbuffer.Length > 0)
                {
                    readbufferData += item switch
                    {
                        '\u0000' => NULL,
                        '\u0001' => START_OF_HEADING,
                        '\u0002' => START_OF_TEXT,
                        '\u0003' => END_OF_TEXT,
                        '\u0004' => END_OF_TRANSMISSION,
                        '\u0005' => ENQUIRY,
                        '\u0006' => ACKNOWLEDGE,
                        '\u0007' => ALERT,
                        '\u0008' => BACKSPACE,
                        '\u0009' => CHARACTER_TABULATION,
                        '\u0010' => DATA_LINK_ESCAPE,
                        '\u0011' => DEVICE_CONTROL_1,
                        '\u0012' => DEVICE_CONTROL_2,
                        '\u0013' => DEVICE_CONTROL_3,
                        '\u0014' => DEVICE_CONTROL_4,
                        '\u0015' => NEGATIVE_ACKNOWLEDGE,
                        '\u0016' => SYNCHRONOUS_IDLE,
                        '\u0017' => END_OF_TRANSMISSION_BLOCK,
                        '\u0018' => CANCEL,
                        '\u0019' => END_OF_MEDIUM,
                        '\u0020' => SPACE,
                        _ => item,
                    };


                }
            }


            //Raises event for counter
            if (CounterDeviceDataReceived != null && _readbuffer.Contains('\u0017'))
            {
                _readbuffer = string.Empty;
                // Instantiates the DeviceDataReceivedEventArgs object.
                DeviceDataReceivedEventArgs args = new()
                {
                    ComPort = _device.CounterComPort.PortName,
                    Message = _readbuffer + Environment.NewLine + readbufferData
                    //Message = "Data: " + dataReceived + Environment.NewLine + dataReference
                };

                // Raise the event.
                CounterDeviceDataReceived(this, args);
            }

            //Log("EVENT: Counter DataReceived: " + dataReceived + " EVENT TYPE: " + e.EventType.ToString());
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
                    ComPort = _device.IOboardComPort.PortName,
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
                WriteBytes(_device.OpenEscrow);
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
                WriteBytes(_device.CloseEscrow);
            }
            else
            {
                Log("COMMAND NOT SENT: CloseEscrow. Port is closed.");
            }
        }

        public StatesResult Sense()
        {
            if (_counterPort != null && _counterPort.IsOpen)
            {
                Log("COMMAND: Sense");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.Sense);
                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());
                if (_buffer.Count > 100)
                    DenominationResultProperty = ParseDenominationResult(_buffer.ToArray<byte>());
                _counterLastBytesRead = _buffer.Count;

                _buffer.Clear();

                if (CounterDeviceDataReceived != null)
                {
                    _readbuffer = string.Empty;
                    // Instantiates the DeviceDataReceivedEventArgs object.
                    DeviceDataReceivedEventArgs args = new()
                    {
                        ComPort = _device.CounterComPort.PortName,
                        Message = Encoding.Default.GetString(_buffer.ToArray<byte>())
                    };
                    CounterDeviceDataReceived(this, args);
                }


                return StateResultProperty;
            }
            else
            {
                _counterLastBytesRead = 0;

                Log("COMMAND NOT SENT: Sense. Port is closed.");
                return StateResultProperty;
            }
        }



        public StatesResult StopCounting()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: StopCounting");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.StopCounting);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: StopCounting. Port is closed.");
                return StateResultProperty;
            }
        }
        public StatesResult StoringStart()
        {
            if (_counterPort != null && _counterPort.IsOpen)
            {
                Log("COMMAND: StoringStart");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.StoringStart);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterSimpleResponse();

                _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return _stateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: StoringStart. Port is closed.");
                return StateResultProperty;
            }
        }

        public StatesResult SwitchCurrency(long counterIndex)
        {
            if (_counterPort != null && _counterPort.IsOpen)
            {
                Log("COMMAND: StoringStart");
                DiscardBuffer(_counterPort);
                byte[] currencyRequest = _device.SwitchCurrency;

                currencyRequest[5] = BitConverter.GetBytes(counterIndex)[0];

                byte[] bcc = GetBCC(currencyRequest);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterSimpleResponse();

                _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return _stateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: StoringStart. Port is closed.");
                return StateResultProperty;
            }
        }

        public StatesResult BatchDataTransmission()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: BatchDataTransmission");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.BatchDataTransmission);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse2();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());
                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: BatchDataTransmission. Port is closed.");
                return StateResultProperty;
            }
        }


        public StatesResult DenominationDataRequest()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: DenominationDataRequest");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.DenominationDataRequest);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: DenominationDataRequest. Port is closed.");
                return StateResultProperty;
            }
        }

        public StatesResult ManualDepositMode()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: ManualDepositMode");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.ManualDepositMode);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: ManualDepositMode. Port is closed.");
                return StateResultProperty;
            }
        }
        public StatesResult DepositMode()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: DepositMode");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.DepositMode);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: DepositMode. Port is closed.");
                return StateResultProperty;
            }
        }
        /// <summary>
        /// Consulta el buffer de denominaciones detectadas
        /// </summary>
        /// <returns></returns>
        public StatesResult CountingDataRequest()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: CountingDataRequest");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.CountingDataRequest);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 100)
                    this.DenominationResultProperty.DenominationArray = ParseDenomination(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: CountingDataRequest. Port is closed.");
                return StateResultProperty;
            }
        }
        public StatesResult DeviceReset()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: DeviceReset");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.DeviceReset);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: DeviceReset. Port is closed.");
                return StateResultProperty;
            }
        }
        public StatesResult RemoteCancel()
        {
            if (_counterPort != null && _counterPort.IsOpen)
            {
                Log("COMMAND: RemoteCancel");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.RemoteCancel);
                Thread.Sleep(SleepTimeout);
                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterSimpleResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: RemoteCancel. Port is closed.");
                return StateResultProperty;
            }
        }


        public StatesResult CollectMode()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: CollectMode");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.CollectMode);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: CollectMode. Port is closed.");
                return StateResultProperty;
            }
        }

        public StatesResult NormalErrorRecoveryMode()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: NormalErrorRecoveryMode");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.NormalErrorRecoveryMode);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: NormalErrorRecoveryMode. Port is closed.");
                return StateResultProperty;
            }
        }
        public StatesResult StoringErrorRecoveryMode()
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: StoringErrorRecoveryMode");
                DiscardBuffer(_counterPort);
                byte[] bcc = GetBCC(_device.StoringErrorRecoveryMode);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterResponse();

                if (_buffer.Count > 20)
                    _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return StateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: StoringErrorRecoveryMode. Port is closed.");
                return StateResultProperty;
            }
        }
        private List<byte> ReadCounterResponse()
        {
            List<byte> _buffer = new();
            Thread.Sleep(SleepTimeout);
            while (true)
            {
                if (_counterPort.IsOpen)
                {
                    var bytes = _counterPort.BytesToRead;
                    if (bytes > 0)
                    {
                        byte[] buffer = new byte[bytes];
                        var countBytes = _counterPort.BaseStream.Read(buffer, 0, bytes);
                        _buffer.AddRange(buffer);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    return _buffer;
                }

            }

            if (CounterDeviceDataReceived != null)
            {
                _readbuffer = string.Empty;
                // Instantiates the DeviceDataReceivedEventArgs object.
                DeviceDataReceivedEventArgs args = new()
                {
                    ComPort = _device.CounterComPort.PortName,
                    Message = Encoding.Default.GetString(_buffer.ToArray<byte>())
                };
                CounterDeviceDataReceived(this, args);
            }
            return _buffer;
        }

        private List<byte> ReadCounterSimpleResponse()
        {
            List<byte> _buffer = new();
            Thread.Sleep(SleepTimeout);
            while (true)
            {
                if (_counterPort.IsOpen)
                {
                    var bytes = _counterPort.BytesToRead;
                    if (bytes > 0)
                    {
                        byte[] buffer = new byte[bytes];
                        var countBytes = _counterPort.BaseStream.Read(buffer, 0, bytes);
                        _buffer.AddRange(buffer);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    return _buffer;
                }

            }

            if (CounterDeviceDataReceived != null)
            {
                _readbuffer = string.Empty;
                // Instantiates the DeviceDataReceivedEventArgs object.
                DeviceDataReceivedEventArgs args = new()
                {
                    ComPort = _device.CounterComPort.PortName,
                    Message = Encoding.Default.GetString(_buffer.ToArray<byte>())
                };
                CounterDeviceDataReceived(this, args);
            }
            return _buffer;
        }

        private List<byte> ReadCounterResponse2()
        {
            List<byte> _buffer = new();
            Thread.Sleep(SleepTimeout);
            while (this.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQCounting)
            {
                var bytes = _counterPort.BytesToRead;
                if (bytes > 0)
                {
                    byte[] buffer = new byte[bytes];
                    var countBytes = _counterPort.BaseStream.Read(buffer, 0, bytes);
                    _buffer.AddRange(buffer);
                }
                else
                {
                    break;
                }
            }

            if (CounterDeviceDataReceived != null)
            {
                _readbuffer = string.Empty;
                // Instantiates the DeviceDataReceivedEventArgs object.
                DeviceDataReceivedEventArgs args = new()
                {
                    ComPort = _device.CounterComPort.PortName,
                    Message = Encoding.Default.GetString(_buffer.ToArray<byte>())
                };
                CounterDeviceDataReceived(this, args);
            }
            return _buffer;
        }

        private string ReadIoBoardResponse()
        {
            List<byte> _buffer = new();
            Thread.Sleep(SleepTimeout);
            while (true)
            {
                var bytes = _ioboardPort.BytesToRead;


                if (bytes > 0)
                {
                    byte[] buffer = new byte[bytes];
                    var countBytes = _ioboardPort.BaseStream.Read(buffer, 0, bytes);
                    _buffer.AddRange(buffer);
                }
                else
                {
                    break;
                }
            }

            _ioBoardLastBytesRead = _buffer.Count;

            if (IOboardDeviceDataReceived != null)
            {
                _readbuffer = string.Empty;
                // Instantiates the DeviceDataReceivedEventArgs object.
                DeviceDataReceivedEventArgs args = new()
                {
                    ComPort = _device.IOboardComPort.PortName,
                    Message = Encoding.Default.GetString(_buffer.ToArray<byte>())
                };
                IOboardDeviceDataReceived(this, args);
            }
            ASCIIEncoding encoding = new ASCIIEncoding();
            string data = encoding.GetString(_buffer.ToArray());

            return data;
        }

        public void Sleep()
        {
            Thread.Sleep(SleepTimeout);
        }

        #endregion

        #region Local methods
        private void WriteBytes(byte[] data)
        {
            try
            {
                if (_counterPort.IsOpen)
                {
                    Log("FUNCTION: WriteResponselessBytes");
                    DiscardBuffer(_counterPort);

                    byte[] bcc = GetBCC(data);
                    _counterPort.Write(bcc, 0, bcc.Length);
                    ReadCounterResponse();
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


        public StatesResult SwitchToCurrency(int currencyNumber)
        {
            if (_counterPort.IsOpen)
            {
                Log("COMMAND: StoringStart");
                DiscardBuffer(_counterPort);



                byte[] currencyRequest = new byte[8] { (byte)2, (byte)48, (byte)48, (byte)50, (byte)57, (byte)49, (byte)3, (byte)0 };

                int baseValue = 48;


                currencyRequest[5] = BitConverter.GetBytes(baseValue + currencyNumber)[0];

                byte[] bcc = GetBCC(currencyRequest);

                _counterPort.BaseStream.Write(bcc, 0, bcc.Length);

                List<byte> _buffer = ReadCounterSimpleResponse();

                _stateResultProperty = SenseParse(_buffer.ToArray<byte>());

                _buffer.Clear();

                return _stateResultProperty;
            }
            else
            {
                Log("COMMAND NOT SENT: StoringStart. Port is closed.");
                return StateResultProperty;
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
                this._ioboardPort.Write(_device.Open);
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
                this._ioboardPort.Write(_device.Close);
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
                this._ioboardPort.Write(_device.UnLock);
                Thread.Sleep(millisecondsTimeout);

                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_device.Status);
                Thread.Sleep(millisecondsTimeout);
                string Lectura = this._ioboardPort.ReadExisting();
                Thread.Sleep(SleepTimeout);
                string[] strArray = Lectura.Split(new char[2] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);


                List<string[]> strArrayList = this.TranslateStatus(strArray[0]);
                this.TranslateStatus(strArray[1]);
                return ((IEnumerable<string>)strArrayList.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("LOCK")))).Last<string>().ToString() == "1";
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IoBoardStatus Status()
        {
            IoBoardStatus result = new();
            try
            {
                if (this._ioboardPort != null && this._ioboardPort.IsOpen)
                {

                    this._ioboardPort.Write(_device.Status);

                    result.ParseStatus(ReadIoBoardResponse());

                    _ioBoardStatus = result;
                }
                else
                {
                    _ioBoardLastBytesRead = 0;
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
            finally
            {
                result = null;
            }
        }

        public void CleanError()
        {
            int millisecondsTimeout = 300;
            try
            {
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_device.Status);
                Thread.Sleep(millisecondsTimeout);
                string[] strArray = this._ioboardPort.ReadExisting().Split(new char[2] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);
                List<string[]> strArrayList = this.TranslateStatus(strArray[0]);
                this.TranslateStatus(strArray[1]);
                Thread.Sleep(SleepTimeout);
                if (((IEnumerable<string>)strArrayList.Find((Predicate<string[]>)(s => ((IEnumerable<string>)s).Contains<string>("BAG")))).Last<string>().ToString() == "00")
                {
                    this.DiscardBuffer(_ioboardPort);
                    this._ioboardPort.Write(_device.Empty);
                    Thread.Sleep(millisecondsTimeout);
                }
                Thread.Sleep(SleepTimeout);
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_device.Approve);
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
                this._ioboardPort.Write(_device.Status);
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
                    this._ioboardPort.Write(_device.Approve);
                    Thread.Sleep(millisecondsTimeout);
                }
                this.DiscardBuffer(_ioboardPort);
                this._ioboardPort.Write(_device.Status);
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
        public void Log(System.Exception ex)
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

            string filename = logDirectory + _device.DeviceName + "."
                + DateTime.Now.ToString("yyyy.MM.dd") + ".log";

            if (_deviceLogEnabled)
            {
                System.IO.StreamWriter file = new(filename, true);
                file.WriteLine(DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss"));
                file.WriteLine(message);
                file.WriteLine("------------------------------------------------------------------------");
                file.Close();

            }
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
                {   // Por alguna razón, la respuesta tiene ocasionalmente 1 solo byte.
                    if (numArray.Length >= MINIMUM_DATA_SIZE)
                    {

                        BitArray StatusInformationBitArray = new BitArray(new byte[] { numArray[4] });

                        string StateInput =
                            (StatusInformationBitArray[0] ? 1 : 0).ToString() +
                            (StatusInformationBitArray[1] ? 1 : 0).ToString() +
                            (StatusInformationBitArray[2] ? 1 : 0).ToString() +
                            (StatusInformationBitArray[3] ? 1 : 0).ToString() +
                            (StatusInformationBitArray[4] ? 1 : 0).ToString() +
                            (StatusInformationBitArray[5] ? 1 : 0).ToString();

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

                        if (statesResult.ErrorStateInformation.AbnormalDevice)
                        {
                            if (DeviceErrorReceived != null)
                            {

                                DeviceErrorEventArgs args = new()
                                {
                                    ErrorCode = "FF02",
                                    ErrorDescription = "AbnormalDevice"
                                };

                                DeviceErrorReceived(this, args);
                            }

                        }

                        if (statesResult.ErrorStateInformation.Jamming)
                        {
                            if (DeviceErrorReceived != null)
                            {

                                DeviceErrorEventArgs args = new()
                                {
                                    ErrorCode = "Jamming",
                                    ErrorDescription = "Jamming"
                                };
                                DeviceErrorReceived(this, args);
                            }
                        }

                        if (statesResult.ErrorStateInformation.AbnormalStorage)
                        {
                            if (DeviceErrorReceived != null)
                            {

                                DeviceErrorEventArgs args = new()
                                {
                                    ErrorCode = "AbnormalStorage",
                                    ErrorDescription = "AbnormalStorage"
                                };
                                DeviceErrorReceived(this, args);
                            }
                        }
                        if (statesResult.ErrorStateInformation.CountingError)
                        {
                            if (DeviceErrorReceived != null)
                            {

                                DeviceErrorEventArgs args = new()
                                {
                                    ErrorCode = "CountingError",
                                    ErrorDescription = "CountingError"
                                };
                                DeviceErrorReceived(this, args);
                            }
                        }

                        // dispara como evento de error el estado de CassetteFull
                        if (statesResult.DoorStateInformation.CassetteFull)
                        {
                            if (DeviceErrorReceived != null)
                            {

                                DeviceErrorEventArgs args = new()
                                {
                                    ErrorCode = "CassetteFull",
                                    ErrorDescription = "CassetteFull"
                                };
                                DeviceErrorReceived(this, args);
                            }
                        }

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

        private DenominationResult ParseDenominationResult(byte[] Qarray)
        {
            try
            {
                DenominationResult denominationResult = new DenominationResult();
                byte[] numArray = new byte[0];
                List<byte> source = new List<byte>();
                int num1 = 0;
                foreach (byte num2 in Qarray)
                {
                    if (num1 > 7 && num1 < 104)
                        source.Add(num2);
                    ++num1;
                }


                byte[] array = source.ToArray<byte>();

                try
                {
                    string s6 = string.Join<char>("", (IEnumerable<char>)Encoding.ASCII.GetChars(new byte[3]
                            {
                          array[75],
                          array[76],
                          array[77]
                            }));
                    denominationResult.AddDenomination("10ARS", int.Parse(s6)); //10ARS
                }
                catch (Exception ex)
                {
                    Log(ex.Message + " " + ex.StackTrace);
                }

                string s7 = string.Join<char>("", (IEnumerable<char>)Encoding.ASCII.GetChars(new byte[3]
           {
          array[78],
          array[79],
          array[80]
           }));
                denominationResult.AddDenomination("20ARS", int.Parse(s7)); //20ARS


                string s1 = string.Join<char>("", (IEnumerable<char>)Encoding.ASCII.GetChars(new byte[3]
                {
          array[81],
          array[82],
          array[83]
                }));
                denominationResult.AddDenomination("50 ARS", int.Parse(s1));  //50 ARS



                string s2 = string.Join<char>("", (IEnumerable<char>)Encoding.ASCII.GetChars(new byte[3]
                {
          array[84],
          array[85],
          array[86]
                }));
                denominationResult.AddDenomination("100ARS", int.Parse(s2)); //100 ARS

                string s3 = string.Join<char>("", (IEnumerable<char>)Encoding.ASCII.GetChars(new byte[3]
                {
          array[87],
          array[88],
          array[89]
                }));
                denominationResult.AddDenomination("200ARS", int.Parse(s3)); //200 ARS
                string s4 = string.Join<char>("", (IEnumerable<char>)Encoding.ASCII.GetChars(new byte[3]
                {
          array[90],
          array[91],
          array[92]
                }));
                denominationResult.AddDenomination("500ARS", int.Parse(s4)); //500 ARS
                string s5 = string.Join<char>("", (IEnumerable<char>)Encoding.ASCII.GetChars(new byte[3]
                {
          array[93],
          array[94],
          array[95]
                }));
                denominationResult.AddDenomination("1000ARS", int.Parse(s5)); //1000 ARS

                this.DenominationResultProperty = denominationResult;
                return denominationResult;
            }
            catch (Exception ex)
            {
                Log(ex.Message + " " + ex.StackTrace);
                return new DenominationResult();
            }
        }

        private byte[] ParseDenomination(byte[] Qarray)
        {
            List<byte> source = new List<byte>();
            int num1 = 0;
            foreach (byte num2 in Qarray)
            {
                if (num1 > 7 && num1 < 104)
                    source.Add(num2);
                ++num1;
            }

            return source.ToArray<byte>();
            //return Qarray;

        }

        #endregion


        #region com ports

        #endregion

        #region Public Properties


        public bool CounterConnected
        {
            get
            {
                if (_counterPort == null)
                    return false;
                else
                    //return Ports.Exists(e => e.EndsWith(_counterPort.PortName));
                    return _counterLastBytesRead > 0;
            }

        }

        public bool IoBoardConnected
        {
            get
            {
                if (_ioboardPort == null)
                    return false;
                else
                    //return Ports.Exists(e => e.EndsWith(_ioboardPort.PortName));
                    return _ioBoardLastBytesRead > 0;
            }
        }

        #endregion
        #region Issues
        public void IoBoardReconnect()
        {
            try
            {
                _ioboardPort.Open();

            }
            catch (Exception)
            {

            }
        }
        public void CounterBoardReconnect()
        {
            try
            {
                _counterPort.Open();

            }
            catch (Exception)
            {


            }
        }
        public void UnJam()
        {

            while (Sense().StatusInformation.OperatingState != StatusInformation.State.Waiting)
            {


                switch (StateResultProperty.ModeStateInformation.ModeState)
                {
                    case ModeStateInformation.Mode.NormalErrorRecoveryMode:
                    case ModeStateInformation.Mode.StoringErrorRecoveryMode:
                        switch (StateResultProperty.StatusInformation.OperatingState)
                        {

                            case StatusInformation.State.EscrowOpenRequest:
                            case StatusInformation.State.StoringError:
                                OpenEscrow();
                                break;
                            case StatusInformation.State.EscrowOpen:
                                break;
                            case StatusInformation.State.BeingRecoverFromStoringError:
                                DeviceReset();
                                break;
                            case StatusInformation.State.BeingReset:
                                DeviceReset();
                                RemoteCancel();
                                StoringStart();
                                break;
                            case StatusInformation.State.EscrowCloseRequest:
                            case StatusInformation.State.PQWaitingTocloseEscrow:
                                CloseEscrow();
                                break;
                            case StatusInformation.State.EscrowClose:
                                break;
                            case StatusInformation.State.StoringStartRequest:
                                StoringStart();
                                break;
                            case StatusInformation.State.BeingStore:
                                break;
                            case StatusInformation.State.Waiting:
                                RemoteCancel();
                                break;
                            case StatusInformation.State.PQStoring:
                                break;

                            default:
                                DeviceReset();
                                break;
                        }
                        break;
                    case ModeStateInformation.Mode.Neutral_SettingMode:
                        switch (StateResultProperty.StatusInformation.OperatingState)
                        {
                            case StatusInformation.State.StoringError:
                                StoringErrorRecoveryMode();

                                break;
                            case StatusInformation.State.Waiting:
                                CloseEscrow();
                                Thread.Sleep(SleepTimeout);
                                RemoteCancel();
                                return;
                        }

                        break;
                    case ModeStateInformation.Mode.InitialMode:
                    case ModeStateInformation.Mode.DepositMode:
                    case ModeStateInformation.Mode.ManualMode:
                    default:
                        switch (StateResultProperty.StatusInformation.OperatingState)
                        {
                            case StatusInformation.State.StoringStartRequest:
                                OpenEscrow();
                                break;
                        }
                        RemoteCancel();
                        break;
                }
                Thread.Sleep(SleepTimeout);
            }

            RemoteCancel();
        
        }
        public void ResetFF0x()
        {
            NormalErrorRecoveryMode();
            Sleep();
            DeviceReset();
            Sleep();
            RemoteCancel();
        }
        public void ResetCassetteFull()
        {
            CollectMode();
            Sleep();
            RemoteCancel();
        }

        #endregion
    }
    #region Event classes

    public class DeviceDataReceivedEventArgs : EventArgs
    {
        // The com port
        public string ComPort = string.Empty;

        // Received message
        public string Message = string.Empty;
    }

    public class DeviceErrorEventArgs : EventArgs
    {
        public string ErrorCode = string.Empty;
        public string ErrorDescription = string.Empty;

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
            State21 = 21,
            State22 = 22,
            State23 = 23,
            PQWaitingToRemoveBankNotes = 24,
            State25 = 25,
            State26 = 26,
            State27 = 27,
            State28 = 28,
            State29 = 29,
            State30 = 30,
            State31 = 31,
            PQCounting = 32,
            State33 = 33,
            State34 = 34,
            State35 = 35,
            State36 = 36,
            State37 = 37,
            State38 = 38,
            State39 = 39,
            PQStoring = 40,
            State41 = 31,
            State42 = 42,
            State43 = 43,
            PQClosingEscrow = 44,
            State45 = 45,
            State46 = 46,
            State47 = 47,
            State48 = 48,
            State49 = 49,
            PQWaitingEnvelope = 50,
            State51 = 51,
            PQWaitingTocloseEscrow = 52

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

        public Dictionary<string, int> Denominations { get; set; } = new Dictionary<string, int>();

        public DenominationResult()
        {
            Denominations = new Dictionary<string, int>();

        }

        public bool AddDenomination(string key, int cantidad)
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
        public int BillCount()
        {
            int count = 0;
            foreach (var denomination in this.Denominations)
            {
                if (denomination.Value > 0)
                    count += Convert.ToInt32(denomination.Key.Replace("ARS", "")) * denomination.Value;

            }
            return count;
        }
        public byte[] DenominationArray { get; set; } = new byte[0];
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


#region Ioboard state



#endregion

