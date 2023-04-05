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
					public const string Operacion_Transaccion_Id = "Operacion_Transaccion_Id";
					public const string Operacion_Transaccion_TipoId = "Operacion_Transaccion_TipoId";
					public const string Operacion_Transaccion_DepositarioId = "Operacion_Transaccion_DepositarioId";
					public const string Operacion_Transaccion_SectorId = "Operacion_Transaccion_SectorId";
					public const string Operacion_Transaccion_SucursalId = "Operacion_Transaccion_SucursalId";
					public const string Operacion_Transaccion_MonedaId = "Operacion_Transaccion_MonedaId";
					public const string Operacion_Transaccion_UsuarioId = "Operacion_Transaccion_UsuarioId";
					public const string Operacion_Transaccion_CuentaId = "Operacion_Transaccion_CuentaId";
					public const string Operacion_Transaccion_ContenedorId = "Operacion_Transaccion_ContenedorId";
					public const string Operacion_Transaccion_SesionId = "Operacion_Transaccion_SesionId";
					public const string Operacion_Transaccion_TurnoId = "Operacion_Transaccion_TurnoId";
					public const string Operacion_Transaccion_CierreDiarioId = "Operacion_Transaccion_CierreDiarioId";
					public const string Operacion_Transaccion_TotalValidado = "Operacion_Transaccion_TotalValidado";
					public const string Operacion_Transaccion_TotalAValidar = "Operacion_Transaccion_TotalAValidar";
					public const string Operacion_Transaccion_Fecha = "Operacion_Transaccion_Fecha";
					public const string Operacion_Transaccion_Finalizada = "Operacion_Transaccion_Finalizada";
					public const string Operacion_Transaccion_EsDepositoAutomatico = "Operacion_Transaccion_EsDepositoAutomatico";
					public const string Operacion_Transaccion_OrigenValorId = "Operacion_Transaccion_OrigenValorId";
					public const string Operacion_Transaccion_CodigoOperacion = "Operacion_Transaccion_CodigoOperacion";
					public const string Operacion_Transaccion_FechaCreacion = "Operacion_Transaccion_FechaCreacion";
					public const string Operacion_Transaccion_FechaModificacion = "Operacion_Transaccion_FechaModificacion";
					public const string Operacion_Transaccion_UsuarioCreacion = "Operacion_Transaccion_UsuarioCreacion";
					public const string Operacion_Transaccion_UsuarioModificacion = "Operacion_Transaccion_UsuarioModificacion";
					public const string Operacion_TipoTransaccion_Id = "Operacion_TipoTransaccion_Id";
					public const string Operacion_TipoTransaccion_Nombre = "Operacion_TipoTransaccion_Nombre";
					public const string Operacion_TipoTransaccion_Descripcion = "Operacion_TipoTransaccion_Descripcion";
					public const string Dispositivo_Depositario_Id = "Dispositivo_Depositario_Id";
					public const string Dispositivo_Depositario_Nombre = "Dispositivo_Depositario_Nombre";
					public const string Dispositivo_Depositario_Descripcion = "Dispositivo_Depositario_Descripcion";
					public const string Dispositivo_Depositario_SectorId = "Dispositivo_Depositario_SectorId";
					public const string Dispositivo_Depositario_NumeroSerie = "Dispositivo_Depositario_NumeroSerie";
					public const string Dispositivo_Depositario_CodigoExterno = "Dispositivo_Depositario_CodigoExterno";
					public const string Directorio_Sector_Id = "Directorio_Sector_Id";
					public const string Directorio_Sector_SucursalId = "Directorio_Sector_SucursalId";
					public const string Directorio_Sector_Nombre = "Directorio_Sector_Nombre";
					public const string Directorio_Sector_Descripcion = "Directorio_Sector_Descripcion";
					public const string Directorio_Sector_CodigoExterno = "Directorio_Sector_CodigoExterno";
					public const string Directorio_Sucursal_Id = "Directorio_Sucursal_Id";
					public const string Directorio_Sucursal_Nombre = "Directorio_Sucursal_Nombre";
					public const string Directorio_Sucursal_Descripcion = "Directorio_Sucursal_Descripcion";
					public const string Directorio_Sucursal_EmpresaId = "Directorio_Sucursal_EmpresaId";
					public const string Directorio_Sucursal_CodigoExterno = "Directorio_Sucursal_CodigoExterno";
					public const string Directorio_Sucursal_Direccion = "Directorio_Sucursal_Direccion";
					public const string Directorio_Sucursal_CodigoPostalId = "Directorio_Sucursal_CodigoPostalId";
					public const string Directorio_Sucursal_ZonaId = "Directorio_Sucursal_ZonaId";
					public const string Valor_Moneda_Id = "Valor_Moneda_Id";
					public const string Valor_Moneda_Nombre = "Valor_Moneda_Nombre";
					public const string Valor_Moneda_PaisId = "Valor_Moneda_PaisId";
					public const string Valor_Moneda_Codigo = "Valor_Moneda_Codigo";
					public const string Valor_Moneda_Simbolo = "Valor_Moneda_Simbolo";
					public const string Valor_Moneda_CodigoExterno = "Valor_Moneda_CodigoExterno";
					public const string Seguridad_Usuario_Id = "Seguridad_Usuario_Id";
					public const string Seguridad_Usuario_EmpresaId = "Seguridad_Usuario_EmpresaId";
					public const string Seguridad_Usuario_LenguajeId = "Seguridad_Usuario_LenguajeId";
					public const string Seguridad_Usuario_PerfilId = "Seguridad_Usuario_PerfilId";
					public const string Seguridad_Usuario_Nombre = "Seguridad_Usuario_Nombre";
					public const string Seguridad_Usuario_Apellido = "Seguridad_Usuario_Apellido";
					public const string Seguridad_Usuario_NombreApellido = "Seguridad_Usuario_NombreApellido";
					public const string Seguridad_Usuario_Documento = "Seguridad_Usuario_Documento";
					public const string Seguridad_Usuario_Legajo = "Seguridad_Usuario_Legajo";
					public const string Seguridad_Usuario_CodigoExterno = "Seguridad_Usuario_CodigoExterno";
					public const string Banca_Cuenta_Id = "Banca_Cuenta_Id";
					public const string Banca_Cuenta_TipoId = "Banca_Cuenta_TipoId";
					public const string Banca_Cuenta_EmpresaId = "Banca_Cuenta_EmpresaId";
					public const string Banca_Cuenta_Nombre = "Banca_Cuenta_Nombre";
					public const string Banca_Cuenta_Numero = "Banca_Cuenta_Numero";
					public const string Banca_Cuenta_Alias = "Banca_Cuenta_Alias";
					public const string Banca_Cuenta_CBU = "Banca_Cuenta_CBU";
					public const string Banca_Cuenta_BancoId = "Banca_Cuenta_BancoId";
					public const string Banca_Cuenta_SucursalBancaria = "Banca_Cuenta_SucursalBancaria";
					public const string Banca_Cuenta_CodigoExterno = "Banca_Cuenta_CodigoExterno";
					public const string Operacion_Contenedor_Id = "Operacion_Contenedor_Id";
					public const string Operacion_Contenedor_Nombre = "Operacion_Contenedor_Nombre";
					public const string Operacion_Contenedor_DepositarioId = "Operacion_Contenedor_DepositarioId";
					public const string Operacion_Contenedor_TipoId = "Operacion_Contenedor_TipoId";
					public const string Operacion_Contenedor_Identificador = "Operacion_Contenedor_Identificador";
					public const string Operacion_Contenedor_FechaApertura = "Operacion_Contenedor_FechaApertura";
					public const string Operacion_Contenedor_FechaCierre = "Operacion_Contenedor_FechaCierre";
					public const string Operacion_Sesion_Id = "Operacion_Sesion_Id";
					public const string Operacion_Sesion_UsuarioId = "Operacion_Sesion_UsuarioId";
					public const string Operacion_Sesion_FechaInicio = "Operacion_Sesion_FechaInicio";
					public const string Operacion_Sesion_FechaCierre = "Operacion_Sesion_FechaCierre";
					public const string Operacion_Sesion_EsCierreAutomatico = "Operacion_Sesion_EsCierreAutomatico";
					public const string Operacion_Turno_Id = "Operacion_Turno_Id";
					public const string Operacion_Turno_TurnoDepositarioId = "Operacion_Turno_TurnoDepositarioId";
					public const string Operacion_Turno_DepositarioId = "Operacion_Turno_DepositarioId";
					public const string Operacion_Turno_SectorId = "Operacion_Turno_SectorId";
					public const string Operacion_Turno_FechaApertura = "Operacion_Turno_FechaApertura";
					public const string Operacion_Turno_FechaCierre = "Operacion_Turno_FechaCierre";
					public const string Operacion_Turno_Fecha = "Operacion_Turno_Fecha";
					public const string Operacion_Turno_Secuencia = "Operacion_Turno_Secuencia";
					public const string Operacion_Turno_CierreDiarioId = "Operacion_Turno_CierreDiarioId";
					public const string Operacion_Turno_Observaciones = "Operacion_Turno_Observaciones";
					public const string Operacion_Turno_CodigoTurno = "Operacion_Turno_CodigoTurno";
					public const string Operacion_CierreDiario_Id = "Operacion_CierreDiario_Id";
					public const string Operacion_CierreDiario_Nombre = "Operacion_CierreDiario_Nombre";
					public const string Operacion_CierreDiario_Fecha = "Operacion_CierreDiario_Fecha";
					public const string Operacion_CierreDiario_DepositarioId = "Operacion_CierreDiario_DepositarioId";
					public const string Operacion_CierreDiario_SesionId = "Operacion_CierreDiario_SesionId";
					public const string Operacion_CierreDiario_CodigoCierre = "Operacion_CierreDiario_CodigoCierre";
					public const string Operacion_CierreDiario_UsuarioCreacion = "Operacion_CierreDiario_UsuarioCreacion";
					public const string Operacion_CierreDiario_FechaCreacion = "Operacion_CierreDiario_FechaCreacion";
					public const string Operacion_CierreDiario_UsuarioModificacion = "Operacion_CierreDiario_UsuarioModificacion";
					public const string Operacion_CierreDiario_FechaModificacion = "Operacion_CierreDiario_FechaModificacion";
					public const string Valor_OrigenValor_Id = "Valor_OrigenValor_Id";
					public const string Valor_OrigenValor_Nombre = "Valor_OrigenValor_Nombre";
					public const string Valor_OrigenValor_Descripcion = "Valor_OrigenValor_Descripcion";
					public const string Valor_OrigenValor_CodigoExterno = "Valor_OrigenValor_CodigoExterno";
				}
				public enum FieldEnum : int
                {
					Operacion_Transaccion_Id,
					Operacion_Transaccion_TipoId,
					Operacion_Transaccion_DepositarioId,
					Operacion_Transaccion_SectorId,
					Operacion_Transaccion_SucursalId,
					Operacion_Transaccion_MonedaId,
					Operacion_Transaccion_UsuarioId,
					Operacion_Transaccion_CuentaId,
					Operacion_Transaccion_ContenedorId,
					Operacion_Transaccion_SesionId,
					Operacion_Transaccion_TurnoId,
					Operacion_Transaccion_CierreDiarioId,
					Operacion_Transaccion_TotalValidado,
					Operacion_Transaccion_TotalAValidar,
					Operacion_Transaccion_Fecha,
					Operacion_Transaccion_Finalizada,
					Operacion_Transaccion_EsDepositoAutomatico,
					Operacion_Transaccion_OrigenValorId,
					Operacion_Transaccion_CodigoOperacion,
					Operacion_Transaccion_FechaCreacion,
					Operacion_Transaccion_FechaModificacion,
					Operacion_Transaccion_UsuarioCreacion,
					Operacion_Transaccion_UsuarioModificacion,
					Operacion_TipoTransaccion_Id,
					Operacion_TipoTransaccion_Nombre,
					Operacion_TipoTransaccion_Descripcion,
					Dispositivo_Depositario_Id,
					Dispositivo_Depositario_Nombre,
					Dispositivo_Depositario_Descripcion,
					Dispositivo_Depositario_SectorId,
					Dispositivo_Depositario_NumeroSerie,
					Dispositivo_Depositario_CodigoExterno,
					Directorio_Sector_Id,
					Directorio_Sector_SucursalId,
					Directorio_Sector_Nombre,
					Directorio_Sector_Descripcion,
					Directorio_Sector_CodigoExterno,
					Directorio_Sucursal_Id,
					Directorio_Sucursal_Nombre,
					Directorio_Sucursal_Descripcion,
					Directorio_Sucursal_EmpresaId,
					Directorio_Sucursal_CodigoExterno,
					Directorio_Sucursal_Direccion,
					Directorio_Sucursal_CodigoPostalId,
					Directorio_Sucursal_ZonaId,
					Valor_Moneda_Id,
					Valor_Moneda_Nombre,
					Valor_Moneda_PaisId,
					Valor_Moneda_Codigo,
					Valor_Moneda_Simbolo,
					Valor_Moneda_CodigoExterno,
					Seguridad_Usuario_Id,
					Seguridad_Usuario_EmpresaId,
					Seguridad_Usuario_LenguajeId,
					Seguridad_Usuario_PerfilId,
					Seguridad_Usuario_Nombre,
					Seguridad_Usuario_Apellido,
					Seguridad_Usuario_NombreApellido,
					Seguridad_Usuario_Documento,
					Seguridad_Usuario_Legajo,
					Seguridad_Usuario_CodigoExterno,
					Banca_Cuenta_Id,
					Banca_Cuenta_TipoId,
					Banca_Cuenta_EmpresaId,
					Banca_Cuenta_Nombre,
					Banca_Cuenta_Numero,
					Banca_Cuenta_Alias,
					Banca_Cuenta_CBU,
					Banca_Cuenta_BancoId,
					Banca_Cuenta_SucursalBancaria,
					Banca_Cuenta_CodigoExterno,
					Operacion_Contenedor_Id,
					Operacion_Contenedor_Nombre,
					Operacion_Contenedor_DepositarioId,
					Operacion_Contenedor_TipoId,
					Operacion_Contenedor_Identificador,
					Operacion_Contenedor_FechaApertura,
					Operacion_Contenedor_FechaCierre,
					Operacion_Sesion_Id,
					Operacion_Sesion_UsuarioId,
					Operacion_Sesion_FechaInicio,
					Operacion_Sesion_FechaCierre,
					Operacion_Sesion_EsCierreAutomatico,
					Operacion_Turno_Id,
					Operacion_Turno_TurnoDepositarioId,
					Operacion_Turno_DepositarioId,
					Operacion_Turno_SectorId,
					Operacion_Turno_FechaApertura,
					Operacion_Turno_FechaCierre,
					Operacion_Turno_Fecha,
					Operacion_Turno_Secuencia,
					Operacion_Turno_CierreDiarioId,
					Operacion_Turno_Observaciones,
					Operacion_Turno_CodigoTurno,
					Operacion_CierreDiario_Id,
					Operacion_CierreDiario_Nombre,
					Operacion_CierreDiario_Fecha,
					Operacion_CierreDiario_DepositarioId,
					Operacion_CierreDiario_SesionId,
					Operacion_CierreDiario_CodigoCierre,
					Operacion_CierreDiario_UsuarioCreacion,
					Operacion_CierreDiario_FechaCreacion,
					Operacion_CierreDiario_UsuarioModificacion,
					Operacion_CierreDiario_FechaModificacion,
					Valor_OrigenValor_Id,
					Valor_OrigenValor_Nombre,
					Valor_OrigenValor_Descripcion,
					Valor_OrigenValor_CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public OperacionTransaccion()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  OperacionTransaccion(Int64 Operacion_Transaccion_Id,Int64 Operacion_Transaccion_TipoId,Int64 Operacion_Transaccion_DepositarioId,Int64 Operacion_Transaccion_SectorId,Int64 Operacion_Transaccion_SucursalId,Int64 Operacion_Transaccion_MonedaId,Int64 Operacion_Transaccion_UsuarioId,Int64 Operacion_Transaccion_CuentaId,Int64 Operacion_Transaccion_ContenedorId,Int64 Operacion_Transaccion_SesionId,Int64 Operacion_Transaccion_TurnoId,Int64 Operacion_Transaccion_CierreDiarioId,Double Operacion_Transaccion_TotalValidado,Double Operacion_Transaccion_TotalAValidar,DateTime Operacion_Transaccion_Fecha,Boolean Operacion_Transaccion_Finalizada,Boolean Operacion_Transaccion_EsDepositoAutomatico,Int64 Operacion_Transaccion_OrigenValorId,String Operacion_Transaccion_CodigoOperacion,DateTime Operacion_Transaccion_FechaCreacion,DateTime Operacion_Transaccion_FechaModificacion,Int64 Operacion_Transaccion_UsuarioCreacion,Int64 Operacion_Transaccion_UsuarioModificacion,Int64 Operacion_TipoTransaccion_Id,String Operacion_TipoTransaccion_Nombre,String Operacion_TipoTransaccion_Descripcion,Int64 Dispositivo_Depositario_Id,String Dispositivo_Depositario_Nombre,String Dispositivo_Depositario_Descripcion,Int64 Dispositivo_Depositario_SectorId,String Dispositivo_Depositario_NumeroSerie,String Dispositivo_Depositario_CodigoExterno,Int64 Directorio_Sector_Id,Int64 Directorio_Sector_SucursalId,String Directorio_Sector_Nombre,String Directorio_Sector_Descripcion,String Directorio_Sector_CodigoExterno,Int64 Directorio_Sucursal_Id,String Directorio_Sucursal_Nombre,String Directorio_Sucursal_Descripcion,Int64 Directorio_Sucursal_EmpresaId,String Directorio_Sucursal_CodigoExterno,String Directorio_Sucursal_Direccion,Int64 Directorio_Sucursal_CodigoPostalId,Int64 Directorio_Sucursal_ZonaId,Int64 Valor_Moneda_Id,String Valor_Moneda_Nombre,Int64 Valor_Moneda_PaisId,String Valor_Moneda_Codigo,String Valor_Moneda_Simbolo,String Valor_Moneda_CodigoExterno,Int64 Seguridad_Usuario_Id,Int64 Seguridad_Usuario_EmpresaId,Int64 Seguridad_Usuario_LenguajeId,Int64 Seguridad_Usuario_PerfilId,String Seguridad_Usuario_Nombre,String Seguridad_Usuario_Apellido,String Seguridad_Usuario_NombreApellido,String Seguridad_Usuario_Documento,String Seguridad_Usuario_Legajo,String Seguridad_Usuario_CodigoExterno,Int64 Banca_Cuenta_Id,Int64 Banca_Cuenta_TipoId,Int64 Banca_Cuenta_EmpresaId,String Banca_Cuenta_Nombre,String Banca_Cuenta_Numero,String Banca_Cuenta_Alias,String Banca_Cuenta_CBU,Int64 Banca_Cuenta_BancoId,String Banca_Cuenta_SucursalBancaria,String Banca_Cuenta_CodigoExterno,Int64 Operacion_Contenedor_Id,String Operacion_Contenedor_Nombre,Int64 Operacion_Contenedor_DepositarioId,Int64 Operacion_Contenedor_TipoId,String Operacion_Contenedor_Identificador,DateTime Operacion_Contenedor_FechaApertura,DateTime Operacion_Contenedor_FechaCierre,Int64 Operacion_Sesion_Id,Int64 Operacion_Sesion_UsuarioId,DateTime Operacion_Sesion_FechaInicio,DateTime Operacion_Sesion_FechaCierre,Boolean Operacion_Sesion_EsCierreAutomatico,Int64 Operacion_Turno_Id,Int64 Operacion_Turno_TurnoDepositarioId,Int64 Operacion_Turno_DepositarioId,Int64 Operacion_Turno_SectorId,DateTime Operacion_Turno_FechaApertura,DateTime Operacion_Turno_FechaCierre,DateTime Operacion_Turno_Fecha,Int32 Operacion_Turno_Secuencia,Int64 Operacion_Turno_CierreDiarioId,String Operacion_Turno_Observaciones,String Operacion_Turno_CodigoTurno,Int64 Operacion_CierreDiario_Id,String Operacion_CierreDiario_Nombre,DateTime Operacion_CierreDiario_Fecha,Int64 Operacion_CierreDiario_DepositarioId,Int64 Operacion_CierreDiario_SesionId,String Operacion_CierreDiario_CodigoCierre,Int64 Operacion_CierreDiario_UsuarioCreacion,DateTime Operacion_CierreDiario_FechaCreacion,Int64 Operacion_CierreDiario_UsuarioModificacion,DateTime Operacion_CierreDiario_FechaModificacion,Int64 Valor_OrigenValor_Id,String Valor_OrigenValor_Nombre,String Valor_OrigenValor_Descripcion,String Valor_OrigenValor_CodigoExterno)
                {
                    this.Operacion_Transaccion_Id = Operacion_Transaccion_Id;
                    this.Operacion_Transaccion_TipoId = Operacion_Transaccion_TipoId;
                    this.Operacion_Transaccion_DepositarioId = Operacion_Transaccion_DepositarioId;
                    this.Operacion_Transaccion_SectorId = Operacion_Transaccion_SectorId;
                    this.Operacion_Transaccion_SucursalId = Operacion_Transaccion_SucursalId;
                    this.Operacion_Transaccion_MonedaId = Operacion_Transaccion_MonedaId;
                    this.Operacion_Transaccion_UsuarioId = Operacion_Transaccion_UsuarioId;
                    this.Operacion_Transaccion_CuentaId = Operacion_Transaccion_CuentaId;
                    this.Operacion_Transaccion_ContenedorId = Operacion_Transaccion_ContenedorId;
                    this.Operacion_Transaccion_SesionId = Operacion_Transaccion_SesionId;
                    this.Operacion_Transaccion_TurnoId = Operacion_Transaccion_TurnoId;
                    this.Operacion_Transaccion_CierreDiarioId = Operacion_Transaccion_CierreDiarioId;
                    this.Operacion_Transaccion_TotalValidado = Operacion_Transaccion_TotalValidado;
                    this.Operacion_Transaccion_TotalAValidar = Operacion_Transaccion_TotalAValidar;
                    this.Operacion_Transaccion_Fecha = Operacion_Transaccion_Fecha;
                    this.Operacion_Transaccion_Finalizada = Operacion_Transaccion_Finalizada;
                    this.Operacion_Transaccion_EsDepositoAutomatico = Operacion_Transaccion_EsDepositoAutomatico;
                    this.Operacion_Transaccion_OrigenValorId = Operacion_Transaccion_OrigenValorId;
                    this.Operacion_Transaccion_CodigoOperacion = Operacion_Transaccion_CodigoOperacion;
                    this.Operacion_Transaccion_FechaCreacion = Operacion_Transaccion_FechaCreacion;
                    this.Operacion_Transaccion_FechaModificacion = Operacion_Transaccion_FechaModificacion;
                    this.Operacion_Transaccion_UsuarioCreacion = Operacion_Transaccion_UsuarioCreacion;
                    this.Operacion_Transaccion_UsuarioModificacion = Operacion_Transaccion_UsuarioModificacion;
                    this.Operacion_TipoTransaccion_Id = Operacion_TipoTransaccion_Id;
                    this.Operacion_TipoTransaccion_Nombre = Operacion_TipoTransaccion_Nombre;
                    this.Operacion_TipoTransaccion_Descripcion = Operacion_TipoTransaccion_Descripcion;
                    this.Dispositivo_Depositario_Id = Dispositivo_Depositario_Id;
                    this.Dispositivo_Depositario_Nombre = Dispositivo_Depositario_Nombre;
                    this.Dispositivo_Depositario_Descripcion = Dispositivo_Depositario_Descripcion;
                    this.Dispositivo_Depositario_SectorId = Dispositivo_Depositario_SectorId;
                    this.Dispositivo_Depositario_NumeroSerie = Dispositivo_Depositario_NumeroSerie;
                    this.Dispositivo_Depositario_CodigoExterno = Dispositivo_Depositario_CodigoExterno;
                    this.Directorio_Sector_Id = Directorio_Sector_Id;
                    this.Directorio_Sector_SucursalId = Directorio_Sector_SucursalId;
                    this.Directorio_Sector_Nombre = Directorio_Sector_Nombre;
                    this.Directorio_Sector_Descripcion = Directorio_Sector_Descripcion;
                    this.Directorio_Sector_CodigoExterno = Directorio_Sector_CodigoExterno;
                    this.Directorio_Sucursal_Id = Directorio_Sucursal_Id;
                    this.Directorio_Sucursal_Nombre = Directorio_Sucursal_Nombre;
                    this.Directorio_Sucursal_Descripcion = Directorio_Sucursal_Descripcion;
                    this.Directorio_Sucursal_EmpresaId = Directorio_Sucursal_EmpresaId;
                    this.Directorio_Sucursal_CodigoExterno = Directorio_Sucursal_CodigoExterno;
                    this.Directorio_Sucursal_Direccion = Directorio_Sucursal_Direccion;
                    this.Directorio_Sucursal_CodigoPostalId = Directorio_Sucursal_CodigoPostalId;
                    this.Directorio_Sucursal_ZonaId = Directorio_Sucursal_ZonaId;
                    this.Valor_Moneda_Id = Valor_Moneda_Id;
                    this.Valor_Moneda_Nombre = Valor_Moneda_Nombre;
                    this.Valor_Moneda_PaisId = Valor_Moneda_PaisId;
                    this.Valor_Moneda_Codigo = Valor_Moneda_Codigo;
                    this.Valor_Moneda_Simbolo = Valor_Moneda_Simbolo;
                    this.Valor_Moneda_CodigoExterno = Valor_Moneda_CodigoExterno;
                    this.Seguridad_Usuario_Id = Seguridad_Usuario_Id;
                    this.Seguridad_Usuario_EmpresaId = Seguridad_Usuario_EmpresaId;
                    this.Seguridad_Usuario_LenguajeId = Seguridad_Usuario_LenguajeId;
                    this.Seguridad_Usuario_PerfilId = Seguridad_Usuario_PerfilId;
                    this.Seguridad_Usuario_Nombre = Seguridad_Usuario_Nombre;
                    this.Seguridad_Usuario_Apellido = Seguridad_Usuario_Apellido;
                    this.Seguridad_Usuario_NombreApellido = Seguridad_Usuario_NombreApellido;
                    this.Seguridad_Usuario_Documento = Seguridad_Usuario_Documento;
                    this.Seguridad_Usuario_Legajo = Seguridad_Usuario_Legajo;
                    this.Seguridad_Usuario_CodigoExterno = Seguridad_Usuario_CodigoExterno;
                    this.Banca_Cuenta_Id = Banca_Cuenta_Id;
                    this.Banca_Cuenta_TipoId = Banca_Cuenta_TipoId;
                    this.Banca_Cuenta_EmpresaId = Banca_Cuenta_EmpresaId;
                    this.Banca_Cuenta_Nombre = Banca_Cuenta_Nombre;
                    this.Banca_Cuenta_Numero = Banca_Cuenta_Numero;
                    this.Banca_Cuenta_Alias = Banca_Cuenta_Alias;
                    this.Banca_Cuenta_CBU = Banca_Cuenta_CBU;
                    this.Banca_Cuenta_BancoId = Banca_Cuenta_BancoId;
                    this.Banca_Cuenta_SucursalBancaria = Banca_Cuenta_SucursalBancaria;
                    this.Banca_Cuenta_CodigoExterno = Banca_Cuenta_CodigoExterno;
                    this.Operacion_Contenedor_Id = Operacion_Contenedor_Id;
                    this.Operacion_Contenedor_Nombre = Operacion_Contenedor_Nombre;
                    this.Operacion_Contenedor_DepositarioId = Operacion_Contenedor_DepositarioId;
                    this.Operacion_Contenedor_TipoId = Operacion_Contenedor_TipoId;
                    this.Operacion_Contenedor_Identificador = Operacion_Contenedor_Identificador;
                    this.Operacion_Contenedor_FechaApertura = Operacion_Contenedor_FechaApertura;
                    this.Operacion_Contenedor_FechaCierre = Operacion_Contenedor_FechaCierre;
                    this.Operacion_Sesion_Id = Operacion_Sesion_Id;
                    this.Operacion_Sesion_UsuarioId = Operacion_Sesion_UsuarioId;
                    this.Operacion_Sesion_FechaInicio = Operacion_Sesion_FechaInicio;
                    this.Operacion_Sesion_FechaCierre = Operacion_Sesion_FechaCierre;
                    this.Operacion_Sesion_EsCierreAutomatico = Operacion_Sesion_EsCierreAutomatico;
                    this.Operacion_Turno_Id = Operacion_Turno_Id;
                    this.Operacion_Turno_TurnoDepositarioId = Operacion_Turno_TurnoDepositarioId;
                    this.Operacion_Turno_DepositarioId = Operacion_Turno_DepositarioId;
                    this.Operacion_Turno_SectorId = Operacion_Turno_SectorId;
                    this.Operacion_Turno_FechaApertura = Operacion_Turno_FechaApertura;
                    this.Operacion_Turno_FechaCierre = Operacion_Turno_FechaCierre;
                    this.Operacion_Turno_Fecha = Operacion_Turno_Fecha;
                    this.Operacion_Turno_Secuencia = Operacion_Turno_Secuencia;
                    this.Operacion_Turno_CierreDiarioId = Operacion_Turno_CierreDiarioId;
                    this.Operacion_Turno_Observaciones = Operacion_Turno_Observaciones;
                    this.Operacion_Turno_CodigoTurno = Operacion_Turno_CodigoTurno;
                    this.Operacion_CierreDiario_Id = Operacion_CierreDiario_Id;
                    this.Operacion_CierreDiario_Nombre = Operacion_CierreDiario_Nombre;
                    this.Operacion_CierreDiario_Fecha = Operacion_CierreDiario_Fecha;
                    this.Operacion_CierreDiario_DepositarioId = Operacion_CierreDiario_DepositarioId;
                    this.Operacion_CierreDiario_SesionId = Operacion_CierreDiario_SesionId;
                    this.Operacion_CierreDiario_CodigoCierre = Operacion_CierreDiario_CodigoCierre;
                    this.Operacion_CierreDiario_UsuarioCreacion = Operacion_CierreDiario_UsuarioCreacion;
                    this.Operacion_CierreDiario_FechaCreacion = Operacion_CierreDiario_FechaCreacion;
                    this.Operacion_CierreDiario_UsuarioModificacion = Operacion_CierreDiario_UsuarioModificacion;
                    this.Operacion_CierreDiario_FechaModificacion = Operacion_CierreDiario_FechaModificacion;
                    this.Valor_OrigenValor_Id = Valor_OrigenValor_Id;
                    this.Valor_OrigenValor_Nombre = Valor_OrigenValor_Nombre;
                    this.Valor_OrigenValor_Descripcion = Valor_OrigenValor_Descripcion;
                    this.Valor_OrigenValor_CodigoExterno = Valor_OrigenValor_CodigoExterno;
                }
             [DataItemAttributeFieldName("Operacion_Transaccion_Id","Operacion_Transaccion_Id")]
             public Int64 Operacion_Transaccion_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_TipoId","Operacion_Transaccion_TipoId")]
             public Int64 Operacion_Transaccion_TipoId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_DepositarioId","Operacion_Transaccion_DepositarioId")]
             public Int64 Operacion_Transaccion_DepositarioId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_SectorId","Operacion_Transaccion_SectorId")]
             public Int64 Operacion_Transaccion_SectorId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_SucursalId","Operacion_Transaccion_SucursalId")]
             public Int64 Operacion_Transaccion_SucursalId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_MonedaId","Operacion_Transaccion_MonedaId")]
             public Int64 Operacion_Transaccion_MonedaId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_UsuarioId","Operacion_Transaccion_UsuarioId")]
             public Int64 Operacion_Transaccion_UsuarioId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_CuentaId","Operacion_Transaccion_CuentaId")]
             public Int64 Operacion_Transaccion_CuentaId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_ContenedorId","Operacion_Transaccion_ContenedorId")]
             public Int64 Operacion_Transaccion_ContenedorId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_SesionId","Operacion_Transaccion_SesionId")]
             public Int64 Operacion_Transaccion_SesionId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_TurnoId","Operacion_Transaccion_TurnoId")]
             public Int64 Operacion_Transaccion_TurnoId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_CierreDiarioId","Operacion_Transaccion_CierreDiarioId")]
             public Int64 Operacion_Transaccion_CierreDiarioId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_TotalValidado","Operacion_Transaccion_TotalValidado")]
             public Double Operacion_Transaccion_TotalValidado { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_TotalAValidar","Operacion_Transaccion_TotalAValidar")]
             public Double Operacion_Transaccion_TotalAValidar { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_Fecha","Operacion_Transaccion_Fecha")]
             public DateTime Operacion_Transaccion_Fecha { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_Finalizada","Operacion_Transaccion_Finalizada")]
             public Boolean Operacion_Transaccion_Finalizada { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_EsDepositoAutomatico","Operacion_Transaccion_EsDepositoAutomatico")]
             public Boolean Operacion_Transaccion_EsDepositoAutomatico { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_OrigenValorId","Operacion_Transaccion_OrigenValorId")]
             public Int64 Operacion_Transaccion_OrigenValorId { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_CodigoOperacion","Operacion_Transaccion_CodigoOperacion")]
             public String Operacion_Transaccion_CodigoOperacion { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_FechaCreacion","Operacion_Transaccion_FechaCreacion")]
             public DateTime Operacion_Transaccion_FechaCreacion { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_FechaModificacion","Operacion_Transaccion_FechaModificacion")]
             public DateTime Operacion_Transaccion_FechaModificacion { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_UsuarioCreacion","Operacion_Transaccion_UsuarioCreacion")]
             public Int64 Operacion_Transaccion_UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_UsuarioModificacion","Operacion_Transaccion_UsuarioModificacion")]
             public Int64 Operacion_Transaccion_UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("Operacion_TipoTransaccion_Id","Operacion_TipoTransaccion_Id")]
             public Int64 Operacion_TipoTransaccion_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_TipoTransaccion_Nombre","Operacion_TipoTransaccion_Nombre")]
             public String Operacion_TipoTransaccion_Nombre { get; set; }
             [DataItemAttributeFieldName("Operacion_TipoTransaccion_Descripcion","Operacion_TipoTransaccion_Descripcion")]
             public String Operacion_TipoTransaccion_Descripcion { get; set; }
             [DataItemAttributeFieldName("Dispositivo_Depositario_Id","Dispositivo_Depositario_Id")]
             public Int64 Dispositivo_Depositario_Id { get; set; }
             [DataItemAttributeFieldName("Dispositivo_Depositario_Nombre","Dispositivo_Depositario_Nombre")]
             public String Dispositivo_Depositario_Nombre { get; set; }
             [DataItemAttributeFieldName("Dispositivo_Depositario_Descripcion","Dispositivo_Depositario_Descripcion")]
             public String Dispositivo_Depositario_Descripcion { get; set; }
             [DataItemAttributeFieldName("Dispositivo_Depositario_SectorId","Dispositivo_Depositario_SectorId")]
             public Int64 Dispositivo_Depositario_SectorId { get; set; }
             [DataItemAttributeFieldName("Dispositivo_Depositario_NumeroSerie","Dispositivo_Depositario_NumeroSerie")]
             public String Dispositivo_Depositario_NumeroSerie { get; set; }
             [DataItemAttributeFieldName("Dispositivo_Depositario_CodigoExterno","Dispositivo_Depositario_CodigoExterno")]
             public String Dispositivo_Depositario_CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Directorio_Sector_Id","Directorio_Sector_Id")]
             public Int64 Directorio_Sector_Id { get; set; }
             [DataItemAttributeFieldName("Directorio_Sector_SucursalId","Directorio_Sector_SucursalId")]
             public Int64 Directorio_Sector_SucursalId { get; set; }
             [DataItemAttributeFieldName("Directorio_Sector_Nombre","Directorio_Sector_Nombre")]
             public String Directorio_Sector_Nombre { get; set; }
             [DataItemAttributeFieldName("Directorio_Sector_Descripcion","Directorio_Sector_Descripcion")]
             public String Directorio_Sector_Descripcion { get; set; }
             [DataItemAttributeFieldName("Directorio_Sector_CodigoExterno","Directorio_Sector_CodigoExterno")]
             public String Directorio_Sector_CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Directorio_Sucursal_Id","Directorio_Sucursal_Id")]
             public Int64 Directorio_Sucursal_Id { get; set; }
             [DataItemAttributeFieldName("Directorio_Sucursal_Nombre","Directorio_Sucursal_Nombre")]
             public String Directorio_Sucursal_Nombre { get; set; }
             [DataItemAttributeFieldName("Directorio_Sucursal_Descripcion","Directorio_Sucursal_Descripcion")]
             public String Directorio_Sucursal_Descripcion { get; set; }
             [DataItemAttributeFieldName("Directorio_Sucursal_EmpresaId","Directorio_Sucursal_EmpresaId")]
             public Int64 Directorio_Sucursal_EmpresaId { get; set; }
             [DataItemAttributeFieldName("Directorio_Sucursal_CodigoExterno","Directorio_Sucursal_CodigoExterno")]
             public String Directorio_Sucursal_CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Directorio_Sucursal_Direccion","Directorio_Sucursal_Direccion")]
             public String Directorio_Sucursal_Direccion { get; set; }
             [DataItemAttributeFieldName("Directorio_Sucursal_CodigoPostalId","Directorio_Sucursal_CodigoPostalId")]
             public Int64 Directorio_Sucursal_CodigoPostalId { get; set; }
             [DataItemAttributeFieldName("Directorio_Sucursal_ZonaId","Directorio_Sucursal_ZonaId")]
             public Int64 Directorio_Sucursal_ZonaId { get; set; }
             [DataItemAttributeFieldName("Valor_Moneda_Id","Valor_Moneda_Id")]
             public Int64 Valor_Moneda_Id { get; set; }
             [DataItemAttributeFieldName("Valor_Moneda_Nombre","Valor_Moneda_Nombre")]
             public String Valor_Moneda_Nombre { get; set; }
             [DataItemAttributeFieldName("Valor_Moneda_PaisId","Valor_Moneda_PaisId")]
             public Int64 Valor_Moneda_PaisId { get; set; }
             [DataItemAttributeFieldName("Valor_Moneda_Codigo","Valor_Moneda_Codigo")]
             public String Valor_Moneda_Codigo { get; set; }
             [DataItemAttributeFieldName("Valor_Moneda_Simbolo","Valor_Moneda_Simbolo")]
             public String Valor_Moneda_Simbolo { get; set; }
             [DataItemAttributeFieldName("Valor_Moneda_CodigoExterno","Valor_Moneda_CodigoExterno")]
             public String Valor_Moneda_CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_Id","Seguridad_Usuario_Id")]
             public Int64 Seguridad_Usuario_Id { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_EmpresaId","Seguridad_Usuario_EmpresaId")]
             public Int64 Seguridad_Usuario_EmpresaId { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_LenguajeId","Seguridad_Usuario_LenguajeId")]
             public Int64 Seguridad_Usuario_LenguajeId { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_PerfilId","Seguridad_Usuario_PerfilId")]
             public Int64 Seguridad_Usuario_PerfilId { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_Nombre","Seguridad_Usuario_Nombre")]
             public String Seguridad_Usuario_Nombre { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_Apellido","Seguridad_Usuario_Apellido")]
             public String Seguridad_Usuario_Apellido { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_NombreApellido","Seguridad_Usuario_NombreApellido")]
             public String Seguridad_Usuario_NombreApellido { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_Documento","Seguridad_Usuario_Documento")]
             public String Seguridad_Usuario_Documento { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_Legajo","Seguridad_Usuario_Legajo")]
             public String Seguridad_Usuario_Legajo { get; set; }
             [DataItemAttributeFieldName("Seguridad_Usuario_CodigoExterno","Seguridad_Usuario_CodigoExterno")]
             public String Seguridad_Usuario_CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_Id","Banca_Cuenta_Id")]
             public Int64 Banca_Cuenta_Id { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_TipoId","Banca_Cuenta_TipoId")]
             public Int64 Banca_Cuenta_TipoId { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_EmpresaId","Banca_Cuenta_EmpresaId")]
             public Int64 Banca_Cuenta_EmpresaId { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_Nombre","Banca_Cuenta_Nombre")]
             public String Banca_Cuenta_Nombre { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_Numero","Banca_Cuenta_Numero")]
             public String Banca_Cuenta_Numero { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_Alias","Banca_Cuenta_Alias")]
             public String Banca_Cuenta_Alias { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_CBU","Banca_Cuenta_CBU")]
             public String Banca_Cuenta_CBU { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_BancoId","Banca_Cuenta_BancoId")]
             public Int64 Banca_Cuenta_BancoId { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_SucursalBancaria","Banca_Cuenta_SucursalBancaria")]
             public String Banca_Cuenta_SucursalBancaria { get; set; }
             [DataItemAttributeFieldName("Banca_Cuenta_CodigoExterno","Banca_Cuenta_CodigoExterno")]
             public String Banca_Cuenta_CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Operacion_Contenedor_Id","Operacion_Contenedor_Id")]
             public Int64 Operacion_Contenedor_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_Contenedor_Nombre","Operacion_Contenedor_Nombre")]
             public String Operacion_Contenedor_Nombre { get; set; }
             [DataItemAttributeFieldName("Operacion_Contenedor_DepositarioId","Operacion_Contenedor_DepositarioId")]
             public Int64 Operacion_Contenedor_DepositarioId { get; set; }
             [DataItemAttributeFieldName("Operacion_Contenedor_TipoId","Operacion_Contenedor_TipoId")]
             public Int64 Operacion_Contenedor_TipoId { get; set; }
             [DataItemAttributeFieldName("Operacion_Contenedor_Identificador","Operacion_Contenedor_Identificador")]
             public String Operacion_Contenedor_Identificador { get; set; }
             [DataItemAttributeFieldName("Operacion_Contenedor_FechaApertura","Operacion_Contenedor_FechaApertura")]
             public DateTime Operacion_Contenedor_FechaApertura { get; set; }
             [DataItemAttributeFieldName("Operacion_Contenedor_FechaCierre","Operacion_Contenedor_FechaCierre")]
             public DateTime Operacion_Contenedor_FechaCierre { get; set; }
             [DataItemAttributeFieldName("Operacion_Sesion_Id","Operacion_Sesion_Id")]
             public Int64 Operacion_Sesion_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_Sesion_UsuarioId","Operacion_Sesion_UsuarioId")]
             public Int64 Operacion_Sesion_UsuarioId { get; set; }
             [DataItemAttributeFieldName("Operacion_Sesion_FechaInicio","Operacion_Sesion_FechaInicio")]
             public DateTime Operacion_Sesion_FechaInicio { get; set; }
             [DataItemAttributeFieldName("Operacion_Sesion_FechaCierre","Operacion_Sesion_FechaCierre")]
             public DateTime Operacion_Sesion_FechaCierre { get; set; }
             [DataItemAttributeFieldName("Operacion_Sesion_EsCierreAutomatico","Operacion_Sesion_EsCierreAutomatico")]
             public Boolean Operacion_Sesion_EsCierreAutomatico { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_Id","Operacion_Turno_Id")]
             public Int64 Operacion_Turno_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_TurnoDepositarioId","Operacion_Turno_TurnoDepositarioId")]
             public Int64 Operacion_Turno_TurnoDepositarioId { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_DepositarioId","Operacion_Turno_DepositarioId")]
             public Int64 Operacion_Turno_DepositarioId { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_SectorId","Operacion_Turno_SectorId")]
             public Int64 Operacion_Turno_SectorId { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_FechaApertura","Operacion_Turno_FechaApertura")]
             public DateTime Operacion_Turno_FechaApertura { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_FechaCierre","Operacion_Turno_FechaCierre")]
             public DateTime Operacion_Turno_FechaCierre { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_Fecha","Operacion_Turno_Fecha")]
             public DateTime Operacion_Turno_Fecha { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_Secuencia","Operacion_Turno_Secuencia")]
             public Int32 Operacion_Turno_Secuencia { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_CierreDiarioId","Operacion_Turno_CierreDiarioId")]
             public Int64 Operacion_Turno_CierreDiarioId { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_Observaciones","Operacion_Turno_Observaciones")]
             public String Operacion_Turno_Observaciones { get; set; }
             [DataItemAttributeFieldName("Operacion_Turno_CodigoTurno","Operacion_Turno_CodigoTurno")]
             public String Operacion_Turno_CodigoTurno { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_Id","Operacion_CierreDiario_Id")]
             public Int64 Operacion_CierreDiario_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_Nombre","Operacion_CierreDiario_Nombre")]
             public String Operacion_CierreDiario_Nombre { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_Fecha","Operacion_CierreDiario_Fecha")]
             public DateTime Operacion_CierreDiario_Fecha { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_DepositarioId","Operacion_CierreDiario_DepositarioId")]
             public Int64 Operacion_CierreDiario_DepositarioId { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_SesionId","Operacion_CierreDiario_SesionId")]
             public Int64 Operacion_CierreDiario_SesionId { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_CodigoCierre","Operacion_CierreDiario_CodigoCierre")]
             public String Operacion_CierreDiario_CodigoCierre { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_UsuarioCreacion","Operacion_CierreDiario_UsuarioCreacion")]
             public Int64 Operacion_CierreDiario_UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_FechaCreacion","Operacion_CierreDiario_FechaCreacion")]
             public DateTime Operacion_CierreDiario_FechaCreacion { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_UsuarioModificacion","Operacion_CierreDiario_UsuarioModificacion")]
             public Int64 Operacion_CierreDiario_UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("Operacion_CierreDiario_FechaModificacion","Operacion_CierreDiario_FechaModificacion")]
             public DateTime Operacion_CierreDiario_FechaModificacion { get; set; }
             [DataItemAttributeFieldName("Valor_OrigenValor_Id","Valor_OrigenValor_Id")]
             public Int64 Valor_OrigenValor_Id { get; set; }
             [DataItemAttributeFieldName("Valor_OrigenValor_Nombre","Valor_OrigenValor_Nombre")]
             public String Valor_OrigenValor_Nombre { get; set; }
             [DataItemAttributeFieldName("Valor_OrigenValor_Descripcion","Valor_OrigenValor_Descripcion")]
             public String Valor_OrigenValor_Descripcion { get; set; }
             [DataItemAttributeFieldName("Valor_OrigenValor_CodigoExterno","Valor_OrigenValor_CodigoExterno")]
             public String Valor_OrigenValor_CodigoExterno { get; set; }
				
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
					public const string Operacion_TransaccionDetalle_Id = "Operacion_TransaccionDetalle_Id";
					public const string Operacion_TransaccionDetalle_TransaccionId = "Operacion_TransaccionDetalle_TransaccionId";
					public const string Operacion_TransaccionDetalle_DenominacionId = "Operacion_TransaccionDetalle_DenominacionId";
					public const string Operacion_TransaccionDetalle_CantidadUnidades = "Operacion_TransaccionDetalle_CantidadUnidades";
					public const string Operacion_TransaccionDetalle_Fecha = "Operacion_TransaccionDetalle_Fecha";
					public const string Operacion_Transaccion_Id = "Operacion_Transaccion_Id";
					public const string Valor_Denominacion_Id = "Valor_Denominacion_Id";
					public const string Valor_Denominacion_Nombre = "Valor_Denominacion_Nombre";
					public const string Valor_Denominacion_TipoValorId = "Valor_Denominacion_TipoValorId";
					public const string Valor_Denominacion_MonedaId = "Valor_Denominacion_MonedaId";
					public const string Valor_Denominacion_Unidades = "Valor_Denominacion_Unidades";
					public const string Valor_Denominacion_CodigoCcTalk = "Valor_Denominacion_CodigoCcTalk";
					public const string Valor_Denominacion_CodigoExterno = "Valor_Denominacion_CodigoExterno";
				}
				public enum FieldEnum : int
                {
					Operacion_TransaccionDetalle_Id,
					Operacion_TransaccionDetalle_TransaccionId,
					Operacion_TransaccionDetalle_DenominacionId,
					Operacion_TransaccionDetalle_CantidadUnidades,
					Operacion_TransaccionDetalle_Fecha,
					Operacion_Transaccion_Id,
					Valor_Denominacion_Id,
					Valor_Denominacion_Nombre,
					Valor_Denominacion_TipoValorId,
					Valor_Denominacion_MonedaId,
					Valor_Denominacion_Unidades,
					Valor_Denominacion_CodigoCcTalk,
					Valor_Denominacion_CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public OperacionTransaccionDetalle()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  OperacionTransaccionDetalle(Int64 Operacion_TransaccionDetalle_Id,Int64 Operacion_TransaccionDetalle_TransaccionId,Int64 Operacion_TransaccionDetalle_DenominacionId,Int64 Operacion_TransaccionDetalle_CantidadUnidades,DateTime Operacion_TransaccionDetalle_Fecha,Int64 Operacion_Transaccion_Id,Int64 Valor_Denominacion_Id,String Valor_Denominacion_Nombre,Int64 Valor_Denominacion_TipoValorId,Int64 Valor_Denominacion_MonedaId,Decimal Valor_Denominacion_Unidades,String Valor_Denominacion_CodigoCcTalk,String Valor_Denominacion_CodigoExterno)
                {
                    this.Operacion_TransaccionDetalle_Id = Operacion_TransaccionDetalle_Id;
                    this.Operacion_TransaccionDetalle_TransaccionId = Operacion_TransaccionDetalle_TransaccionId;
                    this.Operacion_TransaccionDetalle_DenominacionId = Operacion_TransaccionDetalle_DenominacionId;
                    this.Operacion_TransaccionDetalle_CantidadUnidades = Operacion_TransaccionDetalle_CantidadUnidades;
                    this.Operacion_TransaccionDetalle_Fecha = Operacion_TransaccionDetalle_Fecha;
                    this.Operacion_Transaccion_Id = Operacion_Transaccion_Id;
                    this.Valor_Denominacion_Id = Valor_Denominacion_Id;
                    this.Valor_Denominacion_Nombre = Valor_Denominacion_Nombre;
                    this.Valor_Denominacion_TipoValorId = Valor_Denominacion_TipoValorId;
                    this.Valor_Denominacion_MonedaId = Valor_Denominacion_MonedaId;
                    this.Valor_Denominacion_Unidades = Valor_Denominacion_Unidades;
                    this.Valor_Denominacion_CodigoCcTalk = Valor_Denominacion_CodigoCcTalk;
                    this.Valor_Denominacion_CodigoExterno = Valor_Denominacion_CodigoExterno;
                }
             [DataItemAttributeFieldName("Operacion_TransaccionDetalle_Id","Operacion_TransaccionDetalle_Id")]
             public Int64 Operacion_TransaccionDetalle_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionDetalle_TransaccionId","Operacion_TransaccionDetalle_TransaccionId")]
             public Int64 Operacion_TransaccionDetalle_TransaccionId { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionDetalle_DenominacionId","Operacion_TransaccionDetalle_DenominacionId")]
             public Int64 Operacion_TransaccionDetalle_DenominacionId { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionDetalle_CantidadUnidades","Operacion_TransaccionDetalle_CantidadUnidades")]
             public Int64 Operacion_TransaccionDetalle_CantidadUnidades { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionDetalle_Fecha","Operacion_TransaccionDetalle_Fecha")]
             public DateTime Operacion_TransaccionDetalle_Fecha { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_Id","Operacion_Transaccion_Id")]
             public Int64 Operacion_Transaccion_Id { get; set; }
             [DataItemAttributeFieldName("Valor_Denominacion_Id","Valor_Denominacion_Id")]
             public Int64 Valor_Denominacion_Id { get; set; }
             [DataItemAttributeFieldName("Valor_Denominacion_Nombre","Valor_Denominacion_Nombre")]
             public String Valor_Denominacion_Nombre { get; set; }
             [DataItemAttributeFieldName("Valor_Denominacion_TipoValorId","Valor_Denominacion_TipoValorId")]
             public Int64 Valor_Denominacion_TipoValorId { get; set; }
             [DataItemAttributeFieldName("Valor_Denominacion_MonedaId","Valor_Denominacion_MonedaId")]
             public Int64 Valor_Denominacion_MonedaId { get; set; }
             [DataItemAttributeFieldName("Valor_Denominacion_Unidades","Valor_Denominacion_Unidades")]
             public Decimal Valor_Denominacion_Unidades { get; set; }
             [DataItemAttributeFieldName("Valor_Denominacion_CodigoCcTalk","Valor_Denominacion_CodigoCcTalk")]
             public String Valor_Denominacion_CodigoCcTalk { get; set; }
             [DataItemAttributeFieldName("Valor_Denominacion_CodigoExterno","Valor_Denominacion_CodigoExterno")]
             public String Valor_Denominacion_CodigoExterno { get; set; }
				
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
					public const string Operacion_TransaccionSobre_Id = "Operacion_TransaccionSobre_Id";
					public const string Operacion_TransaccionSobre_TransaccionId = "Operacion_TransaccionSobre_TransaccionId";
					public const string Operacion_TransaccionSobre_CodigoSobre = "Operacion_TransaccionSobre_CodigoSobre";
					public const string Operacion_TransaccionSobre_Fecha = "Operacion_TransaccionSobre_Fecha";
					public const string Operacion_Transaccion_Id = "Operacion_Transaccion_Id";
				}
				public enum FieldEnum : int
                {
					Operacion_TransaccionSobre_Id,
					Operacion_TransaccionSobre_TransaccionId,
					Operacion_TransaccionSobre_CodigoSobre,
					Operacion_TransaccionSobre_Fecha,
					Operacion_Transaccion_Id
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public OperacionTransaccionSobre()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  OperacionTransaccionSobre(Int64 Operacion_TransaccionSobre_Id,Int64 Operacion_TransaccionSobre_TransaccionId,String Operacion_TransaccionSobre_CodigoSobre,DateTime Operacion_TransaccionSobre_Fecha,Int64 Operacion_Transaccion_Id)
                {
                    this.Operacion_TransaccionSobre_Id = Operacion_TransaccionSobre_Id;
                    this.Operacion_TransaccionSobre_TransaccionId = Operacion_TransaccionSobre_TransaccionId;
                    this.Operacion_TransaccionSobre_CodigoSobre = Operacion_TransaccionSobre_CodigoSobre;
                    this.Operacion_TransaccionSobre_Fecha = Operacion_TransaccionSobre_Fecha;
                    this.Operacion_Transaccion_Id = Operacion_Transaccion_Id;
                }
             [DataItemAttributeFieldName("Operacion_TransaccionSobre_Id","Operacion_TransaccionSobre_Id")]
             public Int64 Operacion_TransaccionSobre_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobre_TransaccionId","Operacion_TransaccionSobre_TransaccionId")]
             public Int64 Operacion_TransaccionSobre_TransaccionId { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobre_CodigoSobre","Operacion_TransaccionSobre_CodigoSobre")]
             public String Operacion_TransaccionSobre_CodigoSobre { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobre_Fecha","Operacion_TransaccionSobre_Fecha")]
             public DateTime Operacion_TransaccionSobre_Fecha { get; set; }
             [DataItemAttributeFieldName("Operacion_Transaccion_Id","Operacion_Transaccion_Id")]
             public Int64 Operacion_Transaccion_Id { get; set; }
				
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
					public const string Operacion_TransaccionSobreDetalle_Id = "Operacion_TransaccionSobreDetalle_Id";
					public const string Operacion_TransaccionSobreDetalle_SobreId = "Operacion_TransaccionSobreDetalle_SobreId";
					public const string Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId = "Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId";
					public const string Operacion_TransaccionSobreDetalle_CantidadDeclarada = "Operacion_TransaccionSobreDetalle_CantidadDeclarada";
					public const string Operacion_TransaccionSobreDetalle_ValorDeclarado = "Operacion_TransaccionSobreDetalle_ValorDeclarado";
					public const string Operacion_TransaccionSobreDetalle_Fecha = "Operacion_TransaccionSobreDetalle_Fecha";
					public const string Operacion_TransaccionSobre_Id = "Operacion_TransaccionSobre_Id";
					public const string Operacion_TransaccionSobre_TransaccionId = "Operacion_TransaccionSobre_TransaccionId";
					public const string Operacion_TransaccionSobre_CodigoSobre = "Operacion_TransaccionSobre_CodigoSobre";
					public const string Operacion_TransaccionSobre_Fecha = "Operacion_TransaccionSobre_Fecha";
					public const string Valor_RelacionMonedaTipoValor_Id = "Valor_RelacionMonedaTipoValor_Id";
					public const string Valor_RelacionMonedaTipoValor_MonedaId = "Valor_RelacionMonedaTipoValor_MonedaId";
					public const string Valor_RelacionMonedaTipoValor_TipoValorId = "Valor_RelacionMonedaTipoValor_TipoValorId";
					public const string Valor_RelacionMonedaTipoValor_Habilitado = "Valor_RelacionMonedaTipoValor_Habilitado";
					public const string Valor_RelacionMonedaTipoValor_UsuarioCreacion = "Valor_RelacionMonedaTipoValor_UsuarioCreacion";
					public const string Valor_RelacionMonedaTipoValor_FechaCreacion = "Valor_RelacionMonedaTipoValor_FechaCreacion";
					public const string Valor_RelacionMonedaTipoValor_UsuarioModificacion = "Valor_RelacionMonedaTipoValor_UsuarioModificacion";
					public const string Valor_RelacionMonedaTipoValor_FechaModificacion = "Valor_RelacionMonedaTipoValor_FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Operacion_TransaccionSobreDetalle_Id,
					Operacion_TransaccionSobreDetalle_SobreId,
					Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId,
					Operacion_TransaccionSobreDetalle_CantidadDeclarada,
					Operacion_TransaccionSobreDetalle_ValorDeclarado,
					Operacion_TransaccionSobreDetalle_Fecha,
					Operacion_TransaccionSobre_Id,
					Operacion_TransaccionSobre_TransaccionId,
					Operacion_TransaccionSobre_CodigoSobre,
					Operacion_TransaccionSobre_Fecha,
					Valor_RelacionMonedaTipoValor_Id,
					Valor_RelacionMonedaTipoValor_MonedaId,
					Valor_RelacionMonedaTipoValor_TipoValorId,
					Valor_RelacionMonedaTipoValor_Habilitado,
					Valor_RelacionMonedaTipoValor_UsuarioCreacion,
					Valor_RelacionMonedaTipoValor_FechaCreacion,
					Valor_RelacionMonedaTipoValor_UsuarioModificacion,
					Valor_RelacionMonedaTipoValor_FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public OperacionTransaccionSobreDetalle()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  OperacionTransaccionSobreDetalle(Int64 Operacion_TransaccionSobreDetalle_Id,Int64 Operacion_TransaccionSobreDetalle_SobreId,Int64 Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId,Int64 Operacion_TransaccionSobreDetalle_CantidadDeclarada,Double Operacion_TransaccionSobreDetalle_ValorDeclarado,DateTime Operacion_TransaccionSobreDetalle_Fecha,Int64 Operacion_TransaccionSobre_Id,Int64 Operacion_TransaccionSobre_TransaccionId,String Operacion_TransaccionSobre_CodigoSobre,DateTime Operacion_TransaccionSobre_Fecha,Int64 Valor_RelacionMonedaTipoValor_Id,Int64 Valor_RelacionMonedaTipoValor_MonedaId,Int64 Valor_RelacionMonedaTipoValor_TipoValorId,Boolean Valor_RelacionMonedaTipoValor_Habilitado,Int64 Valor_RelacionMonedaTipoValor_UsuarioCreacion,DateTime Valor_RelacionMonedaTipoValor_FechaCreacion,Int64 Valor_RelacionMonedaTipoValor_UsuarioModificacion,DateTime Valor_RelacionMonedaTipoValor_FechaModificacion)
                {
                    this.Operacion_TransaccionSobreDetalle_Id = Operacion_TransaccionSobreDetalle_Id;
                    this.Operacion_TransaccionSobreDetalle_SobreId = Operacion_TransaccionSobreDetalle_SobreId;
                    this.Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId = Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId;
                    this.Operacion_TransaccionSobreDetalle_CantidadDeclarada = Operacion_TransaccionSobreDetalle_CantidadDeclarada;
                    this.Operacion_TransaccionSobreDetalle_ValorDeclarado = Operacion_TransaccionSobreDetalle_ValorDeclarado;
                    this.Operacion_TransaccionSobreDetalle_Fecha = Operacion_TransaccionSobreDetalle_Fecha;
                    this.Operacion_TransaccionSobre_Id = Operacion_TransaccionSobre_Id;
                    this.Operacion_TransaccionSobre_TransaccionId = Operacion_TransaccionSobre_TransaccionId;
                    this.Operacion_TransaccionSobre_CodigoSobre = Operacion_TransaccionSobre_CodigoSobre;
                    this.Operacion_TransaccionSobre_Fecha = Operacion_TransaccionSobre_Fecha;
                    this.Valor_RelacionMonedaTipoValor_Id = Valor_RelacionMonedaTipoValor_Id;
                    this.Valor_RelacionMonedaTipoValor_MonedaId = Valor_RelacionMonedaTipoValor_MonedaId;
                    this.Valor_RelacionMonedaTipoValor_TipoValorId = Valor_RelacionMonedaTipoValor_TipoValorId;
                    this.Valor_RelacionMonedaTipoValor_Habilitado = Valor_RelacionMonedaTipoValor_Habilitado;
                    this.Valor_RelacionMonedaTipoValor_UsuarioCreacion = Valor_RelacionMonedaTipoValor_UsuarioCreacion;
                    this.Valor_RelacionMonedaTipoValor_FechaCreacion = Valor_RelacionMonedaTipoValor_FechaCreacion;
                    this.Valor_RelacionMonedaTipoValor_UsuarioModificacion = Valor_RelacionMonedaTipoValor_UsuarioModificacion;
                    this.Valor_RelacionMonedaTipoValor_FechaModificacion = Valor_RelacionMonedaTipoValor_FechaModificacion;
                }
             [DataItemAttributeFieldName("Operacion_TransaccionSobreDetalle_Id","Operacion_TransaccionSobreDetalle_Id")]
             public Int64 Operacion_TransaccionSobreDetalle_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobreDetalle_SobreId","Operacion_TransaccionSobreDetalle_SobreId")]
             public Int64 Operacion_TransaccionSobreDetalle_SobreId { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId","Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId")]
             public Int64 Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobreDetalle_CantidadDeclarada","Operacion_TransaccionSobreDetalle_CantidadDeclarada")]
             public Int64 Operacion_TransaccionSobreDetalle_CantidadDeclarada { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobreDetalle_ValorDeclarado","Operacion_TransaccionSobreDetalle_ValorDeclarado")]
             public Double Operacion_TransaccionSobreDetalle_ValorDeclarado { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobreDetalle_Fecha","Operacion_TransaccionSobreDetalle_Fecha")]
             public DateTime Operacion_TransaccionSobreDetalle_Fecha { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobre_Id","Operacion_TransaccionSobre_Id")]
             public Int64 Operacion_TransaccionSobre_Id { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobre_TransaccionId","Operacion_TransaccionSobre_TransaccionId")]
             public Int64 Operacion_TransaccionSobre_TransaccionId { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobre_CodigoSobre","Operacion_TransaccionSobre_CodigoSobre")]
             public String Operacion_TransaccionSobre_CodigoSobre { get; set; }
             [DataItemAttributeFieldName("Operacion_TransaccionSobre_Fecha","Operacion_TransaccionSobre_Fecha")]
             public DateTime Operacion_TransaccionSobre_Fecha { get; set; }
             [DataItemAttributeFieldName("Valor_RelacionMonedaTipoValor_Id","Valor_RelacionMonedaTipoValor_Id")]
             public Int64 Valor_RelacionMonedaTipoValor_Id { get; set; }
             [DataItemAttributeFieldName("Valor_RelacionMonedaTipoValor_MonedaId","Valor_RelacionMonedaTipoValor_MonedaId")]
             public Int64 Valor_RelacionMonedaTipoValor_MonedaId { get; set; }
             [DataItemAttributeFieldName("Valor_RelacionMonedaTipoValor_TipoValorId","Valor_RelacionMonedaTipoValor_TipoValorId")]
             public Int64 Valor_RelacionMonedaTipoValor_TipoValorId { get; set; }
             [DataItemAttributeFieldName("Valor_RelacionMonedaTipoValor_Habilitado","Valor_RelacionMonedaTipoValor_Habilitado")]
             public Boolean Valor_RelacionMonedaTipoValor_Habilitado { get; set; }
             [DataItemAttributeFieldName("Valor_RelacionMonedaTipoValor_UsuarioCreacion","Valor_RelacionMonedaTipoValor_UsuarioCreacion")]
             public Int64 Valor_RelacionMonedaTipoValor_UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("Valor_RelacionMonedaTipoValor_FechaCreacion","Valor_RelacionMonedaTipoValor_FechaCreacion")]
             public DateTime Valor_RelacionMonedaTipoValor_FechaCreacion { get; set; }
             [DataItemAttributeFieldName("Valor_RelacionMonedaTipoValor_UsuarioModificacion","Valor_RelacionMonedaTipoValor_UsuarioModificacion")]
             public Int64 Valor_RelacionMonedaTipoValor_UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("Valor_RelacionMonedaTipoValor_FechaModificacion","Valor_RelacionMonedaTipoValor_FechaModificacion")]
             public DateTime Valor_RelacionMonedaTipoValor_FechaModificacion { get; set; }
				
			} //Class OperacionTransaccionSobreDetalle 
			
} //namespace DepositaryWebApi.Entities.Views.Integracion
//////////////////////////////////////////////////////////////////////////////////
