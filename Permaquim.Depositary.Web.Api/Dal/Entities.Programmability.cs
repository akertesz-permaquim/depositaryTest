using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace DepositaryWebApi.Entities.Procedures.Sincronizacion {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("Sincronizacion")]  // Database Schema Name
			[DataItemAttributeObjectName("ObtenerIdDestino","ObtenerIdDestino")]    // Object name  and alias in Database
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)] // Table, Procedures,StoredProcedure,Function
			public class ObtenerIdDestino : IDataItem
			{
				        
				public class ColumnNames
				{
					public const string DestinoId = "DestinoId";
				}
				public enum FieldEnum : int
                {
					DestinoId
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public ObtenerIdDestino()
                {
                }
             [DataItemAttributeFieldName("DestinoId","DestinoId")]
             public Int64? DestinoId { get; set; }
				
			} //Class ObtenerIdDestino 
			
} //namespace DepositaryWebApi.Entities.Procedures.Sincronizacion
