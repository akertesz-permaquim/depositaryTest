using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Model;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeografiaController : ControllerBase
    {
        #region Endpoints
        [HttpGet]
        [Route("ObtenerGeografia")]
        [Authorize]
        public async Task<IActionResult> ObtenerGeografia()
        {
            GeografiaModel data = new();

            try
            {
                data.Paises = ObtenerPaisesBD();
                data.Provincias = ObtenerProvinciasBD();
                data.Ciudades = ObtenerCiudadesBD();
                data.CodigosPostales = ObtenerCodigosPostalesBD();
                data.Zonas = ObtenerZonasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerPaises")]
        [Authorize]
        public async Task<IActionResult> ObtenerPaises()
        {
            GeografiaPaisModel data = new();

            try
            {
                data.Paises = ObtenerPaisesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerProvincias")]
        [Authorize]
        public async Task<IActionResult> ObtenerProvincias()
        {
            GeografiaProvinciaModel data = new();

            try
            {
                data.Provincias = ObtenerProvinciasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerCiudades")]
        [Authorize]
        public async Task<IActionResult> ObtenerCiudades()
        {
            GeografiaCiudadModel data = new();

            try
            {
                data.Ciudades = ObtenerCiudadesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerZonas")]
        [Authorize]
        public async Task<IActionResult> ObtenerZonas()
        {
            GeografiaZonaModel data = new();

            try
            {
                data.Zonas = ObtenerZonasBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerCodigosPostales")]
        [Authorize]
        public async Task<IActionResult> ObtenerCodigosPostales()
        {
            GeografiaCodigoPostalModel data = new();

            try
            {
                data.CodigosPostales = ObtenerCodigosPostalesBD();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(data);
        }

        #endregion

        #region Controllers
        private List<DepositaryWebApi.Entities.Tables.Geografia.Pais> ObtenerPaisesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Pais> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Pais oEntities = new();

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> ObtenerProvinciasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Provincia> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Provincia oEntities = new();

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> ObtenerCiudadesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Ciudad> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Ciudad oEntities = new();

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.Zona> ObtenerZonasBD()
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.Zona> result = new();
            DepositaryWebApi.Business.Tables.Geografia.Zona oEntities = new();

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

        private List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> ObtenerCodigosPostalesBD()
        {
            List<DepositaryWebApi.Entities.Tables.Geografia.CodigoPostal> result = new();
            DepositaryWebApi.Business.Tables.Geografia.CodigoPostal oEntities = new();

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
