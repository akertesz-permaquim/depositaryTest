using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace Permaquim.Depositario.Business.Procedures.Operacion {
	    /// <summary>
	    /// ObtenerExistenciasPorDepositario
	    /// </summary>
		public class ObtenerExistenciasPorDepositario : MappedProcedureDataHandler
		{
         private List<List<IDataItem>> _result = new List<List<IDataItem>>();
         private List<IDataItem> _dataItems = new List<IDataItem>();
         public MappedResult MappedResultSet = new MappedResult();
            public ObtenerExistenciasPorDepositario() : base()
            {
                 _dataItems.Add(new Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario.Resultado());
            }
            public List<List<IDataItem>> Items(Int64? DepositarioId)
            {
                MappedProcedureDataHandler dh = new MappedProcedureDataHandler((IDataItem)new Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario(), _dataItems);
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)});
                 MappedResultSet.Resultado = _result[0].Cast<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario.Resultado>().ToList<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario.Resultado>();
                return _result;
             }
             public List<List<IDataItem>> Resultset
             {
                 get { return _result; }
             }
             public class MappedResult
             {
                 public List<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario.Resultado> Resultado= new List<Entities.Procedures.Operacion.ObtenerExistenciasPorDepositario.Resultado>();
             }
        }// class 
     }
		namespace Permaquim.Depositario.Business.Procedures.Dispositivo {
	    /// <summary>
	    /// ObtenerInformacionDepositario
	    /// </summary>
		public class ObtenerInformacionDepositario : MappedProcedureDataHandler
		{
         private List<List<IDataItem>> _result = new List<List<IDataItem>>();
         private List<IDataItem> _dataItems = new List<IDataItem>();
         public MappedResult MappedResultSet = new MappedResult();
            public ObtenerInformacionDepositario() : base()
            {
                 _dataItems.Add(new Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado());
            }
            public List<List<IDataItem>> Items(Int64? DepositarioId)
            {
                MappedProcedureDataHandler dh = new MappedProcedureDataHandler((IDataItem)new Entities.Procedures.Dispositivo.ObtenerInformacionDepositario(), _dataItems);
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)});
                 MappedResultSet.Resultado = _result[0].Cast<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado>().ToList<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado>();
                return _result;
             }
             public List<List<IDataItem>> Resultset
             {
                 get { return _result; }
             }
             public class MappedResult
             {
                 public List<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado> Resultado= new List<Entities.Procedures.Dispositivo.ObtenerInformacionDepositario.Resultado>();
             }
        }// class 
     }
		namespace Permaquim.Depositario.Business.Procedures.Operacion {
	    /// <summary>
	    /// ObtenerExistenciasAValidarPorDepositario
	    /// </summary>
		public class ObtenerExistenciasAValidarPorDepositario : MappedProcedureDataHandler
		{
         private List<List<IDataItem>> _result = new List<List<IDataItem>>();
         private List<IDataItem> _dataItems = new List<IDataItem>();
         public MappedResult MappedResultSet = new MappedResult();
            public ObtenerExistenciasAValidarPorDepositario() : base()
            {
                 _dataItems.Add(new Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario.Resultado());
            }
            public List<List<IDataItem>> Items(Int64? DepositarioId)
            {
                MappedProcedureDataHandler dh = new MappedProcedureDataHandler((IDataItem)new Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario(), _dataItems);
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)});
                 MappedResultSet.Resultado = _result[0].Cast<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario.Resultado>().ToList<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario.Resultado>();
                return _result;
             }
             public List<List<IDataItem>> Resultset
             {
                 get { return _result; }
             }
             public class MappedResult
             {
                 public List<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario.Resultado> Resultado= new List<Entities.Procedures.Operacion.ObtenerExistenciasAValidarPorDepositario.Resultado>();
             }
        }// class 
     }
		namespace Permaquim.Depositario.Business.Procedures.Operacion {
	    /// <summary>
	    /// ObtenerTotalesGeneralesPorMonedaDepositario
	    /// </summary>
		public class ObtenerTotalesGeneralesPorMonedaDepositario : MappedProcedureDataHandler
		{
         private List<List<IDataItem>> _result = new List<List<IDataItem>>();
         private List<IDataItem> _dataItems = new List<IDataItem>();
         public MappedResult MappedResultSet = new MappedResult();
            public ObtenerTotalesGeneralesPorMonedaDepositario() : base()
            {
                 _dataItems.Add(new Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado());
            }
            public List<List<IDataItem>> Items(Int64? DepositarioId)
            {
                MappedProcedureDataHandler dh = new MappedProcedureDataHandler((IDataItem)new Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario(), _dataItems);
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("DepositarioId", DepositarioId)});
                 MappedResultSet.Resultado = _result[0].Cast<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado>().ToList<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado>();
                return _result;
             }
             public List<List<IDataItem>> Resultset
             {
                 get { return _result; }
             }
             public class MappedResult
             {
                 public List<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado> Resultado= new List<Entities.Procedures.Operacion.ObtenerTotalesGeneralesPorMonedaDepositario.Resultado>();
             }
        }// class 
     }
		namespace Permaquim.Depositario.Business.Procedures.Regionalizacion {
	    /// <summary>
	    /// ObtenerTextosLenguaje
	    /// </summary>
		public class ObtenerTextosLenguaje : MappedProcedureDataHandler
		{
         private List<List<IDataItem>> _result = new List<List<IDataItem>>();
         private List<IDataItem> _dataItems = new List<IDataItem>();
         public MappedResult MappedResultSet = new MappedResult();
            public ObtenerTextosLenguaje() : base()
            {
                 _dataItems.Add(new Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado());
            }
            public List<List<IDataItem>> Items(Int64? UsuarioId)
            {
                MappedProcedureDataHandler dh = new MappedProcedureDataHandler((IDataItem)new Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje(), _dataItems);
                _result = dh.Items(new List<ParameterItemValue> { new ParameterItemValue("UsuarioId", UsuarioId)});
                 MappedResultSet.Resultado = _result[0].Cast<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado>().ToList<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado>();
                return _result;
             }
             public List<List<IDataItem>> Resultset
             {
                 get { return _result; }
             }
             public class MappedResult
             {
                 public List<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado> Resultado= new List<Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado>();
             }
        }// class 
     }
