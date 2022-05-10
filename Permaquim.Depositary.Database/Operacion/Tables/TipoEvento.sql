CREATE TABLE [Operacion].[TipoEvento] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (200) NOT NULL,
    [Descripcion]         VARCHAR (500) NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_TipoEvento_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_TipoEvento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

