using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace Permaquim.Depositary.Business.Views.Operacion {
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
                 public void Add(Permaquim.Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
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
                        this.Where.Add(ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TipoId);
                    }
                   
                }
                if (DepositarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (UsuarioCuentaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioCuentaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioCuentaId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioCuentaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioCuentaId);
                    }
                   
                }
                if (ContenedorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                   
                }
                if (SesionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SesionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SesionId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SesionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SesionId);
                    }
                   
                }
                if (TurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                   
                }
                if (CierreDiarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CierreDiarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CierreDiarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CierreDiarioId);
                    }
                   
                }
                if (Id != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Id, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Id, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                    }
                   
                }
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (DenominacionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DenominacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DenominacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DenominacionId);
                    }
                   
                }
                if (CantidadUnidades != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadUnidades, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadUnidades);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadUnidades, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadUnidades);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fecha, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Fecha);
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
                 public void Add(ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction)
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
                 public void Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.DirEnum direction = Permaquim.Depositary.sqlEnum.DirEnum.ASC)
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
	} //namespace Permaquim.Depositary.Business.Views.Operacion
	namespace Permaquim.Depositary.Business.Views.Reporte {
	    /// <summary>
	    /// 
	    /// </summary>
		public class CierresDiarios : DataHandler
		{
				public enum ColumnEnum : int
                {
					CierreDiarioId,
					DepositarioId,
					SectorId,
					SucursalId,
					EmpresaId,
					UsuarioId,
					Usuario,
					Fecha,
					CierreDiario,
					Empresa,
					Sucursal,
					Sector,
					TurnoId,
					Turno,
					Depositario,
					CantidadTransacciones,
					TotalValidado,
					TotalAValidar,
					Moneda,
					CodigoCierreDiario
				}
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where { get; set; }
         public OrderByCollection OrderBy { get; set; }
         public GroupByCollection GroupBy { get; set; }
         public AggregateCollection Aggregate { get; set; }
            public CierresDiarios() : base()
            {
                base._dataItem = new Entities.Views.Reporte.CierresDiarios();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public CierresDiarios(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Reporte.CierresDiarios();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Permaquim.Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Reporte.CierresDiarios item)
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
			public Entities.Views.Reporte.CierresDiarios Add(Int64 CierreDiarioId,Int64 DepositarioId,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 UsuarioId,String Usuario,DateTime Fecha,String CierreDiario,String Empresa,String Sucursal,String Sector,Int64 TurnoId,String Turno,String Depositario,Int32 CantidadTransacciones,Double TotalValidado,Double TotalAValidar,String Moneda,String CodigoCierreDiario) 
			{
			  return (Entities.Views.Reporte.CierresDiarios)base.Add(new Entities.Views.Reporte.CierresDiarios(CierreDiarioId,DepositarioId,SectorId,SucursalId,EmpresaId,UsuarioId,Usuario,Fecha,CierreDiario,Empresa,Sucursal,Sector,TurnoId,Turno,Depositario,CantidadTransacciones,TotalValidado,TotalAValidar,Moneda,CodigoCierreDiario));
			}
            public new List<Entities.Views.Reporte.CierresDiarios> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderBy.orderByParameter;
                dh.GroupByParameter = this.GroupBy.groupByParameter;
                List<Entities.Views.Reporte.CierresDiarios> _entities = new List<Entities.Views.Reporte.CierresDiarios>();
                _entities = dh.Items().Cast<Entities.Views.Reporte.CierresDiarios>().ToList<Entities.Views.Reporte.CierresDiarios>();
                return _entities;
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="CierreDiarioId"></param>
            /// <param name="DepositarioId"></param>
            /// <param name="SectorId"></param>
            /// <param name="SucursalId"></param>
            /// <param name="EmpresaId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="Usuario"></param>
            /// <param name="Fecha"></param>
            /// <param name="CierreDiario"></param>
            /// <param name="Empresa"></param>
            /// <param name="Sucursal"></param>
            /// <param name="Sector"></param>
            /// <param name="TurnoId"></param>
            /// <param name="Turno"></param>
            /// <param name="Depositario"></param>
            /// <param name="CantidadTransacciones"></param>
            /// <param name="TotalValidado"></param>
            /// <param name="TotalAValidar"></param>
            /// <param name="Moneda"></param>
            /// <param name="CodigoCierreDiario"></param>
            /// <returns></returns>
            public List<Entities.Views.Reporte.CierresDiarios> Items(Int64? CierreDiarioId,Int64? DepositarioId,Int64? SectorId,Int64? SucursalId,Int64? EmpresaId,Int64? UsuarioId,String Usuario,DateTime? Fecha,String CierreDiario,String Empresa,String Sucursal,String Sector,Int64? TurnoId,String Turno,String Depositario,Int32? CantidadTransacciones,Double? TotalValidado,Double? TotalAValidar,String Moneda,String CodigoCierreDiario)
            {
                this.Where.whereParameter.Clear();
                if (CierreDiarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CierreDiarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CierreDiarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CierreDiarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CierreDiarioId);
                    }
                   
                }
                if (DepositarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                   
                }
                if (SectorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                   
                }
                if (SucursalId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                   
                }
                if (EmpresaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (Usuario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Usuario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Usuario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fecha, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                   
                }
                if (CierreDiario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CierreDiario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CierreDiario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CierreDiario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CierreDiario);
                    }
                   
                }
                if (Empresa != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                   
                }
                if (Sucursal != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                   
                }
                if (Sector != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                   
                }
                if (TurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                   
                }
                if (Turno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                   
                }
                if (Depositario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                   
                }
                if (CantidadTransacciones != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadTransacciones, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadTransacciones);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadTransacciones, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadTransacciones);
                    }
                   
                }
                if (TotalValidado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TotalValidado, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalValidado);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TotalValidado, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalValidado);
                    }
                   
                }
                if (TotalAValidar != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TotalAValidar, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalAValidar);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TotalAValidar, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalAValidar);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                   
                }
                if (CodigoCierreDiario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoCierreDiario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoCierreDiario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoCierreDiario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoCierreDiario);
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
                 public void Add(ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction)
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
                 public void Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.DirEnum direction = Permaquim.Depositary.sqlEnum.DirEnum.ASC)
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
        } // class CierresDiarios
	} //namespace Permaquim.Depositary.Business.Views.Reporte
	namespace Permaquim.Depositary.Business.Views.Reporte {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Contenedores : DataHandler
		{
				public enum ColumnEnum : int
                {
					ContenedorId,
					Identificador,
					FechaApertura,
					FechaCierre,
					DepositarioId,
					SectorId,
					SucursalId,
					EmpresaId,
					Empresa,
					Sucursal,
					Sector,
					Depositario,
					CantidadTransacciones,
					CantidadBilletes,
					CantidadSobres,
					CantidadTotalDineroMonedaDefault
				}
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where { get; set; }
         public OrderByCollection OrderBy { get; set; }
         public GroupByCollection GroupBy { get; set; }
         public AggregateCollection Aggregate { get; set; }
            public Contenedores() : base()
            {
                base._dataItem = new Entities.Views.Reporte.Contenedores();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public Contenedores(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Reporte.Contenedores();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Permaquim.Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Reporte.Contenedores item)
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
			public Entities.Views.Reporte.Contenedores Add(Int64 ContenedorId,String Identificador,DateTime FechaApertura,DateTime FechaCierre,Int64 DepositarioId,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,String Empresa,String Sucursal,String Sector,String Depositario,Int32 CantidadTransacciones,Int64 CantidadBilletes,Int32 CantidadSobres,Double CantidadTotalDineroMonedaDefault) 
			{
			  return (Entities.Views.Reporte.Contenedores)base.Add(new Entities.Views.Reporte.Contenedores(ContenedorId,Identificador,FechaApertura,FechaCierre,DepositarioId,SectorId,SucursalId,EmpresaId,Empresa,Sucursal,Sector,Depositario,CantidadTransacciones,CantidadBilletes,CantidadSobres,CantidadTotalDineroMonedaDefault));
			}
            public new List<Entities.Views.Reporte.Contenedores> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderBy.orderByParameter;
                dh.GroupByParameter = this.GroupBy.groupByParameter;
                List<Entities.Views.Reporte.Contenedores> _entities = new List<Entities.Views.Reporte.Contenedores>();
                _entities = dh.Items().Cast<Entities.Views.Reporte.Contenedores>().ToList<Entities.Views.Reporte.Contenedores>();
                return _entities;
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="ContenedorId"></param>
            /// <param name="Identificador"></param>
            /// <param name="FechaApertura"></param>
            /// <param name="FechaCierre"></param>
            /// <param name="DepositarioId"></param>
            /// <param name="SectorId"></param>
            /// <param name="SucursalId"></param>
            /// <param name="EmpresaId"></param>
            /// <param name="Empresa"></param>
            /// <param name="Sucursal"></param>
            /// <param name="Sector"></param>
            /// <param name="Depositario"></param>
            /// <param name="CantidadTransacciones"></param>
            /// <param name="CantidadBilletes"></param>
            /// <param name="CantidadSobres"></param>
            /// <param name="CantidadTotalDineroMonedaDefault"></param>
            /// <returns></returns>
            public List<Entities.Views.Reporte.Contenedores> Items(Int64? ContenedorId,String Identificador,DateTime? FechaApertura,DateTime? FechaCierre,Int64? DepositarioId,Int64? SectorId,Int64? SucursalId,Int64? EmpresaId,String Empresa,String Sucursal,String Sector,String Depositario,Int32? CantidadTransacciones,Int64? CantidadBilletes,Int32? CantidadSobres,Double? CantidadTotalDineroMonedaDefault)
            {
                this.Where.whereParameter.Clear();
                if (ContenedorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                   
                }
                if (Identificador != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Identificador, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Identificador);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Identificador, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Identificador);
                    }
                   
                }
                if (FechaApertura != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaApertura, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaApertura);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaApertura, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaApertura);
                    }
                   
                }
                if (FechaCierre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCierre, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaCierre);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCierre, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaCierre);
                    }
                   
                }
                if (DepositarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                   
                }
                if (SectorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                   
                }
                if (SucursalId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                   
                }
                if (EmpresaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                   
                }
                if (Empresa != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                   
                }
                if (Sucursal != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                   
                }
                if (Sector != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                   
                }
                if (Depositario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                   
                }
                if (CantidadTransacciones != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadTransacciones, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadTransacciones);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadTransacciones, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadTransacciones);
                    }
                   
                }
                if (CantidadBilletes != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadBilletes, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadBilletes);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadBilletes, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadBilletes);
                    }
                   
                }
                if (CantidadSobres != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadSobres, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadSobres);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadSobres, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadSobres);
                    }
                   
                }
                if (CantidadTotalDineroMonedaDefault != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadTotalDineroMonedaDefault, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadTotalDineroMonedaDefault);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadTotalDineroMonedaDefault, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadTotalDineroMonedaDefault);
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
                 public void Add(ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction)
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
                 public void Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.DirEnum direction = Permaquim.Depositary.sqlEnum.DirEnum.ASC)
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
        } // class Contenedores
	} //namespace Permaquim.Depositary.Business.Views.Reporte
	namespace Permaquim.Depositary.Business.Views.Reporte {
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
					SucursalId,
					EmpresaId,
					UsuarioId,
					ContenedorId,
					OrigenId,
					DepositarioId,
					EsquemaDetalleTurnoId,
					Empresa,
					Sucursal,
					Sector,
					Turno,
					Contenedor,
					Usuario,
					Origen,
					Moneda,
					Denominacion,
					CodigoMoneda,
					Depositario,
					Total,
					CodigoOperacion
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
                 public void Add(Permaquim.Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
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
			public Entities.Views.Reporte.DetalleTransacciones Add(Int64 TransaccionId,DateTime FechaTransaccion,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 UsuarioId,Int64 ContenedorId,Int64 OrigenId,Int64 DepositarioId,Int64 EsquemaDetalleTurnoId,String Empresa,String Sucursal,String Sector,String Turno,String Contenedor,String Usuario,String Origen,String Moneda,String Denominacion,String CodigoMoneda,String Depositario,Decimal Total,String CodigoOperacion) 
			{
			  return (Entities.Views.Reporte.DetalleTransacciones)base.Add(new Entities.Views.Reporte.DetalleTransacciones(TransaccionId,FechaTransaccion,SectorId,SucursalId,EmpresaId,UsuarioId,ContenedorId,OrigenId,DepositarioId,EsquemaDetalleTurnoId,Empresa,Sucursal,Sector,Turno,Contenedor,Usuario,Origen,Moneda,Denominacion,CodigoMoneda,Depositario,Total,CodigoOperacion));
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
            /// <param name="SucursalId"></param>
            /// <param name="EmpresaId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="ContenedorId"></param>
            /// <param name="OrigenId"></param>
            /// <param name="DepositarioId"></param>
            /// <param name="EsquemaDetalleTurnoId"></param>
            /// <param name="Empresa"></param>
            /// <param name="Sucursal"></param>
            /// <param name="Sector"></param>
            /// <param name="Turno"></param>
            /// <param name="Contenedor"></param>
            /// <param name="Usuario"></param>
            /// <param name="Origen"></param>
            /// <param name="Moneda"></param>
            /// <param name="Denominacion"></param>
            /// <param name="CodigoMoneda"></param>
            /// <param name="Depositario"></param>
            /// <param name="Total"></param>
            /// <param name="CodigoOperacion"></param>
            /// <returns></returns>
            public List<Entities.Views.Reporte.DetalleTransacciones> Items(Int64? TransaccionId,DateTime? FechaTransaccion,Int64? SectorId,Int64? SucursalId,Int64? EmpresaId,Int64? UsuarioId,Int64? ContenedorId,Int64? OrigenId,Int64? DepositarioId,Int64? EsquemaDetalleTurnoId,String Empresa,String Sucursal,String Sector,String Turno,String Contenedor,String Usuario,String Origen,String Moneda,String Denominacion,String CodigoMoneda,String Depositario,Decimal? Total,String CodigoOperacion)
            {
                this.Where.whereParameter.Clear();
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (FechaTransaccion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaTransaccion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaTransaccion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                   
                }
                if (SectorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                   
                }
                if (SucursalId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                   
                }
                if (EmpresaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (ContenedorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                   
                }
                if (OrigenId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OrigenId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, OrigenId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OrigenId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, OrigenId);
                    }
                   
                }
                if (DepositarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                   
                }
                if (EsquemaDetalleTurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EsquemaDetalleTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EsquemaDetalleTurnoId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EsquemaDetalleTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EsquemaDetalleTurnoId);
                    }
                   
                }
                if (Empresa != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                   
                }
                if (Sucursal != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                   
                }
                if (Sector != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                   
                }
                if (Turno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                   
                }
                if (Contenedor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Contenedor, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Contenedor);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Contenedor, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Contenedor);
                    }
                   
                }
                if (Usuario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Usuario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Usuario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                   
                }
                if (Origen != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Origen, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Origen);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Origen, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Origen);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                   
                }
                if (Denominacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Denominacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Denominacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                   
                }
                if (CodigoMoneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoMoneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoMoneda);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoMoneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoMoneda);
                    }
                   
                }
                if (Depositario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                   
                }
                if (Total != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Total, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Total);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Total, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Total);
                    }
                   
                }
                if (CodigoOperacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoOperacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoOperacion);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoOperacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoOperacion);
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
                 public void Add(ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction)
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
                 public void Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.DirEnum direction = Permaquim.Depositary.sqlEnum.DirEnum.ASC)
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
	} //namespace Permaquim.Depositary.Business.Views.Reporte
	namespace Permaquim.Depositary.Business.Views.Reporte {
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
					Cantidad,
					TipoValor,
					SectorId,
					SucursalId,
					EmpresaId,
					UsuarioId,
					ContenedorId,
					OrigenId,
					DepositarioId,
					EsquemaDetalleTurnoId,
					Empresa,
					Sucursal,
					Sector,
					Turno,
					Contenedor,
					Usuario,
					Origen,
					Depositario,
					CodigoOperacion,
					Moneda
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
                 public void Add(Permaquim.Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
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
			public Entities.Views.Reporte.DetalleTransaccionesSobre Add(Int64 TransaccionId,DateTime FechaTransaccion,String CodigoSobre,Int64 Cantidad,String TipoValor,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 UsuarioId,Int64 ContenedorId,Int64 OrigenId,Int64 DepositarioId,Int64 EsquemaDetalleTurnoId,String Empresa,String Sucursal,String Sector,String Turno,String Contenedor,String Usuario,String Origen,String Depositario,String CodigoOperacion,String Moneda) 
			{
			  return (Entities.Views.Reporte.DetalleTransaccionesSobre)base.Add(new Entities.Views.Reporte.DetalleTransaccionesSobre(TransaccionId,FechaTransaccion,CodigoSobre,Cantidad,TipoValor,SectorId,SucursalId,EmpresaId,UsuarioId,ContenedorId,OrigenId,DepositarioId,EsquemaDetalleTurnoId,Empresa,Sucursal,Sector,Turno,Contenedor,Usuario,Origen,Depositario,CodigoOperacion,Moneda));
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
            /// <param name="Cantidad"></param>
            /// <param name="TipoValor"></param>
            /// <param name="SectorId"></param>
            /// <param name="SucursalId"></param>
            /// <param name="EmpresaId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="ContenedorId"></param>
            /// <param name="OrigenId"></param>
            /// <param name="DepositarioId"></param>
            /// <param name="EsquemaDetalleTurnoId"></param>
            /// <param name="Empresa"></param>
            /// <param name="Sucursal"></param>
            /// <param name="Sector"></param>
            /// <param name="Turno"></param>
            /// <param name="Contenedor"></param>
            /// <param name="Usuario"></param>
            /// <param name="Origen"></param>
            /// <param name="Depositario"></param>
            /// <param name="CodigoOperacion"></param>
            /// <param name="Moneda"></param>
            /// <returns></returns>
            public List<Entities.Views.Reporte.DetalleTransaccionesSobre> Items(Int64? TransaccionId,DateTime? FechaTransaccion,String CodigoSobre,Int64? Cantidad,String TipoValor,Int64? SectorId,Int64? SucursalId,Int64? EmpresaId,Int64? UsuarioId,Int64? ContenedorId,Int64? OrigenId,Int64? DepositarioId,Int64? EsquemaDetalleTurnoId,String Empresa,String Sucursal,String Sector,String Turno,String Contenedor,String Usuario,String Origen,String Depositario,String CodigoOperacion,String Moneda)
            {
                this.Where.whereParameter.Clear();
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (FechaTransaccion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaTransaccion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaTransaccion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                   
                }
                if (CodigoSobre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoSobre, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoSobre);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoSobre, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoSobre);
                    }
                   
                }
                if (Cantidad != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Cantidad, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Cantidad);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Cantidad, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Cantidad);
                    }
                   
                }
                if (TipoValor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TipoValor, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TipoValor);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TipoValor, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TipoValor);
                    }
                   
                }
                if (SectorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                   
                }
                if (SucursalId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                   
                }
                if (EmpresaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (ContenedorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                   
                }
                if (OrigenId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OrigenId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, OrigenId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OrigenId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, OrigenId);
                    }
                   
                }
                if (DepositarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                   
                }
                if (EsquemaDetalleTurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EsquemaDetalleTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EsquemaDetalleTurnoId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EsquemaDetalleTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EsquemaDetalleTurnoId);
                    }
                   
                }
                if (Empresa != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                   
                }
                if (Sucursal != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                   
                }
                if (Sector != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                   
                }
                if (Turno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                   
                }
                if (Contenedor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Contenedor, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Contenedor);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Contenedor, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Contenedor);
                    }
                   
                }
                if (Usuario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Usuario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Usuario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                   
                }
                if (Origen != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Origen, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Origen);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Origen, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Origen);
                    }
                   
                }
                if (Depositario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                   
                }
                if (CodigoOperacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoOperacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoOperacion);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoOperacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoOperacion);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
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
                 public void Add(ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction)
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
                 public void Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.DirEnum direction = Permaquim.Depositary.sqlEnum.DirEnum.ASC)
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
	} //namespace Permaquim.Depositary.Business.Views.Reporte
	namespace Permaquim.Depositary.Business.Views.Reporte {
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
					Turno,
					Depositario,
					Contenedor,
					ContenedorId,
					EsquemaDetalleTurnoId,
					SectorId,
					SucursalId,
					EmpresaId,
					UsuarioId,
					DepositarioId,
					OrigenId,
					Origen,
					CodigoOperacion
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
                 public void Add(Permaquim.Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
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
			public Entities.Views.Reporte.Transacciones Add(Int64 TransaccionId,Int64 TransaccionTipoId,String TransaccionTipo,String Usuario,DateTime FechaTransaccion,DateTime FechaRetiroBolsa,String Moneda,Double TotalValidado,Double TotalAValidar,String Empresa,String Sucursal,String Sector,String Turno,String Depositario,String Contenedor,Int64 ContenedorId,Int64 EsquemaDetalleTurnoId,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 UsuarioId,Int64 DepositarioId,Int64 OrigenId,String Origen,String CodigoOperacion) 
			{
			  return (Entities.Views.Reporte.Transacciones)base.Add(new Entities.Views.Reporte.Transacciones(TransaccionId,TransaccionTipoId,TransaccionTipo,Usuario,FechaTransaccion,FechaRetiroBolsa,Moneda,TotalValidado,TotalAValidar,Empresa,Sucursal,Sector,Turno,Depositario,Contenedor,ContenedorId,EsquemaDetalleTurnoId,SectorId,SucursalId,EmpresaId,UsuarioId,DepositarioId,OrigenId,Origen,CodigoOperacion));
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
            /// <param name="Turno"></param>
            /// <param name="Depositario"></param>
            /// <param name="Contenedor"></param>
            /// <param name="ContenedorId"></param>
            /// <param name="EsquemaDetalleTurnoId"></param>
            /// <param name="SectorId"></param>
            /// <param name="SucursalId"></param>
            /// <param name="EmpresaId"></param>
            /// <param name="UsuarioId"></param>
            /// <param name="DepositarioId"></param>
            /// <param name="OrigenId"></param>
            /// <param name="Origen"></param>
            /// <param name="CodigoOperacion"></param>
            /// <returns></returns>
            public List<Entities.Views.Reporte.Transacciones> Items(Int64? TransaccionId,Int64? TransaccionTipoId,String TransaccionTipo,String Usuario,DateTime? FechaTransaccion,DateTime? FechaRetiroBolsa,String Moneda,Double? TotalValidado,Double? TotalAValidar,String Empresa,String Sucursal,String Sector,String Turno,String Depositario,String Contenedor,Int64? ContenedorId,Int64? EsquemaDetalleTurnoId,Int64? SectorId,Int64? SucursalId,Int64? EmpresaId,Int64? UsuarioId,Int64? DepositarioId,Int64? OrigenId,String Origen,String CodigoOperacion)
            {
                this.Where.whereParameter.Clear();
                if (TransaccionId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionId);
                    }
                   
                }
                if (TransaccionTipoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionTipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionTipoId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionTipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionTipoId);
                    }
                   
                }
                if (TransaccionTipo != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TransaccionTipo, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionTipo);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TransaccionTipo, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TransaccionTipo);
                    }
                   
                }
                if (Usuario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Usuario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Usuario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Usuario);
                    }
                   
                }
                if (FechaTransaccion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaTransaccion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaTransaccion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaTransaccion);
                    }
                   
                }
                if (FechaRetiroBolsa != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaRetiroBolsa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaRetiroBolsa);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaRetiroBolsa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaRetiroBolsa);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                   
                }
                if (TotalValidado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TotalValidado, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalValidado);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TotalValidado, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalValidado);
                    }
                   
                }
                if (TotalAValidar != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TotalAValidar, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalAValidar);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TotalAValidar, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalAValidar);
                    }
                   
                }
                if (Empresa != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                   
                }
                if (Sucursal != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                   
                }
                if (Sector != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                   
                }
                if (Turno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                   
                }
                if (Depositario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                   
                }
                if (Contenedor != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Contenedor, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Contenedor);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Contenedor, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Contenedor);
                    }
                   
                }
                if (ContenedorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, ContenedorId);
                    }
                   
                }
                if (EsquemaDetalleTurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EsquemaDetalleTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EsquemaDetalleTurnoId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EsquemaDetalleTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EsquemaDetalleTurnoId);
                    }
                   
                }
                if (SectorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                   
                }
                if (SucursalId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                   
                }
                if (EmpresaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                   
                }
                if (UsuarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, UsuarioId);
                    }
                   
                }
                if (DepositarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                   
                }
                if (OrigenId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.OrigenId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, OrigenId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.OrigenId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, OrigenId);
                    }
                   
                }
                if (Origen != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Origen, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Origen);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Origen, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Origen);
                    }
                   
                }
                if (CodigoOperacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoOperacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoOperacion);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoOperacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoOperacion);
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
                 public void Add(ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction)
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
                 public void Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.DirEnum direction = Permaquim.Depositary.sqlEnum.DirEnum.ASC)
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
	} //namespace Permaquim.Depositary.Business.Views.Reporte
	namespace Permaquim.Depositary.Business.Views.Reporte {
	    /// <summary>
	    /// 
	    /// </summary>
		public class Turnos : DataHandler
		{
				public enum ColumnEnum : int
                {
					TurnoId,
					DepositarioId,
					SectorId,
					SucursalId,
					EmpresaId,
					EsquemaDetalleTurnoId,
					FechaApertura,
					FechaCierre,
					Fecha,
					Secuencia,
					Turno,
					CierreDiario,
					Empresa,
					Sucursal,
					Sector,
					Depositario,
					CantidadTransacciones,
					TotalValidado,
					TotalAValidar,
					Moneda,
					CodigoTurno
				}
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
         public WhereCollection Where { get; set; }
         public OrderByCollection OrderBy { get; set; }
         public GroupByCollection GroupBy { get; set; }
         public AggregateCollection Aggregate { get; set; }
            public Turnos() : base()
            {
                base._dataItem = new Entities.Views.Reporte.Turnos();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public Turnos(IDataHandler dataHandler)
                : base(dataHandler)
            {
                base._transaction = dataHandler.GetTransaction();
                base._dataItem = new Entities.Views.Reporte.Turnos();
                Where = new WhereCollection();
                OrderBy = new OrderByCollection();
                GroupBy = new GroupByCollection();
            }
            public class AggregateCollection : AggregateParameter
            {
                 internal AggregateParameter aggregateParameter = new AggregateParameter();
                 public void Add(Permaquim.Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
                     {
                         this.aggregateParameter.Add(functionEnum, Enum.GetName(typeof(ColumnEnum), column));
                     }
            }
			// Adds to a memory cache to hold pending transactions
			public void AddToCache(Entities.Views.Reporte.Turnos item)
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
			public Entities.Views.Reporte.Turnos Add(Int64 TurnoId,Int64 DepositarioId,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 EsquemaDetalleTurnoId,DateTime FechaApertura,DateTime FechaCierre,DateTime Fecha,Int32 Secuencia,String Turno,String CierreDiario,String Empresa,String Sucursal,String Sector,String Depositario,Int32 CantidadTransacciones,Double TotalValidado,Double TotalAValidar,String Moneda,String CodigoTurno) 
			{
			  return (Entities.Views.Reporte.Turnos)base.Add(new Entities.Views.Reporte.Turnos(TurnoId,DepositarioId,SectorId,SucursalId,EmpresaId,EsquemaDetalleTurnoId,FechaApertura,FechaCierre,Fecha,Secuencia,Turno,CierreDiario,Empresa,Sucursal,Sector,Depositario,CantidadTransacciones,TotalValidado,TotalAValidar,Moneda,CodigoTurno));
			}
            public new List<Entities.Views.Reporte.Turnos> Items()
            {
                DataHandler dh =  new DataHandler(this._dataItem);
                dh.WhereParameter = this.Where.whereParameter;
                dh.OrderByParameter = this.OrderBy.orderByParameter;
                dh.GroupByParameter = this.GroupBy.groupByParameter;
                List<Entities.Views.Reporte.Turnos> _entities = new List<Entities.Views.Reporte.Turnos>();
                _entities = dh.Items().Cast<Entities.Views.Reporte.Turnos>().ToList<Entities.Views.Reporte.Turnos>();
                return _entities;
            }
            /// <summary>
            /// Gets 
            /// </summary>
            /// <param name="TurnoId"></param>
            /// <param name="DepositarioId"></param>
            /// <param name="SectorId"></param>
            /// <param name="SucursalId"></param>
            /// <param name="EmpresaId"></param>
            /// <param name="EsquemaDetalleTurnoId"></param>
            /// <param name="FechaApertura"></param>
            /// <param name="FechaCierre"></param>
            /// <param name="Fecha"></param>
            /// <param name="Secuencia"></param>
            /// <param name="Turno"></param>
            /// <param name="CierreDiario"></param>
            /// <param name="Empresa"></param>
            /// <param name="Sucursal"></param>
            /// <param name="Sector"></param>
            /// <param name="Depositario"></param>
            /// <param name="CantidadTransacciones"></param>
            /// <param name="TotalValidado"></param>
            /// <param name="TotalAValidar"></param>
            /// <param name="Moneda"></param>
            /// <param name="CodigoTurno"></param>
            /// <returns></returns>
            public List<Entities.Views.Reporte.Turnos> Items(Int64? TurnoId,Int64? DepositarioId,Int64? SectorId,Int64? SucursalId,Int64? EmpresaId,Int64? EsquemaDetalleTurnoId,DateTime? FechaApertura,DateTime? FechaCierre,DateTime? Fecha,Int32? Secuencia,String Turno,String CierreDiario,String Empresa,String Sucursal,String Sector,String Depositario,Int32? CantidadTransacciones,Double? TotalValidado,Double? TotalAValidar,String Moneda,String CodigoTurno)
            {
                this.Where.whereParameter.Clear();
                if (TurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TurnoId);
                    }
                   
                }
                if (DepositarioId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, DepositarioId);
                    }
                   
                }
                if (SectorId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SectorId);
                    }
                   
                }
                if (SucursalId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, SucursalId);
                    }
                   
                }
                if (EmpresaId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EmpresaId);
                    }
                   
                }
                if (EsquemaDetalleTurnoId != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.EsquemaDetalleTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EsquemaDetalleTurnoId);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.EsquemaDetalleTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, EsquemaDetalleTurnoId);
                    }
                   
                }
                if (FechaApertura != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaApertura, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaApertura);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaApertura, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaApertura);
                    }
                   
                }
                if (FechaCierre != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.FechaCierre, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaCierre);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.FechaCierre, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, FechaCierre);
                    }
                   
                }
                if (Fecha != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Fecha, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Fecha, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Fecha);
                    }
                   
                }
                if (Secuencia != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Secuencia, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Secuencia);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Secuencia, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Secuencia);
                    }
                   
                }
                if (Turno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Turno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Turno);
                    }
                   
                }
                if (CierreDiario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CierreDiario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CierreDiario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CierreDiario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CierreDiario);
                    }
                   
                }
                if (Empresa != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Empresa, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Empresa);
                    }
                   
                }
                if (Sucursal != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sucursal, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sucursal);
                    }
                   
                }
                if (Sector != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Sector, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Sector);
                    }
                   
                }
                if (Depositario != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Depositario, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Depositario);
                    }
                   
                }
                if (CantidadTransacciones != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CantidadTransacciones, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadTransacciones);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CantidadTransacciones, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CantidadTransacciones);
                    }
                   
                }
                if (TotalValidado != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TotalValidado, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalValidado);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TotalValidado, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalValidado);
                    }
                   
                }
                if (TotalAValidar != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.TotalAValidar, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalAValidar);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.TotalAValidar, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, TotalAValidar);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                   
                }
                if (CodigoTurno != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.CodigoTurno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoTurno);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.CodigoTurno, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, CodigoTurno);
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
                 public void Add(ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction)
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
                 public void Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.DirEnum direction = Permaquim.Depositary.sqlEnum.DirEnum.ASC)
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
        } // class Turnos
	} //namespace Permaquim.Depositary.Business.Views.Reporte
	namespace Permaquim.Depositary.Business.Views.Valor {
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
                 public void Add(Permaquim.Depositary.sqlEnum.FunctionEnum functionEnum, ColumnEnum column)
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
                        this.Where.Add(ColumnEnum.Nombre, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Nombre, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Nombre);
                    }
                   
                }
                if (Moneda != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Moneda, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Moneda);
                    }
                   
                }
                if (Denominacion != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Denominacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Denominacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Denominacion);
                    }
                   
                }
                if (Unidades != null)
                {
                    if (this.Where.whereParameter.Count == 0)
                    {
                        this.Where.Add(ColumnEnum.Unidades, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Unidades);
                    }
                    else
                    {
                        this.Where.Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum.AND, ColumnEnum.Unidades, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Unidades);
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
                 public void Add(ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void  Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand,object value)
                 {
                     this.whereParameter.Add(Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum betweenColumn, Permaquim.Depositary.sqlEnum.OperandEnum operand, object valueFrom, object valueTo)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), betweenColumn), valueFrom, valueTo);
                 }
                 public void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum conjunction,ColumnEnum column, Permaquim.Depositary.sqlEnum.OperandEnum operand, object value)
                 {
                     this.whereParameter.Add(conjunction, Enum.GetName(typeof(ColumnEnum), column), operand, value);
                 }
                 public void AddOperand(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction)
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
                 public void Add(ColumnEnum column, Permaquim.Depositary.sqlEnum.DirEnum direction = Permaquim.Depositary.sqlEnum.DirEnum.ASC)
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
	} //namespace Permaquim.Depositary.Business.Views.Valor
