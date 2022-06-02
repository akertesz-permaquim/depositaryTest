using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace DepositarioAdminWeb.Entities.Relations.Aplicacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Aplicacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Configuracion","Configuracion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Configuracion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string AplicacionId = "AplicacionId";
					public const string Clave = "Clave";
					public const string Valor = "Valor";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					AplicacionId,
					Clave,
					Valor,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Configuracion()
                {
                }
                public  Configuracion(DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId,String Clave,String Valor,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.AplicacionId = AplicacionId;
                    this.Clave = Clave;
                    this.Valor = Valor;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DepositarioAdminWeb.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("Clave","Clave")]
             public String Clave { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class Configuracion 
} //namespace DepositarioAdminWeb.Entities.Relations.Aplicacion
		namespace DepositarioAdminWeb.Entities.Relations.Auditoria {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Auditoria")]  // Database Schema Name
			[DataItemAttributeObjectName("Log","Log")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Log : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string AplicacionId = "AplicacionId";
					public const string Fecha = "Fecha";
					public const string Descripcion = "Descripcion";
					public const string Detalle = "Detalle";
					public const string Modulo = "Modulo";
					public const string Metodo = "Metodo";
					public const string UsuarioId = "UsuarioId";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					AplicacionId,
					Fecha,
					Descripcion,
					Detalle,
					Modulo,
					Metodo,
					UsuarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Log()
                {
                }
                public  Log(DepositarioAdminWeb.Entities.Relations.Auditoria.TipoLog TipoId,DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId,DateTime Fecha,String Descripcion,String Detalle,String Modulo,String Metodo,Int64 UsuarioId)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.AplicacionId = AplicacionId;
                    this.Fecha = Fecha;
                    this.Descripcion = Descripcion;
                    this.Detalle = Detalle;
                    this.Modulo = Modulo;
                    this.Metodo = Metodo;
                    this.UsuarioId = UsuarioId;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoLog")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Auditoria.TipoLog TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DepositarioAdminWeb.Business.Relations.Auditoria.TipoLog().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Auditoria.TipoLog TipoId_ = null;
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DepositarioAdminWeb.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Detalle","Detalle")]
             public String Detalle { get; set; }
             [DataItemAttributeFieldName("Modulo","Modulo")]
             public String Modulo { get; set; }
             [DataItemAttributeFieldName("Metodo","Metodo")]
             public String Metodo { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
				
			} //Class Log 
} //namespace DepositarioAdminWeb.Entities.Relations.Auditoria
		namespace DepositarioAdminWeb.Entities.Relations.Auditoria {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Auditoria")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoLog","TipoLog")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoLog : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoLog()
                {
                }
                public  TipoLog(String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Log that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Auditoria.Log> ListOf_Log_TipoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Auditoria.Log entities = new DepositarioAdminWeb.Business.Relations.Auditoria.Log();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Auditoria.Log.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoLog 
} //namespace DepositarioAdminWeb.Entities.Relations.Auditoria
		namespace DepositarioAdminWeb.Entities.Relations.Banca {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Banca")]  // Database Schema Name
			[DataItemAttributeObjectName("Banco","Banco")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Banco : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Codigo = "Codigo";
					public const string PaisId = "PaisId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Codigo,
					PaisId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Banco()
                {
                }
                public  Banco(String Nombre,String Descripcion,String Codigo,DepositarioAdminWeb.Entities.Relations.Geografia.Pais PaisId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Codigo = Codigo;
                    this.PaisId = PaisId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("PaisId","PaisId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PaisId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Pais")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Geografia.Pais PaisId
             {
                 get {
                     if (PaisId_ == null || PaisId_.Id != _PaisId)
                         {
                             PaisId = new DepositarioAdminWeb.Business.Relations.Geografia.Pais().Items(this._PaisId).FirstOrDefault();
                         }
                     return PaisId_;
                     }
                 set {PaisId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Geografia.Pais PaisId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this BancoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_BancoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Banca.Cuenta entities = new DepositarioAdminWeb.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Banca.Cuenta.ColumnEnum.BancoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Banco 
} //namespace DepositarioAdminWeb.Entities.Relations.Banca
		namespace DepositarioAdminWeb.Entities.Relations.Banca {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Banca")]  // Database Schema Name
			[DataItemAttributeObjectName("Cuenta","Cuenta")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Cuenta : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string Nombre = "Nombre";
					public const string Numero = "Numero";
					public const string BancoId = "BancoId";
					public const string SucursalBancaria = "SucursalBancaria";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					Nombre,
					Numero,
					BancoId,
					SucursalBancaria,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Cuenta()
                {
                }
                public  Cuenta(Int64 TipoId,String Nombre,String Numero,DepositarioAdminWeb.Entities.Relations.Banca.Banco BancoId,String SucursalBancaria,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.Nombre = Nombre;
                    this.Numero = Numero;
                    this.BancoId = BancoId;
                    this.SucursalBancaria = SucursalBancaria;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             public Int64 TipoId { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Numero","Numero")]
             public String Numero { get; set; }
             [DataItemAttributeFieldName("BancoId","BancoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _BancoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Banco")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Banca.Banco BancoId
             {
                 get {
                     if (BancoId_ == null || BancoId_.Id != _BancoId)
                         {
                             BancoId = new DepositarioAdminWeb.Business.Relations.Banca.Banco().Items(this._BancoId).FirstOrDefault();
                         }
                     return BancoId_;
                     }
                 set {BancoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Banca.Banco BancoId_ = null;
             [DataItemAttributeFieldName("SucursalBancaria","SucursalBancaria")]
             public String SucursalBancaria { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of UsuarioCuenta that have this CuentaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Banca.UsuarioCuenta> ListOf_UsuarioCuenta_CuentaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Banca.UsuarioCuenta entities = new DepositarioAdminWeb.Business.Relations.Banca.UsuarioCuenta();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.CuentaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Cuenta 
} //namespace DepositarioAdminWeb.Entities.Relations.Banca
		namespace DepositarioAdminWeb.Entities.Relations.Banca {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Banca")]  // Database Schema Name
			[DataItemAttributeObjectName("UsuarioCuenta","UsuarioCuenta")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class UsuarioCuenta : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string UsuarioId = "UsuarioId";
					public const string CuentaId = "CuentaId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					UsuarioId,
					CuentaId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public UsuarioCuenta()
                {
                }
                public  UsuarioCuenta(Int64 UsuarioId,DepositarioAdminWeb.Entities.Relations.Banca.Cuenta CuentaId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.UsuarioId = UsuarioId;
                    this.CuentaId = CuentaId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("CuentaId","CuentaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CuentaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Cuenta")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Banca.Cuenta CuentaId
             {
                 get {
                     if (CuentaId_ == null || CuentaId_.Id != _CuentaId)
                         {
                             CuentaId = new DepositarioAdminWeb.Business.Relations.Banca.Cuenta().Items(this._CuentaId).FirstOrDefault();
                         }
                     return CuentaId_;
                     }
                 set {CuentaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Banca.Cuenta CuentaId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this UsuarioCuentaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_UsuarioCuentaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Transaccion entities = new DepositarioAdminWeb.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.UsuarioCuentaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class UsuarioCuenta 
} //namespace DepositarioAdminWeb.Entities.Relations.Banca
		namespace DepositarioAdminWeb.Entities.Relations.Biometria {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Biometria")]  // Database Schema Name
			[DataItemAttributeObjectName("HuellaDactilar","HuellaDactilar")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class HuellaDactilar : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string UsuarioId = "UsuarioId";
					public const string Dedo = "Dedo";
					public const string Huella = "Huella";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					UsuarioId,
					Dedo,
					Huella,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public HuellaDactilar()
                {
                }
                public  HuellaDactilar(Int64 UsuarioId,Byte Dedo,String Huella,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.UsuarioId = UsuarioId;
                    this.Dedo = Dedo;
                    this.Huella = Huella;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("Dedo","Dedo")]
             public Byte Dedo { get; set; }
             [DataItemAttributeFieldName("Huella","Huella")]
             public String Huella { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class HuellaDactilar 
} //namespace DepositarioAdminWeb.Entities.Relations.Biometria
		namespace DepositarioAdminWeb.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("Empresa","Empresa")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Empresa : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string GrupoId = "GrupoId";
					public const string CodigoExterno = "CodigoExterno";
					public const string Direccion = "Direccion";
					public const string CodigoPostalId = "CodigoPostalId";
					public const string EstiloEsquemaId = "EstiloEsquemaId";
					public const string LenguajeId = "LenguajeId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					GrupoId,
					CodigoExterno,
					Direccion,
					CodigoPostalId,
					EstiloEsquemaId,
					LenguajeId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Empresa()
                {
                }
                public  Empresa(String Nombre,String Descripcion,DepositarioAdminWeb.Entities.Relations.Directorio.Grupo GrupoId,String CodigoExterno,String Direccion,Int64 CodigoPostalId,Int64 EstiloEsquemaId,DepositarioAdminWeb.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.GrupoId = GrupoId;
                    this.CodigoExterno = CodigoExterno;
                    this.Direccion = Direccion;
                    this.CodigoPostalId = CodigoPostalId;
                    this.EstiloEsquemaId = EstiloEsquemaId;
                    this.LenguajeId = LenguajeId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("GrupoId","GrupoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _GrupoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Grupo")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Directorio.Grupo GrupoId
             {
                 get {
                     if (GrupoId_ == null || GrupoId_.Id != _GrupoId)
                         {
                             GrupoId = new DepositarioAdminWeb.Business.Relations.Directorio.Grupo().Items(this._GrupoId).FirstOrDefault();
                         }
                     return GrupoId_;
                     }
                 set {GrupoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Directorio.Grupo GrupoId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Direccion","Direccion")]
             public String Direccion { get; set; }
             [DataItemAttributeFieldName("CodigoPostalId","CodigoPostalId")]
             public Int64 CodigoPostalId { get; set; }
             [DataItemAttributeFieldName("EstiloEsquemaId","EstiloEsquemaId")]
             public Int64 EstiloEsquemaId { get; set; }
             [DataItemAttributeFieldName("LenguajeId","LenguajeId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _LenguajeId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Lenguaje")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new DepositarioAdminWeb.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_EmpresaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Directorio.Sucursal entities = new DepositarioAdminWeb.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Sucursal.ColumnEnum.EmpresaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Usuario that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.Usuario> ListOf_Usuario_EmpresaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.Usuario entities = new DepositarioAdminWeb.Business.Relations.Seguridad.Usuario();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.Usuario.ColumnEnum.EmpresaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Empresa 
} //namespace DepositarioAdminWeb.Entities.Relations.Directorio
		namespace DepositarioAdminWeb.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("Grupo","Grupo")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Grupo : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					CodigoExterno,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Grupo()
                {
                }
                public  Grupo(String Nombre,String Descripcion,String CodigoExterno,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this GrupoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Directorio.Empresa> ListOf_Empresa_GrupoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Directorio.Empresa entities = new DepositarioAdminWeb.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Empresa.ColumnEnum.GrupoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Grupo 
} //namespace DepositarioAdminWeb.Entities.Relations.Directorio
		namespace DepositarioAdminWeb.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("IdentificadorUsuario","IdentificadorUsuario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class IdentificadorUsuario : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string UsuarioId = "UsuarioId";
					public const string Valor = "Valor";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					UsuarioId,
					Valor,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public IdentificadorUsuario()
                {
                }
                public  IdentificadorUsuario(Int64 TipoId,Int64 UsuarioId,String Valor,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.UsuarioId = UsuarioId;
                    this.Valor = Valor;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             public Int64 TipoId { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class IdentificadorUsuario 
} //namespace DepositarioAdminWeb.Entities.Relations.Directorio
		namespace DepositarioAdminWeb.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("RelacionMonedaSucursal","RelacionMonedaSucursal")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class RelacionMonedaSucursal : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string MonedaId = "MonedaId";
					public const string SucursalId = "SucursalId";
					public const string EsDefault = "EsDefault";
				}
				public enum FieldEnum : int
                {
					Id,
					MonedaId,
					SucursalId,
					EsDefault
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public RelacionMonedaSucursal()
                {
                }
                public  RelacionMonedaSucursal(DepositarioAdminWeb.Entities.Relations.Valor.Moneda MonedaId,DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal SucursalId,Boolean EsDefault)
                {
                    this.Id = Id;
                    this.MonedaId = MonedaId;
                    this.SucursalId = SucursalId;
                    this.EsDefault = EsDefault;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DepositarioAdminWeb.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SucursalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sucursal")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal SucursalId
             {
                 get {
                     if (SucursalId_ == null || SucursalId_.Id != _SucursalId)
                         {
                             SucursalId = new DepositarioAdminWeb.Business.Relations.Directorio.Sucursal().Items(this._SucursalId).FirstOrDefault();
                         }
                     return SucursalId_;
                     }
                 set {SucursalId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal SucursalId_ = null;
             [DataItemAttributeFieldName("EsDefault","EsDefault")]
             public Boolean EsDefault { get; set; }
				
			} //Class RelacionMonedaSucursal 
} //namespace DepositarioAdminWeb.Entities.Relations.Directorio
		namespace DepositarioAdminWeb.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("RolFuncion","RolFuncion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class RolFuncion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string FuncionId = "FuncionId";
					public const string RolId = "RolId";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					FuncionId,
					RolId,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public RolFuncion()
                {
                }
                public  RolFuncion(DepositarioAdminWeb.Entities.Relations.Seguridad.Funcion FuncionId,DepositarioAdminWeb.Entities.Relations.Seguridad.Rol RolId,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.FuncionId = FuncionId;
                    this.RolId = RolId;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int16 Id { get; set; }
             [DataItemAttributeFieldName("FuncionId","FuncionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _FuncionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Funcion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Funcion FuncionId
             {
                 get {
                     if (FuncionId_ == null || FuncionId_.Id != _FuncionId)
                         {
                             FuncionId = new DepositarioAdminWeb.Business.Relations.Seguridad.Funcion().Items(this._FuncionId).FirstOrDefault();
                         }
                     return FuncionId_;
                     }
                 set {FuncionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Funcion FuncionId_ = null;
             [DataItemAttributeFieldName("RolId","RolId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _RolId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Rol RolId
             {
                 get {
                     if (RolId_ == null || RolId_.Id != _RolId)
                         {
                             RolId = new DepositarioAdminWeb.Business.Relations.Seguridad.Rol().Items(this._RolId).FirstOrDefault();
                         }
                     return RolId_;
                     }
                 set {RolId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Rol RolId_ = null;
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class RolFuncion 
} //namespace DepositarioAdminWeb.Entities.Relations.Directorio
		namespace DepositarioAdminWeb.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("Sector","Sector")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Sector : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string SucursalId = "SucursalId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					SucursalId,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Sector()
                {
                }
                public  Sector(DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal SucursalId,String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.SucursalId = SucursalId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SucursalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sucursal")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal SucursalId
             {
                 get {
                     if (SucursalId_ == null || SucursalId_.Id != _SucursalId)
                         {
                             SucursalId = new DepositarioAdminWeb.Business.Relations.Directorio.Sucursal().Items(this._SucursalId).FirstOrDefault();
                         }
                     return SucursalId_;
                     }
                 set {SucursalId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal SucursalId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_SectorId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario.ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_SectorId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Transaccion entities = new DepositarioAdminWeb.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Agenda that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Turno.Agenda> ListOf_Agenda_SectorId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Turno.Agenda entities = new DepositarioAdminWeb.Business.Relations.Turno.Agenda();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Turno.Agenda.ColumnEnum.SectorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Sector 
} //namespace DepositarioAdminWeb.Entities.Relations.Directorio
		namespace DepositarioAdminWeb.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("Sucursal","Sucursal")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Sucursal : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string EmpresaId = "EmpresaId";
					public const string CodigoExterno = "CodigoExterno";
					public const string Direccion = "Direccion";
					public const string CodigoPostalId = "CodigoPostalId";
					public const string ZonaId = "ZonaId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EmpresaId,
					CodigoExterno,
					Direccion,
					CodigoPostalId,
					ZonaId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Sucursal()
                {
                }
                public  Sucursal(String Nombre,String Descripcion,DepositarioAdminWeb.Entities.Relations.Directorio.Empresa EmpresaId,String CodigoExterno,String Direccion,DepositarioAdminWeb.Entities.Relations.Geografia.CodigoPostal CodigoPostalId,Int64 ZonaId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EmpresaId = EmpresaId;
                    this.CodigoExterno = CodigoExterno;
                    this.Direccion = Direccion;
                    this.CodigoPostalId = CodigoPostalId;
                    this.ZonaId = ZonaId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new DepositarioAdminWeb.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Direccion","Direccion")]
             public String Direccion { get; set; }
             [DataItemAttributeFieldName("CodigoPostalId","CodigoPostalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CodigoPostalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CodigoPostal")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Geografia.CodigoPostal CodigoPostalId
             {
                 get {
                     if (CodigoPostalId_ == null || CodigoPostalId_.Id != _CodigoPostalId)
                         {
                             CodigoPostalId = new DepositarioAdminWeb.Business.Relations.Geografia.CodigoPostal().Items(this._CodigoPostalId).FirstOrDefault();
                         }
                     return CodigoPostalId_;
                     }
                 set {CodigoPostalId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Geografia.CodigoPostal CodigoPostalId_ = null;
             [DataItemAttributeFieldName("ZonaId","ZonaId")]
             public Int64 ZonaId { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this SucursalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_SucursalId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal entities = new DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.SucursalId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sector that have this SucursalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Directorio.Sector> ListOf_Sector_SucursalId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Directorio.Sector entities = new DepositarioAdminWeb.Business.Relations.Directorio.Sector();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Sector.ColumnEnum.SucursalId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this SucursalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_SucursalId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Transaccion entities = new DepositarioAdminWeb.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.SucursalId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Sucursal 
} //namespace DepositarioAdminWeb.Entities.Relations.Directorio
		namespace DepositarioAdminWeb.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoIdentificador","TipoIdentificador")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoIdentificador : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Mascara = "Mascara";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Mascara,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoIdentificador()
                {
                }
                public  TipoIdentificador(String Nombre,String Descripcion,String Mascara,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Mascara = Mascara;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Mascara","Mascara")]
             public String Mascara { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoIdentificador 
} //namespace DepositarioAdminWeb.Entities.Relations.Directorio
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("ComandoContadora","ComandoContadora")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class ComandoContadora : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string ContadoraId = "ContadoraId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Comando = "Comando";
					public const string TiempoDetencion = "TiempoDetencion";
					public const string Respuesta = "Respuesta";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					ContadoraId,
					Nombre,
					Descripcion,
					Comando,
					TiempoDetencion,
					Respuesta,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ComandoContadora()
                {
                }
                public  ComandoContadora(DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoContadora ContadoraId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,String Respuesta,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.ContadoraId = ContadoraId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Comando = Comando;
                    this.TiempoDetencion = TiempoDetencion;
                    this.Respuesta = Respuesta;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("ContadoraId","ContadoraId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ContadoraId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoContadora")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoContadora ContadoraId
             {
                 get {
                     if (ContadoraId_ == null || ContadoraId_.Id != _ContadoraId)
                         {
                             ContadoraId = new DepositarioAdminWeb.Business.Relations.Dispositivo.TipoContadora().Items(this._ContadoraId).FirstOrDefault();
                         }
                     return ContadoraId_;
                     }
                 set {ContadoraId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoContadora ContadoraId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Comando","Comando")]
             public String Comando { get; set; }
             [DataItemAttributeFieldName("TiempoDetencion","TiempoDetencion")]
             public Int64 TiempoDetencion { get; set; }
             [DataItemAttributeFieldName("Respuesta","Respuesta")]
             public String Respuesta { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class ComandoContadora 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("ComandoPlaca","ComandoPlaca")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class ComandoPlaca : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoPlacaId = "TipoPlacaId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Comando = "Comando";
					public const string TiempoDetencion = "TiempoDetencion";
					public const string Respuesta = "Respuesta";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoPlacaId,
					Nombre,
					Descripcion,
					Comando,
					TiempoDetencion,
					Respuesta,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ComandoPlaca()
                {
                }
                public  ComandoPlaca(DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,String Respuesta,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoPlacaId = TipoPlacaId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Comando = Comando;
                    this.TiempoDetencion = TiempoDetencion;
                    this.Respuesta = Respuesta;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoPlacaId","TipoPlacaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoPlacaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoPlaca")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId
             {
                 get {
                     if (TipoPlacaId_ == null || TipoPlacaId_.Id != _TipoPlacaId)
                         {
                             TipoPlacaId = new DepositarioAdminWeb.Business.Relations.Dispositivo.TipoPlaca().Items(this._TipoPlacaId).FirstOrDefault();
                         }
                     return TipoPlacaId_;
                     }
                 set {TipoPlacaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Comando","Comando")]
             public String Comando { get; set; }
             [DataItemAttributeFieldName("TiempoDetencion","TiempoDetencion")]
             public Int64 TiempoDetencion { get; set; }
             [DataItemAttributeFieldName("Respuesta","Respuesta")]
             public String Respuesta { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class ComandoPlaca 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("ConfiguracionDepositario","ConfiguracionDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class ConfiguracionDepositario : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string DepositarioId = "DepositarioId";
					public const string Valor = "Valor";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					DepositarioId,
					Valor,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ConfiguracionDepositario()
                {
                }
                public  ConfiguracionDepositario(DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoConfiguracionDepositario TipoId,DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId,String Valor,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.DepositarioId = DepositarioId;
                    this.Valor = Valor;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoConfiguracionDepositario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoConfiguracionDepositario TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DepositarioAdminWeb.Business.Relations.Dispositivo.TipoConfiguracionDepositario().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoConfiguracionDepositario TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class ConfiguracionDepositario 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("Depositario","Depositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Depositario : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string SectorId = "SectorId";
					public const string NumeroSerie = "NumeroSerie";
					public const string CodigoExterno = "CodigoExterno";
					public const string ModeloId = "ModeloId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					SectorId,
					NumeroSerie,
					CodigoExterno,
					ModeloId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Depositario()
                {
                }
                public  Depositario(String Nombre,String Descripcion,DepositarioAdminWeb.Entities.Relations.Directorio.Sector SectorId,String NumeroSerie,String CodigoExterno,DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo ModeloId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.SectorId = SectorId;
                    this.NumeroSerie = NumeroSerie;
                    this.CodigoExterno = CodigoExterno;
                    this.ModeloId = ModeloId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new DepositarioAdminWeb.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("NumeroSerie","NumeroSerie")]
             public String NumeroSerie { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("ModeloId","ModeloId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ModeloId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Modelo")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo ModeloId
             {
                 get {
                     if (ModeloId_ == null || ModeloId_.Id != _ModeloId)
                         {
                             ModeloId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Modelo().Items(this._ModeloId).FirstOrDefault();
                         }
                     return ModeloId_;
                     }
                 set {ModeloId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo ModeloId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_DepositarioId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_DepositarioId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioContadora entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioEstado that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.DepositarioEstado> ListOf_DepositarioEstado_DepositarioId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioEstado entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioEstado();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioEstado.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_DepositarioId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioPlaca entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioValor that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.DepositarioValor> ListOf_DepositarioValor_DepositarioId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioValor entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioValor();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioValor.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Turno> ListOf_Turno_DepositarioId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Turno entities = new DepositarioAdminWeb.Business.Relations.Operacion.Turno();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Turno.ColumnEnum.DepositarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Depositario 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("DepositarioContadora","DepositarioContadora")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class DepositarioContadora : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string ContadoraId = "ContadoraId";
					public const string DepositarioId = "DepositarioId";
					public const string NumeroSerie = "NumeroSerie";
					public const string PortName = "PortName";
					public const string Parity = "Parity";
					public const string DataBits = "DataBits";
					public const string ReadBufferSize = "ReadBufferSize";
					public const string StopBits = "StopBits";
					public const string ReadTimeout = "ReadTimeout";
					public const string Handshake = "Handshake";
					public const string BaudRate = "BaudRate";
					public const string RtsEnable = "RtsEnable";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					ContadoraId,
					DepositarioId,
					NumeroSerie,
					PortName,
					Parity,
					DataBits,
					ReadBufferSize,
					StopBits,
					ReadTimeout,
					Handshake,
					BaudRate,
					RtsEnable,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public DepositarioContadora()
                {
                }
                public  DepositarioContadora(DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoContadora ContadoraId,DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId,String NumeroSerie,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.ContadoraId = ContadoraId;
                    this.DepositarioId = DepositarioId;
                    this.NumeroSerie = NumeroSerie;
                    this.PortName = PortName;
                    this.Parity = Parity;
                    this.DataBits = DataBits;
                    this.ReadBufferSize = ReadBufferSize;
                    this.StopBits = StopBits;
                    this.ReadTimeout = ReadTimeout;
                    this.Handshake = Handshake;
                    this.BaudRate = BaudRate;
                    this.RtsEnable = RtsEnable;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("ContadoraId","ContadoraId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ContadoraId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoContadora")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoContadora ContadoraId
             {
                 get {
                     if (ContadoraId_ == null || ContadoraId_.Id != _ContadoraId)
                         {
                             ContadoraId = new DepositarioAdminWeb.Business.Relations.Dispositivo.TipoContadora().Items(this._ContadoraId).FirstOrDefault();
                         }
                     return ContadoraId_;
                     }
                 set {ContadoraId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoContadora ContadoraId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("NumeroSerie","NumeroSerie")]
             public String NumeroSerie { get; set; }
             [DataItemAttributeFieldName("PortName","PortName")]
             public String PortName { get; set; }
             [DataItemAttributeFieldName("Parity","Parity")]
             public Int32 Parity { get; set; }
             [DataItemAttributeFieldName("DataBits","DataBits")]
             public Int32 DataBits { get; set; }
             [DataItemAttributeFieldName("ReadBufferSize","ReadBufferSize")]
             public Int32 ReadBufferSize { get; set; }
             [DataItemAttributeFieldName("StopBits","StopBits")]
             public Int32 StopBits { get; set; }
             [DataItemAttributeFieldName("ReadTimeout","ReadTimeout")]
             public Int32 ReadTimeout { get; set; }
             [DataItemAttributeFieldName("Handshake","Handshake")]
             public Int32 Handshake { get; set; }
             [DataItemAttributeFieldName("BaudRate","BaudRate")]
             public Int32 BaudRate { get; set; }
             [DataItemAttributeFieldName("RtsEnable","RtsEnable")]
             public Boolean RtsEnable { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioContadora 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("DepositarioEstado","DepositarioEstado")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class DepositarioEstado : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string DepositarioId = "DepositarioId";
					public const string SectorId = "SectorId";
					public const string SucursalId = "SucursalId";
					public const string ContadoraA = "ContadoraA";
					public const string ContadoraB = "ContadoraB";
					public const string Placa = "Placa";
					public const string Puerta = "Puerta";
					public const string Contenedor = "Contenedor";
					public const string FueraDeServicio = "FueraDeServicio";
					public const string Observaciones = "Observaciones";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					DepositarioId,
					SectorId,
					SucursalId,
					ContadoraA,
					ContadoraB,
					Placa,
					Puerta,
					Contenedor,
					FueraDeServicio,
					Observaciones,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public DepositarioEstado()
                {
                }
                public  DepositarioEstado(DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId,Int64 SectorId,Int64 SucursalId,String ContadoraA,String ContadoraB,String Placa,String Puerta,String Contenedor,Boolean FueraDeServicio,String Observaciones,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.DepositarioId = DepositarioId;
                    this.SectorId = SectorId;
                    this.SucursalId = SucursalId;
                    this.ContadoraA = ContadoraA;
                    this.ContadoraB = ContadoraB;
                    this.Placa = Placa;
                    this.Puerta = Puerta;
                    this.Contenedor = Contenedor;
                    this.FueraDeServicio = FueraDeServicio;
                    this.Observaciones = Observaciones;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             public Int64 SucursalId { get; set; }
             [DataItemAttributeFieldName("ContadoraA","ContadoraA")]
             public String ContadoraA { get; set; }
             [DataItemAttributeFieldName("ContadoraB","ContadoraB")]
             public String ContadoraB { get; set; }
             [DataItemAttributeFieldName("Placa","Placa")]
             public String Placa { get; set; }
             [DataItemAttributeFieldName("Puerta","Puerta")]
             public String Puerta { get; set; }
             [DataItemAttributeFieldName("Contenedor","Contenedor")]
             public String Contenedor { get; set; }
             [DataItemAttributeFieldName("FueraDeServicio","FueraDeServicio")]
             public Boolean FueraDeServicio { get; set; }
             [DataItemAttributeFieldName("Observaciones","Observaciones")]
             public String Observaciones { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioEstado 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("DepositarioPlaca","DepositarioPlaca")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class DepositarioPlaca : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string DepositarioId = "DepositarioId";
					public const string PlacaId = "PlacaId";
					public const string PortName = "PortName";
					public const string Parity = "Parity";
					public const string DataBits = "DataBits";
					public const string ReadBufferSize = "ReadBufferSize";
					public const string StopBits = "StopBits";
					public const string ReadTimeout = "ReadTimeout";
					public const string Handshake = "Handshake";
					public const string BaudRate = "BaudRate";
					public const string RtsEnable = "RtsEnable";
					public const string SensorA = "SensorA";
					public const string BitSensorA = "BitSensorA";
					public const string SensorB = "SensorB";
					public const string BitSensorB = "BitSensorB";
					public const string SensorC = "SensorC";
					public const string BitSensorC = "BitSensorC";
					public const string SensorD = "SensorD";
					public const string BitSensorD = "BitSensorD";
					public const string SensorL = "SensorL";
					public const string BitSensorL = "BitSensorL";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					DepositarioId,
					PlacaId,
					PortName,
					Parity,
					DataBits,
					ReadBufferSize,
					StopBits,
					ReadTimeout,
					Handshake,
					BaudRate,
					RtsEnable,
					SensorA,
					BitSensorA,
					SensorB,
					BitSensorB,
					SensorC,
					BitSensorC,
					SensorD,
					BitSensorD,
					SensorL,
					BitSensorL,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public DepositarioPlaca()
                {
                }
                public  DepositarioPlaca(DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId,DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoPlaca PlacaId,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Boolean SensorA,Int16 BitSensorA,Boolean SensorB,Int16 BitSensorB,Boolean SensorC,Int16 BitSensorC,Boolean SensorD,Int16 BitSensorD,Boolean SensorL,Int16 BitSensorL,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.DepositarioId = DepositarioId;
                    this.PlacaId = PlacaId;
                    this.PortName = PortName;
                    this.Parity = Parity;
                    this.DataBits = DataBits;
                    this.ReadBufferSize = ReadBufferSize;
                    this.StopBits = StopBits;
                    this.ReadTimeout = ReadTimeout;
                    this.Handshake = Handshake;
                    this.BaudRate = BaudRate;
                    this.RtsEnable = RtsEnable;
                    this.SensorA = SensorA;
                    this.BitSensorA = BitSensorA;
                    this.SensorB = SensorB;
                    this.BitSensorB = BitSensorB;
                    this.SensorC = SensorC;
                    this.BitSensorC = BitSensorC;
                    this.SensorD = SensorD;
                    this.BitSensorD = BitSensorD;
                    this.SensorL = SensorL;
                    this.BitSensorL = BitSensorL;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("PlacaId","PlacaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PlacaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoPlaca")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoPlaca PlacaId
             {
                 get {
                     if (PlacaId_ == null || PlacaId_.Id != _PlacaId)
                         {
                             PlacaId = new DepositarioAdminWeb.Business.Relations.Dispositivo.TipoPlaca().Items(this._PlacaId).FirstOrDefault();
                         }
                     return PlacaId_;
                     }
                 set {PlacaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoPlaca PlacaId_ = null;
             [DataItemAttributeFieldName("PortName","PortName")]
             public String PortName { get; set; }
             [DataItemAttributeFieldName("Parity","Parity")]
             public Int32 Parity { get; set; }
             [DataItemAttributeFieldName("DataBits","DataBits")]
             public Int32 DataBits { get; set; }
             [DataItemAttributeFieldName("ReadBufferSize","ReadBufferSize")]
             public Int32 ReadBufferSize { get; set; }
             [DataItemAttributeFieldName("StopBits","StopBits")]
             public Int32 StopBits { get; set; }
             [DataItemAttributeFieldName("ReadTimeout","ReadTimeout")]
             public Int32 ReadTimeout { get; set; }
             [DataItemAttributeFieldName("Handshake","Handshake")]
             public Int32 Handshake { get; set; }
             [DataItemAttributeFieldName("BaudRate","BaudRate")]
             public Int32 BaudRate { get; set; }
             [DataItemAttributeFieldName("RtsEnable","RtsEnable")]
             public Boolean RtsEnable { get; set; }
             [DataItemAttributeFieldName("SensorA","SensorA")]
             public Boolean SensorA { get; set; }
             [DataItemAttributeFieldName("BitSensorA","BitSensorA")]
             public Int16 BitSensorA { get; set; }
             [DataItemAttributeFieldName("SensorB","SensorB")]
             public Boolean SensorB { get; set; }
             [DataItemAttributeFieldName("BitSensorB","BitSensorB")]
             public Int16 BitSensorB { get; set; }
             [DataItemAttributeFieldName("SensorC","SensorC")]
             public Boolean SensorC { get; set; }
             [DataItemAttributeFieldName("BitSensorC","BitSensorC")]
             public Int16 BitSensorC { get; set; }
             [DataItemAttributeFieldName("SensorD","SensorD")]
             public Boolean SensorD { get; set; }
             [DataItemAttributeFieldName("BitSensorD","BitSensorD")]
             public Int16 BitSensorD { get; set; }
             [DataItemAttributeFieldName("SensorL","SensorL")]
             public Boolean SensorL { get; set; }
             [DataItemAttributeFieldName("BitSensorL","BitSensorL")]
             public Int16 BitSensorL { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioPlaca 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("DepositarioValor","DepositarioValor")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class DepositarioValor : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string DepositarioId = "DepositarioId";
					public const string ValorId = "ValorId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					DepositarioId,
					ValorId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public DepositarioValor()
                {
                }
                public  DepositarioValor(DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId,DepositarioAdminWeb.Entities.Relations.Valor.Moneda ValorId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.DepositarioId = DepositarioId;
                    this.ValorId = ValorId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("ValorId","ValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Valor.Moneda ValorId
             {
                 get {
                     if (ValorId_ == null || ValorId_.Id != _ValorId)
                         {
                             ValorId = new DepositarioAdminWeb.Business.Relations.Valor.Moneda().Items(this._ValorId).FirstOrDefault();
                         }
                     return ValorId_;
                     }
                 set {ValorId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Valor.Moneda ValorId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioValor 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("Marca","Marca")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Marca : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Marca()
                {
                }
                public  Marca(String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Modelo that have this MarcaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo> ListOf_Modelo_MarcaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.Modelo entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.Modelo();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.Modelo.ColumnEnum.MarcaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Marca 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("Modelo","Modelo")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Modelo : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string MarcaId = "MarcaId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					MarcaId,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Modelo()
                {
                }
                public  Modelo(DepositarioAdminWeb.Entities.Relations.Dispositivo.Marca MarcaId,String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.MarcaId = MarcaId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("MarcaId","MarcaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MarcaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Marca")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Marca MarcaId
             {
                 get {
                     if (MarcaId_ == null || MarcaId_.Id != _MarcaId)
                         {
                             MarcaId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Marca().Items(this._MarcaId).FirstOrDefault();
                         }
                     return MarcaId_;
                     }
                 set {MarcaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Marca MarcaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this ModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_ModeloId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario.ColumnEnum.ModeloId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContadora that have this ModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoContadora> ListOf_TipoContadora_ModeloId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.TipoContadora entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.TipoContadora();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.TipoContadora.ColumnEnum.ModeloId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoPlaca that have this ModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.TipoPlaca> ListOf_TipoPlaca_ModeloId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.TipoPlaca entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.TipoPlaca();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.TipoPlaca.ColumnEnum.ModeloId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Modelo 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoConfiguracionDepositario","TipoConfiguracionDepositario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoConfiguracionDepositario : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Clave = "Clave";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Clave,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoConfiguracionDepositario()
                {
                }
                public  TipoConfiguracionDepositario(String Clave,String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Clave = Clave;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Clave","Clave")]
             public String Clave { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_TipoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoConfiguracionDepositario 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoContadora","TipoContadora")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoContadora : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string ModeloId = "ModeloId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string PortName = "PortName";
					public const string Parity = "Parity";
					public const string DataBits = "DataBits";
					public const string ReadBufferSize = "ReadBufferSize";
					public const string StopBits = "StopBits";
					public const string ReadTimeout = "ReadTimeout";
					public const string Handshake = "Handshake";
					public const string BaudRate = "BaudRate";
					public const string RtsEnable = "RtsEnable";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					ModeloId,
					Nombre,
					Descripcion,
					PortName,
					Parity,
					DataBits,
					ReadBufferSize,
					StopBits,
					ReadTimeout,
					Handshake,
					BaudRate,
					RtsEnable,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoContadora()
                {
                }
                public  TipoContadora(DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo ModeloId,String Nombre,String Descripcion,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.ModeloId = ModeloId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.PortName = PortName;
                    this.Parity = Parity;
                    this.DataBits = DataBits;
                    this.ReadBufferSize = ReadBufferSize;
                    this.StopBits = StopBits;
                    this.ReadTimeout = ReadTimeout;
                    this.Handshake = Handshake;
                    this.BaudRate = BaudRate;
                    this.RtsEnable = RtsEnable;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("ModeloId","ModeloId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ModeloId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Modelo")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo ModeloId
             {
                 get {
                     if (ModeloId_ == null || ModeloId_.Id != _ModeloId)
                         {
                             ModeloId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Modelo().Items(this._ModeloId).FirstOrDefault();
                         }
                     return ModeloId_;
                     }
                 set {ModeloId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo ModeloId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("PortName","PortName")]
             public String PortName { get; set; }
             [DataItemAttributeFieldName("Parity","Parity")]
             public Int32 Parity { get; set; }
             [DataItemAttributeFieldName("DataBits","DataBits")]
             public Int32 DataBits { get; set; }
             [DataItemAttributeFieldName("ReadBufferSize","ReadBufferSize")]
             public Int32 ReadBufferSize { get; set; }
             [DataItemAttributeFieldName("StopBits","StopBits")]
             public Int32 StopBits { get; set; }
             [DataItemAttributeFieldName("ReadTimeout","ReadTimeout")]
             public Int32 ReadTimeout { get; set; }
             [DataItemAttributeFieldName("Handshake","Handshake")]
             public Int32 Handshake { get; set; }
             [DataItemAttributeFieldName("BaudRate","BaudRate")]
             public Int32 BaudRate { get; set; }
             [DataItemAttributeFieldName("RtsEnable","RtsEnable")]
             public Boolean RtsEnable { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ComandoContadora that have this ContadoraId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.ComandoContadora> ListOf_ComandoContadora_ContadoraId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.ComandoContadora entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.ComandoContadora();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.ComandoContadora.ColumnEnum.ContadoraId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this ContadoraId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_ContadoraId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioContadora entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.ContadoraId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoContadora 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoPlaca","TipoPlaca")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoPlaca : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string ModeloId = "ModeloId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string PortName = "PortName";
					public const string Parity = "Parity";
					public const string DataBits = "DataBits";
					public const string ReadBufferSize = "ReadBufferSize";
					public const string StopBits = "StopBits";
					public const string ReadTimeout = "ReadTimeout";
					public const string Handshake = "Handshake";
					public const string BaudRate = "BaudRate";
					public const string RtsEnable = "RtsEnable";
					public const string SensorA = "SensorA";
					public const string BitSensorA = "BitSensorA";
					public const string SensorB = "SensorB";
					public const string BitSensorB = "BitSensorB";
					public const string SensorC = "SensorC";
					public const string BitSensorC = "BitSensorC";
					public const string SensorD = "SensorD";
					public const string BitSensorD = "BitSensorD";
					public const string SensorL = "SensorL";
					public const string BitSensorL = "BitSensorL";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					ModeloId,
					Nombre,
					Descripcion,
					PortName,
					Parity,
					DataBits,
					ReadBufferSize,
					StopBits,
					ReadTimeout,
					Handshake,
					BaudRate,
					RtsEnable,
					SensorA,
					BitSensorA,
					SensorB,
					BitSensorB,
					SensorC,
					BitSensorC,
					SensorD,
					BitSensorD,
					SensorL,
					BitSensorL,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoPlaca()
                {
                }
                public  TipoPlaca(DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo ModeloId,String Nombre,String Descripcion,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Boolean SensorA,Int16 BitSensorA,Boolean SensorB,Int16 BitSensorB,Boolean SensorC,Int16 BitSensorC,Boolean SensorD,Int16 BitSensorD,Boolean SensorL,Int16 BitSensorL,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.ModeloId = ModeloId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.PortName = PortName;
                    this.Parity = Parity;
                    this.DataBits = DataBits;
                    this.ReadBufferSize = ReadBufferSize;
                    this.StopBits = StopBits;
                    this.ReadTimeout = ReadTimeout;
                    this.Handshake = Handshake;
                    this.BaudRate = BaudRate;
                    this.RtsEnable = RtsEnable;
                    this.SensorA = SensorA;
                    this.BitSensorA = BitSensorA;
                    this.SensorB = SensorB;
                    this.BitSensorB = BitSensorB;
                    this.SensorC = SensorC;
                    this.BitSensorC = BitSensorC;
                    this.SensorD = SensorD;
                    this.BitSensorD = BitSensorD;
                    this.SensorL = SensorL;
                    this.BitSensorL = BitSensorL;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("ModeloId","ModeloId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ModeloId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Modelo")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo ModeloId
             {
                 get {
                     if (ModeloId_ == null || ModeloId_.Id != _ModeloId)
                         {
                             ModeloId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Modelo().Items(this._ModeloId).FirstOrDefault();
                         }
                     return ModeloId_;
                     }
                 set {ModeloId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Modelo ModeloId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("PortName","PortName")]
             public String PortName { get; set; }
             [DataItemAttributeFieldName("Parity","Parity")]
             public Int32 Parity { get; set; }
             [DataItemAttributeFieldName("DataBits","DataBits")]
             public Int32 DataBits { get; set; }
             [DataItemAttributeFieldName("ReadBufferSize","ReadBufferSize")]
             public Int32 ReadBufferSize { get; set; }
             [DataItemAttributeFieldName("StopBits","StopBits")]
             public Int32 StopBits { get; set; }
             [DataItemAttributeFieldName("ReadTimeout","ReadTimeout")]
             public Int32 ReadTimeout { get; set; }
             [DataItemAttributeFieldName("Handshake","Handshake")]
             public Int32 Handshake { get; set; }
             [DataItemAttributeFieldName("BaudRate","BaudRate")]
             public Int32 BaudRate { get; set; }
             [DataItemAttributeFieldName("RtsEnable","RtsEnable")]
             public Boolean RtsEnable { get; set; }
             [DataItemAttributeFieldName("SensorA","SensorA")]
             public Boolean SensorA { get; set; }
             [DataItemAttributeFieldName("BitSensorA","BitSensorA")]
             public Int16 BitSensorA { get; set; }
             [DataItemAttributeFieldName("SensorB","SensorB")]
             public Boolean SensorB { get; set; }
             [DataItemAttributeFieldName("BitSensorB","BitSensorB")]
             public Int16 BitSensorB { get; set; }
             [DataItemAttributeFieldName("SensorC","SensorC")]
             public Boolean SensorC { get; set; }
             [DataItemAttributeFieldName("BitSensorC","BitSensorC")]
             public Int16 BitSensorC { get; set; }
             [DataItemAttributeFieldName("SensorD","SensorD")]
             public Boolean SensorD { get; set; }
             [DataItemAttributeFieldName("BitSensorD","BitSensorD")]
             public Int16 BitSensorD { get; set; }
             [DataItemAttributeFieldName("SensorL","SensorL")]
             public Boolean SensorL { get; set; }
             [DataItemAttributeFieldName("BitSensorL","BitSensorL")]
             public Int16 BitSensorL { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ComandoPlaca that have this TipoPlacaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.ComandoPlaca> ListOf_ComandoPlaca_TipoPlacaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.ComandoPlaca entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.ComandoPlaca();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.ComandoPlaca.ColumnEnum.TipoPlacaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this PlacaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_PlacaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioPlaca entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.PlacaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoPlaca 
} //namespace DepositarioAdminWeb.Entities.Relations.Dispositivo
		namespace DepositarioAdminWeb.Entities.Relations.Estilo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Estilo")]  // Database Schema Name
			[DataItemAttributeObjectName("Esquema","Esquema")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Esquema : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Esquema()
                {
                }
                public  Esquema(String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this EsquemaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_EsquemaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Estilo.EsquemaDetalle entities = new DepositarioAdminWeb.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Esquema 
} //namespace DepositarioAdminWeb.Entities.Relations.Estilo
		namespace DepositarioAdminWeb.Entities.Relations.Estilo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Estilo")]  // Database Schema Name
			[DataItemAttributeObjectName("EsquemaDetalle","EsquemaDetalle")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class EsquemaDetalle : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EsquemaId = "EsquemaId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					EsquemaId,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EsquemaDetalle()
                {
                }
                public  EsquemaDetalle(DepositarioAdminWeb.Entities.Relations.Estilo.Esquema EsquemaId,String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EsquemaId = EsquemaId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EsquemaId","EsquemaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EsquemaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Esquema")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Estilo.Esquema EsquemaId
             {
                 get {
                     if (EsquemaId_ == null || EsquemaId_.Id != _EsquemaId)
                         {
                             EsquemaId = new DepositarioAdminWeb.Business.Relations.Estilo.Esquema().Items(this._EsquemaId).FirstOrDefault();
                         }
                     return EsquemaId_;
                     }
                 set {EsquemaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Estilo.Esquema EsquemaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalleValor that have this EsquemaDetalleId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Estilo.EsquemaDetalleValor> ListOf_EsquemaDetalleValor_EsquemaDetalleId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Estilo.EsquemaDetalleValor entities = new DepositarioAdminWeb.Business.Relations.Estilo.EsquemaDetalleValor();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Estilo.EsquemaDetalleValor.ColumnEnum.EsquemaDetalleId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Agenda that have this EsquemaDetalleId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Turno.Agenda> ListOf_Agenda_EsquemaDetalleId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Turno.Agenda entities = new DepositarioAdminWeb.Business.Relations.Turno.Agenda();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Turno.Agenda.ColumnEnum.EsquemaDetalleId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class EsquemaDetalle 
} //namespace DepositarioAdminWeb.Entities.Relations.Estilo
		namespace DepositarioAdminWeb.Entities.Relations.Estilo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Estilo")]  // Database Schema Name
			[DataItemAttributeObjectName("EsquemaDetalleValor","EsquemaDetalleValor")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class EsquemaDetalleValor : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EsquemaDetalleId = "EsquemaDetalleId";
					public const string Valor = "Valor";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					EsquemaDetalleId,
					Valor,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EsquemaDetalleValor()
                {
                }
                public  EsquemaDetalleValor(DepositarioAdminWeb.Entities.Relations.Estilo.EsquemaDetalle EsquemaDetalleId,String Valor,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EsquemaDetalleId = EsquemaDetalleId;
                    this.Valor = Valor;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EsquemaDetalleId","EsquemaDetalleId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EsquemaDetalleId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EsquemaDetalle")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Estilo.EsquemaDetalle EsquemaDetalleId
             {
                 get {
                     if (EsquemaDetalleId_ == null || EsquemaDetalleId_.Id != _EsquemaDetalleId)
                         {
                             EsquemaDetalleId = new DepositarioAdminWeb.Business.Relations.Estilo.EsquemaDetalle().Items(this._EsquemaDetalleId).FirstOrDefault();
                         }
                     return EsquemaDetalleId_;
                     }
                 set {EsquemaDetalleId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Estilo.EsquemaDetalle EsquemaDetalleId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class EsquemaDetalleValor 
} //namespace DepositarioAdminWeb.Entities.Relations.Estilo
		namespace DepositarioAdminWeb.Entities.Relations.Geografia {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Geografia")]  // Database Schema Name
			[DataItemAttributeObjectName("Ciudad","Ciudad")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Ciudad : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string ProvinciaId = "ProvinciaId";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					ProvinciaId,
					CodigoExterno,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Ciudad()
                {
                }
                public  Ciudad(String Nombre,String Descripcion,DepositarioAdminWeb.Entities.Relations.Geografia.Provincia ProvinciaId,String CodigoExterno,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.ProvinciaId = ProvinciaId;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("ProvinciaId","ProvinciaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ProvinciaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Provincia")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Geografia.Provincia ProvinciaId
             {
                 get {
                     if (ProvinciaId_ == null || ProvinciaId_.Id != _ProvinciaId)
                         {
                             ProvinciaId = new DepositarioAdminWeb.Business.Relations.Geografia.Provincia().Items(this._ProvinciaId).FirstOrDefault();
                         }
                     return ProvinciaId_;
                     }
                 set {ProvinciaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Geografia.Provincia ProvinciaId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of CodigoPostal that have this CiudadId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Geografia.CodigoPostal> ListOf_CodigoPostal_CiudadId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Geografia.CodigoPostal entities = new DepositarioAdminWeb.Business.Relations.Geografia.CodigoPostal();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Geografia.CodigoPostal.ColumnEnum.CiudadId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Ciudad 
} //namespace DepositarioAdminWeb.Entities.Relations.Geografia
		namespace DepositarioAdminWeb.Entities.Relations.Geografia {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Geografia")]  // Database Schema Name
			[DataItemAttributeObjectName("CodigoPostal","CodigoPostal")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class CodigoPostal : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string CiudadId = "CiudadId";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					CiudadId,
					CodigoExterno,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public CodigoPostal()
                {
                }
                public  CodigoPostal(String Nombre,String Descripcion,DepositarioAdminWeb.Entities.Relations.Geografia.Ciudad CiudadId,String CodigoExterno,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.CiudadId = CiudadId;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("CiudadId","CiudadId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CiudadId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Ciudad")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Geografia.Ciudad CiudadId
             {
                 get {
                     if (CiudadId_ == null || CiudadId_.Id != _CiudadId)
                         {
                             CiudadId = new DepositarioAdminWeb.Business.Relations.Geografia.Ciudad().Items(this._CiudadId).FirstOrDefault();
                         }
                     return CiudadId_;
                     }
                 set {CiudadId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Geografia.Ciudad CiudadId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this CodigoPostalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_CodigoPostalId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Directorio.Sucursal entities = new DepositarioAdminWeb.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Sucursal.ColumnEnum.CodigoPostalId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class CodigoPostal 
} //namespace DepositarioAdminWeb.Entities.Relations.Geografia
		namespace DepositarioAdminWeb.Entities.Relations.Geografia {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Geografia")]  // Database Schema Name
			[DataItemAttributeObjectName("Pais","Pais")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Pais : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Codigo = "Codigo";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Codigo,
					CodigoExterno,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Pais()
                {
                }
                public  Pais(String Nombre,String Descripcion,String Codigo,String CodigoExterno,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Codigo = Codigo;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Banco that have this PaisId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Banca.Banco> ListOf_Banco_PaisId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Banca.Banco entities = new DepositarioAdminWeb.Business.Relations.Banca.Banco();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Banca.Banco.ColumnEnum.PaisId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Provincia that have this PaisId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Geografia.Provincia> ListOf_Provincia_PaisId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Geografia.Provincia entities = new DepositarioAdminWeb.Business.Relations.Geografia.Provincia();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Geografia.Provincia.ColumnEnum.PaisId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Pais 
} //namespace DepositarioAdminWeb.Entities.Relations.Geografia
		namespace DepositarioAdminWeb.Entities.Relations.Geografia {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Geografia")]  // Database Schema Name
			[DataItemAttributeObjectName("Provincia","Provincia")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Provincia : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string PaisId = "PaisId";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					PaisId,
					CodigoExterno,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Provincia()
                {
                }
                public  Provincia(String Nombre,String Descripcion,DepositarioAdminWeb.Entities.Relations.Geografia.Pais PaisId,String CodigoExterno,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.PaisId = PaisId;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("PaisId","PaisId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PaisId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Pais")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Geografia.Pais PaisId
             {
                 get {
                     if (PaisId_ == null || PaisId_.Id != _PaisId)
                         {
                             PaisId = new DepositarioAdminWeb.Business.Relations.Geografia.Pais().Items(this._PaisId).FirstOrDefault();
                         }
                     return PaisId_;
                     }
                 set {PaisId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Geografia.Pais PaisId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Ciudad that have this ProvinciaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Geografia.Ciudad> ListOf_Ciudad_ProvinciaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Geografia.Ciudad entities = new DepositarioAdminWeb.Business.Relations.Geografia.Ciudad();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Geografia.Ciudad.ColumnEnum.ProvinciaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Provincia 
} //namespace DepositarioAdminWeb.Entities.Relations.Geografia
		namespace DepositarioAdminWeb.Entities.Relations.Geografia {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Geografia")]  // Database Schema Name
			[DataItemAttributeObjectName("Zona","Zona")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Zona : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Codigo = "Codigo";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Codigo,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Zona()
                {
                }
                public  Zona(String Nombre,String Descripcion,String Codigo,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Codigo = Codigo;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Zona 
} //namespace DepositarioAdminWeb.Entities.Relations.Geografia
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("CierreDiario","CierreDiario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class CierreDiario : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Fecha = "Fecha";
					public const string SesionId = "SesionId";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Fecha,
					SesionId,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public CierreDiario()
                {
                }
                public  CierreDiario(String Nombre,DateTime Fecha,DepositarioAdminWeb.Entities.Relations.Operacion.Sesion SesionId,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Fecha = Fecha;
                    this.SesionId = SesionId;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("SesionId","SesionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SesionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sesion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.Sesion SesionId
             {
                 get {
                     if (SesionId_ == null || SesionId_.Id != _SesionId)
                         {
                             SesionId = new DepositarioAdminWeb.Business.Relations.Operacion.Sesion().Items(this._SesionId).FirstOrDefault();
                         }
                     return SesionId_;
                     }
                 set {SesionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.Sesion SesionId_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this CierreDiarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_CierreDiarioId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Transaccion entities = new DepositarioAdminWeb.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.CierreDiarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this CierreDiarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Turno> ListOf_Turno_CierreDiarioId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Turno entities = new DepositarioAdminWeb.Business.Relations.Operacion.Turno();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Turno.ColumnEnum.CierreDiarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class CierreDiario 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Contenedor","Contenedor")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Contenedor : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string TipoId = "TipoId";
					public const string Identificador = "Identificador";
					public const string FechaApertura = "FechaApertura";
					public const string FechaCierre = "FechaCierre";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					TipoId,
					Identificador,
					FechaApertura,
					FechaCierre,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Contenedor()
                {
                }
                public  Contenedor(String Nombre,DepositarioAdminWeb.Entities.Relations.Operacion.TipoContenedor TipoId,String Identificador,DateTime FechaApertura,DateTime? FechaCierre,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.TipoId = TipoId;
                    this.Identificador = Identificador;
                    this.FechaApertura = FechaApertura;
                    this.FechaCierre = FechaCierre;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoContenedor")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.TipoContenedor TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DepositarioAdminWeb.Business.Relations.Operacion.TipoContenedor().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.TipoContenedor TipoId_ = null;
             [DataItemAttributeFieldName("Identificador","Identificador")]
             public String Identificador { get; set; }
             [DataItemAttributeFieldName("FechaApertura","FechaApertura")]
             public DateTime FechaApertura { get; set; }
             [DataItemAttributeFieldName("FechaCierre","FechaCierre")]
             public DateTime? FechaCierre { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this ContenedorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_ContenedorId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Transaccion entities = new DepositarioAdminWeb.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Contenedor 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Evento","Evento")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Evento : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string SesionId = "SesionId";
					public const string DepositarioId = "DepositarioId";
					public const string Mensaje = "Mensaje";
					public const string Valor = "Valor";
					public const string Fecha = "Fecha";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					SesionId,
					DepositarioId,
					Mensaje,
					Valor,
					Fecha
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Evento()
                {
                }
                public  Evento(DepositarioAdminWeb.Entities.Relations.Operacion.TipoEvento TipoId,Int64? SesionId,Int64 DepositarioId,String Mensaje,String Valor,DateTime Fecha)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.SesionId = SesionId;
                    this.DepositarioId = DepositarioId;
                    this.Mensaje = Mensaje;
                    this.Valor = Valor;
                    this.Fecha = Fecha;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoEvento")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.TipoEvento TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DepositarioAdminWeb.Business.Relations.Operacion.TipoEvento().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.TipoEvento TipoId_ = null;
             [DataItemAttributeFieldName("SesionId","SesionId")]
             public Int64? SesionId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("Mensaje","Mensaje")]
             public String Mensaje { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class Evento 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Sesion","Sesion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Sesion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string UsuarioId = "UsuarioId";
					public const string FechaInicio = "FechaInicio";
					public const string FechaCierre = "FechaCierre";
					public const string EsCierreAutomatico = "EsCierreAutomatico";
				}
				public enum FieldEnum : int
                {
					Id,
					UsuarioId,
					FechaInicio,
					FechaCierre,
					EsCierreAutomatico
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Sesion()
                {
                }
                public  Sesion(Int64 UsuarioId,DateTime FechaInicio,DateTime FechaCierre,Boolean EsCierreAutomatico)
                {
                    this.Id = Id;
                    this.UsuarioId = UsuarioId;
                    this.FechaInicio = FechaInicio;
                    this.FechaCierre = FechaCierre;
                    this.EsCierreAutomatico = EsCierreAutomatico;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("FechaInicio","FechaInicio")]
             public DateTime FechaInicio { get; set; }
             [DataItemAttributeFieldName("FechaCierre","FechaCierre")]
             public DateTime FechaCierre { get; set; }
             [DataItemAttributeFieldName("EsCierreAutomatico","EsCierreAutomatico")]
             public Boolean EsCierreAutomatico { get; set; }
                 /// <summary>
                 ///  Represents the child collection of CierreDiario that have this SesionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.CierreDiario> ListOf_CierreDiario_SesionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.CierreDiario entities = new DepositarioAdminWeb.Business.Relations.Operacion.CierreDiario();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.CierreDiario.ColumnEnum.SesionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this SesionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_SesionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Transaccion entities = new DepositarioAdminWeb.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.SesionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Sesion 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoContenedor","TipoContenedor")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoContenedor : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Capacidad = "Capacidad";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Capacidad,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoContenedor()
                {
                }
                public  TipoContenedor(String Nombre,String Descripcion,Int32 Capacidad,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Capacidad = Capacidad;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Capacidad","Capacidad")]
             public Int32 Capacidad { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Contenedor that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Contenedor> ListOf_Contenedor_TipoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Contenedor entities = new DepositarioAdminWeb.Business.Relations.Operacion.Contenedor();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Contenedor.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoContenedor 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoEvento","TipoEvento")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoEvento : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string EsBloqueante = "EsBloqueante";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EsBloqueante,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoEvento()
                {
                }
                public  TipoEvento(String Nombre,String Descripcion,Boolean EsBloqueante,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EsBloqueante = EsBloqueante;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EsBloqueante","EsBloqueante")]
             public Boolean EsBloqueante { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Evento that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Evento> ListOf_Evento_TipoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Evento entities = new DepositarioAdminWeb.Business.Relations.Operacion.Evento();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Evento.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoEvento 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoTransaccion","TipoTransaccion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoTransaccion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoTransaccion()
                {
                }
                public  TipoTransaccion(String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_TipoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.Transaccion entities = new DepositarioAdminWeb.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoTransaccion 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Transaccion","Transaccion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Transaccion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string DepositarioId = "DepositarioId";
					public const string SectorId = "SectorId";
					public const string SucursalId = "SucursalId";
					public const string UsuarioId = "UsuarioId";
					public const string UsuarioCuentaId = "UsuarioCuentaId";
					public const string ContenedorId = "ContenedorId";
					public const string SesionId = "SesionId";
					public const string TurnoId = "TurnoId";
					public const string CierreDiarioId = "CierreDiarioId";
					public const string TotalValidado = "TotalValidado";
					public const string TotalAValidar = "TotalAValidar";
					public const string Fecha = "Fecha";
					public const string Finalizada = "Finalizada";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					DepositarioId,
					SectorId,
					SucursalId,
					UsuarioId,
					UsuarioCuentaId,
					ContenedorId,
					SesionId,
					TurnoId,
					CierreDiarioId,
					TotalValidado,
					TotalAValidar,
					Fecha,
					Finalizada
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Transaccion()
                {
                }
                public  Transaccion(DepositarioAdminWeb.Entities.Relations.Operacion.TipoTransaccion TipoId,Int64 DepositarioId,DepositarioAdminWeb.Entities.Relations.Directorio.Sector SectorId,DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal SucursalId,Int64 UsuarioId,DepositarioAdminWeb.Entities.Relations.Banca.UsuarioCuenta UsuarioCuentaId,DepositarioAdminWeb.Entities.Relations.Operacion.Contenedor ContenedorId,DepositarioAdminWeb.Entities.Relations.Operacion.Sesion SesionId,Int64 TurnoId,DepositarioAdminWeb.Entities.Relations.Operacion.CierreDiario CierreDiarioId,Double TotalValidado,Double TotalAValidar,DateTime Fecha,Boolean Finalizada)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.DepositarioId = DepositarioId;
                    this.SectorId = SectorId;
                    this.SucursalId = SucursalId;
                    this.UsuarioId = UsuarioId;
                    this.UsuarioCuentaId = UsuarioCuentaId;
                    this.ContenedorId = ContenedorId;
                    this.SesionId = SesionId;
                    this.TurnoId = TurnoId;
                    this.CierreDiarioId = CierreDiarioId;
                    this.TotalValidado = TotalValidado;
                    this.TotalAValidar = TotalAValidar;
                    this.Fecha = Fecha;
                    this.Finalizada = Finalizada;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoTransaccion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.TipoTransaccion TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DepositarioAdminWeb.Business.Relations.Operacion.TipoTransaccion().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.TipoTransaccion TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             public Int64 DepositarioId { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new DepositarioAdminWeb.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SucursalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sucursal")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal SucursalId
             {
                 get {
                     if (SucursalId_ == null || SucursalId_.Id != _SucursalId)
                         {
                             SucursalId = new DepositarioAdminWeb.Business.Relations.Directorio.Sucursal().Items(this._SucursalId).FirstOrDefault();
                         }
                     return SucursalId_;
                     }
                 set {SucursalId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Directorio.Sucursal SucursalId_ = null;
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("UsuarioCuentaId","UsuarioCuentaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCuentaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("UsuarioCuenta")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Banca.UsuarioCuenta UsuarioCuentaId
             {
                 get {
                     if (UsuarioCuentaId_ == null || UsuarioCuentaId_.Id != _UsuarioCuentaId)
                         {
                             UsuarioCuentaId = new DepositarioAdminWeb.Business.Relations.Banca.UsuarioCuenta().Items(this._UsuarioCuentaId).FirstOrDefault();
                         }
                     return UsuarioCuentaId_;
                     }
                 set {UsuarioCuentaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Banca.UsuarioCuenta UsuarioCuentaId_ = null;
             [DataItemAttributeFieldName("ContenedorId","ContenedorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ContenedorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Contenedor")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.Contenedor ContenedorId
             {
                 get {
                     if (ContenedorId_ == null || ContenedorId_.Id != _ContenedorId)
                         {
                             ContenedorId = new DepositarioAdminWeb.Business.Relations.Operacion.Contenedor().Items(this._ContenedorId).FirstOrDefault();
                         }
                     return ContenedorId_;
                     }
                 set {ContenedorId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.Contenedor ContenedorId_ = null;
             [DataItemAttributeFieldName("SesionId","SesionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SesionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sesion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.Sesion SesionId
             {
                 get {
                     if (SesionId_ == null || SesionId_.Id != _SesionId)
                         {
                             SesionId = new DepositarioAdminWeb.Business.Relations.Operacion.Sesion().Items(this._SesionId).FirstOrDefault();
                         }
                     return SesionId_;
                     }
                 set {SesionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.Sesion SesionId_ = null;
             [DataItemAttributeFieldName("TurnoId","TurnoId")]
             public Int64 TurnoId { get; set; }
             [DataItemAttributeFieldName("CierreDiarioId","CierreDiarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CierreDiarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CierreDiario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.CierreDiario CierreDiarioId
             {
                 get {
                     if (CierreDiarioId_ == null || CierreDiarioId_.Id != _CierreDiarioId)
                         {
                             CierreDiarioId = new DepositarioAdminWeb.Business.Relations.Operacion.CierreDiario().Items(this._CierreDiarioId).FirstOrDefault();
                         }
                     return CierreDiarioId_;
                     }
                 set {CierreDiarioId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.CierreDiario CierreDiarioId_ = null;
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public Double TotalValidado { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double TotalAValidar { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("Finalizada","Finalizada")]
             public Boolean Finalizada { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionDetalle that have this TransaccionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.TransaccionDetalle> ListOf_TransaccionDetalle_TransaccionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.TransaccionDetalle entities = new DepositarioAdminWeb.Business.Relations.Operacion.TransaccionDetalle();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TransaccionSobre that have this TransaccionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.TransaccionSobre> ListOf_TransaccionSobre_TransaccionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobre entities = new DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobre();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Transaccion 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("TransaccionDetalle","TransaccionDetalle")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TransaccionDetalle : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TransaccionId = "TransaccionId";
					public const string DenominacionId = "DenominacionId";
					public const string CantidadUnidades = "CantidadUnidades";
					public const string Fecha = "Fecha";
				}
				public enum FieldEnum : int
                {
					Id,
					TransaccionId,
					DenominacionId,
					CantidadUnidades,
					Fecha
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TransaccionDetalle()
                {
                }
                public  TransaccionDetalle(DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion TransaccionId,DepositarioAdminWeb.Entities.Relations.Valor.Denominacion DenominacionId,Int64 CantidadUnidades,DateTime Fecha)
                {
                    this.Id = Id;
                    this.TransaccionId = TransaccionId;
                    this.DenominacionId = DenominacionId;
                    this.CantidadUnidades = CantidadUnidades;
                    this.Fecha = Fecha;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TransaccionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Transaccion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion TransaccionId
             {
                 get {
                     if (TransaccionId_ == null || TransaccionId_.Id != _TransaccionId)
                         {
                             TransaccionId = new DepositarioAdminWeb.Business.Relations.Operacion.Transaccion().Items(this._TransaccionId).FirstOrDefault();
                         }
                     return TransaccionId_;
                     }
                 set {TransaccionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion TransaccionId_ = null;
             [DataItemAttributeFieldName("DenominacionId","DenominacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DenominacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Denominacion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Valor.Denominacion DenominacionId
             {
                 get {
                     if (DenominacionId_ == null || DenominacionId_.Id != _DenominacionId)
                         {
                             DenominacionId = new DepositarioAdminWeb.Business.Relations.Valor.Denominacion().Items(this._DenominacionId).FirstOrDefault();
                         }
                     return DenominacionId_;
                     }
                 set {DenominacionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Valor.Denominacion DenominacionId_ = null;
             [DataItemAttributeFieldName("CantidadUnidades","CantidadUnidades")]
             public Int64 CantidadUnidades { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class TransaccionDetalle 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("TransaccionSobre","TransaccionSobre")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TransaccionSobre : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TransaccionId = "TransaccionId";
					public const string CodigoSobre = "CodigoSobre";
					public const string Fecha = "Fecha";
				}
				public enum FieldEnum : int
                {
					Id,
					TransaccionId,
					CodigoSobre,
					Fecha
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TransaccionSobre()
                {
                }
                public  TransaccionSobre(DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion TransaccionId,String CodigoSobre,DateTime Fecha)
                {
                    this.Id = Id;
                    this.TransaccionId = TransaccionId;
                    this.CodigoSobre = CodigoSobre;
                    this.Fecha = Fecha;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TransaccionId","TransaccionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TransaccionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Transaccion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion TransaccionId
             {
                 get {
                     if (TransaccionId_ == null || TransaccionId_.Id != _TransaccionId)
                         {
                             TransaccionId = new DepositarioAdminWeb.Business.Relations.Operacion.Transaccion().Items(this._TransaccionId).FirstOrDefault();
                         }
                     return TransaccionId_;
                     }
                 set {TransaccionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.Transaccion TransaccionId_ = null;
             [DataItemAttributeFieldName("CodigoSobre","CodigoSobre")]
             public String CodigoSobre { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionSobreDetalle that have this SobreId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.TransaccionSobreDetalle> ListOf_TransaccionSobreDetalle_SobreId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobreDetalle entities = new DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobreDetalle();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.SobreId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TransaccionSobre 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("TransaccionSobreDetalle","TransaccionSobreDetalle")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TransaccionSobreDetalle : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string SobreId = "SobreId";
					public const string RelacionMonedaTipoValorId = "RelacionMonedaTipoValorId";
					public const string CantidadDeclarada = "CantidadDeclarada";
					public const string Fecha = "Fecha";
				}
				public enum FieldEnum : int
                {
					Id,
					SobreId,
					RelacionMonedaTipoValorId,
					CantidadDeclarada,
					Fecha
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TransaccionSobreDetalle()
                {
                }
                public  TransaccionSobreDetalle(DepositarioAdminWeb.Entities.Relations.Operacion.TransaccionSobre SobreId,DepositarioAdminWeb.Entities.Relations.Valor.RelacionMonedaTipoValor RelacionMonedaTipoValorId,Int64 CantidadDeclarada,DateTime Fecha)
                {
                    this.Id = Id;
                    this.SobreId = SobreId;
                    this.RelacionMonedaTipoValorId = RelacionMonedaTipoValorId;
                    this.CantidadDeclarada = CantidadDeclarada;
                    this.Fecha = Fecha;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("SobreId","SobreId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SobreId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TransaccionSobre")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.TransaccionSobre SobreId
             {
                 get {
                     if (SobreId_ == null || SobreId_.Id != _SobreId)
                         {
                             SobreId = new DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobre().Items(this._SobreId).FirstOrDefault();
                         }
                     return SobreId_;
                     }
                 set {SobreId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.TransaccionSobre SobreId_ = null;
             [DataItemAttributeFieldName("RelacionMonedaTipoValorId","RelacionMonedaTipoValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _RelacionMonedaTipoValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("RelacionMonedaTipoValor")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Valor.RelacionMonedaTipoValor RelacionMonedaTipoValorId
             {
                 get {
                     if (RelacionMonedaTipoValorId_ == null || RelacionMonedaTipoValorId_.Id != _RelacionMonedaTipoValorId)
                         {
                             RelacionMonedaTipoValorId = new DepositarioAdminWeb.Business.Relations.Valor.RelacionMonedaTipoValor().Items(this._RelacionMonedaTipoValorId).FirstOrDefault();
                         }
                     return RelacionMonedaTipoValorId_;
                     }
                 set {RelacionMonedaTipoValorId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Valor.RelacionMonedaTipoValor RelacionMonedaTipoValorId_ = null;
             [DataItemAttributeFieldName("CantidadDeclarada","CantidadDeclarada")]
             public Int64 CantidadDeclarada { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class TransaccionSobreDetalle 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Turno","Turno")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Turno : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TurnoDepositarioId = "TurnoDepositarioId";
					public const string DepositarioId = "DepositarioId";
					public const string SectorId = "SectorId";
					public const string FechaApertura = "FechaApertura";
					public const string FechaCierre = "FechaCierre";
					public const string Fecha = "Fecha";
					public const string Secuencia = "Secuencia";
					public const string CierreDiarioId = "CierreDiarioId";
					public const string Observaciones = "Observaciones";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					TurnoDepositarioId,
					DepositarioId,
					SectorId,
					FechaApertura,
					FechaCierre,
					Fecha,
					Secuencia,
					CierreDiarioId,
					Observaciones,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Turno()
                {
                }
                public  Turno(Int64 TurnoDepositarioId,DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId,Int64 SectorId,DateTime? FechaApertura,DateTime? FechaCierre,DateTime? Fecha,Int32 Secuencia,DepositarioAdminWeb.Entities.Relations.Operacion.CierreDiario CierreDiarioId,String Observaciones,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.TurnoDepositarioId = TurnoDepositarioId;
                    this.DepositarioId = DepositarioId;
                    this.SectorId = SectorId;
                    this.FechaApertura = FechaApertura;
                    this.FechaCierre = FechaCierre;
                    this.Fecha = Fecha;
                    this.Secuencia = Secuencia;
                    this.CierreDiarioId = CierreDiarioId;
                    this.Observaciones = Observaciones;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TurnoDepositarioId","TurnoDepositarioId")]
             public Int64 TurnoDepositarioId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DepositarioAdminWeb.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("FechaApertura","FechaApertura")]
             public DateTime? FechaApertura { get; set; }
             [DataItemAttributeFieldName("FechaCierre","FechaCierre")]
             public DateTime? FechaCierre { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime? Fecha { get; set; }
             [DataItemAttributeFieldName("Secuencia","Secuencia")]
             public Int32 Secuencia { get; set; }
             [DataItemAttributeFieldName("CierreDiarioId","CierreDiarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CierreDiarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CierreDiario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Operacion.CierreDiario CierreDiarioId
             {
                 get {
                     if (CierreDiarioId_ == null || CierreDiarioId_.Id != _CierreDiarioId)
                         {
                             CierreDiarioId = new DepositarioAdminWeb.Business.Relations.Operacion.CierreDiario().Items(this._CierreDiarioId).FirstOrDefault();
                         }
                     return CierreDiarioId_;
                     }
                 set {CierreDiarioId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Operacion.CierreDiario CierreDiarioId_ = null;
             [DataItemAttributeFieldName("Observaciones","Observaciones")]
             public String Observaciones { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
				
			} //Class Turno 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("TurnoUsuario","TurnoUsuario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TurnoUsuario : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string UsuarioId = "UsuarioId";
					public const string TurnoId = "TurnoId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					UsuarioId,
					TurnoId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TurnoUsuario()
                {
                }
                public  TurnoUsuario(Int64 UsuarioId,Int64 TurnoId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.UsuarioId = UsuarioId;
                    this.TurnoId = TurnoId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("TurnoId","TurnoId")]
             public Int64 TurnoId { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class TurnoUsuario 
} //namespace DepositarioAdminWeb.Entities.Relations.Operacion
		namespace DepositarioAdminWeb.Entities.Relations.Regionalizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Regionalizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Lenguaje","Lenguaje")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Lenguaje : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Lenguaje()
                {
                }
                public  Lenguaje(String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Directorio.Empresa> ListOf_Empresa_LenguajeId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Directorio.Empresa entities = new DepositarioAdminWeb.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.Empresa.ColumnEnum.LenguajeId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of LenguajeItem that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Regionalizacion.LenguajeItem> ListOf_LenguajeItem_LenguajeId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Regionalizacion.LenguajeItem entities = new DepositarioAdminWeb.Business.Relations.Regionalizacion.LenguajeItem();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Regionalizacion.LenguajeItem.ColumnEnum.LenguajeId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Usuario that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.Usuario> ListOf_Usuario_LenguajeId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.Usuario entities = new DepositarioAdminWeb.Business.Relations.Seguridad.Usuario();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.Usuario.ColumnEnum.LenguajeId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Lenguaje 
} //namespace DepositarioAdminWeb.Entities.Relations.Regionalizacion
		namespace DepositarioAdminWeb.Entities.Relations.Regionalizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Regionalizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("LenguajeItem","LenguajeItem")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class LenguajeItem : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string LenguajeId = "LenguajeId";
					public const string Clave = "Clave";
					public const string Texto = "Texto";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					LenguajeId,
					Clave,
					Texto,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public LenguajeItem()
                {
                }
                public  LenguajeItem(DepositarioAdminWeb.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,String Clave,String Texto,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.LenguajeId = LenguajeId;
                    this.Clave = Clave;
                    this.Texto = Texto;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("LenguajeId","LenguajeId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _LenguajeId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Lenguaje")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new DepositarioAdminWeb.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
             [DataItemAttributeFieldName("Clave","Clave")]
             public String Clave { get; set; }
             [DataItemAttributeFieldName("Texto","Texto")]
             public String Texto { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class LenguajeItem 
} //namespace DepositarioAdminWeb.Entities.Relations.Regionalizacion
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Aplicacion","Aplicacion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Aplicacion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Aplicacion()
                {
                }
                public  Aplicacion(DepositarioAdminWeb.Entities.Relations.Seguridad.TipoAplicacion TipoId,String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoAplicacion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.TipoAplicacion TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DepositarioAdminWeb.Business.Relations.Seguridad.TipoAplicacion().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.TipoAplicacion TipoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Configuracion that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Aplicacion.Configuracion> ListOf_Configuracion_AplicacionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Aplicacion.Configuracion entities = new DepositarioAdminWeb.Business.Relations.Aplicacion.Configuracion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Aplicacion.Configuracion.ColumnEnum.AplicacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Log that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Auditoria.Log> ListOf_Log_AplicacionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Auditoria.Log entities = new DepositarioAdminWeb.Business.Relations.Auditoria.Log();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Auditoria.Log.ColumnEnum.AplicacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametro that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.AplicacionParametro> ListOf_AplicacionParametro_AplicacionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.AplicacionParametro entities = new DepositarioAdminWeb.Business.Relations.Seguridad.AplicacionParametro();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.AplicacionParametro.ColumnEnum.AplicacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_AplicacionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.Funcion entities = new DepositarioAdminWeb.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.Funcion.ColumnEnum.AplicacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_AplicacionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol entities = new DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.AplicacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Aplicacion 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("AplicacionParametro","AplicacionParametro")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class AplicacionParametro : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string AplicacionId = "AplicacionId";
					public const string Nombre = "Nombre";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					AplicacionId,
					Nombre,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public AplicacionParametro()
                {
                }
                public  AplicacionParametro(DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId,String Nombre,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.AplicacionId = AplicacionId;
                    this.Nombre = Nombre;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DepositarioAdminWeb.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class AplicacionParametro 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("AplicacionParametroValor","AplicacionParametroValor")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class AplicacionParametroValor : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string AplicacionId = "AplicacionId";
					public const string ParametroId = "ParametroId";
					public const string Valor = "Valor";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					AplicacionId,
					ParametroId,
					Valor,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public AplicacionParametroValor()
                {
                }
                public  AplicacionParametroValor(Int64 AplicacionId,Int64 ParametroId,String Valor,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.AplicacionId = AplicacionId;
                    this.ParametroId = ParametroId;
                    this.Valor = Valor;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             public Int64 AplicacionId { get; set; }
             [DataItemAttributeFieldName("ParametroId","ParametroId")]
             public Int64 ParametroId { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class AplicacionParametroValor 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Funcion","Funcion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Funcion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string AplicacionId = "AplicacionId";
					public const string TipoId = "TipoId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Referencia = "Referencia";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					AplicacionId,
					TipoId,
					Nombre,
					Descripcion,
					Referencia,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Funcion()
                {
                }
                public  Funcion(DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId,DepositarioAdminWeb.Entities.Relations.Seguridad.TipoFuncion TipoId,String Nombre,String Descripcion,String Referencia,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.AplicacionId = AplicacionId;
                    this.TipoId = TipoId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Referencia = Referencia;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DepositarioAdminWeb.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoFuncion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.TipoFuncion TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DepositarioAdminWeb.Business.Relations.Seguridad.TipoFuncion().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.TipoFuncion TipoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Referencia","Referencia")]
             public String Referencia { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this FuncionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.Menu> ListOf_Menu_FuncionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.Menu entities = new DepositarioAdminWeb.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.Menu.ColumnEnum.FuncionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this FuncionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Directorio.RolFuncion> ListOf_RolFuncion_FuncionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Directorio.RolFuncion entities = new DepositarioAdminWeb.Business.Relations.Directorio.RolFuncion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.RolFuncion.ColumnEnum.FuncionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Funcion 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Menu","Menu")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Menu : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string FuncionId = "FuncionId";
					public const string Imagen = "Imagen";
					public const string DependeDe = "DependeDe";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					Nombre,
					Descripcion,
					FuncionId,
					Imagen,
					DependeDe,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Menu()
                {
                }
                public  Menu(DepositarioAdminWeb.Entities.Relations.Seguridad.TipoMenu TipoId,String Nombre,String Descripcion,DepositarioAdminWeb.Entities.Relations.Seguridad.Funcion FuncionId,String Imagen,DepositarioAdminWeb.Entities.Relations.Seguridad.Menu DependeDe,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.FuncionId = FuncionId;
                    this.Imagen = Imagen;
                    this.DependeDe = DependeDe;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoMenu")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.TipoMenu TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DepositarioAdminWeb.Business.Relations.Seguridad.TipoMenu().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.TipoMenu TipoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("FuncionId","FuncionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _FuncionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Funcion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Funcion FuncionId
             {
                 get {
                     if (FuncionId_ == null || FuncionId_.Id != _FuncionId)
                         {
                             FuncionId = new DepositarioAdminWeb.Business.Relations.Seguridad.Funcion().Items(this._FuncionId).FirstOrDefault();
                         }
                     return FuncionId_;
                     }
                 set {FuncionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Funcion FuncionId_ = null;
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("DependeDe","DependeDe")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DependeDe { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Menu")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Menu DependeDe
             {
                 get {
                     if (DependeDe_ == null || DependeDe_.Id != _DependeDe)
                         {
                             DependeDe = new DepositarioAdminWeb.Business.Relations.Seguridad.Menu().Items(this._DependeDe).FirstOrDefault();
                         }
                     return DependeDe_;
                     }
                 set {DependeDe_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Menu DependeDe_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Menu 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Rol","Rol")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Rol : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string DependeDe = "DependeDe";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					DependeDe,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Rol()
                {
                }
                public  Rol(String Nombre,String Descripcion,DepositarioAdminWeb.Entities.Relations.Seguridad.Rol DependeDe,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.DependeDe = DependeDe;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("DependeDe","DependeDe")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DependeDe { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Rol DependeDe
             {
                 get {
                     if (DependeDe_ == null || DependeDe_.Id != _DependeDe)
                         {
                             DependeDe = new DepositarioAdminWeb.Business.Relations.Seguridad.Rol().Items(this._DependeDe).FirstOrDefault();
                         }
                     return DependeDe_;
                     }
                 set {DependeDe_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Rol DependeDe_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this RolId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Directorio.RolFuncion> ListOf_RolFuncion_RolId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Directorio.RolFuncion entities = new DepositarioAdminWeb.Business.Relations.Directorio.RolFuncion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.RolFuncion.ColumnEnum.RolId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this RolId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_RolId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol entities = new DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.RolId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Rol 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("RolFuncion","RolFuncion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class RolFuncion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string FuncionId = "FuncionId";
					public const string RolId = "RolId";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					FuncionId,
					RolId,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public RolFuncion()
                {
                }
                public  RolFuncion(Int64 FuncionId,Int64 RolId,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.FuncionId = FuncionId;
                    this.RolId = RolId;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int16 Id { get; set; }
             [DataItemAttributeFieldName("FuncionId","FuncionId")]
             public Int64 FuncionId { get; set; }
             [DataItemAttributeFieldName("RolId","RolId")]
             public Int64 RolId { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class RolFuncion 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoAplicacion","TipoAplicacion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoAplicacion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoAplicacion()
                {
                }
                public  TipoAplicacion(String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Aplicacion that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion> ListOf_Aplicacion_TipoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.Aplicacion entities = new DepositarioAdminWeb.Business.Relations.Seguridad.Aplicacion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.Aplicacion.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoAplicacion 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoFuncion","TipoFuncion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoFuncion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoFuncion()
                {
                }
                public  TipoFuncion(String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_TipoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.Funcion entities = new DepositarioAdminWeb.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.Funcion.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoFuncion 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoMenu","TipoMenu")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoMenu : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoMenu()
                {
                }
                public  TipoMenu(String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.Menu> ListOf_Menu_TipoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.Menu entities = new DepositarioAdminWeb.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.Menu.ColumnEnum.TipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoMenu 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Usuario","Usuario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Usuario : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EmpresaId = "EmpresaId";
					public const string LenguajeId = "LenguajeId";
					public const string Nombre = "Nombre";
					public const string Apellido = "Apellido";
					public const string Legajo = "Legajo";
					public const string Mail = "Mail";
					public const string FechaIngreso = "FechaIngreso";
					public const string NickName = "NickName";
					public const string Password = "Password";
					public const string Token = "Token";
					public const string Avatar = "Avatar";
					public const string FechaUltimoLogin = "FechaUltimoLogin";
					public const string DebeCambiarPassword = "DebeCambiarPassword";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					EmpresaId,
					LenguajeId,
					Nombre,
					Apellido,
					Legajo,
					Mail,
					FechaIngreso,
					NickName,
					Password,
					Token,
					Avatar,
					FechaUltimoLogin,
					DebeCambiarPassword,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Usuario()
                {
                }
                public  Usuario(DepositarioAdminWeb.Entities.Relations.Directorio.Empresa EmpresaId,DepositarioAdminWeb.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,String Nombre,String Apellido,String Legajo,String Mail,DateTime FechaIngreso,String NickName,String Password,String Token,String Avatar,DateTime FechaUltimoLogin,Boolean DebeCambiarPassword,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EmpresaId = EmpresaId;
                    this.LenguajeId = LenguajeId;
                    this.Nombre = Nombre;
                    this.Apellido = Apellido;
                    this.Legajo = Legajo;
                    this.Mail = Mail;
                    this.FechaIngreso = FechaIngreso;
                    this.NickName = NickName;
                    this.Password = Password;
                    this.Token = Token;
                    this.Avatar = Avatar;
                    this.FechaUltimoLogin = FechaUltimoLogin;
                    this.DebeCambiarPassword = DebeCambiarPassword;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new DepositarioAdminWeb.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("LenguajeId","LenguajeId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _LenguajeId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Lenguaje")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new DepositarioAdminWeb.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Apellido","Apellido")]
             public String Apellido { get; set; }
             [DataItemAttributeFieldName("Legajo","Legajo")]
             public String Legajo { get; set; }
             [DataItemAttributeFieldName("Mail","Mail")]
             public String Mail { get; set; }
             [DataItemAttributeFieldName("FechaIngreso","FechaIngreso")]
             public DateTime FechaIngreso { get; set; }
             [DataItemAttributeFieldName("NickName","NickName")]
             public String NickName { get; set; }
             [DataItemAttributeFieldName("Password","Password")]
             public String Password { get; set; }
             [DataItemAttributeFieldName("Token","Token")]
             public String Token { get; set; }
             [DataItemAttributeFieldName("Avatar","Avatar")]
             public String Avatar { get; set; }
             [DataItemAttributeFieldName("FechaUltimoLogin","FechaUltimoLogin")]
             public DateTime FechaUltimoLogin { get; set; }
             [DataItemAttributeFieldName("DebeCambiarPassword","DebeCambiarPassword")]
             public Boolean DebeCambiarPassword { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_UsuarioId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol entities = new DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Usuario 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("UsuarioRol","UsuarioRol")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class UsuarioRol : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string UsuarioId = "UsuarioId";
					public const string AplicacionId = "AplicacionId";
					public const string RolId = "RolId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					UsuarioId,
					AplicacionId,
					RolId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public UsuarioRol()
                {
                }
                public  UsuarioRol(DepositarioAdminWeb.Entities.Relations.Seguridad.Usuario UsuarioId,DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId,DepositarioAdminWeb.Entities.Relations.Seguridad.Rol RolId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.UsuarioId = UsuarioId;
                    this.AplicacionId = AplicacionId;
                    this.RolId = RolId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new DepositarioAdminWeb.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DepositarioAdminWeb.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("RolId","RolId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _RolId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Seguridad.Rol RolId
             {
                 get {
                     if (RolId_ == null || RolId_.Id != _RolId)
                         {
                             RolId = new DepositarioAdminWeb.Business.Relations.Seguridad.Rol().Items(this._RolId).FirstOrDefault();
                         }
                     return RolId_;
                     }
                 set {RolId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Seguridad.Rol RolId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class UsuarioRol 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("UsuarioSector","UsuarioSector")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class UsuarioSector : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string UsuarioId = "UsuarioId";
					public const string SectorId = "SectorId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					UsuarioId,
					SectorId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public UsuarioSector()
                {
                }
                public  UsuarioSector(Int64 UsuarioId,Int64 SectorId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.UsuarioId = UsuarioId;
                    this.SectorId = SectorId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             public Int64 SectorId { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class UsuarioSector 
} //namespace DepositarioAdminWeb.Entities.Relations.Seguridad
		namespace DepositarioAdminWeb.Entities.Relations.Sincronizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sincronizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Configuracion","Configuracion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Configuracion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EntidadId = "EntidadId";
					public const string Segundos = "Segundos";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					EntidadId,
					Segundos,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Configuracion()
                {
                }
                public  Configuracion(Int64 EntidadId,Int64 Segundos,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EntidadId = EntidadId;
                    this.Segundos = Segundos;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EntidadId","EntidadId")]
             public Int64 EntidadId { get; set; }
             [DataItemAttributeFieldName("Segundos","Segundos")]
             public Int64 Segundos { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class Configuracion 
} //namespace DepositarioAdminWeb.Entities.Relations.Sincronizacion
		namespace DepositarioAdminWeb.Entities.Relations.Sincronizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sincronizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Entidad","Entidad")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Entidad : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Entidad()
                {
                }
                public  Entidad(String Nombre,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EntidadCabecera that have this EntidadId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Sincronizacion.EntidadCabecera> ListOf_EntidadCabecera_EntidadId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Sincronizacion.EntidadCabecera entities = new DepositarioAdminWeb.Business.Relations.Sincronizacion.EntidadCabecera();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Entidad 
} //namespace DepositarioAdminWeb.Entities.Relations.Sincronizacion
		namespace DepositarioAdminWeb.Entities.Relations.Sincronizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sincronizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("EntidadCabecera","EntidadCabecera")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class EntidadCabecera : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EntidadId = "EntidadId";
					public const string Valor = "Valor";
					public const string Fechainicio = "Fechainicio";
					public const string Fechafin = "Fechafin";
				}
				public enum FieldEnum : int
                {
					Id,
					EntidadId,
					Valor,
					Fechainicio,
					Fechafin
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EntidadCabecera()
                {
                }
                public  EntidadCabecera(DepositarioAdminWeb.Entities.Relations.Sincronizacion.Entidad EntidadId,String Valor,DateTime Fechainicio,DateTime? Fechafin)
                {
                    this.Id = Id;
                    this.EntidadId = EntidadId;
                    this.Valor = Valor;
                    this.Fechainicio = Fechainicio;
                    this.Fechafin = Fechafin;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EntidadId","EntidadId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EntidadId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Entidad")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Sincronizacion.Entidad EntidadId
             {
                 get {
                     if (EntidadId_ == null || EntidadId_.Id != _EntidadId)
                         {
                             EntidadId = new DepositarioAdminWeb.Business.Relations.Sincronizacion.Entidad().Items(this._EntidadId).FirstOrDefault();
                         }
                     return EntidadId_;
                     }
                 set {EntidadId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Sincronizacion.Entidad EntidadId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Fechainicio","Fechainicio")]
             public DateTime Fechainicio { get; set; }
             [DataItemAttributeFieldName("Fechafin","Fechafin")]
             public DateTime? Fechafin { get; set; }
				
			} //Class EntidadCabecera 
} //namespace DepositarioAdminWeb.Entities.Relations.Sincronizacion
		namespace DepositarioAdminWeb.Entities.Relations.Sincronizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sincronizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("EntidadDetalle","EntidadDetalle")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class EntidadDetalle : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EntidadCabeceraId = "EntidadCabeceraId";
					public const string FechaCreacion = "FechaCreacion";
					public const string Valor = "Valor";
				}
				public enum FieldEnum : int
                {
					Id,
					EntidadCabeceraId,
					FechaCreacion,
					Valor
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EntidadDetalle()
                {
                }
                public  EntidadDetalle(Int64 EntidadCabeceraId,DateTime FechaCreacion,String Valor)
                {
                    this.Id = Id;
                    this.EntidadCabeceraId = EntidadCabeceraId;
                    this.FechaCreacion = FechaCreacion;
                    this.Valor = Valor;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EntidadCabeceraId","EntidadCabeceraId")]
             public Int64 EntidadCabeceraId { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EntidadCabecera that have this EntidadId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Sincronizacion.EntidadCabecera> ListOf_EntidadCabecera_EntidadId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Sincronizacion.EntidadCabecera entities = new DepositarioAdminWeb.Business.Relations.Sincronizacion.EntidadCabecera();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class EntidadDetalle 
} //namespace DepositarioAdminWeb.Entities.Relations.Sincronizacion
		namespace DepositarioAdminWeb.Entities.Relations.Turno {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Turno")]  // Database Schema Name
			[DataItemAttributeObjectName("Agenda","Agenda")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Agenda : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string EsquemaDetalleId = "EsquemaDetalleId";
					public const string Fecha = "Fecha";
					public const string SectorId = "SectorId";
					public const string Secuencia = "Secuencia";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					EsquemaDetalleId,
					Fecha,
					SectorId,
					Secuencia,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Agenda()
                {
                }
                public  Agenda(Int64 Id,String Nombre,DepositarioAdminWeb.Entities.Relations.Estilo.EsquemaDetalle EsquemaDetalleId,DateTime Fecha,DepositarioAdminWeb.Entities.Relations.Directorio.Sector SectorId,Int32 Secuencia,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.EsquemaDetalleId = EsquemaDetalleId;
                    this.Fecha = Fecha;
                    this.SectorId = SectorId;
                    this.Secuencia = Secuencia;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("EsquemaDetalleId","EsquemaDetalleId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EsquemaDetalleId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EsquemaDetalle")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Estilo.EsquemaDetalle EsquemaDetalleId
             {
                 get {
                     if (EsquemaDetalleId_ == null || EsquemaDetalleId_.Id != _EsquemaDetalleId)
                         {
                             EsquemaDetalleId = new DepositarioAdminWeb.Business.Relations.Estilo.EsquemaDetalle().Items(this._EsquemaDetalleId).FirstOrDefault();
                         }
                     return EsquemaDetalleId_;
                     }
                 set {EsquemaDetalleId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Estilo.EsquemaDetalle EsquemaDetalleId_ = null;
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new DepositarioAdminWeb.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("Secuencia","Secuencia")]
             public Int32 Secuencia { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Agenda 
} //namespace DepositarioAdminWeb.Entities.Relations.Turno
		namespace DepositarioAdminWeb.Entities.Relations.Turno {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Turno")]  // Database Schema Name
			[DataItemAttributeObjectName("Esquema","Esquema")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Esquema : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Esquema()
                {
                }
                public  Esquema(String Nombre,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Esquema 
} //namespace DepositarioAdminWeb.Entities.Relations.Turno
		namespace DepositarioAdminWeb.Entities.Relations.Turno {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Turno")]  // Database Schema Name
			[DataItemAttributeObjectName("EsquemaDetalle","EsquemaDetalle")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class EsquemaDetalle : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EsquemaTurnoId = "EsquemaTurnoId";
					public const string Nombre = "Nombre";
					public const string Secuencia = "Secuencia";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					EsquemaTurnoId,
					Nombre,
					Secuencia,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EsquemaDetalle()
                {
                }
                public  EsquemaDetalle(Int64 EsquemaTurnoId,String Nombre,Int32 Secuencia,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EsquemaTurnoId = EsquemaTurnoId;
                    this.Nombre = Nombre;
                    this.Secuencia = Secuencia;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EsquemaTurnoId","EsquemaTurnoId")]
             public Int64 EsquemaTurnoId { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Secuencia","Secuencia")]
             public Int32 Secuencia { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class EsquemaDetalle 
} //namespace DepositarioAdminWeb.Entities.Relations.Turno
		namespace DepositarioAdminWeb.Entities.Relations.Valor {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Valor")]  // Database Schema Name
			[DataItemAttributeObjectName("Denominacion","Denominacion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Denominacion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string TipoValorId = "TipoValorId";
					public const string MonedaId = "MonedaId";
					public const string Unidades = "Unidades";
					public const string Imagen = "Imagen";
					public const string CodigoCcTalk = "CodigoCcTalk";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					TipoValorId,
					MonedaId,
					Unidades,
					Imagen,
					CodigoCcTalk,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Denominacion()
                {
                }
                public  Denominacion(String Nombre,DepositarioAdminWeb.Entities.Relations.Valor.Tipo TipoValorId,DepositarioAdminWeb.Entities.Relations.Valor.Moneda MonedaId,Decimal Unidades,String Imagen,String CodigoCcTalk,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.TipoValorId = TipoValorId;
                    this.MonedaId = MonedaId;
                    this.Unidades = Unidades;
                    this.Imagen = Imagen;
                    this.CodigoCcTalk = CodigoCcTalk;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("TipoValorId","TipoValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Tipo")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Valor.Tipo TipoValorId
             {
                 get {
                     if (TipoValorId_ == null || TipoValorId_.Id != _TipoValorId)
                         {
                             TipoValorId = new DepositarioAdminWeb.Business.Relations.Valor.Tipo().Items(this._TipoValorId).FirstOrDefault();
                         }
                     return TipoValorId_;
                     }
                 set {TipoValorId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Valor.Tipo TipoValorId_ = null;
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DepositarioAdminWeb.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("Unidades","Unidades")]
             public Decimal Unidades { get; set; }
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("CodigoCcTalk","CodigoCcTalk")]
             public String CodigoCcTalk { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionDetalle that have this DenominacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.TransaccionDetalle> ListOf_TransaccionDetalle_DenominacionId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.TransaccionDetalle entities = new DepositarioAdminWeb.Business.Relations.Operacion.TransaccionDetalle();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.DenominacionId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Denominacion 
} //namespace DepositarioAdminWeb.Entities.Relations.Valor
		namespace DepositarioAdminWeb.Entities.Relations.Valor {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Valor")]  // Database Schema Name
			[DataItemAttributeObjectName("Moneda","Moneda")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Moneda : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string PaisId = "PaisId";
					public const string Codigo = "Codigo";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					PaisId,
					Codigo,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Moneda()
                {
                }
                public  Moneda(String Nombre,Int64 PaisId,String Codigo,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.PaisId = PaisId;
                    this.Codigo = Codigo;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("PaisId","PaisId")]
             public Int64 PaisId { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_MonedaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal entities = new DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.MonedaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioValor that have this ValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Dispositivo.DepositarioValor> ListOf_DepositarioValor_ValorId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioValor entities = new DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioValor();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Dispositivo.DepositarioValor.ColumnEnum.ValorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_MonedaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Valor.Denominacion entities = new DepositarioAdminWeb.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Valor.Denominacion.ColumnEnum.MonedaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_MonedaId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Valor.RelacionMonedaTipoValor entities = new DepositarioAdminWeb.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.MonedaId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Moneda 
} //namespace DepositarioAdminWeb.Entities.Relations.Valor
		namespace DepositarioAdminWeb.Entities.Relations.Valor {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Valor")]  // Database Schema Name
			[DataItemAttributeObjectName("RelacionMonedaTipoValor","RelacionMonedaTipoValor")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class RelacionMonedaTipoValor : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string MonedaId = "MonedaId";
					public const string TipoValorId = "TipoValorId";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					MonedaId,
					TipoValorId,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public RelacionMonedaTipoValor()
                {
                }
                public  RelacionMonedaTipoValor(DepositarioAdminWeb.Entities.Relations.Valor.Moneda MonedaId,DepositarioAdminWeb.Entities.Relations.Valor.Tipo TipoValorId,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.MonedaId = MonedaId;
                    this.TipoValorId = TipoValorId;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DepositarioAdminWeb.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("TipoValorId","TipoValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Tipo")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Valor.Tipo TipoValorId
             {
                 get {
                     if (TipoValorId_ == null || TipoValorId_.Id != _TipoValorId)
                         {
                             TipoValorId = new DepositarioAdminWeb.Business.Relations.Valor.Tipo().Items(this._TipoValorId).FirstOrDefault();
                         }
                     return TipoValorId_;
                     }
                 set {TipoValorId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Valor.Tipo TipoValorId_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionSobreDetalle that have this RelacionMonedaTipoValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Operacion.TransaccionSobreDetalle> ListOf_TransaccionSobreDetalle_RelacionMonedaTipoValorId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobreDetalle entities = new DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobreDetalle();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.RelacionMonedaTipoValorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class RelacionMonedaTipoValor 
} //namespace DepositarioAdminWeb.Entities.Relations.Valor
		namespace DepositarioAdminWeb.Entities.Relations.Valor {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Valor")]  // Database Schema Name
			[DataItemAttributeObjectName("Tipo","Tipo")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Tipo : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Tipo()
                {
                }
                public  Tipo(String Nombre,String Descripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this TipoValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_TipoValorId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Valor.Denominacion entities = new DepositarioAdminWeb.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Valor.Denominacion.ColumnEnum.TipoValorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this TipoValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_TipoValorId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Valor.RelacionMonedaTipoValor entities = new DepositarioAdminWeb.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.TipoValorId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Tipo 
} //namespace DepositarioAdminWeb.Entities.Relations.Valor
		namespace DepositarioAdminWeb.Entities.Relations.Visualizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Visualizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Perfil","Perfil")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Perfil : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string PerfilTipoId = "PerfilTipoId";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					PerfilTipoId,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Perfil()
                {
                }
                public  Perfil(String Nombre,String Descripcion,DepositarioAdminWeb.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.PerfilTipoId = PerfilTipoId;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("PerfilTipoId","PerfilTipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PerfilTipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("PerfilTipo")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId
             {
                 get {
                     if (PerfilTipoId_ == null || PerfilTipoId_.Id != _PerfilTipoId)
                         {
                             PerfilTipoId = new DepositarioAdminWeb.Business.Relations.Visualizacion.PerfilTipo().Items(this._PerfilTipoId).FirstOrDefault();
                         }
                     return PerfilTipoId_;
                     }
                 set {PerfilTipoId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of PerfilItem that have this PerfilId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Visualizacion.PerfilItem> ListOf_PerfilItem_PerfilId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Visualizacion.PerfilItem entities = new DepositarioAdminWeb.Business.Relations.Visualizacion.PerfilItem();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Visualizacion.PerfilItem.ColumnEnum.PerfilId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Perfil 
} //namespace DepositarioAdminWeb.Entities.Relations.Visualizacion
		namespace DepositarioAdminWeb.Entities.Relations.Visualizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Visualizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("PerfilItem","PerfilItem")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class PerfilItem : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string PerfilId = "PerfilId";
					public const string IdTablaReferencia = "IdTablaReferencia";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					PerfilId,
					IdTablaReferencia,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public PerfilItem()
                {
                }
                public  PerfilItem(DepositarioAdminWeb.Entities.Relations.Visualizacion.Perfil PerfilId,Int64 IdTablaReferencia,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.PerfilId = PerfilId;
                    this.IdTablaReferencia = IdTablaReferencia;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("PerfilId","PerfilId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PerfilId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Perfil")]// Object name in Database
             public DepositarioAdminWeb.Entities.Relations.Visualizacion.Perfil PerfilId
             {
                 get {
                     if (PerfilId_ == null || PerfilId_.Id != _PerfilId)
                         {
                             PerfilId = new DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil().Items(this._PerfilId).FirstOrDefault();
                         }
                     return PerfilId_;
                     }
                 set {PerfilId_  =  value;}
             }
             static DepositarioAdminWeb.Entities.Relations.Visualizacion.Perfil PerfilId_ = null;
             [DataItemAttributeFieldName("IdTablaReferencia","IdTablaReferencia")]
             public Int64 IdTablaReferencia { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class PerfilItem 
} //namespace DepositarioAdminWeb.Entities.Relations.Visualizacion
		namespace DepositarioAdminWeb.Entities.Relations.Visualizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Visualizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("PerfilTipo","PerfilTipo")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class PerfilTipo : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string EsAdministrador = "EsAdministrador";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EsAdministrador,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public PerfilTipo()
                {
                }
                public  PerfilTipo(String Nombre,String Descripcion,Boolean EsAdministrador,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EsAdministrador = EsAdministrador;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EsAdministrador","EsAdministrador")]
             public Boolean EsAdministrador { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64? UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Perfil that have this PerfilTipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DepositarioAdminWeb.Entities.Relations.Visualizacion.Perfil> ListOf_Perfil_PerfilTipoId
                {
                     get {
                             DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil entities = new DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil();
                             entities.Where.Add(DepositarioAdminWeb.Business.Relations.Visualizacion.Perfil.ColumnEnum.PerfilTipoId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class PerfilTipo 
} //namespace DepositarioAdminWeb.Entities.Relations.Visualizacion
