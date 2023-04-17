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
			public Entities.Views.Integracion.OperacionTransaccion Add(Int64 OperacionTransaccion_Id,Int64 OperacionTransaccion_TipoId,Int64 OperacionTransaccion_DepositarioId,Int64 OperacionTransaccion_SectorId,Int64 OperacionTransaccion_SucursalId,Int64 OperacionTransaccion_MonedaId,Int64 OperacionTransaccion_UsuarioId,Int64 OperacionTransaccion_CuentaId,Int64 OperacionTransaccion_ContenedorId,Int64 OperacionTransaccion_SesionId,Int64 OperacionTransaccion_TurnoId,Int64 OperacionTransaccion_CierreDiarioId,Double OperacionTransaccion_TotalValidado,Double OperacionTransaccion_TotalAValidar,DateTime OperacionTransaccion_Fecha,Boolean OperacionTransaccion_Finalizada,Boolean OperacionTransaccion_EsDepositoAutomatico,Int64 OperacionTransaccion_OrigenValorId,String OperacionTransaccion_CodigoOperacion,DateTime OperacionTransaccion_FechaCreacion,Int64 OperacionTipoTransaccion_Id,String OperacionTipoTransaccion_Nombre,String OperacionTipoTransaccion_Descripcion,Int64 DispositivoDepositario_Id,String DispositivoDepositario_Nombre,String DispositivoDepositario_Descripcion,Int64 DispositivoDepositario_SectorId,String DispositivoDepositario_NumeroSerie,String DispositivoDepositario_CodigoExterno,Int64 DirectorioSector_Id,Int64 DirectorioSector_SucursalId,String DirectorioSector_Nombre,String DirectorioSector_Descripcion,String DirectorioSector_CodigoExterno,Int64 DirectorioSucursal_Id,String DirectorioSucursal_Nombre,String DirectorioSucursal_Descripcion,Int64 DirectorioSucursal_EmpresaId,String DirectorioSucursal_CodigoExterno,String DirectorioSucursal_Direccion,Int64 DirectorioSucursal_CodigoPostalId,Int64 DirectorioSucursal_ZonaId,Int64 ValorMoneda_Id,String ValorMoneda_Nombre,Int64 ValorMoneda_PaisId,String ValorMoneda_Codigo,String ValorMoneda_Simbolo,String ValorMoneda_CodigoExterno,Int64 SeguridadUsuario_Id,Int64 SeguridadUsuario_EmpresaId,String SeguridadUsuario_NickName,String SeguridadUsuario_CodigoExterno,Int64 BancaCuenta_Id,Int64 BancaCuenta_TipoId,Int64 BancaCuenta_EmpresaId,String BancaCuenta_Nombre,String BancaCuenta_Numero,String BancaCuenta_Alias,String BancaCuenta_CBU,Int64 BancaCuenta_BancoId,String BancaCuenta_SucursalBancaria,String BancaCuenta_CodigoExterno,Int64 OperacionContenedor_Id,String OperacionContenedor_Nombre,Int64 OperacionContenedor_DepositarioId,Int64 OperacionContenedor_TipoId,String OperacionContenedor_Identificador,DateTime OperacionContenedor_FechaApertura,DateTime OperacionContenedor_FechaCierre,Int64 OperacionSesion_Id,Int64 OperacionSesion_DepositarioId,Int64 OperacionSesion_UsuarioId,DateTime OperacionSesion_FechaInicio,DateTime OperacionSesion_FechaCierre,Boolean OperacionSesion_EsCierreAutomatico,Int64 OperacionTurno_Id,Int64 OperacionTurno_TurnoDepositarioId,Int64 OperacionTurno_DepositarioId,Int64 OperacionTurno_SectorId,DateTime OperacionTurno_FechaApertura,DateTime OperacionTurno_FechaCierre,DateTime OperacionTurno_Fecha,Int32 OperacionTurno_Secuencia,Int64 OperacionTurno_CierreDiarioId,String OperacionTurno_Observaciones,String OperacionTurno_CodigoTurno,Int64 OperacionCierreDiario_Id,String OperacionCierreDiario_Nombre,DateTime OperacionCierreDiario_Fecha,Int64 OperacionCierreDiario_DepositarioId,Int64 OperacionCierreDiario_SesionId,String OperacionCierreDiario_CodigoCierre,Int64 ValorOrigenValor_Id,String ValorOrigenValor_Nombre,String ValorOrigenValor_Descripcion,Int64 ValorOrigenValor_EmpresaId,String ValorOrigenValor_CodigoExterno) 
			{
			  return (Entities.Views.Integracion.OperacionTransaccion)base.Add(new Entities.Views.Integracion.OperacionTransaccion(OperacionTransaccion_Id,OperacionTransaccion_TipoId,OperacionTransaccion_DepositarioId,OperacionTransaccion_SectorId,OperacionTransaccion_SucursalId,OperacionTransaccion_MonedaId,OperacionTransaccion_UsuarioId,OperacionTransaccion_CuentaId,OperacionTransaccion_ContenedorId,OperacionTransaccion_SesionId,OperacionTransaccion_TurnoId,OperacionTransaccion_CierreDiarioId,OperacionTransaccion_TotalValidado,OperacionTransaccion_TotalAValidar,OperacionTransaccion_Fecha,OperacionTransaccion_Finalizada,OperacionTransaccion_EsDepositoAutomatico,OperacionTransaccion_OrigenValorId,OperacionTransaccion_CodigoOperacion,OperacionTransaccion_FechaCreacion,OperacionTipoTransaccion_Id,OperacionTipoTransaccion_Nombre,OperacionTipoTransaccion_Descripcion,DispositivoDepositario_Id,DispositivoDepositario_Nombre,DispositivoDepositario_Descripcion,DispositivoDepositario_SectorId,DispositivoDepositario_NumeroSerie,DispositivoDepositario_CodigoExterno,DirectorioSector_Id,DirectorioSector_SucursalId,DirectorioSector_Nombre,DirectorioSector_Descripcion,DirectorioSector_CodigoExterno,DirectorioSucursal_Id,DirectorioSucursal_Nombre,DirectorioSucursal_Descripcion,DirectorioSucursal_EmpresaId,DirectorioSucursal_CodigoExterno,DirectorioSucursal_Direccion,DirectorioSucursal_CodigoPostalId,DirectorioSucursal_ZonaId,ValorMoneda_Id,ValorMoneda_Nombre,ValorMoneda_PaisId,ValorMoneda_Codigo,ValorMoneda_Simbolo,ValorMoneda_CodigoExterno,SeguridadUsuario_Id,SeguridadUsuario_EmpresaId,SeguridadUsuario_NickName,SeguridadUsuario_CodigoExterno,BancaCuenta_Id,BancaCuenta_TipoId,BancaCuenta_EmpresaId,BancaCuenta_Nombre,BancaCuenta_Numero,BancaCuenta_Alias,BancaCuenta_CBU,BancaCuenta_BancoId,BancaCuenta_SucursalBancaria,BancaCuenta_CodigoExterno,OperacionContenedor_Id,OperacionContenedor_Nombre,OperacionContenedor_DepositarioId,OperacionContenedor_TipoId,OperacionContenedor_Identificador,OperacionContenedor_FechaApertura,OperacionContenedor_FechaCierre,OperacionSesion_Id,OperacionSesion_DepositarioId,OperacionSesion_UsuarioId,OperacionSesion_FechaInicio,OperacionSesion_FechaCierre,OperacionSesion_EsCierreAutomatico,OperacionTurno_Id,OperacionTurno_TurnoDepositarioId,OperacionTurno_DepositarioId,OperacionTurno_SectorId,OperacionTurno_FechaApertura,OperacionTurno_FechaCierre,OperacionTurno_Fecha,OperacionTurno_Secuencia,OperacionTurno_CierreDiarioId,OperacionTurno_Observaciones,OperacionTurno_CodigoTurno,OperacionCierreDiario_Id,OperacionCierreDiario_Nombre,OperacionCierreDiario_Fecha,OperacionCierreDiario_DepositarioId,OperacionCierreDiario_SesionId,OperacionCierreDiario_CodigoCierre,ValorOrigenValor_Id,ValorOrigenValor_Nombre,ValorOrigenValor_Descripcion,ValorOrigenValor_EmpresaId,ValorOrigenValor_CodigoExterno));
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
            /// <param name="OperacionTransaccion_Id"></param>
            /// <param name="OperacionTransaccion_TipoId"></param>
            /// <param name="OperacionTransaccion_DepositarioId"></param>
            /// <param name="OperacionTransaccion_SectorId"></param>
            /// <param name="OperacionTransaccion_SucursalId"></param>
            /// <param name="OperacionTransaccion_MonedaId"></param>
            /// <param name="OperacionTransaccion_UsuarioId"></param>
            /// <param name="OperacionTransaccion_CuentaId"></param>
            /// <param name="OperacionTransaccion_ContenedorId"></param>
            /// <param name="OperacionTransaccion_SesionId"></param>
            /// <param name="OperacionTransaccion_TurnoId"></param>
            /// <param name="OperacionTransaccion_CierreDiarioId"></param>
            /// <param name="OperacionTransaccion_TotalValidado"></param>
            /// <param name="OperacionTransaccion_TotalAValidar"></param>
            /// <param name="OperacionTransaccion_Fecha"></param>
            /// <param name="OperacionTransaccion_Finalizada"></param>
            /// <param name="OperacionTransaccion_EsDepositoAutomatico"></param>
            /// <param name="OperacionTransaccion_OrigenValorId"></param>
            /// <param name="OperacionTransaccion_CodigoOperacion"></param>
            /// <param name="OperacionTransaccion_FechaCreacion"></param>
            /// <param name="OperacionTipoTransaccion_Id"></param>
            /// <param name="OperacionTipoTransaccion_Nombre"></param>
            /// <param name="OperacionTipoTransaccion_Descripcion"></param>
            /// <param name="DispositivoDepositario_Id"></param>
            /// <param name="DispositivoDepositario_Nombre"></param>
            /// <param name="DispositivoDepositario_Descripcion"></param>
            /// <param name="DispositivoDepositario_SectorId"></param>
            /// <param name="DispositivoDepositario_NumeroSerie"></param>
            /// <param name="DispositivoDepositario_CodigoExterno"></param>
            /// <param name="DirectorioSector_Id"></param>
            /// <param name="DirectorioSector_SucursalId"></param>
            /// <param name="DirectorioSector_Nombre"></param>
            /// <param name="DirectorioSector_Descripcion"></param>
            /// <param name="DirectorioSector_CodigoExterno"></param>
            /// <param name="DirectorioSucursal_Id"></param>
            /// <param name="DirectorioSucursal_Nombre"></param>
            /// <param name="DirectorioSucursal_Descripcion"></param>
            /// <param name="DirectorioSucursal_EmpresaId"></param>
            /// <param name="DirectorioSucursal_CodigoExterno"></param>
            /// <param name="DirectorioSucursal_Direccion"></param>
            /// <param name="DirectorioSucursal_CodigoPostalId"></param>
            /// <param name="DirectorioSucursal_ZonaId"></param>
            /// <param name="ValorMoneda_Id"></param>
            /// <param name="ValorMoneda_Nombre"></param>
            /// <param name="ValorMoneda_PaisId"></param>
            /// <param name="ValorMoneda_Codigo"></param>
            /// <param name="ValorMoneda_Simbolo"></param>
            /// <param name="ValorMoneda_CodigoExterno"></param>
            /// <param name="SeguridadUsuario_Id"></param>
            /// <param name="SeguridadUsuario_EmpresaId"></param>
            /// <param name="SeguridadUsuario_NickName"></param>
            /// <param name="SeguridadUsuario_CodigoExterno"></param>
            /// <param name="BancaCuenta_Id"></param>
            /// <param name="BancaCuenta_TipoId"></param>
            /// <param name="BancaCuenta_EmpresaId"></param>
            /// <param name="BancaCuenta_Nombre"></param>
            /// <param name="BancaCuenta_Numero"></param>
            /// <param name="BancaCuenta_Alias"></param>
            /// <param name="BancaCuenta_CBU"></param>
            /// <param name="BancaCuenta_BancoId"></param>
            /// <param name="BancaCuenta_SucursalBancaria"></param>
            /// <param name="BancaCuenta_CodigoExterno"></param>
            /// <param name="OperacionContenedor_Id"></param>
            /// <param name="OperacionContenedor_Nombre"></param>
            /// <param name="OperacionContenedor_DepositarioId"></param>
            /// <param name="OperacionContenedor_TipoId"></param>
            /// <param name="OperacionContenedor_Identificador"></param>
            /// <param name="OperacionContenedor_FechaApertura"></param>
            /// <param name="OperacionContenedor_FechaCierre"></param>
            /// <param name="OperacionSesion_Id"></param>
            /// <param name="OperacionSesion_DepositarioId"></param>
            /// <param name="OperacionSesion_UsuarioId"></param>
            /// <param name="OperacionSesion_FechaInicio"></param>
            /// <param name="OperacionSesion_FechaCierre"></param>
            /// <param name="OperacionSesion_EsCierreAutomatico"></param>
            /// <param name="OperacionTurno_Id"></param>
            /// <param name="OperacionTurno_TurnoDepositarioId"></param>
            /// <param name="OperacionTurno_DepositarioId"></param>
            /// <param name="OperacionTurno_SectorId"></param>
            /// <param name="OperacionTurno_FechaApertura"></param>
            /// <param name="OperacionTurno_FechaCierre"></param>
            /// <param name="OperacionTurno_Fecha"></param>
            /// <param name="OperacionTurno_Secuencia"></param>
            /// <param name="OperacionTurno_CierreDiarioId"></param>
            /// <param name="OperacionTurno_Observaciones"></param>
            /// <param name="OperacionTurno_CodigoTurno"></param>
            /// <param name="OperacionCierreDiario_Id"></param>
            /// <param name="OperacionCierreDiario_Nombre"></param>
            /// <param name="OperacionCierreDiario_Fecha"></param>
            /// <param name="OperacionCierreDiario_DepositarioId"></param>
            /// <param name="OperacionCierreDiario_SesionId"></param>
            /// <param name="OperacionCierreDiario_CodigoCierre"></param>
            /// <param name="ValorOrigenValor_Id"></param>
            /// <param name="ValorOrigenValor_Nombre"></param>
            /// <param name="ValorOrigenValor_Descripcion"></param>
            /// <param name="ValorOrigenValor_EmpresaId"></param>
            /// <param name="ValorOrigenValor_CodigoExterno"></param>
            /// <returns></returns>
            public List<Entities.Views.Integracion.OperacionTransaccion> Items(Int64? OperacionTransaccion_Id,Int64? OperacionTransaccion_TipoId,Int64? OperacionTransaccion_DepositarioId,Int64? OperacionTransaccion_SectorId,Int64? OperacionTransaccion_SucursalId,Int64? OperacionTransaccion_MonedaId,Int64? OperacionTransaccion_UsuarioId,Int64? OperacionTransaccion_CuentaId,Int64? OperacionTransaccion_ContenedorId,Int64? OperacionTransaccion_SesionId,Int64? OperacionTransaccion_TurnoId,Int64? OperacionTransaccion_CierreDiarioId,Double? OperacionTransaccion_TotalValidado,Double? OperacionTransaccion_TotalAValidar,DateTime? OperacionTransaccion_Fecha,Boolean? OperacionTransaccion_Finalizada,Boolean? OperacionTransaccion_EsDepositoAutomatico,Int64? OperacionTransaccion_OrigenValorId,String OperacionTransaccion_CodigoOperacion,DateTime? OperacionTransaccion_FechaCreacion,Int64? OperacionTipoTransaccion_Id,String OperacionTipoTransaccion_Nombre,String OperacionTipoTransaccion_Descripcion,Int64? DispositivoDepositario_Id,String DispositivoDepositario_Nombre,String DispositivoDepositario_Descripcion,Int64? DispositivoDepositario_SectorId,String DispositivoDepositario_NumeroSerie,String DispositivoDepositario_CodigoExterno,Int64? DirectorioSector_Id,Int64? DirectorioSector_SucursalId,String DirectorioSector_Nombre,String DirectorioSector_Descripcion,String DirectorioSector_CodigoExterno,Int64? DirectorioSucursal_Id,String DirectorioSucursal_Nombre,String DirectorioSucursal_Descripcion,Int64? DirectorioSucursal_EmpresaId,String DirectorioSucursal_CodigoExterno,String DirectorioSucursal_Direccion,Int64? DirectorioSucursal_CodigoPostalId,Int64? DirectorioSucursal_ZonaId,Int64? ValorMoneda_Id,String ValorMoneda_Nombre,Int64? ValorMoneda_PaisId,String ValorMoneda_Codigo,String ValorMoneda_Simbolo,String ValorMoneda_CodigoExterno,Int64? SeguridadUsuario_Id,Int64? SeguridadUsuario_EmpresaId,String SeguridadUsuario_NickName,String SeguridadUsuario_CodigoExterno,Int64? BancaCuenta_Id,Int64? BancaCuenta_TipoId,Int64? BancaCuenta_EmpresaId,String BancaCuenta_Nombre,String BancaCuenta_Numero,String BancaCuenta_Alias,String BancaCuenta_CBU,Int64? BancaCuenta_BancoId,String BancaCuenta_SucursalBancaria,String BancaCuenta_CodigoExterno,Int64? OperacionContenedor_Id,String OperacionContenedor_Nombre,Int64? OperacionContenedor_DepositarioId,Int64? OperacionContenedor_TipoId,String OperacionContenedor_Identificador,DateTime? OperacionContenedor_FechaApertura,DateTime? OperacionContenedor_FechaCierre,Int64? OperacionSesion_Id,Int64? OperacionSesion_DepositarioId,Int64? OperacionSesion_UsuarioId,DateTime? OperacionSesion_FechaInicio,DateTime? OperacionSesion_FechaCierre,Boolean? OperacionSesion_EsCierreAutomatico,Int64? OperacionTurno_Id,Int64? OperacionTurno_TurnoDepositarioId,Int64? OperacionTurno_DepositarioId,Int64? OperacionTurno_SectorId,DateTime? OperacionTurno_FechaApertura,DateTime? OperacionTurno_FechaCierre,DateTime? OperacionTurno_Fecha,Int32? OperacionTurno_Secuencia,Int64? OperacionTurno_CierreDiarioId,String OperacionTurno_Observaciones,String OperacionTurno_CodigoTurno,Int64? OperacionCierreDiario_Id,String OperacionCierreDiario_Nombre,DateTime? OperacionCierreDiario_Fecha,Int64? OperacionCierreDiario_DepositarioId,Int64? OperacionCierreDiario_SesionId,String OperacionCierreDiario_CodigoCierre,Int64? ValorOrigenValor_Id,String ValorOrigenValor_Nombre,String ValorOrigenValor_Descripcion,Int64? ValorOrigenValor_EmpresaId,String ValorOrigenValor_CodigoExterno)
            {
                this.Where.Clear();
                if (OperacionTransaccion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Id);
                    }
                   
                }
                if (OperacionTransaccion_TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TipoId);
                    }
                   
                }
                if (OperacionTransaccion_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_DepositarioId);
                    }
                   
                }
                if (OperacionTransaccion_SectorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SectorId);
                    }
                   
                }
                if (OperacionTransaccion_SucursalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SucursalId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SucursalId);
                    }
                   
                }
                if (OperacionTransaccion_MonedaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_MonedaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_MonedaId);
                    }
                   
                }
                if (OperacionTransaccion_UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_UsuarioId);
                    }
                   
                }
                if (OperacionTransaccion_CuentaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_CuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CuentaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_CuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CuentaId);
                    }
                   
                }
                if (OperacionTransaccion_ContenedorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_ContenedorId);
                    }
                   
                }
                if (OperacionTransaccion_SesionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SesionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SesionId);
                    }
                   
                }
                if (OperacionTransaccion_TurnoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TurnoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TurnoId);
                    }
                   
                }
                if (OperacionTransaccion_CierreDiarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CierreDiarioId);
                    }
                   
                }
                if (OperacionTransaccion_TotalValidado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TotalValidado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalValidado);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TotalValidado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalValidado);
                    }
                   
                }
                if (OperacionTransaccion_TotalAValidar != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TotalAValidar, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalAValidar);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TotalAValidar, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalAValidar);
                    }
                   
                }
                if (OperacionTransaccion_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Fecha);
                    }
                   
                }
                if (OperacionTransaccion_Finalizada != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_Finalizada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Finalizada);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_Finalizada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Finalizada);
                    }
                   
                }
                if (OperacionTransaccion_EsDepositoAutomatico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_EsDepositoAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_EsDepositoAutomatico);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_EsDepositoAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_EsDepositoAutomatico);
                    }
                   
                }
                if (OperacionTransaccion_OrigenValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_OrigenValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_OrigenValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_OrigenValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_OrigenValorId);
                    }
                   
                }
                if (OperacionTransaccion_CodigoOperacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_CodigoOperacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CodigoOperacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_CodigoOperacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CodigoOperacion);
                    }
                   
                }
                if (OperacionTransaccion_FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_FechaCreacion);
                    }
                   
                }
                if (OperacionTipoTransaccion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTipoTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTipoTransaccion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTipoTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTipoTransaccion_Id);
                    }
                   
                }
                if (OperacionTipoTransaccion_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTipoTransaccion_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTipoTransaccion_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTipoTransaccion_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTipoTransaccion_Nombre);
                    }
                   
                }
                if (OperacionTipoTransaccion_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTipoTransaccion_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTipoTransaccion_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTipoTransaccion_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTipoTransaccion_Descripcion);
                    }
                   
                }
                if (DispositivoDepositario_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DispositivoDepositario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DispositivoDepositario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_Id);
                    }
                   
                }
                if (DispositivoDepositario_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DispositivoDepositario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DispositivoDepositario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_Nombre);
                    }
                   
                }
                if (DispositivoDepositario_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DispositivoDepositario_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DispositivoDepositario_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_Descripcion);
                    }
                   
                }
                if (DispositivoDepositario_SectorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DispositivoDepositario_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DispositivoDepositario_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_SectorId);
                    }
                   
                }
                if (DispositivoDepositario_NumeroSerie != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DispositivoDepositario_NumeroSerie, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_NumeroSerie);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DispositivoDepositario_NumeroSerie, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_NumeroSerie);
                    }
                   
                }
                if (DispositivoDepositario_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DispositivoDepositario_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DispositivoDepositario_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DispositivoDepositario_CodigoExterno);
                    }
                   
                }
                if (DirectorioSector_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSector_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSector_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_Id);
                    }
                   
                }
                if (DirectorioSector_SucursalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSector_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_SucursalId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSector_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_SucursalId);
                    }
                   
                }
                if (DirectorioSector_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSector_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSector_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_Nombre);
                    }
                   
                }
                if (DirectorioSector_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSector_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSector_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_Descripcion);
                    }
                   
                }
                if (DirectorioSector_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSector_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSector_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSector_CodigoExterno);
                    }
                   
                }
                if (DirectorioSucursal_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSucursal_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSucursal_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_Id);
                    }
                   
                }
                if (DirectorioSucursal_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSucursal_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSucursal_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_Nombre);
                    }
                   
                }
                if (DirectorioSucursal_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSucursal_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSucursal_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_Descripcion);
                    }
                   
                }
                if (DirectorioSucursal_EmpresaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSucursal_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSucursal_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_EmpresaId);
                    }
                   
                }
                if (DirectorioSucursal_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSucursal_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSucursal_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_CodigoExterno);
                    }
                   
                }
                if (DirectorioSucursal_Direccion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSucursal_Direccion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_Direccion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSucursal_Direccion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_Direccion);
                    }
                   
                }
                if (DirectorioSucursal_CodigoPostalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSucursal_CodigoPostalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_CodigoPostalId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSucursal_CodigoPostalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_CodigoPostalId);
                    }
                   
                }
                if (DirectorioSucursal_ZonaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DirectorioSucursal_ZonaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_ZonaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DirectorioSucursal_ZonaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DirectorioSucursal_ZonaId);
                    }
                   
                }
                if (ValorMoneda_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorMoneda_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorMoneda_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_Id);
                    }
                   
                }
                if (ValorMoneda_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorMoneda_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorMoneda_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_Nombre);
                    }
                   
                }
                if (ValorMoneda_PaisId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorMoneda_PaisId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_PaisId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorMoneda_PaisId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_PaisId);
                    }
                   
                }
                if (ValorMoneda_Codigo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorMoneda_Codigo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_Codigo);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorMoneda_Codigo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_Codigo);
                    }
                   
                }
                if (ValorMoneda_Simbolo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorMoneda_Simbolo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_Simbolo);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorMoneda_Simbolo, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_Simbolo);
                    }
                   
                }
                if (ValorMoneda_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorMoneda_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorMoneda_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorMoneda_CodigoExterno);
                    }
                   
                }
                if (SeguridadUsuario_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SeguridadUsuario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SeguridadUsuario_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SeguridadUsuario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SeguridadUsuario_Id);
                    }
                   
                }
                if (SeguridadUsuario_EmpresaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SeguridadUsuario_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SeguridadUsuario_EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SeguridadUsuario_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SeguridadUsuario_EmpresaId);
                    }
                   
                }
                if (SeguridadUsuario_NickName != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SeguridadUsuario_NickName, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SeguridadUsuario_NickName);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SeguridadUsuario_NickName, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SeguridadUsuario_NickName);
                    }
                   
                }
                if (SeguridadUsuario_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SeguridadUsuario_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SeguridadUsuario_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SeguridadUsuario_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SeguridadUsuario_CodigoExterno);
                    }
                   
                }
                if (BancaCuenta_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_Id);
                    }
                   
                }
                if (BancaCuenta_TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_TipoId);
                    }
                   
                }
                if (BancaCuenta_EmpresaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_EmpresaId);
                    }
                   
                }
                if (BancaCuenta_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_Nombre);
                    }
                   
                }
                if (BancaCuenta_Numero != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_Numero, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_Numero);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_Numero, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_Numero);
                    }
                   
                }
                if (BancaCuenta_Alias != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_Alias, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_Alias);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_Alias, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_Alias);
                    }
                   
                }
                if (BancaCuenta_CBU != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_CBU, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_CBU);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_CBU, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_CBU);
                    }
                   
                }
                if (BancaCuenta_BancoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_BancoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_BancoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_BancoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_BancoId);
                    }
                   
                }
                if (BancaCuenta_SucursalBancaria != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_SucursalBancaria, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_SucursalBancaria);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_SucursalBancaria, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_SucursalBancaria);
                    }
                   
                }
                if (BancaCuenta_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancaCuenta_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancaCuenta_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, BancaCuenta_CodigoExterno);
                    }
                   
                }
                if (OperacionContenedor_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionContenedor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionContenedor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_Id);
                    }
                   
                }
                if (OperacionContenedor_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionContenedor_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionContenedor_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_Nombre);
                    }
                   
                }
                if (OperacionContenedor_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionContenedor_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionContenedor_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_DepositarioId);
                    }
                   
                }
                if (OperacionContenedor_TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionContenedor_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionContenedor_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_TipoId);
                    }
                   
                }
                if (OperacionContenedor_Identificador != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionContenedor_Identificador, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_Identificador);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionContenedor_Identificador, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_Identificador);
                    }
                   
                }
                if (OperacionContenedor_FechaApertura != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionContenedor_FechaApertura, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_FechaApertura);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionContenedor_FechaApertura, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_FechaApertura);
                    }
                   
                }
                if (OperacionContenedor_FechaCierre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionContenedor_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_FechaCierre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionContenedor_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionContenedor_FechaCierre);
                    }
                   
                }
                if (OperacionSesion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionSesion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionSesion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_Id);
                    }
                   
                }
                if (OperacionSesion_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionSesion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionSesion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_DepositarioId);
                    }
                   
                }
                if (OperacionSesion_UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionSesion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionSesion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_UsuarioId);
                    }
                   
                }
                if (OperacionSesion_FechaInicio != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionSesion_FechaInicio, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_FechaInicio);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionSesion_FechaInicio, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_FechaInicio);
                    }
                   
                }
                if (OperacionSesion_FechaCierre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionSesion_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_FechaCierre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionSesion_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_FechaCierre);
                    }
                   
                }
                if (OperacionSesion_EsCierreAutomatico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionSesion_EsCierreAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_EsCierreAutomatico);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionSesion_EsCierreAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionSesion_EsCierreAutomatico);
                    }
                   
                }
                if (OperacionTurno_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_Id);
                    }
                   
                }
                if (OperacionTurno_TurnoDepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_TurnoDepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_TurnoDepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_TurnoDepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_TurnoDepositarioId);
                    }
                   
                }
                if (OperacionTurno_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_DepositarioId);
                    }
                   
                }
                if (OperacionTurno_SectorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_SectorId);
                    }
                   
                }
                if (OperacionTurno_FechaApertura != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_FechaApertura, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_FechaApertura);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_FechaApertura, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_FechaApertura);
                    }
                   
                }
                if (OperacionTurno_FechaCierre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_FechaCierre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_FechaCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_FechaCierre);
                    }
                   
                }
                if (OperacionTurno_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_Fecha);
                    }
                   
                }
                if (OperacionTurno_Secuencia != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_Secuencia, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_Secuencia);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_Secuencia, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_Secuencia);
                    }
                   
                }
                if (OperacionTurno_CierreDiarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_CierreDiarioId);
                    }
                   
                }
                if (OperacionTurno_Observaciones != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_Observaciones, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_Observaciones);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_Observaciones, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_Observaciones);
                    }
                   
                }
                if (OperacionTurno_CodigoTurno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTurno_CodigoTurno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_CodigoTurno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTurno_CodigoTurno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTurno_CodigoTurno);
                    }
                   
                }
                if (OperacionCierreDiario_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionCierreDiario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionCierreDiario_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_Id);
                    }
                   
                }
                if (OperacionCierreDiario_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionCierreDiario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionCierreDiario_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_Nombre);
                    }
                   
                }
                if (OperacionCierreDiario_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionCierreDiario_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionCierreDiario_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_Fecha);
                    }
                   
                }
                if (OperacionCierreDiario_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionCierreDiario_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionCierreDiario_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_DepositarioId);
                    }
                   
                }
                if (OperacionCierreDiario_SesionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionCierreDiario_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_SesionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionCierreDiario_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_SesionId);
                    }
                   
                }
                if (OperacionCierreDiario_CodigoCierre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionCierreDiario_CodigoCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_CodigoCierre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionCierreDiario_CodigoCierre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionCierreDiario_CodigoCierre);
                    }
                   
                }
                if (ValorOrigenValor_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorOrigenValor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorOrigenValor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_Id);
                    }
                   
                }
                if (ValorOrigenValor_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorOrigenValor_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorOrigenValor_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_Nombre);
                    }
                   
                }
                if (ValorOrigenValor_Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorOrigenValor_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_Descripcion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorOrigenValor_Descripcion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_Descripcion);
                    }
                   
                }
                if (ValorOrigenValor_EmpresaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorOrigenValor_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorOrigenValor_EmpresaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_EmpresaId);
                    }
                   
                }
                if (ValorOrigenValor_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorOrigenValor_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorOrigenValor_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorOrigenValor_CodigoExterno);
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
			public Entities.Views.Integracion.OperacionTransaccionDetalle Add(Int64 OperacionTransaccionDetalle_Id,Int64 OperacionTransaccionDetalle_TransaccionId,Int64 OperacionTransaccionDetalle_DenominacionId,Int64 OperacionTransaccionDetalle_CantidadUnidades,DateTime OperacionTransaccionDetalle_Fecha,Int64 OperacionTransaccion_Id,Int64 OperacionTransaccion_TipoId,Int64 OperacionTransaccion_DepositarioId,Int64 OperacionTransaccion_SectorId,Int64 OperacionTransaccion_SucursalId,Int64 OperacionTransaccion_MonedaId,Int64 OperacionTransaccion_UsuarioId,Int64 OperacionTransaccion_CuentaId,Int64 OperacionTransaccion_ContenedorId,Int64 OperacionTransaccion_SesionId,Int64 OperacionTransaccion_TurnoId,Int64 OperacionTransaccion_CierreDiarioId,Double OperacionTransaccion_TotalValidado,Double OperacionTransaccion_TotalAValidar,DateTime OperacionTransaccion_Fecha,Boolean OperacionTransaccion_Finalizada,Boolean OperacionTransaccion_EsDepositoAutomatico,Int64 OperacionTransaccion_OrigenValorId,Int64 ValorDenominacion_Id,String ValorDenominacion_Nombre,Int64 ValorDenominacion_TipoValorId,Int64 ValorDenominacion_MonedaId,Decimal ValorDenominacion_Unidades,String ValorDenominacion_CodigoCcTalk,String ValorDenominacion_CodigoExterno) 
			{
			  return (Entities.Views.Integracion.OperacionTransaccionDetalle)base.Add(new Entities.Views.Integracion.OperacionTransaccionDetalle(OperacionTransaccionDetalle_Id,OperacionTransaccionDetalle_TransaccionId,OperacionTransaccionDetalle_DenominacionId,OperacionTransaccionDetalle_CantidadUnidades,OperacionTransaccionDetalle_Fecha,OperacionTransaccion_Id,OperacionTransaccion_TipoId,OperacionTransaccion_DepositarioId,OperacionTransaccion_SectorId,OperacionTransaccion_SucursalId,OperacionTransaccion_MonedaId,OperacionTransaccion_UsuarioId,OperacionTransaccion_CuentaId,OperacionTransaccion_ContenedorId,OperacionTransaccion_SesionId,OperacionTransaccion_TurnoId,OperacionTransaccion_CierreDiarioId,OperacionTransaccion_TotalValidado,OperacionTransaccion_TotalAValidar,OperacionTransaccion_Fecha,OperacionTransaccion_Finalizada,OperacionTransaccion_EsDepositoAutomatico,OperacionTransaccion_OrigenValorId,ValorDenominacion_Id,ValorDenominacion_Nombre,ValorDenominacion_TipoValorId,ValorDenominacion_MonedaId,ValorDenominacion_Unidades,ValorDenominacion_CodigoCcTalk,ValorDenominacion_CodigoExterno));
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
            /// <param name="OperacionTransaccionDetalle_Id"></param>
            /// <param name="OperacionTransaccionDetalle_TransaccionId"></param>
            /// <param name="OperacionTransaccionDetalle_DenominacionId"></param>
            /// <param name="OperacionTransaccionDetalle_CantidadUnidades"></param>
            /// <param name="OperacionTransaccionDetalle_Fecha"></param>
            /// <param name="OperacionTransaccion_Id"></param>
            /// <param name="OperacionTransaccion_TipoId"></param>
            /// <param name="OperacionTransaccion_DepositarioId"></param>
            /// <param name="OperacionTransaccion_SectorId"></param>
            /// <param name="OperacionTransaccion_SucursalId"></param>
            /// <param name="OperacionTransaccion_MonedaId"></param>
            /// <param name="OperacionTransaccion_UsuarioId"></param>
            /// <param name="OperacionTransaccion_CuentaId"></param>
            /// <param name="OperacionTransaccion_ContenedorId"></param>
            /// <param name="OperacionTransaccion_SesionId"></param>
            /// <param name="OperacionTransaccion_TurnoId"></param>
            /// <param name="OperacionTransaccion_CierreDiarioId"></param>
            /// <param name="OperacionTransaccion_TotalValidado"></param>
            /// <param name="OperacionTransaccion_TotalAValidar"></param>
            /// <param name="OperacionTransaccion_Fecha"></param>
            /// <param name="OperacionTransaccion_Finalizada"></param>
            /// <param name="OperacionTransaccion_EsDepositoAutomatico"></param>
            /// <param name="OperacionTransaccion_OrigenValorId"></param>
            /// <param name="ValorDenominacion_Id"></param>
            /// <param name="ValorDenominacion_Nombre"></param>
            /// <param name="ValorDenominacion_TipoValorId"></param>
            /// <param name="ValorDenominacion_MonedaId"></param>
            /// <param name="ValorDenominacion_Unidades"></param>
            /// <param name="ValorDenominacion_CodigoCcTalk"></param>
            /// <param name="ValorDenominacion_CodigoExterno"></param>
            /// <returns></returns>
            public List<Entities.Views.Integracion.OperacionTransaccionDetalle> Items(Int64? OperacionTransaccionDetalle_Id,Int64? OperacionTransaccionDetalle_TransaccionId,Int64? OperacionTransaccionDetalle_DenominacionId,Int64? OperacionTransaccionDetalle_CantidadUnidades,DateTime? OperacionTransaccionDetalle_Fecha,Int64? OperacionTransaccion_Id,Int64? OperacionTransaccion_TipoId,Int64? OperacionTransaccion_DepositarioId,Int64? OperacionTransaccion_SectorId,Int64? OperacionTransaccion_SucursalId,Int64? OperacionTransaccion_MonedaId,Int64? OperacionTransaccion_UsuarioId,Int64? OperacionTransaccion_CuentaId,Int64? OperacionTransaccion_ContenedorId,Int64? OperacionTransaccion_SesionId,Int64? OperacionTransaccion_TurnoId,Int64? OperacionTransaccion_CierreDiarioId,Double? OperacionTransaccion_TotalValidado,Double? OperacionTransaccion_TotalAValidar,DateTime? OperacionTransaccion_Fecha,Boolean? OperacionTransaccion_Finalizada,Boolean? OperacionTransaccion_EsDepositoAutomatico,Int64? OperacionTransaccion_OrigenValorId,Int64? ValorDenominacion_Id,String ValorDenominacion_Nombre,Int64? ValorDenominacion_TipoValorId,Int64? ValorDenominacion_MonedaId,Decimal? ValorDenominacion_Unidades,String ValorDenominacion_CodigoCcTalk,String ValorDenominacion_CodigoExterno)
            {
                this.Where.Clear();
                if (OperacionTransaccionDetalle_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionDetalle_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionDetalle_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_Id);
                    }
                   
                }
                if (OperacionTransaccionDetalle_TransaccionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionDetalle_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionDetalle_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_TransaccionId);
                    }
                   
                }
                if (OperacionTransaccionDetalle_DenominacionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionDetalle_DenominacionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_DenominacionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionDetalle_DenominacionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_DenominacionId);
                    }
                   
                }
                if (OperacionTransaccionDetalle_CantidadUnidades != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionDetalle_CantidadUnidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_CantidadUnidades);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionDetalle_CantidadUnidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_CantidadUnidades);
                    }
                   
                }
                if (OperacionTransaccionDetalle_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionDetalle_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionDetalle_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionDetalle_Fecha);
                    }
                   
                }
                if (OperacionTransaccion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Id);
                    }
                   
                }
                if (OperacionTransaccion_TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TipoId);
                    }
                   
                }
                if (OperacionTransaccion_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_DepositarioId);
                    }
                   
                }
                if (OperacionTransaccion_SectorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SectorId);
                    }
                   
                }
                if (OperacionTransaccion_SucursalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SucursalId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SucursalId);
                    }
                   
                }
                if (OperacionTransaccion_MonedaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_MonedaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_MonedaId);
                    }
                   
                }
                if (OperacionTransaccion_UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_UsuarioId);
                    }
                   
                }
                if (OperacionTransaccion_CuentaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_CuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CuentaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_CuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CuentaId);
                    }
                   
                }
                if (OperacionTransaccion_ContenedorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_ContenedorId);
                    }
                   
                }
                if (OperacionTransaccion_SesionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SesionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SesionId);
                    }
                   
                }
                if (OperacionTransaccion_TurnoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TurnoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TurnoId);
                    }
                   
                }
                if (OperacionTransaccion_CierreDiarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CierreDiarioId);
                    }
                   
                }
                if (OperacionTransaccion_TotalValidado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TotalValidado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalValidado);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TotalValidado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalValidado);
                    }
                   
                }
                if (OperacionTransaccion_TotalAValidar != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TotalAValidar, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalAValidar);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TotalAValidar, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalAValidar);
                    }
                   
                }
                if (OperacionTransaccion_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Fecha);
                    }
                   
                }
                if (OperacionTransaccion_Finalizada != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_Finalizada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Finalizada);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_Finalizada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Finalizada);
                    }
                   
                }
                if (OperacionTransaccion_EsDepositoAutomatico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_EsDepositoAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_EsDepositoAutomatico);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_EsDepositoAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_EsDepositoAutomatico);
                    }
                   
                }
                if (OperacionTransaccion_OrigenValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_OrigenValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_OrigenValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_OrigenValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_OrigenValorId);
                    }
                   
                }
                if (ValorDenominacion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorDenominacion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorDenominacion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_Id);
                    }
                   
                }
                if (ValorDenominacion_Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorDenominacion_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorDenominacion_Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_Nombre);
                    }
                   
                }
                if (ValorDenominacion_TipoValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorDenominacion_TipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_TipoValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorDenominacion_TipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_TipoValorId);
                    }
                   
                }
                if (ValorDenominacion_MonedaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorDenominacion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_MonedaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorDenominacion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_MonedaId);
                    }
                   
                }
                if (ValorDenominacion_Unidades != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorDenominacion_Unidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_Unidades);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorDenominacion_Unidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_Unidades);
                    }
                   
                }
                if (ValorDenominacion_CodigoCcTalk != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorDenominacion_CodigoCcTalk, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_CodigoCcTalk);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorDenominacion_CodigoCcTalk, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_CodigoCcTalk);
                    }
                   
                }
                if (ValorDenominacion_CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorDenominacion_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorDenominacion_CodigoExterno, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorDenominacion_CodigoExterno);
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
			public Entities.Views.Integracion.OperacionTransaccionSobre Add(Int64 OperacionTransaccionSobre_Id,Int64 OperacionTransaccionSobre_TransaccionId,String OperacionTransaccionSobre_CodigoSobre,DateTime OperacionTransaccionSobre_Fecha,Int64 OperacionTransaccion_Id,Int64 OperacionTransaccion_TipoId,Int64 OperacionTransaccion_DepositarioId,Int64 OperacionTransaccion_SectorId,Int64 OperacionTransaccion_SucursalId,Int64 OperacionTransaccion_MonedaId,Int64 OperacionTransaccion_UsuarioId,Int64 OperacionTransaccion_CuentaId,Int64 OperacionTransaccion_ContenedorId,Int64 OperacionTransaccion_SesionId,Int64 OperacionTransaccion_TurnoId,Int64 OperacionTransaccion_CierreDiarioId,Double OperacionTransaccion_TotalValidado,Double OperacionTransaccion_TotalAValidar,DateTime OperacionTransaccion_Fecha,Boolean OperacionTransaccion_Finalizada,Boolean OperacionTransaccion_EsDepositoAutomatico,Int64 OperacionTransaccion_OrigenValorId,String OperacionTransaccion_CodigoOperacion) 
			{
			  return (Entities.Views.Integracion.OperacionTransaccionSobre)base.Add(new Entities.Views.Integracion.OperacionTransaccionSobre(OperacionTransaccionSobre_Id,OperacionTransaccionSobre_TransaccionId,OperacionTransaccionSobre_CodigoSobre,OperacionTransaccionSobre_Fecha,OperacionTransaccion_Id,OperacionTransaccion_TipoId,OperacionTransaccion_DepositarioId,OperacionTransaccion_SectorId,OperacionTransaccion_SucursalId,OperacionTransaccion_MonedaId,OperacionTransaccion_UsuarioId,OperacionTransaccion_CuentaId,OperacionTransaccion_ContenedorId,OperacionTransaccion_SesionId,OperacionTransaccion_TurnoId,OperacionTransaccion_CierreDiarioId,OperacionTransaccion_TotalValidado,OperacionTransaccion_TotalAValidar,OperacionTransaccion_Fecha,OperacionTransaccion_Finalizada,OperacionTransaccion_EsDepositoAutomatico,OperacionTransaccion_OrigenValorId,OperacionTransaccion_CodigoOperacion));
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
            /// <param name="OperacionTransaccionSobre_Id"></param>
            /// <param name="OperacionTransaccionSobre_TransaccionId"></param>
            /// <param name="OperacionTransaccionSobre_CodigoSobre"></param>
            /// <param name="OperacionTransaccionSobre_Fecha"></param>
            /// <param name="OperacionTransaccion_Id"></param>
            /// <param name="OperacionTransaccion_TipoId"></param>
            /// <param name="OperacionTransaccion_DepositarioId"></param>
            /// <param name="OperacionTransaccion_SectorId"></param>
            /// <param name="OperacionTransaccion_SucursalId"></param>
            /// <param name="OperacionTransaccion_MonedaId"></param>
            /// <param name="OperacionTransaccion_UsuarioId"></param>
            /// <param name="OperacionTransaccion_CuentaId"></param>
            /// <param name="OperacionTransaccion_ContenedorId"></param>
            /// <param name="OperacionTransaccion_SesionId"></param>
            /// <param name="OperacionTransaccion_TurnoId"></param>
            /// <param name="OperacionTransaccion_CierreDiarioId"></param>
            /// <param name="OperacionTransaccion_TotalValidado"></param>
            /// <param name="OperacionTransaccion_TotalAValidar"></param>
            /// <param name="OperacionTransaccion_Fecha"></param>
            /// <param name="OperacionTransaccion_Finalizada"></param>
            /// <param name="OperacionTransaccion_EsDepositoAutomatico"></param>
            /// <param name="OperacionTransaccion_OrigenValorId"></param>
            /// <param name="OperacionTransaccion_CodigoOperacion"></param>
            /// <returns></returns>
            public List<Entities.Views.Integracion.OperacionTransaccionSobre> Items(Int64? OperacionTransaccionSobre_Id,Int64? OperacionTransaccionSobre_TransaccionId,String OperacionTransaccionSobre_CodigoSobre,DateTime? OperacionTransaccionSobre_Fecha,Int64? OperacionTransaccion_Id,Int64? OperacionTransaccion_TipoId,Int64? OperacionTransaccion_DepositarioId,Int64? OperacionTransaccion_SectorId,Int64? OperacionTransaccion_SucursalId,Int64? OperacionTransaccion_MonedaId,Int64? OperacionTransaccion_UsuarioId,Int64? OperacionTransaccion_CuentaId,Int64? OperacionTransaccion_ContenedorId,Int64? OperacionTransaccion_SesionId,Int64? OperacionTransaccion_TurnoId,Int64? OperacionTransaccion_CierreDiarioId,Double? OperacionTransaccion_TotalValidado,Double? OperacionTransaccion_TotalAValidar,DateTime? OperacionTransaccion_Fecha,Boolean? OperacionTransaccion_Finalizada,Boolean? OperacionTransaccion_EsDepositoAutomatico,Int64? OperacionTransaccion_OrigenValorId,String OperacionTransaccion_CodigoOperacion)
            {
                this.Where.Clear();
                if (OperacionTransaccionSobre_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobre_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobre_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_Id);
                    }
                   
                }
                if (OperacionTransaccionSobre_TransaccionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobre_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobre_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_TransaccionId);
                    }
                   
                }
                if (OperacionTransaccionSobre_CodigoSobre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobre_CodigoSobre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_CodigoSobre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobre_CodigoSobre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_CodigoSobre);
                    }
                   
                }
                if (OperacionTransaccionSobre_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobre_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobre_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_Fecha);
                    }
                   
                }
                if (OperacionTransaccion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Id);
                    }
                   
                }
                if (OperacionTransaccion_TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TipoId);
                    }
                   
                }
                if (OperacionTransaccion_DepositarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_DepositarioId);
                    }
                   
                }
                if (OperacionTransaccion_SectorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_SectorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SectorId);
                    }
                   
                }
                if (OperacionTransaccion_SucursalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SucursalId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_SucursalId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SucursalId);
                    }
                   
                }
                if (OperacionTransaccion_MonedaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_MonedaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_MonedaId);
                    }
                   
                }
                if (OperacionTransaccion_UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_UsuarioId);
                    }
                   
                }
                if (OperacionTransaccion_CuentaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_CuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CuentaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_CuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CuentaId);
                    }
                   
                }
                if (OperacionTransaccion_ContenedorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_ContenedorId);
                    }
                   
                }
                if (OperacionTransaccion_SesionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SesionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_SesionId);
                    }
                   
                }
                if (OperacionTransaccion_TurnoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TurnoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TurnoId);
                    }
                   
                }
                if (OperacionTransaccion_CierreDiarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CierreDiarioId);
                    }
                   
                }
                if (OperacionTransaccion_TotalValidado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TotalValidado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalValidado);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TotalValidado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalValidado);
                    }
                   
                }
                if (OperacionTransaccion_TotalAValidar != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_TotalAValidar, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalAValidar);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_TotalAValidar, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_TotalAValidar);
                    }
                   
                }
                if (OperacionTransaccion_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Fecha);
                    }
                   
                }
                if (OperacionTransaccion_Finalizada != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_Finalizada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Finalizada);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_Finalizada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_Finalizada);
                    }
                   
                }
                if (OperacionTransaccion_EsDepositoAutomatico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_EsDepositoAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_EsDepositoAutomatico);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_EsDepositoAutomatico, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_EsDepositoAutomatico);
                    }
                   
                }
                if (OperacionTransaccion_OrigenValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_OrigenValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_OrigenValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_OrigenValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_OrigenValorId);
                    }
                   
                }
                if (OperacionTransaccion_CodigoOperacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccion_CodigoOperacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CodigoOperacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccion_CodigoOperacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccion_CodigoOperacion);
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
			public Entities.Views.Integracion.OperacionTransaccionSobreDetalle Add(Int64 OperacionTransaccionSobreDetalle_Id,Int64 OperacionTransaccionSobreDetalle_SobreId,Int64 OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId,Int64 OperacionTransaccionSobreDetalle_CantidadDeclarada,Double OperacionTransaccionSobreDetalle_ValorDeclarado,DateTime OperacionTransaccionSobreDetalle_Fecha,Int64 OperacionTransaccionSobre_Id,Int64 OperacionTransaccionSobre_TransaccionId,String OperacionTransaccionSobre_CodigoSobre,DateTime OperacionTransaccionSobre_Fecha,Int64 ValorRelacionMonedaTipoValor_Id,Int64 ValorRelacionMonedaTipoValor_MonedaId,Int64 ValorRelacionMonedaTipoValor_TipoValorId) 
			{
			  return (Entities.Views.Integracion.OperacionTransaccionSobreDetalle)base.Add(new Entities.Views.Integracion.OperacionTransaccionSobreDetalle(OperacionTransaccionSobreDetalle_Id,OperacionTransaccionSobreDetalle_SobreId,OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId,OperacionTransaccionSobreDetalle_CantidadDeclarada,OperacionTransaccionSobreDetalle_ValorDeclarado,OperacionTransaccionSobreDetalle_Fecha,OperacionTransaccionSobre_Id,OperacionTransaccionSobre_TransaccionId,OperacionTransaccionSobre_CodigoSobre,OperacionTransaccionSobre_Fecha,ValorRelacionMonedaTipoValor_Id,ValorRelacionMonedaTipoValor_MonedaId,ValorRelacionMonedaTipoValor_TipoValorId));
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
            /// <param name="OperacionTransaccionSobreDetalle_Id"></param>
            /// <param name="OperacionTransaccionSobreDetalle_SobreId"></param>
            /// <param name="OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId"></param>
            /// <param name="OperacionTransaccionSobreDetalle_CantidadDeclarada"></param>
            /// <param name="OperacionTransaccionSobreDetalle_ValorDeclarado"></param>
            /// <param name="OperacionTransaccionSobreDetalle_Fecha"></param>
            /// <param name="OperacionTransaccionSobre_Id"></param>
            /// <param name="OperacionTransaccionSobre_TransaccionId"></param>
            /// <param name="OperacionTransaccionSobre_CodigoSobre"></param>
            /// <param name="OperacionTransaccionSobre_Fecha"></param>
            /// <param name="ValorRelacionMonedaTipoValor_Id"></param>
            /// <param name="ValorRelacionMonedaTipoValor_MonedaId"></param>
            /// <param name="ValorRelacionMonedaTipoValor_TipoValorId"></param>
            /// <returns></returns>
            public List<Entities.Views.Integracion.OperacionTransaccionSobreDetalle> Items(Int64? OperacionTransaccionSobreDetalle_Id,Int64? OperacionTransaccionSobreDetalle_SobreId,Int64? OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId,Int64? OperacionTransaccionSobreDetalle_CantidadDeclarada,Double? OperacionTransaccionSobreDetalle_ValorDeclarado,DateTime? OperacionTransaccionSobreDetalle_Fecha,Int64? OperacionTransaccionSobre_Id,Int64? OperacionTransaccionSobre_TransaccionId,String OperacionTransaccionSobre_CodigoSobre,DateTime? OperacionTransaccionSobre_Fecha,Int64? ValorRelacionMonedaTipoValor_Id,Int64? ValorRelacionMonedaTipoValor_MonedaId,Int64? ValorRelacionMonedaTipoValor_TipoValorId)
            {
                this.Where.Clear();
                if (OperacionTransaccionSobreDetalle_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobreDetalle_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobreDetalle_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_Id);
                    }
                   
                }
                if (OperacionTransaccionSobreDetalle_SobreId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobreDetalle_SobreId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_SobreId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobreDetalle_SobreId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_SobreId);
                    }
                   
                }
                if (OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_RelacionMonedaTipoValorId);
                    }
                   
                }
                if (OperacionTransaccionSobreDetalle_CantidadDeclarada != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobreDetalle_CantidadDeclarada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_CantidadDeclarada);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobreDetalle_CantidadDeclarada, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_CantidadDeclarada);
                    }
                   
                }
                if (OperacionTransaccionSobreDetalle_ValorDeclarado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobreDetalle_ValorDeclarado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_ValorDeclarado);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobreDetalle_ValorDeclarado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_ValorDeclarado);
                    }
                   
                }
                if (OperacionTransaccionSobreDetalle_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobreDetalle_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobreDetalle_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobreDetalle_Fecha);
                    }
                   
                }
                if (OperacionTransaccionSobre_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobre_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobre_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_Id);
                    }
                   
                }
                if (OperacionTransaccionSobre_TransaccionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobre_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobre_TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_TransaccionId);
                    }
                   
                }
                if (OperacionTransaccionSobre_CodigoSobre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobre_CodigoSobre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_CodigoSobre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobre_CodigoSobre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_CodigoSobre);
                    }
                   
                }
                if (OperacionTransaccionSobre_Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OperacionTransaccionSobre_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OperacionTransaccionSobre_Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, OperacionTransaccionSobre_Fecha);
                    }
                   
                }
                if (ValorRelacionMonedaTipoValor_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorRelacionMonedaTipoValor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorRelacionMonedaTipoValor_Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorRelacionMonedaTipoValor_Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorRelacionMonedaTipoValor_Id);
                    }
                   
                }
                if (ValorRelacionMonedaTipoValor_MonedaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorRelacionMonedaTipoValor_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorRelacionMonedaTipoValor_MonedaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorRelacionMonedaTipoValor_MonedaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorRelacionMonedaTipoValor_MonedaId);
                    }
                   
                }
                if (ValorRelacionMonedaTipoValor_TipoValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorRelacionMonedaTipoValor_TipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorRelacionMonedaTipoValor_TipoValorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorRelacionMonedaTipoValor_TipoValorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ValorRelacionMonedaTipoValor_TipoValorId);
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
