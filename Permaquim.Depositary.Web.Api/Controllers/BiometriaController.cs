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
        [HttpGet]
        [Route("ObtenerHuellasDactilares")]
        [Authorize]
        public async Task<IActionResult> ObtenerHuellasDactilares()
        {
            BiometriaHuellaDactilarModel data = new();

            Int64 depositarioId = JwtController.GetDepositaryId(HttpContext, _configuration);

            //Iniciamos un registro de sincronizacion de la entidad.
            Int64? SincronizacionId = SincronizacionController.iniciarCabeceraSincronizacion(depositarioId, ENTIDAD_HUELLADACTILAR);

            if (SincronizacionId.HasValue)
            {

                try
                {
                    data.HuellasDactilares = ObtenerHuellasDactilaresBD(SincronizacionController.obtenerFechaUltimaSincronizacion(depositarioId, ENTIDAD_HUELLADACTILAR));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok(data);
            }
            else
            {
                return BadRequest("Error al intentar generar registro de sincronizacion para el depositario");
            }
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
