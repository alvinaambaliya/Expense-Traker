USE [master]
GO
/****** Object:  Database [ExpensetrackerDB]    Script Date: 11-01-2023 10:16:28 ******/
CREATE DATABASE [ExpensetrackerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExpensetrackerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExpensetrackerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExpensetrackerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExpensetrackerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ExpensetrackerDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExpensetrackerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExpensetrackerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExpensetrackerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExpensetrackerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExpensetrackerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExpensetrackerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExpensetrackerDB] SET  MULTI_USER 
GO
ALTER DATABASE [ExpensetrackerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExpensetrackerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExpensetrackerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExpensetrackerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExpensetrackerDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExpensetrackerDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ExpensetrackerDB] SET QUERY_STORE = OFF
GO
USE [ExpensetrackerDB]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 11-01-2023 10:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[Category_name] [varchar](50) NOT NULL,
	[Category_expense_limit] [int] NOT NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[Category_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[expense_limit]    Script Date: 11-01-2023 10:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expense_limit](
	[e_id] [int] IDENTITY(1,1) NOT NULL,
	[Total_expense] [int] NOT NULL,
	[Total_expense_limit] [int] NOT NULL,
 CONSTRAINT [PK_expense_limit] PRIMARY KEY CLUSTERED 
(
	[e_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[expenses]    Script Date: 11-01-2023 10:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Date_Time] [datetime] NOT NULL,
	[Category_name] [varchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_expenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[categories] ([Category_name], [Category_expense_limit]) VALUES (N'device', 500)
INSERT [dbo].[categories] ([Category_name], [Category_expense_limit]) VALUES (N'food', 10000)
INSERT [dbo].[categories] ([Category_name], [Category_expense_limit]) VALUES (N'sports', 5000)
INSERT [dbo].[categories] ([Category_name], [Category_expense_limit]) VALUES (N'travel', 5000)
GO
SET IDENTITY_INSERT [dbo].[expense_limit] ON 

INSERT [dbo].[expense_limit] ([e_id], [Total_expense], [Total_expense_limit]) VALUES (1, 50000, 500000)
INSERT [dbo].[expense_limit] ([e_id], [Total_expense], [Total_expense_limit]) VALUES (8, 45687, 78990)
SET IDENTITY_INSERT [dbo].[expense_limit] OFF
GO
SET IDENTITY_INSERT [dbo].[expenses] ON 

INSERT [dbo].[expenses] ([Id], [Title], [Description], [Date_Time], [Category_name], [Amount]) VALUES (5, N'laptop', N'for work', CAST(N'2021-12-23T00:00:00.000' AS DateTime), N'device', 1000)
INSERT [dbo].[expenses] ([Id], [Title], [Description], [Date_Time], [Category_name], [Amount]) VALUES (6, N'bluetooth speaker', N'for listening the song', CAST(N'2021-12-23T00:00:00.000' AS DateTime), N'device', 1500)
INSERT [dbo].[expenses] ([Id], [Title], [Description], [Date_Time], [Category_name], [Amount]) VALUES (7, N'launch', N'for launch', CAST(N'2023-01-08T22:41:29.927' AS DateTime), N'food', 500)
INSERT [dbo].[expenses] ([Id], [Title], [Description], [Date_Time], [Category_name], [Amount]) VALUES (16, N'jeans', N'for college', CAST(N'2022-12-25T17:08:40.863' AS DateTime), N'clothes', 500)
INSERT [dbo].[expenses] ([Id], [Title], [Description], [Date_Time], [Category_name], [Amount]) VALUES (1012, N'kashmir', N'for ', CAST(N'2022-12-29T20:42:28.657' AS DateTime), N'travel', 10000)
INSERT [dbo].[expenses] ([Id], [Title], [Description], [Date_Time], [Category_name], [Amount]) VALUES (2017, N'ajshddgfh', N'jahsdgg', CAST(N'2023-01-08T11:34:58.023' AS DateTime), N'food', 12345)
SET IDENTITY_INSERT [dbo].[expenses] OFF
GO
ALTER TABLE [dbo].[expenses]  WITH CHECK ADD  CONSTRAINT [FK_expenses_expenses] FOREIGN KEY([Id])
REFERENCES [dbo].[expenses] ([Id])
GO
ALTER TABLE [dbo].[expenses] CHECK CONSTRAINT [FK_expenses_expenses]
GO
USE [master]
GO
ALTER DATABASE [ExpensetrackerDB] SET  READ_WRITE 
GO
