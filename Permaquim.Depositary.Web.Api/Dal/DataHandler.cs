using System;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
public class DataHandler : DataHandlerBase
{
    /// <summary>
    /// No argument constructor
    /// </summary>
    public DataHandler()
        : base()
    { }
    /// <summary>
    /// Constructor with IDataItem
    /// </summary>
    public DataHandler(IDataItem dataItem)
        : base(dataItem)
    {
        _dataItem = dataItem;
    }
    /// <summary>
    /// Constructor to handle Transaction by reflection
    /// </summary>
    /// <remarks></remarks>
    public DataHandler(IDataHandler dataHandler)
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
    /// <summary>
    /// Adds a record in table
    /// </summary>
    /// <param name="Iemm"></param>
    /// <remarks> </remarks>
    internal virtual IDataItem Add(IDataItem item)
    {
        long result = 0;
        try
        {
            _commandText = Constants.SQL_INSERT_INTO ;
            _commandText += GetFullDataEntityName();
            _commandText += " ( " + GetFieldList(false, false);
            _commandText += " ) " + Constants.SQL_VALUES;
            _commandText += " ( " + GetParameterizedValuesList(false,false);
            _commandText += " )";
            BuildParameterValuesList(item);
            _commandText +=  ConfigurationHandler.PkFunction;
            result = ExecuteNonQuery(_commandText, _transaction,true);
            if (result > 0)
            {
                var newIdValue =((IDbDataParameter)base._command.Parameters[Constants.NEWID]).Value;
                string pkName = base.GetPkName();
                Type dataItemType = item.GetType();
                PropertyInfo[] properties = dataItemType.GetProperties();
                foreach (PropertyInfo info in properties)
                {
                    if (info.Name.Equals(pkName) && newIdValue != DBNull.Value)
                    {
                        info.SetValue(item, Convert.ChangeType(newIdValue, info.PropertyType), null);
                        break;
                    }
                }
                return item;
            }
            else
            {
                return null;
            }
        }
        catch (System.Exception ex)
        {
            throw (ex);
        }
    }
    /// <summary>
    /// Adds or Updates referenced IDataItem
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    internal virtual IDataItem AddOrUpdate(IDataItem item)
    {
        throw new NotImplementedException();
    }

    public int TopQuantity { get; set; }

    /// <summary>
    /// Returns a List<IDataItem> for a SQL query.
    /// </summary>
    /// <remarks> </remarks>
    internal virtual List<IDataItem> Items()
    {
        try
        {
            //Clears previous result
            _itemList.Clear();
            _commandText = Constants.SQL_SELECT ;
            if (TopQuantity > 0)
                 _commandText += Constants.SQL_TOP + TopQuantity.ToString() +" ";
            _commandText += GetFieldList(true, true);
            _commandText += Constants.SQL_FROM ;
            _commandText += GetFullDataEntityName();
            _commandText += Constants.SQL_WITH_NOLOCK;
            _commandText += WhereParameter.ToString();
            _commandText += GroupByParameter.ToString();
            BuildParameterValuesList(WhereParameter);
            _commandText += OrderByParameter.ToString();
            _commandText = _commandText.Replace(Constants.INPUT_PARAMETER, _parameterPrefix);
            _datareader = base.ExecuteReader(_commandText, _transaction);
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
            if (_connection.State == ConnectionState.Open && _transaction == null)
                _connection.Close();
        }
    }
    /// <summary>
    /// Deletes records from table
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    internal virtual Int64 Delete()
    {
        try
        {
            _commandText = Constants.SQL_DELETE + Constants.SQL_FROM;
            _commandText += GetFullDataEntityName();
            _commandText += WhereParameter.ToString();
            BuildParameterValuesList(WhereParameter);
            _commandText = _commandText.Replace(Constants.INPUT_PARAMETER, _parameterPrefix);
            return ExecuteNonQuery(_commandText, _transaction,false);
        }
        catch (System.Exception ex)
        {
            throw (ex);
        }
    }
    /// <summary>
    /// Deletes a record represented by IDataItem from Table
    /// </summary>
    /// <param name="Item"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    internal virtual Int64 DeleteItem(IDataItem Item)
    {
        try
        {
            _commandText = Constants.SQL_DELETE + Constants.SQL_FROM;
            _commandText += GetFullDataEntityName();
            _commandText += Constants.SQL_WHERE; 
            _commandText += GetKeysList(Item);
            BuildIDataItemParameterValuesList(Item);
            return ExecuteNonQuery(_commandText, _transaction,false);
        }
        catch (System.Exception ex)
        {
            throw (ex);
        }
    }
    /// <summary>
    /// Elimina todos los registros de la base, con opcion a ejecutar un 'Truncate'.
    /// </summary>
    /// <param name="Truncate"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    internal virtual Int64 Clear(bool truncate)
    {
        try
        {
            if (truncate)
            {
                 _commandText = Constants.SQL_TRUNCATE_TABLE;
            }
            else
            {
                 _commandText = Constants.SQL_DELETE + Constants.SQL_FROM;
            }
            _commandText += GetFullDataEntityName();
            return ExecuteNonQuery(_commandText, _transaction,false);
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Updates a record in Table represented by IDataItem DataEntity
    /// </summary>
    /// <param name="Item"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    internal virtual Int64 Update(IDataItem Item)
    {
        try
        {
            _commandText = Constants.SQL_UPDATE;
            _commandText += GetFullDataEntityName();
            _commandText += Constants.SQL_SET + GetSetList(Item);
            _commandText += Constants.SQL_WHERE;
            _commandText += GetKeysList(Item);
            BuildIDataItemParameterValuesList(Item, true);
            return ExecuteNonQuery(_commandText, _transaction,false);
        }
        catch (System.Exception ex)
        {
            throw (ex);
        }
    }
    /// <summary>
    /// Begins a Transaction.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public new IDbTransaction BeginTransaction()
    {
        try
        {
            if (_connection == null)
            {
                GetConnection();
                _transaction = _connection.BeginTransaction();
                return _transaction;
            }
            else
            {
                throw (new Exception("Transaction already opened"));
            }
        }
        catch (System.Exception ex)
        {
            throw (ex);
        }
    }
    /// <summary>
    /// Ends a Transaction with commit  or rollback passed as boolean.
    /// </summary>
    /// <param name="Commit"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public new bool EndTransaction(bool Commit)
    {
        try
        {
            if (_connection == null)
            {
                throw (new Exception("Transaction not opened yet"));
            }
            else
            {
                if (Commit)
                {
                    _transaction.Commit();
                }
                else
                {
                    _transaction.Rollback();
                }
                _connection.Close();
                _connection = null;
                _transaction = null;
                return true;
            }
        }
        catch (System.Exception ex)
        {
            throw (ex);
        }
    }
}
