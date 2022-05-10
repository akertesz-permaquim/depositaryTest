CREATE TABLE [Directorio].[SucursalBancaria] (
    [Id]                  BIGINT        IDENTITY (0, 1) NOT NULL,
    [BancoId]             BIGINT        NOT NULL,
    [Codigo]              VARCHAR (100) NOT NULL,
    [Direccion]           VARCHAR (MAX) NOT NULL,
    [EstadoLogico]        SMALLINT      CONSTRAINT [DF_SucursalBancaria_EstadoLogico] DEFAULT ((0)) NOT NULL,
    [UsuarioCreacion]     BIGINT        CONSTRAINT [DF__SucursalB__Usuar__61BB7BD9] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]       SMALLDATETIME CONSTRAINT [DF__SucursalB__Fecha__62AFA012] DEFAULT (getdate()) NOT NULL,
    [UsuarioModificacion] BIGINT        CONSTRAINT [DF__SucursalB__Usuar__63A3C44B] DEFAULT ((0)) NOT NULL,
    [FechaModificacion]   SMALLDATETIME CONSTRAINT [DF__SucursalB__Fecha__6497E884] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_SucursalBancaria] PRIMARY KEY CLUSTERED ([Id] ASC)
);

