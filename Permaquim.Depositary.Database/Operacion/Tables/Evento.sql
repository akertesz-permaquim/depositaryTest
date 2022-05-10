CREATE TABLE [Operacion].[Evento] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [TipoId]              BIGINT        NOT NULL,
    [Descripcion]         VARCHAR (500) NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Evento_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__Evento__UsuarioC__16644E42] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__Evento__FechaCre__1758727B] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__Evento__UsuarioM__184C96B4] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__Evento__FechaMod__1940BAED] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

