CREATE TABLE [Regionalizacion].[LenguajeItem] (
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [LenguajeId] BIGINT        NOT NULL,
    [Clave]      VARCHAR (100) NOT NULL,
    [Texto]      VARCHAR (MAX) NOT NULL,
    [Habilitado] BIT           NOT NULL,
    CONSTRAINT [PK_LenguajeItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LenguajeItem_Lenguaje] FOREIGN KEY ([LenguajeId]) REFERENCES [Regionalizacion].[Lenguaje] ([Id])
);

