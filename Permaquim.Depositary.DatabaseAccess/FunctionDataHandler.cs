using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Reflection;
public class FunctionDataHandler : DataHandlerBase
{
    /// <summary>
    /// No constructor
    /// </summary>
    public FunctionDataHandler()
        : base()
    {
    }
    /// <summary>
    /// Constructor with IDataItem
    /// </summary>
    public FunctionDataHandler(IDataItem dataItem)
        : base()
    {
        _dataItem = dataItem;
    }
    /// <summary>
    /// Method for executing Stored Function
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    internal virtual List<IDataItem> Items(List<ParameterItemValue> parameters)
    {
        try
        {
            _itemList.Clear();
            _commandText = GetFullDataEntityName();
            _parameterizedValues.AddRange(parameters);
            _datareader = ExecuteReader(_commandText, _transaction, CommandType.StoredProcedure);
            _itemList = MapDataReaderToDataItem(_datareader, _dataItem);

            return _itemList;
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
}

