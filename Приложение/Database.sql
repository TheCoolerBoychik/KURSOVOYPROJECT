USE [master]
GO
/****** Object:  Database [Database]    Script Date: 26.04.2023 1:25:31 ******/
CREATE DATABASE [Database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Database', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Database_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Database] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Database] SET ARITHABORT OFF 
GO
ALTER DATABASE [Database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Database] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Database] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Database] SET  MULTI_USER 
GO
ALTER DATABASE [Database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Database] SET QUERY_STORE = OFF
GO
USE [Database]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 26.04.2023 1:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[DateofContract] [date] NOT NULL,
	[RieltorsFullName] [nvarchar](50) NOT NULL,
	[UsersFullName] [nvarchar](50) NOT NULL,
	[Period] [nvarchar](50) NOT NULL,
	[TypeOfRoomID] [int] NOT NULL,
	[Amount] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CountsOfRooms]    Script Date: 26.04.2023 1:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountsOfRooms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CountsOfRooms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 26.04.2023 1:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 26.04.2023 1:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 26.04.2023 1:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[Town] [nvarchar](50) NOT NULL,
	[Price] [nvarchar](50) NOT NULL,
	[CountOfRoomID] [int] NOT NULL,
	[TypeOfRoomID] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfRooms]    Script Date: 26.04.2023 1:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfRooms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeOfRooms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26.04.2023 1:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[RequestsID] [int] NOT NULL,
	[ContractID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contracts] ON 

INSERT [dbo].[Contracts] ([ID], [Number], [DateofContract], [RieltorsFullName], [UsersFullName], [Period], [TypeOfRoomID], [Amount]) VALUES (1, N'245604', CAST(N'2000-12-12' AS Date), N'Логопедов К. В', N'Головач Л. П', N'1 год', 1, N'200.000')
INSERT [dbo].[Contracts] ([ID], [Number], [DateofContract], [RieltorsFullName], [UsersFullName], [Period], [TypeOfRoomID], [Amount]) VALUES (2, N'324567', CAST(N'2000-12-13' AS Date), N'Петушков Д. В', N'Петренко Е. А', N'10 лет', 2, N'450.000')
INSERT [dbo].[Contracts] ([ID], [Number], [DateofContract], [RieltorsFullName], [UsersFullName], [Period], [TypeOfRoomID], [Amount]) VALUES (15, N'547575757', CAST(N'2023-04-24' AS Date), N'Мадонов М. А', N'Лавров С. В', N'бессрочно', 4, N'50.000.000')
INSERT [dbo].[Contracts] ([ID], [Number], [DateofContract], [RieltorsFullName], [UsersFullName], [Period], [TypeOfRoomID], [Amount]) VALUES (34, N'2281337', CAST(N'2023-04-06' AS Date), N'Петушков И. А', N'Жуков А. Н', N'2 года', 2, N'1.000.000')
SET IDENTITY_INSERT [dbo].[Contracts] OFF
GO
SET IDENTITY_INSERT [dbo].[CountsOfRooms] ON 

INSERT [dbo].[CountsOfRooms] ([ID], [type]) VALUES (1, N'6 комнат')
INSERT [dbo].[CountsOfRooms] ([ID], [type]) VALUES (2, N'2 комнаты')
INSERT [dbo].[CountsOfRooms] ([ID], [type]) VALUES (3, N'3 комнаты')
INSERT [dbo].[CountsOfRooms] ([ID], [type]) VALUES (4, N'4 комнаты')
INSERT [dbo].[CountsOfRooms] ([ID], [type]) VALUES (5, N'5 комнат')
INSERT [dbo].[CountsOfRooms] ([ID], [type]) VALUES (6, N'6 комнат')
SET IDENTITY_INSERT [dbo].[CountsOfRooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Requests] ON 

