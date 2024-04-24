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
USE [CriticSay]
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
SET IDENTITY_INSERT [dbo].[Movie] ON 
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (3, N'Heat', N'Master criminal Neil McCauley (Robert De Niro) is trying to control the rogue actions of one of his men, while also planning one last big heist before retiring. Meanwhile, Lieutenant Hanna (Al Pacino) attempts to track down McCauley as he deals with the chaos in his own life, including the infidelity of his wife (Diane Venora) and the mental health of his stepdaughter (Natalie Portman). McCauley and Hanna discover a mutual respect, even as they try to thwart each other''s plans.', CAST(N'1995-12-15T00:00:00.000' AS DateTime), N'https://www.movieposters.com/cdn/shop/files/heat.mpw.119090_480x.progressive.jpg?v=1708452299', 3)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (4, N'Transformers ', N'The fate of humanity is at stake when two races of robots, the good Autobots and the villainous Decepticons, bring their war to Earth. The robots have the ability to change into different mechanical objects as they seek the key to ultimate power. Only a human youth, Sam Witwicky (Shia LaBeouf) can save the world from total destruction.', CAST(N'1995-07-03T00:00:00.000' AS DateTime), N'https://www.movieposters.com/cdn/shop/products/67fa5fbafea19b1cdd051a50c8aa090e_31fb1905-5a09-445c-b51f-602cabbbbe7f_480x.progressive.jpg?v=1573651201', 3)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (5, N'The Good, The Bad, The Ugly', N'In the Southwest during the Civil War, a mysterious stranger, Joe (Clint Eastwood), and a Mexican outlaw, Tuco (Eli Wallach), form an uneasy partnership -- Joe turns in the bandit for the reward money, then rescues him just as he is being hanged. When Joe''s shot at the noose goes awry during one escapade, a furious Tuco tries to have him murdered. The men re-team abruptly, however, to beat out a sadistic criminal and the Union army and find $20,000 that a soldier has buried in the desert.', CAST(N'1967-12-29T00:00:00.000' AS DateTime), N'https://www.movieposters.com/cdn/shop/files/goodbadugly.mpw._480x.progressive.jpg?v=1707501317', 11)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (6, N'Late Night with the Devil', N'In 1977 a live television broadcast goes horribly wrong, unleashing evil into the nation''s living rooms.
', CAST(N'2024-03-22T00:00:00.000' AS DateTime), N'https://m.media-amazon.com/images/I/71yksvgZcgL._AC_UF894,1000_QL80_DpWeblab_.jpg', 1)
GO
SET IDENTITY_INSERT [dbo].[Movie] OFF
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
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (2003, N'abc', N'abc', N'abc@gmail.com', N'$2a$13$Dg8mfWuODWww0oO8irOFluouUPLyKbvhP1RZ3T6VJXHYHd7.fU9KG', CAST(N'2024-04-24T12:22:43.483' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (3002, N'ab', N'ab', N'ab@gmail.com', N'$2a$13$s9UseNC8SfcsvL2qbHtT6.WYwYk1MpiubHghHAKlXUYVPJNsa179.', CAST(N'2024-04-24T02:13:55.243' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (3003, N'evan', N'ernst', N'evan@gmail.com', N'$2a$13$e0AtHk8RyFGvhB9BZfQW6.L/H2ojRf7AIvqAm36e35SZKQVxH0vt2', CAST(N'2024-04-15T13:40:30.730' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (3004, N'ab', N'ab', N'ab1@gmail.com', N'$2a$13$igGPlYuRT36CMY6LWFcSauyoeVuGELiVBVpWP1sIMehDhW1eFXzh2', CAST(N'2024-04-19T09:05:10.000' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (4004, N'David', N'Mata', N'david@gmail.com', N'$2a$13$Zc0dMQPgt6e6uhsqRKKO/OnDlaklKV2WOqOUpMY0JJOtt/GUx070W', CAST(N'2024-04-24T11:04:03.227' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (4005, N'hello', N'world', N'helloworld@gmail.com', N'$2a$13$7lbTZR7iVHU.d.wJ/YUW2OPaNL8.Ua0WZagzlLB2fRLWCuFS1iTfq', CAST(N'2024-04-24T12:02:58.000' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (4006, N'Morgan', N'Jennings', N'morgan@gmail.com', N'$2a$13$QFVnFmlY0H6QQf8T94y67uuhPGKrvUf/te9hgC.cjgGdZPfz/Yvpm', CAST(N'2024-04-24T12:04:11.613' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
