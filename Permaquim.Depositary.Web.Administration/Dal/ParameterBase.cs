using System;
using System.Collections.Generic;
public class ParameterItem
{
    public string Column { get; set; }
    public string Operand { get; set; }
    public string Name { get; set; }
    public List<ParameterItemValue> Values { get; set; }
    public string FullQuery { get; set; }
    public bool IsFieldParameter { get; set; } = true;
    public ParameterItem(String fullQuery, bool isFieldParameter = true)
    {
        FullQuery = fullQuery;
        IsFieldParameter = isFieldParameter;
    }
    public ParameterItem(string fullQuery, string column, string operand, string name, List<ParameterItemValue> values, bool isFieldParameter = true)
    {
        Operand = operand;
        Values = values;
        Name = name;
        FullQuery = fullQuery;
        IsFieldParameter = isFieldParameter;
    }
}
public class ParameterItemValue
{
    public string Name { get; set; }
    public object Value { get; set; }
    public ParameterItemValue()
    {
    }
    public ParameterItemValue(string name, object value)
    {
        Value = value;
        Name = name;
    }
}
public class WhereParameterBase
{
    public WhereParameterBase()
    {
        _whereParameters = new List<ParameterItem>();
    }
    internal List<ParameterItem> _whereParameters = new List<ParameterItem>();
    private const string _WHERE = " WHERE ";
    private const string _BETWEEN = " BETWEEN ";
    private const string _EQUAL = " = ";
    private const string _GREATER_THAN = " > ";
    private const string _GREATER_THAN_OR_EQUAL = " >= ";
    private const string _IN_ = " IN ";
    private const string _IS_NOT_NULL = " IS NOT NULL ";
    private const string _IS_NULL = " IS NULL ";
    private const string _LESS_THAN = " < ";
    private const string _LESS_THAN_OR_EQUAL = " <= ";
    private const string _LIKE = " LIKE ";
    private const string _NOT_EQUAL = " <> ";
    private const string _NOT_IN = " NOT IN ";
    private const string _NOT_LIKE = " NOT LIKE ";
    private int counter = -1;
    protected int GetNextParameterIndex()
    {
        counter++;
        return counter;
    }
    protected int GetCurrentParameterIndex()
    {
        return counter;
    }
    internal string GetSQL()
    {
        string _buff = String.Empty;
        try
        {
            foreach (ParameterItem parameterItem in _whereParameters)
            {
                _buff += parameterItem.FullQuery;
            }
            if (_buff.Length > 0)
            {
                return _WHERE + _buff;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected string GetOperand(Permaquim.Depositary.sqlEnum.OperandEnum Operand)
    {
        try
        {
            switch (Operand)
            {
                case Permaquim.Depositary.sqlEnum.OperandEnum.Between:
                    return _BETWEEN;
                case Permaquim.Depositary.sqlEnum.OperandEnum.Equal:
                    return _EQUAL;
                case Permaquim.Depositary.sqlEnum.OperandEnum.GreaterThan:
                    return _GREATER_THAN;
                case Permaquim.Depositary.sqlEnum.OperandEnum.GreaterThanOrEqual:
                    return _GREATER_THAN_OR_EQUAL;
                case Permaquim.Depositary.sqlEnum.OperandEnum.In:
                    return _IN_;
                case Permaquim.Depositary.sqlEnum.OperandEnum.IsNotNull:
                    return _IS_NOT_NULL;
                case Permaquim.Depositary.sqlEnum.OperandEnum.IsNull:
                    return _IS_NULL;
                case Permaquim.Depositary.sqlEnum.OperandEnum.LessThan:
                    return _LESS_THAN;
                case Permaquim.Depositary.sqlEnum.OperandEnum.LessThanOrEqual:
                    return _LESS_THAN_OR_EQUAL;
                case Permaquim.Depositary.sqlEnum.OperandEnum.Like:
                    return _LIKE;
                case Permaquim.Depositary.sqlEnum.OperandEnum.NotEqual:
                    return _NOT_EQUAL;
                case Permaquim.Depositary.sqlEnum.OperandEnum.NotIn:
                    return _NOT_IN;
                case Permaquim.Depositary.sqlEnum.OperandEnum.NotLike:
                    return _NOT_LIKE;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void Clear()
    {
        _whereParameters.Clear();
    }
    public Int64 Count
    {
        get { return _whereParameters.Count; }
    }
    public override string ToString()
    {
        return GetSQL();
    }
}
public class OrderByParameterBase
{
    private const string _COLON = ",";
    private const string _ORDER_BY = " ORDER BY ";
    protected List<ParameterItem> _orderByParameters = new List<ParameterItem>();
    internal string GetSQL() // Esto cambia por la iteración de los ParameterItem
    {
        string _buff = String.Empty;
        try
        {
            foreach (ParameterItem param in _orderByParameters)
            {
                _buff += param.FullQuery + _COLON;
            }
            if (_buff != null && _buff.Length > 0)
            {
                return _ORDER_BY + _buff.Substring(0, _buff.Length - 1);
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void Clear()
    {
        _orderByParameters.Clear();
    }
    public long Count
    {
        get { return _orderByParameters.Count; }
    }
    public override string ToString()
    {
        return GetSQL();
    }
}
public class GroupByParameterBase
{
    private const string _COLON = ",";
    private const string _GROUP_BY = " GROUP BY ";
    protected List<ParameterItem> _groupByParameters = new List<ParameterItem>();
    internal string GetSQL() // Esto cambia por la iteración de los ParameterItem
    {
        string _buff = String.Empty;
        try
        {
            foreach (ParameterItem param in _groupByParameters)
            {
                _buff += param.FullQuery + _COLON;
            }
            if (_buff != null && _buff.Length > 0)
            {
                return _GROUP_BY + _buff.Substring(0, _buff.Length - 1);
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void Clear()
    {
        _groupByParameters.Clear();
    }
    public long Count
    {
        get { return _groupByParameters.Count; }
    }
    public override string ToString()
    {
        return GetSQL();
    }
}
public class AggregateParameterBase
{
    private const string _AVG = " AVG ";
    private const string _COUNT = " COUNT ";
    private const string _MAX = " MAX ";
    private const string _MIN = " MIN ";
    private const string _STDEV = " STDEV ";
    private const string _SUM = " SUM ";
    private const string _VAR = " VAR ";
    private const string _COLON = ",";
    protected List<ParameterItem> _aggregateParameters = new List<ParameterItem>();
    protected string GetOperand(Permaquim.Depositary.sqlEnum.FunctionEnum Operand)
    {
        try
        {
            switch (Operand)
            {
                case Permaquim.Depositary.sqlEnum.FunctionEnum.Avg:
                    return _AVG;
                case Permaquim.Depositary.sqlEnum.FunctionEnum.Count:
                    return _COUNT;
                case Permaquim.Depositary.sqlEnum.FunctionEnum.Max:
                    return _MAX;
                case Permaquim.Depositary.sqlEnum.FunctionEnum.Min:
                    return _MIN;
                case Permaquim.Depositary.sqlEnum.FunctionEnum.StdDev:
                    return _STDEV;
                case Permaquim.Depositary.sqlEnum.FunctionEnum.Sum:
                    return _SUM;
                case Permaquim.Depositary.sqlEnum.FunctionEnum.Var:
                    return _VAR;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    internal string GetSQL()
    {
        string _buff = String.Empty;
        try
        {
            foreach (ParameterItem param in _aggregateParameters)
            {
                _buff += param.FullQuery + _COLON;
            }
            if (_buff != null && _buff.Length > 0)
            {
                return _buff.Substring(0, _buff.Length - 1);
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void Clear()
    {
        _aggregateParameters.Clear();
    }
    public long Count
    {
        get { return _aggregateParameters.Count; }
    }
}
public class WhereParameter : WhereParameterBase
{
    public WhereParameter()
        : base()
    {
    }
    internal void Add(String column, Permaquim.Depositary.sqlEnum.OperandEnum operand, dynamic values)
    {
        string operandString = base.GetOperand(operand);
        List<ParameterItemValue> _values = new List<ParameterItemValue>();
        try
        {
            string _buff = String.Empty;
            if (values != null)
            {
                if (values.GetType().ToString().StartsWith(Constants.SYSTEM_COLLECTIONS))
                {
                    foreach (object value in values)
                    {
                        _buff += Constants.INPUT_PARAMETER + GetNextParameterIndex().ToString() + ",";
                        _values.Add(new ParameterItemValue(Constants.INPUT_PARAMETER + GetCurrentParameterIndex().ToString(), value));
                    }
                }
                else
                {
                    _buff += Constants.INPUT_PARAMETER + GetNextParameterIndex().ToString() + ",";
                    _values.Add(new ParameterItemValue(Constants.INPUT_PARAMETER + GetCurrentParameterIndex().ToString(), values));
                }
            }
            switch (operand)
            {
                case Permaquim.Depositary.sqlEnum.OperandEnum.In:
                case Permaquim.Depositary.sqlEnum.OperandEnum.NotIn:
                    if (_buff.Length > 0)
                        _whereParameters.Add(new ParameterItem(column + " " + operandString + " (" + _buff.Substring(0, _buff.Length - 1) + ")", column, operandString, column, _values));
                    break;
                case Permaquim.Depositary.sqlEnum.OperandEnum.IsNull:
                case Permaquim.Depositary.sqlEnum.OperandEnum.IsNotNull:
                    _whereParameters.Add(new ParameterItem(column + " " + operandString, column, operandString, column, _values));
                    break;
                default:
                    if (_buff.Length > 0)
                        _whereParameters.Add(new ParameterItem(column + " " + operandString + " " + _buff.Substring(0, _buff.Length - 1), column, operandString, column, _values));
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    internal void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction, String column, Permaquim.Depositary.sqlEnum.OperandEnum operand, dynamic values)
    {
        string operandString = base.GetOperand(operand);
        List<ParameterItemValue> _values = new List<ParameterItemValue>();
        try
        {
            string _buff = String.Empty;
            if (values != null)
            {
                if (values.GetType().ToString().StartsWith(Constants.SYSTEM_COLLECTIONS))
                {
                    foreach (object value in values)
                    {
                        _buff += Constants.INPUT_PARAMETER + GetNextParameterIndex().ToString() + ",";
                        _values.Add(new ParameterItemValue(Constants.INPUT_PARAMETER + GetCurrentParameterIndex().ToString(), value));
                    }
                }
                else
                {
                    _buff += Constants.INPUT_PARAMETER + GetNextParameterIndex().ToString() + ",";
                    _values.Add(new ParameterItemValue(Constants.INPUT_PARAMETER + GetCurrentParameterIndex().ToString(), values));
                }
            }
            switch (operand)
            {
                case Permaquim.Depositary.sqlEnum.OperandEnum.In:
                case Permaquim.Depositary.sqlEnum.OperandEnum.NotIn:
                    if (_buff.Length > 0)
                        _whereParameters.Add(new ParameterItem(" " + Enum.GetName(typeof(Permaquim.Depositary.sqlEnum.ConjunctionEnum), Conjunction) + " " + column + " " + operandString + " (" + _buff.Substring(0, _buff.Length - 1) + ")", column, operandString, column, _values));
                    break;
                case Permaquim.Depositary.sqlEnum.OperandEnum.IsNull:
                case Permaquim.Depositary.sqlEnum.OperandEnum.IsNotNull:
                    _whereParameters.Add(new ParameterItem(" " + Enum.GetName(typeof(Permaquim.Depositary.sqlEnum.ConjunctionEnum), Conjunction) + " " + column + " " + operandString, column, operandString, column, _values));
                    break;
                default:
                    if (_buff.Length > 0)
                        _whereParameters.Add(new ParameterItem(" " + Enum.GetName(typeof(Permaquim.Depositary.sqlEnum.ConjunctionEnum), Conjunction) + " " + column + " " + operandString + " " + _buff.Substring(0, _buff.Length - 1), column, operandString, column, _values));
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    internal void Add(String betweenColumn, object fromValue, object toValue)
    {
        List<ParameterItemValue> _values = new List<ParameterItemValue>();
        string firstParameter = GetNextParameterIndex().ToString();
        string secondParameter = GetNextParameterIndex().ToString();
        _values.Add(new ParameterItemValue(Constants.INPUT_PARAMETER + firstParameter, fromValue));
        _values.Add(new ParameterItemValue(Constants.INPUT_PARAMETER + secondParameter, toValue));
        try
        {
            _whereParameters.Add(new ParameterItem(betweenColumn + " BETWEEN " + Constants.INPUT_PARAMETER + firstParameter + " AND " + Constants.INPUT_PARAMETER + secondParameter, betweenColumn, "Between", betweenColumn, _values));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    internal void Add(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction, String betweenColumn, object fromValue, object toValue)
    {
        if (_whereParameters.Count > 0)
        {
            List<ParameterItemValue> _values = new List<ParameterItemValue>();
            string firstParameter = GetNextParameterIndex().ToString();
            string secondParameter = GetNextParameterIndex().ToString();
            _values.Add(new ParameterItemValue(Constants.INPUT_PARAMETER + firstParameter, fromValue));
            _values.Add(new ParameterItemValue(Constants.INPUT_PARAMETER + secondParameter, toValue));
            _whereParameters.Add(new ParameterItem(" " + Enum.GetName(typeof(Permaquim.Depositary.sqlEnum.ConjunctionEnum), Conjunction) + " " + betweenColumn + " BETWEEN " + Constants.INPUT_PARAMETER + firstParameter + " AND " + Constants.INPUT_PARAMETER + secondParameter, betweenColumn, "Between", betweenColumn, _values));
        }
        else
        {
            throw new Exception("Add: Overload Error.");
        }
    }
    internal void OpenParentheses()
    {
        _whereParameters.Add(new ParameterItem(Constants.SQL_OPENPARENTHESES, false));
    }
    internal void CloseParentheses()
    {
        _whereParameters.Add(new ParameterItem(Constants.SQL_CLOSEPARENTHESES, false));
    }
    internal void AddConjunction(Permaquim.Depositary.sqlEnum.ConjunctionEnum Conjunction)
    {
        _whereParameters.Add(new ParameterItem(" " + Enum.GetName(typeof(Permaquim.Depositary.sqlEnum.ConjunctionEnum), Conjunction) + " ", false));
    }
}
public class OrderByParameter : OrderByParameterBase
{
    internal void Add(String Column, Permaquim.Depositary.sqlEnum.DirEnum Direction = Permaquim.Depositary.sqlEnum.DirEnum.ASC)
    {
        try
        {
            base._orderByParameters.Add(new ParameterItem(Column + " " + Enum.GetName(typeof(Permaquim.Depositary.sqlEnum.DirEnum), Direction)));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
public class GroupByParameter : GroupByParameterBase
{
    internal void Add(String Column)
    {
        try
        {
            base._groupByParameters.Add(new ParameterItem(Column));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
public class AggregateParameter : AggregateParameterBase
{
    internal void Add(Permaquim.Depositary.sqlEnum.FunctionEnum AggregateFunction, String Column)
    {
        try
        {
            _aggregateParameters.Add(new ParameterItem(GetOperand(AggregateFunction) + "( " + Column + " )"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
