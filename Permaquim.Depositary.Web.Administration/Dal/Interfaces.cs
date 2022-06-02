using System.Data;
public interface IDataHandler{ IDbTransaction GetTransaction(); }
public interface IDataItem  { }
public interface IDataField  { }
public interface IRelationsDataITem : IDataItem { }
public interface IMappedProcedure { }
