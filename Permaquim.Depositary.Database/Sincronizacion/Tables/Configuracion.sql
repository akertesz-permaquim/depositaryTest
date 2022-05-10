CREATE TABLE [Sincronizacion].[Configuracion] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [EntidadId]           BIGINT        NOT NULL,
    [Segundos]            BIGINT        NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Configuracion_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__Configura__Usuar__542C7691] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__Configura__Fecha__55209ACA] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__Configura__Usuar__5614BF03] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__Configura__Fecha__5708E33C] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Configuracion] PRIMARY KEY CLUSTERED ([Id] ASC)
);

