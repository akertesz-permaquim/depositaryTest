using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace Depositary.Business.Tables.Auditoria {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Log : DataHandler
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
         protected List<Entities.Tables.Auditoria.Log> _entities = new List<Entities.Tables.Auditoria.Log>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Log() : base()
            {
                base._dataItem = new Entities.Tables.Auditoria.Log();
            }
            public Log(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Auditoria.Log();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Auditoria.Log item)
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
         /// <returns>Entities.Tables.Auditoria.Log</returns>
			public Entities.Tables.Auditoria.Log Add(DateTime Fecha,String Tipo,String Descripcion,String Detalle,String OrigenAplicacion,String OrigenMetodo,Int64? UsuarioId) 
			{
			  return (Entities.Tables.Auditoria.Log)base.Add(new Entities.Tables.Auditoria.Log(Fecha,Tipo,Descripcion,Detalle,OrigenAplicacion,OrigenMetodo,UsuarioId));
			}
            public new List<Entities.Tables.Auditoria.Log> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Auditoria.Log>().ToList<Entities.Tables.Auditoria.Log>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Auditoria.Log items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Auditoria.Log> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Auditoria.Log items with parameters.
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
            public List<Entities.Tables.Auditoria.Log> Items(Int64? Id,DateTime? Fecha,String Tipo,String Descripcion,String Detalle,String OrigenAplicacion,String OrigenMetodo,Int64? UsuarioId)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                   
                }
                if (Tipo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo, sqlEnum.OperandEnum.Equal, Tipo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Tipo, Depositary.sqlEnum.OperandEnum.Equal, Tipo);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Detalle != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Detalle, sqlEnum.OperandEnum.Equal, Detalle);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Detalle, Depositary.sqlEnum.OperandEnum.Equal, Detalle);
                    }
                   
                }
                if (OrigenAplicacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OrigenAplicacion, sqlEnum.OperandEnum.Equal, OrigenAplicacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.OrigenAplicacion, Depositary.sqlEnum.OperandEnum.Equal, OrigenAplicacion);
                    }
                   
                }
                if (OrigenMetodo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OrigenMetodo, sqlEnum.OperandEnum.Equal, OrigenMetodo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.OrigenMetodo, Depositary.sqlEnum.OperandEnum.Equal, OrigenMetodo);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Auditoria.Log
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Auditoria.Log Add(Entities.Tables.Auditoria.Log item)
            {
                return (Entities.Tables.Auditoria.Log)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Auditoria.Log
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Auditoria.Log AddOrUpdate(Entities.Tables.Auditoria.Log item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Auditoria.Log)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Auditoria.Log
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Auditoria.Log item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Auditoria.Log with parameters
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
            public Int64 Update(Int64 id,DateTime fecha,String tipo,String descripcion,String detalle,String origenaplicacion,String origenmetodo,Int64? usuarioid)
            {
                return base.Update((IDataItem) new Entities.Tables.Auditoria.Log {Id = id,Fecha = fecha,Tipo = tipo,Descripcion = descripcion,Detalle = detalle,OrigenAplicacion = origenaplicacion,OrigenMetodo = origenmetodo,UsuarioId = usuarioid});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Auditoria.Log
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Auditoria.Log item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Auditoria.Log with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Auditoria.Log {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Auditoria.Log> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Log
	} //namespace Depositary.Business.Tables.Auditoria
	namespace Depositary.Business.Tables.Auditoria {
	    /// <summary>
	    /// 
	    /// </summary>
		public class LogAnomalia : DataHandler
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
         protected List<Entities.Tables.Auditoria.LogAnomalia> _entities = new List<Entities.Tables.Auditoria.LogAnomalia>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public LogAnomalia() : base()
            {
                base._dataItem = new Entities.Tables.Auditoria.LogAnomalia();
            }
            public LogAnomalia(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Auditoria.LogAnomalia();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Auditoria.LogAnomalia item)
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
         /// <returns>Entities.Tables.Auditoria.LogAnomalia</returns>
			public Entities.Tables.Auditoria.LogAnomalia Add(DateTime Fecha,String Tipo,String Descripcion,String Detalle,Int64? UsuarioId) 
			{
			  return (Entities.Tables.Auditoria.LogAnomalia)base.Add(new Entities.Tables.Auditoria.LogAnomalia(Fecha,Tipo,Descripcion,Detalle,UsuarioId));
			}
            public new List<Entities.Tables.Auditoria.LogAnomalia> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Auditoria.LogAnomalia>().ToList<Entities.Tables.Auditoria.LogAnomalia>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Auditoria.LogAnomalia items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Auditoria.LogAnomalia> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Auditoria.LogAnomalia items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Fecha"></param>
            /// <param name="Tipo"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Detalle"></param>
            /// <param name="UsuarioId"></param>
            /// <returns></returns>
            public List<Entities.Tables.Auditoria.LogAnomalia> Items(Int64? Id,DateTime? Fecha,String Tipo,String Descripcion,String Detalle,Int64? UsuarioId)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                   
                }
                if (Tipo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo, sqlEnum.OperandEnum.Equal, Tipo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Tipo, Depositary.sqlEnum.OperandEnum.Equal, Tipo);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Detalle != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Detalle, sqlEnum.OperandEnum.Equal, Detalle);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Detalle, Depositary.sqlEnum.OperandEnum.Equal, Detalle);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Auditoria.LogAnomalia
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Auditoria.LogAnomalia Add(Entities.Tables.Auditoria.LogAnomalia item)
            {
                return (Entities.Tables.Auditoria.LogAnomalia)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Auditoria.LogAnomalia
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Auditoria.LogAnomalia AddOrUpdate(Entities.Tables.Auditoria.LogAnomalia item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Auditoria.LogAnomalia)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Auditoria.LogAnomalia
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Auditoria.LogAnomalia item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Auditoria.LogAnomalia with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Fecha"></param>
            /// <param name="Tipo"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Detalle"></param>
            /// <param name="UsuarioId"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,DateTime fecha,String tipo,String descripcion,String detalle,Int64? usuarioid)
            {
                return base.Update((IDataItem) new Entities.Tables.Auditoria.LogAnomalia {Id = id,Fecha = fecha,Tipo = tipo,Descripcion = descripcion,Detalle = detalle,UsuarioId = usuarioid});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Auditoria.LogAnomalia
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Auditoria.LogAnomalia item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Auditoria.LogAnomalia with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Auditoria.LogAnomalia {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Auditoria.LogAnomalia> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class LogAnomalia
	} //namespace Depositary.Business.Tables.Auditoria
	namespace Depositary.Business.Tables.Biometria {
	    /// <summary>
	    /// 
	    /// </summary>
		public class HuellaDactilar : DataHandler
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
         protected List<Entities.Tables.Biometria.HuellaDactilar> _entities = new List<Entities.Tables.Biometria.HuellaDactilar>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public HuellaDactilar() : base()
            {
                base._dataItem = new Entities.Tables.Biometria.HuellaDactilar();
            }
            public HuellaDactilar(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Biometria.HuellaDactilar();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Biometria.HuellaDactilar item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Biometria.HuellaDactilar</returns>
			public Entities.Tables.Biometria.HuellaDactilar Add(Int64 UsuarioId,Byte Dedo,String Huella,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Biometria.HuellaDactilar)base.Add(new Entities.Tables.Biometria.HuellaDactilar(UsuarioId,Dedo,Huella,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Biometria.HuellaDactilar> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Biometria.HuellaDactilar>().ToList<Entities.Tables.Biometria.HuellaDactilar>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Biometria.HuellaDactilar items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Biometria.HuellaDactilar> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Biometria.HuellaDactilar items with parameters.
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
            public List<Entities.Tables.Biometria.HuellaDactilar> Items(Int64? Id,Int64? UsuarioId,Byte? Dedo,String Huella,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (Dedo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Dedo, sqlEnum.OperandEnum.Equal, Dedo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Dedo, Depositary.sqlEnum.OperandEnum.Equal, Dedo);
                    }
                   
                }
                if (Huella != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Huella, sqlEnum.OperandEnum.Equal, Huella);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Huella, Depositary.sqlEnum.OperandEnum.Equal, Huella);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Biometria.HuellaDactilar
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Biometria.HuellaDactilar Add(Entities.Tables.Biometria.HuellaDactilar item)
            {
                return (Entities.Tables.Biometria.HuellaDactilar)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Biometria.HuellaDactilar
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Biometria.HuellaDactilar AddOrUpdate(Entities.Tables.Biometria.HuellaDactilar item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Biometria.HuellaDactilar)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Biometria.HuellaDactilar
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Biometria.HuellaDactilar item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Biometria.HuellaDactilar with parameters
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
            public Int64 Update(Int64 id,Int64 usuarioid,Byte dedo,String huella,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Biometria.HuellaDactilar {Id = id,UsuarioId = usuarioid,Dedo = dedo,Huella = huella,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Biometria.HuellaDactilar
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Biometria.HuellaDactilar item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Biometria.HuellaDactilar with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Biometria.HuellaDactilar {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Biometria.HuellaDactilar> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class HuellaDactilar
	} //namespace Depositary.Business.Tables.Biometria
	namespace Depositary.Business.Tables.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Banco : DataHandler
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
         protected List<Entities.Tables.Directorio.Banco> _entities = new List<Entities.Tables.Directorio.Banco>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Banco() : base()
            {
                base._dataItem = new Entities.Tables.Directorio.Banco();
            }
            public Banco(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Directorio.Banco();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Directorio.Banco item)
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
         /// <returns>Entities.Tables.Directorio.Banco</returns>
			public Entities.Tables.Directorio.Banco Add(Int64 PaisId,String Codigo,String Denominacion,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,Boolean Habilitado) 
			{
			  return (Entities.Tables.Directorio.Banco)base.Add(new Entities.Tables.Directorio.Banco(PaisId,Codigo,Denominacion,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,Habilitado));
			}
            public new List<Entities.Tables.Directorio.Banco> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Directorio.Banco>().ToList<Entities.Tables.Directorio.Banco>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Directorio.Banco items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Directorio.Banco> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Directorio.Banco items with parameters.
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
            public List<Entities.Tables.Directorio.Banco> Items(Int64? Id,Int64? PaisId,String Codigo,String Denominacion,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (PaisId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PaisId, sqlEnum.OperandEnum.Equal, PaisId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, PaisId);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (Denominacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Denominacion, sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Denominacion, Depositary.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Directorio.Banco
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.Banco Add(Entities.Tables.Directorio.Banco item)
            {
                return (Entities.Tables.Directorio.Banco)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Directorio.Banco
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.Banco AddOrUpdate(Entities.Tables.Directorio.Banco item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Directorio.Banco)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Directorio.Banco
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Directorio.Banco item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Directorio.Banco with parameters
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
            public Int64 Update(Int64 id,Int64 paisid,String codigo,String denominacion,DateTime? fechacreacion,DateTime? fechamodificacion,Int64? usuariocreacion,Int64? usuariomodificacion,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Directorio.Banco {Id = id,PaisId = paisid,Codigo = codigo,Denominacion = denominacion,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Directorio.Banco
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Directorio.Banco item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Directorio.Banco with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Directorio.Banco {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Directorio.Banco> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Banco
	} //namespace Depositary.Business.Tables.Directorio
	namespace Depositary.Business.Tables.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Compania : DataHandler
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
         protected List<Entities.Tables.Directorio.Compania> _entities = new List<Entities.Tables.Directorio.Compania>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Compania() : base()
            {
                base._dataItem = new Entities.Tables.Directorio.Compania();
            }
            public Compania(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Directorio.Compania();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Directorio.Compania item)
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
         /// <param name='GrupoId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Address'></param>
         /// <param name='CodigoPostalId'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Tables.Directorio.Compania</returns>
			public Entities.Tables.Directorio.Compania Add(String Nombre,String Descripcion,Int64 GrupoId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,String Address,Int64 CodigoPostalId,Boolean Habilitado) 
			{
			  return (Entities.Tables.Directorio.Compania)base.Add(new Entities.Tables.Directorio.Compania(Nombre,Descripcion,GrupoId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Address,CodigoPostalId,Habilitado));
			}
            public new List<Entities.Tables.Directorio.Compania> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Directorio.Compania>().ToList<Entities.Tables.Directorio.Compania>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Directorio.Compania items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Directorio.Compania> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Directorio.Compania items with parameters.
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
            public List<Entities.Tables.Directorio.Compania> Items(Int64? Id,String Nombre,String Descripcion,Int64? GrupoId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,String Address,Int64? CodigoPostalId,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (GrupoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.GrupoId, sqlEnum.OperandEnum.Equal, GrupoId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.GrupoId, Depositary.sqlEnum.OperandEnum.Equal, GrupoId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Address != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Address, sqlEnum.OperandEnum.Equal, Address);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Address, Depositary.sqlEnum.OperandEnum.Equal, Address);
                    }
                   
                }
                if (CodigoPostalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoPostalId, sqlEnum.OperandEnum.Equal, CodigoPostalId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoPostalId, Depositary.sqlEnum.OperandEnum.Equal, CodigoPostalId);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Directorio.Compania
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.Compania Add(Entities.Tables.Directorio.Compania item)
            {
                return (Entities.Tables.Directorio.Compania)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Directorio.Compania
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.Compania AddOrUpdate(Entities.Tables.Directorio.Compania item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Directorio.Compania)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Directorio.Compania
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Directorio.Compania item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Directorio.Compania with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int64 grupoid,DateTime fechacreacion,DateTime fechamodificacion,Int64 usuariocreacion,Int64 usuariomodificacion,String codigoexterno,String address,Int64 codigopostalid,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Directorio.Compania {Id = id,Nombre = nombre,Descripcion = descripcion,GrupoId = grupoid,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,CodigoExterno = codigoexterno,Address = address,CodigoPostalId = codigopostalid,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Directorio.Compania
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Directorio.Compania item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Directorio.Compania with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Directorio.Compania {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Directorio.Compania> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Compania
	} //namespace Depositary.Business.Tables.Directorio
	namespace Depositary.Business.Tables.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class CuentaBancaria : DataHandler
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
         protected List<Entities.Tables.Directorio.CuentaBancaria> _entities = new List<Entities.Tables.Directorio.CuentaBancaria>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public CuentaBancaria() : base()
            {
                base._dataItem = new Entities.Tables.Directorio.CuentaBancaria();
            }
            public CuentaBancaria(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Directorio.CuentaBancaria();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Directorio.CuentaBancaria item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Directorio.CuentaBancaria</returns>
			public Entities.Tables.Directorio.CuentaBancaria Add(Int64 TipoId,Int64 SucursalBancariaId,String Codigo,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Directorio.CuentaBancaria)base.Add(new Entities.Tables.Directorio.CuentaBancaria(TipoId,SucursalBancariaId,Codigo,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Directorio.CuentaBancaria> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Directorio.CuentaBancaria>().ToList<Entities.Tables.Directorio.CuentaBancaria>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Directorio.CuentaBancaria items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Directorio.CuentaBancaria> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Directorio.CuentaBancaria items with parameters.
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
            public List<Entities.Tables.Directorio.CuentaBancaria> Items(Int64? Id,Int64? TipoId,Int64? SucursalBancariaId,String Codigo,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (SucursalBancariaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalBancariaId, sqlEnum.OperandEnum.Equal, SucursalBancariaId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.SucursalBancariaId, Depositary.sqlEnum.OperandEnum.Equal, SucursalBancariaId);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Directorio.CuentaBancaria
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.CuentaBancaria Add(Entities.Tables.Directorio.CuentaBancaria item)
            {
                return (Entities.Tables.Directorio.CuentaBancaria)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Directorio.CuentaBancaria
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.CuentaBancaria AddOrUpdate(Entities.Tables.Directorio.CuentaBancaria item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Directorio.CuentaBancaria)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Directorio.CuentaBancaria
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Directorio.CuentaBancaria item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Directorio.CuentaBancaria with parameters
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
            public Int64 Update(Int64 id,Int64 tipoid,Int64 sucursalbancariaid,String codigo,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Directorio.CuentaBancaria {Id = id,TipoId = tipoid,SucursalBancariaId = sucursalbancariaid,Codigo = codigo,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Directorio.CuentaBancaria
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Directorio.CuentaBancaria item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Directorio.CuentaBancaria with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Directorio.CuentaBancaria {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Directorio.CuentaBancaria> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class CuentaBancaria
	} //namespace Depositary.Business.Tables.Directorio
	namespace Depositary.Business.Tables.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Grupo : DataHandler
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
         protected List<Entities.Tables.Directorio.Grupo> _entities = new List<Entities.Tables.Directorio.Grupo>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Grupo() : base()
            {
                base._dataItem = new Entities.Tables.Directorio.Grupo();
            }
            public Grupo(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Directorio.Grupo();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Directorio.Grupo item)
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
         /// <returns>Entities.Tables.Directorio.Grupo</returns>
			public Entities.Tables.Directorio.Grupo Add(String Nombre,String Descripcion,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Tables.Directorio.Grupo)base.Add(new Entities.Tables.Directorio.Grupo(Nombre,Descripcion,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Tables.Directorio.Grupo> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Directorio.Grupo>().ToList<Entities.Tables.Directorio.Grupo>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Directorio.Grupo items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Directorio.Grupo> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Directorio.Grupo items with parameters.
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
            public List<Entities.Tables.Directorio.Grupo> Items(Int64? Id,String Nombre,String Descripcion,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Directorio.Grupo
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.Grupo Add(Entities.Tables.Directorio.Grupo item)
            {
                return (Entities.Tables.Directorio.Grupo)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Directorio.Grupo
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.Grupo AddOrUpdate(Entities.Tables.Directorio.Grupo item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Directorio.Grupo)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Directorio.Grupo
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Directorio.Grupo item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Directorio.Grupo with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,DateTime fechacreacion,DateTime fechamodificacion,Int64 usuariocreacion,Int64 usuariomodificacion,String codigoexterno,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Directorio.Grupo {Id = id,Nombre = nombre,Descripcion = descripcion,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,CodigoExterno = codigoexterno,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Directorio.Grupo
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Directorio.Grupo item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Directorio.Grupo with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Directorio.Grupo {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Directorio.Grupo> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Grupo
	} //namespace Depositary.Business.Tables.Directorio
	namespace Depositary.Business.Tables.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class SucursalBancaria : DataHandler
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
         protected List<Entities.Tables.Directorio.SucursalBancaria> _entities = new List<Entities.Tables.Directorio.SucursalBancaria>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public SucursalBancaria() : base()
            {
                base._dataItem = new Entities.Tables.Directorio.SucursalBancaria();
            }
            public SucursalBancaria(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Directorio.SucursalBancaria();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Directorio.SucursalBancaria item)
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
         /// <returns>Entities.Tables.Directorio.SucursalBancaria</returns>
			public Entities.Tables.Directorio.SucursalBancaria Add(Int64 BancoId,String Codigo,String Direccion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Directorio.SucursalBancaria)base.Add(new Entities.Tables.Directorio.SucursalBancaria(BancoId,Codigo,Direccion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Directorio.SucursalBancaria> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Directorio.SucursalBancaria>().ToList<Entities.Tables.Directorio.SucursalBancaria>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Directorio.SucursalBancaria items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Directorio.SucursalBancaria> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Directorio.SucursalBancaria items with parameters.
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
            public List<Entities.Tables.Directorio.SucursalBancaria> Items(Int64? Id,Int64? BancoId,String Codigo,String Direccion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (BancoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.BancoId, sqlEnum.OperandEnum.Equal, BancoId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.BancoId, Depositary.sqlEnum.OperandEnum.Equal, BancoId);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (Direccion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Direccion, sqlEnum.OperandEnum.Equal, Direccion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Direccion, Depositary.sqlEnum.OperandEnum.Equal, Direccion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Directorio.SucursalBancaria
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.SucursalBancaria Add(Entities.Tables.Directorio.SucursalBancaria item)
            {
                return (Entities.Tables.Directorio.SucursalBancaria)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Directorio.SucursalBancaria
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.SucursalBancaria AddOrUpdate(Entities.Tables.Directorio.SucursalBancaria item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Directorio.SucursalBancaria)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Directorio.SucursalBancaria
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Directorio.SucursalBancaria item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Directorio.SucursalBancaria with parameters
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
            public Int64 Update(Int64 id,Int64 bancoid,String codigo,String direccion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Directorio.SucursalBancaria {Id = id,BancoId = bancoid,Codigo = codigo,Direccion = direccion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Directorio.SucursalBancaria
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Directorio.SucursalBancaria item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Directorio.SucursalBancaria with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Directorio.SucursalBancaria {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Directorio.SucursalBancaria> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class SucursalBancaria
	} //namespace Depositary.Business.Tables.Directorio
	namespace Depositary.Business.Tables.Directorio {
	    /// <summary>
	    /// 
	    /// </summary>
		public class SucursalCompania : DataHandler
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
         protected List<Entities.Tables.Directorio.SucursalCompania> _entities = new List<Entities.Tables.Directorio.SucursalCompania>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public SucursalCompania() : base()
            {
                base._dataItem = new Entities.Tables.Directorio.SucursalCompania();
            }
            public SucursalCompania(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Directorio.SucursalCompania();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Directorio.SucursalCompania item)
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
         /// <param name='CompaniaId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Direccion'></param>
         /// <param name='CodigoPostalId'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Tables.Directorio.SucursalCompania</returns>
			public Entities.Tables.Directorio.SucursalCompania Add(String Nombre,String Descripcion,Int64 CompaniaId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,String Direccion,Int64 CodigoPostalId,Boolean Habilitado) 
			{
			  return (Entities.Tables.Directorio.SucursalCompania)base.Add(new Entities.Tables.Directorio.SucursalCompania(Nombre,Descripcion,CompaniaId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Direccion,CodigoPostalId,Habilitado));
			}
            public new List<Entities.Tables.Directorio.SucursalCompania> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Directorio.SucursalCompania>().ToList<Entities.Tables.Directorio.SucursalCompania>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Directorio.SucursalCompania items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Directorio.SucursalCompania> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Directorio.SucursalCompania items with parameters.
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
            public List<Entities.Tables.Directorio.SucursalCompania> Items(Int64? Id,String Nombre,String Descripcion,Int64? CompaniaId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,String Direccion,Int64? CodigoPostalId,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (CompaniaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CompaniaId, sqlEnum.OperandEnum.Equal, CompaniaId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CompaniaId, Depositary.sqlEnum.OperandEnum.Equal, CompaniaId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Direccion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Direccion, sqlEnum.OperandEnum.Equal, Direccion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Direccion, Depositary.sqlEnum.OperandEnum.Equal, Direccion);
                    }
                   
                }
                if (CodigoPostalId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoPostalId, sqlEnum.OperandEnum.Equal, CodigoPostalId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoPostalId, Depositary.sqlEnum.OperandEnum.Equal, CodigoPostalId);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Directorio.SucursalCompania
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.SucursalCompania Add(Entities.Tables.Directorio.SucursalCompania item)
            {
                return (Entities.Tables.Directorio.SucursalCompania)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Directorio.SucursalCompania
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Directorio.SucursalCompania AddOrUpdate(Entities.Tables.Directorio.SucursalCompania item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Directorio.SucursalCompania)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Directorio.SucursalCompania
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Directorio.SucursalCompania item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Directorio.SucursalCompania with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int64 companiaid,DateTime fechacreacion,DateTime fechamodificacion,Int64 usuariocreacion,Int64 usuariomodificacion,String codigoexterno,String direccion,Int64 codigopostalid,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Directorio.SucursalCompania {Id = id,Nombre = nombre,Descripcion = descripcion,CompaniaId = companiaid,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,CodigoExterno = codigoexterno,Direccion = direccion,CodigoPostalId = codigopostalid,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Directorio.SucursalCompania
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Directorio.SucursalCompania item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Directorio.SucursalCompania with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Directorio.SucursalCompania {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Directorio.SucursalCompania> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class SucursalCompania
	} //namespace Depositary.Business.Tables.Directorio
	namespace Depositary.Business.Tables.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ComandoContadora : DataHandler
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
         protected List<Entities.Tables.Dispositivo.ComandoContadora> _entities = new List<Entities.Tables.Dispositivo.ComandoContadora>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public ComandoContadora() : base()
            {
                base._dataItem = new Entities.Tables.Dispositivo.ComandoContadora();
            }
            public ComandoContadora(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Dispositivo.ComandoContadora();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Dispositivo.ComandoContadora item)
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
         /// <param name='ContadoraId'></param>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Comando'></param>
         /// <param name='TiempoDetencion'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Tables.Dispositivo.ComandoContadora</returns>
			public Entities.Tables.Dispositivo.ComandoContadora Add(Int64 ContadoraId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,Boolean Habilitado) 
			{
			  return (Entities.Tables.Dispositivo.ComandoContadora)base.Add(new Entities.Tables.Dispositivo.ComandoContadora(ContadoraId,Nombre,Descripcion,Comando,TiempoDetencion,Habilitado));
			}
            public new List<Entities.Tables.Dispositivo.ComandoContadora> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Dispositivo.ComandoContadora>().ToList<Entities.Tables.Dispositivo.ComandoContadora>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Dispositivo.ComandoContadora items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Dispositivo.ComandoContadora> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Dispositivo.ComandoContadora items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="ContadoraId"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Comando"></param>
            /// <param name="TiempoDetencion"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Tables.Dispositivo.ComandoContadora> Items(Int64? Id,Int64? ContadoraId,String Nombre,String Descripcion,String Comando,Int64? TiempoDetencion,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (ContadoraId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContadoraId, sqlEnum.OperandEnum.Equal, ContadoraId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.ContadoraId, Depositary.sqlEnum.OperandEnum.Equal, ContadoraId);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Comando != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Comando, sqlEnum.OperandEnum.Equal, Comando);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Comando, Depositary.sqlEnum.OperandEnum.Equal, Comando);
                    }
                   
                }
                if (TiempoDetencion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TiempoDetencion, sqlEnum.OperandEnum.Equal, TiempoDetencion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.TiempoDetencion, Depositary.sqlEnum.OperandEnum.Equal, TiempoDetencion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Dispositivo.ComandoContadora
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.ComandoContadora Add(Entities.Tables.Dispositivo.ComandoContadora item)
            {
                return (Entities.Tables.Dispositivo.ComandoContadora)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Dispositivo.ComandoContadora
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.ComandoContadora AddOrUpdate(Entities.Tables.Dispositivo.ComandoContadora item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Dispositivo.ComandoContadora)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Dispositivo.ComandoContadora
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Dispositivo.ComandoContadora item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Dispositivo.ComandoContadora with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="ContadoraId"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Comando"></param>
            /// <param name="TiempoDetencion"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,Int64 contadoraid,String nombre,String descripcion,String comando,Int64 tiempodetencion,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Dispositivo.ComandoContadora {Id = id,ContadoraId = contadoraid,Nombre = nombre,Descripcion = descripcion,Comando = comando,TiempoDetencion = tiempodetencion,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Dispositivo.ComandoContadora
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Dispositivo.ComandoContadora item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Dispositivo.ComandoContadora with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Dispositivo.ComandoContadora {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Dispositivo.ComandoContadora> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class ComandoContadora
	} //namespace Depositary.Business.Tables.Dispositivo
	namespace Depositary.Business.Tables.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ConfiguracionMaquina : DataHandler
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
         protected List<Entities.Tables.Dispositivo.ConfiguracionMaquina> _entities = new List<Entities.Tables.Dispositivo.ConfiguracionMaquina>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public ConfiguracionMaquina() : base()
            {
                base._dataItem = new Entities.Tables.Dispositivo.ConfiguracionMaquina();
            }
            public ConfiguracionMaquina(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Dispositivo.ConfiguracionMaquina();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Dispositivo.ConfiguracionMaquina item)
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
         /// <param name='TipoId'></param>
         /// <param name='MaquinaId'></param>
         /// <param name='Valor'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Dispositivo.ConfiguracionMaquina</returns>
			public Entities.Tables.Dispositivo.ConfiguracionMaquina Add(Int64 TipoId,Int64 MaquinaId,String Valor,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Dispositivo.ConfiguracionMaquina)base.Add(new Entities.Tables.Dispositivo.ConfiguracionMaquina(TipoId,MaquinaId,Valor,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Dispositivo.ConfiguracionMaquina> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Dispositivo.ConfiguracionMaquina>().ToList<Entities.Tables.Dispositivo.ConfiguracionMaquina>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Dispositivo.ConfiguracionMaquina items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Dispositivo.ConfiguracionMaquina> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Dispositivo.ConfiguracionMaquina items with parameters.
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
            public List<Entities.Tables.Dispositivo.ConfiguracionMaquina> Items(Int64? Id,Int64? TipoId,Int64? MaquinaId,String Valor,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (MaquinaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.MaquinaId, sqlEnum.OperandEnum.Equal, MaquinaId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.MaquinaId, Depositary.sqlEnum.OperandEnum.Equal, MaquinaId);
                    }
                   
                }
                if (Valor != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor, sqlEnum.OperandEnum.Equal, Valor);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Dispositivo.ConfiguracionMaquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.ConfiguracionMaquina Add(Entities.Tables.Dispositivo.ConfiguracionMaquina item)
            {
                return (Entities.Tables.Dispositivo.ConfiguracionMaquina)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Dispositivo.ConfiguracionMaquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.ConfiguracionMaquina AddOrUpdate(Entities.Tables.Dispositivo.ConfiguracionMaquina item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Dispositivo.ConfiguracionMaquina)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Dispositivo.ConfiguracionMaquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Dispositivo.ConfiguracionMaquina item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Dispositivo.ConfiguracionMaquina with parameters
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
            public Int64 Update(Int64 id,Int64 tipoid,Int64 maquinaid,String valor,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Dispositivo.ConfiguracionMaquina {Id = id,TipoId = tipoid,MaquinaId = maquinaid,Valor = valor,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Dispositivo.ConfiguracionMaquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Dispositivo.ConfiguracionMaquina item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Dispositivo.ConfiguracionMaquina with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Dispositivo.ConfiguracionMaquina {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Dispositivo.ConfiguracionMaquina> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class ConfiguracionMaquina
	} //namespace Depositary.Business.Tables.Dispositivo
	namespace Depositary.Business.Tables.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Contadora : DataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado
				}
         protected List<Entities.Tables.Dispositivo.Contadora> _entities = new List<Entities.Tables.Dispositivo.Contadora>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Contadora() : base()
            {
                base._dataItem = new Entities.Tables.Dispositivo.Contadora();
            }
            public Contadora(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Dispositivo.Contadora();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Dispositivo.Contadora item)
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
         /// <returns>Entities.Tables.Dispositivo.Contadora</returns>
			public Entities.Tables.Dispositivo.Contadora Add(String Nombre,String Descripcion,Boolean Habilitado) 
			{
			  return (Entities.Tables.Dispositivo.Contadora)base.Add(new Entities.Tables.Dispositivo.Contadora(Nombre,Descripcion,Habilitado));
			}
            public new List<Entities.Tables.Dispositivo.Contadora> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Dispositivo.Contadora>().ToList<Entities.Tables.Dispositivo.Contadora>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Dispositivo.Contadora items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Dispositivo.Contadora> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Dispositivo.Contadora items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Tables.Dispositivo.Contadora> Items(Int64? Id,String Nombre,String Descripcion,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Dispositivo.Contadora
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.Contadora Add(Entities.Tables.Dispositivo.Contadora item)
            {
                return (Entities.Tables.Dispositivo.Contadora)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Dispositivo.Contadora
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.Contadora AddOrUpdate(Entities.Tables.Dispositivo.Contadora item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Dispositivo.Contadora)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Dispositivo.Contadora
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Dispositivo.Contadora item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Dispositivo.Contadora with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,String nombre,String descripcion,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Dispositivo.Contadora {Id = id,Nombre = nombre,Descripcion = descripcion,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Dispositivo.Contadora
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Dispositivo.Contadora item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Dispositivo.Contadora with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Dispositivo.Contadora {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Dispositivo.Contadora> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Contadora
	} //namespace Depositary.Business.Tables.Dispositivo
	namespace Depositary.Business.Tables.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Estado : DataHandler
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
         protected List<Entities.Tables.Dispositivo.Estado> _entities = new List<Entities.Tables.Dispositivo.Estado>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Estado() : base()
            {
                base._dataItem = new Entities.Tables.Dispositivo.Estado();
            }
            public Estado(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Dispositivo.Estado();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Dispositivo.Estado item)
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
         /// <returns>Entities.Tables.Dispositivo.Estado</returns>
			public Entities.Tables.Dispositivo.Estado Add(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Dispositivo.Estado)base.Add(new Entities.Tables.Dispositivo.Estado(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Dispositivo.Estado> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Dispositivo.Estado>().ToList<Entities.Tables.Dispositivo.Estado>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Dispositivo.Estado items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Dispositivo.Estado> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Dispositivo.Estado items with parameters.
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
            public List<Entities.Tables.Dispositivo.Estado> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Dispositivo.Estado
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.Estado Add(Entities.Tables.Dispositivo.Estado item)
            {
                return (Entities.Tables.Dispositivo.Estado)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Dispositivo.Estado
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.Estado AddOrUpdate(Entities.Tables.Dispositivo.Estado item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Dispositivo.Estado)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Dispositivo.Estado
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Dispositivo.Estado item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Dispositivo.Estado with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Dispositivo.Estado {Id = id,Nombre = nombre,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Dispositivo.Estado
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Dispositivo.Estado item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Dispositivo.Estado with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Dispositivo.Estado {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Dispositivo.Estado> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Estado
	} //namespace Depositary.Business.Tables.Dispositivo
	namespace Depositary.Business.Tables.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Maquina : DataHandler
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
         protected List<Entities.Tables.Dispositivo.Maquina> _entities = new List<Entities.Tables.Dispositivo.Maquina>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Maquina() : base()
            {
                base._dataItem = new Entities.Tables.Dispositivo.Maquina();
            }
            public Maquina(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Dispositivo.Maquina();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Dispositivo.Maquina item)
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
         /// <param name='SucursalCompaniaId'></param>
         /// <param name='NumeroSerie'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='MaquinaTipoId'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Tables.Dispositivo.Maquina</returns>
			public Entities.Tables.Dispositivo.Maquina Add(String Nombre,String Descripcion,Int64 SucursalCompaniaId,String NumeroSerie,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Int64 MaquinaTipoId,Boolean Habilitado) 
			{
			  return (Entities.Tables.Dispositivo.Maquina)base.Add(new Entities.Tables.Dispositivo.Maquina(Nombre,Descripcion,SucursalCompaniaId,NumeroSerie,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,MaquinaTipoId,Habilitado));
			}
            public new List<Entities.Tables.Dispositivo.Maquina> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Dispositivo.Maquina>().ToList<Entities.Tables.Dispositivo.Maquina>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Dispositivo.Maquina items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Dispositivo.Maquina> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Dispositivo.Maquina items with parameters.
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
            public List<Entities.Tables.Dispositivo.Maquina> Items(Int64? Id,String Nombre,String Descripcion,Int64? SucursalCompaniaId,String NumeroSerie,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Int64? MaquinaTipoId,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (SucursalCompaniaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalCompaniaId, sqlEnum.OperandEnum.Equal, SucursalCompaniaId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.SucursalCompaniaId, Depositary.sqlEnum.OperandEnum.Equal, SucursalCompaniaId);
                    }
                   
                }
                if (NumeroSerie != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.NumeroSerie, sqlEnum.OperandEnum.Equal, NumeroSerie);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.NumeroSerie, Depositary.sqlEnum.OperandEnum.Equal, NumeroSerie);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (MaquinaTipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.MaquinaTipoId, sqlEnum.OperandEnum.Equal, MaquinaTipoId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.MaquinaTipoId, Depositary.sqlEnum.OperandEnum.Equal, MaquinaTipoId);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Dispositivo.Maquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.Maquina Add(Entities.Tables.Dispositivo.Maquina item)
            {
                return (Entities.Tables.Dispositivo.Maquina)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Dispositivo.Maquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.Maquina AddOrUpdate(Entities.Tables.Dispositivo.Maquina item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Dispositivo.Maquina)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Dispositivo.Maquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Dispositivo.Maquina item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Dispositivo.Maquina with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int64 sucursalcompaniaid,String numeroserie,DateTime fechacreacion,DateTime fechamodificacion,Int64 usuariocreacion,Int64 usuariomodificacion,String codigoexterno,Int64 maquinatipoid,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Dispositivo.Maquina {Id = id,Nombre = nombre,Descripcion = descripcion,SucursalCompaniaId = sucursalcompaniaid,NumeroSerie = numeroserie,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,CodigoExterno = codigoexterno,MaquinaTipoId = maquinatipoid,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Dispositivo.Maquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Dispositivo.Maquina item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Dispositivo.Maquina with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Dispositivo.Maquina {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Dispositivo.Maquina> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Maquina
	} //namespace Depositary.Business.Tables.Dispositivo
	namespace Depositary.Business.Tables.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoConfiguracionMaquina : DataHandler
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
         protected List<Entities.Tables.Dispositivo.TipoConfiguracionMaquina> _entities = new List<Entities.Tables.Dispositivo.TipoConfiguracionMaquina>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public TipoConfiguracionMaquina() : base()
            {
                base._dataItem = new Entities.Tables.Dispositivo.TipoConfiguracionMaquina();
            }
            public TipoConfiguracionMaquina(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Dispositivo.TipoConfiguracionMaquina();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Dispositivo.TipoConfiguracionMaquina item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Dispositivo.TipoConfiguracionMaquina</returns>
			public Entities.Tables.Dispositivo.TipoConfiguracionMaquina Add(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Dispositivo.TipoConfiguracionMaquina)base.Add(new Entities.Tables.Dispositivo.TipoConfiguracionMaquina(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Dispositivo.TipoConfiguracionMaquina> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Dispositivo.TipoConfiguracionMaquina>().ToList<Entities.Tables.Dispositivo.TipoConfiguracionMaquina>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Dispositivo.TipoConfiguracionMaquina items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Dispositivo.TipoConfiguracionMaquina> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Dispositivo.TipoConfiguracionMaquina items with parameters.
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
            public List<Entities.Tables.Dispositivo.TipoConfiguracionMaquina> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Dispositivo.TipoConfiguracionMaquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.TipoConfiguracionMaquina Add(Entities.Tables.Dispositivo.TipoConfiguracionMaquina item)
            {
                return (Entities.Tables.Dispositivo.TipoConfiguracionMaquina)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Dispositivo.TipoConfiguracionMaquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Dispositivo.TipoConfiguracionMaquina AddOrUpdate(Entities.Tables.Dispositivo.TipoConfiguracionMaquina item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Dispositivo.TipoConfiguracionMaquina)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Dispositivo.TipoConfiguracionMaquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Dispositivo.TipoConfiguracionMaquina item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Dispositivo.TipoConfiguracionMaquina with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Dispositivo.TipoConfiguracionMaquina {Id = id,Nombre = nombre,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Dispositivo.TipoConfiguracionMaquina
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Dispositivo.TipoConfiguracionMaquina item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Dispositivo.TipoConfiguracionMaquina with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Dispositivo.TipoConfiguracionMaquina {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Dispositivo.TipoConfiguracionMaquina> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoConfiguracionMaquina
	} //namespace Depositary.Business.Tables.Dispositivo
	namespace Depositary.Business.Tables.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Evento : DataHandler
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
         protected List<Entities.Tables.Operacion.Evento> _entities = new List<Entities.Tables.Operacion.Evento>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Evento() : base()
            {
                base._dataItem = new Entities.Tables.Operacion.Evento();
            }
            public Evento(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Operacion.Evento();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Operacion.Evento item)
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
         /// <returns>Entities.Tables.Operacion.Evento</returns>
			public Entities.Tables.Operacion.Evento Add(Int64 TipoId,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Operacion.Evento)base.Add(new Entities.Tables.Operacion.Evento(TipoId,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Operacion.Evento> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Operacion.Evento>().ToList<Entities.Tables.Operacion.Evento>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Operacion.Evento items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Operacion.Evento> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Operacion.Evento items with parameters.
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
            public List<Entities.Tables.Operacion.Evento> Items(Int64? Id,Int64? TipoId,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Operacion.Evento
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.Evento Add(Entities.Tables.Operacion.Evento item)
            {
                return (Entities.Tables.Operacion.Evento)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Operacion.Evento
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.Evento AddOrUpdate(Entities.Tables.Operacion.Evento item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Operacion.Evento)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Operacion.Evento
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Operacion.Evento item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Operacion.Evento with parameters
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
            public Int64 Update(Int64 id,Int64 tipoid,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Operacion.Evento {Id = id,TipoId = tipoid,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Operacion.Evento
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Operacion.Evento item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Operacion.Evento with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Operacion.Evento {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Operacion.Evento> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Evento
	} //namespace Depositary.Business.Tables.Operacion
	namespace Depositary.Business.Tables.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoEvento : DataHandler
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
         protected List<Entities.Tables.Operacion.TipoEvento> _entities = new List<Entities.Tables.Operacion.TipoEvento>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public TipoEvento() : base()
            {
                base._dataItem = new Entities.Tables.Operacion.TipoEvento();
            }
            public TipoEvento(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Operacion.TipoEvento();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Operacion.TipoEvento item)
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
         /// <returns>Entities.Tables.Operacion.TipoEvento</returns>
			public Entities.Tables.Operacion.TipoEvento Add(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Operacion.TipoEvento)base.Add(new Entities.Tables.Operacion.TipoEvento(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Operacion.TipoEvento> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Operacion.TipoEvento>().ToList<Entities.Tables.Operacion.TipoEvento>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Operacion.TipoEvento items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Operacion.TipoEvento> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Operacion.TipoEvento items with parameters.
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
            public List<Entities.Tables.Operacion.TipoEvento> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Operacion.TipoEvento
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.TipoEvento Add(Entities.Tables.Operacion.TipoEvento item)
            {
                return (Entities.Tables.Operacion.TipoEvento)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Operacion.TipoEvento
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.TipoEvento AddOrUpdate(Entities.Tables.Operacion.TipoEvento item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Operacion.TipoEvento)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Operacion.TipoEvento
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Operacion.TipoEvento item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Operacion.TipoEvento with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Operacion.TipoEvento {Id = id,Nombre = nombre,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Operacion.TipoEvento
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Operacion.TipoEvento item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Operacion.TipoEvento with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Operacion.TipoEvento {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Operacion.TipoEvento> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoEvento
	} //namespace Depositary.Business.Tables.Operacion
	namespace Depositary.Business.Tables.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Transaccion : DataHandler
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
         protected List<Entities.Tables.Operacion.Transaccion> _entities = new List<Entities.Tables.Operacion.Transaccion>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Transaccion() : base()
            {
                base._dataItem = new Entities.Tables.Operacion.Transaccion();
            }
            public Transaccion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Operacion.Transaccion();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Operacion.Transaccion item)
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
         /// <returns>Entities.Tables.Operacion.Transaccion</returns>
			public Entities.Tables.Operacion.Transaccion Add(Int64 MaquinaId,Int64 UsuarioId,Double ValorDeclarado,Double ValorCertificado,DateTime FechaInicio,DateTime FechaFin) 
			{
			  return (Entities.Tables.Operacion.Transaccion)base.Add(new Entities.Tables.Operacion.Transaccion(MaquinaId,UsuarioId,ValorDeclarado,ValorCertificado,FechaInicio,FechaFin));
			}
            public new List<Entities.Tables.Operacion.Transaccion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Operacion.Transaccion>().ToList<Entities.Tables.Operacion.Transaccion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Operacion.Transaccion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Operacion.Transaccion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Operacion.Transaccion items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="MaquinaId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="ValorDeclarado"></param>
            /// <param name="ValorCertificado"></param>
            /// <param name="FechaInicio"></param>
            /// <param name="FechaFin"></param>
            /// <returns></returns>
            public List<Entities.Tables.Operacion.Transaccion> Items(Int64? Id,Int64? MaquinaId,Int64? UsuarioId,Double? ValorDeclarado,Double? ValorCertificado,DateTime? FechaInicio,DateTime? FechaFin)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (MaquinaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.MaquinaId, sqlEnum.OperandEnum.Equal, MaquinaId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.MaquinaId, Depositary.sqlEnum.OperandEnum.Equal, MaquinaId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (ValorDeclarado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorDeclarado, sqlEnum.OperandEnum.Equal, ValorDeclarado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.ValorDeclarado, Depositary.sqlEnum.OperandEnum.Equal, ValorDeclarado);
                    }
                   
                }
                if (ValorCertificado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorCertificado, sqlEnum.OperandEnum.Equal, ValorCertificado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.ValorCertificado, Depositary.sqlEnum.OperandEnum.Equal, ValorCertificado);
                    }
                   
                }
                if (FechaInicio != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaInicio, sqlEnum.OperandEnum.Equal, FechaInicio);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaInicio, Depositary.sqlEnum.OperandEnum.Equal, FechaInicio);
                    }
                   
                }
                if (FechaFin != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaFin, sqlEnum.OperandEnum.Equal, FechaFin);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaFin, Depositary.sqlEnum.OperandEnum.Equal, FechaFin);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Operacion.Transaccion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.Transaccion Add(Entities.Tables.Operacion.Transaccion item)
            {
                return (Entities.Tables.Operacion.Transaccion)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Operacion.Transaccion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.Transaccion AddOrUpdate(Entities.Tables.Operacion.Transaccion item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Operacion.Transaccion)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Operacion.Transaccion
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Operacion.Transaccion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Operacion.Transaccion with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="MaquinaId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="ValorDeclarado"></param>
            /// <param name="ValorCertificado"></param>
            /// <param name="FechaInicio"></param>
            /// <param name="FechaFin"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,Int64 maquinaid,Int64 usuarioid,Double valordeclarado,Double valorcertificado,DateTime fechainicio,DateTime fechafin)
            {
                return base.Update((IDataItem) new Entities.Tables.Operacion.Transaccion {Id = id,MaquinaId = maquinaid,UsuarioId = usuarioid,ValorDeclarado = valordeclarado,ValorCertificado = valorcertificado,FechaInicio = fechainicio,FechaFin = fechafin});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Operacion.Transaccion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Operacion.Transaccion item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Operacion.Transaccion with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Operacion.Transaccion {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Operacion.Transaccion> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Transaccion
	} //namespace Depositary.Business.Tables.Operacion
	namespace Depositary.Business.Tables.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TransaccionDetalle : DataHandler
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
         protected List<Entities.Tables.Operacion.TransaccionDetalle> _entities = new List<Entities.Tables.Operacion.TransaccionDetalle>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public TransaccionDetalle() : base()
            {
                base._dataItem = new Entities.Tables.Operacion.TransaccionDetalle();
            }
            public TransaccionDetalle(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Operacion.TransaccionDetalle();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Operacion.TransaccionDetalle item)
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
         /// <param name='TransaccionId'></param>
         /// <param name='DenominacionId'></param>
         /// <param name='CantidadCertificada'></param>
         /// <param name='CantidadDeclarada'></param>
         /// <param name='Fecha'></param>
         /// <returns>Entities.Tables.Operacion.TransaccionDetalle</returns>
			public Entities.Tables.Operacion.TransaccionDetalle Add(Int64 TransaccionId,Int64 DenominacionId,Int64 CantidadCertificada,Int64 CantidadDeclarada,DateTime Fecha) 
			{
			  return (Entities.Tables.Operacion.TransaccionDetalle)base.Add(new Entities.Tables.Operacion.TransaccionDetalle(TransaccionId,DenominacionId,CantidadCertificada,CantidadDeclarada,Fecha));
			}
            public new List<Entities.Tables.Operacion.TransaccionDetalle> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Operacion.TransaccionDetalle>().ToList<Entities.Tables.Operacion.TransaccionDetalle>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Operacion.TransaccionDetalle items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Operacion.TransaccionDetalle> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Operacion.TransaccionDetalle items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TransaccionId"></param>
            /// <param name="DenominacionId"></param>
            /// <param name="CantidadCertificada"></param>
            /// <param name="CantidadDeclarada"></param>
            /// <param name="Fecha"></param>
            /// <returns></returns>
            public List<Entities.Tables.Operacion.TransaccionDetalle> Items(Int64? Id,Int64? TransaccionId,Int64? DenominacionId,Int64? CantidadCertificada,Int64? CantidadDeclarada,DateTime? Fecha)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TransaccionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.TransaccionId, Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (DenominacionId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DenominacionId, sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.DenominacionId, Depositary.sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                   
                }
                if (CantidadCertificada != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadCertificada, sqlEnum.OperandEnum.Equal, CantidadCertificada);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CantidadCertificada, Depositary.sqlEnum.OperandEnum.Equal, CantidadCertificada);
                    }
                   
                }
                if (CantidadDeclarada != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadDeclarada, sqlEnum.OperandEnum.Equal, CantidadDeclarada);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CantidadDeclarada, Depositary.sqlEnum.OperandEnum.Equal, CantidadDeclarada);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Fecha, Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Operacion.TransaccionDetalle
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.TransaccionDetalle Add(Entities.Tables.Operacion.TransaccionDetalle item)
            {
                return (Entities.Tables.Operacion.TransaccionDetalle)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Operacion.TransaccionDetalle
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.TransaccionDetalle AddOrUpdate(Entities.Tables.Operacion.TransaccionDetalle item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Operacion.TransaccionDetalle)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Operacion.TransaccionDetalle
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Operacion.TransaccionDetalle item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Operacion.TransaccionDetalle with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="TransaccionId"></param>
            /// <param name="DenominacionId"></param>
            /// <param name="CantidadCertificada"></param>
            /// <param name="CantidadDeclarada"></param>
            /// <param name="Fecha"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,Int64 transaccionid,Int64 denominacionid,Int64 cantidadcertificada,Int64 cantidaddeclarada,DateTime fecha)
            {
                return base.Update((IDataItem) new Entities.Tables.Operacion.TransaccionDetalle {Id = id,TransaccionId = transaccionid,DenominacionId = denominacionid,CantidadCertificada = cantidadcertificada,CantidadDeclarada = cantidaddeclarada,Fecha = fecha});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Operacion.TransaccionDetalle
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Operacion.TransaccionDetalle item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Operacion.TransaccionDetalle with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Operacion.TransaccionDetalle {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Operacion.TransaccionDetalle> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TransaccionDetalle
	} //namespace Depositary.Business.Tables.Operacion
	namespace Depositary.Business.Tables.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Turno : DataHandler
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
         protected List<Entities.Tables.Operacion.Turno> _entities = new List<Entities.Tables.Operacion.Turno>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Turno() : base()
            {
                base._dataItem = new Entities.Tables.Operacion.Turno();
            }
            public Turno(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Operacion.Turno();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Operacion.Turno item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Operacion.Turno</returns>
			public Entities.Tables.Operacion.Turno Add(String Nombre,String Descripcion,TimeSpan Desde,TimeSpan Hasta,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Operacion.Turno)base.Add(new Entities.Tables.Operacion.Turno(Nombre,Descripcion,Desde,Hasta,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Operacion.Turno> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Operacion.Turno>().ToList<Entities.Tables.Operacion.Turno>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Operacion.Turno items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Operacion.Turno> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Operacion.Turno items with parameters.
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
            public List<Entities.Tables.Operacion.Turno> Items(Int64? Id,String Nombre,String Descripcion,TimeSpan? Desde,TimeSpan? Hasta,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Desde != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Desde, sqlEnum.OperandEnum.Equal, Desde);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Desde, Depositary.sqlEnum.OperandEnum.Equal, Desde);
                    }
                   
                }
                if (Hasta != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Hasta, sqlEnum.OperandEnum.Equal, Hasta);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Hasta, Depositary.sqlEnum.OperandEnum.Equal, Hasta);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Operacion.Turno
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.Turno Add(Entities.Tables.Operacion.Turno item)
            {
                return (Entities.Tables.Operacion.Turno)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Operacion.Turno
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.Turno AddOrUpdate(Entities.Tables.Operacion.Turno item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Operacion.Turno)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Operacion.Turno
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Operacion.Turno item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Operacion.Turno with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,TimeSpan desde,TimeSpan hasta,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Operacion.Turno {Id = id,Nombre = nombre,Descripcion = descripcion,Desde = desde,Hasta = hasta,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Operacion.Turno
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Operacion.Turno item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Operacion.Turno with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Operacion.Turno {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Operacion.Turno> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Turno
	} //namespace Depositary.Business.Tables.Operacion
	namespace Depositary.Business.Tables.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TurnoUsuario : DataHandler
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
         protected List<Entities.Tables.Operacion.TurnoUsuario> _entities = new List<Entities.Tables.Operacion.TurnoUsuario>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public TurnoUsuario() : base()
            {
                base._dataItem = new Entities.Tables.Operacion.TurnoUsuario();
            }
            public TurnoUsuario(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Operacion.TurnoUsuario();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Operacion.TurnoUsuario item)
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
         /// <returns>Entities.Tables.Operacion.TurnoUsuario</returns>
			public Entities.Tables.Operacion.TurnoUsuario Add(Int64 UsuarioId,Int64 TurnoId,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Operacion.TurnoUsuario)base.Add(new Entities.Tables.Operacion.TurnoUsuario(UsuarioId,TurnoId,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Operacion.TurnoUsuario> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Operacion.TurnoUsuario>().ToList<Entities.Tables.Operacion.TurnoUsuario>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Operacion.TurnoUsuario items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Operacion.TurnoUsuario> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Operacion.TurnoUsuario items with parameters.
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
            public List<Entities.Tables.Operacion.TurnoUsuario> Items(Int64? Id,Int64? UsuarioId,Int64? TurnoId,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (TurnoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TurnoId, sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.TurnoId, Depositary.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Operacion.TurnoUsuario
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.TurnoUsuario Add(Entities.Tables.Operacion.TurnoUsuario item)
            {
                return (Entities.Tables.Operacion.TurnoUsuario)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Operacion.TurnoUsuario
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Operacion.TurnoUsuario AddOrUpdate(Entities.Tables.Operacion.TurnoUsuario item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Operacion.TurnoUsuario)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Operacion.TurnoUsuario
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Operacion.TurnoUsuario item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Operacion.TurnoUsuario with parameters
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
            public Int64 Update(Int64 id,Int64 usuarioid,Int64 turnoid,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Operacion.TurnoUsuario {Id = id,UsuarioId = usuarioid,TurnoId = turnoid,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Operacion.TurnoUsuario
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Operacion.TurnoUsuario item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Operacion.TurnoUsuario with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Operacion.TurnoUsuario {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Operacion.TurnoUsuario> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TurnoUsuario
	} //namespace Depositary.Business.Tables.Operacion
	namespace Depositary.Business.Tables.Regionalizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Lenguaje : DataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado
				}
         protected List<Entities.Tables.Regionalizacion.Lenguaje> _entities = new List<Entities.Tables.Regionalizacion.Lenguaje>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Lenguaje() : base()
            {
                base._dataItem = new Entities.Tables.Regionalizacion.Lenguaje();
            }
            public Lenguaje(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Regionalizacion.Lenguaje();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Regionalizacion.Lenguaje item)
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
         /// <returns>Entities.Tables.Regionalizacion.Lenguaje</returns>
			public Entities.Tables.Regionalizacion.Lenguaje Add(String Nombre,String Descripcion,Boolean Habilitado) 
			{
			  return (Entities.Tables.Regionalizacion.Lenguaje)base.Add(new Entities.Tables.Regionalizacion.Lenguaje(Nombre,Descripcion,Habilitado));
			}
            public new List<Entities.Tables.Regionalizacion.Lenguaje> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Regionalizacion.Lenguaje>().ToList<Entities.Tables.Regionalizacion.Lenguaje>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Regionalizacion.Lenguaje items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Regionalizacion.Lenguaje> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Regionalizacion.Lenguaje items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Tables.Regionalizacion.Lenguaje> Items(Int64? Id,String Nombre,String Descripcion,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Regionalizacion.Lenguaje
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Regionalizacion.Lenguaje Add(Entities.Tables.Regionalizacion.Lenguaje item)
            {
                return (Entities.Tables.Regionalizacion.Lenguaje)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Regionalizacion.Lenguaje
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Regionalizacion.Lenguaje AddOrUpdate(Entities.Tables.Regionalizacion.Lenguaje item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Regionalizacion.Lenguaje)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Regionalizacion.Lenguaje
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Regionalizacion.Lenguaje item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Regionalizacion.Lenguaje with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,String nombre,String descripcion,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Regionalizacion.Lenguaje {Id = id,Nombre = nombre,Descripcion = descripcion,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Regionalizacion.Lenguaje
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Regionalizacion.Lenguaje item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Regionalizacion.Lenguaje with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Regionalizacion.Lenguaje {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Regionalizacion.Lenguaje> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Lenguaje
	} //namespace Depositary.Business.Tables.Regionalizacion
	namespace Depositary.Business.Tables.Regionalizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class LenguajeItem : DataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					LenguajeId,
					Clave,
					Texto,
					Habilitado
				}
         protected List<Entities.Tables.Regionalizacion.LenguajeItem> _entities = new List<Entities.Tables.Regionalizacion.LenguajeItem>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public LenguajeItem() : base()
            {
                base._dataItem = new Entities.Tables.Regionalizacion.LenguajeItem();
            }
            public LenguajeItem(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Regionalizacion.LenguajeItem();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Regionalizacion.LenguajeItem item)
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
         /// <param name='LenguajeId'></param>
         /// <param name='Clave'></param>
         /// <param name='Texto'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Tables.Regionalizacion.LenguajeItem</returns>
			public Entities.Tables.Regionalizacion.LenguajeItem Add(Int64 LenguajeId,String Clave,String Texto,Boolean Habilitado) 
			{
			  return (Entities.Tables.Regionalizacion.LenguajeItem)base.Add(new Entities.Tables.Regionalizacion.LenguajeItem(LenguajeId,Clave,Texto,Habilitado));
			}
            public new List<Entities.Tables.Regionalizacion.LenguajeItem> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Regionalizacion.LenguajeItem>().ToList<Entities.Tables.Regionalizacion.LenguajeItem>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Regionalizacion.LenguajeItem items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Regionalizacion.LenguajeItem> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Regionalizacion.LenguajeItem items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="LenguajeId"></param>
            /// <param name="Clave"></param>
            /// <param name="Texto"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Tables.Regionalizacion.LenguajeItem> Items(Int64? Id,Int64? LenguajeId,String Clave,String Texto,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (LenguajeId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.LenguajeId, sqlEnum.OperandEnum.Equal, LenguajeId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.LenguajeId, Depositary.sqlEnum.OperandEnum.Equal, LenguajeId);
                    }
                   
                }
                if (Clave != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Clave, sqlEnum.OperandEnum.Equal, Clave);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Clave, Depositary.sqlEnum.OperandEnum.Equal, Clave);
                    }
                   
                }
                if (Texto != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Texto, sqlEnum.OperandEnum.Equal, Texto);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Texto, Depositary.sqlEnum.OperandEnum.Equal, Texto);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Regionalizacion.LenguajeItem
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Regionalizacion.LenguajeItem Add(Entities.Tables.Regionalizacion.LenguajeItem item)
            {
                return (Entities.Tables.Regionalizacion.LenguajeItem)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Regionalizacion.LenguajeItem
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Regionalizacion.LenguajeItem AddOrUpdate(Entities.Tables.Regionalizacion.LenguajeItem item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Regionalizacion.LenguajeItem)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Regionalizacion.LenguajeItem
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Regionalizacion.LenguajeItem item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Regionalizacion.LenguajeItem with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="LenguajeId"></param>
            /// <param name="Clave"></param>
            /// <param name="Texto"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,Int64 lenguajeid,String clave,String texto,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Regionalizacion.LenguajeItem {Id = id,LenguajeId = lenguajeid,Clave = clave,Texto = texto,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Regionalizacion.LenguajeItem
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Regionalizacion.LenguajeItem item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Regionalizacion.LenguajeItem with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Regionalizacion.LenguajeItem {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Regionalizacion.LenguajeItem> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class LenguajeItem
	} //namespace Depositary.Business.Tables.Regionalizacion
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Aplicacion : DataHandler
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
         protected List<Entities.Tables.Seguridad.Aplicacion> _entities = new List<Entities.Tables.Seguridad.Aplicacion>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Aplicacion() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.Aplicacion();
            }
            public Aplicacion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.Aplicacion();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.Aplicacion item)
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
         /// <param name='Tipo_Id'></param>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.Aplicacion</returns>
			public Entities.Tables.Seguridad.Aplicacion Add(Int64 Tipo_Id,String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.Aplicacion)base.Add(new Entities.Tables.Seguridad.Aplicacion(Tipo_Id,Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.Aplicacion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.Aplicacion>().ToList<Entities.Tables.Seguridad.Aplicacion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.Aplicacion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.Aplicacion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.Aplicacion items with parameters.
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
            public List<Entities.Tables.Seguridad.Aplicacion> Items(Int64? Id,Int64? Tipo_Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Tipo_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo_Id, sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.Aplicacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Aplicacion Add(Entities.Tables.Seguridad.Aplicacion item)
            {
                return (Entities.Tables.Seguridad.Aplicacion)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.Aplicacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Aplicacion AddOrUpdate(Entities.Tables.Seguridad.Aplicacion item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.Aplicacion)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.Aplicacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.Aplicacion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.Aplicacion with parameters
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
            public Int64 Update(Int64 id,Int64 tipo_id,String nombre,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.Aplicacion {Id = id,Tipo_Id = tipo_id,Nombre = nombre,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.Aplicacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.Aplicacion item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.Aplicacion with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.Aplicacion {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.Aplicacion> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Aplicacion
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class EstadoLogico : DataHandler
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
         protected List<Entities.Tables.Seguridad.EstadoLogico> _entities = new List<Entities.Tables.Seguridad.EstadoLogico>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public EstadoLogico() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.EstadoLogico();
            }
            public EstadoLogico(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.EstadoLogico();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.EstadoLogico item)
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
         /// <returns>Entities.Tables.Seguridad.EstadoLogico</returns>
			public Entities.Tables.Seguridad.EstadoLogico Add(String Nombre,String Descripcion,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.EstadoLogico)base.Add(new Entities.Tables.Seguridad.EstadoLogico(Nombre,Descripcion,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.EstadoLogico> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.EstadoLogico>().ToList<Entities.Tables.Seguridad.EstadoLogico>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.EstadoLogico items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.EstadoLogico> Items(Int16 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.EstadoLogico items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.EstadoLogico> Items(Int16? Id,String Nombre,String Descripcion,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.EstadoLogico
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.EstadoLogico Add(Entities.Tables.Seguridad.EstadoLogico item)
            {
                return (Entities.Tables.Seguridad.EstadoLogico)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.EstadoLogico
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.EstadoLogico AddOrUpdate(Entities.Tables.Seguridad.EstadoLogico item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.EstadoLogico)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.EstadoLogico
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.EstadoLogico item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.EstadoLogico with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int16 id,String nombre,String descripcion,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.EstadoLogico {Id = id,Nombre = nombre,Descripcion = descripcion,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.EstadoLogico
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.EstadoLogico item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.EstadoLogico with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int16 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.EstadoLogico {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.EstadoLogico> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class EstadoLogico
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Funcion : DataHandler
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
         protected List<Entities.Tables.Seguridad.Funcion> _entities = new List<Entities.Tables.Seguridad.Funcion>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Funcion() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.Funcion();
            }
            public Funcion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.Funcion();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.Funcion item)
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
         /// <param name='Aplicacion_Id'></param>
         /// <param name='Tipo_Id'></param>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Referencia'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.Funcion</returns>
			public Entities.Tables.Seguridad.Funcion Add(Int64 Aplicacion_Id,Int64? Tipo_Id,String Nombre,String Descripcion,String Referencia,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.Funcion)base.Add(new Entities.Tables.Seguridad.Funcion(Aplicacion_Id,Tipo_Id,Nombre,Descripcion,Referencia,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.Funcion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.Funcion>().ToList<Entities.Tables.Seguridad.Funcion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.Funcion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.Funcion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.Funcion items with parameters.
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
            public List<Entities.Tables.Seguridad.Funcion> Items(Int64? Id,Int64? Aplicacion_Id,Int64? Tipo_Id,String Nombre,String Descripcion,String Referencia,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Aplicacion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Aplicacion_Id, sqlEnum.OperandEnum.Equal, Aplicacion_Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Aplicacion_Id, Depositary.sqlEnum.OperandEnum.Equal, Aplicacion_Id);
                    }
                   
                }
                if (Tipo_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo_Id, sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Referencia != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Referencia, sqlEnum.OperandEnum.Equal, Referencia);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Referencia, Depositary.sqlEnum.OperandEnum.Equal, Referencia);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.Funcion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Funcion Add(Entities.Tables.Seguridad.Funcion item)
            {
                return (Entities.Tables.Seguridad.Funcion)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.Funcion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Funcion AddOrUpdate(Entities.Tables.Seguridad.Funcion item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.Funcion)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.Funcion
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.Funcion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.Funcion with parameters
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
            public Int64 Update(Int64 id,Int64 aplicacion_id,Int64? tipo_id,String nombre,String descripcion,String referencia,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.Funcion {Id = id,Aplicacion_Id = aplicacion_id,Tipo_Id = tipo_id,Nombre = nombre,Descripcion = descripcion,Referencia = referencia,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.Funcion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.Funcion item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.Funcion with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.Funcion {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.Funcion> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Funcion
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Identificador : DataHandler
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
         protected List<Entities.Tables.Seguridad.Identificador> _entities = new List<Entities.Tables.Seguridad.Identificador>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Identificador() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.Identificador();
            }
            public Identificador(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.Identificador();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.Identificador item)
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
         /// <returns>Entities.Tables.Seguridad.Identificador</returns>
			public Entities.Tables.Seguridad.Identificador Add(Int64 TipoId,Int64 UsuarioId,String Valor,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.Identificador)base.Add(new Entities.Tables.Seguridad.Identificador(TipoId,UsuarioId,Valor,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.Identificador> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.Identificador>().ToList<Entities.Tables.Seguridad.Identificador>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.Identificador items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.Identificador> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.Identificador items with parameters.
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
            public List<Entities.Tables.Seguridad.Identificador> Items(Int64? Id,Int64? TipoId,Int64? UsuarioId,String Valor,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoId, sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioId, Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (Valor != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor, sqlEnum.OperandEnum.Equal, Valor);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.Identificador
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Identificador Add(Entities.Tables.Seguridad.Identificador item)
            {
                return (Entities.Tables.Seguridad.Identificador)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.Identificador
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Identificador AddOrUpdate(Entities.Tables.Seguridad.Identificador item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.Identificador)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.Identificador
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.Identificador item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.Identificador with parameters
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
            public Int64 Update(Int64 id,Int64 tipoid,Int64 usuarioid,String valor,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.Identificador {Id = id,TipoId = tipoid,UsuarioId = usuarioid,Valor = valor,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.Identificador
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.Identificador item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.Identificador with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.Identificador {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.Identificador> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Identificador
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Menu : DataHandler
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
         protected List<Entities.Tables.Seguridad.Menu> _entities = new List<Entities.Tables.Seguridad.Menu>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Menu() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.Menu();
            }
            public Menu(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.Menu();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.Menu item)
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
         /// <param name='Tipo_Id'></param>
         /// <param name='Nombre'></param>
         /// <param name='Descripcion'></param>
         /// <param name='Funcion_Id'></param>
         /// <param name='Imagen'></param>
         /// <param name='DependeDe'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.Menu</returns>
			public Entities.Tables.Seguridad.Menu Add(Int64 Tipo_Id,String Nombre,String Descripcion,Int64? Funcion_Id,String Imagen,Int64? DependeDe,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.Menu)base.Add(new Entities.Tables.Seguridad.Menu(Tipo_Id,Nombre,Descripcion,Funcion_Id,Imagen,DependeDe,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.Menu> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.Menu>().ToList<Entities.Tables.Seguridad.Menu>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.Menu items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.Menu> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.Menu items with parameters.
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
            public List<Entities.Tables.Seguridad.Menu> Items(Int64? Id,Int64? Tipo_Id,String Nombre,String Descripcion,Int64? Funcion_Id,String Imagen,Int64? DependeDe,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Tipo_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo_Id, sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Tipo_Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Funcion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Funcion_Id, sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                   
                }
                if (Imagen != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Imagen, sqlEnum.OperandEnum.Equal, Imagen);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Imagen, Depositary.sqlEnum.OperandEnum.Equal, Imagen);
                    }
                   
                }
                if (DependeDe != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DependeDe, sqlEnum.OperandEnum.Equal, DependeDe);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.DependeDe, Depositary.sqlEnum.OperandEnum.Equal, DependeDe);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.Menu
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Menu Add(Entities.Tables.Seguridad.Menu item)
            {
                return (Entities.Tables.Seguridad.Menu)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.Menu
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Menu AddOrUpdate(Entities.Tables.Seguridad.Menu item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.Menu)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.Menu
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.Menu item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.Menu with parameters
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
            public Int64 Update(Int64 id,Int64 tipo_id,String nombre,String descripcion,Int64? funcion_id,String imagen,Int64? dependede,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.Menu {Id = id,Tipo_Id = tipo_id,Nombre = nombre,Descripcion = descripcion,Funcion_Id = funcion_id,Imagen = imagen,DependeDe = dependede,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.Menu
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.Menu item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.Menu with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.Menu {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.Menu> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Menu
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Rol : DataHandler
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
         protected List<Entities.Tables.Seguridad.Rol> _entities = new List<Entities.Tables.Seguridad.Rol>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Rol() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.Rol();
            }
            public Rol(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.Rol();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.Rol item)
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
         /// <param name='DependeDe'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.Rol</returns>
			public Entities.Tables.Seguridad.Rol Add(String Nombre,String Descripcion,Int64? DependeDe,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.Rol)base.Add(new Entities.Tables.Seguridad.Rol(Nombre,Descripcion,DependeDe,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.Rol> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.Rol>().ToList<Entities.Tables.Seguridad.Rol>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.Rol items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.Rol> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.Rol items with parameters.
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
            public List<Entities.Tables.Seguridad.Rol> Items(Int64? Id,String Nombre,String Descripcion,Int64? DependeDe,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (DependeDe != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DependeDe, sqlEnum.OperandEnum.Equal, DependeDe);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.DependeDe, Depositary.sqlEnum.OperandEnum.Equal, DependeDe);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.Rol
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Rol Add(Entities.Tables.Seguridad.Rol item)
            {
                return (Entities.Tables.Seguridad.Rol)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.Rol
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Rol AddOrUpdate(Entities.Tables.Seguridad.Rol item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.Rol)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.Rol
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.Rol item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.Rol with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int64? dependede,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.Rol {Id = id,Nombre = nombre,Descripcion = descripcion,DependeDe = dependede,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.Rol
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.Rol item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.Rol with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.Rol {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.Rol> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Rol
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class RolFuncion : DataHandler
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
         protected List<Entities.Tables.Seguridad.RolFuncion> _entities = new List<Entities.Tables.Seguridad.RolFuncion>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public RolFuncion() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.RolFuncion();
            }
            public RolFuncion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.RolFuncion();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.RolFuncion item)
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
         /// <param name='Funcion_Id'></param>
         /// <param name='Rol_Id'></param>
         /// <param name='Descripcion'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.RolFuncion</returns>
			public Entities.Tables.Seguridad.RolFuncion Add(Int64 Funcion_Id,Int64 Rol_Id,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.RolFuncion)base.Add(new Entities.Tables.Seguridad.RolFuncion(Funcion_Id,Rol_Id,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.RolFuncion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.RolFuncion>().ToList<Entities.Tables.Seguridad.RolFuncion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.RolFuncion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.RolFuncion> Items(Int16 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.RolFuncion items with parameters.
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
            public List<Entities.Tables.Seguridad.RolFuncion> Items(Int16? Id,Int64? Funcion_Id,Int64? Rol_Id,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Funcion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Funcion_Id, sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                   
                }
                if (Rol_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Rol_Id, sqlEnum.OperandEnum.Equal, Rol_Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Rol_Id, Depositary.sqlEnum.OperandEnum.Equal, Rol_Id);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.RolFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.RolFuncion Add(Entities.Tables.Seguridad.RolFuncion item)
            {
                return (Entities.Tables.Seguridad.RolFuncion)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.RolFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.RolFuncion AddOrUpdate(Entities.Tables.Seguridad.RolFuncion item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.RolFuncion)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.RolFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.RolFuncion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.RolFuncion with parameters
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
            public Int64 Update(Int16 id,Int64 funcion_id,Int64 rol_id,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.RolFuncion {Id = id,Funcion_Id = funcion_id,Rol_Id = rol_id,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.RolFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.RolFuncion item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.RolFuncion with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int16 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.RolFuncion {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.RolFuncion> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class RolFuncion
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoAplicacion : DataHandler
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
         protected List<Entities.Tables.Seguridad.TipoAplicacion> _entities = new List<Entities.Tables.Seguridad.TipoAplicacion>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public TipoAplicacion() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.TipoAplicacion();
            }
            public TipoAplicacion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.TipoAplicacion();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.TipoAplicacion item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.TipoAplicacion</returns>
			public Entities.Tables.Seguridad.TipoAplicacion Add(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.TipoAplicacion)base.Add(new Entities.Tables.Seguridad.TipoAplicacion(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.TipoAplicacion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.TipoAplicacion>().ToList<Entities.Tables.Seguridad.TipoAplicacion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.TipoAplicacion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.TipoAplicacion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.TipoAplicacion items with parameters.
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
            public List<Entities.Tables.Seguridad.TipoAplicacion> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.TipoAplicacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.TipoAplicacion Add(Entities.Tables.Seguridad.TipoAplicacion item)
            {
                return (Entities.Tables.Seguridad.TipoAplicacion)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.TipoAplicacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.TipoAplicacion AddOrUpdate(Entities.Tables.Seguridad.TipoAplicacion item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.TipoAplicacion)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.TipoAplicacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.TipoAplicacion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.TipoAplicacion with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.TipoAplicacion {Id = id,Nombre = nombre,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.TipoAplicacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.TipoAplicacion item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.TipoAplicacion with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.TipoAplicacion {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.TipoAplicacion> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoAplicacion
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoFuncion : DataHandler
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
         protected List<Entities.Tables.Seguridad.TipoFuncion> _entities = new List<Entities.Tables.Seguridad.TipoFuncion>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public TipoFuncion() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.TipoFuncion();
            }
            public TipoFuncion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.TipoFuncion();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.TipoFuncion item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.TipoFuncion</returns>
			public Entities.Tables.Seguridad.TipoFuncion Add(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.TipoFuncion)base.Add(new Entities.Tables.Seguridad.TipoFuncion(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.TipoFuncion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.TipoFuncion>().ToList<Entities.Tables.Seguridad.TipoFuncion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.TipoFuncion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.TipoFuncion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.TipoFuncion items with parameters.
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
            public List<Entities.Tables.Seguridad.TipoFuncion> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.TipoFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.TipoFuncion Add(Entities.Tables.Seguridad.TipoFuncion item)
            {
                return (Entities.Tables.Seguridad.TipoFuncion)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.TipoFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.TipoFuncion AddOrUpdate(Entities.Tables.Seguridad.TipoFuncion item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.TipoFuncion)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.TipoFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.TipoFuncion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.TipoFuncion with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.TipoFuncion {Id = id,Nombre = nombre,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.TipoFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.TipoFuncion item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.TipoFuncion with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.TipoFuncion {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.TipoFuncion> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoFuncion
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoIdentificador : DataHandler
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
         protected List<Entities.Tables.Seguridad.TipoIdentificador> _entities = new List<Entities.Tables.Seguridad.TipoIdentificador>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public TipoIdentificador() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.TipoIdentificador();
            }
            public TipoIdentificador(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.TipoIdentificador();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.TipoIdentificador item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.TipoIdentificador</returns>
			public Entities.Tables.Seguridad.TipoIdentificador Add(String Nombre,String Descripcion,String Mascara,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.TipoIdentificador)base.Add(new Entities.Tables.Seguridad.TipoIdentificador(Nombre,Descripcion,Mascara,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.TipoIdentificador> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.TipoIdentificador>().ToList<Entities.Tables.Seguridad.TipoIdentificador>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.TipoIdentificador items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.TipoIdentificador> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.TipoIdentificador items with parameters.
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
            public List<Entities.Tables.Seguridad.TipoIdentificador> Items(Int64? Id,String Nombre,String Descripcion,String Mascara,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Mascara != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Mascara, sqlEnum.OperandEnum.Equal, Mascara);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Mascara, Depositary.sqlEnum.OperandEnum.Equal, Mascara);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.TipoIdentificador
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.TipoIdentificador Add(Entities.Tables.Seguridad.TipoIdentificador item)
            {
                return (Entities.Tables.Seguridad.TipoIdentificador)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.TipoIdentificador
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.TipoIdentificador AddOrUpdate(Entities.Tables.Seguridad.TipoIdentificador item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.TipoIdentificador)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.TipoIdentificador
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.TipoIdentificador item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.TipoIdentificador with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,String mascara,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.TipoIdentificador {Id = id,Nombre = nombre,Descripcion = descripcion,Mascara = mascara,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.TipoIdentificador
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.TipoIdentificador item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.TipoIdentificador with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.TipoIdentificador {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.TipoIdentificador> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoIdentificador
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class TipoMenu : DataHandler
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
         protected List<Entities.Tables.Seguridad.TipoMenu> _entities = new List<Entities.Tables.Seguridad.TipoMenu>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public TipoMenu() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.TipoMenu();
            }
            public TipoMenu(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.TipoMenu();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.TipoMenu item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.TipoMenu</returns>
			public Entities.Tables.Seguridad.TipoMenu Add(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.TipoMenu)base.Add(new Entities.Tables.Seguridad.TipoMenu(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.TipoMenu> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.TipoMenu>().ToList<Entities.Tables.Seguridad.TipoMenu>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.TipoMenu items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.TipoMenu> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.TipoMenu items with parameters.
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
            public List<Entities.Tables.Seguridad.TipoMenu> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.TipoMenu
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.TipoMenu Add(Entities.Tables.Seguridad.TipoMenu item)
            {
                return (Entities.Tables.Seguridad.TipoMenu)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.TipoMenu
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.TipoMenu AddOrUpdate(Entities.Tables.Seguridad.TipoMenu item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.TipoMenu)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.TipoMenu
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.TipoMenu item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.TipoMenu with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.TipoMenu {Id = id,Nombre = nombre,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.TipoMenu
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.TipoMenu item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.TipoMenu with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.TipoMenu {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.TipoMenu> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class TipoMenu
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Usuario : DataHandler
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
         protected List<Entities.Tables.Seguridad.Usuario> _entities = new List<Entities.Tables.Seguridad.Usuario>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Usuario() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.Usuario();
            }
            public Usuario(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.Usuario();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.Usuario item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.Usuario</returns>
			public Entities.Tables.Seguridad.Usuario Add(String Nombre,String Apellido,String Legajo,String Mail,DateTime FechaIngreso,String NickName,String Password,String Token,String Avatar,DateTime FechaUltimoLogin,Boolean DebeCambiarPassword,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.Usuario)base.Add(new Entities.Tables.Seguridad.Usuario(Nombre,Apellido,Legajo,Mail,FechaIngreso,NickName,Password,Token,Avatar,FechaUltimoLogin,DebeCambiarPassword,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.Usuario> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.Usuario>().ToList<Entities.Tables.Seguridad.Usuario>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.Usuario items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.Usuario> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.Usuario items with parameters.
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
            public List<Entities.Tables.Seguridad.Usuario> Items(Int64? Id,String Nombre,String Apellido,String Legajo,String Mail,DateTime? FechaIngreso,String NickName,String Password,String Token,String Avatar,DateTime? FechaUltimoLogin,Boolean? DebeCambiarPassword,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Apellido != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Apellido, sqlEnum.OperandEnum.Equal, Apellido);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Apellido, Depositary.sqlEnum.OperandEnum.Equal, Apellido);
                    }
                   
                }
                if (Legajo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Legajo, sqlEnum.OperandEnum.Equal, Legajo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Legajo, Depositary.sqlEnum.OperandEnum.Equal, Legajo);
                    }
                   
                }
                if (Mail != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Mail, sqlEnum.OperandEnum.Equal, Mail);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Mail, Depositary.sqlEnum.OperandEnum.Equal, Mail);
                    }
                   
                }
                if (FechaIngreso != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaIngreso, sqlEnum.OperandEnum.Equal, FechaIngreso);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaIngreso, Depositary.sqlEnum.OperandEnum.Equal, FechaIngreso);
                    }
                   
                }
                if (NickName != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.NickName, sqlEnum.OperandEnum.Equal, NickName);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.NickName, Depositary.sqlEnum.OperandEnum.Equal, NickName);
                    }
                   
                }
                if (Password != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Password, sqlEnum.OperandEnum.Equal, Password);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Password, Depositary.sqlEnum.OperandEnum.Equal, Password);
                    }
                   
                }
                if (Token != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Token, sqlEnum.OperandEnum.Equal, Token);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Token, Depositary.sqlEnum.OperandEnum.Equal, Token);
                    }
                   
                }
                if (Avatar != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Avatar, sqlEnum.OperandEnum.Equal, Avatar);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Avatar, Depositary.sqlEnum.OperandEnum.Equal, Avatar);
                    }
                   
                }
                if (FechaUltimoLogin != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaUltimoLogin, sqlEnum.OperandEnum.Equal, FechaUltimoLogin);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaUltimoLogin, Depositary.sqlEnum.OperandEnum.Equal, FechaUltimoLogin);
                    }
                   
                }
                if (DebeCambiarPassword != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DebeCambiarPassword, sqlEnum.OperandEnum.Equal, DebeCambiarPassword);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.DebeCambiarPassword, Depositary.sqlEnum.OperandEnum.Equal, DebeCambiarPassword);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.Usuario
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Usuario Add(Entities.Tables.Seguridad.Usuario item)
            {
                return (Entities.Tables.Seguridad.Usuario)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.Usuario
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.Usuario AddOrUpdate(Entities.Tables.Seguridad.Usuario item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.Usuario)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.Usuario
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.Usuario item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.Usuario with parameters
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
            public Int64 Update(Int64 id,String nombre,String apellido,String legajo,String mail,DateTime fechaingreso,String nickname,String password,String token,String avatar,DateTime fechaultimologin,Boolean debecambiarpassword,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.Usuario {Id = id,Nombre = nombre,Apellido = apellido,Legajo = legajo,Mail = mail,FechaIngreso = fechaingreso,NickName = nickname,Password = password,Token = token,Avatar = avatar,FechaUltimoLogin = fechaultimologin,DebeCambiarPassword = debecambiarpassword,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.Usuario
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.Usuario item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.Usuario with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.Usuario {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.Usuario> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Usuario
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class UsuarioFuncion : DataHandler
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
         protected List<Entities.Tables.Seguridad.UsuarioFuncion> _entities = new List<Entities.Tables.Seguridad.UsuarioFuncion>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public UsuarioFuncion() : base()
            {
                base._dataItem = new Entities.Tables.Seguridad.UsuarioFuncion();
            }
            public UsuarioFuncion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Seguridad.UsuarioFuncion();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Seguridad.UsuarioFuncion item)
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
         /// <param name='Usuario_Id'></param>
         /// <param name='Funcion_Id'></param>
         /// <param name='FechaDesde'></param>
         /// <param name='FechaHasta'></param>
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Seguridad.UsuarioFuncion</returns>
			public Entities.Tables.Seguridad.UsuarioFuncion Add(Int64 Usuario_Id,Int64 Funcion_Id,DateTime FechaDesde,DateTime FechaHasta,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Seguridad.UsuarioFuncion)base.Add(new Entities.Tables.Seguridad.UsuarioFuncion(Usuario_Id,Funcion_Id,FechaDesde,FechaHasta,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Seguridad.UsuarioFuncion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Seguridad.UsuarioFuncion>().ToList<Entities.Tables.Seguridad.UsuarioFuncion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Seguridad.UsuarioFuncion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Seguridad.UsuarioFuncion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Seguridad.UsuarioFuncion items with parameters.
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
            public List<Entities.Tables.Seguridad.UsuarioFuncion> Items(Int64? Id,Int64? Usuario_Id,Int64? Funcion_Id,DateTime? FechaDesde,DateTime? FechaHasta,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Usuario_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Usuario_Id, sqlEnum.OperandEnum.Equal, Usuario_Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Usuario_Id, Depositary.sqlEnum.OperandEnum.Equal, Usuario_Id);
                    }
                   
                }
                if (Funcion_Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Funcion_Id, sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Funcion_Id);
                    }
                   
                }
                if (FechaDesde != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaDesde, sqlEnum.OperandEnum.Equal, FechaDesde);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaDesde, Depositary.sqlEnum.OperandEnum.Equal, FechaDesde);
                    }
                   
                }
                if (FechaHasta != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaHasta, sqlEnum.OperandEnum.Equal, FechaHasta);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaHasta, Depositary.sqlEnum.OperandEnum.Equal, FechaHasta);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Seguridad.UsuarioFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.UsuarioFuncion Add(Entities.Tables.Seguridad.UsuarioFuncion item)
            {
                return (Entities.Tables.Seguridad.UsuarioFuncion)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Seguridad.UsuarioFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Seguridad.UsuarioFuncion AddOrUpdate(Entities.Tables.Seguridad.UsuarioFuncion item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Seguridad.UsuarioFuncion)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Seguridad.UsuarioFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Seguridad.UsuarioFuncion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Seguridad.UsuarioFuncion with parameters
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
            public Int64 Update(Int64 id,Int64 usuario_id,Int64 funcion_id,DateTime fechadesde,DateTime fechahasta,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Seguridad.UsuarioFuncion {Id = id,Usuario_Id = usuario_id,Funcion_Id = funcion_id,FechaDesde = fechadesde,FechaHasta = fechahasta,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Seguridad.UsuarioFuncion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Seguridad.UsuarioFuncion item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Seguridad.UsuarioFuncion with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Seguridad.UsuarioFuncion {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Seguridad.UsuarioFuncion> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class UsuarioFuncion
	} //namespace Depositary.Business.Tables.Seguridad
	namespace Depositary.Business.Tables.Sig {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Ciudad : DataHandler
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
         protected List<Entities.Tables.Sig.Ciudad> _entities = new List<Entities.Tables.Sig.Ciudad>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Ciudad() : base()
            {
                base._dataItem = new Entities.Tables.Sig.Ciudad();
            }
            public Ciudad(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Sig.Ciudad();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Sig.Ciudad item)
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
         /// <param name='ProvinciaId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Tables.Sig.Ciudad</returns>
			public Entities.Tables.Sig.Ciudad Add(String Nombre,String Descripcion,Int64 ProvinciaId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Tables.Sig.Ciudad)base.Add(new Entities.Tables.Sig.Ciudad(Nombre,Descripcion,ProvinciaId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Tables.Sig.Ciudad> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Sig.Ciudad>().ToList<Entities.Tables.Sig.Ciudad>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Sig.Ciudad items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sig.Ciudad> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Sig.Ciudad items with parameters.
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
            public List<Entities.Tables.Sig.Ciudad> Items(Int64? Id,String Nombre,String Descripcion,Int64? ProvinciaId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (ProvinciaId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ProvinciaId, sqlEnum.OperandEnum.Equal, ProvinciaId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.ProvinciaId, Depositary.sqlEnum.OperandEnum.Equal, ProvinciaId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Sig.Ciudad
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sig.Ciudad Add(Entities.Tables.Sig.Ciudad item)
            {
                return (Entities.Tables.Sig.Ciudad)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Sig.Ciudad
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sig.Ciudad AddOrUpdate(Entities.Tables.Sig.Ciudad item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Sig.Ciudad)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Sig.Ciudad
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Sig.Ciudad item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Sig.Ciudad with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int64 provinciaid,DateTime fechacreacion,DateTime fechamodificacion,Int64 usuariocreacion,Int64 usuariomodificacion,String codigoexterno,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Sig.Ciudad {Id = id,Nombre = nombre,Descripcion = descripcion,ProvinciaId = provinciaid,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,CodigoExterno = codigoexterno,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Sig.Ciudad
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Sig.Ciudad item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Sig.Ciudad with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Sig.Ciudad {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Sig.Ciudad> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Ciudad
	} //namespace Depositary.Business.Tables.Sig
	namespace Depositary.Business.Tables.Sig {
	    /// <summary>
	    /// 
	    /// </summary>
		public class CodigoPostal : DataHandler
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
         protected List<Entities.Tables.Sig.CodigoPostal> _entities = new List<Entities.Tables.Sig.CodigoPostal>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public CodigoPostal() : base()
            {
                base._dataItem = new Entities.Tables.Sig.CodigoPostal();
            }
            public CodigoPostal(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Sig.CodigoPostal();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Sig.CodigoPostal item)
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
         /// <returns>Entities.Tables.Sig.CodigoPostal</returns>
			public Entities.Tables.Sig.CodigoPostal Add(String Nombre,String Descripcion,Int64 CiudadId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Tables.Sig.CodigoPostal)base.Add(new Entities.Tables.Sig.CodigoPostal(Nombre,Descripcion,CiudadId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Tables.Sig.CodigoPostal> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Sig.CodigoPostal>().ToList<Entities.Tables.Sig.CodigoPostal>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Sig.CodigoPostal items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sig.CodigoPostal> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Sig.CodigoPostal items with parameters.
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
            public List<Entities.Tables.Sig.CodigoPostal> Items(Int64? Id,String Nombre,String Descripcion,Int64? CiudadId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (CiudadId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CiudadId, sqlEnum.OperandEnum.Equal, CiudadId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CiudadId, Depositary.sqlEnum.OperandEnum.Equal, CiudadId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Sig.CodigoPostal
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sig.CodigoPostal Add(Entities.Tables.Sig.CodigoPostal item)
            {
                return (Entities.Tables.Sig.CodigoPostal)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Sig.CodigoPostal
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sig.CodigoPostal AddOrUpdate(Entities.Tables.Sig.CodigoPostal item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Sig.CodigoPostal)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Sig.CodigoPostal
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Sig.CodigoPostal item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Sig.CodigoPostal with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int64 ciudadid,DateTime fechacreacion,DateTime fechamodificacion,Int64 usuariocreacion,Int64 usuariomodificacion,String codigoexterno,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Sig.CodigoPostal {Id = id,Nombre = nombre,Descripcion = descripcion,CiudadId = ciudadid,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,CodigoExterno = codigoexterno,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Sig.CodigoPostal
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Sig.CodigoPostal item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Sig.CodigoPostal with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Sig.CodigoPostal {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Sig.CodigoPostal> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class CodigoPostal
	} //namespace Depositary.Business.Tables.Sig
	namespace Depositary.Business.Tables.Sig {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Pais : DataHandler
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
         protected List<Entities.Tables.Sig.Pais> _entities = new List<Entities.Tables.Sig.Pais>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Pais() : base()
            {
                base._dataItem = new Entities.Tables.Sig.Pais();
            }
            public Pais(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Sig.Pais();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Sig.Pais item)
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
         /// <returns>Entities.Tables.Sig.Pais</returns>
			public Entities.Tables.Sig.Pais Add(String Nombre,String Descripcion,String Codigo,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Tables.Sig.Pais)base.Add(new Entities.Tables.Sig.Pais(Nombre,Descripcion,Codigo,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Tables.Sig.Pais> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Sig.Pais>().ToList<Entities.Tables.Sig.Pais>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Sig.Pais items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sig.Pais> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Sig.Pais items with parameters.
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
            public List<Entities.Tables.Sig.Pais> Items(Int64? Id,String Nombre,String Descripcion,String Codigo,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Sig.Pais
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sig.Pais Add(Entities.Tables.Sig.Pais item)
            {
                return (Entities.Tables.Sig.Pais)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Sig.Pais
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sig.Pais AddOrUpdate(Entities.Tables.Sig.Pais item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Sig.Pais)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Sig.Pais
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Sig.Pais item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Sig.Pais with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,String codigo,DateTime fechacreacion,DateTime fechamodificacion,Int64 usuariocreacion,Int64 usuariomodificacion,String codigoexterno,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Sig.Pais {Id = id,Nombre = nombre,Descripcion = descripcion,Codigo = codigo,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,CodigoExterno = codigoexterno,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Sig.Pais
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Sig.Pais item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Sig.Pais with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Sig.Pais {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Sig.Pais> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Pais
	} //namespace Depositary.Business.Tables.Sig
	namespace Depositary.Business.Tables.Sig {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Provincia : DataHandler
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
         protected List<Entities.Tables.Sig.Provincia> _entities = new List<Entities.Tables.Sig.Provincia>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Provincia() : base()
            {
                base._dataItem = new Entities.Tables.Sig.Provincia();
            }
            public Provincia(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Sig.Provincia();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Sig.Provincia item)
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
         /// <param name='PaisId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='CodigoExterno'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Tables.Sig.Provincia</returns>
			public Entities.Tables.Sig.Provincia Add(String Nombre,String Descripcion,Int64 PaisId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado) 
			{
			  return (Entities.Tables.Sig.Provincia)base.Add(new Entities.Tables.Sig.Provincia(Nombre,Descripcion,PaisId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,CodigoExterno,Habilitado));
			}
            public new List<Entities.Tables.Sig.Provincia> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Sig.Provincia>().ToList<Entities.Tables.Sig.Provincia>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Sig.Provincia items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sig.Provincia> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Sig.Provincia items with parameters.
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
            public List<Entities.Tables.Sig.Provincia> Items(Int64? Id,String Nombre,String Descripcion,Int64? PaisId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,String CodigoExterno,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (PaisId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PaisId, sqlEnum.OperandEnum.Equal, PaisId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, PaisId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (CodigoExterno != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoExterno, sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoExterno, Depositary.sqlEnum.OperandEnum.Equal, CodigoExterno);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Sig.Provincia
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sig.Provincia Add(Entities.Tables.Sig.Provincia item)
            {
                return (Entities.Tables.Sig.Provincia)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Sig.Provincia
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sig.Provincia AddOrUpdate(Entities.Tables.Sig.Provincia item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Sig.Provincia)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Sig.Provincia
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Sig.Provincia item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Sig.Provincia with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int64 paisid,DateTime fechacreacion,DateTime fechamodificacion,Int64 usuariocreacion,Int64 usuariomodificacion,String codigoexterno,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Sig.Provincia {Id = id,Nombre = nombre,Descripcion = descripcion,PaisId = paisid,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,CodigoExterno = codigoexterno,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Sig.Provincia
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Sig.Provincia item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Sig.Provincia with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Sig.Provincia {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Sig.Provincia> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Provincia
	} //namespace Depositary.Business.Tables.Sig
	namespace Depositary.Business.Tables.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Configuracion : DataHandler
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
         protected List<Entities.Tables.Sincronizacion.Configuracion> _entities = new List<Entities.Tables.Sincronizacion.Configuracion>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Configuracion() : base()
            {
                base._dataItem = new Entities.Tables.Sincronizacion.Configuracion();
            }
            public Configuracion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Sincronizacion.Configuracion();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Sincronizacion.Configuracion item)
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
         /// <returns>Entities.Tables.Sincronizacion.Configuracion</returns>
			public Entities.Tables.Sincronizacion.Configuracion Add(Int64 EntidadId,Int64 Segundos,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Sincronizacion.Configuracion)base.Add(new Entities.Tables.Sincronizacion.Configuracion(EntidadId,Segundos,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Sincronizacion.Configuracion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Sincronizacion.Configuracion>().ToList<Entities.Tables.Sincronizacion.Configuracion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Sincronizacion.Configuracion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sincronizacion.Configuracion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Sincronizacion.Configuracion items with parameters.
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
            public List<Entities.Tables.Sincronizacion.Configuracion> Items(Int64? Id,Int64? EntidadId,Int64? Segundos,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (EntidadId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EntidadId, sqlEnum.OperandEnum.Equal, EntidadId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EntidadId, Depositary.sqlEnum.OperandEnum.Equal, EntidadId);
                    }
                   
                }
                if (Segundos != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Segundos, sqlEnum.OperandEnum.Equal, Segundos);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Segundos, Depositary.sqlEnum.OperandEnum.Equal, Segundos);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Sincronizacion.Configuracion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sincronizacion.Configuracion Add(Entities.Tables.Sincronizacion.Configuracion item)
            {
                return (Entities.Tables.Sincronizacion.Configuracion)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Sincronizacion.Configuracion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sincronizacion.Configuracion AddOrUpdate(Entities.Tables.Sincronizacion.Configuracion item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Sincronizacion.Configuracion)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Sincronizacion.Configuracion
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Sincronizacion.Configuracion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Sincronizacion.Configuracion with parameters
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
            public Int64 Update(Int64 id,Int64 entidadid,Int64 segundos,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Sincronizacion.Configuracion {Id = id,EntidadId = entidadid,Segundos = segundos,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Sincronizacion.Configuracion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Sincronizacion.Configuracion item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Sincronizacion.Configuracion with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Sincronizacion.Configuracion {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Sincronizacion.Configuracion> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Configuracion
	} //namespace Depositary.Business.Tables.Sincronizacion
	namespace Depositary.Business.Tables.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Entidad : DataHandler
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
         protected List<Entities.Tables.Sincronizacion.Entidad> _entities = new List<Entities.Tables.Sincronizacion.Entidad>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Entidad() : base()
            {
                base._dataItem = new Entities.Tables.Sincronizacion.Entidad();
            }
            public Entidad(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Sincronizacion.Entidad();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Sincronizacion.Entidad item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Sincronizacion.Entidad</returns>
			public Entities.Tables.Sincronizacion.Entidad Add(String Nombre,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Sincronizacion.Entidad)base.Add(new Entities.Tables.Sincronizacion.Entidad(Nombre,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Sincronizacion.Entidad> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Sincronizacion.Entidad>().ToList<Entities.Tables.Sincronizacion.Entidad>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Sincronizacion.Entidad items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sincronizacion.Entidad> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Sincronizacion.Entidad items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sincronizacion.Entidad> Items(Int64? Id,String Nombre,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Sincronizacion.Entidad
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sincronizacion.Entidad Add(Entities.Tables.Sincronizacion.Entidad item)
            {
                return (Entities.Tables.Sincronizacion.Entidad)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Sincronizacion.Entidad
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sincronizacion.Entidad AddOrUpdate(Entities.Tables.Sincronizacion.Entidad item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Sincronizacion.Entidad)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Sincronizacion.Entidad
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Sincronizacion.Entidad item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Sincronizacion.Entidad with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="EstadoLogico"></param>
            /// <param name="UsuarioCreacion"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="UsuarioModificacion"></param>
            /// <param name="FechaModificacion"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,String nombre,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Sincronizacion.Entidad {Id = id,Nombre = nombre,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Sincronizacion.Entidad
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Sincronizacion.Entidad item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Sincronizacion.Entidad with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Sincronizacion.Entidad {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Sincronizacion.Entidad> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Entidad
	} //namespace Depositary.Business.Tables.Sincronizacion
	namespace Depositary.Business.Tables.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class EntidadCabecera : DataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					EntidadId,
					Valor,
					Fechainicio,
					Fechafin
				}
         protected List<Entities.Tables.Sincronizacion.EntidadCabecera> _entities = new List<Entities.Tables.Sincronizacion.EntidadCabecera>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public EntidadCabecera() : base()
            {
                base._dataItem = new Entities.Tables.Sincronizacion.EntidadCabecera();
            }
            public EntidadCabecera(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Sincronizacion.EntidadCabecera();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Sincronizacion.EntidadCabecera item)
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
         /// <returns>Entities.Tables.Sincronizacion.EntidadCabecera</returns>
			public Entities.Tables.Sincronizacion.EntidadCabecera Add(Int64 EntidadId,String Valor,DateTime Fechainicio,DateTime? Fechafin) 
			{
			  return (Entities.Tables.Sincronizacion.EntidadCabecera)base.Add(new Entities.Tables.Sincronizacion.EntidadCabecera(EntidadId,Valor,Fechainicio,Fechafin));
			}
            public new List<Entities.Tables.Sincronizacion.EntidadCabecera> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Sincronizacion.EntidadCabecera>().ToList<Entities.Tables.Sincronizacion.EntidadCabecera>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Sincronizacion.EntidadCabecera items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sincronizacion.EntidadCabecera> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Sincronizacion.EntidadCabecera items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadId"></param>
            /// <param name="Valor"></param>
            /// <param name="Fechainicio"></param>
            /// <param name="Fechafin"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sincronizacion.EntidadCabecera> Items(Int64? Id,Int64? EntidadId,String Valor,DateTime? Fechainicio,DateTime? Fechafin)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (EntidadId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EntidadId, sqlEnum.OperandEnum.Equal, EntidadId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EntidadId, Depositary.sqlEnum.OperandEnum.Equal, EntidadId);
                    }
                   
                }
                if (Valor != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor, sqlEnum.OperandEnum.Equal, Valor);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                   
                }
                if (Fechainicio != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fechainicio, sqlEnum.OperandEnum.Equal, Fechainicio);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Fechainicio, Depositary.sqlEnum.OperandEnum.Equal, Fechainicio);
                    }
                   
                }
                if (Fechafin != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fechafin, sqlEnum.OperandEnum.Equal, Fechafin);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Fechafin, Depositary.sqlEnum.OperandEnum.Equal, Fechafin);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Sincronizacion.EntidadCabecera
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sincronizacion.EntidadCabecera Add(Entities.Tables.Sincronizacion.EntidadCabecera item)
            {
                return (Entities.Tables.Sincronizacion.EntidadCabecera)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Sincronizacion.EntidadCabecera
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sincronizacion.EntidadCabecera AddOrUpdate(Entities.Tables.Sincronizacion.EntidadCabecera item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Sincronizacion.EntidadCabecera)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Sincronizacion.EntidadCabecera
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Sincronizacion.EntidadCabecera item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Sincronizacion.EntidadCabecera with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadId"></param>
            /// <param name="Valor"></param>
            /// <param name="Fechainicio"></param>
            /// <param name="Fechafin"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,Int64 entidadid,String valor,DateTime fechainicio,DateTime? fechafin)
            {
                return base.Update((IDataItem) new Entities.Tables.Sincronizacion.EntidadCabecera {Id = id,EntidadId = entidadid,Valor = valor,Fechainicio = fechainicio,Fechafin = fechafin});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Sincronizacion.EntidadCabecera
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Sincronizacion.EntidadCabecera item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Sincronizacion.EntidadCabecera with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Sincronizacion.EntidadCabecera {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Sincronizacion.EntidadCabecera> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class EntidadCabecera
	} //namespace Depositary.Business.Tables.Sincronizacion
	namespace Depositary.Business.Tables.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class EntidadDetalle : DataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					EntidadCabeceraId,
					FechaCreacion,
					Valor
				}
         protected List<Entities.Tables.Sincronizacion.EntidadDetalle> _entities = new List<Entities.Tables.Sincronizacion.EntidadDetalle>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public EntidadDetalle() : base()
            {
                base._dataItem = new Entities.Tables.Sincronizacion.EntidadDetalle();
            }
            public EntidadDetalle(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Sincronizacion.EntidadDetalle();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Sincronizacion.EntidadDetalle item)
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
         /// <returns>Entities.Tables.Sincronizacion.EntidadDetalle</returns>
			public Entities.Tables.Sincronizacion.EntidadDetalle Add(Int64 EntidadCabeceraId,DateTime FechaCreacion,String Valor) 
			{
			  return (Entities.Tables.Sincronizacion.EntidadDetalle)base.Add(new Entities.Tables.Sincronizacion.EntidadDetalle(EntidadCabeceraId,FechaCreacion,Valor));
			}
            public new List<Entities.Tables.Sincronizacion.EntidadDetalle> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Sincronizacion.EntidadDetalle>().ToList<Entities.Tables.Sincronizacion.EntidadDetalle>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Sincronizacion.EntidadDetalle items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sincronizacion.EntidadDetalle> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Sincronizacion.EntidadDetalle items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadCabeceraId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="Valor"></param>
            /// <returns></returns>
            public List<Entities.Tables.Sincronizacion.EntidadDetalle> Items(Int64? Id,Int64? EntidadCabeceraId,DateTime? FechaCreacion,String Valor)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (EntidadCabeceraId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EntidadCabeceraId, sqlEnum.OperandEnum.Equal, EntidadCabeceraId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EntidadCabeceraId, Depositary.sqlEnum.OperandEnum.Equal, EntidadCabeceraId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (Valor != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Valor, sqlEnum.OperandEnum.Equal, Valor);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Valor, Depositary.sqlEnum.OperandEnum.Equal, Valor);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Sincronizacion.EntidadDetalle
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sincronizacion.EntidadDetalle Add(Entities.Tables.Sincronizacion.EntidadDetalle item)
            {
                return (Entities.Tables.Sincronizacion.EntidadDetalle)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Sincronizacion.EntidadDetalle
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Sincronizacion.EntidadDetalle AddOrUpdate(Entities.Tables.Sincronizacion.EntidadDetalle item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Sincronizacion.EntidadDetalle)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Sincronizacion.EntidadDetalle
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Sincronizacion.EntidadDetalle item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Sincronizacion.EntidadDetalle with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="EntidadCabeceraId"></param>
            /// <param name="FechaCreacion"></param>
            /// <param name="Valor"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,Int64 entidadcabeceraid,DateTime fechacreacion,String valor)
            {
                return base.Update((IDataItem) new Entities.Tables.Sincronizacion.EntidadDetalle {Id = id,EntidadCabeceraId = entidadcabeceraid,FechaCreacion = fechacreacion,Valor = valor});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Sincronizacion.EntidadDetalle
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Sincronizacion.EntidadDetalle item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Sincronizacion.EntidadDetalle with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Sincronizacion.EntidadDetalle {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Sincronizacion.EntidadDetalle> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class EntidadDetalle
	} //namespace Depositary.Business.Tables.Sincronizacion
	namespace Depositary.Business.Tables.Valor {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Denominacion : DataHandler
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
         protected List<Entities.Tables.Valor.Denominacion> _entities = new List<Entities.Tables.Valor.Denominacion>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Denominacion() : base()
            {
                base._dataItem = new Entities.Tables.Valor.Denominacion();
            }
            public Denominacion(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Valor.Denominacion();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Valor.Denominacion item)
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
         /// <returns>Entities.Tables.Valor.Denominacion</returns>
			public Entities.Tables.Valor.Denominacion Add(Int64 ValorId,Decimal Unidades,Byte[] Imagen,Int64? CodigoCcTalk,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Valor.Denominacion)base.Add(new Entities.Tables.Valor.Denominacion(ValorId,Unidades,Imagen,CodigoCcTalk,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Valor.Denominacion> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Valor.Denominacion>().ToList<Entities.Tables.Valor.Denominacion>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Valor.Denominacion items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Valor.Denominacion> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Valor.Denominacion items with parameters.
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
            public List<Entities.Tables.Valor.Denominacion> Items(Int64? Id,Int64? ValorId,Decimal? Unidades,Int64? CodigoCcTalk,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (ValorId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ValorId, sqlEnum.OperandEnum.Equal, ValorId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.ValorId, Depositary.sqlEnum.OperandEnum.Equal, ValorId);
                    }
                   
                }
                if (Unidades != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Unidades, sqlEnum.OperandEnum.Equal, Unidades);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Unidades, Depositary.sqlEnum.OperandEnum.Equal, Unidades);
                    }
                   
                }
                if (CodigoCcTalk != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoCcTalk, sqlEnum.OperandEnum.Equal, CodigoCcTalk);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.CodigoCcTalk, Depositary.sqlEnum.OperandEnum.Equal, CodigoCcTalk);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Valor.Denominacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Valor.Denominacion Add(Entities.Tables.Valor.Denominacion item)
            {
                return (Entities.Tables.Valor.Denominacion)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Valor.Denominacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Valor.Denominacion AddOrUpdate(Entities.Tables.Valor.Denominacion item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Valor.Denominacion)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Valor.Denominacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Valor.Denominacion item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Valor.Denominacion with parameters
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
            public Int64 Update(Int64 id,Int64 valorid,Decimal unidades,Byte[] imagen,Int64? codigocctalk,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Valor.Denominacion {Id = id,ValorId = valorid,Unidades = unidades,Imagen = imagen,CodigoCcTalk = codigocctalk,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Valor.Denominacion
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Valor.Denominacion item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Valor.Denominacion with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Valor.Denominacion {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Valor.Denominacion> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Denominacion
	} //namespace Depositary.Business.Tables.Valor
	namespace Depositary.Business.Tables.Valor {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Tipo : DataHandler
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
         protected List<Entities.Tables.Valor.Tipo> _entities = new List<Entities.Tables.Valor.Tipo>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Tipo() : base()
            {
                base._dataItem = new Entities.Tables.Valor.Tipo();
            }
            public Tipo(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Valor.Tipo();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Valor.Tipo item)
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
         /// <param name='EstadoLogico'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <returns>Entities.Tables.Valor.Tipo</returns>
			public Entities.Tables.Valor.Tipo Add(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Valor.Tipo)base.Add(new Entities.Tables.Valor.Tipo(Nombre,Descripcion,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Valor.Tipo> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Valor.Tipo>().ToList<Entities.Tables.Valor.Tipo>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Valor.Tipo items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Valor.Tipo> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Valor.Tipo items with parameters.
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
            public List<Entities.Tables.Valor.Tipo> Items(Int64? Id,String Nombre,String Descripcion,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Valor.Tipo
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Valor.Tipo Add(Entities.Tables.Valor.Tipo item)
            {
                return (Entities.Tables.Valor.Tipo)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Valor.Tipo
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Valor.Tipo AddOrUpdate(Entities.Tables.Valor.Tipo item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Valor.Tipo)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Valor.Tipo
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Valor.Tipo item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Valor.Tipo with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Valor.Tipo {Id = id,Nombre = nombre,Descripcion = descripcion,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Valor.Tipo
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Valor.Tipo item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Valor.Tipo with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Valor.Tipo {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Valor.Tipo> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Tipo
	} //namespace Depositary.Business.Tables.Valor
	namespace Depositary.Business.Tables.Valor {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Valor : DataHandler
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
         protected List<Entities.Tables.Valor.Valor> _entities = new List<Entities.Tables.Valor.Valor>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Valor() : base()
            {
                base._dataItem = new Entities.Tables.Valor.Valor();
            }
            public Valor(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Valor.Valor();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Valor.Valor item)
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
         /// <returns>Entities.Tables.Valor.Valor</returns>
			public Entities.Tables.Valor.Valor Add(Int64 Tipo,Int64 PaisId,String Codigo,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion) 
			{
			  return (Entities.Tables.Valor.Valor)base.Add(new Entities.Tables.Valor.Valor(Tipo,PaisId,Codigo,EstadoLogico,UsuarioCreacion,FechaCreacion,UsuarioModificacion,FechaModificacion));
			}
            public new List<Entities.Tables.Valor.Valor> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Valor.Valor>().ToList<Entities.Tables.Valor.Valor>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Valor.Valor items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Valor.Valor> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Valor.Valor items with parameters.
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
            public List<Entities.Tables.Valor.Valor> Items(Int64? Id,Int64? Tipo,Int64? PaisId,String Codigo,Int16? EstadoLogico,Int64? UsuarioCreacion,DateTime? FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Tipo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Tipo, sqlEnum.OperandEnum.Equal, Tipo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Tipo, Depositary.sqlEnum.OperandEnum.Equal, Tipo);
                    }
                   
                }
                if (PaisId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PaisId, sqlEnum.OperandEnum.Equal, PaisId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, PaisId);
                    }
                   
                }
                if (Codigo != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Codigo, sqlEnum.OperandEnum.Equal, Codigo);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Codigo, Depositary.sqlEnum.OperandEnum.Equal, Codigo);
                    }
                   
                }
                if (EstadoLogico != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EstadoLogico, sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, EstadoLogico);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Valor.Valor
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Valor.Valor Add(Entities.Tables.Valor.Valor item)
            {
                return (Entities.Tables.Valor.Valor)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Valor.Valor
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Valor.Valor AddOrUpdate(Entities.Tables.Valor.Valor item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Valor.Valor)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Valor.Valor
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Valor.Valor item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Valor.Valor with parameters
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
            public Int64 Update(Int64 id,Int64 tipo,Int64 paisid,String codigo,Int16 estadologico,Int64 usuariocreacion,DateTime fechacreacion,Int64 usuariomodificacion,DateTime fechamodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Valor.Valor {Id = id,Tipo = tipo,PaisId = paisid,Codigo = codigo,EstadoLogico = estadologico,UsuarioCreacion = usuariocreacion,FechaCreacion = fechacreacion,UsuarioModificacion = usuariomodificacion,FechaModificacion = fechamodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Valor.Valor
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Valor.Valor item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Valor.Valor with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Valor.Valor {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Valor.Valor> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Valor
	} //namespace Depositary.Business.Tables.Valor
	namespace Depositary.Business.Tables.Visualizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Perfil : DataHandler
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
         protected List<Entities.Tables.Visualizacion.Perfil> _entities = new List<Entities.Tables.Visualizacion.Perfil>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public Perfil() : base()
            {
                base._dataItem = new Entities.Tables.Visualizacion.Perfil();
            }
            public Perfil(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Visualizacion.Perfil();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Visualizacion.Perfil item)
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
         /// <param name='PerfilTipoId'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <param name='Habilitado'></param>
         /// <returns>Entities.Tables.Visualizacion.Perfil</returns>
			public Entities.Tables.Visualizacion.Perfil Add(String Nombre,String Descripcion,Int64 PerfilTipoId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,Boolean Habilitado) 
			{
			  return (Entities.Tables.Visualizacion.Perfil)base.Add(new Entities.Tables.Visualizacion.Perfil(Nombre,Descripcion,PerfilTipoId,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion,Habilitado));
			}
            public new List<Entities.Tables.Visualizacion.Perfil> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Visualizacion.Perfil>().ToList<Entities.Tables.Visualizacion.Perfil>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Visualizacion.Perfil items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Visualizacion.Perfil> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Visualizacion.Perfil items with parameters.
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
            public List<Entities.Tables.Visualizacion.Perfil> Items(Int64? Id,String Nombre,String Descripcion,Int64? PerfilTipoId,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (PerfilTipoId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PerfilTipoId, sqlEnum.OperandEnum.Equal, PerfilTipoId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.PerfilTipoId, Depositary.sqlEnum.OperandEnum.Equal, PerfilTipoId);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Visualizacion.Perfil
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Visualizacion.Perfil Add(Entities.Tables.Visualizacion.Perfil item)
            {
                return (Entities.Tables.Visualizacion.Perfil)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Visualizacion.Perfil
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Visualizacion.Perfil AddOrUpdate(Entities.Tables.Visualizacion.Perfil item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Visualizacion.Perfil)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Visualizacion.Perfil
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Visualizacion.Perfil item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Visualizacion.Perfil with parameters
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
            public Int64 Update(Int64 id,String nombre,String descripcion,Int64 perfiltipoid,DateTime fechacreacion,DateTime fechamodificacion,Int64 usuariocreacion,Int64 usuariomodificacion,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Visualizacion.Perfil {Id = id,Nombre = nombre,Descripcion = descripcion,PerfilTipoId = perfiltipoid,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Visualizacion.Perfil
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Visualizacion.Perfil item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Visualizacion.Perfil with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Visualizacion.Perfil {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Visualizacion.Perfil> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class Perfil
	} //namespace Depositary.Business.Tables.Visualizacion
	namespace Depositary.Business.Tables.Visualizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class PerfilItem : DataHandler
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
         protected List<Entities.Tables.Visualizacion.PerfilItem> _entities = new List<Entities.Tables.Visualizacion.PerfilItem>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public PerfilItem() : base()
            {
                base._dataItem = new Entities.Tables.Visualizacion.PerfilItem();
            }
            public PerfilItem(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Visualizacion.PerfilItem();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Visualizacion.PerfilItem item)
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
         /// <param name='PerfilId'></param>
         /// <param name='IdTablaReferencia'></param>
         /// <param name='Habilitado'></param>
         /// <param name='FechaCreacion'></param>
         /// <param name='FechaModificacion'></param>
         /// <param name='UsuarioCreacion'></param>
         /// <param name='UsuarioModificacion'></param>
         /// <returns>Entities.Tables.Visualizacion.PerfilItem</returns>
			public Entities.Tables.Visualizacion.PerfilItem Add(Int64 Id,Int64 PerfilId,Int64 IdTablaReferencia,Boolean? Habilitado,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion) 
			{
			  return (Entities.Tables.Visualizacion.PerfilItem)base.Add(new Entities.Tables.Visualizacion.PerfilItem(Id,PerfilId,IdTablaReferencia,Habilitado,FechaCreacion,FechaModificacion,UsuarioCreacion,UsuarioModificacion));
			}
            public new List<Entities.Tables.Visualizacion.PerfilItem> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Visualizacion.PerfilItem>().ToList<Entities.Tables.Visualizacion.PerfilItem>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Visualizacion.PerfilItem items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Visualizacion.PerfilItem> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Visualizacion.PerfilItem items with parameters.
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
            public List<Entities.Tables.Visualizacion.PerfilItem> Items(Int64? Id,Int64? PerfilId,Int64? IdTablaReferencia,Boolean? Habilitado,DateTime? FechaCreacion,DateTime? FechaModificacion,Int64? UsuarioCreacion,Int64? UsuarioModificacion)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (PerfilId != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.PerfilId, sqlEnum.OperandEnum.Equal, PerfilId);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.PerfilId, Depositary.sqlEnum.OperandEnum.Equal, PerfilId);
                    }
                   
                }
                if (IdTablaReferencia != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.IdTablaReferencia, sqlEnum.OperandEnum.Equal, IdTablaReferencia);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.IdTablaReferencia, Depositary.sqlEnum.OperandEnum.Equal, IdTablaReferencia);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                if (FechaCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCreacion, sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaCreacion, Depositary.sqlEnum.OperandEnum.Equal, FechaCreacion);
                    }
                   
                }
                if (FechaModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaModificacion, sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.FechaModificacion, Depositary.sqlEnum.OperandEnum.Equal, FechaModificacion);
                    }
                   
                }
                if (UsuarioCreacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCreacion, sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioCreacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioCreacion);
                    }
                   
                }
                if (UsuarioModificacion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioModificacion, sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.UsuarioModificacion, Depositary.sqlEnum.OperandEnum.Equal, UsuarioModificacion);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Visualizacion.PerfilItem
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Visualizacion.PerfilItem Add(Entities.Tables.Visualizacion.PerfilItem item)
            {
                return (Entities.Tables.Visualizacion.PerfilItem)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Visualizacion.PerfilItem
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Visualizacion.PerfilItem AddOrUpdate(Entities.Tables.Visualizacion.PerfilItem item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Visualizacion.PerfilItem)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Visualizacion.PerfilItem
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Visualizacion.PerfilItem item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Visualizacion.PerfilItem with parameters
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
            public Int64 Update(Int64 id,Int64 perfilid,Int64 idtablareferencia,Boolean? habilitado,DateTime? fechacreacion,DateTime? fechamodificacion,Int64? usuariocreacion,Int64? usuariomodificacion)
            {
                return base.Update((IDataItem) new Entities.Tables.Visualizacion.PerfilItem {Id = id,PerfilId = perfilid,IdTablaReferencia = idtablareferencia,Habilitado = habilitado,FechaCreacion = fechacreacion,FechaModificacion = fechamodificacion,UsuarioCreacion = usuariocreacion,UsuarioModificacion = usuariomodificacion});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Visualizacion.PerfilItem
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Visualizacion.PerfilItem item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Visualizacion.PerfilItem with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Visualizacion.PerfilItem {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Visualizacion.PerfilItem> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class PerfilItem
	} //namespace Depositary.Business.Tables.Visualizacion
	namespace Depositary.Business.Tables.Visualizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class PerfilTipo : DataHandler
		{
				public enum ColumnEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EsAdministrador,
					Habilitado
				}
         protected List<Entities.Tables.Visualizacion.PerfilTipo> _entities = new List<Entities.Tables.Visualizacion.PerfilTipo>();
         protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where = new WhereCollection();
         public OrderByCollection OrderBy = new OrderByCollection();
         public GroupByCollection GroupBy = new GroupByCollection();
         public AggregateCollection Aggregate { get; set; }
            public PerfilTipo() : base()
            {
                base._dataItem = new Entities.Tables.Visualizacion.PerfilTipo();
            }
            public PerfilTipo(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Tables.Visualizacion.PerfilTipo();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Tables.Visualizacion.PerfilTipo item)
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
         /// <returns>Entities.Tables.Visualizacion.PerfilTipo</returns>
			public Entities.Tables.Visualizacion.PerfilTipo Add(String Nombre,String Descripcion,Boolean EsAdministrador,Boolean Habilitado) 
			{
			  return (Entities.Tables.Visualizacion.PerfilTipo)base.Add(new Entities.Tables.Visualizacion.PerfilTipo(Nombre,Descripcion,EsAdministrador,Habilitado));
			}
            public new List<Entities.Tables.Visualizacion.PerfilTipo> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                _entities = dh.Items().Cast<Entities.Tables.Visualizacion.PerfilTipo>().ToList<Entities.Tables.Visualizacion.PerfilTipo>();
                return _entities;
            }
            /// <summary>
            /// Gets Entities.Tables.Visualizacion.PerfilTipo items by Pk
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            public List<Entities.Tables.Visualizacion.PerfilTipo> Items(Int64 Id)
            {
                this.Where.Clear();
                    if (this.Where.Count == 0)
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
            /// Gets Entities.Tables.Visualizacion.PerfilTipo items with parameters.
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EsAdministrador"></param>
            /// <param name="Habilitado"></param>
            /// <returns></returns>
            public List<Entities.Tables.Visualizacion.PerfilTipo> Items(Int64? Id,String Nombre,String Descripcion,Boolean? EsAdministrador,Boolean? Habilitado)
            {
                this.Where.Clear();
                if (Id != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (Nombre != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Nombre, Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Descripcion != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Descripcion, sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Descripcion, Depositary.sqlEnum.OperandEnum.Equal, Descripcion);
                    }
                   
                }
                if (EsAdministrador != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EsAdministrador, sqlEnum.OperandEnum.Equal, EsAdministrador);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.EsAdministrador, Depositary.sqlEnum.OperandEnum.Equal, EsAdministrador);
                    }
                   
                }
                if (Habilitado != null)
                {
                    if (this.Where.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Habilitado, sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                    else
                    {
                        this.Where.Add(sqlEnum.ConjunctionEnum.AND,ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, Habilitado);
                    }
                   
                }
                return this.Items();
            }
            /// <summary>
            /// Adds an instance of Entities.Tables.Visualizacion.PerfilTipo
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Visualizacion.PerfilTipo Add(Entities.Tables.Visualizacion.PerfilTipo item)
            {
                return (Entities.Tables.Visualizacion.PerfilTipo)base.Add((IDataItem)item);
            }
            /// <summary>
            /// Adds or updates an instance of Entities.Tables.Visualizacion.PerfilTipo
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Entities.Tables.Visualizacion.PerfilTipo AddOrUpdate(Entities.Tables.Visualizacion.PerfilTipo item)
            {
                 if (Items(item.Id).Count == 0)
                 {
                     return (Entities.Tables.Visualizacion.PerfilTipo)base.Add((IDataItem)item);
                 }
                 else
                 {
                     Update(item);
                     return item;
                 }
             }
            /// <summary>
            /// Updates an instance of Entities.Tables.Visualizacion.PerfilTipo
            /// </summary>
            /// <param name="item"></param>
            /// <returns><Int64/returns>
            public Int64 Update(Entities.Tables.Visualizacion.PerfilTipo item)
            {
                return base.Update((IDataItem)item);
            }
            /// Updates an instance of Entities.Tables.Visualizacion.PerfilTipo with parameters
            /// </summary>
            /// <param name="Id"></param>
            /// <param name="Nombre"></param>
            /// <param name="Descripcion"></param>
            /// <param name="EsAdministrador"></param>
            /// <param name="Habilitado"></param>
            /// <returns>Int64</returns>
            public Int64 Update(Int64 id,String nombre,String descripcion,Boolean esadministrador,Boolean habilitado)
            {
                return base.Update((IDataItem) new Entities.Tables.Visualizacion.PerfilTipo {Id = id,Nombre = nombre,Descripcion = descripcion,EsAdministrador = esadministrador,Habilitado = habilitado});
            }
            /// <summary>
            /// Deletes an instance of Entities.Tables.Visualizacion.PerfilTipo
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public Int64 Delete(Entities.Tables.Visualizacion.PerfilTipo item)
            {
                return base.DeleteItem((IDataItem)item);
            }
            /// <summary>
            /// Deletes Entities.Tables.Visualizacion.PerfilTipo with where conditions
            /// </summary>
            /// <returns></returns>
            public new Int64 Delete()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where;
                dh.OrderByParameter = this.OrderBy;
                dh.GroupByParameter = this.GroupBy;
                return dh.Delete();
            }
            /// <summary>
            /// Deletes by Pks
            /// </summary>
            /// <returns></returns>
            public Int64 Delete(Int64 id)
            {
                return base.DeleteItem((IDataItem) new Entities.Tables.Visualizacion.PerfilTipo {Id = id});
            }
            /// <summary>
            /// Holds last Items() executed.
            /// </summary>
            /// <returns>Last Items()</returns>
            public List<Entities.Tables.Visualizacion.PerfilTipo> Result
            {
                get{return _entities;}
            }
            public class WhereCollection : WhereParameter {
                 public void Add(ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     base.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public new void Clear()
                 {
                     base.Clear();
                 }
                 public new long Count
                 {
                     get {
                         return base.Count;
                     }
                 }
            }
            public class OrderByCollection : OrderByParameter {
                 public void Add(ColumnEnum column, Depositary.sqlEnum.DirEnum direction = Depositary.sqlEnum.DirEnum.ASC)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column), direction);
                 }
            }
            public class GroupByCollection : GroupByParameter {
                 public void Add(ColumnEnum column)
                 {
                     base.Add(Enum.GetName(typeof(ColumnEnum), column));
                 }
            }
        } // class PerfilTipo
	} //namespace Depositary.Business.Tables.Visualizacion
