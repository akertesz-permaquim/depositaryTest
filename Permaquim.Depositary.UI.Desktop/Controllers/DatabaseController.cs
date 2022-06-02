using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class DatabaseController
    {
        /// <summary>
        /// Representa el usuario registrado en el Sistema
        /// </summary>
        public static PQDepositario.Entities.Relations.Seguridad.Usuario CurrentUser { get; private set; }
        public static PQDepositario.Entities.Relations.Seguridad.Usuario Login(string user, string password)
        {
                
            PQDepositario.Entities.Relations.Seguridad.Usuario usuario = new();

            try
            {
                PQDepositario.Business.Relations.Seguridad.Usuario usuarios = new();
                usuarios.Where.Add(PQDepositario.Business.Relations.Seguridad.Usuario.ColumnEnum.NickName, PQDepositario.sqlEnum.OperandEnum.Equal, user);
                usuarios.Where.Add(PQDepositario.sqlEnum.ConjunctionEnum.AND,PQDepositario.Business.Relations.Seguridad.Usuario.ColumnEnum.Password, PQDepositario.sqlEnum.OperandEnum.Equal, password);

                usuarios.Items();
                if (usuarios.Result.Count > 0)
                {
                    usuario = usuarios.Result.FirstOrDefault();
                    CurrentUser = usuario;
                }

                return usuario;
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                
                return usuario;
            }
 
        }
    }
}
