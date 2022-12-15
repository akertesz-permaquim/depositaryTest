﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiometriaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BiometriaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string ENTIDAD_HUELLADACTILAR = "Biometria.HuellaDactilar";

        #region Endpoints
        [HttpPost]
        [Route("ObtenerHuellasDactilares")]
        [Authorize]
        public async Task<IActionResult> ObtenerHuellasDactilares([FromBody] BiometriaHuellaDactilarModel data)
        {
            //Por defecto se indica una fecha minima para no usar nulos
            DateTime fechaSincronizacionDefault = new(1900, 1, 1);

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            try
            {
                //Iniciamos un registro de sincronizacion de la entidad.
                Int64? SincroBiometriaHuellaDactilarId = SynchronizationController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_HUELLADACTILAR);

                if (SincroBiometriaHuellaDactilarId.HasValue)
                {
                    var fechaDiferencial = data.SincroDates.ContainsKey(ENTIDAD_HUELLADACTILAR) ? data.SincroDates[ENTIDAD_HUELLADACTILAR] : fechaSincronizacionDefault;
                    data.HuellasDactilares = ObtenerHuellasDactilaresBD(fechaDiferencial);
                    SynchronizationController.finalizarCabeceraSincronizacion(SincroBiometriaHuellaDactilarId.Value);
                }
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return BadRequest(ex.Message);
            }

            return Ok(data);

        }

        #endregion

        #region Controllers

        private List<DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar> ObtenerHuellasDactilaresBD(DateTime fechaUltimaSincronizacion)
        {
            List<DepositaryWebApi.Entities.Tables.Biometria.HuellaDactilar> result = new();
            DepositaryWebApi.Business.Tables.Biometria.HuellaDactilar oEntities = new();
            oEntities.Where.Add(DepositaryWebApi.Business.Tables.Biometria.HuellaDactilar.ColumnEnum.FechaCreacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);
            oEntities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.OR, DepositaryWebApi.Business.Tables.Biometria.HuellaDactilar.ColumnEnum.FechaModificacion, DepositaryWebApi.sqlEnum.OperandEnum.GreaterThanOrEqual, fechaUltimaSincronizacion);

            try
            {
                oEntities.Items();
                if (oEntities.Result.Count > 0)
                {
                    foreach (var item in oEntities.Result)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #endregion
    }
}
