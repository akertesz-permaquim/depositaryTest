CREATE TABLE [Operacion].[TransaccionDetalle] (
    [Id]                  BIGINT        IDENTITY (1, 1) NOT NULL,
    [TransaccionId]       BIGINT        NOT NULL,
    [DenominacionId]      BIGINT        NOT NULL,
    [CantidadCertificada] BIGINT        NOT NULL,
    [CantidadDeclarada]   BIGINT        NOT NULL,
    [Fecha]               SMALLDATETIME NOT NULL,
    CONSTRAINT [PK_TransaccionDetalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TransaccionDetalle_Denominacion] FOREIGN KEY ([DenominacionId]) REFERENCES [Valor].[Denominacion] ([Id]),
    CONSTRAINT [FK_TransaccionDetalle_Transaccion] FOREIGN KEY ([TransaccionId]) REFERENCES [Operacion].[Transaccion] ([Id])
);

