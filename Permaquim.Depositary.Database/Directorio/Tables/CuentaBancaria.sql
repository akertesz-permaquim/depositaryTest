CREATE TABLE [Directorio].[CuentaBancaria] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [TipoId]              BIGINT        NOT NULL,
    [SucursalBancariaId]  BIGINT        NOT NULL,
    [Codigo]              VARCHAR (100) NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_CuentaBancaria_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__CuentaBan__Usuar__5A1A5A11] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__CuentaBan__Fecha__5B0E7E4A] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__CuentaBan__Usuar__5C02A283] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__CuentaBan__Fecha__5CF6C6BC] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_CuentaBancaria] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seguridad_EstadoLogico] FOREIGN KEY ([EstadoLogico]) REFERENCES [Seguridad].[EstadoLogico] ([Id])
);

