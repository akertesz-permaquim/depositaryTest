CREATE TABLE [Dispositivo].[Estado] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (200) NOT NULL,
    [Descripcion]         VARCHAR (500) NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Estado_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED ([Id] ASC)
);

