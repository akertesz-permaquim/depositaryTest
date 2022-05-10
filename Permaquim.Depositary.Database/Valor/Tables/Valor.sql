CREATE TABLE [Valor].[Valor] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Tipo]                BIGINT        NOT NULL,
    [PaisId]              BIGINT        NOT NULL,
    [Codigo]              VARCHAR (50)  NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Valor_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__Valor__UsuarioCr__320C68B7] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__Valor__FechaCrea__33008CF0] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__Valor__UsuarioMo__33F4B129] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__Valor__FechaModi__34E8D562] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Valor] PRIMARY KEY CLUSTERED ([Id] ASC)
);