INSERT [dbo].[Requests] ([ID], [FullName], [PhoneNumber], [City], [Email]) VALUES (1, N'Мордашов Виктор Николаевич', N'28005434395', N'Москва', N'zhivunatimane@rambler.ru')
INSERT [dbo].[Requests] ([ID], [FullName], [PhoneNumber], [City], [Email]) VALUES (2, N'Натуралов Евгений Борисович', N'89224593481', N'Крым', N'igrauvgenshin@gmail.com')
INSERT [dbo].[Requests] ([ID], [FullName], [PhoneNumber], [City], [Email]) VALUES (7, N'Жуков Алексей Сергеевич', N'89124451212', N'Чечня', N'shinobuparasha123@mail.ru')
INSERT [dbo].[Requests] ([ID], [FullName], [PhoneNumber], [City], [Email]) VALUES (8, N'Оскретков Данил Антонович', N'89123458734', N'Москва', N'hqdonelove@yandex.ru')
SET IDENTITY_INSERT [dbo].[Requests] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID], [title]) VALUES (1, N'1')
INSERT [dbo].[Roles] ([ID], [title]) VALUES (2, N'2')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([ID], [address], [Town], [Price], [CountOfRoomID], [TypeOfRoomID]) VALUES (8, N'ул. Тиманская 4Б', N'Воркута', N'5.000.000$', 6, 4)
INSERT [dbo].[Rooms] ([ID], [address], [Town], [Price], [CountOfRoomID], [TypeOfRoomID]) VALUES (9, N'Ленина 21', N'Санкт-Петербург', N'4.000.000', 1, 1)
INSERT [dbo].[Rooms] ([ID], [address], [Town], [Price], [CountOfRoomID], [TypeOfRoomID]) VALUES (10, N'Дачная улица 7', N'Нижний Новгород', N'2.500.000', 2, 2)
INSERT [dbo].[Rooms] ([ID], [address], [Town], [Price], [CountOfRoomID], [TypeOfRoomID]) VALUES (11, N'Тверская 1', N'Москва', N'10.000.000', 4, 3)
INSERT [dbo].[Rooms] ([ID], [address], [Town], [Price], [CountOfRoomID], [TypeOfRoomID]) VALUES (12, N'Карама, аль- 24-я улица', N'Абу-Даби', N'24.000.000', 5, 5)
INSERT [dbo].[Rooms] ([ID], [address], [Town], [Price], [CountOfRoomID], [TypeOfRoomID]) VALUES (15, N'1905 года площадь, 4', N'Екатеринбург', N'4.500.000', 1, 2)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeOfRooms] ON 

INSERT [dbo].[TypeOfRooms] ([ID], [title]) VALUES (1, N'Студия')
INSERT [dbo].[TypeOfRooms] ([ID], [title]) VALUES (2, N'Квартира')
INSERT [dbo].[TypeOfRooms] ([ID], [title]) VALUES (3, N'Аппартаменты')
INSERT [dbo].[TypeOfRooms] ([ID], [title]) VALUES (4, N'Пентхаус')
INSERT [dbo].[TypeOfRooms] ([ID], [title]) VALUES (5, N'Коттедж')
SET IDENTITY_INSERT [dbo].[TypeOfRooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [RoleID], [RequestsID], [ContractID], [RoomID], [Login], [Password]) VALUES (1, 1, 1, 1, 1, N'1', N'1')
INSERT [dbo].[Users] ([ID], [RoleID], [RequestsID], [ContractID], [RoomID], [Login], [Password]) VALUES (2, 2, 2, 2, 2, N'2', N'2')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_TypeOfRooms] FOREIGN KEY([TypeOfRoomID])
REFERENCES [dbo].[TypeOfRooms] ([ID])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_TypeOfRooms]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_CountsOfRooms] FOREIGN KEY([CountOfRoomID])
REFERENCES [dbo].[CountsOfRooms] ([ID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_CountsOfRooms]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_TypeOfRooms] FOREIGN KEY([TypeOfRoomID])
REFERENCES [dbo].[TypeOfRooms] ([ID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_TypeOfRooms]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Contracts] FOREIGN KEY([ContractID])
REFERENCES [dbo].[Contracts] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Contracts]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Requests] FOREIGN KEY([RequestsID])
REFERENCES [dbo].[Requests] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Requests]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [Database] SET  READ_WRITE 
GO
