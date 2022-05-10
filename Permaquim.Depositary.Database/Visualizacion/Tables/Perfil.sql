CREATE TABLE [Visualizacion].[Perfil] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (100) NOT NULL,
    [Descripcion]         VARCHAR (500) NOT NULL,
    [PerfilTipoId]        BIGINT        NOT NULL,
    [FechaCreacion]       SMALLDATETIME NOT NULL,
    [FechaModificacion]   SMALLDATETIME NOT NULL,
    [UsuarioCreacion]     BIGINT        NOT NULL,
    [UsuarioModificacion] BIGINT        NOT NULL,
    [Habilitado]          BIT           NOT NULL,
    CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Perfil_PerfilTipo] FOREIGN KEY ([PerfilTipoId]) REFERENCES [Visualizacion].[PerfilTipo] ([Id])
);

