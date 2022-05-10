CREATE TABLE [Biometria].[HuellaDactilar] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [UsuarioId]           BIGINT        NOT NULL,
    [Dedo]                TINYINT       NOT NULL,
    [Huella]              NTEXT         NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Huella_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__Huella__UsuarioC__77DFC722] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__Huella__FechaCre__78D3EB5B] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__Huella__UsuarioM__79C80F94] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__Huella__FechaMod__7ABC33CD] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_HuellaDactilar] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seguridad_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id])
);

