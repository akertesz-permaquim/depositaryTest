using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace DepositarioAdminWeb.Business.Procedures.Dispositivo {
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
	} // namespace DepositarioAdminWeb.Business.Procedures.Dispositivo
	namespace DepositarioAdminWeb.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerDetalleTransaccion : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerDetalleTransaccion> _result = new List<Entities.Procedures.Operacion.ObtenerDetalleTransaccion>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerDetalleTransaccion() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerDetalleTransaccion();
            }
            public  List<Entities.Procedures.Operacion.ObtenerDetalleTransaccion> Items(Int64? TransaccionID)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerDetalleTransaccion> _entities = new List<Entities.Procedures.Operacion.ObtenerDetalleTransaccion>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("TransaccionID", TransaccionID)}).Cast<Entities.Procedures.Operacion.ObtenerDetalleTransaccion>().ToList<Entities.Procedures.Operacion.ObtenerDetalleTransaccion>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerDetalleTransaccion> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DepositarioAdminWeb.Business.Procedures.Operacion
	namespace DepositarioAdminWeb.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerDetalleTransaccionSobre : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre> _result = new List<Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerDetalleTransaccionSobre() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre();
            }
            public  List<Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre> Items(Int64? TransaccionSobreID)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre> _entities = new List<Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("TransaccionSobreID", TransaccionSobreID)}).Cast<Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre>().ToList<Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerDetalleTransaccionSobre> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DepositarioAdminWeb.Business.Procedures.Operacion
	namespace DepositarioAdminWeb.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerEventosPorDepositario : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerEventosPorDepositario> _result = new List<Entities.Procedures.Operacion.ObtenerEventosPorDepositario>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerEventosPorDepositario() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerEventosPorDepositario();
            }
            public  List<Entities.Procedures.Operacion.ObtenerEventosPorDepositario> Items(Int64? DepositarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerEventosPorDepositario> _entities = new List<Entities.Procedures.Operacion.ObtenerEventosPorDepositario>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Procedures.Operacion.ObtenerEventosPorDepositario>().ToList<Entities.Procedures.Operacion.ObtenerEventosPorDepositario>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerEventosPorDepositario> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DepositarioAdminWeb.Business.Procedures.Operacion
	namespace DepositarioAdminWeb.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerTransaccionesPorDepositario : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario> _result = new List<Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerTransaccionesPorDepositario() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario();
            }
            public  List<Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario> Items(Int64? DepositarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario> _entities = new List<Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario>().ToList<Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerTransaccionesPorDepositario> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DepositarioAdminWeb.Business.Procedures.Operacion
	namespace DepositarioAdminWeb.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerTransaccionesSobrePorDepositario : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario> _result = new List<Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerTransaccionesSobrePorDepositario() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario();
            }
            public  List<Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario> Items(Int64? DepositarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario> _entities = new List<Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario>().ToList<Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerTransaccionesSobrePorDepositario> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DepositarioAdminWeb.Business.Procedures.Operacion
