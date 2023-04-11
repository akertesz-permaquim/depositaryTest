using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            public  List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen> Items(String EntidadNombre,Int64? DestinoId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen> _entities = new List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("EntidadNombre", EntidadNombre), new ParameterItemValue("DestinoId", DestinoId)}).Cast<Entities.Procedures.Sincronizacion.ObtenerIdOrigen>().ToList<Entities.Procedures.Sincronizacion.ObtenerIdOrigen>();
                return _result;
             }
             public List<Entities.Procedures.Sincronizacion.ObtenerIdOrigen> Resultset
             {
                 get { return _result; }
             }
             public void Dispose()
             {
                 _cacheItemList = null;
				
                 base.Dispose(true);
             }
        }// class Sincronizacion
	} // namespace Permaquim.Depositario.Business.Procedures.Sincronizacion
