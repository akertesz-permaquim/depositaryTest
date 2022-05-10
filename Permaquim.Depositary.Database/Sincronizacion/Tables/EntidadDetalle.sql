CREATE TABLE [Sincronizacion].[EntidadDetalle] (
    [Id]                BIGINT        IDENTITY (0, 1) NOT NULL,
    [EntidadCabeceraId] BIGINT        NOT NULL,
    [FechaCreacion]     SMALLDATETIME CONSTRAINT [DF__EntidadDe__Fecha__33BFA6FF] DEFAULT (getdate()) NOT NULL,
    [Valor]             VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_EntidadDetalle] PRIMARY KEY CLUSTERED ([Id] ASC)
);

