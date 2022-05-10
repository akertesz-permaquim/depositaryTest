CREATE TABLE [Seguridad].[Funcion] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Aplicacion_Id]       BIGINT        NOT NULL,
    [Tipo_Id]             BIGINT        NULL,
    [Nombre]              VARCHAR (50)  NOT NULL,
    [Descripcion]         VARCHAR (50)  NOT NULL,
    [Referencia]          VARCHAR (500) NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_AplicacionFuncion_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_AplicacionFuncion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AplicacionFuncion_Aplicacion] FOREIGN KEY ([Aplicacion_Id]) REFERENCES [Seguridad].[Aplicacion] ([Id]),
    CONSTRAINT [FK_AplicacionFuncion_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id]),
    CONSTRAINT [FK_Funcion_TipoFuncion] FOREIGN KEY ([Tipo_Id]) REFERENCES [Seguridad].[TipoFuncion] ([Id])
);

