using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace DepositarioAdminWeb.Entities.Views.Operacion {
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
					public const string Cantidad = "Cantidad";
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
					Cantidad,
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
                public  VistaTransaccion(Int64 TipoId,Int64 DepositarioId,Int64 UsuarioId,Int64 UsuarioCuentaId,Int64 ContenedorId,Int64 SesionId,Int64 TurnoId,Int64 CierreDiarioId,Int64 Id,Int64 TransaccionId,Int64 DenominacionId,Int64 Cantidad,DateTime Fecha)
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
                    this.Cantidad = Cantidad;
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
             [DataItemAttributeFieldName("Cantidad","Cantidad")]
             public Int64 Cantidad { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class VistaTransaccion 
			
} //namespace DepositarioAdminWeb.Entities.Views.Operacion
//////////////////////////////////////////////////////////////////////////////////
		namespace DepositarioAdminWeb.Entities.Views.Valor {
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
			
} //namespace DepositarioAdminWeb.Entities.Views.Valor
//////////////////////////////////////////////////////////////////////////////////
