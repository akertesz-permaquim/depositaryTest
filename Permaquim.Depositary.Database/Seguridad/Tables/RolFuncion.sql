CREATE TABLE [Seguridad].[RolFuncion] (
    [Id]                  SMALLINT      IDENTITY (0, 1) NOT NULL,
    [Funcion_Id]          BIGINT        NOT NULL,
    [Rol_Id]              BIGINT        NOT NULL,
    [Descripcion]         VARCHAR (50)  NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_RolAplicacionFuncion_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_RolAplicacionFuncion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RolAplicacionFuncion_AplicacionFuncion] FOREIGN KEY ([Funcion_Id]) REFERENCES [Seguridad].[Funcion] ([Id]),
    CONSTRAINT [FK_RolAplicacionFuncion_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id]),
    CONSTRAINT [FK_RolAplicacionFuncion_Rol] FOREIGN KEY ([Rol_Id]) REFERENCES [Seguridad].[Rol] ([Id])
);

