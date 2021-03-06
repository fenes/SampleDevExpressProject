USE [master]
GO
/****** Object:  Database [SampleDevExpressDB]    Script Date: 16.05.2020 23:35:56 ******/
CREATE DATABASE [SampleDevExpressDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SampleDevExpressDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SampleDevExpressDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SampleDevExpressDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SampleDevExpressDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
GO
USE [SampleDevExpressDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 16.05.2020 23:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Town] [nvarchar](100) NOT NULL,
	[Country] [nvarchar](100) NOT NULL,
	[Telephone] [nvarchar](100) NOT NULL,
	[TaxNumber] [nvarchar](50) NOT NULL,
	[TCKNumber] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[WebAddress] [nvarchar](100) NULL,
	[AccountType] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [SampleDevExpressDB] SET  READ_WRITE 
GO

USE [SampleDevExpressDB]
GO
INSERT INTO [dbo].[Account]
([Code],[Name],[Surname],[Address],[Town],[Country],[Telephone],[TaxNumber],[TCKNumber],[Email],[WebAddress],[AccountType],[Created],[Updated])
VALUES
('UK-07' ,'John ','Doe','X region, 07100','LA','USA','55 222 11 55','784424','454755774225','contact@john.com','john.com',1,GETDATE(),GETDATE())


INSERT INTO [dbo].[Account]
([Code],[Name],[Surname],[Address],[Town],[Country],[Telephone],[TaxNumber],[TCKNumber],[Email],[WebAddress],[AccountType],[Created],[Updated])
VALUES
('UK-08' ,'John ','Wick','Y region','LA','USA','77 874 11 55','234234','8679867965','contact@john.com','john.com',1,GETDATE(),GETDATE())


INSERT INTO [dbo].[Account]
([Code],[Name],[Surname],[Address],[Town],[Country],[Telephone],[TaxNumber],[TCKNumber],[Email],[WebAddress],[AccountType],[Created],[Updated])
VALUES
('UK-09' ,'Batman ','Doe','London Bridge','London','UK','55 222 11 55','784424','56456','contact@batman.com','batman.com',2,GETDATE(),GETDATE())


INSERT INTO [dbo].[Account]
([Code],[Name],[Surname],[Address],[Town],[Country],[Telephone],[TaxNumber],[TCKNumber],[Email],[WebAddress],[AccountType],[Created],[Updated])
VALUES
('UK-99' ,'Hulk ','Monster','Brooklyn ','NYC','USA','88 145 65 85','244542','4521402133','contact@hulk.com','hulk.com',2,GETDATE(),GETDATE())

