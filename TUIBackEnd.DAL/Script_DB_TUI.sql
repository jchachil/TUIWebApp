USE [master]
GO
/****** Object:  Database [TUIWebApp]    Script Date: 09/19/2018 17:23:04 ******/
CREATE DATABASE [TUIWebApp] ON  PRIMARY 
( NAME = N'TUIWebApp', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TUIWebApp.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TUIWebApp_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TUIWebApp_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TUIWebApp] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TUIWebApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TUIWebApp] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TUIWebApp] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TUIWebApp] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TUIWebApp] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TUIWebApp] SET ARITHABORT OFF
GO
ALTER DATABASE [TUIWebApp] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TUIWebApp] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TUIWebApp] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TUIWebApp] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TUIWebApp] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TUIWebApp] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TUIWebApp] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TUIWebApp] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TUIWebApp] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TUIWebApp] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TUIWebApp] SET  DISABLE_BROKER
GO
ALTER DATABASE [TUIWebApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TUIWebApp] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TUIWebApp] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TUIWebApp] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TUIWebApp] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TUIWebApp] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TUIWebApp] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TUIWebApp] SET  READ_WRITE
GO
ALTER DATABASE [TUIWebApp] SET RECOVERY FULL
GO
ALTER DATABASE [TUIWebApp] SET  MULTI_USER
GO
ALTER DATABASE [TUIWebApp] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TUIWebApp] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'TUIWebApp', N'ON'
GO
USE [TUIWebApp]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 09/19/2018 17:23:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country] ON
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (1, N'Morocco')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (2, N'France')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (3, N'Italy')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (4, N'Spain')
SET IDENTITY_INSERT [dbo].[Country] OFF
/****** Object:  Table [dbo].[Airport]    Script Date: 09/19/2018 17:23:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AirportName] [nvarchar](max) NULL,
	[AirportCode] [nvarchar](max) NULL,
	[Country_Id] [int] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Airport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Country_Id] ON [dbo].[Airport] 
(
	[Country_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Airport] ON
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (1, N'Casablanca', N'CMN', 1, 40.2, 73.5)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (2, N'Fes', N'FEZ', 1, 41.1, 60.2)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (3, N'Marrakech', N'RAK', 1, 30.1, 65.1)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (4, N'Oujda', N'OUD', 1, 20.1, 4.2)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (5, N'Rabat', N'RBA', 1, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (6, N'Lyon', N'LYS', 2, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (7, N'Marseille', N'MRS', 2, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (8, N'Charles de Gaulle Airport', N'CDG', 2, 10, 11)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (9, N'Orly Airport', N'ORY', 2, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (10, N'Strasbourg Airport', N'SXB', 2, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (11, N'Toulouse', N'TLS', 2, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (12, N'Naples', N'NAP', 3, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (13, N'Milan', N'LIN', 3, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (14, N'Bari', N'BRI', 3, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (15, N'Rome', N'FCO', 3, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (16, N'Venice', N'VCE', 3, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (17, N'Alicante', N'ALC', 4, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (18, N'Barcelona', N'BCN', 4, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (19, N'Ibiza', N'IBZ', 4, 0, 0)
INSERT [dbo].[Airport] ([Id], [AirportName], [AirportCode], [Country_Id], [Latitude], [Longitude]) VALUES (20, N'Madrid', N'MAD', 4, 0, 0)
SET IDENTITY_INSERT [dbo].[Airport] OFF
/****** Object:  Table [dbo].[Flight]    Script Date: 09/19/2018 17:23:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartureAirport_Id] [int] NOT NULL,
	[DestinationAirport_Id] [int] NOT NULL,
	[FlightDistance] [float] NOT NULL,
	[AirCratfFuelComsumpDistance] [float] NOT NULL,
	[FlightTime] [float] NOT NULL,
	[TakeOffEffort] [float] NOT NULL,
	[FuelNeeded] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Flight] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DepartureAirport_Id] ON [dbo].[Flight] 
(
	[DepartureAirport_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DestinationAirport_Id] ON [dbo].[Flight] 
(
	[DestinationAirport_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Flight] ON
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (1, 6, 18, 0, 1200.5, 3.5, 80, 4281.75)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (2, 4, 8, 1340087.0370677896, 1000.6, 2, 110, 2111.2)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (3, 5, 6, 0, 1500, 2, 200, 3200)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (4, 4, 11, 0, 1000, 2, 100, 2100)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (5, 17, 12, 0, 111, 2, 120, 342)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (6, 3, 15, 0, 13, 4, 15, 67)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (7, 19, 7, 0, 100, 1.5, 111, 261)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (8, 19, 6, 0, 1400.4, 2.5, 100.5, 3601.5)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (9, 13, 5, 0, 1700, 3.5, 400, 6350)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (35, 15, 1, 0, 1100, 2.5, 200, 2950)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (36, 6, 12, 0, 1500, 2, 100, 3100)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (37, 13, 2, 0, 1200, 2, 124, 2524)
INSERT [dbo].[Flight] ([Id], [DepartureAirport_Id], [DestinationAirport_Id], [FlightDistance], [AirCratfFuelComsumpDistance], [FlightTime], [TakeOffEffort], [FuelNeeded]) VALUES (38, 4, 15, 0, 1500, 3.5, 200, 5450)
SET IDENTITY_INSERT [dbo].[Flight] OFF
/****** Object:  Default [DF__Airport__Latitud__29572725]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Airport] ADD  DEFAULT ((0)) FOR [Latitude]
GO
/****** Object:  Default [DF__Airport__Longitu__2A4B4B5E]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Airport] ADD  DEFAULT ((0)) FOR [Longitude]
GO
/****** Object:  Default [DF__Flight__FlightDi__2B3F6F97]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Flight] ADD  DEFAULT ((0)) FOR [FlightDistance]
GO
/****** Object:  Default [DF__Flight__AirCratf__2C3393D0]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Flight] ADD  DEFAULT ((0)) FOR [AirCratfFuelComsumpDistance]
GO
/****** Object:  Default [DF__Flight__FlightTi__2D27B809]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Flight] ADD  DEFAULT ((0)) FOR [FlightTime]
GO
/****** Object:  Default [DF__Flight__TakeOffE__2E1BDC42]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Flight] ADD  DEFAULT ((0)) FOR [TakeOffEffort]
GO
/****** Object:  Default [DF__Flight__FuelNeed__2F10007B]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Flight] ADD  DEFAULT ((0)) FOR [FuelNeeded]
GO
/****** Object:  ForeignKey [FK_dbo.Airport_dbo.Country_Country_Id]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Airport]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Airport_dbo.Country_Country_Id] FOREIGN KEY([Country_Id])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Airport] CHECK CONSTRAINT [FK_dbo.Airport_dbo.Country_Country_Id]
GO
/****** Object:  ForeignKey [FK_dbo.Flight_dbo.Airport_DepartureAirport_Id]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Flight_dbo.Airport_DepartureAirport_Id] FOREIGN KEY([DepartureAirport_Id])
REFERENCES [dbo].[Airport] ([Id])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_dbo.Flight_dbo.Airport_DepartureAirport_Id]
GO
/****** Object:  ForeignKey [FK_dbo.Flight_dbo.Airport_DestinationAirport_Id]    Script Date: 09/19/2018 17:23:05 ******/
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Flight_dbo.Airport_DestinationAirport_Id] FOREIGN KEY([DestinationAirport_Id])
REFERENCES [dbo].[Airport] ([Id])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_dbo.Flight_dbo.Airport_DestinationAirport_Id]
GO
