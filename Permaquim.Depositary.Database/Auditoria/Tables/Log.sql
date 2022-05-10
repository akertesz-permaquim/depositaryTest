CREATE TABLE [Auditoria].[Log] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [Fecha]            DATETIME       NOT NULL,
    [Tipo]             VARCHAR (100)  NULL,
    [Descripcion]      NVARCHAR (MAX) NULL,
    [Detalle]          NVARCHAR (MAX) NULL,
    [OrigenAplicacion] NVARCHAR (500) NULL,
    [OrigenMetodo]     NVARCHAR (500) NULL,
    [UsuarioId]        BIGINT         NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([Id] ASC)
);

