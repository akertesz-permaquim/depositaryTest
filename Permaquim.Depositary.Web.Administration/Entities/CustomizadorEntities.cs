namespace Permaquim.Depositary.Web.Administration.CustomizadorEntities
{
    public class CustomizacionPagina
    {
        public Depositary.Entities.Tables.Customizador.Entidad AtributosTabla  { get; set; }
        public List<Depositary.Entities.Tables.Customizador.EntidadAtributo> AtributosColumnas { get; set; }

        public CustomizacionPagina()
        {
            AtributosTabla = new();
            AtributosColumnas = new();
        }
    }
}
