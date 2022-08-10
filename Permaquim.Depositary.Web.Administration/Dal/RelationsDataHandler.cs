using System;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using Permaquim.Depositary.Entities;
public class RelationsDataHandler : DataHandler
{
    /// <summary>
    /// No argument constructor
    /// </summary>
    public RelationsDataHandler()
        : base()
    { }
    /// <summary>
    /// Constructor with IDataItem
    /// </summary>
    public RelationsDataHandler(IDataItem dataItem)
        : base(dataItem)
    {
        _dataItem = dataItem;
    }
    /// <summary>
    /// Constructor to handle Transaction by reflection
    /// </summary>
    /// <remarks></remarks>
    public RelationsDataHandler(IDataHandler dataHandler)
        : base()
    {
        try
        {
            _transaction = dataHandler.GetTransaction();
        }
        catch (Exception)
        {
            throw (new Exception("DataHandler (New) : Transaction assignment Error."));
        }
    }
    ///////////////////////////////////// Reflection Mapping //////////////////////////////////////////////////////////////
    protected override List<IDataItem> MapDataReaderToDataItem<IDataItem>(IDataReader dr, IDataItem dataItem) //where IDataItem : new()
    {
        Type dataItemType = dataItem.GetType();
        PropertyInfo[] properties = dataItemType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public); // TODO: Pasar a caché.
        Hashtable hashtable = new Hashtable();
        //List<IDataItem> entities = new List<IDataItem>();
        List<IDataItem> entities = new List<IDataItem>();
        foreach (PropertyInfo info in properties)
        {
            hashtable[info.Name] = info;
        }
        while (dr.Read())
        {
            IDataItem newObject = (IDataItem)Activator.CreateInstance(dataItemType, false);
            for (int index = 0; index < dr.FieldCount; index++)
            {
                PropertyInfo info = (PropertyInfo)hashtable[_dataFieldDefinitions[index].Name];
                if ((info != null) && info.CanWrite)
                {
                    if (!dr.GetValue(index).Equals(System.DBNull.Value))
                    {
                        if (info.PropertyType.Namespace.Contains("Entities.Relations"))
                        {
                            info = (PropertyInfo)hashtable[ "_" + _dataFieldDefinitions[index].Name];
                        }
                            info.SetValue(newObject, dr.GetValue(index), null);
                    }
                }
            }
            entities.Add(newObject);
        }
        dr.Close();
        return entities;
    }
}
