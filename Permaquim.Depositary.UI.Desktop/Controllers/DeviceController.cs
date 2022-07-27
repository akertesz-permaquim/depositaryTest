using Permaquim.Depositary.UI.Desktop.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{

    internal static class DeviceController
    {
      public static int GetPollingInterval()
        {
            
            int returnValue = Int32.Parse( ConfigurationController.
                GetDepositaryConfigurationItem(Global.Enumerations.DepositaryConfigurationEnum.POLLTIME));
            return returnValue;
        }
        public static int GetSleepInterval()
        {

            int returnValue = Int32.Parse(ConfigurationController.
                GetDepositaryConfigurationItem(Global.Enumerations.DepositaryConfigurationEnum.SLEEPTIME));
            return returnValue;
        }


        public static DEXDevice InitializeDevice()
        {
            DEXDevice device = new();
            device.RemoteCancel = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.RemoteCancel))).FirstOrDefault().Comando);

            device.BatchDataTransmission = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.BatchDataTransmission))).FirstOrDefault().Comando);

            device.CloseEscrow = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.CloseEscrow))).FirstOrDefault().Comando);

            device.CollectMode = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.CollectMode))).FirstOrDefault().Comando);

            device.CountingDataRequest = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.CountingDataRequest))).FirstOrDefault().Comando);

            device.DenominationDataRequest = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.DenominationDataRequest))).FirstOrDefault().Comando);

            device.DepositMode = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.DepositMode))).FirstOrDefault().Comando);

            device.DeviceReset = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.DeviceReset))).FirstOrDefault().Comando);

            device.ManualDepositMode = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.ManualDepositMode))).FirstOrDefault().Comando);

            device.NormalErrorRecoveryMode = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.NormalErrorRecoveryMode))).FirstOrDefault().Comando);

            device.OpenEscrow = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.OpenEscrow))).FirstOrDefault().Comando);

            device.Sense = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.Sense))).FirstOrDefault().Comando);

            device.StoringStart = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.StoringStart))).FirstOrDefault().Comando);

            device.SwitchCurrency = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.SwitchCurrency))).FirstOrDefault().Comando);

            device.StopCounting = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.StopCounting))).FirstOrDefault().Comando);

            device.StoringErrorRecoveryMode = Convert.FromBase64String(DatabaseController.CurrentDepositaryCounterCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(CounterCommandEnum.StoringErrorRecoveryMode))).FirstOrDefault().Comando);

            device.Open = DatabaseController.CurrentDepositaryIoBoardCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(IoboardCommandEnum.Open))).FirstOrDefault().Comando;

            device.Close = DatabaseController.CurrentDepositaryIoBoardCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(IoboardCommandEnum.Close))).FirstOrDefault().Comando;

            device.UnLock = DatabaseController.CurrentDepositaryIoBoardCommands.Where
                 (x => x.Nombre.Equals(Enum.GetName(IoboardCommandEnum.UnLock))).FirstOrDefault().Comando;

            device.Status = DatabaseController.CurrentDepositaryIoBoardCommands.Where
                 (x => x.Nombre.Equals(Enum.GetName(IoboardCommandEnum.Status))).FirstOrDefault().Comando;

            device.Empty = DatabaseController.CurrentDepositaryIoBoardCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(IoboardCommandEnum.Empty))).FirstOrDefault().Comando;

            device.Approve = DatabaseController.CurrentDepositaryIoBoardCommands.Where
                (x => x.Nombre.Equals(Enum.GetName(IoboardCommandEnum.Approve))).FirstOrDefault().Comando;

            device.CounterComPort = new()
            {
                BaudRate = DatabaseController.CurrentDepositaryCounter.BaudRate,
                Parity = DatabaseController.CurrentDepositaryCounter.Parity,
                StopBits = DatabaseController.CurrentDepositaryCounter.StopBits,
                DataBits = DatabaseController.CurrentDepositaryCounter.DataBits,
                Handshake = DatabaseController.CurrentDepositaryCounter.Handshake,
                PortName = DatabaseController.CurrentDepositaryCounter.PortName,
                ReadBufferSize = DatabaseController.CurrentDepositaryCounter.ReadBufferSize,
                ReadTimeout = DatabaseController.CurrentDepositaryCounter.ReadTimeout,
                RtsEnable = DatabaseController.CurrentDepositaryCounter.RtsEnable,
            };

            device.IOboardComPort = new()
            {
                BaudRate = DatabaseController.CurrentDepositaryIoboard.BaudRate,
                DataBits = DatabaseController.CurrentDepositaryIoboard.DataBits,
                Parity = DatabaseController.CurrentDepositaryIoboard.Parity,
                Handshake = DatabaseController.CurrentDepositaryIoboard.Handshake,
                PortName = DatabaseController.CurrentDepositaryIoboard.PortName,
                RtsEnable = DatabaseController.CurrentDepositaryIoboard.RtsEnable,
                ReadBufferSize = DatabaseController.CurrentDepositaryIoboard.ReadBufferSize,
                ReadTimeout = DatabaseController.CurrentDepositaryIoboard.ReadTimeout,
                StopBits = DatabaseController.CurrentDepositaryIoboard.StopBits,
            };

            return device;
        }


}
}
