using System;
public class GenericDataField : IDataField
{
    public GenericDataField(string name, string value)
    {
        try
        {
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
}
public class DataFieldDefinition
{
    public DataFieldDefinition(String name, String frameworkName,String dataTypeName, bool isPk,bool isAuto, bool isKey, bool isFk, bool isDp,bool isNone,bool exclude)
    {
        Name = name;
        FrameworkName = frameworkName;
        DataTypeName = dataTypeName;
        IsPk = isPk;
        IsAuto = isAuto;
        IsKey = isKey;
        IsFk = isFk;
        IsDp = isDp;
        IsNone = isNone;
        Exclude = exclude;
    }
    public String Name { get; set; }
    public String FrameworkName { get; set; }
    public String DataTypeName { get; set; }
    public bool IsPk { get; set; }
    public bool IsAuto { get; set; }
    public bool IsKey { get; set; }
    public bool IsFk { get; set; }
    public bool IsDp { get; set; }
    public bool IsNone { get; set; }
    public bool Exclude { get; set; }
}
