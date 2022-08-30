namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class DirectorioController
    {
        public static Entities.Moneda ObtenerMonedaPrincipalSucursal(Int64 pSucursalId)
        {
            Entities.Moneda moneda = new();

            Depositary.Business.Relations.Directorio.RelacionMonedaSucursal oRelacionMonedaSucursal = new();
            oRelacionMonedaSucursal.Where.Add(Depositary.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oRelacionMonedaSucursal.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.SucursalId, Depositary.sqlEnum.OperandEnum.Equal, pSucursalId);
            oRelacionMonedaSucursal.OrderByParameter.Add(Depositary.Business.Relations.Directorio.RelacionMonedaSucursal.ColumnEnum.EsDefault, Depositary.sqlEnum.DirEnum.DESC);

            oRelacionMonedaSucursal.Items();

            if (oRelacionMonedaSucursal.Result.Count > 0)
            {
                var entidadMoneda = oRelacionMonedaSucursal.Result.FirstOrDefault().MonedaId;
                moneda.Id = entidadMoneda.Id;
                moneda.Nombre = entidadMoneda.Nombre;
                moneda.Simbolo = entidadMoneda.Simbolo;
                moneda.Codigo = entidadMoneda.Codigo;
                moneda.Habilitado = entidadMoneda.Habilitado;
                moneda.PaisId = entidadMoneda._PaisId;
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
