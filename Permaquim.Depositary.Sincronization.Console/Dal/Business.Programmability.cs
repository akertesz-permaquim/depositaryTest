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
	namespace Permaquim.Depositario.Business.Procedures.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerIdOrigen : ProcedureDataHandler
		{
         private List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen> _result = new List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerIdOrigen() : base()
            {
                base._dataItem = new Entities.Procedures.Sincronizacion.ObtenerIdOrigen();
            }
            public  List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen> Items(String EntidadNombre,Int64? DepositarioId,Int64? DestinoId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen> _entities = new List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("EntidadNombre", EntidadNombre), new ParameterItemValue("DepositarioId", DepositarioId), new ParameterItemValue("DestinoId", DestinoId)}).Cast<Entities.Procedures.Sincronizacion.ObtenerIdOrigen>().ToList<Entities.Procedures.Sincronizacion.ObtenerIdOrigen>();
                return _result;
             }
             public List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen> Resultset
             {
                 get { return _result; }
             }
        }// class Sincronizacion
	} // namespace Permaquim.Depositario.Business.Procedures.Sincronizacion
