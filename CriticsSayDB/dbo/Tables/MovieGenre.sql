CREATE TABLE [dbo].[MovieGenre] (
    [MovieId] INT NOT NULL,
    [GenreId] INT NOT NULL,
    CONSTRAINT [FK_MovieGenre_Genre] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genre] ([GenreId]),
    CONSTRAINT [FK_MovieGenre_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([MovieId])
);

