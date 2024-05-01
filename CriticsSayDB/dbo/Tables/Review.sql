CREATE TABLE [dbo].[Review] (
    [ReviewId]      INT           IDENTITY (1, 1) NOT NULL,
    [ReviewContent] VARCHAR (500) NOT NULL,
    [Rating]        INT           NOT NULL,
    [DatePosted]    DATETIME      NOT NULL,
    [MovieId]       INT           NOT NULL,
    CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED ([ReviewId] ASC),
    CONSTRAINT [FK_Review_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([MovieId])
);





