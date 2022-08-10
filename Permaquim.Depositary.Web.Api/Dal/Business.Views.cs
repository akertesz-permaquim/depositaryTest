using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace DepositaryWebApi.Business.Views.Operacion {
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
					CantidadUnidades,
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
                 public void Add(DepositaryWebApi.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
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
			public Entities.Views.Operacion.VistaTransaccion Add(Int64 TipoId,Int64 DepositarioId,Int64 UsuarioId,Int64 UsuarioCuentaId,Int64 ContenedorId,Int64 SesionId,Int64 TurnoId,Int64 CierreDiarioId,Int64 Id,Int64 TransaccionId,Int64 DenominacionId,Int64 CantidadUnidades,DateTime Fecha) 
			{
			  return (Entities.Views.Operacion.VistaTransaccion)base.Add(new Entities.Views.Operacion.VistaTransaccion(TipoId,DepositarioId,UsuarioId,UsuarioCuentaId,ContenedorId,SesionId,TurnoId,CierreDiarioId,Id,TransaccionId,DenominacionId,CantidadUnidades,Fecha));
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
            /// <param name="CantidadUnidades"></param>
            /// <param name="Fecha"></param>
            /// <returns></returns>
            public List<Entities.Views.Operacion.VistaTransaccion> Items(Int64? TipoId,Int64? DepositarioId,Int64? UsuarioId,Int64? UsuarioCuentaId,Int64? ContenedorId,Int64? SesionId,Int64? TurnoId,Int64? CierreDiarioId,Int64? Id,Int64? TransaccionId,Int64? DenominacionId,Int64? CantidadUnidades,DateTime? Fecha)
            {
                this.Where.whereParameter.Clear();
                if (TipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TipoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (DepositarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DepositarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (UsuarioCuentaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, UsuarioCuentaId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCuentaId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, UsuarioCuentaId);
                    }
                   
                }
                if (ContenedorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContenedorId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                   
                }
                if (SesionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SesionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SesionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, SesionId);
                    }
                   
                }
                if (TurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TurnoId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                   
                }
                if (CierreDiarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CierreDiarioId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, CierreDiarioId);
                    }
                   
                }
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (DenominacionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DenominacionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DenominacionId, DepositaryWebApi.sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                   
                }
                if (CantidadUnidades != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadUnidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, CantidadUnidades);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadUnidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, CantidadUnidades);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fecha, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Fecha);
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
                 public void Add(ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(DepositaryWebApi.sqlEnum.ConjunctionEnum Conjunction)
                 {
                     this.whereParameter.AddConjunction(Conjunction);
                 }
                 public void OpenParentheses()
                 {
                     this.whereParameter.OpenParentheses();
                 }
                 public void CloseParentheses()
                 {
                     this.whereParameter.CloseParentheses();
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
        } // class VistaTransaccion
	} //namespace DepositaryWebApi.Business.Views.Operacion
	namespace DepositaryWebApi.Business.Views.Valor {
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
                 public void Add(DepositaryWebApi.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
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
                        this.Where.Add(ColumnEnum.Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                   
                }
                if (Denominacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Denominacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Denominacion, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                   
                }
                if (Unidades != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Unidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Unidades);
                    }
                    else
                    {
                        this.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Unidades, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Unidades);
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
                 public void Add(ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, DepositaryWebApi.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(DepositaryWebApi.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, DepositaryWebApi.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(DepositaryWebApi.sqlEnum.ConjunctionEnum Conjunction)
                 {
                     this.whereParameter.AddConjunction(Conjunction);
                 }
                 public void OpenParentheses()
                 {
                     this.whereParameter.OpenParentheses();
                 }
                 public void CloseParentheses()
                 {
                     this.whereParameter.CloseParentheses();
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
        } // class VistaDenominacion
	} //namespace DepositaryWebApi.Business.Views.Valor
