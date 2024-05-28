# Gestran API

## Description
API for Gestran, responsible for mange vehicle inspections.
Architecture explain:</br>
I Have 5 layers based on DDD:
</br>
WebAPI -> Layer with Api swagger, controller, configurations.</br>
Applicaton - > Bussiness Logic Layer.</br>
Core -> Models, Dto, Entities and Interfaces of Business, Services, WebServices and Repositorys</br>
Infraestructure -> Persistence, Services and Connected Services.</br>
TestsBusinessAPI -> Layer of Business test.

## 🚀 Installation/Implemetation
To run project in local you should have instaled the SDK for .net core 8 and a database in SQL SERVER with the database below:
<details>
  <summary>Click to show/hide</summary>
  
```sql
USE [master]
GO
/****** Object:  Database [GenericEnterprise]    Script Date: 22/05/2024 03:42:22 ******/
CREATE DATABASE [GenericEnterprise]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GenericEnterprise', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GenericEnterprise.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GenericEnterprise_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GenericEnterprise_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GenericEnterprise] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GenericEnterprise].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GenericEnterprise] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ARITHABORT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GenericEnterprise] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GenericEnterprise] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GenericEnterprise] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GenericEnterprise] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GenericEnterprise] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GenericEnterprise] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GenericEnterprise] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GenericEnterprise] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GenericEnterprise] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GenericEnterprise] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GenericEnterprise] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GenericEnterprise] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GenericEnterprise] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GenericEnterprise] SET  MULTI_USER 
GO
ALTER DATABASE [GenericEnterprise] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GenericEnterprise] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GenericEnterprise] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GenericEnterprise] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GenericEnterprise] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GenericEnterprise] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GenericEnterprise] SET QUERY_STORE = OFF
GO
USE [GenericEnterprise]
GO
/****** Object:  Table [dbo].[GE_AUTHentications]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_AUTHentications](
	[Id_AUTH] [int] IDENTITY(1,1) NOT NULL,
	[Name_AUTH] [nvarchar](255) NOT NULL,
	[DisplayName_AUTH] [nvarchar](255) NOT NULL,
	[IsActive_AUTH] [bit] NOT NULL,
	[IsDeleted_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK_GE_AUTHentications] PRIMARY KEY CLUSTERED 
(
	[Id_AUTH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_Inspectable]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_Inspectable](
	[InspectableId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK__GE_Inspe__CC03D86849BB3767] PRIMARY KEY CLUSTERED 
(
	[InspectableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_InspectableType]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_InspectableType](
	[VehicleTypeId] [int] NOT NULL,
	[InspectableId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_Inspection]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_Inspection](
	[InspectionId] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NULL,
	[InspectorId] [int] NULL,
	[StatusId] [int] NULL,
	[Comment] [nvarchar](255) NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
 CONSTRAINT [PK__GE_Inspe__30B2DC083F6D4130] PRIMARY KEY CLUSTERED 
(
	[InspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_InspectionDetail]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_InspectionDetail](
	[InspectionDetailId] [int] IDENTITY(1,1) NOT NULL,
	[InspectionId] [int] NULL,
	[InspectableId] [int] NULL,
	[Result] [nvarchar](50) NULL,
	[Observation] [nvarchar](255) NULL,
 CONSTRAINT [PK__GE_Inspe__F9BA6C2DCA6B62BD] PRIMARY KEY CLUSTERED 
(
	[InspectionDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_InspectionStatus]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_InspectionStatus](
	[StatusId] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK__GE_Inspe__C8EE206346FCB43F] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_MEmberOF]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_MEmberOF](
	[Id_MEOF] [int] IDENTITY(1,1) NOT NULL,
	[Id_USER] [int] NOT NULL,
	[Id_PROF] [int] NOT NULL,
 CONSTRAINT [PK_GE_MEmberOF] PRIMARY KEY CLUSTERED 
(
	[Id_MEOF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_PROFiles]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_PROFiles](
	[Id_PROF] [int] IDENTITY(1,1) NOT NULL,
	[Name_PROF] [nvarchar](255) NOT NULL,
	[DisplayName_PROF] [nvarchar](255) NOT NULL,
	[IsActive_PROF] [bit] NOT NULL,
	[IsDeleted_PROF] [bit] NOT NULL,
 CONSTRAINT [PK_GE_PROFiles] PRIMARY KEY CLUSTERED 
(
	[Id_PROF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_USERs]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_USERs](
	[Id_USER] [int] IDENTITY(1,1) NOT NULL,
	[Id_AUTH] [int] NOT NULL,
	[FirstName_USER] [nvarchar](255) NOT NULL,
	[LastName_USER] [nvarchar](255) NOT NULL,
	[JobTitle_USER] [nvarchar](255) NULL,
	[Login_USER] [nvarchar](255) NOT NULL,
	[Mail_USER] [nvarchar](255) NOT NULL,
	[Password_USER] [nvarchar](255) NULL,
	[Phone_USER] [nvarchar](20) NULL,
	[Photo_USER] [nvarchar](max) NULL,
	[IsActive_USER] [bit] NOT NULL,
	[IsDeleted_USER] [bit] NOT NULL,
 CONSTRAINT [PK_GE_USERs] PRIMARY KEY CLUSTERED 
(
	[Id_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_Vehicle]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_Vehicle](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [nvarchar](20) NULL,
	[VehicleTypeId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[LastInspection] [datetime2](7) NULL,
	[LastInspectorUserId] [int] NULL,
	[IsBeingInspected] [bit] NULL,
 CONSTRAINT [PK__GE_Vehic__476B5492D397F901] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_VehicleType]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_VehicleType](
	[VehicleTypeId] [int] NOT NULL,
	[Brand] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[Year] [int] NULL,
	[Feature1] [nvarchar](50) NULL,
	[Feature2] [nvarchar](50) NULL,
	[Feature3] [nvarchar](50) NULL,
 CONSTRAINT [PK__GE_Vehic__9F44964359283529] PRIMARY KEY CLUSTERED 
(
	[VehicleTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GE_AUTHentications] ON 
GO
INSERT [dbo].[GE_AUTHentications] ([Id_AUTH], [Name_AUTH], [DisplayName_AUTH], [IsActive_AUTH], [IsDeleted_AUTH]) VALUES (1, N'AD', N'Active Directory', 1, 0)
GO
INSERT [dbo].[GE_AUTHentications] ([Id_AUTH], [Name_AUTH], [DisplayName_AUTH], [IsActive_AUTH], [IsDeleted_AUTH]) VALUES (2, N'GE', N'Generic Enterprise', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[GE_AUTHentications] OFF
GO
SET IDENTITY_INSERT [dbo].[GE_Inspectable] ON 
GO
INSERT [dbo].[GE_Inspectable] ([InspectableId], [Name], [Description]) VALUES (1, N'Volante', N'Inspeciona se houve avarias no volante')
GO
INSERT [dbo].[GE_Inspectable] ([InspectableId], [Name], [Description]) VALUES (2, N'Rodas', N'Inspeciona se houve avarias em todas as rodas')
GO
INSERT [dbo].[GE_Inspectable] ([InspectableId], [Name], [Description]) VALUES (3, N'Pintura', N'Inspeciona se houve avarias na pintura externa')
GO
INSERT [dbo].[GE_Inspectable] ([InspectableId], [Name], [Description]) VALUES (4, N'Banco do Motorista', N'Inspeciona se houve avarias no banco do motorista')
GO
SET IDENTITY_INSERT [dbo].[GE_Inspectable] OFF
GO
INSERT [dbo].[GE_InspectableType] ([VehicleTypeId], [InspectableId]) VALUES (1, 1)
GO
INSERT [dbo].[GE_InspectableType] ([VehicleTypeId], [InspectableId]) VALUES (1, 2)
GO
INSERT [dbo].[GE_InspectableType] ([VehicleTypeId], [InspectableId]) VALUES (1, 3)
GO
INSERT [dbo].[GE_InspectableType] ([VehicleTypeId], [InspectableId]) VALUES (1, 4)
GO
INSERT [dbo].[GE_InspectionStatus] ([StatusId], [Description]) VALUES (1, N'Inspection Just Open')
GO
INSERT [dbo].[GE_InspectionStatus] ([StatusId], [Description]) VALUES (2, N'Inspection Filled')
GO
INSERT [dbo].[GE_InspectionStatus] ([StatusId], [Description]) VALUES (3, N'Inspection Aproved')
GO
INSERT [dbo].[GE_InspectionStatus] ([StatusId], [Description]) VALUES (4, N'Inspection Rejected')
GO
SET IDENTITY_INSERT [dbo].[GE_MEmberOF] ON 
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (6, 2, 3)
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (7, 3, 2)
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (8, 4, 1)
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (9, 5, 1)
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (10, 6, 2)
GO
SET IDENTITY_INSERT [dbo].[GE_MEmberOF] OFF
GO
SET IDENTITY_INSERT [dbo].[GE_PROFiles] ON 
GO
INSERT [dbo].[GE_PROFiles] ([Id_PROF], [Name_PROF], [DisplayName_PROF], [IsActive_PROF], [IsDeleted_PROF]) VALUES (1, N'USER', N'Utilizador', 1, 0)
GO
INSERT [dbo].[GE_PROFiles] ([Id_PROF], [Name_PROF], [DisplayName_PROF], [IsActive_PROF], [IsDeleted_PROF]) VALUES (2, N'ADM', N'Administrador', 1, 0)
GO
INSERT [dbo].[GE_PROFiles] ([Id_PROF], [Name_PROF], [DisplayName_PROF], [IsActive_PROF], [IsDeleted_PROF]) VALUES (3, N'SYSA', N'Administrador do Sistema', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[GE_PROFiles] OFF
GO
SET IDENTITY_INSERT [dbo].[GE_USERs] ON 
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (2, 2, N'Francisco', N'Holanda', N'Dev', N'francisco.holanda', N'francisco.holanda@teste.com', N'JQ52ynJj3EZhziBKhlw9vxFi7ITBAeFJKIOsSEHXXIc=', N'5511994428427', NULL, 1, 0)
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (3, 2, N'Teste', N'Usuario', N'Tester', N'teste.teste', N'teste@teste.com', N'aEncIPQ04wp9pPRqQjqHj/9/Q4kY49gOxKVcsHmUBLw=', N'551994428427', N'string', 1, 0)
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (4, 2, N'Rodrigo', N'Silva', N'Supervisor', N'rod123', N'rod123@hotmail.com', N'kCOsuzajWvvR43iT0JuvKVJWDAIG1JiRB3QYi4i02nc=', N'11912345678', N'string', 1, 0)
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (5, 2, N'teste', N'teste', N'tester', N'teste123', N'teste@teste.com', N'BZN/adjkV2v3y/dyrz9yeKSCdvDeFRoJgkK3rzmvu4s=', N'11912345678', N'string', 1, 0)
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (6, 2, N'ADMIN', N'TESTER', N'SYSADMIN', N'admin123', N'admin@teste.com', N'lPNBEbt1ZsEA1yk8/IX+LN1oBo7rdtN6q/6xxm9e9jE=', N'11912345678', N'string', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[GE_USERs] OFF
GO
SET IDENTITY_INSERT [dbo].[GE_Vehicle] ON 
GO
INSERT [dbo].[GE_Vehicle] ([VehicleId], [LicensePlate], [VehicleTypeId], [Name], [LastInspection], [LastInspectorUserId], [IsBeingInspected]) VALUES (1, N'AAA1010', 1, N'Veiculo de transporte de mercadoria', CAST(N'2024-05-21T22:41:54.1200000' AS DateTime2), 0, 0)
GO
SET IDENTITY_INSERT [dbo].[GE_Vehicle] OFF
GO
INSERT [dbo].[GE_VehicleType] ([VehicleTypeId], [Brand], [Model], [Year], [Feature1], [Feature2], [Feature3]) VALUES (1, N'GM', N'Kadet', 1990, N'Ar Condicionado', N'Completo', N'Trava Elétrica')
GO
INSERT [dbo].[GE_VehicleType] ([VehicleTypeId], [Brand], [Model], [Year], [Feature1], [Feature2], [Feature3]) VALUES (2, N'FORD', N'KA', 2015, N'', N'', N'')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GE_USERs]    Script Date: 22/05/2024 03:42:22 ******/
ALTER TABLE [dbo].[GE_USERs] ADD  CONSTRAINT [IX_GE_USERs] UNIQUE NONCLUSTERED 
(
	[Login_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GE_AUTHentications] ADD  CONSTRAINT [DF_GE_AUTHentications_IsActive_AUTH]  DEFAULT ((1)) FOR [IsActive_AUTH]
GO
ALTER TABLE [dbo].[GE_AUTHentications] ADD  CONSTRAINT [DF_GE_AUTHentications_IsDeleted_AUTH]  DEFAULT ((0)) FOR [IsDeleted_AUTH]
GO
ALTER TABLE [dbo].[GE_PROFiles] ADD  CONSTRAINT [DF_GE_PROFiles_IsActive_PROF]  DEFAULT ((1)) FOR [IsActive_PROF]
GO
ALTER TABLE [dbo].[GE_PROFiles] ADD  CONSTRAINT [DF_GE_PROFiles_IsDeleted_PROF]  DEFAULT ((0)) FOR [IsDeleted_PROF]
GO
ALTER TABLE [dbo].[GE_USERs] ADD  CONSTRAINT [DF_GE_USERs_IsActive_USER]  DEFAULT ((1)) FOR [IsActive_USER]
GO
ALTER TABLE [dbo].[GE_USERs] ADD  CONSTRAINT [DF_GE_USERs_IsDeleted_USER]  DEFAULT ((0)) FOR [IsDeleted_USER]
GO
ALTER TABLE [dbo].[GE_InspectableType]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Inspe__0A9D95DB] FOREIGN KEY([InspectableId])
REFERENCES [dbo].[GE_Inspectable] ([InspectableId])
GO
ALTER TABLE [dbo].[GE_InspectableType] CHECK CONSTRAINT [FK__GE_Inspec__Inspe__0A9D95DB]
GO
ALTER TABLE [dbo].[GE_InspectableType]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Vehic__09A971A2] FOREIGN KEY([VehicleTypeId])
REFERENCES [dbo].[GE_VehicleType] ([VehicleTypeId])
GO
ALTER TABLE [dbo].[GE_InspectableType] CHECK CONSTRAINT [FK__GE_Inspec__Vehic__09A971A2]
GO
ALTER TABLE [dbo].[GE_Inspection]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Statu__10566F31] FOREIGN KEY([StatusId])
REFERENCES [dbo].[GE_InspectionStatus] ([StatusId])
GO
ALTER TABLE [dbo].[GE_Inspection] CHECK CONSTRAINT [FK__GE_Inspec__Statu__10566F31]
GO
ALTER TABLE [dbo].[GE_Inspection]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Vehic__0F624AF8] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[GE_Vehicle] ([VehicleId])
GO
ALTER TABLE [dbo].[GE_Inspection] CHECK CONSTRAINT [FK__GE_Inspec__Vehic__0F624AF8]
GO
ALTER TABLE [dbo].[GE_InspectionDetail]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Inspe__1332DBDC] FOREIGN KEY([InspectionId])
REFERENCES [dbo].[GE_Inspection] ([InspectionId])
GO
ALTER TABLE [dbo].[GE_InspectionDetail] CHECK CONSTRAINT [FK__GE_Inspec__Inspe__1332DBDC]
GO
ALTER TABLE [dbo].[GE_InspectionDetail]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Inspe__14270015] FOREIGN KEY([InspectableId])
REFERENCES [dbo].[GE_Inspectable] ([InspectableId])
GO
ALTER TABLE [dbo].[GE_InspectionDetail] CHECK CONSTRAINT [FK__GE_Inspec__Inspe__14270015]
GO
ALTER TABLE [dbo].[GE_MEmberOF]  WITH CHECK ADD  CONSTRAINT [FK_GE_MEmberOF_GE_PROFiles] FOREIGN KEY([Id_PROF])
REFERENCES [dbo].[GE_PROFiles] ([Id_PROF])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GE_MEmberOF] CHECK CONSTRAINT [FK_GE_MEmberOF_GE_PROFiles]
GO
ALTER TABLE [dbo].[GE_MEmberOF]  WITH CHECK ADD  CONSTRAINT [FK_GE_MEmberOF_GE_USERs] FOREIGN KEY([Id_USER])
REFERENCES [dbo].[GE_USERs] ([Id_USER])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GE_MEmberOF] CHECK CONSTRAINT [FK_GE_MEmberOF_GE_USERs]
GO
ALTER TABLE [dbo].[GE_USERs]  WITH CHECK ADD  CONSTRAINT [FK_GE_USERs_GE_AUTHentications] FOREIGN KEY([Id_AUTH])
REFERENCES [dbo].[GE_AUTHentications] ([Id_AUTH])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GE_USERs] CHECK CONSTRAINT [FK_GE_USERs_GE_AUTHentications]
GO
ALTER TABLE [dbo].[GE_Vehicle]  WITH CHECK ADD  CONSTRAINT [FK__GE_Vehicl__Vehic__04E4BC85] FOREIGN KEY([VehicleTypeId])
REFERENCES [dbo].[GE_VehicleType] ([VehicleTypeId])
GO
ALTER TABLE [dbo].[GE_Vehicle] CHECK CONSTRAINT [FK__GE_Vehicl__Vehic__04E4BC85]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_AUTHentications', @level2type=N'COLUMN',@level2name=N'IsActive_AUTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_AUTHentications', @level2type=N'COLUMN',@level2name=N'IsDeleted_AUTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_PROFiles', @level2type=N'COLUMN',@level2name=N'IsActive_PROF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_PROFiles', @level2type=N'COLUMN',@level2name=N'IsDeleted_PROF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_USERs', @level2type=N'COLUMN',@level2name=N'IsActive_USER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_USERs', @level2type=N'COLUMN',@level2name=N'IsDeleted_USER'
GO
USE [master]
GO
ALTER DATABASE [GenericEnterprise] SET  READ_WRITE 
GO

```
</details>

