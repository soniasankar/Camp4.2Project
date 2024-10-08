USE [master]
GO
/****** Object:  Database [CMS_db]    Script Date: 27-08-2024 13:19:49 ******/
CREATE DATABASE [CMS_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CMS_db', FILENAME = N'D:\program_sqlserver\MSSQL16.MSSQLSERVER\MSSQL\DATA\CMS_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CMS_db_log', FILENAME = N'D:\program_sqlserver\MSSQL16.MSSQLSERVER\MSSQL\DATA\CMS_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CMS_db] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CMS_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CMS_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CMS_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CMS_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CMS_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CMS_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [CMS_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CMS_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CMS_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CMS_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CMS_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CMS_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CMS_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CMS_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CMS_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CMS_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CMS_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CMS_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CMS_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CMS_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CMS_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CMS_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CMS_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CMS_db] SET RECOVERY FULL 
GO
ALTER DATABASE [CMS_db] SET  MULTI_USER 
GO
ALTER DATABASE [CMS_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CMS_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CMS_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CMS_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CMS_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CMS_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CMS_db', N'ON'
GO
ALTER DATABASE [CMS_db] SET QUERY_STORE = ON
GO
ALTER DATABASE [CMS_db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CMS_db]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorID] [int] NOT NULL,
	[AppointmentID] [int] NOT NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[BillDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAppointment]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAppointment](
	[Token] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](100) NULL,
	[DoctorID] [int] NULL,
	[ReasonForAppointment] [varchar](255) NULL,
	[AppointmentDate] [date] NULL,
	[AppointmentTime] [time](7) NULL,
	[PatientId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diagnosis]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diagnosis](
	[DiagnosisID] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentId] [int] NULL,
	[PatientName] [varchar](100) NULL,
	[DoctorID] [int] NULL,
	[Course] [varchar](20) NULL,
	[Dosage] [varchar](20) NULL,
	[Symptoms] [varchar](255) NULL,
	[DiagnosisDetails] [varchar](50) NULL,
	[MedicineName] [varchar](50) NULL,
	[TestName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DiagnosisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[DoctorName] [varchar](50) NULL,
	[Specialization] [varchar](50) NULL,
	[ConsultingFees] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MEDICINE]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MEDICINE](
	[MedicineName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Address] [varchar](255) NULL,
	[BloodGroup] [varchar](5) NULL,
	[Gender] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEST]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEST](
	[TestName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TestName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersRole]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersRole](
	[RoleId] [int] NOT NULL,
	[RoleName] [varchar](50) NULL,
	[isActive] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERSTABLE]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERSTABLE](
	[UserId] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[isActive] [varchar](50) NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookAppointment] ON 

INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (1, N'sonia', 1, N'review', CAST(N'2024-08-26' AS Date), CAST(N'10:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (2, N'sonia', 2, N'hi', CAST(N'2024-08-27' AS Date), CAST(N'15:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (3, N'jimcy', 1, N'fever', CAST(N'2024-08-26' AS Date), CAST(N'13:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (4, N'sonia', 1, N'hi', CAST(N'2024-08-26' AS Date), CAST(N'11:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (5, N'akhil', 2, N'fever', CAST(N'2024-08-26' AS Date), CAST(N'12:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (6, N'sonia', 3, N'3', CAST(N'2024-08-28' AS Date), CAST(N'12:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (7, N'sonia', 1, N'fever', CAST(N'2024-08-26' AS Date), CAST(N'10:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (8, N'jimcy', 1, N'fever', CAST(N'2024-08-26' AS Date), CAST(N'13:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (9, N'ramu', 3, N'xray', CAST(N'2024-08-26' AS Date), CAST(N'10:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (10, N'jeevan', 2, N'review', CAST(N'2024-08-27' AS Date), CAST(N'11:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (11, N'ravi', 1, N'heart pain', CAST(N'2024-08-26' AS Date), CAST(N'11:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (12, N'jimcy', 2, N'rashesh', CAST(N'2024-08-27' AS Date), CAST(N'12:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (13, N'jhon', 3, N'xray', CAST(N'2024-08-31' AS Date), CAST(N'15:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (1012, N'sonia', 1, N'fever', CAST(N'2024-08-27' AS Date), CAST(N'11:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (1013, N'jeevan', 3, N'xray', CAST(N'2024-08-28' AS Date), CAST(N'10:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (1014, N'sonia', 2, N'fever', CAST(N'2024-08-28' AS Date), CAST(N'11:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (1015, N'sonia', 1, N'fevver', CAST(N'2024-08-27' AS Date), CAST(N'10:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (1016, N'sonia', 1, N'fever', CAST(N'2024-08-27' AS Date), CAST(N'11:00:00' AS Time), NULL)
INSERT [dbo].[BookAppointment] ([Token], [PatientName], [DoctorID], [ReasonForAppointment], [AppointmentDate], [AppointmentTime], [PatientId]) VALUES (1017, N'sonia', 1, N'fever', CAST(N'2024-08-27' AS Date), CAST(N'10:00:00' AS Time), NULL)
SET IDENTITY_INSERT [dbo].[BookAppointment] OFF
GO
SET IDENTITY_INSERT [dbo].[Diagnosis] ON 

INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (1, 1, N'', 1, N'2 days', N'1', N'fever', N'viral', N'Paracetamol', N'')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (2, 1, N'', 1, N'2 days', N'3', N'fever', N'fever', N'Paracetamol', N'')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (3, 1, N'', 1, N' 3 days', N'2', N'fever', N'fever', N'Paracetamol', N'')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (4, 6, N'', 0, N'8', N'9', N'9', N'i', N'Paracetamol', N'')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (5, 2, N'', 2, N'3', N'2', N'fever', N'good', N'Paracetamol', N'')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (6, 2, N'', 2, N'', N'2', N'2', N'2', N'Ibuprofen', N'')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (7, 9, N'', 3, N'2', N'2', N'Xray', N'vroken ', N'Ibuprofen', N'')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (1007, 2, N'', 2, N'2 days', N'20', N'fever', N'viral fever', N'Paracetamol', N'')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (1008, 10, N'', 2, N'3 days (1-1-1)', N'200', N'headache', N'miagrine', N'Ibuprofen', N'')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (1009, 2, N'', 2, N'1', N'1', N'fever', N'fever', N'Paracetamol', N'Echo')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (1010, 2, N'', 2, N'2 days (1-1-1)', N'650', N'headache', N'migraine', N'Paracetamol', N'Blood Test')
INSERT [dbo].[Diagnosis] ([DiagnosisID], [AppointmentId], [PatientName], [DoctorID], [Course], [Dosage], [Symptoms], [DiagnosisDetails], [MedicineName], [TestName]) VALUES (1011, 2, N'', 2, N'2', N'20', N'sonia', N'hi', N'Paracetamol', N'')
SET IDENTITY_INSERT [dbo].[Diagnosis] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctor] ON 

INSERT [dbo].[Doctor] ([DoctorID], [UserId], [DoctorName], [Specialization], [ConsultingFees]) VALUES (1, 2, N'Dhanusha', N'Cardiologist', N'100')
INSERT [dbo].[Doctor] ([DoctorID], [UserId], [DoctorName], [Specialization], [ConsultingFees]) VALUES (2, 3, N'Akhila', N'Dermatology', N'150')
INSERT [dbo].[Doctor] ([DoctorID], [UserId], [DoctorName], [Specialization], [ConsultingFees]) VALUES (3, 4, N'Beni', N'Radiology', N'240')
SET IDENTITY_INSERT [dbo].[Doctor] OFF
GO
INSERT [dbo].[MEDICINE] ([MedicineName]) VALUES (N'Amoxicillin')
INSERT [dbo].[MEDICINE] ([MedicineName]) VALUES (N'Ibuprofen')
INSERT [dbo].[MEDICINE] ([MedicineName]) VALUES (N'Metformin')
INSERT [dbo].[MEDICINE] ([MedicineName]) VALUES (N'Omeprazole')
INSERT [dbo].[MEDICINE] ([MedicineName]) VALUES (N'Paracetamol')
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (1, N'soam', CAST(N'2002-12-12' AS Date), N'truovandrum', N'A+', N'Female', N'soniasankark@gmailcom', N'7356820285')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (2, N'sonia', CAST(N'2002-02-25' AS Date), N'truovandrum', N'A+', N'Female', N'soniasankar@gmail.com', N'7356820285')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (3, N'Jimcy', CAST(N'2002-02-25' AS Date), N'truovandrum', N'A+', N'Female', N'Soniasankark@gmail.com', N'7356820285')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (4, N'Anju', CAST(N'1998-02-12' AS Date), N'truovandrum', N'A+', N'Female', N'anju@gmail.com', N'7356820285')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (5, N'joel', CAST(N'1997-09-12' AS Date), N'kannur', N'A+', N'Female', N'joel@gmail.com', N'8281687574')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (6, N'Ahal', CAST(N'1947-04-13' AS Date), N'Neyyar', N'A+', N'Female', N'ahal@gmail.com', N'9827812398')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (7, N'jerina', CAST(N'2002-12-05' AS Date), N'TamilNadu', N'A+', N'Female', N'jerina@gmail.com', N'6356712345')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (8, N'jimcy', CAST(N'2001-12-04' AS Date), N'Kashmir', N'A-', N'Female', N'jimcy@gmail.com', N'7512345678')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (9, N'fhkjd', CAST(N'2001-12-03' AS Date), N'kkdnjkd', N'A+', N'Female', N'kdgdjdm@gmail.com', N'6712345678')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (10, N'cheif', CAST(N'1989-12-01' AS Date), N'karunagapalli', N'B-', N'Male', N'cheif@gmail.com', N'7123456789')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (11, N'Ramu', CAST(N'1978-12-04' AS Date), N'kollam', N'AB+', N'Male', N'ramu@gmail.com', N'8912345671')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (12, N'jimcy', CAST(N'1789-12-08' AS Date), N'tamil nadu', N'O+', N'Female', N'jimcy@gmail.com', N'9812345671')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (13, N'tom', CAST(N'2000-12-05' AS Date), N'Trivandrum', N'AB-', N'Male', N'sonia@gmail.com', N'8912345678')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (14, N'akhil', CAST(N'2001-12-09' AS Date), N'trivandrum', N'O+', N'Male', N'akhil@gmail.com', N'8381687574')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (15, N'sonia', CAST(N'2000-12-01' AS Date), N'trivandrum', N'A-', N'Female', N'sonia@gmail.com', N'9995115849')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (16, N'Ramu', CAST(N'2003-12-04' AS Date), N'trivadrum', N'AB+', N'Female', N'ramu@gmail.com', N'9995115849')
INSERT [dbo].[Patient] ([PatientId], [PatientName], [DOB], [Address], [BloodGroup], [Gender], [Email], [PhoneNumber]) VALUES (17, N'sonia', CAST(N'2001-12-05' AS Date), N'truovandrum', N'A+', N'Female', N'sonia@gmail.com', N'7356820285')
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
INSERT [dbo].[TEST] ([TestName]) VALUES (N'Bloodtest')
INSERT [dbo].[TEST] ([TestName]) VALUES (N'Genetictesting')
INSERT [dbo].[TEST] ([TestName]) VALUES (N'MRItest')
INSERT [dbo].[TEST] ([TestName]) VALUES (N'Thyroidtest')
INSERT [dbo].[TEST] ([TestName]) VALUES (N'X-rays')
GO
INSERT [dbo].[UsersRole] ([RoleId], [RoleName], [isActive]) VALUES (1, N'Receptionist', N'True')
INSERT [dbo].[UsersRole] ([RoleId], [RoleName], [isActive]) VALUES (2, N'Doctor', N'True')
GO
INSERT [dbo].[USERSTABLE] ([UserId], [UserName], [Password], [isActive], [RoleId]) VALUES (1, N'Athila', N'Athi@23', N'True', 1)
INSERT [dbo].[USERSTABLE] ([UserId], [UserName], [Password], [isActive], [RoleId]) VALUES (2, N'Dhanusha', N'Dha@24', N'True', 2)
INSERT [dbo].[USERSTABLE] ([UserId], [UserName], [Password], [isActive], [RoleId]) VALUES (3, N'Akhila', N'Akh@25', N'True', 2)
INSERT [dbo].[USERSTABLE] ([UserId], [UserName], [Password], [isActive], [RoleId]) VALUES (4, N'Beni', N'Ben@23', N'True', 2)
INSERT [dbo].[USERSTABLE] ([UserId], [UserName], [Password], [isActive], [RoleId]) VALUES (5, N'Rani_12', N'Rani@23', N'True', 2)
INSERT [dbo].[USERSTABLE] ([UserId], [UserName], [Password], [isActive], [RoleId]) VALUES (6, N'Sonia@25', N'Sonia@25', N'True', 2)
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([AppointmentID])
REFERENCES [dbo].[BookAppointment] ([Token])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([PatientId])
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USERSTABLE] ([UserId])
GO
ALTER TABLE [dbo].[USERSTABLE]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[UsersRole] ([RoleId])
GO
/****** Object:  StoredProcedure [dbo].[InsertBookAppointment]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[InsertBookAppointment]
    @PatientName VARCHAR(100),
    @DoctorID INT,
    @ReasonForAppointment VARCHAR(255),
    @AppointmentTime TIME,
    @AppointmentDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO BookAppointment (PatientName, DoctorID, ReasonForAppointment, AppointmentDate, AppointmentTime)
    VALUES (@PatientName, @DoctorID, @ReasonForAppointment, @AppointmentDate, @AppointmentTime);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertDiagnosis]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertDiagnosis]
    @AppointmentId INT,
    @PatientName VARCHAR(100),
    @DoctorID INT,
    @Course VARCHAR(20),
    @Dosage VARCHAR(20),
    @Symptoms VARCHAR(255),
    @DiagnosisDetails VARCHAR(50),
    @MedicineName VARCHAR(50),
    @TestName VARCHAR(50)
AS
BEGIN
    INSERT INTO Diagnosis (
        AppointmentId,
        PatientName,
        DoctorID,
        Course,
        Dosage,
        Symptoms,
        DiagnosisDetails,
        MedicineName,
        TestName
    )
    VALUES (
        @AppointmentId,
        @PatientName,
        @DoctorID,
        @Course,
        @Dosage,
        @Symptoms,
        @DiagnosisDetails,
        @MedicineName,
        @TestName
    );
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAppointmentsForToday]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAppointmentsForToday]
AS
BEGIN
    DECLARE @Today DATE = CAST(GETDATE() AS DATE);

    SELECT 
        Token,
        PatientName,
        DoctorID,
        ReasonForAppointment,
        AppointmentDate,
        AppointmentTime
    FROM 
        BookAppointment
    WHERE 
        AppointmentDate = @Today;
END;
GO
/****** Object:  StoredProcedure [dbo].[spAddAppointment]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spAddAppointment]
    @PatientName NVARCHAR(100),
    @DoctorID INT,
    @ReasonForAppointment NVARCHAR(255),
    @AppointmentDate DATE,
    @AppointmentTime TIME
AS
BEGIN
    INSERT INTO BookAppointment (PatientName, DoctorID, ReasonForAppointment, AppointmentDate, AppointmentTime)
    VALUES (@PatientName, @DoctorID, @ReasonForAppointment, @AppointmentDate, @AppointmentTime);
END
GO
/****** Object:  StoredProcedure [dbo].[spAddPatient]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddPatient]
    @PatientName NVARCHAR(50),
    @DOB Date,
    @Address NVARCHAR(255),
    @BloodGroup NVARCHAR(5),
    @Gender NVARCHAR(50),
    @Email NVARCHAR(50),
    @PhoneNumber NVARCHAR(50)
AS
BEGIN
    INSERT INTO Patient (PatientName, DOB, Address, BloodGroup, Gender, Email, PhoneNumber)
    VALUES (@PatientName, @DOB, @Address, @BloodGroup, @Gender, @Email, @PhoneNumber);
END;
GO
/****** Object:  StoredProcedure [dbo].[spBill]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBill]
    @PatientId INT,
    @DoctorID INT,
    @ConsultingFees DECIMAL(10, 2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Your logic to calculate the bill
    -- Example:
    SELECT @ConsultingFees = ConsultingFees
    FROM Doctors
    WHERE DoctorID = @DoctorID;

    -- You might have other logic here
END;
GO
/****** Object:  StoredProcedure [dbo].[spFetchAppointmentDetails]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[spFetchAppointmentDetails]
    @TokenID INT
AS
BEGIN
    SELECT 
        BA.PatientName,
        BA.ReasonForAppointment,
        BA.AppointmentDate,
        D.MedicineName,
        D.TestName
    FROM 
        BookAppointment BA
    LEFT JOIN 
        Diagnosis D ON BA.Token = D.AppointmentId
    WHERE 
        BA.Token = @TokenID;
END;
GO
/****** Object:  StoredProcedure [dbo].[spFetchPatientDetails]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[spFetchPatientDetails]
    @PatientId INT
AS
BEGIN
    SELECT 
        P.PatientName,
        BA.ReasonForAppointment,
        D.MedicineName,
        D.TestName,
        DT.DoctorName AS DoctorName
    FROM 
        Patient P
    LEFT JOIN 
        BookAppointment BA ON P.PatientId = BA.PatientId
    LEFT JOIN 
        Doctor DT ON BA.DoctorID = DT.DoctorID
    LEFT JOIN 
        Diagnosis D ON BA.Token = D.AppointmentId
    WHERE 
        P.PatientId = @PatientId;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetAppointmentsForToday]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAppointmentsForToday]
AS
BEGIN
    DECLARE @Today DATE = CAST(GETDATE() AS DATE);

    SELECT 
        Token,
        PatientName,
        DoctorID,
        ReasonForAppointment,
        AppointmentDate,
        AppointmentTime
    FROM 
        BookAppointment
    WHERE 
        AppointmentDate = @Today;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetDoctorIDByToken]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDoctorIDByToken]
    @TokenID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Select the Doctor ID based on the provided token ID
    SELECT BA.DoctorID
    FROM BookAppointment BA
    WHERE BA.Token = @TokenID;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetDoctorNames]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDoctorNames]
    @DoctorID INT
AS
BEGIN
    SELECT DoctorName
    FROM Doctor
    WHERE DoctorID = @DoctorID;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetPatientIdByName]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetPatientIdByName]
    @PatientName NVARCHAR(50)
AS
BEGIN
    -- Ensure no extra messages are sent
    SET NOCOUNT ON;

    -- Select the PatientId based on the PatientName
    SELECT PatientId
    FROM Patient
    WHERE PatientName = @PatientName;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetPatientNameByToken]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spGetPatientNameByToken]
    @TokenID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Select the patient's name based on the provided token ID
    SELECT P.PatientName
    FROM BookAppointment BA
    INNER JOIN Patient P ON BA.PatientId = P.PatientId
    WHERE BA.Token = @TokenID;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetUserNew]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetUserNew]
    @User NVARCHAR(50),
    @Password NVARCHAR(50),
    @Rid INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Example query, adjust according to your actual schema
    SELECT @Rid = RoleId
    FROM USERSTABLE
    WHERE Username = @User AND Password = @Password;
END
GO
/****** Object:  StoredProcedure [dbo].[spListDoctor]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spListDoctor]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DoctorID, DoctorName, Specialization, ConsultingFees
    FROM Doctor;
END;
GO
/****** Object:  StoredProcedure [dbo].[spListDoctors]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spListDoctors]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DoctorID, DoctorName, Specialization, ConsultingFees
    FROM Doctor;
END;
GO
/****** Object:  StoredProcedure [dbo].[spListPatient]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListPatient]
AS
BEGIN
    SELECT * FROM Patient;
END;
GO
/****** Object:  StoredProcedure [dbo].[spMedicine]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[spMedicine]
AS
BEGIN
    SELECT * FROM MEDICINE;
END;
GO
/****** Object:  StoredProcedure [dbo].[spSearchByNumber]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[spSearchByNumber]
    @PhoneNumber NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Patient WHERE PhoneNumber = @PhoneNumber;
END;
GO
/****** Object:  StoredProcedure [dbo].[spTest]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[spTest]
AS
BEGIN
    SELECT * FROM TEST;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateAddressByPhoneNumber]    Script Date: 27-08-2024 13:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAddressByPhoneNumber]
    @PhoneNumber NVARCHAR(50),
    @NewAddress NVARCHAR(255)
AS
BEGIN
    UPDATE Patient
    SET Address = @NewAddress
    WHERE PhoneNumber = @PhoneNumber;
END;
GO
USE [master]
GO
ALTER DATABASE [CMS_db] SET  READ_WRITE 
GO
