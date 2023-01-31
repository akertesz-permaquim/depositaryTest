using DefaultNamespace.Business.Relations.Operacion;

namespace Permaquim.Depositary.Interface.Out.Controllers
{
    public static class DatabaseController
    {
        internal static List<DefaultNamespace.Entities.Relations.Operacion.Contenedor> GetContainers()
        {
            DefaultNamespace.Business.Relations.Operacion.Contenedor containers = new();
            containers.Items();
            return containers.Result;
        }

        internal static List<DefaultNamespace.Entities.Relations.Operacion.Transaccion> GetTransactions()
        {

            DefaultNamespace.Business.Relations.Operacion.Transaccion trx = new();
            trx.Items();
            return trx.Result;

        }
    }
}
