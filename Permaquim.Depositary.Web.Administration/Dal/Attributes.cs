using System;
/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public class DataItemAttributeSchemaName : Attribute
{
     public string schemaName { get; set; }
        public DataItemAttributeSchemaName(string schemaName)
        {
            this.schemaName = schemaName;
        }
}
/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public class DataItemAttributeObjectName : Attribute
{
    public string ObjectName { get; set; }
    public string ObjectAlias { get; set; }
    public DataItemAttributeObjectName(string objectName, string objectAlias)
    {
        this.ObjectName = objectName;
        this.ObjectAlias = objectAlias;
    }
}
/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public class DataItemAttributeObjectType : Attribute
{
    public enum ObjectTypeEnum
    {
        Table,
        View,
        Procedure,
        Function
    }
    public ObjectTypeEnum objectType { get; set; }
    public DataItemAttributeObjectType(ObjectTypeEnum objectType)
    {
        this.objectType = objectType;
    }
}
/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
public class PropertyAttribute : Attribute
{
    public enum PropertyAttributeEnum
    {
        Pk,
        Auto,
        Fk,
        Key,
        Display,
        Exclude,
        None
    }
    public PropertyAttributeEnum _propertyAttribute { get; set; }
    public PropertyAttribute(PropertyAttributeEnum propertyAttribute)
    {
        this._propertyAttribute = propertyAttribute;
    }
}
/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
public class PropertyAttributeForeignKeyObjectName : Attribute
{
    public string ForeignKeyObjectName { get; set; }
    public PropertyAttributeForeignKeyObjectName(string foreignKeyObjectName)
    {
        this.ForeignKeyObjectName = foreignKeyObjectName;
    }
}
/// <summary>
///   Usage: [DataItemAttributeFieldName("Discontinued,Discontinued")]
/// </summary>
[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
public class DataItemAttributeFieldName : Attribute
{
     public string FieldName { get; set; }
     public string FieldFrameworkName { get; set; }
     public DataItemAttributeFieldName(string fieldName, string fieldFrameworkName)
     {
         this.FieldName = fieldName;
         this.FieldFrameworkName = fieldFrameworkName;
     }
}
