CREATE TABLE [dbo].[List] (
    [ListId]    INT      NOT NULL,
    [PersonId]  INT      NOT NULL,
    [DateAdded] DATETIME NOT NULL,
    [MovieId]   INT      IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_List] PRIMARY KEY CLUSTERED ([ListId] ASC),
    CONSTRAINT [FK_List_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([MovieId]),
    CONSTRAINT [FK_List_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId])
);

