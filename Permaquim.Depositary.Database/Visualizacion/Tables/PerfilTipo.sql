CREATE TABLE [Visualizacion].[PerfilTipo] (
    [Id]              BIGINT        IDENTITY (0, 1) NOT NULL,
    [Nombre]          VARCHAR (100) NOT NULL,
    [Descripcion]     VARCHAR (500) NOT NULL,
    [EsAdministrador] BIT           NOT NULL,
    [Habilitado]      BIT           NOT NULL,
    CONSTRAINT [PK_PerfilTipo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

