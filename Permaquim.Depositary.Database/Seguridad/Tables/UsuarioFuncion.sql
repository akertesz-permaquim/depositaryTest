CREATE TABLE [Seguridad].[UsuarioFuncion] (
    [Id]                  BIGINT        IDENTITY (1, 1) NOT NULL,
    [Usuario_Id]          BIGINT        NOT NULL,
    [Funcion_Id]          BIGINT        NOT NULL,
    [FechaDesde]          SMALLDATETIME NOT NULL,
    [FechaHasta]          SMALLDATETIME NOT NULL,
    [EstadoLogico]        SMALLINT      NOT NULL,
    [UsuarioCreacion]     BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Usuario_Funcion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Usuario_Funcion_Funcion] FOREIGN KEY ([Funcion_Id]) REFERENCES [Seguridad].[Funcion] ([Id]),
    CONSTRAINT [FK_Usuario_Funcion_Usuario] FOREIGN KEY ([Usuario_Id]) REFERENCES [Seguridad].[Usuario] ([Id])
);

