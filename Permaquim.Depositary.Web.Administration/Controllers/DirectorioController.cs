namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class DirectorioController
    {
        public static Entities.Moneda ObtenerMonedaPrincipalSucursal(Int64 pSucursalId)
        {
            Entities.Moneda moneda = new();

            DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal oRelacionMonedaSucursal = new();
            oRelacionMonedaSucursal.Where.Add(DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.Habilitado, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, true);
            oRelacionMonedaSucursal.Where.Add(DepositarioAdminWeb.sqlEnum.ConjunctionEnum.AND, DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.SucursalId, DepositarioAdminWeb.sqlEnum.OperandEnum.Equal, pSucursalId);
            oRelacionMonedaSucursal.OrderByParameter.Add(DepositarioAdminWeb.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.EsDefault, DepositarioAdminWeb.sqlEnum.DirEnum.DESC);

            oRelacionMonedaSucursal.Items();

            if (oRelacionMonedaSucursal.Result.Count > 0)
            {
                moneda.Id = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.Id;
                moneda.Nombre = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.Nombre;
                moneda.Simbolo = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.Simbolo;
                moneda.Codigo = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.Codigo;
                moneda.Habilitado = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.Habilitado;
                moneda.IndiceEnContadora = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.IndiceEnContadora;
                moneda.PaisId = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.PaisId;
                moneda.UsuarioCreacion = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.UsuarioCreacion.ToString();
                moneda.UsuarioModificacion = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.UsuarioModificacion.ToString();
                moneda.FechaModificacion = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.FechaModificacion;
                moneda.FechaCreacion = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId.FechaCreacion;
            }

            return moneda;
        }
    }
}
