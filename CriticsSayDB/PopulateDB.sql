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
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (5, N'The Good, The Bad, The Ugly', N'In the Southwest during the Civil War, a mysterious stranger, Joe (Clint Eastwood), and a Mexican outlaw, Tuco (Eli Wallach), form an uneasy partnership -- Joe turns in the bandit for the reward money, then rescues him just as he is being hanged. When Joe''s shot at the noose goes awry during one escapade, a furious Tuco tries to have him murdered. The men re-team abruptly, however, to beat out a sadistic criminal and the Union army and find $20,000 that a soldier has buried in the desert.', CAST(N'1967-12-29T00:00:00.000' AS DateTime), N'https://www.movieposters.com/cdn/shop/files/goodbadugly.mpw._480x.progressive.jpg?v=1707501317', 11)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (6, N'Late Night with the Devil', N'In 1977 a live television broadcast goes horribly wrong, unleashing evil into the nation''s living rooms.
', CAST(N'2024-03-22T00:00:00.000' AS DateTime), N'https://m.media-amazon.com/images/I/71yksvgZcgL._AC_UF894,1000_QL80_DpWeblab_.jpg', 1)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (1003, N'Barnyard', N'cows go moo', CAST(N'2014-02-05T00:00:00.000' AS DateTime), N'https://www.movieposters.com/cdn/shop/products/321e5f713497412085cfacbd73b6e740_adad1e11-ba06-4bb3-8c0b-4b38d0da9f48_480x.progressive.jpg?v=1573618770', 4)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (3006, N'Frozen', N'ice princess', CAST(N'2024-05-01T00:00:00.000' AS DateTime), N'https://i.ebayimg.com/images/g/BbUAAOxyc2pTZyaw/s-l1600.jpg', 4)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (3007, N'Star Wars', N'The Imperial Forces -- under orders from cruel Darth Vader (David Prowse) -- hold Princess Leia (Carrie Fisher) hostage, in their efforts to quell the rebellion against the Galactic Empire. Luke Skywalker (Mark Hamill) and Han Solo (Harrison Ford), captain of the Millennium Falcon, work together with the companionable droid duo R2-D2 (Kenny Baker) and C-3PO (Anthony Daniels) to rescue the beautiful princess, help the Rebel Alliance, and restore freedom and justice to the Galaxy.', CAST(N'1977-05-25T00:00:00.000' AS DateTime), N'https://www.movieposters.com/cdn/shop/products/23fd3ba334c1e8e84c96906497d577bf_6d652cf7-d705-42d2-96aa-2c3963f8a178_480x.progressive.jpg?v=1573613876', 9)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (3008, N'Avengers: Endgame', N'Adrift in space with no food or water, Tony Stark sends a message to Pepper Potts as his oxygen supply starts to dwindle. Meanwhile, the remaining Avengers -- Thor, Black Widow, Captain America and Bruce Banner -- must figure out a way to bring back their vanquished allies for an epic showdown with Thanos -- the evil demigod who decimated the planet and the universe.', CAST(N'2019-04-26T00:00:00.000' AS DateTime), N'https://www.movieposters.com/cdn/shop/products/108b520c55e3c9760f77a06110d6a73b_e97cf224-d57f-44e3-8477-4f5479cd746b_480x.progressive.jpg?v=1573616089', 3)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (3009, N'Once Upon a Time in Hollywood', N'Actor Rick Dalton gained fame and fortune by starring in a 1950s television Western, but is now struggling to find meaningful work in a Hollywood that he doesn''t recognize anymore. He spends most of his time drinking and palling around with Cliff Booth, his easygoing best friend and longtime stunt double. Rick also happens to live next door to Roman Polanski and Sharon Tate -- the filmmaker and budding actress whose futures will forever be altered by members of the Manson Family.', CAST(N'2019-07-26T00:00:00.000' AS DateTime), N'https://www.movieposters.com/cdn/shop/products/onceuponatimehollywood.flo.ar_480x.progressive.jpg?v=1597169428', 7)
GO
INSERT [dbo].[Movie] ([MovieId], [MovieTitle], [MovieDescription], [ReleaseDate], [MoviePoster], [GenreId]) VALUES (3010, N'Pulp Fiction', N'Vincent Vega (John Travolta) and Jules Winnfield (Samuel L. Jackson) are hitmen with a penchant for philosophical discussions. In this ultra-hip, multi-strand crime movie, their storyline is interwoven with those of their boss, gangster Marsellus Wallace (Ving Rhames) ; his actress wife, Mia (Uma Thurman) ; struggling boxer Butch Coolidge (Bruce Willis) ; master fixer Winston Wolfe (Harvey Keitel) and a nervous pair of armed robbers, "Pumpkin" (Tim Roth) and "Honey Bunny" (Amanda Plummer).', CAST(N'1994-10-14T00:00:00.000' AS DateTime), N'https://www.movieposters.com/cdn/shop/products/950e439404c3d5eddd86ae876cec83bf_949b5045-2503-4883-bcd2-ff1f31f5b14c_480x.progressive.jpg?v=1573588746', 7)
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
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (2003, N'abc', N'abc', N'abc@gmail.com', N'$2a$13$Dg8mfWuODWww0oO8irOFluouUPLyKbvhP1RZ3T6VJXHYHd7.fU9KG', CAST(N'2024-05-01T12:07:09.167' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (3002, N'ab', N'ab', N'ab@gmail.com', N'$2a$13$s9UseNC8SfcsvL2qbHtT6.WYwYk1MpiubHghHAKlXUYVPJNsa179.', CAST(N'2024-04-24T02:13:55.243' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (3003, N'evan', N'ernst', N'evan@gmail.com', N'$2a$13$e0AtHk8RyFGvhB9BZfQW6.L/H2ojRf7AIvqAm36e35SZKQVxH0vt2', CAST(N'2024-04-15T13:40:30.730' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (3004, N'ab', N'ab', N'ab1@gmail.com', N'$2a$13$igGPlYuRT36CMY6LWFcSauyoeVuGELiVBVpWP1sIMehDhW1eFXzh2', CAST(N'2024-04-19T09:05:10.000' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (4004, N'David', N'Mata', N'david@gmail.com', N'$2a$13$Zc0dMQPgt6e6uhsqRKKO/OnDlaklKV2WOqOUpMY0JJOtt/GUx070W', CAST(N'2024-04-24T13:47:23.353' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (4005, N'hello', N'world', N'helloworld@gmail.com', N'$2a$13$7lbTZR7iVHU.d.wJ/YUW2OPaNL8.Ua0WZagzlLB2fRLWCuFS1iTfq', CAST(N'2024-04-24T12:02:58.000' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (4006, N'Morgan', N'Jennings', N'morgan@gmail.com', N'$2a$13$QFVnFmlY0H6QQf8T94y67uuhPGKrvUf/te9hgC.cjgGdZPfz/Yvpm', CAST(N'2024-04-24T12:04:11.613' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (5005, N'cba', N'cba', N'cba@gmail.com', N'$2a$13$JTXv3sYh4Jkltpw.51MTGeDiqRSI7nu.rm.EVUM5SXDWboLl1psCK', CAST(N'2024-04-24T13:08:09.363' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (6005, N'Bruh', N'Man', N'bruh@gmail.com', N'$2a$13$CLceiC5F6jMrPHEYPYYrMeF8Zuisk56N.ZBaBfh40VvGHVm1R16aS', CAST(N'2024-04-29T13:08:31.270' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (7005, N'testman', N'test', N'test@gmail.com', N'$2a$13$T6uq8x5nyQ6/gQGT8Df9C.xIUvl3hlsLIPLGLTFIvrpOUiOpkvLOm', CAST(N'2024-05-01T01:26:05.000' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (7006, N'testagain', N'again', N'testagain@gmail.com', N'$2a$13$VP1XELpcYly3C8/N/95gVOKjJtqMeYl27.Qz.DZeFOUIh/o2A7dBu', CAST(N'2024-05-01T01:29:44.000' AS DateTime), 2)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [Password], [LastLoginTime], [RoleId]) VALUES (7007, N'bruh', N'dude', N'dude@gmail.com', N'$2a$13$IfqZNYp7tvQ.1INGRS9QkuymXrp4IBPXXos60jXW72OMqcXczZO7u', CAST(N'2024-05-01T11:11:19.000' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[Review] ON 
GO
INSERT [dbo].[Review] ([ReviewId], [ReviewContent], [Rating], [DatePosted], [MovieId]) VALUES (6, N'i am dumb
', 0, CAST(N'2024-04-17T00:00:00.000' AS DateTime), 5)
GO
INSERT [dbo].[Review] ([ReviewId], [ReviewContent], [Rating], [DatePosted], [MovieId]) VALUES (8, N'greatest movie of all time', 4, CAST(N'2024-04-15T00:00:00.000' AS DateTime), 3)
GO
INSERT [dbo].[Review] ([ReviewId], [ReviewContent], [Rating], [DatePosted], [MovieId]) VALUES (9, N'movie is the best', 5, CAST(N'2024-03-04T00:00:00.000' AS DateTime), 3008)
GO
INSERT [dbo].[Review] ([ReviewId], [ReviewContent], [Rating], [DatePosted], [MovieId]) VALUES (10, N'2nd best star wars film', 5, CAST(N'2024-02-19T00:00:00.000' AS DateTime), 3007)
GO
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
