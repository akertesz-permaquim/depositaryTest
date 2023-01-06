using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Reflection;
public class DataHandlerBase: IDataHandler, IDisposable
{
    #region Local Variables
    protected string _commandText = null;
    protected string _fieldList = string.Empty;
    protected string _valueList = string.Empty;
    protected string _adoNetAssemblyName = string.Empty;
    protected string _adoNetConnectionTypeName = string.Empty;
    protected string _parameterPrefix = string.Empty;
    protected string _connectionString = string.Empty;
    protected Int32 _commandTimeout = 30;
    /// List of parameters to hold DataItem Values information
    /// </summary>
    protected List<ParameterItemValue> _parameterizedValues = new List<ParameterItemValue>();
    #endregion
    #region Local interfaces
        protected IDataItem _dataItem = null;
        protected List<IDataItem> _itemList = new List<IDataItem>();
    #endregion
    #region ADO.NET Interfaces
        protected IDbConnection _connection = null;
        protected IDbCommand _command = null;
        protected IDbTransaction _transaction { get; set; }
        protected IDataReader _datareader { get; set; }
    #endregion
    /// <summary>
    /// Represents Where condition list
    /// </summary>
    internal WhereParameterBase WhereParameter {get;set;}
    /// <summary>
    /// Represents Order By parameters
    /// </summary>
    internal OrderByParameterBase OrderByParameter  {get;set;}
    /// <summary>
    /// Represents Group By parameters
    /// </summary>
    internal GroupByParameterBase GroupByParameter  {get;set;}
    /// <summary>
    /// Represents aggregate parameter
    /// </summary>
    internal AggregateParameterBase AggregateParameter {get;set;}
    /// <summary>
    /// Reflection cache data
    /// </summary>
	#region Reflection data
		private Type _dataItemType = null;
		private PropertyInfo[] _properties = null;
		private System.Attribute _objectSchemaTypeAttribute = null;
		private System.Attribute _objectNameTypeAttribute = null;
	#endregion
    /// <summary>
    /// These are field definitions stores as Custom Attributes in Entities
    /// and are loaded with Reflection
    /// </summary>
    protected List<DataFieldDefinition> _dataFieldDefinitions = new List<DataFieldDefinition>();
    private bool disposedValue;
    /// <summary>
    /// No constructor
    /// </summary>
    public DataHandlerBase()
        : base()
    {
        WhereParameter = new WhereParameterBase();
        OrderByParameter = new OrderByParameterBase();
        GroupByParameter = new GroupByParameterBase();
        getAssembliesNames();
    }
    /// <summary>
    /// Constructor with IDataItem
    /// </summary>
    public DataHandlerBase(IDataItem dataItem)
        : base()
    {
        WhereParameter = new WhereParameterBase();
        OrderByParameter = new OrderByParameterBase();
        GroupByParameter = new GroupByParameterBase();
        _dataItem = dataItem;
        AnalizeIDataItem();
        getAssembliesNames();
    }
    /// <summary>
    /// Constructor to handle Transaction by reflection
    /// IDataHandler has Connection and dataItem intrinsic information
    /// </summary>
    /// <remarks></remarks>
    public DataHandlerBase(IDataHandler dataHandler)
        : base()
    {
        try
        {
             WhereParameter = new WhereParameterBase();
			    OrderByParameter = new OrderByParameterBase();
             GroupByParameter = new GroupByParameterBase();
            //_transaction = dataHandler.GetTransaction(); // Gets IDataHandler transaction
			//_dataItem = dataHandler._dataItem; // Gets IDataHandler IdataItem
        }
        catch (Exception)
        {
            throw (new Exception(Constants.ERROR_CONSTRUCTOR));
        }
    }
    /// <summary>
    /// Returns working transaction
    /// </summary>
    /// <returns></returns>
    IDbTransaction IDataHandler.GetTransaction()
    {
        return _transaction;
    }
	/////////////// Este bloque es para analizar y cachear los datos del IDataItem //////////////////////
    /// <summary>
    /// Gets IdataItem reflection information and set corresponding variables.
    /// </summary>
    /// <returns></returns>	
   private void AnalizeIDataItem()
    {
        if (_dataItemType == null)
        {
            _dataItemType = _dataItem.GetType();
            _properties = _dataItemType.GetProperties();
            //Gets the Schema Name of the IDataItem
            Type DataItemAttributeSchemaNameType = typeof(DataItemAttributeSchemaName);
            //Gets the Object Name of the IDataItem
            Type DataItemAttributeObjectNameType = typeof(DataItemAttributeObjectName);
            Type PropertyAttribute = typeof(PropertyAttribute);
            Type PropertyAttributeEnum = typeof(PropertyAttribute.PropertyAttributeEnum);
            for (int i = 0; i < (((System.Reflection.MemberInfo)(_dataItemType))).GetCustomAttributes(false).Length; i++)
            {
                switch ((((System.Reflection.MemberInfo)(_dataItemType))).GetCustomAttributes(false)[i].ToString())
                {
                    case Constants.SYSTEM_SERIALIZABLEATTRIBUTE:
                        break;
                    case Constants.DATAITEMATTRIBUTESCHEMANAME:
                        _objectSchemaTypeAttribute = (DataItemAttributeSchemaName)(((System.Reflection.MemberInfo)(_dataItemType))).GetCustomAttributes(false)[i];
                        break;
                    case Constants.DATAITEMATTRIBUTEOBJECTTYPE:
                        break;
                    case Constants.DATAITEMATTRIBUTEOBJECTNAME:
                        _objectNameTypeAttribute = (DataItemAttributeObjectName)(((System.Reflection.MemberInfo)(_dataItemType))).GetCustomAttributes(false)[i];
                        break;
                    default:
                        break;
                }
            }
            foreach (PropertyInfo info in _properties)
            {
                bool isPk = false;
                bool isAuto = false;
                bool isKey = false;
                bool isFk = false;
                bool isDp = false;
                bool isNone = false;
                bool exclude = false;
                bool isComputed = false;
                String fieldName = String.Empty;
                String fieldFrameworkName = String.Empty;
                int customAttributesCount = info.GetCustomAttributes(false).GetLength(0);
                for (int i = 0; i < customAttributesCount; i++)
                {
                    if ( info.GetCustomAttributes(false)[i].GetType().Name.Equals(Constants.PROPERTYATTRIBUTE))
                    {
                        switch (((PropertyAttribute)(info.GetCustomAttributes(false)[i]))._propertyAttribute)
                        {
                            case global::PropertyAttribute.PropertyAttributeEnum.Pk:
                                isPk = true;
                                break;
                            case global::PropertyAttribute.PropertyAttributeEnum.Auto:
                                isAuto = true;
                                break;
                            case global::PropertyAttribute.PropertyAttributeEnum.Key:
                                isKey = true;
                                break;
                            case global::PropertyAttribute.PropertyAttributeEnum.Fk:
                                isFk = true;
                                break;
                            case global::PropertyAttribute.PropertyAttributeEnum.Display:
                                isDp = true;
                                break;
                            case global::PropertyAttribute.PropertyAttributeEnum.None:
                                isNone = true;
                                break;
                            case global::PropertyAttribute.PropertyAttributeEnum.Exclude:
                                exclude = true;
                                break;
                            case global::PropertyAttribute.PropertyAttributeEnum.Computed:
                                isComputed = true;
                                break;
                            default:
                                break;
                        }
                    }
                    fieldName = info.Name;
                    if (info.GetCustomAttributes(false)[i].GetType().Name.Equals(Constants.DATAITEMATTRIBUTEFIELDNAME))
                    {
                        fieldName = ((DataItemAttributeFieldName)(info.GetCustomAttributes(false)[i])).FieldName;
                        fieldFrameworkName = ((DataItemAttributeFieldName)(info.GetCustomAttributes(false)[i])).FieldFrameworkName;
                    }
                }
                 if(!exclude)
                     _dataFieldDefinitions.Add(new DataFieldDefinition(fieldName, fieldFrameworkName,(info.PropertyType).FullName, isPk,isAuto, isKey, isFk, isDp,isNone,exclude, isComputed));
            }
        }
    }
	/// <summary>
    /// Returns [Schema name].[Object name] eg.: [dbo].[User]
    /// </summary>
    /// <returns></returns>
	protected String GetFullDataEntityName()
	{
        AnalizeIDataItem();
        if (((DataItemAttributeSchemaName)_objectSchemaTypeAttribute).schemaName.Equals(String.Empty))
		        return  "[" + ((DataItemAttributeObjectName)_objectNameTypeAttribute).ObjectName + "]";
        else 
		        return  "[" + ((DataItemAttributeSchemaName)_objectSchemaTypeAttribute).schemaName + "]" +
		         ".[" + ((DataItemAttributeObjectName)_objectNameTypeAttribute).ObjectName + "]";
	}
	/// <summary>
    /// Returns field list separated by colon eg.: "[Id],[Name],[Description]"
    /// </summary>
    /// <returns></returns>
	protected String GetFieldList(bool includePk, bool includeComputed)
	{
		string result = string.Empty;
        foreach (DataFieldDefinition field in _dataFieldDefinitions)
		{
            if ((!field.IsPk && !field.IsComputed) || (field.IsPk && !field.IsAuto) || (includePk && field.IsPk) || (includeComputed && field.IsComputed))
                result += "[" + field.Name + "]" + ",";
		}
		return result.Substring(0, result.Length - 1);	
	}
    /// <summary>
    /// Returns parametrized values list : @Id, @Name,@Description
    /// </summary>
    /// <param name="includePk"></param>
    /// <returns></returns>
    protected String GetParameterizedValuesList(bool includePk, bool includeComputed)
    {
        string result = string.Empty;
        foreach (DataFieldDefinition field in _dataFieldDefinitions)
        {
            if ((!field.IsPk && !field.IsComputed) || (field.IsPk && !field.IsAuto) || (includePk && field.IsPk) || (includeComputed && field.IsComputed))
                result += _parameterPrefix + field.Name + ",";
        }
        return result.Substring(0, result.Length - 1);
    }
    /// <summary>
    /// Builds Parameter Values list eg.: "@Id,@Name'" for select based on parameters
    /// </summary>
    /// <returns></returns>
    protected void BuildParameterValuesList(WhereParameterBase item)
    {
        _parameterizedValues.Clear();
        foreach (ParameterItem field in item._whereParameters)
        {
            if(field.IsFieldParameter)
            {
                 foreach (ParameterItemValue value in field.Values)
                 {
                     _parameterizedValues.Add(new ParameterItemValue(value.Name.Replace(Constants.INPUT_PARAMETER, _parameterPrefix), value.Value));
                 }
            }
        }
    }	
    /// <summary>
    /// Builds Parameter Values list eg.: "@Id,@Name'" for select based on IDataItem parameters
    /// </summary>
    /// <returns></returns>
    protected void BuildIDataItemParameterValuesList(IDataItem item,bool includeNonPk = false)
    {
        _parameterizedValues.Clear();
        _dataItem = item;
        AnalizeIDataItem();
        foreach (DataFieldDefinition field in _dataFieldDefinitions)
        {
            if(field.IsPk)
            {
                var pkValue = item.GetType().GetProperty(field.Name).GetValue(item, null);
                _parameterizedValues.Add(new ParameterItemValue(field.Name.Replace(Constants.INPUT_PARAMETER, _parameterPrefix), pkValue));
            }
            if (!field.IsPk && includeNonPk)
            {
                var pkValue = item.GetType().GetProperty(field.Name).GetValue(item, null);
                _parameterizedValues.Add(new ParameterItemValue(field.Name.Replace(Constants.INPUT_PARAMETER, _parameterPrefix), pkValue));
            }
        }
    }	
    /// <summary>
    /// Builds Parameter Values list eg.: "@Id,@Name'" for Insert
    /// </summary>
    /// <returns></returns>
	protected void BuildParameterValuesList(IDataItem item)
	{
        _parameterizedValues.Clear();
       
        foreach (DataFieldDefinition field in _dataFieldDefinitions)
		{
            if (!field.IsPk || (field.IsPk && !field.IsAuto))
            {
                var memberData = item.GetType().GetProperty(field.Name).GetValue(item, null);
                _parameterizedValues.Add(new ParameterItemValue( _parameterPrefix + field.Name, memberData));
            }
		}
		
	}	
	/// <summary>
    /// Returns set list separated by colon eg.: "[Id] = @Id,[Name] = @Name,[Description] = @Description"
    /// </summary>
    /// <returns></returns>
	
