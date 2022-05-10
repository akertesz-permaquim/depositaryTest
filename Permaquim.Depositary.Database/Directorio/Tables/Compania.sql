CREATE TABLE [Directorio].[Compania] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (100) NOT NULL,
    [Descripcion]         VARCHAR (500) NOT NULL,
    [GrupoId]             BIGINT        NOT NULL,
    [FechaCreacion]       SMALLDATETIME NOT NULL,
    [FechaModificacion]   SMALLDATETIME NOT NULL,
    [UsuarioCreacion]     BIGINT        NOT NULL,
    [UsuarioModificacion] BIGINT        NOT NULL,
    [CodigoExterno]       VARCHAR (100) NOT NULL,
    [Address]             VARCHAR (150) NOT NULL,
    [CodigoPostalId]      BIGINT        NOT NULL,
    [Habilitado]          BIT           NOT NULL,
    CONSTRAINT [PK_Compania] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Compania_Grupo] FOREIGN KEY ([GrupoId]) REFERENCES [Directorio].[Grupo] ([Id])
);

