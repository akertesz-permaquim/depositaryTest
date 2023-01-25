using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace DefaultNamespace.Entities.Relations.Aplicacion {
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
					public const string ValidacionDatoId = "ValidacionDatoId";
					public const string Descripcion = "Descripcion";
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
					ValidacionDatoId,
					Descripcion,
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
                public  Configuracion(DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId,DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId,String Descripcion,String Clave,String Valor,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.AplicacionId = AplicacionId;
                    this.ValidacionDatoId = ValidacionDatoId;
                    this.Descripcion = Descripcion;
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
             public DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("ValidacionDatoId","ValidacionDatoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ValidacionDatoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("ConfiguracionValidacionDato")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId
             {
                 get {
                     if (ValidacionDatoId_ == null || ValidacionDatoId_.Id != _ValidacionDatoId)
                         {
                             ValidacionDatoId = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato().Items(this._ValidacionDatoId).FirstOrDefault();
                         }
                     return ValidacionDatoId_;
                     }
                 set {ValidacionDatoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId_ = null;
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Clave","Clave")]
             public String Clave { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class Configuracion 
} //namespace DefaultNamespace.Entities.Relations.Aplicacion
		namespace DefaultNamespace.Entities.Relations.Aplicacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Aplicacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ConfiguracionEmpresa","ConfiguracionEmpresa")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class ConfiguracionEmpresa : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EmpresaId = "EmpresaId";
					public const string ValidacionDatoId = "ValidacionDatoId";
					public const string Descripcion = "Descripcion";
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
					EmpresaId,
					ValidacionDatoId,
					Descripcion,
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
                public ConfiguracionEmpresa()
                {
                }
                public  ConfiguracionEmpresa(DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId,DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId,String Descripcion,String Clave,String Valor,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EmpresaId = EmpresaId;
                    this.ValidacionDatoId = ValidacionDatoId;
                    this.Descripcion = Descripcion;
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
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new DefaultNamespace.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("ValidacionDatoId","ValidacionDatoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ValidacionDatoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("ConfiguracionValidacionDato")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId
             {
                 get {
                     if (ValidacionDatoId_ == null || ValidacionDatoId_.Id != _ValidacionDatoId)
                         {
                             ValidacionDatoId = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato().Items(this._ValidacionDatoId).FirstOrDefault();
                         }
                     return ValidacionDatoId_;
                     }
                 set {ValidacionDatoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId_ = null;
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Clave","Clave")]
             public String Clave { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class ConfiguracionEmpresa 
} //namespace DefaultNamespace.Entities.Relations.Aplicacion
		namespace DefaultNamespace.Entities.Relations.Aplicacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Aplicacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ConfiguracionTipoDato","ConfiguracionTipoDato")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class ConfiguracionTipoDato : IRelationsDataITem
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
                public ConfiguracionTipoDato()
                {
                }
                public  ConfiguracionTipoDato(String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionValidacionDato that have this TipoDatoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato> ListOf_ConfiguracionValidacionDato_TipoDatoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato entities = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato.ColumnEnum.TipoDatoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class ConfiguracionTipoDato 
} //namespace DefaultNamespace.Entities.Relations.Aplicacion
		namespace DefaultNamespace.Entities.Relations.Aplicacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Aplicacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ConfiguracionValidacionDato","ConfiguracionValidacionDato")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class ConfiguracionValidacionDato : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoDatoId = "TipoDatoId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string ExpresionRegular = "ExpresionRegular";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoDatoId,
					Nombre,
					Descripcion,
					ExpresionRegular,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ConfiguracionValidacionDato()
                {
                }
                public  ConfiguracionValidacionDato(DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionTipoDato TipoDatoId,String Nombre,String Descripcion,String ExpresionRegular,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoDatoId = TipoDatoId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.ExpresionRegular = ExpresionRegular;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoDatoId","TipoDatoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoDatoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("ConfiguracionTipoDato")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionTipoDato TipoDatoId
             {
                 get {
                     if (TipoDatoId_ == null || TipoDatoId_.Id != _TipoDatoId)
                         {
                             TipoDatoId = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionTipoDato().Items(this._TipoDatoId).FirstOrDefault();
                         }
                     return TipoDatoId_;
                     }
                 set {TipoDatoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionTipoDato TipoDatoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("ExpresionRegular","ExpresionRegular")]
             public String ExpresionRegular { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Configuracion that have this ValidacionDatoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.Configuracion> ListOf_Configuracion_ValidacionDatoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.Configuracion entities = new DefaultNamespace.Business.Relations.Aplicacion.Configuracion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.Configuracion.ColumnEnum.ValidacionDatoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionEmpresa that have this ValidacionDatoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionEmpresa> ListOf_ConfiguracionEmpresa_ValidacionDatoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa entities = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa.ColumnEnum.ValidacionDatoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoConfiguracionDepositario that have this ValidacionDatoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.TipoConfiguracionDepositario> ListOf_TipoConfiguracionDepositario_ValidacionDatoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario entities = new DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.ValidacionDatoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class ConfiguracionValidacionDato 
} //namespace DefaultNamespace.Entities.Relations.Aplicacion
		namespace DefaultNamespace.Entities.Relations.Auditoria {
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
                public  Log(DefaultNamespace.Entities.Relations.Auditoria.TipoLog TipoId,DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId,DateTime Fecha,String Descripcion,String Detalle,String Modulo,String Metodo,Int64 UsuarioId)
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
             public DefaultNamespace.Entities.Relations.Auditoria.TipoLog TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Auditoria.TipoLog().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Auditoria.TipoLog TipoId_ = null;
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
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
} //namespace DefaultNamespace.Entities.Relations.Auditoria
		namespace DefaultNamespace.Entities.Relations.Auditoria {
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
                public  TipoLog(String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Log that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Auditoria.Log> ListOf_Log_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Auditoria.Log entities = new DefaultNamespace.Business.Relations.Auditoria.Log();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Auditoria.Log.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoLog 
} //namespace DefaultNamespace.Entities.Relations.Auditoria
		namespace DefaultNamespace.Entities.Relations.Banca {
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
                public  Banco(String Nombre,String Descripcion,String Codigo,DefaultNamespace.Entities.Relations.Geografia.Pais PaisId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public DefaultNamespace.Entities.Relations.Geografia.Pais PaisId
             {
                 get {
                     if (PaisId_ == null || PaisId_.Id != _PaisId)
                         {
                             PaisId = new DefaultNamespace.Business.Relations.Geografia.Pais().Items(this._PaisId).FirstOrDefault();
                         }
                     return PaisId_;
                     }
                 set {PaisId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Geografia.Pais PaisId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this BancoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_BancoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.Cuenta entities = new DefaultNamespace.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.Cuenta.ColumnEnum.BancoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Banco 
} //namespace DefaultNamespace.Entities.Relations.Banca
		namespace DefaultNamespace.Entities.Relations.Banca {
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
					public const string EmpresaId = "EmpresaId";
					public const string Nombre = "Nombre";
					public const string Numero = "Numero";
					public const string Alias = "Alias";
					public const string CBU = "CBU";
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
					EmpresaId,
					Nombre,
					Numero,
					Alias,
					CBU,
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
                public  Cuenta(DefaultNamespace.Entities.Relations.Banca.TipoCuenta TipoId,DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId,String Nombre,String Numero,String Alias,String CBU,DefaultNamespace.Entities.Relations.Banca.Banco BancoId,String SucursalBancaria,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.EmpresaId = EmpresaId;
                    this.Nombre = Nombre;
                    this.Numero = Numero;
                    this.Alias = Alias;
                    this.CBU = CBU;
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoCuenta")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Banca.TipoCuenta TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Banca.TipoCuenta().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Banca.TipoCuenta TipoId_ = null;
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new DefaultNamespace.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Numero","Numero")]
             public String Numero { get; set; }
             [DataItemAttributeFieldName("Alias","Alias")]
             public String Alias { get; set; }
             [DataItemAttributeFieldName("CBU","CBU")]
             public String CBU { get; set; }
             [DataItemAttributeFieldName("BancoId","BancoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _BancoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Banco")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Banca.Banco BancoId
             {
                 get {
                     if (BancoId_ == null || BancoId_.Id != _BancoId)
                         {
                             BancoId = new DefaultNamespace.Business.Relations.Banca.Banco().Items(this._BancoId).FirstOrDefault();
                         }
                     return BancoId_;
                     }
                 set {BancoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Banca.Banco BancoId_ = null;
             [DataItemAttributeFieldName("SucursalBancaria","SucursalBancaria")]
             public String SucursalBancaria { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of UsuarioCuenta that have this CuentaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.UsuarioCuenta> ListOf_UsuarioCuenta_CuentaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.UsuarioCuenta entities = new DefaultNamespace.Business.Relations.Banca.UsuarioCuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.CuentaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this CuentaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_CuentaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.CuentaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Cuenta 
} //namespace DefaultNamespace.Entities.Relations.Banca
		namespace DefaultNamespace.Entities.Relations.Banca {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Banca")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoCuenta","TipoCuenta")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoCuenta : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string MonedaId = "MonedaId";
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
					MonedaId,
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
                public TipoCuenta()
                {
                }
                public  TipoCuenta(DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId,String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.MonedaId = MonedaId;
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
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DefaultNamespace.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.Cuenta entities = new DefaultNamespace.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.Cuenta.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoCuenta 
} //namespace DefaultNamespace.Entities.Relations.Banca
		namespace DefaultNamespace.Entities.Relations.Banca {
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
                public  UsuarioCuenta(DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId,DefaultNamespace.Entities.Relations.Banca.Cuenta CuentaId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("CuentaId","CuentaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CuentaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Cuenta")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Banca.Cuenta CuentaId
             {
                 get {
                     if (CuentaId_ == null || CuentaId_.Id != _CuentaId)
                         {
                             CuentaId = new DefaultNamespace.Business.Relations.Banca.Cuenta().Items(this._CuentaId).FirstOrDefault();
                         }
                     return CuentaId_;
                     }
                 set {CuentaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Banca.Cuenta CuentaId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class UsuarioCuenta 
} //namespace DefaultNamespace.Entities.Relations.Banca
		namespace DefaultNamespace.Entities.Relations.Biometria {
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
                public  HuellaDactilar(Int64 UsuarioId,Byte Dedo,String Huella,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class HuellaDactilar 
} //namespace DefaultNamespace.Entities.Relations.Biometria
		namespace DefaultNamespace.Entities.Relations.Customizador {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Customizador")]  // Database Schema Name
			[DataItemAttributeObjectName("Entidad","Entidad")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Entidad : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Tipo = "Tipo";
					public const string Nombre = "Nombre";
					public const string Esquema = "Esquema";
					public const string HabilitarAgrupamiento = "HabilitarAgrupamiento";
					public const string HabilitarMovilidad = "HabilitarMovilidad";
					public const string HabilitarFiltrado = "HabilitarFiltrado";
					public const string HabilitarColumnasOpcionales = "HabilitarColumnasOpcionales";
					public const string HabilitarOrdenamiento = "HabilitarOrdenamiento";
					public const string HabilitarRedimensionamiento = "HabilitarRedimensionamiento";
					public const string HabilitarPaginado = "HabilitarPaginado";
					public const string HabilitarAuditoria = "HabilitarAuditoria";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Tipo,
					Nombre,
					Esquema,
					HabilitarAgrupamiento,
					HabilitarMovilidad,
					HabilitarFiltrado,
					HabilitarColumnasOpcionales,
					HabilitarOrdenamiento,
					HabilitarRedimensionamiento,
					HabilitarPaginado,
					HabilitarAuditoria,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Entidad()
                {
                }
                public  Entidad(String Tipo,String Nombre,String Esquema,Boolean HabilitarAgrupamiento,Boolean HabilitarMovilidad,Boolean HabilitarFiltrado,Boolean HabilitarColumnasOpcionales,Boolean HabilitarOrdenamiento,Boolean HabilitarRedimensionamiento,Boolean HabilitarPaginado,Boolean HabilitarAuditoria,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Tipo = Tipo;
                    this.Nombre = Nombre;
                    this.Esquema = Esquema;
                    this.HabilitarAgrupamiento = HabilitarAgrupamiento;
                    this.HabilitarMovilidad = HabilitarMovilidad;
                    this.HabilitarFiltrado = HabilitarFiltrado;
                    this.HabilitarColumnasOpcionales = HabilitarColumnasOpcionales;
                    this.HabilitarOrdenamiento = HabilitarOrdenamiento;
                    this.HabilitarRedimensionamiento = HabilitarRedimensionamiento;
                    this.HabilitarPaginado = HabilitarPaginado;
                    this.HabilitarAuditoria = HabilitarAuditoria;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Tipo","Tipo")]
             public String Tipo { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Esquema","Esquema")]
             public String Esquema { get; set; }
             [DataItemAttributeFieldName("HabilitarAgrupamiento","HabilitarAgrupamiento")]
             public Boolean HabilitarAgrupamiento { get; set; }
             [DataItemAttributeFieldName("HabilitarMovilidad","HabilitarMovilidad")]
             public Boolean HabilitarMovilidad { get; set; }
             [DataItemAttributeFieldName("HabilitarFiltrado","HabilitarFiltrado")]
             public Boolean HabilitarFiltrado { get; set; }
             [DataItemAttributeFieldName("HabilitarColumnasOpcionales","HabilitarColumnasOpcionales")]
             public Boolean HabilitarColumnasOpcionales { get; set; }
             [DataItemAttributeFieldName("HabilitarOrdenamiento","HabilitarOrdenamiento")]
             public Boolean HabilitarOrdenamiento { get; set; }
             [DataItemAttributeFieldName("HabilitarRedimensionamiento","HabilitarRedimensionamiento")]
             public Boolean HabilitarRedimensionamiento { get; set; }
             [DataItemAttributeFieldName("HabilitarPaginado","HabilitarPaginado")]
             public Boolean HabilitarPaginado { get; set; }
             [DataItemAttributeFieldName("HabilitarAuditoria","HabilitarAuditoria")]
             public Boolean HabilitarAuditoria { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EntidadAtributo that have this EntidadId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Customizador.EntidadAtributo> ListOf_EntidadAtributo_EntidadId
                {
                     get {
                             DefaultNamespace.Business.Relations.Customizador.EntidadAtributo entities = new DefaultNamespace.Business.Relations.Customizador.EntidadAtributo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Customizador.EntidadAtributo.ColumnEnum.EntidadId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EntidadCabecera that have this EntidadId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Sincronizacion.EntidadCabecera> ListOf_EntidadCabecera_EntidadId
                {
                     get {
                             DefaultNamespace.Business.Relations.Sincronizacion.EntidadCabecera entities = new DefaultNamespace.Business.Relations.Sincronizacion.EntidadCabecera();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Entidad 
} //namespace DefaultNamespace.Entities.Relations.Customizador
		namespace DefaultNamespace.Entities.Relations.Customizador {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Customizador")]  // Database Schema Name
			[DataItemAttributeObjectName("EntidadAtributo","EntidadAtributo")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class EntidadAtributo : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EntidadId = "EntidadId";
					public const string Nombre = "Nombre";
					public const string VisibleEnGrilla = "VisibleEnGrilla";
					public const string VisibleEnSelectorColumnas = "VisibleEnSelectorColumnas";
					public const string Redimensionable = "Redimensionable";
					public const string Agrupable = "Agrupable";
					public const string Movible = "Movible";
					public const string Ordenable = "Ordenable";
					public const string Filtrable = "Filtrable";
					public const string PosicionEnGrilla = "PosicionEnGrilla";
					public const string AnchoMinimoEnGrilla = "AnchoMinimoEnGrilla";
					public const string AnchoEnGrilla = "AnchoEnGrilla";
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
					Nombre,
					VisibleEnGrilla,
					VisibleEnSelectorColumnas,
					Redimensionable,
					Agrupable,
					Movible,
					Ordenable,
					Filtrable,
					PosicionEnGrilla,
					AnchoMinimoEnGrilla,
					AnchoEnGrilla,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EntidadAtributo()
                {
                }
                public  EntidadAtributo(DefaultNamespace.Entities.Relations.Customizador.Entidad EntidadId,String Nombre,Boolean VisibleEnGrilla,Boolean VisibleEnSelectorColumnas,Boolean Redimensionable,Boolean Agrupable,Boolean Movible,Boolean Ordenable,Boolean Filtrable,Int32? PosicionEnGrilla,Int32 AnchoMinimoEnGrilla,Int32 AnchoEnGrilla,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EntidadId = EntidadId;
                    this.Nombre = Nombre;
                    this.VisibleEnGrilla = VisibleEnGrilla;
                    this.VisibleEnSelectorColumnas = VisibleEnSelectorColumnas;
                    this.Redimensionable = Redimensionable;
                    this.Agrupable = Agrupable;
                    this.Movible = Movible;
                    this.Ordenable = Ordenable;
                    this.Filtrable = Filtrable;
                    this.PosicionEnGrilla = PosicionEnGrilla;
                    this.AnchoMinimoEnGrilla = AnchoMinimoEnGrilla;
                    this.AnchoEnGrilla = AnchoEnGrilla;
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EntidadId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Entidad")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Customizador.Entidad EntidadId
             {
                 get {
                     if (EntidadId_ == null || EntidadId_.Id != _EntidadId)
                         {
                             EntidadId = new DefaultNamespace.Business.Relations.Customizador.Entidad().Items(this._EntidadId).FirstOrDefault();
                         }
                     return EntidadId_;
                     }
                 set {EntidadId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Customizador.Entidad EntidadId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("VisibleEnGrilla","VisibleEnGrilla")]
             public Boolean VisibleEnGrilla { get; set; }
             [DataItemAttributeFieldName("VisibleEnSelectorColumnas","VisibleEnSelectorColumnas")]
             public Boolean VisibleEnSelectorColumnas { get; set; }
             [DataItemAttributeFieldName("Redimensionable","Redimensionable")]
             public Boolean Redimensionable { get; set; }
             [DataItemAttributeFieldName("Agrupable","Agrupable")]
             public Boolean Agrupable { get; set; }
             [DataItemAttributeFieldName("Movible","Movible")]
             public Boolean Movible { get; set; }
             [DataItemAttributeFieldName("Ordenable","Ordenable")]
             public Boolean Ordenable { get; set; }
             [DataItemAttributeFieldName("Filtrable","Filtrable")]
             public Boolean Filtrable { get; set; }
             [DataItemAttributeFieldName("PosicionEnGrilla","PosicionEnGrilla")]
             public Int32? PosicionEnGrilla { get; set; }
             [DataItemAttributeFieldName("AnchoMinimoEnGrilla","AnchoMinimoEnGrilla")]
             public Int32 AnchoMinimoEnGrilla { get; set; }
             [DataItemAttributeFieldName("AnchoEnGrilla","AnchoEnGrilla")]
             public Int32 AnchoEnGrilla { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class EntidadAtributo 
} //namespace DefaultNamespace.Entities.Relations.Customizador
		namespace DefaultNamespace.Entities.Relations.Directorio {
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
					public const string EsDefault = "EsDefault";
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
					EsDefault,
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
                public  Empresa(String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Directorio.Grupo GrupoId,String CodigoExterno,String Direccion,DefaultNamespace.Entities.Relations.Geografia.CodigoPostal CodigoPostalId,DefaultNamespace.Entities.Relations.Estilo.Esquema EstiloEsquemaId,DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,Boolean Habilitado,Boolean EsDefault,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
                    this.EsDefault = EsDefault;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("GrupoId","GrupoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _GrupoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Grupo")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Grupo GrupoId
             {
                 get {
                     if (GrupoId_ == null || GrupoId_.Id != _GrupoId)
                         {
                             GrupoId = new DefaultNamespace.Business.Relations.Directorio.Grupo().Items(this._GrupoId).FirstOrDefault();
                         }
                     return GrupoId_;
                     }
                 set {GrupoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Grupo GrupoId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Direccion","Direccion")]
             public String Direccion { get; set; }
             [DataItemAttributeFieldName("CodigoPostalId","CodigoPostalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CodigoPostalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CodigoPostal")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Geografia.CodigoPostal CodigoPostalId
             {
                 get {
                     if (CodigoPostalId_ == null || CodigoPostalId_.Id != _CodigoPostalId)
                         {
                             CodigoPostalId = new DefaultNamespace.Business.Relations.Geografia.CodigoPostal().Items(this._CodigoPostalId).FirstOrDefault();
                         }
                     return CodigoPostalId_;
                     }
                 set {CodigoPostalId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Geografia.CodigoPostal CodigoPostalId_ = null;
             [DataItemAttributeFieldName("EstiloEsquemaId","EstiloEsquemaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EstiloEsquemaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Esquema")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Estilo.Esquema EstiloEsquemaId
             {
                 get {
                     if (EstiloEsquemaId_ == null || EstiloEsquemaId_.Id != _EstiloEsquemaId)
                         {
                             EstiloEsquemaId = new DefaultNamespace.Business.Relations.Estilo.Esquema().Items(this._EstiloEsquemaId).FirstOrDefault();
                         }
                     return EstiloEsquemaId_;
                     }
                 set {EstiloEsquemaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Estilo.Esquema EstiloEsquemaId_ = null;
             [DataItemAttributeFieldName("LenguajeId","LenguajeId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _LenguajeId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Lenguaje")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new DefaultNamespace.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("EsDefault","EsDefault")]
             public Boolean EsDefault { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionEmpresa that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionEmpresa> ListOf_ConfiguracionEmpresa_EmpresaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa entities = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa.ColumnEnum.EmpresaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_EmpresaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.Cuenta entities = new DefaultNamespace.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.Cuenta.ColumnEnum.EmpresaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_EmpresaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Sucursal entities = new DefaultNamespace.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Sucursal.ColumnEnum.EmpresaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Impresion.Ticket> ListOf_Ticket_EmpresaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Impresion.Ticket entities = new DefaultNamespace.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Impresion.Ticket.ColumnEnum.EmpresaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Usuario that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Usuario> ListOf_Usuario_EmpresaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Usuario entities = new DefaultNamespace.Business.Relations.Seguridad.Usuario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Usuario.ColumnEnum.EmpresaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of OrigenValor that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.OrigenValor> ListOf_OrigenValor_EmpresaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.OrigenValor entities = new DefaultNamespace.Business.Relations.Valor.OrigenValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.OrigenValor.ColumnEnum.EmpresaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Empresa 
} //namespace DefaultNamespace.Entities.Relations.Directorio
		namespace DefaultNamespace.Entities.Relations.Directorio {
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
                public  Grupo(String Nombre,String Descripcion,String CodigoExterno,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this GrupoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Empresa> ListOf_Empresa_GrupoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Empresa entities = new DefaultNamespace.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Empresa.ColumnEnum.GrupoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Grupo 
} //namespace DefaultNamespace.Entities.Relations.Directorio
		namespace DefaultNamespace.Entities.Relations.Directorio {
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
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					MonedaId,
					SucursalId,
					EsDefault,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public RelacionMonedaSucursal()
                {
                }
                public  RelacionMonedaSucursal(DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId,DefaultNamespace.Entities.Relations.Directorio.Sucursal SucursalId,Boolean EsDefault,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.MonedaId = MonedaId;
                    this.SucursalId = SucursalId;
                    this.EsDefault = EsDefault;
                    this.Habilitado = Habilitado;
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
             public DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DefaultNamespace.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SucursalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sucursal")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Sucursal SucursalId
             {
                 get {
                     if (SucursalId_ == null || SucursalId_.Id != _SucursalId)
                         {
                             SucursalId = new DefaultNamespace.Business.Relations.Directorio.Sucursal().Items(this._SucursalId).FirstOrDefault();
                         }
                     return SucursalId_;
                     }
                 set {SucursalId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Sucursal SucursalId_ = null;
             [DataItemAttributeFieldName("EsDefault","EsDefault")]
             public Boolean EsDefault { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class RelacionMonedaSucursal 
} //namespace DefaultNamespace.Entities.Relations.Directorio
		namespace DefaultNamespace.Entities.Relations.Directorio {
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
                public  Sector(DefaultNamespace.Entities.Relations.Directorio.Sucursal SucursalId,String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public DefaultNamespace.Entities.Relations.Directorio.Sucursal SucursalId
             {
                 get {
                     if (SucursalId_ == null || SucursalId_.Id != _SucursalId)
                         {
                             SucursalId = new DefaultNamespace.Business.Relations.Directorio.Sucursal().Items(this._SucursalId).FirstOrDefault();
                         }
                     return SucursalId_;
                     }
                 set {SucursalId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Sucursal SucursalId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_SectorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Depositario entities = new DefaultNamespace.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Depositario.ColumnEnum.SectorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_SectorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.SectorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Turno> ListOf_Turno_SectorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Turno entities = new DefaultNamespace.Business.Relations.Operacion.Turno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Turno.ColumnEnum.SectorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioSector that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.UsuarioSector> ListOf_UsuarioSector_SectorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.UsuarioSector entities = new DefaultNamespace.Business.Relations.Seguridad.UsuarioSector();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.UsuarioSector.ColumnEnum.SectorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AgendaTurno that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Turno.AgendaTurno> ListOf_AgendaTurno_SectorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Turno.AgendaTurno entities = new DefaultNamespace.Business.Relations.Turno.AgendaTurno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Turno.AgendaTurno.ColumnEnum.SectorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Sector 
} //namespace DefaultNamespace.Entities.Relations.Directorio
		namespace DefaultNamespace.Entities.Relations.Directorio {
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
                public  Sucursal(String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId,String CodigoExterno,String Direccion,DefaultNamespace.Entities.Relations.Geografia.CodigoPostal CodigoPostalId,DefaultNamespace.Entities.Relations.Geografia.Zona ZonaId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new DefaultNamespace.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Direccion","Direccion")]
             public String Direccion { get; set; }
             [DataItemAttributeFieldName("CodigoPostalId","CodigoPostalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CodigoPostalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CodigoPostal")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Geografia.CodigoPostal CodigoPostalId
             {
                 get {
                     if (CodigoPostalId_ == null || CodigoPostalId_.Id != _CodigoPostalId)
                         {
                             CodigoPostalId = new DefaultNamespace.Business.Relations.Geografia.CodigoPostal().Items(this._CodigoPostalId).FirstOrDefault();
                         }
                     return CodigoPostalId_;
                     }
                 set {CodigoPostalId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Geografia.CodigoPostal CodigoPostalId_ = null;
             [DataItemAttributeFieldName("ZonaId","ZonaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ZonaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Zona")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Geografia.Zona ZonaId
             {
                 get {
                     if (ZonaId_ == null || ZonaId_.Id != _ZonaId)
                         {
                             ZonaId = new DefaultNamespace.Business.Relations.Geografia.Zona().Items(this._ZonaId).FirstOrDefault();
                         }
                     return ZonaId_;
                     }
                 set {ZonaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Geografia.Zona ZonaId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this SucursalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_SucursalId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal entities = new DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.SucursalId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sector that have this SucursalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Sector> ListOf_Sector_SucursalId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Sector entities = new DefaultNamespace.Business.Relations.Directorio.Sector();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Sector.ColumnEnum.SucursalId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this SucursalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_SucursalId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.SucursalId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Sucursal 
} //namespace DefaultNamespace.Entities.Relations.Directorio
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("ComandoContadora","ComandoContadora")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class ComandoContadora : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoContadoraId = "TipoContadoraId";
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
					TipoContadoraId,
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
                public  ComandoContadora(DefaultNamespace.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,String Respuesta,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoContadoraId = TipoContadoraId;
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
             [DataItemAttributeFieldName("TipoContadoraId","TipoContadoraId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoContadoraId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoContadora")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId
             {
                 get {
                     if (TipoContadoraId_ == null || TipoContadoraId_.Id != _TipoContadoraId)
                         {
                             TipoContadoraId = new DefaultNamespace.Business.Relations.Dispositivo.TipoContadora().Items(this._TipoContadoraId).FirstOrDefault();
                         }
                     return TipoContadoraId_;
                     }
                 set {TipoContadoraId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class ComandoContadora 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
                public  ComandoPlaca(DefaultNamespace.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,String Respuesta,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public DefaultNamespace.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId
             {
                 get {
                     if (TipoPlacaId_ == null || TipoPlacaId_.Id != _TipoPlacaId)
                         {
                             TipoPlacaId = new DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca().Items(this._TipoPlacaId).FirstOrDefault();
                         }
                     return TipoPlacaId_;
                     }
                 set {TipoPlacaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class ComandoPlaca 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
                public  ConfiguracionDepositario(DefaultNamespace.Entities.Relations.Dispositivo.TipoConfiguracionDepositario TipoId,DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,String Valor,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public DefaultNamespace.Entities.Relations.Dispositivo.TipoConfiguracionDepositario TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.TipoConfiguracionDepositario TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class ConfiguracionDepositario 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
					public const string TipoContenedorId = "TipoContenedorId";
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
					TipoContenedorId,
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
                public  Depositario(String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Directorio.Sector SectorId,String NumeroSerie,String CodigoExterno,DefaultNamespace.Entities.Relations.Dispositivo.Modelo ModeloId,DefaultNamespace.Entities.Relations.Operacion.TipoContenedor TipoContenedorId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.SectorId = SectorId;
                    this.NumeroSerie = NumeroSerie;
                    this.CodigoExterno = CodigoExterno;
                    this.ModeloId = ModeloId;
                    this.TipoContenedorId = TipoContenedorId;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new DefaultNamespace.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("NumeroSerie","NumeroSerie")]
             public String NumeroSerie { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("ModeloId","ModeloId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ModeloId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Modelo")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Modelo ModeloId
             {
                 get {
                     if (ModeloId_ == null || ModeloId_.Id != _ModeloId)
                         {
                             ModeloId = new DefaultNamespace.Business.Relations.Dispositivo.Modelo().Items(this._ModeloId).FirstOrDefault();
                         }
                     return ModeloId_;
                     }
                 set {ModeloId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Modelo ModeloId_ = null;
             [DataItemAttributeFieldName("TipoContenedorId","TipoContenedorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoContenedorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoContenedor")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Operacion.TipoContenedor TipoContenedorId
             {
                 get {
                     if (TipoContenedorId_ == null || TipoContenedorId_.Id != _TipoContenedorId)
                         {
                             TipoContenedorId = new DefaultNamespace.Business.Relations.Operacion.TipoContenedor().Items(this._TipoContenedorId).FirstOrDefault();
                         }
                     return TipoContenedorId_;
                     }
                 set {TipoContenedorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.TipoContenedor TipoContenedorId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioEstado that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioEstado> ListOf_DepositarioEstado_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioEstado entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioEstado();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioEstado.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioMoneda that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioMoneda> ListOf_DepositarioMoneda_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CierreDiario that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.CierreDiario> ListOf_CierreDiario_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.CierreDiario entities = new DefaultNamespace.Business.Relations.Operacion.CierreDiario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.CierreDiario.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Contenedor that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Contenedor> ListOf_Contenedor_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Contenedor entities = new DefaultNamespace.Business.Relations.Operacion.Contenedor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Contenedor.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Evento that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Evento> ListOf_Evento_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Evento entities = new DefaultNamespace.Business.Relations.Operacion.Evento();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Evento.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sesion that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Sesion> ListOf_Sesion_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Sesion entities = new DefaultNamespace.Business.Relations.Operacion.Sesion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Sesion.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Turno> ListOf_Turno_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Turno entities = new DefaultNamespace.Business.Relations.Operacion.Turno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Turno.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EntidadCabecera that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Sincronizacion.EntidadCabecera> ListOf_EntidadCabecera_DepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Sincronizacion.EntidadCabecera entities = new DefaultNamespace.Business.Relations.Sincronizacion.EntidadCabecera();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Sincronizacion.EntidadCabecera.ColumnEnum.DepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Depositario 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("DepositarioContadora","DepositarioContadora")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class DepositarioContadora : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoContadoraId = "TipoContadoraId";
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
					public const string PollTime = "PollTime";
					public const string Sleeptime = "Sleeptime";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoContadoraId,
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
					PollTime,
					Sleeptime,
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
                public  DepositarioContadora(DefaultNamespace.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId,DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,String NumeroSerie,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Int32 PollTime,Int32 Sleeptime,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoContadoraId = TipoContadoraId;
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
                    this.PollTime = PollTime;
                    this.Sleeptime = Sleeptime;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoContadoraId","TipoContadoraId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoContadoraId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoContadora")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId
             {
                 get {
                     if (TipoContadoraId_ == null || TipoContadoraId_.Id != _TipoContadoraId)
                         {
                             TipoContadoraId = new DefaultNamespace.Business.Relations.Dispositivo.TipoContadora().Items(this._TipoContadoraId).FirstOrDefault();
                         }
                     return TipoContadoraId_;
                     }
                 set {TipoContadoraId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
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
             [DataItemAttributeFieldName("PollTime","PollTime")]
             public Int32 PollTime { get; set; }
             [DataItemAttributeFieldName("Sleeptime","Sleeptime")]
             public Int32 Sleeptime { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioContadora 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
					public const string ContadoraA = "ContadoraA";
					public const string ContadoraB = "ContadoraB";
					public const string Placa = "Placa";
					public const string Puerta = "Puerta";
					public const string Contenedor = "Contenedor";
					public const string Impresora = "Impresora";
					public const string FueraDeServicio = "FueraDeServicio";
					public const string Observaciones = "Observaciones";
					public const string Fecha = "Fecha";
				}
				public enum FieldEnum : int
                {
					Id,
					DepositarioId,
					ContadoraA,
					ContadoraB,
					Placa,
					Puerta,
					Contenedor,
					Impresora,
					FueraDeServicio,
					Observaciones,
					Fecha
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public DepositarioEstado()
                {
                }
                public  DepositarioEstado(DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,String ContadoraA,String ContadoraB,String Placa,String Puerta,String Contenedor,String Impresora,Boolean FueraDeServicio,String Observaciones,DateTime Fecha)
                {
                    this.Id = Id;
                    this.DepositarioId = DepositarioId;
                    this.ContadoraA = ContadoraA;
                    this.ContadoraB = ContadoraB;
                    this.Placa = Placa;
                    this.Puerta = Puerta;
                    this.Contenedor = Contenedor;
                    this.Impresora = Impresora;
                    this.FueraDeServicio = FueraDeServicio;
                    this.Observaciones = Observaciones;
                    this.Fecha = Fecha;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
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
             [DataItemAttributeFieldName("Impresora","Impresora")]
             public String Impresora { get; set; }
             [DataItemAttributeFieldName("FueraDeServicio","FueraDeServicio")]
             public Boolean FueraDeServicio { get; set; }
             [DataItemAttributeFieldName("Observaciones","Observaciones")]
             public String Observaciones { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class DepositarioEstado 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("DepositarioMoneda","DepositarioMoneda")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class DepositarioMoneda : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string DepositarioId = "DepositarioId";
					public const string MonedaId = "MonedaId";
					public const string IndiceEnContadora = "IndiceEnContadora";
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
					MonedaId,
					IndiceEnContadora,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public DepositarioMoneda()
                {
                }
                public  DepositarioMoneda(DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId,Int32 IndiceEnContadora,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.DepositarioId = DepositarioId;
                    this.MonedaId = MonedaId;
                    this.IndiceEnContadora = IndiceEnContadora;
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
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DefaultNamespace.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("IndiceEnContadora","IndiceEnContadora")]
             public Int32 IndiceEnContadora { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioMoneda 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
					public const string TipoPlacaId = "TipoPlacaId";
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
					public const string PollTime = "PollTime";
					public const string Sleeptime = "Sleeptime";
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
					TipoPlacaId,
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
					PollTime,
					Sleeptime,
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
                public  DepositarioPlaca(DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,DefaultNamespace.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Boolean SensorA,Int16 BitSensorA,Boolean SensorB,Int16 BitSensorB,Boolean SensorC,Int16 BitSensorC,Boolean SensorD,Int16 BitSensorD,Boolean SensorL,Int16 BitSensorL,Int32 PollTime,Int32 Sleeptime,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.DepositarioId = DepositarioId;
                    this.TipoPlacaId = TipoPlacaId;
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
                    this.PollTime = PollTime;
                    this.Sleeptime = Sleeptime;
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
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("TipoPlacaId","TipoPlacaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoPlacaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoPlaca")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId
             {
                 get {
                     if (TipoPlacaId_ == null || TipoPlacaId_.Id != _TipoPlacaId)
                         {
                             TipoPlacaId = new DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca().Items(this._TipoPlacaId).FirstOrDefault();
                         }
                     return TipoPlacaId_;
                     }
                 set {TipoPlacaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId_ = null;
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
             [DataItemAttributeFieldName("PollTime","PollTime")]
             public Int32 PollTime { get; set; }
             [DataItemAttributeFieldName("Sleeptime","Sleeptime")]
             public Int32 Sleeptime { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioPlaca 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
                public  Marca(String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Modelo that have this MarcaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Modelo> ListOf_Modelo_MarcaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Modelo entities = new DefaultNamespace.Business.Relations.Dispositivo.Modelo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Modelo.ColumnEnum.MarcaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Marca 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
					public const string Imagen = "Imagen";
					public const string PlantillaMonedaId = "PlantillaMonedaId";
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
					Imagen,
					PlantillaMonedaId,
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
                public  Modelo(DefaultNamespace.Entities.Relations.Dispositivo.Marca MarcaId,String Nombre,String Descripcion,String Imagen,DefaultNamespace.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.MarcaId = MarcaId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Imagen = Imagen;
                    this.PlantillaMonedaId = PlantillaMonedaId;
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
             public DefaultNamespace.Entities.Relations.Dispositivo.Marca MarcaId
             {
                 get {
                     if (MarcaId_ == null || MarcaId_.Id != _MarcaId)
                         {
                             MarcaId = new DefaultNamespace.Business.Relations.Dispositivo.Marca().Items(this._MarcaId).FirstOrDefault();
                         }
                     return MarcaId_;
                     }
                 set {MarcaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Marca MarcaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("PlantillaMonedaId","PlantillaMonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PlantillaMonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("PlantillaMoneda")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId
             {
                 get {
                     if (PlantillaMonedaId_ == null || PlantillaMonedaId_.Id != _PlantillaMonedaId)
                         {
                             PlantillaMonedaId = new DefaultNamespace.Business.Relations.Dispositivo.PlantillaMoneda().Items(this._PlantillaMonedaId).FirstOrDefault();
                         }
                     return PlantillaMonedaId_;
                     }
                 set {PlantillaMonedaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this ModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_ModeloId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Depositario entities = new DefaultNamespace.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Depositario.ColumnEnum.ModeloId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContadora that have this ModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.TipoContadora> ListOf_TipoContadora_ModeloId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.TipoContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.TipoContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.TipoContadora.ColumnEnum.ModeloId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoPlaca that have this ModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.TipoPlaca> ListOf_TipoPlaca_ModeloId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca.ColumnEnum.ModeloId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaTicket that have this DepositarioModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Impresion.PlantillaTicket> ListOf_PlantillaTicket_DepositarioModeloId
                {
                     get {
                             DefaultNamespace.Business.Relations.Impresion.PlantillaTicket entities = new DefaultNamespace.Business.Relations.Impresion.PlantillaTicket();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Impresion.PlantillaTicket.ColumnEnum.DepositarioModeloId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this DepositarioModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Impresion.Ticket> ListOf_Ticket_DepositarioModeloId
                {
                     get {
                             DefaultNamespace.Business.Relations.Impresion.Ticket entities = new DefaultNamespace.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Impresion.Ticket.ColumnEnum.DepositarioModeloId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Modelo 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("PlantillaMoneda","PlantillaMoneda")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class PlantillaMoneda : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Decripcion = "Decripcion";
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
					Decripcion,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public PlantillaMoneda()
                {
                }
                public  PlantillaMoneda(String Nombre,String Decripcion,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Decripcion = Decripcion;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Decripcion","Decripcion")]
             public String Decripcion { get; set; }
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
                 ///  Represents the child collection of Modelo that have this PlantillaMonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Modelo> ListOf_Modelo_PlantillaMonedaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Modelo entities = new DefaultNamespace.Business.Relations.Dispositivo.Modelo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Modelo.ColumnEnum.PlantillaMonedaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaMonedaDetalle that have this PlantillaMonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.PlantillaMonedaDetalle> ListOf_PlantillaMonedaDetalle_PlantillaMonedaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.PlantillaMonedaDetalle entities = new DefaultNamespace.Business.Relations.Dispositivo.PlantillaMonedaDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.PlantillaMonedaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class PlantillaMoneda 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("PlantillaMonedaDetalle","PlantillaMonedaDetalle")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class PlantillaMonedaDetalle : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string PlantillaMonedaId = "PlantillaMonedaId";
					public const string Nombre = "Nombre";
					public const string Decripcion = "Decripcion";
					public const string MonedaId = "MonedaId";
					public const string Secuencia = "Secuencia";
					public const string Habilitado = "Habilitado";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					PlantillaMonedaId,
					Nombre,
					Decripcion,
					MonedaId,
					Secuencia,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public PlantillaMonedaDetalle()
                {
                }
                public  PlantillaMonedaDetalle(DefaultNamespace.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId,String Nombre,String Decripcion,DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId,Int16 Secuencia,Boolean Habilitado,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64? UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.PlantillaMonedaId = PlantillaMonedaId;
                    this.Nombre = Nombre;
                    this.Decripcion = Decripcion;
                    this.MonedaId = MonedaId;
                    this.Secuencia = Secuencia;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("PlantillaMonedaId","PlantillaMonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PlantillaMonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("PlantillaMoneda")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId
             {
                 get {
                     if (PlantillaMonedaId_ == null || PlantillaMonedaId_.Id != _PlantillaMonedaId)
                         {
                             PlantillaMonedaId = new DefaultNamespace.Business.Relations.Dispositivo.PlantillaMoneda().Items(this._PlantillaMonedaId).FirstOrDefault();
                         }
                     return PlantillaMonedaId_;
                     }
                 set {PlantillaMonedaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Decripcion","Decripcion")]
             public String Decripcion { get; set; }
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DefaultNamespace.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("Secuencia","Secuencia")]
             public Int16 Secuencia { get; set; }
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
				
			} //Class PlantillaMonedaDetalle 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
					public const string ValidacionDatoId = "ValidacionDatoId";
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
					Clave,
					Nombre,
					Descripcion,
					ValidacionDatoId,
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
                public TipoConfiguracionDepositario()
                {
                }
                public  TipoConfiguracionDepositario(String Clave,String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId,String Valor,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Clave = Clave;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.ValidacionDatoId = ValidacionDatoId;
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
             [DataItemAttributeFieldName("Clave","Clave")]
             public String Clave { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("ValidacionDatoId","ValidacionDatoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ValidacionDatoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("ConfiguracionValidacionDato")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId
             {
                 get {
                     if (ValidacionDatoId_ == null || ValidacionDatoId_.Id != _ValidacionDatoId)
                         {
                             ValidacionDatoId = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato().Items(this._ValidacionDatoId).FirstOrDefault();
                         }
                     return ValidacionDatoId_;
                     }
                 set {ValidacionDatoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoConfiguracionDepositario 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
					public const string PollTime = "PollTime";
					public const string Sleeptime = "Sleeptime";
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
					PollTime,
					Sleeptime,
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
                public  TipoContadora(DefaultNamespace.Entities.Relations.Dispositivo.Modelo ModeloId,String Nombre,String Descripcion,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Int32 PollTime,Int32 Sleeptime,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
                    this.PollTime = PollTime;
                    this.Sleeptime = Sleeptime;
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
             public DefaultNamespace.Entities.Relations.Dispositivo.Modelo ModeloId
             {
                 get {
                     if (ModeloId_ == null || ModeloId_.Id != _ModeloId)
                         {
                             ModeloId = new DefaultNamespace.Business.Relations.Dispositivo.Modelo().Items(this._ModeloId).FirstOrDefault();
                         }
                     return ModeloId_;
                     }
                 set {ModeloId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Modelo ModeloId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
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
             [DataItemAttributeFieldName("PollTime","PollTime")]
             public Int32 PollTime { get; set; }
             [DataItemAttributeFieldName("Sleeptime","Sleeptime")]
             public Int32 Sleeptime { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ComandoContadora that have this TipoContadoraId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ComandoContadora> ListOf_ComandoContadora_TipoContadoraId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ComandoContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.ComandoContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ComandoContadora.ColumnEnum.TipoContadoraId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this TipoContadoraId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_TipoContadoraId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.TipoContadoraId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoContadora 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Dispositivo {
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
					public const string PollTime = "PollTime";
					public const string Sleeptime = "Sleeptime";
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
					PollTime,
					Sleeptime,
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
                public  TipoPlaca(DefaultNamespace.Entities.Relations.Dispositivo.Modelo ModeloId,String Nombre,String Descripcion,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Boolean SensorA,Int16 BitSensorA,Boolean SensorB,Int16 BitSensorB,Boolean SensorC,Int16 BitSensorC,Boolean SensorD,Int16 BitSensorD,Boolean SensorL,Int16 BitSensorL,Int32 PollTime,Int32 Sleeptime,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
                    this.PollTime = PollTime;
                    this.Sleeptime = Sleeptime;
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
             public DefaultNamespace.Entities.Relations.Dispositivo.Modelo ModeloId
             {
                 get {
                     if (ModeloId_ == null || ModeloId_.Id != _ModeloId)
                         {
                             ModeloId = new DefaultNamespace.Business.Relations.Dispositivo.Modelo().Items(this._ModeloId).FirstOrDefault();
                         }
                     return ModeloId_;
                     }
                 set {ModeloId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Modelo ModeloId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
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
             [DataItemAttributeFieldName("PollTime","PollTime")]
             public Int32 PollTime { get; set; }
             [DataItemAttributeFieldName("Sleeptime","Sleeptime")]
             public Int32 Sleeptime { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ComandoPlaca that have this TipoPlacaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ComandoPlaca> ListOf_ComandoPlaca_TipoPlacaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ComandoPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.ComandoPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ComandoPlaca.ColumnEnum.TipoPlacaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this TipoPlacaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_TipoPlacaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.TipoPlacaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoPlaca 
} //namespace DefaultNamespace.Entities.Relations.Dispositivo
		namespace DefaultNamespace.Entities.Relations.Estilo {
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
					public const string EsDefault = "EsDefault";
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
					EsDefault,
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
                public  Esquema(String Nombre,String Descripcion,Boolean EsDefault,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EsDefault = EsDefault;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EsDefault","EsDefault")]
             public Boolean EsDefault { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this EstiloEsquemaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Empresa> ListOf_Empresa_EstiloEsquemaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Empresa entities = new DefaultNamespace.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Empresa.ColumnEnum.EstiloEsquemaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this EsquemaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_EsquemaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle entities = new DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Esquema 
} //namespace DefaultNamespace.Entities.Relations.Estilo
		namespace DefaultNamespace.Entities.Relations.Estilo {
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
					public const string AplicacionId = "AplicacionId";
					public const string TipoEsquemaDetalleId = "TipoEsquemaDetalleId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Valor = "Valor";
					public const string Imagen = "Imagen";
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
					AplicacionId,
					TipoEsquemaDetalleId,
					Nombre,
					Descripcion,
					Valor,
					Imagen,
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
                public  EsquemaDetalle(DefaultNamespace.Entities.Relations.Estilo.Esquema EsquemaId,DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId,DefaultNamespace.Entities.Relations.Estilo.TipoEsquemaDetalle TipoEsquemaDetalleId,String Nombre,String Descripcion,String Valor,String Imagen,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EsquemaId = EsquemaId;
                    this.AplicacionId = AplicacionId;
                    this.TipoEsquemaDetalleId = TipoEsquemaDetalleId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Valor = Valor;
                    this.Imagen = Imagen;
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
             public DefaultNamespace.Entities.Relations.Estilo.Esquema EsquemaId
             {
                 get {
                     if (EsquemaId_ == null || EsquemaId_.Id != _EsquemaId)
                         {
                             EsquemaId = new DefaultNamespace.Business.Relations.Estilo.Esquema().Items(this._EsquemaId).FirstOrDefault();
                         }
                     return EsquemaId_;
                     }
                 set {EsquemaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Estilo.Esquema EsquemaId_ = null;
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("TipoEsquemaDetalleId","TipoEsquemaDetalleId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoEsquemaDetalleId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoEsquemaDetalle")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Estilo.TipoEsquemaDetalle TipoEsquemaDetalleId
             {
                 get {
                     if (TipoEsquemaDetalleId_ == null || TipoEsquemaDetalleId_.Id != _TipoEsquemaDetalleId)
                         {
                             TipoEsquemaDetalleId = new DefaultNamespace.Business.Relations.Estilo.TipoEsquemaDetalle().Items(this._TipoEsquemaDetalleId).FirstOrDefault();
                         }
                     return TipoEsquemaDetalleId_;
                     }
                 set {TipoEsquemaDetalleId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Estilo.TipoEsquemaDetalle TipoEsquemaDetalleId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class EsquemaDetalle 
} //namespace DefaultNamespace.Entities.Relations.Estilo
		namespace DefaultNamespace.Entities.Relations.Estilo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Estilo")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoEsquemaDetalle","TipoEsquemaDetalle")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoEsquemaDetalle : IRelationsDataITem
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
                public TipoEsquemaDetalle()
                {
                }
                public  TipoEsquemaDetalle(String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this TipoEsquemaDetalleId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_TipoEsquemaDetalleId
                {
                     get {
                             DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle entities = new DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.TipoEsquemaDetalleId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoEsquemaDetalle 
} //namespace DefaultNamespace.Entities.Relations.Estilo
		namespace DefaultNamespace.Entities.Relations.Geografia {
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
                public  Ciudad(String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Geografia.Provincia ProvinciaId,String CodigoExterno,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("ProvinciaId","ProvinciaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ProvinciaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Provincia")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Geografia.Provincia ProvinciaId
             {
                 get {
                     if (ProvinciaId_ == null || ProvinciaId_.Id != _ProvinciaId)
                         {
                             ProvinciaId = new DefaultNamespace.Business.Relations.Geografia.Provincia().Items(this._ProvinciaId).FirstOrDefault();
                         }
                     return ProvinciaId_;
                     }
                 set {ProvinciaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Geografia.Provincia ProvinciaId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of CodigoPostal that have this CiudadId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.CodigoPostal> ListOf_CodigoPostal_CiudadId
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.CodigoPostal entities = new DefaultNamespace.Business.Relations.Geografia.CodigoPostal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.CodigoPostal.ColumnEnum.CiudadId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Ciudad 
} //namespace DefaultNamespace.Entities.Relations.Geografia
		namespace DefaultNamespace.Entities.Relations.Geografia {
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
                public  CodigoPostal(String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Geografia.Ciudad CiudadId,String CodigoExterno,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("CiudadId","CiudadId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CiudadId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Ciudad")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Geografia.Ciudad CiudadId
             {
                 get {
                     if (CiudadId_ == null || CiudadId_.Id != _CiudadId)
                         {
                             CiudadId = new DefaultNamespace.Business.Relations.Geografia.Ciudad().Items(this._CiudadId).FirstOrDefault();
                         }
                     return CiudadId_;
                     }
                 set {CiudadId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Geografia.Ciudad CiudadId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this CodigoPostalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Empresa> ListOf_Empresa_CodigoPostalId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Empresa entities = new DefaultNamespace.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Empresa.ColumnEnum.CodigoPostalId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this CodigoPostalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_CodigoPostalId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Sucursal entities = new DefaultNamespace.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Sucursal.ColumnEnum.CodigoPostalId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class CodigoPostal 
} //namespace DefaultNamespace.Entities.Relations.Geografia
		namespace DefaultNamespace.Entities.Relations.Geografia {
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
                public  Pais(String Nombre,String Descripcion,String Codigo,String CodigoExterno,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Banco that have this PaisId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.Banco> ListOf_Banco_PaisId
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.Banco entities = new DefaultNamespace.Business.Relations.Banca.Banco();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.Banco.ColumnEnum.PaisId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Provincia that have this PaisId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Provincia> ListOf_Provincia_PaisId
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Provincia entities = new DefaultNamespace.Business.Relations.Geografia.Provincia();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Provincia.ColumnEnum.PaisId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Moneda that have this PaisId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.Moneda> ListOf_Moneda_PaisId
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.Moneda entities = new DefaultNamespace.Business.Relations.Valor.Moneda();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.Moneda.ColumnEnum.PaisId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Pais 
} //namespace DefaultNamespace.Entities.Relations.Geografia
		namespace DefaultNamespace.Entities.Relations.Geografia {
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
                public  Provincia(String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Geografia.Pais PaisId,String CodigoExterno,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("PaisId","PaisId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PaisId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Pais")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Geografia.Pais PaisId
             {
                 get {
                     if (PaisId_ == null || PaisId_.Id != _PaisId)
                         {
                             PaisId = new DefaultNamespace.Business.Relations.Geografia.Pais().Items(this._PaisId).FirstOrDefault();
                         }
                     return PaisId_;
                     }
                 set {PaisId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Geografia.Pais PaisId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Ciudad that have this ProvinciaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Ciudad> ListOf_Ciudad_ProvinciaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Ciudad entities = new DefaultNamespace.Business.Relations.Geografia.Ciudad();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Ciudad.ColumnEnum.ProvinciaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Provincia 
} //namespace DefaultNamespace.Entities.Relations.Geografia
		namespace DefaultNamespace.Entities.Relations.Geografia {
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
                public  Zona(String Nombre,String Descripcion,String Codigo,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this ZonaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_ZonaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Sucursal entities = new DefaultNamespace.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Sucursal.ColumnEnum.ZonaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Zona 
} //namespace DefaultNamespace.Entities.Relations.Geografia
		namespace DefaultNamespace.Entities.Relations.Impresion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Impresion")]  // Database Schema Name
			[DataItemAttributeObjectName("PlantillaTicket","PlantillaTicket")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class PlantillaTicket : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string DepositarioModeloId = "DepositarioModeloId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Impresora = "Impresora";
					public const string TextoCabecera = "TextoCabecera";
					public const string NombreFuenteCabecera = "NombreFuenteCabecera";
					public const string TamanioFuenteCabecera = "TamanioFuenteCabecera";
					public const string UbicacionTextoCabecera = "UbicacionTextoCabecera";
					public const string TextoPie = "TextoPie";
					public const string NombreFuentePie = "NombreFuentePie";
					public const string TamanioFuentePie = "TamanioFuentePie";
					public const string UbicacionTextoPie = "UbicacionTextoPie";
					public const string Imagen = "Imagen";
					public const string UbicacionImagen = "UbicacionImagen";
					public const string UbicacionTextoDetalle = "UbicacionTextoDetalle";
					public const string AnchoDetalle = "AnchoDetalle";
					public const string TamanioEntreLineas = "TamanioEntreLineas";
					public const string AnchoReporte = "AnchoReporte";
					public const string FactorAltoReporte = "FactorAltoReporte";
					public const string LineasAlFinal = "LineasAlFinal";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					DepositarioModeloId,
					Nombre,
					Descripcion,
					Impresora,
					TextoCabecera,
					NombreFuenteCabecera,
					TamanioFuenteCabecera,
					UbicacionTextoCabecera,
					TextoPie,
					NombreFuentePie,
					TamanioFuentePie,
					UbicacionTextoPie,
					Imagen,
					UbicacionImagen,
					UbicacionTextoDetalle,
					AnchoDetalle,
					TamanioEntreLineas,
					AnchoReporte,
					FactorAltoReporte,
					LineasAlFinal
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public PlantillaTicket()
                {
                }
                public  PlantillaTicket(DefaultNamespace.Entities.Relations.Impresion.TipoTicket TipoId,DefaultNamespace.Entities.Relations.Dispositivo.Modelo DepositarioModeloId,String Nombre,String Descripcion,String Impresora,String TextoCabecera,String NombreFuenteCabecera,Int32 TamanioFuenteCabecera,Int32 UbicacionTextoCabecera,String TextoPie,String NombreFuentePie,Int32 TamanioFuentePie,String UbicacionTextoPie,String Imagen,String UbicacionImagen,Int32 UbicacionTextoDetalle,Int32 AnchoDetalle,Int32 TamanioEntreLineas,Int32 AnchoReporte,Int32 FactorAltoReporte,Int32 LineasAlFinal)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.DepositarioModeloId = DepositarioModeloId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Impresora = Impresora;
                    this.TextoCabecera = TextoCabecera;
                    this.NombreFuenteCabecera = NombreFuenteCabecera;
                    this.TamanioFuenteCabecera = TamanioFuenteCabecera;
                    this.UbicacionTextoCabecera = UbicacionTextoCabecera;
                    this.TextoPie = TextoPie;
                    this.NombreFuentePie = NombreFuentePie;
                    this.TamanioFuentePie = TamanioFuentePie;
                    this.UbicacionTextoPie = UbicacionTextoPie;
                    this.Imagen = Imagen;
                    this.UbicacionImagen = UbicacionImagen;
                    this.UbicacionTextoDetalle = UbicacionTextoDetalle;
                    this.AnchoDetalle = AnchoDetalle;
                    this.TamanioEntreLineas = TamanioEntreLineas;
                    this.AnchoReporte = AnchoReporte;
                    this.FactorAltoReporte = FactorAltoReporte;
                    this.LineasAlFinal = LineasAlFinal;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoTicket")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Impresion.TipoTicket TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Impresion.TipoTicket().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Impresion.TipoTicket TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioModeloId","DepositarioModeloId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioModeloId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Modelo")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Modelo DepositarioModeloId
             {
                 get {
                     if (DepositarioModeloId_ == null || DepositarioModeloId_.Id != _DepositarioModeloId)
                         {
                             DepositarioModeloId = new DefaultNamespace.Business.Relations.Dispositivo.Modelo().Items(this._DepositarioModeloId).FirstOrDefault();
                         }
                     return DepositarioModeloId_;
                     }
                 set {DepositarioModeloId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Modelo DepositarioModeloId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Impresora","Impresora")]
             public String Impresora { get; set; }
             [DataItemAttributeFieldName("TextoCabecera","TextoCabecera")]
             public String TextoCabecera { get; set; }
             [DataItemAttributeFieldName("NombreFuenteCabecera","NombreFuenteCabecera")]
             public String NombreFuenteCabecera { get; set; }
             [DataItemAttributeFieldName("TamanioFuenteCabecera","TamanioFuenteCabecera")]
             public Int32 TamanioFuenteCabecera { get; set; }
             [DataItemAttributeFieldName("UbicacionTextoCabecera","UbicacionTextoCabecera")]
             public Int32 UbicacionTextoCabecera { get; set; }
             [DataItemAttributeFieldName("TextoPie","TextoPie")]
             public String TextoPie { get; set; }
             [DataItemAttributeFieldName("NombreFuentePie","NombreFuentePie")]
             public String NombreFuentePie { get; set; }
             [DataItemAttributeFieldName("TamanioFuentePie","TamanioFuentePie")]
             public Int32 TamanioFuentePie { get; set; }
             [DataItemAttributeFieldName("UbicacionTextoPie","UbicacionTextoPie")]
             public String UbicacionTextoPie { get; set; }
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("UbicacionImagen","UbicacionImagen")]
             public String UbicacionImagen { get; set; }
             [DataItemAttributeFieldName("UbicacionTextoDetalle","UbicacionTextoDetalle")]
             public Int32 UbicacionTextoDetalle { get; set; }
             [DataItemAttributeFieldName("AnchoDetalle","AnchoDetalle")]
             public Int32 AnchoDetalle { get; set; }
             [DataItemAttributeFieldName("TamanioEntreLineas","TamanioEntreLineas")]
             public Int32 TamanioEntreLineas { get; set; }
             [DataItemAttributeFieldName("AnchoReporte","AnchoReporte")]
             public Int32 AnchoReporte { get; set; }
             [DataItemAttributeFieldName("FactorAltoReporte","FactorAltoReporte")]
             public Int32 FactorAltoReporte { get; set; }
             [DataItemAttributeFieldName("LineasAlFinal","LineasAlFinal")]
             public Int32 LineasAlFinal { get; set; }
				
			} //Class PlantillaTicket 
} //namespace DefaultNamespace.Entities.Relations.Impresion
		namespace DefaultNamespace.Entities.Relations.Impresion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Impresion")]  // Database Schema Name
			[DataItemAttributeObjectName("Ticket","Ticket")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Ticket : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string DepositarioModeloId = "DepositarioModeloId";
					public const string EmpresaId = "EmpresaId";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Impresora = "Impresora";
					public const string TextoCabecera = "TextoCabecera";
					public const string NombreFuenteCabecera = "NombreFuenteCabecera";
					public const string TamanioFuenteCabecera = "TamanioFuenteCabecera";
					public const string UbicacionTextoCabecera = "UbicacionTextoCabecera";
					public const string TextoPie = "TextoPie";
					public const string NombreFuentePie = "NombreFuentePie";
					public const string TamanioFuentePie = "TamanioFuentePie";
					public const string UbicacionTextoPie = "UbicacionTextoPie";
					public const string Imagen = "Imagen";
					public const string UbicacionImagen = "UbicacionImagen";
					public const string UbicacionTextoDetalle = "UbicacionTextoDetalle";
					public const string AnchoDetalle = "AnchoDetalle";
					public const string TamanioEntreLineas = "TamanioEntreLineas";
					public const string AnchoReporte = "AnchoReporte";
					public const string FactorAltoReporte = "FactorAltoReporte";
					public const string LineasAlFinal = "LineasAlFinal";
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
					DepositarioModeloId,
					EmpresaId,
					Nombre,
					Descripcion,
					Impresora,
					TextoCabecera,
					NombreFuenteCabecera,
					TamanioFuenteCabecera,
					UbicacionTextoCabecera,
					TextoPie,
					NombreFuentePie,
					TamanioFuentePie,
					UbicacionTextoPie,
					Imagen,
					UbicacionImagen,
					UbicacionTextoDetalle,
					AnchoDetalle,
					TamanioEntreLineas,
					AnchoReporte,
					FactorAltoReporte,
					LineasAlFinal,
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Ticket()
                {
                }
                public  Ticket(DefaultNamespace.Entities.Relations.Impresion.TipoTicket TipoId,DefaultNamespace.Entities.Relations.Dispositivo.Modelo DepositarioModeloId,DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId,String Nombre,String Descripcion,String Impresora,String TextoCabecera,String NombreFuenteCabecera,Int32 TamanioFuenteCabecera,Int32 UbicacionTextoCabecera,String TextoPie,String NombreFuentePie,Int32 TamanioFuentePie,String UbicacionTextoPie,String Imagen,String UbicacionImagen,Int32 UbicacionTextoDetalle,Int32 AnchoDetalle,Int32 TamanioEntreLineas,Int32 AnchoReporte,Int32 FactorAltoReporte,Int32 LineasAlFinal,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.DepositarioModeloId = DepositarioModeloId;
                    this.EmpresaId = EmpresaId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Impresora = Impresora;
                    this.TextoCabecera = TextoCabecera;
                    this.NombreFuenteCabecera = NombreFuenteCabecera;
                    this.TamanioFuenteCabecera = TamanioFuenteCabecera;
                    this.UbicacionTextoCabecera = UbicacionTextoCabecera;
                    this.TextoPie = TextoPie;
                    this.NombreFuentePie = NombreFuentePie;
                    this.TamanioFuentePie = TamanioFuentePie;
                    this.UbicacionTextoPie = UbicacionTextoPie;
                    this.Imagen = Imagen;
                    this.UbicacionImagen = UbicacionImagen;
                    this.UbicacionTextoDetalle = UbicacionTextoDetalle;
                    this.AnchoDetalle = AnchoDetalle;
                    this.TamanioEntreLineas = TamanioEntreLineas;
                    this.AnchoReporte = AnchoReporte;
                    this.FactorAltoReporte = FactorAltoReporte;
                    this.LineasAlFinal = LineasAlFinal;
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
             [PropertyAttributeForeignKeyObjectName("TipoTicket")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Impresion.TipoTicket TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Impresion.TipoTicket().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Impresion.TipoTicket TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioModeloId","DepositarioModeloId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioModeloId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Modelo")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Modelo DepositarioModeloId
             {
                 get {
                     if (DepositarioModeloId_ == null || DepositarioModeloId_.Id != _DepositarioModeloId)
                         {
                             DepositarioModeloId = new DefaultNamespace.Business.Relations.Dispositivo.Modelo().Items(this._DepositarioModeloId).FirstOrDefault();
                         }
                     return DepositarioModeloId_;
                     }
                 set {DepositarioModeloId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Modelo DepositarioModeloId_ = null;
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new DefaultNamespace.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Impresora","Impresora")]
             public String Impresora { get; set; }
             [DataItemAttributeFieldName("TextoCabecera","TextoCabecera")]
             public String TextoCabecera { get; set; }
             [DataItemAttributeFieldName("NombreFuenteCabecera","NombreFuenteCabecera")]
             public String NombreFuenteCabecera { get; set; }
             [DataItemAttributeFieldName("TamanioFuenteCabecera","TamanioFuenteCabecera")]
             public Int32 TamanioFuenteCabecera { get; set; }
             [DataItemAttributeFieldName("UbicacionTextoCabecera","UbicacionTextoCabecera")]
             public Int32 UbicacionTextoCabecera { get; set; }
             [DataItemAttributeFieldName("TextoPie","TextoPie")]
             public String TextoPie { get; set; }
             [DataItemAttributeFieldName("NombreFuentePie","NombreFuentePie")]
             public String NombreFuentePie { get; set; }
             [DataItemAttributeFieldName("TamanioFuentePie","TamanioFuentePie")]
             public Int32 TamanioFuentePie { get; set; }
             [DataItemAttributeFieldName("UbicacionTextoPie","UbicacionTextoPie")]
             public String UbicacionTextoPie { get; set; }
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("UbicacionImagen","UbicacionImagen")]
             public String UbicacionImagen { get; set; }
             [DataItemAttributeFieldName("UbicacionTextoDetalle","UbicacionTextoDetalle")]
             public Int32 UbicacionTextoDetalle { get; set; }
             [DataItemAttributeFieldName("AnchoDetalle","AnchoDetalle")]
             public Int32 AnchoDetalle { get; set; }
             [DataItemAttributeFieldName("TamanioEntreLineas","TamanioEntreLineas")]
             public Int32 TamanioEntreLineas { get; set; }
             [DataItemAttributeFieldName("AnchoReporte","AnchoReporte")]
             public Int32 AnchoReporte { get; set; }
             [DataItemAttributeFieldName("FactorAltoReporte","FactorAltoReporte")]
             public Int32 FactorAltoReporte { get; set; }
             [DataItemAttributeFieldName("LineasAlFinal","LineasAlFinal")]
             public Int32 LineasAlFinal { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class Ticket 
} //namespace DefaultNamespace.Entities.Relations.Impresion
		namespace DefaultNamespace.Entities.Relations.Impresion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Impresion")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoTicket","TipoTicket")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoTicket : IRelationsDataITem
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
                public TipoTicket()
                {
                }
                public  TipoTicket(String Nombre,String Descripcion,String Codigo,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of PlantillaTicket that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Impresion.PlantillaTicket> ListOf_PlantillaTicket_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Impresion.PlantillaTicket entities = new DefaultNamespace.Business.Relations.Impresion.PlantillaTicket();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Impresion.PlantillaTicket.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Impresion.Ticket> ListOf_Ticket_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Impresion.Ticket entities = new DefaultNamespace.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Impresion.Ticket.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoTicket 
} //namespace DefaultNamespace.Entities.Relations.Impresion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
					public const string DepositarioId = "DepositarioId";
					public const string SesionId = "SesionId";
					public const string CodigoCierre = "CodigoCierre";
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
					DepositarioId,
					SesionId,
					CodigoCierre,
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
                public  CierreDiario(String Nombre,DateTime? Fecha,DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,DefaultNamespace.Entities.Relations.Operacion.Sesion SesionId,String CodigoCierre,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Fecha = Fecha;
                    this.DepositarioId = DepositarioId;
                    this.SesionId = SesionId;
                    this.CodigoCierre = CodigoCierre;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime? Fecha { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("SesionId","SesionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SesionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sesion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Operacion.Sesion SesionId
             {
                 get {
                     if (SesionId_ == null || SesionId_.Id != _SesionId)
                         {
                             SesionId = new DefaultNamespace.Business.Relations.Operacion.Sesion().Items(this._SesionId).FirstOrDefault();
                         }
                     return SesionId_;
                     }
                 set {SesionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.Sesion SesionId_ = null;
             [DataItemAttributeFieldName("CodigoCierre","CodigoCierre")]
             public String CodigoCierre { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this CierreDiarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_CierreDiarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.CierreDiarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this CierreDiarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Turno> ListOf_Turno_CierreDiarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Turno entities = new DefaultNamespace.Business.Relations.Operacion.Turno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Turno.ColumnEnum.CierreDiarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class CierreDiario 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
					public const string DepositarioId = "DepositarioId";
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
					DepositarioId,
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
                public  Contenedor(String Nombre,DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,DefaultNamespace.Entities.Relations.Operacion.TipoContenedor TipoId,String Identificador,DateTime FechaApertura,DateTime? FechaCierre,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.DepositarioId = DepositarioId;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoContenedor")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Operacion.TipoContenedor TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Operacion.TipoContenedor().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.TipoContenedor TipoId_ = null;
             [DataItemAttributeFieldName("Identificador","Identificador")]
             public String Identificador { get; set; }
             [DataItemAttributeFieldName("FechaApertura","FechaApertura")]
             public DateTime FechaApertura { get; set; }
             [DataItemAttributeFieldName("FechaCierre","FechaCierre")]
             public DateTime? FechaCierre { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this ContenedorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_ContenedorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Contenedor 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
                public  Evento(DefaultNamespace.Entities.Relations.Operacion.TipoEvento TipoId,Int64? SesionId,DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,String Mensaje,String Valor,DateTime Fecha)
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
             public DefaultNamespace.Entities.Relations.Operacion.TipoEvento TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Operacion.TipoEvento().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.TipoEvento TipoId_ = null;
             [DataItemAttributeFieldName("SesionId","SesionId")]
             public Int64? SesionId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("Mensaje","Mensaje")]
             public String Mensaje { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class Evento 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Sesion","Sesion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Sesion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string DepositarioId = "DepositarioId";
					public const string UsuarioId = "UsuarioId";
					public const string FechaInicio = "FechaInicio";
					public const string FechaCierre = "FechaCierre";
					public const string EsCierreAutomatico = "EsCierreAutomatico";
				}
				public enum FieldEnum : int
                {
					Id,
					DepositarioId,
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
                public  Sesion(DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,Int64 UsuarioId,DateTime FechaInicio,DateTime? FechaCierre,Boolean? EsCierreAutomatico)
                {
                    this.Id = Id;
                    this.DepositarioId = DepositarioId;
                    this.UsuarioId = UsuarioId;
                    this.FechaInicio = FechaInicio;
                    this.FechaCierre = FechaCierre;
                    this.EsCierreAutomatico = EsCierreAutomatico;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("FechaInicio","FechaInicio")]
             public DateTime FechaInicio { get; set; }
             [DataItemAttributeFieldName("FechaCierre","FechaCierre")]
             public DateTime? FechaCierre { get; set; }
             [DataItemAttributeFieldName("EsCierreAutomatico","EsCierreAutomatico")]
             public Boolean? EsCierreAutomatico { get; set; }
                 /// <summary>
                 ///  Represents the child collection of CierreDiario that have this SesionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.CierreDiario> ListOf_CierreDiario_SesionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.CierreDiario entities = new DefaultNamespace.Business.Relations.Operacion.CierreDiario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.CierreDiario.ColumnEnum.SesionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this SesionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_SesionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.SesionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Sesion 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
                public  TipoContenedor(String Nombre,String Descripcion,Int32 Capacidad,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Capacidad","Capacidad")]
             public Int32 Capacidad { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this TipoContenedorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_TipoContenedorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Depositario entities = new DefaultNamespace.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Depositario.ColumnEnum.TipoContenedorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Contenedor that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Contenedor> ListOf_Contenedor_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Contenedor entities = new DefaultNamespace.Business.Relations.Operacion.Contenedor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Contenedor.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoContenedor 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
                public  TipoEvento(String Nombre,String Descripcion,Boolean EsBloqueante,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EsBloqueante","EsBloqueante")]
             public Boolean EsBloqueante { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Evento that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Evento> ListOf_Evento_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Evento entities = new DefaultNamespace.Business.Relations.Operacion.Evento();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Evento.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoEvento 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
					public const string FuncionId = "FuncionId";
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
					FuncionId,
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
                public  TipoTransaccion(String Nombre,String Descripcion,Int64? FuncionId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.FuncionId = FuncionId;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("FuncionId","FuncionId")]
             public Int64? FuncionId { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoTransaccion 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
					public const string MonedaId = "MonedaId";
					public const string UsuarioId = "UsuarioId";
					public const string CuentaId = "CuentaId";
					public const string ContenedorId = "ContenedorId";
					public const string SesionId = "SesionId";
					public const string TurnoId = "TurnoId";
					public const string CierreDiarioId = "CierreDiarioId";
					public const string TotalValidado = "TotalValidado";
					public const string TotalAValidar = "TotalAValidar";
					public const string Fecha = "Fecha";
					public const string Finalizada = "Finalizada";
					public const string EsDepositoAutomatico = "EsDepositoAutomatico";
					public const string OrigenValorId = "OrigenValorId";
					public const string CodigoOperacion = "CodigoOperacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					DepositarioId,
					SectorId,
					SucursalId,
					MonedaId,
					UsuarioId,
					CuentaId,
					ContenedorId,
					SesionId,
					TurnoId,
					CierreDiarioId,
					TotalValidado,
					TotalAValidar,
					Fecha,
					Finalizada,
					EsDepositoAutomatico,
					OrigenValorId,
					CodigoOperacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Transaccion()
                {
                }
                public  Transaccion(DefaultNamespace.Entities.Relations.Operacion.TipoTransaccion TipoId,DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,DefaultNamespace.Entities.Relations.Directorio.Sector SectorId,DefaultNamespace.Entities.Relations.Directorio.Sucursal SucursalId,DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId,DefaultNamespace.Entities.Relations.Banca.Cuenta CuentaId,DefaultNamespace.Entities.Relations.Operacion.Contenedor ContenedorId,DefaultNamespace.Entities.Relations.Operacion.Sesion SesionId,DefaultNamespace.Entities.Relations.Operacion.Turno TurnoId,DefaultNamespace.Entities.Relations.Operacion.CierreDiario CierreDiarioId,Double TotalValidado,Double TotalAValidar,DateTime Fecha,Boolean Finalizada,Boolean EsDepositoAutomatico,DefaultNamespace.Entities.Relations.Valor.OrigenValor OrigenValorId,String CodigoOperacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.DepositarioId = DepositarioId;
                    this.SectorId = SectorId;
                    this.SucursalId = SucursalId;
                    this.MonedaId = MonedaId;
                    this.UsuarioId = UsuarioId;
                    this.CuentaId = CuentaId;
                    this.ContenedorId = ContenedorId;
                    this.SesionId = SesionId;
                    this.TurnoId = TurnoId;
                    this.CierreDiarioId = CierreDiarioId;
                    this.TotalValidado = TotalValidado;
                    this.TotalAValidar = TotalAValidar;
                    this.Fecha = Fecha;
                    this.Finalizada = Finalizada;
                    this.EsDepositoAutomatico = EsDepositoAutomatico;
                    this.OrigenValorId = OrigenValorId;
                    this.CodigoOperacion = CodigoOperacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoTransaccion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Operacion.TipoTransaccion TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Operacion.TipoTransaccion().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.TipoTransaccion TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new DefaultNamespace.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SucursalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sucursal")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Sucursal SucursalId
             {
                 get {
                     if (SucursalId_ == null || SucursalId_.Id != _SucursalId)
                         {
                             SucursalId = new DefaultNamespace.Business.Relations.Directorio.Sucursal().Items(this._SucursalId).FirstOrDefault();
                         }
                     return SucursalId_;
                     }
                 set {SucursalId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Sucursal SucursalId_ = null;
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DefaultNamespace.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("CuentaId","CuentaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CuentaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Cuenta")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Banca.Cuenta CuentaId
             {
                 get {
                     if (CuentaId_ == null || CuentaId_.Id != _CuentaId)
                         {
                             CuentaId = new DefaultNamespace.Business.Relations.Banca.Cuenta().Items(this._CuentaId).FirstOrDefault();
                         }
                     return CuentaId_;
                     }
                 set {CuentaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Banca.Cuenta CuentaId_ = null;
             [DataItemAttributeFieldName("ContenedorId","ContenedorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ContenedorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Contenedor")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Operacion.Contenedor ContenedorId
             {
                 get {
                     if (ContenedorId_ == null || ContenedorId_.Id != _ContenedorId)
                         {
                             ContenedorId = new DefaultNamespace.Business.Relations.Operacion.Contenedor().Items(this._ContenedorId).FirstOrDefault();
                         }
                     return ContenedorId_;
                     }
                 set {ContenedorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.Contenedor ContenedorId_ = null;
             [DataItemAttributeFieldName("SesionId","SesionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SesionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sesion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Operacion.Sesion SesionId
             {
                 get {
                     if (SesionId_ == null || SesionId_.Id != _SesionId)
                         {
                             SesionId = new DefaultNamespace.Business.Relations.Operacion.Sesion().Items(this._SesionId).FirstOrDefault();
                         }
                     return SesionId_;
                     }
                 set {SesionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.Sesion SesionId_ = null;
             [DataItemAttributeFieldName("TurnoId","TurnoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TurnoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Turno")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Operacion.Turno TurnoId
             {
                 get {
                     if (TurnoId_ == null || TurnoId_.Id != _TurnoId)
                         {
                             TurnoId = new DefaultNamespace.Business.Relations.Operacion.Turno().Items(this._TurnoId).FirstOrDefault();
                         }
                     return TurnoId_;
                     }
                 set {TurnoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.Turno TurnoId_ = null;
             [DataItemAttributeFieldName("CierreDiarioId","CierreDiarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CierreDiarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CierreDiario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Operacion.CierreDiario CierreDiarioId
             {
                 get {
                     if (CierreDiarioId_ == null || CierreDiarioId_.Id != _CierreDiarioId)
                         {
                             CierreDiarioId = new DefaultNamespace.Business.Relations.Operacion.CierreDiario().Items(this._CierreDiarioId).FirstOrDefault();
                         }
                     return CierreDiarioId_;
                     }
                 set {CierreDiarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.CierreDiario CierreDiarioId_ = null;
             [DataItemAttributeFieldName("TotalValidado","TotalValidado")]
             public Double TotalValidado { get; set; }
             [DataItemAttributeFieldName("TotalAValidar","TotalAValidar")]
             public Double TotalAValidar { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("Finalizada","Finalizada")]
             public Boolean Finalizada { get; set; }
             [DataItemAttributeFieldName("EsDepositoAutomatico","EsDepositoAutomatico")]
             public Boolean EsDepositoAutomatico { get; set; }
             [DataItemAttributeFieldName("OrigenValorId","OrigenValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _OrigenValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("OrigenValor")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.OrigenValor OrigenValorId
             {
                 get {
                     if (OrigenValorId_ == null || OrigenValorId_.Id != _OrigenValorId)
                         {
                             OrigenValorId = new DefaultNamespace.Business.Relations.Valor.OrigenValor().Items(this._OrigenValorId).FirstOrDefault();
                         }
                     return OrigenValorId_;
                     }
                 set {OrigenValorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.OrigenValor OrigenValorId_ = null;
             [DataItemAttributeFieldName("CodigoOperacion","CodigoOperacion")]
             public String CodigoOperacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionDetalle that have this TransaccionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TransaccionDetalle> ListOf_TransaccionDetalle_TransaccionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TransaccionDetalle entities = new DefaultNamespace.Business.Relations.Operacion.TransaccionDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TransaccionSobre that have this TransaccionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TransaccionSobre> ListOf_TransaccionSobre_TransaccionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TransaccionSobre entities = new DefaultNamespace.Business.Relations.Operacion.TransaccionSobre();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Transaccion 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
                public  TransaccionDetalle(DefaultNamespace.Entities.Relations.Operacion.Transaccion TransaccionId,DefaultNamespace.Entities.Relations.Valor.Denominacion DenominacionId,Int64 CantidadUnidades,DateTime Fecha)
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
             public DefaultNamespace.Entities.Relations.Operacion.Transaccion TransaccionId
             {
                 get {
                     if (TransaccionId_ == null || TransaccionId_.Id != _TransaccionId)
                         {
                             TransaccionId = new DefaultNamespace.Business.Relations.Operacion.Transaccion().Items(this._TransaccionId).FirstOrDefault();
                         }
                     return TransaccionId_;
                     }
                 set {TransaccionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.Transaccion TransaccionId_ = null;
             [DataItemAttributeFieldName("DenominacionId","DenominacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DenominacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Denominacion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.Denominacion DenominacionId
             {
                 get {
                     if (DenominacionId_ == null || DenominacionId_.Id != _DenominacionId)
                         {
                             DenominacionId = new DefaultNamespace.Business.Relations.Valor.Denominacion().Items(this._DenominacionId).FirstOrDefault();
                         }
                     return DenominacionId_;
                     }
                 set {DenominacionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Denominacion DenominacionId_ = null;
             [DataItemAttributeFieldName("CantidadUnidades","CantidadUnidades")]
             public Int64 CantidadUnidades { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class TransaccionDetalle 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
                public  TransaccionSobre(DefaultNamespace.Entities.Relations.Operacion.Transaccion TransaccionId,String CodigoSobre,DateTime Fecha)
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
             public DefaultNamespace.Entities.Relations.Operacion.Transaccion TransaccionId
             {
                 get {
                     if (TransaccionId_ == null || TransaccionId_.Id != _TransaccionId)
                         {
                             TransaccionId = new DefaultNamespace.Business.Relations.Operacion.Transaccion().Items(this._TransaccionId).FirstOrDefault();
                         }
                     return TransaccionId_;
                     }
                 set {TransaccionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.Transaccion TransaccionId_ = null;
             [DataItemAttributeFieldName("CodigoSobre","CodigoSobre")]
             public String CodigoSobre { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionSobreDetalle that have this SobreId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TransaccionSobreDetalle> ListOf_TransaccionSobreDetalle_SobreId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TransaccionSobreDetalle entities = new DefaultNamespace.Business.Relations.Operacion.TransaccionSobreDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.SobreId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TransaccionSobre 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
					public const string ValorDeclarado = "ValorDeclarado";
					public const string Fecha = "Fecha";
				}
				public enum FieldEnum : int
                {
					Id,
					SobreId,
					RelacionMonedaTipoValorId,
					CantidadDeclarada,
					ValorDeclarado,
					Fecha
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TransaccionSobreDetalle()
                {
                }
                public  TransaccionSobreDetalle(DefaultNamespace.Entities.Relations.Operacion.TransaccionSobre SobreId,DefaultNamespace.Entities.Relations.Valor.RelacionMonedaTipoValor RelacionMonedaTipoValorId,Int64 CantidadDeclarada,Double ValorDeclarado,DateTime Fecha)
                {
                    this.Id = Id;
                    this.SobreId = SobreId;
                    this.RelacionMonedaTipoValorId = RelacionMonedaTipoValorId;
                    this.CantidadDeclarada = CantidadDeclarada;
                    this.ValorDeclarado = ValorDeclarado;
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
             public DefaultNamespace.Entities.Relations.Operacion.TransaccionSobre SobreId
             {
                 get {
                     if (SobreId_ == null || SobreId_.Id != _SobreId)
                         {
                             SobreId = new DefaultNamespace.Business.Relations.Operacion.TransaccionSobre().Items(this._SobreId).FirstOrDefault();
                         }
                     return SobreId_;
                     }
                 set {SobreId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.TransaccionSobre SobreId_ = null;
             [DataItemAttributeFieldName("RelacionMonedaTipoValorId","RelacionMonedaTipoValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _RelacionMonedaTipoValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("RelacionMonedaTipoValor")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.RelacionMonedaTipoValor RelacionMonedaTipoValorId
             {
                 get {
                     if (RelacionMonedaTipoValorId_ == null || RelacionMonedaTipoValorId_.Id != _RelacionMonedaTipoValorId)
                         {
                             RelacionMonedaTipoValorId = new DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor().Items(this._RelacionMonedaTipoValorId).FirstOrDefault();
                         }
                     return RelacionMonedaTipoValorId_;
                     }
                 set {RelacionMonedaTipoValorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.RelacionMonedaTipoValor RelacionMonedaTipoValorId_ = null;
             [DataItemAttributeFieldName("CantidadDeclarada","CantidadDeclarada")]
             public Int64 CantidadDeclarada { get; set; }
             [DataItemAttributeFieldName("ValorDeclarado","ValorDeclarado")]
             public Double ValorDeclarado { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class TransaccionSobreDetalle 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
					public const string CodigoTurno = "CodigoTurno";
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
					CodigoTurno,
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
                public  Turno(DefaultNamespace.Entities.Relations.Turno.AgendaTurno TurnoDepositarioId,DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,DefaultNamespace.Entities.Relations.Directorio.Sector SectorId,DateTime? FechaApertura,DateTime? FechaCierre,DateTime? Fecha,Int32 Secuencia,DefaultNamespace.Entities.Relations.Operacion.CierreDiario CierreDiarioId,String Observaciones,String CodigoTurno,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,Boolean Habilitado)
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
                    this.CodigoTurno = CodigoTurno;
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TurnoDepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("AgendaTurno")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Turno.AgendaTurno TurnoDepositarioId
             {
                 get {
                     if (TurnoDepositarioId_ == null || TurnoDepositarioId_.Id != _TurnoDepositarioId)
                         {
                             TurnoDepositarioId = new DefaultNamespace.Business.Relations.Turno.AgendaTurno().Items(this._TurnoDepositarioId).FirstOrDefault();
                         }
                     return TurnoDepositarioId_;
                     }
                 set {TurnoDepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Turno.AgendaTurno TurnoDepositarioId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new DefaultNamespace.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Sector SectorId_ = null;
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
             public DefaultNamespace.Entities.Relations.Operacion.CierreDiario CierreDiarioId
             {
                 get {
                     if (CierreDiarioId_ == null || CierreDiarioId_.Id != _CierreDiarioId)
                         {
                             CierreDiarioId = new DefaultNamespace.Business.Relations.Operacion.CierreDiario().Items(this._CierreDiarioId).FirstOrDefault();
                         }
                     return CierreDiarioId_;
                     }
                 set {CierreDiarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Operacion.CierreDiario CierreDiarioId_ = null;
             [DataItemAttributeFieldName("Observaciones","Observaciones")]
             public String Observaciones { get; set; }
             [DataItemAttributeFieldName("CodigoTurno","CodigoTurno")]
             public String CodigoTurno { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this TurnoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_TurnoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Turno 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Operacion {
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
                public  TurnoUsuario(Int64 UsuarioId,Int64 TurnoId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class TurnoUsuario 
} //namespace DefaultNamespace.Entities.Relations.Operacion
		namespace DefaultNamespace.Entities.Relations.Regionalizacion {
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
					public const string Cultura = "Cultura";
					public const string EsDefault = "EsDefault";
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
					Cultura,
					EsDefault,
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
                public  Lenguaje(String Nombre,String Descripcion,String Cultura,Boolean EsDefault,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Cultura = Cultura;
                    this.EsDefault = EsDefault;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Cultura","Cultura")]
             public String Cultura { get; set; }
             [DataItemAttributeFieldName("EsDefault","EsDefault")]
             public Boolean EsDefault { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Empresa> ListOf_Empresa_LenguajeId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Empresa entities = new DefaultNamespace.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Empresa.ColumnEnum.LenguajeId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of LenguajeItem that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Regionalizacion.LenguajeItem> ListOf_LenguajeItem_LenguajeId
                {
                     get {
                             DefaultNamespace.Business.Relations.Regionalizacion.LenguajeItem entities = new DefaultNamespace.Business.Relations.Regionalizacion.LenguajeItem();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Regionalizacion.LenguajeItem.ColumnEnum.LenguajeId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Usuario that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Usuario> ListOf_Usuario_LenguajeId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Usuario entities = new DefaultNamespace.Business.Relations.Seguridad.Usuario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Usuario.ColumnEnum.LenguajeId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Lenguaje 
} //namespace DefaultNamespace.Entities.Relations.Regionalizacion
		namespace DefaultNamespace.Entities.Relations.Regionalizacion {
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
					public const string LargoMaximo = "LargoMaximo";
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
					LargoMaximo,
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
                public  LenguajeItem(DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,String Clave,String Texto,Boolean Habilitado,Int32 LargoMaximo,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.LenguajeId = LenguajeId;
                    this.Clave = Clave;
                    this.Texto = Texto;
                    this.Habilitado = Habilitado;
                    this.LargoMaximo = LargoMaximo;
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
             public DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new DefaultNamespace.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
             [DataItemAttributeFieldName("Clave","Clave")]
             public String Clave { get; set; }
             [DataItemAttributeFieldName("Texto","Texto")]
             public String Texto { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("LargoMaximo","LargoMaximo")]
             public Int32 LargoMaximo { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class LenguajeItem 
} //namespace DefaultNamespace.Entities.Relations.Regionalizacion
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  Aplicacion(DefaultNamespace.Entities.Relations.Seguridad.TipoAplicacion TipoId,String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public DefaultNamespace.Entities.Relations.Seguridad.TipoAplicacion TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Seguridad.TipoAplicacion().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.TipoAplicacion TipoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Configuracion that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.Configuracion> ListOf_Configuracion_AplicacionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.Configuracion entities = new DefaultNamespace.Business.Relations.Aplicacion.Configuracion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.Configuracion.ColumnEnum.AplicacionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Log that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Auditoria.Log> ListOf_Log_AplicacionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Auditoria.Log entities = new DefaultNamespace.Business.Relations.Auditoria.Log();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Auditoria.Log.ColumnEnum.AplicacionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_AplicacionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle entities = new DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.AplicacionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametro that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametro> ListOf_AplicacionParametro_AplicacionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro entities = new DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro.ColumnEnum.AplicacionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametroValor that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametroValor> ListOf_AplicacionParametroValor_AplicacionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor entities = new DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor.ColumnEnum.AplicacionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_AplicacionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Funcion entities = new DefaultNamespace.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Funcion.ColumnEnum.AplicacionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Rol that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Rol> ListOf_Rol_AplicacionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Rol entities = new DefaultNamespace.Business.Relations.Seguridad.Rol();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Rol.ColumnEnum.AplicacionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Aplicacion 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  AplicacionParametro(DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId,String Nombre,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametroValor that have this ParametroId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametroValor> ListOf_AplicacionParametroValor_ParametroId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor entities = new DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor.ColumnEnum.ParametroId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class AplicacionParametro 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  AplicacionParametroValor(DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId,DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametro ParametroId,String Valor,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("ParametroId","ParametroId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ParametroId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("AplicacionParametro")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametro ParametroId
             {
                 get {
                     if (ParametroId_ == null || ParametroId_.Id != _ParametroId)
                         {
                             ParametroId = new DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro().Items(this._ParametroId).FirstOrDefault();
                         }
                     return ParametroId_;
                     }
                 set {ParametroId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametro ParametroId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class AplicacionParametroValor 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  Funcion(DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId,DefaultNamespace.Entities.Relations.Seguridad.TipoFuncion TipoId,String Nombre,String Descripcion,String Referencia,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoFuncion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.TipoFuncion TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Seguridad.TipoFuncion().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.TipoFuncion TipoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Referencia","Referencia")]
             public String Referencia { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this FuncionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Menu> ListOf_Menu_FuncionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Menu entities = new DefaultNamespace.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Menu.ColumnEnum.FuncionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this FuncionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_FuncionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.RolFuncion entities = new DefaultNamespace.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.RolFuncion.ColumnEnum.FuncionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Funcion 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
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
                public  IdentificadorUsuario(DefaultNamespace.Entities.Relations.Seguridad.TipoIdentificador TipoId,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId,String Valor,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoIdentificador")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.TipoIdentificador TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Seguridad.TipoIdentificador().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.TipoIdentificador TipoId_ = null;
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class IdentificadorUsuario 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  Menu(DefaultNamespace.Entities.Relations.Seguridad.TipoMenu TipoId,String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Seguridad.Funcion FuncionId,String Imagen,DefaultNamespace.Entities.Relations.Seguridad.Menu DependeDe,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public DefaultNamespace.Entities.Relations.Seguridad.TipoMenu TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new DefaultNamespace.Business.Relations.Seguridad.TipoMenu().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.TipoMenu TipoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("FuncionId","FuncionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _FuncionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Funcion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Funcion FuncionId
             {
                 get {
                     if (FuncionId_ == null || FuncionId_.Id != _FuncionId)
                         {
                             FuncionId = new DefaultNamespace.Business.Relations.Seguridad.Funcion().Items(this._FuncionId).FirstOrDefault();
                         }
                     return FuncionId_;
                     }
                 set {FuncionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Funcion FuncionId_ = null;
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("DependeDe","DependeDe")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DependeDe { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Menu")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Menu DependeDe
             {
                 get {
                     if (DependeDe_ == null || DependeDe_.Id != _DependeDe)
                         {
                             DependeDe = new DefaultNamespace.Business.Relations.Seguridad.Menu().Items(this._DependeDe).FirstOrDefault();
                         }
                     return DependeDe_;
                     }
                 set {DependeDe_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Menu DependeDe_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class Menu 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Rol","Rol")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Rol : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string AplicacionId = "AplicacionId";
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
					AplicacionId,
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
                public  Rol(DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId,String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Seguridad.Rol DependeDe,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.AplicacionId = AplicacionId;
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
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("DependeDe","DependeDe")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DependeDe { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Rol DependeDe
             {
                 get {
                     if (DependeDe_ == null || DependeDe_.Id != _DependeDe)
                         {
                             DependeDe = new DefaultNamespace.Business.Relations.Seguridad.Rol().Items(this._DependeDe).FirstOrDefault();
                         }
                     return DependeDe_;
                     }
                 set {DependeDe_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Rol DependeDe_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this RolId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_RolId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.RolFuncion entities = new DefaultNamespace.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.RolFuncion.ColumnEnum.RolId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this RolId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_RolId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.UsuarioRol entities = new DefaultNamespace.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.RolId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Rol 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
					public const string PuedeAgregar = "PuedeAgregar";
					public const string PuedeModificar = "PuedeModificar";
					public const string PuedeEliminar = "PuedeEliminar";
					public const string PuedeVisualizar = "PuedeVisualizar";
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
					PuedeAgregar,
					PuedeModificar,
					PuedeEliminar,
					PuedeVisualizar,
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
                public  RolFuncion(DefaultNamespace.Entities.Relations.Seguridad.Funcion FuncionId,DefaultNamespace.Entities.Relations.Seguridad.Rol RolId,String Descripcion,Boolean PuedeAgregar,Boolean PuedeModificar,Boolean PuedeEliminar,Boolean PuedeVisualizar,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.FuncionId = FuncionId;
                    this.RolId = RolId;
                    this.Descripcion = Descripcion;
                    this.PuedeAgregar = PuedeAgregar;
                    this.PuedeModificar = PuedeModificar;
                    this.PuedeEliminar = PuedeEliminar;
                    this.PuedeVisualizar = PuedeVisualizar;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("FuncionId","FuncionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _FuncionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Funcion")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Funcion FuncionId
             {
                 get {
                     if (FuncionId_ == null || FuncionId_.Id != _FuncionId)
                         {
                             FuncionId = new DefaultNamespace.Business.Relations.Seguridad.Funcion().Items(this._FuncionId).FirstOrDefault();
                         }
                     return FuncionId_;
                     }
                 set {FuncionId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Funcion FuncionId_ = null;
             [DataItemAttributeFieldName("RolId","RolId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _RolId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Rol RolId
             {
                 get {
                     if (RolId_ == null || RolId_.Id != _RolId)
                         {
                             RolId = new DefaultNamespace.Business.Relations.Seguridad.Rol().Items(this._RolId).FirstOrDefault();
                         }
                     return RolId_;
                     }
                 set {RolId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Rol RolId_ = null;
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("PuedeAgregar","PuedeAgregar")]
             public Boolean PuedeAgregar { get; set; }
             [DataItemAttributeFieldName("PuedeModificar","PuedeModificar")]
             public Boolean PuedeModificar { get; set; }
             [DataItemAttributeFieldName("PuedeEliminar","PuedeEliminar")]
             public Boolean PuedeEliminar { get; set; }
             [DataItemAttributeFieldName("PuedeVisualizar","PuedeVisualizar")]
             public Boolean PuedeVisualizar { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class RolFuncion 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  TipoAplicacion(String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Aplicacion that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Aplicacion> ListOf_Aplicacion_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Aplicacion entities = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Aplicacion.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoAplicacion 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  TipoFuncion(String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Funcion entities = new DefaultNamespace.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Funcion.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoFuncion 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
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
                public  TipoIdentificador(String Nombre,String Descripcion,String Mascara,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Mascara","Mascara")]
             public String Mascara { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of IdentificadorUsuario that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.IdentificadorUsuario> ListOf_IdentificadorUsuario_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario entities = new DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoIdentificador 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  TipoMenu(String Nombre,String Descripcion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Menu> ListOf_Menu_TipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Menu entities = new DefaultNamespace.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Menu.ColumnEnum.TipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoMenu 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
					public const string PerfilId = "PerfilId";
					public const string Nombre = "Nombre";
					public const string Apellido = "Apellido";
					public const string NombreApellido = "NombreApellido";
					public const string Documento = "Documento";
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
					public const string CantidadLogueosIncorrectos = "CantidadLogueosIncorrectos";
					public const string Bloqueado = "Bloqueado";
					public const string FechaExpiracion = "FechaExpiracion";
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
					PerfilId,
					Nombre,
					Apellido,
					NombreApellido,
					Documento,
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
					CantidadLogueosIncorrectos,
					Bloqueado,
					FechaExpiracion,
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
                public  Usuario(DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId,DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,DefaultNamespace.Entities.Relations.Visualizacion.Perfil PerfilId,String Nombre,String Apellido,String NombreApellido,String Documento,String Legajo,String Mail,DateTime FechaIngreso,String NickName,String Password,String Token,String Avatar,DateTime? FechaUltimoLogin,Boolean DebeCambiarPassword,Boolean Habilitado,Int32 CantidadLogueosIncorrectos,Boolean Bloqueado,DateTime? FechaExpiracion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EmpresaId = EmpresaId;
                    this.LenguajeId = LenguajeId;
                    this.PerfilId = PerfilId;
                    this.Nombre = Nombre;
                    this.Apellido = Apellido;
                    this.NombreApellido = NombreApellido;
                    this.Documento = Documento;
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
                    this.CantidadLogueosIncorrectos = CantidadLogueosIncorrectos;
                    this.Bloqueado = Bloqueado;
                    this.FechaExpiracion = FechaExpiracion;
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
             public DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new DefaultNamespace.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("LenguajeId","LenguajeId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _LenguajeId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Lenguaje")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new DefaultNamespace.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
             [DataItemAttributeFieldName("PerfilId","PerfilId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PerfilId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Perfil")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Visualizacion.Perfil PerfilId
             {
                 get {
                     if (PerfilId_ == null || PerfilId_.Id != _PerfilId)
                         {
                             PerfilId = new DefaultNamespace.Business.Relations.Visualizacion.Perfil().Items(this._PerfilId).FirstOrDefault();
                         }
                     return PerfilId_;
                     }
                 set {PerfilId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Visualizacion.Perfil PerfilId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Apellido","Apellido")]
             public String Apellido { get; set; }
             [DataItemAttributeFieldName("NombreApellido","NombreApellido")]
             public String NombreApellido { get; set; }
             [DataItemAttributeFieldName("Documento","Documento")]
             public String Documento { get; set; }
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
             public DateTime? FechaUltimoLogin { get; set; }
             [DataItemAttributeFieldName("DebeCambiarPassword","DebeCambiarPassword")]
             public Boolean DebeCambiarPassword { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("CantidadLogueosIncorrectos","CantidadLogueosIncorrectos")]
             public Int32 CantidadLogueosIncorrectos { get; set; }
             [DataItemAttributeFieldName("Bloqueado","Bloqueado")]
             public Boolean Bloqueado { get; set; }
             [DataItemAttributeFieldName("FechaExpiracion","FechaExpiracion")]
             public DateTime? FechaExpiracion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Configuracion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.Configuracion> ListOf_Configuracion_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.Configuracion entities = new DefaultNamespace.Business.Relations.Aplicacion.Configuracion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.Configuracion.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Configuracion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.Configuracion> ListOf_Configuracion_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.Configuracion entities = new DefaultNamespace.Business.Relations.Aplicacion.Configuracion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.Configuracion.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionEmpresa that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionEmpresa> ListOf_ConfiguracionEmpresa_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa entities = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionEmpresa that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionEmpresa> ListOf_ConfiguracionEmpresa_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa entities = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionEmpresa.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionTipoDato that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionTipoDato> ListOf_ConfiguracionTipoDato_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionTipoDato entities = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionTipoDato();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionTipoDato.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionTipoDato that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionTipoDato> ListOf_ConfiguracionTipoDato_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionTipoDato entities = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionTipoDato();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionTipoDato.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionValidacionDato that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato> ListOf_ConfiguracionValidacionDato_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato entities = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionValidacionDato that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Aplicacion.ConfiguracionValidacionDato> ListOf_ConfiguracionValidacionDato_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato entities = new DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Aplicacion.ConfiguracionValidacionDato.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoLog that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Auditoria.TipoLog> ListOf_TipoLog_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Auditoria.TipoLog entities = new DefaultNamespace.Business.Relations.Auditoria.TipoLog();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Auditoria.TipoLog.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoLog that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Auditoria.TipoLog> ListOf_TipoLog_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Auditoria.TipoLog entities = new DefaultNamespace.Business.Relations.Auditoria.TipoLog();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Auditoria.TipoLog.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Banco that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.Banco> ListOf_Banco_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.Banco entities = new DefaultNamespace.Business.Relations.Banca.Banco();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.Banco.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Banco that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.Banco> ListOf_Banco_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.Banco entities = new DefaultNamespace.Business.Relations.Banca.Banco();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.Banco.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.Cuenta entities = new DefaultNamespace.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.Cuenta.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.Cuenta entities = new DefaultNamespace.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.Cuenta.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoCuenta that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.TipoCuenta> ListOf_TipoCuenta_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.TipoCuenta entities = new DefaultNamespace.Business.Relations.Banca.TipoCuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.TipoCuenta.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoCuenta that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.TipoCuenta> ListOf_TipoCuenta_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.TipoCuenta entities = new DefaultNamespace.Business.Relations.Banca.TipoCuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.TipoCuenta.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioCuenta that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.UsuarioCuenta> ListOf_UsuarioCuenta_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.UsuarioCuenta entities = new DefaultNamespace.Business.Relations.Banca.UsuarioCuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioCuenta that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.UsuarioCuenta> ListOf_UsuarioCuenta_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.UsuarioCuenta entities = new DefaultNamespace.Business.Relations.Banca.UsuarioCuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioCuenta that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.UsuarioCuenta> ListOf_UsuarioCuenta_UsuarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.UsuarioCuenta entities = new DefaultNamespace.Business.Relations.Banca.UsuarioCuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.UsuarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of HuellaDactilar that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Biometria.HuellaDactilar> ListOf_HuellaDactilar_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Biometria.HuellaDactilar entities = new DefaultNamespace.Business.Relations.Biometria.HuellaDactilar();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Biometria.HuellaDactilar.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of HuellaDactilar that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Biometria.HuellaDactilar> ListOf_HuellaDactilar_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Biometria.HuellaDactilar entities = new DefaultNamespace.Business.Relations.Biometria.HuellaDactilar();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Biometria.HuellaDactilar.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Entidad that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Customizador.Entidad> ListOf_Entidad_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Customizador.Entidad entities = new DefaultNamespace.Business.Relations.Customizador.Entidad();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Customizador.Entidad.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Entidad that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Customizador.Entidad> ListOf_Entidad_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Customizador.Entidad entities = new DefaultNamespace.Business.Relations.Customizador.Entidad();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Customizador.Entidad.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EntidadAtributo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Customizador.EntidadAtributo> ListOf_EntidadAtributo_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Customizador.EntidadAtributo entities = new DefaultNamespace.Business.Relations.Customizador.EntidadAtributo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Customizador.EntidadAtributo.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EntidadAtributo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Customizador.EntidadAtributo> ListOf_EntidadAtributo_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Customizador.EntidadAtributo entities = new DefaultNamespace.Business.Relations.Customizador.EntidadAtributo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Customizador.EntidadAtributo.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Empresa> ListOf_Empresa_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Empresa entities = new DefaultNamespace.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Empresa.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Empresa> ListOf_Empresa_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Empresa entities = new DefaultNamespace.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Empresa.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Grupo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Grupo> ListOf_Grupo_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Grupo entities = new DefaultNamespace.Business.Relations.Directorio.Grupo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Grupo.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Grupo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Grupo> ListOf_Grupo_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Grupo entities = new DefaultNamespace.Business.Relations.Directorio.Grupo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Grupo.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal entities = new DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal entities = new DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sector that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Sector> ListOf_Sector_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Sector entities = new DefaultNamespace.Business.Relations.Directorio.Sector();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Sector.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sector that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Sector> ListOf_Sector_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Sector entities = new DefaultNamespace.Business.Relations.Directorio.Sector();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Sector.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Sucursal entities = new DefaultNamespace.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Sucursal.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.Sucursal entities = new DefaultNamespace.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.Sucursal.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ComandoContadora that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ComandoContadora> ListOf_ComandoContadora_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ComandoContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.ComandoContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ComandoContadora.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ComandoContadora that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ComandoContadora> ListOf_ComandoContadora_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ComandoContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.ComandoContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ComandoContadora.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ComandoPlaca that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ComandoPlaca> ListOf_ComandoPlaca_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ComandoPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.ComandoPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ComandoPlaca.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ComandoPlaca that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ComandoPlaca> ListOf_ComandoPlaca_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ComandoPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.ComandoPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ComandoPlaca.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Depositario entities = new DefaultNamespace.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Depositario.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Depositario entities = new DefaultNamespace.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Depositario.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioMoneda that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioMoneda> ListOf_DepositarioMoneda_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioMoneda that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioMoneda> ListOf_DepositarioMoneda_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Marca that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Marca> ListOf_Marca_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Marca entities = new DefaultNamespace.Business.Relations.Dispositivo.Marca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Marca.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Marca that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Marca> ListOf_Marca_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Marca entities = new DefaultNamespace.Business.Relations.Dispositivo.Marca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Marca.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Modelo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Modelo> ListOf_Modelo_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Modelo entities = new DefaultNamespace.Business.Relations.Dispositivo.Modelo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Modelo.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Modelo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.Modelo> ListOf_Modelo_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.Modelo entities = new DefaultNamespace.Business.Relations.Dispositivo.Modelo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.Modelo.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoConfiguracionDepositario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.TipoConfiguracionDepositario> ListOf_TipoConfiguracionDepositario_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario entities = new DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoConfiguracionDepositario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.TipoConfiguracionDepositario> ListOf_TipoConfiguracionDepositario_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario entities = new DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContadora that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.TipoContadora> ListOf_TipoContadora_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.TipoContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.TipoContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.TipoContadora.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContadora that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.TipoContadora> ListOf_TipoContadora_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.TipoContadora entities = new DefaultNamespace.Business.Relations.Dispositivo.TipoContadora();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.TipoContadora.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoPlaca that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.TipoPlaca> ListOf_TipoPlaca_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoPlaca that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.TipoPlaca> ListOf_TipoPlaca_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca entities = new DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.TipoPlaca.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Esquema that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Estilo.Esquema> ListOf_Esquema_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Estilo.Esquema entities = new DefaultNamespace.Business.Relations.Estilo.Esquema();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Estilo.Esquema.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Esquema that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Estilo.Esquema> ListOf_Esquema_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Estilo.Esquema entities = new DefaultNamespace.Business.Relations.Estilo.Esquema();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Estilo.Esquema.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle entities = new DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle entities = new DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoEsquemaDetalle that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Estilo.TipoEsquemaDetalle> ListOf_TipoEsquemaDetalle_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Estilo.TipoEsquemaDetalle entities = new DefaultNamespace.Business.Relations.Estilo.TipoEsquemaDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Estilo.TipoEsquemaDetalle.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoEsquemaDetalle that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Estilo.TipoEsquemaDetalle> ListOf_TipoEsquemaDetalle_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Estilo.TipoEsquemaDetalle entities = new DefaultNamespace.Business.Relations.Estilo.TipoEsquemaDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Estilo.TipoEsquemaDetalle.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ciudad that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Ciudad> ListOf_Ciudad_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Ciudad entities = new DefaultNamespace.Business.Relations.Geografia.Ciudad();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Ciudad.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ciudad that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Ciudad> ListOf_Ciudad_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Ciudad entities = new DefaultNamespace.Business.Relations.Geografia.Ciudad();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Ciudad.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CodigoPostal that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.CodigoPostal> ListOf_CodigoPostal_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.CodigoPostal entities = new DefaultNamespace.Business.Relations.Geografia.CodigoPostal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.CodigoPostal.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CodigoPostal that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.CodigoPostal> ListOf_CodigoPostal_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.CodigoPostal entities = new DefaultNamespace.Business.Relations.Geografia.CodigoPostal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.CodigoPostal.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Pais that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Pais> ListOf_Pais_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Pais entities = new DefaultNamespace.Business.Relations.Geografia.Pais();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Pais.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Pais that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Pais> ListOf_Pais_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Pais entities = new DefaultNamespace.Business.Relations.Geografia.Pais();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Pais.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Provincia that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Provincia> ListOf_Provincia_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Provincia entities = new DefaultNamespace.Business.Relations.Geografia.Provincia();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Provincia.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Provincia that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Provincia> ListOf_Provincia_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Provincia entities = new DefaultNamespace.Business.Relations.Geografia.Provincia();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Provincia.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Zona that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Zona> ListOf_Zona_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Zona entities = new DefaultNamespace.Business.Relations.Geografia.Zona();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Zona.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Zona that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Geografia.Zona> ListOf_Zona_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Geografia.Zona entities = new DefaultNamespace.Business.Relations.Geografia.Zona();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Geografia.Zona.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Impresion.Ticket> ListOf_Ticket_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Impresion.Ticket entities = new DefaultNamespace.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Impresion.Ticket.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Impresion.Ticket> ListOf_Ticket_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Impresion.Ticket entities = new DefaultNamespace.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Impresion.Ticket.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoTicket that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Impresion.TipoTicket> ListOf_TipoTicket_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Impresion.TipoTicket entities = new DefaultNamespace.Business.Relations.Impresion.TipoTicket();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Impresion.TipoTicket.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoTicket that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Impresion.TipoTicket> ListOf_TipoTicket_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Impresion.TipoTicket entities = new DefaultNamespace.Business.Relations.Impresion.TipoTicket();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Impresion.TipoTicket.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CierreDiario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.CierreDiario> ListOf_CierreDiario_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.CierreDiario entities = new DefaultNamespace.Business.Relations.Operacion.CierreDiario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.CierreDiario.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CierreDiario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.CierreDiario> ListOf_CierreDiario_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.CierreDiario entities = new DefaultNamespace.Business.Relations.Operacion.CierreDiario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.CierreDiario.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Contenedor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Contenedor> ListOf_Contenedor_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Contenedor entities = new DefaultNamespace.Business.Relations.Operacion.Contenedor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Contenedor.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Contenedor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Contenedor> ListOf_Contenedor_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Contenedor entities = new DefaultNamespace.Business.Relations.Operacion.Contenedor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Contenedor.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContenedor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TipoContenedor> ListOf_TipoContenedor_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TipoContenedor entities = new DefaultNamespace.Business.Relations.Operacion.TipoContenedor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TipoContenedor.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContenedor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TipoContenedor> ListOf_TipoContenedor_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TipoContenedor entities = new DefaultNamespace.Business.Relations.Operacion.TipoContenedor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TipoContenedor.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoEvento that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TipoEvento> ListOf_TipoEvento_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TipoEvento entities = new DefaultNamespace.Business.Relations.Operacion.TipoEvento();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TipoEvento.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoEvento that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TipoEvento> ListOf_TipoEvento_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TipoEvento entities = new DefaultNamespace.Business.Relations.Operacion.TipoEvento();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TipoEvento.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoTransaccion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TipoTransaccion> ListOf_TipoTransaccion_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TipoTransaccion entities = new DefaultNamespace.Business.Relations.Operacion.TipoTransaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TipoTransaccion.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoTransaccion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TipoTransaccion> ListOf_TipoTransaccion_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TipoTransaccion entities = new DefaultNamespace.Business.Relations.Operacion.TipoTransaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TipoTransaccion.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_UsuarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.UsuarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Turno> ListOf_Turno_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Turno entities = new DefaultNamespace.Business.Relations.Operacion.Turno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Turno.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Turno> ListOf_Turno_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Turno entities = new DefaultNamespace.Business.Relations.Operacion.Turno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Turno.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TurnoUsuario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TurnoUsuario> ListOf_TurnoUsuario_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TurnoUsuario entities = new DefaultNamespace.Business.Relations.Operacion.TurnoUsuario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TurnoUsuario.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TurnoUsuario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TurnoUsuario> ListOf_TurnoUsuario_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TurnoUsuario entities = new DefaultNamespace.Business.Relations.Operacion.TurnoUsuario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TurnoUsuario.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Lenguaje that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje> ListOf_Lenguaje_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Regionalizacion.Lenguaje entities = new DefaultNamespace.Business.Relations.Regionalizacion.Lenguaje();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Regionalizacion.Lenguaje.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Lenguaje that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Regionalizacion.Lenguaje> ListOf_Lenguaje_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Regionalizacion.Lenguaje entities = new DefaultNamespace.Business.Relations.Regionalizacion.Lenguaje();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Regionalizacion.Lenguaje.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of LenguajeItem that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Regionalizacion.LenguajeItem> ListOf_LenguajeItem_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Regionalizacion.LenguajeItem entities = new DefaultNamespace.Business.Relations.Regionalizacion.LenguajeItem();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Regionalizacion.LenguajeItem.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of LenguajeItem that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Regionalizacion.LenguajeItem> ListOf_LenguajeItem_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Regionalizacion.LenguajeItem entities = new DefaultNamespace.Business.Relations.Regionalizacion.LenguajeItem();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Regionalizacion.LenguajeItem.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Aplicacion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Aplicacion> ListOf_Aplicacion_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Aplicacion entities = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Aplicacion.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Aplicacion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Aplicacion> ListOf_Aplicacion_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Aplicacion entities = new DefaultNamespace.Business.Relations.Seguridad.Aplicacion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Aplicacion.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametro that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametro> ListOf_AplicacionParametro_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro entities = new DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametro that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametro> ListOf_AplicacionParametro_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro entities = new DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.AplicacionParametro.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametroValor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametroValor> ListOf_AplicacionParametroValor_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor entities = new DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametroValor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.AplicacionParametroValor> ListOf_AplicacionParametroValor_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor entities = new DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.AplicacionParametroValor.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Funcion entities = new DefaultNamespace.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Funcion.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Funcion entities = new DefaultNamespace.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Funcion.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of IdentificadorUsuario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.IdentificadorUsuario> ListOf_IdentificadorUsuario_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario entities = new DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of IdentificadorUsuario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.IdentificadorUsuario> ListOf_IdentificadorUsuario_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario entities = new DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of IdentificadorUsuario that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.IdentificadorUsuario> ListOf_IdentificadorUsuario_UsuarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario entities = new DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.IdentificadorUsuario.ColumnEnum.UsuarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Menu> ListOf_Menu_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Menu entities = new DefaultNamespace.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Menu.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Menu> ListOf_Menu_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Menu entities = new DefaultNamespace.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Menu.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Rol that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Rol> ListOf_Rol_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Rol entities = new DefaultNamespace.Business.Relations.Seguridad.Rol();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Rol.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Rol that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Rol> ListOf_Rol_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Rol entities = new DefaultNamespace.Business.Relations.Seguridad.Rol();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Rol.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.RolFuncion entities = new DefaultNamespace.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.RolFuncion.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.RolFuncion entities = new DefaultNamespace.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.RolFuncion.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoAplicacion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.TipoAplicacion> ListOf_TipoAplicacion_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.TipoAplicacion entities = new DefaultNamespace.Business.Relations.Seguridad.TipoAplicacion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.TipoAplicacion.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoAplicacion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.TipoAplicacion> ListOf_TipoAplicacion_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.TipoAplicacion entities = new DefaultNamespace.Business.Relations.Seguridad.TipoAplicacion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.TipoAplicacion.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoFuncion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.TipoFuncion> ListOf_TipoFuncion_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.TipoFuncion entities = new DefaultNamespace.Business.Relations.Seguridad.TipoFuncion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.TipoFuncion.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoFuncion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.TipoFuncion> ListOf_TipoFuncion_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.TipoFuncion entities = new DefaultNamespace.Business.Relations.Seguridad.TipoFuncion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.TipoFuncion.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoIdentificador that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.TipoIdentificador> ListOf_TipoIdentificador_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.TipoIdentificador entities = new DefaultNamespace.Business.Relations.Seguridad.TipoIdentificador();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.TipoIdentificador.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoIdentificador that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.TipoIdentificador> ListOf_TipoIdentificador_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.TipoIdentificador entities = new DefaultNamespace.Business.Relations.Seguridad.TipoIdentificador();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.TipoIdentificador.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoMenu that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.TipoMenu> ListOf_TipoMenu_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.TipoMenu entities = new DefaultNamespace.Business.Relations.Seguridad.TipoMenu();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.TipoMenu.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoMenu that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.TipoMenu> ListOf_TipoMenu_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.TipoMenu entities = new DefaultNamespace.Business.Relations.Seguridad.TipoMenu();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.TipoMenu.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_UsuarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.UsuarioRol entities = new DefaultNamespace.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.UsuarioRol entities = new DefaultNamespace.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.UsuarioRol entities = new DefaultNamespace.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioSector that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.UsuarioSector> ListOf_UsuarioSector_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.UsuarioSector entities = new DefaultNamespace.Business.Relations.Seguridad.UsuarioSector();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.UsuarioSector.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioSector that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.UsuarioSector> ListOf_UsuarioSector_UsuarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.UsuarioSector entities = new DefaultNamespace.Business.Relations.Seguridad.UsuarioSector();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.UsuarioSector.ColumnEnum.UsuarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioSector that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.UsuarioSector> ListOf_UsuarioSector_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.UsuarioSector entities = new DefaultNamespace.Business.Relations.Seguridad.UsuarioSector();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.UsuarioSector.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AgendaTurno that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Turno.AgendaTurno> ListOf_AgendaTurno_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Turno.AgendaTurno entities = new DefaultNamespace.Business.Relations.Turno.AgendaTurno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Turno.AgendaTurno.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AgendaTurno that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Turno.AgendaTurno> ListOf_AgendaTurno_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Turno.AgendaTurno entities = new DefaultNamespace.Business.Relations.Turno.AgendaTurno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Turno.AgendaTurno.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.Denominacion entities = new DefaultNamespace.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.Denominacion.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.Denominacion entities = new DefaultNamespace.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.Denominacion.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Moneda that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.Moneda> ListOf_Moneda_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.Moneda entities = new DefaultNamespace.Business.Relations.Valor.Moneda();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.Moneda.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Moneda that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.Moneda> ListOf_Moneda_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.Moneda entities = new DefaultNamespace.Business.Relations.Valor.Moneda();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.Moneda.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of OrigenValor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.OrigenValor> ListOf_OrigenValor_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.OrigenValor entities = new DefaultNamespace.Business.Relations.Valor.OrigenValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.OrigenValor.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of OrigenValor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.OrigenValor> ListOf_OrigenValor_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.OrigenValor entities = new DefaultNamespace.Business.Relations.Valor.OrigenValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.OrigenValor.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor entities = new DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor entities = new DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Tipo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.Tipo> ListOf_Tipo_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.Tipo entities = new DefaultNamespace.Business.Relations.Valor.Tipo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.Tipo.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Tipo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.Tipo> ListOf_Tipo_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.Tipo entities = new DefaultNamespace.Business.Relations.Valor.Tipo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.Tipo.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Perfil that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Visualizacion.Perfil> ListOf_Perfil_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Visualizacion.Perfil entities = new DefaultNamespace.Business.Relations.Visualizacion.Perfil();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Visualizacion.Perfil.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Perfil that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Visualizacion.Perfil> ListOf_Perfil_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Visualizacion.Perfil entities = new DefaultNamespace.Business.Relations.Visualizacion.Perfil();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Visualizacion.Perfil.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilItem that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Visualizacion.PerfilItem> ListOf_PerfilItem_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Visualizacion.PerfilItem entities = new DefaultNamespace.Business.Relations.Visualizacion.PerfilItem();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Visualizacion.PerfilItem.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilItem that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Visualizacion.PerfilItem> ListOf_PerfilItem_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Visualizacion.PerfilItem entities = new DefaultNamespace.Business.Relations.Visualizacion.PerfilItem();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Visualizacion.PerfilItem.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilTipo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Visualizacion.PerfilTipo> ListOf_PerfilTipo_UsuarioModificacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Visualizacion.PerfilTipo entities = new DefaultNamespace.Business.Relations.Visualizacion.PerfilTipo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Visualizacion.PerfilTipo.ColumnEnum.UsuarioModificacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilTipo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Visualizacion.PerfilTipo> ListOf_PerfilTipo_UsuarioCreacion
                {
                     get {
                             DefaultNamespace.Business.Relations.Visualizacion.PerfilTipo entities = new DefaultNamespace.Business.Relations.Visualizacion.PerfilTipo();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Visualizacion.PerfilTipo.ColumnEnum.UsuarioCreacion, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Usuario 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  UsuarioRol(DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId,DefaultNamespace.Entities.Relations.Seguridad.Rol RolId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.UsuarioId = UsuarioId;
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
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("RolId","RolId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _RolId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Rol RolId
             {
                 get {
                     if (RolId_ == null || RolId_.Id != _RolId)
                         {
                             RolId = new DefaultNamespace.Business.Relations.Seguridad.Rol().Items(this._RolId).FirstOrDefault();
                         }
                     return RolId_;
                     }
                 set {RolId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Rol RolId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class UsuarioRol 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Seguridad {
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
                public  UsuarioSector(DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId,DefaultNamespace.Entities.Relations.Directorio.Sector SectorId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new DefaultNamespace.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class UsuarioSector 
} //namespace DefaultNamespace.Entities.Relations.Seguridad
		namespace DefaultNamespace.Entities.Relations.Sincronizacion {
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
} //namespace DefaultNamespace.Entities.Relations.Sincronizacion
		namespace DefaultNamespace.Entities.Relations.Sincronizacion {
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
				
			} //Class Entidad 
} //namespace DefaultNamespace.Entities.Relations.Sincronizacion
		namespace DefaultNamespace.Entities.Relations.Sincronizacion {
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
					public const string DepositarioId = "DepositarioId";
					public const string Valor = "Valor";
					public const string Fechainicio = "Fechainicio";
					public const string Fechafin = "Fechafin";
				}
				public enum FieldEnum : int
                {
					Id,
					EntidadId,
					DepositarioId,
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
                public  EntidadCabecera(DefaultNamespace.Entities.Relations.Customizador.Entidad EntidadId,DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId,String Valor,DateTime Fechainicio,DateTime? Fechafin)
                {
                    this.Id = Id;
                    this.EntidadId = EntidadId;
                    this.DepositarioId = DepositarioId;
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
             public DefaultNamespace.Entities.Relations.Customizador.Entidad EntidadId
             {
                 get {
                     if (EntidadId_ == null || EntidadId_.Id != _EntidadId)
                         {
                             EntidadId = new DefaultNamespace.Business.Relations.Customizador.Entidad().Items(this._EntidadId).FirstOrDefault();
                         }
                     return EntidadId_;
                     }
                 set {EntidadId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Customizador.Entidad EntidadId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new DefaultNamespace.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Fechainicio","Fechainicio")]
             public DateTime Fechainicio { get; set; }
             [DataItemAttributeFieldName("Fechafin","Fechafin")]
             public DateTime? Fechafin { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EntidadDetalle that have this EntidadCabeceraId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Sincronizacion.EntidadDetalle> ListOf_EntidadDetalle_EntidadCabeceraId
                {
                     get {
                             DefaultNamespace.Business.Relations.Sincronizacion.EntidadDetalle entities = new DefaultNamespace.Business.Relations.Sincronizacion.EntidadDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Sincronizacion.EntidadDetalle.ColumnEnum.EntidadCabeceraId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class EntidadCabecera 
} //namespace DefaultNamespace.Entities.Relations.Sincronizacion
		namespace DefaultNamespace.Entities.Relations.Sincronizacion {
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
					public const string OrigenId = "OrigenId";
					public const string DestinoId = "DestinoId";
				}
				public enum FieldEnum : int
                {
					Id,
					EntidadCabeceraId,
					FechaCreacion,
					OrigenId,
					DestinoId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EntidadDetalle()
                {
                }
                public  EntidadDetalle(DefaultNamespace.Entities.Relations.Sincronizacion.EntidadCabecera EntidadCabeceraId,DateTime FechaCreacion,Int64 OrigenId,Int64 DestinoId)
                {
                    this.Id = Id;
                    this.EntidadCabeceraId = EntidadCabeceraId;
                    this.FechaCreacion = FechaCreacion;
                    this.OrigenId = OrigenId;
                    this.DestinoId = DestinoId;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EntidadCabeceraId","EntidadCabeceraId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EntidadCabeceraId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EntidadCabecera")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Sincronizacion.EntidadCabecera EntidadCabeceraId
             {
                 get {
                     if (EntidadCabeceraId_ == null || EntidadCabeceraId_.Id != _EntidadCabeceraId)
                         {
                             EntidadCabeceraId = new DefaultNamespace.Business.Relations.Sincronizacion.EntidadCabecera().Items(this._EntidadCabeceraId).FirstOrDefault();
                         }
                     return EntidadCabeceraId_;
                     }
                 set {EntidadCabeceraId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Sincronizacion.EntidadCabecera EntidadCabeceraId_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("OrigenId","OrigenId")]
             public Int64 OrigenId { get; set; }
             [DataItemAttributeFieldName("DestinoId","DestinoId")]
             public Int64 DestinoId { get; set; }
				
			} //Class EntidadDetalle 
} //namespace DefaultNamespace.Entities.Relations.Sincronizacion
		namespace DefaultNamespace.Entities.Relations.Turno {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Turno")]  // Database Schema Name
			[DataItemAttributeObjectName("AgendaTurno","AgendaTurno")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class AgendaTurno : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string EsquemaDetalleTurnoId = "EsquemaDetalleTurnoId";
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
					EsquemaDetalleTurnoId,
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
                public AgendaTurno()
                {
                }
                public  AgendaTurno(String Nombre,DefaultNamespace.Entities.Relations.Turno.EsquemaDetalleTurno EsquemaDetalleTurnoId,DateTime Fecha,DefaultNamespace.Entities.Relations.Directorio.Sector SectorId,Int32 Secuencia,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.EsquemaDetalleTurnoId = EsquemaDetalleTurnoId;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("EsquemaDetalleTurnoId","EsquemaDetalleTurnoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EsquemaDetalleTurnoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EsquemaDetalleTurno")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Turno.EsquemaDetalleTurno EsquemaDetalleTurnoId
             {
                 get {
                     if (EsquemaDetalleTurnoId_ == null || EsquemaDetalleTurnoId_.Id != _EsquemaDetalleTurnoId)
                         {
                             EsquemaDetalleTurnoId = new DefaultNamespace.Business.Relations.Turno.EsquemaDetalleTurno().Items(this._EsquemaDetalleTurnoId).FirstOrDefault();
                         }
                     return EsquemaDetalleTurnoId_;
                     }
                 set {EsquemaDetalleTurnoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Turno.EsquemaDetalleTurno EsquemaDetalleTurnoId_ = null;
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new DefaultNamespace.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("Secuencia","Secuencia")]
             public Int32 Secuencia { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this TurnoDepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Turno> ListOf_Turno_TurnoDepositarioId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Turno entities = new DefaultNamespace.Business.Relations.Operacion.Turno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Turno.ColumnEnum.TurnoDepositarioId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class AgendaTurno 
} //namespace DefaultNamespace.Entities.Relations.Turno
		namespace DefaultNamespace.Entities.Relations.Turno {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Turno")]  // Database Schema Name
			[DataItemAttributeObjectName("EsquemaDetalleTurno","EsquemaDetalleTurno")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class EsquemaDetalleTurno : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string EsquemaTurnoId = "EsquemaTurnoId";
					public const string Nombre = "Nombre";
					public const string Secuencia = "Secuencia";
					public const string Habilitado = "Habilitado";
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
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EsquemaDetalleTurno()
                {
                }
                public  EsquemaDetalleTurno(DefaultNamespace.Entities.Relations.Turno.EsquemaTurno EsquemaTurnoId,String Nombre,Int32 Secuencia,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.EsquemaTurnoId = EsquemaTurnoId;
                    this.Nombre = Nombre;
                    this.Secuencia = Secuencia;
                    this.Habilitado = Habilitado;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EsquemaTurnoId","EsquemaTurnoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EsquemaTurnoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EsquemaTurno")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Turno.EsquemaTurno EsquemaTurnoId
             {
                 get {
                     if (EsquemaTurnoId_ == null || EsquemaTurnoId_.Id != _EsquemaTurnoId)
                         {
                             EsquemaTurnoId = new DefaultNamespace.Business.Relations.Turno.EsquemaTurno().Items(this._EsquemaTurnoId).FirstOrDefault();
                         }
                     return EsquemaTurnoId_;
                     }
                 set {EsquemaTurnoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Turno.EsquemaTurno EsquemaTurnoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Secuencia","Secuencia")]
             public Int32 Secuencia { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of AgendaTurno that have this EsquemaDetalleTurnoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Turno.AgendaTurno> ListOf_AgendaTurno_EsquemaDetalleTurnoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Turno.AgendaTurno entities = new DefaultNamespace.Business.Relations.Turno.AgendaTurno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Turno.AgendaTurno.ColumnEnum.EsquemaDetalleTurnoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class EsquemaDetalleTurno 
} //namespace DefaultNamespace.Entities.Relations.Turno
		namespace DefaultNamespace.Entities.Relations.Turno {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Turno")]  // Database Schema Name
			[DataItemAttributeObjectName("EsquemaTurno","EsquemaTurno")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class EsquemaTurno : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
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
                public EsquemaTurno()
                {
                }
                public  EsquemaTurno(String Nombre,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
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
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalleTurno that have this EsquemaTurnoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Turno.EsquemaDetalleTurno> ListOf_EsquemaDetalleTurno_EsquemaTurnoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Turno.EsquemaDetalleTurno entities = new DefaultNamespace.Business.Relations.Turno.EsquemaDetalleTurno();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Turno.EsquemaDetalleTurno.ColumnEnum.EsquemaTurnoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class EsquemaTurno 
} //namespace DefaultNamespace.Entities.Relations.Turno
		namespace DefaultNamespace.Entities.Relations.Valor {
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
					public const string Posicion = "Posicion";
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
					Posicion,
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
                public  Denominacion(String Nombre,DefaultNamespace.Entities.Relations.Valor.Tipo TipoValorId,DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId,Decimal Unidades,String Imagen,String CodigoCcTalk,Int32 Posicion,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.TipoValorId = TipoValorId;
                    this.MonedaId = MonedaId;
                    this.Unidades = Unidades;
                    this.Imagen = Imagen;
                    this.CodigoCcTalk = CodigoCcTalk;
                    this.Posicion = Posicion;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("TipoValorId","TipoValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Tipo")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.Tipo TipoValorId
             {
                 get {
                     if (TipoValorId_ == null || TipoValorId_.Id != _TipoValorId)
                         {
                             TipoValorId = new DefaultNamespace.Business.Relations.Valor.Tipo().Items(this._TipoValorId).FirstOrDefault();
                         }
                     return TipoValorId_;
                     }
                 set {TipoValorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Tipo TipoValorId_ = null;
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DefaultNamespace.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("Unidades","Unidades")]
             public Decimal Unidades { get; set; }
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("CodigoCcTalk","CodigoCcTalk")]
             public String CodigoCcTalk { get; set; }
             [DataItemAttributeFieldName("Posicion","Posicion")]
             public Int32 Posicion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionDetalle that have this DenominacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TransaccionDetalle> ListOf_TransaccionDetalle_DenominacionId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TransaccionDetalle entities = new DefaultNamespace.Business.Relations.Operacion.TransaccionDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.DenominacionId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Denominacion 
} //namespace DefaultNamespace.Entities.Relations.Valor
		namespace DefaultNamespace.Entities.Relations.Valor {
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
					public const string Simbolo = "Simbolo";
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
					Simbolo,
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
                public  Moneda(String Nombre,DefaultNamespace.Entities.Relations.Geografia.Pais PaisId,String Codigo,String Simbolo,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.PaisId = PaisId;
                    this.Codigo = Codigo;
                    this.Simbolo = Simbolo;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("PaisId","PaisId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PaisId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Pais")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Geografia.Pais PaisId
             {
                 get {
                     if (PaisId_ == null || PaisId_.Id != _PaisId)
                         {
                             PaisId = new DefaultNamespace.Business.Relations.Geografia.Pais().Items(this._PaisId).FirstOrDefault();
                         }
                     return PaisId_;
                     }
                 set {PaisId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Geografia.Pais PaisId_ = null;
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("Simbolo","Simbolo")]
             public String Simbolo { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TipoCuenta that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Banca.TipoCuenta> ListOf_TipoCuenta_MonedaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Banca.TipoCuenta entities = new DefaultNamespace.Business.Relations.Banca.TipoCuenta();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Banca.TipoCuenta.ColumnEnum.MonedaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_MonedaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal entities = new DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.MonedaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioMoneda that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.DepositarioMoneda> ListOf_DepositarioMoneda_MonedaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda entities = new DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.MonedaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaMonedaDetalle that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Dispositivo.PlantillaMonedaDetalle> ListOf_PlantillaMonedaDetalle_MonedaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Dispositivo.PlantillaMonedaDetalle entities = new DefaultNamespace.Business.Relations.Dispositivo.PlantillaMonedaDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.MonedaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_MonedaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_MonedaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.Denominacion entities = new DefaultNamespace.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.Denominacion.ColumnEnum.MonedaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_MonedaId
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor entities = new DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.MonedaId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Moneda 
} //namespace DefaultNamespace.Entities.Relations.Valor
		namespace DefaultNamespace.Entities.Relations.Valor {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Valor")]  // Database Schema Name
			[DataItemAttributeObjectName("OrigenValor","OrigenValor")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class OrigenValor : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string EmpresaId = "EmpresaId";
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
					Habilitado,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public OrigenValor()
                {
                }
                public  OrigenValor(String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EmpresaId = EmpresaId;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new DefaultNamespace.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this OrigenValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_OrigenValorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.Transaccion entities = new DefaultNamespace.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.Transaccion.ColumnEnum.OrigenValorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class OrigenValor 
} //namespace DefaultNamespace.Entities.Relations.Valor
		namespace DefaultNamespace.Entities.Relations.Valor {
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
					public const string Habilitado = "Habilitado";
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
					Habilitado,
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
                public  RelacionMonedaTipoValor(DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId,DefaultNamespace.Entities.Relations.Valor.Tipo TipoValorId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.MonedaId = MonedaId;
                    this.TipoValorId = TipoValorId;
                    this.Habilitado = Habilitado;
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
             public DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new DefaultNamespace.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("TipoValorId","TipoValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Tipo")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Valor.Tipo TipoValorId
             {
                 get {
                     if (TipoValorId_ == null || TipoValorId_.Id != _TipoValorId)
                         {
                             TipoValorId = new DefaultNamespace.Business.Relations.Valor.Tipo().Items(this._TipoValorId).FirstOrDefault();
                         }
                     return TipoValorId_;
                     }
                 set {TipoValorId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Valor.Tipo TipoValorId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionSobreDetalle that have this RelacionMonedaTipoValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Operacion.TransaccionSobreDetalle> ListOf_TransaccionSobreDetalle_RelacionMonedaTipoValorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Operacion.TransaccionSobreDetalle entities = new DefaultNamespace.Business.Relations.Operacion.TransaccionSobreDetalle();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.RelacionMonedaTipoValorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class RelacionMonedaTipoValor 
} //namespace DefaultNamespace.Entities.Relations.Valor
		namespace DefaultNamespace.Entities.Relations.Valor {
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
					public const string Imagen = "Imagen";
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
					Imagen,
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
                public  Tipo(String Nombre,String Descripcion,String Imagen,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Imagen = Imagen;
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this TipoValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_TipoValorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.Denominacion entities = new DefaultNamespace.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.Denominacion.ColumnEnum.TipoValorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this TipoValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_TipoValorId
                {
                     get {
                             DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor entities = new DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.TipoValorId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Tipo 
} //namespace DefaultNamespace.Entities.Relations.Valor
		namespace DefaultNamespace.Entities.Relations.Visualizacion {
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
                public  Perfil(String Nombre,String Descripcion,DefaultNamespace.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("PerfilTipoId","PerfilTipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PerfilTipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("PerfilTipo")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId
             {
                 get {
                     if (PerfilTipoId_ == null || PerfilTipoId_.Id != _PerfilTipoId)
                         {
                             PerfilTipoId = new DefaultNamespace.Business.Relations.Visualizacion.PerfilTipo().Items(this._PerfilTipoId).FirstOrDefault();
                         }
                     return PerfilTipoId_;
                     }
                 set {PerfilTipoId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Usuario that have this PerfilId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Seguridad.Usuario> ListOf_Usuario_PerfilId
                {
                     get {
                             DefaultNamespace.Business.Relations.Seguridad.Usuario entities = new DefaultNamespace.Business.Relations.Seguridad.Usuario();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Seguridad.Usuario.ColumnEnum.PerfilId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilItem that have this PerfilId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Visualizacion.PerfilItem> ListOf_PerfilItem_PerfilId
                {
                     get {
                             DefaultNamespace.Business.Relations.Visualizacion.PerfilItem entities = new DefaultNamespace.Business.Relations.Visualizacion.PerfilItem();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Visualizacion.PerfilItem.ColumnEnum.PerfilId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Perfil 
} //namespace DefaultNamespace.Entities.Relations.Visualizacion
		namespace DefaultNamespace.Entities.Relations.Visualizacion {
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
                public  PerfilItem(DefaultNamespace.Entities.Relations.Visualizacion.Perfil PerfilId,Int64 IdTablaReferencia,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public DefaultNamespace.Entities.Relations.Visualizacion.Perfil PerfilId
             {
                 get {
                     if (PerfilId_ == null || PerfilId_.Id != _PerfilId)
                         {
                             PerfilId = new DefaultNamespace.Business.Relations.Visualizacion.Perfil().Items(this._PerfilId).FirstOrDefault();
                         }
                     return PerfilId_;
                     }
                 set {PerfilId_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Visualizacion.Perfil PerfilId_ = null;
             [DataItemAttributeFieldName("IdTablaReferencia","IdTablaReferencia")]
             public Int64 IdTablaReferencia { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class PerfilItem 
} //namespace DefaultNamespace.Entities.Relations.Visualizacion
		namespace DefaultNamespace.Entities.Relations.Visualizacion {
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
                public  PerfilTipo(String Nombre,String Descripcion,Boolean EsAdministrador,Boolean Habilitado,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EsAdministrador","EsAdministrador")]
             public Boolean EsAdministrador { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new DefaultNamespace.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static DefaultNamespace.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Perfil that have this PerfilTipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<DefaultNamespace.Entities.Relations.Visualizacion.Perfil> ListOf_Perfil_PerfilTipoId
                {
                     get {
                             DefaultNamespace.Business.Relations.Visualizacion.Perfil entities = new DefaultNamespace.Business.Relations.Visualizacion.Perfil();
                             entities.Where.Add(DefaultNamespace.Business.Relations.Visualizacion.Perfil.ColumnEnum.PerfilTipoId, DefaultNamespace.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class PerfilTipo 
} //namespace DefaultNamespace.Entities.Relations.Visualizacion
