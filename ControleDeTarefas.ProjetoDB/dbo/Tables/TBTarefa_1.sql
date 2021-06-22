CREATE TABLE [dbo].[TBTarefa] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [titulo]              VARCHAR (100) NOT NULL,
    [dataCriacao]         DATETIME      NOT NULL,
    [dataConclusao]       DATETIME      NULL,
    [percentualConcluido] INT           NOT NULL,
    [prioridade]          INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

