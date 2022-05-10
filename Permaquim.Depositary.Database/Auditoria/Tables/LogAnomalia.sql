CREATE TABLE [Auditoria].[LogAnomalia] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Fecha]       DATETIME       NOT NULL,
    [Tipo]        VARCHAR (100)  NULL,
    [Descripcion] NVARCHAR (MAX) NULL,
    [Detalle]     NVARCHAR (MAX) NULL,
    [UsuarioId]   BIGINT         NULL,
    CONSTRAINT [PK_LogAnomalia] PRIMARY KEY CLUSTERED ([Id] ASC)
);

