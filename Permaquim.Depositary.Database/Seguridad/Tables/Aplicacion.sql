CREATE TABLE [Seguridad].[Aplicacion] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Tipo_Id]             BIGINT        NOT NULL,
    [Nombre]              VARCHAR (50)  NOT NULL,
    [Descripcion]         VARCHAR (50)  NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Aplicacion_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Aplicacion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Aplicacion_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id]),
    CONSTRAINT [FK_Aplicacion_TipoAplicacion] FOREIGN KEY ([Tipo_Id]) REFERENCES [Seguridad].[TipoAplicacion] ([Id])
);

