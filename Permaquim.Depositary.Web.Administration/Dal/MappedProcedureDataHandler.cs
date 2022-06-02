using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Reflection;
public class MappedProcedureDataHandler : DataHandlerBase
{
    private List<IDataItem> _dataItems;

    /// <summary>
    /// No constructor
    /// </summary>
    public MappedProcedureDataHandler()
        : base()
    {
    }
    /// <summary>
    /// Constructor with List of IDataItem
    /// </summary>
    public MappedProcedureDataHandler(IDataItem dataItem, List<IDataItem> dataItems)
        : base()
    {
        _dataItem = dataItem;
        _dataItems = dataItems;
    }
    /// <summary>
    /// Method for executing mapped Stored Procedure
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    internal virtual List<List<IDataItem>> Items(List<ParameterItemValue> parameters)
    {
        try
        {
            _itemList.Clear();
            _commandText = GetFullDataEntityName();
            _parameterizedValues.AddRange(parameters);
            _datareader = ExecuteReader(_commandText, _transaction, CommandType.StoredProcedure);
            List<List<IDataItem>> results = new List<List<IDataItem>>();

            foreach (IDataItem item in _dataItems)
            {
                results.Add(mMapDataReaderToDataItem(_datareader, item));

                _datareader.NextResult();
            }

            return results;
        }
        catch (System.Exception ex)
        {
            throw (ex);
        }
        finally
        {
            if (_datareader != null)
                _datareader.Close();
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
    protected virtual List<IDataItem> mMapDataReaderToDataItem<IDataItem>(IDataReader dr, IDataItem dataItem) //where IDataItem : new()
    {
        Type dataItemType = dataItem.GetType();
        PropertyInfo[] properties = dataItemType.GetProperties();
        Hashtable hashtable = new Hashtable();
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
                PropertyInfo info = (PropertyInfo)hashtable[dr.GetName(index)];
                if ((info != null) && info.CanWrite)
                {
                    if (!dr.GetValue(index).Equals(System.DBNull.Value))
                        info.SetValue(newObject, dr.GetValue(index), null);
                }
            }
            entities.Add(newObject);
        }

        return entities;
    }
}
