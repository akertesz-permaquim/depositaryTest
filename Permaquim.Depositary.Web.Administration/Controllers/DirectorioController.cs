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
                var entidadMoneda = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId;
                moneda.Id = entidadMoneda.Id;
                moneda.Nombre = entidadMoneda.Nombre;
                moneda.Simbolo = entidadMoneda.Simbolo;
                moneda.Codigo = entidadMoneda.Codigo;
                moneda.Habilitado = entidadMoneda.Habilitado;
                moneda.IndiceEnContadora = entidadMoneda.IndiceEnContadora;
                moneda.PaisId = entidadMoneda.PaisId;
                //TODO revisar FK usuario
                moneda.UsuarioCreacion = entidadMoneda.UsuarioCreacion.ToString();
                moneda.UsuarioModificacion = entidadMoneda.UsuarioModificacion.ToString();
                moneda.FechaModificacion = entidadMoneda.FechaModificacion;
                moneda.FechaCreacion = entidadMoneda.FechaCreacion;
            }

            return moneda;
        }
    }
}
