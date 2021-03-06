USE [master]
GO
/****** Object:  Database [DBSalary]    Script Date: 3/27/2016 2:53:17 AM ******/
CREATE DATABASE [DBSalary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBSalary', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBSalary.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBSalary_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBSalary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBSalary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBSalary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBSalary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBSalary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBSalary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBSalary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBSalary] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBSalary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBSalary] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBSalary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBSalary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBSalary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBSalary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBSalary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBSalary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBSalary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBSalary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBSalary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBSalary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBSalary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBSalary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBSalary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBSalary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBSalary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBSalary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBSalary] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBSalary] SET  MULTI_USER 
GO
ALTER DATABASE [DBSalary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBSalary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBSalary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBSalary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBSalary]
GO
/****** Object:  Table [dbo].[People]    Script Date: 3/27/2016 2:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [varchar](150) NOT NULL,
	[SalaryDate] [date] NOT NULL,
	[IdSalary] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PeoplesSalary]    Script Date: 3/27/2016 2:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeoplesSalary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [real] NOT NULL,
 CONSTRAINT [PK_PeoplesSalary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (1, N'Roman Lopalov Tychkov', CAST(0x943B0B00 AS Date), 1)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (2, N'Kirill Katraga Alexeev', CAST(0xB33B0B00 AS Date), 2)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (3, N'Vitor Rokov Lomonov', CAST(0xB33B0B00 AS Date), 3)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (4, N'Zoro Kolimov Robanov', CAST(0x943B0B00 AS Date), 4)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (5, N'Firsttt', CAST(0xB33B0B00 AS Date), 5)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (6, N'First', CAST(0x07380B00 AS Date), 6)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (7, N'Second', CAST(0x26380B00 AS Date), 7)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (8, N'Third', CAST(0x42380B00 AS Date), 5)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (9, N'Firsttt', CAST(0xB33B0B00 AS Date), 5)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (10, N'First', CAST(0x07380B00 AS Date), 6)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (11, N'Second', CAST(0x26380B00 AS Date), 7)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (12, N'Third', CAST(0x42380B00 AS Date), 5)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (13, N'Firsttt', CAST(0xB33B0B00 AS Date), 5)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (14, N'First', CAST(0x07380B00 AS Date), 6)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (15, N'Second', CAST(0x26380B00 AS Date), 7)
INSERT [dbo].[People] ([Id], [FIO], [SalaryDate], [IdSalary]) VALUES (16, N'Third', CAST(0x42380B00 AS Date), 5)
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[PeoplesSalary] ON 

INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (1, 30050)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (2, 48000.8)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (3, 55000.6)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (4, 38000.5)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (5, 3000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (6, 1000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (7, 2000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (8, 3000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (9, 3000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (10, 1000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (11, 2000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (12, 3000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (13, 3000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (14, 1000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (15, 2000.23)
INSERT [dbo].[PeoplesSalary] ([Id], [Salary]) VALUES (16, 3000.23)
SET IDENTITY_INSERT [dbo].[PeoplesSalary] OFF
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_PeoplesSalary] FOREIGN KEY([IdSalary])
REFERENCES [dbo].[PeoplesSalary] ([Id])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_PeoplesSalary]
GO
USE [master]
GO
ALTER DATABASE [DBSalary] SET  READ_WRITE 
GO
