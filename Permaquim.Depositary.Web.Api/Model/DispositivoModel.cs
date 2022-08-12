﻿namespace Permaquim.Depositary.Web.Api.Model
{
    public class DispositivoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.Modelo> Modelos { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.Marca> Marcas { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.Depositario> Depositarios { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoPlaca> TiposPlacas { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoPlaca> ComandosPlacas { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> TiposConfiguraciones { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioPlaca> PlacasDepositarios { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> ConfiguracionesDepositarios { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoContadora> TiposContadoras { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioContadora> ContadorasDepositarios { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoContadora> ComandosContadoras { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioMoneda> MonedasDepositarios { get; set; } = new();
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioEstado> EstadosDepositarios { get; set; } = new();
    }

    public class DispositivoDepositarioModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.Depositario> Depositarios { get; set; } = new();
    }
    public class DispositivoMarcaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.Marca> Marcas { get; set; } = new();
    }
    public class DispositivoModeloModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.Modelo> Modelos { get; set; } = new();
    }
    public class DispositivoTipoPlacaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoPlaca> TiposPlacas { get; set; } = new();
    }
    public class DispositivoComandoContadoraModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoContadora> ComandosContadoras { get; set; } = new();
    }
    public class DispositivoComandoPlacaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ComandoPlaca> ComandosPlacas { get; set; } = new();
    }
    public class DispositivoConfiguracionDepositarioModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario> ConfiguracionesDepositarios { get; set; } = new();
    }
    public class DispositivoDepositarioContadoraModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioContadora> ContadorasDepositarios { get; set; } = new();
    }
    public class DispositivoDepositarioEstadoModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioEstado> EstadosDepositarios { get; set; } = new();
    }
    public class DispositivoDepositarioPlacaModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioPlaca> PlacasDepositarios { get; set; } = new();
    }
    public class DispositivoDepositarioValorModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioMoneda> MonedasDepositarios { get; set; } = new();
    }
    public class DispositivoTipoConfiguracionDepositarioModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoConfiguracionDepositario> TiposConfiguraciones { get; set; } = new();
    }
    public class DispositivoTipoContadoraModel
    {
        public List<DepositaryWebApi.Entities.Tables.Dispositivo.TipoContadora> TiposContadoras { get; set; } = new();
    }

}