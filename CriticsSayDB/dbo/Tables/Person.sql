CREATE TABLE [dbo].[Person] (
    [PersonId]      INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]     VARCHAR (50)  NOT NULL,
    [LastName]      VARCHAR (50)  NOT NULL,
    [Email]         VARCHAR (100) NOT NULL,
    [Password]      VARCHAR (100) NOT NULL,
    [LastLoginTime] DATETIME      NULL,
    [RoleId]        INT           NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC),
    CONSTRAINT [FK_Person_Role1] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
);









