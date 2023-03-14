using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
		namespace Permaquim.Depositario.Entities.Procedures. dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("FinalizarPrimeraSincronizacion","FinalizarPrimeraSincronizacion")]
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)]
			public class FinalizarPrimeraSincronizacion : IDataItem // ResultContainer
			{
			public class Result : IDataItem
				        {
				public class ColumnNames
				{
					public const string Resultado = "Resultado";
				}
				public enum FieldEnum : int
                {
					Resultado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Result()
                {}
             [DataItemAttributeFieldName("Resultado","Resultado")]
             public String Resultado { get; set; }
     }
     }
     }
		namespace Permaquim.Depositario.Entities.Procedures. dbo {
			[Serializable()]                         //
			[DataItemAttributeSchemaName("dbo")]  // Database Schema Name
			[DataItemAttributeObjectName("IniciarPrimeraSincronizacion","IniciarPrimeraSincronizacion")]
			[DataItemAttributeObjectType(DataItemAttributeObjectType.ObjectTypeEnum.Procedure)]
			public class IniciarPrimeraSincronizacion : IDataItem // ResultContainer
			{
			public class Result : IDataItem
				        {
				public class ColumnNames
				{
					public const string Resultado = "Resultado";
				}
				public enum FieldEnum : int
                {
					Resultado
				}
	               /// <summary>
                /// Parameterless Constructor
	               /// <summary>
                public Result()
                {}
             [DataItemAttributeFieldName("Resultado","Resultado")]
             public String Resultado { get; set; }
     }
     }
     }
