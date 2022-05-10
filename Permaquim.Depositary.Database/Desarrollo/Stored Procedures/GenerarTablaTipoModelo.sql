-- ==================================================================================
-- Author:		Claudio Cespon
-- Create date: 4/4/2022
-- Description:	Genera un tabla tipo estándar con el patrón de diseño,
-- con identity comenzando en 0, e insertando el correspondiente 'No Especificado'
-- ==================================================================================
CREATE   PROCEDURE [Desarrollo].[GenerarTablaTipoModelo]

		 @Schema VARCHAR(MAX),	-- Nombre del Esquema donde se creará la tabla
		 @Entity VARCHAR(MAX),	-- Nombre de la tabla
		 @CreateSchema BIT = 0, -- Indica si se debe crear el esquema nuevo
		 @EnableCDC BIT = 0		-- Indica si se le debe habilitar el servicionde Change Data Capture

AS
BEGIN
		SET NOCOUNT ON;

		-- El esquema default se aplica para no generar error
		IF @Schema = ''
		BEGIN
			SET @Schema = 'dbo'
		END

		IF NOT EXISTS (SELECT name FROM sys.schemas WHERE name = @Schema)
		BEGIN
			IF @CreateSchema = 1
				BEGIN
					EXEC('CREATE SCHEMA ' + @Schema)
				END
			ELSE
				BEGIN
				DECLARE @Mensaje VARCHAR(MAX) =' El esquema ' + @Schema + ' no existe. Para crearlo indíquelo con el parámetro @CreateSchema = 1'
					 RAISERROR(@Mensaje, 1001, 1)
					 RETURN 
				END
		END

		DECLARE @sql NVARCHAR(MAX)  = 

		'CREATE TABLE [' + @Schema + '].[' + @Entity + '](
			[Id] [bigint] IDENTITY(0,1) NOT NULL,
			[Nombre] [VARCHAR](200) NOT NULL,
			[Descripcion] [VARCHAR](500) NOT NULL,
			[EstadoLogico] [smallint] NOT NULL,
			[UsuarioCreacion] [bigint] NOT NULL,
			[FechaCreacion] [smalldatetime] NOT NULL,
			[UsuarioModificacion] [bigint] NOT NULL,
			[FechaModificacion] [smalldatetime] NOT NULL,
		 CONSTRAINT [PK_' + @Entity + '] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
		) ON [PRIMARY]


		ALTER TABLE [' + @Schema + '].[' + @Entity + '] ADD  CONSTRAINT [DF_' + @Entity + '_EstadoLogico]  DEFAULT ((0)) FOR [EstadoLogico]


		ALTER TABLE [' + @Schema + '].[' + @Entity + '] ADD  DEFAULT ((0)) FOR [UsuarioCreacion]


		ALTER TABLE [' + @Schema + '].[' + @Entity + '] ADD  DEFAULT (getdate()) FOR [FechaCreacion]


		ALTER TABLE [' + @Schema + '].[' + @Entity + '] ADD  DEFAULT ((0)) FOR [UsuarioModificacion]


		ALTER TABLE [' + @Schema + '].[' + @Entity + '] ADD  DEFAULT (getdate()) FOR [FechaModificacion]

		ALTER TABLE [' + @Schema + '].[' + @Entity + ']  WITH CHECK ADD  CONSTRAINT [FK_Seguridad_EstadoLogico] FOREIGN KEY([EstadoLogico])
		REFERENCES [Seguridad].[EstadoLogico] ([Id])


		ALTER TABLE [' + @Schema + '].[' + @Entity + '] CHECK CONSTRAINT [FK_Seguridad_EstadoLogico]'

		PRINT @sql

		IF @EnableCDC = 1
			BEGIN
				EXEC sys.sp_cdc_enable_table 
				@source_schema =@Schema, 
				@source_name = @Entity, 
				@role_name = NULL;
			END

	

 DECLARE @sqlInsert NVARCHAR(MAX) 
		SET @sqlInsert = 'INSERT INTO [' + @Schema + '].[' + @Entity + ']
		([Nombre],[Descripcion],[EstadoLogico],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
		VALUES
		(''No Especificado'',''No Especificado'',0,0,GETDATE(),0,GETDATE())'
		PRINT @sqlInsert


	EXECUTE sp_executesql @sql
	
	EXECUTE sp_executesql @sqlInsert


END
 -- EXEC [Desarrollo].[GenerarTablaTipoModelo] @Schema , @Entity , @CreateSchema,  @EnableCDC 
 -- EXEC [Desarrollo].[GenerarTablaTipoModelo] 'Seguridad' , 'TipoBanco' , 1,  0

