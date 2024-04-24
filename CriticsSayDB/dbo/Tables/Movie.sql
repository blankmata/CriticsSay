CREATE TABLE [dbo].[Movie] (
    [MovieId]          INT            IDENTITY (1, 1) NOT NULL,
    [MovieTitle]       VARCHAR (100)  NOT NULL,
    [MovieDescription] VARCHAR (500)  NOT NULL,
    [ReleaseDate]      DATETIME       NOT NULL,
    [MoviePoster]      NVARCHAR (MAX) NOT NULL,
    [GenreId]          INT            NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([MovieId] ASC),
    CONSTRAINT [FK_Movie_Genre] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genre] ([GenreId])
);











