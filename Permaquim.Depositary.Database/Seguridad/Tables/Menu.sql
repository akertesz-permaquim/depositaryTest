CREATE TABLE [Seguridad].[Menu] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Tipo_Id]             BIGINT        NOT NULL,
    [Nombre]              VARCHAR (50)  NOT NULL,
    [Descripcion]         VARCHAR (50)  NOT NULL,
    [Funcion_Id]          BIGINT        NULL,
    [Imagen]              VARCHAR (MAX) CONSTRAINT [DF_Menu_Imagen] DEFAULT ('') NOT NULL,
    [DependeDe]           BIGINT        NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Menu_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__Menu__UsuarioCre__6BE40491] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__Menu__FechaCreac__6CD828CA] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__Menu__UsuarioMod__6DCC4D03] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__Menu__FechaModif__6EC0713C] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Menu_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id]),
    CONSTRAINT [FK_Menu_Funcion] FOREIGN KEY ([Funcion_Id]) REFERENCES [Seguridad].[Funcion] ([Id]),
    CONSTRAINT [FK_Menu_Menu] FOREIGN KEY ([DependeDe]) REFERENCES [Seguridad].[Menu] ([Id]),
    CONSTRAINT [FK_Menu_TipoMenu] FOREIGN KEY ([Tipo_Id]) REFERENCES [Seguridad].[TipoMenu] ([Id])
);

