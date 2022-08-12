using Permaquim.Depositary.Web.Api.Security;
using System.Security.Claims;

namespace Permaquim.Depositary.Web.Api.Controllers
{
    public static class JwtController
    {
        private const string JTI = "jti";
        private const string PASSWORDKEY = "AppSettings:PasswordKey";
        public static string GetDepositaryCode(HttpContext context,IConfiguration configuration)
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
