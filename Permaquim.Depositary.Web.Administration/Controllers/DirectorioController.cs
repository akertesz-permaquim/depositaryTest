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
        public static bool InsertarMonedaRelacionSucursalEnDepositarios(Depositary.Entities.Tables.Directorio.RelacionMonedaSucursal NuevaRelacionMonedaSucursal)
        {
            bool resultado = false;

            //Obtenemos los sectores asociados a la sucursal
            Depositary.Business.Relations.Directorio.Sector oSectores = new();
            oSectores.Where.Add(Business.Relations.Directorio.Sector.ColumnEnum.SucursalId, sqlEnum.OperandEnum.Equal, NuevaRelacionMonedaSucursal.SucursalId);

            oSectores.Items();

            if (oSectores.Result.Count > 0)
            {
                Depositary.Business.Tables.Dispositivo.DepositarioMoneda oDepositarioMoneda = new();
                Depositary.Entities.Tables.Dispositivo.DepositarioMoneda eDepositarioMoneda = new();
                eDepositarioMoneda.MonedaId = NuevaRelacionMonedaSucursal.MonedaId;
                eDepositarioMoneda.Habilitado = NuevaRelacionMonedaSucursal.Habilitado;
                eDepositarioMoneda.FechaCreacion = DateTime.Now;
                eDepositarioMoneda.UsuarioCreacion = NuevaRelacionMonedaSucursal.UsuarioCreacion;
                eDepositarioMoneda.IndiceEnContadora = 0; //TODO: Revisar este dato, parece que no se usa.

                oDepositarioMoneda.BeginTransaction();
                foreach (var sector in oSectores.Result)
                {
                    //Obtenemos los depositarios asociados al sector
                    var depositariosAsociadosSector = sector.ListOf_Depositario_SectorId;

                    if (depositariosAsociadosSector != null && depositariosAsociadosSector.Any())
                    {
                        foreach (var depositario in depositariosAsociadosSector)
                        {
                            try
                            {
                                eDepositarioMoneda.DepositarioId = depositario.Id;
                                oDepositarioMoneda.Add(eDepositarioMoneda);
                            }
                            catch (Exception ex)
                            {
                                AuditController.Log(ex);
                                oDepositarioMoneda.EndTransaction(false);
                                return false;
                            }
                        }
                    }
                }
                oDepositarioMoneda.EndTransaction(true);

            }

            resultado = true;

            return resultado;

        }

        public static List<Depositary.Entities.Tables.Directorio.Empresa> ObtenerEmpresasNoDefault(Int64 pEmpresaDefaultId)
        {
            List<Depositary.Entities.Tables.Directorio.Empresa> resultado = new();

            Depositary.Business.Tables.Directorio.Empresa oEmpresa = new();
            oEmpresa.Where.Add(Depositary.Business.Tables.Directorio.Empresa.ColumnEnum.Id, Depositary.sqlEnum.OperandEnum.NotEqual, pEmpresaDefaultId);

            resultado = oEmpresa.Items();

            return resultado;
        }
    }
}