	protected String GetSetList(IDataItem item)
	{
		string result = string.Empty;
        foreach (DataFieldDefinition field in _dataFieldDefinitions)
        {
            if (!field.IsPk && !field.IsComputed)
            {
				result += "[" + field.Name + "]" + " = " + _parameterPrefix + field.Name + ",";
            }
        }
		return result.Substring(0, result.Length - 1);	
	}
	/// <summary>
    /// Returns keys list separated by colon eg.: "[Id] = @Id AND [Code] = @Code"
    /// </summary>
    /// <returns></returns>
    protected String GetKeysList(IDataItem item)
	{
		string result = String.Empty;
		foreach (DataFieldDefinition field in _dataFieldDefinitions)
		{
            if (field.IsPk || field.IsKey)
			{
				result += "[" + field.Name + "]" + " = " + _parameterPrefix + field.Name + Constants.SQL_AND;
			}
		}
		return result.Substring(0, result.Length - 5);	
	}
    /// <summary>
    /// Begins a Transaction.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    internal virtual IDbTransaction BeginTransaction()
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
                throw (new Exception(Constants.ERROR_TRANSACTION_ALREADY_OPENED));
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
    internal virtual bool EndTransaction(bool Commit)
    {
        try
        {
            if (_connection == null)
            {
                throw (new Exception(Constants.ERROR_TRANSACTION_NOT_OPENED_YET));
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
    protected void GetConnection()
    {
        if (_transaction != null)
        {
             _connection = _transaction.Connection;
        }
        else
        {
             if (_connection == null)
             {
                 getAssembliesNames();
                 // Create a  connection of the type
                 _connection = (IDbConnection)Activator.CreateInstance(_adoNetAssemblyName, _adoNetConnectionTypeName).Unwrap();
                 // Retrieve the Connection String    
                 _connection.ConnectionString = DepositaryWebApi.Crypto.Decrypt(ConfigurationHandler.ConnectionString ,ConfigurationHandler.PasswordKey);
                 _connection.Open();
              }
        }
    }
    protected IDbCommand GetCommand(string query, IDbConnection connection, IDbTransaction transaction, CommandType commandType = CommandType.Text)
    {
        getAssembliesNames();
        IDbCommand newCommand = connection.CreateCommand();
        newCommand.CommandText = query;
        newCommand.Connection = connection;
        newCommand.Transaction = transaction;
        newCommand.CommandType = commandType;
        newCommand.CommandTimeout = _commandTimeout;
        foreach (ParameterItemValue parameterValue in _parameterizedValues)
		{
			    IDbDataParameter parameter = newCommand.CreateParameter();
			    parameter.ParameterName = parameterValue.Name;
			    parameter.Value = parameterValue.Value == null ? DBNull.Value : parameterValue.Value;
			    newCommand.Parameters.Add(parameter);
		}		
        return newCommand;
    }
    protected void getAssembliesNames()
    {
        if (_adoNetAssemblyName.Equals(String.Empty) || _adoNetConnectionTypeName.Equals(String.Empty))
        {
             _adoNetAssemblyName = ConfigurationHandler.AdoNetAssemblyName;
             _adoNetConnectionTypeName = ConfigurationHandler.AdoNetConnectionTypeName;
             _commandTimeout = ConfigurationHandler.AdoNetCommandTimeout;
             _parameterPrefix = ConfigurationHandler.ParameterPrefix;
        }
    }
    protected IDataReader ExecuteReader(String query, IDbTransaction transaction, CommandType commandType = CommandType.Text)
    {
        try
        {
            GetConnection();
            _command = GetCommand(query, _connection, transaction,commandType);
		
            return _command.ExecuteReader();
        }
        catch (Exception sqlExeption)
        {
            throw sqlExeption;
        }
    }
    protected Int64 ExecuteNonQuery(String query, IDbTransaction transaction,bool addOutputParameter)
    {
        try
        {
            GetConnection();
            _command = GetCommand(query, _connection, transaction);
            if (addOutputParameter)
            {
                IDbDataParameter outputParam = _command.CreateParameter();
                outputParam.ParameterName = Constants.NEWID;
                outputParam.Direction = ParameterDirection.Output;
                outputParam.Size = Int32.MaxValue;
                _command.Parameters.Add(outputParam); 
            }
            if(_connection.State == ConnectionState.Closed)
                 _connection.Open();
            return _command.ExecuteNonQuery();
        }
        catch (Exception sqlExeption)
        {
            throw sqlExeption;
        }
        finally
        {
            if(_connection.State != ConnectionState.Closed && transaction == null)
                 _connection.Close();
        }
    }
    protected string GetPkName()
    {
        string returnValue = string.Empty;
        foreach (var item in _dataFieldDefinitions)
        {
            if (item.IsPk)
                returnValue =  item.Name;
        }
        return returnValue;
    }
    /// <summary>
    /// Maps DataReader data to DataItem entity with reflection.
    /// </summary>
    /// <param name="dr"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    protected virtual List<IDataItem> MapDataReaderToDataItem<IDataItem>(IDataReader dr, IDataItem dataItem) //where IDataItem : new()
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
                PropertyInfo info = (PropertyInfo)hashtable[_dataFieldDefinitions[index].Name];
                if ((info != null) && info.CanWrite)
                {
                     if (!dr.GetValue(index).Equals(System.DBNull.Value))
                         info.SetValue(newObject, dr.GetValue(index), null);
                }
            }
            entities.Add(newObject);
        }
        dr.Close();
        return entities;
    }
 
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                _itemList = null;
                _fieldList = null;
                _dataItem = null;
            }
 
            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _connection = null;
            _command = null;
            _transaction = null;
            _datareader = null;
 
            disposedValue = true;
        }
    }
 
    void IDisposable.Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
