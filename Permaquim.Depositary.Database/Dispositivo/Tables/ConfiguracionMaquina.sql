CREATE TABLE [Dispositivo].[ConfiguracionMaquina] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [TipoId]              BIGINT        NOT NULL,
    [MaquinaId]           BIGINT        NOT NULL,
    [Valor]               VARCHAR (500) NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_configuracionMaquina_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__configura__Usuar__3335971A] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__configura__Fecha__3429BB53] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__configura__Usuar__351DDF8C] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__configura__Fecha__361203C5] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_configuracionMaquina] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ConfiguracionMaquina_Maquina] FOREIGN KEY ([MaquinaId]) REFERENCES [Dispositivo].[Maquina] ([Id]),
    CONSTRAINT [FK_ConfiguracionMaquina_TipoConfiguracionMaquina] FOREIGN KEY ([TipoId]) REFERENCES [Dispositivo].[TipoConfiguracionMaquina] ([Id])
);

