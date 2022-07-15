using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace Permaquim.Depositario.Entities.Procedures. Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerExistenciasPorDepositario","ObtenerExistenciasPorDepositario")]
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)]
			public class ObtenerExistenciasPorDepositario : IDataItem // ResultContainer
			{
			public class Resultado : IDataItem
				        {
				public class ColumnNames
				{
					public const string Moneda = "Moneda";
					public const string Denominacion = "Denominacion";
					public const string CantidadValidada = "CantidadValidada";
					public const string CantidadAValidar = "CantidadAValidar";
					public const string ImagenDenominacion = "ImagenDenominacion";
					public const string DepositarioId = "DepositarioId";
				}
				public enum FieldEnum : int
                {
					Moneda,
					Denominacion,
					CantidadValidada,
					CantidadAValidar,
					ImagenDenominacion,
					DepositarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Resultado()
                {}
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("Denominacion","Denominacion")]
             public String Denominacion { get; set; }
             [DataItemAttributeFieldName("CantidadValidada","CantidadValidada")]
             public Int32? CantidadValidada { get; set; }
             [DataItemAttributeFieldName("CantidadAValidar","CantidadAValidar")]
             public Int32? CantidadAValidar { get; set; }
             [DataItemAttributeFieldName("ImagenDenominacion","ImagenDenominacion")]
             public String? ImagenDenominacion { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
     }
     }
     }
		namespace Permaquim.Depositario.Entities.Procedures. Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerInformacionDepositario","ObtenerInformacionDepositario")]
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)]
			public class ObtenerInformacionDepositario : IDataItem // ResultContainer
			{
			public class Resultado : IDataItem
				        {
				public class ColumnNames
				{
					public const string DepositarioId = "DepositarioId";
					public const string NumeroSerie = "NumeroSerie";
					public const string FechaUltimaSincronizacion = "FechaUltimaSincronizacion";
					public const string PorcentajeOcupacionBolsa = "PorcentajeOcupacionBolsa";
					public const string IdentificadorBolsa = "IdentificadorBolsa";
					public const string TotalValidado = "TotalValidado";
					public const string TotalAValidar = "TotalAValidar";
					public const string Total = "Total";
				}
				public enum FieldEnum : int
                {
					DepositarioId,
					NumeroSerie,
					FechaUltimaSincronizacion,
					PorcentajeOcupacionBolsa,
					IdentificadorBolsa,
					TotalValidado,
					TotalAValidar,
					Total
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Resultado()
                {}
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("NumeroSerie","NumeroSerie")]
             public String NumeroSerie { get; set; }
             [DataItemAttributeFieldName("FechaUltimaSincronizacion","FechaUltimaSincronizacion")]
             public DateTime FechaUltimaSincronizacion { get; set; }
             [DataItemAttributeFieldName("PorcentajeOcupacionBolsa","PorcentajeOcupacionBolsa")]
             public Double PorcentajeOcupacionBolsa { get; set; }
             [DataItemAttributeFieldName("IdentificadorBolsa","IdentificadorBolsa")]
             public String IdentificadorBolsa { get; set; }
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public Double TotalValidado { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double TotalAValidar { get; set; }
             [DataItemAttributeFieldName("Total","Total")]
             public Double Total { get; set; }
     }
     }
     }
		namespace Permaquim.Depositario.Entities.Procedures. Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerExistenciasAValidarPorDepositario","ObtenerExistenciasAValidarPorDepositario")]
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)]
			public class ObtenerExistenciasAValidarPorDepositario : IDataItem // ResultContainer
			{
			public class Resultado : IDataItem
				        {
				public class ColumnNames
				{
					public const string Moneda = "Moneda";
					public const string TipoValor = "TipoValor";
					public const string ValorDeclarado = "ValorDeclarado";
					public const string DepositarioId = "DepositarioId";
				}
				public enum FieldEnum : int
                {
					Moneda,
					TipoValor,
					ValorDeclarado,
					DepositarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Resultado()
                {}
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("TipoValor","TipoValor")]
             public String TipoValor { get; set; }
             [DataItemAttributeFieldName("ValorDeclarado","ValorDeclarado")]
             public Int32? ValorDeclarado { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
     }
     }
     }
		namespace Permaquim.Depositario.Entities.Procedures. Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerTotalesGeneralesPorMonedaDepositario","ObtenerTotalesGeneralesPorMonedaDepositario")]
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)]
			public class ObtenerTotalesGeneralesPorMonedaDepositario : IDataItem // ResultContainer
			{
			public class Resultado : IDataItem
				        {
				public class ColumnNames
				{
					public const string Moneda = "Moneda";
					public const string TotalValidado = "TotalValidado";
					public const string TotalAValidar = "TotalAValidar";
					public const string Total = "Total";
					public const string DepositarioId = "DepositarioId";
				}
				public enum FieldEnum : int
                {
					Moneda,
					TotalValidado,
					TotalAValidar,
					Total,
					DepositarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Resultado()
                {}
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public Double TotalValidado { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double TotalAValidar { get; set; }
             [DataItemAttributeFieldName("Total","Total")]
             public Double Total { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
     }
     }
     }
		namespace Permaquim.Depositario.Entities.Procedures. Regionalizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Regionalizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerTextosLenguaje","ObtenerTextosLenguaje")]
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)]
			public class ObtenerTextosLenguaje : IDataItem // ResultContainer
			{
			public class Resultado : IDataItem
				        {
				public class ColumnNames
				{
					public const string Clave = "Clave";
					public const string Texto = "Texto";
					public const string Lenguaje = "Lenguaje";
				}
				public enum FieldEnum : int
                {
					Clave,
					Texto,
					Lenguaje
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Resultado()
                {}
             [DataItemAttributeFieldName("Clave","Clave")]
             public String Clave { get; set; }
             [DataItemAttributeFieldName("Texto","Texto")]
             public String Texto { get; set; }
             [DataItemAttributeFieldName("Lenguaje","Lenguaje")]
             public String Lenguaje { get; set; }
     }
     }
     }
