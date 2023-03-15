using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace Permaquim.Depositario.Business.Procedures.dbo {
	    /// <summary>
	    /// FinalizarPrimeraSincronizacion
	    /// </summary>
		public class FinalizarPrimeraSincronizacion : MappedProcedureDataHandler
		{
         private List<List<IDataItem>> _result = new List<List<IDataItem>>();
         private List<IDataItem> _dataItems = new List<IDataItem>();
         public MappedResult MappedResultSet = new MappedResult();
            public FinalizarPrimeraSincronizacion() : base()
            {
                 _dataItems.Add(new Entities.Procedures.dbo.FinalizarPrimeraSincronizacion.Result());
            }
            public List<List<IDataItem>> Items(Int64? @DepositarioId)
            {
                MappedProcedureDataHandler dh = new MappedProcedureDataHandler((IDataItem)new Entities.Procedures.dbo.FinalizarPrimeraSincronizacion(), _dataItems);
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)});
                 MappedResultSet.Result = _result[0].Cast<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion.Result>().ToList<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion.Result>();
                return _result;
             }
             public List<List<IDataItem>> Resultset
             {
                 get { return _result; }
             }
             public class MappedResult
             {
                 public List<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion.Result> Result= new List<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion.Result>();
             }
        }// class 
     }
		namespace Permaquim.Depositario.Business.Procedures.dbo {
	    /// <summary>
	    /// IniciarPrimeraSincronizacion
	    /// </summary>
		public class IniciarPrimeraSincronizacion : MappedProcedureDataHandler
		{
         private List<List<IDataItem>> _result = new List<List<IDataItem>>();
         private List<IDataItem> _dataItems = new List<IDataItem>();
         public MappedResult MappedResultSet = new MappedResult();
            public IniciarPrimeraSincronizacion() : base()
            {
                 _dataItems.Add(new Entities.Procedures.dbo.IniciarPrimeraSincronizacion.Result());
            }
            public List<List<IDataItem>> Items()
            {
                MappedProcedureDataHandler dh = new MappedProcedureDataHandler((IDataItem)new Entities.Procedures.dbo.IniciarPrimeraSincronizacion(), _dataItems);
                _result = dh.Items(new List<ParameterItemValue> {});
                 MappedResultSet.Result = _result[0].Cast<Entities.Procedures.dbo.IniciarPrimeraSincronizacion.Result>().ToList<Entities.Procedures.dbo.IniciarPrimeraSincronizacion.Result>();
                return _result;
             }
             public List<List<IDataItem>> Resultset
             {
                 get { return _result; }
             }
             public class MappedResult
             {
                 public List<Entities.Procedures.dbo.IniciarPrimeraSincronizacion.Result> Result= new List<Entities.Procedures.dbo.IniciarPrimeraSincronizacion.Result>();
             }
        }// class 
     }
