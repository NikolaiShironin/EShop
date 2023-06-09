USE [master]
GO
/****** Object:  Database [EStore]    Script Date: 27.03.2023 21:45:50 ******/
CREATE DATABASE [EStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [EStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EStore] SET RECOVERY FULL 
GO
ALTER DATABASE [EStore] SET  MULTI_USER 
GO
ALTER DATABASE [EStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EStore', N'ON'
GO
ALTER DATABASE [EStore] SET QUERY_STORE = OFF
GO
USE [EStore]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CName] [varchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [varchar](max) NULL,
	[PhoneNumber] [varchar](max) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[DeliveryID] [int] IDENTITY(1,1) NOT NULL,
	[Adress] [varchar](max) NULL,
	[DeliveryEmployeeID] [int] NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[DeliveryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryEmployee]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryEmployee](
	[DeliveryEmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FIOEmployee] [varchar](max) NULL,
 CONSTRAINT [PK_DeliveryEmployee] PRIMARY KEY CLUSTERED 
(
	[DeliveryEmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goods]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods](
	[GoodsID] [int] IDENTITY(1,1) NOT NULL,
	[GName] [varchar](max) NULL,
	[Firm] [varchar](max) NULL,
	[Model] [varchar](max) NULL,
	[CategoryID] [int] NULL,
	[Specifications] [varchar](max) NULL,
	[Price] [int] NULL,
	[WarrantyPerMonth] [int] NULL,
	[GImage] [varchar](max) NULL,
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[GoodsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrdersID] [int] IDENTITY(1,1) NOT NULL,
	[StoreID] [int] NULL,
	[WayToGetID] [int] NULL,
	[DeliveryID] [int] NULL,
	[ClientID] [int] NULL,
	[StatusID] [int] NULL,
	[DateTime] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrdersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersGoods]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersGoods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrdersID] [int] NULL,
	[GoodsID] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrdersGoods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[SName] [varchar](max) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[StoreID] [int] IDENTITY(1,1) NOT NULL,
	[EMail] [nvarchar](max) NULL,
	[Adress] [varchar](max) NULL,
	[Code] [int] NULL,
	[Picture] [varchar](max) NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WayToGet]    Script Date: 27.03.2023 21:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WayToGet](
	[WayToGetID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](max) NULL,
 CONSTRAINT [PK_WayToGet] PRIMARY KEY CLUSTERED 
(
	[WayToGetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CName]) VALUES (1, N'Бытовая техника')
INSERT [dbo].[Category] ([CategoryID], [CName]) VALUES (2, N'Декор')
INSERT [dbo].[Category] ([CategoryID], [CName]) VALUES (3, N'Мультимедиа')
INSERT [dbo].[Category] ([CategoryID], [CName]) VALUES (4, N'Смартфоны и фототехника')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientID], [FIO], [PhoneNumber]) VALUES (1, N'Никулина Николь Ильинична', N'7599668990')
INSERT [dbo].[Client] ([ClientID], [FIO], [PhoneNumber]) VALUES (2, N'Козлова Ксения Тимофеевна', N'7032576337')
INSERT [dbo].[Client] ([ClientID], [FIO], [PhoneNumber]) VALUES (3, N'Петрова Софья Михайловна', N'7504091251')
INSERT [dbo].[Client] ([ClientID], [FIO], [PhoneNumber]) VALUES (4, N'Иванова Анна Константиновна', N'7472957099')
INSERT [dbo].[Client] ([ClientID], [FIO], [PhoneNumber]) VALUES (5, N'Балашов Антон Дмитриевич', N'7573805556')
INSERT [dbo].[Client] ([ClientID], [FIO], [PhoneNumber]) VALUES (6, N'Лебедев Егор Маратович', N'7909495771')
INSERT [dbo].[Client] ([ClientID], [FIO], [PhoneNumber]) VALUES (7, N'Афанасьева Елизавета Ярославовна', N'7766714605')
INSERT [dbo].[Client] ([ClientID], [FIO], [PhoneNumber]) VALUES (8, N'Чумаков Денис Ильич', N'7312893745')
INSERT [dbo].[Client] ([ClientID], [FIO], [PhoneNumber]) VALUES (9, N'Тихомиров Кирилл Максимович', N'7024108974')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Delivery] ON 

INSERT [dbo].[Delivery] ([DeliveryID], [Adress], [DeliveryEmployeeID]) VALUES (1, N'Читинская область, город Домодедово, ул. Космонавтов, 74', 1)
INSERT [dbo].[Delivery] ([DeliveryID], [Adress], [DeliveryEmployeeID]) VALUES (2, N'Тюменская область, город Серпухов, пл. Космонавтов, 70', 2)
INSERT [dbo].[Delivery] ([DeliveryID], [Adress], [DeliveryEmployeeID]) VALUES (3, N'Мурманская область, город Клин, шоссе Ломоносова, 01', 3)
INSERT [dbo].[Delivery] ([DeliveryID], [Adress], [DeliveryEmployeeID]) VALUES (4, N'Ростовская область, город Солнечногорск, пр. Космонавтов, 48', 1)
INSERT [dbo].[Delivery] ([DeliveryID], [Adress], [DeliveryEmployeeID]) VALUES (5, N'Волгоградская область, город Щёлково, ул. Гоголя, 77', 4)
INSERT [dbo].[Delivery] ([DeliveryID], [Adress], [DeliveryEmployeeID]) VALUES (6, N'Читинская область, город Домодедово, наб. Гагарина, 16', 5)
SET IDENTITY_INSERT [dbo].[Delivery] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliveryEmployee] ON 

