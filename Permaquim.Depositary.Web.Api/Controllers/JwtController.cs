using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Security;
using System.Security.Claims;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    public static class JwtController
    {
        private const string JTI = "jti";
        private const string PASSWORDKEY = "AppSettings:PasswordKey";

        public static Int64? _depositaryId { get; private set; }

        public static Int64 GetDepositaryId(HttpContext context, IConfiguration configuration)
        {
            if (_depositaryId == null)
            {
                // Verifica que eista un turno disponible para el depositario / sector
                DepositaryWebApi.Business.Tables.Dispositivo.Depositario oDepositario = new();
                oDepositario.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, true);
                oDepositario.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
                    DepositaryWebApi.sqlEnum.OperandEnum.Equal, GetDepositaryCode(context, configuration));

                oDepositario.Items();

                if (oDepositario.Result.Count != 0)
                {
                    _depositaryId = oDepositario.Result.FirstOrDefault().Id;
                }

            }
            return _depositaryId.Value;

        }
        public static string GetDepositaryCode(HttpContext context, IConfiguration configuration)
        {
            string DepositaryCode = String.Empty;
            ClaimsIdentity? identity = context.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                DepositaryCode = identity.Claims.First(claim => claim.Type == JTI).Value;
            }

            return Cryptography.Decrypt(DepositaryCode, configuration[PASSWORDKEY]);
        }


    }
}
