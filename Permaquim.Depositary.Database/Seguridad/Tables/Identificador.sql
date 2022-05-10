CREATE TABLE [Seguridad].[Identificador] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [TipoId]              BIGINT        NOT NULL,
    [UsuarioId]           BIGINT        NOT NULL,
    [Valor]               VARCHAR (MAX) NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Identificador_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__Identific__Usuar__05F8DC4F] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__Identific__Fecha__06ED0088] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__Identific__Usuar__07E124C1] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__Identific__Fecha__08D548FA] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Identificador] PRIMARY KEY CLUSTERED ([Id] ASC)
);

