using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace DepositaryWebApi.Business.Procedures.Sincronizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerIdDestino : ProcedureDataHandler
		{
         private List<Entities.Procedures.Sincronizacion.ObtenerIdDestino> _result = new List<Entities.Procedures.Sincronizacion.ObtenerIdDestino>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerIdDestino() : base()
            {
                base._dataItem = new Entities.Procedures.Sincronizacion.ObtenerIdDestino();
            }
            public  List<Entities.Procedures.Sincronizacion.ObtenerIdDestino> Items(String EntidadNombre,Int64? OrigenId,Int64? DepositarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Sincronizacion.ObtenerIdDestino> _entities = new List<Entities.Procedures.Sincronizacion.ObtenerIdDestino>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("EntidadNombre", EntidadNombre), new ParameterItemValue("OrigenId", OrigenId), new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Procedures.Sincronizacion.ObtenerIdDestino>().ToList<Entities.Procedures.Sincronizacion.ObtenerIdDestino>();
                return _result;
             }
             public List<Entities.Procedures.Sincronizacion.ObtenerIdDestino> Resultset
             {
                 get { return _result; }
             }
             public void Dispose()
             {
                 _cacheItemList = null;
				
                 base.Dispose(true);
             }
        }// class Sincronizacion
	} // namespace DepositaryWebApi.Business.Procedures.Sincronizacion