## 📋 Usage
The Swagger is ready to use, if you run the project as Debug mode it will be not necessary to authenticate to call other methods, but if you dont, you have to authenticate with a login and password, use the Creat User endpoint to creat a User.

## ♾️ Business worflow explanation and logic to be applied back-front
1 - Create users, With job title Inspector and Supervisor for example;</br>
2 - Crerate a Vehicle Type, Inspectables, Create the relation between then;</br>
3 - Create a Vehicle.</br>
4 - Create a new Inspection, this will lock so any others can open another Inspection</br>
5 - Insert the information about the inspectables, i made this in a dynamic way, so the front can only show exact what show be inspected and answered.</br>
6 - A Supervisor have to approve or reject te inspection, after this another inspection could be initialized.
* - To get your first Token you can use {"mail": "admin@teste.com", "password": "123456"}

## 🤝 TODO list
More and better test;</br>
Cloud publish(Dockerfile and conteinerization);</br>
Generics CRUDs;</br>

## ☝️ Sugestions
Workflow System to enchance Inspection and other procces related;</br>
Define and controle what profile could access each end-point;</br>

## 🖥️ Used Technologies
NET CORE 8;</br>
SQL SERVER EXPRESS;</br>
Data Annotations;</br>
AutoMapper;</br>
Entity Framework;</br>
Swagger;</br>
JWT;</br>
xUnit;

