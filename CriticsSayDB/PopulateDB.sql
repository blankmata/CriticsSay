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
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Owner')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'User')
GO
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
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (9, N'Science Fiction')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (10, N'Thriller')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (11, N'Western')
GO
INSERT [dbo].[Genre] ([GenreId], [GenreName]) VALUES (12, N'Family')
GO
SET IDENTITY_INSERT [dbo].[Genre] ON
GO
