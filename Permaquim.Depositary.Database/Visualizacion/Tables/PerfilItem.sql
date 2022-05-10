CREATE TABLE [Visualizacion].[PerfilItem] (
    [Id]                  BIGINT   NOT NULL,
    [PerfilId]            BIGINT   NOT NULL,
    [IdTablaReferencia]   BIGINT   NOT NULL,
    [Habilitado]          BIT      NULL,
    [FechaCreacion]       DATETIME NULL,
    [FechaModificacion]   DATETIME NULL,
    [UsuarioCreacion]     BIGINT   NULL,
    [UsuarioModificacion] BIGINT   NULL,
    CONSTRAINT [PK_PerfilItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PerfilItem_Perfil] FOREIGN KEY ([PerfilId]) REFERENCES [Visualizacion].[Perfil] ([Id])
);

