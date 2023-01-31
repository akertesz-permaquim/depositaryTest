using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	namespace DefaultNamespace.Business.Procedures.Customizador {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ConstruirEntidadesyAtributos : ProcedureDataHandler
		{
         private List<Entities.Procedures.Customizador.ConstruirEntidadesyAtributos> _result = new List<Entities.Procedures.Customizador.ConstruirEntidadesyAtributos>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ConstruirEntidadesyAtributos() : base()
            {
                base._dataItem = new Entities.Procedures.Customizador.ConstruirEntidadesyAtributos();
            }
            public  List<Entities.Procedures.Customizador.ConstruirEntidadesyAtributos> Items()
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Customizador.ConstruirEntidadesyAtributos> _entities = new List<Entities.Procedures.Customizador.ConstruirEntidadesyAtributos>();
                _result = dh.Items(new List<ParameterItemValue> {}).Cast<Entities.Procedures.Customizador.ConstruirEntidadesyAtributos>().ToList<Entities.Procedures.Customizador.ConstruirEntidadesyAtributos>();
                return _result;
             }
             public List<Entities.Procedures.Customizador.ConstruirEntidadesyAtributos> Resultset
             {
                 get { return _result; }
             }
        }// class Customizador
	} // namespace DefaultNamespace.Business.Procedures.Customizador
	namespace DefaultNamespace.Business.Procedures.dbo {
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
	} // namespace DefaultNamespace.Business.Procedures.dbo
	namespace DefaultNamespace.Business.Functions.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class fn_diagramobjects : FunctionDataHandler
		{
         private List<Entities.Functions.dbo.fn_diagramobjects> _result = new List<Entities.Functions.dbo.fn_diagramobjects>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public fn_diagramobjects() : base()
            {
                base._dataItem = new Entities.Functions.dbo.fn_diagramobjects();
            }
            public  List<Entities.Functions.dbo.fn_diagramobjects> Items()
            {
                FunctionDataHandler dh =  new FunctionDataHandler(this._dataItem);
                List<Entities.Functions.dbo.fn_diagramobjects> _entities = new List<Entities.Functions.dbo.fn_diagramobjects>();
                _result = dh.Items(new List<ParameterItemValue> {}).Cast<Entities.Functions.dbo.fn_diagramobjects>().ToList<Entities.Functions.dbo.fn_diagramobjects>();
                return _result;
             }
             public List<Entities.Functions.dbo.fn_diagramobjects> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace DefaultNamespace.Business.Functions.dbo
	namespace DefaultNamespace.Business.Procedures.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class sp_alterdiagram : ProcedureDataHandler
		{
         private List<Entities.Procedures.dbo.sp_alterdiagram> _result = new List<Entities.Procedures.dbo.sp_alterdiagram>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public sp_alterdiagram() : base()
            {
                base._dataItem = new Entities.Procedures.dbo.sp_alterdiagram();
            }
            public  List<Entities.Procedures.dbo.sp_alterdiagram> Items(String diagramname,Int32? owner_id,Int32? version,Byte[]? definition)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.dbo.sp_alterdiagram> _entities = new List<Entities.Procedures.dbo.sp_alterdiagram>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("diagramname", diagramname), new ParameterItemValue("owner_id", owner_id), new ParameterItemValue("version", version), new ParameterItemValue("definition", definition)}).Cast<Entities.Procedures.dbo.sp_alterdiagram>().ToList<Entities.Procedures.dbo.sp_alterdiagram>();
                return _result;
             }
             public List<Entities.Procedures.dbo.sp_alterdiagram> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace DefaultNamespace.Business.Procedures.dbo
	namespace DefaultNamespace.Business.Procedures.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class sp_creatediagram : ProcedureDataHandler
		{
         private List<Entities.Procedures.dbo.sp_creatediagram> _result = new List<Entities.Procedures.dbo.sp_creatediagram>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public sp_creatediagram() : base()
            {
                base._dataItem = new Entities.Procedures.dbo.sp_creatediagram();
            }
            public  List<Entities.Procedures.dbo.sp_creatediagram> Items(String diagramname,Int32? owner_id,Int32? version,Byte[]? definition)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.dbo.sp_creatediagram> _entities = new List<Entities.Procedures.dbo.sp_creatediagram>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("diagramname", diagramname), new ParameterItemValue("owner_id", owner_id), new ParameterItemValue("version", version), new ParameterItemValue("definition", definition)}).Cast<Entities.Procedures.dbo.sp_creatediagram>().ToList<Entities.Procedures.dbo.sp_creatediagram>();
                return _result;
             }
             public List<Entities.Procedures.dbo.sp_creatediagram> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace DefaultNamespace.Business.Procedures.dbo
	namespace DefaultNamespace.Business.Procedures.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class sp_dropdiagram : ProcedureDataHandler
		{
         private List<Entities.Procedures.dbo.sp_dropdiagram> _result = new List<Entities.Procedures.dbo.sp_dropdiagram>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public sp_dropdiagram() : base()
            {
                base._dataItem = new Entities.Procedures.dbo.sp_dropdiagram();
            }
            public  List<Entities.Procedures.dbo.sp_dropdiagram> Items(String diagramname,Int32? owner_id)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.dbo.sp_dropdiagram> _entities = new List<Entities.Procedures.dbo.sp_dropdiagram>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("diagramname", diagramname), new ParameterItemValue("owner_id", owner_id)}).Cast<Entities.Procedures.dbo.sp_dropdiagram>().ToList<Entities.Procedures.dbo.sp_dropdiagram>();
                return _result;
             }
             public List<Entities.Procedures.dbo.sp_dropdiagram> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace DefaultNamespace.Business.Procedures.dbo
	namespace DefaultNamespace.Business.Procedures.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class sp_helpdiagramdefinition : ProcedureDataHandler
		{
         private List<Entities.Procedures.dbo.sp_helpdiagramdefinition> _result = new List<Entities.Procedures.dbo.sp_helpdiagramdefinition>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public sp_helpdiagramdefinition() : base()
            {
                base._dataItem = new Entities.Procedures.dbo.sp_helpdiagramdefinition();
            }
            public  List<Entities.Procedures.dbo.sp_helpdiagramdefinition> Items(String diagramname,Int32? owner_id)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.dbo.sp_helpdiagramdefinition> _entities = new List<Entities.Procedures.dbo.sp_helpdiagramdefinition>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("diagramname", diagramname), new ParameterItemValue("owner_id", owner_id)}).Cast<Entities.Procedures.dbo.sp_helpdiagramdefinition>().ToList<Entities.Procedures.dbo.sp_helpdiagramdefinition>();
                return _result;
             }
             public List<Entities.Procedures.dbo.sp_helpdiagramdefinition> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace DefaultNamespace.Business.Procedures.dbo
	namespace DefaultNamespace.Business.Procedures.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class sp_helpdiagrams : ProcedureDataHandler
		{
         private List<Entities.Procedures.dbo.sp_helpdiagrams> _result = new List<Entities.Procedures.dbo.sp_helpdiagrams>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public sp_helpdiagrams() : base()
            {
                base._dataItem = new Entities.Procedures.dbo.sp_helpdiagrams();
            }
            public  List<Entities.Procedures.dbo.sp_helpdiagrams> Items(String diagramname,Int32? owner_id)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.dbo.sp_helpdiagrams> _entities = new List<Entities.Procedures.dbo.sp_helpdiagrams>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("diagramname", diagramname), new ParameterItemValue("owner_id", owner_id)}).Cast<Entities.Procedures.dbo.sp_helpdiagrams>().ToList<Entities.Procedures.dbo.sp_helpdiagrams>();
                return _result;
             }
             public List<Entities.Procedures.dbo.sp_helpdiagrams> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace DefaultNamespace.Business.Procedures.dbo
	namespace DefaultNamespace.Business.Procedures.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class sp_renamediagram : ProcedureDataHandler
		{
         private List<Entities.Procedures.dbo.sp_renamediagram> _result = new List<Entities.Procedures.dbo.sp_renamediagram>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public sp_renamediagram() : base()
            {
                base._dataItem = new Entities.Procedures.dbo.sp_renamediagram();
            }
            public  List<Entities.Procedures.dbo.sp_renamediagram> Items(String diagramname,Int32? owner_id,String new_diagramname)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.dbo.sp_renamediagram> _entities = new List<Entities.Procedures.dbo.sp_renamediagram>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("diagramname", diagramname), new ParameterItemValue("owner_id", owner_id), new ParameterItemValue("new_diagramname", new_diagramname)}).Cast<Entities.Procedures.dbo.sp_renamediagram>().ToList<Entities.Procedures.dbo.sp_renamediagram>();
                return _result;
             }
             public List<Entities.Procedures.dbo.sp_renamediagram> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace DefaultNamespace.Business.Procedures.dbo
	namespace DefaultNamespace.Business.Procedures.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class sp_upgraddiagrams : ProcedureDataHandler
		{
         private List<Entities.Procedures.dbo.sp_upgraddiagrams> _result = new List<Entities.Procedures.dbo.sp_upgraddiagrams>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public sp_upgraddiagrams() : base()
            {
                base._dataItem = new Entities.Procedures.dbo.sp_upgraddiagrams();
            }
            public  List<Entities.Procedures.dbo.sp_upgraddiagrams> Items()
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.dbo.sp_upgraddiagrams> _entities = new List<Entities.Procedures.dbo.sp_upgraddiagrams>();
                _result = dh.Items(new List<ParameterItemValue> {}).Cast<Entities.Procedures.dbo.sp_upgraddiagrams>().ToList<Entities.Procedures.dbo.sp_upgraddiagrams>();
                return _result;
             }
             public List<Entities.Procedures.dbo.sp_upgraddiagrams> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace DefaultNamespace.Business.Procedures.dbo
	namespace DefaultNamespace.Business.Functions.dbo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class splitCapital : FunctionDataHandler
		{
         private List<Entities.Functions.dbo.splitCapital> _result = new List<Entities.Functions.dbo.splitCapital>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public splitCapital() : base()
            {
                base._dataItem = new Entities.Functions.dbo.splitCapital();
            }
            public  List<Entities.Functions.dbo.splitCapital> Items(String param)
            {
                FunctionDataHandler dh =  new FunctionDataHandler(this._dataItem);
                List<Entities.Functions.dbo.splitCapital> _entities = new List<Entities.Functions.dbo.splitCapital>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("param", param)}).Cast<Entities.Functions.dbo.splitCapital>().ToList<Entities.Functions.dbo.splitCapital>();
                return _result;
             }
             public List<Entities.Functions.dbo.splitCapital> Resultset
             {
                 get { return _result; }
             }
        }// class dbo
	} // namespace DefaultNamespace.Business.Functions.dbo
	namespace DefaultNamespace.Business.Procedures.Desarrollo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ActualizarLenguajeItem : ProcedureDataHandler
		{
         private List<Entities.Procedures.Desarrollo.ActualizarLenguajeItem> _result = new List<Entities.Procedures.Desarrollo.ActualizarLenguajeItem>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ActualizarLenguajeItem() : base()
            {
                base._dataItem = new Entities.Procedures.Desarrollo.ActualizarLenguajeItem();
            }
            public  List<Entities.Procedures.Desarrollo.ActualizarLenguajeItem> Items()
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Desarrollo.ActualizarLenguajeItem> _entities = new List<Entities.Procedures.Desarrollo.ActualizarLenguajeItem>();
                _result = dh.Items(new List<ParameterItemValue> {}).Cast<Entities.Procedures.Desarrollo.ActualizarLenguajeItem>().ToList<Entities.Procedures.Desarrollo.ActualizarLenguajeItem>();
                return _result;
             }
             public List<Entities.Procedures.Desarrollo.ActualizarLenguajeItem> Resultset
             {
                 get { return _result; }
             }
        }// class Desarrollo
	} // namespace DefaultNamespace.Business.Procedures.Desarrollo
	namespace DefaultNamespace.Business.Procedures.Desarrollo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class GenerarTablaModelo : ProcedureDataHandler
		{
         private List<Entities.Procedures.Desarrollo.GenerarTablaModelo> _result = new List<Entities.Procedures.Desarrollo.GenerarTablaModelo>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public GenerarTablaModelo() : base()
            {
                base._dataItem = new Entities.Procedures.Desarrollo.GenerarTablaModelo();
            }
            public  List<Entities.Procedures.Desarrollo.GenerarTablaModelo> Items(String Schema,String Entity,Boolean? CreateSchema,Boolean? EnableCDC)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Desarrollo.GenerarTablaModelo> _entities = new List<Entities.Procedures.Desarrollo.GenerarTablaModelo>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("Schema", Schema), new ParameterItemValue("Entity", Entity), new ParameterItemValue("CreateSchema", CreateSchema), new ParameterItemValue("EnableCDC", EnableCDC)}).Cast<Entities.Procedures.Desarrollo.GenerarTablaModelo>().ToList<Entities.Procedures.Desarrollo.GenerarTablaModelo>();
                return _result;
             }
             public List<Entities.Procedures.Desarrollo.GenerarTablaModelo> Resultset
             {
                 get { return _result; }
             }
        }// class Desarrollo
	} // namespace DefaultNamespace.Business.Procedures.Desarrollo
	namespace DefaultNamespace.Business.Procedures.Desarrollo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class GenerarTablaTipoModelo : ProcedureDataHandler
		{
         private List<Entities.Procedures.Desarrollo.GenerarTablaTipoModelo> _result = new List<Entities.Procedures.Desarrollo.GenerarTablaTipoModelo>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public GenerarTablaTipoModelo() : base()
            {
                base._dataItem = new Entities.Procedures.Desarrollo.GenerarTablaTipoModelo();
            }
            public  List<Entities.Procedures.Desarrollo.GenerarTablaTipoModelo> Items(String Schema,String Entity,Boolean? CreateSchema,Boolean? EnableCDC)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Desarrollo.GenerarTablaTipoModelo> _entities = new List<Entities.Procedures.Desarrollo.GenerarTablaTipoModelo>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("Schema", Schema), new ParameterItemValue("Entity", Entity), new ParameterItemValue("CreateSchema", CreateSchema), new ParameterItemValue("EnableCDC", EnableCDC)}).Cast<Entities.Procedures.Desarrollo.GenerarTablaTipoModelo>().ToList<Entities.Procedures.Desarrollo.GenerarTablaTipoModelo>();
                return _result;
             }
             public List<Entities.Procedures.Desarrollo.GenerarTablaTipoModelo> Resultset
             {
                 get { return _result; }
             }
        }// class Desarrollo
	} // namespace DefaultNamespace.Business.Procedures.Desarrollo
	namespace DefaultNamespace.Business.Procedures.Dispositivo {
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
	} // namespace DefaultNamespace.Business.Procedures.Dispositivo
	namespace DefaultNamespace.Business.Procedures.Dispositivo {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerInformacionDepositario : ProcedureDataHandler
		{
         private List<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario> _result = new List<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerInformacionDepositario() : base()
            {
                base._dataItem = new Entities.Procedures.Dispositivo.ObtenerInformacionDepositario();
            }
            public  List<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario> Items(Int64? DepositarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario> _entities = new List<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario>().ToList<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario>();
                return _result;
             }
             public List<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario> Resultset
             {
                 get { return _result; }
             }
        }// class Dispositivo
	} // namespace DefaultNamespace.Business.Procedures.Dispositivo
	namespace DefaultNamespace.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerDatosTransaccionDepositoBillete : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoBillete> _result = new List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoBillete>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerDatosTransaccionDepositoBillete() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoBillete();
            }
            public  List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoBillete> Items(Int64? TransaccionId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoBillete> _entities = new List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoBillete>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("TransaccionId", TransaccionId)}).Cast<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoBillete>().ToList<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoBillete>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoBillete> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerDatosTransaccionDepositoSobre : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoSobre> _result = new List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoSobre>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerDatosTransaccionDepositoSobre() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoSobre();
            }
            public  List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoSobre> Items(Int64? TransaccionId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoSobre> _entities = new List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoSobre>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("TransaccionId", TransaccionId)}).Cast<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoSobre>().ToList<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoSobre>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerDatosTransaccionDepositoSobre> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Procedures.Operacion {
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
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Procedures.Operacion {
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
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Procedures.Operacion {
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
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerExistenciasAValidarPorDepositario : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario> _result = new List<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerExistenciasAValidarPorDepositario() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario();
            }
            public  List<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario> Items(Int64? DepositarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario> _entities = new List<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario>().ToList<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerExistenciasPorDepositario : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario> _result = new List<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerExistenciasPorDepositario() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario();
            }
            public  List<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario> Items(Int64? DepositarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario> _entities = new List<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario>().ToList<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Functions.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerPorcentajeOcupacionBolsaPorContenedor : FunctionDataHandler
		{
         private List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorContenedor> _result = new List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorContenedor>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerPorcentajeOcupacionBolsaPorContenedor() : base()
            {
                base._dataItem = new Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorContenedor();
            }
            public  List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorContenedor> Items(Int64? ContenedorId)
            {
                FunctionDataHandler dh =  new FunctionDataHandler(this._dataItem);
                List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorContenedor> _entities = new List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorContenedor>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("ContenedorId", ContenedorId)}).Cast<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorContenedor>().ToList<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorContenedor>();
                return _result;
             }
             public List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorContenedor> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DefaultNamespace.Business.Functions.Operacion
	namespace DefaultNamespace.Business.Functions.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerPorcentajeOcupacionBolsaPorDepositario : FunctionDataHandler
		{
         private List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorDepositario> _result = new List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorDepositario>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerPorcentajeOcupacionBolsaPorDepositario() : base()
            {
                base._dataItem = new Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorDepositario();
            }
            public  List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorDepositario> Items(Int64? DepositarioId)
            {
                FunctionDataHandler dh =  new FunctionDataHandler(this._dataItem);
                List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorDepositario> _entities = new List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorDepositario>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorDepositario>().ToList<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorDepositario>();
                return _result;
             }
             public List<Entities.Functions.Operacion.ObtenerPorcentajeOcupacionBolsaPorDepositario> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DefaultNamespace.Business.Functions.Operacion
	namespace DefaultNamespace.Business.Procedures.Operacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerTotalesGeneralesPorMonedaDepositario : ProcedureDataHandler
		{
         private List<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario> _result = new List<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerTotalesGeneralesPorMonedaDepositario() : base()
            {
                base._dataItem = new Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario();
            }
            public  List<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario> Items(Int64? DepositarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario> _entities = new List<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)}).Cast<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario>().ToList<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario>();
                return _result;
             }
             public List<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario> Resultset
             {
                 get { return _result; }
             }
        }// class Operacion
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Procedures.Operacion {
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
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Procedures.Operacion {
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
	} // namespace DefaultNamespace.Business.Procedures.Operacion
	namespace DefaultNamespace.Business.Procedures.Regionalizacion {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerTextosLenguaje : ProcedureDataHandler
		{
         private List<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje> _result = new List<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerTextosLenguaje() : base()
            {
                base._dataItem = new Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje();
            }
            public  List<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje> Items(Int64? UsuarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje> _entities = new List<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("UsuarioId", UsuarioId)}).Cast<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje>().ToList<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje>();
                return _result;
             }
             public List<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje> Resultset
             {
                 get { return _result; }
             }
        }// class Regionalizacion
	} // namespace DefaultNamespace.Business.Procedures.Regionalizacion
	namespace DefaultNamespace.Business.Procedures.Seguridad {
	    /// <summary>
	    /// 
	    /// </summary>
		public class ObtenerRolesPorUsuario : ProcedureDataHandler
		{
         private List<Entities.Procedures.Seguridad.ObtenerRolesPorUsuario> _result = new List<Entities.Procedures.Seguridad.ObtenerRolesPorUsuario>();
			protected List<IDataItem> _cacheItemList = new List<IDataItem>();
            public ObtenerRolesPorUsuario() : base()
            {
                base._dataItem = new Entities.Procedures.Seguridad.ObtenerRolesPorUsuario();
            }
            public  List<Entities.Procedures.Seguridad.ObtenerRolesPorUsuario> Items(Int64? UsuarioId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Seguridad.ObtenerRolesPorUsuario> _entities = new List<Entities.Procedures.Seguridad.ObtenerRolesPorUsuario>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("UsuarioId", UsuarioId)}).Cast<Entities.Procedures.Seguridad.ObtenerRolesPorUsuario>().ToList<Entities.Procedures.Seguridad.ObtenerRolesPorUsuario>();
                return _result;
             }
             public List<Entities.Procedures.Seguridad.ObtenerRolesPorUsuario> Resultset
             {
                 get { return _result; }
             }
        }// class Seguridad
	} // namespace DefaultNamespace.Business.Procedures.Seguridad
	namespace DefaultNamespace.Business.Procedures.Sincronizacion {
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
            public  List<Entities.Procedures.Sincronizacion.ObtenerIdDestino> Items(String EntidadNombre,Int64? DepositarioId,Int64? OrigenId)
            {
                ProcedureDataHandler dh =  new ProcedureDataHandler(this._dataItem);
                List<Entities.Procedures.Sincronizacion.ObtenerIdDestino> _entities = new List<Entities.Procedures.Sincronizacion.ObtenerIdDestino>();
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("EntidadNombre", EntidadNombre), new ParameterItemValue("DepositarioId", DepositarioId), new ParameterItemValue("OrigenId", OrigenId)}).Cast<Entities.Procedures.Sincronizacion.ObtenerIdDestino>().ToList<Entities.Procedures.Sincronizacion.ObtenerIdDestino>();
                return _result;
             }
             public List<Entities.Procedures.Sincronizacion.ObtenerIdDestino> Resultset
             {
                 get { return _result; }
             }
        }// class Sincronizacion
	} // namespace DefaultNamespace.Business.Procedures.Sincronizacion
	namespace DefaultNamespace.Business.Procedures.Sincronizacion {
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
	} // namespace DefaultNamespace.Business.Procedures.Sincronizacion
