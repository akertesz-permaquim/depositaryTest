CREATE TABLE [Operacion].[TurnoUsuario] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [UsuarioId]           BIGINT        NOT NULL,
    [TurnoId]             BIGINT        NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_TurnoUsuario_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__TurnoUsua__Usuar__6A85CC04] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__TurnoUsua__Fecha__6B79F03D] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__TurnoUsua__Usuar__6C6E1476] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__TurnoUsua__Fecha__6D6238AF] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_TurnoUsuario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

