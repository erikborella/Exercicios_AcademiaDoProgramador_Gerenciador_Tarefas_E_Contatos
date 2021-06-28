CREATE TABLE [dbo].[TBCompromisso] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [assunto]     VARCHAR (100) NOT NULL,
    [local]       VARCHAR (200) NOT NULL,
    [data]        DATE          NOT NULL,
    [horaInicial] TIME (7)      NOT NULL,
    [horaFinal]   TIME (7)      NOT NULL,
    [contato_id]  INT           NULL,
    CONSTRAINT [PK_TBCompromisso] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCompromisso_TBContato] FOREIGN KEY ([contato_id]) REFERENCES [dbo].[TBContato] ([Id]) ON DELETE SET NULL
);


