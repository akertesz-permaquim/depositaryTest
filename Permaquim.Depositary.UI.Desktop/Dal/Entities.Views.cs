using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace Permaquim.Depositario.Entities.Views.Operacion {
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
			
} //namespace Permaquim.Depositario.Entities.Views.Operacion
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositario.Entities.Views.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("VistaTransaccionMonedaDefaultSucursal","VistaTransaccionMonedaDefaultSucursal")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class VistaTransaccionMonedaDefaultSucursal : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string DepositarioId = "DepositarioId";
					public const string TransaccionId = "TransaccionId";
					public const string TotalAValidar = "TotalAValidar";
					public const string TotalValidado = "TotalValidado";
					public const string MonedaId = "MonedaId";
				}
				public enum FieldEnum : int
                {
					DepositarioId,
					TransaccionId,
					TotalAValidar,
					TotalValidado,
					MonedaId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public VistaTransaccionMonedaDefaultSucursal()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  VistaTransaccionMonedaDefaultSucursal(Int64 DepositarioId,Int64 TransaccionId,Double TotalAValidar,Double TotalValidado,Int64 MonedaId)
                {
                    this.DepositarioId = DepositarioId;
                    this.TransaccionId = TransaccionId;
                    this.TotalAValidar = TotalAValidar;
                    this.TotalValidado = TotalValidado;
                    this.MonedaId = MonedaId;
                }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64 TransaccionId { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double TotalAValidar { get; set; }
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public Double TotalValidado { get; set; }
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             public Int64 MonedaId { get; set; }
				
			} //Class VistaTransaccionMonedaDefaultSucursal 
			
} //namespace Permaquim.Depositario.Entities.Views.Operacion
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositario.Entities.Views.Reporte {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Reporte")]  // Database Schema Name
			[DataItemAttributeObjectName("CierresDiarios","CierresDiarios")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class CierresDiarios : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string CierreDiarioId = "CierreDiarioId";
					public const string DepositarioId = "DepositarioId";
					public const string SectorId = "SectorId";
					public const string SucursalId = "SucursalId";
					public const string EmpresaId = "EmpresaId";
					public const string UsuarioId = "UsuarioId";
					public const string Usuario = "Usuario";
					public const string Fecha = "Fecha";
					public const string CierreDiario = "CierreDiario";
					public const string Empresa = "Empresa";
					public const string Sucursal = "Sucursal";
					public const string Sector = "Sector";
					public const string Depositario = "Depositario";
					public const string CantidadTransacciones = "CantidadTransacciones";
					public const string TotalValidado = "TotalValidado";
					public const string TotalAValidar = "TotalAValidar";
					public const string Moneda = "Moneda";
					public const string CodigoCierreDiario = "CodigoCierreDiario";
				}
				public enum FieldEnum : int
                {
					CierreDiarioId,
					DepositarioId,
					SectorId,
					SucursalId,
					EmpresaId,
					UsuarioId,
					Usuario,
					Fecha,
					CierreDiario,
					Empresa,
					Sucursal,
					Sector,
					Depositario,
					CantidadTransacciones,
					TotalValidado,
					TotalAValidar,
					Moneda,
					CodigoCierreDiario
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public CierresDiarios()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  CierresDiarios(Int64 CierreDiarioId,Int64 DepositarioId,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 UsuarioId,String Usuario,DateTime Fecha,String CierreDiario,String Empresa,String Sucursal,String Sector,String Depositario,Int32 CantidadTransacciones,Double TotalValidado,Double TotalAValidar,String Moneda,String CodigoCierreDiario)
                {
                    this.CierreDiarioId = CierreDiarioId;
                    this.DepositarioId = DepositarioId;
                    this.SectorId = SectorId;
                    this.SucursalId = SucursalId;
                    this.EmpresaId = EmpresaId;
                    this.UsuarioId = UsuarioId;
                    this.Usuario = Usuario;
                    this.Fecha = Fecha;
                    this.CierreDiario = CierreDiario;
                    this.Empresa = Empresa;
                    this.Sucursal = Sucursal;
                    this.Sector = Sector;
                    this.Depositario = Depositario;
                    this.CantidadTransacciones = CantidadTransacciones;
                    this.TotalValidado = TotalValidado;
                    this.TotalAValidar = TotalAValidar;
                    this.Moneda = Moneda;
                    this.CodigoCierreDiario = CodigoCierreDiario;
                }
             [DataItemAttributeFieldName("CierreDiarioId","CierreDiarioId")]
             public Int64 CierreDiarioId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             public Int64 SucursalId { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             public Int64 EmpresaId { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("Usuario","Usuario")]
             public String Usuario { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("CierreDiario","CierreDiario")]
             public String CierreDiario { get; set; }
             [DataItemAttributeFieldName("Empresa","Empresa")]
             public String Empresa { get; set; }
             [DataItemAttributeFieldName("Sucursal","Sucursal")]
             public String Sucursal { get; set; }
             [DataItemAttributeFieldName("Sector","Sector")]
             public String Sector { get; set; }
             [DataItemAttributeFieldName("Depositario","Depositario")]
             public String Depositario { get; set; }
             [DataItemAttributeFieldName("CantidadTransacciones","CantidadTransacciones")]
             public Int32 CantidadTransacciones { get; set; }
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public Double TotalValidado { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double TotalAValidar { get; set; }
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("CodigoCierreDiario","CodigoCierreDiario")]
             public String CodigoCierreDiario { get; set; }
				
			} //Class CierresDiarios 
			
} //namespace Permaquim.Depositario.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositario.Entities.Views.Reporte {
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
					public const string DepositarioId = "DepositarioId";
					public const string SectorId = "SectorId";
					public const string SucursalId = "SucursalId";
					public const string EmpresaId = "EmpresaId";
					public const string Empresa = "Empresa";
					public const string Sucursal = "Sucursal";
					public const string Sector = "Sector";
					public const string Depositario = "Depositario";
					public const string CantidadTransacciones = "CantidadTransacciones";
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
					DepositarioId,
					SectorId,
					SucursalId,
					EmpresaId,
					Empresa,
					Sucursal,
					Sector,
					Depositario,
					CantidadTransacciones,
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
                public  Contenedores(Int64 ContenedorId,String Identificador,DateTime FechaApertura,DateTime FechaCierre,Int64 DepositarioId,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,String Empresa,String Sucursal,String Sector,String Depositario,Int32 CantidadTransacciones,Int64 CantidadBilletes,Int32 CantidadSobres,Double CantidadTotalDineroMonedaDefault)
                {
                    this.ContenedorId = ContenedorId;
                    this.Identificador = Identificador;
                    this.FechaApertura = FechaApertura;
                    this.FechaCierre = FechaCierre;
                    this.DepositarioId = DepositarioId;
                    this.SectorId = SectorId;
                    this.SucursalId = SucursalId;
                    this.EmpresaId = EmpresaId;
                    this.Empresa = Empresa;
                    this.Sucursal = Sucursal;
                    this.Sector = Sector;
                    this.Depositario = Depositario;
                    this.CantidadTransacciones = CantidadTransacciones;
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
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             public Int64 SucursalId { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             public Int64 EmpresaId { get; set; }
             [DataItemAttributeFieldName("Empresa","Empresa")]
             public String Empresa { get; set; }
             [DataItemAttributeFieldName("Sucursal","Sucursal")]
             public String Sucursal { get; set; }
             [DataItemAttributeFieldName("Sector","Sector")]
             public String Sector { get; set; }
             [DataItemAttributeFieldName("Depositario","Depositario")]
             public String Depositario { get; set; }
             [DataItemAttributeFieldName("CantidadTransacciones","CantidadTransacciones")]
             public Int32 CantidadTransacciones { get; set; }
             [DataItemAttributeFieldName("CantidadBilletes","CantidadBilletes")]
             public Int64 CantidadBilletes { get; set; }
             [DataItemAttributeFieldName("CantidadSobres","CantidadSobres")]
             public Int32 CantidadSobres { get; set; }
             [DataItemAttributeFieldName("CantidadTotalDineroMonedaDefault","CantidadTotalDineroMonedaDefault")]
             public Double CantidadTotalDineroMonedaDefault { get; set; }
				
			} //Class Contenedores 
			
} //namespace Permaquim.Depositario.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositario.Entities.Views.Reporte {
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
					public const string SucursalId = "SucursalId";
					public const string EmpresaId = "EmpresaId";
					public const string UsuarioId = "UsuarioId";
					public const string ContenedorId = "ContenedorId";
					public const string OrigenId = "OrigenId";
					public const string DepositarioId = "DepositarioId";
					public const string EsquemaDetalleTurnoId = "EsquemaDetalleTurnoId";
					public const string Empresa = "Empresa";
					public const string Sucursal = "Sucursal";
					public const string Sector = "Sector";
					public const string Turno = "Turno";
					public const string Contenedor = "Contenedor";
					public const string Usuario = "Usuario";
					public const string Origen = "Origen";
					public const string Moneda = "Moneda";
					public const string Denominacion = "Denominacion";
					public const string CodigoMoneda = "CodigoMoneda";
					public const string Depositario = "Depositario";
					public const string Total = "Total";
					public const string CodigoOperacion = "CodigoOperacion";
				}
				public enum FieldEnum : int
                {
					TransaccionId,
					FechaTransaccion,
					SectorId,
					SucursalId,
					EmpresaId,
					UsuarioId,
					ContenedorId,
					OrigenId,
					DepositarioId,
					EsquemaDetalleTurnoId,
					Empresa,
					Sucursal,
					Sector,
					Turno,
					Contenedor,
					Usuario,
					Origen,
					Moneda,
					Denominacion,
					CodigoMoneda,
					Depositario,
					Total,
					CodigoOperacion
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
                public  DetalleTransacciones(Int64 TransaccionId,DateTime FechaTransaccion,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 UsuarioId,Int64 ContenedorId,Int64 OrigenId,Int64 DepositarioId,Int64 EsquemaDetalleTurnoId,String Empresa,String Sucursal,String Sector,String Turno,String Contenedor,String Usuario,String Origen,String Moneda,String Denominacion,String CodigoMoneda,String Depositario,Decimal Total,String CodigoOperacion)
                {
                    this.TransaccionId = TransaccionId;
                    this.FechaTransaccion = FechaTransaccion;
                    this.SectorId = SectorId;
                    this.SucursalId = SucursalId;
                    this.EmpresaId = EmpresaId;
                    this.UsuarioId = UsuarioId;
                    this.ContenedorId = ContenedorId;
                    this.OrigenId = OrigenId;
                    this.DepositarioId = DepositarioId;
                    this.EsquemaDetalleTurnoId = EsquemaDetalleTurnoId;
                    this.Empresa = Empresa;
                    this.Sucursal = Sucursal;
                    this.Sector = Sector;
                    this.Turno = Turno;
                    this.Contenedor = Contenedor;
                    this.Usuario = Usuario;
                    this.Origen = Origen;
                    this.Moneda = Moneda;
                    this.Denominacion = Denominacion;
                    this.CodigoMoneda = CodigoMoneda;
                    this.Depositario = Depositario;
                    this.Total = Total;
                    this.CodigoOperacion = CodigoOperacion;
                }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64 TransaccionId { get; set; }
             [DataItemAttributeFieldName("FechaTransaccion","FechaTransaccion")]
             public DateTime FechaTransaccion { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             public Int64 SucursalId { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             public Int64 EmpresaId { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("ContenedorId","ContenedorId")]
             public Int64 ContenedorId { get; set; }
             [DataItemAttributeFieldName("OrigenId","OrigenId")]
             public Int64 OrigenId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("EsquemaDetalleTurnoId","EsquemaDetalleTurnoId")]
             public Int64 EsquemaDetalleTurnoId { get; set; }
             [DataItemAttributeFieldName("Empresa","Empresa")]
             public String Empresa { get; set; }
             [DataItemAttributeFieldName("Sucursal","Sucursal")]
             public String Sucursal { get; set; }
             [DataItemAttributeFieldName("Sector","Sector")]
             public String Sector { get; set; }
             [DataItemAttributeFieldName("Turno","Turno")]
             public String Turno { get; set; }
             [DataItemAttributeFieldName("Contenedor","Contenedor")]
             public String Contenedor { get; set; }
             [DataItemAttributeFieldName("Usuario","Usuario")]
             public String Usuario { get; set; }
             [DataItemAttributeFieldName("Origen","Origen")]
             public String Origen { get; set; }
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("Denominacion","Denominacion")]
             public String Denominacion { get; set; }
             [DataItemAttributeFieldName("CodigoMoneda","CodigoMoneda")]
             public String CodigoMoneda { get; set; }
             [DataItemAttributeFieldName("Depositario","Depositario")]
             public String Depositario { get; set; }
             [DataItemAttributeFieldName("Total","Total")]
             public Decimal Total { get; set; }
             [DataItemAttributeFieldName("CodigoOperacion","CodigoOperacion")]
             public String CodigoOperacion { get; set; }
				
			} //Class DetalleTransacciones 
			
} //namespace Permaquim.Depositario.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositario.Entities.Views.Reporte {
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
					public const string Cantidad = "Cantidad";
					public const string TipoValor = "TipoValor";
					public const string SectorId = "SectorId";
					public const string SucursalId = "SucursalId";
					public const string EmpresaId = "EmpresaId";
					public const string UsuarioId = "UsuarioId";
					public const string ContenedorId = "ContenedorId";
					public const string OrigenId = "OrigenId";
					public const string DepositarioId = "DepositarioId";
					public const string EsquemaDetalleTurnoId = "EsquemaDetalleTurnoId";
					public const string Empresa = "Empresa";
					public const string Sucursal = "Sucursal";
					public const string Sector = "Sector";
					public const string Turno = "Turno";
					public const string Contenedor = "Contenedor";
					public const string Usuario = "Usuario";
					public const string Origen = "Origen";
					public const string Depositario = "Depositario";
					public const string CodigoOperacion = "CodigoOperacion";
					public const string Moneda = "Moneda";
				}
				public enum FieldEnum : int
                {
					TransaccionId,
					FechaTransaccion,
					CodigoSobre,
					Cantidad,
					TipoValor,
					SectorId,
					SucursalId,
					EmpresaId,
					UsuarioId,
					ContenedorId,
					OrigenId,
					DepositarioId,
					EsquemaDetalleTurnoId,
					Empresa,
					Sucursal,
					Sector,
					Turno,
					Contenedor,
					Usuario,
					Origen,
					Depositario,
					CodigoOperacion,
					Moneda
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
                public  DetalleTransaccionesSobre(Int64 TransaccionId,DateTime FechaTransaccion,String CodigoSobre,Int64 Cantidad,String TipoValor,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 UsuarioId,Int64 ContenedorId,Int64 OrigenId,Int64 DepositarioId,Int64 EsquemaDetalleTurnoId,String Empresa,String Sucursal,String Sector,String Turno,String Contenedor,String Usuario,String Origen,String Depositario,String CodigoOperacion,String Moneda)
                {
                    this.TransaccionId = TransaccionId;
                    this.FechaTransaccion = FechaTransaccion;
                    this.CodigoSobre = CodigoSobre;
                    this.Cantidad = Cantidad;
                    this.TipoValor = TipoValor;
                    this.SectorId = SectorId;
                    this.SucursalId = SucursalId;
                    this.EmpresaId = EmpresaId;
                    this.UsuarioId = UsuarioId;
                    this.ContenedorId = ContenedorId;
                    this.OrigenId = OrigenId;
                    this.DepositarioId = DepositarioId;
                    this.EsquemaDetalleTurnoId = EsquemaDetalleTurnoId;
                    this.Empresa = Empresa;
                    this.Sucursal = Sucursal;
                    this.Sector = Sector;
                    this.Turno = Turno;
                    this.Contenedor = Contenedor;
                    this.Usuario = Usuario;
                    this.Origen = Origen;
                    this.Depositario = Depositario;
                    this.CodigoOperacion = CodigoOperacion;
                    this.Moneda = Moneda;
                }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             public Int64 TransaccionId { get; set; }
             [DataItemAttributeFieldName("FechaTransaccion","FechaTransaccion")]
             public DateTime FechaTransaccion { get; set; }
             [DataItemAttributeFieldName("CodigoSobre","CodigoSobre")]
             public String CodigoSobre { get; set; }
             [DataItemAttributeFieldName("Cantidad","Cantidad")]
             public Int64 Cantidad { get; set; }
             [DataItemAttributeFieldName("TipoValor","TipoValor")]
             public String TipoValor { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             public Int64 SucursalId { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             public Int64 EmpresaId { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("ContenedorId","ContenedorId")]
             public Int64 ContenedorId { get; set; }
             [DataItemAttributeFieldName("OrigenId","OrigenId")]
             public Int64 OrigenId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("EsquemaDetalleTurnoId","EsquemaDetalleTurnoId")]
             public Int64 EsquemaDetalleTurnoId { get; set; }
             [DataItemAttributeFieldName("Empresa","Empresa")]
             public String Empresa { get; set; }
             [DataItemAttributeFieldName("Sucursal","Sucursal")]
             public String Sucursal { get; set; }
             [DataItemAttributeFieldName("Sector","Sector")]
             public String Sector { get; set; }
             [DataItemAttributeFieldName("Turno","Turno")]
             public String Turno { get; set; }
             [DataItemAttributeFieldName("Contenedor","Contenedor")]
             public String Contenedor { get; set; }
             [DataItemAttributeFieldName("Usuario","Usuario")]
             public String Usuario { get; set; }
             [DataItemAttributeFieldName("Origen","Origen")]
             public String Origen { get; set; }
             [DataItemAttributeFieldName("Depositario","Depositario")]
             public String Depositario { get; set; }
             [DataItemAttributeFieldName("CodigoOperacion","CodigoOperacion")]
             public String CodigoOperacion { get; set; }
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
				
			} //Class DetalleTransaccionesSobre 
			
} //namespace Permaquim.Depositario.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositario.Entities.Views.Reporte {
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
					public const string OrigenId = "OrigenId";
					public const string Origen = "Origen";
					public const string CodigoOperacion = "CodigoOperacion";
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
					DepositarioId,
					OrigenId,
					Origen,
					CodigoOperacion
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
                public  Transacciones(Int64 TransaccionId,Int64 TransaccionTipoId,String TransaccionTipo,String Usuario,DateTime FechaTransaccion,DateTime FechaRetiroBolsa,String Moneda,Double TotalValidado,Double TotalAValidar,String Empresa,String Sucursal,String Sector,String Turno,String Depositario,String Contenedor,Int64 ContenedorId,Int64 EsquemaDetalleTurnoId,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 UsuarioId,Int64 DepositarioId,Int64 OrigenId,String Origen,String CodigoOperacion)
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
                    this.OrigenId = OrigenId;
                    this.Origen = Origen;
                    this.CodigoOperacion = CodigoOperacion;
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
             [DataItemAttributeFieldName("OrigenId","OrigenId")]
             public Int64 OrigenId { get; set; }
             [DataItemAttributeFieldName("Origen","Origen")]
             public String Origen { get; set; }
             [DataItemAttributeFieldName("CodigoOperacion","CodigoOperacion")]
             public String CodigoOperacion { get; set; }
				
			} //Class Transacciones 
			
} //namespace Permaquim.Depositario.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositario.Entities.Views.Reporte {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Reporte")]  // Database Schema Name
			[DataItemAttributeObjectName("Turnos","Turnos")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.View)] // Table, View,StoredProcedure,Function
			public class Turnos : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string TurnoId = "TurnoId";
					public const string DepositarioId = "DepositarioId";
					public const string SectorId = "SectorId";
					public const string SucursalId = "SucursalId";
					public const string EmpresaId = "EmpresaId";
					public const string EsquemaDetalleTurnoId = "EsquemaDetalleTurnoId";
					public const string FechaApertura = "FechaApertura";
					public const string FechaCierre = "FechaCierre";
					public const string Fecha = "Fecha";
					public const string Secuencia = "Secuencia";
					public const string Turno = "Turno";
					public const string CierreDiario = "CierreDiario";
					public const string Empresa = "Empresa";
					public const string Sucursal = "Sucursal";
					public const string Sector = "Sector";
					public const string Depositario = "Depositario";
					public const string CantidadTransacciones = "CantidadTransacciones";
					public const string TotalValidado = "TotalValidado";
					public const string TotalAValidar = "TotalAValidar";
					public const string Moneda = "Moneda";
					public const string CodigoTurno = "CodigoTurno";
				}
				public enum FieldEnum : int
                {
					TurnoId,
					DepositarioId,
					SectorId,
					SucursalId,
					EmpresaId,
					EsquemaDetalleTurnoId,
					FechaApertura,
					FechaCierre,
					Fecha,
					Secuencia,
					Turno,
					CierreDiario,
					Empresa,
					Sucursal,
					Sector,
					Depositario,
					CantidadTransacciones,
					TotalValidado,
					TotalAValidar,
					Moneda,
					CodigoTurno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Turnos()
                {
                }
	               /// <summary>
                /// Constructor with Parameters 
	               /// <summary>
                public  Turnos(Int64 TurnoId,Int64 DepositarioId,Int64 SectorId,Int64 SucursalId,Int64 EmpresaId,Int64 EsquemaDetalleTurnoId,DateTime FechaApertura,DateTime FechaCierre,DateTime Fecha,Int32 Secuencia,String Turno,String CierreDiario,String Empresa,String Sucursal,String Sector,String Depositario,Int32 CantidadTransacciones,Double TotalValidado,Double TotalAValidar,String Moneda,String CodigoTurno)
                {
                    this.TurnoId = TurnoId;
                    this.DepositarioId = DepositarioId;
                    this.SectorId = SectorId;
                    this.SucursalId = SucursalId;
                    this.EmpresaId = EmpresaId;
                    this.EsquemaDetalleTurnoId = EsquemaDetalleTurnoId;
                    this.FechaApertura = FechaApertura;
                    this.FechaCierre = FechaCierre;
                    this.Fecha = Fecha;
                    this.Secuencia = Secuencia;
                    this.Turno = Turno;
                    this.CierreDiario = CierreDiario;
                    this.Empresa = Empresa;
                    this.Sucursal = Sucursal;
                    this.Sector = Sector;
                    this.Depositario = Depositario;
                    this.CantidadTransacciones = CantidadTransacciones;
                    this.TotalValidado = TotalValidado;
                    this.TotalAValidar = TotalAValidar;
                    this.Moneda = Moneda;
                    this.CodigoTurno = CodigoTurno;
                }
             [DataItemAttributeFieldName("TurnoId","TurnoId")]
             public Int64 TurnoId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             public Int64 SucursalId { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             public Int64 EmpresaId { get; set; }
             [DataItemAttributeFieldName("EsquemaDetalleTurnoId","EsquemaDetalleTurnoId")]
             public Int64 EsquemaDetalleTurnoId { get; set; }
             [DataItemAttributeFieldName("FechaApertura","FechaApertura")]
             public DateTime FechaApertura { get; set; }
             [DataItemAttributeFieldName("FechaCierre","FechaCierre")]
             public DateTime FechaCierre { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("Secuencia","Secuencia")]
             public Int32 Secuencia { get; set; }
             [DataItemAttributeFieldName("Turno","Turno")]
             public String Turno { get; set; }
             [DataItemAttributeFieldName("CierreDiario","CierreDiario")]
             public String CierreDiario { get; set; }
             [DataItemAttributeFieldName("Empresa","Empresa")]
             public String Empresa { get; set; }
             [DataItemAttributeFieldName("Sucursal","Sucursal")]
             public String Sucursal { get; set; }
             [DataItemAttributeFieldName("Sector","Sector")]
             public String Sector { get; set; }
             [DataItemAttributeFieldName("Depositario","Depositario")]
             public String Depositario { get; set; }
             [DataItemAttributeFieldName("CantidadTransacciones","CantidadTransacciones")]
             public Int32 CantidadTransacciones { get; set; }
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public Double TotalValidado { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double TotalAValidar { get; set; }
             [DataItemAttributeFieldName("Moneda","Moneda")]
             public String Moneda { get; set; }
             [DataItemAttributeFieldName("CodigoTurno","CodigoTurno")]
             public String CodigoTurno { get; set; }
				
			} //Class Turnos 
			
} //namespace Permaquim.Depositario.Entities.Views.Reporte
//////////////////////////////////////////////////////////////////////////////////
		namespace Permaquim.Depositario.Entities.Views.Valor {
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
			
} //namespace Permaquim.Depositario.Entities.Views.Valor
//////////////////////////////////////////////////////////////////////////////////
