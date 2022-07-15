using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace DepositarioAdminWeb.Business.Views.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class VistaTransaccion : DataHandler
		{
				public enum ColumnEnum : int
                {
					TipoId,
					DepositarioId,
					UsuarioId,
					UsuarioCuentaId,
					ContenedorId,
					SesionId,
					TurnoId,
					CierreDiarioId,
					Id,
					TransaccionId,
					DenominacionId,
					Cantidad,
					Fecha
				}
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where { get; set; }
         public OrderByCollection OrderBy { get; set; }
         public GroupByCollection GroupBy { get; set; }
         public AggregateCollection Aggregate { get; set; }
            public VistaTransaccion() : base()
            {
                base._dataItem = new Entities.Views.Operacion.VistaTransaccion();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public VistaTransaccion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Operacion.VistaTransaccion();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(DepositarioAdminWeb.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Operacion.VistaTransaccion item)
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
			public Entities.Views.Operacion.VistaTransaccion Add(Int64 TipoId,Int64 DepositarioId,Int64 UsuarioId,Int64 UsuarioCuentaId,Int64 ContenedorId,Int64 SesionId,Int64 TurnoId,Int64 CierreDiarioId,Int64 Id,Int64 TransaccionId,Int64 DenominacionId,Int64 Cantidad,DateTime Fecha) 
			{
			  return (Entities.Views.Operacion.VistaTransaccion)base.Add(new Entities.Views.Operacion.VistaTransaccion(TipoId,DepositarioId,UsuarioId,UsuarioCuentaId,ContenedorId,SesionId,TurnoId,CierreDiarioId,Id,TransaccionId,DenominacionId,Cantidad,Fecha));
			}
            public new List<Entities.Views.Operacion.VistaTransaccion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderBy.orderByParameter;
                dh.GroupByParameter = this.GroupBy.groupByParameter;
                List<Entities.Views.Operacion.VistaTransaccion> _entities = new List<Entities.Views.Operacion.VistaTransaccion>();
                _entities = dh.Items().Cast<Entities.Views.Operacion.VistaTransaccion>().ToList<Entities.Views.Operacion.VistaTransaccion>();
                return _entities;
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="TipoId"></param>
            /// <param name="DepositarioId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="UsuarioCuentaId"></param>
            /// <param name="ContenedorId"></param>
            /// <param name="SesionId"></param>
            /// <param name="TurnoId"></param>
            /// <param name="CierreDiarioId"></param>
            /// <param name="Id"></param>
            /// <param name="TransaccionId"></param>
            /// <param name="DenominacionId"></param>
            /// <param name="Cantidad"></param>
            /// <param name="Fecha"></param>
            /// <returns></returns>
            public List<Entities.Views.Operacion.VistaTransaccion> Items(Int64? TipoId,Int64? DepositarioId,Int64? UsuarioId,Int64? UsuarioCuentaId,Int64? ContenedorId,Int64? SesionId,Int64? TurnoId,Int64? CierreDiarioId,Int64? Id,Int64? TransaccionId,Int64? DenominacionId,Int64? Cantidad,DateTime? Fecha)
            {
                this.Where.whereParameter.Clear();
                if (TipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (DepositarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (UsuarioCuentaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCuentaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, UsuarioCuentaId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCuentaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, UsuarioCuentaId);
                    }
                   
                }
                if (ContenedorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                   
                }
                if (SesionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SesionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, SesionId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SesionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, SesionId);
                    }
                   
                }
                if (TurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TurnoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TurnoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                   
                }
                if (CierreDiarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CierreDiarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CierreDiarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, CierreDiarioId);
                    }
                   
                }
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (DenominacionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DenominacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DenominacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                   
                }
                if (Cantidad != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Cantidad, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Cantidad);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Cantidad, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Cantidad);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fecha, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Fecha);
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
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.DirEnum direction = DepositarioAdminWeb.sqlEnum.DirEnum.ASC)
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
        } // class VistaTransaccion
	} //namespace DepositarioAdminWeb.Business.Views.Operacion
	namespace DepositarioAdminWeb.Business.Views.Reporte {
	    /// <summary>
	    /// 
	    /// </summary>
		public class DetalleTransacciones : DataHandler
		{
				public enum ColumnEnum : int
                {
					TransaccionId,
					FechaTransaccion,
					SectorId,
					Moneda,
					Denominacion,
					CodigoMoneda,
					Total
				}
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where { get; set; }
         public OrderByCollection OrderBy { get; set; }
         public GroupByCollection GroupBy { get; set; }
         public AggregateCollection Aggregate { get; set; }
            public DetalleTransacciones() : base()
            {
                base._dataItem = new Entities.Views.Reporte.DetalleTransacciones();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public DetalleTransacciones(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Reporte.DetalleTransacciones();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(DepositarioAdminWeb.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Reporte.DetalleTransacciones item)
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
			public Entities.Views.Reporte.DetalleTransacciones Add(Int64 TransaccionId,DateTime FechaTransaccion,Int64 SectorId,String Moneda,String Denominacion,String CodigoMoneda,Decimal Total) 
			{
			  return (Entities.Views.Reporte.DetalleTransacciones)base.Add(new Entities.Views.Reporte.DetalleTransacciones(TransaccionId,FechaTransaccion,SectorId,Moneda,Denominacion,CodigoMoneda,Total));
			}
            public new List<Entities.Views.Reporte.DetalleTransacciones> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderBy.orderByParameter;
                dh.GroupByParameter = this.GroupBy.groupByParameter;
                List<Entities.Views.Reporte.DetalleTransacciones> _entities = new List<Entities.Views.Reporte.DetalleTransacciones>();
                _entities = dh.Items().Cast<Entities.Views.Reporte.DetalleTransacciones>().ToList<Entities.Views.Reporte.DetalleTransacciones>();
                return _entities;
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="TransaccionId"></param>
            /// <param name="FechaTransaccion"></param>
            /// <param name="SectorId"></param>
            /// <param name="Moneda"></param>
            /// <param name="Denominacion"></param>
            /// <param name="CodigoMoneda"></param>
            /// <param name="Total"></param>
            /// <returns></returns>
            public List<Entities.Views.Reporte.DetalleTransacciones> Items(Int64? TransaccionId,DateTime? FechaTransaccion,Int64? SectorId,String Moneda,String Denominacion,String CodigoMoneda,Decimal? Total)
            {
                this.Where.whereParameter.Clear();
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (FechaTransaccion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaTransaccion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaTransaccion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                   
                }
                if (SectorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                   
                }
                if (Denominacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Denominacion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Denominacion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                   
                }
                if (CodigoMoneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoMoneda, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, CodigoMoneda);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoMoneda, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, CodigoMoneda);
                    }
                   
                }
                if (Total != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Total, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Total);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Total, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Total);
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
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.DirEnum direction = DepositarioAdminWeb.sqlEnum.DirEnum.ASC)
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
        } // class DetalleTransacciones
	} //namespace DepositarioAdminWeb.Business.Views.Reporte
	namespace DepositarioAdminWeb.Business.Views.Reporte {
	    /// <summary>
	    /// 
	    /// </summary>
		public class DetalleTransaccionesSobre : DataHandler
		{
				public enum ColumnEnum : int
                {
					TransaccionId,
					FechaTransaccion,
					CodigoSobre,
					UsuarioId,
					ContenedorId,
					Cantidad,
					TipoValor,
					TurnoId,
					SectorId
				}
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where { get; set; }
         public OrderByCollection OrderBy { get; set; }
         public GroupByCollection GroupBy { get; set; }
         public AggregateCollection Aggregate { get; set; }
            public DetalleTransaccionesSobre() : base()
            {
                base._dataItem = new Entities.Views.Reporte.DetalleTransaccionesSobre();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public DetalleTransaccionesSobre(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Reporte.DetalleTransaccionesSobre();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(DepositarioAdminWeb.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Reporte.DetalleTransaccionesSobre item)
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
			public Entities.Views.Reporte.DetalleTransaccionesSobre Add(Int64 TransaccionId,DateTime FechaTransaccion,String CodigoSobre,Int64 UsuarioId,Int64 ContenedorId,Int64 Cantidad,String TipoValor,Int64 TurnoId,Int64 SectorId) 
			{
			  return (Entities.Views.Reporte.DetalleTransaccionesSobre)base.Add(new Entities.Views.Reporte.DetalleTransaccionesSobre(TransaccionId,FechaTransaccion,CodigoSobre,UsuarioId,ContenedorId,Cantidad,TipoValor,TurnoId,SectorId));
			}
            public new List<Entities.Views.Reporte.DetalleTransaccionesSobre> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderBy.orderByParameter;
                dh.GroupByParameter = this.GroupBy.groupByParameter;
                List<Entities.Views.Reporte.DetalleTransaccionesSobre> _entities = new List<Entities.Views.Reporte.DetalleTransaccionesSobre>();
                _entities = dh.Items().Cast<Entities.Views.Reporte.DetalleTransaccionesSobre>().ToList<Entities.Views.Reporte.DetalleTransaccionesSobre>();
                return _entities;
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="TransaccionId"></param>
            /// <param name="FechaTransaccion"></param>
            /// <param name="CodigoSobre"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="ContenedorId"></param>
            /// <param name="Cantidad"></param>
            /// <param name="TipoValor"></param>
            /// <param name="TurnoId"></param>
            /// <param name="SectorId"></param>
            /// <returns></returns>
            public List<Entities.Views.Reporte.DetalleTransaccionesSobre> Items(Int64? TransaccionId,DateTime? FechaTransaccion,String CodigoSobre,Int64? UsuarioId,Int64? ContenedorId,Int64? Cantidad,String TipoValor,Int64? TurnoId,Int64? SectorId)
            {
                this.Where.whereParameter.Clear();
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (FechaTransaccion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaTransaccion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaTransaccion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                   
                }
                if (CodigoSobre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoSobre, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, CodigoSobre);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoSobre, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, CodigoSobre);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (ContenedorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                   
                }
                if (Cantidad != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Cantidad, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Cantidad);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Cantidad, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Cantidad);
                    }
                   
                }
                if (TipoValor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoValor, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TipoValor);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TipoValor, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TipoValor);
                    }
                   
                }
                if (TurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TurnoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TurnoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                   
                }
                if (SectorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, SectorId);
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
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.DirEnum direction = DepositarioAdminWeb.sqlEnum.DirEnum.ASC)
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
        } // class DetalleTransaccionesSobre
	} //namespace DepositarioAdminWeb.Business.Views.Reporte
	namespace DepositarioAdminWeb.Business.Views.Reporte {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Transacciones : DataHandler
		{
				public enum ColumnEnum : int
                {
					TransaccionId,
					TransaccionTipoId,
					TransaccionTipo,
					Usuario,
					FechaTransaccion,
					FechaRetiroBolsa,
					Moneda,
					TotalValidado,
					TotalAValidar,
					Empresa,
					Sucursal,
					Sector,
					Contenedor,
					Turno,
					ContenedorId,
					TurnoId,
					SectorId,
					UsuarioId
				}
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where { get; set; }
         public OrderByCollection OrderBy { get; set; }
         public GroupByCollection GroupBy { get; set; }
         public AggregateCollection Aggregate { get; set; }
            public Transacciones() : base()
            {
                base._dataItem = new Entities.Views.Reporte.Transacciones();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public Transacciones(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Reporte.Transacciones();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(DepositarioAdminWeb.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Reporte.Transacciones item)
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
			public Entities.Views.Reporte.Transacciones Add(Int64 TransaccionId,Int64 TransaccionTipoId,String TransaccionTipo,String Usuario,DateTime FechaTransaccion,DateTime FechaRetiroBolsa,String Moneda,Double TotalValidado,Double TotalAValidar,String Empresa,String Sucursal,String Sector,String Contenedor,String Turno,Int64 ContenedorId,Int64 TurnoId,Int64 SectorId,Int64 UsuarioId) 
			{
			  return (Entities.Views.Reporte.Transacciones)base.Add(new Entities.Views.Reporte.Transacciones(TransaccionId,TransaccionTipoId,TransaccionTipo,Usuario,FechaTransaccion,FechaRetiroBolsa,Moneda,TotalValidado,TotalAValidar,Empresa,Sucursal,Sector,Contenedor,Turno,ContenedorId,TurnoId,SectorId,UsuarioId));
			}
            public new List<Entities.Views.Reporte.Transacciones> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderBy.orderByParameter;
                dh.GroupByParameter = this.GroupBy.groupByParameter;
                List<Entities.Views.Reporte.Transacciones> _entities = new List<Entities.Views.Reporte.Transacciones>();
                _entities = dh.Items().Cast<Entities.Views.Reporte.Transacciones>().ToList<Entities.Views.Reporte.Transacciones>();
                return _entities;
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="TransaccionId"></param>
            /// <param name="TransaccionTipoId"></param>
            /// <param name="TransaccionTipo"></param>
            /// <param name="Usuario"></param>
            /// <param name="FechaTransaccion"></param>
            /// <param name="FechaRetiroBolsa"></param>
            /// <param name="Moneda"></param>
            /// <param name="TotalValidado"></param>
            /// <param name="TotalAValidar"></param>
            /// <param name="Empresa"></param>
            /// <param name="Sucursal"></param>
            /// <param name="Sector"></param>
            /// <param name="Contenedor"></param>
            /// <param name="Turno"></param>
            /// <param name="ContenedorId"></param>
            /// <param name="TurnoId"></param>
            /// <param name="SectorId"></param>
            /// <param name="UsuarioId"></param>
            /// <returns></returns>
            public List<Entities.Views.Reporte.Transacciones> Items(Int64? TransaccionId,Int64? TransaccionTipoId,String TransaccionTipo,String Usuario,DateTime? FechaTransaccion,DateTime? FechaRetiroBolsa,String Moneda,Double? TotalValidado,Double? TotalAValidar,String Empresa,String Sucursal,String Sector,String Contenedor,String Turno,Int64? ContenedorId,Int64? TurnoId,Int64? SectorId,Int64? UsuarioId)
            {
                this.Where.whereParameter.Clear();
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (TransaccionTipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionTipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionTipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionTipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionTipoId);
                    }
                   
                }
                if (TransaccionTipo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionTipo, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionTipo);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionTipo, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TransaccionTipo);
                    }
                   
                }
                if (Usuario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Usuario, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Usuario, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                   
                }
                if (FechaTransaccion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaTransaccion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaTransaccion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                   
                }
                if (FechaRetiroBolsa != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaRetiroBolsa, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, FechaRetiroBolsa);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaRetiroBolsa, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, FechaRetiroBolsa);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                   
                }
                if (TotalValidado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TotalValidado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TotalValidado);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TotalValidado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TotalValidado);
                    }
                   
                }
                if (TotalAValidar != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TotalAValidar, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TotalAValidar);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TotalAValidar, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TotalAValidar);
                    }
                   
                }
                if (Empresa != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Empresa, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Empresa, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                   
                }
                if (Sucursal != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sucursal, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sucursal, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                   
                }
                if (Sector != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sector, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Sector);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sector, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Sector);
                    }
                   
                }
                if (Contenedor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Contenedor, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Contenedor);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Contenedor, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Contenedor);
                    }
                   
                }
                if (Turno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Turno, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Turno);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Turno, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Turno);
                    }
                   
                }
                if (ContenedorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                   
                }
                if (TurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TurnoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TurnoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                   
                }
                if (SectorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, UsuarioId);
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
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.DirEnum direction = DepositarioAdminWeb.sqlEnum.DirEnum.ASC)
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
        } // class Transacciones
	} //namespace DepositarioAdminWeb.Business.Views.Reporte
	namespace DepositarioAdminWeb.Business.Views.Valor {
	    /// <summary>
	    /// 
	    /// </summary>
		public class VistaDenominacion : DataHandler
		{
				public enum ColumnEnum : int
                {
					Nombre,
					Moneda,
					Denominacion,
					Unidades
				}
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where { get; set; }
         public OrderByCollection OrderBy { get; set; }
         public GroupByCollection GroupBy { get; set; }
         public AggregateCollection Aggregate { get; set; }
            public VistaDenominacion() : base()
            {
                base._dataItem = new Entities.Views.Valor.VistaDenominacion();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public VistaDenominacion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Valor.VistaDenominacion();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(DepositarioAdminWeb.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Valor.VistaDenominacion item)
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
			public Entities.Views.Valor.VistaDenominacion Add(String Nombre,String Moneda,String Denominacion,Decimal Unidades) 
			{
			  return (Entities.Views.Valor.VistaDenominacion)base.Add(new Entities.Views.Valor.VistaDenominacion(Nombre,Moneda,Denominacion,Unidades));
			}
            public new List<Entities.Views.Valor.VistaDenominacion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderBy.orderByParameter;
                dh.GroupByParameter = this.GroupBy.groupByParameter;
                List<Entities.Views.Valor.VistaDenominacion> _entities = new List<Entities.Views.Valor.VistaDenominacion>();
                _entities = dh.Items().Cast<Entities.Views.Valor.VistaDenominacion>().ToList<Entities.Views.Valor.VistaDenominacion>();
                return _entities;
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="Nombre"></param>
            /// <param name="Moneda"></param>
            /// <param name="Denominacion"></param>
            /// <param name="Unidades"></param>
            /// <returns></returns>
            public List<Entities.Views.Valor.VistaDenominacion> Items(String Nombre,String Moneda,String Denominacion,Decimal? Unidades)
            {
                this.Where.whereParameter.Clear();
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                   
                }
                if (Denominacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Denominacion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Denominacion, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                   
                }
                if (Unidades != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Unidades, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Unidades);
                    }
                    else
                    {
                        this.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Unidades, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Unidades);
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
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositarioAdminWeb.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, DepositarioAdminWeb.sqlEnum.DirEnum direction = DepositarioAdminWeb.sqlEnum.DirEnum.ASC)
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
        } // class VistaDenominacion
	} //namespace DepositarioAdminWeb.Business.Views.Valor
