CREATE TABLE [Directorio].[Banco] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [PaisId]              BIGINT        NOT NULL,
    [Codigo]              VARCHAR (100) NOT NULL,
    [Denominacion]        VARCHAR (500) NOT NULL,
    [FechaCreacion]       SMALLDATETIME NULL,
    [FechaModificacion]   SMALLDATETIME NULL,
    [UsuarioCreacion]     BIGINT        NULL,
    [UsuarioModificacion] BIGINT        NULL,
    [Habilitado]          BIT           CONSTRAINT [DF_Banco_Habilitado] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED ([Id] ASC)
);

