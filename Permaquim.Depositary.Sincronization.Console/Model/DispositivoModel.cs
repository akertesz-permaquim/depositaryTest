using Permaquim.Depositary.Sincronization.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.Sincronization.Console.Model
{
    internal class DispositivoModel : IModel
    {
        public List<Depositario.Entities.Tables.Dispositivo.Modelo> Modelos { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.Marca> Marcas { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.Depositario> Depositarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.TipoPlaca> TiposPlacas { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ComandoPlaca> ComandosPlacas { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> TiposConfiguraciones { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioPlaca> PlacasDepositarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ConfiguracionDepositario> ConfiguracionesDepositarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.TipoContadora> TiposContadoras { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioContadora> ContadorasDepositarios { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.ComandoContadora> ComandosContadoras { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioMoneda> MonedasDepositario { get; set; } = new();
        public List<Depositario.Entities.Tables.Dispositivo.DepositarioEstado> EstadosDepositarios { get; set; } = new();
        public DateTime? SincroDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Persist()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {

            Depositario.Business.Tables.Dispositivo.Modelo modelos = new();
            foreach (var item in Modelos)
            {
                modelos.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.Marca marcas = new();
            foreach (var item in Marcas)
            {
                marcas.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.Depositario depositarios = new();
            foreach (var item in Depositarios)
            {
                depositarios.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.TipoPlaca tipoPlacas = new();
            foreach (var item in TiposPlacas)
            {
                tipoPlacas.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.ComandoPlaca comandosPlaca = new();
            foreach (var item in ComandosPlacas)
            {
                comandosPlaca.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.TipoConfiguracionDepositario tipoConfiguracionesDepositario = new();
            foreach (var item in TiposConfiguraciones)
            {
                tipoConfiguracionesDepositario.AddOrUpdate(item);
            }


            Depositario.Business.Tables.Dispositivo.DepositarioPlaca  depositarioPlaca = new();
            foreach (var item in PlacasDepositarios)
            {
                depositarioPlaca.AddOrUpdate(item);
            }


            Depositario.Business.Tables.Dispositivo.ConfiguracionDepositario configuracionDepositario = new();
            foreach (var item in ConfiguracionesDepositarios)
            {
                configuracionDepositario.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.TipoContadora tiposContadora = new();
            foreach (var item in TiposContadoras)
            {
                tiposContadora.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.DepositarioContadora depositarioContadora = new();
            foreach (var item in ContadorasDepositarios)
            {
                depositarioContadora.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.ComandoContadora comandosContadora = new();
            foreach (var item in ComandosContadoras)
            {
                comandosContadora.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.DepositarioMoneda depositarioValores = new();
            foreach (var item in MonedasDepositario)
            {
                depositarioValores.AddOrUpdate(item);
            }

            Depositario.Business.Tables.Dispositivo.DepositarioEstado depositarioEstados = new();
            foreach (var item in EstadosDepositarios)
            {
                depositarioEstados.AddOrUpdate(item);
            }

        }

        public void Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
