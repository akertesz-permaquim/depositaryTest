using Microsoft.AspNetCore.Http;
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
 
        public ActionResult ObtenerToken([FromBody]LoginModel model)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            DepositaryWebApi.Business.Relations.Seguridad.Usuario usuarios = new();
            usuarios.Where.Add(DepositaryWebApi.Business.Relations.Seguridad.Usuario.ColumnEnum.NickName,
                DepositaryWebApi.sqlEnum.OperandEnum.Equal, model.UserName);
            usuarios.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND,
                DepositaryWebApi.Business.Relations.Seguridad.Usuario.ColumnEnum.Password, DepositaryWebApi.sqlEnum.OperandEnum.Equal, Cryptography.Hash(model.Password));
            usuarios.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND,
                DepositaryWebApi.Business.Relations.Seguridad.Usuario.ColumnEnum.Habilitado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, true);
            usuarios.Items();

            //Si se encuentra un usuario con ese password se devuelve el token, si no un BadRequest con mensaje de error.
            if(usuarios.Result.Count>0)
            {
                var usuario = usuarios.Result.FirstOrDefault();

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.Surname, usuario.Apellido),
                    new Claim(ClaimTypes.Email, usuario.Mail),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                };

                DepositaryWebApi.Business.Relations.Seguridad.UsuarioRol usuarioRol = new();

                usuarioRol.Where.Add(DepositaryWebApi.Business.Relations.Seguridad.UsuarioRol.ColumnEnum.UsuarioId,
                    DepositaryWebApi.sqlEnum.OperandEnum.Equal, usuarios.Result.FirstOrDefault().Id);

                var userRoles = usuarioRol.Items();

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole.RolId.Nombre));
                }

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
                return BadRequest("Usuario o contraseña invalidos.");
            }
        }

    }
}
