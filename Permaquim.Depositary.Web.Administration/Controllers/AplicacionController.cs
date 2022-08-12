﻿namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class AplicacionController
    {
        public static string ObtenerConfiguracionGeneral(string pClave)
        {
            string resultado = "";

            //Obtengo la aplicacion
            Depositary.Business.Tables.Seguridad.Aplicacion oAplicacion = new();
            oAplicacion.Where.Add(Depositary.Business.Tables.Seguridad.Aplicacion.ColumnEnum.TipoId, Depositary.sqlEnum.OperandEnum.Equal, SeguridadEntities.TipoAplicacion.Web);
            oAplicacion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Seguridad.Aplicacion.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);

            oAplicacion.Items();

            if (oAplicacion.Result.Count > 0)
            {
                Depositary.Business.Tables.Aplicacion.Configuracion oConfiguracion = new();
                oConfiguracion.Where.Add(Depositary.Business.Tables.Aplicacion.Configuracion.ColumnEnum.AplicacionId, Depositary.sqlEnum.OperandEnum.Equal, oAplicacion.Result.FirstOrDefault().Id);
                oConfiguracion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
                oConfiguracion.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Aplicacion.Configuracion.ColumnEnum.Clave, Depositary.sqlEnum.OperandEnum.Equal, pClave);

                oConfiguracion.Items();

                if (oConfiguracion.Result.Count > 0)
                {
                    resultado = oConfiguracion.Result.FirstOrDefault().Valor;
                }
            }

            return resultado;
        }

        public static string ObtenerConfiguracionEmpresa(string pClave, Int64 pEmpresaId)
        {
            string resultado = "";

            Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa oConfiguracionEmpresa = new();
            oConfiguracionEmpresa.Where.Add(Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.EmpresaId, Depositary.sqlEnum.OperandEnum.Equal, pEmpresaId);
            oConfiguracionEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.Habilitado, Depositary.sqlEnum.OperandEnum.Equal, true);
            oConfiguracionEmpresa.Where.Add(Depositary.sqlEnum.ConjunctionEnum.AND, Depositary.Business.Tables.Aplicacion.ConfiguracionEmpresa.ColumnEnum.Clave, Depositary.sqlEnum.OperandEnum.Equal, pClave);

            oConfiguracionEmpresa.Items();

            if (oConfiguracionEmpresa.Result.Count > 0)
            {
                resultado = oConfiguracionEmpresa.Result.FirstOrDefault().Valor;
            }

            return resultado;
        }
    }
}