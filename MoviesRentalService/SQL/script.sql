USE [master]
GO

/****** Object:  Database [MoviesRental]    Script Date: 12/6/2023 9:17:12 PM ******/
CREATE DATABASE [MoviesRental]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MoviesRental', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MoviesRental.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MoviesRental_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MoviesRental_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoviesRental].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MoviesRental] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MoviesRental] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MoviesRental] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MoviesRental] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MoviesRental] SET ARITHABORT OFF 
GO

ALTER DATABASE [MoviesRental] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MoviesRental] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MoviesRental] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MoviesRental] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MoviesRental] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MoviesRental] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MoviesRental] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MoviesRental] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MoviesRental] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MoviesRental] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MoviesRental] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MoviesRental] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MoviesRental] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MoviesRental] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MoviesRental] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MoviesRental] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MoviesRental] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MoviesRental] SET RECOVERY FULL 
GO

ALTER DATABASE [MoviesRental] SET  MULTI_USER 
GO

ALTER DATABASE [MoviesRental] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MoviesRental] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MoviesRental] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MoviesRental] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MoviesRental] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MoviesRental] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [MoviesRental] SET QUERY_STORE = ON
GO

ALTER DATABASE [MoviesRental] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [MoviesRental] SET  READ_WRITE 
GO

--Table script

USE [MoviesRental]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 12/6/2023 9:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieRental]    Script Date: 12/6/2023 9:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieRental](
	[MovieRentalId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[IsRented] [bit] NULL,
	[DateRented] [datetime] NULL,
 CONSTRAINT [PK_MovieRental] PRIMARY KEY CLUSTERED 
(
	[MovieRentalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/6/2023 9:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Password] [nvarchar](max) NULL,
	[IsAdmin] [bit] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
