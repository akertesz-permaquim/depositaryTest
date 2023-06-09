﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Permaquim.Depositary.Web.Api.Model;
using Permaquim.Depositary.Web.Api.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly ILogger<AutenticacionController> _logger;
        private readonly IConfiguration _configuration;

        public AutenticacionController(

          IConfiguration configuration)
        {

            _configuration = configuration;
        }

        [HttpPost("ObtenerToken")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult ObtenerToken([FromBody] LoginModel model)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            //DepositaryWebApi.Business.Relations.Dispositivo.Depositario entities = new();
            //entities.Where.Add(DepositaryWebApi.Business.Relations.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
            //    DepositaryWebApi.sqlEnum.OperandEnum.Equal, Cryptography.Decrypt(model.DepositaryCode,_configuration["AppSettings:PasswordKey"]));
            //entities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND,
            //    DepositaryWebApi.Business.Relations.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, true);
            //entities.Items();

            ////Si se encuentra un usuario con ese password se devuelve el token, si no un BadRequest con mensaje de error.
            //if(entities.Result.Count>0)
            //{
            //    var usuario = entities.Result.FirstOrDefault();

            var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, model.DepositaryCode),
                };

            var token = new JwtSecurityToken(
               issuer: _configuration["JWT:ValidIssuer"],
               audience: _configuration["JWT:ValidAudience"],
               expires: DateTime.Now.AddHours(Convert.ToInt32(_configuration["JWT:Hours"])),
               claims: authClaims,
               signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

               );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
            //}
            //else
            //{
            //    return BadRequest("Código de depositario inválido.");
            //}
        }

        /// <summary>
        /// Obtiene el token del usuario registrado para integración
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("TokenUsuario")]
        [ApiConventionMethod(typeof(DefaultApiConventions),nameof(DefaultApiConventions.Post))]
        public ActionResult ObtenerTokenusuario([FromBody] UserLoginModel model)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            DepositaryWebApi.Business.Tables.Seguridad.Usuario entities = new();

            entities.Where.Add(DepositaryWebApi.Business.Tables.Seguridad.Usuario.ColumnEnum.NickName,
                DepositaryWebApi.sqlEnum.OperandEnum.Equal, Base64Decode(model.UserNickName));
            entities.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND,
                DepositaryWebApi.Business.Tables.Seguridad.Usuario.ColumnEnum.Password,
                DepositaryWebApi.sqlEnum.OperandEnum.Equal, Cryptography.Hash(Base64Decode(model.Password)));

            entities.Items();

            //Si se encuentra un usuario con ese password se devuelve el token, si no un BadRequest con mensaje de error.
            if (entities.Result.Count > 0)
            {
                var usuario = entities.Result.FirstOrDefault();

                if (usuario.Habilitado)
                {
                    var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, Base64Decode(model.UserNickName)),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                };

                    var token = new JwtSecurityToken(
                       issuer: _configuration["JWT:ValidIssuer"],
                       audience: _configuration["JWT:ValidAudience"],
                       expires: DateTime.Now.AddHours(Convert.ToInt32(_configuration["JWT:Hours"])),
                       claims: authClaims,
                       signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

                       );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                else
                {
                    return BadRequest("Usuario no habilitado.");
                }
            }
            else
            {
                return BadRequest("Usuario no encontrado.");
            }
        }
        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
