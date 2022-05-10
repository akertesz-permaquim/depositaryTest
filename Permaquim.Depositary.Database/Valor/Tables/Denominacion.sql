CREATE TABLE [Valor].[Denominacion] (
    [Id]                  BIGINT          IDENTITY (0, 1) NOT NULL,
    [ValorId]             BIGINT          NOT NULL,
    [Unidades]            DECIMAL (18, 2) NOT NULL,
    [Imagen]              VARBINARY (MAX) NOT NULL,
    [CodigoCcTalk]        BIGINT          NULL,
    [EstadoLogico]        SMALLINT        CONSTRAINT [DF_Denominacion_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT          CONSTRAINT [DF__Denominac__Usuar__3F6663D5] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME   CONSTRAINT [DF__Denominac__Fecha__405A880E] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT          CONSTRAINT [DF__Denominac__Usuar__414EAC47] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME   CONSTRAINT [DF__Denominac__Fecha__4242D080] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Denominacion] PRIMARY KEY CLUSTERED ([Id] ASC)
);

