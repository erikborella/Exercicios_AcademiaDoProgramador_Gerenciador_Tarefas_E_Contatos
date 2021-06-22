CREATE TABLE [dbo].[TBContato] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [nome]     VARCHAR(50)    NOT NULL,
    [email]    VARCHAR (200) NOT NULL,
    [telefone] VARCHAR (20)  NOT NULL,
    [empresa]  VARCHAR (200) NOT NULL,
    [cargo]    VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

