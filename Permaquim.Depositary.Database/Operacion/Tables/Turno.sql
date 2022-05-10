CREATE TABLE [Operacion].[Turno] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (100) NOT NULL,
    [Descripcion]         VARCHAR (500) NOT NULL,
    [Desde]               TIME (7)      NOT NULL,
    [Hasta]               TIME (7)      NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_Turno_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__Turno__UsuarioCr__53A266AC] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__Turno__FechaCrea__54968AE5] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__Turno__UsuarioMo__558AAF1E] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__Turno__FechaModi__567ED357] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seguridad_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id])
);

