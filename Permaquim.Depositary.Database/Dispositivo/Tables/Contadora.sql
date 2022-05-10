CREATE TABLE [Dispositivo].[Contadora] (
    [Id]          BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]      VARCHAR (100) NOT NULL,
    [Descripcion] VARCHAR (500) NOT NULL,
    [Habilitado]  BIT           NOT NULL,
    CONSTRAINT [PK_Contadora] PRIMARY KEY CLUSTERED ([Id] ASC)
);

