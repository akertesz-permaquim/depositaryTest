using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace PQDepositario.Business.Procedures.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerDepositarios : ProcedureDataHandler
		{
         private List<Entities.Procedures.Dispositivo.ObtenerDepositarios> _result = new List<Entities.Procedures.Dispositivo.ObtenerDepositarios>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerDepositarios() : base()
            {
                base._dataItem = new Entities.Procedures.Dispositivo.ObtenerDepositarios();
            }
            public  List<Entities.Procedures.Dispositivo.ObtenerDepositarios> Items()
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Dispositivo.ObtenerDepositarios> _entities = new List<Entities.Procedures.Dispositivo.ObtenerDepositarios>();
                _result = dh.Items(new List<ParameterItemValue> {}).Cast<Entities.Procedures.Dispositivo.ObtenerDepositarios>().ToList<Entities.Procedures.Dispositivo.ObtenerDepositarios>();
                return _result;
             }
             public List<Entities.Procedures.Dispositivo.ObtenerDepositarios> Resultset
             {
                 get { return _result; }
             }
        }// class Dispositivo
	} // namespace PQDepositario.Business.Procedures.Dispositivo
