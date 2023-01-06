using Microsoft.AspNetCore.Mvc;
using Permaquim.Depositary.Web.Api.Security;
using System.Security.Claims;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    public static class JwtController
    {
        private const string JTI = "jti";
        private const string PASSWORDKEY = "AppSettings:PasswordKey";

        public static Int64 GetDepositaryId(HttpContext context, IConfiguration configuration)
        {
            Int64? depositaryId = null;
            //if (_depositaryId == null)
            //{
            using (DepositaryWebApi.Business.Tables.Dispositivo.Depositario bTablesDepositario = new())
            {

                bTablesDepositario.Where.Add(DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.Habilitado, DepositaryWebApi.sqlEnum.OperandEnum.Equal, true);
                bTablesDepositario.Where.Add(DepositaryWebApi.sqlEnum.ConjunctionEnum.AND, DepositaryWebApi.Business.Tables.Dispositivo.Depositario.ColumnEnum.CodigoExterno,
                    DepositaryWebApi.sqlEnum.OperandEnum.Equal, GetDepositaryCode(context, configuration));

                bTablesDepositario.Items();

                if (bTablesDepositario.Result.Count != 0)
                {
                    depositaryId = bTablesDepositario.Result.FirstOrDefault().Id;
                }
            }

            return depositaryId.Value;
            //}
            //return _depositaryId.Value;

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

        public static string GetDepositaryCode(HttpContext context)
        {
            string DepositaryCode = String.Empty;
            ClaimsIdentity? identity = context.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                DepositaryCode = identity.Claims.First(claim => claim.Type == JTI).Value;
            }

            return DepositaryCode;
        }


    }
}
