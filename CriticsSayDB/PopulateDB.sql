/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[Genre] ON 
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (1, N'Horror')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (2, N'Comedy')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (3, N'Action')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (4, N'Animation')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (5, N'Romance')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (6, N'Adventure')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (7, N'Drama')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (8, N'Fantasy')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (9, N'ScienceFiction')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (10, N'Thriller')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (11, N'Western')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (12, N'Family')
GO
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Owner')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (1, N'David', N'Mata', N'matad2@jacks.sfasu.edu', N'Password', CAST(N'2024-03-30T13:51:01.000' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (2, N'David', N'Mata', N'matad2@jacks.sfasu.edu', N'$2a$13$U6J/UcFY6vE5E35F3f74jeBi9J7bPnaYSCqAIdMjlN6th8T7rCi4y', CAST(N'2024-03-30T14:20:56.000' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (1002, N'David', N'Mata', N'matadavid5499@gmail.com', N'$2a$13$foRpc531Kj5ncH/ZWrEjsuzQban7rmP01BaKKClHGyvbb6ownSjSK', CAST(N'2024-04-01T13:23:30.000' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
