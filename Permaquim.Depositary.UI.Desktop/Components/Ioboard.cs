using System.IO.Ports;

public class IoBoard
{

    public enum IOBOARD_VERSION
    {
        V4520_1_0 = 0, //.PORTSPEED.BAUDRATE_38400),
        V4520_1_2 = 1,  //.PORTSPEED.BAUDRATE_115200),
        MX220_1_0 = 2  //.PORTSPEED.BAUDRATE_115200);
    }

}


public class IoBoardStatus 
{
    private string? _data;
    public enum BAG_STATE
    {
        BAG_STATE_ERROR = 0,
        BAG_STATE_REMOVED = 1,
        BAG_STATE_INPLACE = 2,
        BAG_STATE_TAKING_START = 3,
        BAG_STATE_TAKING_STEP1 = 4,
        BAG_STATE_TAKING_STEP2 = 5,
        BAG_STATE_PUTTING_START = 6,
        BAG_STATE_PUTTING_1 = 7,
        BAG_STATE_PUTTING_2 = 8,
        BAG_STATE_PUTTING_3 = 9,
        BAG_STATE_PUTTING_4 = 10,
        BAG_STATE_PUTTING_5 = 11,
        BAG_STATE_PUTTING_6 = 12

    }
    public enum IoBoardError
    {
        IOBOARD_FW_ERROR = 0, 
        IOBOARD_COMMUNICATION_TIMEOUT =  1, 
        IOBOARD_COMMUNICATION_ERROR = 2

    }
    public enum SHUTTER_STATE
    {
        SHUTTER_START_CLOSE = 0,
        SHUTTER_START_OPEN = 1,
        SHUTTER_RUN_OPEN = 2,
        SHUTTER_RUN_CLOSE = 3,
        SHUTTER_RUN_OPEN_PORT = 4,
        SHUTTER_RUN_CLOSE_PORT = 5,
        SHUTTER_STOP_OPEN = 6,
        SHUTTER_STOP_CLOSE = 7,
        SHUTTER_OPEN = 8,
        SHUTTER_CLOSED = 9
    }
    public enum BAG_APROVE_STATE
    {
        BAG_APROVED = 0,
        BAG_NOT_APROVED = 1,
        BAG_APROVE_WAIT = 2,
        BAG_APROVE_CONFIRM = 3

    }

    public enum LOCK_STATE
    {
        LOCKED = 0,
        UNLOCKED  = 1
    }
    public enum GATE_STATE
    {
        STATE_0 = 0,
        STATE_1 = 1,
        STATE_2 = 2,
        CLOSED = 3,
        STATE_4 = 4,
        STATE_5 = 5,
        STATE_6 = 6,
        OPEN = 7,
        STATE_8 = 8,
        STATE_9 = 9,
        STATE_10 = 10

    }

    public IoBoardStatus ParseStatus(String data)
    {

        _data = data;
        try
        {
            if (_data.StartsWith("STATUS :") && _data.Length > 71)
            {
                try
                {
                    this.A = byte.Parse(_data.Substring(13, 2));
                    this.B = byte.Parse(_data.Substring(21, 2));
                    this.C = byte.Parse(_data.Substring(29, 2));
                    this.D = byte.Parse(_data.Substring(37, 2));
                    this.BAG_SENSOR = byte.Parse(_data.Substring(54, 2));
                    this.BAG_STATUS = byte.Parse(_data.Substring(70, 2));
                }
                catch (Exception e)
                {
                    //Logger.warn("checkStatus invalid number: %s", new Object[] { e.getMessage() });
                }
            }
            else if (_data.StartsWith("STATE :") && _data.Length > 45)
            {
                try
                {
                    this.BagState = (BAG_STATE)int.Parse(_data.Substring(12, 2));
                    this.BagAproveState = (BAG_APROVE_STATE)int.Parse(_data.Substring(27, 1));
                    this.ShutterState = (SHUTTER_STATE)int.Parse(_data.Substring(37, 2));
                    this.LockState = (LOCK_STATE)Int32.Parse(_data.Substring(45, 1));
                    this.GateState = (GATE_STATE)Int32.Parse(_data.Substring(52, 1));
                }
                catch (Exception e)
                {
                    //Logger.warn("checkStatus invalid number: %s", new Object[] { e.getMessage() });
                }
            }
            else if (_data.StartsWith("CRITICAL :") && _data.Length > 15)
            {
                this.CriticalError = _data.Substring(11);
            }
            else if (_data.Contains("ERROR"))
            {
                if (_data.Contains("SHUTTER"))// && Configuration.isIgnoreShutter())
                {
                    this.ShutterErrorInformation = _data;
                }
                else
                {
                    this.GeneralErrorInformation = _data;
                }
                this.Error = IoBoardError.IOBOARD_FW_ERROR;
            }
            else
            {
                if (_data.Length <= 0)
                {
                    //continue;
                    System.Diagnostics.Debug.Print(_data);
                }
                //Logger.warn("IOBOARD Ignoring line (%d): %s", new Object[] { l.length(), l });
            }
        }
        catch (Exception)
        {
         }

        return this;

    }
    public IoBoardStatus Getstatus()
    {
        return this;
    }
    public IoBoardStatus Getstatus(string data)
    {
        return this.Getstatus(data);
    }
    public Byte A { get; private set; }
    public Byte B { get; private set; }
    public Byte C { get; private set; }
    public Byte D { get; private set; }
    public Byte BAG_STATUS { get; private set; }
    public Byte BAG_SENSOR { get; private set; }
    public IoBoardError Error { get; private set; }
    public BAG_STATE BagState { get; private set; }
    public SHUTTER_STATE ShutterState { get; private set; }
    public LOCK_STATE LockState { get; private set; }
    public GATE_STATE GateState { get; private set; }
    public BAG_APROVE_STATE BagAproveState { get; private set; }

    public string CriticalError { get; private set; }
    public string GeneralErrorInformation { get; private set; }
    public string ShutterErrorInformation { get; private set; }

    public override string ToString()
    {
        return this._data;
    }

}
