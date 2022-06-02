using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace DepositarioAdminWeb {
public class sqlEnum
{
    public enum OperandEnum
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Like,
        NotLike,
        IsNull,
        IsNotNull,
        Between,
        In,
        NotIn
    }
    public enum DirEnum
    {
        ASC,
        DESC
    }
    public enum ConjunctionEnum
    {
        AND,
        OR
    }
    public enum FunctionEnum
    {
        Avg = 1,
        Count,
        Max,
        Min,
        StdDev,
        Var,
        Sum
    }
 }
}
/// <summary>
/// Clase DataField - Fecha de Creación : lunes, 07 de octubre de 2013
/// </summary>
/// <remarks> Representa una consulta de Funciones de agregación. </remarks>
public class DataField
{
    private string _name;
    private object _value;
    public DataField(string Name, object Value)
    {
        _name = Name;
        _value = Value;
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public object Value
    {
        get { return _value; }
        set { _value = value; }
    }
}
