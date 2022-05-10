CREATE TABLE [Seguridad].[EstadoLogico] (
    [Id]                  SMALLINT      IDENTITY (0, 1) NOT NULL,
    [Nombre]              VARCHAR (50)  NOT NULL,
    [Descripcion]         VARCHAR (50)  NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__EstadoLog__Usuar__6442E2C9] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__EstadoLog__Fecha__65370702] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__EstadoLog__Usuar__662B2B3B] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__EstadoLog__Fecha__671F4F74] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_EstadoLogico] PRIMARY KEY CLUSTERED ([Id] ASC)
);

