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
					public const string OperacionTransaccion_FechaModificacion = "OperacionTransaccion_FechaModificacion";
					public const string OperacionTransaccion_UsuarioCreacion = "OperacionTransaccion_UsuarioCreacion";
					public const string OperacionTransaccion_UsuarioModificacion = "OperacionTransaccion_UsuarioModificacion";
					public const string OperacionTipoTransaccion_Id = "OperacionTipoTransaccion_Id";
					public const string OperacionTipoTransaccion_Nombre = "OperacionTipoTransaccion_Nombre";
					public const string OperacionTipoTransaccion_Descripcion = "OperacionTipoTransaccion_Descripcion";
					public const string OperacionTipoTransaccion_FuncionId = "OperacionTipoTransaccion_FuncionId";
					public const string OperacionTipoTransaccion_Habilitado = "OperacionTipoTransaccion_Habilitado";
					public const string OperacionTipoTransaccion_UsuarioCreacion = "OperacionTipoTransaccion_UsuarioCreacion";
					public const string OperacionTipoTransaccion_FechaCreacion = "OperacionTipoTransaccion_FechaCreacion";
					public const string OperacionTipoTransaccion_UsuarioModificacion = "OperacionTipoTransaccion_UsuarioModificacion";
					public const string OperacionTipoTransaccion_FechaModificacion = "OperacionTipoTransaccion_FechaModificacion";
					public const string DispositivoDepositario_Id = "DispositivoDepositario_Id";
					public const string DispositivoDepositario_Nombre = "DispositivoDepositario_Nombre";
					public const string DispositivoDepositario_Descripcion = "DispositivoDepositario_Descripcion";
					public const string DispositivoDepositario_SectorId = "DispositivoDepositario_SectorId";
					public const string DispositivoDepositario_NumeroSerie = "DispositivoDepositario_NumeroSerie";
					public const string DispositivoDepositario_CodigoExterno = "DispositivoDepositario_CodigoExterno";
					public const string DispositivoDepositario_TipoContenedorId = "DispositivoDepositario_TipoContenedorId";
					public const string DispositivoDepositario_ModeloId = "DispositivoDepositario_ModeloId";
					public const string DispositivoDepositario_Habilitado = "DispositivoDepositario_Habilitado";
					public const string DispositivoDepositario_UsuarioCreacion = "DispositivoDepositario_UsuarioCreacion";
					public const string DispositivoDepositario_FechaCreacion = "DispositivoDepositario_FechaCreacion";
					public const string DispositivoDepositario_UsuarioModificacion = "DispositivoDepositario_UsuarioModificacion";
					public const string DispositivoDepositario_FechaModificacion = "DispositivoDepositario_FechaModificacion";
					public const string DirectorioSector_Id = "DirectorioSector_Id";
					public const string DirectorioSector_SucursalId = "DirectorioSector_SucursalId";
					public const string DirectorioSector_Nombre = "DirectorioSector_Nombre";
					public const string DirectorioSector_Descripcion = "DirectorioSector_Descripcion";
					public const string DirectorioSector_Habilitado = "DirectorioSector_Habilitado";
					public const string DirectorioSector_UsuarioCreacion = "DirectorioSector_UsuarioCreacion";
					public const string DirectorioSector_FechaCreacion = "DirectorioSector_FechaCreacion";
					public const string DirectorioSector_UsuarioModificacion = "DirectorioSector_UsuarioModificacion";
					public const string DirectorioSector_FechaModificacion = "DirectorioSector_FechaModificacion";
					public const string DirectorioSector_CodigoExterno = "DirectorioSector_CodigoExterno";
					public const string DirectorioSucursal_Id = "DirectorioSucursal_Id";
					public const string DirectorioSucursal_Nombre = "DirectorioSucursal_Nombre";
					public const string DirectorioSucursal_Descripcion = "DirectorioSucursal_Descripcion";
					public const string DirectorioSucursal_EmpresaId = "DirectorioSucursal_EmpresaId";
					public const string DirectorioSucursal_CodigoExterno = "DirectorioSucursal_CodigoExterno";
					public const string DirectorioSucursal_Direccion = "DirectorioSucursal_Direccion";
					public const string DirectorioSucursal_CodigoPostalId = "DirectorioSucursal_CodigoPostalId";
					public const string DirectorioSucursal_ZonaId = "DirectorioSucursal_ZonaId";
					public const string DirectorioSucursal_Habilitado = "DirectorioSucursal_Habilitado";
					public const string DirectorioSucursal_UsuarioCreacion = "DirectorioSucursal_UsuarioCreacion";
					public const string DirectorioSucursal_FechaCreacion = "DirectorioSucursal_FechaCreacion";
					public const string DirectorioSucursal_UsuarioModificacion = "DirectorioSucursal_UsuarioModificacion";
					public const string DirectorioSucursal_FechaModificacion = "DirectorioSucursal_FechaModificacion";
					public const string ValorMoneda_Id = "ValorMoneda_Id";
					public const string ValorMoneda_Nombre = "ValorMoneda_Nombre";
					public const string ValorMoneda_PaisId = "ValorMoneda_PaisId";
					public const string ValorMoneda_Codigo = "ValorMoneda_Codigo";
					public const string ValorMoneda_Simbolo = "ValorMoneda_Simbolo";
					public const string ValorMoneda_CodigoExterno = "ValorMoneda_CodigoExterno";
					public const string ValorMoneda_Habilitado = "ValorMoneda_Habilitado";
					public const string ValorMoneda_UsuarioCreacion = "ValorMoneda_UsuarioCreacion";
					public const string ValorMoneda_FechaCreacion = "ValorMoneda_FechaCreacion";
					public const string ValorMoneda_UsuarioModificacion = "ValorMoneda_UsuarioModificacion";
					public const string ValorMoneda_FechaModificacion = "ValorMoneda_FechaModificacion";
					public const string SeguridadUsuario_Id = "SeguridadUsuario_Id";
					public const string SeguridadUsuario_EmpresaId = "SeguridadUsuario_EmpresaId";
					public const string SeguridadUsuario_LenguajeId = "SeguridadUsuario_LenguajeId";
					public const string SeguridadUsuario_PerfilId = "SeguridadUsuario_PerfilId";
					public const string SeguridadUsuario_Nombre = "SeguridadUsuario_Nombre";
					public const string SeguridadUsuario_Apellido = "SeguridadUsuario_Apellido";
					public const string SeguridadUsuario_NombreApellido = "SeguridadUsuario_NombreApellido";
					public const string SeguridadUsuario_Documento = "SeguridadUsuario_Documento";
					public const string SeguridadUsuario_Legajo = "SeguridadUsuario_Legajo";
					public const string SeguridadUsuario_Mail = "SeguridadUsuario_Mail";
					public const string SeguridadUsuario_FechaIngreso = "SeguridadUsuario_FechaIngreso";
					public const string SeguridadUsuario_NickName = "SeguridadUsuario_NickName";
					public const string SeguridadUsuario_Password = "SeguridadUsuario_Password";
					public const string SeguridadUsuario_Token = "SeguridadUsuario_Token";
					public const string SeguridadUsuario_Avatar = "SeguridadUsuario_Avatar";
					public const string SeguridadUsuario_FechaUltimoLogin = "SeguridadUsuario_FechaUltimoLogin";
					public const string SeguridadUsuario_DebeCambiarPassword = "SeguridadUsuario_DebeCambiarPassword";
					public const string SeguridadUsuario_Habilitado = "SeguridadUsuario_Habilitado";
					public const string SeguridadUsuario_CantidadLogueosIncorrectos = "SeguridadUsuario_CantidadLogueosIncorrectos";
					public const string SeguridadUsuario_Bloqueado = "SeguridadUsuario_Bloqueado";
					public const string SeguridadUsuario_FechaExpiracion = "SeguridadUsuario_FechaExpiracion";
					public const string SeguridadUsuario_UsuarioCreacion = "SeguridadUsuario_UsuarioCreacion";
					public const string SeguridadUsuario_FechaCreacion = "SeguridadUsuario_FechaCreacion";
					public const string SeguridadUsuario_UsuarioModificacion = "SeguridadUsuario_UsuarioModificacion";
					public const string SeguridadUsuario_FechaModificacion = "SeguridadUsuario_FechaModificacion";
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
					public const string BancaCuenta_Habilitado = "BancaCuenta_Habilitado";
					public const string BancaCuenta_UsuarioCreacion = "BancaCuenta_UsuarioCreacion";
					public const string BancaCuenta_FechaCreacion = "BancaCuenta_FechaCreacion";
					public const string BancaCuenta_UsuarioModificacion = "BancaCuenta_UsuarioModificacion";
					public const string BancaCuenta_FechaModificacion = "BancaCuenta_FechaModificacion";
					public const string BancaCuenta_CodigoExterno = "BancaCuenta_CodigoExterno";
					public const string OperacionContenedor_Id = "OperacionContenedor_Id";
					public const string OperacionContenedor_Nombre = "OperacionContenedor_Nombre";
					public const string OperacionContenedor_DepositarioId = "OperacionContenedor_DepositarioId";
					public const string OperacionContenedor_TipoId = "OperacionContenedor_TipoId";
					public const string OperacionContenedor_Identificador = "OperacionContenedor_Identificador";
					public const string OperacionContenedor_FechaApertura = "OperacionContenedor_FechaApertura";
					public const string OperacionContenedor_FechaCierre = "OperacionContenedor_FechaCierre";
					public const string OperacionContenedor_Habilitado = "OperacionContenedor_Habilitado";
					public const string OperacionContenedor_UsuarioCreacion = "OperacionContenedor_UsuarioCreacion";
					public const string OperacionContenedor_FechaCreacion = "OperacionContenedor_FechaCreacion";
					public const string OperacionContenedor_UsuarioModificacion = "OperacionContenedor_UsuarioModificacion";
					public const string OperacionContenedor_FechaModificacion = "OperacionContenedor_FechaModificacion";
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
					public const string OperacionTurno_UsuarioCreacion = "OperacionTurno_UsuarioCreacion";
					public const string OperacionTurno_FechaCreacion = "OperacionTurno_FechaCreacion";
					public const string OperacionTurno_UsuarioModificacion = "OperacionTurno_UsuarioModificacion";
					public const string OperacionTurno_FechaModificacion = "OperacionTurno_FechaModificacion";
					public const string OperacionTurno_Habilitado = "OperacionTurno_Habilitado";
					public const string OperacionCierreDiario_Id = "OperacionCierreDiario_Id";
					public const string OperacionCierreDiario_Nombre = "OperacionCierreDiario_Nombre";
					public const string OperacionCierreDiario_Fecha = "OperacionCierreDiario_Fecha";
					public const string OperacionCierreDiario_DepositarioId = "OperacionCierreDiario_DepositarioId";
					public const string OperacionCierreDiario_SesionId = "OperacionCierreDiario_SesionId";
					public const string OperacionCierreDiario_CodigoCierre = "OperacionCierreDiario_CodigoCierre";
					public const string OperacionCierreDiario_UsuarioCreacion = "OperacionCierreDiario_UsuarioCreacion";
					public const string OperacionCierreDiario_FechaCreacion = "OperacionCierreDiario_FechaCreacion";
					public const string OperacionCierreDiario_UsuarioModificacion = "OperacionCierreDiario_UsuarioModificacion";
					public const string OperacionCierreDiario_FechaModificacion = "OperacionCierreDiario_FechaModificacion";
					public const string ValorOrigenValor_Id = "ValorOrigenValor_Id";
					public const string ValorOrigenValor_Nombre = "ValorOrigenValor_Nombre";
					public const string ValorOrigenValor_Descripcion = "ValorOrigenValor_Descripcion";
					public const string ValorOrigenValor_EmpresaId = "ValorOrigenValor_EmpresaId";
					public const string ValorOrigenValor_Habilitado = "ValorOrigenValor_Habilitado";
					public const string ValorOrigenValor_UsuarioCreacion = "ValorOrigenValor_UsuarioCreacion";
					public const string ValorOrigenValor_FechaCreacion = "ValorOrigenValor_FechaCreacion";
					public const string ValorOrigenValor_UsuarioModificacion = "ValorOrigenValor_UsuarioModificacion";
					public const string ValorOrigenValor_FechaModificacion = "ValorOrigenValor_FechaModificacion";
					public const string ValorOrigenValor_CodigoExterno = "ValorOrigenValor_CodigoExterno";
					public const string SeguridadUsuario_UsuarioCreacion_Id = "SeguridadUsuario_UsuarioCreacion_Id";
					public const string SeguridadUsuario_UsuarioCreacion_EmpresaId = "SeguridadUsuario_UsuarioCreacion_EmpresaId";
					public const string SeguridadUsuario_UsuarioCreacion_LenguajeId = "SeguridadUsuario_UsuarioCreacion_LenguajeId";
					public const string SeguridadUsuario_UsuarioCreacion_PerfilId = "SeguridadUsuario_UsuarioCreacion_PerfilId";
					public const string SeguridadUsuario_UsuarioCreacion_Nombre = "SeguridadUsuario_UsuarioCreacion_Nombre";
					public const string SeguridadUsuario_UsuarioCreacion_Apellido = "SeguridadUsuario_UsuarioCreacion_Apellido";
					public const string SeguridadUsuario_UsuarioCreacion_NombreApellido = "SeguridadUsuario_UsuarioCreacion_NombreApellido";
					public const string SeguridadUsuario_UsuarioCreacion_Documento = "SeguridadUsuario_UsuarioCreacion_Documento";
					public const string SeguridadUsuario_UsuarioCreacion_Legajo = "SeguridadUsuario_UsuarioCreacion_Legajo";
					public const string SeguridadUsuario_UsuarioCreacion_Mail = "SeguridadUsuario_UsuarioCreacion_Mail";
					public const string SeguridadUsuario_UsuarioCreacion_FechaIngreso = "SeguridadUsuario_UsuarioCreacion_FechaIngreso";
					public const string SeguridadUsuario_UsuarioCreacion_NickName = "SeguridadUsuario_UsuarioCreacion_NickName";
					public const string SeguridadUsuario_UsuarioCreacion_Password = "SeguridadUsuario_UsuarioCreacion_Password";
					public const string SeguridadUsuario_UsuarioCreacion_Token = "SeguridadUsuario_UsuarioCreacion_Token";
					public const string SeguridadUsuario_UsuarioCreacion_Avatar = "SeguridadUsuario_UsuarioCreacion_Avatar";
					public const string SeguridadUsuario_UsuarioCreacion_FechaUltimoLogin = "SeguridadUsuario_UsuarioCreacion_FechaUltimoLogin";
					public const string SeguridadUsuario_UsuarioCreacion_DebeCambiarPassword = "SeguridadUsuario_UsuarioCreacion_DebeCambiarPassword";
					public const string SeguridadUsuario_UsuarioCreacion_Habilitado = "SeguridadUsuario_UsuarioCreacion_Habilitado";
					public const string SeguridadUsuario_UsuarioCreacion_CantidadLogueosIncorrectos = "SeguridadUsuario_UsuarioCreacion_CantidadLogueosIncorrectos";
					public const string SeguridadUsuario_UsuarioCreacion_Bloqueado = "SeguridadUsuario_UsuarioCreacion_Bloqueado";
					public const string SeguridadUsuario_UsuarioCreacion_FechaExpiracion = "SeguridadUsuario_UsuarioCreacion_FechaExpiracion";
					public const string SeguridadUsuario_UsuarioCreacion_UsuarioCreacion = "SeguridadUsuario_UsuarioCreacion_UsuarioCreacion";
					public const string SeguridadUsuario_UsuarioCreacion_FechaCreacion = "SeguridadUsuario_UsuarioCreacion_FechaCreacion";
					public const string SeguridadUsuario_UsuarioCreacion_UsuarioModificacion = "SeguridadUsuario_UsuarioCreacion_UsuarioModificacion";
					public const string SeguridadUsuario_UsuarioCreacion_FechaModificacion = "SeguridadUsuario_UsuarioCreacion_FechaModificacion";
					public const string SeguridadUsuario_UsuarioCreacion_CodigoExterno = "SeguridadUsuario_UsuarioCreacion_CodigoExterno";
					public const string SeguridadUsuario_UsuarioModificacion_Id = "SeguridadUsuario_UsuarioModificacion_Id";
					public const string SeguridadUsuario_UsuarioModificacion_EmpresaId = "SeguridadUsuario_UsuarioModificacion_EmpresaId";
					public const string SeguridadUsuario_UsuarioModificacion_LenguajeId = "SeguridadUsuario_UsuarioModificacion_LenguajeId";
					public const string SeguridadUsuario_UsuarioModificacion_PerfilId = "SeguridadUsuario_UsuarioModificacion_PerfilId";
					public const string SeguridadUsuario_UsuarioModificacion_Nombre = "SeguridadUsuario_UsuarioModificacion_Nombre";
					public const string SeguridadUsuario_UsuarioModificacion_Apellido = "SeguridadUsuario_UsuarioModificacion_Apellido";
					public const string SeguridadUsuario_UsuarioModificacion_NombreApellido = "SeguridadUsuario_UsuarioModificacion_NombreApellido";
					public const string SeguridadUsuario_UsuarioModificacion_Documento = "SeguridadUsuario_UsuarioModificacion_Documento";
					public const string SeguridadUsuario_UsuarioModificacion_Legajo = "SeguridadUsuario_UsuarioModificacion_Legajo";
					public const string SeguridadUsuario_UsuarioModificacion_Mail = "SeguridadUsuario_UsuarioModificacion_Mail";
					public const string SeguridadUsuario_UsuarioModificacion_FechaIngreso = "SeguridadUsuario_UsuarioModificacion_FechaIngreso";
					public const string SeguridadUsuario_UsuarioModificacion_NickName = "SeguridadUsuario_UsuarioModificacion_NickName";
					public const string SeguridadUsuario_UsuarioModificacion_Password = "SeguridadUsuario_UsuarioModificacion_Password";
					public const string SeguridadUsuario_UsuarioModificacion_Token = "SeguridadUsuario_UsuarioModificacion_Token";
					public const string SeguridadUsuario_UsuarioModificacion_Avatar = "SeguridadUsuario_UsuarioModificacion_Avatar";
					public const string SeguridadUsuario_UsuarioModificacion_FechaUltimoLogin = "SeguridadUsuario_UsuarioModificacion_FechaUltimoLogin";
					public const string SeguridadUsuario_UsuarioModificacion_DebeCambiarPassword = "SeguridadUsuario_UsuarioModificacion_DebeCambiarPassword";
					public const string SeguridadUsuario_UsuarioModificacion_Habilitado = "SeguridadUsuario_UsuarioModificacion_Habilitado";
					public const string SeguridadUsuario_UsuarioModificacion_CantidadLogueosIncorrectos = "SeguridadUsuario_UsuarioModificacion_CantidadLogueosIncorrectos";
					public const string SeguridadUsuario_UsuarioModificacion_Bloqueado = "SeguridadUsuario_UsuarioModificacion_Bloqueado";
					public const string SeguridadUsuario_UsuarioModificacion_FechaExpiracion = "SeguridadUsuario_UsuarioModificacion_FechaExpiracion";
					public const string SeguridadUsuario_UsuarioModificacion_UsuarioCreacion = "SeguridadUsuario_UsuarioModificacion_UsuarioCreacion";
					public const string SeguridadUsuario_UsuarioModificacion_FechaCreacion = "SeguridadUsuario_UsuarioModificacion_FechaCreacion";
					public const string SeguridadUsuario_UsuarioModificacion_UsuarioModificacion = "SeguridadUsuario_UsuarioModificacion_UsuarioModificacion";
					public const string SeguridadUsuario_UsuarioModificacion_FechaModificacion = "SeguridadUsuario_UsuarioModificacion_FechaModificacion";
					public const string SeguridadUsuario_UsuarioModificacion_CodigoExterno = "SeguridadUsuario_UsuarioModificacion_CodigoExterno";
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
					OperacionTransaccion_FechaModificacion,
					OperacionTransaccion_UsuarioCreacion,
					OperacionTransaccion_UsuarioModificacion,
					OperacionTipoTransaccion_Id,
					OperacionTipoTransaccion_Nombre,
					OperacionTipoTransaccion_Descripcion,
					OperacionTipoTransaccion_FuncionId,
					OperacionTipoTransaccion_Habilitado,
					OperacionTipoTransaccion_UsuarioCreacion,
					OperacionTipoTransaccion_FechaCreacion,
					OperacionTipoTransaccion_UsuarioModificacion,
					OperacionTipoTransaccion_FechaModificacion,
					DispositivoDepositario_Id,
					DispositivoDepositario_Nombre,
					DispositivoDepositario_Descripcion,
					DispositivoDepositario_SectorId,
					DispositivoDepositario_NumeroSerie,
					DispositivoDepositario_CodigoExterno,
					DispositivoDepositario_TipoContenedorId,
					DispositivoDepositario_ModeloId,
					DispositivoDepositario_Habilitado,
					DispositivoDepositario_UsuarioCreacion,
					DispositivoDepositario_FechaCreacion,
					DispositivoDepositario_UsuarioModificacion,
					DispositivoDepositario_FechaModificacion,
					DirectorioSector_Id,
					DirectorioSector_SucursalId,
					DirectorioSector_Nombre,
					DirectorioSector_Descripcion,
					DirectorioSector_Habilitado,
					DirectorioSector_UsuarioCreacion,
					DirectorioSector_FechaCreacion,
					DirectorioSector_UsuarioModificacion,
					DirectorioSector_FechaModificacion,
					DirectorioSector_CodigoExterno,
					DirectorioSucursal_Id,
					DirectorioSucursal_Nombre,
					DirectorioSucursal_Descripcion,
					DirectorioSucursal_EmpresaId,
					DirectorioSucursal_CodigoExterno,
					DirectorioSucursal_Direccion,
					DirectorioSucursal_CodigoPostalId,
					DirectorioSucursal_ZonaId,
					DirectorioSucursal_Habilitado,
					DirectorioSucursal_UsuarioCreacion,
					DirectorioSucursal_FechaCreacion,
					DirectorioSucursal_UsuarioModificacion,
					DirectorioSucursal_FechaModificacion,
					ValorMoneda_Id,
					ValorMoneda_Nombre,
					ValorMoneda_PaisId,
					ValorMoneda_Codigo,
					ValorMoneda_Simbolo,
					ValorMoneda_CodigoExterno,
					ValorMoneda_Habilitado,
					ValorMoneda_UsuarioCreacion,
					ValorMoneda_FechaCreacion,
					ValorMoneda_UsuarioModificacion,
					ValorMoneda_FechaModificacion,
					SeguridadUsuario_Id,
					SeguridadUsuario_EmpresaId,
					SeguridadUsuario_LenguajeId,
					SeguridadUsuario_PerfilId,
					SeguridadUsuario_Nombre,
					SeguridadUsuario_Apellido,
					SeguridadUsuario_NombreApellido,
					SeguridadUsuario_Documento,
					SeguridadUsuario_Legajo,
					SeguridadUsuario_Mail,
					SeguridadUsuario_FechaIngreso,
					SeguridadUsuario_NickName,
					SeguridadUsuario_Password,
					SeguridadUsuario_Token,
					SeguridadUsuario_Avatar,
					SeguridadUsuario_FechaUltimoLogin,
					SeguridadUsuario_DebeCambiarPassword,
					SeguridadUsuario_Habilitado,
					SeguridadUsuario_CantidadLogueosIncorrectos,
					SeguridadUsuario_Bloqueado,
					SeguridadUsuario_FechaExpiracion,
					SeguridadUsuario_UsuarioCreacion,
					SeguridadUsuario_FechaCreacion,
					SeguridadUsuario_UsuarioModificacion,
					SeguridadUsuario_FechaModificacion,
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
					BancaCuenta_Habilitado,
					BancaCuenta_UsuarioCreacion,
					BancaCuenta_FechaCreacion,
					BancaCuenta_UsuarioModificacion,
					BancaCuenta_FechaModificacion,
					BancaCuenta_CodigoExterno,
					OperacionContenedor_Id,
					OperacionContenedor_Nombre,
					OperacionContenedor_DepositarioId,
					OperacionContenedor_TipoId,
					OperacionContenedor_Identificador,
					OperacionContenedor_FechaApertura,
					OperacionContenedor_FechaCierre,
					OperacionContenedor_Habilitado,
					OperacionContenedor_UsuarioCreacion,
					OperacionContenedor_FechaCreacion,
					OperacionContenedor_UsuarioModificacion,
					OperacionContenedor_FechaModificacion,
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
					OperacionTurno_UsuarioCreacion,
					OperacionTurno_FechaCreacion,
					OperacionTurno_UsuarioModificacion,
					OperacionTurno_FechaModificacion,
					OperacionTurno_Habilitado,
					OperacionCierreDiario_Id,
					OperacionCierreDiario_Nombre,
					OperacionCierreDiario_Fecha,
					OperacionCierreDiario_DepositarioId,
					OperacionCierreDiario_SesionId,
					OperacionCierreDiario_CodigoCierre,
					OperacionCierreDiario_UsuarioCreacion,
					OperacionCierreDiario_FechaCreacion,
					OperacionCierreDiario_UsuarioModificacion,
					OperacionCierreDiario_FechaModificacion,
					ValorOrigenValor_Id,
					ValorOrigenValor_Nombre,
					ValorOrigenValor_Descripcion,
					ValorOrigenValor_EmpresaId,
					ValorOrigenValor_Habilitado,
					ValorOrigenValor_UsuarioCreacion,
					ValorOrigenValor_FechaCreacion,
					ValorOrigenValor_UsuarioModificacion,
					ValorOrigenValor_FechaModificacion,
					ValorOrigenValor_CodigoExterno,
					SeguridadUsuario_UsuarioCreacion_Id,
					SeguridadUsuario_UsuarioCreacion_EmpresaId,
					SeguridadUsuario_UsuarioCreacion_LenguajeId,
					SeguridadUsuario_UsuarioCreacion_PerfilId,
					SeguridadUsuario_UsuarioCreacion_Nombre,
					SeguridadUsuario_UsuarioCreacion_Apellido,
					SeguridadUsuario_UsuarioCreacion_NombreApellido,
					SeguridadUsuario_UsuarioCreacion_Documento,
					SeguridadUsuario_UsuarioCreacion_Legajo,
					SeguridadUsuario_UsuarioCreacion_Mail,
					SeguridadUsuario_UsuarioCreacion_FechaIngreso,
					SeguridadUsuario_UsuarioCreacion_NickName,
					SeguridadUsuario_UsuarioCreacion_Password,
					SeguridadUsuario_UsuarioCreacion_Token,
					SeguridadUsuario_UsuarioCreacion_Avatar,
					SeguridadUsuario_UsuarioCreacion_FechaUltimoLogin,
					SeguridadUsuario_UsuarioCreacion_DebeCambiarPassword,
					SeguridadUsuario_UsuarioCreacion_Habilitado,
					SeguridadUsuario_UsuarioCreacion_CantidadLogueosIncorrectos,
					SeguridadUsuario_UsuarioCreacion_Bloqueado,
					SeguridadUsuario_UsuarioCreacion_FechaExpiracion,
					SeguridadUsuario_UsuarioCreacion_UsuarioCreacion,
					SeguridadUsuario_UsuarioCreacion_FechaCreacion,
					SeguridadUsuario_UsuarioCreacion_UsuarioModificacion,
					SeguridadUsuario_UsuarioCreacion_FechaModificacion,
					SeguridadUsuario_UsuarioCreacion_CodigoExterno,
					SeguridadUsuario_UsuarioModificacion_Id,
					SeguridadUsuario_UsuarioModificacion_EmpresaId,
					SeguridadUsuario_UsuarioModificacion_LenguajeId,
					SeguridadUsuario_UsuarioModificacion_PerfilId,
					SeguridadUsuario_UsuarioModificacion_Nombre,
					SeguridadUsuario_UsuarioModificacion_Apellido,
					SeguridadUsuario_UsuarioModificacion_NombreApellido,
					SeguridadUsuario_UsuarioModificacion_Documento,
					SeguridadUsuario_UsuarioModificacion_Legajo,
					SeguridadUsuario_UsuarioModificacion_Mail,
					SeguridadUsuario_UsuarioModificacion_FechaIngreso,
					SeguridadUsuario_UsuarioModificacion_NickName,
					SeguridadUsuario_UsuarioModificacion_Password,
					SeguridadUsuario_UsuarioModificacion_Token,
					SeguridadUsuario_UsuarioModificacion_Avatar,
					SeguridadUsuario_UsuarioModificacion_FechaUltimoLogin,
					SeguridadUsuario_UsuarioModificacion_DebeCambiarPassword,
					SeguridadUsuario_UsuarioModificacion_Habilitado,
					SeguridadUsuario_UsuarioModificacion_CantidadLogueosIncorrectos,
					SeguridadUsuario_UsuarioModificacion_Bloqueado,
					SeguridadUsuario_UsuarioModificacion_FechaExpiracion,
					SeguridadUsuario_UsuarioModificacion_UsuarioCreacion,
					SeguridadUsuario_UsuarioModificacion_FechaCreacion,
					SeguridadUsuario_UsuarioModificacion_UsuarioModificacion,
					SeguridadUsuario_UsuarioModificacion_FechaModificacion,
					SeguridadUsuario_UsuarioModificacion_CodigoExterno
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
                public  OperacionTransaccion(Int64 OperacionTransaccion_Id,Int64 OperacionTransaccion_TipoId,Int64 OperacionTransaccion_DepositarioId,Int64 OperacionTransaccion_SectorId,Int64 OperacionTransaccion_SucursalId,Int64 OperacionTransaccion_MonedaId,Int64 OperacionTransaccion_UsuarioId,Int64 OperacionTransaccion_CuentaId,Int64 OperacionTransaccion_ContenedorId,Int64 OperacionTransaccion_SesionId,Int64 OperacionTransaccion_TurnoId,Int64 OperacionTransaccion_CierreDiarioId,Double OperacionTransaccion_TotalValidado,Double OperacionTransaccion_TotalAValidar,DateTime OperacionTransaccion_Fecha,Boolean OperacionTransaccion_Finalizada,Boolean OperacionTransaccion_EsDepositoAutomatico,Int64 OperacionTransaccion_OrigenValorId,String OperacionTransaccion_CodigoOperacion,DateTime OperacionTransaccion_FechaCreacion,DateTime OperacionTransaccion_FechaModificacion,Int64 OperacionTransaccion_UsuarioCreacion,Int64 OperacionTransaccion_UsuarioModificacion,Int64 OperacionTipoTransaccion_Id,String OperacionTipoTransaccion_Nombre,String OperacionTipoTransaccion_Descripcion,Int64 OperacionTipoTransaccion_FuncionId,Boolean OperacionTipoTransaccion_Habilitado,Int64 OperacionTipoTransaccion_UsuarioCreacion,DateTime OperacionTipoTransaccion_FechaCreacion,Int64 OperacionTipoTransaccion_UsuarioModificacion,DateTime OperacionTipoTransaccion_FechaModificacion,Int64 DispositivoDepositario_Id,String DispositivoDepositario_Nombre,String DispositivoDepositario_Descripcion,Int64 DispositivoDepositario_SectorId,String DispositivoDepositario_NumeroSerie,String DispositivoDepositario_CodigoExterno,Int64 DispositivoDepositario_TipoContenedorId,Int64 DispositivoDepositario_ModeloId,Boolean DispositivoDepositario_Habilitado,Int64 DispositivoDepositario_UsuarioCreacion,DateTime DispositivoDepositario_FechaCreacion,Int64 DispositivoDepositario_UsuarioModificacion,DateTime DispositivoDepositario_FechaModificacion,Int64 DirectorioSector_Id,Int64 DirectorioSector_SucursalId,String DirectorioSector_Nombre,String DirectorioSector_Descripcion,Boolean DirectorioSector_Habilitado,Int64 DirectorioSector_UsuarioCreacion,DateTime DirectorioSector_FechaCreacion,Int64 DirectorioSector_UsuarioModificacion,DateTime DirectorioSector_FechaModificacion,String DirectorioSector_CodigoExterno,Int64 DirectorioSucursal_Id,String DirectorioSucursal_Nombre,String DirectorioSucursal_Descripcion,Int64 DirectorioSucursal_EmpresaId,String DirectorioSucursal_CodigoExterno,String DirectorioSucursal_Direccion,Int64 DirectorioSucursal_CodigoPostalId,Int64 DirectorioSucursal_ZonaId,Boolean DirectorioSucursal_Habilitado,Int64 DirectorioSucursal_UsuarioCreacion,DateTime DirectorioSucursal_FechaCreacion,Int64 DirectorioSucursal_UsuarioModificacion,DateTime DirectorioSucursal_FechaModificacion,Int64 ValorMoneda_Id,String ValorMoneda_Nombre,Int64 ValorMoneda_PaisId,String ValorMoneda_Codigo,String ValorMoneda_Simbolo,String ValorMoneda_CodigoExterno,Boolean ValorMoneda_Habilitado,Int64 ValorMoneda_UsuarioCreacion,DateTime ValorMoneda_FechaCreacion,Int64 ValorMoneda_UsuarioModificacion,DateTime ValorMoneda_FechaModificacion,Int64 SeguridadUsuario_Id,Int64 SeguridadUsuario_EmpresaId,Int64 SeguridadUsuario_LenguajeId,Int64 SeguridadUsuario_PerfilId,String SeguridadUsuario_Nombre,String SeguridadUsuario_Apellido,String SeguridadUsuario_NombreApellido,String SeguridadUsuario_Documento,String SeguridadUsuario_Legajo,String SeguridadUsuario_Mail,DateTime SeguridadUsuario_FechaIngreso,String SeguridadUsuario_NickName,String SeguridadUsuario_Password,String SeguridadUsuario_Token,String SeguridadUsuario_Avatar,DateTime SeguridadUsuario_FechaUltimoLogin,Boolean SeguridadUsuario_DebeCambiarPassword,Boolean SeguridadUsuario_Habilitado,Int32 SeguridadUsuario_CantidadLogueosIncorrectos,Boolean SeguridadUsuario_Bloqueado,DateTime SeguridadUsuario_FechaExpiracion,Int64 SeguridadUsuario_UsuarioCreacion,DateTime SeguridadUsuario_FechaCreacion,Int64 SeguridadUsuario_UsuarioModificacion,DateTime SeguridadUsuario_FechaModificacion,String SeguridadUsuario_CodigoExterno,Int64 BancaCuenta_Id,Int64 BancaCuenta_TipoId,Int64 BancaCuenta_EmpresaId,String BancaCuenta_Nombre,String BancaCuenta_Numero,String BancaCuenta_Alias,String BancaCuenta_CBU,Int64 BancaCuenta_BancoId,String BancaCuenta_SucursalBancaria,Boolean BancaCuenta_Habilitado,Int64 BancaCuenta_UsuarioCreacion,DateTime BancaCuenta_FechaCreacion,Int64 BancaCuenta_UsuarioModificacion,DateTime BancaCuenta_FechaModificacion,String BancaCuenta_CodigoExterno,Int64 OperacionContenedor_Id,String OperacionContenedor_Nombre,Int64 OperacionContenedor_DepositarioId,Int64 OperacionContenedor_TipoId,String OperacionContenedor_Identificador,DateTime OperacionContenedor_FechaApertura,DateTime OperacionContenedor_FechaCierre,Boolean OperacionContenedor_Habilitado,Int64 OperacionContenedor_UsuarioCreacion,DateTime OperacionContenedor_FechaCreacion,Int64 OperacionContenedor_UsuarioModificacion,DateTime OperacionContenedor_FechaModificacion,Int64 OperacionSesion_Id,Int64 OperacionSesion_DepositarioId,Int64 OperacionSesion_UsuarioId,DateTime OperacionSesion_FechaInicio,DateTime OperacionSesion_FechaCierre,Boolean OperacionSesion_EsCierreAutomatico,Int64 OperacionTurno_Id,Int64 OperacionTurno_TurnoDepositarioId,Int64 OperacionTurno_DepositarioId,Int64 OperacionTurno_SectorId,DateTime OperacionTurno_FechaApertura,DateTime OperacionTurno_FechaCierre,DateTime OperacionTurno_Fecha,Int32 OperacionTurno_Secuencia,Int64 OperacionTurno_CierreDiarioId,String OperacionTurno_Observaciones,String OperacionTurno_CodigoTurno,Int64 OperacionTurno_UsuarioCreacion,DateTime OperacionTurno_FechaCreacion,Int64 OperacionTurno_UsuarioModificacion,DateTime OperacionTurno_FechaModificacion,Boolean OperacionTurno_Habilitado,Int64 OperacionCierreDiario_Id,String OperacionCierreDiario_Nombre,DateTime OperacionCierreDiario_Fecha,Int64 OperacionCierreDiario_DepositarioId,Int64 OperacionCierreDiario_SesionId,String OperacionCierreDiario_CodigoCierre,Int64 OperacionCierreDiario_UsuarioCreacion,DateTime OperacionCierreDiario_FechaCreacion,Int64 OperacionCierreDiario_UsuarioModificacion,DateTime OperacionCierreDiario_FechaModificacion,Int64 ValorOrigenValor_Id,String ValorOrigenValor_Nombre,String ValorOrigenValor_Descripcion,Int64 ValorOrigenValor_EmpresaId,Boolean ValorOrigenValor_Habilitado,Int64 ValorOrigenValor_UsuarioCreacion,DateTime ValorOrigenValor_FechaCreacion,Int64 ValorOrigenValor_UsuarioModificacion,DateTime ValorOrigenValor_FechaModificacion,String ValorOrigenValor_CodigoExterno,Int64 SeguridadUsuario_UsuarioCreacion_Id,Int64 SeguridadUsuario_UsuarioCreacion_EmpresaId,Int64 SeguridadUsuario_UsuarioCreacion_LenguajeId,Int64 SeguridadUsuario_UsuarioCreacion_PerfilId,String SeguridadUsuario_UsuarioCreacion_Nombre,String SeguridadUsuario_UsuarioCreacion_Apellido,String SeguridadUsuario_UsuarioCreacion_NombreApellido,String SeguridadUsuario_UsuarioCreacion_Documento,String SeguridadUsuario_UsuarioCreacion_Legajo,String SeguridadUsuario_UsuarioCreacion_Mail,DateTime SeguridadUsuario_UsuarioCreacion_FechaIngreso,String SeguridadUsuario_UsuarioCreacion_NickName,String SeguridadUsuario_UsuarioCreacion_Password,String SeguridadUsuario_UsuarioCreacion_Token,String SeguridadUsuario_UsuarioCreacion_Avatar,DateTime SeguridadUsuario_UsuarioCreacion_FechaUltimoLogin,Boolean SeguridadUsuario_UsuarioCreacion_DebeCambiarPassword,Boolean SeguridadUsuario_UsuarioCreacion_Habilitado,Int32 SeguridadUsuario_UsuarioCreacion_CantidadLogueosIncorrectos,Boolean SeguridadUsuario_UsuarioCreacion_Bloqueado,DateTime SeguridadUsuario_UsuarioCreacion_FechaExpiracion,Int64 SeguridadUsuario_UsuarioCreacion_UsuarioCreacion,DateTime SeguridadUsuario_UsuarioCreacion_FechaCreacion,Int64 SeguridadUsuario_UsuarioCreacion_UsuarioModificacion,DateTime SeguridadUsuario_UsuarioCreacion_FechaModificacion,String SeguridadUsuario_UsuarioCreacion_CodigoExterno,Int64 SeguridadUsuario_UsuarioModificacion_Id,Int64 SeguridadUsuario_UsuarioModificacion_EmpresaId,Int64 SeguridadUsuario_UsuarioModificacion_LenguajeId,Int64 SeguridadUsuario_UsuarioModificacion_PerfilId,String SeguridadUsuario_UsuarioModificacion_Nombre,String SeguridadUsuario_UsuarioModificacion_Apellido,String SeguridadUsuario_UsuarioModificacion_NombreApellido,String SeguridadUsuario_UsuarioModificacion_Documento,String SeguridadUsuario_UsuarioModificacion_Legajo,String SeguridadUsuario_UsuarioModificacion_Mail,DateTime SeguridadUsuario_UsuarioModificacion_FechaIngreso,String SeguridadUsuario_UsuarioModificacion_NickName,String SeguridadUsuario_UsuarioModificacion_Password,String SeguridadUsuario_UsuarioModificacion_Token,String SeguridadUsuario_UsuarioModificacion_Avatar,DateTime SeguridadUsuario_UsuarioModificacion_FechaUltimoLogin,Boolean SeguridadUsuario_UsuarioModificacion_DebeCambiarPassword,Boolean SeguridadUsuario_UsuarioModificacion_Habilitado,Int32 SeguridadUsuario_UsuarioModificacion_CantidadLogueosIncorrectos,Boolean SeguridadUsuario_UsuarioModificacion_Bloqueado,DateTime SeguridadUsuario_UsuarioModificacion_FechaExpiracion,Int64 SeguridadUsuario_UsuarioModificacion_UsuarioCreacion,DateTime SeguridadUsuario_UsuarioModificacion_FechaCreacion,Int64 SeguridadUsuario_UsuarioModificacion_UsuarioModificacion,DateTime SeguridadUsuario_UsuarioModificacion_FechaModificacion,String SeguridadUsuario_UsuarioModificacion_CodigoExterno)
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
                    this.OperacionTransaccion_FechaModificacion = OperacionTransaccion_FechaModificacion;
                    this.OperacionTransaccion_UsuarioCreacion = OperacionTransaccion_UsuarioCreacion;
                    this.OperacionTransaccion_UsuarioModificacion = OperacionTransaccion_UsuarioModificacion;
                    this.OperacionTipoTransaccion_Id = OperacionTipoTransaccion_Id;
                    this.OperacionTipoTransaccion_Nombre = OperacionTipoTransaccion_Nombre;
                    this.OperacionTipoTransaccion_Descripcion = OperacionTipoTransaccion_Descripcion;
                    this.OperacionTipoTransaccion_FuncionId = OperacionTipoTransaccion_FuncionId;
                    this.OperacionTipoTransaccion_Habilitado = OperacionTipoTransaccion_Habilitado;
                    this.OperacionTipoTransaccion_UsuarioCreacion = OperacionTipoTransaccion_UsuarioCreacion;
                    this.OperacionTipoTransaccion_FechaCreacion = OperacionTipoTransaccion_FechaCreacion;
                    this.OperacionTipoTransaccion_UsuarioModificacion = OperacionTipoTransaccion_UsuarioModificacion;
                    this.OperacionTipoTransaccion_FechaModificacion = OperacionTipoTransaccion_FechaModificacion;
                    this.DispositivoDepositario_Id = DispositivoDepositario_Id;
                    this.DispositivoDepositario_Nombre = DispositivoDepositario_Nombre;
                    this.DispositivoDepositario_Descripcion = DispositivoDepositario_Descripcion;
                    this.DispositivoDepositario_SectorId = DispositivoDepositario_SectorId;
                    this.DispositivoDepositario_NumeroSerie = DispositivoDepositario_NumeroSerie;
                    this.DispositivoDepositario_CodigoExterno = DispositivoDepositario_CodigoExterno;
                    this.DispositivoDepositario_TipoContenedorId = DispositivoDepositario_TipoContenedorId;
                    this.DispositivoDepositario_ModeloId = DispositivoDepositario_ModeloId;
                    this.DispositivoDepositario_Habilitado = DispositivoDepositario_Habilitado;
                    this.DispositivoDepositario_UsuarioCreacion = DispositivoDepositario_UsuarioCreacion;
                    this.DispositivoDepositario_FechaCreacion = DispositivoDepositario_FechaCreacion;
                    this.DispositivoDepositario_UsuarioModificacion = DispositivoDepositario_UsuarioModificacion;
                    this.DispositivoDepositario_FechaModificacion = DispositivoDepositario_FechaModificacion;
                    this.DirectorioSector_Id = DirectorioSector_Id;
                    this.DirectorioSector_SucursalId = DirectorioSector_SucursalId;
                    this.DirectorioSector_Nombre = DirectorioSector_Nombre;
                    this.DirectorioSector_Descripcion = DirectorioSector_Descripcion;
                    this.DirectorioSector_Habilitado = DirectorioSector_Habilitado;
                    this.DirectorioSector_UsuarioCreacion = DirectorioSector_UsuarioCreacion;
                    this.DirectorioSector_FechaCreacion = DirectorioSector_FechaCreacion;
                    this.DirectorioSector_UsuarioModificacion = DirectorioSector_UsuarioModificacion;
                    this.DirectorioSector_FechaModificacion = DirectorioSector_FechaModificacion;
                    this.DirectorioSector_CodigoExterno = DirectorioSector_CodigoExterno;
                    this.DirectorioSucursal_Id = DirectorioSucursal_Id;
                    this.DirectorioSucursal_Nombre = DirectorioSucursal_Nombre;
                    this.DirectorioSucursal_Descripcion = DirectorioSucursal_Descripcion;
                    this.DirectorioSucursal_EmpresaId = DirectorioSucursal_EmpresaId;
                    this.DirectorioSucursal_CodigoExterno = DirectorioSucursal_CodigoExterno;
                    this.DirectorioSucursal_Direccion = DirectorioSucursal_Direccion;
                    this.DirectorioSucursal_CodigoPostalId = DirectorioSucursal_CodigoPostalId;
                    this.DirectorioSucursal_ZonaId = DirectorioSucursal_ZonaId;
                    this.DirectorioSucursal_Habilitado = DirectorioSucursal_Habilitado;
                    this.DirectorioSucursal_UsuarioCreacion = DirectorioSucursal_UsuarioCreacion;
                    this.DirectorioSucursal_FechaCreacion = DirectorioSucursal_FechaCreacion;
                    this.DirectorioSucursal_UsuarioModificacion = DirectorioSucursal_UsuarioModificacion;
                    this.DirectorioSucursal_FechaModificacion = DirectorioSucursal_FechaModificacion;
                    this.ValorMoneda_Id = ValorMoneda_Id;
                    this.ValorMoneda_Nombre = ValorMoneda_Nombre;
                    this.ValorMoneda_PaisId = ValorMoneda_PaisId;
                    this.ValorMoneda_Codigo = ValorMoneda_Codigo;
                    this.ValorMoneda_Simbolo = ValorMoneda_Simbolo;
                    this.ValorMoneda_CodigoExterno = ValorMoneda_CodigoExterno;
                    this.ValorMoneda_Habilitado = ValorMoneda_Habilitado;
                    this.ValorMoneda_UsuarioCreacion = ValorMoneda_UsuarioCreacion;
                    this.ValorMoneda_FechaCreacion = ValorMoneda_FechaCreacion;
                    this.ValorMoneda_UsuarioModificacion = ValorMoneda_UsuarioModificacion;
                    this.ValorMoneda_FechaModificacion = ValorMoneda_FechaModificacion;
                    this.SeguridadUsuario_Id = SeguridadUsuario_Id;
                    this.SeguridadUsuario_EmpresaId = SeguridadUsuario_EmpresaId;
                    this.SeguridadUsuario_LenguajeId = SeguridadUsuario_LenguajeId;
                    this.SeguridadUsuario_PerfilId = SeguridadUsuario_PerfilId;
                    this.SeguridadUsuario_Nombre = SeguridadUsuario_Nombre;
                    this.SeguridadUsuario_Apellido = SeguridadUsuario_Apellido;
                    this.SeguridadUsuario_NombreApellido = SeguridadUsuario_NombreApellido;
                    this.SeguridadUsuario_Documento = SeguridadUsuario_Documento;
                    this.SeguridadUsuario_Legajo = SeguridadUsuario_Legajo;
                    this.SeguridadUsuario_Mail = SeguridadUsuario_Mail;
                    this.SeguridadUsuario_FechaIngreso = SeguridadUsuario_FechaIngreso;
                    this.SeguridadUsuario_NickName = SeguridadUsuario_NickName;
                    this.SeguridadUsuario_Password = SeguridadUsuario_Password;
                    this.SeguridadUsuario_Token = SeguridadUsuario_Token;
                    this.SeguridadUsuario_Avatar = SeguridadUsuario_Avatar;
                    this.SeguridadUsuario_FechaUltimoLogin = SeguridadUsuario_FechaUltimoLogin;
                    this.SeguridadUsuario_DebeCambiarPassword = SeguridadUsuario_DebeCambiarPassword;
                    this.SeguridadUsuario_Habilitado = SeguridadUsuario_Habilitado;
                    this.SeguridadUsuario_CantidadLogueosIncorrectos = SeguridadUsuario_CantidadLogueosIncorrectos;
                    this.SeguridadUsuario_Bloqueado = SeguridadUsuario_Bloqueado;
                    this.SeguridadUsuario_FechaExpiracion = SeguridadUsuario_FechaExpiracion;
                    this.SeguridadUsuario_UsuarioCreacion = SeguridadUsuario_UsuarioCreacion;
                    this.SeguridadUsuario_FechaCreacion = SeguridadUsuario_FechaCreacion;
                    this.SeguridadUsuario_UsuarioModificacion = SeguridadUsuario_UsuarioModificacion;
                    this.SeguridadUsuario_FechaModificacion = SeguridadUsuario_FechaModificacion;
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
                    this.BancaCuenta_Habilitado = BancaCuenta_Habilitado;
                    this.BancaCuenta_UsuarioCreacion = BancaCuenta_UsuarioCreacion;
                    this.BancaCuenta_FechaCreacion = BancaCuenta_FechaCreacion;
                    this.BancaCuenta_UsuarioModificacion = BancaCuenta_UsuarioModificacion;
                    this.BancaCuenta_FechaModificacion = BancaCuenta_FechaModificacion;
                    this.BancaCuenta_CodigoExterno = BancaCuenta_CodigoExterno;
                    this.OperacionContenedor_Id = OperacionContenedor_Id;
                    this.OperacionContenedor_Nombre = OperacionContenedor_Nombre;
                    this.OperacionContenedor_DepositarioId = OperacionContenedor_DepositarioId;
                    this.OperacionContenedor_TipoId = OperacionContenedor_TipoId;
                    this.OperacionContenedor_Identificador = OperacionContenedor_Identificador;
                    this.OperacionContenedor_FechaApertura = OperacionContenedor_FechaApertura;
                    this.OperacionContenedor_FechaCierre = OperacionContenedor_FechaCierre;
                    this.OperacionContenedor_Habilitado = OperacionContenedor_Habilitado;
                    this.OperacionContenedor_UsuarioCreacion = OperacionContenedor_UsuarioCreacion;
                    this.OperacionContenedor_FechaCreacion = OperacionContenedor_FechaCreacion;
                    this.OperacionContenedor_UsuarioModificacion = OperacionContenedor_UsuarioModificacion;
                    this.OperacionContenedor_FechaModificacion = OperacionContenedor_FechaModificacion;
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
                    this.OperacionTurno_UsuarioCreacion = OperacionTurno_UsuarioCreacion;
                    this.OperacionTurno_FechaCreacion = OperacionTurno_FechaCreacion;
                    this.OperacionTurno_UsuarioModificacion = OperacionTurno_UsuarioModificacion;
                    this.OperacionTurno_FechaModificacion = OperacionTurno_FechaModificacion;
                    this.OperacionTurno_Habilitado = OperacionTurno_Habilitado;
                    this.OperacionCierreDiario_Id = OperacionCierreDiario_Id;
                    this.OperacionCierreDiario_Nombre = OperacionCierreDiario_Nombre;
                    this.OperacionCierreDiario_Fecha = OperacionCierreDiario_Fecha;
                    this.OperacionCierreDiario_DepositarioId = OperacionCierreDiario_DepositarioId;
                    this.OperacionCierreDiario_SesionId = OperacionCierreDiario_SesionId;
                    this.OperacionCierreDiario_CodigoCierre = OperacionCierreDiario_CodigoCierre;
                    this.OperacionCierreDiario_UsuarioCreacion = OperacionCierreDiario_UsuarioCreacion;
                    this.OperacionCierreDiario_FechaCreacion = OperacionCierreDiario_FechaCreacion;
                    this.OperacionCierreDiario_UsuarioModificacion = OperacionCierreDiario_UsuarioModificacion;
                    this.OperacionCierreDiario_FechaModificacion = OperacionCierreDiario_FechaModificacion;
                    this.ValorOrigenValor_Id = ValorOrigenValor_Id;
                    this.ValorOrigenValor_Nombre = ValorOrigenValor_Nombre;
                    this.ValorOrigenValor_Descripcion = ValorOrigenValor_Descripcion;
                    this.ValorOrigenValor_EmpresaId = ValorOrigenValor_EmpresaId;
                    this.ValorOrigenValor_Habilitado = ValorOrigenValor_Habilitado;
                    this.ValorOrigenValor_UsuarioCreacion = ValorOrigenValor_UsuarioCreacion;
                    this.ValorOrigenValor_FechaCreacion = ValorOrigenValor_FechaCreacion;
                    this.ValorOrigenValor_UsuarioModificacion = ValorOrigenValor_UsuarioModificacion;
                    this.ValorOrigenValor_FechaModificacion = ValorOrigenValor_FechaModificacion;
                    this.ValorOrigenValor_CodigoExterno = ValorOrigenValor_CodigoExterno;
                    this.SeguridadUsuario_UsuarioCreacion_Id = SeguridadUsuario_UsuarioCreacion_Id;
                    this.SeguridadUsuario_UsuarioCreacion_EmpresaId = SeguridadUsuario_UsuarioCreacion_EmpresaId;
                    this.SeguridadUsuario_UsuarioCreacion_LenguajeId = SeguridadUsuario_UsuarioCreacion_LenguajeId;
                    this.SeguridadUsuario_UsuarioCreacion_PerfilId = SeguridadUsuario_UsuarioCreacion_PerfilId;
                    this.SeguridadUsuario_UsuarioCreacion_Nombre = SeguridadUsuario_UsuarioCreacion_Nombre;
                    this.SeguridadUsuario_UsuarioCreacion_Apellido = SeguridadUsuario_UsuarioCreacion_Apellido;
                    this.SeguridadUsuario_UsuarioCreacion_NombreApellido = SeguridadUsuario_UsuarioCreacion_NombreApellido;
                    this.SeguridadUsuario_UsuarioCreacion_Documento = SeguridadUsuario_UsuarioCreacion_Documento;
                    this.SeguridadUsuario_UsuarioCreacion_Legajo = SeguridadUsuario_UsuarioCreacion_Legajo;
                    this.SeguridadUsuario_UsuarioCreacion_Mail = SeguridadUsuario_UsuarioCreacion_Mail;
                    this.SeguridadUsuario_UsuarioCreacion_FechaIngreso = SeguridadUsuario_UsuarioCreacion_FechaIngreso;
                    this.SeguridadUsuario_UsuarioCreacion_NickName = SeguridadUsuario_UsuarioCreacion_NickName;
                    this.SeguridadUsuario_UsuarioCreacion_Password = SeguridadUsuario_UsuarioCreacion_Password;
                    this.SeguridadUsuario_UsuarioCreacion_Token = SeguridadUsuario_UsuarioCreacion_Token;
                    this.SeguridadUsuario_UsuarioCreacion_Avatar = SeguridadUsuario_UsuarioCreacion_Avatar;
                    this.SeguridadUsuario_UsuarioCreacion_FechaUltimoLogin = SeguridadUsuario_UsuarioCreacion_FechaUltimoLogin;
                    this.SeguridadUsuario_UsuarioCreacion_DebeCambiarPassword = SeguridadUsuario_UsuarioCreacion_DebeCambiarPassword;
                    this.SeguridadUsuario_UsuarioCreacion_Habilitado = SeguridadUsuario_UsuarioCreacion_Habilitado;
                    this.SeguridadUsuario_UsuarioCreacion_CantidadLogueosIncorrectos = SeguridadUsuario_UsuarioCreacion_CantidadLogueosIncorrectos;
                    this.SeguridadUsuario_UsuarioCreacion_Bloqueado = SeguridadUsuario_UsuarioCreacion_Bloqueado;
                    this.SeguridadUsuario_UsuarioCreacion_FechaExpiracion = SeguridadUsuario_UsuarioCreacion_FechaExpiracion;
                    this.SeguridadUsuario_UsuarioCreacion_UsuarioCreacion = SeguridadUsuario_UsuarioCreacion_UsuarioCreacion;
                    this.SeguridadUsuario_UsuarioCreacion_FechaCreacion = SeguridadUsuario_UsuarioCreacion_FechaCreacion;
                    this.SeguridadUsuario_UsuarioCreacion_UsuarioModificacion = SeguridadUsuario_UsuarioCreacion_UsuarioModificacion;
                    this.SeguridadUsuario_UsuarioCreacion_FechaModificacion = SeguridadUsuario_UsuarioCreacion_FechaModificacion;
                    this.SeguridadUsuario_UsuarioCreacion_CodigoExterno = SeguridadUsuario_UsuarioCreacion_CodigoExterno;
                    this.SeguridadUsuario_UsuarioModificacion_Id = SeguridadUsuario_UsuarioModificacion_Id;
                    this.SeguridadUsuario_UsuarioModificacion_EmpresaId = SeguridadUsuario_UsuarioModificacion_EmpresaId;
                    this.SeguridadUsuario_UsuarioModificacion_LenguajeId = SeguridadUsuario_UsuarioModificacion_LenguajeId;
                    this.SeguridadUsuario_UsuarioModificacion_PerfilId = SeguridadUsuario_UsuarioModificacion_PerfilId;
                    this.SeguridadUsuario_UsuarioModificacion_Nombre = SeguridadUsuario_UsuarioModificacion_Nombre;
                    this.SeguridadUsuario_UsuarioModificacion_Apellido = SeguridadUsuario_UsuarioModificacion_Apellido;
                    this.SeguridadUsuario_UsuarioModificacion_NombreApellido = SeguridadUsuario_UsuarioModificacion_NombreApellido;
                    this.SeguridadUsuario_UsuarioModificacion_Documento = SeguridadUsuario_UsuarioModificacion_Documento;
                    this.SeguridadUsuario_UsuarioModificacion_Legajo = SeguridadUsuario_UsuarioModificacion_Legajo;
                    this.SeguridadUsuario_UsuarioModificacion_Mail = SeguridadUsuario_UsuarioModificacion_Mail;
                    this.SeguridadUsuario_UsuarioModificacion_FechaIngreso = SeguridadUsuario_UsuarioModificacion_FechaIngreso;
                    this.SeguridadUsuario_UsuarioModificacion_NickName = SeguridadUsuario_UsuarioModificacion_NickName;
                    this.SeguridadUsuario_UsuarioModificacion_Password = SeguridadUsuario_UsuarioModificacion_Password;
                    this.SeguridadUsuario_UsuarioModificacion_Token = SeguridadUsuario_UsuarioModificacion_Token;
                    this.SeguridadUsuario_UsuarioModificacion_Avatar = SeguridadUsuario_UsuarioModificacion_Avatar;
                    this.SeguridadUsuario_UsuarioModificacion_FechaUltimoLogin = SeguridadUsuario_UsuarioModificacion_FechaUltimoLogin;
                    this.SeguridadUsuario_UsuarioModificacion_DebeCambiarPassword = SeguridadUsuario_UsuarioModificacion_DebeCambiarPassword;
                    this.SeguridadUsuario_UsuarioModificacion_Habilitado = SeguridadUsuario_UsuarioModificacion_Habilitado;
                    this.SeguridadUsuario_UsuarioModificacion_CantidadLogueosIncorrectos = SeguridadUsuario_UsuarioModificacion_CantidadLogueosIncorrectos;
                    this.SeguridadUsuario_UsuarioModificacion_Bloqueado = SeguridadUsuario_UsuarioModificacion_Bloqueado;
                    this.SeguridadUsuario_UsuarioModificacion_FechaExpiracion = SeguridadUsuario_UsuarioModificacion_FechaExpiracion;
                    this.SeguridadUsuario_UsuarioModificacion_UsuarioCreacion = SeguridadUsuario_UsuarioModificacion_UsuarioCreacion;
                    this.SeguridadUsuario_UsuarioModificacion_FechaCreacion = SeguridadUsuario_UsuarioModificacion_FechaCreacion;
                    this.SeguridadUsuario_UsuarioModificacion_UsuarioModificacion = SeguridadUsuario_UsuarioModificacion_UsuarioModificacion;
                    this.SeguridadUsuario_UsuarioModificacion_FechaModificacion = SeguridadUsuario_UsuarioModificacion_FechaModificacion;
                    this.SeguridadUsuario_UsuarioModificacion_CodigoExterno = SeguridadUsuario_UsuarioModificacion_CodigoExterno;
                }
             /// <summary>
             /// Id de la Transaccion- TEST
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Id","OperacionTransaccion_Id")]
             public Int64 OperacionTransaccion_Id { get; set; }
             /// <summary>
             /// Tipo de Transaccion -TEST
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TipoId","OperacionTransaccion_TipoId")]
             public Int64 OperacionTransaccion_TipoId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_DepositarioId","OperacionTransaccion_DepositarioId")]
             public Int64 OperacionTransaccion_DepositarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SectorId","OperacionTransaccion_SectorId")]
             public Int64 OperacionTransaccion_SectorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SucursalId","OperacionTransaccion_SucursalId")]
             public Int64 OperacionTransaccion_SucursalId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_MonedaId","OperacionTransaccion_MonedaId")]
             public Int64 OperacionTransaccion_MonedaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioId","OperacionTransaccion_UsuarioId")]
             public Int64 OperacionTransaccion_UsuarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CuentaId","OperacionTransaccion_CuentaId")]
             public Int64 OperacionTransaccion_CuentaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_ContenedorId","OperacionTransaccion_ContenedorId")]
             public Int64 OperacionTransaccion_ContenedorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SesionId","OperacionTransaccion_SesionId")]
             public Int64 OperacionTransaccion_SesionId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TurnoId","OperacionTransaccion_TurnoId")]
             public Int64 OperacionTransaccion_TurnoId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CierreDiarioId","OperacionTransaccion_CierreDiarioId")]
             public Int64 OperacionTransaccion_CierreDiarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalValidado","OperacionTransaccion_TotalValidado")]
             public Double OperacionTransaccion_TotalValidado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalAValidar","OperacionTransaccion_TotalAValidar")]
             public Double OperacionTransaccion_TotalAValidar { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Fecha","OperacionTransaccion_Fecha")]
             public DateTime OperacionTransaccion_Fecha { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Finalizada","OperacionTransaccion_Finalizada")]
             public Boolean OperacionTransaccion_Finalizada { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_EsDepositoAutomatico","OperacionTransaccion_EsDepositoAutomatico")]
             public Boolean OperacionTransaccion_EsDepositoAutomatico { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_OrigenValorId","OperacionTransaccion_OrigenValorId")]
             public Int64 OperacionTransaccion_OrigenValorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CodigoOperacion","OperacionTransaccion_CodigoOperacion")]
             public String OperacionTransaccion_CodigoOperacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_FechaCreacion","OperacionTransaccion_FechaCreacion")]
             public DateTime OperacionTransaccion_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_FechaModificacion","OperacionTransaccion_FechaModificacion")]
             public DateTime OperacionTransaccion_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioCreacion","OperacionTransaccion_UsuarioCreacion")]
             public Int64 OperacionTransaccion_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioModificacion","OperacionTransaccion_UsuarioModificacion")]
             public Int64 OperacionTransaccion_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_Id","OperacionTipoTransaccion_Id")]
             public Int64 OperacionTipoTransaccion_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_Nombre","OperacionTipoTransaccion_Nombre")]
             public String OperacionTipoTransaccion_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_Descripcion","OperacionTipoTransaccion_Descripcion")]
             public String OperacionTipoTransaccion_Descripcion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_FuncionId","OperacionTipoTransaccion_FuncionId")]
             public Int64 OperacionTipoTransaccion_FuncionId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_Habilitado","OperacionTipoTransaccion_Habilitado")]
             public Boolean OperacionTipoTransaccion_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_UsuarioCreacion","OperacionTipoTransaccion_UsuarioCreacion")]
             public Int64 OperacionTipoTransaccion_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_FechaCreacion","OperacionTipoTransaccion_FechaCreacion")]
             public DateTime OperacionTipoTransaccion_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_UsuarioModificacion","OperacionTipoTransaccion_UsuarioModificacion")]
             public Int64 OperacionTipoTransaccion_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTipoTransaccion_FechaModificacion","OperacionTipoTransaccion_FechaModificacion")]
             public DateTime OperacionTipoTransaccion_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_Id","DispositivoDepositario_Id")]
             public Int64 DispositivoDepositario_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_Nombre","DispositivoDepositario_Nombre")]
             public String DispositivoDepositario_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_Descripcion","DispositivoDepositario_Descripcion")]
             public String DispositivoDepositario_Descripcion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_SectorId","DispositivoDepositario_SectorId")]
             public Int64 DispositivoDepositario_SectorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_NumeroSerie","DispositivoDepositario_NumeroSerie")]
             public String DispositivoDepositario_NumeroSerie { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_CodigoExterno","DispositivoDepositario_CodigoExterno")]
             public String DispositivoDepositario_CodigoExterno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_TipoContenedorId","DispositivoDepositario_TipoContenedorId")]
             public Int64 DispositivoDepositario_TipoContenedorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_ModeloId","DispositivoDepositario_ModeloId")]
             public Int64 DispositivoDepositario_ModeloId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_Habilitado","DispositivoDepositario_Habilitado")]
             public Boolean DispositivoDepositario_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_UsuarioCreacion","DispositivoDepositario_UsuarioCreacion")]
             public Int64 DispositivoDepositario_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_FechaCreacion","DispositivoDepositario_FechaCreacion")]
             public DateTime DispositivoDepositario_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_UsuarioModificacion","DispositivoDepositario_UsuarioModificacion")]
             public Int64 DispositivoDepositario_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DispositivoDepositario_FechaModificacion","DispositivoDepositario_FechaModificacion")]
             public DateTime DispositivoDepositario_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_Id","DirectorioSector_Id")]
             public Int64 DirectorioSector_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_SucursalId","DirectorioSector_SucursalId")]
             public Int64 DirectorioSector_SucursalId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_Nombre","DirectorioSector_Nombre")]
             public String DirectorioSector_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_Descripcion","DirectorioSector_Descripcion")]
             public String DirectorioSector_Descripcion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_Habilitado","DirectorioSector_Habilitado")]
             public Boolean DirectorioSector_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_UsuarioCreacion","DirectorioSector_UsuarioCreacion")]
             public Int64 DirectorioSector_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_FechaCreacion","DirectorioSector_FechaCreacion")]
             public DateTime DirectorioSector_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_UsuarioModificacion","DirectorioSector_UsuarioModificacion")]
             public Int64 DirectorioSector_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_FechaModificacion","DirectorioSector_FechaModificacion")]
             public DateTime DirectorioSector_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSector_CodigoExterno","DirectorioSector_CodigoExterno")]
             public String DirectorioSector_CodigoExterno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_Id","DirectorioSucursal_Id")]
             public Int64 DirectorioSucursal_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_Nombre","DirectorioSucursal_Nombre")]
             public String DirectorioSucursal_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_Descripcion","DirectorioSucursal_Descripcion")]
             public String DirectorioSucursal_Descripcion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_EmpresaId","DirectorioSucursal_EmpresaId")]
             public Int64 DirectorioSucursal_EmpresaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_CodigoExterno","DirectorioSucursal_CodigoExterno")]
             public String DirectorioSucursal_CodigoExterno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_Direccion","DirectorioSucursal_Direccion")]
             public String DirectorioSucursal_Direccion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_CodigoPostalId","DirectorioSucursal_CodigoPostalId")]
             public Int64 DirectorioSucursal_CodigoPostalId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_ZonaId","DirectorioSucursal_ZonaId")]
             public Int64 DirectorioSucursal_ZonaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_Habilitado","DirectorioSucursal_Habilitado")]
             public Boolean DirectorioSucursal_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_UsuarioCreacion","DirectorioSucursal_UsuarioCreacion")]
             public Int64 DirectorioSucursal_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_FechaCreacion","DirectorioSucursal_FechaCreacion")]
             public DateTime DirectorioSucursal_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_UsuarioModificacion","DirectorioSucursal_UsuarioModificacion")]
             public Int64 DirectorioSucursal_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("DirectorioSucursal_FechaModificacion","DirectorioSucursal_FechaModificacion")]
             public DateTime DirectorioSucursal_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_Id","ValorMoneda_Id")]
             public Int64 ValorMoneda_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_Nombre","ValorMoneda_Nombre")]
             public String ValorMoneda_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_PaisId","ValorMoneda_PaisId")]
             public Int64 ValorMoneda_PaisId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_Codigo","ValorMoneda_Codigo")]
             public String ValorMoneda_Codigo { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_Simbolo","ValorMoneda_Simbolo")]
             public String ValorMoneda_Simbolo { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_CodigoExterno","ValorMoneda_CodigoExterno")]
             public String ValorMoneda_CodigoExterno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_Habilitado","ValorMoneda_Habilitado")]
             public Boolean ValorMoneda_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_UsuarioCreacion","ValorMoneda_UsuarioCreacion")]
             public Int64 ValorMoneda_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_FechaCreacion","ValorMoneda_FechaCreacion")]
             public DateTime ValorMoneda_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_UsuarioModificacion","ValorMoneda_UsuarioModificacion")]
             public Int64 ValorMoneda_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorMoneda_FechaModificacion","ValorMoneda_FechaModificacion")]
             public DateTime ValorMoneda_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Id","SeguridadUsuario_Id")]
             public Int64 SeguridadUsuario_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_EmpresaId","SeguridadUsuario_EmpresaId")]
             public Int64 SeguridadUsuario_EmpresaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_LenguajeId","SeguridadUsuario_LenguajeId")]
             public Int64 SeguridadUsuario_LenguajeId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_PerfilId","SeguridadUsuario_PerfilId")]
             public Int64 SeguridadUsuario_PerfilId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Nombre","SeguridadUsuario_Nombre")]
             public String SeguridadUsuario_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Apellido","SeguridadUsuario_Apellido")]
             public String SeguridadUsuario_Apellido { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_NombreApellido","SeguridadUsuario_NombreApellido")]
             public String SeguridadUsuario_NombreApellido { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Documento","SeguridadUsuario_Documento")]
             public String SeguridadUsuario_Documento { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Legajo","SeguridadUsuario_Legajo")]
             public String SeguridadUsuario_Legajo { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Mail","SeguridadUsuario_Mail")]
             public String SeguridadUsuario_Mail { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_FechaIngreso","SeguridadUsuario_FechaIngreso")]
             public DateTime SeguridadUsuario_FechaIngreso { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_NickName","SeguridadUsuario_NickName")]
             public String SeguridadUsuario_NickName { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Password","SeguridadUsuario_Password")]
             public String SeguridadUsuario_Password { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Token","SeguridadUsuario_Token")]
             public String SeguridadUsuario_Token { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Avatar","SeguridadUsuario_Avatar")]
             public String SeguridadUsuario_Avatar { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_FechaUltimoLogin","SeguridadUsuario_FechaUltimoLogin")]
             public DateTime SeguridadUsuario_FechaUltimoLogin { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_DebeCambiarPassword","SeguridadUsuario_DebeCambiarPassword")]
             public Boolean SeguridadUsuario_DebeCambiarPassword { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Habilitado","SeguridadUsuario_Habilitado")]
             public Boolean SeguridadUsuario_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_CantidadLogueosIncorrectos","SeguridadUsuario_CantidadLogueosIncorrectos")]
             public Int32 SeguridadUsuario_CantidadLogueosIncorrectos { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_Bloqueado","SeguridadUsuario_Bloqueado")]
             public Boolean SeguridadUsuario_Bloqueado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_FechaExpiracion","SeguridadUsuario_FechaExpiracion")]
             public DateTime SeguridadUsuario_FechaExpiracion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion","SeguridadUsuario_UsuarioCreacion")]
             public Int64 SeguridadUsuario_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_FechaCreacion","SeguridadUsuario_FechaCreacion")]
             public DateTime SeguridadUsuario_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion","SeguridadUsuario_UsuarioModificacion")]
             public Int64 SeguridadUsuario_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_FechaModificacion","SeguridadUsuario_FechaModificacion")]
             public DateTime SeguridadUsuario_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_CodigoExterno","SeguridadUsuario_CodigoExterno")]
             public String SeguridadUsuario_CodigoExterno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_Id","BancaCuenta_Id")]
             public Int64 BancaCuenta_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_TipoId","BancaCuenta_TipoId")]
             public Int64 BancaCuenta_TipoId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_EmpresaId","BancaCuenta_EmpresaId")]
             public Int64 BancaCuenta_EmpresaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_Nombre","BancaCuenta_Nombre")]
             public String BancaCuenta_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_Numero","BancaCuenta_Numero")]
             public String BancaCuenta_Numero { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_Alias","BancaCuenta_Alias")]
             public String BancaCuenta_Alias { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_CBU","BancaCuenta_CBU")]
             public String BancaCuenta_CBU { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_BancoId","BancaCuenta_BancoId")]
             public Int64 BancaCuenta_BancoId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_SucursalBancaria","BancaCuenta_SucursalBancaria")]
             public String BancaCuenta_SucursalBancaria { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_Habilitado","BancaCuenta_Habilitado")]
             public Boolean BancaCuenta_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_UsuarioCreacion","BancaCuenta_UsuarioCreacion")]
             public Int64 BancaCuenta_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_FechaCreacion","BancaCuenta_FechaCreacion")]
             public DateTime BancaCuenta_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_UsuarioModificacion","BancaCuenta_UsuarioModificacion")]
             public Int64 BancaCuenta_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_FechaModificacion","BancaCuenta_FechaModificacion")]
             public DateTime BancaCuenta_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("BancaCuenta_CodigoExterno","BancaCuenta_CodigoExterno")]
             public String BancaCuenta_CodigoExterno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_Id","OperacionContenedor_Id")]
             public Int64 OperacionContenedor_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_Nombre","OperacionContenedor_Nombre")]
             public String OperacionContenedor_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_DepositarioId","OperacionContenedor_DepositarioId")]
             public Int64 OperacionContenedor_DepositarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_TipoId","OperacionContenedor_TipoId")]
             public Int64 OperacionContenedor_TipoId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_Identificador","OperacionContenedor_Identificador")]
             public String OperacionContenedor_Identificador { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_FechaApertura","OperacionContenedor_FechaApertura")]
             public DateTime OperacionContenedor_FechaApertura { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_FechaCierre","OperacionContenedor_FechaCierre")]
             public DateTime OperacionContenedor_FechaCierre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_Habilitado","OperacionContenedor_Habilitado")]
             public Boolean OperacionContenedor_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_UsuarioCreacion","OperacionContenedor_UsuarioCreacion")]
             public Int64 OperacionContenedor_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_FechaCreacion","OperacionContenedor_FechaCreacion")]
             public DateTime OperacionContenedor_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_UsuarioModificacion","OperacionContenedor_UsuarioModificacion")]
             public Int64 OperacionContenedor_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionContenedor_FechaModificacion","OperacionContenedor_FechaModificacion")]
             public DateTime OperacionContenedor_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_Id","OperacionSesion_Id")]
             public Int64 OperacionSesion_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_DepositarioId","OperacionSesion_DepositarioId")]
             public Int64 OperacionSesion_DepositarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_UsuarioId","OperacionSesion_UsuarioId")]
             public Int64 OperacionSesion_UsuarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_FechaInicio","OperacionSesion_FechaInicio")]
             public DateTime OperacionSesion_FechaInicio { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_FechaCierre","OperacionSesion_FechaCierre")]
             public DateTime OperacionSesion_FechaCierre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionSesion_EsCierreAutomatico","OperacionSesion_EsCierreAutomatico")]
             public Boolean OperacionSesion_EsCierreAutomatico { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_Id","OperacionTurno_Id")]
             public Int64 OperacionTurno_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_TurnoDepositarioId","OperacionTurno_TurnoDepositarioId")]
             public Int64 OperacionTurno_TurnoDepositarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_DepositarioId","OperacionTurno_DepositarioId")]
             public Int64 OperacionTurno_DepositarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_SectorId","OperacionTurno_SectorId")]
             public Int64 OperacionTurno_SectorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_FechaApertura","OperacionTurno_FechaApertura")]
             public DateTime OperacionTurno_FechaApertura { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_FechaCierre","OperacionTurno_FechaCierre")]
             public DateTime OperacionTurno_FechaCierre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_Fecha","OperacionTurno_Fecha")]
             public DateTime OperacionTurno_Fecha { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_Secuencia","OperacionTurno_Secuencia")]
             public Int32 OperacionTurno_Secuencia { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_CierreDiarioId","OperacionTurno_CierreDiarioId")]
             public Int64 OperacionTurno_CierreDiarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_Observaciones","OperacionTurno_Observaciones")]
             public String OperacionTurno_Observaciones { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_CodigoTurno","OperacionTurno_CodigoTurno")]
             public String OperacionTurno_CodigoTurno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_UsuarioCreacion","OperacionTurno_UsuarioCreacion")]
             public Int64 OperacionTurno_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_FechaCreacion","OperacionTurno_FechaCreacion")]
             public DateTime OperacionTurno_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_UsuarioModificacion","OperacionTurno_UsuarioModificacion")]
             public Int64 OperacionTurno_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_FechaModificacion","OperacionTurno_FechaModificacion")]
             public DateTime OperacionTurno_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTurno_Habilitado","OperacionTurno_Habilitado")]
             public Boolean OperacionTurno_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_Id","OperacionCierreDiario_Id")]
             public Int64 OperacionCierreDiario_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_Nombre","OperacionCierreDiario_Nombre")]
             public String OperacionCierreDiario_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_Fecha","OperacionCierreDiario_Fecha")]
             public DateTime OperacionCierreDiario_Fecha { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_DepositarioId","OperacionCierreDiario_DepositarioId")]
             public Int64 OperacionCierreDiario_DepositarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_SesionId","OperacionCierreDiario_SesionId")]
             public Int64 OperacionCierreDiario_SesionId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_CodigoCierre","OperacionCierreDiario_CodigoCierre")]
             public String OperacionCierreDiario_CodigoCierre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_UsuarioCreacion","OperacionCierreDiario_UsuarioCreacion")]
             public Int64 OperacionCierreDiario_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_FechaCreacion","OperacionCierreDiario_FechaCreacion")]
             public DateTime OperacionCierreDiario_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_UsuarioModificacion","OperacionCierreDiario_UsuarioModificacion")]
             public Int64 OperacionCierreDiario_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionCierreDiario_FechaModificacion","OperacionCierreDiario_FechaModificacion")]
             public DateTime OperacionCierreDiario_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_Id","ValorOrigenValor_Id")]
             public Int64 ValorOrigenValor_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_Nombre","ValorOrigenValor_Nombre")]
             public String ValorOrigenValor_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_Descripcion","ValorOrigenValor_Descripcion")]
             public String ValorOrigenValor_Descripcion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_EmpresaId","ValorOrigenValor_EmpresaId")]
             public Int64 ValorOrigenValor_EmpresaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_Habilitado","ValorOrigenValor_Habilitado")]
             public Boolean ValorOrigenValor_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_UsuarioCreacion","ValorOrigenValor_UsuarioCreacion")]
             public Int64 ValorOrigenValor_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_FechaCreacion","ValorOrigenValor_FechaCreacion")]
             public DateTime ValorOrigenValor_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_UsuarioModificacion","ValorOrigenValor_UsuarioModificacion")]
             public Int64 ValorOrigenValor_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_FechaModificacion","ValorOrigenValor_FechaModificacion")]
             public DateTime ValorOrigenValor_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorOrigenValor_CodigoExterno","ValorOrigenValor_CodigoExterno")]
             public String ValorOrigenValor_CodigoExterno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Id","SeguridadUsuario_UsuarioCreacion_Id")]
             public Int64 SeguridadUsuario_UsuarioCreacion_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_EmpresaId","SeguridadUsuario_UsuarioCreacion_EmpresaId")]
             public Int64 SeguridadUsuario_UsuarioCreacion_EmpresaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_LenguajeId","SeguridadUsuario_UsuarioCreacion_LenguajeId")]
             public Int64 SeguridadUsuario_UsuarioCreacion_LenguajeId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_PerfilId","SeguridadUsuario_UsuarioCreacion_PerfilId")]
             public Int64 SeguridadUsuario_UsuarioCreacion_PerfilId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Nombre","SeguridadUsuario_UsuarioCreacion_Nombre")]
             public String SeguridadUsuario_UsuarioCreacion_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Apellido","SeguridadUsuario_UsuarioCreacion_Apellido")]
             public String SeguridadUsuario_UsuarioCreacion_Apellido { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_NombreApellido","SeguridadUsuario_UsuarioCreacion_NombreApellido")]
             public String SeguridadUsuario_UsuarioCreacion_NombreApellido { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Documento","SeguridadUsuario_UsuarioCreacion_Documento")]
             public String SeguridadUsuario_UsuarioCreacion_Documento { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Legajo","SeguridadUsuario_UsuarioCreacion_Legajo")]
             public String SeguridadUsuario_UsuarioCreacion_Legajo { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Mail","SeguridadUsuario_UsuarioCreacion_Mail")]
             public String SeguridadUsuario_UsuarioCreacion_Mail { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_FechaIngreso","SeguridadUsuario_UsuarioCreacion_FechaIngreso")]
             public DateTime SeguridadUsuario_UsuarioCreacion_FechaIngreso { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_NickName","SeguridadUsuario_UsuarioCreacion_NickName")]
             public String SeguridadUsuario_UsuarioCreacion_NickName { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Password","SeguridadUsuario_UsuarioCreacion_Password")]
             public String SeguridadUsuario_UsuarioCreacion_Password { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Token","SeguridadUsuario_UsuarioCreacion_Token")]
             public String SeguridadUsuario_UsuarioCreacion_Token { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Avatar","SeguridadUsuario_UsuarioCreacion_Avatar")]
             public String SeguridadUsuario_UsuarioCreacion_Avatar { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_FechaUltimoLogin","SeguridadUsuario_UsuarioCreacion_FechaUltimoLogin")]
             public DateTime SeguridadUsuario_UsuarioCreacion_FechaUltimoLogin { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_DebeCambiarPassword","SeguridadUsuario_UsuarioCreacion_DebeCambiarPassword")]
             public Boolean SeguridadUsuario_UsuarioCreacion_DebeCambiarPassword { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Habilitado","SeguridadUsuario_UsuarioCreacion_Habilitado")]
             public Boolean SeguridadUsuario_UsuarioCreacion_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_CantidadLogueosIncorrectos","SeguridadUsuario_UsuarioCreacion_CantidadLogueosIncorrectos")]
             public Int32 SeguridadUsuario_UsuarioCreacion_CantidadLogueosIncorrectos { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_Bloqueado","SeguridadUsuario_UsuarioCreacion_Bloqueado")]
             public Boolean SeguridadUsuario_UsuarioCreacion_Bloqueado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_FechaExpiracion","SeguridadUsuario_UsuarioCreacion_FechaExpiracion")]
             public DateTime SeguridadUsuario_UsuarioCreacion_FechaExpiracion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_UsuarioCreacion","SeguridadUsuario_UsuarioCreacion_UsuarioCreacion")]
             public Int64 SeguridadUsuario_UsuarioCreacion_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_FechaCreacion","SeguridadUsuario_UsuarioCreacion_FechaCreacion")]
             public DateTime SeguridadUsuario_UsuarioCreacion_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_UsuarioModificacion","SeguridadUsuario_UsuarioCreacion_UsuarioModificacion")]
             public Int64 SeguridadUsuario_UsuarioCreacion_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_FechaModificacion","SeguridadUsuario_UsuarioCreacion_FechaModificacion")]
             public DateTime SeguridadUsuario_UsuarioCreacion_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioCreacion_CodigoExterno","SeguridadUsuario_UsuarioCreacion_CodigoExterno")]
             public String SeguridadUsuario_UsuarioCreacion_CodigoExterno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Id","SeguridadUsuario_UsuarioModificacion_Id")]
             public Int64 SeguridadUsuario_UsuarioModificacion_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_EmpresaId","SeguridadUsuario_UsuarioModificacion_EmpresaId")]
             public Int64 SeguridadUsuario_UsuarioModificacion_EmpresaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_LenguajeId","SeguridadUsuario_UsuarioModificacion_LenguajeId")]
             public Int64 SeguridadUsuario_UsuarioModificacion_LenguajeId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_PerfilId","SeguridadUsuario_UsuarioModificacion_PerfilId")]
             public Int64 SeguridadUsuario_UsuarioModificacion_PerfilId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Nombre","SeguridadUsuario_UsuarioModificacion_Nombre")]
             public String SeguridadUsuario_UsuarioModificacion_Nombre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Apellido","SeguridadUsuario_UsuarioModificacion_Apellido")]
             public String SeguridadUsuario_UsuarioModificacion_Apellido { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_NombreApellido","SeguridadUsuario_UsuarioModificacion_NombreApellido")]
             public String SeguridadUsuario_UsuarioModificacion_NombreApellido { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Documento","SeguridadUsuario_UsuarioModificacion_Documento")]
             public String SeguridadUsuario_UsuarioModificacion_Documento { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Legajo","SeguridadUsuario_UsuarioModificacion_Legajo")]
             public String SeguridadUsuario_UsuarioModificacion_Legajo { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Mail","SeguridadUsuario_UsuarioModificacion_Mail")]
             public String SeguridadUsuario_UsuarioModificacion_Mail { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_FechaIngreso","SeguridadUsuario_UsuarioModificacion_FechaIngreso")]
             public DateTime SeguridadUsuario_UsuarioModificacion_FechaIngreso { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_NickName","SeguridadUsuario_UsuarioModificacion_NickName")]
             public String SeguridadUsuario_UsuarioModificacion_NickName { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Password","SeguridadUsuario_UsuarioModificacion_Password")]
             public String SeguridadUsuario_UsuarioModificacion_Password { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Token","SeguridadUsuario_UsuarioModificacion_Token")]
             public String SeguridadUsuario_UsuarioModificacion_Token { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Avatar","SeguridadUsuario_UsuarioModificacion_Avatar")]
             public String SeguridadUsuario_UsuarioModificacion_Avatar { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_FechaUltimoLogin","SeguridadUsuario_UsuarioModificacion_FechaUltimoLogin")]
             public DateTime SeguridadUsuario_UsuarioModificacion_FechaUltimoLogin { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_DebeCambiarPassword","SeguridadUsuario_UsuarioModificacion_DebeCambiarPassword")]
             public Boolean SeguridadUsuario_UsuarioModificacion_DebeCambiarPassword { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Habilitado","SeguridadUsuario_UsuarioModificacion_Habilitado")]
             public Boolean SeguridadUsuario_UsuarioModificacion_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_CantidadLogueosIncorrectos","SeguridadUsuario_UsuarioModificacion_CantidadLogueosIncorrectos")]
             public Int32 SeguridadUsuario_UsuarioModificacion_CantidadLogueosIncorrectos { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_Bloqueado","SeguridadUsuario_UsuarioModificacion_Bloqueado")]
             public Boolean SeguridadUsuario_UsuarioModificacion_Bloqueado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_FechaExpiracion","SeguridadUsuario_UsuarioModificacion_FechaExpiracion")]
             public DateTime SeguridadUsuario_UsuarioModificacion_FechaExpiracion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_UsuarioCreacion","SeguridadUsuario_UsuarioModificacion_UsuarioCreacion")]
             public Int64 SeguridadUsuario_UsuarioModificacion_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_FechaCreacion","SeguridadUsuario_UsuarioModificacion_FechaCreacion")]
             public DateTime SeguridadUsuario_UsuarioModificacion_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_UsuarioModificacion","SeguridadUsuario_UsuarioModificacion_UsuarioModificacion")]
             public Int64 SeguridadUsuario_UsuarioModificacion_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_FechaModificacion","SeguridadUsuario_UsuarioModificacion_FechaModificacion")]
             public DateTime SeguridadUsuario_UsuarioModificacion_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("SeguridadUsuario_UsuarioModificacion_CodigoExterno","SeguridadUsuario_UsuarioModificacion_CodigoExterno")]
             public String SeguridadUsuario_UsuarioModificacion_CodigoExterno { get; set; }
				
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
					public const string OperacionTransaccion_CodigoOperacion = "OperacionTransaccion_CodigoOperacion";
					public const string OperacionTransaccion_FechaCreacion = "OperacionTransaccion_FechaCreacion";
					public const string OperacionTransaccion_FechaModificacion = "OperacionTransaccion_FechaModificacion";
					public const string OperacionTransaccion_UsuarioCreacion = "OperacionTransaccion_UsuarioCreacion";
					public const string OperacionTransaccion_UsuarioModificacion = "OperacionTransaccion_UsuarioModificacion";
					public const string ValorDenominacion_Id = "ValorDenominacion_Id";
					public const string ValorDenominacion_Nombre = "ValorDenominacion_Nombre";
					public const string ValorDenominacion_TipoValorId = "ValorDenominacion_TipoValorId";
					public const string ValorDenominacion_MonedaId = "ValorDenominacion_MonedaId";
					public const string ValorDenominacion_Unidades = "ValorDenominacion_Unidades";
					public const string ValorDenominacion_Imagen = "ValorDenominacion_Imagen";
					public const string ValorDenominacion_CodigoCcTalk = "ValorDenominacion_CodigoCcTalk";
					public const string ValorDenominacion_Posicion = "ValorDenominacion_Posicion";
					public const string ValorDenominacion_CodigoExterno = "ValorDenominacion_CodigoExterno";
					public const string ValorDenominacion_Habilitado = "ValorDenominacion_Habilitado";
					public const string ValorDenominacion_UsuarioCreacion = "ValorDenominacion_UsuarioCreacion";
					public const string ValorDenominacion_FechaCreacion = "ValorDenominacion_FechaCreacion";
					public const string ValorDenominacion_UsuarioModificacion = "ValorDenominacion_UsuarioModificacion";
					public const string ValorDenominacion_FechaModificacion = "ValorDenominacion_FechaModificacion";
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
					OperacionTransaccion_CodigoOperacion,
					OperacionTransaccion_FechaCreacion,
					OperacionTransaccion_FechaModificacion,
					OperacionTransaccion_UsuarioCreacion,
					OperacionTransaccion_UsuarioModificacion,
					ValorDenominacion_Id,
					ValorDenominacion_Nombre,
					ValorDenominacion_TipoValorId,
					ValorDenominacion_MonedaId,
					ValorDenominacion_Unidades,
					ValorDenominacion_Imagen,
					ValorDenominacion_CodigoCcTalk,
					ValorDenominacion_Posicion,
					ValorDenominacion_CodigoExterno,
					ValorDenominacion_Habilitado,
					ValorDenominacion_UsuarioCreacion,
					ValorDenominacion_FechaCreacion,
					ValorDenominacion_UsuarioModificacion,
					ValorDenominacion_FechaModificacion
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
                public  OperacionTransaccionDetalle(Int64 OperacionTransaccionDetalle_Id,Int64 OperacionTransaccionDetalle_TransaccionId,Int64 OperacionTransaccionDetalle_DenominacionId,Int64 OperacionTransaccionDetalle_CantidadUnidades,DateTime OperacionTransaccionDetalle_Fecha,Int64 OperacionTransaccion_Id,Int64 OperacionTransaccion_TipoId,Int64 OperacionTransaccion_DepositarioId,Int64 OperacionTransaccion_SectorId,Int64 OperacionTransaccion_SucursalId,Int64 OperacionTransaccion_MonedaId,Int64 OperacionTransaccion_UsuarioId,Int64 OperacionTransaccion_CuentaId,Int64 OperacionTransaccion_ContenedorId,Int64 OperacionTransaccion_SesionId,Int64 OperacionTransaccion_TurnoId,Int64 OperacionTransaccion_CierreDiarioId,Double OperacionTransaccion_TotalValidado,Double OperacionTransaccion_TotalAValidar,DateTime OperacionTransaccion_Fecha,Boolean OperacionTransaccion_Finalizada,Boolean OperacionTransaccion_EsDepositoAutomatico,Int64 OperacionTransaccion_OrigenValorId,String OperacionTransaccion_CodigoOperacion,DateTime OperacionTransaccion_FechaCreacion,DateTime OperacionTransaccion_FechaModificacion,Int64 OperacionTransaccion_UsuarioCreacion,Int64 OperacionTransaccion_UsuarioModificacion,Int64 ValorDenominacion_Id,String ValorDenominacion_Nombre,Int64 ValorDenominacion_TipoValorId,Int64 ValorDenominacion_MonedaId,Decimal ValorDenominacion_Unidades,String ValorDenominacion_Imagen,String ValorDenominacion_CodigoCcTalk,Int32 ValorDenominacion_Posicion,String ValorDenominacion_CodigoExterno,Boolean ValorDenominacion_Habilitado,Int64 ValorDenominacion_UsuarioCreacion,DateTime ValorDenominacion_FechaCreacion,Int64 ValorDenominacion_UsuarioModificacion,DateTime ValorDenominacion_FechaModificacion)
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
                    this.OperacionTransaccion_CodigoOperacion = OperacionTransaccion_CodigoOperacion;
                    this.OperacionTransaccion_FechaCreacion = OperacionTransaccion_FechaCreacion;
                    this.OperacionTransaccion_FechaModificacion = OperacionTransaccion_FechaModificacion;
                    this.OperacionTransaccion_UsuarioCreacion = OperacionTransaccion_UsuarioCreacion;
                    this.OperacionTransaccion_UsuarioModificacion = OperacionTransaccion_UsuarioModificacion;
                    this.ValorDenominacion_Id = ValorDenominacion_Id;
                    this.ValorDenominacion_Nombre = ValorDenominacion_Nombre;
                    this.ValorDenominacion_TipoValorId = ValorDenominacion_TipoValorId;
                    this.ValorDenominacion_MonedaId = ValorDenominacion_MonedaId;
                    this.ValorDenominacion_Unidades = ValorDenominacion_Unidades;
                    this.ValorDenominacion_Imagen = ValorDenominacion_Imagen;
                    this.ValorDenominacion_CodigoCcTalk = ValorDenominacion_CodigoCcTalk;
                    this.ValorDenominacion_Posicion = ValorDenominacion_Posicion;
                    this.ValorDenominacion_CodigoExterno = ValorDenominacion_CodigoExterno;
                    this.ValorDenominacion_Habilitado = ValorDenominacion_Habilitado;
                    this.ValorDenominacion_UsuarioCreacion = ValorDenominacion_UsuarioCreacion;
                    this.ValorDenominacion_FechaCreacion = ValorDenominacion_FechaCreacion;
                    this.ValorDenominacion_UsuarioModificacion = ValorDenominacion_UsuarioModificacion;
                    this.ValorDenominacion_FechaModificacion = ValorDenominacion_FechaModificacion;
                }
             /// <summary>
             /// Identificador de registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_Id","OperacionTransaccionDetalle_Id")]
             public Int64 OperacionTransaccionDetalle_Id { get; set; }
             /// <summary>
             /// Identificador de transaccion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_TransaccionId","OperacionTransaccionDetalle_TransaccionId")]
             public Int64 OperacionTransaccionDetalle_TransaccionId { get; set; }
             /// <summary>
             /// Identificador de denominacion
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_DenominacionId","OperacionTransaccionDetalle_DenominacionId")]
             public Int64 OperacionTransaccionDetalle_DenominacionId { get; set; }
             /// <summary>
             /// Cantidad sensada de la denminación
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_CantidadUnidades","OperacionTransaccionDetalle_CantidadUnidades")]
             public Int64 OperacionTransaccionDetalle_CantidadUnidades { get; set; }
             /// <summary>
             /// Fecha de alta del registro
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionDetalle_Fecha","OperacionTransaccionDetalle_Fecha")]
             public DateTime OperacionTransaccionDetalle_Fecha { get; set; }
             /// <summary>
             /// Id de la Transaccion- TEST
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Id","OperacionTransaccion_Id")]
             public Int64 OperacionTransaccion_Id { get; set; }
             /// <summary>
             /// Tipo de Transaccion -TEST
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TipoId","OperacionTransaccion_TipoId")]
             public Int64 OperacionTransaccion_TipoId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_DepositarioId","OperacionTransaccion_DepositarioId")]
             public Int64 OperacionTransaccion_DepositarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SectorId","OperacionTransaccion_SectorId")]
             public Int64 OperacionTransaccion_SectorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SucursalId","OperacionTransaccion_SucursalId")]
             public Int64 OperacionTransaccion_SucursalId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_MonedaId","OperacionTransaccion_MonedaId")]
             public Int64 OperacionTransaccion_MonedaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioId","OperacionTransaccion_UsuarioId")]
             public Int64 OperacionTransaccion_UsuarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CuentaId","OperacionTransaccion_CuentaId")]
             public Int64 OperacionTransaccion_CuentaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_ContenedorId","OperacionTransaccion_ContenedorId")]
             public Int64 OperacionTransaccion_ContenedorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SesionId","OperacionTransaccion_SesionId")]
             public Int64 OperacionTransaccion_SesionId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TurnoId","OperacionTransaccion_TurnoId")]
             public Int64 OperacionTransaccion_TurnoId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CierreDiarioId","OperacionTransaccion_CierreDiarioId")]
             public Int64 OperacionTransaccion_CierreDiarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalValidado","OperacionTransaccion_TotalValidado")]
             public Double OperacionTransaccion_TotalValidado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalAValidar","OperacionTransaccion_TotalAValidar")]
             public Double OperacionTransaccion_TotalAValidar { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Fecha","OperacionTransaccion_Fecha")]
             public DateTime OperacionTransaccion_Fecha { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Finalizada","OperacionTransaccion_Finalizada")]
             public Boolean OperacionTransaccion_Finalizada { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_EsDepositoAutomatico","OperacionTransaccion_EsDepositoAutomatico")]
             public Boolean OperacionTransaccion_EsDepositoAutomatico { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_OrigenValorId","OperacionTransaccion_OrigenValorId")]
             public Int64 OperacionTransaccion_OrigenValorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CodigoOperacion","OperacionTransaccion_CodigoOperacion")]
             public String OperacionTransaccion_CodigoOperacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_FechaCreacion","OperacionTransaccion_FechaCreacion")]
             public DateTime OperacionTransaccion_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_FechaModificacion","OperacionTransaccion_FechaModificacion")]
             public DateTime OperacionTransaccion_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioCreacion","OperacionTransaccion_UsuarioCreacion")]
             public Int64 OperacionTransaccion_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioModificacion","OperacionTransaccion_UsuarioModificacion")]
             public Int64 OperacionTransaccion_UsuarioModificacion { get; set; }
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
             [DataItemAttributeFieldName("ValorDenominacion_Imagen","ValorDenominacion_Imagen")]
             public String ValorDenominacion_Imagen { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_CodigoCcTalk","ValorDenominacion_CodigoCcTalk")]
             public String ValorDenominacion_CodigoCcTalk { get; set; }
             /// <summary>
             /// Indica en qué posición del buffer es informada la cantidad detectada por la lectora
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_Posicion","ValorDenominacion_Posicion")]
             public Int32 ValorDenominacion_Posicion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_CodigoExterno","ValorDenominacion_CodigoExterno")]
             public String ValorDenominacion_CodigoExterno { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_Habilitado","ValorDenominacion_Habilitado")]
             public Boolean ValorDenominacion_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_UsuarioCreacion","ValorDenominacion_UsuarioCreacion")]
             public Int64 ValorDenominacion_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_FechaCreacion","ValorDenominacion_FechaCreacion")]
             public DateTime ValorDenominacion_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_UsuarioModificacion","ValorDenominacion_UsuarioModificacion")]
             public Int64 ValorDenominacion_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorDenominacion_FechaModificacion","ValorDenominacion_FechaModificacion")]
             public DateTime ValorDenominacion_FechaModificacion { get; set; }
				
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
					public const string OperacionTransaccion_FechaCreacion = "OperacionTransaccion_FechaCreacion";
					public const string OperacionTransaccion_FechaModificacion = "OperacionTransaccion_FechaModificacion";
					public const string OperacionTransaccion_UsuarioCreacion = "OperacionTransaccion_UsuarioCreacion";
					public const string OperacionTransaccion_UsuarioModificacion = "OperacionTransaccion_UsuarioModificacion";
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
					OperacionTransaccion_CodigoOperacion,
					OperacionTransaccion_FechaCreacion,
					OperacionTransaccion_FechaModificacion,
					OperacionTransaccion_UsuarioCreacion,
					OperacionTransaccion_UsuarioModificacion
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
                public  OperacionTransaccionSobre(Int64 OperacionTransaccionSobre_Id,Int64 OperacionTransaccionSobre_TransaccionId,String OperacionTransaccionSobre_CodigoSobre,DateTime OperacionTransaccionSobre_Fecha,Int64 OperacionTransaccion_Id,Int64 OperacionTransaccion_TipoId,Int64 OperacionTransaccion_DepositarioId,Int64 OperacionTransaccion_SectorId,Int64 OperacionTransaccion_SucursalId,Int64 OperacionTransaccion_MonedaId,Int64 OperacionTransaccion_UsuarioId,Int64 OperacionTransaccion_CuentaId,Int64 OperacionTransaccion_ContenedorId,Int64 OperacionTransaccion_SesionId,Int64 OperacionTransaccion_TurnoId,Int64 OperacionTransaccion_CierreDiarioId,Double OperacionTransaccion_TotalValidado,Double OperacionTransaccion_TotalAValidar,DateTime OperacionTransaccion_Fecha,Boolean OperacionTransaccion_Finalizada,Boolean OperacionTransaccion_EsDepositoAutomatico,Int64 OperacionTransaccion_OrigenValorId,String OperacionTransaccion_CodigoOperacion,DateTime OperacionTransaccion_FechaCreacion,DateTime OperacionTransaccion_FechaModificacion,Int64 OperacionTransaccion_UsuarioCreacion,Int64 OperacionTransaccion_UsuarioModificacion)
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
                    this.OperacionTransaccion_FechaCreacion = OperacionTransaccion_FechaCreacion;
                    this.OperacionTransaccion_FechaModificacion = OperacionTransaccion_FechaModificacion;
                    this.OperacionTransaccion_UsuarioCreacion = OperacionTransaccion_UsuarioCreacion;
                    this.OperacionTransaccion_UsuarioModificacion = OperacionTransaccion_UsuarioModificacion;
                }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_Id","OperacionTransaccionSobre_Id")]
             public Int64 OperacionTransaccionSobre_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_TransaccionId","OperacionTransaccionSobre_TransaccionId")]
             public Int64 OperacionTransaccionSobre_TransaccionId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_CodigoSobre","OperacionTransaccionSobre_CodigoSobre")]
             public String OperacionTransaccionSobre_CodigoSobre { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_Fecha","OperacionTransaccionSobre_Fecha")]
             public DateTime OperacionTransaccionSobre_Fecha { get; set; }
             /// <summary>
             /// Id de la Transaccion- TEST
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Id","OperacionTransaccion_Id")]
             public Int64 OperacionTransaccion_Id { get; set; }
             /// <summary>
             /// Tipo de Transaccion -TEST
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TipoId","OperacionTransaccion_TipoId")]
             public Int64 OperacionTransaccion_TipoId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_DepositarioId","OperacionTransaccion_DepositarioId")]
             public Int64 OperacionTransaccion_DepositarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SectorId","OperacionTransaccion_SectorId")]
             public Int64 OperacionTransaccion_SectorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SucursalId","OperacionTransaccion_SucursalId")]
             public Int64 OperacionTransaccion_SucursalId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_MonedaId","OperacionTransaccion_MonedaId")]
             public Int64 OperacionTransaccion_MonedaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioId","OperacionTransaccion_UsuarioId")]
             public Int64 OperacionTransaccion_UsuarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CuentaId","OperacionTransaccion_CuentaId")]
             public Int64 OperacionTransaccion_CuentaId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_ContenedorId","OperacionTransaccion_ContenedorId")]
             public Int64 OperacionTransaccion_ContenedorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_SesionId","OperacionTransaccion_SesionId")]
             public Int64 OperacionTransaccion_SesionId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TurnoId","OperacionTransaccion_TurnoId")]
             public Int64 OperacionTransaccion_TurnoId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CierreDiarioId","OperacionTransaccion_CierreDiarioId")]
             public Int64 OperacionTransaccion_CierreDiarioId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalValidado","OperacionTransaccion_TotalValidado")]
             public Double OperacionTransaccion_TotalValidado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_TotalAValidar","OperacionTransaccion_TotalAValidar")]
             public Double OperacionTransaccion_TotalAValidar { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Fecha","OperacionTransaccion_Fecha")]
             public DateTime OperacionTransaccion_Fecha { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_Finalizada","OperacionTransaccion_Finalizada")]
             public Boolean OperacionTransaccion_Finalizada { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_EsDepositoAutomatico","OperacionTransaccion_EsDepositoAutomatico")]
             public Boolean OperacionTransaccion_EsDepositoAutomatico { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_OrigenValorId","OperacionTransaccion_OrigenValorId")]
             public Int64 OperacionTransaccion_OrigenValorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_CodigoOperacion","OperacionTransaccion_CodigoOperacion")]
             public String OperacionTransaccion_CodigoOperacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_FechaCreacion","OperacionTransaccion_FechaCreacion")]
             public DateTime OperacionTransaccion_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_FechaModificacion","OperacionTransaccion_FechaModificacion")]
             public DateTime OperacionTransaccion_FechaModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioCreacion","OperacionTransaccion_UsuarioCreacion")]
             public Int64 OperacionTransaccion_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccion_UsuarioModificacion","OperacionTransaccion_UsuarioModificacion")]
             public Int64 OperacionTransaccion_UsuarioModificacion { get; set; }
				
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
					public const string ValorRelacionMonedaTipoValor_Habilitado = "ValorRelacionMonedaTipoValor_Habilitado";
					public const string ValorRelacionMonedaTipoValor_UsuarioCreacion = "ValorRelacionMonedaTipoValor_UsuarioCreacion";
					public const string ValorRelacionMonedaTipoValor_FechaCreacion = "ValorRelacionMonedaTipoValor_FechaCreacion";
					public const string ValorRelacionMonedaTipoValor_UsuarioModificacion = "ValorRelacionMonedaTipoValor_UsuarioModificacion";
					public const string ValorRelacionMonedaTipoValor_FechaModificacion = "ValorRelacionMonedaTipoValor_FechaModificacion";
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
					ValorRelacionMonedaTipoValor_TipoValorId,
					ValorRelacionMonedaTipoValor_Habilitado,
					ValorRelacionMonedaTipoValor_UsuarioCreacion,
					ValorRelacionMonedaTipoValor_FechaCreacion,
					ValorRelacionMonedaTipoValor_UsuarioModificacion,
					ValorRelacionMonedaTipoValor_FechaModificacion
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
                public  OperacionTransaccionSobreDetalle(Int64 OperacionTransaccionSobreDetalle_Id,Int64 OperacionTransaccionSobreDetalle_SobreId,Int64 OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId,Int64 OperacionTransaccionSobreDetalle_CantidadDeclarada,Double OperacionTransaccionSobreDetalle_ValorDeclarado,DateTime OperacionTransaccionSobreDetalle_Fecha,Int64 OperacionTransaccionSobre_Id,Int64 OperacionTransaccionSobre_TransaccionId,String OperacionTransaccionSobre_CodigoSobre,DateTime OperacionTransaccionSobre_Fecha,Int64 ValorRelacionMonedaTipoValor_Id,Int64 ValorRelacionMonedaTipoValor_MonedaId,Int64 ValorRelacionMonedaTipoValor_TipoValorId,Boolean ValorRelacionMonedaTipoValor_Habilitado,Int64 ValorRelacionMonedaTipoValor_UsuarioCreacion,DateTime ValorRelacionMonedaTipoValor_FechaCreacion,Int64 ValorRelacionMonedaTipoValor_UsuarioModificacion,DateTime ValorRelacionMonedaTipoValor_FechaModificacion)
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
                    this.ValorRelacionMonedaTipoValor_Habilitado = ValorRelacionMonedaTipoValor_Habilitado;
                    this.ValorRelacionMonedaTipoValor_UsuarioCreacion = ValorRelacionMonedaTipoValor_UsuarioCreacion;
                    this.ValorRelacionMonedaTipoValor_FechaCreacion = ValorRelacionMonedaTipoValor_FechaCreacion;
                    this.ValorRelacionMonedaTipoValor_UsuarioModificacion = ValorRelacionMonedaTipoValor_UsuarioModificacion;
                    this.ValorRelacionMonedaTipoValor_FechaModificacion = ValorRelacionMonedaTipoValor_FechaModificacion;
                }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_Id","OperacionTransaccionSobreDetalle_Id")]
             public Int64 OperacionTransaccionSobreDetalle_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_SobreId","OperacionTransaccionSobreDetalle_SobreId")]
             public Int64 OperacionTransaccionSobreDetalle_SobreId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId","OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId")]
             public Int64 OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_CantidadDeclarada","OperacionTransaccionSobreDetalle_CantidadDeclarada")]
             public Int64 OperacionTransaccionSobreDetalle_CantidadDeclarada { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_ValorDeclarado","OperacionTransaccionSobreDetalle_ValorDeclarado")]
             public Double OperacionTransaccionSobreDetalle_ValorDeclarado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobreDetalle_Fecha","OperacionTransaccionSobreDetalle_Fecha")]
             public DateTime OperacionTransaccionSobreDetalle_Fecha { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_Id","OperacionTransaccionSobre_Id")]
             public Int64 OperacionTransaccionSobre_Id { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_TransaccionId","OperacionTransaccionSobre_TransaccionId")]
             public Int64 OperacionTransaccionSobre_TransaccionId { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("OperacionTransaccionSobre_CodigoSobre","OperacionTransaccionSobre_CodigoSobre")]
             public String OperacionTransaccionSobre_CodigoSobre { get; set; }
             /// <summary>
             /// 
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
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorRelacionMonedaTipoValor_Habilitado","ValorRelacionMonedaTipoValor_Habilitado")]
             public Boolean ValorRelacionMonedaTipoValor_Habilitado { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorRelacionMonedaTipoValor_UsuarioCreacion","ValorRelacionMonedaTipoValor_UsuarioCreacion")]
             public Int64 ValorRelacionMonedaTipoValor_UsuarioCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorRelacionMonedaTipoValor_FechaCreacion","ValorRelacionMonedaTipoValor_FechaCreacion")]
             public DateTime ValorRelacionMonedaTipoValor_FechaCreacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorRelacionMonedaTipoValor_UsuarioModificacion","ValorRelacionMonedaTipoValor_UsuarioModificacion")]
             public Int64 ValorRelacionMonedaTipoValor_UsuarioModificacion { get; set; }
             /// <summary>
             /// 
             /// </summary>
             [DataItemAttributeFieldName("ValorRelacionMonedaTipoValor_FechaModificacion","ValorRelacionMonedaTipoValor_FechaModificacion")]
             public DateTime ValorRelacionMonedaTipoValor_FechaModificacion { get; set; }
				
			} //Class OperacionTransaccionSobreDetalle 
			
} //namespace DepositaryWebApi.Entities.Views.Integracion
//////////////////////////////////////////////////////////////////////////////////
