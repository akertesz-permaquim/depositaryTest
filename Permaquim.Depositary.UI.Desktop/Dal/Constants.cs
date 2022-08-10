using System;
public class Constants {
    #region DataType Constants
         internal const string SYSTEM_STRING = "System.String";
         internal const string SYSTEM_DATETIME = "System.DateTime";
         internal const string SYSTEM_BOOLEAN = "System.Boolean";
         internal const string SYSTEM_OBJECT = "System.Object";
         internal const string SYSTEM_COLLECTIONS = "System.Collections";
    #endregion
    #region Parameter Constants
         internal const string INPUT_PARAMETER = "INPUT_PARAMETER";
         internal const string OUTPUT_PARAMETER = "OUTPUT_PARAMETER";
    #endregion
    #region Configuration Constants
         internal const string ADONETASSEMBLYNAME = "AdoNetAssemblyName";
         internal const string PASSWORDKEY = "PasswordKey";
         internal const string ADONETCONNECTIONTYPENAME = "AdoNetConnectionTypeName";
         internal const string ADONETCOMMANDTIMEOUT = "AdoNetCommandTimeout";
         internal const string CONNECTIONSTRING = "ConnectionString";
         internal const string PARAMETERPREFIX = "ParameterPrefix";
         internal const string PKFUNCTION = "PkFunction";
         internal const string NEWID = "@newId";
    #endregion
    #region CustomProperties Constants
         internal const string DATAITEMATTRIBUTESCHEMANAME = "DataItemAttributeSchemaName";
         internal const string DATAITEMATTRIBUTEOBJECTTYPE = "DataItemAttributeObjectType";
         internal const string DATAITEMATTRIBUTEOBJECTNAME = "DataItemAttributeObjectName";
         internal const string DATAITEMATTRIBUTEFIELDNAME = "DataItemAttributeFieldName";
         internal const string PROPERTYATTRIBUTE = "PropertyAttribute";
    #endregion
    #region reflection custom attributes Constants
         internal const string SYSTEM_SERIALIZABLEATTRIBUTE = "System.SerializableAttribute";
    #endregion
    #region SQL syntax Constants
         internal const string SQL_EXEC = "EXEC ";
         internal const string SQL_SELECT = " SELECT ";
         internal const string SQL_UPDATE = " UPDATE ";
         internal const string SQL_DELETE = " DELETE ";
         internal const string SQL_FROM = " FROM ";
         internal const string SQL_WHERE = " WHERE ";
         internal const string SQL_SET = " SET ";
         internal const string SQL_TRUNCATE_TABLE = " TRUNCATE TABLE ";
         internal const string SQL_INSERT_INTO = " INSERT INTO ";
         internal const string SQL_VALUES = " VALUES ";
         internal const string SQL_AND = " AND ";
    #endregion
    #region Error Constants
         internal const string ERROR_CONSTRUCTOR = "DataHandler (constructor) : Transaction assignment Error.";
         internal const string ERROR_TRANSACTION_ALREADY_OPENED = "Transaction already opened";
         internal const string ERROR_TRANSACTION_NOT_OPENED_YET = "Transaction not opened yet";
    #endregion
}
