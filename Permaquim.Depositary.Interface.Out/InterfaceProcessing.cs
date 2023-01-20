// See https://aka.ms/new-console-template for more information
using DefaultNamespace.Entities.Relations.Valor;
using Permaquim.Depositary.Interface.Out.Controllers;
using Permaquim.Depositary.UI.Desktop.Controllers;
using System.Text;

internal class InterfaceProcessing
{
    private const string CSV_HEADER = "Transaccion, DNI, Fecha / Hora, 1000, 500, 200, 100, 50, 20, 10, Moneda";
    private Dictionary<string, Dictionary<decimal, long>> denomsCache = new();
    private string OutputPath { get; set; }
    public InterfaceProcessing(string path)
    {
        OutputPath = path;
    }
    internal void Process()
    {
        List<DefaultNamespace.Entities.Relations.Operacion.Contenedor> containers = DatabaseController.GetContainers();
        int processedTrx = 0;
        foreach (var ctr in containers)
        {
            StringBuilder csvOut = new();
            csvOut.AppendLine(CSV_HEADER);
            var bagCode = ctr.Id;
            var trx = ctr.ListOf_Transaccion_ContenedorId;
            foreach (var transaction in trx)
            {
                var dni = transaction.UsuarioId.Documento;
                var trxId = transaction.Id.ToString();
                var moneda = transaction.MonedaId.Codigo;
                Dictionary<decimal, long> denomList = GenerateDictionary(transaction.MonedaId);
                string line = trxId + ","+dni+",";
                foreach (var detail in transaction.ListOf_TransaccionDetalle_TransaccionId)
                {
                    denomList[detail.DenominacionId.Unidades] += detail.CantidadUnidades;
                }
                List<decimal> denomKeys = denomList.Keys.OrderByDescending(x => x).ToList();
                foreach (var key in denomKeys)
                {
                    line += denomList[key] + ",";
                }
                line += moneda;

                csvOut.AppendLine(line);
                processedTrx++;
                Console.WriteLine("Processed " + processedTrx + " transactions.");
            }

            var str = csvOut.ToString();
            Directory.CreateDirectory(OutputPath);
            try
            {
                File.WriteAllText(OutputPath + "\\" + "bolsa" + bagCode + ".csv", str);
            }
            catch (Exception)
            {

            }
        }
    }

    private Dictionary<decimal, long> GenerateDictionary(Moneda monedaId)
    {
        if (denomsCache.ContainsKey(monedaId.Codigo)) return denomsCache[monedaId.Codigo];
        Dictionary<decimal, long> dic = new();
        foreach (var denom in monedaId.ListOf_Denominacion_MonedaId)
        {
            dic[denom.Unidades] = 0;
        }
        if(dic.Keys.Count < 7)
        {
            for(int i = 0; i <= 7 - dic.Keys.Count; i++)
            {
                dic[i] = 0;
            }
        }
        denomsCache[monedaId.Codigo] = dic;
        return dic;
    }

    
}