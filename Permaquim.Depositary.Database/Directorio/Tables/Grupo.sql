CREATE TABLE [Directorio].[Grupo] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (100) NOT NULL,
    [Descripcion]         VARCHAR (500) NOT NULL,
    [FechaCreacion]       SMALLDATETIME NOT NULL,
    [FechaModificacion]   SMALLDATETIME NOT NULL,
    [UsuarioCreacion]     BIGINT        NOT NULL,
    [UsuarioModificacion] BIGINT        NOT NULL,
    [CodigoExterno]       VARCHAR (100) NOT NULL,
    [Habilitado]          BIT           NOT NULL,
    CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

