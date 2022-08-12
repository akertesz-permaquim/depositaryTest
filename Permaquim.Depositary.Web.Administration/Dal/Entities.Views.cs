using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace Permaquim.Depositary.Entities.Views.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("VistaTransaccion","VistaTransaccion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class VistaTransaccion : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string TipoId = "TipoId";
					public const string DepositarioId = "DepositarioId";
					public const string UsuarioId = "UsuarioId";
					public const string UsuarioCuentaId = "UsuarioCuentaId";
					public const string ContenedorId = "ContenedorId";
					public const string SesionId = "SesionId";
					public const string TurnoId = "TurnoId";
					public const string CierreDiarioId = "CierreDiarioId";
					public const string Id = "Id";
					public const string TransaccionId = "TransaccionId";
					public const string DenominacionId = "DenominacionId";
					public const string CantidadUnidades = "CantidadUnidades";
					public const string Fecha = "Fecha";
				}
				public enum FieldEnum : int
                {
					TipoId,
					DepositarioId,
					UsuarioId,
					UsuarioCuentaId,
					ContenedorId,
					SesionId,
					TurnoId,
					CierreDiarioId,
					Id,
					TransaccionId,
					DenominacionId,
					CantidadUnidades,
					Fecha
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public VistaTransaccion()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  VistaTransaccion(Int64 TipoId,Int64 DepositarioId,Int64 UsuarioId,Int64 UsuarioCuentaId,Int64 ContenedorId,Int64 SesionId,Int64 TurnoId,Int64 CierreDiarioId,Int64 Id,Int64 TransaccionId,Int64 DenominacionId,Int64 CantidadUnidades,DateTime Fecha)
                {
                    this.TipoId = TipoId;
                    this.DepositarioId = DepositarioId;
                    this.UsuarioId = UsuarioId;
                    this.UsuarioCuentaId = UsuarioCuentaId;
                    this.ContenedorId = ContenedorId;
                    this.SesionId = SesionId;
                    this.TurnoId = TurnoId;
                    this.CierreDiarioId = CierreDiarioId;
                    this.Id = Id;
                    this.TransaccionId = TransaccionId;
                    this.DenominacionId = DenominacionId;
                    this.CantidadUnidades = CantidadUnidades;
                    this.Fecha = Fecha;
                }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             public Int64 TipoId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("UsuarioCuentaId","UsuarioCuentaId")]
             public Int64 UsuarioCuentaId { get; set; }
             [DataItemAttributeFieldName("ContenedorId","ContenedorId")]
             public Int64 ContenedorId { get; set; }
             [DataItemAttributeFieldName("SesionId","SesionId")]
             public Int64 SesionId { get; set; }
             [DataItemAttributeFieldName("TurnoId","TurnoId")]
             public Int64 TurnoId { get; set; }
             [DataItemAttributeFieldName("CierreDiarioId","CierreDiarioId")]
             public Int64 CierreDiarioId { get; set; }
             [DataItemAttributeFieldName("Id","Id")]
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64 TransaccionId { get; set; }
             [DataItemAttributeFieldName("DenominacionId","DenominacionId")]
             public Int64 DenominacionId { get; set; }
             [DataItemAttributeFieldName("CantidadUnidades","CantidadUnidades")]
             public Int64 CantidadUnidades { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class VistaTransaccion 
			
} //namespace Permaquim.Depositary.Entities.Views.Operacion
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositary.Entities.Views.Reporte {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Reporte")]  // Database Schema Name
			[DataItemAttributeObjectName("Contenedores","Contenedores")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class Contenedores : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string ContenedorId = "ContenedorId";
					public const string Identificador = "Identificador";
					public const string FechaApertura = "FechaApertura";
					public const string FechaCierre = "FechaCierre";
					public const string Depositario = "Depositario";
					public const string DepositarioId = "DepositarioId";
					public const string CantidadTransacciones = "CantidadTransacciones";
					public const string SectorId = "SectorId";
					public const string CantidadBilletes = "CantidadBilletes";
					public const string CantidadSobres = "CantidadSobres";
					public const string CantidadTotalDineroMonedaDefault = "CantidadTotalDineroMonedaDefault";
				}
				public enum FieldEnum : int
                {
					ContenedorId,
					Identificador,
					FechaApertura,
					FechaCierre,
					Depositario,
					DepositarioId,
					CantidadTransacciones,
					SectorId,
					CantidadBilletes,
					CantidadSobres,
					CantidadTotalDineroMonedaDefault
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Contenedores()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  Contenedores(Int64 ContenedorId,String Identificador,DateTime FechaApertura,DateTime FechaCierre,String Depositario,Int64 DepositarioId,Int32 CantidadTransacciones,Int64 SectorId,Int64 CantidadBilletes,Int32 CantidadSobres,Double CantidadTotalDineroMonedaDefault)
                {
                    this.ContenedorId = ContenedorId;
                    this.Identificador = Identificador;
                    this.FechaApertura = FechaApertura;
                    this.FechaCierre = FechaCierre;
                    this.Depositario = Depositario;
                    this.DepositarioId = DepositarioId;
                    this.CantidadTransacciones = CantidadTransacciones;
                    this.SectorId = SectorId;
                    this.CantidadBilletes = CantidadBilletes;
                    this.CantidadSobres = CantidadSobres;
                    this.CantidadTotalDineroMonedaDefault = CantidadTotalDineroMonedaDefault;
                }
             [DataItemAttributeFieldName("ContenedorId","ContenedorId")]
             public Int64 ContenedorId { get; set; }
             [DataItemAttributeFieldName("Identificador","Identificador")]
             public String Identificador { get; set; }
             [DataItemAttributeFieldName("FechaApertura","FechaApertura")]
             public DateTime FechaApertura { get; set; }
             [DataItemAttributeFieldName("FechaCierre","FechaCierre")]
             public DateTime FechaCierre { get; set; }
             [DataItemAttributeFieldName("Depositario","Depositario")]
             public String Depositario { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("CantidadTransacciones","CantidadTransacciones")]
             public Int32 CantidadTransacciones { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("CantidadBilletes","CantidadBilletes")]
             public Int64 CantidadBilletes { get; set; }
             [DataItemAttributeFieldName("CantidadSobres","CantidadSobres")]
             public Int32 CantidadSobres { get; set; }
             [DataItemAttributeFieldName("CantidadTotalDineroMonedaDefault","CantidadTotalDineroMonedaDefault")]
             public Double CantidadTotalDineroMonedaDefault { get; set; }
				
			} //Class Contenedores 
			
} //namespace Permaquim.Depositary.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositary.Entities.Views.Reporte {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Reporte")]  // Database Schema Name
			[DataItemAttributeObjectName("DetalleTransacciones","DetalleTransacciones")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class DetalleTransacciones : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string TransaccionId = "TransaccionId";
					public const string FechaTransaccion = "FechaTransaccion";
					public const string SectorId = "SectorId";
					public const string Moneda = "Moneda";
					public const string Denominacion = "Denominacion";
					public const string CodigoMoneda = "CodigoMoneda";
					public const string DepositarioId = "DepositarioId";
					public const string Depositario = "Depositario";
					public const string Total = "Total";
				}
				public enum FieldEnum : int
                {
					TransaccionId,
					FechaTransaccion,
					SectorId,
					Moneda,
					Denominacion,
					CodigoMoneda,
					DepositarioId,
					Depositario,
					Total
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public DetalleTransacciones()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  DetalleTransacciones(Int64 TransaccionId,DateTime FechaTransaccion,Int64 SectorId,String Moneda,String Denominacion,String CodigoMoneda,Int64 DepositarioId,String Depositario,Decimal Total)
                {
                    this.TransaccionId = TransaccionId;
                    this.FechaTransaccion = FechaTransaccion;
                    this.SectorId = SectorId;
                    this.Moneda = Moneda;
                    this.Denominacion = Denominacion;
                    this.CodigoMoneda = CodigoMoneda;
                    this.DepositarioId = DepositarioId;
                    this.Depositario = Depositario;
                    this.Total = Total;
                }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64 TransaccionId { get; set; }
             [DataItemAttributeFieldName("FechaTransaccion","FechaTransaccion")]
             public DateTime FechaTransaccion { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("Denominacion","Denominacion")]
             public String Denominacion { get; set; }
             [DataItemAttributeFieldName("CodigoMoneda","CodigoMoneda")]
             public String CodigoMoneda { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("Depositario","Depositario")]
             public String Depositario { get; set; }
             [DataItemAttributeFieldName("Total","Total")]
             public Decimal Total { get; set; }
				
			} //Class DetalleTransacciones 
			
} //namespace Permaquim.Depositary.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositary.Entities.Views.Reporte {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Reporte")]  // Database Schema Name
			[DataItemAttributeObjectName("DetalleTransaccionesSobre","DetalleTransaccionesSobre")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class DetalleTransaccionesSobre : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string TransaccionId = "TransaccionId";
					public const string FechaTransaccion = "FechaTransaccion";
					public const string CodigoSobre = "CodigoSobre";
					public const string UsuarioId = "UsuarioId";
					public const string ContenedorId = "ContenedorId";
					public const string Cantidad = "Cantidad";
					public const string Depositario = "Depositario";
					public const string TipoValor = "TipoValor";
					public const string TurnoId = "TurnoId";
					public const string SectorId = "SectorId";
					public const string DepositarioId = "DepositarioId";
				}
				public enum FieldEnum : int
                {
					TransaccionId,
					FechaTransaccion,
					CodigoSobre,
					UsuarioId,
					ContenedorId,
					Cantidad,
					Depositario,
					TipoValor,
					TurnoId,
					SectorId,
					DepositarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public DetalleTransaccionesSobre()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  DetalleTransaccionesSobre(Int64 TransaccionId,DateTime FechaTransaccion,String CodigoSobre,Int64 UsuarioId,Int64 ContenedorId,Int64 Cantidad,String Depositario,String TipoValor,Int64 TurnoId,Int64 SectorId,Int64 DepositarioId)
                {
                    this.TransaccionId = TransaccionId;
                    this.FechaTransaccion = FechaTransaccion;
                    this.CodigoSobre = CodigoSobre;
                    this.UsuarioId = UsuarioId;
                    this.ContenedorId = ContenedorId;
                    this.Cantidad = Cantidad;
                    this.Depositario = Depositario;
                    this.TipoValor = TipoValor;
                    this.TurnoId = TurnoId;
                    this.SectorId = SectorId;
                    this.DepositarioId = DepositarioId;
                }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64 TransaccionId { get; set; }
             [DataItemAttributeFieldName("FechaTransaccion","FechaTransaccion")]
             public DateTime FechaTransaccion { get; set; }
             [DataItemAttributeFieldName("CodigoSobre","CodigoSobre")]
             public String CodigoSobre { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("ContenedorId","ContenedorId")]
             public Int64 ContenedorId { get; set; }
             [DataItemAttributeFieldName("Cantidad","Cantidad")]
             public Int64 Cantidad { get; set; }
             [DataItemAttributeFieldName("Depositario","Depositario")]
             public String Depositario { get; set; }
             [DataItemAttributeFieldName("TipoValor","TipoValor")]
             public String TipoValor { get; set; }
             [DataItemAttributeFieldName("TurnoId","TurnoId")]
             public Int64 TurnoId { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
				
			} //Class DetalleTransaccionesSobre 
			
} //namespace Permaquim.Depositary.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositary.Entities.Views.Reporte {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Reporte")]  // Database Schema Name
			[DataItemAttributeObjectName("Transacciones","Transacciones")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class Transacciones : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string TransaccionId = "TransaccionId";
					public const string TransaccionTipoId = "TransaccionTipoId";
					public const string TransaccionTipo = "TransaccionTipo";
					public const string Usuario = "Usuario";
					public const string FechaTransaccion = "FechaTransaccion";
					public const string FechaRetiroBolsa = "FechaRetiroBolsa";
					public const string Moneda = "Moneda";
					public const string TotalValidado = "TotalValidado";
					public const string TotalAValidar = "TotalAValidar";
					public const string Empresa = "Empresa";
					public const string Sucursal = "Sucursal";
					public const string Sector = "Sector";
					public const string Turno = "Turno";
					public const string Depositario = "Depositario";
					public const string Contenedor = "Contenedor";
					public const string ContenedorId = "ContenedorId";
					public const string EsquemaDetalleTurnoId = "EsquemaDetalleTurnoId";
					public const string SectorId = "SectorId";
					public const string SucursalId = "SucursalId";
					public const string EmpresaId = "EmpresaId";
					public const string UsuarioId = "UsuarioId";
					public const string DepositarioId = "DepositarioId";
				}
				public enum FieldEnum : int
                {
					TransaccionId,
					TransaccionTipoId,
					TransaccionTipo,
					Usuario,
					FechaTransaccion,
					FechaRetiroBolsa,
					Moneda,
					TotalValidado,
					TotalAValidar,
					Empresa,
					Sucursal,
					Sector,
					Turno,
					Depositario,
					Contenedor,
					ContenedorId,
					EsquemaDetalleTurnoId,
					SectorId,
					SucursalId,
					EmpresaId,
					UsuarioId,
					DepositarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Transacciones()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  Transacciones(Int64 TransaccionId,Int64 TransaccionTipoId,String TransaccionTipo,String Usuario,DateTime FechaTransaccion,DateTime FechaRetiroBolsa,String Moneda,Double TotalValidado,Double TotalAValidar,String Empresa,String Sucursal,String Sector,String Turno,String Depositario,String Contenedor,Int64 ContenedorId,Int64 EsquemaDetalleTurnoId,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 UsuarioId,Int64 DepositarioId)
                {
                    this.TransaccionId = TransaccionId;
                    this.TransaccionTipoId = TransaccionTipoId;
                    this.TransaccionTipo = TransaccionTipo;
                    this.Usuario = Usuario;
                    this.FechaTransaccion = FechaTransaccion;
                    this.FechaRetiroBolsa = FechaRetiroBolsa;
                    this.Moneda = Moneda;
                    this.TotalValidado = TotalValidado;
                    this.TotalAValidar = TotalAValidar;
                    this.Empresa = Empresa;
                    this.Sucursal = Sucursal;
                    this.Sector = Sector;
                    this.Turno = Turno;
                    this.Depositario = Depositario;
                    this.Contenedor = Contenedor;
                    this.ContenedorId = ContenedorId;
                    this.EsquemaDetalleTurnoId = EsquemaDetalleTurnoId;
                    this.SectorId = SectorId;
                    this.SucursalId = SucursalId;
                    this.EmpresaId = EmpresaId;
                    this.UsuarioId = UsuarioId;
                    this.DepositarioId = DepositarioId;
                }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64 TransaccionId { get; set; }
             [DataItemAttributeFieldName("TransaccionTipoId","TransaccionTipoId")]
             public Int64 TransaccionTipoId { get; set; }
             [DataItemAttributeFieldName("TransaccionTipo","TransaccionTipo")]
             public String TransaccionTipo { get; set; }
             [DataItemAttributeFieldName("Usuario","Usuario")]
             public String Usuario { get; set; }
             [DataItemAttributeFieldName("FechaTransaccion","FechaTransaccion")]
             public DateTime FechaTransaccion { get; set; }
             [DataItemAttributeFieldName("FechaRetiroBolsa","FechaRetiroBolsa")]
             public DateTime FechaRetiroBolsa { get; set; }
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public Double TotalValidado { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double TotalAValidar { get; set; }
             [DataItemAttributeFieldName("Empresa","Empresa")]
             public String Empresa { get; set; }
             [DataItemAttributeFieldName("Sucursal","Sucursal")]
             public String Sucursal { get; set; }
             [DataItemAttributeFieldName("Sector","Sector")]
             public String Sector { get; set; }
             [DataItemAttributeFieldName("Turno","Turno")]
             public String Turno { get; set; }
             [DataItemAttributeFieldName("Depositario","Depositario")]
             public String Depositario { get; set; }
             [DataItemAttributeFieldName("Contenedor","Contenedor")]
             public String Contenedor { get; set; }
             [DataItemAttributeFieldName("ContenedorId","ContenedorId")]
             public Int64 ContenedorId { get; set; }
             [DataItemAttributeFieldName("EsquemaDetalleTurnoId","EsquemaDetalleTurnoId")]
             public Int64 EsquemaDetalleTurnoId { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             public Int64 SucursalId { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             public Int64 EmpresaId { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
				
			} //Class Transacciones 
			
} //namespace Permaquim.Depositary.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositary.Entities.Views.Valor {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Valor")]  // Database Schema Name
			[DataItemAttributeObjectName("VistaDenominacion","VistaDenominacion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class VistaDenominacion : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string Nombre = "Nombre";
					public const string Moneda = "Moneda";
					public const string Denominacion = "Denominacion";
					public const string Unidades = "Unidades";
				}
				public enum FieldEnum : int
                {
					Nombre,
					Moneda,
					Denominacion,
					Unidades
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public VistaDenominacion()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  VistaDenominacion(String Nombre,String Moneda,String Denominacion,Decimal Unidades)
                {
                    this.Nombre = Nombre;
                    this.Moneda = Moneda;
                    this.Denominacion = Denominacion;
                    this.Unidades = Unidades;
                }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("Denominacion","Denominacion")]
             public String Denominacion { get; set; }
             [DataItemAttributeFieldName("Unidades","Unidades")]
             public Decimal Unidades { get; set; }
				
			} //Class VistaDenominacion 
			
} //namespace Permaquim.Depositary.Entities.Views.Valor
//////////////////////////////////////////////////////////////////////////////////
