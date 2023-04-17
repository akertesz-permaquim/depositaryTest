using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace DepositaryWebApi.Entities.Views.Integracion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Integracion")]  // Database Schema Name
			[DataItemAttributeObjectName("OperacionTransaccion","OperacionTransaccion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class OperacionTransaccion : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string OperacionTransaccion_Id = "OperacionTransaccion_Id";
					public const string OperacionTransaccion_TipoId = "OperacionTransaccion_TipoId";
					public const string OperacionTransaccion_DepositarioId = "OperacionTransaccion_DepositarioId";
					public const string OperacionTransaccion_SectorId = "OperacionTransaccion_SectorId";
					public const string OperacionTransaccion_SucursalId = "OperacionTransaccion_SucursalId";
					public const string OperacionTransaccion_MonedaId = "OperacionTransaccion_MonedaId";
					public const string OperacionTransaccion_UsuarioId = "OperacionTransaccion_UsuarioId";
					public const string OperacionTransaccion_CuentaId = "OperacionTransaccion_CuentaId";
					public const string OperacionTransaccion_ContenedorId = "OperacionTransaccion_ContenedorId";
					public const string OperacionTransaccion_SesionId = "OperacionTransaccion_SesionId";
					public const string OperacionTransaccion_TurnoId = "OperacionTransaccion_TurnoId";
					public const string OperacionTransaccion_CierreDiarioId = "OperacionTransaccion_CierreDiarioId";
					public const string OperacionTransaccion_TotalValidado = "OperacionTransaccion_TotalValidado";
					public const string OperacionTransaccion_TotalAValidar = "OperacionTransaccion_TotalAValidar";
					public const string OperacionTransaccion_Fecha = "OperacionTransaccion_Fecha";
					public const string OperacionTransaccion_Finalizada = "OperacionTransaccion_Finalizada";
					public const string OperacionTransaccion_EsDepositoAutomatico = "OperacionTransaccion_EsDepositoAutomatico";
					public const string OperacionTransaccion_OrigenValorId = "OperacionTransaccion_OrigenValorId";
					public const string OperacionTransaccion_CodigoOperacion = "OperacionTransaccion_CodigoOperacion";
					public const string OperacionTransaccion_FechaCreacion = "OperacionTransaccion_FechaCreacion";
					public const string OperacionTipoTransaccion_Id = "OperacionTipoTransaccion_Id";
					public const string OperacionTipoTransaccion_Nombre = "OperacionTipoTransaccion_Nombre";
					public const string OperacionTipoTransaccion_Descripcion = "OperacionTipoTransaccion_Descripcion";
					public const string DispositivoDepositario_Id = "DispositivoDepositario_Id";
					public const string DispositivoDepositario_Nombre = "DispositivoDepositario_Nombre";
					public const string DispositivoDepositario_Descripcion = "DispositivoDepositario_Descripcion";
					public const string DispositivoDepositario_SectorId = "DispositivoDepositario_SectorId";
					public const string DispositivoDepositario_NumeroSerie = "DispositivoDepositario_NumeroSerie";
					public const string DispositivoDepositario_CodigoExterno = "DispositivoDepositario_CodigoExterno";
					public const string DirectorioSector_Id = "DirectorioSector_Id";
					public const string DirectorioSector_SucursalId = "DirectorioSector_SucursalId";
					public const string DirectorioSector_Nombre = "DirectorioSector_Nombre";
					public const string DirectorioSector_Descripcion = "DirectorioSector_Descripcion";
					public const string DirectorioSector_CodigoExterno = "DirectorioSector_CodigoExterno";
					public const string DirectorioSucursal_Id = "DirectorioSucursal_Id";
					public const string DirectorioSucursal_Nombre = "DirectorioSucursal_Nombre";
					public const string DirectorioSucursal_Descripcion = "DirectorioSucursal_Descripcion";
					public const string DirectorioSucursal_EmpresaId = "DirectorioSucursal_EmpresaId";
					public const string DirectorioSucursal_CodigoExterno = "DirectorioSucursal_CodigoExterno";
					public const string DirectorioSucursal_Direccion = "DirectorioSucursal_Direccion";
					public const string DirectorioSucursal_CodigoPostalId = "DirectorioSucursal_CodigoPostalId";
					public const string DirectorioSucursal_ZonaId = "DirectorioSucursal_ZonaId";
					public const string ValorMoneda_Id = "ValorMoneda_Id";
					public const string ValorMoneda_Nombre = "ValorMoneda_Nombre";
					public const string ValorMoneda_PaisId = "ValorMoneda_PaisId";
					public const string ValorMoneda_Codigo = "ValorMoneda_Codigo";
					public const string ValorMoneda_Simbolo = "ValorMoneda_Simbolo";
					public const string ValorMoneda_CodigoExterno = "ValorMoneda_CodigoExterno";
					public const string SeguridadUsuario_Id = "SeguridadUsuario_Id";
					public const string SeguridadUsuario_EmpresaId = "SeguridadUsuario_EmpresaId";
					public const string SeguridadUsuario_NickName = "SeguridadUsuario_NickName";
					public const string SeguridadUsuario_CodigoExterno = "SeguridadUsuario_CodigoExterno";
					public const string BancaCuenta_Id = "BancaCuenta_Id";
					public const string BancaCuenta_TipoId = "BancaCuenta_TipoId";
					public const string BancaCuenta_EmpresaId = "BancaCuenta_EmpresaId";
					public const string BancaCuenta_Nombre = "BancaCuenta_Nombre";
					public const string BancaCuenta_Numero = "BancaCuenta_Numero";
					public const string BancaCuenta_Alias = "BancaCuenta_Alias";
					public const string BancaCuenta_CBU = "BancaCuenta_CBU";
					public const string BancaCuenta_BancoId = "BancaCuenta_BancoId";
					public const string BancaCuenta_SucursalBancaria = "BancaCuenta_SucursalBancaria";
					public const string BancaCuenta_CodigoExterno = "BancaCuenta_CodigoExterno";
					public const string OperacionContenedor_Id = "OperacionContenedor_Id";
					public const string OperacionContenedor_Nombre = "OperacionContenedor_Nombre";
					public const string OperacionContenedor_DepositarioId = "OperacionContenedor_DepositarioId";
					public const string OperacionContenedor_TipoId = "OperacionContenedor_TipoId";
					public const string OperacionContenedor_Identificador = "OperacionContenedor_Identificador";
					public const string OperacionContenedor_FechaApertura = "OperacionContenedor_FechaApertura";
					public const string OperacionContenedor_FechaCierre = "OperacionContenedor_FechaCierre";
					public const string OperacionSesion_Id = "OperacionSesion_Id";
					public const string OperacionSesion_DepositarioId = "OperacionSesion_DepositarioId";
					public const string OperacionSesion_UsuarioId = "OperacionSesion_UsuarioId";
					public const string OperacionSesion_FechaInicio = "OperacionSesion_FechaInicio";
					public const string OperacionSesion_FechaCierre = "OperacionSesion_FechaCierre";
					public const string OperacionSesion_EsCierreAutomatico = "OperacionSesion_EsCierreAutomatico";
					public const string OperacionTurno_Id = "OperacionTurno_Id";
					public const string OperacionTurno_TurnoDepositarioId = "OperacionTurno_TurnoDepositarioId";
					public const string OperacionTurno_DepositarioId = "OperacionTurno_DepositarioId";
					public const string OperacionTurno_SectorId = "OperacionTurno_SectorId";
					public const string OperacionTurno_FechaApertura = "OperacionTurno_FechaApertura";
					public const string OperacionTurno_FechaCierre = "OperacionTurno_FechaCierre";
					public const string OperacionTurno_Fecha = "OperacionTurno_Fecha";
					public const string OperacionTurno_Secuencia = "OperacionTurno_Secuencia";
					public const string OperacionTurno_CierreDiarioId = "OperacionTurno_CierreDiarioId";
					public const string OperacionTurno_Observaciones = "OperacionTurno_Observaciones";
					public const string OperacionTurno_CodigoTurno = "OperacionTurno_CodigoTurno";
					public const string OperacionCierreDiario_Id = "OperacionCierreDiario_Id";
					public const string OperacionCierreDiario_Nombre = "OperacionCierreDiario_Nombre";
					public const string OperacionCierreDiario_Fecha = "OperacionCierreDiario_Fecha";
					public const string OperacionCierreDiario_DepositarioId = "OperacionCierreDiario_DepositarioId";
					public const string OperacionCierreDiario_SesionId = "OperacionCierreDiario_SesionId";
					public const string OperacionCierreDiario_CodigoCierre = "OperacionCierreDiario_CodigoCierre";
					public const string ValorOrigenValor_Id = "ValorOrigenValor_Id";
					public const string ValorOrigenValor_Nombre = "ValorOrigenValor_Nombre";
					public const string ValorOrigenValor_Descripcion = "ValorOrigenValor_Descripcion";
					public const string ValorOrigenValor_EmpresaId = "ValorOrigenValor_EmpresaId";
					public const string ValorOrigenValor_CodigoExterno = "ValorOrigenValor_CodigoExterno";
				}
				public enum FieldEnum : int
                {
					OperacionTransaccion_Id,
					OperacionTransaccion_TipoId,
					OperacionTransaccion_DepositarioId,
					OperacionTransaccion_SectorId,
					OperacionTransaccion_SucursalId,
					OperacionTransaccion_MonedaId,
					OperacionTransaccion_UsuarioId,
					OperacionTransaccion_CuentaId,
					OperacionTransaccion_ContenedorId,
					OperacionTransaccion_SesionId,
					OperacionTransaccion_TurnoId,
					OperacionTransaccion_CierreDiarioId,
					OperacionTransaccion_TotalValidado,
					OperacionTransaccion_TotalAValidar,
					OperacionTransaccion_Fecha,
					OperacionTransaccion_Finalizada,
					OperacionTransaccion_EsDepositoAutomatico,
					OperacionTransaccion_OrigenValorId,
					OperacionTransaccion_CodigoOperacion,
					OperacionTransaccion_FechaCreacion,
					OperacionTipoTransaccion_Id,
					OperacionTipoTransaccion_Nombre,
					OperacionTipoTransaccion_Descripcion,
					DispositivoDepositario_Id,
					DispositivoDepositario_Nombre,
					DispositivoDepositario_Descripcion,
					DispositivoDepositario_SectorId,
					DispositivoDepositario_NumeroSerie,
					DispositivoDepositario_CodigoExterno,
					DirectorioSector_Id,
					DirectorioSector_SucursalId,
					DirectorioSector_Nombre,
					DirectorioSector_Descripcion,
					DirectorioSector_CodigoExterno,
					DirectorioSucursal_Id,
					DirectorioSucursal_Nombre,
					DirectorioSucursal_Descripcion,
					DirectorioSucursal_EmpresaId,
					DirectorioSucursal_CodigoExterno,
					DirectorioSucursal_Direccion,
					DirectorioSucursal_CodigoPostalId,
					DirectorioSucursal_ZonaId,
					ValorMoneda_Id,
					ValorMoneda_Nombre,
					ValorMoneda_PaisId,
					ValorMoneda_Codigo,
					ValorMoneda_Simbolo,
					ValorMoneda_CodigoExterno,
					SeguridadUsuario_Id,
					SeguridadUsuario_EmpresaId,
					SeguridadUsuario_NickName,
					SeguridadUsuario_CodigoExterno,
					BancaCuenta_Id,
					BancaCuenta_TipoId,
					BancaCuenta_EmpresaId,
					BancaCuenta_Nombre,
					BancaCuenta_Numero,
					BancaCuenta_Alias,
					BancaCuenta_CBU,
					BancaCuenta_BancoId,
					BancaCuenta_SucursalBancaria,
					BancaCuenta_CodigoExterno,
					OperacionContenedor_Id,
					OperacionContenedor_Nombre,
					OperacionContenedor_DepositarioId,
					OperacionContenedor_TipoId,
					OperacionContenedor_Identificador,
					OperacionContenedor_FechaApertura,
					OperacionContenedor_FechaCierre,
					OperacionSesion_Id,
					OperacionSesion_DepositarioId,
					OperacionSesion_UsuarioId,
					OperacionSesion_FechaInicio,
					OperacionSesion_FechaCierre,
					OperacionSesion_EsCierreAutomatico,
					OperacionTurno_Id,
					OperacionTurno_TurnoDepositarioId,
					OperacionTurno_DepositarioId,
					OperacionTurno_SectorId,
					OperacionTurno_FechaApertura,
					OperacionTurno_FechaCierre,
					OperacionTurno_Fecha,
					OperacionTurno_Secuencia,
					OperacionTurno_CierreDiarioId,
					OperacionTurno_Observaciones,
					OperacionTurno_CodigoTurno,
					OperacionCierreDiario_Id,
					OperacionCierreDiario_Nombre,
					OperacionCierreDiario_Fecha,
					OperacionCierreDiario_DepositarioId,
					OperacionCierreDiario_SesionId,
					OperacionCierreDiario_CodigoCierre,
					ValorOrigenValor_Id,
					ValorOrigenValor_Nombre,
					ValorOrigenValor_Descripcion,
					ValorOrigenValor_EmpresaId,
					ValorOrigenValor_CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// </summary>
                public OperacionTransaccion()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// </summary>
                public  OperacionTransaccion(Int64 OperacionTransaccion_Id,Int64 OperacionTransaccion_TipoId,Int64 OperacionTransaccion_DepositarioId,Int64 OperacionTransaccion_SectorId,Int64 OperacionTransaccion_SucursalId,Int64 OperacionTransaccion_MonedaId,Int64 OperacionTransaccion_UsuarioId,Int64 OperacionTransaccion_CuentaId,Int64 OperacionTransaccion_ContenedorId,Int64 OperacionTransaccion_SesionId,Int64 OperacionTransaccion_TurnoId,Int64 OperacionTransaccion_CierreDiarioId,Double OperacionTransaccion_TotalValidado,Double OperacionTransaccion_TotalAValidar,DateTime OperacionTransaccion_Fecha,Boolean OperacionTransaccion_Finalizada,Boolean OperacionTransaccion_EsDepositoAutomatico,Int64 OperacionTransaccion_OrigenValorId,String OperacionTransaccion_CodigoOperacion,DateTime OperacionTransaccion_FechaCreacion,Int64 OperacionTipoTransaccion_Id,String OperacionTipoTransaccion_Nombre,String OperacionTipoTransaccion_Descripcion,Int64 DispositivoDepositario_Id,String DispositivoDepositario_Nombre,String DispositivoDepositario_Descripcion,Int64 DispositivoDepositario_SectorId,String DispositivoDepositario_NumeroSerie,String DispositivoDepositario_CodigoExterno,Int64 DirectorioSector_Id,Int64 DirectorioSector_SucursalId,String DirectorioSector_Nombre,String DirectorioSector_Descripcion,String DirectorioSector_CodigoExterno,Int64 DirectorioSucursal_Id,String DirectorioSucursal_Nombre,String DirectorioSucursal_Descripcion,Int64 DirectorioSucursal_EmpresaId,String DirectorioSucursal_CodigoExterno,String DirectorioSucursal_Direccion,Int64 DirectorioSucursal_CodigoPostalId,Int64 DirectorioSucursal_ZonaId,Int64 ValorMoneda_Id,String ValorMoneda_Nombre,Int64 ValorMoneda_PaisId,String ValorMoneda_Codigo,String ValorMoneda_Simbolo,String ValorMoneda_CodigoExterno,Int64 SeguridadUsuario_Id,Int64 SeguridadUsuario_EmpresaId,String SeguridadUsuario_NickName,String SeguridadUsuario_CodigoExterno,Int64 BancaCuenta_Id,Int64 BancaCuenta_TipoId,Int64 BancaCuenta_EmpresaId,String BancaCuenta_Nombre,String BancaCuenta_Numero,String BancaCuenta_Alias,String BancaCuenta_CBU,Int64 BancaCuenta_BancoId,String BancaCuenta_SucursalBancaria,String BancaCuenta_CodigoExterno,Int64 OperacionContenedor_Id,String OperacionContenedor_Nombre,Int64 OperacionContenedor_DepositarioId,Int64 OperacionContenedor_TipoId,String OperacionContenedor_Identificador,DateTime OperacionContenedor_FechaApertura,DateTime OperacionContenedor_FechaCierre,Int64 OperacionSesion_Id,Int64 OperacionSesion_DepositarioId,Int64 OperacionSesion_UsuarioId,DateTime OperacionSesion_FechaInicio,DateTime OperacionSesion_FechaCierre,Boolean OperacionSesion_EsCierreAutomatico,Int64 OperacionTurno_Id,Int64 OperacionTurno_TurnoDepositarioId,Int64 OperacionTurno_DepositarioId,Int64 OperacionTurno_SectorId,DateTime OperacionTurno_FechaApertura,DateTime OperacionTurno_FechaCierre,DateTime OperacionTurno_Fecha,Int32 OperacionTurno_Secuencia,Int64 OperacionTurno_CierreDiarioId,String OperacionTurno_Observaciones,String OperacionTurno_CodigoTurno,Int64 OperacionCierreDiario_Id,String OperacionCierreDiario_Nombre,DateTime OperacionCierreDiario_Fecha,Int64 OperacionCierreDiario_DepositarioId,Int64 OperacionCierreDiario_SesionId,String OperacionCierreDiario_CodigoCierre,Int64 ValorOrigenValor_Id,String ValorOrigenValor_Nombre,String ValorOrigenValor_Descripcion,Int64 ValorOrigenValor_EmpresaId,String ValorOrigenValor_CodigoExterno)
                {
                    this.OperacionTransaccion_Id = OperacionTransaccion_Id;
                    this.OperacionTransaccion_TipoId = OperacionTransaccion_TipoId;
                    this.OperacionTransaccion_DepositarioId = OperacionTransaccion_DepositarioId;
                    this.OperacionTransaccion_SectorId = OperacionTransaccion_SectorId;
                    this.OperacionTransaccion_SucursalId = OperacionTransaccion_SucursalId;
                    this.OperacionTransaccion_MonedaId = OperacionTransaccion_MonedaId;
                    this.OperacionTransaccion_UsuarioId = OperacionTransaccion_UsuarioId;
                    this.OperacionTransaccion_CuentaId = OperacionTransaccion_CuentaId;
                    this.OperacionTransaccion_ContenedorId = OperacionTransaccion_ContenedorId;
                    this.OperacionTransaccion_SesionId = OperacionTransaccion_SesionId;
                    this.OperacionTransaccion_TurnoId = OperacionTransaccion_TurnoId;
                    this.OperacionTransaccion_CierreDiarioId = OperacionTransaccion_CierreDiarioId;
                    this.OperacionTransaccion_TotalValidado = OperacionTransaccion_TotalValidado;
                    this.OperacionTransaccion_TotalAValidar = OperacionTransaccion_TotalAValidar;
                    this.OperacionTransaccion_Fecha = OperacionTransaccion_Fecha;
                    this.OperacionTransaccion_Finalizada = OperacionTransaccion_Finalizada;
                    this.OperacionTransaccion_EsDepositoAutomatico = OperacionTransaccion_EsDepositoAutomatico;
                    this.OperacionTransaccion_OrigenValorId = OperacionTransaccion_OrigenValorId;
                    this.OperacionTransaccion_CodigoOperacion = OperacionTransaccion_CodigoOperacion;
                    this.OperacionTransaccion_FechaCreacion = OperacionTransaccion_FechaCreacion;
                    this.OperacionTipoTransaccion_Id = OperacionTipoTransaccion_Id;
                    this.OperacionTipoTransaccion_Nombre = OperacionTipoTransaccion_Nombre;
                    this.OperacionTipoTransaccion_Descripcion = OperacionTipoTransaccion_Descripcion;
                    this.DispositivoDepositario_Id = DispositivoDepositario_Id;
                    this.DispositivoDepositario_Nombre = DispositivoDepositario_Nombre;
                    this.DispositivoDepositario_Descripcion = DispositivoDepositario_Descripcion;
                    this.DispositivoDepositario_SectorId = DispositivoDepositario_SectorId;
                    this.DispositivoDepositario_NumeroSerie = DispositivoDepositario_NumeroSerie;
                    this.DispositivoDepositario_CodigoExterno = DispositivoDepositario_CodigoExterno;
                    this.DirectorioSector_Id = DirectorioSector_Id;
                    this.DirectorioSector_SucursalId = DirectorioSector_SucursalId;
                    this.DirectorioSector_Nombre = DirectorioSector_Nombre;
                    this.DirectorioSector_Descripcion = DirectorioSector_Descripcion;
                    this.DirectorioSector_CodigoExterno = DirectorioSector_CodigoExterno;
                    this.DirectorioSucursal_Id = DirectorioSucursal_Id;
                    this.DirectorioSucursal_Nombre = DirectorioSucursal_Nombre;
                    this.DirectorioSucursal_Descripcion = DirectorioSucursal_Descripcion;
                    this.DirectorioSucursal_EmpresaId = DirectorioSucursal_EmpresaId;
                    this.DirectorioSucursal_CodigoExterno = DirectorioSucursal_CodigoExterno;
                    this.DirectorioSucursal_Direccion = DirectorioSucursal_Direccion;
                    this.DirectorioSucursal_CodigoPostalId = DirectorioSucursal_CodigoPostalId;
                    this.DirectorioSucursal_ZonaId = DirectorioSucursal_ZonaId;
                    this.ValorMoneda_Id = ValorMoneda_Id;
                    this.ValorMoneda_Nombre = ValorMoneda_Nombre;
                    this.ValorMoneda_PaisId = ValorMoneda_PaisId;
                    this.ValorMoneda_Codigo = ValorMoneda_Codigo;
                    this.ValorMoneda_Simbolo = ValorMoneda_Simbolo;
                    this.ValorMoneda_CodigoExterno = ValorMoneda_CodigoExterno;
                    this.SeguridadUsuario_Id = SeguridadUsuario_Id;
                    this.SeguridadUsuario_EmpresaId = SeguridadUsuario_EmpresaId;
                    this.SeguridadUsuario_NickName = SeguridadUsuario_NickName;
                    this.SeguridadUsuario_CodigoExterno = SeguridadUsuario_CodigoExterno;
                    this.BancaCuenta_Id = BancaCuenta_Id;
                    this.BancaCuenta_TipoId = BancaCuenta_TipoId;
                    this.BancaCuenta_EmpresaId = BancaCuenta_EmpresaId;
                    this.BancaCuenta_Nombre = BancaCuenta_Nombre;
                    this.BancaCuenta_Numero = BancaCuenta_Numero;
                    this.BancaCuenta_Alias = BancaCuenta_Alias;
                    this.BancaCuenta_CBU = BancaCuenta_CBU;
                    this.BancaCuenta_BancoId = BancaCuenta_BancoId;
                    this.BancaCuenta_SucursalBancaria = BancaCuenta_SucursalBancaria;
                    this.BancaCuenta_CodigoExterno = BancaCuenta_CodigoExterno;
                    this.OperacionContenedor_Id = OperacionContenedor_Id;
                    this.OperacionContenedor_Nombre = OperacionContenedor_Nombre;
                    this.OperacionContenedor_DepositarioId = OperacionContenedor_DepositarioId;
                    this.OperacionContenedor_TipoId = OperacionContenedor_TipoId;
                    this.OperacionContenedor_Identificador = OperacionContenedor_Identificador;
                    this.OperacionContenedor_FechaApertura = OperacionContenedor_FechaApertura;
                    this.OperacionContenedor_FechaCierre = OperacionContenedor_FechaCierre;
                    this.OperacionSesion_Id = OperacionSesion_Id;
                    this.OperacionSesion_DepositarioId = OperacionSesion_DepositarioId;
                    this.OperacionSesion_UsuarioId = OperacionSesion_UsuarioId;
                    this.OperacionSesion_FechaInicio = OperacionSesion_FechaInicio;
                    this.OperacionSesion_FechaCierre = OperacionSesion_FechaCierre;
                    this.OperacionSesion_EsCierreAutomatico = OperacionSesion_EsCierreAutomatico;
                    this.OperacionTurno_Id = OperacionTurno_Id;
                    this.OperacionTurno_TurnoDepositarioId = OperacionTurno_TurnoDepositarioId;
                    this.OperacionTurno_DepositarioId = OperacionTurno_DepositarioId;
                    this.OperacionTurno_SectorId = OperacionTurno_SectorId;
                    this.OperacionTurno_FechaApertura = OperacionTurno_FechaApertura;
                    this.OperacionTurno_FechaCierre = OperacionTurno_FechaCierre;
                    this.OperacionTurno_Fecha = OperacionTurno_Fecha;
                    this.OperacionTurno_Secuencia = OperacionTurno_Secuencia;
                    this.OperacionTurno_CierreDiarioId = OperacionTurno_CierreDiarioId;
                    this.OperacionTurno_Observaciones = OperacionTurno_Observaciones;
                    this.OperacionTurno_CodigoTurno = OperacionTurno_CodigoTurno;
                    this.OperacionCierreDiario_Id = OperacionCierreDiario_Id;
                    this.OperacionCierreDiario_Nombre = OperacionCierreDiario_Nombre;
                    this.OperacionCierreDiario_Fecha = OperacionCierreDiario_Fecha;
                    this.OperacionCierreDiario_DepositarioId = OperacionCierreDiario_DepositarioId;
                    this.OperacionCierreDiario_SesionId = OperacionCierreDiario_SesionId;
                    this.OperacionCierreDiario_CodigoCierre = OperacionCierreDiario_CodigoCierre;
                    this.ValorOrigenValor_Id = ValorOrigenValor_Id;
                    this.ValorOrigenValor_Nombre = ValorOrigenValor_Nombre;
                    this.ValorOrigenValor_Descripcion = ValorOrigenValor_Descripcion;
                    this.ValorOrigenValor_EmpresaId = ValorOrigenValor_EmpresaId;
                    this.ValorOrigenValor_CodigoExterno = ValorOrigenValor_CodigoExterno;
                }
             /// <summary>
             /// Identificador de la Transaccion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Id","OperacionTransaccion_Id")]
             public Int64 OperacionTransaccion_Id { get; set; }
             /// <summary>
             /// Identificador del tipo de Transaccion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TipoId","OperacionTransaccion_TipoId")]
             public Int64 OperacionTransaccion_TipoId { get; set; }
             /// <summary>
             /// Identificador de Depositario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_DepositarioId","OperacionTransaccion_DepositarioId")]
             public Int64 OperacionTransaccion_DepositarioId { get; set; }
             /// <summary>
             /// Identificador de Sector
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SectorId","OperacionTransaccion_SectorId")]
             public Int64 OperacionTransaccion_SectorId { get; set; }
             /// <summary>
             /// Identificador de sucursal
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SucursalId","OperacionTransaccion_SucursalId")]
             public Int64 OperacionTransaccion_SucursalId { get; set; }
             /// <summary>
             /// Identificador de Moneda
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_MonedaId","OperacionTransaccion_MonedaId")]
             public Int64 OperacionTransaccion_MonedaId { get; set; }
             /// <summary>
             /// Identificador de usuario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioId","OperacionTransaccion_UsuarioId")]
             public Int64 OperacionTransaccion_UsuarioId { get; set; }
             /// <summary>
             /// Identificador de Cuenta bancaria
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CuentaId","OperacionTransaccion_CuentaId")]
             public Int64 OperacionTransaccion_CuentaId { get; set; }
             /// <summary>
             /// Identificador de Contenedor (Bolsa)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_ContenedorId","OperacionTransaccion_ContenedorId")]
             public Int64 OperacionTransaccion_ContenedorId { get; set; }
             /// <summary>
             /// Identificador de Sesión
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SesionId","OperacionTransaccion_SesionId")]
             public Int64 OperacionTransaccion_SesionId { get; set; }
             /// <summary>
             /// Identificador de Turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TurnoId","OperacionTransaccion_TurnoId")]
             public Int64 OperacionTransaccion_TurnoId { get; set; }
             /// <summary>
             /// Identificador de Cierre diario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CierreDiarioId","OperacionTransaccion_CierreDiarioId")]
             public Int64 OperacionTransaccion_CierreDiarioId { get; set; }
             /// <summary>
             /// Importe de valores detectado por la contadora
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalValidado","OperacionTransaccion_TotalValidado")]
             public Double OperacionTransaccion_TotalValidado { get; set; }
             /// <summary>
             /// Total de valores por identificar (Dice contener)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalAValidar","OperacionTransaccion_TotalAValidar")]
             public Double OperacionTransaccion_TotalAValidar { get; set; }
             /// <summary>
             /// Fecha de la operación
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Fecha","OperacionTransaccion_Fecha")]
             public DateTime OperacionTransaccion_Fecha { get; set; }
             /// <summary>
             /// Indica si la transacción fué finalizada sin errores
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Finalizada","OperacionTransaccion_Finalizada")]
             public Boolean OperacionTransaccion_Finalizada { get; set; }
             /// <summary>
             /// Indica si la transacción finalizó automáticamente (Por Timeout)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_EsDepositoAutomatico","OperacionTransaccion_EsDepositoAutomatico")]
             public Boolean OperacionTransaccion_EsDepositoAutomatico { get; set; }
             /// <summary>
             /// Identificador del orígen del valor 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_OrigenValorId","OperacionTransaccion_OrigenValorId")]
             public Int64 OperacionTransaccion_OrigenValorId { get; set; }
             /// <summary>
             /// Código unívoco formado por el identificador del depositario, fecha e identificados de registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CodigoOperacion","OperacionTransaccion_CodigoOperacion")]
             public String OperacionTransaccion_CodigoOperacion { get; set; }
             /// <summary>
             /// Fecha de creación del registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_FechaCreacion","OperacionTransaccion_FechaCreacion")]
             public DateTime OperacionTransaccion_FechaCreacion { get; set; }
             /// <summary>
             /// Identificador de transacción
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_Id","OperacionTipoTransaccion_Id")]
             public Int64 OperacionTipoTransaccion_Id { get; set; }
             /// <summary>
             /// Nombre del tipo de la transacción
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_Nombre","OperacionTipoTransaccion_Nombre")]
             public String OperacionTipoTransaccion_Nombre { get; set; }
             /// <summary>
             /// Descripción del tipo de la transacción
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_Descripcion","OperacionTipoTransaccion_Descripcion")]
             public String OperacionTipoTransaccion_Descripcion { get; set; }
             /// <summary>
             /// Identificador de depositario
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_Id","DispositivoDepositario_Id")]
             public Int64 DispositivoDepositario_Id { get; set; }
             /// <summary>
             /// Nombre de depositario
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_Nombre","DispositivoDepositario_Nombre")]
             public String DispositivoDepositario_Nombre { get; set; }
             /// <summary>
             /// Descripcion de depositario
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_Descripcion","DispositivoDepositario_Descripcion")]
             public String DispositivoDepositario_Descripcion { get; set; }
             /// <summary>
             /// Identificador de sector
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_SectorId","DispositivoDepositario_SectorId")]
             public Int64 DispositivoDepositario_SectorId { get; set; }
             /// <summary>
             /// Número de serie del equipo (Depositario)
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_NumeroSerie","DispositivoDepositario_NumeroSerie")]
             public String DispositivoDepositario_NumeroSerie { get; set; }
             /// <summary>
             /// Código externo (utilizado para integración con sistemas externos)
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_CodigoExterno","DispositivoDepositario_CodigoExterno")]
             public String DispositivoDepositario_CodigoExterno { get; set; }
             /// <summary>
             /// Identificador de Sector
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_Id","DirectorioSector_Id")]
             public Int64 DirectorioSector_Id { get; set; }
             /// <summary>
             /// Identificador de sucursal
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_SucursalId","DirectorioSector_SucursalId")]
             public Int64 DirectorioSector_SucursalId { get; set; }
             /// <summary>
             /// Nombre del sector
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_Nombre","DirectorioSector_Nombre")]
             public String DirectorioSector_Nombre { get; set; }
             /// <summary>
             /// Descripción del sector
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_Descripcion","DirectorioSector_Descripcion")]
             public String DirectorioSector_Descripcion { get; set; }
             /// <summary>
             /// Código externo (usado para integración con otros sistemas)
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_CodigoExterno","DirectorioSector_CodigoExterno")]
             public String DirectorioSector_CodigoExterno { get; set; }
             /// <summary>
             /// Identificador de Sucursal
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_Id","DirectorioSucursal_Id")]
             public Int64 DirectorioSucursal_Id { get; set; }
             /// <summary>
             /// Nombre de la sucursal
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_Nombre","DirectorioSucursal_Nombre")]
             public String DirectorioSucursal_Nombre { get; set; }
             /// <summary>
             /// Descripción de la sucursal
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_Descripcion","DirectorioSucursal_Descripcion")]
             public String DirectorioSucursal_Descripcion { get; set; }
             /// <summary>
             /// Identificador de Empresa
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_EmpresaId","DirectorioSucursal_EmpresaId")]
             public Int64 DirectorioSucursal_EmpresaId { get; set; }
             /// <summary>
             /// Código externo (usado para integración con otros sistemas)
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_CodigoExterno","DirectorioSucursal_CodigoExterno")]
             public String DirectorioSucursal_CodigoExterno { get; set; }
             /// <summary>
             /// Dirección de la Susursal
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_Direccion","DirectorioSucursal_Direccion")]
             public String DirectorioSucursal_Direccion { get; set; }
             /// <summary>
             /// Identificador del código postal
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_CodigoPostalId","DirectorioSucursal_CodigoPostalId")]
             public Int64 DirectorioSucursal_CodigoPostalId { get; set; }
             /// <summary>
             /// Identificador de zona
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_ZonaId","DirectorioSucursal_ZonaId")]
             public Int64 DirectorioSucursal_ZonaId { get; set; }
             /// <summary>
             /// Identificador de Modena
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_Id","ValorMoneda_Id")]
             public Int64 ValorMoneda_Id { get; set; }
             /// <summary>
             /// Nombre de la moneda
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_Nombre","ValorMoneda_Nombre")]
             public String ValorMoneda_Nombre { get; set; }
             /// <summary>
             /// Identificador de País
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_PaisId","ValorMoneda_PaisId")]
             public Int64 ValorMoneda_PaisId { get; set; }
             /// <summary>
             /// Código de Moneda
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_Codigo","ValorMoneda_Codigo")]
             public String ValorMoneda_Codigo { get; set; }
             /// <summary>
             /// Símbolo de moneda
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_Simbolo","ValorMoneda_Simbolo")]
             public String ValorMoneda_Simbolo { get; set; }
             /// <summary>
             /// Código externo (usado para integración con otros sistemas)
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_CodigoExterno","ValorMoneda_CodigoExterno")]
             public String ValorMoneda_CodigoExterno { get; set; }
             /// <summary>
             /// Identificador de usuario
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Id","SeguridadUsuario_Id")]
             public Int64 SeguridadUsuario_Id { get; set; }
             /// <summary>
             /// Identificador de Empresa
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_EmpresaId","SeguridadUsuario_EmpresaId")]
             public Int64 SeguridadUsuario_EmpresaId { get; set; }
             /// <summary>
             /// Nombre del usuario en el sistema
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_NickName","SeguridadUsuario_NickName")]
             public String SeguridadUsuario_NickName { get; set; }
             /// <summary>
             /// Código externo (usado para integración con otros sistemas)
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_CodigoExterno","SeguridadUsuario_CodigoExterno")]
             public String SeguridadUsuario_CodigoExterno { get; set; }
             /// <summary>
             /// Identificador de cuenta bancaria
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_Id","BancaCuenta_Id")]
             public Int64 BancaCuenta_Id { get; set; }
             /// <summary>
             /// Identificador de tipo de cuenta bancaria
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_TipoId","BancaCuenta_TipoId")]
             public Int64 BancaCuenta_TipoId { get; set; }
             /// <summary>
             /// Identificador de empresa
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_EmpresaId","BancaCuenta_EmpresaId")]
             public Int64 BancaCuenta_EmpresaId { get; set; }
             /// <summary>
             /// Nombre de la cuenta bancaria
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_Nombre","BancaCuenta_Nombre")]
             public String BancaCuenta_Nombre { get; set; }
             /// <summary>
             /// Número de la cuenta bancaria
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_Numero","BancaCuenta_Numero")]
             public String BancaCuenta_Numero { get; set; }
             /// <summary>
             /// Alias de la cuenta bancaria
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_Alias","BancaCuenta_Alias")]
             public String BancaCuenta_Alias { get; set; }
             /// <summary>
             /// Clave bancaria uniforme de la cuenta bancaria
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_CBU","BancaCuenta_CBU")]
             public String BancaCuenta_CBU { get; set; }
             /// <summary>
             /// Identificador de banco
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_BancoId","BancaCuenta_BancoId")]
             public Int64 BancaCuenta_BancoId { get; set; }
             /// <summary>
             /// Sucursal bancaria
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_SucursalBancaria","BancaCuenta_SucursalBancaria")]
             public String BancaCuenta_SucursalBancaria { get; set; }
             /// <summary>
             /// Código externo (usado para integración con otros sistemas)
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_CodigoExterno","BancaCuenta_CodigoExterno")]
             public String BancaCuenta_CodigoExterno { get; set; }
             /// <summary>
             /// Identificador de Contenedor (bolsa)
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_Id","OperacionContenedor_Id")]
             public Int64 OperacionContenedor_Id { get; set; }
             /// <summary>
             /// Nombre del contenedor (bolsa)
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_Nombre","OperacionContenedor_Nombre")]
             public String OperacionContenedor_Nombre { get; set; }
             /// <summary>
             /// Identificador de depositario
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_DepositarioId","OperacionContenedor_DepositarioId")]
             public Int64 OperacionContenedor_DepositarioId { get; set; }
             /// <summary>
             /// Identificador de tipo de cotenedor
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_TipoId","OperacionContenedor_TipoId")]
             public Int64 OperacionContenedor_TipoId { get; set; }
             /// <summary>
             /// Código alfanumérico que identifica el contenedor (Si en la configuración se indica como requerido)
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_Identificador","OperacionContenedor_Identificador")]
             public String OperacionContenedor_Identificador { get; set; }
             /// <summary>
             /// Fecha de apertura del contenedor (bolsa)
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_FechaApertura","OperacionContenedor_FechaApertura")]
             public DateTime OperacionContenedor_FechaApertura { get; set; }
             /// <summary>
             /// Fecha de cierre del contenedor (bolsa)
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_FechaCierre","OperacionContenedor_FechaCierre")]
             public DateTime OperacionContenedor_FechaCierre { get; set; }
             /// <summary>
             /// Identificador de Sesión
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_Id","OperacionSesion_Id")]
             public Int64 OperacionSesion_Id { get; set; }
             /// <summary>
             /// Identificador de depositario en donde se genera la sesión
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_DepositarioId","OperacionSesion_DepositarioId")]
             public Int64 OperacionSesion_DepositarioId { get; set; }
             /// <summary>
             /// Identificador de usuario que genera la sesión
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_UsuarioId","OperacionSesion_UsuarioId")]
             public Int64 OperacionSesion_UsuarioId { get; set; }
             /// <summary>
             /// Fecha de inicio de la sesión
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_FechaInicio","OperacionSesion_FechaInicio")]
             public DateTime OperacionSesion_FechaInicio { get; set; }
             /// <summary>
             /// Fecha de cierre de la sesión
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_FechaCierre","OperacionSesion_FechaCierre")]
             public DateTime OperacionSesion_FechaCierre { get; set; }
             /// <summary>
             /// indica si la sesión se cerró automáticamente (Timeout)
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_EsCierreAutomatico","OperacionSesion_EsCierreAutomatico")]
             public Boolean OperacionSesion_EsCierreAutomatico { get; set; }
             /// <summary>
             /// Identificador de turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_Id","OperacionTurno_Id")]
             public Int64 OperacionTurno_Id { get; set; }
             /// <summary>
             /// Identificador de depositario / turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_TurnoDepositarioId","OperacionTurno_TurnoDepositarioId")]
             public Int64 OperacionTurno_TurnoDepositarioId { get; set; }
             /// <summary>
             /// Identificador de depositario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_DepositarioId","OperacionTurno_DepositarioId")]
             public Int64 OperacionTurno_DepositarioId { get; set; }
             /// <summary>
             /// Identificador de sector
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_SectorId","OperacionTurno_SectorId")]
             public Int64 OperacionTurno_SectorId { get; set; }
             /// <summary>
             /// Fecha de apertura del turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_FechaApertura","OperacionTurno_FechaApertura")]
             public DateTime OperacionTurno_FechaApertura { get; set; }
             /// <summary>
             /// Fecha de cierre del turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_FechaCierre","OperacionTurno_FechaCierre")]
             public DateTime OperacionTurno_FechaCierre { get; set; }
             /// <summary>
             /// Fecha de programación del turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_Fecha","OperacionTurno_Fecha")]
             public DateTime OperacionTurno_Fecha { get; set; }
             /// <summary>
             /// Secuencia del turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_Secuencia","OperacionTurno_Secuencia")]
             public Int32 OperacionTurno_Secuencia { get; set; }
             /// <summary>
             /// Identificador del cierre diario que incluye al turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_CierreDiarioId","OperacionTurno_CierreDiarioId")]
             public Int64 OperacionTurno_CierreDiarioId { get; set; }
             /// <summary>
             /// Observaciones
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_Observaciones","OperacionTurno_Observaciones")]
             public String OperacionTurno_Observaciones { get; set; }
             /// <summary>
             /// Código del turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_CodigoTurno","OperacionTurno_CodigoTurno")]
             public String OperacionTurno_CodigoTurno { get; set; }
             /// <summary>
             /// Identificador del cierre diario
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_Id","OperacionCierreDiario_Id")]
             public Int64 OperacionCierreDiario_Id { get; set; }
             /// <summary>
             /// Nombre del cierre diario
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_Nombre","OperacionCierreDiario_Nombre")]
             public String OperacionCierreDiario_Nombre { get; set; }
             /// <summary>
             /// Fecha del cierre diario
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_Fecha","OperacionCierreDiario_Fecha")]
             public DateTime OperacionCierreDiario_Fecha { get; set; }
             /// <summary>
             /// Identificador de depositario
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_DepositarioId","OperacionCierreDiario_DepositarioId")]
             public Int64 OperacionCierreDiario_DepositarioId { get; set; }
             /// <summary>
             /// Identificador de la sesión en la que se generó el cierre diario
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_SesionId","OperacionCierreDiario_SesionId")]
             public Int64 OperacionCierreDiario_SesionId { get; set; }
             /// <summary>
             /// Código del cierre diario
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_CodigoCierre","OperacionCierreDiario_CodigoCierre")]
             public String OperacionCierreDiario_CodigoCierre { get; set; }
             /// <summary>
             /// Identificador del orígen del valor
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_Id","ValorOrigenValor_Id")]
             public Int64 ValorOrigenValor_Id { get; set; }
             /// <summary>
             /// Nombre del orígen del valor
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_Nombre","ValorOrigenValor_Nombre")]
             public String ValorOrigenValor_Nombre { get; set; }
             /// <summary>
             /// Descripción del orígen del valor
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_Descripcion","ValorOrigenValor_Descripcion")]
             public String ValorOrigenValor_Descripcion { get; set; }
             /// <summary>
             /// Identificador de empresa
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_EmpresaId","ValorOrigenValor_EmpresaId")]
             public Int64 ValorOrigenValor_EmpresaId { get; set; }
             /// <summary>
             /// Código externo (usado para integración con otros sistemas)
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_CodigoExterno","ValorOrigenValor_CodigoExterno")]
             public String ValorOrigenValor_CodigoExterno { get; set; }
				
			} //Class OperacionTransaccion 
			
} //namespace DepositaryWebApi.Entities.Views.Integracion
//////////////////////////////////////////////////////////////////////////////////
		namespace DepositaryWebApi.Entities.Views.Integracion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Integracion")]  // Database Schema Name
			[DataItemAttributeObjectName("OperacionTransaccionDetalle","OperacionTransaccionDetalle")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class OperacionTransaccionDetalle : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string OperacionTransaccionDetalle_Id = "OperacionTransaccionDetalle_Id";
					public const string OperacionTransaccionDetalle_TransaccionId = "OperacionTransaccionDetalle_TransaccionId";
					public const string OperacionTransaccionDetalle_DenominacionId = "OperacionTransaccionDetalle_DenominacionId";
					public const string OperacionTransaccionDetalle_CantidadUnidades = "OperacionTransaccionDetalle_CantidadUnidades";
					public const string OperacionTransaccionDetalle_Fecha = "OperacionTransaccionDetalle_Fecha";
					public const string OperacionTransaccion_Id = "OperacionTransaccion_Id";
					public const string OperacionTransaccion_TipoId = "OperacionTransaccion_TipoId";
					public const string OperacionTransaccion_DepositarioId = "OperacionTransaccion_DepositarioId";
					public const string OperacionTransaccion_SectorId = "OperacionTransaccion_SectorId";
					public const string OperacionTransaccion_SucursalId = "OperacionTransaccion_SucursalId";
					public const string OperacionTransaccion_MonedaId = "OperacionTransaccion_MonedaId";
					public const string OperacionTransaccion_UsuarioId = "OperacionTransaccion_UsuarioId";
					public const string OperacionTransaccion_CuentaId = "OperacionTransaccion_CuentaId";
					public const string OperacionTransaccion_ContenedorId = "OperacionTransaccion_ContenedorId";
					public const string OperacionTransaccion_SesionId = "OperacionTransaccion_SesionId";
					public const string OperacionTransaccion_TurnoId = "OperacionTransaccion_TurnoId";
					public const string OperacionTransaccion_CierreDiarioId = "OperacionTransaccion_CierreDiarioId";
					public const string OperacionTransaccion_TotalValidado = "OperacionTransaccion_TotalValidado";
					public const string OperacionTransaccion_TotalAValidar = "OperacionTransaccion_TotalAValidar";
					public const string OperacionTransaccion_Fecha = "OperacionTransaccion_Fecha";
					public const string OperacionTransaccion_Finalizada = "OperacionTransaccion_Finalizada";
					public const string OperacionTransaccion_EsDepositoAutomatico = "OperacionTransaccion_EsDepositoAutomatico";
					public const string OperacionTransaccion_OrigenValorId = "OperacionTransaccion_OrigenValorId";
					public const string ValorDenominacion_Id = "ValorDenominacion_Id";
					public const string ValorDenominacion_Nombre = "ValorDenominacion_Nombre";
					public const string ValorDenominacion_TipoValorId = "ValorDenominacion_TipoValorId";
					public const string ValorDenominacion_MonedaId = "ValorDenominacion_MonedaId";
					public const string ValorDenominacion_Unidades = "ValorDenominacion_Unidades";
					public const string ValorDenominacion_CodigoCcTalk = "ValorDenominacion_CodigoCcTalk";
					public const string ValorDenominacion_CodigoExterno = "ValorDenominacion_CodigoExterno";
				}
				public enum FieldEnum : int
                {
					OperacionTransaccionDetalle_Id,
					OperacionTransaccionDetalle_TransaccionId,
					OperacionTransaccionDetalle_DenominacionId,
					OperacionTransaccionDetalle_CantidadUnidades,
					OperacionTransaccionDetalle_Fecha,
					OperacionTransaccion_Id,
					OperacionTransaccion_TipoId,
					OperacionTransaccion_DepositarioId,
					OperacionTransaccion_SectorId,
					OperacionTransaccion_SucursalId,
					OperacionTransaccion_MonedaId,
					OperacionTransaccion_UsuarioId,
					OperacionTransaccion_CuentaId,
					OperacionTransaccion_ContenedorId,
					OperacionTransaccion_SesionId,
					OperacionTransaccion_TurnoId,
					OperacionTransaccion_CierreDiarioId,
					OperacionTransaccion_TotalValidado,
					OperacionTransaccion_TotalAValidar,
					OperacionTransaccion_Fecha,
					OperacionTransaccion_Finalizada,
					OperacionTransaccion_EsDepositoAutomatico,
					OperacionTransaccion_OrigenValorId,
					ValorDenominacion_Id,
					ValorDenominacion_Nombre,
					ValorDenominacion_TipoValorId,
					ValorDenominacion_MonedaId,
					ValorDenominacion_Unidades,
					ValorDenominacion_CodigoCcTalk,
					ValorDenominacion_CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// </summary>
                public OperacionTransaccionDetalle()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// </summary>
                public  OperacionTransaccionDetalle(Int64 OperacionTransaccionDetalle_Id,Int64 OperacionTransaccionDetalle_TransaccionId,Int64 OperacionTransaccionDetalle_DenominacionId,Int64 OperacionTransaccionDetalle_CantidadUnidades,DateTime OperacionTransaccionDetalle_Fecha,Int64 OperacionTransaccion_Id,Int64 OperacionTransaccion_TipoId,Int64 OperacionTransaccion_DepositarioId,Int64 OperacionTransaccion_SectorId,Int64 OperacionTransaccion_SucursalId,Int64 OperacionTransaccion_MonedaId,Int64 OperacionTransaccion_UsuarioId,Int64 OperacionTransaccion_CuentaId,Int64 OperacionTransaccion_ContenedorId,Int64 OperacionTransaccion_SesionId,Int64 OperacionTransaccion_TurnoId,Int64 OperacionTransaccion_CierreDiarioId,Double OperacionTransaccion_TotalValidado,Double OperacionTransaccion_TotalAValidar,DateTime OperacionTransaccion_Fecha,Boolean OperacionTransaccion_Finalizada,Boolean OperacionTransaccion_EsDepositoAutomatico,Int64 OperacionTransaccion_OrigenValorId,Int64 ValorDenominacion_Id,String ValorDenominacion_Nombre,Int64 ValorDenominacion_TipoValorId,Int64 ValorDenominacion_MonedaId,Decimal ValorDenominacion_Unidades,String ValorDenominacion_CodigoCcTalk,String ValorDenominacion_CodigoExterno)
                {
                    this.OperacionTransaccionDetalle_Id = OperacionTransaccionDetalle_Id;
                    this.OperacionTransaccionDetalle_TransaccionId = OperacionTransaccionDetalle_TransaccionId;
                    this.OperacionTransaccionDetalle_DenominacionId = OperacionTransaccionDetalle_DenominacionId;
                    this.OperacionTransaccionDetalle_CantidadUnidades = OperacionTransaccionDetalle_CantidadUnidades;
                    this.OperacionTransaccionDetalle_Fecha = OperacionTransaccionDetalle_Fecha;
                    this.OperacionTransaccion_Id = OperacionTransaccion_Id;
                    this.OperacionTransaccion_TipoId = OperacionTransaccion_TipoId;
                    this.OperacionTransaccion_DepositarioId = OperacionTransaccion_DepositarioId;
                    this.OperacionTransaccion_SectorId = OperacionTransaccion_SectorId;
                    this.OperacionTransaccion_SucursalId = OperacionTransaccion_SucursalId;
                    this.OperacionTransaccion_MonedaId = OperacionTransaccion_MonedaId;
                    this.OperacionTransaccion_UsuarioId = OperacionTransaccion_UsuarioId;
                    this.OperacionTransaccion_CuentaId = OperacionTransaccion_CuentaId;
                    this.OperacionTransaccion_ContenedorId = OperacionTransaccion_ContenedorId;
                    this.OperacionTransaccion_SesionId = OperacionTransaccion_SesionId;
                    this.OperacionTransaccion_TurnoId = OperacionTransaccion_TurnoId;
                    this.OperacionTransaccion_CierreDiarioId = OperacionTransaccion_CierreDiarioId;
                    this.OperacionTransaccion_TotalValidado = OperacionTransaccion_TotalValidado;
                    this.OperacionTransaccion_TotalAValidar = OperacionTransaccion_TotalAValidar;
                    this.OperacionTransaccion_Fecha = OperacionTransaccion_Fecha;
                    this.OperacionTransaccion_Finalizada = OperacionTransaccion_Finalizada;
                    this.OperacionTransaccion_EsDepositoAutomatico = OperacionTransaccion_EsDepositoAutomatico;
                    this.OperacionTransaccion_OrigenValorId = OperacionTransaccion_OrigenValorId;
                    this.ValorDenominacion_Id = ValorDenominacion_Id;
                    this.ValorDenominacion_Nombre = ValorDenominacion_Nombre;
                    this.ValorDenominacion_TipoValorId = ValorDenominacion_TipoValorId;
                    this.ValorDenominacion_MonedaId = ValorDenominacion_MonedaId;
                    this.ValorDenominacion_Unidades = ValorDenominacion_Unidades;
                    this.ValorDenominacion_CodigoCcTalk = ValorDenominacion_CodigoCcTalk;
                    this.ValorDenominacion_CodigoExterno = ValorDenominacion_CodigoExterno;
                }
             /// <summary>
             /// Identificador de registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_Id","OperacionTransaccionDetalle_Id")]
             public Int64 OperacionTransaccionDetalle_Id { get; set; }
             /// <summary>
             /// Identificador de la transaccion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_TransaccionId","OperacionTransaccionDetalle_TransaccionId")]
             public Int64 OperacionTransaccionDetalle_TransaccionId { get; set; }
             /// <summary>
             /// Identificador de la denominacion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_DenominacionId","OperacionTransaccionDetalle_DenominacionId")]
             public Int64 OperacionTransaccionDetalle_DenominacionId { get; set; }
             /// <summary>
             /// Cantidad sensada de la denominación
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_CantidadUnidades","OperacionTransaccionDetalle_CantidadUnidades")]
             public Int64 OperacionTransaccionDetalle_CantidadUnidades { get; set; }
             /// <summary>
             /// Fecha de alta del registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_Fecha","OperacionTransaccionDetalle_Fecha")]
             public DateTime OperacionTransaccionDetalle_Fecha { get; set; }
             /// <summary>
             /// Identificador de la Transaccion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Id","OperacionTransaccion_Id")]
             public Int64 OperacionTransaccion_Id { get; set; }
             /// <summary>
             /// Identificador del tipo de Transaccion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TipoId","OperacionTransaccion_TipoId")]
             public Int64 OperacionTransaccion_TipoId { get; set; }
             /// <summary>
             /// Identificador de Depositario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_DepositarioId","OperacionTransaccion_DepositarioId")]
             public Int64 OperacionTransaccion_DepositarioId { get; set; }
             /// <summary>
             /// Identificador de Sector
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SectorId","OperacionTransaccion_SectorId")]
             public Int64 OperacionTransaccion_SectorId { get; set; }
             /// <summary>
             /// Identificador de sucursal
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SucursalId","OperacionTransaccion_SucursalId")]
             public Int64 OperacionTransaccion_SucursalId { get; set; }
             /// <summary>
             /// Identificador de Moneda
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_MonedaId","OperacionTransaccion_MonedaId")]
             public Int64 OperacionTransaccion_MonedaId { get; set; }
             /// <summary>
             /// Identificador de usuario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioId","OperacionTransaccion_UsuarioId")]
             public Int64 OperacionTransaccion_UsuarioId { get; set; }
             /// <summary>
             /// Identificador de Cuenta bancaria
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CuentaId","OperacionTransaccion_CuentaId")]
             public Int64 OperacionTransaccion_CuentaId { get; set; }
             /// <summary>
             /// Identificador de Contenedor (Bolsa)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_ContenedorId","OperacionTransaccion_ContenedorId")]
             public Int64 OperacionTransaccion_ContenedorId { get; set; }
             /// <summary>
             /// Identificador de Sesión
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SesionId","OperacionTransaccion_SesionId")]
             public Int64 OperacionTransaccion_SesionId { get; set; }
             /// <summary>
             /// Identificador de Turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TurnoId","OperacionTransaccion_TurnoId")]
             public Int64 OperacionTransaccion_TurnoId { get; set; }
             /// <summary>
             /// Identificador de Cierre diario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CierreDiarioId","OperacionTransaccion_CierreDiarioId")]
             public Int64 OperacionTransaccion_CierreDiarioId { get; set; }
             /// <summary>
             /// Importe de valores detectado por la contadora
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalValidado","OperacionTransaccion_TotalValidado")]
             public Double OperacionTransaccion_TotalValidado { get; set; }
             /// <summary>
             /// Total de valores por identificar (Dice contener)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalAValidar","OperacionTransaccion_TotalAValidar")]
             public Double OperacionTransaccion_TotalAValidar { get; set; }
             /// <summary>
             /// Fecha de la operación
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Fecha","OperacionTransaccion_Fecha")]
             public DateTime OperacionTransaccion_Fecha { get; set; }
             /// <summary>
             /// Indica si la transacción fué finalizada sin errores
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Finalizada","OperacionTransaccion_Finalizada")]
             public Boolean OperacionTransaccion_Finalizada { get; set; }
             /// <summary>
             /// Indica si la transacción finalizó automáticamente (Por Timeout)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_EsDepositoAutomatico","OperacionTransaccion_EsDepositoAutomatico")]
             public Boolean OperacionTransaccion_EsDepositoAutomatico { get; set; }
             /// <summary>
             /// Identificador del orígen del valor 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_OrigenValorId","OperacionTransaccion_OrigenValorId")]
             public Int64 OperacionTransaccion_OrigenValorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_Id","ValorDenominacion_Id")]
             public Int64 ValorDenominacion_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_Nombre","ValorDenominacion_Nombre")]
             public String ValorDenominacion_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_TipoValorId","ValorDenominacion_TipoValorId")]
             public Int64 ValorDenominacion_TipoValorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_MonedaId","ValorDenominacion_MonedaId")]
             public Int64 ValorDenominacion_MonedaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_Unidades","ValorDenominacion_Unidades")]
             public Decimal ValorDenominacion_Unidades { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_CodigoCcTalk","ValorDenominacion_CodigoCcTalk")]
             public String ValorDenominacion_CodigoCcTalk { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_CodigoExterno","ValorDenominacion_CodigoExterno")]
             public String ValorDenominacion_CodigoExterno { get; set; }
				
			} //Class OperacionTransaccionDetalle 
			
} //namespace DepositaryWebApi.Entities.Views.Integracion
//////////////////////////////////////////////////////////////////////////////////
		namespace DepositaryWebApi.Entities.Views.Integracion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Integracion")]  // Database Schema Name
			[DataItemAttributeObjectName("OperacionTransaccionSobre","OperacionTransaccionSobre")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class OperacionTransaccionSobre : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string OperacionTransaccionSobre_Id = "OperacionTransaccionSobre_Id";
					public const string OperacionTransaccionSobre_TransaccionId = "OperacionTransaccionSobre_TransaccionId";
					public const string OperacionTransaccionSobre_CodigoSobre = "OperacionTransaccionSobre_CodigoSobre";
					public const string OperacionTransaccionSobre_Fecha = "OperacionTransaccionSobre_Fecha";
					public const string OperacionTransaccion_Id = "OperacionTransaccion_Id";
					public const string OperacionTransaccion_TipoId = "OperacionTransaccion_TipoId";
					public const string OperacionTransaccion_DepositarioId = "OperacionTransaccion_DepositarioId";
					public const string OperacionTransaccion_SectorId = "OperacionTransaccion_SectorId";
					public const string OperacionTransaccion_SucursalId = "OperacionTransaccion_SucursalId";
					public const string OperacionTransaccion_MonedaId = "OperacionTransaccion_MonedaId";
					public const string OperacionTransaccion_UsuarioId = "OperacionTransaccion_UsuarioId";
					public const string OperacionTransaccion_CuentaId = "OperacionTransaccion_CuentaId";
					public const string OperacionTransaccion_ContenedorId = "OperacionTransaccion_ContenedorId";
					public const string OperacionTransaccion_SesionId = "OperacionTransaccion_SesionId";
					public const string OperacionTransaccion_TurnoId = "OperacionTransaccion_TurnoId";
					public const string OperacionTransaccion_CierreDiarioId = "OperacionTransaccion_CierreDiarioId";
					public const string OperacionTransaccion_TotalValidado = "OperacionTransaccion_TotalValidado";
					public const string OperacionTransaccion_TotalAValidar = "OperacionTransaccion_TotalAValidar";
					public const string OperacionTransaccion_Fecha = "OperacionTransaccion_Fecha";
					public const string OperacionTransaccion_Finalizada = "OperacionTransaccion_Finalizada";
					public const string OperacionTransaccion_EsDepositoAutomatico = "OperacionTransaccion_EsDepositoAutomatico";
					public const string OperacionTransaccion_OrigenValorId = "OperacionTransaccion_OrigenValorId";
					public const string OperacionTransaccion_CodigoOperacion = "OperacionTransaccion_CodigoOperacion";
				}
				public enum FieldEnum : int
                {
					OperacionTransaccionSobre_Id,
					OperacionTransaccionSobre_TransaccionId,
					OperacionTransaccionSobre_CodigoSobre,
					OperacionTransaccionSobre_Fecha,
					OperacionTransaccion_Id,
					OperacionTransaccion_TipoId,
					OperacionTransaccion_DepositarioId,
					OperacionTransaccion_SectorId,
					OperacionTransaccion_SucursalId,
					OperacionTransaccion_MonedaId,
					OperacionTransaccion_UsuarioId,
					OperacionTransaccion_CuentaId,
					OperacionTransaccion_ContenedorId,
					OperacionTransaccion_SesionId,
					OperacionTransaccion_TurnoId,
					OperacionTransaccion_CierreDiarioId,
					OperacionTransaccion_TotalValidado,
					OperacionTransaccion_TotalAValidar,
					OperacionTransaccion_Fecha,
					OperacionTransaccion_Finalizada,
					OperacionTransaccion_EsDepositoAutomatico,
					OperacionTransaccion_OrigenValorId,
					OperacionTransaccion_CodigoOperacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// </summary>
                public OperacionTransaccionSobre()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// </summary>
                public  OperacionTransaccionSobre(Int64 OperacionTransaccionSobre_Id,Int64 OperacionTransaccionSobre_TransaccionId,String OperacionTransaccionSobre_CodigoSobre,DateTime OperacionTransaccionSobre_Fecha,Int64 OperacionTransaccion_Id,Int64 OperacionTransaccion_TipoId,Int64 OperacionTransaccion_DepositarioId,Int64 OperacionTransaccion_SectorId,Int64 OperacionTransaccion_SucursalId,Int64 OperacionTransaccion_MonedaId,Int64 OperacionTransaccion_UsuarioId,Int64 OperacionTransaccion_CuentaId,Int64 OperacionTransaccion_ContenedorId,Int64 OperacionTransaccion_SesionId,Int64 OperacionTransaccion_TurnoId,Int64 OperacionTransaccion_CierreDiarioId,Double OperacionTransaccion_TotalValidado,Double OperacionTransaccion_TotalAValidar,DateTime OperacionTransaccion_Fecha,Boolean OperacionTransaccion_Finalizada,Boolean OperacionTransaccion_EsDepositoAutomatico,Int64 OperacionTransaccion_OrigenValorId,String OperacionTransaccion_CodigoOperacion)
                {
                    this.OperacionTransaccionSobre_Id = OperacionTransaccionSobre_Id;
                    this.OperacionTransaccionSobre_TransaccionId = OperacionTransaccionSobre_TransaccionId;
                    this.OperacionTransaccionSobre_CodigoSobre = OperacionTransaccionSobre_CodigoSobre;
                    this.OperacionTransaccionSobre_Fecha = OperacionTransaccionSobre_Fecha;
                    this.OperacionTransaccion_Id = OperacionTransaccion_Id;
                    this.OperacionTransaccion_TipoId = OperacionTransaccion_TipoId;
                    this.OperacionTransaccion_DepositarioId = OperacionTransaccion_DepositarioId;
                    this.OperacionTransaccion_SectorId = OperacionTransaccion_SectorId;
                    this.OperacionTransaccion_SucursalId = OperacionTransaccion_SucursalId;
                    this.OperacionTransaccion_MonedaId = OperacionTransaccion_MonedaId;
                    this.OperacionTransaccion_UsuarioId = OperacionTransaccion_UsuarioId;
                    this.OperacionTransaccion_CuentaId = OperacionTransaccion_CuentaId;
                    this.OperacionTransaccion_ContenedorId = OperacionTransaccion_ContenedorId;
                    this.OperacionTransaccion_SesionId = OperacionTransaccion_SesionId;
                    this.OperacionTransaccion_TurnoId = OperacionTransaccion_TurnoId;
                    this.OperacionTransaccion_CierreDiarioId = OperacionTransaccion_CierreDiarioId;
                    this.OperacionTransaccion_TotalValidado = OperacionTransaccion_TotalValidado;
                    this.OperacionTransaccion_TotalAValidar = OperacionTransaccion_TotalAValidar;
                    this.OperacionTransaccion_Fecha = OperacionTransaccion_Fecha;
                    this.OperacionTransaccion_Finalizada = OperacionTransaccion_Finalizada;
                    this.OperacionTransaccion_EsDepositoAutomatico = OperacionTransaccion_EsDepositoAutomatico;
                    this.OperacionTransaccion_OrigenValorId = OperacionTransaccion_OrigenValorId;
                    this.OperacionTransaccion_CodigoOperacion = OperacionTransaccion_CodigoOperacion;
                }
             /// <summary>
             /// Identificador de registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_Id","OperacionTransaccionSobre_Id")]
             public Int64 OperacionTransaccionSobre_Id { get; set; }
             /// <summary>
             /// Identificador de la transacción
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_TransaccionId","OperacionTransaccionSobre_TransaccionId")]
             public Int64 OperacionTransaccionSobre_TransaccionId { get; set; }
             /// <summary>
             /// Código alfanumérico que identifica el sobre (Si en la configuración se indica como requerido)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_CodigoSobre","OperacionTransaccionSobre_CodigoSobre")]
             public String OperacionTransaccionSobre_CodigoSobre { get; set; }
             /// <summary>
             /// Fecha de alta del registro 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_Fecha","OperacionTransaccionSobre_Fecha")]
             public DateTime OperacionTransaccionSobre_Fecha { get; set; }
             /// <summary>
             /// Identificador de la Transaccion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Id","OperacionTransaccion_Id")]
             public Int64 OperacionTransaccion_Id { get; set; }
             /// <summary>
             /// Identificador del tipo de Transaccion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TipoId","OperacionTransaccion_TipoId")]
             public Int64 OperacionTransaccion_TipoId { get; set; }
             /// <summary>
             /// Identificador de Depositario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_DepositarioId","OperacionTransaccion_DepositarioId")]
             public Int64 OperacionTransaccion_DepositarioId { get; set; }
             /// <summary>
             /// Identificador de Sector
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SectorId","OperacionTransaccion_SectorId")]
             public Int64 OperacionTransaccion_SectorId { get; set; }
             /// <summary>
             /// Identificador de sucursal
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SucursalId","OperacionTransaccion_SucursalId")]
             public Int64 OperacionTransaccion_SucursalId { get; set; }
             /// <summary>
             /// Identificador de Moneda
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_MonedaId","OperacionTransaccion_MonedaId")]
             public Int64 OperacionTransaccion_MonedaId { get; set; }
             /// <summary>
             /// Identificador de usuario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioId","OperacionTransaccion_UsuarioId")]
             public Int64 OperacionTransaccion_UsuarioId { get; set; }
             /// <summary>
             /// Identificador de Cuenta bancaria
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CuentaId","OperacionTransaccion_CuentaId")]
             public Int64 OperacionTransaccion_CuentaId { get; set; }
             /// <summary>
             /// Identificador de Contenedor (Bolsa)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_ContenedorId","OperacionTransaccion_ContenedorId")]
             public Int64 OperacionTransaccion_ContenedorId { get; set; }
             /// <summary>
             /// Identificador de Sesión
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SesionId","OperacionTransaccion_SesionId")]
             public Int64 OperacionTransaccion_SesionId { get; set; }
             /// <summary>
             /// Identificador de Turno
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TurnoId","OperacionTransaccion_TurnoId")]
             public Int64 OperacionTransaccion_TurnoId { get; set; }
             /// <summary>
             /// Identificador de Cierre diario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CierreDiarioId","OperacionTransaccion_CierreDiarioId")]
             public Int64 OperacionTransaccion_CierreDiarioId { get; set; }
             /// <summary>
             /// Importe de valores detectado por la contadora
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalValidado","OperacionTransaccion_TotalValidado")]
             public Double OperacionTransaccion_TotalValidado { get; set; }
             /// <summary>
             /// Total de valores por identificar (Dice contener)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalAValidar","OperacionTransaccion_TotalAValidar")]
             public Double OperacionTransaccion_TotalAValidar { get; set; }
             /// <summary>
             /// Fecha de la operación
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Fecha","OperacionTransaccion_Fecha")]
             public DateTime OperacionTransaccion_Fecha { get; set; }
             /// <summary>
             /// Indica si la transacción fué finalizada sin errores
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Finalizada","OperacionTransaccion_Finalizada")]
             public Boolean OperacionTransaccion_Finalizada { get; set; }
             /// <summary>
             /// Indica si la transacción finalizó automáticamente (Por Timeout)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_EsDepositoAutomatico","OperacionTransaccion_EsDepositoAutomatico")]
             public Boolean OperacionTransaccion_EsDepositoAutomatico { get; set; }
             /// <summary>
             /// Identificador del orígen del valor 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_OrigenValorId","OperacionTransaccion_OrigenValorId")]
             public Int64 OperacionTransaccion_OrigenValorId { get; set; }
             /// <summary>
             /// Código unívoco formado por el identificador del depositario, fecha e identificados de registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CodigoOperacion","OperacionTransaccion_CodigoOperacion")]
             public String OperacionTransaccion_CodigoOperacion { get; set; }
				
			} //Class OperacionTransaccionSobre 
			
} //namespace DepositaryWebApi.Entities.Views.Integracion
//////////////////////////////////////////////////////////////////////////////////
		namespace DepositaryWebApi.Entities.Views.Integracion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Integracion")]  // Database Schema Name
			[DataItemAttributeObjectName("OperacionTransaccionSobreDetalle","OperacionTransaccionSobreDetalle")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class OperacionTransaccionSobreDetalle : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string OperacionTransaccionSobreDetalle_Id = "OperacionTransaccionSobreDetalle_Id";
					public const string OperacionTransaccionSobreDetalle_SobreId = "OperacionTransaccionSobreDetalle_SobreId";
					public const string OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId = "OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId";
					public const string OperacionTransaccionSobreDetalle_CantidadDeclarada = "OperacionTransaccionSobreDetalle_CantidadDeclarada";
					public const string OperacionTransaccionSobreDetalle_ValorDeclarado = "OperacionTransaccionSobreDetalle_ValorDeclarado";
					public const string OperacionTransaccionSobreDetalle_Fecha = "OperacionTransaccionSobreDetalle_Fecha";
					public const string OperacionTransaccionSobre_Id = "OperacionTransaccionSobre_Id";
					public const string OperacionTransaccionSobre_TransaccionId = "OperacionTransaccionSobre_TransaccionId";
					public const string OperacionTransaccionSobre_CodigoSobre = "OperacionTransaccionSobre_CodigoSobre";
					public const string OperacionTransaccionSobre_Fecha = "OperacionTransaccionSobre_Fecha";
					public const string ValorRelacionMonedaTipoValor_Id = "ValorRelacionMonedaTipoValor_Id";
					public const string ValorRelacionMonedaTipoValor_MonedaId = "ValorRelacionMonedaTipoValor_MonedaId";
					public const string ValorRelacionMonedaTipoValor_TipoValorId = "ValorRelacionMonedaTipoValor_TipoValorId";
				}
				public enum FieldEnum : int
                {
					OperacionTransaccionSobreDetalle_Id,
					OperacionTransaccionSobreDetalle_SobreId,
					OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId,
					OperacionTransaccionSobreDetalle_CantidadDeclarada,
					OperacionTransaccionSobreDetalle_ValorDeclarado,
					OperacionTransaccionSobreDetalle_Fecha,
					OperacionTransaccionSobre_Id,
					OperacionTransaccionSobre_TransaccionId,
					OperacionTransaccionSobre_CodigoSobre,
					OperacionTransaccionSobre_Fecha,
					ValorRelacionMonedaTipoValor_Id,
					ValorRelacionMonedaTipoValor_MonedaId,
					ValorRelacionMonedaTipoValor_TipoValorId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// </summary>
                public OperacionTransaccionSobreDetalle()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// </summary>
                public  OperacionTransaccionSobreDetalle(Int64 OperacionTransaccionSobreDetalle_Id,Int64 OperacionTransaccionSobreDetalle_SobreId,Int64 OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId,Int64 OperacionTransaccionSobreDetalle_CantidadDeclarada,Double OperacionTransaccionSobreDetalle_ValorDeclarado,DateTime OperacionTransaccionSobreDetalle_Fecha,Int64 OperacionTransaccionSobre_Id,Int64 OperacionTransaccionSobre_TransaccionId,String OperacionTransaccionSobre_CodigoSobre,DateTime OperacionTransaccionSobre_Fecha,Int64 ValorRelacionMonedaTipoValor_Id,Int64 ValorRelacionMonedaTipoValor_MonedaId,Int64 ValorRelacionMonedaTipoValor_TipoValorId)
                {
                    this.OperacionTransaccionSobreDetalle_Id = OperacionTransaccionSobreDetalle_Id;
                    this.OperacionTransaccionSobreDetalle_SobreId = OperacionTransaccionSobreDetalle_SobreId;
                    this.OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId = OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId;
                    this.OperacionTransaccionSobreDetalle_CantidadDeclarada = OperacionTransaccionSobreDetalle_CantidadDeclarada;
                    this.OperacionTransaccionSobreDetalle_ValorDeclarado = OperacionTransaccionSobreDetalle_ValorDeclarado;
                    this.OperacionTransaccionSobreDetalle_Fecha = OperacionTransaccionSobreDetalle_Fecha;
                    this.OperacionTransaccionSobre_Id = OperacionTransaccionSobre_Id;
                    this.OperacionTransaccionSobre_TransaccionId = OperacionTransaccionSobre_TransaccionId;
                    this.OperacionTransaccionSobre_CodigoSobre = OperacionTransaccionSobre_CodigoSobre;
                    this.OperacionTransaccionSobre_Fecha = OperacionTransaccionSobre_Fecha;
                    this.ValorRelacionMonedaTipoValor_Id = ValorRelacionMonedaTipoValor_Id;
                    this.ValorRelacionMonedaTipoValor_MonedaId = ValorRelacionMonedaTipoValor_MonedaId;
                    this.ValorRelacionMonedaTipoValor_TipoValorId = ValorRelacionMonedaTipoValor_TipoValorId;
                }
             /// <summary>
             /// Identificador de registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_Id","OperacionTransaccionSobreDetalle_Id")]
             public Int64 OperacionTransaccionSobreDetalle_Id { get; set; }
             /// <summary>
             /// Identificador de sobre
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_SobreId","OperacionTransaccionSobreDetalle_SobreId")]
             public Int64 OperacionTransaccionSobreDetalle_SobreId { get; set; }
             /// <summary>
             /// Identificador del valor indicado por el usuario
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId","OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId")]
             public Int64 OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId { get; set; }
             /// <summary>
             /// Cantidad del valor declarado (RelacionMonedaTipoValorId)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_CantidadDeclarada","OperacionTransaccionSobreDetalle_CantidadDeclarada")]
             public Int64 OperacionTransaccionSobreDetalle_CantidadDeclarada { get; set; }
             /// <summary>
             /// Valor declarado (RelacionMonedaTipoValorId)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_ValorDeclarado","OperacionTransaccionSobreDetalle_ValorDeclarado")]
             public Double OperacionTransaccionSobreDetalle_ValorDeclarado { get; set; }
             /// <summary>
             /// Fecha de alta del registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_Fecha","OperacionTransaccionSobreDetalle_Fecha")]
             public DateTime OperacionTransaccionSobreDetalle_Fecha { get; set; }
             /// <summary>
             /// Identificador de registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_Id","OperacionTransaccionSobre_Id")]
             public Int64 OperacionTransaccionSobre_Id { get; set; }
             /// <summary>
             /// Identificador de la transacción
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_TransaccionId","OperacionTransaccionSobre_TransaccionId")]
             public Int64 OperacionTransaccionSobre_TransaccionId { get; set; }
             /// <summary>
             /// Código alfanumérico que identifica el sobre (Si en la configuración se indica como requerido)
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_CodigoSobre","OperacionTransaccionSobre_CodigoSobre")]
             public String OperacionTransaccionSobre_CodigoSobre { get; set; }
             /// <summary>
             /// Fecha de alta del registro 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_Fecha","OperacionTransaccionSobre_Fecha")]
             public DateTime OperacionTransaccionSobre_Fecha { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorRelacionMonedaTipoValor_Id","ValorRelacionMonedaTipoValor_Id")]
             public Int64 ValorRelacionMonedaTipoValor_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorRelacionMonedaTipoValor_MonedaId","ValorRelacionMonedaTipoValor_MonedaId")]
             public Int64 ValorRelacionMonedaTipoValor_MonedaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorRelacionMonedaTipoValor_TipoValorId","ValorRelacionMonedaTipoValor_TipoValorId")]
             public Int64 ValorRelacionMonedaTipoValor_TipoValorId { get; set; }
				
			} //Class OperacionTransaccionSobreDetalle 
			
} //namespace DepositaryWebApi.Entities.Views.Integracion
//////////////////////////////////////////////////////////////////////////////////
