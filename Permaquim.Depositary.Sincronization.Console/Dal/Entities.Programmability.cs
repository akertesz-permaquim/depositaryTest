using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace Permaquim.Depositario.Entities.Procedures.dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("FinalizarPrimeraSincronizacion","FinalizarPrimeraSincronizacion")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class FinalizarPrimeraSincronizacion : IDataItem
			{
				        
				public class ColumnNames
				{
				}
				public enum FieldEnum : int
                {
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public FinalizarPrimeraSincronizacion()
                {
                }
				
			} //Class FinalizarPrimeraSincronizacion 
			
} //namespace Permaquim.Depositario.Entities.Procedures.dbo
