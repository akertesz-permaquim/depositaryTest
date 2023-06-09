﻿namespace Permaquim.Depositary.Web.Api.Model
{
    public class AuditoriaModel
    {
        public Int64? SynchronizationExecutionId { get; set; }

        public List<DepositaryWebApi.Entities.Tables.Auditoria.TipoLog> TiposLog { get; set; } = new();
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();
    }

    public class AuditoriaTipoLogModel
    {
        public List<DepositaryWebApi.Entities.Tables.Auditoria.TipoLog> TiposLog { get; set; } = new();
    }
}
