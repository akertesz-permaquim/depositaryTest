CREATE TABLE [Seguridad].[Usuario] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (200) NOT NULL,
    [Apellido]            VARCHAR (200) NOT NULL,
    [Legajo]              VARCHAR (50)  CONSTRAINT [DF_Usuario_Legajo] DEFAULT ('') NOT NULL,
    [Mail]                VARCHAR (200) CONSTRAINT [DF_Usuario_Mail] DEFAULT ('') NOT NULL,
    [FechaIngreso]        SMALLDATETIME CONSTRAINT [DF_Usuario_FechaIngreso] DEFAULT (getdate()) NOT NULL,
    [NickName]            VARCHAR (50)  CONSTRAINT [DF_Usuario_NickName] DEFAULT ('') NOT NULL,
    [Password]            VARCHAR (50)  CONSTRAINT [DF_Usuario_Password] DEFAULT ('') NOT NULL,
    [Token]               VARCHAR (200) CONSTRAINT [DF_Usuario_Token] DEFAULT ('') NULL,
    [Avatar]              VARCHAR (MAX) CONSTRAINT [DF_Usuario_Avatar] DEFAULT ('') NULL,
    [FechaUltimoLogin]    SMALLDATETIME CONSTRAINT [DF_Usuario_UltimaFechaLogin] DEFAULT (getdate()) NOT NULL,
    [DebeCambiarPassword] BIT           CONSTRAINT [DF_Usuario_DebeCambiarPassword] DEFAULT ((1)) NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Usuario_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF_Usuario_UsuarioCreacion] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF_Usuario_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF_Usuario_UsuarioModificacion] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF_Usuario_FechaModificacion] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Usuario_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id])
);

