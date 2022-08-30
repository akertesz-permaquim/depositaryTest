using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace DepositaryWebApi.Entities.Procedures.Dispositivo {
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
			
} //namespace DepositaryWebApi.Entities.Procedures.Dispositivo
		namespace DepositaryWebApi.Entities.Procedures.Operacion {
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
			
} //namespace DepositaryWebApi.Entities.Procedures.Operacion
		namespace DepositaryWebApi.Entities.Procedures.Operacion {
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
			
} //namespace DepositaryWebApi.Entities.Procedures.Operacion
		namespace DepositaryWebApi.Entities.Procedures.Operacion {
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
			
} //namespace DepositaryWebApi.Entities.Procedures.Operacion
		namespace DepositaryWebApi.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerTransaccionesPorDepositario","ObtenerTransaccionesPorDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerTransaccionesPorDepositario : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string TransaccionId = "TransaccionId";
					public const string FechaTransaccion = "FechaTransaccion";
					public const string TipoTransaccion = "TipoTransaccion";
					public const string UsuarioTransaccion = "UsuarioTransaccion";
					public const string UsuarioCuenta = "UsuarioCuenta";
					public const string Cuenta = "Cuenta";
					public const string Banco = "Banco";
					public const string Contenedor = "Contenedor";
					public const string TotalValidado = "TotalValidado";
					public const string DepositarioId = "DepositarioId";
				}
				public enum FieldEnum : int
                {
					TransaccionId,
					FechaTransaccion,
					TipoTransaccion,
					UsuarioTransaccion,
					UsuarioCuenta,
					Cuenta,
					Banco,
					Contenedor,
					TotalValidado,
					DepositarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerTransaccionesPorDepositario()
                {
                }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64? TransaccionId { get; set; }
             [DataItemAttributeFieldName("FechaTransaccion","FechaTransaccion")]
             public DateTime? FechaTransaccion { get; set; }
             [DataItemAttributeFieldName("TipoTransaccion","TipoTransaccion")]
             public String TipoTransaccion { get; set; }
             [DataItemAttributeFieldName("UsuarioTransaccion","UsuarioTransaccion")]
             public String UsuarioTransaccion { get; set; }
             [DataItemAttributeFieldName("UsuarioCuenta","UsuarioCuenta")]
             public String UsuarioCuenta { get; set; }
             [DataItemAttributeFieldName("Cuenta","Cuenta")]
             public String Cuenta { get; set; }
             [DataItemAttributeFieldName("Banco","Banco")]
             public String Banco { get; set; }
             [DataItemAttributeFieldName("Contenedor","Contenedor")]
             public String Contenedor { get; set; }
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public String TotalValidado { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64? DepositarioId { get; set; }
				
			} //Class ObtenerTransaccionesPorDepositario 
			
} //namespace DepositaryWebApi.Entities.Procedures.Operacion
		namespace DepositaryWebApi.Entities.Procedures.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerTransaccionesSobrePorDepositario","ObtenerTransaccionesSobrePorDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerTransaccionesSobrePorDepositario : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string TransaccionId = "TransaccionId";
					public const string TransaccionSobreId = "TransaccionSobreId";
					public const string FechaTransaccion = "FechaTransaccion";
					public const string FechaTransaccionSobre = "FechaTransaccionSobre";
					public const string TipoTransaccion = "TipoTransaccion";
					public const string UsuarioTransaccion = "UsuarioTransaccion";
					public const string UsuarioCuenta = "UsuarioCuenta";
					public const string Cuenta = "Cuenta";
					public const string Banco = "Banco";
					public const string Contenedor = "Contenedor";
					public const string CodigoSobre = "CodigoSobre";
					public const string DepositarioId = "DepositarioId";
					public const string TotalAValidar = "TotalAValidar";
				}
				public enum FieldEnum : int
                {
					TransaccionId,
					TransaccionSobreId,
					FechaTransaccion,
					FechaTransaccionSobre,
					TipoTransaccion,
					UsuarioTransaccion,
					UsuarioCuenta,
					Cuenta,
					Banco,
					Contenedor,
					CodigoSobre,
					DepositarioId,
					TotalAValidar
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerTransaccionesSobrePorDepositario()
                {
                }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64? TransaccionId { get; set; }
             [DataItemAttributeFieldName("TransaccionSobreId","TransaccionSobreId")]
             public Int64? TransaccionSobreId { get; set; }
             [DataItemAttributeFieldName("FechaTransaccion","FechaTransaccion")]
             public DateTime? FechaTransaccion { get; set; }
             [DataItemAttributeFieldName("FechaTransaccionSobre","FechaTransaccionSobre")]
             public DateTime? FechaTransaccionSobre { get; set; }
             [DataItemAttributeFieldName("TipoTransaccion","TipoTransaccion")]
             public String TipoTransaccion { get; set; }
             [DataItemAttributeFieldName("UsuarioTransaccion","UsuarioTransaccion")]
             public String UsuarioTransaccion { get; set; }
             [DataItemAttributeFieldName("UsuarioCuenta","UsuarioCuenta")]
             public String UsuarioCuenta { get; set; }
             [DataItemAttributeFieldName("Cuenta","Cuenta")]
             public String Cuenta { get; set; }
             [DataItemAttributeFieldName("Banco","Banco")]
             public String Banco { get; set; }
             [DataItemAttributeFieldName("Contenedor","Contenedor")]
             public String Contenedor { get; set; }
             [DataItemAttributeFieldName("CodigoSobre","CodigoSobre")]
             public String CodigoSobre { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64? DepositarioId { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double? TotalAValidar { get; set; }
				
			} //Class ObtenerTransaccionesSobrePorDepositario 
			
} //namespace DepositaryWebApi.Entities.Procedures.Operacion
		namespace DepositaryWebApi.Entities.Procedures.Seguridad {
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
			
} //namespace DepositaryWebApi.Entities.Procedures.Seguridad
