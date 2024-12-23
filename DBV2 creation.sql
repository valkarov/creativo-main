USE [master]
GO
/****** Object:  Database [CreativoDBV2]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE DATABASE [CreativoDBV2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CreativoDBV2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CreativoDBV2.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CreativoDBV2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CreativoDBV2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CreativoDBV2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CreativoDBV2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CreativoDBV2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CreativoDBV2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CreativoDBV2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CreativoDBV2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CreativoDBV2] SET ARITHABORT OFF 
GO
ALTER DATABASE [CreativoDBV2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CreativoDBV2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CreativoDBV2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CreativoDBV2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CreativoDBV2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CreativoDBV2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CreativoDBV2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CreativoDBV2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CreativoDBV2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CreativoDBV2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CreativoDBV2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CreativoDBV2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CreativoDBV2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CreativoDBV2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CreativoDBV2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CreativoDBV2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CreativoDBV2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CreativoDBV2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CreativoDBV2] SET  MULTI_USER 
GO
ALTER DATABASE [CreativoDBV2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CreativoDBV2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CreativoDBV2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CreativoDBV2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CreativoDBV2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CreativoDBV2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CreativoDBV2] SET QUERY_STORE = ON
GO
ALTER DATABASE [CreativoDBV2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CreativoDBV2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cantons]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cantons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ProvinceId] [int] NOT NULL,
 CONSTRAINT [PK_Cantons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Districts]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CantonId] [int] NOT NULL,
 CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntrepeneurshipAdmins]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntrepeneurshipAdmins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntrepeneurshipId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_EntrepeneurshipAdmins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrepeneurships]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrepeneurships](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DistrictId] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Reason] [nvarchar](max) NOT NULL,
	[Sinpe] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[state] [int] NOT NULL,
	[EntrepeneurshipTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Entrepeneurships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntrepeneurshipSocials]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntrepeneurshipSocials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntrepeneurshipId] [int] NOT NULL,
	[SocialId] [int] NOT NULL,
 CONSTRAINT [PK_EntrepeneurshipSocials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntrepeneurshipType]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntrepeneurshipType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EntrepeneurshipType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ForumComments]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForumComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[ForumId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_ForumComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forums]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_Forums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventories]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProducts]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[InventoryId] [int] NOT NULL,
 CONSTRAINT [PK_OrderProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[DistrictId] [int] NOT NULL,
	[EntrepeneurshipId] [int] NOT NULL,
	[DeliveryManId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[DeliveryDate] [datetime2](7) NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provinces]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provinces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Provinces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](max) NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socials]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[SocialTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Socials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialTypes]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SocialTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
	[DistrictId] [int] NULL,
	[Cedula] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkShopClients]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkShopClients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkshopId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[lastDigits] [nvarchar](max) NOT NULL,
	[price] [real] NOT NULL,
 CONSTRAINT [PK_WorkShopClients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkshopPhotos]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkshopPhotos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
	[WorkshopId] [int] NOT NULL,
 CONSTRAINT [PK_WorkshopPhotos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workshops]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workshops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[WorkshopTypeId] [int] NOT NULL,
	[EntrepeneurshipId] [int] NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[Price] [real] NOT NULL,
 CONSTRAINT [PK_Workshops] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkshopTypes]    Script Date: 11/16/2024 3:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkshopTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_WorkshopTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Cantons_ProvinceId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Cantons_ProvinceId] ON [dbo].[Cantons]
(
	[ProvinceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Districts_CantonId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Districts_CantonId] ON [dbo].[Districts]
(
	[CantonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EntrepeneurshipAdmins_EntrepeneurshipId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_EntrepeneurshipAdmins_EntrepeneurshipId] ON [dbo].[EntrepeneurshipAdmins]
(
	[EntrepeneurshipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EntrepeneurshipAdmins_UserId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_EntrepeneurshipAdmins_UserId] ON [dbo].[EntrepeneurshipAdmins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Entrepeneurships_DistrictId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Entrepeneurships_DistrictId] ON [dbo].[Entrepeneurships]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Entrepeneurships_EntrepeneurshipTypeId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Entrepeneurships_EntrepeneurshipTypeId] ON [dbo].[Entrepeneurships]
(
	[EntrepeneurshipTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EntrepeneurshipSocials_EntrepeneurshipId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_EntrepeneurshipSocials_EntrepeneurshipId] ON [dbo].[EntrepeneurshipSocials]
(
	[EntrepeneurshipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EntrepeneurshipSocials_SocialId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_EntrepeneurshipSocials_SocialId] ON [dbo].[EntrepeneurshipSocials]
(
	[SocialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ForumComments_AuthorId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_ForumComments_AuthorId] ON [dbo].[ForumComments]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ForumComments_ForumId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_ForumComments_ForumId] ON [dbo].[ForumComments]
(
	[ForumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Forums_AuthorId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Forums_AuthorId] ON [dbo].[Forums]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderProducts_InventoryId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderProducts_InventoryId] ON [dbo].[OrderProducts]
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderProducts_OrderId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderProducts_OrderId] ON [dbo].[OrderProducts]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_DeliveryManId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_DeliveryManId] ON [dbo].[Orders]
(
	[DeliveryManId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_DistrictId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_DistrictId] ON [dbo].[Orders]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_EntrepeneurshipId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_EntrepeneurshipId] ON [dbo].[Orders]
(
	[EntrepeneurshipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Socials_SocialTypeId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Socials_SocialTypeId] ON [dbo].[Socials]
(
	[SocialTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_UserId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_UserId] ON [dbo].[UserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_DistrictId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_DistrictId] ON [dbo].[Users]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkShopClients_UserId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_WorkShopClients_UserId] ON [dbo].[WorkShopClients]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkShopClients_WorkshopId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_WorkShopClients_WorkshopId] ON [dbo].[WorkShopClients]
(
	[WorkshopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkshopPhotos_WorkshopId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_WorkshopPhotos_WorkshopId] ON [dbo].[WorkshopPhotos]
(
	[WorkshopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Workshops_EntrepeneurshipId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Workshops_EntrepeneurshipId] ON [dbo].[Workshops]
(
	[EntrepeneurshipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Workshops_WorkshopTypeId]    Script Date: 11/16/2024 3:28:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Workshops_WorkshopTypeId] ON [dbo].[Workshops]
(
	[WorkshopTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Entrepeneurships] ADD  DEFAULT ((0)) FOR [state]
GO
ALTER TABLE [dbo].[Entrepeneurships] ADD  DEFAULT ((0)) FOR [EntrepeneurshipTypeId]
GO
ALTER TABLE [dbo].[ForumComments] ADD  DEFAULT ((0)) FOR [AuthorId]
GO
ALTER TABLE [dbo].[Forums] ADD  DEFAULT ((0)) FOR [AuthorId]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [DeliveryManId]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Date]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DeliveryDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [Cedula]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [Phone]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [UserName]
GO
ALTER TABLE [dbo].[WorkShopClients] ADD  DEFAULT (N'') FOR [State]
GO
ALTER TABLE [dbo].[WorkShopClients] ADD  DEFAULT (N'') FOR [lastDigits]
GO
ALTER TABLE [dbo].[WorkShopClients] ADD  DEFAULT (CONVERT([real],(0))) FOR [price]
GO
ALTER TABLE [dbo].[Workshops] ADD  DEFAULT ((0)) FOR [EntrepeneurshipId]
GO
ALTER TABLE [dbo].[Workshops] ADD  DEFAULT (N'') FOR [Link]
GO
ALTER TABLE [dbo].[Workshops] ADD  DEFAULT (CONVERT([real],(0))) FOR [Price]
GO
ALTER TABLE [dbo].[Cantons]  WITH CHECK ADD  CONSTRAINT [FK_Cantons_Provinces_ProvinceId] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Provinces] ([Id])
GO
ALTER TABLE [dbo].[Cantons] CHECK CONSTRAINT [FK_Cantons_Provinces_ProvinceId]
GO
ALTER TABLE [dbo].[Districts]  WITH CHECK ADD  CONSTRAINT [FK_Districts_Cantons_CantonId] FOREIGN KEY([CantonId])
REFERENCES [dbo].[Cantons] ([Id])
GO
ALTER TABLE [dbo].[Districts] CHECK CONSTRAINT [FK_Districts_Cantons_CantonId]
GO
ALTER TABLE [dbo].[EntrepeneurshipAdmins]  WITH CHECK ADD  CONSTRAINT [FK_EntrepeneurshipAdmins_Entrepeneurships_EntrepeneurshipId] FOREIGN KEY([EntrepeneurshipId])
REFERENCES [dbo].[Entrepeneurships] ([Id])
GO
ALTER TABLE [dbo].[EntrepeneurshipAdmins] CHECK CONSTRAINT [FK_EntrepeneurshipAdmins_Entrepeneurships_EntrepeneurshipId]
GO
ALTER TABLE [dbo].[EntrepeneurshipAdmins]  WITH CHECK ADD  CONSTRAINT [FK_EntrepeneurshipAdmins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[EntrepeneurshipAdmins] CHECK CONSTRAINT [FK_EntrepeneurshipAdmins_Users_UserId]
GO
ALTER TABLE [dbo].[Entrepeneurships]  WITH CHECK ADD  CONSTRAINT [FK_Entrepeneurships_Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
GO
ALTER TABLE [dbo].[Entrepeneurships] CHECK CONSTRAINT [FK_Entrepeneurships_Districts_DistrictId]
GO
ALTER TABLE [dbo].[Entrepeneurships]  WITH CHECK ADD  CONSTRAINT [FK_Entrepeneurships_EntrepeneurshipType_EntrepeneurshipTypeId] FOREIGN KEY([EntrepeneurshipTypeId])
REFERENCES [dbo].[EntrepeneurshipType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Entrepeneurships] CHECK CONSTRAINT [FK_Entrepeneurships_EntrepeneurshipType_EntrepeneurshipTypeId]
GO
ALTER TABLE [dbo].[EntrepeneurshipSocials]  WITH CHECK ADD  CONSTRAINT [FK_EntrepeneurshipSocials_Entrepeneurships_EntrepeneurshipId] FOREIGN KEY([EntrepeneurshipId])
REFERENCES [dbo].[Entrepeneurships] ([Id])
GO
ALTER TABLE [dbo].[EntrepeneurshipSocials] CHECK CONSTRAINT [FK_EntrepeneurshipSocials_Entrepeneurships_EntrepeneurshipId]
GO
ALTER TABLE [dbo].[EntrepeneurshipSocials]  WITH CHECK ADD  CONSTRAINT [FK_EntrepeneurshipSocials_Socials_SocialId] FOREIGN KEY([SocialId])
REFERENCES [dbo].[Socials] ([Id])
GO
ALTER TABLE [dbo].[EntrepeneurshipSocials] CHECK CONSTRAINT [FK_EntrepeneurshipSocials_Socials_SocialId]
GO
ALTER TABLE [dbo].[ForumComments]  WITH CHECK ADD  CONSTRAINT [FK_ForumComments_Forums_ForumId] FOREIGN KEY([ForumId])
REFERENCES [dbo].[Forums] ([Id])
GO
ALTER TABLE [dbo].[ForumComments] CHECK CONSTRAINT [FK_ForumComments_Forums_ForumId]
GO
ALTER TABLE [dbo].[ForumComments]  WITH CHECK ADD  CONSTRAINT [FK_ForumComments_Users_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ForumComments] CHECK CONSTRAINT [FK_ForumComments_Users_AuthorId]
GO
ALTER TABLE [dbo].[Forums]  WITH CHECK ADD  CONSTRAINT [FK_Forums_Users_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Forums] CHECK CONSTRAINT [FK_Forums_Users_AuthorId]
GO
ALTER TABLE [dbo].[OrderProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrderProducts_Inventories_InventoryId] FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventories] ([Id])
GO
ALTER TABLE [dbo].[OrderProducts] CHECK CONSTRAINT [FK_OrderProducts_Inventories_InventoryId]
GO
ALTER TABLE [dbo].[OrderProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrderProducts_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderProducts] CHECK CONSTRAINT [FK_OrderProducts_Orders_OrderId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Districts_DistrictId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Entrepeneurships_EntrepeneurshipId] FOREIGN KEY([EntrepeneurshipId])
REFERENCES [dbo].[Entrepeneurships] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Entrepeneurships_EntrepeneurshipId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_DeliveryManId] FOREIGN KEY([DeliveryManId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_DeliveryManId]
GO
ALTER TABLE [dbo].[Socials]  WITH CHECK ADD  CONSTRAINT [FK_Socials_SocialTypes_SocialTypeId] FOREIGN KEY([SocialTypeId])
REFERENCES [dbo].[SocialTypes] ([Id])
GO
ALTER TABLE [dbo].[Socials] CHECK CONSTRAINT [FK_Socials_SocialTypes_SocialTypeId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Districts_DistrictId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
ALTER TABLE [dbo].[WorkShopClients]  WITH CHECK ADD  CONSTRAINT [FK_WorkShopClients_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WorkShopClients] CHECK CONSTRAINT [FK_WorkShopClients_Users_UserId]
GO
ALTER TABLE [dbo].[WorkShopClients]  WITH CHECK ADD  CONSTRAINT [FK_WorkShopClients_Workshops_WorkshopId] FOREIGN KEY([WorkshopId])
REFERENCES [dbo].[Workshops] ([Id])
GO
ALTER TABLE [dbo].[WorkShopClients] CHECK CONSTRAINT [FK_WorkShopClients_Workshops_WorkshopId]
GO
ALTER TABLE [dbo].[WorkshopPhotos]  WITH CHECK ADD  CONSTRAINT [FK_WorkshopPhotos_Workshops_WorkshopId] FOREIGN KEY([WorkshopId])
REFERENCES [dbo].[Workshops] ([Id])
GO
ALTER TABLE [dbo].[WorkshopPhotos] CHECK CONSTRAINT [FK_WorkshopPhotos_Workshops_WorkshopId]
GO
ALTER TABLE [dbo].[Workshops]  WITH CHECK ADD  CONSTRAINT [FK_Workshops_Entrepeneurships_EntrepeneurshipId] FOREIGN KEY([EntrepeneurshipId])
REFERENCES [dbo].[Entrepeneurships] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Workshops] CHECK CONSTRAINT [FK_Workshops_Entrepeneurships_EntrepeneurshipId]
GO
ALTER TABLE [dbo].[Workshops]  WITH CHECK ADD  CONSTRAINT [FK_Workshops_WorkshopTypes_WorkshopTypeId] FOREIGN KEY([WorkshopTypeId])
REFERENCES [dbo].[WorkshopTypes] ([Id])
GO
ALTER TABLE [dbo].[Workshops] CHECK CONSTRAINT [FK_Workshops_WorkshopTypes_WorkshopTypeId]
GO
USE [master]
GO
ALTER DATABASE [CreativoDBV2] SET  READ_WRITE 
GO
