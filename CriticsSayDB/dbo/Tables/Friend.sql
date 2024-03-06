﻿CREATE TABLE [dbo].[Friend] (
    [FriendId] INT NOT NULL,
    [PersonId] INT NOT NULL,
    CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED ([FriendId] ASC),
    CONSTRAINT [FK_Friend_Friend2] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Friend] ([FriendId])
);

