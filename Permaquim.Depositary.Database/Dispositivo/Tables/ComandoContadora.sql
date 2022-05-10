CREATE TABLE [Dispositivo].[ComandoContadora] (
    [Id]              BIGINT        IDENTITY (1, 1) NOT NULL,
    [ContadoraId]     BIGINT        NOT NULL,
    [Nombre]          VARCHAR (100) NOT NULL,
    [Descripcion]     VARCHAR (500) NOT NULL,
    [Comando]         VARCHAR (10)  NOT NULL,
    [TiempoDetencion] BIGINT        NOT NULL,
    [Habilitado]      BIT           NOT NULL,
    CONSTRAINT [PK_ComandoContadora] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ComandoContadora_Contadora] FOREIGN KEY ([ContadoraId]) REFERENCES [Dispositivo].[Contadora] ([Id])
);

