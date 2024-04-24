CREATE TABLE [dbo].[PersonReview] (
    [PersonId] INT IDENTITY (1, 1) NOT NULL,
    [ReviewId] INT NOT NULL,
    CONSTRAINT [PK_PersonReview] PRIMARY KEY CLUSTERED ([PersonId] ASC),
    CONSTRAINT [FK_PersonReview_Review] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Review] ([ReviewId])
);

