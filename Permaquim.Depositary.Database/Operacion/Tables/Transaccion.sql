CREATE TABLE [Operacion].[Transaccion] (
    [Id]               BIGINT        IDENTITY (1, 1) NOT NULL,
    [MaquinaId]        BIGINT        NOT NULL,
    [UsuarioId]        BIGINT        NOT NULL,
    [ValorDeclarado]   FLOAT (53)    NOT NULL,
    [ValorCertificado] FLOAT (53)    NOT NULL,
    [FechaInicio]      SMALLDATETIME NOT NULL,
    [FechaFin]         SMALLDATETIME NOT NULL,
    CONSTRAINT [PK_Transaccion] PRIMARY KEY CLUSTERED ([Id] ASC)
);

