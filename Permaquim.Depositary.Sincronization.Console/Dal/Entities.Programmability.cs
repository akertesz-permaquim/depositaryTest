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
		namespace Permaquim.Depositario.Entities.Procedures.Sincronizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sincronizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerIdOrigen","ObtenerIdOrigen")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerIdOrigen : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string OrigenId = "OrigenId";
				}
				public enum FieldEnum : int
                {
					OrigenId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerIdOrigen()
                {
                }
             [DataItemAttributeFieldName("OrigenId","OrigenId")]
             public Int64? OrigenId { get; set; }
				
			} //Class ObtenerIdOrigen 
			
} //namespace Permaquim.Depositario.Entities.Procedures.Sincronizacion
