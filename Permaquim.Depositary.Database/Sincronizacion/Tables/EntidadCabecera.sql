CREATE TABLE [Sincronizacion].[EntidadCabecera] (
    [Id]          BIGINT        IDENTITY (0, 1) NOT NULL,
    [EntidadId]   BIGINT        NOT NULL,
    [Valor]       VARCHAR (500) NOT NULL,
    [Fechainicio] SMALLDATETIME CONSTRAINT [DF__EntidadCa__Fecha__3A6CA48E] DEFAULT (getdate()) NOT NULL,
    [Fechafin]    SMALLDATETIME NULL,
    CONSTRAINT [PK_EntidadCabecera] PRIMARY KEY CLUSTERED ([Id] ASC)
);