## 📝 License
Only for study and non-distributable.
# [PT-BR]

# Gestran API

## Descrição
API para o Gestran, responsável pelo gerenciamento de inspeções de veículos.
Explicação da arquitetura:</br>
Tenho 5 camadas baseadas em DDD:
</br>
WebAPI -> Camada com Swagger, controladores, configurações da API.</br>
Application -> Camada de Lógica de Negócios.</br>
Core -> Modelos, DTOs, Entidades e Interfaces de Negócios, Serviços, WebServices e Repositórios.</br>
Infrastructure -> Persistência, Serviços e Serviços Conectados.</br>
TestsBusinessAPI -> Camada de teste de Negócios.

## 🚀 Instalação/Implementação
Para executar o projeto localmente, você deve ter instalado o SDK do .NET Core 8 e um banco de dados SQL SERVER com o banco de dados abaixo:
<details>
  <summary>Click to show/hide</summary>
  
```sql
USE [master]
GO
/****** Object:  Database [GenericEnterprise]    Script Date: 22/05/2024 03:42:22 ******/
CREATE DATABASE [GenericEnterprise]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GenericEnterprise', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GenericEnterprise.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GenericEnterprise_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GenericEnterprise_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GenericEnterprise] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GenericEnterprise].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GenericEnterprise] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ARITHABORT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GenericEnterprise] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GenericEnterprise] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GenericEnterprise] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GenericEnterprise] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GenericEnterprise] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GenericEnterprise] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GenericEnterprise] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GenericEnterprise] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GenericEnterprise] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GenericEnterprise] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GenericEnterprise] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GenericEnterprise] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GenericEnterprise] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GenericEnterprise] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GenericEnterprise] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GenericEnterprise] SET  MULTI_USER 
GO
ALTER DATABASE [GenericEnterprise] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GenericEnterprise] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GenericEnterprise] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GenericEnterprise] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GenericEnterprise] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GenericEnterprise] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GenericEnterprise] SET QUERY_STORE = OFF
GO
USE [GenericEnterprise]
GO
/****** Object:  Table [dbo].[GE_AUTHentications]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_AUTHentications](
	[Id_AUTH] [int] IDENTITY(1,1) NOT NULL,
	[Name_AUTH] [nvarchar](255) NOT NULL,
	[DisplayName_AUTH] [nvarchar](255) NOT NULL,
	[IsActive_AUTH] [bit] NOT NULL,
	[IsDeleted_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK_GE_AUTHentications] PRIMARY KEY CLUSTERED 
(
	[Id_AUTH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_Inspectable]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_Inspectable](
	[InspectableId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK__GE_Inspe__CC03D86849BB3767] PRIMARY KEY CLUSTERED 
(
	[InspectableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_InspectableType]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_InspectableType](
	[VehicleTypeId] [int] NOT NULL,
	[InspectableId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_Inspection]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_Inspection](
	[InspectionId] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NULL,
	[InspectorId] [int] NULL,
	[StatusId] [int] NULL,
	[Comment] [nvarchar](255) NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
 CONSTRAINT [PK__GE_Inspe__30B2DC083F6D4130] PRIMARY KEY CLUSTERED 
(
	[InspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_InspectionDetail]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_InspectionDetail](
	[InspectionDetailId] [int] IDENTITY(1,1) NOT NULL,
	[InspectionId] [int] NULL,
	[InspectableId] [int] NULL,
	[Result] [nvarchar](50) NULL,
	[Observation] [nvarchar](255) NULL,
 CONSTRAINT [PK__GE_Inspe__F9BA6C2DCA6B62BD] PRIMARY KEY CLUSTERED 
(
	[InspectionDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_InspectionStatus]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_InspectionStatus](
	[StatusId] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK__GE_Inspe__C8EE206346FCB43F] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_MEmberOF]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_MEmberOF](
	[Id_MEOF] [int] IDENTITY(1,1) NOT NULL,
	[Id_USER] [int] NOT NULL,
	[Id_PROF] [int] NOT NULL,
 CONSTRAINT [PK_GE_MEmberOF] PRIMARY KEY CLUSTERED 
(
	[Id_MEOF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_PROFiles]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_PROFiles](
	[Id_PROF] [int] IDENTITY(1,1) NOT NULL,
	[Name_PROF] [nvarchar](255) NOT NULL,
	[DisplayName_PROF] [nvarchar](255) NOT NULL,
	[IsActive_PROF] [bit] NOT NULL,
	[IsDeleted_PROF] [bit] NOT NULL,
 CONSTRAINT [PK_GE_PROFiles] PRIMARY KEY CLUSTERED 
(
	[Id_PROF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_USERs]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_USERs](
	[Id_USER] [int] IDENTITY(1,1) NOT NULL,
	[Id_AUTH] [int] NOT NULL,
	[FirstName_USER] [nvarchar](255) NOT NULL,
	[LastName_USER] [nvarchar](255) NOT NULL,
	[JobTitle_USER] [nvarchar](255) NULL,
	[Login_USER] [nvarchar](255) NOT NULL,
	[Mail_USER] [nvarchar](255) NOT NULL,
	[Password_USER] [nvarchar](255) NULL,
	[Phone_USER] [nvarchar](20) NULL,
	[Photo_USER] [nvarchar](max) NULL,
	[IsActive_USER] [bit] NOT NULL,
	[IsDeleted_USER] [bit] NOT NULL,
 CONSTRAINT [PK_GE_USERs] PRIMARY KEY CLUSTERED 
(
	[Id_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_Vehicle]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_Vehicle](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [nvarchar](20) NULL,
	[VehicleTypeId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[LastInspection] [datetime2](7) NULL,
	[LastInspectorUserId] [int] NULL,
	[IsBeingInspected] [bit] NULL,
 CONSTRAINT [PK__GE_Vehic__476B5492D397F901] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GE_VehicleType]    Script Date: 22/05/2024 03:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GE_VehicleType](
	[VehicleTypeId] [int] NOT NULL,
	[Brand] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[Year] [int] NULL,
	[Feature1] [nvarchar](50) NULL,
	[Feature2] [nvarchar](50) NULL,
	[Feature3] [nvarchar](50) NULL,
 CONSTRAINT [PK__GE_Vehic__9F44964359283529] PRIMARY KEY CLUSTERED 
(
	[VehicleTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GE_AUTHentications] ON 
GO
INSERT [dbo].[GE_AUTHentications] ([Id_AUTH], [Name_AUTH], [DisplayName_AUTH], [IsActive_AUTH], [IsDeleted_AUTH]) VALUES (1, N'AD', N'Active Directory', 1, 0)
GO
INSERT [dbo].[GE_AUTHentications] ([Id_AUTH], [Name_AUTH], [DisplayName_AUTH], [IsActive_AUTH], [IsDeleted_AUTH]) VALUES (2, N'GE', N'Generic Enterprise', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[GE_AUTHentications] OFF
GO
SET IDENTITY_INSERT [dbo].[GE_Inspectable] ON 
GO
INSERT [dbo].[GE_Inspectable] ([InspectableId], [Name], [Description]) VALUES (1, N'Volante', N'Inspeciona se houve avarias no volante')
GO
INSERT [dbo].[GE_Inspectable] ([InspectableId], [Name], [Description]) VALUES (2, N'Rodas', N'Inspeciona se houve avarias em todas as rodas')
GO
INSERT [dbo].[GE_Inspectable] ([InspectableId], [Name], [Description]) VALUES (3, N'Pintura', N'Inspeciona se houve avarias na pintura externa')
GO
INSERT [dbo].[GE_Inspectable] ([InspectableId], [Name], [Description]) VALUES (4, N'Banco do Motorista', N'Inspeciona se houve avarias no banco do motorista')
GO
SET IDENTITY_INSERT [dbo].[GE_Inspectable] OFF
GO
INSERT [dbo].[GE_InspectableType] ([VehicleTypeId], [InspectableId]) VALUES (1, 1)
GO
INSERT [dbo].[GE_InspectableType] ([VehicleTypeId], [InspectableId]) VALUES (1, 2)
GO
INSERT [dbo].[GE_InspectableType] ([VehicleTypeId], [InspectableId]) VALUES (1, 3)
GO
INSERT [dbo].[GE_InspectableType] ([VehicleTypeId], [InspectableId]) VALUES (1, 4)
GO
INSERT [dbo].[GE_InspectionStatus] ([StatusId], [Description]) VALUES (1, N'Inspection Just Open')
GO
INSERT [dbo].[GE_InspectionStatus] ([StatusId], [Description]) VALUES (2, N'Inspection Filled')
GO
INSERT [dbo].[GE_InspectionStatus] ([StatusId], [Description]) VALUES (3, N'Inspection Aproved')
GO
INSERT [dbo].[GE_InspectionStatus] ([StatusId], [Description]) VALUES (4, N'Inspection Rejected')
GO
SET IDENTITY_INSERT [dbo].[GE_MEmberOF] ON 
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (6, 2, 3)
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (7, 3, 2)
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (8, 4, 1)
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (9, 5, 1)
GO
INSERT [dbo].[GE_MEmberOF] ([Id_MEOF], [Id_USER], [Id_PROF]) VALUES (10, 6, 2)
GO
SET IDENTITY_INSERT [dbo].[GE_MEmberOF] OFF
GO
SET IDENTITY_INSERT [dbo].[GE_PROFiles] ON 
GO
INSERT [dbo].[GE_PROFiles] ([Id_PROF], [Name_PROF], [DisplayName_PROF], [IsActive_PROF], [IsDeleted_PROF]) VALUES (1, N'USER', N'Utilizador', 1, 0)
GO
INSERT [dbo].[GE_PROFiles] ([Id_PROF], [Name_PROF], [DisplayName_PROF], [IsActive_PROF], [IsDeleted_PROF]) VALUES (2, N'ADM', N'Administrador', 1, 0)
GO
INSERT [dbo].[GE_PROFiles] ([Id_PROF], [Name_PROF], [DisplayName_PROF], [IsActive_PROF], [IsDeleted_PROF]) VALUES (3, N'SYSA', N'Administrador do Sistema', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[GE_PROFiles] OFF
GO
SET IDENTITY_INSERT [dbo].[GE_USERs] ON 
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (2, 2, N'Francisco', N'Holanda', N'Dev', N'francisco.holanda', N'francisco.holanda@teste.com', N'JQ52ynJj3EZhziBKhlw9vxFi7ITBAeFJKIOsSEHXXIc=', N'5511994428427', NULL, 1, 0)
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (3, 2, N'Teste', N'Usuario', N'Tester', N'teste.teste', N'teste@teste.com', N'aEncIPQ04wp9pPRqQjqHj/9/Q4kY49gOxKVcsHmUBLw=', N'551994428427', N'string', 1, 0)
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (4, 2, N'Rodrigo', N'Silva', N'Supervisor', N'rod123', N'rod123@hotmail.com', N'kCOsuzajWvvR43iT0JuvKVJWDAIG1JiRB3QYi4i02nc=', N'11912345678', N'string', 1, 0)
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (5, 2, N'teste', N'teste', N'tester', N'teste123', N'teste@teste.com', N'BZN/adjkV2v3y/dyrz9yeKSCdvDeFRoJgkK3rzmvu4s=', N'11912345678', N'string', 1, 0)
GO
INSERT [dbo].[GE_USERs] ([Id_USER], [Id_AUTH], [FirstName_USER], [LastName_USER], [JobTitle_USER], [Login_USER], [Mail_USER], [Password_USER], [Phone_USER], [Photo_USER], [IsActive_USER], [IsDeleted_USER]) VALUES (6, 2, N'ADMIN', N'TESTER', N'SYSADMIN', N'admin123', N'admin@teste.com', N'lPNBEbt1ZsEA1yk8/IX+LN1oBo7rdtN6q/6xxm9e9jE=', N'11912345678', N'string', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[GE_USERs] OFF
GO
SET IDENTITY_INSERT [dbo].[GE_Vehicle] ON 
GO
INSERT [dbo].[GE_Vehicle] ([VehicleId], [LicensePlate], [VehicleTypeId], [Name], [LastInspection], [LastInspectorUserId], [IsBeingInspected]) VALUES (1, N'AAA1010', 1, N'Veiculo de transporte de mercadoria', CAST(N'2024-05-21T22:41:54.1200000' AS DateTime2), 0, 0)
GO
SET IDENTITY_INSERT [dbo].[GE_Vehicle] OFF
GO
INSERT [dbo].[GE_VehicleType] ([VehicleTypeId], [Brand], [Model], [Year], [Feature1], [Feature2], [Feature3]) VALUES (1, N'GM', N'Kadet', 1990, N'Ar Condicionado', N'Completo', N'Trava Elétrica')
GO
INSERT [dbo].[GE_VehicleType] ([VehicleTypeId], [Brand], [Model], [Year], [Feature1], [Feature2], [Feature3]) VALUES (2, N'FORD', N'KA', 2015, N'', N'', N'')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GE_USERs]    Script Date: 22/05/2024 03:42:22 ******/
ALTER TABLE [dbo].[GE_USERs] ADD  CONSTRAINT [IX_GE_USERs] UNIQUE NONCLUSTERED 
(
	[Login_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GE_AUTHentications] ADD  CONSTRAINT [DF_GE_AUTHentications_IsActive_AUTH]  DEFAULT ((1)) FOR [IsActive_AUTH]
GO
ALTER TABLE [dbo].[GE_AUTHentications] ADD  CONSTRAINT [DF_GE_AUTHentications_IsDeleted_AUTH]  DEFAULT ((0)) FOR [IsDeleted_AUTH]
GO
ALTER TABLE [dbo].[GE_PROFiles] ADD  CONSTRAINT [DF_GE_PROFiles_IsActive_PROF]  DEFAULT ((1)) FOR [IsActive_PROF]
GO
ALTER TABLE [dbo].[GE_PROFiles] ADD  CONSTRAINT [DF_GE_PROFiles_IsDeleted_PROF]  DEFAULT ((0)) FOR [IsDeleted_PROF]
GO
ALTER TABLE [dbo].[GE_USERs] ADD  CONSTRAINT [DF_GE_USERs_IsActive_USER]  DEFAULT ((1)) FOR [IsActive_USER]
GO
ALTER TABLE [dbo].[GE_USERs] ADD  CONSTRAINT [DF_GE_USERs_IsDeleted_USER]  DEFAULT ((0)) FOR [IsDeleted_USER]
GO
ALTER TABLE [dbo].[GE_InspectableType]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Inspe__0A9D95DB] FOREIGN KEY([InspectableId])
REFERENCES [dbo].[GE_Inspectable] ([InspectableId])
GO
ALTER TABLE [dbo].[GE_InspectableType] CHECK CONSTRAINT [FK__GE_Inspec__Inspe__0A9D95DB]
GO
ALTER TABLE [dbo].[GE_InspectableType]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Vehic__09A971A2] FOREIGN KEY([VehicleTypeId])
REFERENCES [dbo].[GE_VehicleType] ([VehicleTypeId])
GO
ALTER TABLE [dbo].[GE_InspectableType] CHECK CONSTRAINT [FK__GE_Inspec__Vehic__09A971A2]
GO
ALTER TABLE [dbo].[GE_Inspection]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Statu__10566F31] FOREIGN KEY([StatusId])
REFERENCES [dbo].[GE_InspectionStatus] ([StatusId])
GO
ALTER TABLE [dbo].[GE_Inspection] CHECK CONSTRAINT [FK__GE_Inspec__Statu__10566F31]
GO
ALTER TABLE [dbo].[GE_Inspection]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Vehic__0F624AF8] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[GE_Vehicle] ([VehicleId])
GO
ALTER TABLE [dbo].[GE_Inspection] CHECK CONSTRAINT [FK__GE_Inspec__Vehic__0F624AF8]
GO
ALTER TABLE [dbo].[GE_InspectionDetail]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Inspe__1332DBDC] FOREIGN KEY([InspectionId])
REFERENCES [dbo].[GE_Inspection] ([InspectionId])
GO
ALTER TABLE [dbo].[GE_InspectionDetail] CHECK CONSTRAINT [FK__GE_Inspec__Inspe__1332DBDC]
GO
ALTER TABLE [dbo].[GE_InspectionDetail]  WITH CHECK ADD  CONSTRAINT [FK__GE_Inspec__Inspe__14270015] FOREIGN KEY([InspectableId])
REFERENCES [dbo].[GE_Inspectable] ([InspectableId])
GO
ALTER TABLE [dbo].[GE_InspectionDetail] CHECK CONSTRAINT [FK__GE_Inspec__Inspe__14270015]
GO
ALTER TABLE [dbo].[GE_MEmberOF]  WITH CHECK ADD  CONSTRAINT [FK_GE_MEmberOF_GE_PROFiles] FOREIGN KEY([Id_PROF])
REFERENCES [dbo].[GE_PROFiles] ([Id_PROF])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GE_MEmberOF] CHECK CONSTRAINT [FK_GE_MEmberOF_GE_PROFiles]
GO
ALTER TABLE [dbo].[GE_MEmberOF]  WITH CHECK ADD  CONSTRAINT [FK_GE_MEmberOF_GE_USERs] FOREIGN KEY([Id_USER])
REFERENCES [dbo].[GE_USERs] ([Id_USER])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GE_MEmberOF] CHECK CONSTRAINT [FK_GE_MEmberOF_GE_USERs]
GO
ALTER TABLE [dbo].[GE_USERs]  WITH CHECK ADD  CONSTRAINT [FK_GE_USERs_GE_AUTHentications] FOREIGN KEY([Id_AUTH])
REFERENCES [dbo].[GE_AUTHentications] ([Id_AUTH])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GE_USERs] CHECK CONSTRAINT [FK_GE_USERs_GE_AUTHentications]
GO
ALTER TABLE [dbo].[GE_Vehicle]  WITH CHECK ADD  CONSTRAINT [FK__GE_Vehicl__Vehic__04E4BC85] FOREIGN KEY([VehicleTypeId])
REFERENCES [dbo].[GE_VehicleType] ([VehicleTypeId])
GO
ALTER TABLE [dbo].[GE_Vehicle] CHECK CONSTRAINT [FK__GE_Vehicl__Vehic__04E4BC85]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_AUTHentications', @level2type=N'COLUMN',@level2name=N'IsActive_AUTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_AUTHentications', @level2type=N'COLUMN',@level2name=N'IsDeleted_AUTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_PROFiles', @level2type=N'COLUMN',@level2name=N'IsActive_PROF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_PROFiles', @level2type=N'COLUMN',@level2name=N'IsDeleted_PROF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_USERs', @level2type=N'COLUMN',@level2name=N'IsActive_USER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GE_USERs', @level2type=N'COLUMN',@level2name=N'IsDeleted_USER'
GO
USE [master]
GO
ALTER DATABASE [GenericEnterprise] SET  READ_WRITE 
GO

```
</details>

