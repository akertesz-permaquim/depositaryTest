﻿using Permaquim.Depositary.Sincronization.Console.Controllers;
using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class ConfiguracionModel : IModel
    {
        public List<Depositario.Entities.Tables.Aplicacion.Configuracion> ConfiguracionAplicacion { get; set; } = new();

        public List<Depositario.Entities.Tables.Dispositivo.ConfiguracionDepositario> ConfiguracionDispositivo { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        public Int64? SynchronizationExecutionId = SynchronizationController.CurrentSynchronizationExecutionId;

        public void Process()
        {
            try
            {
                Depositario.Business.Tables.Aplicacion.Configuracion configuracion = new();
                foreach (var item in ConfiguracionAplicacion)
                {
                    configuracion.AddOrUpdate(item);
                }

                Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario configuracionDepositario = new();
                foreach (var item in ConfiguracionDispositivo)
                {
                    configuracionDepositario.AddOrUpdate(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        public void Persist()
        {
            throw new NotImplementedException();
        }


    }
}
