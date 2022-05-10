CREATE TABLE [Seguridad].[TipoAplicacion] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (50)  NOT NULL,
    [Descripcion]         VARCHAR (50)  NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_TipoAplicacion_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_TipoAplicacion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TipoAplicacion_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id])
);

