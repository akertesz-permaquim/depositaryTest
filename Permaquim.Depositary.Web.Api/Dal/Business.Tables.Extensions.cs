    #region Configuracion

	namespace DepositaryWebApi.Business.Tables.Aplicacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Configuracion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Aplicacion.Configuracion Add(Entities.Tables.Aplicacion.Configuracion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Aplicacion.Configuracion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Aplicacion.Configuracion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Aplicacion.Configuracion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Aplicacion.Configuracion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Aplicacion.Configuracion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Aplicacion.Configuracion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Aplicacion.Configuracion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region ConfiguracionEmpresa

	namespace DepositaryWebApi.Business.Tables.Aplicacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ConfiguracionEmpresa
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Aplicacion.ConfiguracionEmpresa Add(Entities.Tables.Aplicacion.ConfiguracionEmpresa item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Aplicacion.ConfiguracionEmpresa)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Aplicacion.ConfiguracionEmpresa item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Aplicacion.ConfiguracionEmpresa refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionEmpresa entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Aplicacion.ConfiguracionEmpresa" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Aplicacion.ConfiguracionEmpresa" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Aplicacion.ConfiguracionEmpresa" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region ConfiguracionTipoDato

	namespace DepositaryWebApi.Business.Tables.Aplicacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ConfiguracionTipoDato
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Aplicacion.ConfiguracionTipoDato Add(Entities.Tables.Aplicacion.ConfiguracionTipoDato item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Aplicacion.ConfiguracionTipoDato)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Aplicacion.ConfiguracionTipoDato item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Aplicacion.ConfiguracionTipoDato refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionTipoDato entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Aplicacion.ConfiguracionTipoDato" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Aplicacion.ConfiguracionTipoDato" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Aplicacion.ConfiguracionTipoDato" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region ConfiguracionValidacionDato

	namespace DepositaryWebApi.Business.Tables.Aplicacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ConfiguracionValidacionDato
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Aplicacion.ConfiguracionValidacionDato Add(Entities.Tables.Aplicacion.ConfiguracionValidacionDato item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Aplicacion.ConfiguracionValidacionDato)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Aplicacion.ConfiguracionValidacionDato item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Aplicacion.ConfiguracionValidacionDato refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Aplicacion.ConfiguracionValidacionDato entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Aplicacion.ConfiguracionValidacionDato" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Aplicacion.ConfiguracionValidacionDato" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Aplicacion.ConfiguracionValidacionDato" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Log

	namespace DepositaryWebApi.Business.Tables.Auditoria
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Log
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Auditoria.Log Add(Entities.Tables.Auditoria.Log item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Auditoria.Log)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Auditoria.Log item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Auditoria.Log refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Auditoria.Log entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Auditoria.Log" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Auditoria.Log" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Auditoria.Log" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoLog

	namespace DepositaryWebApi.Business.Tables.Auditoria
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoLog
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Auditoria.TipoLog Add(Entities.Tables.Auditoria.TipoLog item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Auditoria.TipoLog)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Auditoria.TipoLog item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Auditoria.TipoLog refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Auditoria.TipoLog entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Auditoria.TipoLog" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Auditoria.TipoLog" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Auditoria.TipoLog" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Banco

	namespace DepositaryWebApi.Business.Tables.Banca
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Banco
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Banca.Banco Add(Entities.Tables.Banca.Banco item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Banca.Banco)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Banca.Banco item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Banca.Banco refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Banca.Banco entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Banca.Banco" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Banca.Banco" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Banca.Banco" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Cuenta

	namespace DepositaryWebApi.Business.Tables.Banca
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Cuenta
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Banca.Cuenta Add(Entities.Tables.Banca.Cuenta item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Banca.Cuenta)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Banca.Cuenta item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Banca.Cuenta refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Banca.Cuenta entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Banca.Cuenta" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Banca.Cuenta" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Banca.Cuenta" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoCuenta

	namespace DepositaryWebApi.Business.Tables.Banca
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoCuenta
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Banca.TipoCuenta Add(Entities.Tables.Banca.TipoCuenta item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Banca.TipoCuenta)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Banca.TipoCuenta item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Banca.TipoCuenta refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Banca.TipoCuenta entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Banca.TipoCuenta" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Banca.TipoCuenta" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Banca.TipoCuenta" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region UsuarioCuenta

	namespace DepositaryWebApi.Business.Tables.Banca
{
	/// <summary>
	/// 
	/// </summary>
	public partial class UsuarioCuenta
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Banca.UsuarioCuenta Add(Entities.Tables.Banca.UsuarioCuenta item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Banca.UsuarioCuenta)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Banca.UsuarioCuenta item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Banca.UsuarioCuenta refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Banca.UsuarioCuenta entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Banca.UsuarioCuenta" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Banca.UsuarioCuenta" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Banca.UsuarioCuenta" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region HuellaDactilar

	namespace DepositaryWebApi.Business.Tables.Biometria
{
	/// <summary>
	/// 
	/// </summary>
	public partial class HuellaDactilar
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Biometria.HuellaDactilar Add(Entities.Tables.Biometria.HuellaDactilar item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Biometria.HuellaDactilar)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Biometria.HuellaDactilar item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Biometria.HuellaDactilar refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Biometria.HuellaDactilar" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Biometria.HuellaDactilar" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Biometria.HuellaDactilar" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Entidad

	namespace DepositaryWebApi.Business.Tables.Customizador
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Entidad
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Customizador.Entidad Add(Entities.Tables.Customizador.Entidad item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Customizador.Entidad)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Customizador.Entidad item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Customizador.Entidad refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Customizador.Entidad entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Customizador.Entidad" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Customizador.Entidad" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Customizador.Entidad" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region EntidadAtributo

	namespace DepositaryWebApi.Business.Tables.Customizador
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EntidadAtributo
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Customizador.EntidadAtributo Add(Entities.Tables.Customizador.EntidadAtributo item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Customizador.EntidadAtributo)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Customizador.EntidadAtributo item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Customizador.EntidadAtributo refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Customizador.EntidadAtributo entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Customizador.EntidadAtributo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Customizador.EntidadAtributo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Customizador.EntidadAtributo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Empresa

	namespace DepositaryWebApi.Business.Tables.Directorio
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Empresa
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Directorio.Empresa Add(Entities.Tables.Directorio.Empresa item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Directorio.Empresa)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Directorio.Empresa item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Directorio.Empresa refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Directorio.Empresa entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Directorio.Empresa" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Directorio.Empresa" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Directorio.Empresa" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Grupo

	namespace DepositaryWebApi.Business.Tables.Directorio
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Grupo
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Directorio.Grupo Add(Entities.Tables.Directorio.Grupo item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Directorio.Grupo)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Directorio.Grupo item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Directorio.Grupo refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Directorio.Grupo entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Directorio.Grupo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Directorio.Grupo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Directorio.Grupo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region RelacionMonedaSucursal

	namespace DepositaryWebApi.Business.Tables.Directorio
{
	/// <summary>
	/// 
	/// </summary>
	public partial class RelacionMonedaSucursal
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Directorio.RelacionMonedaSucursal Add(Entities.Tables.Directorio.RelacionMonedaSucursal item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Directorio.RelacionMonedaSucursal)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Directorio.RelacionMonedaSucursal item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Directorio.RelacionMonedaSucursal refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Directorio.RelacionMonedaSucursal entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Directorio.RelacionMonedaSucursal" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Directorio.RelacionMonedaSucursal" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Directorio.RelacionMonedaSucursal" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Sector

	namespace DepositaryWebApi.Business.Tables.Directorio
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Sector
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Directorio.Sector Add(Entities.Tables.Directorio.Sector item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Directorio.Sector)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Directorio.Sector item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Directorio.Sector refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Directorio.Sector entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Directorio.Sector" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Directorio.Sector" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Directorio.Sector" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Sucursal

	namespace DepositaryWebApi.Business.Tables.Directorio
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Sucursal
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Directorio.Sucursal Add(Entities.Tables.Directorio.Sucursal item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Directorio.Sucursal)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Directorio.Sucursal item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Directorio.Sucursal refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Directorio.Sucursal entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Directorio.Sucursal" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Directorio.Sucursal" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Directorio.Sucursal" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region ComandoContadora

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ComandoContadora
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.ComandoContadora Add(Entities.Tables.Dispositivo.ComandoContadora item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.ComandoContadora)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.ComandoContadora item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.ComandoContadora refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.ComandoContadora entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.ComandoContadora" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.ComandoContadora" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.ComandoContadora" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region ComandoPlaca

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ComandoPlaca
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.ComandoPlaca Add(Entities.Tables.Dispositivo.ComandoPlaca item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.ComandoPlaca)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.ComandoPlaca item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.ComandoPlaca refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.ComandoPlaca entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.ComandoPlaca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.ComandoPlaca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.ComandoPlaca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region ConfiguracionDepositario

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ConfiguracionDepositario
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.ConfiguracionDepositario Add(Entities.Tables.Dispositivo.ConfiguracionDepositario item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.ConfiguracionDepositario)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.ConfiguracionDepositario item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.ConfiguracionDepositario refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.ConfiguracionDepositario entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.ConfiguracionDepositario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.ConfiguracionDepositario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.ConfiguracionDepositario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Depositario

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Depositario
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.Depositario Add(Entities.Tables.Dispositivo.Depositario item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.Depositario)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.Depositario item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.Depositario refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.Depositario entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.Depositario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.Depositario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.Depositario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region DepositarioContadora

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class DepositarioContadora
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.DepositarioContadora Add(Entities.Tables.Dispositivo.DepositarioContadora item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.DepositarioContadora)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.DepositarioContadora item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.DepositarioContadora refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioContadora entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioContadora" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioContadora" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioContadora" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region DepositarioEstado

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class DepositarioEstado
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.DepositarioEstado Add(Entities.Tables.Dispositivo.DepositarioEstado item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.DepositarioEstado)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.DepositarioEstado item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.DepositarioEstado refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioEstado entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioEstado" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioEstado" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioEstado" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region DepositarioMoneda

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class DepositarioMoneda
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.DepositarioMoneda Add(Entities.Tables.Dispositivo.DepositarioMoneda item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.DepositarioMoneda)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.DepositarioMoneda item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.DepositarioMoneda refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioMoneda entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioMoneda" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioMoneda" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioMoneda" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region DepositarioPlaca

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class DepositarioPlaca
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.DepositarioPlaca Add(Entities.Tables.Dispositivo.DepositarioPlaca item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.DepositarioPlaca)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.DepositarioPlaca item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.DepositarioPlaca refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.DepositarioPlaca entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioPlaca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioPlaca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.DepositarioPlaca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Marca

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Marca
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.Marca Add(Entities.Tables.Dispositivo.Marca item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.Marca)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.Marca item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.Marca refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.Marca entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.Marca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.Marca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.Marca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Modelo

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Modelo
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.Modelo Add(Entities.Tables.Dispositivo.Modelo item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.Modelo)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.Modelo item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.Modelo refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.Modelo entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.Modelo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.Modelo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.Modelo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region PlantillaMoneda

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class PlantillaMoneda
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.PlantillaMoneda Add(Entities.Tables.Dispositivo.PlantillaMoneda item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.PlantillaMoneda)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.PlantillaMoneda item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.PlantillaMoneda refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.PlantillaMoneda entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.PlantillaMoneda" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.PlantillaMoneda" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.PlantillaMoneda" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region PlantillaMonedaDetalle

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class PlantillaMonedaDetalle
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.PlantillaMonedaDetalle Add(Entities.Tables.Dispositivo.PlantillaMonedaDetalle item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.PlantillaMonedaDetalle)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.PlantillaMonedaDetalle item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.PlantillaMonedaDetalle refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.PlantillaMonedaDetalle entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.PlantillaMonedaDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.PlantillaMonedaDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.PlantillaMonedaDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoConfiguracionDepositario

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoConfiguracionDepositario
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.TipoConfiguracionDepositario Add(Entities.Tables.Dispositivo.TipoConfiguracionDepositario item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.TipoConfiguracionDepositario)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.TipoConfiguracionDepositario item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.TipoConfiguracionDepositario refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.TipoConfiguracionDepositario entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.TipoConfiguracionDepositario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.TipoConfiguracionDepositario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.TipoConfiguracionDepositario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoContadora

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoContadora
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.TipoContadora Add(Entities.Tables.Dispositivo.TipoContadora item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.TipoContadora)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.TipoContadora item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.TipoContadora refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.TipoContadora entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.TipoContadora" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.TipoContadora" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.TipoContadora" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoPlaca

	namespace DepositaryWebApi.Business.Tables.Dispositivo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoPlaca
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Dispositivo.TipoPlaca Add(Entities.Tables.Dispositivo.TipoPlaca item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Dispositivo.TipoPlaca)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Dispositivo.TipoPlaca item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Dispositivo.TipoPlaca refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Dispositivo.TipoPlaca entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Dispositivo.TipoPlaca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Dispositivo.TipoPlaca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Dispositivo.TipoPlaca" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Esquema

	namespace DepositaryWebApi.Business.Tables.Estilo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Esquema
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Estilo.Esquema Add(Entities.Tables.Estilo.Esquema item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Estilo.Esquema)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Estilo.Esquema item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Estilo.Esquema refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Estilo.Esquema entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Estilo.Esquema" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Estilo.Esquema" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Estilo.Esquema" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region EsquemaDetalle

	namespace DepositaryWebApi.Business.Tables.Estilo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EsquemaDetalle
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Estilo.EsquemaDetalle Add(Entities.Tables.Estilo.EsquemaDetalle item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Estilo.EsquemaDetalle)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Estilo.EsquemaDetalle item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Estilo.EsquemaDetalle refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Estilo.EsquemaDetalle entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Estilo.EsquemaDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Estilo.EsquemaDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Estilo.EsquemaDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoEsquemaDetalle

	namespace DepositaryWebApi.Business.Tables.Estilo
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoEsquemaDetalle
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Estilo.TipoEsquemaDetalle Add(Entities.Tables.Estilo.TipoEsquemaDetalle item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Estilo.TipoEsquemaDetalle)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Estilo.TipoEsquemaDetalle item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Estilo.TipoEsquemaDetalle refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Estilo.TipoEsquemaDetalle entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Estilo.TipoEsquemaDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Estilo.TipoEsquemaDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Estilo.TipoEsquemaDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Ciudad

	namespace DepositaryWebApi.Business.Tables.Geografia
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Ciudad
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Geografia.Ciudad Add(Entities.Tables.Geografia.Ciudad item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Geografia.Ciudad)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Geografia.Ciudad item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Geografia.Ciudad refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Geografia.Ciudad entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Geografia.Ciudad" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Geografia.Ciudad" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Geografia.Ciudad" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region CodigoPostal

	namespace DepositaryWebApi.Business.Tables.Geografia
{
	/// <summary>
	/// 
	/// </summary>
	public partial class CodigoPostal
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Geografia.CodigoPostal Add(Entities.Tables.Geografia.CodigoPostal item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Geografia.CodigoPostal)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Geografia.CodigoPostal item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Geografia.CodigoPostal refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Geografia.CodigoPostal" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Geografia.CodigoPostal" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Geografia.CodigoPostal" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Pais

	namespace DepositaryWebApi.Business.Tables.Geografia
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Pais
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Geografia.Pais Add(Entities.Tables.Geografia.Pais item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Geografia.Pais)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Geografia.Pais item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Geografia.Pais refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Geografia.Pais entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Geografia.Pais" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Geografia.Pais" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Geografia.Pais" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Provincia

	namespace DepositaryWebApi.Business.Tables.Geografia
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Provincia
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Geografia.Provincia Add(Entities.Tables.Geografia.Provincia item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Geografia.Provincia)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Geografia.Provincia item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Geografia.Provincia refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Geografia.Provincia entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Geografia.Provincia" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Geografia.Provincia" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Geografia.Provincia" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Zona

	namespace DepositaryWebApi.Business.Tables.Geografia
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Zona
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Geografia.Zona Add(Entities.Tables.Geografia.Zona item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Geografia.Zona)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Geografia.Zona item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Geografia.Zona refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Geografia.Zona entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Geografia.Zona" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Geografia.Zona" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Geografia.Zona" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Ticket

	namespace DepositaryWebApi.Business.Tables.Impresion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Ticket
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Impresion.Ticket Add(Entities.Tables.Impresion.Ticket item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Impresion.Ticket)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Impresion.Ticket item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Impresion.Ticket refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Impresion.Ticket entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Impresion.Ticket" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Impresion.Ticket" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Impresion.Ticket" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoTicket

	namespace DepositaryWebApi.Business.Tables.Impresion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoTicket
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Impresion.TipoTicket Add(Entities.Tables.Impresion.TipoTicket item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Impresion.TipoTicket)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Impresion.TipoTicket item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Impresion.TipoTicket refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Impresion.TipoTicket entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Impresion.TipoTicket" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Impresion.TipoTicket" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Impresion.TipoTicket" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region CierreDiario

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class CierreDiario
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.CierreDiario Add(Entities.Tables.Operacion.CierreDiario item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.CierreDiario)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.CierreDiario item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.CierreDiario refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.CierreDiario entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.CierreDiario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.CierreDiario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.CierreDiario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Contenedor

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Contenedor
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.Contenedor Add(Entities.Tables.Operacion.Contenedor item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.Contenedor)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.Contenedor item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.Contenedor refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.Contenedor entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.Contenedor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.Contenedor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.Contenedor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Evento

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Evento
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.Evento Add(Entities.Tables.Operacion.Evento item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.Evento)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.Evento item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.Evento refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.Evento entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.Evento" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.Evento" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.Evento" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Sesion

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Sesion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.Sesion Add(Entities.Tables.Operacion.Sesion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.Sesion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.Sesion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.Sesion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.Sesion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.Sesion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.Sesion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.Sesion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoContenedor

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoContenedor
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.TipoContenedor Add(Entities.Tables.Operacion.TipoContenedor item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.TipoContenedor)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.TipoContenedor item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.TipoContenedor refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.TipoContenedor entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.TipoContenedor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.TipoContenedor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.TipoContenedor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoEvento

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoEvento
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.TipoEvento Add(Entities.Tables.Operacion.TipoEvento item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.TipoEvento)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.TipoEvento item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.TipoEvento refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.TipoEvento entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.TipoEvento" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.TipoEvento" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.TipoEvento" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoTransaccion

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoTransaccion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.TipoTransaccion Add(Entities.Tables.Operacion.TipoTransaccion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.TipoTransaccion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.TipoTransaccion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.TipoTransaccion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.TipoTransaccion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.TipoTransaccion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.TipoTransaccion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.TipoTransaccion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Transaccion

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Transaccion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.Transaccion Add(Entities.Tables.Operacion.Transaccion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.Transaccion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.Transaccion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.Transaccion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.Transaccion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.Transaccion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.Transaccion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.Transaccion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TransaccionDetalle

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TransaccionDetalle
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.TransaccionDetalle Add(Entities.Tables.Operacion.TransaccionDetalle item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.TransaccionDetalle)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.TransaccionDetalle item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.TransaccionDetalle refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.TransaccionDetalle entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.TransaccionDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.TransaccionDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.TransaccionDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TransaccionSobre

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TransaccionSobre
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.TransaccionSobre Add(Entities.Tables.Operacion.TransaccionSobre item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.TransaccionSobre)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.TransaccionSobre item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.TransaccionSobre refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobre entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.TransaccionSobre" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.TransaccionSobre" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.TransaccionSobre" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TransaccionSobreDetalle

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TransaccionSobreDetalle
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.TransaccionSobreDetalle Add(Entities.Tables.Operacion.TransaccionSobreDetalle item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.TransaccionSobreDetalle)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.TransaccionSobreDetalle item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.TransaccionSobreDetalle refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.TransaccionSobreDetalle entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.TransaccionSobreDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.TransaccionSobreDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.TransaccionSobreDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Turno

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Turno
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.Turno Add(Entities.Tables.Operacion.Turno item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.Turno)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.Turno item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.Turno refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.Turno entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.Turno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.Turno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.Turno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TurnoUsuario

	namespace DepositaryWebApi.Business.Tables.Operacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TurnoUsuario
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Operacion.TurnoUsuario Add(Entities.Tables.Operacion.TurnoUsuario item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Operacion.TurnoUsuario)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Operacion.TurnoUsuario item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Operacion.TurnoUsuario refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Operacion.TurnoUsuario entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Operacion.TurnoUsuario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Operacion.TurnoUsuario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Operacion.TurnoUsuario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Lenguaje

	namespace DepositaryWebApi.Business.Tables.Regionalizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Lenguaje
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Regionalizacion.Lenguaje Add(Entities.Tables.Regionalizacion.Lenguaje item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Regionalizacion.Lenguaje)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Regionalizacion.Lenguaje item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Regionalizacion.Lenguaje refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Regionalizacion.Lenguaje entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Regionalizacion.Lenguaje" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Regionalizacion.Lenguaje" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Regionalizacion.Lenguaje" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region LenguajeItem

	namespace DepositaryWebApi.Business.Tables.Regionalizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class LenguajeItem
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Regionalizacion.LenguajeItem Add(Entities.Tables.Regionalizacion.LenguajeItem item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Regionalizacion.LenguajeItem)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Regionalizacion.LenguajeItem item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Regionalizacion.LenguajeItem refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Regionalizacion.LenguajeItem entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Regionalizacion.LenguajeItem" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Regionalizacion.LenguajeItem" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Regionalizacion.LenguajeItem" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Aplicacion

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Aplicacion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.Aplicacion Add(Entities.Tables.Seguridad.Aplicacion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.Aplicacion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.Aplicacion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.Aplicacion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.Aplicacion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.Aplicacion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.Aplicacion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.Aplicacion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region AplicacionParametro

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class AplicacionParametro
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.AplicacionParametro Add(Entities.Tables.Seguridad.AplicacionParametro item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.AplicacionParametro)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.AplicacionParametro item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.AplicacionParametro refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametro entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.AplicacionParametro" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.AplicacionParametro" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.AplicacionParametro" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region AplicacionParametroValor

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class AplicacionParametroValor
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.AplicacionParametroValor Add(Entities.Tables.Seguridad.AplicacionParametroValor item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.AplicacionParametroValor)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.AplicacionParametroValor item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.AplicacionParametroValor refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.AplicacionParametroValor entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.AplicacionParametroValor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.AplicacionParametroValor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.AplicacionParametroValor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Funcion

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Funcion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.Funcion Add(Entities.Tables.Seguridad.Funcion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.Funcion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.Funcion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.Funcion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.Funcion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.Funcion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.Funcion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.Funcion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region IdentificadorUsuario

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IdentificadorUsuario
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.IdentificadorUsuario Add(Entities.Tables.Seguridad.IdentificadorUsuario item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.IdentificadorUsuario)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.IdentificadorUsuario item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.IdentificadorUsuario refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.IdentificadorUsuario entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.IdentificadorUsuario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.IdentificadorUsuario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.IdentificadorUsuario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Menu

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Menu
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.Menu Add(Entities.Tables.Seguridad.Menu item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.Menu)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.Menu item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.Menu refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.Menu entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.Menu" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.Menu" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.Menu" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Rol

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Rol
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.Rol Add(Entities.Tables.Seguridad.Rol item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.Rol)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.Rol item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.Rol refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.Rol entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.Rol" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.Rol" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.Rol" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region RolFuncion

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class RolFuncion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.RolFuncion Add(Entities.Tables.Seguridad.RolFuncion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.RolFuncion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.RolFuncion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.RolFuncion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.RolFuncion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.RolFuncion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.RolFuncion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.RolFuncion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoAplicacion

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoAplicacion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.TipoAplicacion Add(Entities.Tables.Seguridad.TipoAplicacion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.TipoAplicacion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.TipoAplicacion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.TipoAplicacion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.TipoAplicacion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.TipoAplicacion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.TipoAplicacion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.TipoAplicacion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoFuncion

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoFuncion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.TipoFuncion Add(Entities.Tables.Seguridad.TipoFuncion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.TipoFuncion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.TipoFuncion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.TipoFuncion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.TipoFuncion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.TipoFuncion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.TipoFuncion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.TipoFuncion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoIdentificador

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoIdentificador
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.TipoIdentificador Add(Entities.Tables.Seguridad.TipoIdentificador item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.TipoIdentificador)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.TipoIdentificador item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.TipoIdentificador refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.TipoIdentificador entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.TipoIdentificador" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.TipoIdentificador" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.TipoIdentificador" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region TipoMenu

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TipoMenu
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.TipoMenu Add(Entities.Tables.Seguridad.TipoMenu item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.TipoMenu)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.TipoMenu item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.TipoMenu refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.TipoMenu entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.TipoMenu" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.TipoMenu" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.TipoMenu" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Usuario

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Usuario
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.Usuario Add(Entities.Tables.Seguridad.Usuario item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.Usuario)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.Usuario item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.Usuario refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.Usuario entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.Usuario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.Usuario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.Usuario" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region UsuarioRol

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class UsuarioRol
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.UsuarioRol Add(Entities.Tables.Seguridad.UsuarioRol item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.UsuarioRol)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.UsuarioRol item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.UsuarioRol refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.UsuarioRol entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.UsuarioRol" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.UsuarioRol" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.UsuarioRol" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region UsuarioSector

	namespace DepositaryWebApi.Business.Tables.Seguridad
{
	/// <summary>
	/// 
	/// </summary>
	public partial class UsuarioSector
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Seguridad.UsuarioSector Add(Entities.Tables.Seguridad.UsuarioSector item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Seguridad.UsuarioSector)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Seguridad.UsuarioSector item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Seguridad.UsuarioSector refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Seguridad.UsuarioSector entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Seguridad.UsuarioSector" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Seguridad.UsuarioSector" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Seguridad.UsuarioSector" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Configuracion

	namespace DepositaryWebApi.Business.Tables.Sincronizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Configuracion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Sincronizacion.Configuracion Add(Entities.Tables.Sincronizacion.Configuracion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Sincronizacion.Configuracion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Sincronizacion.Configuracion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Sincronizacion.Configuracion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Sincronizacion.Configuracion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Sincronizacion.Configuracion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Sincronizacion.Configuracion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Sincronizacion.Configuracion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Ejecucion

	namespace DepositaryWebApi.Business.Tables.Sincronizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Ejecucion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Sincronizacion.Ejecucion Add(Entities.Tables.Sincronizacion.Ejecucion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Sincronizacion.Ejecucion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Sincronizacion.Ejecucion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Sincronizacion.Ejecucion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Sincronizacion.Ejecucion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Sincronizacion.Ejecucion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Sincronizacion.Ejecucion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Sincronizacion.Ejecucion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Entidad

	namespace DepositaryWebApi.Business.Tables.Sincronizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Entidad
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Sincronizacion.Entidad Add(Entities.Tables.Sincronizacion.Entidad item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Sincronizacion.Entidad)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Sincronizacion.Entidad item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Sincronizacion.Entidad refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Sincronizacion.Entidad entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Sincronizacion.Entidad" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Sincronizacion.Entidad" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Sincronizacion.Entidad" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region EntidadCabecera

	namespace DepositaryWebApi.Business.Tables.Sincronizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EntidadCabecera
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Sincronizacion.EntidadCabecera Add(Entities.Tables.Sincronizacion.EntidadCabecera item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Sincronizacion.EntidadCabecera)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Sincronizacion.EntidadCabecera item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Sincronizacion.EntidadCabecera refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadCabecera entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Sincronizacion.EntidadCabecera" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Sincronizacion.EntidadCabecera" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Sincronizacion.EntidadCabecera" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region EntidadDetalle

	namespace DepositaryWebApi.Business.Tables.Sincronizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EntidadDetalle
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Sincronizacion.EntidadDetalle Add(Entities.Tables.Sincronizacion.EntidadDetalle item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Sincronizacion.EntidadDetalle)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Sincronizacion.EntidadDetalle item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Sincronizacion.EntidadDetalle refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Sincronizacion.EntidadDetalle entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Sincronizacion.EntidadDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Sincronizacion.EntidadDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Sincronizacion.EntidadDetalle" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = -1
			});

			return 0;
        }
    }
}

    #endregion

    #region AgendaTurno

	namespace DepositaryWebApi.Business.Tables.Turno
{
	/// <summary>
	/// 
	/// </summary>
	public partial class AgendaTurno
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Turno.AgendaTurno Add(Entities.Tables.Turno.AgendaTurno item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Turno.AgendaTurno)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Turno.AgendaTurno item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Turno.AgendaTurno refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Turno.AgendaTurno entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Turno.AgendaTurno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Turno.AgendaTurno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Turno.AgendaTurno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region EsquemaDetalleTurno

	namespace DepositaryWebApi.Business.Tables.Turno
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EsquemaDetalleTurno
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Turno.EsquemaDetalleTurno Add(Entities.Tables.Turno.EsquemaDetalleTurno item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Turno.EsquemaDetalleTurno)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Turno.EsquemaDetalleTurno item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Turno.EsquemaDetalleTurno refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Turno.EsquemaDetalleTurno entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Turno.EsquemaDetalleTurno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Turno.EsquemaDetalleTurno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Turno.EsquemaDetalleTurno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region EsquemaTurno

	namespace DepositaryWebApi.Business.Tables.Turno
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EsquemaTurno
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Turno.EsquemaTurno Add(Entities.Tables.Turno.EsquemaTurno item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Turno.EsquemaTurno)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Turno.EsquemaTurno item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Turno.EsquemaTurno refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Turno.EsquemaTurno entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Turno.EsquemaTurno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Turno.EsquemaTurno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Turno.EsquemaTurno" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Denominacion

	namespace DepositaryWebApi.Business.Tables.Valor
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Denominacion
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Valor.Denominacion Add(Entities.Tables.Valor.Denominacion item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Valor.Denominacion)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Valor.Denominacion item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Valor.Denominacion refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Valor.Denominacion entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Valor.Denominacion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Valor.Denominacion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Valor.Denominacion" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Moneda

	namespace DepositaryWebApi.Business.Tables.Valor
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Moneda
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Valor.Moneda Add(Entities.Tables.Valor.Moneda item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Valor.Moneda)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Valor.Moneda item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Valor.Moneda refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Valor.Moneda entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Valor.Moneda" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Valor.Moneda" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Valor.Moneda" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region OrigenValor

	namespace DepositaryWebApi.Business.Tables.Valor
{
	/// <summary>
	/// 
	/// </summary>
	public partial class OrigenValor
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Valor.OrigenValor Add(Entities.Tables.Valor.OrigenValor item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Valor.OrigenValor)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Valor.OrigenValor item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Valor.OrigenValor refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Valor.OrigenValor entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Valor.OrigenValor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Valor.OrigenValor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Valor.OrigenValor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region RelacionMonedaTipoValor

	namespace DepositaryWebApi.Business.Tables.Valor
{
	/// <summary>
	/// 
	/// </summary>
	public partial class RelacionMonedaTipoValor
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Valor.RelacionMonedaTipoValor Add(Entities.Tables.Valor.RelacionMonedaTipoValor item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Valor.RelacionMonedaTipoValor)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Valor.RelacionMonedaTipoValor item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Valor.RelacionMonedaTipoValor refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Valor.RelacionMonedaTipoValor entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Valor.RelacionMonedaTipoValor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Valor.RelacionMonedaTipoValor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Valor.RelacionMonedaTipoValor" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Tipo

	namespace DepositaryWebApi.Business.Tables.Valor
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Tipo
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Valor.Tipo Add(Entities.Tables.Valor.Tipo item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Valor.Tipo)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Valor.Tipo item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Valor.Tipo refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Valor.Tipo entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Valor.Tipo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Valor.Tipo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Valor.Tipo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region Perfil

	namespace DepositaryWebApi.Business.Tables.Visualizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Perfil
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Visualizacion.Perfil Add(Entities.Tables.Visualizacion.Perfil item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Visualizacion.Perfil)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Visualizacion.Perfil item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Visualizacion.Perfil refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Visualizacion.Perfil entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Visualizacion.Perfil" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Visualizacion.Perfil" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Visualizacion.Perfil" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region PerfilItem

	namespace DepositaryWebApi.Business.Tables.Visualizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class PerfilItem
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Visualizacion.PerfilItem Add(Entities.Tables.Visualizacion.PerfilItem item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Visualizacion.PerfilItem)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Visualizacion.PerfilItem item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Visualizacion.PerfilItem refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Visualizacion.PerfilItem entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Visualizacion.PerfilItem" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Visualizacion.PerfilItem" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Visualizacion.PerfilItem" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

    #region PerfilTipo

	namespace DepositaryWebApi.Business.Tables.Visualizacion
{
	/// <summary>
	/// 
	/// </summary>
	public partial class PerfilTipo
	{
		public enum LogTypeEnum {
			Ninguno,
			Alta,
			Baja,
			Modificacion
		}

		public Entities.Tables.Visualizacion.PerfilTipo Add(Entities.Tables.Visualizacion.PerfilTipo item,long aplicacionId)
		{
			var refItem =  (Entities.Tables.Visualizacion.PerfilTipo)base.Add((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Alta, refItem);
			return refItem;
		}
		public Int64 Update(Entities.Tables.Visualizacion.PerfilTipo item, long aplicacionId)
		{
			var refItem = base.Update((IDataItem)item);
			LogEvent(aplicacionId, LogTypeEnum.Modificacion, item);
			return refItem;
		}

		public Int64 Delete(Int64 id, long aplicacionId)
		{
			Business.Tables.Visualizacion.PerfilTipo refentities = new();
			refentities.Items(id);
			var refentity = refentities.Result.FirstOrDefault();
			LogEvent(aplicacionId, LogTypeEnum.Baja, refentity);
			return  base.DeleteItem(refentity);

		}

		private int LogEvent(long applicacionId, LogTypeEnum logType, DepositaryWebApi.Entities.Tables.Visualizacion.PerfilTipo entity)

		{
			string descripcion = string.Empty;
			string metodo = string.Empty;
			string identificador = string.Empty;
			identificador = " Id: " + entity.Id.ToString();

			switch (logType)
			{
				case LogTypeEnum.Ninguno:
					descripcion = "No especificado";
					metodo = Enum.GetName(LogTypeEnum.Ninguno);
					break;
				case LogTypeEnum.Alta:
					descripcion = "Alta de entidad: DepositaryWebApi.Business.Visualizacion.PerfilTipo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Alta);
					break;
				case LogTypeEnum.Baja:
					descripcion = "Baja de entidad: DepositaryWebApi.Business.Visualizacion.PerfilTipo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Baja);
					break;
				case LogTypeEnum.Modificacion:
					descripcion = "Modificacion de entidad: DepositaryWebApi.Business.Visualizacion.PerfilTipo" + identificador;
					metodo = Enum.GetName(LogTypeEnum.Modificacion);
					break;
				default:
					break;
			}

			DepositaryWebApi.Business.Tables.Auditoria.Log logEntities = new();
			logEntities.Add(new()
			{
				AplicacionId = applicacionId,
				Descripcion = descripcion,
				Detalle = descripcion,
				Fecha = DateTime.Now,
				Metodo = metodo,
				Modulo = "",
				TipoId = (long)logType,
				UsuarioId = entity.UsuarioModificacion != null ? (long)entity.UsuarioModificacion : entity.UsuarioCreacion != null ? (long)entity.UsuarioCreacion : -1
			});

			return 0;
        }
    }
}

    #endregion

