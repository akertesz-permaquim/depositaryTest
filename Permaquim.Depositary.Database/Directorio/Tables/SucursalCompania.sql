CREATE TABLE [Directorio].[SucursalCompania] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (50)  NOT NULL,
    [Descripcion]         VARCHAR (500) NOT NULL,
    [CompaniaId]          BIGINT        NOT NULL,
    [FechaCreacion]       DATETIME      NOT NULL,
    [FechaModificacion]   DATETIME      NOT NULL,
    [UsuarioCreacion]     BIGINT        NOT NULL,
    [UsuarioModificacion] BIGINT        NOT NULL,
    [CodigoExterno]       VARCHAR (50)  NOT NULL,
    [Direccion]           VARCHAR (500) NOT NULL,
    [CodigoPostalId]      BIGINT        NOT NULL,
    [Habilitado]          BIT           NOT NULL,
    CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sucursal_CodigoPostal] FOREIGN KEY ([CodigoPostalId]) REFERENCES [Sig].[CodigoPostal] ([Id]),
    CONSTRAINT [FK_SucursalCompania_Compania] FOREIGN KEY ([CompaniaId]) REFERENCES [Directorio].[Compania] ([Id])
);

