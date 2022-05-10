using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Depositary
{
    public static class Utilities
    {
        public static List<IDataItem> GetDataItems()
        {
            List<IDataItem> returnValue = new List<IDataItem>();

            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IDataItem))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IDataItem;

            returnValue.AddRange(instances);

            return returnValue ;
        }

        public static List<IDataHandler> GetDataHandlers()
        {
            List<IDataHandler> returnValue = new List<IDataHandler>();

            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IDataHandler))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IDataHandler;

            returnValue.AddRange(instances);
            
            return returnValue ;
        }
        public static IDataHandler GetDataHandlerByName(string name)
        {
            return GetDataHandlers().Where(x => x.ToString().Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Usage : ExecuteWithTimeMeasurement(() => m.Items()).ToString(); 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static long ExecuteWithTimeMeasurement(Action action)
        {
            if (action == null) throw new ArgumentNullException();
            else
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                action();
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }
        }

    }
}

