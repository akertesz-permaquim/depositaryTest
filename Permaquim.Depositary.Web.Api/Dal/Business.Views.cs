using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace DepositaryWebApi.Business.Views.Integracion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class OperacionTransaccion : DataHandler
		{
				public enum ColumnEnum : int
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
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
         private List<Entities.Views.Integracion.OperacionTransaccion> _entities = new List<Entities.Views.Integracion.OperacionTransaccion>();
            public OperacionTransaccion() : base()
            {
                base._dataItem = new Entities.Views.Integracion.OperacionTransaccion();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public OperacionTransaccion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Integracion.OperacionTransaccion();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(DepositaryWebApi.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Integracion.OperacionTransaccion item)
			{
				_cacheItemList.Add(item);
			}
			public void UpdateCache()
			{
                this.BeginTransaction();
				foreach(IDataItem item in _cacheItemList)
					base.Add(item);
				this.EndTransaction(true);
			}
			// Method that accepts arguments corresponding to fields (Those wich aren´t identity.)
			public Entities.Views.Integracion.OperacionTransaccion Add(Int64 Operacion_Transaccion_Id,Int64 Operacion_Transaccion_TipoId,Int64 Operacion_Transaccion_DepositarioId,Int64 Operacion_Transaccion_SectorId,Int64 Operacion_Transaccion_SucursalId,Int64 Operacion_Transaccion_MonedaId,Int64 Operacion_Transaccion_UsuarioId,Int64 Operacion_Transaccion_CuentaId,Int64 Operacion_Transaccion_ContenedorId,Int64 Operacion_Transaccion_SesionId,Int64 Operacion_Transaccion_TurnoId,Int64 Operacion_Transaccion_CierreDiarioId,Double Operacion_Transaccion_TotalValidado,Double Operacion_Transaccion_TotalAValidar,DateTime Operacion_Transaccion_Fecha,Boolean Operacion_Transaccion_Finalizada,Boolean Operacion_Transaccion_EsDepositoAutomatico,Int64 Operacion_Transaccion_OrigenValorId,String Operacion_Transaccion_CodigoOperacion,DateTime Operacion_Transaccion_FechaCreacion,DateTime Operacion_Transaccion_FechaModificacion,Int64 Operacion_Transaccion_UsuarioCreacion,Int64 Operacion_Transaccion_UsuarioModificacion,Int64 Operacion_TipoTransaccion_Id,String Operacion_TipoTransaccion_Nombre,String Operacion_TipoTransaccion_Descripcion,Int64 Dispositivo_Depositario_Id,String Dispositivo_Depositario_Nombre,String Dispositivo_Depositario_Descripcion,Int64 Dispositivo_Depositario_SectorId,String Dispositivo_Depositario_NumeroSerie,String Dispositivo_Depositario_CodigoExterno,Int64 Directorio_Sector_Id,Int64 Directorio_Sector_SucursalId,String Directorio_Sector_Nombre,String Directorio_Sector_Descripcion,String Directorio_Sector_CodigoExterno,Int64 Directorio_Sucursal_Id,String Directorio_Sucursal_Nombre,String Directorio_Sucursal_Descripcion,Int64 Directorio_Sucursal_EmpresaId,String Directorio_Sucursal_CodigoExterno,String Directorio_Sucursal_Direccion,Int64 Directorio_Sucursal_CodigoPostalId,Int64 Directorio_Sucursal_ZonaId,Int64 Valor_Moneda_Id,String Valor_Moneda_Nombre,Int64 Valor_Moneda_PaisId,String Valor_Moneda_Codigo,String Valor_Moneda_Simbolo,String Valor_Moneda_CodigoExterno,Int64 Seguridad_Usuario_Id,Int64 Seguridad_Usuario_EmpresaId,Int64 Seguridad_Usuario_LenguajeId,Int64 Seguridad_Usuario_PerfilId,String Seguridad_Usuario_Nombre,String Seguridad_Usuario_Apellido,String Seguridad_Usuario_NombreApellido,String Seguridad_Usuario_Documento,String Seguridad_Usuario_Legajo,String Seguridad_Usuario_CodigoExterno,Int64 Banca_Cuenta_Id,Int64 Banca_Cuenta_TipoId,Int64 Banca_Cuenta_EmpresaId,String Banca_Cuenta_Nombre,String Banca_Cuenta_Numero,String Banca_Cuenta_Alias,String Banca_Cuenta_CBU,Int64 Banca_Cuenta_BancoId,String Banca_Cuenta_SucursalBancaria,String Banca_Cuenta_CodigoExterno,Int64 Operacion_Contenedor_Id,String Operacion_Contenedor_Nombre,Int64 Operacion_Contenedor_DepositarioId,Int64 Operacion_Contenedor_TipoId,String Operacion_Contenedor_Identificador,DateTime Operacion_Contenedor_FechaApertura,DateTime Operacion_Contenedor_FechaCierre,Int64 Operacion_Sesion_Id,Int64 Operacion_Sesion_UsuarioId,DateTime Operacion_Sesion_FechaInicio,DateTime Operacion_Sesion_FechaCierre,Boolean Operacion_Sesion_EsCierreAutomatico,Int64 Operacion_Turno_Id,Int64 Operacion_Turno_TurnoDepositarioId,Int64 Operacion_Turno_DepositarioId,Int64 Operacion_Turno_SectorId,DateTime Operacion_Turno_FechaApertura,DateTime Operacion_Turno_FechaCierre,DateTime Operacion_Turno_Fecha,Int32 Operacion_Turno_Secuencia,Int64 Operacion_Turno_CierreDiarioId,String Operacion_Turno_Observaciones,String Operacion_Turno_CodigoTurno,Int64 Operacion_CierreDiario_Id,String Operacion_CierreDiario_Nombre,DateTime Operacion_CierreDiario_Fecha,Int64 Operacion_CierreDiario_DepositarioId,Int64 Operacion_CierreDiario_SesionId,String Operacion_CierreDiario_CodigoCierre,Int64 Operacion_CierreDiario_UsuarioCreacion,DateTime Operacion_CierreDiario_FechaCreacion,Int64 Operacion_CierreDiario_UsuarioModificacion,DateTime Operacion_CierreDiario_FechaModificacion,Int64 Valor_OrigenValor_Id,String Valor_OrigenValor_Nombre,String Valor_OrigenValor_Descripcion,String Valor_OrigenValor_CodigoExterno) 
			{
			  return (Entities.Views.Integracion.OperacionTransaccion)base.Add(new Entities.Views.Integracion.OperacionTransaccion(Operacion_Transaccion_Id,Operacion_Transaccion_TipoId,Operacion_Transaccion_DepositarioId,Operacion_Transaccion_SectorId,Operacion_Transaccion_SucursalId,Operacion_Transaccion_MonedaId,Operacion_Transaccion_UsuarioId,Operacion_Transaccion_CuentaId,Operacion_Transaccion_ContenedorId,Operacion_Transaccion_SesionId,Operacion_Transaccion_TurnoId,Operacion_Transaccion_CierreDiarioId,Operacion_Transaccion_TotalValidado,Operacion_Transaccion_TotalAValidar,Operacion_Transaccion_Fecha,Operacion_Transaccion_Finalizada,Operacion_Transaccion_EsDepositoAutomatico,Operacion_Transaccion_OrigenValorId,Operacion_Transaccion_CodigoOperacion,Operacion_Transaccion_FechaCreacion,Operacion_Transaccion_FechaModificacion,Operacion_Transaccion_UsuarioCreacion,Operacion_Transaccion_UsuarioModificacion,Operacion_TipoTransaccion_Id,Operacion_TipoTransaccion_Nombre,Operacion_TipoTransaccion_Descripcion,Dispositivo_Depositario_Id,Dispositivo_Depositario_Nombre,Dispositivo_Depositario_Descripcion,Dispositivo_Depositario_SectorId,Dispositivo_Depositario_NumeroSerie,Dispositivo_Depositario_CodigoExterno,Directorio_Sector_Id,Directorio_Sector_SucursalId,Directorio_Sector_Nombre,Directorio_Sector_Descripcion,Directorio_Sector_CodigoExterno,Directorio_Sucursal_Id,Directorio_Sucursal_Nombre,Directorio_Sucursal_Descripcion,Directorio_Sucursal_EmpresaId,Directorio_Sucursal_CodigoExterno,Directorio_Sucursal_Direccion,Directorio_Sucursal_CodigoPostalId,Directorio_Sucursal_ZonaId,Valor_Moneda_Id,Valor_Moneda_Nombre,Valor_Moneda_PaisId,Valor_Moneda_Codigo,Valor_Moneda_Simbolo,Valor_Moneda_CodigoExterno,Seguridad_Usuario_Id,Seguridad_Usuario_EmpresaId,Seguridad_Usuario_LenguajeId,Seguridad_Usuario_PerfilId,Seguridad_Usuario_Nombre,Seguridad_Usuario_Apellido,Seguridad_Usuario_NombreApellido,Seguridad_Usuario_Documento,Seguridad_Usuario_Legajo,Seguridad_Usuario_CodigoExterno,Banca_Cuenta_Id,Banca_Cuenta_TipoId,Banca_Cuenta_EmpresaId,Banca_Cuenta_Nombre,Banca_Cuenta_Numero,Banca_Cuenta_Alias,Banca_Cuenta_CBU,Banca_Cuenta_BancoId,Banca_Cuenta_SucursalBancaria,Banca_Cuenta_CodigoExterno,Operacion_Contenedor_Id,Operacion_Contenedor_Nombre,Operacion_Contenedor_DepositarioId,Operacion_Contenedor_TipoId,Operacion_Contenedor_Identificador,Operacion_Contenedor_FechaApertura,Operacion_Contenedor_FechaCierre,Operacion_Sesion_Id,Operacion_Sesion_UsuarioId,Operacion_Sesion_FechaInicio,Operacion_Sesion_FechaCierre,Operacion_Sesion_EsCierreAutomatico,Operacion_Turno_Id,Operacion_Turno_TurnoDepositarioId,Operacion_Turno_DepositarioId,Operacion_Turno_SectorId,Operacion_Turno_FechaApertura,Operacion_Turno_FechaCierre,Operacion_Turno_Fecha,Operacion_Turno_Secuencia,Operacion_Turno_CierreDiarioId,Operacion_Turno_Observaciones,Operacion_Turno_CodigoTurno,Operacion_CierreDiario_Id,Operacion_CierreDiario_Nombre,Operacion_CierreDiario_Fecha,Operacion_CierreDiario_DepositarioId,Operacion_CierreDiario_SesionId,Operacion_CierreDiario_CodigoCierre,Operacion_CierreDiario_UsuarioCreacion,Operacion_CierreDiario_FechaCreacion,Operacion_CierreDiario_UsuarioModificacion,Operacion_CierreDiario_FechaModificacion,Valor_OrigenValor_Id,Valor_OrigenValor_Nombre,Valor_OrigenValor_Descripcion,Valor_OrigenValor_CodigoExterno));
			}
            public new List<Entities.Views.Integracion.OperacionTransaccion> Items()
            {
                this.WhereParameter = this.Where;
                this.OrderByParameter = this.OrderBy.orderByParameter;
                this.GroupByParameter = this.GroupBy.groupByParameter;
                this.TopQuantity = this.TopQuantity;
                base.AnalizeIDataItem();
                _entities = base.Items().Cast<Entities.Views.Integracion.OperacionTransaccion>().ToList<Entities.Views.Integracion.OperacionTransaccion>();
                return _entities;
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Views.Integracion.OperacionTransaccion> Result
            {
                get{return _entities;}
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="Operacion_Transaccion_Id"></param>
            /// <param name="Operacion_Transaccion_TipoId"></param>
            /// <param name="Operacion_Transaccion_DepositarioId"></param>
            /// <param name="Operacion_Transaccion_SectorId"></param>
            /// <param name="Operacion_Transaccion_SucursalId"></param>
            /// <param name="Operacion_Transaccion_MonedaId"></param>
            /// <param name="Operacion_Transaccion_UsuarioId"></param>
            /// <param name="Operacion_Transaccion_CuentaId"></param>
            /// <param name="Operacion_Transaccion_ContenedorId"></param>
            /// <param name="Operacion_Transaccion_SesionId"></param>
            /// <param name="Operacion_Transaccion_TurnoId"></param>
            /// <param name="Operacion_Transaccion_CierreDiarioId"></param>
            /// <param name="Operacion_Transaccion_TotalValidado"></param>
            /// <param name="Operacion_Transaccion_TotalAValidar"></param>
            /// <param name="Operacion_Transaccion_Fecha"></param>
            /// <param name="Operacion_Transaccion_Finalizada"></param>
            /// <param name="Operacion_Transaccion_EsDepositoAutomatico"></param>
            /// <param name="Operacion_Transaccion_OrigenValorId"></param>
            /// <param name="Operacion_Transaccion_CodigoOperacion"></param>
            /// <param name="Operacion_Transaccion_FechaCreacion"></param>
            /// <param name="Operacion_Transaccion_FechaModificacion"></param>
            /// <param name="Operacion_Transaccion_UsuarioCreacion"></param>
            /// <param name="Operacion_Transaccion_UsuarioModificacion"></param>
            /// <param name="Operacion_TipoTransaccion_Id"></param>
            /// <param name="Operacion_TipoTransaccion_Nombre"></param>
            /// <param name="Operacion_TipoTransaccion_Descripcion"></param>
            /// <param name="Dispositivo_Depositario_Id"></param>
            /// <param name="Dispositivo_Depositario_Nombre"></param>
            /// <param name="Dispositivo_Depositario_Descripcion"></param>
            /// <param name="Dispositivo_Depositario_SectorId"></param>
            /// <param name="Dispositivo_Depositario_NumeroSerie"></param>
            /// <param name="Dispositivo_Depositario_CodigoExterno"></param>
            /// <param name="Directorio_Sector_Id"></param>
            /// <param name="Directorio_Sector_SucursalId"></param>
            /// <param name="Directorio_Sector_Nombre"></param>
            /// <param name="Directorio_Sector_Descripcion"></param>
            /// <param name="Directorio_Sector_CodigoExterno"></param>
            /// <param name="Directorio_Sucursal_Id"></param>
            /// <param name="Directorio_Sucursal_Nombre"></param>
            /// <param name="Directorio_Sucursal_Descripcion"></param>
            /// <param name="Directorio_Sucursal_EmpresaId"></param>
            /// <param name="Directorio_Sucursal_CodigoExterno"></param>
            /// <param name="Directorio_Sucursal_Direccion"></param>
            /// <param name="Directorio_Sucursal_CodigoPostalId"></param>
            /// <param name="Directorio_Sucursal_ZonaId"></param>
            /// <param name="Valor_Moneda_Id"></param>
            /// <param name="Valor_Moneda_Nombre"></param>
            /// <param name="Valor_Moneda_PaisId"></param>
            /// <param name="Valor_Moneda_Codigo"></param>
            /// <param name="Valor_Moneda_Simbolo"></param>
            /// <param name="Valor_Moneda_CodigoExterno"></param>
            /// <param name="Seguridad_Usuario_Id"></param>
            /// <param name="Seguridad_Usuario_EmpresaId"></param>
            /// <param name="Seguridad_Usuario_LenguajeId"></param>
            /// <param name="Seguridad_Usuario_PerfilId"></param>
            /// <param name="Seguridad_Usuario_Nombre"></param>
            /// <param name="Seguridad_Usuario_Apellido"></param>
            /// <param name="Seguridad_Usuario_NombreApellido"></param>
            /// <param name="Seguridad_Usuario_Documento"></param>
            /// <param name="Seguridad_Usuario_Legajo"></param>
            /// <param name="Seguridad_Usuario_CodigoExterno"></param>
            /// <param name="Banca_Cuenta_Id"></param>
            /// <param name="Banca_Cuenta_TipoId"></param>
            /// <param name="Banca_Cuenta_EmpresaId"></param>
            /// <param name="Banca_Cuenta_Nombre"></param>
            /// <param name="Banca_Cuenta_Numero"></param>
            /// <param name="Banca_Cuenta_Alias"></param>
            /// <param name="Banca_Cuenta_CBU"></param>
            /// <param name="Banca_Cuenta_BancoId"></param>
            /// <param name="Banca_Cuenta_SucursalBancaria"></param>
            /// <param name="Banca_Cuenta_CodigoExterno"></param>
            /// <param name="Operacion_Contenedor_Id"></param>
            /// <param name="Operacion_Contenedor_Nombre"></param>
            /// <param name="Operacion_Contenedor_DepositarioId"></param>
            /// <param name="Operacion_Contenedor_TipoId"></param>
            /// <param name="Operacion_Contenedor_Identificador"></param>
            /// <param name="Operacion_Contenedor_FechaApertura"></param>
            /// <param name="Operacion_Contenedor_FechaCierre"></param>
            /// <param name="Operacion_Sesion_Id"></param>
            /// <param name="Operacion_Sesion_UsuarioId"></param>
            /// <param name="Operacion_Sesion_FechaInicio"></param>
            /// <param name="Operacion_Sesion_FechaCierre"></param>
            /// <param name="Operacion_Sesion_EsCierreAutomatico"></param>
            /// <param name="Operacion_Turno_Id"></param>
            /// <param name="Operacion_Turno_TurnoDepositarioId"></param>
            /// <param name="Operacion_Turno_DepositarioId"></param>
            /// <param name="Operacion_Turno_SectorId"></param>
            /// <param name="Operacion_Turno_FechaApertura"></param>
            /// <param name="Operacion_Turno_FechaCierre"></param>
            /// <param name="Operacion_Turno_Fecha"></param>
            /// <param name="Operacion_Turno_Secuencia"></param>
            /// <param name="Operacion_Turno_CierreDiarioId"></param>
            /// <param name="Operacion_Turno_Observaciones"></param>
            /// <param name="Operacion_Turno_CodigoTurno"></param>
            /// <param name="Operacion_CierreDiario_Id"></param>
            /// <param name="Operacion_CierreDiario_Nombre"></param>
            /// <param name="Operacion_CierreDiario_Fecha"></param>
            /// <param name="Operacion_CierreDiario_DepositarioId"></param>
            /// <param name="Operacion_CierreDiario_SesionId"></param>
            /// <param name="Operacion_CierreDiario_CodigoCierre"></param>
            /// <param name="Operacion_CierreDiario_UsuarioCreacion"></param>
            /// <param name="Operacion_CierreDiario_FechaCreacion"></param>
            /// <param name="Operacion_CierreDiario_UsuarioModificacion"></param>
            /// <param name="Operacion_CierreDiario_FechaModificacion"></param>
            /// <param name="Valor_OrigenValor_Id"></param>
            /// <param name="Valor_OrigenValor_Nombre"></param>
            /// <param name="Valor_OrigenValor_Descripcion"></param>
            /// <param name="Valor_OrigenValor_CodigoExterno"></param>
            /// <returns></returns>
            public List<Entities.Views.Integracion.OperacionTransaccion> Items(Int64? Operacion_Transaccion_Id,Int64? Operacion_Transaccion_TipoId,Int64? Operacion_Transaccion_DepositarioId,Int64? Operacion_Transaccion_SectorId,Int64? Operacion_Transaccion_SucursalId,Int64? Operacion_Transaccion_MonedaId,Int64? Operacion_Transaccion_UsuarioId,Int64? Operacion_Transaccion_CuentaId,Int64? Operacion_Transaccion_ContenedorId,Int64? Operacion_Transaccion_SesionId,Int64? Operacion_Transaccion_TurnoId,Int64? Operacion_Transaccion_CierreDiarioId,Double? Operacion_Transaccion_TotalValidado,Double? Operacion_Transaccion_TotalAValidar,DateTime? Operacion_Transaccion_Fecha,Boolean? Operacion_Transaccion_Finalizada,Boolean? Operacion_Transaccion_EsDepositoAutomatico,Int64? Operacion_Transaccion_OrigenValorId,String Operacion_Transaccion_CodigoOperacion,DateTime? Operacion_Transaccion_FechaCreacion,DateTime? Operacion_Transaccion_FechaModificacion,Int64? Operacion_Transaccion_UsuarioCreacion,Int64? Operacion_Transaccion_UsuarioModificacion,Int64? Operacion_TipoTransaccion_Id,String Operacion_TipoTransaccion_Nombre,String Operacion_TipoTransaccion_Descripcion,Int64? Dispositivo_Depositario_Id,String Dispositivo_Depositario_Nombre,String Dispositivo_Depositario_Descripcion,Int64? Dispositivo_Depositario_SectorId,String Dispositivo_Depositario_NumeroSerie,String Dispositivo_Depositario_CodigoExterno,Int64? Directorio_Sector_Id,Int64? Directorio_Sector_SucursalId,String Directorio_Sector_Nombre,String Directorio_Sector_Descripcion,String Directorio_Sector_CodigoExterno,Int64? Directorio_Sucursal_Id,String Directorio_Sucursal_Nombre,String Directorio_Sucursal_Descripcion,Int64? Directorio_Sucursal_EmpresaId,String Directorio_Sucursal_CodigoExterno,String Directorio_Sucursal_Direccion,Int64? Directorio_Sucursal_CodigoPostalId,Int64? Directorio_Sucursal_ZonaId,Int64? Valor_Moneda_Id,String Valor_Moneda_Nombre,Int64? Valor_Moneda_PaisId,String Valor_Moneda_Codigo,String Valor_Moneda_Simbolo,String Valor_Moneda_CodigoExterno,Int64? Seguridad_Usuario_Id,Int64? Seguridad_Usuario_EmpresaId,Int64? Seguridad_Usuario_LenguajeId,Int64? Seguridad_Usuario_PerfilId,String Seguridad_Usuario_Nombre,String Seguridad_Usuario_Apellido,String Seguridad_Usuario_NombreApellido,String Seguridad_Usuario_Documento,String Seguridad_Usuario_Legajo,String Seguridad_Usuario_CodigoExterno,Int64? Banca_Cuenta_Id,Int64? Banca_Cuenta_TipoId,Int64? Banca_Cuenta_EmpresaId,String Banca_Cuenta_Nombre,String Banca_Cuenta_Numero,String Banca_Cuenta_Alias,String Banca_Cuenta_CBU,Int64? Banca_Cuenta_BancoId,String Banca_Cuenta_SucursalBancaria,String Banca_Cuenta_CodigoExterno,Int64? Operacion_Contenedor_Id,String Operacion_Contenedor_Nombre,Int64? Operacion_Contenedor_DepositarioId,Int64? Operacion_Contenedor_TipoId,String Operacion_Contenedor_Identificador,DateTime? Operacion_Contenedor_FechaApertura,DateTime? Operacion_Contenedor_FechaCierre,Int64? Operacion_Sesion_Id,Int64? Operacion_Sesion_UsuarioId,DateTime? Operacion_Sesion_FechaInicio,DateTime? Operacion_Sesion_FechaCierre,Boolean? Operacion_Sesion_EsCierreAutomatico,Int64? Operacion_Turno_Id,Int64? Operacion_Turno_TurnoDepositarioId,Int64? Operacion_Turno_DepositarioId,Int64? Operacion_Turno_SectorId,DateTime? Operacion_Turno_FechaApertura,DateTime? Operacion_Turno_FechaCierre,DateTime? Operacion_Turno_Fecha,Int32? Operacion_Turno_Secuencia,Int64? Operacion_Turno_CierreDiarioId,String Operacion_Turno_Observaciones,String Operacion_Turno_CodigoTurno,Int64? Operacion_CierreDiario_Id,String Operacion_CierreDiario_Nombre,DateTime? Operacion_CierreDiario_Fecha,Int64? Operacion_CierreDiario_DepositarioId,Int64? Operacion_CierreDiario_SesionId,String Operacion_CierreDiario_CodigoCierre,Int64? Operacion_CierreDiario_UsuarioCreacion,DateTime? Operacion_CierreDiario_FechaCreacion,Int64? Operacion_CierreDiario_UsuarioModificacion,DateTime? Operacion_CierreDiario_FechaModificacion,Int64? Valor_OrigenValor_Id,String Valor_OrigenValor_Nombre,String Valor_OrigenValor_Descripcion,String Valor_OrigenValor_CodigoExterno)
            {
                this.Where.Clear();
                if (Operacion_Transaccion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Id);
                    }
                   
                }
                if (Operacion_Transaccion_TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_TipoId);
                    }
                   
                }
                if (Operacion_Transaccion_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_DepositarioId);
                    }
                   
                }
                if (Operacion_Transaccion_SectorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_SectorId);
                    }
                   
                }
                if (Operacion_Transaccion_SucursalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_SucursalId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_SucursalId);
                    }
                   
                }
                if (Operacion_Transaccion_MonedaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_MonedaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_MonedaId);
                    }
                   
                }
                if (Operacion_Transaccion_UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_UsuarioId);
                    }
                   
                }
                if (Operacion_Transaccion_CuentaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_CuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_CuentaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_CuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_CuentaId);
                    }
                   
                }
                if (Operacion_Transaccion_ContenedorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_ContenedorId);
                    }
                   
                }
                if (Operacion_Transaccion_SesionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_SesionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_SesionId);
                    }
                   
                }
                if (Operacion_Transaccion_TurnoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_TurnoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_TurnoId);
                    }
                   
                }
                if (Operacion_Transaccion_CierreDiarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_CierreDiarioId);
                    }
                   
                }
                if (Operacion_Transaccion_TotalValidado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_TotalValidado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_TotalValidado);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_TotalValidado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_TotalValidado);
                    }
                   
                }
                if (Operacion_Transaccion_TotalAValidar != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_TotalAValidar, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_TotalAValidar);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_TotalAValidar, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_TotalAValidar);
                    }
                   
                }
                if (Operacion_Transaccion_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Fecha);
                    }
                   
                }
                if (Operacion_Transaccion_Finalizada != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_Finalizada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Finalizada);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_Finalizada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Finalizada);
                    }
                   
                }
                if (Operacion_Transaccion_EsDepositoAutomatico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_EsDepositoAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_EsDepositoAutomatico);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_EsDepositoAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_EsDepositoAutomatico);
                    }
                   
                }
                if (Operacion_Transaccion_OrigenValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_OrigenValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_OrigenValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_OrigenValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_OrigenValorId);
                    }
                   
                }
                if (Operacion_Transaccion_CodigoOperacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_CodigoOperacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_CodigoOperacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_CodigoOperacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_CodigoOperacion);
                    }
                   
                }
                if (Operacion_Transaccion_FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_FechaCreacion);
                    }
                   
                }
                if (Operacion_Transaccion_FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_FechaModificacion);
                    }
                   
                }
                if (Operacion_Transaccion_UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_UsuarioCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_UsuarioCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_UsuarioCreacion);
                    }
                   
                }
                if (Operacion_Transaccion_UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_UsuarioModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_UsuarioModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_UsuarioModificacion);
                    }
                   
                }
                if (Operacion_TipoTransaccion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TipoTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TipoTransaccion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TipoTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TipoTransaccion_Id);
                    }
                   
                }
                if (Operacion_TipoTransaccion_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TipoTransaccion_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TipoTransaccion_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TipoTransaccion_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TipoTransaccion_Nombre);
                    }
                   
                }
                if (Operacion_TipoTransaccion_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TipoTransaccion_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TipoTransaccion_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TipoTransaccion_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TipoTransaccion_Descripcion);
                    }
                   
                }
                if (Dispositivo_Depositario_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Dispositivo_Depositario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Dispositivo_Depositario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_Id);
                    }
                   
                }
                if (Dispositivo_Depositario_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Dispositivo_Depositario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Dispositivo_Depositario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_Nombre);
                    }
                   
                }
                if (Dispositivo_Depositario_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Dispositivo_Depositario_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Dispositivo_Depositario_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_Descripcion);
                    }
                   
                }
                if (Dispositivo_Depositario_SectorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Dispositivo_Depositario_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Dispositivo_Depositario_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_SectorId);
                    }
                   
                }
                if (Dispositivo_Depositario_NumeroSerie != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Dispositivo_Depositario_NumeroSerie, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_NumeroSerie);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Dispositivo_Depositario_NumeroSerie, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_NumeroSerie);
                    }
                   
                }
                if (Dispositivo_Depositario_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Dispositivo_Depositario_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Dispositivo_Depositario_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Dispositivo_Depositario_CodigoExterno);
                    }
                   
                }
                if (Directorio_Sector_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sector_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sector_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_Id);
                    }
                   
                }
                if (Directorio_Sector_SucursalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sector_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_SucursalId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sector_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_SucursalId);
                    }
                   
                }
                if (Directorio_Sector_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sector_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sector_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_Nombre);
                    }
                   
                }
                if (Directorio_Sector_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sector_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sector_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_Descripcion);
                    }
                   
                }
                if (Directorio_Sector_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sector_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sector_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sector_CodigoExterno);
                    }
                   
                }
                if (Directorio_Sucursal_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sucursal_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sucursal_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_Id);
                    }
                   
                }
                if (Directorio_Sucursal_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sucursal_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sucursal_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_Nombre);
                    }
                   
                }
                if (Directorio_Sucursal_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sucursal_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sucursal_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_Descripcion);
                    }
                   
                }
                if (Directorio_Sucursal_EmpresaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sucursal_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sucursal_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_EmpresaId);
                    }
                   
                }
                if (Directorio_Sucursal_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sucursal_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sucursal_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_CodigoExterno);
                    }
                   
                }
                if (Directorio_Sucursal_Direccion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sucursal_Direccion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_Direccion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sucursal_Direccion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_Direccion);
                    }
                   
                }
                if (Directorio_Sucursal_CodigoPostalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sucursal_CodigoPostalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_CodigoPostalId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sucursal_CodigoPostalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_CodigoPostalId);
                    }
                   
                }
                if (Directorio_Sucursal_ZonaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Directorio_Sucursal_ZonaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_ZonaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Directorio_Sucursal_ZonaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Directorio_Sucursal_ZonaId);
                    }
                   
                }
                if (Valor_Moneda_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Moneda_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Moneda_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_Id);
                    }
                   
                }
                if (Valor_Moneda_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Moneda_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Moneda_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_Nombre);
                    }
                   
                }
                if (Valor_Moneda_PaisId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Moneda_PaisId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_PaisId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Moneda_PaisId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_PaisId);
                    }
                   
                }
                if (Valor_Moneda_Codigo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Moneda_Codigo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_Codigo);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Moneda_Codigo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_Codigo);
                    }
                   
                }
                if (Valor_Moneda_Simbolo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Moneda_Simbolo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_Simbolo);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Moneda_Simbolo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_Simbolo);
                    }
                   
                }
                if (Valor_Moneda_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Moneda_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Moneda_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Moneda_CodigoExterno);
                    }
                   
                }
                if (Seguridad_Usuario_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Id);
                    }
                   
                }
                if (Seguridad_Usuario_EmpresaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_EmpresaId);
                    }
                   
                }
                if (Seguridad_Usuario_LenguajeId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_LenguajeId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_LenguajeId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_LenguajeId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_LenguajeId);
                    }
                   
                }
                if (Seguridad_Usuario_PerfilId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_PerfilId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_PerfilId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_PerfilId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_PerfilId);
                    }
                   
                }
                if (Seguridad_Usuario_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Nombre);
                    }
                   
                }
                if (Seguridad_Usuario_Apellido != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_Apellido, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Apellido);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_Apellido, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Apellido);
                    }
                   
                }
                if (Seguridad_Usuario_NombreApellido != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_NombreApellido, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_NombreApellido);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_NombreApellido, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_NombreApellido);
                    }
                   
                }
                if (Seguridad_Usuario_Documento != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_Documento, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Documento);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_Documento, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Documento);
                    }
                   
                }
                if (Seguridad_Usuario_Legajo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_Legajo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Legajo);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_Legajo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_Legajo);
                    }
                   
                }
                if (Seguridad_Usuario_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Seguridad_Usuario_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Seguridad_Usuario_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Seguridad_Usuario_CodigoExterno);
                    }
                   
                }
                if (Banca_Cuenta_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_Id);
                    }
                   
                }
                if (Banca_Cuenta_TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_TipoId);
                    }
                   
                }
                if (Banca_Cuenta_EmpresaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_EmpresaId);
                    }
                   
                }
                if (Banca_Cuenta_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_Nombre);
                    }
                   
                }
                if (Banca_Cuenta_Numero != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_Numero, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_Numero);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_Numero, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_Numero);
                    }
                   
                }
                if (Banca_Cuenta_Alias != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_Alias, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_Alias);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_Alias, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_Alias);
                    }
                   
                }
                if (Banca_Cuenta_CBU != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_CBU, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_CBU);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_CBU, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_CBU);
                    }
                   
                }
                if (Banca_Cuenta_BancoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_BancoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_BancoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_BancoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_BancoId);
                    }
                   
                }
                if (Banca_Cuenta_SucursalBancaria != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_SucursalBancaria, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_SucursalBancaria);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_SucursalBancaria, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_SucursalBancaria);
                    }
                   
                }
                if (Banca_Cuenta_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Banca_Cuenta_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Banca_Cuenta_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Banca_Cuenta_CodigoExterno);
                    }
                   
                }
                if (Operacion_Contenedor_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Contenedor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Contenedor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_Id);
                    }
                   
                }
                if (Operacion_Contenedor_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Contenedor_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Contenedor_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_Nombre);
                    }
                   
                }
                if (Operacion_Contenedor_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Contenedor_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Contenedor_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_DepositarioId);
                    }
                   
                }
                if (Operacion_Contenedor_TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Contenedor_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Contenedor_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_TipoId);
                    }
                   
                }
                if (Operacion_Contenedor_Identificador != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Contenedor_Identificador, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_Identificador);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Contenedor_Identificador, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_Identificador);
                    }
                   
                }
                if (Operacion_Contenedor_FechaApertura != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Contenedor_FechaApertura, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_FechaApertura);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Contenedor_FechaApertura, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_FechaApertura);
                    }
                   
                }
                if (Operacion_Contenedor_FechaCierre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Contenedor_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_FechaCierre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Contenedor_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Contenedor_FechaCierre);
                    }
                   
                }
                if (Operacion_Sesion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Sesion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Sesion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_Id);
                    }
                   
                }
                if (Operacion_Sesion_UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Sesion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Sesion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_UsuarioId);
                    }
                   
                }
                if (Operacion_Sesion_FechaInicio != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Sesion_FechaInicio, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_FechaInicio);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Sesion_FechaInicio, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_FechaInicio);
                    }
                   
                }
                if (Operacion_Sesion_FechaCierre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Sesion_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_FechaCierre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Sesion_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_FechaCierre);
                    }
                   
                }
                if (Operacion_Sesion_EsCierreAutomatico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Sesion_EsCierreAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_EsCierreAutomatico);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Sesion_EsCierreAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Sesion_EsCierreAutomatico);
                    }
                   
                }
                if (Operacion_Turno_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_Id);
                    }
                   
                }
                if (Operacion_Turno_TurnoDepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_TurnoDepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_TurnoDepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_TurnoDepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_TurnoDepositarioId);
                    }
                   
                }
                if (Operacion_Turno_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_DepositarioId);
                    }
                   
                }
                if (Operacion_Turno_SectorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_SectorId);
                    }
                   
                }
                if (Operacion_Turno_FechaApertura != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_FechaApertura, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_FechaApertura);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_FechaApertura, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_FechaApertura);
                    }
                   
                }
                if (Operacion_Turno_FechaCierre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_FechaCierre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_FechaCierre);
                    }
                   
                }
                if (Operacion_Turno_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_Fecha);
                    }
                   
                }
                if (Operacion_Turno_Secuencia != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_Secuencia, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_Secuencia);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_Secuencia, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_Secuencia);
                    }
                   
                }
                if (Operacion_Turno_CierreDiarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_CierreDiarioId);
                    }
                   
                }
                if (Operacion_Turno_Observaciones != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_Observaciones, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_Observaciones);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_Observaciones, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_Observaciones);
                    }
                   
                }
                if (Operacion_Turno_CodigoTurno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Turno_CodigoTurno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_CodigoTurno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Turno_CodigoTurno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Turno_CodigoTurno);
                    }
                   
                }
                if (Operacion_CierreDiario_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_Id);
                    }
                   
                }
                if (Operacion_CierreDiario_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_Nombre);
                    }
                   
                }
                if (Operacion_CierreDiario_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_Fecha);
                    }
                   
                }
                if (Operacion_CierreDiario_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_DepositarioId);
                    }
                   
                }
                if (Operacion_CierreDiario_SesionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_SesionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_SesionId);
                    }
                   
                }
                if (Operacion_CierreDiario_CodigoCierre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_CodigoCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_CodigoCierre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_CodigoCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_CodigoCierre);
                    }
                   
                }
                if (Operacion_CierreDiario_UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_UsuarioCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_UsuarioCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_UsuarioCreacion);
                    }
                   
                }
                if (Operacion_CierreDiario_FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_FechaCreacion);
                    }
                   
                }
                if (Operacion_CierreDiario_UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_UsuarioModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_UsuarioModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_UsuarioModificacion);
                    }
                   
                }
                if (Operacion_CierreDiario_FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_CierreDiario_FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_CierreDiario_FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_CierreDiario_FechaModificacion);
                    }
                   
                }
                if (Valor_OrigenValor_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_OrigenValor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_OrigenValor_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_OrigenValor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_OrigenValor_Id);
                    }
                   
                }
                if (Valor_OrigenValor_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_OrigenValor_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_OrigenValor_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_OrigenValor_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_OrigenValor_Nombre);
                    }
                   
                }
                if (Valor_OrigenValor_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_OrigenValor_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_OrigenValor_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_OrigenValor_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_OrigenValor_Descripcion);
                    }
                   
                }
                if (Valor_OrigenValor_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_OrigenValor_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_OrigenValor_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_OrigenValor_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_OrigenValor_CodigoExterno);
                    }
                   
                }
                return this.Items();
            }
            public new IDataItem Add(IDataItem item)
            {
                DataHandler dh = new DataHandler(this._dataItem);
                return base.Add(item);
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(DepositaryWebApi.sqlEnum.ConjunctionEnum Conjunction)
                 {
                     base.AddConjunction(Conjunction);
                 }
                 public void OpenParentheses()
                 {
                     base.OpenParentheses();
                 }
                 public void CloseParentheses()
                 {
                     base.CloseParentheses();
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, DepositaryWebApi.sqlEnum.DirEnum direction = DepositaryWebApi.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
             public void Dispose()
             {
                 _cacheItemList = null;
                 Where = null;
                 OrderBy = null;
                 GroupBy = null;
                 Aggregate = null;
				
                 base.Dispose(true);
             }
        } // class OperacionTransaccion
	} //namespace DepositaryWebApi.Business.Views.Integracion
	namespace DepositaryWebApi.Business.Views.Integracion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class OperacionTransaccionDetalle : DataHandler
		{
				public enum ColumnEnum : int
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
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
         private List<Entities.Views.Integracion.OperacionTransaccionDetalle> _entities = new List<Entities.Views.Integracion.OperacionTransaccionDetalle>();
            public OperacionTransaccionDetalle() : base()
            {
                base._dataItem = new Entities.Views.Integracion.OperacionTransaccionDetalle();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public OperacionTransaccionDetalle(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Integracion.OperacionTransaccionDetalle();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(DepositaryWebApi.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Integracion.OperacionTransaccionDetalle item)
			{
				_cacheItemList.Add(item);
			}
			public void UpdateCache()
			{
                this.BeginTransaction();
				foreach(IDataItem item in _cacheItemList)
					base.Add(item);
				this.EndTransaction(true);
			}
			// Method that accepts arguments corresponding to fields (Those wich aren´t identity.)
			public Entities.Views.Integracion.OperacionTransaccionDetalle Add(Int64 Operacion_TransaccionDetalle_Id,Int64 Operacion_TransaccionDetalle_TransaccionId,Int64 Operacion_TransaccionDetalle_DenominacionId,Int64 Operacion_TransaccionDetalle_CantidadUnidades,DateTime Operacion_TransaccionDetalle_Fecha,Int64 Operacion_Transaccion_Id,Int64 Valor_Denominacion_Id,String Valor_Denominacion_Nombre,Int64 Valor_Denominacion_TipoValorId,Int64 Valor_Denominacion_MonedaId,Decimal Valor_Denominacion_Unidades,String Valor_Denominacion_CodigoCcTalk,String Valor_Denominacion_CodigoExterno) 
			{
			  return (Entities.Views.Integracion.OperacionTransaccionDetalle)base.Add(new Entities.Views.Integracion.OperacionTransaccionDetalle(Operacion_TransaccionDetalle_Id,Operacion_TransaccionDetalle_TransaccionId,Operacion_TransaccionDetalle_DenominacionId,Operacion_TransaccionDetalle_CantidadUnidades,Operacion_TransaccionDetalle_Fecha,Operacion_Transaccion_Id,Valor_Denominacion_Id,Valor_Denominacion_Nombre,Valor_Denominacion_TipoValorId,Valor_Denominacion_MonedaId,Valor_Denominacion_Unidades,Valor_Denominacion_CodigoCcTalk,Valor_Denominacion_CodigoExterno));
			}
            public new List<Entities.Views.Integracion.OperacionTransaccionDetalle> Items()
            {
                this.WhereParameter = this.Where;
                this.OrderByParameter = this.OrderBy.orderByParameter;
                this.GroupByParameter = this.GroupBy.groupByParameter;
                this.TopQuantity = this.TopQuantity;
                base.AnalizeIDataItem();
                _entities = base.Items().Cast<Entities.Views.Integracion.OperacionTransaccionDetalle>().ToList<Entities.Views.Integracion.OperacionTransaccionDetalle>();
                return _entities;
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Views.Integracion.OperacionTransaccionDetalle> Result
            {
                get{return _entities;}
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="Operacion_TransaccionDetalle_Id"></param>
            /// <param name="Operacion_TransaccionDetalle_TransaccionId"></param>
            /// <param name="Operacion_TransaccionDetalle_DenominacionId"></param>
            /// <param name="Operacion_TransaccionDetalle_CantidadUnidades"></param>
            /// <param name="Operacion_TransaccionDetalle_Fecha"></param>
            /// <param name="Operacion_Transaccion_Id"></param>
            /// <param name="Valor_Denominacion_Id"></param>
            /// <param name="Valor_Denominacion_Nombre"></param>
            /// <param name="Valor_Denominacion_TipoValorId"></param>
            /// <param name="Valor_Denominacion_MonedaId"></param>
            /// <param name="Valor_Denominacion_Unidades"></param>
            /// <param name="Valor_Denominacion_CodigoCcTalk"></param>
            /// <param name="Valor_Denominacion_CodigoExterno"></param>
            /// <returns></returns>
            public List<Entities.Views.Integracion.OperacionTransaccionDetalle> Items(Int64? Operacion_TransaccionDetalle_Id,Int64? Operacion_TransaccionDetalle_TransaccionId,Int64? Operacion_TransaccionDetalle_DenominacionId,Int64? Operacion_TransaccionDetalle_CantidadUnidades,DateTime? Operacion_TransaccionDetalle_Fecha,Int64? Operacion_Transaccion_Id,Int64? Valor_Denominacion_Id,String Valor_Denominacion_Nombre,Int64? Valor_Denominacion_TipoValorId,Int64? Valor_Denominacion_MonedaId,Decimal? Valor_Denominacion_Unidades,String Valor_Denominacion_CodigoCcTalk,String Valor_Denominacion_CodigoExterno)
            {
                this.Where.Clear();
                if (Operacion_TransaccionDetalle_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionDetalle_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionDetalle_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_Id);
                    }
                   
                }
                if (Operacion_TransaccionDetalle_TransaccionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionDetalle_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionDetalle_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_TransaccionId);
                    }
                   
                }
                if (Operacion_TransaccionDetalle_DenominacionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionDetalle_DenominacionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_DenominacionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionDetalle_DenominacionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_DenominacionId);
                    }
                   
                }
                if (Operacion_TransaccionDetalle_CantidadUnidades != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionDetalle_CantidadUnidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_CantidadUnidades);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionDetalle_CantidadUnidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_CantidadUnidades);
                    }
                   
                }
                if (Operacion_TransaccionDetalle_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionDetalle_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionDetalle_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionDetalle_Fecha);
                    }
                   
                }
                if (Operacion_Transaccion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Id);
                    }
                   
                }
                if (Valor_Denominacion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Denominacion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Denominacion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_Id);
                    }
                   
                }
                if (Valor_Denominacion_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Denominacion_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Denominacion_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_Nombre);
                    }
                   
                }
                if (Valor_Denominacion_TipoValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Denominacion_TipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_TipoValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Denominacion_TipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_TipoValorId);
                    }
                   
                }
                if (Valor_Denominacion_MonedaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Denominacion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_MonedaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Denominacion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_MonedaId);
                    }
                   
                }
                if (Valor_Denominacion_Unidades != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Denominacion_Unidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_Unidades);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Denominacion_Unidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_Unidades);
                    }
                   
                }
                if (Valor_Denominacion_CodigoCcTalk != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Denominacion_CodigoCcTalk, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_CodigoCcTalk);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Denominacion_CodigoCcTalk, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_CodigoCcTalk);
                    }
                   
                }
                if (Valor_Denominacion_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_Denominacion_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_Denominacion_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_Denominacion_CodigoExterno);
                    }
                   
                }
                return this.Items();
            }
            public new IDataItem Add(IDataItem item)
            {
                DataHandler dh = new DataHandler(this._dataItem);
                return base.Add(item);
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(DepositaryWebApi.sqlEnum.ConjunctionEnum Conjunction)
                 {
                     base.AddConjunction(Conjunction);
                 }
                 public void OpenParentheses()
                 {
                     base.OpenParentheses();
                 }
                 public void CloseParentheses()
                 {
                     base.CloseParentheses();
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, DepositaryWebApi.sqlEnum.DirEnum direction = DepositaryWebApi.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
             public void Dispose()
             {
                 _cacheItemList = null;
                 Where = null;
                 OrderBy = null;
                 GroupBy = null;
                 Aggregate = null;
				
                 base.Dispose(true);
             }
        } // class OperacionTransaccionDetalle
	} //namespace DepositaryWebApi.Business.Views.Integracion
	namespace DepositaryWebApi.Business.Views.Integracion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class OperacionTransaccionSobre : DataHandler
		{
				public enum ColumnEnum : int
                {
					Operacion_TransaccionSobre_Id,
					Operacion_TransaccionSobre_TransaccionId,
					Operacion_TransaccionSobre_CodigoSobre,
					Operacion_TransaccionSobre_Fecha,
					Operacion_Transaccion_Id
				}
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
         private List<Entities.Views.Integracion.OperacionTransaccionSobre> _entities = new List<Entities.Views.Integracion.OperacionTransaccionSobre>();
            public OperacionTransaccionSobre() : base()
            {
                base._dataItem = new Entities.Views.Integracion.OperacionTransaccionSobre();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public OperacionTransaccionSobre(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Integracion.OperacionTransaccionSobre();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(DepositaryWebApi.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Integracion.OperacionTransaccionSobre item)
			{
				_cacheItemList.Add(item);
			}
			public void UpdateCache()
			{
                this.BeginTransaction();
				foreach(IDataItem item in _cacheItemList)
					base.Add(item);
				this.EndTransaction(true);
			}
			// Method that accepts arguments corresponding to fields (Those wich aren´t identity.)
			public Entities.Views.Integracion.OperacionTransaccionSobre Add(Int64 Operacion_TransaccionSobre_Id,Int64 Operacion_TransaccionSobre_TransaccionId,String Operacion_TransaccionSobre_CodigoSobre,DateTime Operacion_TransaccionSobre_Fecha,Int64 Operacion_Transaccion_Id) 
			{
			  return (Entities.Views.Integracion.OperacionTransaccionSobre)base.Add(new Entities.Views.Integracion.OperacionTransaccionSobre(Operacion_TransaccionSobre_Id,Operacion_TransaccionSobre_TransaccionId,Operacion_TransaccionSobre_CodigoSobre,Operacion_TransaccionSobre_Fecha,Operacion_Transaccion_Id));
			}
            public new List<Entities.Views.Integracion.OperacionTransaccionSobre> Items()
            {
                this.WhereParameter = this.Where;
                this.OrderByParameter = this.OrderBy.orderByParameter;
                this.GroupByParameter = this.GroupBy.groupByParameter;
                this.TopQuantity = this.TopQuantity;
                base.AnalizeIDataItem();
                _entities = base.Items().Cast<Entities.Views.Integracion.OperacionTransaccionSobre>().ToList<Entities.Views.Integracion.OperacionTransaccionSobre>();
                return _entities;
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Views.Integracion.OperacionTransaccionSobre> Result
            {
                get{return _entities;}
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="Operacion_TransaccionSobre_Id"></param>
            /// <param name="Operacion_TransaccionSobre_TransaccionId"></param>
            /// <param name="Operacion_TransaccionSobre_CodigoSobre"></param>
            /// <param name="Operacion_TransaccionSobre_Fecha"></param>
            /// <param name="Operacion_Transaccion_Id"></param>
            /// <returns></returns>
            public List<Entities.Views.Integracion.OperacionTransaccionSobre> Items(Int64? Operacion_TransaccionSobre_Id,Int64? Operacion_TransaccionSobre_TransaccionId,String Operacion_TransaccionSobre_CodigoSobre,DateTime? Operacion_TransaccionSobre_Fecha,Int64? Operacion_Transaccion_Id)
            {
                this.Where.Clear();
                if (Operacion_TransaccionSobre_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobre_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobre_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_Id);
                    }
                   
                }
                if (Operacion_TransaccionSobre_TransaccionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobre_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobre_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_TransaccionId);
                    }
                   
                }
                if (Operacion_TransaccionSobre_CodigoSobre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobre_CodigoSobre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_CodigoSobre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobre_CodigoSobre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_CodigoSobre);
                    }
                   
                }
                if (Operacion_TransaccionSobre_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobre_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobre_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_Fecha);
                    }
                   
                }
                if (Operacion_Transaccion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_Transaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_Transaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_Transaccion_Id);
                    }
                   
                }
                return this.Items();
            }
            public new IDataItem Add(IDataItem item)
            {
                DataHandler dh = new DataHandler(this._dataItem);
                return base.Add(item);
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(DepositaryWebApi.sqlEnum.ConjunctionEnum Conjunction)
                 {
                     base.AddConjunction(Conjunction);
                 }
                 public void OpenParentheses()
                 {
                     base.OpenParentheses();
                 }
                 public void CloseParentheses()
                 {
                     base.CloseParentheses();
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, DepositaryWebApi.sqlEnum.DirEnum direction = DepositaryWebApi.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
             public void Dispose()
             {
                 _cacheItemList = null;
                 Where = null;
                 OrderBy = null;
                 GroupBy = null;
                 Aggregate = null;
				
                 base.Dispose(true);
             }
        } // class OperacionTransaccionSobre
	} //namespace DepositaryWebApi.Business.Views.Integracion
	namespace DepositaryWebApi.Business.Views.Integracion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class OperacionTransaccionSobreDetalle : DataHandler
		{
				public enum ColumnEnum : int
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
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
         private List<Entities.Views.Integracion.OperacionTransaccionSobreDetalle> _entities = new List<Entities.Views.Integracion.OperacionTransaccionSobreDetalle>();
            public OperacionTransaccionSobreDetalle() : base()
            {
                base._dataItem = new Entities.Views.Integracion.OperacionTransaccionSobreDetalle();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public OperacionTransaccionSobreDetalle(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Integracion.OperacionTransaccionSobreDetalle();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(DepositaryWebApi.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Integracion.OperacionTransaccionSobreDetalle item)
			{
				_cacheItemList.Add(item);
			}
			public void UpdateCache()
			{
                this.BeginTransaction();
				foreach(IDataItem item in _cacheItemList)
					base.Add(item);
				this.EndTransaction(true);
			}
			// Method that accepts arguments corresponding to fields (Those wich aren´t identity.)
			public Entities.Views.Integracion.OperacionTransaccionSobreDetalle Add(Int64 Operacion_TransaccionSobreDetalle_Id,Int64 Operacion_TransaccionSobreDetalle_SobreId,Int64 Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId,Int64 Operacion_TransaccionSobreDetalle_CantidadDeclarada,Double Operacion_TransaccionSobreDetalle_ValorDeclarado,DateTime Operacion_TransaccionSobreDetalle_Fecha,Int64 Operacion_TransaccionSobre_Id,Int64 Operacion_TransaccionSobre_TransaccionId,String Operacion_TransaccionSobre_CodigoSobre,DateTime Operacion_TransaccionSobre_Fecha,Int64 Valor_RelacionMonedaTipoValor_Id,Int64 Valor_RelacionMonedaTipoValor_MonedaId,Int64 Valor_RelacionMonedaTipoValor_TipoValorId,Boolean Valor_RelacionMonedaTipoValor_Habilitado,Int64 Valor_RelacionMonedaTipoValor_UsuarioCreacion,DateTime Valor_RelacionMonedaTipoValor_FechaCreacion,Int64 Valor_RelacionMonedaTipoValor_UsuarioModificacion,DateTime Valor_RelacionMonedaTipoValor_FechaModificacion) 
			{
			  return (Entities.Views.Integracion.OperacionTransaccionSobreDetalle)base.Add(new Entities.Views.Integracion.OperacionTransaccionSobreDetalle(Operacion_TransaccionSobreDetalle_Id,Operacion_TransaccionSobreDetalle_SobreId,Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId,Operacion_TransaccionSobreDetalle_CantidadDeclarada,Operacion_TransaccionSobreDetalle_ValorDeclarado,Operacion_TransaccionSobreDetalle_Fecha,Operacion_TransaccionSobre_Id,Operacion_TransaccionSobre_TransaccionId,Operacion_TransaccionSobre_CodigoSobre,Operacion_TransaccionSobre_Fecha,Valor_RelacionMonedaTipoValor_Id,Valor_RelacionMonedaTipoValor_MonedaId,Valor_RelacionMonedaTipoValor_TipoValorId,Valor_RelacionMonedaTipoValor_Habilitado,Valor_RelacionMonedaTipoValor_UsuarioCreacion,Valor_RelacionMonedaTipoValor_FechaCreacion,Valor_RelacionMonedaTipoValor_UsuarioModificacion,Valor_RelacionMonedaTipoValor_FechaModificacion));
			}
            public new List<Entities.Views.Integracion.OperacionTransaccionSobreDetalle> Items()
            {
                this.WhereParameter = this.Where;
                this.OrderByParameter = this.OrderBy.orderByParameter;
                this.GroupByParameter = this.GroupBy.groupByParameter;
                this.TopQuantity = this.TopQuantity;
                base.AnalizeIDataItem();
                _entities = base.Items().Cast<Entities.Views.Integracion.OperacionTransaccionSobreDetalle>().ToList<Entities.Views.Integracion.OperacionTransaccionSobreDetalle>();
                return _entities;
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Views.Integracion.OperacionTransaccionSobreDetalle> Result
            {
                get{return _entities;}
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="Operacion_TransaccionSobreDetalle_Id"></param>
            /// <param name="Operacion_TransaccionSobreDetalle_SobreId"></param>
            /// <param name="Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId"></param>
            /// <param name="Operacion_TransaccionSobreDetalle_CantidadDeclarada"></param>
            /// <param name="Operacion_TransaccionSobreDetalle_ValorDeclarado"></param>
            /// <param name="Operacion_TransaccionSobreDetalle_Fecha"></param>
            /// <param name="Operacion_TransaccionSobre_Id"></param>
            /// <param name="Operacion_TransaccionSobre_TransaccionId"></param>
            /// <param name="Operacion_TransaccionSobre_CodigoSobre"></param>
            /// <param name="Operacion_TransaccionSobre_Fecha"></param>
            /// <param name="Valor_RelacionMonedaTipoValor_Id"></param>
            /// <param name="Valor_RelacionMonedaTipoValor_MonedaId"></param>
            /// <param name="Valor_RelacionMonedaTipoValor_TipoValorId"></param>
            /// <param name="Valor_RelacionMonedaTipoValor_Habilitado"></param>
            /// <param name="Valor_RelacionMonedaTipoValor_UsuarioCreacion"></param>
            /// <param name="Valor_RelacionMonedaTipoValor_FechaCreacion"></param>
            /// <param name="Valor_RelacionMonedaTipoValor_UsuarioModificacion"></param>
            /// <param name="Valor_RelacionMonedaTipoValor_FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Views.Integracion.OperacionTransaccionSobreDetalle> Items(Int64? Operacion_TransaccionSobreDetalle_Id,Int64? Operacion_TransaccionSobreDetalle_SobreId,Int64? Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId,Int64? Operacion_TransaccionSobreDetalle_CantidadDeclarada,Double? Operacion_TransaccionSobreDetalle_ValorDeclarado,DateTime? Operacion_TransaccionSobreDetalle_Fecha,Int64? Operacion_TransaccionSobre_Id,Int64? Operacion_TransaccionSobre_TransaccionId,String Operacion_TransaccionSobre_CodigoSobre,DateTime? Operacion_TransaccionSobre_Fecha,Int64? Valor_RelacionMonedaTipoValor_Id,Int64? Valor_RelacionMonedaTipoValor_MonedaId,Int64? Valor_RelacionMonedaTipoValor_TipoValorId,Boolean? Valor_RelacionMonedaTipoValor_Habilitado,Int64? Valor_RelacionMonedaTipoValor_UsuarioCreacion,DateTime? Valor_RelacionMonedaTipoValor_FechaCreacion,Int64? Valor_RelacionMonedaTipoValor_UsuarioModificacion,DateTime? Valor_RelacionMonedaTipoValor_FechaModificacion)
            {
                this.Where.Clear();
                if (Operacion_TransaccionSobreDetalle_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobreDetalle_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobreDetalle_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_Id);
                    }
                   
                }
                if (Operacion_TransaccionSobreDetalle_SobreId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobreDetalle_SobreId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_SobreId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobreDetalle_SobreId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_SobreId);
                    }
                   
                }
                if (Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_RelacionMonedaTipoValorId);
                    }
                   
                }
                if (Operacion_TransaccionSobreDetalle_CantidadDeclarada != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobreDetalle_CantidadDeclarada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_CantidadDeclarada);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobreDetalle_CantidadDeclarada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_CantidadDeclarada);
                    }
                   
                }
                if (Operacion_TransaccionSobreDetalle_ValorDeclarado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobreDetalle_ValorDeclarado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_ValorDeclarado);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobreDetalle_ValorDeclarado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_ValorDeclarado);
                    }
                   
                }
                if (Operacion_TransaccionSobreDetalle_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobreDetalle_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobreDetalle_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobreDetalle_Fecha);
                    }
                   
                }
                if (Operacion_TransaccionSobre_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobre_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobre_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_Id);
                    }
                   
                }
                if (Operacion_TransaccionSobre_TransaccionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobre_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobre_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_TransaccionId);
                    }
                   
                }
                if (Operacion_TransaccionSobre_CodigoSobre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobre_CodigoSobre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_CodigoSobre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobre_CodigoSobre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_CodigoSobre);
                    }
                   
                }
                if (Operacion_TransaccionSobre_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Operacion_TransaccionSobre_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Operacion_TransaccionSobre_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Operacion_TransaccionSobre_Fecha);
                    }
                   
                }
                if (Valor_RelacionMonedaTipoValor_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_RelacionMonedaTipoValor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_RelacionMonedaTipoValor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_Id);
                    }
                   
                }
                if (Valor_RelacionMonedaTipoValor_MonedaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_RelacionMonedaTipoValor_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_MonedaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_RelacionMonedaTipoValor_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_MonedaId);
                    }
                   
                }
                if (Valor_RelacionMonedaTipoValor_TipoValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_RelacionMonedaTipoValor_TipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_TipoValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_RelacionMonedaTipoValor_TipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_TipoValorId);
                    }
                   
                }
                if (Valor_RelacionMonedaTipoValor_Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_RelacionMonedaTipoValor_Habilitado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_Habilitado);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_RelacionMonedaTipoValor_Habilitado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_Habilitado);
                    }
                   
                }
                if (Valor_RelacionMonedaTipoValor_UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_RelacionMonedaTipoValor_UsuarioCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_RelacionMonedaTipoValor_UsuarioCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_UsuarioCreacion);
                    }
                   
                }
                if (Valor_RelacionMonedaTipoValor_FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_RelacionMonedaTipoValor_FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_RelacionMonedaTipoValor_FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_FechaCreacion);
                    }
                   
                }
                if (Valor_RelacionMonedaTipoValor_UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_RelacionMonedaTipoValor_UsuarioModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_RelacionMonedaTipoValor_UsuarioModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_UsuarioModificacion);
                    }
                   
                }
                if (Valor_RelacionMonedaTipoValor_FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor_RelacionMonedaTipoValor_FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor_RelacionMonedaTipoValor_FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Valor_RelacionMonedaTipoValor_FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public new IDataItem Add(IDataItem item)
            {
                DataHandler dh = new DataHandler(this._dataItem);
                return base.Add(item);
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(DepositaryWebApi.sqlEnum.ConjunctionEnum Conjunction)
                 {
                     base.AddConjunction(Conjunction);
                 }
                 public void OpenParentheses()
                 {
                     base.OpenParentheses();
                 }
                 public void CloseParentheses()
                 {
                     base.CloseParentheses();
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, DepositaryWebApi.sqlEnum.DirEnum direction = DepositaryWebApi.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
             public void Dispose()
             {
                 _cacheItemList = null;
                 Where = null;
                 OrderBy = null;
                 GroupBy = null;
                 Aggregate = null;
				
                 base.Dispose(true);
             }
        } // class OperacionTransaccionSobreDetalle
	} //namespace DepositaryWebApi.Business.Views.Integracion
