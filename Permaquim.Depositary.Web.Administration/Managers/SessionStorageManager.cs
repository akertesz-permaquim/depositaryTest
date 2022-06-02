using Microsoft.AspNetCore.Components;
using Permaquim.Depositary.Web.Administration.Controllers;

namespace Permaquim.Depositary.Web.Administration.Managers
{
    public partial class SessionStorageManager
    {

        [Inject]
        static Blazored.SessionStorage.ISessionStorageService sessionStorage { get; set; }
        public static Int64? UsuarioId
        {
            get
            {
                return GetUsuarioId().Result;
            }
            set
            {
                if (value.HasValue)
                    SetUsuarioId(value.Value);
            }
        }

        public static string NickName
        {
            get
            {
                return GetNickName().Result;
            }
            set
            {
                SetNickName(value);
            }
        }

        public static string NombreUsuario
        {
            get
            {
                return GetNombreUsuario().Result;
            }
            set
            {
                SetNombreUsuario(value);
            }
        }
        public static string ApellidoUsuario
        {
            get
            {
                return GetApellidoUsuario().Result;
            }
            set
            {
                SetApellidoUsuario(value);
            }
        }
        public static string Avatar
        {
            get
            {
                return GetAvatar().Result;
            }
            set
            {
                SetAvatar(value);
            }
        }
        public static Int64 LenguajeId
        {
            get
            {
                return GetLenguajeId().Result;
            }
            set
            {
                SetLenguajeId(value);
            }
        }

        public static List<DepositarioAdminWeb.Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado> DataLenguaje
        {
            get
            {
                return GetDataLenguaje().Result;
            }
            set
            {
                SetDataLenguaje(value);
            }
        }

        public static async void SetUsuarioId(Int64 pIdUsuario)
        {
            //if(sessionStorage==null)
            //{

            //}
            //else
            await sessionStorage.SetItemAsync("IdUsuario", pIdUsuario);
        }
        public static async Task<Int64?> GetUsuarioId()
        {
            return await sessionStorage.GetItemAsync<Int64?>("Id");
        }
        public static async void SetNickName(string pNickName)
        {
            await sessionStorage.SetItemAsync("NickName", pNickName);
        }
        public static async Task<string> GetNickName()
        {
            return await sessionStorage.GetItemAsync<string>("NickName");
        }
        public static async void SetNombreUsuario(string pNombreUsuario)
        {
            await sessionStorage.SetItemAsync("NombreUsuario", pNombreUsuario);
        }
        public static async Task<string> GetNombreUsuario()
        {
            return await sessionStorage.GetItemAsync<string>("NombreUsuario");
        }
        public static async void SetApellidoUsuario(string pApellidoUsuario)
        {
            await sessionStorage.SetItemAsync("ApellidoUsuario", pApellidoUsuario);
        }
        public static async Task<string> GetApellidoUsuario()
        {
            return await sessionStorage.GetItemAsync<string>("ApellidoUsuario");
        }
        public static async void SetAvatar(string pAvatar)
        {
            await sessionStorage.SetItemAsync("Avatar", pAvatar);
        }
        public static async Task<string> GetAvatar()
        {
            return await sessionStorage.GetItemAsync<string>("Avatar");
        }
        public static async void SetLenguajeId(Int64 pLenguajeId)
        {
            await sessionStorage.SetItemAsync("LenguajeId", pLenguajeId);
        }
        public static async Task<Int64> GetLenguajeId()
        {
            return await sessionStorage.GetItemAsync<Int64>("LenguajeId");
        }
        public static async void SetDataLenguaje(List<DepositarioAdminWeb.Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado> pDataLenguaje)
        {
            await sessionStorage.SetItemAsync("DataLenguaje", pDataLenguaje);
        }
        public static async Task<List<DepositarioAdminWeb.Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado>> GetDataLenguaje()
        {
            return await sessionStorage.GetItemAsync<List<DepositarioAdminWeb.Entities.Procedures.Regionalizacion.ObtenerTextosLenguaje.Resultado>>("DataLenguaje");
        }

        public static async void clearSessionStorage()
        {
            await sessionStorage.ClearAsync();
        }
    }
}
