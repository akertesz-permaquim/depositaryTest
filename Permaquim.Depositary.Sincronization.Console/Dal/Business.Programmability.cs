using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace Permaquim.Depositario.Business.Procedures.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class FinalizarPrimeraSincronizacion : ProcedureDataHandler
		{
         private List<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion> _result = new List<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public FinalizarPrimeraSincronizacion() : base()
            {
                base._dataItem = new Entities.Procedures.dbo.FinalizarPrimeraSincronizacion();
            }
            public  List<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion> Items(Int64? DepositarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion> _entities = new List<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion>().ToList<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion>();
                return _result;
             }
             public List<Entities.Procedures.dbo.FinalizarPrimeraSincronizacion> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace Permaquim.Depositario.Business.Procedures.dbo
