CREATE TABLE [Seguridad].[TipoIdentificador] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (200) NOT NULL,
    [Descripcion]         VARCHAR (500) NOT NULL,
    [Mascara]             VARCHAR (500) NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_TipoIdentificador_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__TipoIdent__Usuar__7E57BA87] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__TipoIdent__Fecha__7F4BDEC0] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__TipoIdent__Usuar__004002F9] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__TipoIdent__Fecha__01342732] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_TipoIdentificador] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seguridad_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Patrón que debe observar la entidad', @level0type = N'SCHEMA', @level0name = N'Seguridad', @level1type = N'TABLE', @level1name = N'TipoIdentificador', @level2type = N'COLUMN', @level2name = N'Mascara';

