using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace Permaquim.Depositary.Entities.Relations.Aplicacion {
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
                public  Configuracion(Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId,Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId,String Descripcion,String Clave,String Valor,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("ValidacionDatoId","ValidacionDatoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ValidacionDatoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("ConfiguracionValidacionDato")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId
             {
                 get {
                     if (ValidacionDatoId_ == null || ValidacionDatoId_.Id != _ValidacionDatoId)
                         {
                             ValidacionDatoId = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato().Items(this._ValidacionDatoId).FirstOrDefault();
                         }
                     return ValidacionDatoId_;
                     }
                 set {ValidacionDatoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class Configuracion 
} //namespace Permaquim.Depositary.Entities.Relations.Aplicacion
		namespace Permaquim.Depositary.Entities.Relations.Aplicacion {
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
                public  ConfiguracionEmpresa(Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId,Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId,String Descripcion,String Clave,String Valor,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new Permaquim.Depositary.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("ValidacionDatoId","ValidacionDatoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ValidacionDatoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("ConfiguracionValidacionDato")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId
             {
                 get {
                     if (ValidacionDatoId_ == null || ValidacionDatoId_.Id != _ValidacionDatoId)
                         {
                             ValidacionDatoId = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato().Items(this._ValidacionDatoId).FirstOrDefault();
                         }
                     return ValidacionDatoId_;
                     }
                 set {ValidacionDatoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class ConfiguracionEmpresa 
} //namespace Permaquim.Depositary.Entities.Relations.Aplicacion
		namespace Permaquim.Depositary.Entities.Relations.Aplicacion {
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
                public  ConfiguracionTipoDato(String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionValidacionDato that have this TipoDatoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato> ListOf_ConfiguracionValidacionDato_TipoDatoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato entities = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato.ColumnEnum.TipoDatoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class ConfiguracionTipoDato 
} //namespace Permaquim.Depositary.Entities.Relations.Aplicacion
		namespace Permaquim.Depositary.Entities.Relations.Aplicacion {
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
                public  ConfiguracionValidacionDato(Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionTipoDato TipoDatoId,String Nombre,String Descripcion,String ExpresionRegular,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionTipoDato TipoDatoId
             {
                 get {
                     if (TipoDatoId_ == null || TipoDatoId_.Id != _TipoDatoId)
                         {
                             TipoDatoId = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionTipoDato().Items(this._TipoDatoId).FirstOrDefault();
                         }
                     return TipoDatoId_;
                     }
                 set {TipoDatoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionTipoDato TipoDatoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Configuracion that have this ValidacionDatoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.Configuracion> ListOf_Configuracion_ValidacionDatoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion entities = new Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion.ColumnEnum.ValidacionDatoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionEmpresa that have this ValidacionDatoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionEmpresa> ListOf_ConfiguracionEmpresa_ValidacionDatoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa entities = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa.ColumnEnum.ValidacionDatoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoConfiguracionDepositario that have this ValidacionDatoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.TipoConfiguracionDepositario> ListOf_TipoConfiguracionDepositario_ValidacionDatoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.ValidacionDatoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class ConfiguracionValidacionDato 
} //namespace Permaquim.Depositary.Entities.Relations.Aplicacion
		namespace Permaquim.Depositary.Entities.Relations.Auditoria {
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
                public  Log(Permaquim.Depositary.Entities.Relations.Auditoria.TipoLog TipoId,Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId,DateTime Fecha,String Descripcion,String Detalle,String Modulo,String Metodo,Int64 UsuarioId)
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
             public Permaquim.Depositary.Entities.Relations.Auditoria.TipoLog TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Auditoria.TipoLog().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Auditoria.TipoLog TipoId_ = null;
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
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
} //namespace Permaquim.Depositary.Entities.Relations.Auditoria
		namespace Permaquim.Depositary.Entities.Relations.Auditoria {
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
                public  TipoLog(String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Log that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Auditoria.Log> ListOf_Log_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Auditoria.Log entities = new Permaquim.Depositary.Business.Relations.Auditoria.Log();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Auditoria.Log.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoLog 
} //namespace Permaquim.Depositary.Entities.Relations.Auditoria
		namespace Permaquim.Depositary.Entities.Relations.Banca {
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
                public  Banco(String Nombre,String Descripcion,String Codigo,Permaquim.Depositary.Entities.Relations.Geografia.Pais PaisId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Geografia.Pais PaisId
             {
                 get {
                     if (PaisId_ == null || PaisId_.Id != _PaisId)
                         {
                             PaisId = new Permaquim.Depositary.Business.Relations.Geografia.Pais().Items(this._PaisId).FirstOrDefault();
                         }
                     return PaisId_;
                     }
                 set {PaisId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Geografia.Pais PaisId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this BancoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_BancoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.Cuenta entities = new Permaquim.Depositary.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.Cuenta.ColumnEnum.BancoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Banco 
} //namespace Permaquim.Depositary.Entities.Relations.Banca
		namespace Permaquim.Depositary.Entities.Relations.Banca {
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
					public const string CodigoExterno = "CodigoExterno";
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
					FechaModificacion,
					CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Cuenta()
                {
                }
                public  Cuenta(Permaquim.Depositary.Entities.Relations.Banca.TipoCuenta TipoId,Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId,String Nombre,String Numero,String Alias,String CBU,Permaquim.Depositary.Entities.Relations.Banca.Banco BancoId,String SucursalBancaria,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,String CodigoExterno)
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
                    this.CodigoExterno = CodigoExterno;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoCuenta")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Banca.TipoCuenta TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Banca.TipoCuenta().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Banca.TipoCuenta TipoId_ = null;
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new Permaquim.Depositary.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Banca.Banco BancoId
             {
                 get {
                     if (BancoId_ == null || BancoId_.Id != _BancoId)
                         {
                             BancoId = new Permaquim.Depositary.Business.Relations.Banca.Banco().Items(this._BancoId).FirstOrDefault();
                         }
                     return BancoId_;
                     }
                 set {BancoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Banca.Banco BancoId_ = null;
             [DataItemAttributeFieldName("SucursalBancaria","SucursalBancaria")]
             public String SucursalBancaria { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
                 /// <summary>
                 ///  Represents the child collection of UsuarioCuenta that have this CuentaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.UsuarioCuenta> ListOf_UsuarioCuenta_CuentaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta entities = new Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.CuentaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this CuentaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_CuentaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.CuentaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Cuenta 
} //namespace Permaquim.Depositary.Entities.Relations.Banca
		namespace Permaquim.Depositary.Entities.Relations.Banca {
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
					public const string CodigoExterno = "CodigoExterno";
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
					FechaModificacion,
					CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoCuenta()
                {
                }
                public  TipoCuenta(Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId,String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,String CodigoExterno)
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
                    this.CodigoExterno = CodigoExterno;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new Permaquim.Depositary.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.Cuenta entities = new Permaquim.Depositary.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.Cuenta.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoCuenta 
} //namespace Permaquim.Depositary.Entities.Relations.Banca
		namespace Permaquim.Depositary.Entities.Relations.Banca {
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
                public  UsuarioCuenta(Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId,Permaquim.Depositary.Entities.Relations.Banca.Cuenta CuentaId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("CuentaId","CuentaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CuentaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Cuenta")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Banca.Cuenta CuentaId
             {
                 get {
                     if (CuentaId_ == null || CuentaId_.Id != _CuentaId)
                         {
                             CuentaId = new Permaquim.Depositary.Business.Relations.Banca.Cuenta().Items(this._CuentaId).FirstOrDefault();
                         }
                     return CuentaId_;
                     }
                 set {CuentaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Banca.Cuenta CuentaId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class UsuarioCuenta 
} //namespace Permaquim.Depositary.Entities.Relations.Banca
		namespace Permaquim.Depositary.Entities.Relations.Biometria {
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
                public  HuellaDactilar(Int64 UsuarioId,Byte Dedo,String Huella,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class HuellaDactilar 
} //namespace Permaquim.Depositary.Entities.Relations.Biometria
		namespace Permaquim.Depositary.Entities.Relations.Customizador {
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
					public const string RegistrosPorPagina = "RegistrosPorPagina";
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
					RegistrosPorPagina,
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
                public  Entidad(String Tipo,String Nombre,String Esquema,Boolean HabilitarAgrupamiento,Boolean HabilitarMovilidad,Boolean HabilitarFiltrado,Boolean HabilitarColumnasOpcionales,Boolean HabilitarOrdenamiento,Boolean HabilitarRedimensionamiento,Boolean HabilitarPaginado,Int32? RegistrosPorPagina,Boolean HabilitarAuditoria,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
                    this.RegistrosPorPagina = RegistrosPorPagina;
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             [DataItemAttributeFieldName("RegistrosPorPagina","RegistrosPorPagina")]
             public Int32? RegistrosPorPagina { get; set; }
             [DataItemAttributeFieldName("HabilitarAuditoria","HabilitarAuditoria")]
             public Boolean HabilitarAuditoria { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EntidadAtributo that have this EntidadId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Customizador.EntidadAtributo> ListOf_EntidadAtributo_EntidadId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Customizador.EntidadAtributo entities = new Permaquim.Depositary.Business.Relations.Customizador.EntidadAtributo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Customizador.EntidadAtributo.ColumnEnum.EntidadId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EntidadCabecera that have this EntidadId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Sincronizacion.EntidadCabecera> ListOf_EntidadCabecera_EntidadId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Sincronizacion.EntidadCabecera entities = new Permaquim.Depositary.Business.Relations.Sincronizacion.EntidadCabecera();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Sincronizacion.EntidadCabecera.ColumnEnum.EntidadId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Entidad 
} //namespace Permaquim.Depositary.Entities.Relations.Customizador
		namespace Permaquim.Depositary.Entities.Relations.Customizador {
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
                public  EntidadAtributo(Permaquim.Depositary.Entities.Relations.Customizador.Entidad EntidadId,String Nombre,Boolean VisibleEnGrilla,Boolean VisibleEnSelectorColumnas,Boolean Redimensionable,Boolean Agrupable,Boolean Movible,Boolean Ordenable,Boolean Filtrable,Int32? PosicionEnGrilla,Int32 AnchoMinimoEnGrilla,Int32 AnchoEnGrilla,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Customizador.Entidad EntidadId
             {
                 get {
                     if (EntidadId_ == null || EntidadId_.Id != _EntidadId)
                         {
                             EntidadId = new Permaquim.Depositary.Business.Relations.Customizador.Entidad().Items(this._EntidadId).FirstOrDefault();
                         }
                     return EntidadId_;
                     }
                 set {EntidadId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Customizador.Entidad EntidadId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class EntidadAtributo 
} //namespace Permaquim.Depositary.Entities.Relations.Customizador
		namespace Permaquim.Depositary.Entities.Relations.Directorio {
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
                public  Empresa(String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Directorio.Grupo GrupoId,String CodigoExterno,String Direccion,Permaquim.Depositary.Entities.Relations.Geografia.CodigoPostal CodigoPostalId,Permaquim.Depositary.Entities.Relations.Estilo.Esquema EstiloEsquemaId,Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,Boolean Habilitado,Boolean EsDefault,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("GrupoId","GrupoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _GrupoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Grupo")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Grupo GrupoId
             {
                 get {
                     if (GrupoId_ == null || GrupoId_.Id != _GrupoId)
                         {
                             GrupoId = new Permaquim.Depositary.Business.Relations.Directorio.Grupo().Items(this._GrupoId).FirstOrDefault();
                         }
                     return GrupoId_;
                     }
                 set {GrupoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Grupo GrupoId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Direccion","Direccion")]
             public String Direccion { get; set; }
             [DataItemAttributeFieldName("CodigoPostalId","CodigoPostalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CodigoPostalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CodigoPostal")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Geografia.CodigoPostal CodigoPostalId
             {
                 get {
                     if (CodigoPostalId_ == null || CodigoPostalId_.Id != _CodigoPostalId)
                         {
                             CodigoPostalId = new Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal().Items(this._CodigoPostalId).FirstOrDefault();
                         }
                     return CodigoPostalId_;
                     }
                 set {CodigoPostalId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Geografia.CodigoPostal CodigoPostalId_ = null;
             [DataItemAttributeFieldName("EstiloEsquemaId","EstiloEsquemaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EstiloEsquemaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Esquema")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Estilo.Esquema EstiloEsquemaId
             {
                 get {
                     if (EstiloEsquemaId_ == null || EstiloEsquemaId_.Id != _EstiloEsquemaId)
                         {
                             EstiloEsquemaId = new Permaquim.Depositary.Business.Relations.Estilo.Esquema().Items(this._EstiloEsquemaId).FirstOrDefault();
                         }
                     return EstiloEsquemaId_;
                     }
                 set {EstiloEsquemaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Estilo.Esquema EstiloEsquemaId_ = null;
             [DataItemAttributeFieldName("LenguajeId","LenguajeId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _LenguajeId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Lenguaje")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new Permaquim.Depositary.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("EsDefault","EsDefault")]
             public Boolean EsDefault { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionEmpresa that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionEmpresa> ListOf_ConfiguracionEmpresa_EmpresaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa entities = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa.ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_EmpresaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.Cuenta entities = new Permaquim.Depositary.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.Cuenta.ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_EmpresaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Sucursal entities = new Permaquim.Depositary.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Impresion.Ticket> ListOf_Ticket_EmpresaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Impresion.Ticket entities = new Permaquim.Depositary.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Impresion.Ticket.ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Usuario that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Usuario> ListOf_Usuario_EmpresaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Usuario entities = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of OrigenValor that have this EmpresaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.OrigenValor> ListOf_OrigenValor_EmpresaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.OrigenValor entities = new Permaquim.Depositary.Business.Relations.Valor.OrigenValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.OrigenValor.ColumnEnum.EmpresaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Empresa 
} //namespace Permaquim.Depositary.Entities.Relations.Directorio
		namespace Permaquim.Depositary.Entities.Relations.Directorio {
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
                public  Grupo(String Nombre,String Descripcion,String CodigoExterno,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this GrupoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Empresa> ListOf_Empresa_GrupoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Empresa entities = new Permaquim.Depositary.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.GrupoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Grupo 
} //namespace Permaquim.Depositary.Entities.Relations.Directorio
		namespace Permaquim.Depositary.Entities.Relations.Directorio {
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
                public  RelacionMonedaSucursal(Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId,Permaquim.Depositary.Entities.Relations.Directorio.Sucursal SucursalId,Boolean EsDefault,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new Permaquim.Depositary.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SucursalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sucursal")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Sucursal SucursalId
             {
                 get {
                     if (SucursalId_ == null || SucursalId_.Id != _SucursalId)
                         {
                             SucursalId = new Permaquim.Depositary.Business.Relations.Directorio.Sucursal().Items(this._SucursalId).FirstOrDefault();
                         }
                     return SucursalId_;
                     }
                 set {SucursalId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Sucursal SucursalId_ = null;
             [DataItemAttributeFieldName("EsDefault","EsDefault")]
             public Boolean EsDefault { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class RelacionMonedaSucursal 
} //namespace Permaquim.Depositary.Entities.Relations.Directorio
		namespace Permaquim.Depositary.Entities.Relations.Directorio {
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
					public const string CodigoExterno = "CodigoExterno";
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
					FechaModificacion,
					CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Sector()
                {
                }
                public  Sector(Permaquim.Depositary.Entities.Relations.Directorio.Sucursal SucursalId,String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,String CodigoExterno)
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
                    this.CodigoExterno = CodigoExterno;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SucursalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sucursal")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Sucursal SucursalId
             {
                 get {
                     if (SucursalId_ == null || SucursalId_.Id != _SucursalId)
                         {
                             SucursalId = new Permaquim.Depositary.Business.Relations.Directorio.Sucursal().Items(this._SucursalId).FirstOrDefault();
                         }
                     return SucursalId_;
                     }
                 set {SucursalId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Sucursal SucursalId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_SectorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Depositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_SectorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Turno> ListOf_Turno_SectorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Turno entities = new Permaquim.Depositary.Business.Relations.Operacion.Turno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Turno.ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioSector that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.UsuarioSector> ListOf_UsuarioSector_SectorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector entities = new Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector.ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AgendaTurno that have this SectorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Turno.AgendaTurno> ListOf_AgendaTurno_SectorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Turno.AgendaTurno entities = new Permaquim.Depositary.Business.Relations.Turno.AgendaTurno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Turno.AgendaTurno.ColumnEnum.SectorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Sector 
} //namespace Permaquim.Depositary.Entities.Relations.Directorio
		namespace Permaquim.Depositary.Entities.Relations.Directorio {
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
                public  Sucursal(String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId,String CodigoExterno,String Direccion,Permaquim.Depositary.Entities.Relations.Geografia.CodigoPostal CodigoPostalId,Permaquim.Depositary.Entities.Relations.Geografia.Zona ZonaId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new Permaquim.Depositary.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Direccion","Direccion")]
             public String Direccion { get; set; }
             [DataItemAttributeFieldName("CodigoPostalId","CodigoPostalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CodigoPostalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CodigoPostal")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Geografia.CodigoPostal CodigoPostalId
             {
                 get {
                     if (CodigoPostalId_ == null || CodigoPostalId_.Id != _CodigoPostalId)
                         {
                             CodigoPostalId = new Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal().Items(this._CodigoPostalId).FirstOrDefault();
                         }
                     return CodigoPostalId_;
                     }
                 set {CodigoPostalId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Geografia.CodigoPostal CodigoPostalId_ = null;
             [DataItemAttributeFieldName("ZonaId","ZonaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ZonaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Zona")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Geografia.Zona ZonaId
             {
                 get {
                     if (ZonaId_ == null || ZonaId_.Id != _ZonaId)
                         {
                             ZonaId = new Permaquim.Depositary.Business.Relations.Geografia.Zona().Items(this._ZonaId).FirstOrDefault();
                         }
                     return ZonaId_;
                     }
                 set {ZonaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Geografia.Zona ZonaId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this SucursalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_SucursalId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal entities = new Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sector that have this SucursalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Sector> ListOf_Sector_SucursalId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Sector entities = new Permaquim.Depositary.Business.Relations.Directorio.Sector();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Sector.ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this SucursalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_SucursalId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.SucursalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Sucursal 
} //namespace Permaquim.Depositary.Entities.Relations.Directorio
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  ComandoContadora(Permaquim.Depositary.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,String Respuesta,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId
             {
                 get {
                     if (TipoContadoraId_ == null || TipoContadoraId_.Id != _TipoContadoraId)
                         {
                             TipoContadoraId = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora().Items(this._TipoContadoraId).FirstOrDefault();
                         }
                     return TipoContadoraId_;
                     }
                 set {TipoContadoraId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId_ = null;
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class ComandoContadora 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  ComandoPlaca(Permaquim.Depositary.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,String Respuesta,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId
             {
                 get {
                     if (TipoPlacaId_ == null || TipoPlacaId_.Id != _TipoPlacaId)
                         {
                             TipoPlacaId = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca().Items(this._TipoPlacaId).FirstOrDefault();
                         }
                     return TipoPlacaId_;
                     }
                 set {TipoPlacaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId_ = null;
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class ComandoPlaca 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  ConfiguracionDepositario(Permaquim.Depositary.Entities.Relations.Dispositivo.TipoConfiguracionDepositario TipoId,Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,String Valor,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.TipoConfiguracionDepositario TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.TipoConfiguracionDepositario TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class ConfiguracionDepositario 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
					public const string TipoContenedorId = "TipoContenedorId";
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
					TipoContenedorId,
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
                public  Depositario(String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId,String NumeroSerie,String CodigoExterno,Permaquim.Depositary.Entities.Relations.Operacion.TipoContenedor TipoContenedorId,Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo ModeloId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.SectorId = SectorId;
                    this.NumeroSerie = NumeroSerie;
                    this.CodigoExterno = CodigoExterno;
                    this.TipoContenedorId = TipoContenedorId;
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
             public Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new Permaquim.Depositary.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("NumeroSerie","NumeroSerie")]
             public String NumeroSerie { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("TipoContenedorId","TipoContenedorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoContenedorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoContenedor")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Operacion.TipoContenedor TipoContenedorId
             {
                 get {
                     if (TipoContenedorId_ == null || TipoContenedorId_.Id != _TipoContenedorId)
                         {
                             TipoContenedorId = new Permaquim.Depositary.Business.Relations.Operacion.TipoContenedor().Items(this._TipoContenedorId).FirstOrDefault();
                         }
                     return TipoContenedorId_;
                     }
                 set {TipoContenedorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.TipoContenedor TipoContenedorId_ = null;
             [DataItemAttributeFieldName("ModeloId","ModeloId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ModeloId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Modelo")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo ModeloId
             {
                 get {
                     if (ModeloId_ == null || ModeloId_.Id != _ModeloId)
                         {
                             ModeloId = new Permaquim.Depositary.Business.Relations.Dispositivo.Modelo().Items(this._ModeloId).FirstOrDefault();
                         }
                     return ModeloId_;
                     }
                 set {ModeloId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo ModeloId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioEstado that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioEstado> ListOf_DepositarioEstado_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioEstado entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioEstado();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioEstado.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioMoneda that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioMoneda> ListOf_DepositarioMoneda_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CierreDiario that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario> ListOf_CierreDiario_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.CierreDiario entities = new Permaquim.Depositary.Business.Relations.Operacion.CierreDiario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.CierreDiario.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Contenedor that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Contenedor> ListOf_Contenedor_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Contenedor entities = new Permaquim.Depositary.Business.Relations.Operacion.Contenedor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Evento that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Evento> ListOf_Evento_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Evento entities = new Permaquim.Depositary.Business.Relations.Operacion.Evento();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Evento.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sesion that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Sesion> ListOf_Sesion_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Sesion entities = new Permaquim.Depositary.Business.Relations.Operacion.Sesion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Sesion.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Turno> ListOf_Turno_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Turno entities = new Permaquim.Depositary.Business.Relations.Operacion.Turno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Turno.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ejecucion that have this DepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Sincronizacion.Ejecucion> ListOf_Ejecucion_DepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Sincronizacion.Ejecucion entities = new Permaquim.Depositary.Business.Relations.Sincronizacion.Ejecucion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Sincronizacion.Ejecucion.ColumnEnum.DepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Depositario 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  DepositarioContadora(Permaquim.Depositary.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId,Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,String NumeroSerie,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Int32 PollTime,Int32 Sleeptime,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId
             {
                 get {
                     if (TipoContadoraId_ == null || TipoContadoraId_.Id != _TipoContadoraId)
                         {
                             TipoContadoraId = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora().Items(this._TipoContadoraId).FirstOrDefault();
                         }
                     return TipoContadoraId_;
                     }
                 set {TipoContadoraId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.TipoContadora TipoContadoraId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioContadora 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  DepositarioEstado(Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,String ContadoraA,String ContadoraB,String Placa,String Puerta,String Contenedor,String Impresora,Boolean FueraDeServicio,String Observaciones,DateTime Fecha)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
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
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  DepositarioMoneda(Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId,Int32 IndiceEnContadora,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new Permaquim.Depositary.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("IndiceEnContadora","IndiceEnContadora")]
             public Int32 IndiceEnContadora { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioMoneda 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  DepositarioPlaca(Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,Permaquim.Depositary.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Boolean SensorA,Int16 BitSensorA,Boolean SensorB,Int16 BitSensorB,Boolean SensorC,Int16 BitSensorC,Boolean SensorD,Int16 BitSensorD,Boolean SensorL,Int16 BitSensorL,Int32 PollTime,Int32 Sleeptime,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("TipoPlacaId","TipoPlacaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoPlacaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoPlaca")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId
             {
                 get {
                     if (TipoPlacaId_ == null || TipoPlacaId_.Id != _TipoPlacaId)
                         {
                             TipoPlacaId = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca().Items(this._TipoPlacaId).FirstOrDefault();
                         }
                     return TipoPlacaId_;
                     }
                 set {TipoPlacaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.TipoPlaca TipoPlacaId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class DepositarioPlaca 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  Marca(String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Modelo that have this MarcaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo> ListOf_Modelo_MarcaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Modelo entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Modelo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Modelo.ColumnEnum.MarcaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Marca 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  Modelo(Permaquim.Depositary.Entities.Relations.Dispositivo.Marca MarcaId,String Nombre,String Descripcion,String Imagen,Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Marca MarcaId
             {
                 get {
                     if (MarcaId_ == null || MarcaId_.Id != _MarcaId)
                         {
                             MarcaId = new Permaquim.Depositary.Business.Relations.Dispositivo.Marca().Items(this._MarcaId).FirstOrDefault();
                         }
                     return MarcaId_;
                     }
                 set {MarcaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Marca MarcaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId
             {
                 get {
                     if (PlantillaMonedaId_ == null || PlantillaMonedaId_.Id != _PlantillaMonedaId)
                         {
                             PlantillaMonedaId = new Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMoneda().Items(this._PlantillaMonedaId).FirstOrDefault();
                         }
                     return PlantillaMonedaId_;
                     }
                 set {PlantillaMonedaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this ModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_ModeloId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Depositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.ModeloId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContadora that have this ModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.TipoContadora> ListOf_TipoContadora_ModeloId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora.ColumnEnum.ModeloId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoPlaca that have this ModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.TipoPlaca> ListOf_TipoPlaca_ModeloId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca.ColumnEnum.ModeloId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaTicket that have this DepositarioModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Impresion.PlantillaTicket> ListOf_PlantillaTicket_DepositarioModeloId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Impresion.PlantillaTicket entities = new Permaquim.Depositary.Business.Relations.Impresion.PlantillaTicket();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Impresion.PlantillaTicket.ColumnEnum.DepositarioModeloId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this DepositarioModeloId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Impresion.Ticket> ListOf_Ticket_DepositarioModeloId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Impresion.Ticket entities = new Permaquim.Depositary.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Impresion.Ticket.ColumnEnum.DepositarioModeloId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Modelo 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  PlantillaMoneda(String Nombre,String Decripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Decripcion","Decripcion")]
             public String Decripcion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Modelo that have this PlantillaMonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo> ListOf_Modelo_PlantillaMonedaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Modelo entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Modelo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Modelo.ColumnEnum.PlantillaMonedaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaMonedaDetalle that have this PlantillaMonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMonedaDetalle> ListOf_PlantillaMonedaDetalle_PlantillaMonedaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle entities = new Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.PlantillaMonedaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class PlantillaMoneda 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  PlantillaMonedaDetalle(Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId,String Nombre,String Decripcion,Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId,Int16 Secuencia,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId
             {
                 get {
                     if (PlantillaMonedaId_ == null || PlantillaMonedaId_.Id != _PlantillaMonedaId)
                         {
                             PlantillaMonedaId = new Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMoneda().Items(this._PlantillaMonedaId).FirstOrDefault();
                         }
                     return PlantillaMonedaId_;
                     }
                 set {PlantillaMonedaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMoneda PlantillaMonedaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Decripcion","Decripcion")]
             public String Decripcion { get; set; }
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new Permaquim.Depositary.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("Secuencia","Secuencia")]
             public Int16 Secuencia { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class PlantillaMonedaDetalle 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  TipoConfiguracionDepositario(String Clave,String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId,String Valor,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("ValidacionDatoId","ValidacionDatoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ValidacionDatoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("ConfiguracionValidacionDato")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId
             {
                 get {
                     if (ValidacionDatoId_ == null || ValidacionDatoId_.Id != _ValidacionDatoId)
                         {
                             ValidacionDatoId = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato().Items(this._ValidacionDatoId).FirstOrDefault();
                         }
                     return ValidacionDatoId_;
                     }
                 set {ValidacionDatoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato ValidacionDatoId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoConfiguracionDepositario 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  TipoContadora(Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo ModeloId,String Nombre,String Descripcion,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Int32 PollTime,Int32 Sleeptime,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo ModeloId
             {
                 get {
                     if (ModeloId_ == null || ModeloId_.Id != _ModeloId)
                         {
                             ModeloId = new Permaquim.Depositary.Business.Relations.Dispositivo.Modelo().Items(this._ModeloId).FirstOrDefault();
                         }
                     return ModeloId_;
                     }
                 set {ModeloId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo ModeloId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ComandoContadora that have this TipoContadoraId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ComandoContadora> ListOf_ComandoContadora_TipoContadoraId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ComandoContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ComandoContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ComandoContadora.ColumnEnum.TipoContadoraId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this TipoContadoraId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_TipoContadoraId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.TipoContadoraId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoContadora 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Dispositivo {
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
                public  TipoPlaca(Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo ModeloId,String Nombre,String Descripcion,String PortName,Int32 Parity,Int32 DataBits,Int32 ReadBufferSize,Int32 StopBits,Int32 ReadTimeout,Int32 Handshake,Int32 BaudRate,Boolean RtsEnable,Boolean SensorA,Int16 BitSensorA,Boolean SensorB,Int16 BitSensorB,Boolean SensorC,Int16 BitSensorC,Boolean SensorD,Int16 BitSensorD,Boolean SensorL,Int16 BitSensorL,Int32 PollTime,Int32 Sleeptime,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo ModeloId
             {
                 get {
                     if (ModeloId_ == null || ModeloId_.Id != _ModeloId)
                         {
                             ModeloId = new Permaquim.Depositary.Business.Relations.Dispositivo.Modelo().Items(this._ModeloId).FirstOrDefault();
                         }
                     return ModeloId_;
                     }
                 set {ModeloId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo ModeloId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ComandoPlaca that have this TipoPlacaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ComandoPlaca> ListOf_ComandoPlaca_TipoPlacaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ComandoPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ComandoPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ComandoPlaca.ColumnEnum.TipoPlacaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this TipoPlacaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_TipoPlacaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.TipoPlacaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoPlaca 
} //namespace Permaquim.Depositary.Entities.Relations.Dispositivo
		namespace Permaquim.Depositary.Entities.Relations.Estilo {
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
                public  Esquema(String Nombre,String Descripcion,Boolean EsDefault,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this EstiloEsquemaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Empresa> ListOf_Empresa_EstiloEsquemaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Empresa entities = new Permaquim.Depositary.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.EstiloEsquemaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this EsquemaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_EsquemaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle entities = new Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.EsquemaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Esquema 
} //namespace Permaquim.Depositary.Entities.Relations.Estilo
		namespace Permaquim.Depositary.Entities.Relations.Estilo {
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
                public  EsquemaDetalle(Permaquim.Depositary.Entities.Relations.Estilo.Esquema EsquemaId,Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId,Permaquim.Depositary.Entities.Relations.Estilo.TipoEsquemaDetalle TipoEsquemaDetalleId,String Nombre,String Descripcion,String Valor,String Imagen,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Estilo.Esquema EsquemaId
             {
                 get {
                     if (EsquemaId_ == null || EsquemaId_.Id != _EsquemaId)
                         {
                             EsquemaId = new Permaquim.Depositary.Business.Relations.Estilo.Esquema().Items(this._EsquemaId).FirstOrDefault();
                         }
                     return EsquemaId_;
                     }
                 set {EsquemaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Estilo.Esquema EsquemaId_ = null;
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("TipoEsquemaDetalleId","TipoEsquemaDetalleId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoEsquemaDetalleId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoEsquemaDetalle")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Estilo.TipoEsquemaDetalle TipoEsquemaDetalleId
             {
                 get {
                     if (TipoEsquemaDetalleId_ == null || TipoEsquemaDetalleId_.Id != _TipoEsquemaDetalleId)
                         {
                             TipoEsquemaDetalleId = new Permaquim.Depositary.Business.Relations.Estilo.TipoEsquemaDetalle().Items(this._TipoEsquemaDetalleId).FirstOrDefault();
                         }
                     return TipoEsquemaDetalleId_;
                     }
                 set {TipoEsquemaDetalleId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Estilo.TipoEsquemaDetalle TipoEsquemaDetalleId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class EsquemaDetalle 
} //namespace Permaquim.Depositary.Entities.Relations.Estilo
		namespace Permaquim.Depositary.Entities.Relations.Estilo {
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
                public  TipoEsquemaDetalle(String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this TipoEsquemaDetalleId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_TipoEsquemaDetalleId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle entities = new Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.TipoEsquemaDetalleId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoEsquemaDetalle 
} //namespace Permaquim.Depositary.Entities.Relations.Estilo
		namespace Permaquim.Depositary.Entities.Relations.Geografia {
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
                public  Ciudad(String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Geografia.Provincia ProvinciaId,String CodigoExterno,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Geografia.Provincia ProvinciaId
             {
                 get {
                     if (ProvinciaId_ == null || ProvinciaId_.Id != _ProvinciaId)
                         {
                             ProvinciaId = new Permaquim.Depositary.Business.Relations.Geografia.Provincia().Items(this._ProvinciaId).FirstOrDefault();
                         }
                     return ProvinciaId_;
                     }
                 set {ProvinciaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Geografia.Provincia ProvinciaId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of CodigoPostal that have this CiudadId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.CodigoPostal> ListOf_CodigoPostal_CiudadId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal entities = new Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal.ColumnEnum.CiudadId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Ciudad 
} //namespace Permaquim.Depositary.Entities.Relations.Geografia
		namespace Permaquim.Depositary.Entities.Relations.Geografia {
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
                public  CodigoPostal(String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Geografia.Ciudad CiudadId,String CodigoExterno,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Geografia.Ciudad CiudadId
             {
                 get {
                     if (CiudadId_ == null || CiudadId_.Id != _CiudadId)
                         {
                             CiudadId = new Permaquim.Depositary.Business.Relations.Geografia.Ciudad().Items(this._CiudadId).FirstOrDefault();
                         }
                     return CiudadId_;
                     }
                 set {CiudadId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Geografia.Ciudad CiudadId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this CodigoPostalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Empresa> ListOf_Empresa_CodigoPostalId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Empresa entities = new Permaquim.Depositary.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.CodigoPostalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this CodigoPostalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_CodigoPostalId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Sucursal entities = new Permaquim.Depositary.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.CodigoPostalId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class CodigoPostal 
} //namespace Permaquim.Depositary.Entities.Relations.Geografia
		namespace Permaquim.Depositary.Entities.Relations.Geografia {
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
                public  Pais(String Nombre,String Descripcion,String Codigo,String CodigoExterno,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Banco that have this PaisId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.Banco> ListOf_Banco_PaisId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.Banco entities = new Permaquim.Depositary.Business.Relations.Banca.Banco();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.Banco.ColumnEnum.PaisId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Provincia that have this PaisId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Provincia> ListOf_Provincia_PaisId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Provincia entities = new Permaquim.Depositary.Business.Relations.Geografia.Provincia();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Provincia.ColumnEnum.PaisId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Moneda that have this PaisId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.Moneda> ListOf_Moneda_PaisId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.Moneda entities = new Permaquim.Depositary.Business.Relations.Valor.Moneda();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.Moneda.ColumnEnum.PaisId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Pais 
} //namespace Permaquim.Depositary.Entities.Relations.Geografia
		namespace Permaquim.Depositary.Entities.Relations.Geografia {
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
                public  Provincia(String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Geografia.Pais PaisId,String CodigoExterno,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Geografia.Pais PaisId
             {
                 get {
                     if (PaisId_ == null || PaisId_.Id != _PaisId)
                         {
                             PaisId = new Permaquim.Depositary.Business.Relations.Geografia.Pais().Items(this._PaisId).FirstOrDefault();
                         }
                     return PaisId_;
                     }
                 set {PaisId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Geografia.Pais PaisId_ = null;
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Ciudad that have this ProvinciaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Ciudad> ListOf_Ciudad_ProvinciaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Ciudad entities = new Permaquim.Depositary.Business.Relations.Geografia.Ciudad();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Ciudad.ColumnEnum.ProvinciaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Provincia 
} //namespace Permaquim.Depositary.Entities.Relations.Geografia
		namespace Permaquim.Depositary.Entities.Relations.Geografia {
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
					public const string CodigoExterno = "CodigoExterno";
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
					FechaModificacion,
					CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Zona()
                {
                }
                public  Zona(String Nombre,String Descripcion,String Codigo,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,String CodigoExterno)
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
                    this.CodigoExterno = CodigoExterno;
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this ZonaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_ZonaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Sucursal entities = new Permaquim.Depositary.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.ZonaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Zona 
} //namespace Permaquim.Depositary.Entities.Relations.Geografia
		namespace Permaquim.Depositary.Entities.Relations.Impresion {
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
                public  PlantillaTicket(Permaquim.Depositary.Entities.Relations.Impresion.TipoTicket TipoId,Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo DepositarioModeloId,String Nombre,String Descripcion,String Impresora,String TextoCabecera,String NombreFuenteCabecera,Int32 TamanioFuenteCabecera,Int32 UbicacionTextoCabecera,String TextoPie,String NombreFuentePie,Int32 TamanioFuentePie,String UbicacionTextoPie,String Imagen,String UbicacionImagen,Int32 UbicacionTextoDetalle,Int32 AnchoDetalle,Int32 TamanioEntreLineas,Int32 AnchoReporte,Int32 FactorAltoReporte,Int32 LineasAlFinal)
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
             public Permaquim.Depositary.Entities.Relations.Impresion.TipoTicket TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Impresion.TipoTicket().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Impresion.TipoTicket TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioModeloId","DepositarioModeloId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioModeloId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Modelo")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo DepositarioModeloId
             {
                 get {
                     if (DepositarioModeloId_ == null || DepositarioModeloId_.Id != _DepositarioModeloId)
                         {
                             DepositarioModeloId = new Permaquim.Depositary.Business.Relations.Dispositivo.Modelo().Items(this._DepositarioModeloId).FirstOrDefault();
                         }
                     return DepositarioModeloId_;
                     }
                 set {DepositarioModeloId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo DepositarioModeloId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class PlantillaTicket 
} //namespace Permaquim.Depositary.Entities.Relations.Impresion
		namespace Permaquim.Depositary.Entities.Relations.Impresion {
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
                public  Ticket(Permaquim.Depositary.Entities.Relations.Impresion.TipoTicket TipoId,Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo DepositarioModeloId,Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId,String Nombre,String Descripcion,String Impresora,String TextoCabecera,String NombreFuenteCabecera,Int32 TamanioFuenteCabecera,Int32 UbicacionTextoCabecera,String TextoPie,String NombreFuentePie,Int32 TamanioFuentePie,String UbicacionTextoPie,String Imagen,String UbicacionImagen,Int32 UbicacionTextoDetalle,Int32 AnchoDetalle,Int32 TamanioEntreLineas,Int32 AnchoReporte,Int32 FactorAltoReporte,Int32 LineasAlFinal,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Impresion.TipoTicket TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Impresion.TipoTicket().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Impresion.TipoTicket TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioModeloId","DepositarioModeloId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioModeloId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Modelo")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo DepositarioModeloId
             {
                 get {
                     if (DepositarioModeloId_ == null || DepositarioModeloId_.Id != _DepositarioModeloId)
                         {
                             DepositarioModeloId = new Permaquim.Depositary.Business.Relations.Dispositivo.Modelo().Items(this._DepositarioModeloId).FirstOrDefault();
                         }
                     return DepositarioModeloId_;
                     }
                 set {DepositarioModeloId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo DepositarioModeloId_ = null;
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new Permaquim.Depositary.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Ticket 
} //namespace Permaquim.Depositary.Entities.Relations.Impresion
		namespace Permaquim.Depositary.Entities.Relations.Impresion {
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
                public  TipoTicket(String Nombre,String Descripcion,String Codigo,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of PlantillaTicket that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Impresion.PlantillaTicket> ListOf_PlantillaTicket_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Impresion.PlantillaTicket entities = new Permaquim.Depositary.Business.Relations.Impresion.PlantillaTicket();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Impresion.PlantillaTicket.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Impresion.Ticket> ListOf_Ticket_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Impresion.Ticket entities = new Permaquim.Depositary.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Impresion.Ticket.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoTicket 
} //namespace Permaquim.Depositary.Entities.Relations.Impresion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  CierreDiario(String Nombre,DateTime? Fecha,Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,Permaquim.Depositary.Entities.Relations.Operacion.Sesion SesionId,String CodigoCierre,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime? Fecha { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("SesionId","SesionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SesionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sesion")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Operacion.Sesion SesionId
             {
                 get {
                     if (SesionId_ == null || SesionId_.Id != _SesionId)
                         {
                             SesionId = new Permaquim.Depositary.Business.Relations.Operacion.Sesion().Items(this._SesionId).FirstOrDefault();
                         }
                     return SesionId_;
                     }
                 set {SesionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.Sesion SesionId_ = null;
             [DataItemAttributeFieldName("CodigoCierre","CodigoCierre")]
             public String CodigoCierre { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this CierreDiarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_CierreDiarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.CierreDiarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this CierreDiarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Turno> ListOf_Turno_CierreDiarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Turno entities = new Permaquim.Depositary.Business.Relations.Operacion.Turno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Turno.ColumnEnum.CierreDiarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class CierreDiario 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  Contenedor(String Nombre,Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,Permaquim.Depositary.Entities.Relations.Operacion.TipoContenedor TipoId,String Identificador,DateTime FechaApertura,DateTime? FechaCierre,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoContenedor")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Operacion.TipoContenedor TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Operacion.TipoContenedor().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.TipoContenedor TipoId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this ContenedorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_ContenedorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.ContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Contenedor 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  Evento(Permaquim.Depositary.Entities.Relations.Operacion.TipoEvento TipoId,Int64? SesionId,Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,String Mensaje,String Valor,DateTime Fecha)
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
             public Permaquim.Depositary.Entities.Relations.Operacion.TipoEvento TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Operacion.TipoEvento().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.TipoEvento TipoId_ = null;
             [DataItemAttributeFieldName("SesionId","SesionId")]
             public Int64? SesionId { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("Mensaje","Mensaje")]
             public String Mensaje { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class Evento 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  Sesion(Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,Int64 UsuarioId,DateTime FechaInicio,DateTime? FechaCierre,Boolean? EsCierreAutomatico)
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
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
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
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario> ListOf_CierreDiario_SesionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.CierreDiario entities = new Permaquim.Depositary.Business.Relations.Operacion.CierreDiario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.CierreDiario.ColumnEnum.SesionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this SesionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_SesionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.SesionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Sesion 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
					public const string CodigoExterno = "CodigoExterno";
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
					FechaModificacion,
					CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoContenedor()
                {
                }
                public  TipoContenedor(String Nombre,String Descripcion,Int32 Capacidad,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,String CodigoExterno)
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
                    this.CodigoExterno = CodigoExterno;
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this TipoContenedorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_TipoContenedorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Depositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.TipoContenedorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Contenedor that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Contenedor> ListOf_Contenedor_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Contenedor entities = new Permaquim.Depositary.Business.Relations.Operacion.Contenedor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoContenedor 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  TipoEvento(String Nombre,String Descripcion,Boolean EsBloqueante,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Evento that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Evento> ListOf_Evento_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Evento entities = new Permaquim.Depositary.Business.Relations.Operacion.Evento();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Evento.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoEvento 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  TipoTransaccion(String Nombre,String Descripcion,Int64? FuncionId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoTransaccion 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
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
					CodigoOperacion,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Transaccion()
                {
                }
                public  Transaccion(Permaquim.Depositary.Entities.Relations.Operacion.TipoTransaccion TipoId,Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId,Permaquim.Depositary.Entities.Relations.Directorio.Sucursal SucursalId,Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId,Permaquim.Depositary.Entities.Relations.Banca.Cuenta CuentaId,Permaquim.Depositary.Entities.Relations.Operacion.Contenedor ContenedorId,Permaquim.Depositary.Entities.Relations.Operacion.Sesion SesionId,Permaquim.Depositary.Entities.Relations.Operacion.Turno TurnoId,Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario CierreDiarioId,Double TotalValidado,Double TotalAValidar,DateTime Fecha,Boolean Finalizada,Boolean EsDepositoAutomatico,Permaquim.Depositary.Entities.Relations.Valor.OrigenValor OrigenValorId,String CodigoOperacion,DateTime FechaCreacion,DateTime? FechaModificacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion)
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
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoTransaccion")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Operacion.TipoTransaccion TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Operacion.TipoTransaccion().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.TipoTransaccion TipoId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new Permaquim.Depositary.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("SucursalId","SucursalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SucursalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sucursal")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Sucursal SucursalId
             {
                 get {
                     if (SucursalId_ == null || SucursalId_.Id != _SucursalId)
                         {
                             SucursalId = new Permaquim.Depositary.Business.Relations.Directorio.Sucursal().Items(this._SucursalId).FirstOrDefault();
                         }
                     return SucursalId_;
                     }
                 set {SucursalId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Sucursal SucursalId_ = null;
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new Permaquim.Depositary.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("CuentaId","CuentaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CuentaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Cuenta")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Banca.Cuenta CuentaId
             {
                 get {
                     if (CuentaId_ == null || CuentaId_.Id != _CuentaId)
                         {
                             CuentaId = new Permaquim.Depositary.Business.Relations.Banca.Cuenta().Items(this._CuentaId).FirstOrDefault();
                         }
                     return CuentaId_;
                     }
                 set {CuentaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Banca.Cuenta CuentaId_ = null;
             [DataItemAttributeFieldName("ContenedorId","ContenedorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ContenedorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Contenedor")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Operacion.Contenedor ContenedorId
             {
                 get {
                     if (ContenedorId_ == null || ContenedorId_.Id != _ContenedorId)
                         {
                             ContenedorId = new Permaquim.Depositary.Business.Relations.Operacion.Contenedor().Items(this._ContenedorId).FirstOrDefault();
                         }
                     return ContenedorId_;
                     }
                 set {ContenedorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.Contenedor ContenedorId_ = null;
             [DataItemAttributeFieldName("SesionId","SesionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SesionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sesion")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Operacion.Sesion SesionId
             {
                 get {
                     if (SesionId_ == null || SesionId_.Id != _SesionId)
                         {
                             SesionId = new Permaquim.Depositary.Business.Relations.Operacion.Sesion().Items(this._SesionId).FirstOrDefault();
                         }
                     return SesionId_;
                     }
                 set {SesionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.Sesion SesionId_ = null;
             [DataItemAttributeFieldName("TurnoId","TurnoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TurnoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Turno")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Operacion.Turno TurnoId
             {
                 get {
                     if (TurnoId_ == null || TurnoId_.Id != _TurnoId)
                         {
                             TurnoId = new Permaquim.Depositary.Business.Relations.Operacion.Turno().Items(this._TurnoId).FirstOrDefault();
                         }
                     return TurnoId_;
                     }
                 set {TurnoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.Turno TurnoId_ = null;
             [DataItemAttributeFieldName("CierreDiarioId","CierreDiarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CierreDiarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CierreDiario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario CierreDiarioId
             {
                 get {
                     if (CierreDiarioId_ == null || CierreDiarioId_.Id != _CierreDiarioId)
                         {
                             CierreDiarioId = new Permaquim.Depositary.Business.Relations.Operacion.CierreDiario().Items(this._CierreDiarioId).FirstOrDefault();
                         }
                     return CierreDiarioId_;
                     }
                 set {CierreDiarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario CierreDiarioId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Valor.OrigenValor OrigenValorId
             {
                 get {
                     if (OrigenValorId_ == null || OrigenValorId_.Id != _OrigenValorId)
                         {
                             OrigenValorId = new Permaquim.Depositary.Business.Relations.Valor.OrigenValor().Items(this._OrigenValorId).FirstOrDefault();
                         }
                     return OrigenValorId_;
                     }
                 set {OrigenValorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.OrigenValor OrigenValorId_ = null;
             [DataItemAttributeFieldName("CodigoOperacion","CodigoOperacion")]
             public String CodigoOperacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
                 /// <summary>
                 ///  Represents the child collection of TransaccionDetalle that have this TransaccionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TransaccionDetalle> ListOf_TransaccionDetalle_TransaccionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TransaccionDetalle entities = new Permaquim.Depositary.Business.Relations.Operacion.TransaccionDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TransaccionSobre that have this TransaccionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TransaccionSobre> ListOf_TransaccionSobre_TransaccionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobre entities = new Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobre();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobre.ColumnEnum.TransaccionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Transaccion 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  TransaccionDetalle(Permaquim.Depositary.Entities.Relations.Operacion.Transaccion TransaccionId,Permaquim.Depositary.Entities.Relations.Valor.Denominacion DenominacionId,Int64 CantidadUnidades,DateTime Fecha)
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
             public Permaquim.Depositary.Entities.Relations.Operacion.Transaccion TransaccionId
             {
                 get {
                     if (TransaccionId_ == null || TransaccionId_.Id != _TransaccionId)
                         {
                             TransaccionId = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion().Items(this._TransaccionId).FirstOrDefault();
                         }
                     return TransaccionId_;
                     }
                 set {TransaccionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.Transaccion TransaccionId_ = null;
             [DataItemAttributeFieldName("DenominacionId","DenominacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DenominacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Denominacion")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Valor.Denominacion DenominacionId
             {
                 get {
                     if (DenominacionId_ == null || DenominacionId_.Id != _DenominacionId)
                         {
                             DenominacionId = new Permaquim.Depositary.Business.Relations.Valor.Denominacion().Items(this._DenominacionId).FirstOrDefault();
                         }
                     return DenominacionId_;
                     }
                 set {DenominacionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Denominacion DenominacionId_ = null;
             [DataItemAttributeFieldName("CantidadUnidades","CantidadUnidades")]
             public Int64 CantidadUnidades { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class TransaccionDetalle 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  TransaccionSobre(Permaquim.Depositary.Entities.Relations.Operacion.Transaccion TransaccionId,String CodigoSobre,DateTime Fecha)
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
             public Permaquim.Depositary.Entities.Relations.Operacion.Transaccion TransaccionId
             {
                 get {
                     if (TransaccionId_ == null || TransaccionId_.Id != _TransaccionId)
                         {
                             TransaccionId = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion().Items(this._TransaccionId).FirstOrDefault();
                         }
                     return TransaccionId_;
                     }
                 set {TransaccionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.Transaccion TransaccionId_ = null;
             [DataItemAttributeFieldName("CodigoSobre","CodigoSobre")]
             public String CodigoSobre { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionSobreDetalle that have this SobreId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TransaccionSobreDetalle> ListOf_TransaccionSobreDetalle_SobreId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobreDetalle entities = new Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobreDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.SobreId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TransaccionSobre 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  TransaccionSobreDetalle(Permaquim.Depositary.Entities.Relations.Operacion.TransaccionSobre SobreId,Permaquim.Depositary.Entities.Relations.Valor.RelacionMonedaTipoValor RelacionMonedaTipoValorId,Int64 CantidadDeclarada,Double ValorDeclarado,DateTime Fecha)
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
             public Permaquim.Depositary.Entities.Relations.Operacion.TransaccionSobre SobreId
             {
                 get {
                     if (SobreId_ == null || SobreId_.Id != _SobreId)
                         {
                             SobreId = new Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobre().Items(this._SobreId).FirstOrDefault();
                         }
                     return SobreId_;
                     }
                 set {SobreId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.TransaccionSobre SobreId_ = null;
             [DataItemAttributeFieldName("RelacionMonedaTipoValorId","RelacionMonedaTipoValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _RelacionMonedaTipoValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("RelacionMonedaTipoValor")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Valor.RelacionMonedaTipoValor RelacionMonedaTipoValorId
             {
                 get {
                     if (RelacionMonedaTipoValorId_ == null || RelacionMonedaTipoValorId_.Id != _RelacionMonedaTipoValorId)
                         {
                             RelacionMonedaTipoValorId = new Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor().Items(this._RelacionMonedaTipoValorId).FirstOrDefault();
                         }
                     return RelacionMonedaTipoValorId_;
                     }
                 set {RelacionMonedaTipoValorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.RelacionMonedaTipoValor RelacionMonedaTipoValorId_ = null;
             [DataItemAttributeFieldName("CantidadDeclarada","CantidadDeclarada")]
             public Int64 CantidadDeclarada { get; set; }
             [DataItemAttributeFieldName("ValorDeclarado","ValorDeclarado")]
             public Double ValorDeclarado { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class TransaccionSobreDetalle 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  Turno(Permaquim.Depositary.Entities.Relations.Turno.AgendaTurno TurnoDepositarioId,Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId,DateTime? FechaApertura,DateTime? FechaCierre,DateTime? Fecha,Int32 Secuencia,Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario CierreDiarioId,String Observaciones,String CodigoTurno,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,Boolean Habilitado)
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
             public Permaquim.Depositary.Entities.Relations.Turno.AgendaTurno TurnoDepositarioId
             {
                 get {
                     if (TurnoDepositarioId_ == null || TurnoDepositarioId_.Id != _TurnoDepositarioId)
                         {
                             TurnoDepositarioId = new Permaquim.Depositary.Business.Relations.Turno.AgendaTurno().Items(this._TurnoDepositarioId).FirstOrDefault();
                         }
                     return TurnoDepositarioId_;
                     }
                 set {TurnoDepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Turno.AgendaTurno TurnoDepositarioId_ = null;
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new Permaquim.Depositary.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario CierreDiarioId
             {
                 get {
                     if (CierreDiarioId_ == null || CierreDiarioId_.Id != _CierreDiarioId)
                         {
                             CierreDiarioId = new Permaquim.Depositary.Business.Relations.Operacion.CierreDiario().Items(this._CierreDiarioId).FirstOrDefault();
                         }
                     return CierreDiarioId_;
                     }
                 set {CierreDiarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario CierreDiarioId_ = null;
             [DataItemAttributeFieldName("Observaciones","Observaciones")]
             public String Observaciones { get; set; }
             [DataItemAttributeFieldName("CodigoTurno","CodigoTurno")]
             public String CodigoTurno { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this TurnoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_TurnoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.TurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Turno 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Operacion {
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
                public  TurnoUsuario(Int64 UsuarioId,Int64 TurnoId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class TurnoUsuario 
} //namespace Permaquim.Depositary.Entities.Relations.Operacion
		namespace Permaquim.Depositary.Entities.Relations.Regionalizacion {
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
                public  Lenguaje(String Nombre,String Descripcion,String Cultura,Boolean EsDefault,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Empresa> ListOf_Empresa_LenguajeId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Empresa entities = new Permaquim.Depositary.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.LenguajeId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of LenguajeItem that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Regionalizacion.LenguajeItem> ListOf_LenguajeItem_LenguajeId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Regionalizacion.LenguajeItem entities = new Permaquim.Depositary.Business.Relations.Regionalizacion.LenguajeItem();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Regionalizacion.LenguajeItem.ColumnEnum.LenguajeId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Usuario that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Usuario> ListOf_Usuario_LenguajeId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Usuario entities = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.LenguajeId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Lenguaje 
} //namespace Permaquim.Depositary.Entities.Relations.Regionalizacion
		namespace Permaquim.Depositary.Entities.Relations.Regionalizacion {
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
                public  LenguajeItem(Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,String Clave,String Texto,Boolean Habilitado,Int32 LargoMaximo,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new Permaquim.Depositary.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class LenguajeItem 
} //namespace Permaquim.Depositary.Entities.Relations.Regionalizacion
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  Aplicacion(Permaquim.Depositary.Entities.Relations.Seguridad.TipoAplicacion TipoId,String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.TipoAplicacion TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Seguridad.TipoAplicacion().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.TipoAplicacion TipoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Configuracion that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.Configuracion> ListOf_Configuracion_AplicacionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion entities = new Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion.ColumnEnum.AplicacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Log that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Auditoria.Log> ListOf_Log_AplicacionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Auditoria.Log entities = new Permaquim.Depositary.Business.Relations.Auditoria.Log();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Auditoria.Log.ColumnEnum.AplicacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_AplicacionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle entities = new Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.AplicacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametro that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametro> ListOf_AplicacionParametro_AplicacionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro entities = new Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro.ColumnEnum.AplicacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametroValor that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametroValor> ListOf_AplicacionParametroValor_AplicacionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor entities = new Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor.ColumnEnum.AplicacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_AplicacionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Funcion entities = new Permaquim.Depositary.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Funcion.ColumnEnum.AplicacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Rol that have this AplicacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Rol> ListOf_Rol_AplicacionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Rol entities = new Permaquim.Depositary.Business.Relations.Seguridad.Rol();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Rol.ColumnEnum.AplicacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Aplicacion 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  AplicacionParametro(Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId,String Nombre,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametroValor that have this ParametroId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametroValor> ListOf_AplicacionParametroValor_ParametroId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor entities = new Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor.ColumnEnum.ParametroId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class AplicacionParametro 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  AplicacionParametroValor(Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId,Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametro ParametroId,String Valor,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("ParametroId","ParametroId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ParametroId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("AplicacionParametro")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametro ParametroId
             {
                 get {
                     if (ParametroId_ == null || ParametroId_.Id != _ParametroId)
                         {
                             ParametroId = new Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro().Items(this._ParametroId).FirstOrDefault();
                         }
                     return ParametroId_;
                     }
                 set {ParametroId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametro ParametroId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class AplicacionParametroValor 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  Funcion(Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId,Permaquim.Depositary.Entities.Relations.Seguridad.TipoFuncion TipoId,String Nombre,String Descripcion,String Referencia,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
             [DataItemAttributeFieldName("TipoId","TipoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoFuncion")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.TipoFuncion TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Seguridad.TipoFuncion().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.TipoFuncion TipoId_ = null;
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this FuncionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Menu> ListOf_Menu_FuncionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Menu entities = new Permaquim.Depositary.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Menu.ColumnEnum.FuncionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this FuncionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_FuncionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion entities = new Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.FuncionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Funcion 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  IdentificadorUsuario(Permaquim.Depositary.Entities.Relations.Seguridad.TipoIdentificador TipoId,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId,String Valor,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.TipoIdentificador TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Seguridad.TipoIdentificador().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.TipoIdentificador TipoId_ = null;
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class IdentificadorUsuario 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
					public const string Orden = "Orden";
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
					Orden,
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
                public  Menu(Permaquim.Depositary.Entities.Relations.Seguridad.TipoMenu TipoId,String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Seguridad.Funcion FuncionId,String Imagen,Permaquim.Depositary.Entities.Relations.Seguridad.Menu DependeDe,Int32 Orden,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.FuncionId = FuncionId;
                    this.Imagen = Imagen;
                    this.DependeDe = DependeDe;
                    this.Orden = Orden;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.TipoMenu TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Permaquim.Depositary.Business.Relations.Seguridad.TipoMenu().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.TipoMenu TipoId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Funcion FuncionId
             {
                 get {
                     if (FuncionId_ == null || FuncionId_.Id != _FuncionId)
                         {
                             FuncionId = new Permaquim.Depositary.Business.Relations.Seguridad.Funcion().Items(this._FuncionId).FirstOrDefault();
                         }
                     return FuncionId_;
                     }
                 set {FuncionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Funcion FuncionId_ = null;
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("DependeDe","DependeDe")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DependeDe { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Menu")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Menu DependeDe
             {
                 get {
                     if (DependeDe_ == null || DependeDe_.Id != _DependeDe)
                         {
                             DependeDe = new Permaquim.Depositary.Business.Relations.Seguridad.Menu().Items(this._DependeDe).FirstOrDefault();
                         }
                     return DependeDe_;
                     }
                 set {DependeDe_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Menu DependeDe_ = null;
             [DataItemAttributeFieldName("Orden","Orden")]
             public Int32 Orden { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Menu 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
					public const string CodigoExterno = "CodigoExterno";
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
					FechaModificacion,
					CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Rol()
                {
                }
                public  Rol(Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId,String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Seguridad.Rol DependeDe,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,String CodigoExterno)
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
                    this.CodigoExterno = CodigoExterno;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("AplicacionId","AplicacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _AplicacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId
             {
                 get {
                     if (AplicacionId_ == null || AplicacionId_.Id != _AplicacionId)
                         {
                             AplicacionId = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion().Items(this._AplicacionId).FirstOrDefault();
                         }
                     return AplicacionId_;
                     }
                 set {AplicacionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion AplicacionId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Rol DependeDe
             {
                 get {
                     if (DependeDe_ == null || DependeDe_.Id != _DependeDe)
                         {
                             DependeDe = new Permaquim.Depositary.Business.Relations.Seguridad.Rol().Items(this._DependeDe).FirstOrDefault();
                         }
                     return DependeDe_;
                     }
                 set {DependeDe_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Rol DependeDe_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this RolId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_RolId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion entities = new Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.RolId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this RolId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_RolId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol entities = new Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.RolId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Rol 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  RolFuncion(Permaquim.Depositary.Entities.Relations.Seguridad.Funcion FuncionId,Permaquim.Depositary.Entities.Relations.Seguridad.Rol RolId,String Descripcion,Boolean PuedeAgregar,Boolean PuedeModificar,Boolean PuedeEliminar,Boolean PuedeVisualizar,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Funcion FuncionId
             {
                 get {
                     if (FuncionId_ == null || FuncionId_.Id != _FuncionId)
                         {
                             FuncionId = new Permaquim.Depositary.Business.Relations.Seguridad.Funcion().Items(this._FuncionId).FirstOrDefault();
                         }
                     return FuncionId_;
                     }
                 set {FuncionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Funcion FuncionId_ = null;
             [DataItemAttributeFieldName("RolId","RolId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _RolId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Rol RolId
             {
                 get {
                     if (RolId_ == null || RolId_.Id != _RolId)
                         {
                             RolId = new Permaquim.Depositary.Business.Relations.Seguridad.Rol().Items(this._RolId).FirstOrDefault();
                         }
                     return RolId_;
                     }
                 set {RolId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Rol RolId_ = null;
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class RolFuncion 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  TipoAplicacion(String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Aplicacion that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion> ListOf_Aplicacion_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion entities = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoAplicacion 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  TipoFuncion(String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Funcion entities = new Permaquim.Depositary.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Funcion.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoFuncion 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  TipoIdentificador(String Nombre,String Descripcion,String Mascara,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of IdentificadorUsuario that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.IdentificadorUsuario> ListOf_IdentificadorUsuario_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario entities = new Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoIdentificador 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  TipoMenu(String Nombre,String Descripcion,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Menu> ListOf_Menu_TipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Menu entities = new Permaquim.Depositary.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Menu.ColumnEnum.TipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class TipoMenu 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
					public const string CodigoExterno = "CodigoExterno";
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
					FechaModificacion,
					CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Usuario()
                {
                }
                public  Usuario(Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId,Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,Permaquim.Depositary.Entities.Relations.Visualizacion.Perfil PerfilId,String Nombre,String Apellido,String NombreApellido,String Documento,String Legajo,String Mail,DateTime FechaIngreso,String NickName,String Password,String Token,String Avatar,DateTime? FechaUltimoLogin,Boolean DebeCambiarPassword,Boolean Habilitado,Int32 CantidadLogueosIncorrectos,Boolean Bloqueado,DateTime? FechaExpiracion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,String CodigoExterno)
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
                    this.CodigoExterno = CodigoExterno;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EmpresaId","EmpresaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EmpresaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Empresa")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new Permaquim.Depositary.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("LenguajeId","LenguajeId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _LenguajeId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Lenguaje")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new Permaquim.Depositary.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
             [DataItemAttributeFieldName("PerfilId","PerfilId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PerfilId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Perfil")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Visualizacion.Perfil PerfilId
             {
                 get {
                     if (PerfilId_ == null || PerfilId_.Id != _PerfilId)
                         {
                             PerfilId = new Permaquim.Depositary.Business.Relations.Visualizacion.Perfil().Items(this._PerfilId).FirstOrDefault();
                         }
                     return PerfilId_;
                     }
                 set {PerfilId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Visualizacion.Perfil PerfilId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Configuracion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.Configuracion> ListOf_Configuracion_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion entities = new Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Configuracion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.Configuracion> ListOf_Configuracion_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion entities = new Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.Configuracion.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionEmpresa that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionEmpresa> ListOf_ConfiguracionEmpresa_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa entities = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionEmpresa that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionEmpresa> ListOf_ConfiguracionEmpresa_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa entities = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionEmpresa.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionTipoDato that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionTipoDato> ListOf_ConfiguracionTipoDato_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionTipoDato entities = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionTipoDato();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionTipoDato.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionTipoDato that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionTipoDato> ListOf_ConfiguracionTipoDato_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionTipoDato entities = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionTipoDato();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionTipoDato.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionValidacionDato that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato> ListOf_ConfiguracionValidacionDato_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato entities = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionValidacionDato that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Aplicacion.ConfiguracionValidacionDato> ListOf_ConfiguracionValidacionDato_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato entities = new Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Aplicacion.ConfiguracionValidacionDato.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoLog that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Auditoria.TipoLog> ListOf_TipoLog_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Auditoria.TipoLog entities = new Permaquim.Depositary.Business.Relations.Auditoria.TipoLog();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Auditoria.TipoLog.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoLog that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Auditoria.TipoLog> ListOf_TipoLog_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Auditoria.TipoLog entities = new Permaquim.Depositary.Business.Relations.Auditoria.TipoLog();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Auditoria.TipoLog.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Banco that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.Banco> ListOf_Banco_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.Banco entities = new Permaquim.Depositary.Business.Relations.Banca.Banco();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.Banco.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Banco that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.Banco> ListOf_Banco_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.Banco entities = new Permaquim.Depositary.Business.Relations.Banca.Banco();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.Banco.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.Cuenta entities = new Permaquim.Depositary.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.Cuenta.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Cuenta that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.Cuenta> ListOf_Cuenta_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.Cuenta entities = new Permaquim.Depositary.Business.Relations.Banca.Cuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.Cuenta.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoCuenta that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.TipoCuenta> ListOf_TipoCuenta_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.TipoCuenta entities = new Permaquim.Depositary.Business.Relations.Banca.TipoCuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.TipoCuenta.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoCuenta that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.TipoCuenta> ListOf_TipoCuenta_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.TipoCuenta entities = new Permaquim.Depositary.Business.Relations.Banca.TipoCuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.TipoCuenta.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioCuenta that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.UsuarioCuenta> ListOf_UsuarioCuenta_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta entities = new Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioCuenta that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.UsuarioCuenta> ListOf_UsuarioCuenta_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta entities = new Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioCuenta that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.UsuarioCuenta> ListOf_UsuarioCuenta_UsuarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta entities = new Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.UsuarioCuenta.ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of HuellaDactilar that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Biometria.HuellaDactilar> ListOf_HuellaDactilar_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Biometria.HuellaDactilar entities = new Permaquim.Depositary.Business.Relations.Biometria.HuellaDactilar();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Biometria.HuellaDactilar.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of HuellaDactilar that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Biometria.HuellaDactilar> ListOf_HuellaDactilar_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Biometria.HuellaDactilar entities = new Permaquim.Depositary.Business.Relations.Biometria.HuellaDactilar();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Biometria.HuellaDactilar.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Entidad that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Customizador.Entidad> ListOf_Entidad_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Customizador.Entidad entities = new Permaquim.Depositary.Business.Relations.Customizador.Entidad();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Customizador.Entidad.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Entidad that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Customizador.Entidad> ListOf_Entidad_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Customizador.Entidad entities = new Permaquim.Depositary.Business.Relations.Customizador.Entidad();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Customizador.Entidad.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EntidadAtributo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Customizador.EntidadAtributo> ListOf_EntidadAtributo_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Customizador.EntidadAtributo entities = new Permaquim.Depositary.Business.Relations.Customizador.EntidadAtributo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Customizador.EntidadAtributo.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EntidadAtributo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Customizador.EntidadAtributo> ListOf_EntidadAtributo_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Customizador.EntidadAtributo entities = new Permaquim.Depositary.Business.Relations.Customizador.EntidadAtributo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Customizador.EntidadAtributo.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Empresa> ListOf_Empresa_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Empresa entities = new Permaquim.Depositary.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Empresa that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Empresa> ListOf_Empresa_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Empresa entities = new Permaquim.Depositary.Business.Relations.Directorio.Empresa();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Empresa.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Grupo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Grupo> ListOf_Grupo_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Grupo entities = new Permaquim.Depositary.Business.Relations.Directorio.Grupo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Grupo.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Grupo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Grupo> ListOf_Grupo_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Grupo entities = new Permaquim.Depositary.Business.Relations.Directorio.Grupo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Grupo.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal entities = new Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal entities = new Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sector that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Sector> ListOf_Sector_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Sector entities = new Permaquim.Depositary.Business.Relations.Directorio.Sector();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Sector.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sector that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Sector> ListOf_Sector_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Sector entities = new Permaquim.Depositary.Business.Relations.Directorio.Sector();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Sector.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Sucursal entities = new Permaquim.Depositary.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Sucursal that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.Sucursal> ListOf_Sucursal_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.Sucursal entities = new Permaquim.Depositary.Business.Relations.Directorio.Sucursal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.Sucursal.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ComandoContadora that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ComandoContadora> ListOf_ComandoContadora_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ComandoContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ComandoContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ComandoContadora.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ComandoContadora that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ComandoContadora> ListOf_ComandoContadora_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ComandoContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ComandoContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ComandoContadora.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ComandoPlaca that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ComandoPlaca> ListOf_ComandoPlaca_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ComandoPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ComandoPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ComandoPlaca.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ComandoPlaca that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ComandoPlaca> ListOf_ComandoPlaca_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ComandoPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ComandoPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ComandoPlaca.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionDepositario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.ConfiguracionDepositario> ListOf_ConfiguracionDepositario_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.ConfiguracionDepositario.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Depositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Depositario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario> ListOf_Depositario_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Depositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Depositario.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioContadora that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioContadora> ListOf_DepositarioContadora_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioContadora.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioMoneda that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioMoneda> ListOf_DepositarioMoneda_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioMoneda that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioMoneda> ListOf_DepositarioMoneda_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioPlaca that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioPlaca> ListOf_DepositarioPlaca_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioPlaca.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Marca that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Marca> ListOf_Marca_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Marca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Marca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Marca.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Marca that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Marca> ListOf_Marca_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Marca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Marca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Marca.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Modelo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo> ListOf_Modelo_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Modelo entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Modelo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Modelo.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Modelo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.Modelo> ListOf_Modelo_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.Modelo entities = new Permaquim.Depositary.Business.Relations.Dispositivo.Modelo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.Modelo.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaMoneda that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMoneda> ListOf_PlantillaMoneda_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMoneda entities = new Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMoneda();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMoneda.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaMoneda that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMoneda> ListOf_PlantillaMoneda_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMoneda entities = new Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMoneda();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMoneda.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaMonedaDetalle that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMonedaDetalle> ListOf_PlantillaMonedaDetalle_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle entities = new Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaMonedaDetalle that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMonedaDetalle> ListOf_PlantillaMonedaDetalle_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle entities = new Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoConfiguracionDepositario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.TipoConfiguracionDepositario> ListOf_TipoConfiguracionDepositario_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoConfiguracionDepositario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.TipoConfiguracionDepositario> ListOf_TipoConfiguracionDepositario_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario entities = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.TipoConfiguracionDepositario.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContadora that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.TipoContadora> ListOf_TipoContadora_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContadora that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.TipoContadora> ListOf_TipoContadora_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora entities = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.TipoContadora.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoPlaca that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.TipoPlaca> ListOf_TipoPlaca_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoPlaca that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.TipoPlaca> ListOf_TipoPlaca_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca entities = new Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.TipoPlaca.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Esquema that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Estilo.Esquema> ListOf_Esquema_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Estilo.Esquema entities = new Permaquim.Depositary.Business.Relations.Estilo.Esquema();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Estilo.Esquema.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Esquema that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Estilo.Esquema> ListOf_Esquema_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Estilo.Esquema entities = new Permaquim.Depositary.Business.Relations.Estilo.Esquema();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Estilo.Esquema.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle entities = new Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalle that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Estilo.EsquemaDetalle> ListOf_EsquemaDetalle_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle entities = new Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Estilo.EsquemaDetalle.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoEsquemaDetalle that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Estilo.TipoEsquemaDetalle> ListOf_TipoEsquemaDetalle_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Estilo.TipoEsquemaDetalle entities = new Permaquim.Depositary.Business.Relations.Estilo.TipoEsquemaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Estilo.TipoEsquemaDetalle.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoEsquemaDetalle that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Estilo.TipoEsquemaDetalle> ListOf_TipoEsquemaDetalle_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Estilo.TipoEsquemaDetalle entities = new Permaquim.Depositary.Business.Relations.Estilo.TipoEsquemaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Estilo.TipoEsquemaDetalle.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ciudad that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Ciudad> ListOf_Ciudad_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Ciudad entities = new Permaquim.Depositary.Business.Relations.Geografia.Ciudad();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Ciudad.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ciudad that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Ciudad> ListOf_Ciudad_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Ciudad entities = new Permaquim.Depositary.Business.Relations.Geografia.Ciudad();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Ciudad.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CodigoPostal that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.CodigoPostal> ListOf_CodigoPostal_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal entities = new Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CodigoPostal that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.CodigoPostal> ListOf_CodigoPostal_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal entities = new Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.CodigoPostal.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Pais that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Pais> ListOf_Pais_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Pais entities = new Permaquim.Depositary.Business.Relations.Geografia.Pais();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Pais.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Pais that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Pais> ListOf_Pais_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Pais entities = new Permaquim.Depositary.Business.Relations.Geografia.Pais();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Pais.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Provincia that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Provincia> ListOf_Provincia_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Provincia entities = new Permaquim.Depositary.Business.Relations.Geografia.Provincia();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Provincia.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Provincia that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Provincia> ListOf_Provincia_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Provincia entities = new Permaquim.Depositary.Business.Relations.Geografia.Provincia();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Provincia.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Zona that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Zona> ListOf_Zona_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Zona entities = new Permaquim.Depositary.Business.Relations.Geografia.Zona();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Zona.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Zona that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Geografia.Zona> ListOf_Zona_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Geografia.Zona entities = new Permaquim.Depositary.Business.Relations.Geografia.Zona();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Geografia.Zona.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Impresion.Ticket> ListOf_Ticket_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Impresion.Ticket entities = new Permaquim.Depositary.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Impresion.Ticket.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Ticket that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Impresion.Ticket> ListOf_Ticket_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Impresion.Ticket entities = new Permaquim.Depositary.Business.Relations.Impresion.Ticket();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Impresion.Ticket.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoTicket that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Impresion.TipoTicket> ListOf_TipoTicket_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Impresion.TipoTicket entities = new Permaquim.Depositary.Business.Relations.Impresion.TipoTicket();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Impresion.TipoTicket.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoTicket that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Impresion.TipoTicket> ListOf_TipoTicket_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Impresion.TipoTicket entities = new Permaquim.Depositary.Business.Relations.Impresion.TipoTicket();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Impresion.TipoTicket.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CierreDiario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario> ListOf_CierreDiario_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.CierreDiario entities = new Permaquim.Depositary.Business.Relations.Operacion.CierreDiario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.CierreDiario.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of CierreDiario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.CierreDiario> ListOf_CierreDiario_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.CierreDiario entities = new Permaquim.Depositary.Business.Relations.Operacion.CierreDiario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.CierreDiario.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Contenedor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Contenedor> ListOf_Contenedor_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Contenedor entities = new Permaquim.Depositary.Business.Relations.Operacion.Contenedor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Contenedor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Contenedor> ListOf_Contenedor_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Contenedor entities = new Permaquim.Depositary.Business.Relations.Operacion.Contenedor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Contenedor.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContenedor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TipoContenedor> ListOf_TipoContenedor_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TipoContenedor entities = new Permaquim.Depositary.Business.Relations.Operacion.TipoContenedor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TipoContenedor.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoContenedor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TipoContenedor> ListOf_TipoContenedor_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TipoContenedor entities = new Permaquim.Depositary.Business.Relations.Operacion.TipoContenedor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TipoContenedor.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoEvento that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TipoEvento> ListOf_TipoEvento_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TipoEvento entities = new Permaquim.Depositary.Business.Relations.Operacion.TipoEvento();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TipoEvento.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoEvento that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TipoEvento> ListOf_TipoEvento_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TipoEvento entities = new Permaquim.Depositary.Business.Relations.Operacion.TipoEvento();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TipoEvento.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoTransaccion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TipoTransaccion> ListOf_TipoTransaccion_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TipoTransaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.TipoTransaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TipoTransaccion.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoTransaccion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TipoTransaccion> ListOf_TipoTransaccion_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TipoTransaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.TipoTransaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TipoTransaccion.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_UsuarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Turno> ListOf_Turno_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Turno entities = new Permaquim.Depositary.Business.Relations.Operacion.Turno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Turno.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Turno> ListOf_Turno_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Turno entities = new Permaquim.Depositary.Business.Relations.Operacion.Turno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Turno.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TurnoUsuario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TurnoUsuario> ListOf_TurnoUsuario_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TurnoUsuario entities = new Permaquim.Depositary.Business.Relations.Operacion.TurnoUsuario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TurnoUsuario.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TurnoUsuario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TurnoUsuario> ListOf_TurnoUsuario_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TurnoUsuario entities = new Permaquim.Depositary.Business.Relations.Operacion.TurnoUsuario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TurnoUsuario.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Lenguaje that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje> ListOf_Lenguaje_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Regionalizacion.Lenguaje entities = new Permaquim.Depositary.Business.Relations.Regionalizacion.Lenguaje();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Regionalizacion.Lenguaje.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Lenguaje that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Regionalizacion.Lenguaje> ListOf_Lenguaje_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Regionalizacion.Lenguaje entities = new Permaquim.Depositary.Business.Relations.Regionalizacion.Lenguaje();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Regionalizacion.Lenguaje.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of LenguajeItem that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Regionalizacion.LenguajeItem> ListOf_LenguajeItem_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Regionalizacion.LenguajeItem entities = new Permaquim.Depositary.Business.Relations.Regionalizacion.LenguajeItem();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Regionalizacion.LenguajeItem.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of LenguajeItem that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Regionalizacion.LenguajeItem> ListOf_LenguajeItem_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Regionalizacion.LenguajeItem entities = new Permaquim.Depositary.Business.Relations.Regionalizacion.LenguajeItem();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Regionalizacion.LenguajeItem.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Aplicacion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion> ListOf_Aplicacion_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion entities = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Aplicacion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Aplicacion> ListOf_Aplicacion_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion entities = new Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Aplicacion.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametro that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametro> ListOf_AplicacionParametro_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro entities = new Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametro that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametro> ListOf_AplicacionParametro_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro entities = new Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametro.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametroValor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametroValor> ListOf_AplicacionParametroValor_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor entities = new Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AplicacionParametroValor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.AplicacionParametroValor> ListOf_AplicacionParametroValor_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor entities = new Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.AplicacionParametroValor.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Funcion entities = new Permaquim.Depositary.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Funcion.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Funcion entities = new Permaquim.Depositary.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Funcion.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of IdentificadorUsuario that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.IdentificadorUsuario> ListOf_IdentificadorUsuario_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario entities = new Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of IdentificadorUsuario that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.IdentificadorUsuario> ListOf_IdentificadorUsuario_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario entities = new Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of IdentificadorUsuario that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.IdentificadorUsuario> ListOf_IdentificadorUsuario_UsuarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario entities = new Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.IdentificadorUsuario.ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Menu> ListOf_Menu_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Menu entities = new Permaquim.Depositary.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Menu.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Menu> ListOf_Menu_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Menu entities = new Permaquim.Depositary.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Menu.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Rol that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Rol> ListOf_Rol_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Rol entities = new Permaquim.Depositary.Business.Relations.Seguridad.Rol();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Rol.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Rol that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Rol> ListOf_Rol_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Rol entities = new Permaquim.Depositary.Business.Relations.Seguridad.Rol();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Rol.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion entities = new Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion entities = new Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoAplicacion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.TipoAplicacion> ListOf_TipoAplicacion_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.TipoAplicacion entities = new Permaquim.Depositary.Business.Relations.Seguridad.TipoAplicacion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.TipoAplicacion.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoAplicacion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.TipoAplicacion> ListOf_TipoAplicacion_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.TipoAplicacion entities = new Permaquim.Depositary.Business.Relations.Seguridad.TipoAplicacion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.TipoAplicacion.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoFuncion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.TipoFuncion> ListOf_TipoFuncion_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.TipoFuncion entities = new Permaquim.Depositary.Business.Relations.Seguridad.TipoFuncion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.TipoFuncion.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoFuncion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.TipoFuncion> ListOf_TipoFuncion_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.TipoFuncion entities = new Permaquim.Depositary.Business.Relations.Seguridad.TipoFuncion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.TipoFuncion.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoIdentificador that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.TipoIdentificador> ListOf_TipoIdentificador_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.TipoIdentificador entities = new Permaquim.Depositary.Business.Relations.Seguridad.TipoIdentificador();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.TipoIdentificador.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoIdentificador that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.TipoIdentificador> ListOf_TipoIdentificador_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.TipoIdentificador entities = new Permaquim.Depositary.Business.Relations.Seguridad.TipoIdentificador();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.TipoIdentificador.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoMenu that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.TipoMenu> ListOf_TipoMenu_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.TipoMenu entities = new Permaquim.Depositary.Business.Relations.Seguridad.TipoMenu();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.TipoMenu.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoMenu that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.TipoMenu> ListOf_TipoMenu_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.TipoMenu entities = new Permaquim.Depositary.Business.Relations.Seguridad.TipoMenu();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.TipoMenu.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol entities = new Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol entities = new Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioRol that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.UsuarioRol> ListOf_UsuarioRol_UsuarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol entities = new Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioSector that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.UsuarioSector> ListOf_UsuarioSector_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector entities = new Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioSector that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.UsuarioSector> ListOf_UsuarioSector_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector entities = new Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioSector that have this UsuarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.UsuarioSector> ListOf_UsuarioSector_UsuarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector entities = new Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.UsuarioSector.ColumnEnum.UsuarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AgendaTurno that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Turno.AgendaTurno> ListOf_AgendaTurno_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Turno.AgendaTurno entities = new Permaquim.Depositary.Business.Relations.Turno.AgendaTurno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Turno.AgendaTurno.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of AgendaTurno that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Turno.AgendaTurno> ListOf_AgendaTurno_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Turno.AgendaTurno entities = new Permaquim.Depositary.Business.Relations.Turno.AgendaTurno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Turno.AgendaTurno.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalleTurno that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Turno.EsquemaDetalleTurno> ListOf_EsquemaDetalleTurno_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno entities = new Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalleTurno that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Turno.EsquemaDetalleTurno> ListOf_EsquemaDetalleTurno_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno entities = new Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaTurno that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Turno.EsquemaTurno> ListOf_EsquemaTurno_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Turno.EsquemaTurno entities = new Permaquim.Depositary.Business.Relations.Turno.EsquemaTurno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Turno.EsquemaTurno.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of EsquemaTurno that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Turno.EsquemaTurno> ListOf_EsquemaTurno_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Turno.EsquemaTurno entities = new Permaquim.Depositary.Business.Relations.Turno.EsquemaTurno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Turno.EsquemaTurno.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.Denominacion entities = new Permaquim.Depositary.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.Denominacion.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.Denominacion entities = new Permaquim.Depositary.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.Denominacion.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Moneda that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.Moneda> ListOf_Moneda_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.Moneda entities = new Permaquim.Depositary.Business.Relations.Valor.Moneda();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.Moneda.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Moneda that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.Moneda> ListOf_Moneda_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.Moneda entities = new Permaquim.Depositary.Business.Relations.Valor.Moneda();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.Moneda.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of OrigenValor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.OrigenValor> ListOf_OrigenValor_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.OrigenValor entities = new Permaquim.Depositary.Business.Relations.Valor.OrigenValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.OrigenValor.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of OrigenValor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.OrigenValor> ListOf_OrigenValor_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.OrigenValor entities = new Permaquim.Depositary.Business.Relations.Valor.OrigenValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.OrigenValor.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor entities = new Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor entities = new Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Tipo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.Tipo> ListOf_Tipo_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.Tipo entities = new Permaquim.Depositary.Business.Relations.Valor.Tipo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.Tipo.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Tipo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.Tipo> ListOf_Tipo_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.Tipo entities = new Permaquim.Depositary.Business.Relations.Valor.Tipo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.Tipo.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Perfil that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Visualizacion.Perfil> ListOf_Perfil_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Visualizacion.Perfil entities = new Permaquim.Depositary.Business.Relations.Visualizacion.Perfil();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Perfil that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Visualizacion.Perfil> ListOf_Perfil_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Visualizacion.Perfil entities = new Permaquim.Depositary.Business.Relations.Visualizacion.Perfil();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilItem that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Visualizacion.PerfilItem> ListOf_PerfilItem_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Visualizacion.PerfilItem entities = new Permaquim.Depositary.Business.Relations.Visualizacion.PerfilItem();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Visualizacion.PerfilItem.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilItem that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Visualizacion.PerfilItem> ListOf_PerfilItem_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Visualizacion.PerfilItem entities = new Permaquim.Depositary.Business.Relations.Visualizacion.PerfilItem();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Visualizacion.PerfilItem.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilTipo that have this UsuarioModificacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Visualizacion.PerfilTipo> ListOf_PerfilTipo_UsuarioModificacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Visualizacion.PerfilTipo entities = new Permaquim.Depositary.Business.Relations.Visualizacion.PerfilTipo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Visualizacion.PerfilTipo.ColumnEnum.UsuarioModificacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilTipo that have this UsuarioCreacion value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Visualizacion.PerfilTipo> ListOf_PerfilTipo_UsuarioCreacion
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Visualizacion.PerfilTipo entities = new Permaquim.Depositary.Business.Relations.Visualizacion.PerfilTipo();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Visualizacion.PerfilTipo.ColumnEnum.UsuarioCreacion, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Usuario 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  UsuarioRol(Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId,Permaquim.Depositary.Entities.Relations.Seguridad.Rol RolId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("RolId","RolId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _RolId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Rol RolId
             {
                 get {
                     if (RolId_ == null || RolId_.Id != _RolId)
                         {
                             RolId = new Permaquim.Depositary.Business.Relations.Seguridad.Rol().Items(this._RolId).FirstOrDefault();
                         }
                     return RolId_;
                     }
                 set {RolId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Rol RolId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class UsuarioRol 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Seguridad {
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
                public  UsuarioSector(Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId,Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId
             {
                 get {
                     if (UsuarioId_ == null || UsuarioId_.Id != _UsuarioId)
                         {
                             UsuarioId = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioId).FirstOrDefault();
                         }
                     return UsuarioId_;
                     }
                 set {UsuarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioId_ = null;
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new Permaquim.Depositary.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class UsuarioSector 
} //namespace Permaquim.Depositary.Entities.Relations.Seguridad
		namespace Permaquim.Depositary.Entities.Relations.Sincronizacion {
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
} //namespace Permaquim.Depositary.Entities.Relations.Sincronizacion
		namespace Permaquim.Depositary.Entities.Relations.Sincronizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sincronizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Ejecucion","Ejecucion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Ejecucion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string DepositarioId = "DepositarioId";
					public const string FechaInicio = "FechaInicio";
					public const string FechaFin = "FechaFin";
					public const string Finalizada = "Finalizada";
					public const string EsPrimeraSincronizacion = "EsPrimeraSincronizacion";
				}
				public enum FieldEnum : int
                {
					Id,
					DepositarioId,
					FechaInicio,
					FechaFin,
					Finalizada,
					EsPrimeraSincronizacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Ejecucion()
                {
                }
                public  Ejecucion(Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId,DateTime FechaInicio,DateTime? FechaFin,Boolean Finalizada,Boolean EsPrimeraSincronizacion)
                {
                    this.Id = Id;
                    this.DepositarioId = DepositarioId;
                    this.FechaInicio = FechaInicio;
                    this.FechaFin = FechaFin;
                    this.Finalizada = Finalizada;
                    this.EsPrimeraSincronizacion = EsPrimeraSincronizacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("DepositarioId","DepositarioId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DepositarioId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Depositario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId
             {
                 get {
                     if (DepositarioId_ == null || DepositarioId_.Id != _DepositarioId)
                         {
                             DepositarioId = new Permaquim.Depositary.Business.Relations.Dispositivo.Depositario().Items(this._DepositarioId).FirstOrDefault();
                         }
                     return DepositarioId_;
                     }
                 set {DepositarioId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Dispositivo.Depositario DepositarioId_ = null;
             [DataItemAttributeFieldName("FechaInicio","FechaInicio")]
             public DateTime FechaInicio { get; set; }
             [DataItemAttributeFieldName("FechaFin","FechaFin")]
             public DateTime? FechaFin { get; set; }
             [DataItemAttributeFieldName("Finalizada","Finalizada")]
             public Boolean Finalizada { get; set; }
             [DataItemAttributeFieldName("EsPrimeraSincronizacion","EsPrimeraSincronizacion")]
             public Boolean EsPrimeraSincronizacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EntidadCabecera that have this EjecucionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Sincronizacion.EntidadCabecera> ListOf_EntidadCabecera_EjecucionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Sincronizacion.EntidadCabecera entities = new Permaquim.Depositary.Business.Relations.Sincronizacion.EntidadCabecera();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Sincronizacion.EntidadCabecera.ColumnEnum.EjecucionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Ejecucion 
} //namespace Permaquim.Depositary.Entities.Relations.Sincronizacion
		namespace Permaquim.Depositary.Entities.Relations.Sincronizacion {
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
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Entidad 
} //namespace Permaquim.Depositary.Entities.Relations.Sincronizacion
		namespace Permaquim.Depositary.Entities.Relations.Sincronizacion {
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
					public const string EjecucionId = "EjecucionId";
				}
				public enum FieldEnum : int
                {
					Id,
					EntidadId,
					Valor,
					Fechainicio,
					Fechafin,
					EjecucionId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EntidadCabecera()
                {
                }
                public  EntidadCabecera(Permaquim.Depositary.Entities.Relations.Customizador.Entidad EntidadId,String Valor,DateTime Fechainicio,DateTime? Fechafin,Permaquim.Depositary.Entities.Relations.Sincronizacion.Ejecucion EjecucionId)
                {
                    this.Id = Id;
                    this.EntidadId = EntidadId;
                    this.Valor = Valor;
                    this.Fechainicio = Fechainicio;
                    this.Fechafin = Fechafin;
                    this.EjecucionId = EjecucionId;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("EntidadId","EntidadId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EntidadId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Entidad")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Customizador.Entidad EntidadId
             {
                 get {
                     if (EntidadId_ == null || EntidadId_.Id != _EntidadId)
                         {
                             EntidadId = new Permaquim.Depositary.Business.Relations.Customizador.Entidad().Items(this._EntidadId).FirstOrDefault();
                         }
                     return EntidadId_;
                     }
                 set {EntidadId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Customizador.Entidad EntidadId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Fechainicio","Fechainicio")]
             public DateTime Fechainicio { get; set; }
             [DataItemAttributeFieldName("Fechafin","Fechafin")]
             public DateTime? Fechafin { get; set; }
             [DataItemAttributeFieldName("EjecucionId","EjecucionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EjecucionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Ejecucion")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Sincronizacion.Ejecucion EjecucionId
             {
                 get {
                     if (EjecucionId_ == null || EjecucionId_.Id != _EjecucionId)
                         {
                             EjecucionId = new Permaquim.Depositary.Business.Relations.Sincronizacion.Ejecucion().Items(this._EjecucionId).FirstOrDefault();
                         }
                     return EjecucionId_;
                     }
                 set {EjecucionId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Sincronizacion.Ejecucion EjecucionId_ = null;
				
			} //Class EntidadCabecera 
} //namespace Permaquim.Depositary.Entities.Relations.Sincronizacion
		namespace Permaquim.Depositary.Entities.Relations.Sincronizacion {
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
                public  EntidadDetalle(Int64 EntidadCabeceraId,DateTime FechaCreacion,Int64 OrigenId,Int64 DestinoId)
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
             public Int64 EntidadCabeceraId { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("OrigenId","OrigenId")]
             public Int64 OrigenId { get; set; }
             [DataItemAttributeFieldName("DestinoId","DestinoId")]
             public Int64 DestinoId { get; set; }
				
			} //Class EntidadDetalle 
} //namespace Permaquim.Depositary.Entities.Relations.Sincronizacion
		namespace Permaquim.Depositary.Entities.Relations.Turno {
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
                public  AgendaTurno(String Nombre,Permaquim.Depositary.Entities.Relations.Turno.EsquemaDetalleTurno EsquemaDetalleTurnoId,DateTime Fecha,Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId,Int32 Secuencia,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,Boolean Habilitado)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("EsquemaDetalleTurnoId","EsquemaDetalleTurnoId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _EsquemaDetalleTurnoId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EsquemaDetalleTurno")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Turno.EsquemaDetalleTurno EsquemaDetalleTurnoId
             {
                 get {
                     if (EsquemaDetalleTurnoId_ == null || EsquemaDetalleTurnoId_.Id != _EsquemaDetalleTurnoId)
                         {
                             EsquemaDetalleTurnoId = new Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno().Items(this._EsquemaDetalleTurnoId).FirstOrDefault();
                         }
                     return EsquemaDetalleTurnoId_;
                     }
                 set {EsquemaDetalleTurnoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Turno.EsquemaDetalleTurno EsquemaDetalleTurnoId_ = null;
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("SectorId","SectorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SectorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Sector")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId
             {
                 get {
                     if (SectorId_ == null || SectorId_.Id != _SectorId)
                         {
                             SectorId = new Permaquim.Depositary.Business.Relations.Directorio.Sector().Items(this._SectorId).FirstOrDefault();
                         }
                     return SectorId_;
                     }
                 set {SectorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Sector SectorId_ = null;
             [DataItemAttributeFieldName("Secuencia","Secuencia")]
             public Int32 Secuencia { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Turno that have this TurnoDepositarioId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Turno> ListOf_Turno_TurnoDepositarioId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Turno entities = new Permaquim.Depositary.Business.Relations.Operacion.Turno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Turno.ColumnEnum.TurnoDepositarioId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class AgendaTurno 
} //namespace Permaquim.Depositary.Entities.Relations.Turno
		namespace Permaquim.Depositary.Entities.Relations.Turno {
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
                public  EsquemaDetalleTurno(Permaquim.Depositary.Entities.Relations.Turno.EsquemaTurno EsquemaTurnoId,String Nombre,Int32 Secuencia,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Turno.EsquemaTurno EsquemaTurnoId
             {
                 get {
                     if (EsquemaTurnoId_ == null || EsquemaTurnoId_.Id != _EsquemaTurnoId)
                         {
                             EsquemaTurnoId = new Permaquim.Depositary.Business.Relations.Turno.EsquemaTurno().Items(this._EsquemaTurnoId).FirstOrDefault();
                         }
                     return EsquemaTurnoId_;
                     }
                 set {EsquemaTurnoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Turno.EsquemaTurno EsquemaTurnoId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of AgendaTurno that have this EsquemaDetalleTurnoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Turno.AgendaTurno> ListOf_AgendaTurno_EsquemaDetalleTurnoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Turno.AgendaTurno entities = new Permaquim.Depositary.Business.Relations.Turno.AgendaTurno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Turno.AgendaTurno.ColumnEnum.EsquemaDetalleTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class EsquemaDetalleTurno 
} //namespace Permaquim.Depositary.Entities.Relations.Turno
		namespace Permaquim.Depositary.Entities.Relations.Turno {
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
					public const string OperaSinTurno = "OperaSinTurno";
					public const string OperaDiasCorridos = "OperaDiasCorridos";
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
					OperaSinTurno,
					OperaDiasCorridos,
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
                public  EsquemaTurno(String Nombre,Boolean OperaSinTurno,Boolean OperaDiasCorridos,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.OperaSinTurno = OperaSinTurno;
                    this.OperaDiasCorridos = OperaDiasCorridos;
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
             [DataItemAttributeFieldName("OperaSinTurno","OperaSinTurno")]
             public Boolean OperaSinTurno { get; set; }
             [DataItemAttributeFieldName("OperaDiasCorridos","OperaDiasCorridos")]
             public Boolean OperaDiasCorridos { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of EsquemaDetalleTurno that have this EsquemaTurnoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Turno.EsquemaDetalleTurno> ListOf_EsquemaDetalleTurno_EsquemaTurnoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno entities = new Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Turno.EsquemaDetalleTurno.ColumnEnum.EsquemaTurnoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class EsquemaTurno 
} //namespace Permaquim.Depositary.Entities.Relations.Turno
		namespace Permaquim.Depositary.Entities.Relations.Valor {
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
					TipoValorId,
					MonedaId,
					Unidades,
					Imagen,
					CodigoCcTalk,
					Posicion,
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
                public Denominacion()
                {
                }
                public  Denominacion(String Nombre,Permaquim.Depositary.Entities.Relations.Valor.Tipo TipoValorId,Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId,Decimal Unidades,String Imagen,String CodigoCcTalk,Int32 Posicion,String CodigoExterno,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.TipoValorId = TipoValorId;
                    this.MonedaId = MonedaId;
                    this.Unidades = Unidades;
                    this.Imagen = Imagen;
                    this.CodigoCcTalk = CodigoCcTalk;
                    this.Posicion = Posicion;
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
             [DataItemAttributeFieldName("TipoValorId","TipoValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Tipo")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Valor.Tipo TipoValorId
             {
                 get {
                     if (TipoValorId_ == null || TipoValorId_.Id != _TipoValorId)
                         {
                             TipoValorId = new Permaquim.Depositary.Business.Relations.Valor.Tipo().Items(this._TipoValorId).FirstOrDefault();
                         }
                     return TipoValorId_;
                     }
                 set {TipoValorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Tipo TipoValorId_ = null;
             [DataItemAttributeFieldName("MonedaId","MonedaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MonedaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Moneda")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new Permaquim.Depositary.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("Unidades","Unidades")]
             public Decimal Unidades { get; set; }
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("CodigoCcTalk","CodigoCcTalk")]
             public String CodigoCcTalk { get; set; }
             [DataItemAttributeFieldName("Posicion","Posicion")]
             public Int32 Posicion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionDetalle that have this DenominacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TransaccionDetalle> ListOf_TransaccionDetalle_DenominacionId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TransaccionDetalle entities = new Permaquim.Depositary.Business.Relations.Operacion.TransaccionDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.DenominacionId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Denominacion 
} //namespace Permaquim.Depositary.Entities.Relations.Valor
		namespace Permaquim.Depositary.Entities.Relations.Valor {
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
					PaisId,
					Codigo,
					Simbolo,
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
                public Moneda()
                {
                }
                public  Moneda(String Nombre,Permaquim.Depositary.Entities.Relations.Geografia.Pais PaisId,String Codigo,String Simbolo,String CodigoExterno,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.PaisId = PaisId;
                    this.Codigo = Codigo;
                    this.Simbolo = Simbolo;
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
             [DataItemAttributeFieldName("PaisId","PaisId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PaisId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Pais")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Geografia.Pais PaisId
             {
                 get {
                     if (PaisId_ == null || PaisId_.Id != _PaisId)
                         {
                             PaisId = new Permaquim.Depositary.Business.Relations.Geografia.Pais().Items(this._PaisId).FirstOrDefault();
                         }
                     return PaisId_;
                     }
                 set {PaisId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Geografia.Pais PaisId_ = null;
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("Simbolo","Simbolo")]
             public String Simbolo { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TipoCuenta that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Banca.TipoCuenta> ListOf_TipoCuenta_MonedaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Banca.TipoCuenta entities = new Permaquim.Depositary.Business.Relations.Banca.TipoCuenta();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Banca.TipoCuenta.ColumnEnum.MonedaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaSucursal that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Directorio.RelacionMonedaSucursal> ListOf_RelacionMonedaSucursal_MonedaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal entities = new Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.MonedaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of DepositarioMoneda that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.DepositarioMoneda> ListOf_DepositarioMoneda_MonedaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda entities = new Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.DepositarioMoneda.ColumnEnum.MonedaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PlantillaMonedaDetalle that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Dispositivo.PlantillaMonedaDetalle> ListOf_PlantillaMonedaDetalle_MonedaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle entities = new Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Dispositivo.PlantillaMonedaDetalle.ColumnEnum.MonedaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_MonedaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.MonedaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_MonedaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.Denominacion entities = new Permaquim.Depositary.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.Denominacion.ColumnEnum.MonedaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this MonedaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_MonedaId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor entities = new Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.MonedaId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Moneda 
} //namespace Permaquim.Depositary.Entities.Relations.Valor
		namespace Permaquim.Depositary.Entities.Relations.Valor {
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
					public const string CodigoExterno = "CodigoExterno";
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
					FechaModificacion,
					CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public OrigenValor()
                {
                }
                public  OrigenValor(String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,String CodigoExterno)
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
                    this.CodigoExterno = CodigoExterno;
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
             public Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId
             {
                 get {
                     if (EmpresaId_ == null || EmpresaId_.Id != _EmpresaId)
                         {
                             EmpresaId = new Permaquim.Depositary.Business.Relations.Directorio.Empresa().Items(this._EmpresaId).FirstOrDefault();
                         }
                     return EmpresaId_;
                     }
                 set {EmpresaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Directorio.Empresa EmpresaId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Transaccion that have this OrigenValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.Transaccion> ListOf_Transaccion_OrigenValorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.Transaccion entities = new Permaquim.Depositary.Business.Relations.Operacion.Transaccion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.Transaccion.ColumnEnum.OrigenValorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class OrigenValor 
} //namespace Permaquim.Depositary.Entities.Relations.Valor
		namespace Permaquim.Depositary.Entities.Relations.Valor {
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
                public  RelacionMonedaTipoValor(Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId,Permaquim.Depositary.Entities.Relations.Valor.Tipo TipoValorId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId
             {
                 get {
                     if (MonedaId_ == null || MonedaId_.Id != _MonedaId)
                         {
                             MonedaId = new Permaquim.Depositary.Business.Relations.Valor.Moneda().Items(this._MonedaId).FirstOrDefault();
                         }
                     return MonedaId_;
                     }
                 set {MonedaId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Moneda MonedaId_ = null;
             [DataItemAttributeFieldName("TipoValorId","TipoValorId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _TipoValorId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Tipo")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Valor.Tipo TipoValorId
             {
                 get {
                     if (TipoValorId_ == null || TipoValorId_.Id != _TipoValorId)
                         {
                             TipoValorId = new Permaquim.Depositary.Business.Relations.Valor.Tipo().Items(this._TipoValorId).FirstOrDefault();
                         }
                     return TipoValorId_;
                     }
                 set {TipoValorId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Valor.Tipo TipoValorId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionSobreDetalle that have this RelacionMonedaTipoValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Operacion.TransaccionSobreDetalle> ListOf_TransaccionSobreDetalle_RelacionMonedaTipoValorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobreDetalle entities = new Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobreDetalle();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Operacion.TransaccionSobreDetalle.ColumnEnum.RelacionMonedaTipoValorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class RelacionMonedaTipoValor 
} //namespace Permaquim.Depositary.Entities.Relations.Valor
		namespace Permaquim.Depositary.Entities.Relations.Valor {
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
					public const string CodigoExterno = "CodigoExterno";
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
					FechaModificacion,
					CodigoExterno
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Tipo()
                {
                }
                public  Tipo(String Nombre,String Descripcion,String Imagen,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion,String CodigoExterno)
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
                    this.CodigoExterno = CodigoExterno;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Display)] //Is Display Default
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
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Denominacion that have this TipoValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.Denominacion> ListOf_Denominacion_TipoValorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.Denominacion entities = new Permaquim.Depositary.Business.Relations.Valor.Denominacion();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.Denominacion.ColumnEnum.TipoValorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RelacionMonedaTipoValor that have this TipoValorId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Valor.RelacionMonedaTipoValor> ListOf_RelacionMonedaTipoValor_TipoValorId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor entities = new Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Valor.RelacionMonedaTipoValor.ColumnEnum.TipoValorId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Tipo 
} //namespace Permaquim.Depositary.Entities.Relations.Valor
		namespace Permaquim.Depositary.Entities.Relations.Visualizacion {
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
                public  Perfil(String Nombre,String Descripcion,Permaquim.Depositary.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId
             {
                 get {
                     if (PerfilTipoId_ == null || PerfilTipoId_.Id != _PerfilTipoId)
                         {
                             PerfilTipoId = new Permaquim.Depositary.Business.Relations.Visualizacion.PerfilTipo().Items(this._PerfilTipoId).FirstOrDefault();
                         }
                     return PerfilTipoId_;
                     }
                 set {PerfilTipoId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Usuario that have this PerfilId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Seguridad.Usuario> ListOf_Usuario_PerfilId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Seguridad.Usuario entities = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.PerfilId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of PerfilItem that have this PerfilId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Visualizacion.PerfilItem> ListOf_PerfilItem_PerfilId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Visualizacion.PerfilItem entities = new Permaquim.Depositary.Business.Relations.Visualizacion.PerfilItem();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Visualizacion.PerfilItem.ColumnEnum.PerfilId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class Perfil 
} //namespace Permaquim.Depositary.Entities.Relations.Visualizacion
		namespace Permaquim.Depositary.Entities.Relations.Visualizacion {
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
                public  PerfilItem(Permaquim.Depositary.Entities.Relations.Visualizacion.Perfil PerfilId,Int64 IdTablaReferencia,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             public Permaquim.Depositary.Entities.Relations.Visualizacion.Perfil PerfilId
             {
                 get {
                     if (PerfilId_ == null || PerfilId_.Id != _PerfilId)
                         {
                             PerfilId = new Permaquim.Depositary.Business.Relations.Visualizacion.Perfil().Items(this._PerfilId).FirstOrDefault();
                         }
                     return PerfilId_;
                     }
                 set {PerfilId_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Visualizacion.Perfil PerfilId_ = null;
             [DataItemAttributeFieldName("IdTablaReferencia","IdTablaReferencia")]
             public Int64 IdTablaReferencia { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
				
			} //Class PerfilItem 
} //namespace Permaquim.Depositary.Entities.Relations.Visualizacion
		namespace Permaquim.Depositary.Entities.Relations.Visualizacion {
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
                public  PerfilTipo(String Nombre,String Descripcion,Boolean EsAdministrador,Boolean Habilitado,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion,DateTime FechaCreacion,Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion,DateTime? FechaModificacion)
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
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioCreacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion
             {
                 get {
                     if (UsuarioCreacion_ == null || UsuarioCreacion_.Id != _UsuarioCreacion)
                         {
                             UsuarioCreacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioCreacion).FirstOrDefault();
                         }
                     return UsuarioCreacion_;
                     }
                 set {UsuarioCreacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioCreacion_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _UsuarioModificacion { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion
             {
                 get {
                     if (UsuarioModificacion_ == null || UsuarioModificacion_.Id != _UsuarioModificacion)
                         {
                             UsuarioModificacion = new Permaquim.Depositary.Business.Relations.Seguridad.Usuario().Items(this._UsuarioModificacion).FirstOrDefault();
                         }
                     return UsuarioModificacion_;
                     }
                 set {UsuarioModificacion_  =  value;}
             }
             static Permaquim.Depositary.Entities.Relations.Seguridad.Usuario UsuarioModificacion_ = null;
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime? FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Perfil that have this PerfilTipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Permaquim.Depositary.Entities.Relations.Visualizacion.Perfil> ListOf_Perfil_PerfilTipoId
                {
                     get {
                             Permaquim.Depositary.Business.Relations.Visualizacion.Perfil entities = new Permaquim.Depositary.Business.Relations.Visualizacion.Perfil();
                             entities.Where.Add(Permaquim.Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.PerfilTipoId, Permaquim.Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
             public override int GetHashCode() => (Nombre == null ? string.Empty : Nombre).GetHashCode();
             public override string ToString() => Nombre;
				
			} //Class PerfilTipo 
} //namespace Permaquim.Depositary.Entities.Relations.Visualizacion
