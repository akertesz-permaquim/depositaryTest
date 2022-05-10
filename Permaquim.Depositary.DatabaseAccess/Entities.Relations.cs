using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace Depositary.Entities.Relations.Auditoria {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Auditoria")]  // Database Schema Name
			[DataItemAttributeObjectName("Log","Log")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Log : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Fecha = "Fecha";
					public const string Tipo = "Tipo";
					public const string Descripcion = "Descripcion";
					public const string Detalle = "Detalle";
					public const string OrigenAplicacion = "OrigenAplicacion";
					public const string OrigenMetodo = "OrigenMetodo";
					public const string UsuarioId = "UsuarioId";
				}
				public enum FieldEnum : int
                {
					Id,
					Fecha,
					Tipo,
					Descripcion,
					Detalle,
					OrigenAplicacion,
					OrigenMetodo,
					UsuarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Log()
                {
                }
                public  Log(DateTime Fecha,String Tipo,String Descripcion,String Detalle,String OrigenAplicacion,String OrigenMetodo,Int64 UsuarioId)
                {
                    this.Id = Id;
                    this.Fecha = Fecha;
                    this.Tipo = Tipo;
                    this.Descripcion = Descripcion;
                    this.Detalle = Detalle;
                    this.OrigenAplicacion = OrigenAplicacion;
                    this.OrigenMetodo = OrigenMetodo;
                    this.UsuarioId = UsuarioId;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("Tipo","Tipo")]
             public String Tipo { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Detalle","Detalle")]
             public String Detalle { get; set; }
             [DataItemAttributeFieldName("OrigenAplicacion","OrigenAplicacion")]
             public String OrigenAplicacion { get; set; }
             [DataItemAttributeFieldName("OrigenMetodo","OrigenMetodo")]
             public String OrigenMetodo { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
				
			} //Class Log 
} //namespace Depositary.Entities.Relations.Auditoria
		namespace Depositary.Entities.Relations.Auditoria {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Auditoria")]  // Database Schema Name
			[DataItemAttributeObjectName("LogAnomalia","LogAnomalia")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class LogAnomalia : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Fecha = "Fecha";
					public const string Tipo = "Tipo";
					public const string Descripcion = "Descripcion";
					public const string Detalle = "Detalle";
					public const string UsuarioId = "UsuarioId";
				}
				public enum FieldEnum : int
                {
					Id,
					Fecha,
					Tipo,
					Descripcion,
					Detalle,
					UsuarioId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public LogAnomalia()
                {
                }
                public  LogAnomalia(DateTime Fecha,String Tipo,String Descripcion,String Detalle,Int64 UsuarioId)
                {
                    this.Id = Id;
                    this.Fecha = Fecha;
                    this.Tipo = Tipo;
                    this.Descripcion = Descripcion;
                    this.Detalle = Detalle;
                    this.UsuarioId = UsuarioId;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
             [DataItemAttributeFieldName("Tipo","Tipo")]
             public String Tipo { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Detalle","Detalle")]
             public String Detalle { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
				
			} //Class LogAnomalia 
} //namespace Depositary.Entities.Relations.Auditoria
		namespace Depositary.Entities.Relations.Biometria {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  HuellaDactilar(Int64 UsuarioId,Byte Dedo,String Huella,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.UsuarioId = UsuarioId;
                    this.Dedo = Dedo;
                    this.Huella = Huella;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class HuellaDactilar 
} //namespace Depositary.Entities.Relations.Biometria
		namespace Depositary.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("Banco","Banco")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Banco : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string PaisId = "PaisId";
					public const string Codigo = "Codigo";
					public const string Denominacion = "Denominacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					PaisId,
					Codigo,
					Denominacion,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Banco()
                {
                }
                public  Banco(Int64 PaisId,String Codigo,String Denominacion,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.PaisId = PaisId;
                    this.Codigo = Codigo;
                    this.Denominacion = Denominacion;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("PaisId","PaisId")]
             public Int64 PaisId { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("Denominacion","Denominacion")]
             public String Denominacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
				
			} //Class Banco 
} //namespace Depositary.Entities.Relations.Directorio
		namespace Depositary.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("Compania","Compania")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Compania : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string GrupoId = "GrupoId";
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string CodigoExterno = "CodigoExterno";
					public const string Address = "Address";
					public const string CodigoPostalId = "CodigoPostalId";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					GrupoId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Address,
					CodigoPostalId,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Compania()
                {
                }
                public  Compania(String Nombre,String Descripcion,Depositary.Entities.Relations.Directorio.Grupo GrupoId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,String Address,Int64 CodigoPostalId,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.GrupoId = GrupoId;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.CodigoExterno = CodigoExterno;
                    this.Address = Address;
                    this.CodigoPostalId = CodigoPostalId;
                    this.Habilitado = Habilitado;
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
             public Depositary.Entities.Relations.Directorio.Grupo GrupoId
             {
                 get {
                     if (GrupoId_ == null || GrupoId_.Id != _GrupoId)
                         {
                             GrupoId = new Depositary.Business.Relations.Directorio.Grupo().Items(this._GrupoId).FirstOrDefault();
                         }
                     return GrupoId_;
                     }
                 set {GrupoId_  =  value;}
             }
             static Depositary.Entities.Relations.Directorio.Grupo GrupoId_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Address","Address")]
             public String Address { get; set; }
             [DataItemAttributeFieldName("CodigoPostalId","CodigoPostalId")]
             public Int64 CodigoPostalId { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of SucursalCompania that have this CompaniaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Directorio.SucursalCompania> ListOf_SucursalCompania_CompaniaId
                {
                     get {
                             Depositary.Business.Relations.Directorio.SucursalCompania entities = new Depositary.Business.Relations.Directorio.SucursalCompania();
                             entities.Where.Add(Depositary.Business.Relations.Directorio.SucursalCompania.ColumnEnum.CompaniaId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Compania 
} //namespace Depositary.Entities.Relations.Directorio
		namespace Depositary.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("CuentaBancaria","CuentaBancaria")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class CuentaBancaria : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string SucursalBancariaId = "SucursalBancariaId";
					public const string Codigo = "Codigo";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					SucursalBancariaId,
					Codigo,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public CuentaBancaria()
                {
                }
                public  CuentaBancaria(Int64 TipoId,Int64 SucursalBancariaId,String Codigo,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.SucursalBancariaId = SucursalBancariaId;
                    this.Codigo = Codigo;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("SucursalBancariaId","SucursalBancariaId")]
             public Int64 SucursalBancariaId { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class CuentaBancaria 
} //namespace Depositary.Entities.Relations.Directorio
		namespace Depositary.Entities.Relations.Directorio {
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
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Grupo()
                {
                }
                public  Grupo(String Nombre,String Descripcion,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Compania that have this GrupoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Directorio.Compania> ListOf_Compania_GrupoId
                {
                     get {
                             Depositary.Business.Relations.Directorio.Compania entities = new Depositary.Business.Relations.Directorio.Compania();
                             entities.Where.Add(Depositary.Business.Relations.Directorio.Compania.ColumnEnum.GrupoId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Grupo 
} //namespace Depositary.Entities.Relations.Directorio
		namespace Depositary.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("SucursalBancaria","SucursalBancaria")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class SucursalBancaria : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string BancoId = "BancoId";
					public const string Codigo = "Codigo";
					public const string Direccion = "Direccion";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					BancoId,
					Codigo,
					Direccion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public SucursalBancaria()
                {
                }
                public  SucursalBancaria(Int64 BancoId,String Codigo,String Direccion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.BancoId = BancoId;
                    this.Codigo = Codigo;
                    this.Direccion = Direccion;
                    this.EstadoLogico = EstadoLogico;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("BancoId","BancoId")]
             public Int64 BancoId { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("Direccion","Direccion")]
             public String Direccion { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class SucursalBancaria 
} //namespace Depositary.Entities.Relations.Directorio
		namespace Depositary.Entities.Relations.Directorio {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Directorio")]  // Database Schema Name
			[DataItemAttributeObjectName("SucursalCompania","SucursalCompania")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class SucursalCompania : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string CompaniaId = "CompaniaId";
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string CodigoExterno = "CodigoExterno";
					public const string Direccion = "Direccion";
					public const string CodigoPostalId = "CodigoPostalId";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					CompaniaId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Direccion,
					CodigoPostalId,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public SucursalCompania()
                {
                }
                public  SucursalCompania(String Nombre,String Descripcion,Depositary.Entities.Relations.Directorio.Compania CompaniaId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,String Direccion,Depositary.Entities.Relations.Sig.CodigoPostal CodigoPostalId,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.CompaniaId = CompaniaId;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.CodigoExterno = CodigoExterno;
                    this.Direccion = Direccion;
                    this.CodigoPostalId = CodigoPostalId;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("CompaniaId","CompaniaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CompaniaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Compania")]// Object name in Database
             public Depositary.Entities.Relations.Directorio.Compania CompaniaId
             {
                 get {
                     if (CompaniaId_ == null || CompaniaId_.Id != _CompaniaId)
                         {
                             CompaniaId = new Depositary.Business.Relations.Directorio.Compania().Items(this._CompaniaId).FirstOrDefault();
                         }
                     return CompaniaId_;
                     }
                 set {CompaniaId_  =  value;}
             }
             static Depositary.Entities.Relations.Directorio.Compania CompaniaId_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Direccion","Direccion")]
             public String Direccion { get; set; }
             [DataItemAttributeFieldName("CodigoPostalId","CodigoPostalId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _CodigoPostalId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("CodigoPostal")]// Object name in Database
             public Depositary.Entities.Relations.Sig.CodigoPostal CodigoPostalId
             {
                 get {
                     if (CodigoPostalId_ == null || CodigoPostalId_.Id != _CodigoPostalId)
                         {
                             CodigoPostalId = new Depositary.Business.Relations.Sig.CodigoPostal().Items(this._CodigoPostalId).FirstOrDefault();
                         }
                     return CodigoPostalId_;
                     }
                 set {CodigoPostalId_  =  value;}
             }
             static Depositary.Entities.Relations.Sig.CodigoPostal CodigoPostalId_ = null;
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Maquina that have this SucursalCompaniaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Dispositivo.Maquina> ListOf_Maquina_SucursalCompaniaId
                {
                     get {
                             Depositary.Business.Relations.Dispositivo.Maquina entities = new Depositary.Business.Relations.Dispositivo.Maquina();
                             entities.Where.Add(Depositary.Business.Relations.Dispositivo.Maquina.ColumnEnum.SucursalCompaniaId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class SucursalCompania 
} //namespace Depositary.Entities.Relations.Directorio
		namespace Depositary.Entities.Relations.Dispositivo {
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
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					ContadoraId,
					Nombre,
					Descripcion,
					Comando,
					TiempoDetencion,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ComandoContadora()
                {
                }
                public  ComandoContadora(Depositary.Entities.Relations.Dispositivo.Contadora ContadoraId,String Nombre,String Descripcion,String Comando,Int64 TiempoDetencion,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.ContadoraId = ContadoraId;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Comando = Comando;
                    this.TiempoDetencion = TiempoDetencion;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("ContadoraId","ContadoraId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _ContadoraId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Contadora")]// Object name in Database
             public Depositary.Entities.Relations.Dispositivo.Contadora ContadoraId
             {
                 get {
                     if (ContadoraId_ == null || ContadoraId_.Id != _ContadoraId)
                         {
                             ContadoraId = new Depositary.Business.Relations.Dispositivo.Contadora().Items(this._ContadoraId).FirstOrDefault();
                         }
                     return ContadoraId_;
                     }
                 set {ContadoraId_  =  value;}
             }
             static Depositary.Entities.Relations.Dispositivo.Contadora ContadoraId_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Comando","Comando")]
             public String Comando { get; set; }
             [DataItemAttributeFieldName("TiempoDetencion","TiempoDetencion")]
             public Int64 TiempoDetencion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
				
			} //Class ComandoContadora 
} //namespace Depositary.Entities.Relations.Dispositivo
		namespace Depositary.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("ConfiguracionMaquina","ConfiguracionMaquina")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class ConfiguracionMaquina : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string MaquinaId = "MaquinaId";
					public const string Valor = "Valor";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					MaquinaId,
					Valor,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ConfiguracionMaquina()
                {
                }
                public  ConfiguracionMaquina(Depositary.Entities.Relations.Dispositivo.TipoConfiguracionMaquina TipoId,Depositary.Entities.Relations.Dispositivo.Maquina MaquinaId,String Valor,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.MaquinaId = MaquinaId;
                    this.Valor = Valor;
                    this.EstadoLogico = EstadoLogico;
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
             [PropertyAttributeForeignKeyObjectName("TipoConfiguracionMaquina")]// Object name in Database
             public Depositary.Entities.Relations.Dispositivo.TipoConfiguracionMaquina TipoId
             {
                 get {
                     if (TipoId_ == null || TipoId_.Id != _TipoId)
                         {
                             TipoId = new Depositary.Business.Relations.Dispositivo.TipoConfiguracionMaquina().Items(this._TipoId).FirstOrDefault();
                         }
                     return TipoId_;
                     }
                 set {TipoId_  =  value;}
             }
             static Depositary.Entities.Relations.Dispositivo.TipoConfiguracionMaquina TipoId_ = null;
             [DataItemAttributeFieldName("MaquinaId","MaquinaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _MaquinaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Maquina")]// Object name in Database
             public Depositary.Entities.Relations.Dispositivo.Maquina MaquinaId
             {
                 get {
                     if (MaquinaId_ == null || MaquinaId_.Id != _MaquinaId)
                         {
                             MaquinaId = new Depositary.Business.Relations.Dispositivo.Maquina().Items(this._MaquinaId).FirstOrDefault();
                         }
                     return MaquinaId_;
                     }
                 set {MaquinaId_  =  value;}
             }
             static Depositary.Entities.Relations.Dispositivo.Maquina MaquinaId_ = null;
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class ConfiguracionMaquina 
} //namespace Depositary.Entities.Relations.Dispositivo
		namespace Depositary.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("Contadora","Contadora")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Contadora : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Contadora()
                {
                }
                public  Contadora(String Nombre,String Descripcion,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
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
                 /// <summary>
                 ///  Represents the child collection of ComandoContadora that have this ContadoraId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Dispositivo.ComandoContadora> ListOf_ComandoContadora_ContadoraId
                {
                     get {
                             Depositary.Business.Relations.Dispositivo.ComandoContadora entities = new Depositary.Business.Relations.Dispositivo.ComandoContadora();
                             entities.Where.Add(Depositary.Business.Relations.Dispositivo.ComandoContadora.ColumnEnum.ContadoraId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Contadora 
} //namespace Depositary.Entities.Relations.Dispositivo
		namespace Depositary.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("Estado","Estado")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Estado : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Estado()
                {
                }
                public  Estado(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class Estado 
} //namespace Depositary.Entities.Relations.Dispositivo
		namespace Depositary.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("Maquina","Maquina")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Maquina : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string SucursalCompaniaId = "SucursalCompaniaId";
					public const string NumeroSerie = "NumeroSerie";
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string CodigoExterno = "CodigoExterno";
					public const string MaquinaTipoId = "MaquinaTipoId";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					SucursalCompaniaId,
					NumeroSerie,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					MaquinaTipoId,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Maquina()
                {
                }
                public  Maquina(String Nombre,String Descripcion,Depositary.Entities.Relations.Directorio.SucursalCompania SucursalCompaniaId,String NumeroSerie,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Int64 MaquinaTipoId,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.SucursalCompaniaId = SucursalCompaniaId;
                    this.NumeroSerie = NumeroSerie;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.CodigoExterno = CodigoExterno;
                    this.MaquinaTipoId = MaquinaTipoId;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("SucursalCompaniaId","SucursalCompaniaId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _SucursalCompaniaId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("SucursalCompania")]// Object name in Database
             public Depositary.Entities.Relations.Directorio.SucursalCompania SucursalCompaniaId
             {
                 get {
                     if (SucursalCompaniaId_ == null || SucursalCompaniaId_.Id != _SucursalCompaniaId)
                         {
                             SucursalCompaniaId = new Depositary.Business.Relations.Directorio.SucursalCompania().Items(this._SucursalCompaniaId).FirstOrDefault();
                         }
                     return SucursalCompaniaId_;
                     }
                 set {SucursalCompaniaId_  =  value;}
             }
             static Depositary.Entities.Relations.Directorio.SucursalCompania SucursalCompaniaId_ = null;
             [DataItemAttributeFieldName("NumeroSerie","NumeroSerie")]
             public String NumeroSerie { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("MaquinaTipoId","MaquinaTipoId")]
             public Int64 MaquinaTipoId { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionMaquina that have this MaquinaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Dispositivo.ConfiguracionMaquina> ListOf_ConfiguracionMaquina_MaquinaId
                {
                     get {
                             Depositary.Business.Relations.Dispositivo.ConfiguracionMaquina entities = new Depositary.Business.Relations.Dispositivo.ConfiguracionMaquina();
                             entities.Where.Add(Depositary.Business.Relations.Dispositivo.ConfiguracionMaquina.ColumnEnum.MaquinaId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Maquina 
} //namespace Depositary.Entities.Relations.Dispositivo
		namespace Depositary.Entities.Relations.Dispositivo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Dispositivo")]  // Database Schema Name
			[DataItemAttributeObjectName("TipoConfiguracionMaquina","TipoConfiguracionMaquina")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class TipoConfiguracionMaquina : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TipoConfiguracionMaquina()
                {
                }
                public  TipoConfiguracionMaquina(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of ConfiguracionMaquina that have this TipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Dispositivo.ConfiguracionMaquina> ListOf_ConfiguracionMaquina_TipoId
                {
                     get {
                             Depositary.Business.Relations.Dispositivo.ConfiguracionMaquina entities = new Depositary.Business.Relations.Dispositivo.ConfiguracionMaquina();
                             entities.Where.Add(Depositary.Business.Relations.Dispositivo.ConfiguracionMaquina.ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoConfiguracionMaquina 
} //namespace Depositary.Entities.Relations.Dispositivo
		namespace Depositary.Entities.Relations.Operacion {
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
					public const string Descripcion = "Descripcion";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					TipoId,
					Descripcion,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Evento()
                {
                }
                public  Evento(Int64 TipoId,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class Evento 
} //namespace Depositary.Entities.Relations.Operacion
		namespace Depositary.Entities.Relations.Operacion {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  TipoEvento(String Nombre,String Descripcion,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class TipoEvento 
} //namespace Depositary.Entities.Relations.Operacion
		namespace Depositary.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Transaccion","Transaccion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Transaccion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string MaquinaId = "MaquinaId";
					public const string UsuarioId = "UsuarioId";
					public const string ValorDeclarado = "ValorDeclarado";
					public const string ValorCertificado = "ValorCertificado";
					public const string FechaInicio = "FechaInicio";
					public const string FechaFin = "FechaFin";
				}
				public enum FieldEnum : int
                {
					Id,
					MaquinaId,
					UsuarioId,
					ValorDeclarado,
					ValorCertificado,
					FechaInicio,
					FechaFin
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Transaccion()
                {
                }
                public  Transaccion(Int64 MaquinaId,Int64 UsuarioId,Double ValorDeclarado,Double ValorCertificado,DateTime FechaInicio,DateTime FechaFin)
                {
                    this.Id = Id;
                    this.MaquinaId = MaquinaId;
                    this.UsuarioId = UsuarioId;
                    this.ValorDeclarado = ValorDeclarado;
                    this.ValorCertificado = ValorCertificado;
                    this.FechaInicio = FechaInicio;
                    this.FechaFin = FechaFin;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("MaquinaId","MaquinaId")]
             public Int64 MaquinaId { get; set; }
             [DataItemAttributeFieldName("UsuarioId","UsuarioId")]
             public Int64 UsuarioId { get; set; }
             [DataItemAttributeFieldName("ValorDeclarado","ValorDeclarado")]
             public Double ValorDeclarado { get; set; }
             [DataItemAttributeFieldName("ValorCertificado","ValorCertificado")]
             public Double ValorCertificado { get; set; }
             [DataItemAttributeFieldName("FechaInicio","FechaInicio")]
             public DateTime FechaInicio { get; set; }
             [DataItemAttributeFieldName("FechaFin","FechaFin")]
             public DateTime FechaFin { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionDetalle that have this TransaccionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Operacion.TransaccionDetalle> ListOf_TransaccionDetalle_TransaccionId
                {
                     get {
                             Depositary.Business.Relations.Operacion.TransaccionDetalle entities = new Depositary.Business.Relations.Operacion.TransaccionDetalle();
                             entities.Where.Add(Depositary.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Transaccion 
} //namespace Depositary.Entities.Relations.Operacion
		namespace Depositary.Entities.Relations.Operacion {
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
					public const string CantidadCertificada = "CantidadCertificada";
					public const string CantidadDeclarada = "CantidadDeclarada";
					public const string Fecha = "Fecha";
				}
				public enum FieldEnum : int
                {
					Id,
					TransaccionId,
					DenominacionId,
					CantidadCertificada,
					CantidadDeclarada,
					Fecha
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public TransaccionDetalle()
                {
                }
                public  TransaccionDetalle(Depositary.Entities.Relations.Operacion.Transaccion TransaccionId,Depositary.Entities.Relations.Valor.Denominacion DenominacionId,Int64 CantidadCertificada,Int64 CantidadDeclarada,DateTime Fecha)
                {
                    this.Id = Id;
                    this.TransaccionId = TransaccionId;
                    this.DenominacionId = DenominacionId;
                    this.CantidadCertificada = CantidadCertificada;
                    this.CantidadDeclarada = CantidadDeclarada;
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
             public Depositary.Entities.Relations.Operacion.Transaccion TransaccionId
             {
                 get {
                     if (TransaccionId_ == null || TransaccionId_.Id != _TransaccionId)
                         {
                             TransaccionId = new Depositary.Business.Relations.Operacion.Transaccion().Items(this._TransaccionId).FirstOrDefault();
                         }
                     return TransaccionId_;
                     }
                 set {TransaccionId_  =  value;}
             }
             static Depositary.Entities.Relations.Operacion.Transaccion TransaccionId_ = null;
             [DataItemAttributeFieldName("DenominacionId","DenominacionId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DenominacionId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Denominacion")]// Object name in Database
             public Depositary.Entities.Relations.Valor.Denominacion DenominacionId
             {
                 get {
                     if (DenominacionId_ == null || DenominacionId_.Id != _DenominacionId)
                         {
                             DenominacionId = new Depositary.Business.Relations.Valor.Denominacion().Items(this._DenominacionId).FirstOrDefault();
                         }
                     return DenominacionId_;
                     }
                 set {DenominacionId_  =  value;}
             }
             static Depositary.Entities.Relations.Valor.Denominacion DenominacionId_ = null;
             [DataItemAttributeFieldName("CantidadCertificada","CantidadCertificada")]
             public Int64 CantidadCertificada { get; set; }
             [DataItemAttributeFieldName("CantidadDeclarada","CantidadDeclarada")]
             public Int64 CantidadDeclarada { get; set; }
             [DataItemAttributeFieldName("Fecha","Fecha")]
             public DateTime Fecha { get; set; }
				
			} //Class TransaccionDetalle 
} //namespace Depositary.Entities.Relations.Operacion
		namespace Depositary.Entities.Relations.Operacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Operacion")]  // Database Schema Name
			[DataItemAttributeObjectName("Turno","Turno")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Turno : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Desde = "Desde";
					public const string Hasta = "Hasta";
					public const string EstadoLogico = "EstadoLogico";
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
					Desde,
					Hasta,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Turno()
                {
                }
                public  Turno(String Nombre,String Descripcion,TimeSpan Desde,TimeSpan Hasta,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Desde = Desde;
                    this.Hasta = Hasta;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("Desde","Desde")]
             public TimeSpan Desde { get; set; }
             [DataItemAttributeFieldName("Hasta","Hasta")]
             public TimeSpan Hasta { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class Turno 
} //namespace Depositary.Entities.Relations.Operacion
		namespace Depositary.Entities.Relations.Operacion {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  TurnoUsuario(Int64 UsuarioId,Int64 TurnoId,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.UsuarioId = UsuarioId;
                    this.TurnoId = TurnoId;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class TurnoUsuario 
} //namespace Depositary.Entities.Relations.Operacion
		namespace Depositary.Entities.Relations.Regionalizacion {
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
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Lenguaje()
                {
                }
                public  Lenguaje(String Nombre,String Descripcion,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Habilitado = Habilitado;
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
                 /// <summary>
                 ///  Represents the child collection of LenguajeItem that have this LenguajeId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Regionalizacion.LenguajeItem> ListOf_LenguajeItem_LenguajeId
                {
                     get {
                             Depositary.Business.Relations.Regionalizacion.LenguajeItem entities = new Depositary.Business.Relations.Regionalizacion.LenguajeItem();
                             entities.Where.Add(Depositary.Business.Relations.Regionalizacion.LenguajeItem.ColumnEnum.LenguajeId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Lenguaje 
} //namespace Depositary.Entities.Relations.Regionalizacion
		namespace Depositary.Entities.Relations.Regionalizacion {
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
				}
				public enum FieldEnum : int
                {
					Id,
					LenguajeId,
					Clave,
					Texto,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public LenguajeItem()
                {
                }
                public  LenguajeItem(Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId,String Clave,String Texto,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.LenguajeId = LenguajeId;
                    this.Clave = Clave;
                    this.Texto = Texto;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("LenguajeId","LenguajeId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _LenguajeId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Lenguaje")]// Object name in Database
             public Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId
             {
                 get {
                     if (LenguajeId_ == null || LenguajeId_.Id != _LenguajeId)
                         {
                             LenguajeId = new Depositary.Business.Relations.Regionalizacion.Lenguaje().Items(this._LenguajeId).FirstOrDefault();
                         }
                     return LenguajeId_;
                     }
                 set {LenguajeId_  =  value;}
             }
             static Depositary.Entities.Relations.Regionalizacion.Lenguaje LenguajeId_ = null;
             [DataItemAttributeFieldName("Clave","Clave")]
             public String Clave { get; set; }
             [DataItemAttributeFieldName("Texto","Texto")]
             public String Texto { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
				
			} //Class LenguajeItem 
} //namespace Depositary.Entities.Relations.Regionalizacion
		namespace Depositary.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Aplicacion","Aplicacion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Aplicacion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Tipo_Id = "Tipo_Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Tipo_Id,
					Nombre,
					Descripcion,
					EstadoLogico,
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
                public  Aplicacion(Depositary.Entities.Relations.Seguridad.TipoAplicacion Tipo_Id,String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Tipo_Id = Tipo_Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Tipo_Id","Tipo_Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _Tipo_Id { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoAplicacion")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.TipoAplicacion Tipo_Id
             {
                 get {
                     if (Tipo_Id_ == null || Tipo_Id_.Id != _Tipo_Id)
                         {
                             Tipo_Id = new Depositary.Business.Relations.Seguridad.TipoAplicacion().Items(this._Tipo_Id).FirstOrDefault();
                         }
                     return Tipo_Id_;
                     }
                 set {Tipo_Id_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.TipoAplicacion Tipo_Id_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this Aplicacion_Id value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_Aplicacion_Id
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Funcion entities = new Depositary.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Funcion.ColumnEnum.Aplicacion_Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Aplicacion 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("EstadoLogico","EstadoLogico")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class EstadoLogico : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
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
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public EstadoLogico()
                {
                }
                public  EstadoLogico(String Nombre,String Descripcion,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int16 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of HuellaDactilar that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Biometria.HuellaDactilar> ListOf_HuellaDactilar_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Biometria.HuellaDactilar entities = new Depositary.Business.Relations.Biometria.HuellaDactilar();
                             entities.Where.Add(Depositary.Business.Relations.Biometria.HuellaDactilar.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Aplicacion that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Aplicacion> ListOf_Aplicacion_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Aplicacion entities = new Depositary.Business.Relations.Seguridad.Aplicacion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Aplicacion.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Funcion entities = new Depositary.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Funcion.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Menu> ListOf_Menu_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Menu entities = new Depositary.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Menu.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Rol that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Rol> ListOf_Rol_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Rol entities = new Depositary.Business.Relations.Seguridad.Rol();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Rol.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Seguridad.RolFuncion entities = new Depositary.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoAplicacion that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.TipoAplicacion> ListOf_TipoAplicacion_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Seguridad.TipoAplicacion entities = new Depositary.Business.Relations.Seguridad.TipoAplicacion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.TipoAplicacion.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoFuncion that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.TipoFuncion> ListOf_TipoFuncion_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Seguridad.TipoFuncion entities = new Depositary.Business.Relations.Seguridad.TipoFuncion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.TipoFuncion.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of TipoMenu that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.TipoMenu> ListOf_TipoMenu_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Seguridad.TipoMenu entities = new Depositary.Business.Relations.Seguridad.TipoMenu();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.TipoMenu.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of Usuario that have this EstadoLogico value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Usuario> ListOf_Usuario_EstadoLogico
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Usuario entities = new Depositary.Business.Relations.Seguridad.Usuario();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Usuario.ColumnEnum.EstadoLogico, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class EstadoLogico 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Funcion","Funcion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Funcion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Aplicacion_Id = "Aplicacion_Id";
					public const string Tipo_Id = "Tipo_Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Referencia = "Referencia";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Aplicacion_Id,
					Tipo_Id,
					Nombre,
					Descripcion,
					Referencia,
					EstadoLogico,
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
                public  Funcion(Depositary.Entities.Relations.Seguridad.Aplicacion Aplicacion_Id,Depositary.Entities.Relations.Seguridad.TipoFuncion Tipo_Id,String Nombre,String Descripcion,String Referencia,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Aplicacion_Id = Aplicacion_Id;
                    this.Tipo_Id = Tipo_Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Referencia = Referencia;
                    this.EstadoLogico = EstadoLogico;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Aplicacion_Id","Aplicacion_Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _Aplicacion_Id { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Aplicacion")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.Aplicacion Aplicacion_Id
             {
                 get {
                     if (Aplicacion_Id_ == null || Aplicacion_Id_.Id != _Aplicacion_Id)
                         {
                             Aplicacion_Id = new Depositary.Business.Relations.Seguridad.Aplicacion().Items(this._Aplicacion_Id).FirstOrDefault();
                         }
                     return Aplicacion_Id_;
                     }
                 set {Aplicacion_Id_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.Aplicacion Aplicacion_Id_ = null;
             [DataItemAttributeFieldName("Tipo_Id","Tipo_Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _Tipo_Id { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoFuncion")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.TipoFuncion Tipo_Id
             {
                 get {
                     if (Tipo_Id_ == null || Tipo_Id_.Id != _Tipo_Id)
                         {
                             Tipo_Id = new Depositary.Business.Relations.Seguridad.TipoFuncion().Items(this._Tipo_Id).FirstOrDefault();
                         }
                     return Tipo_Id_;
                     }
                 set {Tipo_Id_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.TipoFuncion Tipo_Id_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Referencia","Referencia")]
             public String Referencia { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this Funcion_Id value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Menu> ListOf_Menu_Funcion_Id
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Menu entities = new Depositary.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Menu.ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this Funcion_Id value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_Funcion_Id
                {
                     get {
                             Depositary.Business.Relations.Seguridad.RolFuncion entities = new Depositary.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
                 /// <summary>
                 ///  Represents the child collection of UsuarioFuncion that have this Funcion_Id value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.UsuarioFuncion> ListOf_UsuarioFuncion_Funcion_Id
                {
                     get {
                             Depositary.Business.Relations.Seguridad.UsuarioFuncion entities = new Depositary.Business.Relations.Seguridad.UsuarioFuncion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.UsuarioFuncion.ColumnEnum.Funcion_Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Funcion 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Identificador","Identificador")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Identificador : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string TipoId = "TipoId";
					public const string UsuarioId = "UsuarioId";
					public const string Valor = "Valor";
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Identificador()
                {
                }
                public  Identificador(Int64 TipoId,Int64 UsuarioId,String Valor,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.TipoId = TipoId;
                    this.UsuarioId = UsuarioId;
                    this.Valor = Valor;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class Identificador 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Menu","Menu")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Menu : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Tipo_Id = "Tipo_Id";
					public const string Nombre = "Nombre";
					public const string Descripcion = "Descripcion";
					public const string Funcion_Id = "Funcion_Id";
					public const string Imagen = "Imagen";
					public const string DependeDe = "DependeDe";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Tipo_Id,
					Nombre,
					Descripcion,
					Funcion_Id,
					Imagen,
					DependeDe,
					EstadoLogico,
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
                public  Menu(Depositary.Entities.Relations.Seguridad.TipoMenu Tipo_Id,String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id,String Imagen,Depositary.Entities.Relations.Seguridad.Menu DependeDe,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Tipo_Id = Tipo_Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Funcion_Id = Funcion_Id;
                    this.Imagen = Imagen;
                    this.DependeDe = DependeDe;
                    this.EstadoLogico = EstadoLogico;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Tipo_Id","Tipo_Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _Tipo_Id { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("TipoMenu")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.TipoMenu Tipo_Id
             {
                 get {
                     if (Tipo_Id_ == null || Tipo_Id_.Id != _Tipo_Id)
                         {
                             Tipo_Id = new Depositary.Business.Relations.Seguridad.TipoMenu().Items(this._Tipo_Id).FirstOrDefault();
                         }
                     return Tipo_Id_;
                     }
                 set {Tipo_Id_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.TipoMenu Tipo_Id_ = null;
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("Funcion_Id","Funcion_Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _Funcion_Id { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Funcion")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id
             {
                 get {
                     if (Funcion_Id_ == null || Funcion_Id_.Id != _Funcion_Id)
                         {
                             Funcion_Id = new Depositary.Business.Relations.Seguridad.Funcion().Items(this._Funcion_Id).FirstOrDefault();
                         }
                     return Funcion_Id_;
                     }
                 set {Funcion_Id_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id_ = null;
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public String Imagen { get; set; }
             [DataItemAttributeFieldName("DependeDe","DependeDe")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DependeDe { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Menu")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.Menu DependeDe
             {
                 get {
                     if (DependeDe_ == null || DependeDe_.Id != _DependeDe)
                         {
                             DependeDe = new Depositary.Business.Relations.Seguridad.Menu().Items(this._DependeDe).FirstOrDefault();
                         }
                     return DependeDe_;
                     }
                 set {DependeDe_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.Menu DependeDe_ = null;
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class Menu 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  Rol(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.Rol DependeDe,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.DependeDe = DependeDe;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("DependeDe","DependeDe")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _DependeDe { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.Rol DependeDe
             {
                 get {
                     if (DependeDe_ == null || DependeDe_.Id != _DependeDe)
                         {
                             DependeDe = new Depositary.Business.Relations.Seguridad.Rol().Items(this._DependeDe).FirstOrDefault();
                         }
                     return DependeDe_;
                     }
                 set {DependeDe_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.Rol DependeDe_ = null;
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of RolFuncion that have this Rol_Id value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.RolFuncion> ListOf_RolFuncion_Rol_Id
                {
                     get {
                             Depositary.Business.Relations.Seguridad.RolFuncion entities = new Depositary.Business.Relations.Seguridad.RolFuncion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.RolFuncion.ColumnEnum.Rol_Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Rol 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("RolFuncion","RolFuncion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class RolFuncion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Funcion_Id = "Funcion_Id";
					public const string Rol_Id = "Rol_Id";
					public const string Descripcion = "Descripcion";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Funcion_Id,
					Rol_Id,
					Descripcion,
					EstadoLogico,
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
                public  RolFuncion(Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id,Depositary.Entities.Relations.Seguridad.Rol Rol_Id,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Funcion_Id = Funcion_Id;
                    this.Rol_Id = Rol_Id;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int16 Id { get; set; }
             [DataItemAttributeFieldName("Funcion_Id","Funcion_Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _Funcion_Id { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Funcion")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id
             {
                 get {
                     if (Funcion_Id_ == null || Funcion_Id_.Id != _Funcion_Id)
                         {
                             Funcion_Id = new Depositary.Business.Relations.Seguridad.Funcion().Items(this._Funcion_Id).FirstOrDefault();
                         }
                     return Funcion_Id_;
                     }
                 set {Funcion_Id_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id_ = null;
             [DataItemAttributeFieldName("Rol_Id","Rol_Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _Rol_Id { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Rol")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.Rol Rol_Id
             {
                 get {
                     if (Rol_Id_ == null || Rol_Id_.Id != _Rol_Id)
                         {
                             Rol_Id = new Depositary.Business.Relations.Seguridad.Rol().Items(this._Rol_Id).FirstOrDefault();
                         }
                     return Rol_Id_;
                     }
                 set {Rol_Id_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.Rol Rol_Id_ = null;
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class RolFuncion 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  TipoAplicacion(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Aplicacion that have this Tipo_Id value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Aplicacion> ListOf_Aplicacion_Tipo_Id
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Aplicacion entities = new Depositary.Business.Relations.Seguridad.Aplicacion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Aplicacion.ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoAplicacion 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  TipoFuncion(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Funcion that have this Tipo_Id value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Funcion> ListOf_Funcion_Tipo_Id
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Funcion entities = new Depositary.Business.Relations.Seguridad.Funcion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Funcion.ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoFuncion 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  TipoIdentificador(String Nombre,String Descripcion,String Mascara,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Mascara = Mascara;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class TipoIdentificador 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  TipoMenu(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Menu that have this Tipo_Id value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.Menu> ListOf_Menu_Tipo_Id
                {
                     get {
                             Depositary.Business.Relations.Seguridad.Menu entities = new Depositary.Business.Relations.Seguridad.Menu();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.Menu.ColumnEnum.Tipo_Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class TipoMenu 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("Usuario","Usuario")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Usuario : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
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
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
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
					EstadoLogico,
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
                public  Usuario(String Nombre,String Apellido,String Legajo,String Mail,DateTime FechaIngreso,String NickName,String Password,String Token,String Avatar,DateTime FechaUltimoLogin,Boolean DebeCambiarPassword,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
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
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of UsuarioFuncion that have this Usuario_Id value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Seguridad.UsuarioFuncion> ListOf_UsuarioFuncion_Usuario_Id
                {
                     get {
                             Depositary.Business.Relations.Seguridad.UsuarioFuncion entities = new Depositary.Business.Relations.Seguridad.UsuarioFuncion();
                             entities.Where.Add(Depositary.Business.Relations.Seguridad.UsuarioFuncion.ColumnEnum.Usuario_Id, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Usuario 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Seguridad {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Seguridad")]  // Database Schema Name
			[DataItemAttributeObjectName("UsuarioFuncion","UsuarioFuncion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class UsuarioFuncion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Usuario_Id = "Usuario_Id";
					public const string Funcion_Id = "Funcion_Id";
					public const string FechaDesde = "FechaDesde";
					public const string FechaHasta = "FechaHasta";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Usuario_Id,
					Funcion_Id,
					FechaDesde,
					FechaHasta,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public UsuarioFuncion()
                {
                }
                public  UsuarioFuncion(Depositary.Entities.Relations.Seguridad.Usuario Usuario_Id,Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id,DateTime FechaDesde,DateTime FechaHasta,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Usuario_Id = Usuario_Id;
                    this.Funcion_Id = Funcion_Id;
                    this.FechaDesde = FechaDesde;
                    this.FechaHasta = FechaHasta;
                    this.EstadoLogico = EstadoLogico;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Usuario_Id","Usuario_Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _Usuario_Id { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Usuario")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.Usuario Usuario_Id
             {
                 get {
                     if (Usuario_Id_ == null || Usuario_Id_.Id != _Usuario_Id)
                         {
                             Usuario_Id = new Depositary.Business.Relations.Seguridad.Usuario().Items(this._Usuario_Id).FirstOrDefault();
                         }
                     return Usuario_Id_;
                     }
                 set {Usuario_Id_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.Usuario Usuario_Id_ = null;
             [DataItemAttributeFieldName("Funcion_Id","Funcion_Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _Funcion_Id { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Funcion")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id
             {
                 get {
                     if (Funcion_Id_ == null || Funcion_Id_.Id != _Funcion_Id)
                         {
                             Funcion_Id = new Depositary.Business.Relations.Seguridad.Funcion().Items(this._Funcion_Id).FirstOrDefault();
                         }
                     return Funcion_Id_;
                     }
                 set {Funcion_Id_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.Funcion Funcion_Id_ = null;
             [DataItemAttributeFieldName("FechaDesde","FechaDesde")]
             public DateTime FechaDesde { get; set; }
             [DataItemAttributeFieldName("FechaHasta","FechaHasta")]
             public DateTime FechaHasta { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class UsuarioFuncion 
} //namespace Depositary.Entities.Relations.Seguridad
		namespace Depositary.Entities.Relations.Sig {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sig")]  // Database Schema Name
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
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					ProvinciaId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Ciudad()
                {
                }
                public  Ciudad(String Nombre,String Descripcion,Depositary.Entities.Relations.Sig.Provincia ProvinciaId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.ProvinciaId = ProvinciaId;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
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
             public Depositary.Entities.Relations.Sig.Provincia ProvinciaId
             {
                 get {
                     if (ProvinciaId_ == null || ProvinciaId_.Id != _ProvinciaId)
                         {
                             ProvinciaId = new Depositary.Business.Relations.Sig.Provincia().Items(this._ProvinciaId).FirstOrDefault();
                         }
                     return ProvinciaId_;
                     }
                 set {ProvinciaId_  =  value;}
             }
             static Depositary.Entities.Relations.Sig.Provincia ProvinciaId_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
				
			} //Class Ciudad 
} //namespace Depositary.Entities.Relations.Sig
		namespace Depositary.Entities.Relations.Sig {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sig")]  // Database Schema Name
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
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					CiudadId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public CodigoPostal()
                {
                }
                public  CodigoPostal(String Nombre,String Descripcion,Int64 CiudadId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.CiudadId = CiudadId;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Nombre","Nombre")]
             public String Nombre { get; set; }
             [DataItemAttributeFieldName("Descripcion","Descripcion")]
             public String Descripcion { get; set; }
             [DataItemAttributeFieldName("CiudadId","CiudadId")]
             public Int64 CiudadId { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of SucursalCompania that have this CodigoPostalId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Directorio.SucursalCompania> ListOf_SucursalCompania_CodigoPostalId
                {
                     get {
                             Depositary.Business.Relations.Directorio.SucursalCompania entities = new Depositary.Business.Relations.Directorio.SucursalCompania();
                             entities.Where.Add(Depositary.Business.Relations.Directorio.SucursalCompania.ColumnEnum.CodigoPostalId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class CodigoPostal 
} //namespace Depositary.Entities.Relations.Sig
		namespace Depositary.Entities.Relations.Sig {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sig")]  // Database Schema Name
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
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					Codigo,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Pais()
                {
                }
                public  Pais(String Nombre,String Descripcion,String Codigo,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.Codigo = Codigo;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
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
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Provincia that have this PaisId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Sig.Provincia> ListOf_Provincia_PaisId
                {
                     get {
                             Depositary.Business.Relations.Sig.Provincia entities = new Depositary.Business.Relations.Sig.Provincia();
                             entities.Where.Add(Depositary.Business.Relations.Sig.Provincia.ColumnEnum.PaisId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Pais 
} //namespace Depositary.Entities.Relations.Sig
		namespace Depositary.Entities.Relations.Sig {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sig")]  // Database Schema Name
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
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string CodigoExterno = "CodigoExterno";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					PaisId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					CodigoExterno,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Provincia()
                {
                }
                public  Provincia(String Nombre,String Descripcion,Depositary.Entities.Relations.Sig.Pais PaisId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,String CodigoExterno,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.PaisId = PaisId;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.CodigoExterno = CodigoExterno;
                    this.Habilitado = Habilitado;
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
             public Depositary.Entities.Relations.Sig.Pais PaisId
             {
                 get {
                     if (PaisId_ == null || PaisId_.Id != _PaisId)
                         {
                             PaisId = new Depositary.Business.Relations.Sig.Pais().Items(this._PaisId).FirstOrDefault();
                         }
                     return PaisId_;
                     }
                 set {PaisId_  =  value;}
             }
             static Depositary.Entities.Relations.Sig.Pais PaisId_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("CodigoExterno","CodigoExterno")]
             public String CodigoExterno { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of Ciudad that have this ProvinciaId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Sig.Ciudad> ListOf_Ciudad_ProvinciaId
                {
                     get {
                             Depositary.Business.Relations.Sig.Ciudad entities = new Depositary.Business.Relations.Sig.Ciudad();
                             entities.Where.Add(Depositary.Business.Relations.Sig.Ciudad.ColumnEnum.ProvinciaId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Provincia 
} //namespace Depositary.Entities.Relations.Sig
		namespace Depositary.Entities.Relations.Sincronizacion {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  Configuracion(Int64 EntidadId,Int64 Segundos,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.EntidadId = EntidadId;
                    this.Segundos = Segundos;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class Configuracion 
} //namespace Depositary.Entities.Relations.Sincronizacion
		namespace Depositary.Entities.Relations.Sincronizacion {
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
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					EstadoLogico,
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
                public  Entidad(String Nombre,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class Entidad 
} //namespace Depositary.Entities.Relations.Sincronizacion
		namespace Depositary.Entities.Relations.Sincronizacion {
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
                public  EntidadCabecera(Int64 EntidadId,String Valor,DateTime Fechainicio,DateTime Fechafin)
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
             public Int64 EntidadId { get; set; }
             [DataItemAttributeFieldName("Valor","Valor")]
             public String Valor { get; set; }
             [DataItemAttributeFieldName("Fechainicio","Fechainicio")]
             public DateTime Fechainicio { get; set; }
             [DataItemAttributeFieldName("Fechafin","Fechafin")]
             public DateTime Fechafin { get; set; }
				
			} //Class EntidadCabecera 
} //namespace Depositary.Entities.Relations.Sincronizacion
		namespace Depositary.Entities.Relations.Sincronizacion {
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
				
			} //Class EntidadDetalle 
} //namespace Depositary.Entities.Relations.Sincronizacion
		namespace Depositary.Entities.Relations.Valor {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Valor")]  // Database Schema Name
			[DataItemAttributeObjectName("Denominacion","Denominacion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Denominacion : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string ValorId = "ValorId";
					public const string Unidades = "Unidades";
					public const string Imagen = "Imagen";
					public const string CodigoCcTalk = "CodigoCcTalk";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					ValorId,
					Unidades,
					Imagen,
					CodigoCcTalk,
					EstadoLogico,
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
                public  Denominacion(Int64 ValorId,Decimal Unidades,Byte[] Imagen,Int64 CodigoCcTalk,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.ValorId = ValorId;
                    this.Unidades = Unidades;
                    this.Imagen = Imagen;
                    this.CodigoCcTalk = CodigoCcTalk;
                    this.EstadoLogico = EstadoLogico;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("ValorId","ValorId")]
             public Int64 ValorId { get; set; }
             [DataItemAttributeFieldName("Unidades","Unidades")]
             public Decimal Unidades { get; set; }
             [DataItemAttributeFieldName("Imagen","Imagen")]
             public Byte[] Imagen { get; set; }
             [DataItemAttributeFieldName("CodigoCcTalk","CodigoCcTalk")]
             public Int64 CodigoCcTalk { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
                 /// <summary>
                 ///  Represents the child collection of TransaccionDetalle that have this DenominacionId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Operacion.TransaccionDetalle> ListOf_TransaccionDetalle_DenominacionId
                {
                     get {
                             Depositary.Business.Relations.Operacion.TransaccionDetalle entities = new Depositary.Business.Relations.Operacion.TransaccionDetalle();
                             entities.Where.Add(Depositary.Business.Relations.Operacion.TransaccionDetalle.ColumnEnum.DenominacionId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Denominacion 
} //namespace Depositary.Entities.Relations.Valor
		namespace Depositary.Entities.Relations.Valor {
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
					public const string EstadoLogico = "EstadoLogico";
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
					EstadoLogico,
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
                public  Tipo(String Nombre,String Descripcion,Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EstadoLogico = EstadoLogico;
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
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int16 _EstadoLogico { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("EstadoLogico")]// Object name in Database
             public Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico
             {
                 get {
                     if (EstadoLogico_ == null || EstadoLogico_.Id != _EstadoLogico)
                         {
                             EstadoLogico = new Depositary.Business.Relations.Seguridad.EstadoLogico().Items(this._EstadoLogico).FirstOrDefault();
                         }
                     return EstadoLogico_;
                     }
                 set {EstadoLogico_  =  value;}
             }
             static Depositary.Entities.Relations.Seguridad.EstadoLogico EstadoLogico_ = null;
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class Tipo 
} //namespace Depositary.Entities.Relations.Valor
		namespace Depositary.Entities.Relations.Valor {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Valor")]  // Database Schema Name
			[DataItemAttributeObjectName("Valor","Valor")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Table)] // Table, View,StoredProcedure,Function
			public class Valor : IRelationsDataITem
			{
				        
				public class ColumnNames
				{
					public const string Id = "Id";
					public const string Tipo = "Tipo";
					public const string PaisId = "PaisId";
					public const string Codigo = "Codigo";
					public const string EstadoLogico = "EstadoLogico";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string FechaCreacion = "FechaCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string FechaModificacion = "FechaModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					Tipo,
					PaisId,
					Codigo,
					EstadoLogico,
					UsuarioCreacion,
					FechaCreacion,
					UsuarioModificacion,
					FechaModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Valor()
                {
                }
                public  Valor(Int64 Tipo,Int64 PaisId,String Codigo,Int16 EstadoLogico,Int64 UsuarioCreacion,DateTime FechaCreacion,Int64 UsuarioModificacion,DateTime FechaModificacion)
                {
                    this.Id = Id;
                    this.Tipo = Tipo;
                    this.PaisId = PaisId;
                    this.Codigo = Codigo;
                    this.EstadoLogico = EstadoLogico;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.FechaCreacion = FechaCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.FechaModificacion = FechaModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("Tipo","Tipo")]
             public Int64 Tipo { get; set; }
             [DataItemAttributeFieldName("PaisId","PaisId")]
             public Int64 PaisId { get; set; }
             [DataItemAttributeFieldName("Codigo","Codigo")]
             public String Codigo { get; set; }
             [DataItemAttributeFieldName("EstadoLogico","EstadoLogico")]
             public Int16 EstadoLogico { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
				
			} //Class Valor 
} //namespace Depositary.Entities.Relations.Valor
		namespace Depositary.Entities.Relations.Visualizacion {
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
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
					public const string Habilitado = "Habilitado";
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					PerfilTipoId,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Perfil()
                {
                }
                public  Perfil(String Nombre,String Descripcion,Depositary.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.PerfilTipoId = PerfilTipoId;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                    this.Habilitado = Habilitado;
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
             public Depositary.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId
             {
                 get {
                     if (PerfilTipoId_ == null || PerfilTipoId_.Id != _PerfilTipoId)
                         {
                             PerfilTipoId = new Depositary.Business.Relations.Visualizacion.PerfilTipo().Items(this._PerfilTipoId).FirstOrDefault();
                         }
                     return PerfilTipoId_;
                     }
                 set {PerfilTipoId_  =  value;}
             }
             static Depositary.Entities.Relations.Visualizacion.PerfilTipo PerfilTipoId_ = null;
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
                 /// <summary>
                 ///  Represents the child collection of PerfilItem that have this PerfilId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Visualizacion.PerfilItem> ListOf_PerfilItem_PerfilId
                {
                     get {
                             Depositary.Business.Relations.Visualizacion.PerfilItem entities = new Depositary.Business.Relations.Visualizacion.PerfilItem();
                             entities.Where.Add(Depositary.Business.Relations.Visualizacion.PerfilItem.ColumnEnum.PerfilId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class Perfil 
} //namespace Depositary.Entities.Relations.Visualizacion
		namespace Depositary.Entities.Relations.Visualizacion {
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
					public const string FechaCreacion = "FechaCreacion";
					public const string FechaModificacion = "FechaModificacion";
					public const string UsuarioCreacion = "UsuarioCreacion";
					public const string UsuarioModificacion = "UsuarioModificacion";
				}
				public enum FieldEnum : int
                {
					Id,
					PerfilId,
					IdTablaReferencia,
					Habilitado,
					FechaCreacion,
					FechaModificacion,
					UsuarioCreacion,
					UsuarioModificacion
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public PerfilItem()
                {
                }
                public  PerfilItem(Int64 Id,Depositary.Entities.Relations.Visualizacion.Perfil PerfilId,Int64 IdTablaReferencia,Boolean Habilitado,DateTime FechaCreacion,DateTime FechaModificacion,Int64 UsuarioCreacion,Int64 UsuarioModificacion)
                {
                    this.Id = Id;
                    this.PerfilId = PerfilId;
                    this.IdTablaReferencia = IdTablaReferencia;
                    this.Habilitado = Habilitado;
                    this.FechaCreacion = FechaCreacion;
                    this.FechaModificacion = FechaModificacion;
                    this.UsuarioCreacion = UsuarioCreacion;
                    this.UsuarioModificacion = UsuarioModificacion;
                }
             [DataItemAttributeFieldName("Id","Id")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Pk)] //Is Primary Key
             public Int64 Id { get; set; }
             [DataItemAttributeFieldName("PerfilId","PerfilId")]
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
             internal Int64 _PerfilId { get; set; }
             [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Fk)] //Is Foreign Key
             [PropertyAttributeForeignKeyObjectName("Perfil")]// Object name in Database
             public Depositary.Entities.Relations.Visualizacion.Perfil PerfilId
             {
                 get {
                     if (PerfilId_ == null || PerfilId_.Id != _PerfilId)
                         {
                             PerfilId = new Depositary.Business.Relations.Visualizacion.Perfil().Items(this._PerfilId).FirstOrDefault();
                         }
                     return PerfilId_;
                     }
                 set {PerfilId_  =  value;}
             }
             static Depositary.Entities.Relations.Visualizacion.Perfil PerfilId_ = null;
             [DataItemAttributeFieldName("IdTablaReferencia","IdTablaReferencia")]
             public Int64 IdTablaReferencia { get; set; }
             [DataItemAttributeFieldName("Habilitado","Habilitado")]
             public Boolean Habilitado { get; set; }
             [DataItemAttributeFieldName("FechaCreacion","FechaCreacion")]
             public DateTime FechaCreacion { get; set; }
             [DataItemAttributeFieldName("FechaModificacion","FechaModificacion")]
             public DateTime FechaModificacion { get; set; }
             [DataItemAttributeFieldName("UsuarioCreacion","UsuarioCreacion")]
             public Int64 UsuarioCreacion { get; set; }
             [DataItemAttributeFieldName("UsuarioModificacion","UsuarioModificacion")]
             public Int64 UsuarioModificacion { get; set; }
				
			} //Class PerfilItem 
} //namespace Depositary.Entities.Relations.Visualizacion
		namespace Depositary.Entities.Relations.Visualizacion {
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
				}
				public enum FieldEnum : int
                {
					Id,
					Nombre,
					Descripcion,
					EsAdministrador,
					Habilitado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public PerfilTipo()
                {
                }
                public  PerfilTipo(String Nombre,String Descripcion,Boolean EsAdministrador,Boolean Habilitado)
                {
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Descripcion = Descripcion;
                    this.EsAdministrador = EsAdministrador;
                    this.Habilitado = Habilitado;
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
                 /// <summary>
                 ///  Represents the child collection of Perfil that have this PerfilTipoId value.
                 /// </summary>
                 [PropertyAttribute(PropertyAttribute.PropertyAttributeEnum.Exclude)] //Exclude
                 public List<Depositary.Entities.Relations.Visualizacion.Perfil> ListOf_Perfil_PerfilTipoId
                {
                     get {
                             Depositary.Business.Relations.Visualizacion.Perfil entities = new Depositary.Business.Relations.Visualizacion.Perfil();
                             entities.Where.Add(Depositary.Business.Relations.Visualizacion.Perfil.ColumnEnum.PerfilTipoId, Depositary.sqlEnum.OperandEnum.Equal, Id);
                             return entities.Items();
                         }
                }
				
			} //Class PerfilTipo 
} //namespace Depositary.Entities.Relations.Visualizacion
