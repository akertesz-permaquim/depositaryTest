namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class CustomizadorController
    {
        public static CustomizadorEntities.CustomizacionPagina ObtenerCustomizacionPagina(string Esquema, string Tabla)
        {
            CustomizadorEntities.CustomizacionPagina resultado = new();

            Business.Tables.Customizador.Entidad entidad = new();
            entidad.Where.Add(Business.Tables.Customizador.Entidad.ColumnEnum.Esquema, sqlEnum.OperandEnum.Equal, Esquema);
            entidad.Where.Add(sqlEnum.ConjunctionEnum.AND, Business.Tables.Customizador.Entidad.ColumnEnum.Nombre, sqlEnum.OperandEnum.Equal, Tabla);

            entidad.Items();

            if (entidad.Result.Count > 0)
            {
                Depositary.Entities.Tables.Customizador.Entidad entidadEncontrada = entidad.Result.FirstOrDefault();

                resultado.AtributosTabla = entidadEncontrada;

                Business.Tables.Customizador.EntidadAtributo entidadAtributo = new();
                entidadAtributo.Where.Add(Business.Tables.Customizador.EntidadAtributo.ColumnEnum.EntidadId, sqlEnum.OperandEnum.Equal, entidadEncontrada.Id);

                entidadAtributo.Items();

                if (entidadAtributo.Result.Count > 0)
                {
                    foreach (var atributo in entidadAtributo.Result)
                    {
                        resultado.AtributosColumnas.Add(atributo);
                    }
                }
            }

            return resultado;
        }

        public static bool ObtenerPropiedadGrilla(string NombrePropiedad, Depositary.Entities.Tables.Customizador.Entidad AtributosTabla)
        {
            bool resultado = false;
            bool valorPropiedad;

            try
            {
                if (AtributosTabla != null)
                {
                    if (bool.TryParse(AtributosTabla.GetType().GetProperty(NombrePropiedad).GetValue(AtributosTabla, null).ToString(), out valorPropiedad))
                    {
                        resultado = valorPropiedad;
                    }
                }
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
            }

            return resultado;
        }

        public static bool ObtenerPropiedadVisibilidadColumna(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            bool resultado = false;

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.VisibleEnGrilla;
            }

            return resultado;
        }
        public static bool ObtenerPropiedadVisibilidadColumnaEnSelector(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            bool resultado = false;

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.VisibleEnSelectorColumnas;
            }

            return resultado;
        }

        public static bool ObtenerPropiedadColumnaRedimensionable(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            bool resultado = false;

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.Redimensionable;
            }

            return resultado;
        }
        public static bool ObtenerPropiedadColumnaAgrupable(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            bool resultado = false;

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.Agrupable;
            }

            return resultado;
        }
        public static bool ObtenerPropiedadColumnaMovible(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            bool resultado = false;

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.Movible;
            }

            return resultado;
        }
        public static bool ObtenerPropiedadColumnaOrdenable(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            bool resultado = false;

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.Ordenable;
            }

            return resultado;
        }
        public static bool ObtenerPropiedadColumnaFiltrable(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            bool resultado = false;

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.Filtrable;
            }

            return resultado;
        }

        public static int? ObtenerPropiedadPosicionColumnaEnGrilla(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            int? resultado = null;

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.PosicionEnGrilla;
            }

            return resultado;
        }

        public static string ObtenerPropiedadAnchoMinimoColumnaEnGrilla(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            string resultado = "1";

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.AnchoMinimoEnGrilla.ToString();
            }

            return resultado;
        }

        public static string ObtenerPropiedadAnchoColumnaEnGrilla(string Campo, List<Depositary.Entities.Tables.Customizador.EntidadAtributo> Atributos)
        {
            string resultado = "1";

            var propiedadesCampo = Atributos.FirstOrDefault(x => x.Nombre == Campo);

            if (propiedadesCampo != null)
            {
                resultado = propiedadesCampo.AnchoEnGrilla.ToString();
            }

            return resultado + "px";
        }
    }
}