INSERT [dbo].[DeliveryEmployee] ([DeliveryEmployeeID], [FIOEmployee]) VALUES (1, N'Артемьев Вальтер Феликсович')
INSERT [dbo].[DeliveryEmployee] ([DeliveryEmployeeID], [FIOEmployee]) VALUES (2, N'Сергеев Филипп Фролович
')
INSERT [dbo].[DeliveryEmployee] ([DeliveryEmployeeID], [FIOEmployee]) VALUES (3, N'Ершов Митрофан Альвианович')
INSERT [dbo].[DeliveryEmployee] ([DeliveryEmployeeID], [FIOEmployee]) VALUES (4, N'Пестов Максим Улебович
')
INSERT [dbo].[DeliveryEmployee] ([DeliveryEmployeeID], [FIOEmployee]) VALUES (5, N'Дмитриев Касьян Антонинович')
SET IDENTITY_INSERT [dbo].[DeliveryEmployee] OFF
GO
SET IDENTITY_INSERT [dbo].[Goods] ON 

INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (1, N'Холодильник', N'Samsung', N'RB33A3240WW', 1, N'No Frost - не требует разморозки, Увеличенный полезный объем Space Max, Тихий инверторный компрессор', 48999, 12, N'\ResPhoto\1Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (2, N'Пылесос', N'Tefal', N'TW4855EA', 1, N'Компактный корпус, Удобный контейнер для пыли, Циклонная технология', 12999, 24, N'\ResPhoto\2Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (3, N'Микроволновая печь', N'Haier', N'HMB-MM207SA', 1, N'Размораживание по весу, Тип управления - механический', 5999, 12, N'\ResPhoto\3Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (4, N'Электрический духовой шкаф', N'Thomson', N'BO30E-6803', 1, N'9 режимов работы, Каталитическая пластина и очистка паром, Мягкое закрытие двери (с доводчиками)', 23999, 24, N'\ResPhoto\4Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (5, N'Светильник настольный', N'Apeyron', N'A0F83-NV', 2, N'LED/ энергосберегающая КЛЛ/ накаливания, Мощность - 25 Вт', 2260, 12, N'\ResPhoto\5Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (6, N'Светильник для зеркала', N'Apeyron', N'A02F83-NW', 2, N'Цвет - белый, Пульт переключения', 770, 12, N'\ResPhoto\6Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (7, N'Телевизор', N'Sony', N'KD55X81J', 3, N'Цветовой охват TRILUMINOS PRO, Поддержка Dolby Vision / Atmos', 69999, 12, N'\ResPhoto\7Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (8, N'Портативная акустическая система', N'LG', N'RP4B', 3, N'Работа от аккумулятора до 10 ч, Подключение до 3-х смартфонов (Android)', 22999, 60, N'\ResPhoto\8Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (9, N'DVD-плеер', N'BBK', N'DVP176SI', 3, N'Выход RCA видео композитный, Выход RCA аудио', 2550, 12, N'\ResPhoto\9Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (10, N'Смартфон', N'Honor', N'70 8+256Gb Crystal Silver', 4, N'Профессиональная камера 54Мп, Быстрая зарядка HONOR SuperCharge, Сверхчеткий OLED-экран 120Гц', 40499, 12, N'\ResPhoto\10Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (11, N'Фотоаппарат', N'Canon', N'Power Shot G7 X Mk II Black', 4, N'Стабилизатор изображения - оптический, Панорамная съемка, Распознавание лиц', 47499, 24, N'\ResPhoto\11Good.jpg')
INSERT [dbo].[Goods] ([GoodsID], [GName], [Firm], [Model], [CategoryID], [Specifications], [Price], [WarrantyPerMonth], [GImage]) VALUES (12, N'Электрочайник', N'Redmond', N'RK-G196', 1, N'контактная группа STRIX, Синяя LED-подсветка, Колба из термостойкого стекла', 1499, 12, N'\ResPhoto\12Good.jpg')
SET IDENTITY_INSERT [dbo].[Goods] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (1, 1, 2, 1, 1, 1, CAST(N'2022-01-11T11:59:23.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (2, 2, 2, 2, 2, 1, CAST(N'2022-01-13T12:43:03.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (3, 3, 2, 3, 3, 1, CAST(N'2022-01-15T11:35:43.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (4, 1, 2, 4, 4, 2, CAST(N'2022-01-17T14:35:43.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (5, 2, 2, 5, 5, 1, CAST(N'2022-01-30T10:11:11.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (6, 1, 2, 6, 6, 1, CAST(N'2022-02-05T16:10:32.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (7, 1, 1, NULL, 7, 2, CAST(N'2022-02-07T18:10:32.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (8, 2, 1, NULL, 9, 1, CAST(N'2022-01-25T15:16:52.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (9, 3, 1, NULL, 8, 1, CAST(N'2022-02-23T17:32:41.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (10, 2, 1, NULL, 9, 1, CAST(N'2022-02-28T18:19:18.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (11, 1, 1, NULL, 2, 1, CAST(N'2022-02-04T18:16:50.000' AS DateTime))
INSERT [dbo].[Orders] ([OrdersID], [StoreID], [WayToGetID], [DeliveryID], [ClientID], [StatusID], [DateTime]) VALUES (12, 2, 1, NULL, 4, 1, CAST(N'2022-03-04T16:14:32.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdersGoods] ON 

INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (1, 1, 1, 2)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (2, 1, 2, 1)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (3, 2, 4, 1)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (4, 3, 3, 1)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (5, 4, 2, 2)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (6, 5, 6, 3)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (7, 6, 5, 1)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (8, 6, 7, 1)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (9, 7, 12, 1)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (10, 8, 10, 2)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (11, 11, 1, 2)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (12, 11, 11, 1)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (13, 11, 4, 1)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (14, 9, 5, 2)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (15, 10, 7, 1)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (16, 10, 9, 2)
INSERT [dbo].[OrdersGoods] ([id], [OrdersID], [GoodsID], [Quantity]) VALUES (17, 12, 8, 2)
SET IDENTITY_INSERT [dbo].[OrdersGoods] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusID], [SName]) VALUES (1, N'Выполнен')
INSERT [dbo].[Status] ([StatusID], [SName]) VALUES (2, N'В ожидании')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Store] ON 

INSERT [dbo].[Store] ([StoreID], [EMail], [Adress], [Code], [Picture]) VALUES (1, N'FirstMarketPlace@mail.ru', N'Москва. 9 Китайгородский пр-д', 1001, N'\ResPhoto\1Store.jpg')
INSERT [dbo].[Store] ([StoreID], [EMail], [Adress], [Code], [Picture]) VALUES (2, N'SecondMarketPlace@mail.ru', N'Санкт-Петербург. 2 Красноборский пер.', 1002, N'\ResPhoto\2Store.jpg')
INSERT [dbo].[Store] ([StoreID], [EMail], [Adress], [Code], [Picture]) VALUES (3, N'ThirdMarketPlace@mail.ru', N'Калининград. Калининградская обл.', 1003, N'\ResPhoto\3Store.jpg')
INSERT [dbo].[Store] ([StoreID], [EMail], [Adress], [Code], [Picture]) VALUES (4, N'sdfsdf', N'dsfsdf', 1232, NULL)
SET IDENTITY_INSERT [dbo].[Store] OFF
GO
SET IDENTITY_INSERT [dbo].[WayToGet] ON 

INSERT [dbo].[WayToGet] ([WayToGetID], [Type]) VALUES (1, N'Самовывоз')
INSERT [dbo].[WayToGet] ([WayToGetID], [Type]) VALUES (2, N'Доставка')
SET IDENTITY_INSERT [dbo].[WayToGet] OFF
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_DeliveryEmployee] FOREIGN KEY([DeliveryEmployeeID])
REFERENCES [dbo].[DeliveryEmployee] ([DeliveryEmployeeID])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_DeliveryEmployee]
GO
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD  CONSTRAINT [FK_Goods_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Goods] CHECK CONSTRAINT [FK_Goods_Category]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Client]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Delivery] FOREIGN KEY([DeliveryID])
REFERENCES [dbo].[Delivery] ([DeliveryID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Delivery]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Status]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Store] FOREIGN KEY([StoreID])
REFERENCES [dbo].[Store] ([StoreID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Store]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_WayToGet] FOREIGN KEY([WayToGetID])
REFERENCES [dbo].[WayToGet] ([WayToGetID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_WayToGet]
GO
ALTER TABLE [dbo].[OrdersGoods]  WITH CHECK ADD  CONSTRAINT [FK_OrdersGoods_Goods] FOREIGN KEY([GoodsID])
REFERENCES [dbo].[Goods] ([GoodsID])
GO
ALTER TABLE [dbo].[OrdersGoods] CHECK CONSTRAINT [FK_OrdersGoods_Goods]
GO
ALTER TABLE [dbo].[OrdersGoods]  WITH CHECK ADD  CONSTRAINT [FK_OrdersGoods_Orders] FOREIGN KEY([OrdersID])
REFERENCES [dbo].[Orders] ([OrdersID])
GO
ALTER TABLE [dbo].[OrdersGoods] CHECK CONSTRAINT [FK_OrdersGoods_Orders]
GO
USE [master]
GO
ALTER DATABASE [EStore] SET  READ_WRITE 
GO
