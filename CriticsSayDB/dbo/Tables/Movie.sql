CREATE TABLE [dbo].[Movie] (
    [MovieId]     INT           NOT NULL,
    [MovieTitle]  VARCHAR (100) NOT NULL,
    [ReleaseDate] DATETIME      NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([MovieId] ASC)
);

