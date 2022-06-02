using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace PQDepositario.Entities.Procedures.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerDepositarios","ObtenerDepositarios")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerDepositarios : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string DepositarioId = "DepositarioId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Sector = "Sector";
					public const string Sucursal = "Sucursal";
					public const string Empresa = "Empresa";
					public const string NumeroSerie = "NumeroSerie";
					public const string CodigoExterno = "CodigoExterno";
					public const string Modelo = "Modelo";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string CantidadDepositoUltimoCierre = "CantidadDepositoUltimoCierre";
					public const string ValorTotalEnBolsa = "ValorTotalEnBolsa";
					public const string SemaforoOnline = "SemaforoOnline";
					public const string SemaforoAnomalia = "SemaforoAnomalia";
					public const string SemaforoOcupacionBolsa = "SemaforoOcupacionBolsa";
				}
				public enum FieldEnum : int
                {
					DepositarioId,
					Nombre,
					Descripcion,
					Sector,
					Sucursal,
					Empresa,
					NumeroSerie,
					CodigoExterno,
					Modelo,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion,
					CantidadDepositoUltimoCierre,
					ValorTotalEnBolsa,
					SemaforoOnline,
					SemaforoAnomalia,
					SemaforoOcupacionBolsa
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerDepositarios()
                {
                }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64? DepositarioId { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Sector","Sector")]
             public String Sector { get; set; }
             [DataItemAttributeFieldName("Sucursal","Sucursal")]
             public String Sucursal { get; set; }
             [DataItemAttributeFieldName("Empresa","Empresa")]
             public String Empresa { get; set; }
             [DataItemAttributeFieldName("NumeroSerie","NumeroSerie")]
             public String NumeroSerie { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Modelo","Modelo")]
             public String Modelo { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean? Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public String UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime? FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public String UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CantidadDepositoUltimoCierre","CantidadDepositoUltimoCierre")]
             public Int32? CantidadDepositoUltimoCierre { get; set; }
             [DataItemAttributeFieldName("ValorTotalEnBolsa","ValorTotalEnBolsa")]
             public Double? ValorTotalEnBolsa { get; set; }
             [DataItemAttributeFieldName("SemaforoOnline","SemaforoOnline")]
             public String SemaforoOnline { get; set; }
             [DataItemAttributeFieldName("SemaforoAnomalia","SemaforoAnomalia")]
             public String SemaforoAnomalia { get; set; }
             [DataItemAttributeFieldName("SemaforoOcupacionBolsa","SemaforoOcupacionBolsa")]
             public String SemaforoOcupacionBolsa { get; set; }
				
			} //Class ObtenerDepositarios 
			
} //namespace PQDepositario.Entities.Procedures.Dispositivo