## 📋 Uso
O Swagger está pronto para uso. Se você executar o projeto no modo Debug, não será necessário autenticar para chamar outros métodos, mas se você não fizer isso, precisará autenticar com um login e senha. Use o endpoint de criação de usuário para criar um usuário.

## ♾️ Explicação do fluxo de negócios e lógica a ser aplicada back-front
1 - Criar usuários, com título de trabalho Inspetor e Supervisor, por exemplo;</br>
2 - Criar um Tipo de Veículo, Inspeccionáveis, Criar a relação entre eles;</br>
3 - Criar um Veículo.</br>
4 - Criar uma nova Inspeção, isso irá bloquear para que outros não possam abrir outra Inspeção;</br>
5 - Inserir as informações sobre os inspecionáveis, fiz isso de forma dinâmica, para que a interface possa mostrar exatamente o que deve ser inspecionado e respondido;</br>
6 - Um Supervisor deve aprovar ou rejeitar a inspeção, após isso, outra inspeção pode ser inicializada.
* - Para obter seu primeiro Token, você pode usar {"email": "admin@teste.com", "password": "123456"}

## 🤝 Lista de Tarefas
Mais e melhores testes;</br>
Publicação na nuvem (Dockerfile e contenerização);</br>
CRUDs genéricos;</br>

## ☝️ Sugestões
Sistema de Fluxo de Trabalho para melhorar a Inspeção e outros processos relacionados;</br>
Definir e controlar quais perfis podem acessar cada endpoint;</br>

## 🖥️ Tecnologias Utilizadas
.NET CORE 8;</br>
SQL SERVER EXPRESS;</br>
Anotações de Dados;</br>
AutoMapper;</br>
Entity Framework;</br>
Swagger;</br>
JWT;</br>
xUnit;

## 📝 Licença
Apenas para estudo e não distribuível.
