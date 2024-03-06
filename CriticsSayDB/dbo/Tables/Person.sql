CREATE TABLE [dbo].[Person] (
    [PersonId]      INT           NOT NULL,
    [FirstName]     VARCHAR (50)  NOT NULL,
    [LastName]      VARCHAR (50)  NOT NULL,
    [Email]         VARCHAR (100) NOT NULL,
    [PasswordHash]  VARCHAR (100) NOT NULL,
    [RegisterDate]  DATETIME      NULL,
    [LastLoginTime] DATETIME      NULL,
    [RoleId]        INT           IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC),
    CONSTRAINT [FK_Person_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Person] ([PersonId])
);

