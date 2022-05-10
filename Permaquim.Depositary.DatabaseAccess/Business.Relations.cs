using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace Depositary.Business.Relations.Auditoria {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Log : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Fecha,
					Tipo,
					Descripcion,
					Detalle,
					OrigenAplicacion,
					OrigenMetodo,
					UsuarioId
				}
			   protected List<Entities.Relations.Auditoria.Log> _cacheItemList = new List<Entities.Relations.Auditoria.Log>();
			   protected List<Entities.Relations.Auditoria.Log> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Log() : base()
            {
                base._dataItem = new Entities.Relations.Auditoria.Log();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Auditoria.Log item)
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
         /// <summary>
         /// Log Add Method
         /// </summary>
         /// <param name='Fecha'></param>
         /// <param name='Tipo'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Detalle'></param>
         /// <param name='OrigenAplicacion'></param>
         /// <param name='OrigenMetodo'></param>
         /// <param name='UsuarioId'></param>
         /// <returns>Entities.Relations.Auditoria.Log</returns>
			public Entities.Relations.Auditoria.Log Add(DateTime Fecha,String Tipo,String Descripcion,String Detalle,String OrigenAplicacion,String OrigenMetodo,Int64 UsuarioId) 
			{
			  return (Entities.Relations.Auditoria.Log)base.Add(new Entities.Relations.Auditoria.Log(Fecha,Tipo,Descripcion,Detalle,OrigenAplicacion,OrigenMetodo,UsuarioId));
			}
            public new List<Entities.Relations.Auditoria.Log> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Auditoria.Log>().ToList<Entities.Relations.Auditoria.Log>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Auditoria.Log items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Auditoria.Log> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Fecha"></param>
            /// <param name="Tipo"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Detalle"></param>
            /// <param name="OrigenAplicacion"></param>
            /// <param name="OrigenMetodo"></param>
            /// <param name="UsuarioId"></param>
            /// <returns></returns>
            public List<Entities.Relations.Auditoria.Log> Items(Int64? Id,DateTime? Fecha,String Tipo,String Descripcion,String Detalle,String OrigenAplicacion,String OrigenMetodo,Int64? UsuarioId)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                   
                }
                if (Tipo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo, Depositary.sqlEnum.OperandEnum.Equal, Tipo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Tipo, Depositary.sqlEnum.OperandEnum.Equal, Tipo);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Detalle != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Detalle, Depositary.sqlEnum.OperandEnum.Equal, Detalle);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Detalle, Depositary.sqlEnum.OperandEnum.Equal, Detalle);
                    }
                   
                }
                if (OrigenAplicacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OrigenAplicacion, Depositary.sqlEnum.OperandEnum.Equal, OrigenAplicacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OrigenAplicacion, Depositary.sqlEnum.OperandEnum.Equal, OrigenAplicacion);
                    }
                   
                }
                if (OrigenMetodo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OrigenMetodo, Depositary.sqlEnum.OperandEnum.Equal, OrigenMetodo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OrigenMetodo, Depositary.sqlEnum.OperandEnum.Equal, OrigenMetodo);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Auditoria.Log> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Auditoria.Log Add(Entities.Relations.Auditoria.Log item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Auditoria.Log)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Auditoria.Log item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Auditoria.Log with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Fecha"></param>
            /// <param name="Tipo"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Detalle"></param>
            /// <param name="OrigenAplicacion"></param>
            /// <param name="OrigenMetodo"></param>
            /// <param name="UsuarioId"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,DateTime Fecha,String Tipo,String Descripcion,String Detalle,String OrigenAplicacion,String OrigenMetodo,Int64 UsuarioId)
            {
                 Entities.Tables.Auditoria.Log item = new Entities.Tables.Auditoria.Log();
                 item.Id = Id;
                 item.Fecha = Fecha;
                 item.Tipo = Tipo;
                 item.Descripcion = Descripcion;
                 item.Detalle = Detalle;
                 item.OrigenAplicacion = OrigenAplicacion;
                 item.OrigenMetodo = OrigenMetodo;
                 item.UsuarioId = UsuarioId;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Log
	} //namespace Depositary.Business.Relations.Auditoria
	namespace Depositary.Business.Relations.Auditoria {
	    /// <summary>
	    /// 
	    /// </summary>
		public class LogAnomalia : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Fecha,
					Tipo,
					Descripcion,
					Detalle,
					UsuarioId
				}
			   protected List<Entities.Relations.Auditoria.LogAnomalia> _cacheItemList = new List<Entities.Relations.Auditoria.LogAnomalia>();
			   protected List<Entities.Relations.Auditoria.LogAnomalia> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public LogAnomalia() : base()
            {
                base._dataItem = new Entities.Relations.Auditoria.LogAnomalia();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Auditoria.LogAnomalia item)
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
         /// <summary>
         /// LogAnomalia Add Method
         /// </summary>
         /// <param name='Fecha'></param>
         /// <param name='Tipo'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Detalle'></param>
         /// <param name='UsuarioId'></param>
         /// <returns>Entities.Relations.Auditoria.LogAnomalia</returns>
			public Entities.Relations.Auditoria.LogAnomalia Add(DateTime Fecha,String Tipo,String Descripcion,String Detalle,Int64 UsuarioId) 
			{
			  return (Entities.Relations.Auditoria.LogAnomalia)base.Add(new Entities.Relations.Auditoria.LogAnomalia(Fecha,Tipo,Descripcion,Detalle,UsuarioId));
			}
            public new List<Entities.Relations.Auditoria.LogAnomalia> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Auditoria.LogAnomalia>().ToList<Entities.Relations.Auditoria.LogAnomalia>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Auditoria.LogAnomalia items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Auditoria.LogAnomalia> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Fecha"></param>
            /// <param name="Tipo"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Detalle"></param>
            /// <param name="UsuarioId"></param>
            /// <returns></returns>
            public List<Entities.Relations.Auditoria.LogAnomalia> Items(Int64? Id,DateTime? Fecha,String Tipo,String Descripcion,String Detalle,Int64? UsuarioId)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                   
                }
                if (Tipo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo, Depositary.sqlEnum.OperandEnum.Equal, Tipo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Tipo, Depositary.sqlEnum.OperandEnum.Equal, Tipo);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Detalle != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Detalle, Depositary.sqlEnum.OperandEnum.Equal, Detalle);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Detalle, Depositary.sqlEnum.OperandEnum.Equal, Detalle);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Auditoria.LogAnomalia> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Auditoria.LogAnomalia Add(Entities.Relations.Auditoria.LogAnomalia item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Auditoria.LogAnomalia)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Auditoria.LogAnomalia item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Auditoria.LogAnomalia with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Fecha"></param>
            /// <param name="Tipo"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Detalle"></param>
            /// <param name="UsuarioId"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,DateTime Fecha,String Tipo,String Descripcion,String Detalle,Int64 UsuarioId)
            {
                 Entities.Tables.Auditoria.LogAnomalia item = new Entities.Tables.Auditoria.LogAnomalia();
                 item.Id = Id;
                 item.Fecha = Fecha;
                 item.Tipo = Tipo;
                 item.Descripcion = Descripcion;
                 item.Detalle = Detalle;
                 item.UsuarioId = UsuarioId;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class LogAnomalia
	} //namespace Depositary.Business.Relations.Auditoria
	namespace Depositary.Business.Relations.Biometria {
	    /// <summary>
	    /// 
	    /// </summary>
		public class HuellaDactilar : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					UsuarioId,
					Dedo,
					Huella,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Biometria.HuellaDactilar> _cacheItemList = new List<Entities.Relations.Biometria.HuellaDactilar>();
			   protected List<Entities.Relations.Biometria.HuellaDactilar> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public HuellaDactilar() : base()
            {
                base._dataItem = new Entities.Relations.Biometria.HuellaDactilar();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Biometria.HuellaDactilar item)
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
         /// <summary>
         /// HuellaDactilar Add Method
         /// </summary>
         /// <param name='UsuarioId'></param>
         /// <param name='Dedo'></param>
         /// <param name='Huella'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Biometria.HuellaDactilar</returns>
			public Entities.Relations.Biometria.HuellaDactilar Add(Int64 UsuarioId,Byte Dedo,String Huella,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Biometria.HuellaDactilar)base.Add(new Entities.Relations.Biometria.HuellaDactilar(UsuarioId,Dedo,Huella,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Biometria.HuellaDactilar> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Biometria.HuellaDactilar>().ToList<Entities.Relations.Biometria.HuellaDactilar>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Biometria.HuellaDactilar items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Biometria.HuellaDactilar> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="Dedo"></param>
            /// <param name="Huella"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Biometria.HuellaDactilar> Items(Int64? Id,Int64? UsuarioId,Byte? Dedo,String Huella,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (Dedo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Dedo, Depositary.sqlEnum.OperandEnum.Equal, Dedo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Dedo, Depositary.sqlEnum.OperandEnum.Equal, Dedo);
                    }
                   
                }
                if (Huella != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Huella, Depositary.sqlEnum.OperandEnum.Equal, Huella);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Huella, Depositary.sqlEnum.OperandEnum.Equal, Huella);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Biometria.HuellaDactilar> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Biometria.HuellaDactilar Add(Entities.Relations.Biometria.HuellaDactilar item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Biometria.HuellaDactilar)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Biometria.HuellaDactilar item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Biometria.HuellaDactilar with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="Dedo"></param>
            /// <param name="Huella"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 UsuarioId,Byte Dedo,String Huella,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Biometria.HuellaDactilar item = new Entities.Tables.Biometria.HuellaDactilar();
                 item.Id = Id;
                 item.UsuarioId = UsuarioId;
                 item.Dedo = Dedo;
                 item.Huella = Huella;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class HuellaDactilar
	} //namespace Depositary.Business.Relations.Biometria
	namespace Depositary.Business.Relations.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Banco : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					PaisId,
					Codigo,
					Denominacion,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					Habilitado
				}
			   protected List<Entities.Relations.Directorio.Banco> _cacheItemList = new List<Entities.Relations.Directorio.Banco>();
			   protected List<Entities.Relations.Directorio.Banco> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Banco() : base()
            {
                base._dataItem = new Entities.Relations.Directorio.Banco();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Directorio.Banco item)
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
         /// <summary>
         /// Banco Add Method
         /// </summary>
         /// <param name='PaisId'></param>
         /// <param name='Codigo'></param>
         /// <param name='Denominacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Directorio.Banco</returns>
			public Entities.Relations.Directorio.Banco Add(Int64 PaisId,String Codigo,String Denominacion,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,Boolean Habilitado) 
			{
			  return (Entities.Relations.Directorio.Banco)base.Add(new Entities.Relations.Directorio.Banco(PaisId,Codigo,Denominacion,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,Habilitado));
			}
            public new List<Entities.Relations.Directorio.Banco> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Directorio.Banco>().ToList<Entities.Relations.Directorio.Banco>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Directorio.Banco items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.Banco> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="PaisId"></param>
            /// <param name="Codigo"></param>
            /// <param name="Denominacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.Banco> Items(Int64? Id,Int64? PaisId,String Codigo,String Denominacion,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (PaisId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, PaisId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, PaisId);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (Denominacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Denominacion, Depositary.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Denominacion, Depositary.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Directorio.Banco> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Directorio.Banco Add(Entities.Relations.Directorio.Banco item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Directorio.Banco)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Directorio.Banco item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Directorio.Banco with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="PaisId"></param>
            /// <param name="Codigo"></param>
            /// <param name="Denominacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 PaisId,String Codigo,String Denominacion,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,Boolean Habilitado)
            {
                 Entities.Tables.Directorio.Banco item = new Entities.Tables.Directorio.Banco();
                 item.Id = Id;
                 item.PaisId = PaisId;
                 item.Codigo = Codigo;
                 item.Denominacion = Denominacion;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Banco
	} //namespace Depositary.Business.Relations.Directorio
	namespace Depositary.Business.Relations.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Compania : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					GrupoId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Address,
					CodigoPostalId,
					Habilitado
				}
			   protected List<Entities.Relations.Directorio.Compania> _cacheItemList = new List<Entities.Relations.Directorio.Compania>();
			   protected List<Entities.Relations.Directorio.Compania> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Compania() : base()
            {
                base._dataItem = new Entities.Relations.Directorio.Compania();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Directorio.Compania item)
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
         /// <summary>
         /// Compania Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Directorio.Grupo GrupoId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Address'></param>
         /// <param name='CodigoPostalId'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Directorio.Compania</returns>
			public Entities.Relations.Directorio.Compania Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Directorio.Grupo GrupoId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,String Address,Int64 CodigoPostalId,Boolean Habilitado) 
			{
			  return (Entities.Relations.Directorio.Compania)base.Add(new Entities.Relations.Directorio.Compania(Nombre,Descripcion,GrupoId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Address,CodigoPostalId,Habilitado));
			}
            public new List<Entities.Relations.Directorio.Compania> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Directorio.Compania>().ToList<Entities.Relations.Directorio.Compania>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Directorio.Compania items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.Compania> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="GrupoId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Address"></param>
            /// <param name="CodigoPostalId"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.Compania> Items(Int64? Id,String Nombre,String Descripcion,Int64? GrupoId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,String Address,Int64? CodigoPostalId,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (GrupoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.GrupoId, Depositary.sqlEnum.OperandEnum.Equal, GrupoId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.GrupoId, Depositary.sqlEnum.OperandEnum.Equal, GrupoId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Address != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Address, Depositary.sqlEnum.OperandEnum.Equal, Address);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Address, Depositary.sqlEnum.OperandEnum.Equal, Address);
                    }
                   
                }
                if (CodigoPostalId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoPostalId, Depositary.sqlEnum.OperandEnum.Equal, CodigoPostalId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoPostalId, Depositary.sqlEnum.OperandEnum.Equal, CodigoPostalId);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Directorio.Compania> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Directorio.Compania Add(Entities.Relations.Directorio.Compania item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Directorio.Compania)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Directorio.Compania item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Directorio.Compania with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="GrupoId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Address"></param>
            /// <param name="CodigoPostalId"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int64 GrupoId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,String Address,Int64 CodigoPostalId,Boolean Habilitado)
            {
                 Entities.Tables.Directorio.Compania item = new Entities.Tables.Directorio.Compania();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.GrupoId = GrupoId;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.CodigoExterno = CodigoExterno;
                 item.Address = Address;
                 item.CodigoPostalId = CodigoPostalId;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Compania
	} //namespace Depositary.Business.Relations.Directorio
	namespace Depositary.Business.Relations.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class CuentaBancaria : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					TipoId,
					SucursalBancariaId,
					Codigo,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Directorio.CuentaBancaria> _cacheItemList = new List<Entities.Relations.Directorio.CuentaBancaria>();
			   protected List<Entities.Relations.Directorio.CuentaBancaria> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public CuentaBancaria() : base()
            {
                base._dataItem = new Entities.Relations.Directorio.CuentaBancaria();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Directorio.CuentaBancaria item)
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
         /// <summary>
         /// CuentaBancaria Add Method
         /// </summary>
         /// <param name='TipoId'></param>
         /// <param name='SucursalBancariaId'></param>
         /// <param name='Codigo'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Directorio.CuentaBancaria</returns>
			public Entities.Relations.Directorio.CuentaBancaria Add(Int64 TipoId,Int64 SucursalBancariaId,String Codigo,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Directorio.CuentaBancaria)base.Add(new Entities.Relations.Directorio.CuentaBancaria(TipoId,SucursalBancariaId,Codigo,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Directorio.CuentaBancaria> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Directorio.CuentaBancaria>().ToList<Entities.Relations.Directorio.CuentaBancaria>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Directorio.CuentaBancaria items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.CuentaBancaria> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TipoId"></param>
            /// <param name="SucursalBancariaId"></param>
            /// <param name="Codigo"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.CuentaBancaria> Items(Int64? Id,Int64? TipoId,Int64? SucursalBancariaId,String Codigo,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (SucursalBancariaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalBancariaId, Depositary.sqlEnum.OperandEnum.Equal, SucursalBancariaId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SucursalBancariaId, Depositary.sqlEnum.OperandEnum.Equal, SucursalBancariaId);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Directorio.CuentaBancaria> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Directorio.CuentaBancaria Add(Entities.Relations.Directorio.CuentaBancaria item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Directorio.CuentaBancaria)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Directorio.CuentaBancaria item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Directorio.CuentaBancaria with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TipoId"></param>
            /// <param name="SucursalBancariaId"></param>
            /// <param name="Codigo"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 TipoId,Int64 SucursalBancariaId,String Codigo,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Directorio.CuentaBancaria item = new Entities.Tables.Directorio.CuentaBancaria();
                 item.Id = Id;
                 item.TipoId = TipoId;
                 item.SucursalBancariaId = SucursalBancariaId;
                 item.Codigo = Codigo;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class CuentaBancaria
	} //namespace Depositary.Business.Relations.Directorio
	namespace Depositary.Business.Relations.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Grupo : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
			   protected List<Entities.Relations.Directorio.Grupo> _cacheItemList = new List<Entities.Relations.Directorio.Grupo>();
			   protected List<Entities.Relations.Directorio.Grupo> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Grupo() : base()
            {
                base._dataItem = new Entities.Relations.Directorio.Grupo();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Directorio.Grupo item)
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
         /// <summary>
         /// Grupo Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Directorio.Grupo</returns>
			public Entities.Relations.Directorio.Grupo Add(String Nombre,String Descripcion,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Relations.Directorio.Grupo)base.Add(new Entities.Relations.Directorio.Grupo(Nombre,Descripcion,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Relations.Directorio.Grupo> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Directorio.Grupo>().ToList<Entities.Relations.Directorio.Grupo>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Directorio.Grupo items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.Grupo> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.Grupo> Items(Int64? Id,String Nombre,String Descripcion,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Directorio.Grupo> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Directorio.Grupo Add(Entities.Relations.Directorio.Grupo item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Directorio.Grupo)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Directorio.Grupo item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Directorio.Grupo with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
            {
                 Entities.Tables.Directorio.Grupo item = new Entities.Tables.Directorio.Grupo();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.CodigoExterno = CodigoExterno;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Grupo
	} //namespace Depositary.Business.Relations.Directorio
	namespace Depositary.Business.Relations.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class SucursalBancaria : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					BancoId,
					Codigo,
					Direccion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Directorio.SucursalBancaria> _cacheItemList = new List<Entities.Relations.Directorio.SucursalBancaria>();
			   protected List<Entities.Relations.Directorio.SucursalBancaria> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public SucursalBancaria() : base()
            {
                base._dataItem = new Entities.Relations.Directorio.SucursalBancaria();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Directorio.SucursalBancaria item)
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
         /// <summary>
         /// SucursalBancaria Add Method
         /// </summary>
         /// <param name='BancoId'></param>
         /// <param name='Codigo'></param>
         /// <param name='Direccion'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Directorio.SucursalBancaria</returns>
			public Entities.Relations.Directorio.SucursalBancaria Add(Int64 BancoId,String Codigo,String Direccion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Directorio.SucursalBancaria)base.Add(new Entities.Relations.Directorio.SucursalBancaria(BancoId,Codigo,Direccion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Directorio.SucursalBancaria> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Directorio.SucursalBancaria>().ToList<Entities.Relations.Directorio.SucursalBancaria>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Directorio.SucursalBancaria items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.SucursalBancaria> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="BancoId"></param>
            /// <param name="Codigo"></param>
            /// <param name="Direccion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.SucursalBancaria> Items(Int64? Id,Int64? BancoId,String Codigo,String Direccion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (BancoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancoId, Depositary.sqlEnum.OperandEnum.Equal, BancoId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.BancoId, Depositary.sqlEnum.OperandEnum.Equal, BancoId);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (Direccion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Direccion, Depositary.sqlEnum.OperandEnum.Equal, Direccion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Direccion, Depositary.sqlEnum.OperandEnum.Equal, Direccion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Directorio.SucursalBancaria> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Directorio.SucursalBancaria Add(Entities.Relations.Directorio.SucursalBancaria item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Directorio.SucursalBancaria)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Directorio.SucursalBancaria item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Directorio.SucursalBancaria with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="BancoId"></param>
            /// <param name="Codigo"></param>
            /// <param name="Direccion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 BancoId,String Codigo,String Direccion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Directorio.SucursalBancaria item = new Entities.Tables.Directorio.SucursalBancaria();
                 item.Id = Id;
                 item.BancoId = BancoId;
                 item.Codigo = Codigo;
                 item.Direccion = Direccion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class SucursalBancaria
	} //namespace Depositary.Business.Relations.Directorio
	namespace Depositary.Business.Relations.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class SucursalCompania : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					CompaniaId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Direccion,
					CodigoPostalId,
					Habilitado
				}
			   protected List<Entities.Relations.Directorio.SucursalCompania> _cacheItemList = new List<Entities.Relations.Directorio.SucursalCompania>();
			   protected List<Entities.Relations.Directorio.SucursalCompania> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public SucursalCompania() : base()
            {
                base._dataItem = new Entities.Relations.Directorio.SucursalCompania();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Directorio.SucursalCompania item)
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
         /// <summary>
         /// SucursalCompania Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Directorio.Compania CompaniaId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Direccion'></param>
         /// <param name='Depositary.Entities.Relations.Sig.CodigoPostal CodigoPostalId'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Directorio.SucursalCompania</returns>
			public Entities.Relations.Directorio.SucursalCompania Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Directorio.Compania CompaniaId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,String Direccion,Depositary.Entities.Relations.Sig.CodigoPostal CodigoPostalId,Boolean Habilitado) 
			{
			  return (Entities.Relations.Directorio.SucursalCompania)base.Add(new Entities.Relations.Directorio.SucursalCompania(Nombre,Descripcion,CompaniaId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Direccion,CodigoPostalId,Habilitado));
			}
            public new List<Entities.Relations.Directorio.SucursalCompania> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Directorio.SucursalCompania>().ToList<Entities.Relations.Directorio.SucursalCompania>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Directorio.SucursalCompania items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.SucursalCompania> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="CompaniaId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Direccion"></param>
            /// <param name="CodigoPostalId"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Directorio.SucursalCompania> Items(Int64? Id,String Nombre,String Descripcion,Int64? CompaniaId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,String Direccion,Int64? CodigoPostalId,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (CompaniaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CompaniaId, Depositary.sqlEnum.OperandEnum.Equal, CompaniaId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CompaniaId, Depositary.sqlEnum.OperandEnum.Equal, CompaniaId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Direccion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Direccion, Depositary.sqlEnum.OperandEnum.Equal, Direccion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Direccion, Depositary.sqlEnum.OperandEnum.Equal, Direccion);
                    }
                   
                }
                if (CodigoPostalId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoPostalId, Depositary.sqlEnum.OperandEnum.Equal, CodigoPostalId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoPostalId, Depositary.sqlEnum.OperandEnum.Equal, CodigoPostalId);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Directorio.SucursalCompania> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Directorio.SucursalCompania Add(Entities.Relations.Directorio.SucursalCompania item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Directorio.SucursalCompania)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Directorio.SucursalCompania item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Directorio.SucursalCompania with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="CompaniaId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Direccion"></param>
            /// <param name="CodigoPostalId"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int64 CompaniaId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,String Direccion,Int64 CodigoPostalId,Boolean Habilitado)
            {
                 Entities.Tables.Directorio.SucursalCompania item = new Entities.Tables.Directorio.SucursalCompania();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.CompaniaId = CompaniaId;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.CodigoExterno = CodigoExterno;
                 item.Direccion = Direccion;
                 item.CodigoPostalId = CodigoPostalId;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class SucursalCompania
	} //namespace Depositary.Business.Relations.Directorio
	namespace Depositary.Business.Relations.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ComandoContadora : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					ContadoraId,
					Nombre,
					Descripcion,
					Comando,
					TiempoDetencion,
					Habilitado
				}
			   protected List<Entities.Relations.Dispositivo.ComandoContadora> _cacheItemList = new List<Entities.Relations.Dispositivo.ComandoContadora>();
			   protected List<Entities.Relations.Dispositivo.ComandoContadora> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public ComandoContadora() : base()
            {
                base._dataItem = new Entities.Relations.Dispositivo.ComandoContadora();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Dispositivo.ComandoContadora item)
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
         /// <summary>
         /// ComandoContadora Add Method
         /// </summary>
         /// <param name='Depositary.Entities.Relations.Dispositivo.Contadora ContadoraId'></param>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Comando'></param>
         /// <param name='TiempoDetencion'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Dispositivo.ComandoContadora</returns>
			public Entities.Relations.Dispositivo.ComandoContadora Add(Depositary.Entities.Relations.Dispositivo.Contadora ContadoraId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,Boolean Habilitado) 
			{
			  return (Entities.Relations.Dispositivo.ComandoContadora)base.Add(new Entities.Relations.Dispositivo.ComandoContadora(ContadoraId,Nombre,Descripcion,Comando,TiempoDetencion,Habilitado));
			}
            public new List<Entities.Relations.Dispositivo.ComandoContadora> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Dispositivo.ComandoContadora>().ToList<Entities.Relations.Dispositivo.ComandoContadora>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Dispositivo.ComandoContadora items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.ComandoContadora> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="ContadoraId"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Comando"></param>
            /// <param name="TiempoDetencion"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.ComandoContadora> Items(Int64? Id,Int64? ContadoraId,String Nombre,String Descripcion,String Comando,Int64? TiempoDetencion,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (ContadoraId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContadoraId, Depositary.sqlEnum.OperandEnum.Equal, ContadoraId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContadoraId, Depositary.sqlEnum.OperandEnum.Equal, ContadoraId);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Comando != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Comando, Depositary.sqlEnum.OperandEnum.Equal, Comando);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Comando, Depositary.sqlEnum.OperandEnum.Equal, Comando);
                    }
                   
                }
                if (TiempoDetencion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TiempoDetencion, Depositary.sqlEnum.OperandEnum.Equal, TiempoDetencion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TiempoDetencion, Depositary.sqlEnum.OperandEnum.Equal, TiempoDetencion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Dispositivo.ComandoContadora> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Dispositivo.ComandoContadora Add(Entities.Relations.Dispositivo.ComandoContadora item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Dispositivo.ComandoContadora)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Dispositivo.ComandoContadora item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Dispositivo.ComandoContadora with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="ContadoraId"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Comando"></param>
            /// <param name="TiempoDetencion"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 ContadoraId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,Boolean Habilitado)
            {
                 Entities.Tables.Dispositivo.ComandoContadora item = new Entities.Tables.Dispositivo.ComandoContadora();
                 item.Id = Id;
                 item.ContadoraId = ContadoraId;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.Comando = Comando;
                 item.TiempoDetencion = TiempoDetencion;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class ComandoContadora
	} //namespace Depositary.Business.Relations.Dispositivo
	namespace Depositary.Business.Relations.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ConfiguracionMaquina : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					TipoId,
					MaquinaId,
					Valor,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Dispositivo.ConfiguracionMaquina> _cacheItemList = new List<Entities.Relations.Dispositivo.ConfiguracionMaquina>();
			   protected List<Entities.Relations.Dispositivo.ConfiguracionMaquina> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public ConfiguracionMaquina() : base()
            {
                base._dataItem = new Entities.Relations.Dispositivo.ConfiguracionMaquina();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Dispositivo.ConfiguracionMaquina item)
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
         /// <summary>
         /// ConfiguracionMaquina Add Method
         /// </summary>
         /// <param name='Depositary.Entities.Relations.Dispositivo.TipoConfiguracionMaquina TipoId'></param>
         /// <param name='Depositary.Entities.Relations.Dispositivo.Maquina MaquinaId'></param>
         /// <param name='Valor'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Dispositivo.ConfiguracionMaquina</returns>
			public Entities.Relations.Dispositivo.ConfiguracionMaquina Add(Depositary.Entities.Relations.Dispositivo.TipoConfiguracionMaquina TipoId,Depositary.Entities.Relations.Dispositivo.Maquina MaquinaId,String Valor,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Dispositivo.ConfiguracionMaquina)base.Add(new Entities.Relations.Dispositivo.ConfiguracionMaquina(TipoId,MaquinaId,Valor,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Dispositivo.ConfiguracionMaquina> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Dispositivo.ConfiguracionMaquina>().ToList<Entities.Relations.Dispositivo.ConfiguracionMaquina>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Dispositivo.ConfiguracionMaquina items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.ConfiguracionMaquina> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TipoId"></param>
            /// <param name="MaquinaId"></param>
            /// <param name="Valor"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.ConfiguracionMaquina> Items(Int64? Id,Int64? TipoId,Int64? MaquinaId,String Valor,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (MaquinaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.MaquinaId, Depositary.sqlEnum.OperandEnum.Equal, MaquinaId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.MaquinaId, Depositary.sqlEnum.OperandEnum.Equal, MaquinaId);
                    }
                   
                }
                if (Valor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Dispositivo.ConfiguracionMaquina> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Dispositivo.ConfiguracionMaquina Add(Entities.Relations.Dispositivo.ConfiguracionMaquina item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Dispositivo.ConfiguracionMaquina)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Dispositivo.ConfiguracionMaquina item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Dispositivo.ConfiguracionMaquina with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TipoId"></param>
            /// <param name="MaquinaId"></param>
            /// <param name="Valor"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 TipoId,Int64 MaquinaId,String Valor,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Dispositivo.ConfiguracionMaquina item = new Entities.Tables.Dispositivo.ConfiguracionMaquina();
                 item.Id = Id;
                 item.TipoId = TipoId;
                 item.MaquinaId = MaquinaId;
                 item.Valor = Valor;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class ConfiguracionMaquina
	} //namespace Depositary.Business.Relations.Dispositivo
	namespace Depositary.Business.Relations.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Contadora : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado
				}
			   protected List<Entities.Relations.Dispositivo.Contadora> _cacheItemList = new List<Entities.Relations.Dispositivo.Contadora>();
			   protected List<Entities.Relations.Dispositivo.Contadora> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Contadora() : base()
            {
                base._dataItem = new Entities.Relations.Dispositivo.Contadora();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Dispositivo.Contadora item)
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
         /// <summary>
         /// Contadora Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Dispositivo.Contadora</returns>
			public Entities.Relations.Dispositivo.Contadora Add(String Nombre,String Descripcion,Boolean Habilitado) 
			{
			  return (Entities.Relations.Dispositivo.Contadora)base.Add(new Entities.Relations.Dispositivo.Contadora(Nombre,Descripcion,Habilitado));
			}
            public new List<Entities.Relations.Dispositivo.Contadora> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Dispositivo.Contadora>().ToList<Entities.Relations.Dispositivo.Contadora>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Dispositivo.Contadora items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.Contadora> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.Contadora> Items(Int64? Id,String Nombre,String Descripcion,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Dispositivo.Contadora> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Dispositivo.Contadora Add(Entities.Relations.Dispositivo.Contadora item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Dispositivo.Contadora)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Dispositivo.Contadora item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Dispositivo.Contadora with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Boolean Habilitado)
            {
                 Entities.Tables.Dispositivo.Contadora item = new Entities.Tables.Dispositivo.Contadora();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Contadora
	} //namespace Depositary.Business.Relations.Dispositivo
	namespace Depositary.Business.Relations.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Estado : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Dispositivo.Estado> _cacheItemList = new List<Entities.Relations.Dispositivo.Estado>();
			   protected List<Entities.Relations.Dispositivo.Estado> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Estado() : base()
            {
                base._dataItem = new Entities.Relations.Dispositivo.Estado();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Dispositivo.Estado item)
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
         /// <summary>
         /// Estado Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Dispositivo.Estado</returns>
			public Entities.Relations.Dispositivo.Estado Add(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Dispositivo.Estado)base.Add(new Entities.Relations.Dispositivo.Estado(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Dispositivo.Estado> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Dispositivo.Estado>().ToList<Entities.Relations.Dispositivo.Estado>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Dispositivo.Estado items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.Estado> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.Estado> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Dispositivo.Estado> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Dispositivo.Estado Add(Entities.Relations.Dispositivo.Estado item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Dispositivo.Estado)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Dispositivo.Estado item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Dispositivo.Estado with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Dispositivo.Estado item = new Entities.Tables.Dispositivo.Estado();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Estado
	} //namespace Depositary.Business.Relations.Dispositivo
	namespace Depositary.Business.Relations.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Maquina : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					SucursalCompaniaId,
					NumeroSerie,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					MaquinaTipoId,
					Habilitado
				}
			   protected List<Entities.Relations.Dispositivo.Maquina> _cacheItemList = new List<Entities.Relations.Dispositivo.Maquina>();
			   protected List<Entities.Relations.Dispositivo.Maquina> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Maquina() : base()
            {
                base._dataItem = new Entities.Relations.Dispositivo.Maquina();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Dispositivo.Maquina item)
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
         /// <summary>
         /// Maquina Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Directorio.SucursalCompania SucursalCompaniaId'></param>
         /// <param name='NumeroSerie'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='MaquinaTipoId'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Dispositivo.Maquina</returns>
			public Entities.Relations.Dispositivo.Maquina Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Directorio.SucursalCompania SucursalCompaniaId,String NumeroSerie,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Int64 MaquinaTipoId,Boolean Habilitado) 
			{
			  return (Entities.Relations.Dispositivo.Maquina)base.Add(new Entities.Relations.Dispositivo.Maquina(Nombre,Descripcion,SucursalCompaniaId,NumeroSerie,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,MaquinaTipoId,Habilitado));
			}
            public new List<Entities.Relations.Dispositivo.Maquina> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Dispositivo.Maquina>().ToList<Entities.Relations.Dispositivo.Maquina>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Dispositivo.Maquina items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.Maquina> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="SucursalCompaniaId"></param>
            /// <param name="NumeroSerie"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="MaquinaTipoId"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.Maquina> Items(Int64? Id,String Nombre,String Descripcion,Int64? SucursalCompaniaId,String NumeroSerie,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Int64? MaquinaTipoId,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (SucursalCompaniaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalCompaniaId, Depositary.sqlEnum.OperandEnum.Equal, SucursalCompaniaId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SucursalCompaniaId, Depositary.sqlEnum.OperandEnum.Equal, SucursalCompaniaId);
                    }
                   
                }
                if (NumeroSerie != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.NumeroSerie, Depositary.sqlEnum.OperandEnum.Equal, NumeroSerie);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.NumeroSerie, Depositary.sqlEnum.OperandEnum.Equal, NumeroSerie);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (MaquinaTipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.MaquinaTipoId, Depositary.sqlEnum.OperandEnum.Equal, MaquinaTipoId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.MaquinaTipoId, Depositary.sqlEnum.OperandEnum.Equal, MaquinaTipoId);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Dispositivo.Maquina> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Dispositivo.Maquina Add(Entities.Relations.Dispositivo.Maquina item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Dispositivo.Maquina)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Dispositivo.Maquina item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Dispositivo.Maquina with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="SucursalCompaniaId"></param>
            /// <param name="NumeroSerie"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="MaquinaTipoId"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int64 SucursalCompaniaId,String NumeroSerie,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Int64 MaquinaTipoId,Boolean Habilitado)
            {
                 Entities.Tables.Dispositivo.Maquina item = new Entities.Tables.Dispositivo.Maquina();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.SucursalCompaniaId = SucursalCompaniaId;
                 item.NumeroSerie = NumeroSerie;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.CodigoExterno = CodigoExterno;
                 item.MaquinaTipoId = MaquinaTipoId;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Maquina
	} //namespace Depositary.Business.Relations.Dispositivo
	namespace Depositary.Business.Relations.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoConfiguracionMaquina : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Dispositivo.TipoConfiguracionMaquina> _cacheItemList = new List<Entities.Relations.Dispositivo.TipoConfiguracionMaquina>();
			   protected List<Entities.Relations.Dispositivo.TipoConfiguracionMaquina> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public TipoConfiguracionMaquina() : base()
            {
                base._dataItem = new Entities.Relations.Dispositivo.TipoConfiguracionMaquina();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Dispositivo.TipoConfiguracionMaquina item)
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
         /// <summary>
         /// TipoConfiguracionMaquina Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Dispositivo.TipoConfiguracionMaquina</returns>
			public Entities.Relations.Dispositivo.TipoConfiguracionMaquina Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Dispositivo.TipoConfiguracionMaquina)base.Add(new Entities.Relations.Dispositivo.TipoConfiguracionMaquina(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Dispositivo.TipoConfiguracionMaquina> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Dispositivo.TipoConfiguracionMaquina>().ToList<Entities.Relations.Dispositivo.TipoConfiguracionMaquina>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Dispositivo.TipoConfiguracionMaquina items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.TipoConfiguracionMaquina> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Dispositivo.TipoConfiguracionMaquina> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Dispositivo.TipoConfiguracionMaquina> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Dispositivo.TipoConfiguracionMaquina Add(Entities.Relations.Dispositivo.TipoConfiguracionMaquina item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Dispositivo.TipoConfiguracionMaquina)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Dispositivo.TipoConfiguracionMaquina item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Dispositivo.TipoConfiguracionMaquina with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Dispositivo.TipoConfiguracionMaquina item = new Entities.Tables.Dispositivo.TipoConfiguracionMaquina();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoConfiguracionMaquina
	} //namespace Depositary.Business.Relations.Dispositivo
	namespace Depositary.Business.Relations.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Evento : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					TipoId,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Operacion.Evento> _cacheItemList = new List<Entities.Relations.Operacion.Evento>();
			   protected List<Entities.Relations.Operacion.Evento> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Evento() : base()
            {
                base._dataItem = new Entities.Relations.Operacion.Evento();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Operacion.Evento item)
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
         /// <summary>
         /// Evento Add Method
         /// </summary>
         /// <param name='TipoId'></param>
         /// <param name='Descripcion'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Operacion.Evento</returns>
			public Entities.Relations.Operacion.Evento Add(Int64 TipoId,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Operacion.Evento)base.Add(new Entities.Relations.Operacion.Evento(TipoId,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Operacion.Evento> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Operacion.Evento>().ToList<Entities.Relations.Operacion.Evento>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Operacion.Evento items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.Evento> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TipoId"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.Evento> Items(Int64? Id,Int64? TipoId,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Operacion.Evento> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Operacion.Evento Add(Entities.Relations.Operacion.Evento item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Operacion.Evento)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Operacion.Evento item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Operacion.Evento with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TipoId"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 TipoId,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Operacion.Evento item = new Entities.Tables.Operacion.Evento();
                 item.Id = Id;
                 item.TipoId = TipoId;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Evento
	} //namespace Depositary.Business.Relations.Operacion
	namespace Depositary.Business.Relations.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoEvento : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Operacion.TipoEvento> _cacheItemList = new List<Entities.Relations.Operacion.TipoEvento>();
			   protected List<Entities.Relations.Operacion.TipoEvento> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public TipoEvento() : base()
            {
                base._dataItem = new Entities.Relations.Operacion.TipoEvento();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Operacion.TipoEvento item)
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
         /// <summary>
         /// TipoEvento Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Operacion.TipoEvento</returns>
			public Entities.Relations.Operacion.TipoEvento Add(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Operacion.TipoEvento)base.Add(new Entities.Relations.Operacion.TipoEvento(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Operacion.TipoEvento> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Operacion.TipoEvento>().ToList<Entities.Relations.Operacion.TipoEvento>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Operacion.TipoEvento items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.TipoEvento> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.TipoEvento> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Operacion.TipoEvento> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Operacion.TipoEvento Add(Entities.Relations.Operacion.TipoEvento item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Operacion.TipoEvento)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Operacion.TipoEvento item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Operacion.TipoEvento with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Operacion.TipoEvento item = new Entities.Tables.Operacion.TipoEvento();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoEvento
	} //namespace Depositary.Business.Relations.Operacion
	namespace Depositary.Business.Relations.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Transaccion : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					MaquinaId,
					UsuarioId,
					ValorDeclarado,
					ValorCertificado,
					FechaInicio,
					FechaFin
				}
			   protected List<Entities.Relations.Operacion.Transaccion> _cacheItemList = new List<Entities.Relations.Operacion.Transaccion>();
			   protected List<Entities.Relations.Operacion.Transaccion> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Transaccion() : base()
            {
                base._dataItem = new Entities.Relations.Operacion.Transaccion();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Operacion.Transaccion item)
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
         /// <summary>
         /// Transaccion Add Method
         /// </summary>
         /// <param name='MaquinaId'></param>
         /// <param name='UsuarioId'></param>
         /// <param name='ValorDeclarado'></param>
         /// <param name='ValorCertificado'></param>
         /// <param name='FechaInicio'></param>
         /// <param name='FechaFin'></param>
         /// <returns>Entities.Relations.Operacion.Transaccion</returns>
			public Entities.Relations.Operacion.Transaccion Add(Int64 MaquinaId,Int64 UsuarioId,Double ValorDeclarado,Double ValorCertificado,DateTime FechaInicio,DateTime FechaFin) 
			{
			  return (Entities.Relations.Operacion.Transaccion)base.Add(new Entities.Relations.Operacion.Transaccion(MaquinaId,UsuarioId,ValorDeclarado,ValorCertificado,FechaInicio,FechaFin));
			}
            public new List<Entities.Relations.Operacion.Transaccion> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Operacion.Transaccion>().ToList<Entities.Relations.Operacion.Transaccion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Operacion.Transaccion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.Transaccion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="MaquinaId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="ValorDeclarado"></param>
            /// <param name="ValorCertificado"></param>
            /// <param name="FechaInicio"></param>
            /// <param name="FechaFin"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.Transaccion> Items(Int64? Id,Int64? MaquinaId,Int64? UsuarioId,Double? ValorDeclarado,Double? ValorCertificado,DateTime? FechaInicio,DateTime? FechaFin)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (MaquinaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.MaquinaId, Depositary.sqlEnum.OperandEnum.Equal, MaquinaId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.MaquinaId, Depositary.sqlEnum.OperandEnum.Equal, MaquinaId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (ValorDeclarado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorDeclarado, Depositary.sqlEnum.OperandEnum.Equal, ValorDeclarado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorDeclarado, Depositary.sqlEnum.OperandEnum.Equal, ValorDeclarado);
                    }
                   
                }
                if (ValorCertificado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorCertificado, Depositary.sqlEnum.OperandEnum.Equal, ValorCertificado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorCertificado, Depositary.sqlEnum.OperandEnum.Equal, ValorCertificado);
                    }
                   
                }
                if (FechaInicio != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaInicio, Depositary.sqlEnum.OperandEnum.Equal, FechaInicio);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaInicio, Depositary.sqlEnum.OperandEnum.Equal, FechaInicio);
                    }
                   
                }
                if (FechaFin != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaFin, Depositary.sqlEnum.OperandEnum.Equal, FechaFin);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaFin, Depositary.sqlEnum.OperandEnum.Equal, FechaFin);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Operacion.Transaccion> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Operacion.Transaccion Add(Entities.Relations.Operacion.Transaccion item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Operacion.Transaccion)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Operacion.Transaccion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Operacion.Transaccion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="MaquinaId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="ValorDeclarado"></param>
            /// <param name="ValorCertificado"></param>
            /// <param name="FechaInicio"></param>
            /// <param name="FechaFin"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 MaquinaId,Int64 UsuarioId,Double ValorDeclarado,Double ValorCertificado,DateTime FechaInicio,DateTime FechaFin)
            {
                 Entities.Tables.Operacion.Transaccion item = new Entities.Tables.Operacion.Transaccion();
                 item.Id = Id;
                 item.MaquinaId = MaquinaId;
                 item.UsuarioId = UsuarioId;
                 item.ValorDeclarado = ValorDeclarado;
                 item.ValorCertificado = ValorCertificado;
                 item.FechaInicio = FechaInicio;
                 item.FechaFin = FechaFin;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Transaccion
	} //namespace Depositary.Business.Relations.Operacion
	namespace Depositary.Business.Relations.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TransaccionDetalle : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					TransaccionId,
					DenominacionId,
					CantidadCertificada,
					CantidadDeclarada,
					Fecha
				}
			   protected List<Entities.Relations.Operacion.TransaccionDetalle> _cacheItemList = new List<Entities.Relations.Operacion.TransaccionDetalle>();
			   protected List<Entities.Relations.Operacion.TransaccionDetalle> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public TransaccionDetalle() : base()
            {
                base._dataItem = new Entities.Relations.Operacion.TransaccionDetalle();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Operacion.TransaccionDetalle item)
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
         /// <summary>
         /// TransaccionDetalle Add Method
         /// </summary>
         /// <param name='Depositary.Entities.Relations.Operacion.Transaccion TransaccionId'></param>
         /// <param name='Depositary.Entities.Relations.Valor.Denominacion DenominacionId'></param>
         /// <param name='CantidadCertificada'></param>
         /// <param name='CantidadDeclarada'></param>
         /// <param name='Fecha'></param>
         /// <returns>Entities.Relations.Operacion.TransaccionDetalle</returns>
			public Entities.Relations.Operacion.TransaccionDetalle Add(Depositary.Entities.Relations.Operacion.Transaccion TransaccionId,Depositary.Entities.Relations.Valor.Denominacion DenominacionId,Int64 CantidadCertificada,Int64 CantidadDeclarada,DateTime Fecha) 
			{
			  return (Entities.Relations.Operacion.TransaccionDetalle)base.Add(new Entities.Relations.Operacion.TransaccionDetalle(TransaccionId,DenominacionId,CantidadCertificada,CantidadDeclarada,Fecha));
			}
            public new List<Entities.Relations.Operacion.TransaccionDetalle> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Operacion.TransaccionDetalle>().ToList<Entities.Relations.Operacion.TransaccionDetalle>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Operacion.TransaccionDetalle items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.TransaccionDetalle> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TransaccionId"></param>
            /// <param name="DenominacionId"></param>
            /// <param name="CantidadCertificada"></param>
            /// <param name="CantidadDeclarada"></param>
            /// <param name="Fecha"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.TransaccionDetalle> Items(Int64? Id,Int64? TransaccionId,Int64? DenominacionId,Int64? CantidadCertificada,Int64? CantidadDeclarada,DateTime? Fecha)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (DenominacionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DenominacionId, Depositary.sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DenominacionId, Depositary.sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                   
                }
                if (CantidadCertificada != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadCertificada, Depositary.sqlEnum.OperandEnum.Equal, CantidadCertificada);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadCertificada, Depositary.sqlEnum.OperandEnum.Equal, CantidadCertificada);
                    }
                   
                }
                if (CantidadDeclarada != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadDeclarada, Depositary.sqlEnum.OperandEnum.Equal, CantidadDeclarada);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadDeclarada, Depositary.sqlEnum.OperandEnum.Equal, CantidadDeclarada);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Operacion.TransaccionDetalle> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Operacion.TransaccionDetalle Add(Entities.Relations.Operacion.TransaccionDetalle item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Operacion.TransaccionDetalle)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Operacion.TransaccionDetalle item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Operacion.TransaccionDetalle with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TransaccionId"></param>
            /// <param name="DenominacionId"></param>
            /// <param name="CantidadCertificada"></param>
            /// <param name="CantidadDeclarada"></param>
            /// <param name="Fecha"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 TransaccionId,Int64 DenominacionId,Int64 CantidadCertificada,Int64 CantidadDeclarada,DateTime Fecha)
            {
                 Entities.Tables.Operacion.TransaccionDetalle item = new Entities.Tables.Operacion.TransaccionDetalle();
                 item.Id = Id;
                 item.TransaccionId = TransaccionId;
                 item.DenominacionId = DenominacionId;
                 item.CantidadCertificada = CantidadCertificada;
                 item.CantidadDeclarada = CantidadDeclarada;
                 item.Fecha = Fecha;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TransaccionDetalle
	} //namespace Depositary.Business.Relations.Operacion
	namespace Depositary.Business.Relations.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Turno : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Desde,
					Hasta,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Operacion.Turno> _cacheItemList = new List<Entities.Relations.Operacion.Turno>();
			   protected List<Entities.Relations.Operacion.Turno> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Turno() : base()
            {
                base._dataItem = new Entities.Relations.Operacion.Turno();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Operacion.Turno item)
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
         /// <summary>
         /// Turno Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Desde'></param>
         /// <param name='Hasta'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Operacion.Turno</returns>
			public Entities.Relations.Operacion.Turno Add(String Nombre,String Descripcion,TimeSpan Desde,TimeSpan Hasta,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Operacion.Turno)base.Add(new Entities.Relations.Operacion.Turno(Nombre,Descripcion,Desde,Hasta,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Operacion.Turno> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Operacion.Turno>().ToList<Entities.Relations.Operacion.Turno>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Operacion.Turno items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.Turno> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Desde"></param>
            /// <param name="Hasta"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.Turno> Items(Int64? Id,String Nombre,String Descripcion,TimeSpan? Desde,TimeSpan? Hasta,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Desde != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Desde, Depositary.sqlEnum.OperandEnum.Equal, Desde);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Desde, Depositary.sqlEnum.OperandEnum.Equal, Desde);
                    }
                   
                }
                if (Hasta != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Hasta, Depositary.sqlEnum.OperandEnum.Equal, Hasta);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Hasta, Depositary.sqlEnum.OperandEnum.Equal, Hasta);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Operacion.Turno> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Operacion.Turno Add(Entities.Relations.Operacion.Turno item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Operacion.Turno)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Operacion.Turno item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Operacion.Turno with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Desde"></param>
            /// <param name="Hasta"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,TimeSpan Desde,TimeSpan Hasta,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Operacion.Turno item = new Entities.Tables.Operacion.Turno();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.Desde = Desde;
                 item.Hasta = Hasta;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Turno
	} //namespace Depositary.Business.Relations.Operacion
	namespace Depositary.Business.Relations.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TurnoUsuario : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					UsuarioId,
					TurnoId,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Operacion.TurnoUsuario> _cacheItemList = new List<Entities.Relations.Operacion.TurnoUsuario>();
			   protected List<Entities.Relations.Operacion.TurnoUsuario> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public TurnoUsuario() : base()
            {
                base._dataItem = new Entities.Relations.Operacion.TurnoUsuario();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Operacion.TurnoUsuario item)
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
         /// <summary>
         /// TurnoUsuario Add Method
         /// </summary>
         /// <param name='UsuarioId'></param>
         /// <param name='TurnoId'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Operacion.TurnoUsuario</returns>
			public Entities.Relations.Operacion.TurnoUsuario Add(Int64 UsuarioId,Int64 TurnoId,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Operacion.TurnoUsuario)base.Add(new Entities.Relations.Operacion.TurnoUsuario(UsuarioId,TurnoId,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Operacion.TurnoUsuario> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Operacion.TurnoUsuario>().ToList<Entities.Relations.Operacion.TurnoUsuario>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Operacion.TurnoUsuario items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.TurnoUsuario> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="TurnoId"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Operacion.TurnoUsuario> Items(Int64? Id,Int64? UsuarioId,Int64? TurnoId,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (TurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TurnoId, Depositary.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TurnoId, Depositary.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Operacion.TurnoUsuario> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Operacion.TurnoUsuario Add(Entities.Relations.Operacion.TurnoUsuario item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Operacion.TurnoUsuario)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Operacion.TurnoUsuario item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Operacion.TurnoUsuario with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="TurnoId"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 UsuarioId,Int64 TurnoId,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Operacion.TurnoUsuario item = new Entities.Tables.Operacion.TurnoUsuario();
                 item.Id = Id;
                 item.UsuarioId = UsuarioId;
                 item.TurnoId = TurnoId;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TurnoUsuario
	} //namespace Depositary.Business.Relations.Operacion
	namespace Depositary.Business.Relations.Regionalizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Lenguaje : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado
				}
			   protected List<Entities.Relations.Regionalizacion.Lenguaje> _cacheItemList = new List<Entities.Relations.Regionalizacion.Lenguaje>();
			   protected List<Entities.Relations.Regionalizacion.Lenguaje> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Lenguaje() : base()
            {
                base._dataItem = new Entities.Relations.Regionalizacion.Lenguaje();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Regionalizacion.Lenguaje item)
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
         /// <summary>
         /// Lenguaje Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Regionalizacion.Lenguaje</returns>
			public Entities.Relations.Regionalizacion.Lenguaje Add(String Nombre,String Descripcion,Boolean Habilitado) 
			{
			  return (Entities.Relations.Regionalizacion.Lenguaje)base.Add(new Entities.Relations.Regionalizacion.Lenguaje(Nombre,Descripcion,Habilitado));
			}
            public new List<Entities.Relations.Regionalizacion.Lenguaje> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Regionalizacion.Lenguaje>().ToList<Entities.Relations.Regionalizacion.Lenguaje>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Regionalizacion.Lenguaje items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Regionalizacion.Lenguaje> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Regionalizacion.Lenguaje> Items(Int64? Id,String Nombre,String Descripcion,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Regionalizacion.Lenguaje> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Regionalizacion.Lenguaje Add(Entities.Relations.Regionalizacion.Lenguaje item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Regionalizacion.Lenguaje)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Regionalizacion.Lenguaje item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Regionalizacion.Lenguaje with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Boolean Habilitado)
            {
                 Entities.Tables.Regionalizacion.Lenguaje item = new Entities.Tables.Regionalizacion.Lenguaje();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Lenguaje
	} //namespace Depositary.Business.Relations.Regionalizacion
	namespace Depositary.Business.Relations.Regionalizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class LenguajeItem : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					LenguajeId,
					Clave,
					Texto,
					Habilitado
				}
			   protected List<Entities.Relations.Regionalizacion.LenguajeItem> _cacheItemList = new List<Entities.Relations.Regionalizacion.LenguajeItem>();
			   protected List<Entities.Relations.Regionalizacion.LenguajeItem> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public LenguajeItem() : base()
            {
                base._dataItem = new Entities.Relations.Regionalizacion.LenguajeItem();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Regionalizacion.LenguajeItem item)
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
         /// <summary>
         /// LenguajeItem Add Method
         /// </summary>
         /// <param name='Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId'></param>
         /// <param name='Clave'></param>
         /// <param name='Texto'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Regionalizacion.LenguajeItem</returns>
			public Entities.Relations.Regionalizacion.LenguajeItem Add(Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,String Clave,String Texto,Boolean Habilitado) 
			{
			  return (Entities.Relations.Regionalizacion.LenguajeItem)base.Add(new Entities.Relations.Regionalizacion.LenguajeItem(LenguajeId,Clave,Texto,Habilitado));
			}
            public new List<Entities.Relations.Regionalizacion.LenguajeItem> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Regionalizacion.LenguajeItem>().ToList<Entities.Relations.Regionalizacion.LenguajeItem>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Regionalizacion.LenguajeItem items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Regionalizacion.LenguajeItem> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="LenguajeId"></param>
            /// <param name="Clave"></param>
            /// <param name="Texto"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Regionalizacion.LenguajeItem> Items(Int64? Id,Int64? LenguajeId,String Clave,String Texto,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (LenguajeId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.LenguajeId, Depositary.sqlEnum.OperandEnum.Equal, LenguajeId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.LenguajeId, Depositary.sqlEnum.OperandEnum.Equal, LenguajeId);
                    }
                   
                }
                if (Clave != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Clave, Depositary.sqlEnum.OperandEnum.Equal, Clave);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Clave, Depositary.sqlEnum.OperandEnum.Equal, Clave);
                    }
                   
                }
                if (Texto != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Texto, Depositary.sqlEnum.OperandEnum.Equal, Texto);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Texto, Depositary.sqlEnum.OperandEnum.Equal, Texto);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Regionalizacion.LenguajeItem> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Regionalizacion.LenguajeItem Add(Entities.Relations.Regionalizacion.LenguajeItem item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Regionalizacion.LenguajeItem)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Regionalizacion.LenguajeItem item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Regionalizacion.LenguajeItem with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="LenguajeId"></param>
            /// <param name="Clave"></param>
            /// <param name="Texto"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 LenguajeId,String Clave,String Texto,Boolean Habilitado)
            {
                 Entities.Tables.Regionalizacion.LenguajeItem item = new Entities.Tables.Regionalizacion.LenguajeItem();
                 item.Id = Id;
                 item.LenguajeId = LenguajeId;
                 item.Clave = Clave;
                 item.Texto = Texto;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class LenguajeItem
	} //namespace Depositary.Business.Relations.Regionalizacion
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Aplicacion : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Tipo_Id,
					Nombre,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.Aplicacion> _cacheItemList = new List<Entities.Relations.Seguridad.Aplicacion>();
			   protected List<Entities.Relations.Seguridad.Aplicacion> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Aplicacion() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.Aplicacion();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.Aplicacion item)
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
         /// <summary>
         /// Aplicacion Add Method
         /// </summary>
         /// <param name='Depositary.Entities.Relations.Seguridad.TipoAplicacion Tipo_Id'></param>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.Aplicacion</returns>
			public Entities.Relations.Seguridad.Aplicacion Add(Depositary.Entities.Relations.Seguridad.TipoAplicacion Tipo_Id,String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.Aplicacion)base.Add(new Entities.Relations.Seguridad.Aplicacion(Tipo_Id,Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.Aplicacion> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.Aplicacion>().ToList<Entities.Relations.Seguridad.Aplicacion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.Aplicacion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Aplicacion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Tipo_Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Aplicacion> Items(Int64? Id,Int64? Tipo_Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Tipo_Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.Aplicacion> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.Aplicacion Add(Entities.Relations.Seguridad.Aplicacion item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.Aplicacion)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.Aplicacion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.Aplicacion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Tipo_Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 Tipo_Id,String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.Aplicacion item = new Entities.Tables.Seguridad.Aplicacion();
                 item.Id = Id;
                 item.Tipo_Id = Tipo_Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Aplicacion
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class EstadoLogico : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.EstadoLogico> _cacheItemList = new List<Entities.Relations.Seguridad.EstadoLogico>();
			   protected List<Entities.Relations.Seguridad.EstadoLogico> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public EstadoLogico() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.EstadoLogico();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.EstadoLogico item)
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
         /// <summary>
         /// EstadoLogico Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.EstadoLogico</returns>
			public Entities.Relations.Seguridad.EstadoLogico Add(String Nombre,String Descripcion,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.EstadoLogico)base.Add(new Entities.Relations.Seguridad.EstadoLogico(Nombre,Descripcion,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.EstadoLogico> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.EstadoLogico>().ToList<Entities.Relations.Seguridad.EstadoLogico>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.EstadoLogico items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.EstadoLogico> Items(Int16 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.EstadoLogico> Items(Int16? Id,String Nombre,String Descripcion,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.EstadoLogico> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.EstadoLogico Add(Entities.Relations.Seguridad.EstadoLogico item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.EstadoLogico)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.EstadoLogico item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.EstadoLogico with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int16 Id,String Nombre,String Descripcion,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.EstadoLogico item = new Entities.Tables.Seguridad.EstadoLogico();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class EstadoLogico
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Funcion : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Aplicacion_Id,
					Tipo_Id,
					Nombre,
					Descripcion,
					Referencia,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.Funcion> _cacheItemList = new List<Entities.Relations.Seguridad.Funcion>();
			   protected List<Entities.Relations.Seguridad.Funcion> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Funcion() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.Funcion();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.Funcion item)
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
         /// <summary>
         /// Funcion Add Method
         /// </summary>
         /// <param name='Depositary.Entities.Relations.Seguridad.Aplicacion Aplicacion_Id'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.TipoFuncion Tipo_Id'></param>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Referencia'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.Funcion</returns>
			public Entities.Relations.Seguridad.Funcion Add(Depositary.Entities.Relations.Seguridad.Aplicacion Aplicacion_Id,Depositary.Entities.Relations.Seguridad.TipoFuncion Tipo_Id,String Nombre,String Descripcion,String Referencia,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.Funcion)base.Add(new Entities.Relations.Seguridad.Funcion(Aplicacion_Id,Tipo_Id,Nombre,Descripcion,Referencia,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.Funcion> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.Funcion>().ToList<Entities.Relations.Seguridad.Funcion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.Funcion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Funcion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Aplicacion_Id"></param>
            /// <param name="Tipo_Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Referencia"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Funcion> Items(Int64? Id,Int64? Aplicacion_Id,Int64? Tipo_Id,String Nombre,String Descripcion,String Referencia,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Aplicacion_Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Aplicacion_Id, Depositary.sqlEnum.OperandEnum.Equal, Aplicacion_Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Aplicacion_Id, Depositary.sqlEnum.OperandEnum.Equal, Aplicacion_Id);
                    }
                   
                }
                if (Tipo_Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Referencia != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Referencia, Depositary.sqlEnum.OperandEnum.Equal, Referencia);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Referencia, Depositary.sqlEnum.OperandEnum.Equal, Referencia);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.Funcion> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.Funcion Add(Entities.Relations.Seguridad.Funcion item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.Funcion)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.Funcion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.Funcion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Aplicacion_Id"></param>
            /// <param name="Tipo_Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Referencia"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 Aplicacion_Id,Int64 Tipo_Id,String Nombre,String Descripcion,String Referencia,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.Funcion item = new Entities.Tables.Seguridad.Funcion();
                 item.Id = Id;
                 item.Aplicacion_Id = Aplicacion_Id;
                 item.Tipo_Id = Tipo_Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.Referencia = Referencia;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Funcion
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Identificador : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					TipoId,
					UsuarioId,
					Valor,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.Identificador> _cacheItemList = new List<Entities.Relations.Seguridad.Identificador>();
			   protected List<Entities.Relations.Seguridad.Identificador> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Identificador() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.Identificador();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.Identificador item)
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
         /// <summary>
         /// Identificador Add Method
         /// </summary>
         /// <param name='TipoId'></param>
         /// <param name='UsuarioId'></param>
         /// <param name='Valor'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.Identificador</returns>
			public Entities.Relations.Seguridad.Identificador Add(Int64 TipoId,Int64 UsuarioId,String Valor,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.Identificador)base.Add(new Entities.Relations.Seguridad.Identificador(TipoId,UsuarioId,Valor,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.Identificador> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.Identificador>().ToList<Entities.Relations.Seguridad.Identificador>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.Identificador items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Identificador> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TipoId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="Valor"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Identificador> Items(Int64? Id,Int64? TipoId,Int64? UsuarioId,String Valor,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (Valor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.Identificador> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.Identificador Add(Entities.Relations.Seguridad.Identificador item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.Identificador)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.Identificador item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.Identificador with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TipoId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="Valor"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 TipoId,Int64 UsuarioId,String Valor,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.Identificador item = new Entities.Tables.Seguridad.Identificador();
                 item.Id = Id;
                 item.TipoId = TipoId;
                 item.UsuarioId = UsuarioId;
                 item.Valor = Valor;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Identificador
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Menu : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Tipo_Id,
					Nombre,
					Descripcion,
					Funcion_Id,
					Imagen,
					DependeDe,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.Menu> _cacheItemList = new List<Entities.Relations.Seguridad.Menu>();
			   protected List<Entities.Relations.Seguridad.Menu> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Menu() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.Menu();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.Menu item)
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
         /// <summary>
         /// Menu Add Method
         /// </summary>
         /// <param name='Depositary.Entities.Relations.Seguridad.TipoMenu Tipo_Id'></param>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id'></param>
         /// <param name='Imagen'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.Menu DependeDe'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.Menu</returns>
			public Entities.Relations.Seguridad.Menu Add(Depositary.Entities.Relations.Seguridad.TipoMenu Tipo_Id,String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id,String Imagen,Depositary.Entities.Relations.Seguridad.Menu DependeDe,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.Menu)base.Add(new Entities.Relations.Seguridad.Menu(Tipo_Id,Nombre,Descripcion,Funcion_Id,Imagen,DependeDe,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.Menu> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.Menu>().ToList<Entities.Relations.Seguridad.Menu>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.Menu items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Menu> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Tipo_Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Funcion_Id"></param>
            /// <param name="Imagen"></param>
            /// <param name="DependeDe"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Menu> Items(Int64? Id,Int64? Tipo_Id,String Nombre,String Descripcion,Int64? Funcion_Id,String Imagen,Int64? DependeDe,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Tipo_Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Funcion_Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                   
                }
                if (Imagen != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Imagen, Depositary.sqlEnum.OperandEnum.Equal, Imagen);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Imagen, Depositary.sqlEnum.OperandEnum.Equal, Imagen);
                    }
                   
                }
                if (DependeDe != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DependeDe, Depositary.sqlEnum.OperandEnum.Equal, DependeDe);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DependeDe, Depositary.sqlEnum.OperandEnum.Equal, DependeDe);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.Menu> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.Menu Add(Entities.Relations.Seguridad.Menu item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.Menu)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.Menu item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.Menu with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Tipo_Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Funcion_Id"></param>
            /// <param name="Imagen"></param>
            /// <param name="DependeDe"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 Tipo_Id,String Nombre,String Descripcion,Int64 Funcion_Id,String Imagen,Int64 DependeDe,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.Menu item = new Entities.Tables.Seguridad.Menu();
                 item.Id = Id;
                 item.Tipo_Id = Tipo_Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.Funcion_Id = Funcion_Id;
                 item.Imagen = Imagen;
                 item.DependeDe = DependeDe;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Menu
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Rol : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					DependeDe,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.Rol> _cacheItemList = new List<Entities.Relations.Seguridad.Rol>();
			   protected List<Entities.Relations.Seguridad.Rol> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Rol() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.Rol();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.Rol item)
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
         /// <summary>
         /// Rol Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.Rol DependeDe'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.Rol</returns>
			public Entities.Relations.Seguridad.Rol Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.Rol DependeDe,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.Rol)base.Add(new Entities.Relations.Seguridad.Rol(Nombre,Descripcion,DependeDe,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.Rol> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.Rol>().ToList<Entities.Relations.Seguridad.Rol>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.Rol items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Rol> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="DependeDe"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Rol> Items(Int64? Id,String Nombre,String Descripcion,Int64? DependeDe,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (DependeDe != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DependeDe, Depositary.sqlEnum.OperandEnum.Equal, DependeDe);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DependeDe, Depositary.sqlEnum.OperandEnum.Equal, DependeDe);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.Rol> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.Rol Add(Entities.Relations.Seguridad.Rol item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.Rol)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.Rol item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.Rol with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="DependeDe"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int64 DependeDe,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.Rol item = new Entities.Tables.Seguridad.Rol();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.DependeDe = DependeDe;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Rol
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class RolFuncion : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Funcion_Id,
					Rol_Id,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.RolFuncion> _cacheItemList = new List<Entities.Relations.Seguridad.RolFuncion>();
			   protected List<Entities.Relations.Seguridad.RolFuncion> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public RolFuncion() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.RolFuncion();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.RolFuncion item)
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
         /// <summary>
         /// RolFuncion Add Method
         /// </summary>
         /// <param name='Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.Rol Rol_Id'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.RolFuncion</returns>
			public Entities.Relations.Seguridad.RolFuncion Add(Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id,Depositary.Entities.Relations.Seguridad.Rol Rol_Id,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.RolFuncion)base.Add(new Entities.Relations.Seguridad.RolFuncion(Funcion_Id,Rol_Id,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.RolFuncion> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.RolFuncion>().ToList<Entities.Relations.Seguridad.RolFuncion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.RolFuncion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.RolFuncion> Items(Int16 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Funcion_Id"></param>
            /// <param name="Rol_Id"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.RolFuncion> Items(Int16? Id,Int64? Funcion_Id,Int64? Rol_Id,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Funcion_Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                   
                }
                if (Rol_Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Rol_Id, Depositary.sqlEnum.OperandEnum.Equal, Rol_Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Rol_Id, Depositary.sqlEnum.OperandEnum.Equal, Rol_Id);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.RolFuncion> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.RolFuncion Add(Entities.Relations.Seguridad.RolFuncion item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.RolFuncion)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.RolFuncion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.RolFuncion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Funcion_Id"></param>
            /// <param name="Rol_Id"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int16 Id,Int64 Funcion_Id,Int64 Rol_Id,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.RolFuncion item = new Entities.Tables.Seguridad.RolFuncion();
                 item.Id = Id;
                 item.Funcion_Id = Funcion_Id;
                 item.Rol_Id = Rol_Id;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class RolFuncion
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoAplicacion : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.TipoAplicacion> _cacheItemList = new List<Entities.Relations.Seguridad.TipoAplicacion>();
			   protected List<Entities.Relations.Seguridad.TipoAplicacion> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public TipoAplicacion() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.TipoAplicacion();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.TipoAplicacion item)
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
         /// <summary>
         /// TipoAplicacion Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.TipoAplicacion</returns>
			public Entities.Relations.Seguridad.TipoAplicacion Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.TipoAplicacion)base.Add(new Entities.Relations.Seguridad.TipoAplicacion(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.TipoAplicacion> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.TipoAplicacion>().ToList<Entities.Relations.Seguridad.TipoAplicacion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.TipoAplicacion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.TipoAplicacion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.TipoAplicacion> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.TipoAplicacion> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.TipoAplicacion Add(Entities.Relations.Seguridad.TipoAplicacion item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.TipoAplicacion)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.TipoAplicacion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.TipoAplicacion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.TipoAplicacion item = new Entities.Tables.Seguridad.TipoAplicacion();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoAplicacion
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoFuncion : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.TipoFuncion> _cacheItemList = new List<Entities.Relations.Seguridad.TipoFuncion>();
			   protected List<Entities.Relations.Seguridad.TipoFuncion> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public TipoFuncion() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.TipoFuncion();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.TipoFuncion item)
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
         /// <summary>
         /// TipoFuncion Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.TipoFuncion</returns>
			public Entities.Relations.Seguridad.TipoFuncion Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.TipoFuncion)base.Add(new Entities.Relations.Seguridad.TipoFuncion(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.TipoFuncion> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.TipoFuncion>().ToList<Entities.Relations.Seguridad.TipoFuncion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.TipoFuncion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.TipoFuncion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.TipoFuncion> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.TipoFuncion> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.TipoFuncion Add(Entities.Relations.Seguridad.TipoFuncion item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.TipoFuncion)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.TipoFuncion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.TipoFuncion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.TipoFuncion item = new Entities.Tables.Seguridad.TipoFuncion();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoFuncion
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoIdentificador : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Mascara,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.TipoIdentificador> _cacheItemList = new List<Entities.Relations.Seguridad.TipoIdentificador>();
			   protected List<Entities.Relations.Seguridad.TipoIdentificador> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public TipoIdentificador() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.TipoIdentificador();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.TipoIdentificador item)
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
         /// <summary>
         /// TipoIdentificador Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Mascara'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.TipoIdentificador</returns>
			public Entities.Relations.Seguridad.TipoIdentificador Add(String Nombre,String Descripcion,String Mascara,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.TipoIdentificador)base.Add(new Entities.Relations.Seguridad.TipoIdentificador(Nombre,Descripcion,Mascara,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.TipoIdentificador> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.TipoIdentificador>().ToList<Entities.Relations.Seguridad.TipoIdentificador>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.TipoIdentificador items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.TipoIdentificador> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Mascara"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.TipoIdentificador> Items(Int64? Id,String Nombre,String Descripcion,String Mascara,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Mascara != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Mascara, Depositary.sqlEnum.OperandEnum.Equal, Mascara);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Mascara, Depositary.sqlEnum.OperandEnum.Equal, Mascara);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.TipoIdentificador> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.TipoIdentificador Add(Entities.Relations.Seguridad.TipoIdentificador item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.TipoIdentificador)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.TipoIdentificador item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.TipoIdentificador with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Mascara"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,String Mascara,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.TipoIdentificador item = new Entities.Tables.Seguridad.TipoIdentificador();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.Mascara = Mascara;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoIdentificador
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoMenu : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.TipoMenu> _cacheItemList = new List<Entities.Relations.Seguridad.TipoMenu>();
			   protected List<Entities.Relations.Seguridad.TipoMenu> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public TipoMenu() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.TipoMenu();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.TipoMenu item)
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
         /// <summary>
         /// TipoMenu Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.TipoMenu</returns>
			public Entities.Relations.Seguridad.TipoMenu Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.TipoMenu)base.Add(new Entities.Relations.Seguridad.TipoMenu(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.TipoMenu> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.TipoMenu>().ToList<Entities.Relations.Seguridad.TipoMenu>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.TipoMenu items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.TipoMenu> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.TipoMenu> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.TipoMenu> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.TipoMenu Add(Entities.Relations.Seguridad.TipoMenu item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.TipoMenu)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.TipoMenu item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.TipoMenu with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.TipoMenu item = new Entities.Tables.Seguridad.TipoMenu();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoMenu
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Usuario : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Apellido,
					Legajo,
					Mail,
					FechaIngreso,
					NickName,
					Password,
					Token,
					Avatar,
					FechaUltimoLogin,
					DebeCambiarPassword,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.Usuario> _cacheItemList = new List<Entities.Relations.Seguridad.Usuario>();
			   protected List<Entities.Relations.Seguridad.Usuario> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Usuario() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.Usuario();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.Usuario item)
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
         /// <summary>
         /// Usuario Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Apellido'></param>
         /// <param name='Legajo'></param>
         /// <param name='Mail'></param>
         /// <param name='FechaIngreso'></param>
         /// <param name='NickName'></param>
         /// <param name='Password'></param>
         /// <param name='Token'></param>
         /// <param name='Avatar'></param>
         /// <param name='FechaUltimoLogin'></param>
         /// <param name='DebeCambiarPassword'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.Usuario</returns>
			public Entities.Relations.Seguridad.Usuario Add(String Nombre,String Apellido,String Legajo,String Mail,DateTime FechaIngreso,String NickName,String Password,String Token,String Avatar,DateTime FechaUltimoLogin,Boolean DebeCambiarPassword,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.Usuario)base.Add(new Entities.Relations.Seguridad.Usuario(Nombre,Apellido,Legajo,Mail,FechaIngreso,NickName,Password,Token,Avatar,FechaUltimoLogin,DebeCambiarPassword,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.Usuario> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.Usuario>().ToList<Entities.Relations.Seguridad.Usuario>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.Usuario items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Usuario> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Apellido"></param>
            /// <param name="Legajo"></param>
            /// <param name="Mail"></param>
            /// <param name="FechaIngreso"></param>
            /// <param name="NickName"></param>
            /// <param name="Password"></param>
            /// <param name="Token"></param>
            /// <param name="Avatar"></param>
            /// <param name="FechaUltimoLogin"></param>
            /// <param name="DebeCambiarPassword"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.Usuario> Items(Int64? Id,String Nombre,String Apellido,String Legajo,String Mail,DateTime? FechaIngreso,String NickName,String Password,String Token,String Avatar,DateTime? FechaUltimoLogin,Boolean? DebeCambiarPassword,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Apellido != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Apellido, Depositary.sqlEnum.OperandEnum.Equal, Apellido);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Apellido, Depositary.sqlEnum.OperandEnum.Equal, Apellido);
                    }
                   
                }
                if (Legajo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Legajo, Depositary.sqlEnum.OperandEnum.Equal, Legajo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Legajo, Depositary.sqlEnum.OperandEnum.Equal, Legajo);
                    }
                   
                }
                if (Mail != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Mail, Depositary.sqlEnum.OperandEnum.Equal, Mail);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Mail, Depositary.sqlEnum.OperandEnum.Equal, Mail);
                    }
                   
                }
                if (FechaIngreso != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaIngreso, Depositary.sqlEnum.OperandEnum.Equal, FechaIngreso);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaIngreso, Depositary.sqlEnum.OperandEnum.Equal, FechaIngreso);
                    }
                   
                }
                if (NickName != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.NickName, Depositary.sqlEnum.OperandEnum.Equal, NickName);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.NickName, Depositary.sqlEnum.OperandEnum.Equal, NickName);
                    }
                   
                }
                if (Password != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Password, Depositary.sqlEnum.OperandEnum.Equal, Password);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Password, Depositary.sqlEnum.OperandEnum.Equal, Password);
                    }
                   
                }
                if (Token != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Token, Depositary.sqlEnum.OperandEnum.Equal, Token);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Token, Depositary.sqlEnum.OperandEnum.Equal, Token);
                    }
                   
                }
                if (Avatar != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Avatar, Depositary.sqlEnum.OperandEnum.Equal, Avatar);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Avatar, Depositary.sqlEnum.OperandEnum.Equal, Avatar);
                    }
                   
                }
                if (FechaUltimoLogin != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaUltimoLogin, Depositary.sqlEnum.OperandEnum.Equal, FechaUltimoLogin);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaUltimoLogin, Depositary.sqlEnum.OperandEnum.Equal, FechaUltimoLogin);
                    }
                   
                }
                if (DebeCambiarPassword != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DebeCambiarPassword, Depositary.sqlEnum.OperandEnum.Equal, DebeCambiarPassword);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DebeCambiarPassword, Depositary.sqlEnum.OperandEnum.Equal, DebeCambiarPassword);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.Usuario> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.Usuario Add(Entities.Relations.Seguridad.Usuario item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.Usuario)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.Usuario item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.Usuario with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Apellido"></param>
            /// <param name="Legajo"></param>
            /// <param name="Mail"></param>
            /// <param name="FechaIngreso"></param>
            /// <param name="NickName"></param>
            /// <param name="Password"></param>
            /// <param name="Token"></param>
            /// <param name="Avatar"></param>
            /// <param name="FechaUltimoLogin"></param>
            /// <param name="DebeCambiarPassword"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Apellido,String Legajo,String Mail,DateTime FechaIngreso,String NickName,String Password,String Token,String Avatar,DateTime FechaUltimoLogin,Boolean DebeCambiarPassword,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.Usuario item = new Entities.Tables.Seguridad.Usuario();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Apellido = Apellido;
                 item.Legajo = Legajo;
                 item.Mail = Mail;
                 item.FechaIngreso = FechaIngreso;
                 item.NickName = NickName;
                 item.Password = Password;
                 item.Token = Token;
                 item.Avatar = Avatar;
                 item.FechaUltimoLogin = FechaUltimoLogin;
                 item.DebeCambiarPassword = DebeCambiarPassword;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Usuario
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class UsuarioFuncion : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Usuario_Id,
					Funcion_Id,
					FechaDesde,
					FechaHasta,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Seguridad.UsuarioFuncion> _cacheItemList = new List<Entities.Relations.Seguridad.UsuarioFuncion>();
			   protected List<Entities.Relations.Seguridad.UsuarioFuncion> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public UsuarioFuncion() : base()
            {
                base._dataItem = new Entities.Relations.Seguridad.UsuarioFuncion();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Seguridad.UsuarioFuncion item)
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
         /// <summary>
         /// UsuarioFuncion Add Method
         /// </summary>
         /// <param name='Depositary.Entities.Relations.Seguridad.Usuario Usuario_Id'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id'></param>
         /// <param name='FechaDesde'></param>
         /// <param name='FechaHasta'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Seguridad.UsuarioFuncion</returns>
			public Entities.Relations.Seguridad.UsuarioFuncion Add(Depositary.Entities.Relations.Seguridad.Usuario Usuario_Id,Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id,DateTime FechaDesde,DateTime FechaHasta,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Seguridad.UsuarioFuncion)base.Add(new Entities.Relations.Seguridad.UsuarioFuncion(Usuario_Id,Funcion_Id,FechaDesde,FechaHasta,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Seguridad.UsuarioFuncion> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Seguridad.UsuarioFuncion>().ToList<Entities.Relations.Seguridad.UsuarioFuncion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Seguridad.UsuarioFuncion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.UsuarioFuncion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Usuario_Id"></param>
            /// <param name="Funcion_Id"></param>
            /// <param name="FechaDesde"></param>
            /// <param name="FechaHasta"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Seguridad.UsuarioFuncion> Items(Int64? Id,Int64? Usuario_Id,Int64? Funcion_Id,DateTime? FechaDesde,DateTime? FechaHasta,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Usuario_Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Usuario_Id, Depositary.sqlEnum.OperandEnum.Equal, Usuario_Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Usuario_Id, Depositary.sqlEnum.OperandEnum.Equal, Usuario_Id);
                    }
                   
                }
                if (Funcion_Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                   
                }
                if (FechaDesde != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaDesde, Depositary.sqlEnum.OperandEnum.Equal, FechaDesde);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaDesde, Depositary.sqlEnum.OperandEnum.Equal, FechaDesde);
                    }
                   
                }
                if (FechaHasta != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaHasta, Depositary.sqlEnum.OperandEnum.Equal, FechaHasta);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaHasta, Depositary.sqlEnum.OperandEnum.Equal, FechaHasta);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Seguridad.UsuarioFuncion> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Seguridad.UsuarioFuncion Add(Entities.Relations.Seguridad.UsuarioFuncion item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Seguridad.UsuarioFuncion)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Seguridad.UsuarioFuncion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Seguridad.UsuarioFuncion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Usuario_Id"></param>
            /// <param name="Funcion_Id"></param>
            /// <param name="FechaDesde"></param>
            /// <param name="FechaHasta"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 Usuario_Id,Int64 Funcion_Id,DateTime FechaDesde,DateTime FechaHasta,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Seguridad.UsuarioFuncion item = new Entities.Tables.Seguridad.UsuarioFuncion();
                 item.Id = Id;
                 item.Usuario_Id = Usuario_Id;
                 item.Funcion_Id = Funcion_Id;
                 item.FechaDesde = FechaDesde;
                 item.FechaHasta = FechaHasta;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class UsuarioFuncion
	} //namespace Depositary.Business.Relations.Seguridad
	namespace Depositary.Business.Relations.Sig {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Ciudad : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					ProvinciaId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
			   protected List<Entities.Relations.Sig.Ciudad> _cacheItemList = new List<Entities.Relations.Sig.Ciudad>();
			   protected List<Entities.Relations.Sig.Ciudad> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Ciudad() : base()
            {
                base._dataItem = new Entities.Relations.Sig.Ciudad();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Sig.Ciudad item)
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
         /// <summary>
         /// Ciudad Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Sig.Provincia ProvinciaId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Sig.Ciudad</returns>
			public Entities.Relations.Sig.Ciudad Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Sig.Provincia ProvinciaId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Relations.Sig.Ciudad)base.Add(new Entities.Relations.Sig.Ciudad(Nombre,Descripcion,ProvinciaId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Relations.Sig.Ciudad> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Sig.Ciudad>().ToList<Entities.Relations.Sig.Ciudad>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Sig.Ciudad items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sig.Ciudad> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="ProvinciaId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sig.Ciudad> Items(Int64? Id,String Nombre,String Descripcion,Int64? ProvinciaId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (ProvinciaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ProvinciaId, Depositary.sqlEnum.OperandEnum.Equal, ProvinciaId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ProvinciaId, Depositary.sqlEnum.OperandEnum.Equal, ProvinciaId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Sig.Ciudad> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Sig.Ciudad Add(Entities.Relations.Sig.Ciudad item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Sig.Ciudad)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Sig.Ciudad item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Sig.Ciudad with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="ProvinciaId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int64 ProvinciaId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
            {
                 Entities.Tables.Sig.Ciudad item = new Entities.Tables.Sig.Ciudad();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.ProvinciaId = ProvinciaId;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.CodigoExterno = CodigoExterno;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Ciudad
	} //namespace Depositary.Business.Relations.Sig
	namespace Depositary.Business.Relations.Sig {
	    /// <summary>
	    /// 
	    /// </summary>
		public class CodigoPostal : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					CiudadId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
			   protected List<Entities.Relations.Sig.CodigoPostal> _cacheItemList = new List<Entities.Relations.Sig.CodigoPostal>();
			   protected List<Entities.Relations.Sig.CodigoPostal> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public CodigoPostal() : base()
            {
                base._dataItem = new Entities.Relations.Sig.CodigoPostal();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Sig.CodigoPostal item)
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
         /// <summary>
         /// CodigoPostal Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='CiudadId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Sig.CodigoPostal</returns>
			public Entities.Relations.Sig.CodigoPostal Add(String Nombre,String Descripcion,Int64 CiudadId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Relations.Sig.CodigoPostal)base.Add(new Entities.Relations.Sig.CodigoPostal(Nombre,Descripcion,CiudadId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Relations.Sig.CodigoPostal> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Sig.CodigoPostal>().ToList<Entities.Relations.Sig.CodigoPostal>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Sig.CodigoPostal items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sig.CodigoPostal> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="CiudadId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sig.CodigoPostal> Items(Int64? Id,String Nombre,String Descripcion,Int64? CiudadId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (CiudadId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CiudadId, Depositary.sqlEnum.OperandEnum.Equal, CiudadId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CiudadId, Depositary.sqlEnum.OperandEnum.Equal, CiudadId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Sig.CodigoPostal> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Sig.CodigoPostal Add(Entities.Relations.Sig.CodigoPostal item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Sig.CodigoPostal)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Sig.CodigoPostal item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Sig.CodigoPostal with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="CiudadId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int64 CiudadId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
            {
                 Entities.Tables.Sig.CodigoPostal item = new Entities.Tables.Sig.CodigoPostal();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.CiudadId = CiudadId;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.CodigoExterno = CodigoExterno;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class CodigoPostal
	} //namespace Depositary.Business.Relations.Sig
	namespace Depositary.Business.Relations.Sig {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Pais : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Codigo,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
			   protected List<Entities.Relations.Sig.Pais> _cacheItemList = new List<Entities.Relations.Sig.Pais>();
			   protected List<Entities.Relations.Sig.Pais> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Pais() : base()
            {
                base._dataItem = new Entities.Relations.Sig.Pais();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Sig.Pais item)
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
         /// <summary>
         /// Pais Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Codigo'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Sig.Pais</returns>
			public Entities.Relations.Sig.Pais Add(String Nombre,String Descripcion,String Codigo,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Relations.Sig.Pais)base.Add(new Entities.Relations.Sig.Pais(Nombre,Descripcion,Codigo,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Relations.Sig.Pais> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Sig.Pais>().ToList<Entities.Relations.Sig.Pais>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Sig.Pais items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sig.Pais> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Codigo"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sig.Pais> Items(Int64? Id,String Nombre,String Descripcion,String Codigo,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Sig.Pais> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Sig.Pais Add(Entities.Relations.Sig.Pais item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Sig.Pais)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Sig.Pais item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Sig.Pais with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Codigo"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,String Codigo,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
            {
                 Entities.Tables.Sig.Pais item = new Entities.Tables.Sig.Pais();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.Codigo = Codigo;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.CodigoExterno = CodigoExterno;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Pais
	} //namespace Depositary.Business.Relations.Sig
	namespace Depositary.Business.Relations.Sig {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Provincia : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					PaisId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
			   protected List<Entities.Relations.Sig.Provincia> _cacheItemList = new List<Entities.Relations.Sig.Provincia>();
			   protected List<Entities.Relations.Sig.Provincia> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Provincia() : base()
            {
                base._dataItem = new Entities.Relations.Sig.Provincia();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Sig.Provincia item)
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
         /// <summary>
         /// Provincia Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Sig.Pais PaisId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Sig.Provincia</returns>
			public Entities.Relations.Sig.Provincia Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Sig.Pais PaisId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Relations.Sig.Provincia)base.Add(new Entities.Relations.Sig.Provincia(Nombre,Descripcion,PaisId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Relations.Sig.Provincia> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Sig.Provincia>().ToList<Entities.Relations.Sig.Provincia>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Sig.Provincia items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sig.Provincia> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="PaisId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sig.Provincia> Items(Int64? Id,String Nombre,String Descripcion,Int64? PaisId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (PaisId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, PaisId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, PaisId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Sig.Provincia> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Sig.Provincia Add(Entities.Relations.Sig.Provincia item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Sig.Provincia)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Sig.Provincia item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Sig.Provincia with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="PaisId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="CodigoExterno"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int64 PaisId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
            {
                 Entities.Tables.Sig.Provincia item = new Entities.Tables.Sig.Provincia();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.PaisId = PaisId;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.CodigoExterno = CodigoExterno;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Provincia
	} //namespace Depositary.Business.Relations.Sig
	namespace Depositary.Business.Relations.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Configuracion : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					EntidadId,
					Segundos,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Sincronizacion.Configuracion> _cacheItemList = new List<Entities.Relations.Sincronizacion.Configuracion>();
			   protected List<Entities.Relations.Sincronizacion.Configuracion> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Configuracion() : base()
            {
                base._dataItem = new Entities.Relations.Sincronizacion.Configuracion();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Sincronizacion.Configuracion item)
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
         /// <summary>
         /// Configuracion Add Method
         /// </summary>
         /// <param name='EntidadId'></param>
         /// <param name='Segundos'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Sincronizacion.Configuracion</returns>
			public Entities.Relations.Sincronizacion.Configuracion Add(Int64 EntidadId,Int64 Segundos,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Sincronizacion.Configuracion)base.Add(new Entities.Relations.Sincronizacion.Configuracion(EntidadId,Segundos,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Sincronizacion.Configuracion> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Sincronizacion.Configuracion>().ToList<Entities.Relations.Sincronizacion.Configuracion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Sincronizacion.Configuracion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sincronizacion.Configuracion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadId"></param>
            /// <param name="Segundos"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sincronizacion.Configuracion> Items(Int64? Id,Int64? EntidadId,Int64? Segundos,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (EntidadId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EntidadId, Depositary.sqlEnum.OperandEnum.Equal, EntidadId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EntidadId, Depositary.sqlEnum.OperandEnum.Equal, EntidadId);
                    }
                   
                }
                if (Segundos != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Segundos, Depositary.sqlEnum.OperandEnum.Equal, Segundos);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Segundos, Depositary.sqlEnum.OperandEnum.Equal, Segundos);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Sincronizacion.Configuracion> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Sincronizacion.Configuracion Add(Entities.Relations.Sincronizacion.Configuracion item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Sincronizacion.Configuracion)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Sincronizacion.Configuracion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Sincronizacion.Configuracion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadId"></param>
            /// <param name="Segundos"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 EntidadId,Int64 Segundos,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Sincronizacion.Configuracion item = new Entities.Tables.Sincronizacion.Configuracion();
                 item.Id = Id;
                 item.EntidadId = EntidadId;
                 item.Segundos = Segundos;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Configuracion
	} //namespace Depositary.Business.Relations.Sincronizacion
	namespace Depositary.Business.Relations.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Entidad : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Sincronizacion.Entidad> _cacheItemList = new List<Entities.Relations.Sincronizacion.Entidad>();
			   protected List<Entities.Relations.Sincronizacion.Entidad> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Entidad() : base()
            {
                base._dataItem = new Entities.Relations.Sincronizacion.Entidad();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Sincronizacion.Entidad item)
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
         /// <summary>
         /// Entidad Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Sincronizacion.Entidad</returns>
			public Entities.Relations.Sincronizacion.Entidad Add(String Nombre,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Sincronizacion.Entidad)base.Add(new Entities.Relations.Sincronizacion.Entidad(Nombre,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Sincronizacion.Entidad> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Sincronizacion.Entidad>().ToList<Entities.Relations.Sincronizacion.Entidad>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Sincronizacion.Entidad items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sincronizacion.Entidad> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sincronizacion.Entidad> Items(Int64? Id,String Nombre,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Sincronizacion.Entidad> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Sincronizacion.Entidad Add(Entities.Relations.Sincronizacion.Entidad item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Sincronizacion.Entidad)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Sincronizacion.Entidad item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Sincronizacion.Entidad with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Sincronizacion.Entidad item = new Entities.Tables.Sincronizacion.Entidad();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Entidad
	} //namespace Depositary.Business.Relations.Sincronizacion
	namespace Depositary.Business.Relations.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class EntidadCabecera : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					EntidadId,
					Valor,
					Fechainicio,
					Fechafin
				}
			   protected List<Entities.Relations.Sincronizacion.EntidadCabecera> _cacheItemList = new List<Entities.Relations.Sincronizacion.EntidadCabecera>();
			   protected List<Entities.Relations.Sincronizacion.EntidadCabecera> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public EntidadCabecera() : base()
            {
                base._dataItem = new Entities.Relations.Sincronizacion.EntidadCabecera();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Sincronizacion.EntidadCabecera item)
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
         /// <summary>
         /// EntidadCabecera Add Method
         /// </summary>
         /// <param name='EntidadId'></param>
         /// <param name='Valor'></param>
         /// <param name='Fechainicio'></param>
         /// <param name='Fechafin'></param>
         /// <returns>Entities.Relations.Sincronizacion.EntidadCabecera</returns>
			public Entities.Relations.Sincronizacion.EntidadCabecera Add(Int64 EntidadId,String Valor,DateTime Fechainicio,DateTime Fechafin) 
			{
			  return (Entities.Relations.Sincronizacion.EntidadCabecera)base.Add(new Entities.Relations.Sincronizacion.EntidadCabecera(EntidadId,Valor,Fechainicio,Fechafin));
			}
            public new List<Entities.Relations.Sincronizacion.EntidadCabecera> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Sincronizacion.EntidadCabecera>().ToList<Entities.Relations.Sincronizacion.EntidadCabecera>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Sincronizacion.EntidadCabecera items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sincronizacion.EntidadCabecera> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadId"></param>
            /// <param name="Valor"></param>
            /// <param name="Fechainicio"></param>
            /// <param name="Fechafin"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sincronizacion.EntidadCabecera> Items(Int64? Id,Int64? EntidadId,String Valor,DateTime? Fechainicio,DateTime? Fechafin)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (EntidadId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EntidadId, Depositary.sqlEnum.OperandEnum.Equal, EntidadId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EntidadId, Depositary.sqlEnum.OperandEnum.Equal, EntidadId);
                    }
                   
                }
                if (Valor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                   
                }
                if (Fechainicio != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fechainicio, Depositary.sqlEnum.OperandEnum.Equal, Fechainicio);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fechainicio, Depositary.sqlEnum.OperandEnum.Equal, Fechainicio);
                    }
                   
                }
                if (Fechafin != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fechafin, Depositary.sqlEnum.OperandEnum.Equal, Fechafin);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fechafin, Depositary.sqlEnum.OperandEnum.Equal, Fechafin);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Sincronizacion.EntidadCabecera> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Sincronizacion.EntidadCabecera Add(Entities.Relations.Sincronizacion.EntidadCabecera item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Sincronizacion.EntidadCabecera)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Sincronizacion.EntidadCabecera item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Sincronizacion.EntidadCabecera with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadId"></param>
            /// <param name="Valor"></param>
            /// <param name="Fechainicio"></param>
            /// <param name="Fechafin"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 EntidadId,String Valor,DateTime Fechainicio,DateTime Fechafin)
            {
                 Entities.Tables.Sincronizacion.EntidadCabecera item = new Entities.Tables.Sincronizacion.EntidadCabecera();
                 item.Id = Id;
                 item.EntidadId = EntidadId;
                 item.Valor = Valor;
                 item.Fechainicio = Fechainicio;
                 item.Fechafin = Fechafin;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class EntidadCabecera
	} //namespace Depositary.Business.Relations.Sincronizacion
	namespace Depositary.Business.Relations.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class EntidadDetalle : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					EntidadCabeceraId,
					FechaCreacion,
					Valor
				}
			   protected List<Entities.Relations.Sincronizacion.EntidadDetalle> _cacheItemList = new List<Entities.Relations.Sincronizacion.EntidadDetalle>();
			   protected List<Entities.Relations.Sincronizacion.EntidadDetalle> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public EntidadDetalle() : base()
            {
                base._dataItem = new Entities.Relations.Sincronizacion.EntidadDetalle();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Sincronizacion.EntidadDetalle item)
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
         /// <summary>
         /// EntidadDetalle Add Method
         /// </summary>
         /// <param name='EntidadCabeceraId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='Valor'></param>
         /// <returns>Entities.Relations.Sincronizacion.EntidadDetalle</returns>
			public Entities.Relations.Sincronizacion.EntidadDetalle Add(Int64 EntidadCabeceraId,DateTime FechaCreacion,String Valor) 
			{
			  return (Entities.Relations.Sincronizacion.EntidadDetalle)base.Add(new Entities.Relations.Sincronizacion.EntidadDetalle(EntidadCabeceraId,FechaCreacion,Valor));
			}
            public new List<Entities.Relations.Sincronizacion.EntidadDetalle> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Sincronizacion.EntidadDetalle>().ToList<Entities.Relations.Sincronizacion.EntidadDetalle>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Sincronizacion.EntidadDetalle items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sincronizacion.EntidadDetalle> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadCabeceraId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="Valor"></param>
            /// <returns></returns>
            public List<Entities.Relations.Sincronizacion.EntidadDetalle> Items(Int64? Id,Int64? EntidadCabeceraId,DateTime? FechaCreacion,String Valor)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (EntidadCabeceraId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EntidadCabeceraId, Depositary.sqlEnum.OperandEnum.Equal, EntidadCabeceraId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EntidadCabeceraId, Depositary.sqlEnum.OperandEnum.Equal, EntidadCabeceraId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (Valor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Sincronizacion.EntidadDetalle> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Sincronizacion.EntidadDetalle Add(Entities.Relations.Sincronizacion.EntidadDetalle item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Sincronizacion.EntidadDetalle)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Sincronizacion.EntidadDetalle item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Sincronizacion.EntidadDetalle with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadCabeceraId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="Valor"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 EntidadCabeceraId,DateTime FechaCreacion,String Valor)
            {
                 Entities.Tables.Sincronizacion.EntidadDetalle item = new Entities.Tables.Sincronizacion.EntidadDetalle();
                 item.Id = Id;
                 item.EntidadCabeceraId = EntidadCabeceraId;
                 item.FechaCreacion = FechaCreacion;
                 item.Valor = Valor;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class EntidadDetalle
	} //namespace Depositary.Business.Relations.Sincronizacion
	namespace Depositary.Business.Relations.Valor {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Denominacion : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					ValorId,
					Unidades,
					Imagen,
					CodigoCcTalk,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Valor.Denominacion> _cacheItemList = new List<Entities.Relations.Valor.Denominacion>();
			   protected List<Entities.Relations.Valor.Denominacion> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Denominacion() : base()
            {
                base._dataItem = new Entities.Relations.Valor.Denominacion();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Valor.Denominacion item)
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
         /// <summary>
         /// Denominacion Add Method
         /// </summary>
         /// <param name='ValorId'></param>
         /// <param name='Unidades'></param>
         /// <param name='Imagen'></param>
         /// <param name='CodigoCcTalk'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Valor.Denominacion</returns>
			public Entities.Relations.Valor.Denominacion Add(Int64 ValorId,Decimal Unidades,Byte[] Imagen,Int64 CodigoCcTalk,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Valor.Denominacion)base.Add(new Entities.Relations.Valor.Denominacion(ValorId,Unidades,Imagen,CodigoCcTalk,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Valor.Denominacion> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Valor.Denominacion>().ToList<Entities.Relations.Valor.Denominacion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Valor.Denominacion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Valor.Denominacion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="ValorId"></param>
            /// <param name="Unidades"></param>
            /// <param name="Imagen"></param>
            /// <param name="CodigoCcTalk"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Valor.Denominacion> Items(Int64? Id,Int64? ValorId,Decimal? Unidades,Int64? CodigoCcTalk,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (ValorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorId, Depositary.sqlEnum.OperandEnum.Equal, ValorId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ValorId, Depositary.sqlEnum.OperandEnum.Equal, ValorId);
                    }
                   
                }
                if (Unidades != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Unidades, Depositary.sqlEnum.OperandEnum.Equal, Unidades);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Unidades, Depositary.sqlEnum.OperandEnum.Equal, Unidades);
                    }
                   
                }
                if (CodigoCcTalk != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoCcTalk, Depositary.sqlEnum.OperandEnum.Equal, CodigoCcTalk);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoCcTalk, Depositary.sqlEnum.OperandEnum.Equal, CodigoCcTalk);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Valor.Denominacion> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Valor.Denominacion Add(Entities.Relations.Valor.Denominacion item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Valor.Denominacion)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Valor.Denominacion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Valor.Denominacion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="ValorId"></param>
            /// <param name="Unidades"></param>
            /// <param name="Imagen"></param>
            /// <param name="CodigoCcTalk"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 ValorId,Decimal Unidades,Byte[] Imagen,Int64 CodigoCcTalk,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Valor.Denominacion item = new Entities.Tables.Valor.Denominacion();
                 item.Id = Id;
                 item.ValorId = ValorId;
                 item.Unidades = Unidades;
                 item.Imagen = Imagen;
                 item.CodigoCcTalk = CodigoCcTalk;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Denominacion
	} //namespace Depositary.Business.Relations.Valor
	namespace Depositary.Business.Relations.Valor {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Tipo : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Valor.Tipo> _cacheItemList = new List<Entities.Relations.Valor.Tipo>();
			   protected List<Entities.Relations.Valor.Tipo> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Tipo() : base()
            {
                base._dataItem = new Entities.Relations.Valor.Tipo();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Valor.Tipo item)
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
         /// <summary>
         /// Tipo Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Valor.Tipo</returns>
			public Entities.Relations.Valor.Tipo Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Valor.Tipo)base.Add(new Entities.Relations.Valor.Tipo(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Valor.Tipo> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Valor.Tipo>().ToList<Entities.Relations.Valor.Tipo>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Valor.Tipo items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Valor.Tipo> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Valor.Tipo> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Valor.Tipo> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Valor.Tipo Add(Entities.Relations.Valor.Tipo item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Valor.Tipo)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Valor.Tipo item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Valor.Tipo with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Valor.Tipo item = new Entities.Tables.Valor.Tipo();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Tipo
	} //namespace Depositary.Business.Relations.Valor
	namespace Depositary.Business.Relations.Valor {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Valor : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Tipo,
					PaisId,
					Codigo,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
			   protected List<Entities.Relations.Valor.Valor> _cacheItemList = new List<Entities.Relations.Valor.Valor>();
			   protected List<Entities.Relations.Valor.Valor> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Valor() : base()
            {
                base._dataItem = new Entities.Relations.Valor.Valor();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Valor.Valor item)
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
         /// <summary>
         /// Valor Add Method
         /// </summary>
         /// <param name='Tipo'></param>
         /// <param name='PaisId'></param>
         /// <param name='Codigo'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Relations.Valor.Valor</returns>
			public Entities.Relations.Valor.Valor Add(Int64 Tipo,Int64 PaisId,String Codigo,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Relations.Valor.Valor)base.Add(new Entities.Relations.Valor.Valor(Tipo,PaisId,Codigo,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Relations.Valor.Valor> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Valor.Valor>().ToList<Entities.Relations.Valor.Valor>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Valor.Valor items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Valor.Valor> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Tipo"></param>
            /// <param name="PaisId"></param>
            /// <param name="Codigo"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Valor.Valor> Items(Int64? Id,Int64? Tipo,Int64? PaisId,String Codigo,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Tipo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo, Depositary.sqlEnum.OperandEnum.Equal, Tipo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Tipo, Depositary.sqlEnum.OperandEnum.Equal, Tipo);
                    }
                   
                }
                if (PaisId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, PaisId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, PaisId);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Valor.Valor> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Valor.Valor Add(Entities.Relations.Valor.Valor item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Valor.Valor)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Valor.Valor item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Valor.Valor with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Tipo"></param>
            /// <param name="PaisId"></param>
            /// <param name="Codigo"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 Tipo,Int64 PaisId,String Codigo,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
            {
                 Entities.Tables.Valor.Valor item = new Entities.Tables.Valor.Valor();
                 item.Id = Id;
                 item.Tipo = Tipo;
                 item.PaisId = PaisId;
                 item.Codigo = Codigo;
                 item.EstadoLogico = EstadoLogico;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.FechaCreacion = FechaCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.FechaModificacion = FechaModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Valor
	} //namespace Depositary.Business.Relations.Valor
	namespace Depositary.Business.Relations.Visualizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Perfil : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					PerfilTipoId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					Habilitado
				}
			   protected List<Entities.Relations.Visualizacion.Perfil> _cacheItemList = new List<Entities.Relations.Visualizacion.Perfil>();
			   protected List<Entities.Relations.Visualizacion.Perfil> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public Perfil() : base()
            {
                base._dataItem = new Entities.Relations.Visualizacion.Perfil();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Visualizacion.Perfil item)
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
         /// <summary>
         /// Perfil Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Depositary.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Visualizacion.Perfil</returns>
			public Entities.Relations.Visualizacion.Perfil Add(String Nombre,String Descripcion,Depositary.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,Boolean Habilitado) 
			{
			  return (Entities.Relations.Visualizacion.Perfil)base.Add(new Entities.Relations.Visualizacion.Perfil(Nombre,Descripcion,PerfilTipoId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,Habilitado));
			}
            public new List<Entities.Relations.Visualizacion.Perfil> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Visualizacion.Perfil>().ToList<Entities.Relations.Visualizacion.Perfil>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Visualizacion.Perfil items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Visualizacion.Perfil> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="PerfilTipoId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Visualizacion.Perfil> Items(Int64? Id,String Nombre,String Descripcion,Int64? PerfilTipoId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (PerfilTipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PerfilTipoId, Depositary.sqlEnum.OperandEnum.Equal, PerfilTipoId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.PerfilTipoId, Depositary.sqlEnum.OperandEnum.Equal, PerfilTipoId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Visualizacion.Perfil> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Visualizacion.Perfil Add(Entities.Relations.Visualizacion.Perfil item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Visualizacion.Perfil)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Visualizacion.Perfil item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Visualizacion.Perfil with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="PerfilTipoId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Int64 PerfilTipoId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,Boolean Habilitado)
            {
                 Entities.Tables.Visualizacion.Perfil item = new Entities.Tables.Visualizacion.Perfil();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.PerfilTipoId = PerfilTipoId;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Perfil
	} //namespace Depositary.Business.Relations.Visualizacion
	namespace Depositary.Business.Relations.Visualizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class PerfilItem : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					PerfilId,
					IdTablaReferencia,
					Habilitado,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion
				}
			   protected List<Entities.Relations.Visualizacion.PerfilItem> _cacheItemList = new List<Entities.Relations.Visualizacion.PerfilItem>();
			   protected List<Entities.Relations.Visualizacion.PerfilItem> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public PerfilItem() : base()
            {
                base._dataItem = new Entities.Relations.Visualizacion.PerfilItem();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Visualizacion.PerfilItem item)
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
         /// <summary>
         /// PerfilItem Add Method
         /// </summary>
         /// <param name='Id'></param>
         /// <param name='Depositary.Entities.Relations.Visualizacion.Perfil PerfilId'></param>
         /// <param name='IdTablaReferencia'></param>
         /// <param name='Habilitado'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <returns>Entities.Relations.Visualizacion.PerfilItem</returns>
			public Entities.Relations.Visualizacion.PerfilItem Add(Int64 Id,Depositary.Entities.Relations.Visualizacion.Perfil PerfilId,Int64 IdTablaReferencia,Boolean Habilitado,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion) 
			{
			  return (Entities.Relations.Visualizacion.PerfilItem)base.Add(new Entities.Relations.Visualizacion.PerfilItem(Id,PerfilId,IdTablaReferencia,Habilitado,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion));
			}
            public new List<Entities.Relations.Visualizacion.PerfilItem> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Visualizacion.PerfilItem>().ToList<Entities.Relations.Visualizacion.PerfilItem>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Visualizacion.PerfilItem items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Visualizacion.PerfilItem> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="PerfilId"></param>
            /// <param name="IdTablaReferencia"></param>
            /// <param name="Habilitado"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <returns></returns>
            public List<Entities.Relations.Visualizacion.PerfilItem> Items(Int64? Id,Int64? PerfilId,Int64? IdTablaReferencia,Boolean? Habilitado,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (PerfilId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PerfilId, Depositary.sqlEnum.OperandEnum.Equal, PerfilId);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.PerfilId, Depositary.sqlEnum.OperandEnum.Equal, PerfilId);
                    }
                   
                }
                if (IdTablaReferencia != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.IdTablaReferencia, Depositary.sqlEnum.OperandEnum.Equal, IdTablaReferencia);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.IdTablaReferencia, Depositary.sqlEnum.OperandEnum.Equal, IdTablaReferencia);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Visualizacion.PerfilItem> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Visualizacion.PerfilItem Add(Entities.Relations.Visualizacion.PerfilItem item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Visualizacion.PerfilItem)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Visualizacion.PerfilItem item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Visualizacion.PerfilItem with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="PerfilId"></param>
            /// <param name="IdTablaReferencia"></param>
            /// <param name="Habilitado"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,Int64 PerfilId,Int64 IdTablaReferencia,Boolean Habilitado,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion)
            {
                 Entities.Tables.Visualizacion.PerfilItem item = new Entities.Tables.Visualizacion.PerfilItem();
                 item.Id = Id;
                 item.PerfilId = PerfilId;
                 item.IdTablaReferencia = IdTablaReferencia;
                 item.Habilitado = Habilitado;
                 item.FechaCreacion = FechaCreacion;
                 item.FechaModificacion = FechaModificacion;
                 item.UsuarioCreacion = UsuarioCreacion;
                 item.UsuarioModificacion = UsuarioModificacion;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class PerfilItem
	} //namespace Depositary.Business.Relations.Visualizacion
	namespace Depositary.Business.Relations.Visualizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class PerfilTipo : RelationsDataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EsAdministrador,
					Habilitado
				}
			   protected List<Entities.Relations.Visualizacion.PerfilTipo> _cacheItemList = new List<Entities.Relations.Visualizacion.PerfilTipo>();
			   protected List<Entities.Relations.Visualizacion.PerfilTipo> _entities = null;
            public new CustomWhereParameter Where { get; set; }
            public new CustomOrderByParameter OrderByParameter { get; set; }
            public new CustomGroupByParameter GroupByParameter { get; set; }
            public new CustomAggregateParameter AggregateParameter { get; set; }
            public PerfilTipo() : base()
            {
                base._dataItem = new Entities.Relations.Visualizacion.PerfilTipo();
                Where = new CustomWhereParameter();
                OrderByParameter = new CustomOrderByParameter();
                GroupByParameter = new CustomGroupByParameter();
            }
            public class CustomAggregateParameter : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Relations.Visualizacion.PerfilTipo item)
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
         /// <summary>
         /// PerfilTipo Add Method
         /// </summary>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='EsAdministrador'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Relations.Visualizacion.PerfilTipo</returns>
			public Entities.Relations.Visualizacion.PerfilTipo Add(String Nombre,String Descripcion,Boolean EsAdministrador,Boolean Habilitado) 
			{
			  return (Entities.Relations.Visualizacion.PerfilTipo)base.Add(new Entities.Relations.Visualizacion.PerfilTipo(Nombre,Descripcion,EsAdministrador,Habilitado));
			}
            public new List<Entities.Relations.Visualizacion.PerfilTipo> Items()
            {
                RelationsDataHandler dh =  new RelationsDataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderByParameter.orderByParameter;
                dh.GroupByParameter = this.GroupByParameter.groupByParameter;
                _entities = dh.Items().Cast<Entities.Relations.Visualizacion.PerfilTipo>().ToList<Entities.Relations.Visualizacion.PerfilTipo>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Relations.Visualizacion.PerfilTipo items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Relations.Visualizacion.PerfilTipo> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.whereParameter.Count == 0)
                    {
                         this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                         this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                return this.Items();
            }
            /// <summary>
            /// Gets items with all fields
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EsAdministrador"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Relations.Visualizacion.PerfilTipo> Items(Int64? Id,String Nombre,String Descripcion,Boolean? EsAdministrador,Boolean? Habilitado)
            {
                this.Where.whereParameter.Clear();
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EsAdministrador != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EsAdministrador, Depositary.sqlEnum.OperandEnum.Equal, EsAdministrador);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EsAdministrador, Depositary.sqlEnum.OperandEnum.Equal, EsAdministrador);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            public List<Entities.Relations.Visualizacion.PerfilTipo> Result 
            {
                get { return _entities; }
            }
            public Entities.Relations.Visualizacion.PerfilTipo Add(Entities.Relations.Visualizacion.PerfilTipo item)
            {
                RelationsDataHandler dh = new RelationsDataHandler(this._dataItem);
                return (Entities.Relations.Visualizacion.PerfilTipo)base.Add((IDataItem)item);
            }
            public Int64 Update(Entities.Relations.Visualizacion.PerfilTipo item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Relations.Visualizacion.PerfilTipo with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EsAdministrador"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 Id,String Nombre,String Descripcion,Boolean EsAdministrador,Boolean Habilitado)
            {
                 Entities.Tables.Visualizacion.PerfilTipo item = new Entities.Tables.Visualizacion.PerfilTipo();
                 item.Id = Id;
                 item.Nombre = Nombre;
                 item.Descripcion = Descripcion;
                 item.EsAdministrador = EsAdministrador;
                 item.Habilitado = Habilitado;

                return base.Update((IDataItem)item);
            }
            public class CustomWhereParameter : WhereParameter {
                 internal WhereParameter whereParameter = new WhereParameter();
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Clear()
                 {
                     this.whereParameter.Clear();
                 }
                 public long Count
                 {
                     get {
                         return this.whereParameter.Count;
                     }
                 }
            }
            public class CustomOrderByParameter : OrderByParameter {
                 internal OrderByParameter orderByParameter = new OrderByParameter();
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     this.orderByParameter.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class CustomGroupByParameter : GroupByParameter {
                 internal GroupByParameter groupByParameter = new GroupByParameter();
                 public void Add(ColumnEnum column)
                 {
                     this.groupByParameter.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class PerfilTipo
	} //namespace Depositary.Business.Relations.Visualizacion
