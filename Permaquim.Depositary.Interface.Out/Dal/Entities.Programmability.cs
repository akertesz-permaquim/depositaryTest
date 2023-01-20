using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace DefaultNamespace.Entities.Procedures.Customizador {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Customizador")]  // Database Schema Name
			[DataItemAttributeObjectName("ConstruirEntidadesyAtributos","ConstruirEntidadesyAtributos")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ConstruirEntidadesyAtributos : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ConstruirEntidadesyAtributos()
                {
                }
				
			} //Class ConstruirEntidadesyAtributos 
			
} //namespace DefaultNamespace.Entities.Procedures.Customizador
		namespace DefaultNamespace.Entities.Procedures.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("FinalizarPrimeraSincronizacion","FinalizarPrimeraSincronizacion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class FinalizarPrimeraSincronizacion : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public FinalizarPrimeraSincronizacion()
                {
                }
				
			} //Class FinalizarPrimeraSincronizacion 
			
} //namespace DefaultNamespace.Entities.Procedures.dbo
		namespace DefaultNamespace.Entities.Functions.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("fn_diagramobjects","fn_diagramobjects")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Function)] // Table, Functions,StoredProcedure,Function
			public class fn_diagramobjects : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public fn_diagramobjects()
                {
                }
				
			} //Class fn_diagramobjects 
			
} //namespace DefaultNamespace.Entities.Functions.dbo
		namespace DefaultNamespace.Entities.Procedures.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("sp_alterdiagram","sp_alterdiagram")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class sp_alterdiagram : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public sp_alterdiagram()
                {
                }
				
			} //Class sp_alterdiagram 
			
} //namespace DefaultNamespace.Entities.Procedures.dbo
		namespace DefaultNamespace.Entities.Procedures.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("sp_creatediagram","sp_creatediagram")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class sp_creatediagram : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public sp_creatediagram()
                {
                }
				
			} //Class sp_creatediagram 
			
} //namespace DefaultNamespace.Entities.Procedures.dbo
		namespace DefaultNamespace.Entities.Procedures.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("sp_dropdiagram","sp_dropdiagram")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class sp_dropdiagram : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public sp_dropdiagram()
                {
                }
				
			} //Class sp_dropdiagram 
			
} //namespace DefaultNamespace.Entities.Procedures.dbo
		namespace DefaultNamespace.Entities.Procedures.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("sp_helpdiagramdefinition","sp_helpdiagramdefinition")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class sp_helpdiagramdefinition : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string version = "version";
					public const string definition = "definition";
				}
				public enum FieldEnum : int
                {
					version,
					definition
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public sp_helpdiagramdefinition()
                {
                }
             [DataItemAttributeFieldName("version","version")]
             public Int32? version { get; set; }
             [DataItemAttributeFieldName("definition","definition")]
             public Byte[]? definition { get; set; }
				
			} //Class sp_helpdiagramdefinition 
			
} //namespace DefaultNamespace.Entities.Procedures.dbo
		namespace DefaultNamespace.Entities.Procedures.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("sp_helpdiagrams","sp_helpdiagrams")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class sp_helpdiagrams : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string Database = "Database";
					public const string Name = "Name";
					public const string ID = "ID";
					public const string Owner = "Owner";
					public const string OwnerID = "OwnerID";
				}
				public enum FieldEnum : int
                {
					Database,
					Name,
					ID,
					Owner,
					OwnerID
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public sp_helpdiagrams()
                {
                }
             [DataItemAttributeFieldName("Database","Database")]
             public String Database { get; set; }
             [DataItemAttributeFieldName("Name","Name")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Id Display Default
             public String Name { get; set; }
             [DataItemAttributeFieldName("ID","ID")]
             public Int32? ID { get; set; }
             [DataItemAttributeFieldName("Owner","Owner")]
             public String Owner { get; set; }
             [DataItemAttributeFieldName("OwnerID","OwnerID")]
             public Int32? OwnerID { get; set; }
				
			} //Class sp_helpdiagrams 
			
} //namespace DefaultNamespace.Entities.Procedures.dbo
		namespace DefaultNamespace.Entities.Procedures.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("sp_renamediagram","sp_renamediagram")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class sp_renamediagram : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public sp_renamediagram()
                {
                }
				
			} //Class sp_renamediagram 
			
} //namespace DefaultNamespace.Entities.Procedures.dbo
		namespace DefaultNamespace.Entities.Procedures.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("sp_upgraddiagrams","sp_upgraddiagrams")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class sp_upgraddiagrams : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public sp_upgraddiagrams()
                {
                }
				
			} //Class sp_upgraddiagrams 
			
} //namespace DefaultNamespace.Entities.Procedures.dbo
		namespace DefaultNamespace.Entities.Functions.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("splitCapital","splitCapital")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Function)] // Table, Functions,StoredProcedure,Function
			public class splitCapital : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public splitCapital()
                {
                }
				
			} //Class splitCapital 
			
} //namespace DefaultNamespace.Entities.Functions.dbo
		namespace DefaultNamespace.Entities.Procedures.Desarrollo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Desarrollo")]  // Database Schema Name
			[DataItemAttributeObjectName("ActualizarLenguajeItem","ActualizarLenguajeItem")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ActualizarLenguajeItem : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ActualizarLenguajeItem()
                {
                }
				
			} //Class ActualizarLenguajeItem 
			
} //namespace DefaultNamespace.Entities.Procedures.Desarrollo
		namespace DefaultNamespace.Entities.Procedures.Desarrollo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Desarrollo")]  // Database Schema Name
			[DataItemAttributeObjectName("GenerarTablaModelo","GenerarTablaModelo")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class GenerarTablaModelo : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public GenerarTablaModelo()
                {
                }
				
			} //Class GenerarTablaModelo 
			
} //namespace DefaultNamespace.Entities.Procedures.Desarrollo
		namespace DefaultNamespace.Entities.Procedures.Desarrollo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Desarrollo")]  // Database Schema Name
			[DataItemAttributeObjectName("GenerarTablaTipoModelo","GenerarTablaTipoModelo")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class GenerarTablaTipoModelo : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public GenerarTablaTipoModelo()
                {
                }
				
			} //Class GenerarTablaTipoModelo 
			
} //namespace DefaultNamespace.Entities.Procedures.Desarrollo
		namespace DefaultNamespace.Entities.Procedures.Dispositivo {
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
             [DataItemAttributeFieldName("ValorTotalEnBolsa","ValorTotalEnBolsa")]
             public String ValorTotalEnBolsa { get; set; }
             [DataItemAttributeFieldName("SemaforoOnline","SemaforoOnline")]
             public String SemaforoOnline { get; set; }
             [DataItemAttributeFieldName("SemaforoAnomalia","SemaforoAnomalia")]
             public String SemaforoAnomalia { get; set; }
             [DataItemAttributeFieldName("SemaforoOcupacionBolsa","SemaforoOcupacionBolsa")]
             public String SemaforoOcupacionBolsa { get; set; }
				
			} //Class ObtenerDepositarios 
			
} //namespace DefaultNamespace.Entities.Procedures.Dispositivo
		namespace DefaultNamespace.Entities.Procedures.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerInformacionDepositario","ObtenerInformacionDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerInformacionDepositario : IDataItem
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
					public const string CodigoMoneda = "CodigoMoneda";
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
					Total,
					CodigoMoneda
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerInformacionDepositario()
                {
                }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64? DepositarioId { get; set; }
             [DataItemAttributeFieldName("NumeroSerie","NumeroSerie")]
             public String NumeroSerie { get; set; }
             [DataItemAttributeFieldName("FechaUltimaSincronizacion","FechaUltimaSincronizacion")]
             public DateTime? FechaUltimaSincronizacion { get; set; }
             [DataItemAttributeFieldName("PorcentajeOcupacionBolsa","PorcentajeOcupacionBolsa")]
             public Double? PorcentajeOcupacionBolsa { get; set; }
             [DataItemAttributeFieldName("IdentificadorBolsa","IdentificadorBolsa")]
             public String IdentificadorBolsa { get; set; }
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public Double? TotalValidado { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double? TotalAValidar { get; set; }
             [DataItemAttributeFieldName("Total","Total")]
             public Double? Total { get; set; }
             [DataItemAttributeFieldName("CodigoMoneda","CodigoMoneda")]
             public String CodigoMoneda { get; set; }
				
			} //Class ObtenerInformacionDepositario 
			
} //namespace DefaultNamespace.Entities.Procedures.Dispositivo
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerDatosTransaccionDepositoBillete","ObtenerDatosTransaccionDepositoBillete")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerDatosTransaccionDepositoBillete : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerDatosTransaccionDepositoBillete()
                {
                }
				
			} //Class ObtenerDatosTransaccionDepositoBillete 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerDatosTransaccionDepositoSobre","ObtenerDatosTransaccionDepositoSobre")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerDatosTransaccionDepositoSobre : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerDatosTransaccionDepositoSobre()
                {
                }
				
			} //Class ObtenerDatosTransaccionDepositoSobre 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerDetalleTransaccion","ObtenerDetalleTransaccion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerDetalleTransaccion : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string TransaccionDetalleId = "TransaccionDetalleId";
					public const string FechaTransaccionDetalle = "FechaTransaccionDetalle";
					public const string Denominacion = "Denominacion";
					public const string ImagenDenominacion = "ImagenDenominacion";
					public const string Moneda = "Moneda";
					public const string CantidadUnidades = "CantidadUnidades";
					public const string TransaccionId = "TransaccionId";
				}
				public enum FieldEnum : int
                {
					TransaccionDetalleId,
					FechaTransaccionDetalle,
					Denominacion,
					ImagenDenominacion,
					Moneda,
					CantidadUnidades,
					TransaccionId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerDetalleTransaccion()
                {
                }
             [DataItemAttributeFieldName("TransaccionDetalleId","TransaccionDetalleId")]
             public Int64? TransaccionDetalleId { get; set; }
             [DataItemAttributeFieldName("FechaTransaccionDetalle","FechaTransaccionDetalle")]
             public DateTime? FechaTransaccionDetalle { get; set; }
             [DataItemAttributeFieldName("Denominacion","Denominacion")]
             public String Denominacion { get; set; }
             [DataItemAttributeFieldName("ImagenDenominacion","ImagenDenominacion")]
             public String ImagenDenominacion { get; set; }
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("CantidadUnidades","CantidadUnidades")]
             public Int64? CantidadUnidades { get; set; }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64? TransaccionId { get; set; }
				
			} //Class ObtenerDetalleTransaccion 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerDetalleTransaccionSobre","ObtenerDetalleTransaccionSobre")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerDetalleTransaccionSobre : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string TransaccionSobreDetalleId = "TransaccionSobreDetalleId";
					public const string FechaTransaccionSobreDetalle = "FechaTransaccionSobreDetalle";
					public const string CantidadDeclarada = "CantidadDeclarada";
					public const string TransaccionSobreId = "TransaccionSobreId";
					public const string Moneda = "Moneda";
					public const string TipoValor = "TipoValor";
				}
				public enum FieldEnum : int
                {
					TransaccionSobreDetalleId,
					FechaTransaccionSobreDetalle,
					CantidadDeclarada,
					TransaccionSobreId,
					Moneda,
					TipoValor
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerDetalleTransaccionSobre()
                {
                }
             [DataItemAttributeFieldName("TransaccionSobreDetalleId","TransaccionSobreDetalleId")]
             public Int64? TransaccionSobreDetalleId { get; set; }
             [DataItemAttributeFieldName("FechaTransaccionSobreDetalle","FechaTransaccionSobreDetalle")]
             public DateTime? FechaTransaccionSobreDetalle { get; set; }
             [DataItemAttributeFieldName("CantidadDeclarada","CantidadDeclarada")]
             public Int64? CantidadDeclarada { get; set; }
             [DataItemAttributeFieldName("TransaccionSobreId","TransaccionSobreId")]
             public Int64? TransaccionSobreId { get; set; }
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("TipoValor","TipoValor")]
             public String TipoValor { get; set; }
				
			} //Class ObtenerDetalleTransaccionSobre 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerEventosPorDepositario","ObtenerEventosPorDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerEventosPorDepositario : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string EventoId = "EventoId";
					public const string FechaEvento = "FechaEvento";
					public const string Mensaje = "Mensaje";
					public const string Valor = "Valor";
					public const string TipoEvento = "TipoEvento";
					public const string DepositarioId = "DepositarioId";
				}
				public enum FieldEnum : int
                {
					EventoId,
					FechaEvento,
					Mensaje,
					Valor,
					TipoEvento,
					DepositarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerEventosPorDepositario()
                {
                }
             [DataItemAttributeFieldName("EventoId","EventoId")]
             public Int64? EventoId { get; set; }
             [DataItemAttributeFieldName("FechaEvento","FechaEvento")]
             public DateTime? FechaEvento { get; set; }
             [DataItemAttributeFieldName("Mensaje","Mensaje")]
             public String Mensaje { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("TipoEvento","TipoEvento")]
             public String TipoEvento { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64? DepositarioId { get; set; }
				
			} //Class ObtenerEventosPorDepositario 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerExistenciasAValidarPorDepositario","ObtenerExistenciasAValidarPorDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerExistenciasAValidarPorDepositario : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerExistenciasAValidarPorDepositario()
                {
                }
				
			} //Class ObtenerExistenciasAValidarPorDepositario 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerExistenciasPorDepositario","ObtenerExistenciasPorDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerExistenciasPorDepositario : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerExistenciasPorDepositario()
                {
                }
				
			} //Class ObtenerExistenciasPorDepositario 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Functions.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerPorcentajeOcupacionBolsaPorContenedor","ObtenerPorcentajeOcupacionBolsaPorContenedor")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Function)] // Table, Functions,StoredProcedure,Function
			public class ObtenerPorcentajeOcupacionBolsaPorContenedor : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerPorcentajeOcupacionBolsaPorContenedor()
                {
                }
				
			} //Class ObtenerPorcentajeOcupacionBolsaPorContenedor 
			
} //namespace DefaultNamespace.Entities.Functions.Operacion
		namespace DefaultNamespace.Entities.Functions.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerPorcentajeOcupacionBolsaPorDepositario","ObtenerPorcentajeOcupacionBolsaPorDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Function)] // Table, Functions,StoredProcedure,Function
			public class ObtenerPorcentajeOcupacionBolsaPorDepositario : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerPorcentajeOcupacionBolsaPorDepositario()
                {
                }
				
			} //Class ObtenerPorcentajeOcupacionBolsaPorDepositario 
			
} //namespace DefaultNamespace.Entities.Functions.Operacion
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerTotalesGeneralesPorMonedaDepositario","ObtenerTotalesGeneralesPorMonedaDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerTotalesGeneralesPorMonedaDepositario : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerTotalesGeneralesPorMonedaDepositario()
                {
                }
				
			} //Class ObtenerTotalesGeneralesPorMonedaDepositario 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerTransaccionesPorDepositario","ObtenerTransaccionesPorDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerTransaccionesPorDepositario : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerTransaccionesPorDepositario()
                {
                }
				
			} //Class ObtenerTransaccionesPorDepositario 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerTransaccionesSobrePorDepositario","ObtenerTransaccionesSobrePorDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerTransaccionesSobrePorDepositario : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerTransaccionesSobrePorDepositario()
                {
                }
				
			} //Class ObtenerTransaccionesSobrePorDepositario 
			
} //namespace DefaultNamespace.Entities.Procedures.Operacion
		namespace DefaultNamespace.Entities.Procedures.Regionalizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Regionalizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerTextosLenguaje","ObtenerTextosLenguaje")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerTextosLenguaje : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerTextosLenguaje()
                {
                }
				
			} //Class ObtenerTextosLenguaje 
			
} //namespace DefaultNamespace.Entities.Procedures.Regionalizacion
		namespace DefaultNamespace.Entities.Procedures.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerRolesPorUsuario","ObtenerRolesPorUsuario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerRolesPorUsuario : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerRolesPorUsuario()
                {
                }
				
			} //Class ObtenerRolesPorUsuario 
			
} //namespace DefaultNamespace.Entities.Procedures.Seguridad
		namespace DefaultNamespace.Entities.Procedures.Sincronizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sincronizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerIdDestino","ObtenerIdDestino")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerIdDestino : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string DestinoId = "DestinoId";
				}
				public enum FieldEnum : int
                {
					DestinoId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerIdDestino()
                {
                }
             [DataItemAttributeFieldName("DestinoId","DestinoId")]
             public Int64? DestinoId { get; set; }
				
			} //Class ObtenerIdDestino 
			
} //namespace DefaultNamespace.Entities.Procedures.Sincronizacion
		namespace DefaultNamespace.Entities.Procedures.Sincronizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sincronizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerIdOrigen","ObtenerIdOrigen")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerIdOrigen : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string OrigenId = "OrigenId";
				}
				public enum FieldEnum : int
                {
					OrigenId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerIdOrigen()
                {
                }
             [DataItemAttributeFieldName("OrigenId","OrigenId")]
             public Int64? OrigenId { get; set; }
				
			} //Class ObtenerIdOrigen 
			
} //namespace DefaultNamespace.Entities.Procedures.Sincronizacion
