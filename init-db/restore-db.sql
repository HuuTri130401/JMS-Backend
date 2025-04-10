USE [JMS_BE]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28/02/2025 11:40:00 PM ******/
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
/****** Object:  Table [dbo].[Inventories]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventories](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[ReferenceId] [uniqueidentifier] NULL,
	[Supplier] [nvarchar](max) NOT NULL,
	[TotalImportPrice] [decimal](18, 2) NOT NULL,
	[ImportedAt] [datetimeoffset](7) NOT NULL,
	[TotalExportPrice] [decimal](18, 2) NOT NULL,
	[ExportedAt] [datetimeoffset](7) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryDetails]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryDetails](
	[Id] [uniqueidentifier] NOT NULL,
	[InventoryId] [uniqueidentifier] NOT NULL,
	[JewelryId] [uniqueidentifier] NOT NULL,
	[ImportPrice] [decimal](18, 2) NOT NULL,
	[ExportPrice] [decimal](18, 2) NOT NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_InventoryDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jewelries]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jewelries](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedPrice] [decimal](18, 2) NOT NULL,
	[ImportPrice] [decimal](18, 2) NULL,
	[SalePrice] [decimal](18, 2) NULL,
	[Status] [int] NOT NULL,
	[ImportedAt] [datetimeoffset](7) NULL,
	[SoldAt] [datetimeoffset](7) NULL,
	[Note] [nvarchar](max) NULL,
	[Color] [nvarchar](max) NULL,
	[BarCode] [nvarchar](max) NULL,
	[QRCode] [nvarchar](max) NULL,
	[SKU] [nvarchar](50) NOT NULL,
	[Material] [nvarchar](50) NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
	[Gemstone] [nvarchar](50) NOT NULL,
	[Size] [nvarchar](50) NULL,
	[CertificateNumber] [nvarchar](200) NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[Origin] [nvarchar](max) NULL,
	[Supplier] [nvarchar](max) NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Jewelries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[JewelryId] [uniqueidentifier] NOT NULL,
	[SalePrice] [decimal](18, 2) NOT NULL,
	[SoldAt] [datetimeoffset](7) NOT NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](200) NULL,
	[LastName] [nvarchar](300) NOT NULL,
	[FullName] [nvarchar](500) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](1000) NOT NULL,
	[Status] [int] NULL,
	[Birthday] [datetimeoffset](7) NULL,
	[IdentityCard] [nvarchar](50) NOT NULL,
	[IdentityCardDate] [datetimeoffset](7) NULL,
	[IdentityCardAddress] [nvarchar](1000) NOT NULL,
	[Password] [nvarchar](4000) NOT NULL,
	[Gender] [int] NULL,
	[IsAdmin] [bit] NULL,
	[PurchaseRevenue] [decimal](18, 2) NOT NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiryTime] [datetime2](7) NOT NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250111141123_Initial DB', N'6.0.0')
GO
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'30134dfe-6e46-4056-b204-24d431cc029c', N'IMPORT-9534', 1, 1, NULL, N'ffffffffffffffffffffffff', CAST(2300.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'ffffffffffffffffffffffff', CAST(N'2025-01-23T15:57:22.8454509+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T16:02:41.2228474+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'e3a4c525-675b-40d7-a8df-2fd9ba6767eb', N'IMPORT-5731', 1, 1, NULL, N'THT', CAST(358023.00 AS Decimal(18, 2)), CAST(N'2025-01-13T22:10:14.7735682+07:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'NO.', CAST(N'2025-01-13T22:10:14.8803834+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-22T16:51:35.1791504+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'df1f7005-1941-4c6a-9f16-42f883af4360', N'IMPORT-9647', 1, 3, NULL, N'KKKKKKK', CAST(11111110.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'dfdfdfdf', CAST(N'2025-01-14T20:22:26.8525577+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-14T20:25:43.5505823+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'c4fd6724-683f-474c-a366-4f329eeab18f', N'IMPORT-2479', 1, 2, NULL, N'Huu Tri Jewelry', CAST(2393937.00 AS Decimal(18, 2)), CAST(N'2025-01-14T19:32:08.6897578+07:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'string', CAST(N'2025-01-14T19:32:08.7276410+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-14T20:09:53.3037974+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'ae8e1eb0-af55-4f22-9ed8-619d40092827', N'IMPORT-3882', 1, 1, NULL, N'TU TRINH', CAST(3000.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'RING RING', CAST(N'2025-01-15T11:53:23.6328948+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-22T16:51:21.7720167+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'492d5b0b-60c6-4ced-bc09-83ab1c2936a3', N'IMPORT-9111', 1, 1, NULL, N'', CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'', CAST(N'2025-01-23T14:53:08.9919222+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T15:12:08.3294172+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'076bdd2f-7fb2-4c00-91ab-90a2ada2d475', N'IMPORT-2413', 1, 1, NULL, N'Nguyễn Thống', CAST(6000.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'Kim cương chất lượng cao', CAST(N'2025-01-22T17:29:03.2861747+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'937a1b1a-8828-47cc-98ae-a696e6cf0d25', N'IMPORT-7584', 1, 1, NULL, N'', CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'', CAST(N'2025-01-23T14:53:49.0685698+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T15:11:34.9199797+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'deb21c32-01fe-4ee4-9991-a72e583e2db6', N'IMPORT-3045', 1, 1, NULL, N'Huu Tri', CAST(334.00 AS Decimal(18, 2)), CAST(N'2025-01-12T12:16:46.9333859+07:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'Huu Tri Supplier', CAST(N'2025-01-12T12:16:47.0048476+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-21T16:57:03.0233563+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'87ae6251-a7be-4b48-88de-b6e0ba7c6da2', N'IMPORT-9028', 1, 1, NULL, N'Hữu Trí', CAST(10110.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'Hữu Trí Hữu Trí Hữu Trí', CAST(N'2025-01-23T11:18:13.8616423+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T13:23:57.9238775+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'17a04aa3-5e79-425a-a142-bcbad65b3d7b', N'IMPORT-6060', 1, 2, NULL, N'Test  123', CAST(2222.00 AS Decimal(18, 2)), CAST(N'2025-02-17T09:27:10.2845617+07:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'Duyệt sáng 17/02', CAST(N'2025-01-23T13:49:03.8345011+00:00' AS DateTimeOffset), NULL, CAST(N'2025-02-17T09:27:10.4514223+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'71b621da-3485-4bc6-af04-c9e645b4cdba', N'IMPORT-6080', 1, 1, NULL, N'Huu TRI IMPORT 19/01 UPDATED', CAST(11110.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'Khong', CAST(N'2025-01-19T21:34:35.5954506+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-22T16:45:26.3593155+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'9408f0f4-2913-490a-922e-d71f55431d89', N'IMPORT-7159', 1, 1, NULL, N'23333', CAST(111.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'23333', CAST(N'2025-01-23T15:55:49.7561721+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T16:02:48.8519430+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Inventories] ([Id], [Code], [Type], [Status], [ReferenceId], [Supplier], [TotalImportPrice], [ImportedAt], [TotalExportPrice], [ExportedAt], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'b9549e82-05bf-431b-982c-f228ebcf5676', N'IMPORT-9285', 1, 1, NULL, N'12121212', CAST(1212.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), N'1212', CAST(N'2025-01-23T16:06:33.3459285+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T16:06:42.9892695+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
GO
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'ac0641f5-393a-46a9-77f5-08dd32c84fd9', N'deb21c32-01fe-4ee4-9991-a72e583e2db6', N'2fd829a9-209c-4fed-92a2-08dd32c7a2ec', CAST(200.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-12T12:16:47.0968880+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-21T16:40:22.2112100+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'bc12db88-56f2-4847-77f6-08dd32c84fd9', N'deb21c32-01fe-4ee4-9991-a72e583e2db6', N'a0d9bfc6-deb7-4faf-92a3-08dd32c7a2ec', CAST(134.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-12T12:16:47.1282936+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-21T16:40:22.2112135+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'22342787-325e-45ca-44ed-08dd33e4623e', N'e3a4c525-675b-40d7-a8df-2fd9ba6767eb', N'b1bcca13-55be-4055-92a6-08dd32c7a2ec', CAST(123456.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-13T22:10:15.0238289+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-19T20:51:45.2426987+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'211ce885-d0f5-4798-44ee-08dd33e4623e', N'e3a4c525-675b-40d7-a8df-2fd9ba6767eb', N'56c91740-e5ab-466f-92a4-08dd32c7a2ec', CAST(234567.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-13T22:10:15.0810779+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-19T20:51:45.2426998+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'1b717ea6-9f55-46fb-aaf5-08dd34977687', N'c4fd6724-683f-474c-a366-4f329eeab18f', N'292918ed-7fab-4db6-2dc4-08dd34961168', CAST(797979.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-14T19:32:08.9736085+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'9faf8e26-646f-407a-aaf6-08dd34977687', N'c4fd6724-683f-474c-a366-4f329eeab18f', N'8ac5daa2-2819-4b21-2dc6-08dd34961168', CAST(797979.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-14T19:32:09.0228006+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'4e43dcf9-6568-42e8-aaf7-08dd34977687', N'c4fd6724-683f-474c-a366-4f329eeab18f', N'ee10cb38-2d10-441b-2dc5-08dd34961168', CAST(797979.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-14T19:32:09.0229936+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'eaed3025-3a05-4898-559c-08dd349e7d6d', N'df1f7005-1941-4c6a-9f16-42f883af4360', N'2e97e207-25c1-445e-2dc8-08dd34961168', CAST(5555555.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-14T20:22:27.0219711+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'5453a9d4-dcc1-4904-559d-08dd349e7d6d', N'df1f7005-1941-4c6a-9f16-42f883af4360', N'e755bc87-e64a-4f05-2dc7-08dd34961168', CAST(5555555.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-14T20:22:27.0736409+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'7da0e31e-7e71-411c-3fdd-08dd35208a9e', N'ae8e1eb0-af55-4f22-9ed8-619d40092827', N'149096ed-d6a9-4afa-5a88-08dd351f9511', CAST(1500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-15T11:53:23.7312772+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-15T12:21:30.6327731+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'7b6288ce-f676-4374-3fde-08dd35208a9e', N'ae8e1eb0-af55-4f22-9ed8-619d40092827', N'30681651-2455-41a7-5a89-08dd351f9511', CAST(1500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-15T11:53:23.7601277+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-15T12:21:30.6327750+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'5200507c-5429-41df-0ecf-08dd38966595', N'71b621da-3485-4bc6-af04-c9e645b4cdba', N'2703e193-a784-44dd-cabe-08dd3895fc29', CAST(5000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-19T21:34:35.6985740+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-21T16:45:04.2737250+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'62439a87-a5c7-4222-0ed0-08dd38966595', N'71b621da-3485-4bc6-af04-c9e645b4cdba', N'c64ca07f-360c-4680-cabf-08dd3895fc29', CAST(5000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-19T21:34:35.7267116+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-21T10:05:44.6944357+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'f5934c56-5330-48d9-1a2c-08dd39c87f5e', N'71b621da-3485-4bc6-af04-c9e645b4cdba', N'41083aed-4a4f-44c3-cabd-08dd3895fc29', CAST(5555.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-21T10:05:44.9395224+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-21T16:45:04.2737263+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'fb05eda4-d0cd-4f43-fcde-08dd3acf97b2', N'076bdd2f-7fb2-4c00-91ab-90a2ada2d475', N'b1bcca13-55be-4055-92a6-08dd32c7a2ec', CAST(2500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-22T17:29:03.4156038+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'91f2e561-e9ef-4f5c-fcdf-08dd3acf97b2', N'076bdd2f-7fb2-4c00-91ab-90a2ada2d475', N'56c91740-e5ab-466f-92a4-08dd32c7a2ec', CAST(3500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-22T17:29:03.4630593+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'1b57bde1-7023-4016-0653-08dd3b64f480', N'87ae6251-a7be-4b48-88de-b6e0ba7c6da2', N'5ae333b6-91a3-4d2f-5b92-08dd3aa5190d', CAST(5555.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T11:18:14.1223386+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'cf888a7d-77a8-4ae3-0654-08dd3b64f480', N'87ae6251-a7be-4b48-88de-b6e0ba7c6da2', N'2703e193-a784-44dd-cabe-08dd3895fc29', CAST(4555.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T11:18:14.1611652+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'1d4689b9-5e44-47f1-963c-08dd3b7a069f', N'17a04aa3-5e79-425a-a142-bcbad65b3d7b', N'883e22d5-751e-4226-5a87-08dd351f9511', CAST(7979.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T13:49:03.9586698+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T14:21:01.7549087+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'484df6a3-c1ff-4b7c-963d-08dd3b7a069f', N'17a04aa3-5e79-425a-a142-bcbad65b3d7b', N'4ddb73e2-d840-443e-5a86-08dd351f9511', CAST(7979.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T13:49:04.0080272+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T13:58:54.2671600+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'eb196378-ece2-4f30-9b63-08dd3b7e7df4', N'17a04aa3-5e79-425a-a142-bcbad65b3d7b', N'4ddb73e2-d840-443e-5a86-08dd351f9511', CAST(2222.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T14:21:02.1389295+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T14:21:02.1371883+07:00' AS DateTimeOffset), NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'36277333-fb23-40d2-3ef3-08dd3b82fa91', N'492d5b0b-60c6-4ced-bc09-83ab1c2936a3', N'1a434dce-77ac-49a1-9ee8-08dd3a9f8c2b', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T14:53:09.2046470+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T15:12:08.3304850+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'1df8ff41-5135-44d6-3ef4-08dd3b82fa91', N'492d5b0b-60c6-4ced-bc09-83ab1c2936a3', N'41083aed-4a4f-44c3-cabd-08dd3895fc29', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T14:53:09.2422036+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T15:12:08.3304860+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'd80a34ef-0fbb-4a94-3ef5-08dd3b82fa91', N'937a1b1a-8828-47cc-98ae-a696e6cf0d25', N'f5d2632f-dd3d-4163-cabc-08dd3895fc29', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T14:53:49.0800169+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T15:11:34.9341374+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'7f98fa84-1144-4b61-3ef6-08dd3b82fa91', N'9408f0f4-2913-490a-922e-d71f55431d89', N'1a434dce-77ac-49a1-9ee8-08dd3a9f8c2b', CAST(111.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T15:55:49.7682900+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'8df907d6-40f1-416b-3ef7-08dd3b82fa91', N'30134dfe-6e46-4056-b204-24d431cc029c', N'41083aed-4a4f-44c3-cabd-08dd3895fc29', CAST(2300.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T15:57:22.8573680+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T16:02:41.2251885+07:00' AS DateTimeOffset), NULL, 1, 1)
INSERT [dbo].[InventoryDetails] ([Id], [InventoryId], [JewelryId], [ImportPrice], [ExportPrice], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'88ac0d04-37d3-4555-3ef8-08dd3b82fa91', N'b9549e82-05bf-431b-982c-f228ebcf5676', N'41083aed-4a4f-44c3-cabd-08dd3895fc29', CAST(1212.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-01-23T16:06:33.3575105+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T16:06:42.9916241+07:00' AS DateTimeOffset), NULL, 1, 1)
GO
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'2fd829a9-209c-4fed-92a2-08dd32c7a2ec', N'Ruby Ring', N'JW-1', N'A luxurious gold ring with a ruby gemstone.', CAST(120.50 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), NULL, 8, NULL, NULL, N'Perfect for special occasions.', N'Red', N'', N'', N'', N'Gold', CAST(5.20 AS Decimal(18, 2)), N'Ruby', N'M', N'CERT12345', N'', N'Sri Lanka', N'GemCraft Co.', CAST(N'2025-01-12T12:11:56.9502139+00:00' AS DateTimeOffset), NULL, NULL, N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'a0d9bfc6-deb7-4faf-92a3-08dd32c7a2ec', N'Emerald Pendant', N'JW-2', N'A stunning platinum pendant with an emerald.', CAST(95.75 AS Decimal(18, 2)), CAST(134.00 AS Decimal(18, 2)), NULL, 8, NULL, NULL, N'Comes with a matching chain.', N'Green', N'', N'', N'', N'Platinum', CAST(3.80 AS Decimal(18, 2)), N'Emerald', N'L', N'CERT54321', N'', N'Colombia', N'Emerald Jewelers', CAST(N'2025-01-12T12:12:09.5618099+00:00' AS DateTimeOffset), NULL, NULL, N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'56c91740-e5ab-466f-92a4-08dd32c7a2ec', N'Sapphire Earrings đ', N'JW-3', N'Elegant silver earrings featuring blue sapphires.', CAST(85.00 AS Decimal(18, 2)), CAST(3500.00 AS Decimal(18, 2)), CAST(44444.00 AS Decimal(18, 2)), 2, NULL, NULL, N'Lightweight and comfortable.', N'Blue', N'', N'', N'', N'Silver', CAST(2.50 AS Decimal(18, 2)), N'Sapphire', N'M', N'CERT67890', N'', N'Myanmar', N'BlueGem Inc.', CAST(N'2025-01-12T12:12:31.9059486+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-22T17:29:03.2834692+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'32259d83-7f20-481c-92a5-08dd32c7a2ec', N'Diamond Bracelet', N'JW-4', N'A sparkling white gold bracelet with diamonds.', CAST(250.00 AS Decimal(18, 2)), NULL, NULL, 2, NULL, NULL, N'A timeless piece for any collection.', N'White', N'', N'', N'', N'White Gold', CAST(10.00 AS Decimal(18, 2)), N'Diamond', N'L', N'CERT09876', N'', N'South Africa', N'Diamond House', CAST(N'2025-01-12T12:12:48.2986450+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'b1bcca13-55be-4055-92a6-08dd32c7a2ec', N'Amethyst Necklace', N'JW-5', N'An exquisite rose gold necklace with an amethyst centerpiece.', CAST(70.30 AS Decimal(18, 2)), CAST(2500.00 AS Decimal(18, 2)), CAST(22222.00 AS Decimal(18, 2)), 2, NULL, NULL, N'Ideal for evening wear.', N'Purple', N'', N'', N'', N'Rose Gold', CAST(7.50 AS Decimal(18, 2)), N'Amethyst', N'S', N'CERT11223', N'', N'Brazil', N'PurpleGems', CAST(N'2025-01-12T12:13:07.5458723+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-22T17:29:03.2834719+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'292918ed-7fab-4db6-2dc4-08dd34961168', N'Amethyst Ring', N'JW-6', N'Silver ring with a radiant amethyst gemstone.', CAST(700.00 AS Decimal(18, 2)), CAST(797979.00 AS Decimal(18, 2)), CAST(999999.00 AS Decimal(18, 2)), 3, CAST(N'2025-01-14T20:09:53.1117856+07:00' AS DateTimeOffset), NULL, N'Special Valentine''s collection', N'Purple', N'', N'', N'', N'Silver', CAST(4.50 AS Decimal(18, 2)), N'Amethyst', N'M', N'CERT99001', N'', N'Brazil', N'Purple Shine Co.', CAST(N'2025-01-14T19:22:09.7990500+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-14T20:09:53.1117845+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'ee10cb38-2d10-441b-2dc5-08dd34961168', N'Opal Necklace 11111', N'JW-7', N'Gold necklace featuring a stunning opal gemstone.', CAST(1800.00 AS Decimal(18, 2)), CAST(797979.00 AS Decimal(18, 2)), CAST(999999.00 AS Decimal(18, 2)), 0, CAST(N'2025-01-14T20:09:53.1117884+07:00' AS DateTimeOffset), NULL, N'Highly durable design', N'White', N'', N'', N'', N'Gold', CAST(12.00 AS Decimal(18, 2)), N'Opal', N'L', N'CERT22334', N'', N'Australia', N'Opal Glow Ltd.', CAST(N'2025-01-14T19:22:20.1025235+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-16T14:45:33.4522236+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'8ac5daa2-2819-4b21-2dc6-08dd34961168', N'Citrine Bracelet', N'JW-8', N'Bronze bracelet with citrine gemstones.', CAST(850.00 AS Decimal(18, 2)), CAST(797979.00 AS Decimal(18, 2)), CAST(999999.00 AS Decimal(18, 2)), 3, CAST(N'2025-01-14T20:09:53.1117888+07:00' AS DateTimeOffset), NULL, N'Perfect for daily wear', N'Yellow', N'', N'', N'', N'Bronze', CAST(8.00 AS Decimal(18, 2)), N'Citrine', N'S', N'CERT55677', N'', N'Madagascar', N'Sunny Gems Co.', CAST(N'2025-01-14T19:22:32.2359314+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-14T20:09:53.1117888+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'e755bc87-e64a-4f05-2dc7-08dd34961168', N'Pearl Earrings', N'JW-9', N'Elegant white gold earrings with freshwater pearls.', CAST(950.00 AS Decimal(18, 2)), CAST(5555555.00 AS Decimal(18, 2)), CAST(44444.00 AS Decimal(18, 2)), 5, NULL, NULL, N'Classic design for formal events', N'White', N'', N'', N'', N'White Gold', CAST(3.20 AS Decimal(18, 2)), N'Pearl', N'XS', N'CERT66789', N'', N'Japan', N'Ocean Pearls Ltd.', CAST(N'2025-01-14T19:22:39.9240345+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-14T20:25:43.5184411+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'2e97e207-25c1-445e-2dc8-08dd34961168', N'Garnet Pendant', N'JW-10', N'Silver pendant with a fiery red garnet gemstone.', CAST(650.00 AS Decimal(18, 2)), CAST(5555555.00 AS Decimal(18, 2)), CAST(44444.00 AS Decimal(18, 2)), 5, NULL, NULL, N'Affordable luxury', N'Red', N'', N'', N'', N'Silver', CAST(4.00 AS Decimal(18, 2)), N'Garnet', N'M', N'CERT99012', N'', N'India', N'Redstone Gems', CAST(N'2025-01-14T19:22:47.6872493+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-14T20:25:43.5184433+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'6f9df491-5a0f-467e-5a85-08dd351f9511', N'Elegant Ruby Ring 123123', N'JW-11', N'A classic gold ring with a stunning ruby centerpiece.', CAST(500.00 AS Decimal(18, 2)), NULL, NULL, 1, NULL, NULL, N'Perfect for formal occasions.', N'Red', N'', N'', N'', N'Gold', CAST(3.20 AS Decimal(18, 2)), N'Ruby', N'M', N'CERT12345', N'', N'Vietnam', N'RubyCrafts', CAST(N'2025-01-15T11:46:31.7401351+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-16T15:10:42.2441702+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'4ddb73e2-d840-443e-5a86-08dd351f9511', N'Luxury Diamond Band UPDATED lại fff', N'JW-12', N'A sleek platinum band adorned with small diamonds.', CAST(1200.00 AS Decimal(18, 2)), CAST(2222.00 AS Decimal(18, 2)), CAST(3333.00 AS Decimal(18, 2)), 4, CAST(N'2025-02-17T09:27:10.2921556+07:00' AS DateTimeOffset), NULL, N'Timeless design for engagements.', N'Silver', N'', N'', N'', N'Platinum', CAST(4.50 AS Decimal(18, 2)), N'Diamond', N'L', N'CERT67890', N'', N'South Africa', N'Diamond Creations', CAST(N'2025-01-15T11:46:39.8153989+00:00' AS DateTimeOffset), NULL, CAST(N'2025-02-17T09:28:38.8337331+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'883e22d5-751e-4226-5a87-08dd351f9511', N'Emerald Twist Ring Updated', N'JW-13', N'A white gold ring featuring a unique twisted design with emeralds.', CAST(800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, 8, NULL, NULL, N'Limited edition piece.', N'Green', N'', N'', N'', N'White Gold', CAST(2.80 AS Decimal(18, 2)), N'Emerald', N'S', N'CERT11223', N'', N'Colombia', N'GreenStone Jewelry', CAST(N'2025-01-15T11:46:49.3191221+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T14:20:40.8019885+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'149096ed-d6a9-4afa-5a88-08dd351f9511', N'Sapphire Halo Ring 123123', N'JW-14', N'A rose gold ring with a sapphire surrounded by diamonds.', CAST(950.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL, N'A favorite among collectors.', N'Blue', N'', N'', N'', N'Rose Gold', CAST(3.00 AS Decimal(18, 2)), N'Sapphire', N'M', N'CERT44556', N'', N'Sri Lanka', N'Blue Jewelers', CAST(N'2025-01-15T11:47:01.0139534+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-16T14:53:31.8225466+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'30681651-2455-41a7-5a89-08dd351f9511', N'Opal Necklace 11111', N'JW-13', N'Gold necklace featuring a stunning opal gemstone.', CAST(1800.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL, N'Highly durable design', N'White', N'', N'', N'', N'Gold', CAST(12.00 AS Decimal(18, 2)), N'Opal', N'L', N'CERT22334', N'', N'Australia', N'Opal Glow Ltd.', CAST(N'2025-01-15T11:47:08.2978523+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-16T14:50:04.9988157+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'12188ffc-60a6-4165-cabb-08dd3895fc29', N'Vòng Kim Cương Anh Thái', N'JW-16', N'Vòng kim cương tinh tế với thiết kế cổ điển.', CAST(2500.50 AS Decimal(18, 2)), NULL, NULL, 1, NULL, NULL, N'Có thể điều chỉnh kích thước', N'Trắng', N'', N'', N'', N'Bạc 925', CAST(5.20 AS Decimal(18, 2)), N'Kim cương', N'S', N'CD123456789', N'', N'Việt Nam', N'Công ty Kim Cương An Phát', CAST(N'2025-01-19T21:31:38.8031403+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'f5d2632f-dd3d-4163-cabc-08dd3895fc29', N'Vòng Ngọc Trai Thanh Lịch', N'JW-17', N'Vòng ngọc trai với thiết kế hiện đại và thanh lịch.', CAST(1800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, 8, NULL, NULL, N'Có thể tùy chọn màu ngọc', N'Ngọc trai trắng', N'', N'', N'', N'Vàng 18K', CAST(4.50 AS Decimal(18, 2)), N'Ngọc trai', N'S', N'NT987654321', N'', N'Thái Lan', N'Cửa hàng Ngọc Trai Sài Gòn', CAST(N'2025-01-19T21:31:52.7672821+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T14:53:49.0681447+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'41083aed-4a4f-44c3-cabd-08dd3895fc29', N'Vòng Bạc Thiết Kế Độc Đáo', N'JW-18', N'Vòng bạc với họa tiết tinh xảo, phù hợp với mọi phong cách.', CAST(750.75 AS Decimal(18, 2)), CAST(1212.00 AS Decimal(18, 2)), NULL, 8, NULL, NULL, N'Không kèm hộp đựng', N'Bạc', N'', N'', N'', N'Bạc nguyên chất', CAST(3.80 AS Decimal(18, 2)), N'Không', N'S', N'BK192837465', N'', N'Trung Quốc', N'Nhà sản xuất Vàng Bạc Đá Quý', CAST(N'2025-01-19T21:32:05.4722827+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T16:06:33.3455400+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'2703e193-a784-44dd-cabe-08dd3895fc29', N'Vòng Vàng Hồng Sang Trọng', N'JW-19', N'Vòng vàng hồng với thiết kế sang trọng và quý phái.', CAST(3200.00 AS Decimal(18, 2)), CAST(4555.00 AS Decimal(18, 2)), NULL, 2, NULL, NULL, N'Kèm theo giấy chứng nhận', N'Hồng', N'', N'', N'', N'Vàng hồng 24K', CAST(6.00 AS Decimal(18, 2)), N'Ruby', N'M', N'VH564738291', N'', N'Ý', N'Công ty Vàng Bạc Đá Quý Hà Nội', CAST(N'2025-01-19T21:32:17.3180168+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T11:18:13.8459352+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'c64ca07f-360c-4680-cabf-08dd3895fc29', N'Vòng Vàng Hồng Sang Trọng', N'JW-20', N'Vòng vàng hồng với thiết kế sang trọng và quý phái.', CAST(3200.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), NULL, 2, NULL, NULL, N'Kèm theo giấy chứng nhận', N'Hồng', N'', N'', N'', N'Vàng hồng 24K', CAST(6.00 AS Decimal(18, 2)), N'Ruby', N'L', N'VH564738291', N'', N'Ý', N'Công ty Vàng Bạc Đá Quý Hà Nội', CAST(N'2025-01-19T21:32:27.7117671+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-19T21:34:35.5817250+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'25c34eb1-7ca0-462f-9ee7-08dd3a9f8c2b', N'SP 001', N'JW-21', N'Không có gì để nói', CAST(1000.00 AS Decimal(18, 2)), NULL, NULL, 1, NULL, NULL, N'', N'Red', N'', N'', N'', N'fff', CAST(1212.00 AS Decimal(18, 2)), N'1212', N'M', N'1212', N'', N'1212', N'Huu Tri', CAST(N'2025-01-22T11:45:08.1513958+00:00' AS DateTimeOffset), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'1a434dce-77ac-49a1-9ee8-08dd3a9f8c2b', N'Name updated 111', N'JW-22', N'd', CAST(12.00 AS Decimal(18, 2)), CAST(111.00 AS Decimal(18, 2)), NULL, 2, NULL, NULL, N'd', N'12', N'', N'', N'', N'12', CAST(12.00 AS Decimal(18, 2)), N'12', N'S', N'12', N'', N'12', N'd', CAST(N'2025-01-22T11:46:04.2814145+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T15:55:49.7557956+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Jewelries] ([Id], [Name], [Code], [Description], [CreatedPrice], [ImportPrice], [SalePrice], [Status], [ImportedAt], [SoldAt], [Note], [Color], [BarCode], [QRCode], [SKU], [Material], [Weight], [Gemstone], [Size], [CertificateNumber], [ImageUrl], [Origin], [Supplier], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'5ae333b6-91a3-4d2f-5b92-08dd3aa5190d', N'123123', N'JW-23', N'123', CAST(123.00 AS Decimal(18, 2)), CAST(5555.00 AS Decimal(18, 2)), NULL, 2, NULL, NULL, N'12344', N'123', N'', N'', N'', N'123', CAST(123.00 AS Decimal(18, 2)), N'123', N'XL', N'123', N'', N'123', N'123', CAST(N'2025-01-22T12:24:52.0571205+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-23T11:18:13.8459484+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [JewelryId], [SalePrice], [SoldAt], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'1e8ec229-c40b-44cd-feca-08dd4efac9ab', N'38570d9b-0260-46ef-b372-0c72afd1dd86', N'4ddb73e2-d840-443e-5a86-08dd351f9511', CAST(3333.00 AS Decimal(18, 2)), CAST(N'2025-02-17T09:28:38.8338984+07:00' AS DateTimeOffset), NULL, NULL, NULL, NULL, 0, 1)
GO
INSERT [dbo].[Orders] ([Id], [CustomerId], [Code], [Status], [TotalAmount], [Note], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'38570d9b-0260-46ef-b372-0c72afd1dd86', N'c48582f2-63ec-4ad3-0faa-08dd36a97cb4', N'ORDER-173863', 1, CAST(3333.00 AS Decimal(18, 2)), N'Đơn hàng tạo lần đầu', CAST(N'2025-02-17T09:28:38.8367968+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
GO
INSERT [dbo].[Roles] ([Id], [RoleName], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'a0d68896-6e89-46a4-a9e7-2b0aa17edc97', N'User', NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Roles] ([Id], [RoleName], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'254a86dd-3e41-45b8-bb91-f97ee3b17c70', N'Admin', NULL, NULL, NULL, NULL, 0, 1)
GO
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'76fc0760-be56-4c90-b09c-fde6436050f9', N'aac63b91-beb8-4de4-b050-f2888fdff282', N'254a86dd-3e41-45b8-bb91-f97ee3b17c70', NULL, NULL, NULL, NULL, 0, 1)
GO
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'36dabb6a-d17a-44ae-0fa6-08dd36a97cb4', N'USER-2639', N'johnDoe', N'John', N'Doe', N'John Doe', N'0901234567', N'john.doe@example.com', N'123 Main Street', 1, CAST(N'2025-01-17T03:43:57.7250000+00:00' AS DateTimeOffset), N'123456789', NULL, N'', N'37F2B81713B12864FDD78828F9ECA8A36BC47E84', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-17T10:46:12.5832280+00:00' AS DateTimeOffset), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'7a610b67-f03e-4338-0fa7-08dd36a97cb4', N'USER-9795', N'janeSmith UPDATED 1', N'Jane', N'Smith', N'Jane Smith', N'0912345678', N'jane.smith@example.com', N'456 Elm Avenue', 1, CAST(N'2025-01-17T10:43:57.7250000+07:00' AS DateTimeOffset), N'987654321', NULL, N'', N'37F2B81713B12864FDD78828F9ECA8A36BC47E84', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-17T10:46:29.6988945+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-17T10:51:00.9216746+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 1, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'51d737e2-fdf8-4cd2-0fa8-08dd36a97cb4', N'USER-9195', N'michaelJordan', N'Michael', N'Jordan', N'Michael Jordan', N'0923456789', N'michael.jordan@example.com', N'23 Basketball Road', 1, CAST(N'2025-01-17T03:43:57.7250000+00:00' AS DateTimeOffset), N'234567891', NULL, N'', N'37F2B81713B12864FDD78828F9ECA8A36BC47E84', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-17T10:46:41.9281858+00:00' AS DateTimeOffset), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'397cf661-a2ec-46d3-0fa9-08dd36a97cb4', N'USER-2282', N'emilyClark', N'Emily', N'Clark', N'Emily Clark', N'0934567890', N'emily.clark@example.com', N'17 Cherry Boulevard', 1, CAST(N'2025-01-17T03:43:57.7250000+00:00' AS DateTimeOffset), N'456789012', NULL, N'', N'37F2B81713B12864FDD78828F9ECA8A36BC47E84', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-17T10:46:54.1768730+00:00' AS DateTimeOffset), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'c48582f2-63ec-4ad3-0faa-08dd36a97cb4', N'USER-2558', N'alexNguyen  111', N'Alex', N'Nguyen', N'Alex Nguyen', N'0945678901', N'alex.nguyen@example.com', N'50 West Street', 1, CAST(N'2025-01-17T10:43:57.7250000+07:00' AS DateTimeOffset), N'567890123', NULL, N'', N'37F2B81713B12864FDD78828F9ECA8A36BC47E84', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-17T10:47:09.1033493+00:00' AS DateTimeOffset), NULL, CAST(N'2025-01-22T15:34:13.2736775+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'eaff72d3-775e-45a5-ced9-08dd3ac2939a', N'USER-4308', N'Huu Tri', N'Tran', N'Tri', N'Tran Huu Tri', N'0328595889', N'trithse151390@gmail.com', N'Bình Phước', 1, CAST(N'2001-04-13T00:00:00.0000000+07:00' AS DateTimeOffset), N'123123123', NULL, N'', N'FF9A32AB4A6E687FF64C2A139A9D04BD3AD58F10', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-01-22T15:55:53.0665858+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'cca60322-4b23-47f4-3036-08dd44076b0e', N'USER-7916', N'john_doe', N'John', N'Doe', N'John Doe', N'1234567890', N'johndoe@example.com', N'123 Main St, New York, NY', 1, CAST(N'1995-06-15T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID123456789', NULL, N'', N'CBFDAC6008F9CAB4083784CBD1874F76618D2A97', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:01:20.7778446+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'798aa963-b830-498f-3037-08dd44076b0e', N'USER-3697', N'jane_smith', N'Jane', N'Smith', N'Jane Smith', N'0987654321', N'janesmith@example.com', N'456 Elm St, Los Angeles, CA', 1, CAST(N'1998-09-25T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID987654321', NULL, N'', N'8B52ACC8B470B12DD8CD38C641A867B4CB1CB324', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:01:35.4155207+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'9d0133be-3e0e-4f04-3038-08dd44076b0e', N'USER-2792', N'david_brown', N'David', N'Brown', N'David Brown', N'1122334455', N'davidbrown@example.com', N'789 Oak St, Chicago, IL', 1, CAST(N'1992-03-12T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID112233445', NULL, N'', N'217F3B08D5DD91EF2452677A46741BC1DE2DA458', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:01:49.3652041+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'892230b7-2523-409e-3039-08dd44076b0e', N'USER-8758', N'emily_white', N'Emily', N'White', N'Emily White', N'2233445566', N'emilywhite@example.com', N'321 Pine St, Houston, TX', 1, CAST(N'2000-07-19T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID223344556', NULL, N'', N'597B2BC36BEA3439F0F5D552B3240054FA01A60F', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:02:03.2121828+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'3f6024e1-17d6-4844-303a-08dd44076b0e', N'USER-8684', N'michael_johnson', N'Michael', N'Johnson', N'Michael Johnson', N'3344556677', N'michaeljohnson@example.com', N'654 Maple St, San Francisco, CA', 1, CAST(N'1991-11-05T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID334455667', NULL, N'', N'7A33165959CC48F6CEED221AADD518653623B319', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:02:17.1979955+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'b8b53d87-cb00-4470-303b-08dd44076b0e', N'USER-6699', N'sophia_miller', N'Sophia', N'Miller', N'Sophia Miller', N'4455667788', N'sophiamiller@example.com', N'987 Birch St, Seattle, WA', 1, CAST(N'1997-02-28T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID445566778', NULL, N'', N'B20FEF0D7E357025CF344BAD6122942058BEC019', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:02:31.7680801+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'de56ebd6-c25f-4b68-303c-08dd44076b0e', N'USER-4353', N'william_taylor', N'William', N'Taylor', N'William Taylor', N'5566778899', N'williamtaylor@example.com', N'159 Cedar St, Boston, MA', 1, CAST(N'1989-12-10T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID556677889', NULL, N'', N'996C390442DEF46DCA0D19C5DC94454099770579', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:02:44.4563557+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'f397d751-a6a3-4d95-303d-08dd44076b0e', N'USER-2424', N'olivia_anderson', N'Olivia', N'Anderson', N'Olivia Anderson', N'6677889900', N'oliviaanderson@example.com', N'753 Walnut St, Denver, CO', 1, CAST(N'1994-08-07T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID667788990', NULL, N'', N'BF95DD0C64B8F2D99E32EB1F10F1AD914ED5EE8C', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:02:57.4426199+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'1953ecd4-1202-45d0-303e-08dd44076b0e', N'USER-9229', N'james_wilson', N'James', N'Wilson', N'James Wilson', N'7788990011', N'jameswilson@example.com', N'852 Spruce St, Miami, FL', 1, CAST(N'1993-05-14T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID778899001', NULL, N'', N'190BB86F4FD139FEE6F8CC1945544594322A0560', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:03:09.7201808+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'33c7b795-c206-4c58-303f-08dd44076b0e', N'USER-2065', N'ava_moore', N'Ava', N'Moore', N'Ava Moore', N'8899001122', N'avamoore@example.com', N'951 Chestnut St, Austin, TX', 1, CAST(N'1996-01-22T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID889900112', NULL, N'', N'F91D86E2A55B9F68526F10FBCD45F8CB01419E60', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:03:21.9082473+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'71acc3e3-816e-45f0-3040-08dd44076b0e', N'USER-3844', N'lucas_bennett', N'Lucas', N'Bennett', N'Lucas Bennett', N'9011223344', N'lucasbennett@example.com', N'741 Willow St, Portland, OR', 1, CAST(N'1992-10-30T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID901122334', NULL, N'', N'7A4D421C97CC030E3D8624D0E2827FA08F9847A6', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:04:30.0662684+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'4aaa168f-59e7-4c75-3041-08dd44076b0e', N'USER-4148', N'mia_roberts', N'Mia', N'Roberts', N'Mia Roberts', N'9122334455', N'miaroberts@example.com', N'369 Aspen St, Phoenix, AZ', 1, CAST(N'1998-04-17T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID912233445', NULL, N'', N'46A0DBD69B26152971FB0575BA13E12294E7C469', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:04:42.0937879+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'4ff65d28-2dfc-444c-3042-08dd44076b0e', N'USER-6805', N'ethan_hall', N'Ethan', N'Hall', N'Ethan Hall', N'9233445566', N'ethanhall@example.com', N'258 Redwood St, Dallas, TX', 1, CAST(N'1995-07-22T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID923344556', NULL, N'', N'D702DFFE074959FF7FA8E8289C945ED9751516E2', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:04:55.1863100+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'cf6a412c-bf78-4f3b-3043-08dd44076b0e', N'USER-7563', N'amelia_clark', N'Amelia', N'Clark', N'Amelia Clark', N'9344556677', N'ameliac@example.com', N'147 Sycamore St, San Diego, CA', 1, CAST(N'1999-11-02T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID934455667', NULL, N'', N'E852F04C338EF0DFC8689A571E1E8E5008BEF1E4', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:05:06.5334525+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'3d112836-053d-4f8f-3044-08dd44076b0e', N'USER-6717', N'noah_lewis', N'Noah', N'Lewis', N'Noah Lewis', N'9455667788', N'noahlewis@example.com', N'369 Poplar St, Nashville, TN', 1, CAST(N'1991-06-28T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID945566778', NULL, N'', N'A669B2EC0FC3773C85D2181782AEA19C10113A57', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:05:18.2134390+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'17ba767f-144c-476b-3045-08dd44076b0e', N'USER-8759', N'charlotte_walker', N'Charlotte', N'Walker', N'Charlotte Walker', N'9566778899', N'charlottew@example.com', N'852 Magnolia St, Atlanta, GA', 1, CAST(N'1993-09-14T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID956677889', NULL, N'', N'176470A5CC7D50FD9A6C1230B987CB04770845B5', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:05:28.5464506+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'5e187325-fa1b-4e8a-3046-08dd44076b0e', N'USER-3502', N'liam_scott', N'Liam', N'Scott', N'Liam Scott', N'9677889900', N'liamscott@example.com', N'369 Palm St, Las Vegas, NV', 1, CAST(N'1988-12-03T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID967788990', NULL, N'', N'0F638B26EC80DDB9653A174A071A2454EC8F90A6', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:05:34.5716221+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'e3b9210e-649c-4e08-3047-08dd44076b0e', N'USER-5038', N'isabella_harris', N'Isabella', N'Harris', N'Isabella Harris', N'9788990011', N'isabellah@example.com', N'741 Cedar St, Minneapolis, MN', 1, CAST(N'1996-03-25T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID978899001', NULL, N'', N'185EAE4ED03083E3D0696B62082DA0AC02FB4F85', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:05:42.0955769+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'c698b2b3-9d16-477d-3048-08dd44076b0e', N'USER-6704', N'benjamin_adams', N'Benjamin', N'Adams', N'Benjamin Adams', N'9899001122', N'benjaminadams@example.com', N'258 Laurel St, Kansas City, MO', 1, CAST(N'1990-05-09T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID989900112', NULL, N'', N'915EF83015A1EA420B9F3DD64C86879174EA54D0', 1, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:05:50.6070001+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'1e889200-1662-4f2a-3049-08dd44076b0e', N'USER-6542', N'ella_martin', N'Ella', N'Martin', N'Ella Martin', N'9900112233', N'ellamartin@example.com', N'159 Olive St, Charlotte, NC', 1, CAST(N'2001-07-30T04:00:00.9680000+00:00' AS DateTimeOffset), N'ID990011223', NULL, N'', N'853DEF9F83E045436FD760F6ECD62EE4938560D3', 0, 0, CAST(0.00 AS Decimal(18, 2)), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-03T11:05:56.2686320+00:00' AS DateTimeOffset), NULL, NULL, NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [FirstName], [LastName], [FullName], [Phone], [Email], [Address], [Status], [Birthday], [IdentityCard], [IdentityCardDate], [IdentityCardAddress], [Password], [Gender], [IsAdmin], [PurchaseRevenue], [RefreshToken], [RefreshTokenExpiryTime], [Created], [CreatedBy], [Updated], [UpdatedBy], [Deleted], [IsActive]) VALUES (N'aac63b91-beb8-4de4-b050-f2888fdff282', N'AD-01', N'admin', N'Tri', N'Tran', N'Tran Huu Tri', N'0333444666', N'admin@gmail.com', N'Bù Đăng, Binh Phuoc', 1, NULL, N'12345', CAST(N'2015-12-25T00:00:00.0000000+07:00' AS DateTimeOffset), N'Binh Phuoc', N'FF9A32AB4A6E687FF64C2A139A9D04BD3AD58F10', 1, 1, CAST(0.00 AS Decimal(18, 2)), N'ZzjSyXz39x2y/sG9+DG4ExRteu1T4ZIAnDadNTsAT9U=', CAST(N'2025-08-25T12:52:51.0077628' AS DateTime2), CAST(N'2025-01-11T21:11:22.8743770+00:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', CAST(N'2025-01-17T10:20:00.8082333+07:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', 0, 1)
GO
ALTER TABLE [dbo].[InventoryDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryDetails_Inventories_InventoryId] FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryDetails] CHECK CONSTRAINT [FK_InventoryDetails_Inventories_InventoryId]
GO
ALTER TABLE [dbo].[InventoryDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryDetails_Jewelries_JewelryId] FOREIGN KEY([JewelryId])
REFERENCES [dbo].[Jewelries] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryDetails] CHECK CONSTRAINT [FK_InventoryDetails_Jewelries_JewelryId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Jewelries_JewelryId] FOREIGN KEY([JewelryId])
REFERENCES [dbo].[Jewelries] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Jewelries_JewelryId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
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
/****** Object:  StoredProcedure [dbo].[GetDetail_Inventory]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDetail_Inventory]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- Truy vấn thông tin chính của Inventory
    SELECT 
        i.Id,
        i.Code,
        i.Type,
        CASE i.Type
            WHEN 1 THEN 'Import'
            WHEN 2 THEN 'Export'
            ELSE 'Unknown'
        END AS TypeName,
        i.Status,
        CASE i.Status
            WHEN 1 THEN 'Temporary'
            WHEN 2 THEN 'Confirmed'
            ELSE 'Unknown'
        END AS StatusName,
        i.ReferenceId,
        i.Supplier,
        i.TotalImportPrice,
        i.ImportedAt,
        i.TotalExportPrice,
        i.ExportedAt,
        i.Note,
        i.Created AS Created,
        i.CreatedBy,
        i.Updated,
        i.UpdatedBy,
        i.Deleted,
        i.IsActive,
        NULL AS CreatedByName, -- Có thể thay NULL bằng giá trị thực tế nếu cần
        NULL AS CreatedByCode
    FROM Inventories AS i
    WHERE i.Id = @Id AND i.Deleted = 0;

    -- Truy vấn danh sách chi tiết của Inventory
    SELECT
        d.InventoryId,
        d.JewelryId,
        d.ImportPrice,
        d.ExportPrice
    FROM InventoryDetails AS d
    WHERE d.InventoryId = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetPagedData_Innventory]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPagedData_Innventory]
    @PageIndex INT = 1,
    @PageSize INT = 20,
    @SearchContent NVARCHAR(1000) = NULL,
    @OrderBy NVARCHAR(250) = 'i.Created DESC',
    @Ids VARCHAR(MAX) = NULL,
    @Type INT = NULL,
    @Status INT = NULL,
    @IsPaged BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalItem INT;

    IF (@PageIndex IS NULL OR @PageIndex < 1)
        SET @PageIndex = 1;

    IF (@PageSize IS NULL OR @PageSize < 1)
        SET @PageSize = 20;

    -- Tính tổng số bản ghi nếu cần
    IF (@IsPaged = 1)
    BEGIN
        SELECT
            @TotalItem = COUNT(DISTINCT i.Id)
        FROM Inventories AS i
            -- LEFT JOIN InventoryDetails AS id ON id.InventoryId = i.Id
        WHERE i.Deleted = 0
            AND (
                @SearchContent IS NULL
            OR i.Type LIKE N'%' + @SearchContent + '%'
            OR i.Status LIKE N'%' + @SearchContent + '%'
              )
            AND (
                @Ids IS NULL
            OR i.Id IN (SELECT value
            FROM STRING_SPLIT(@Ids, ','))
              )
            AND (
                @Type IS NULL
            OR i.[Type] LIKE @Type
              )
            AND (
                @Status IS NULL
            OR i.[Status] LIKE @Status
              );
    END
    ELSE
    BEGIN
        SET @TotalItem = 0;
    -- Không cần tính tổng khi không phân trang
    END

    ;
    WITH
        PagedList
        AS
        (
            SELECT DISTINCT i.Id
        FROM Inventories AS i
            -- LEFT JOIN InventoryDetails AS id ON id.InventoryId = i.Id
        WHERE i.Deleted = 0
            AND (
                @SearchContent IS NULL
            OR i.Type LIKE N'%' + @SearchContent + '%'
            OR i.Status LIKE N'%' + @SearchContent + '%'
              )
            AND (
                @Ids IS NULL
            OR i.Id IN (SELECT value
            FROM STRING_SPLIT(@Ids, ','))
              )
            AND (
                @Type IS NULL
            OR i.[Type] LIKE @Type
              )
            AND (
                @Status IS NULL
            OR i.[Status] LIKE @Status
              )
        )
    SELECT
        i.*,
        @TotalItem AS TotalItem
    FROM PagedList AS pl
        LEFT JOIN Inventories AS i ON i.Id = pl.Id
        -- LEFT JOIN InventoryDetails AS id ON id.InventoryId = i.Id
    -- Nếu muốn dữ liệu không bị nhân bản dòng (do LEFT JOIN Roles),
    -- có thể GROUP BY hoặc chỉ SELECT các trường cần thiết ở đây
    ORDER BY 
        CASE 
            WHEN @OrderBy = 'i.Created ASC' THEN i.Created
            WHEN @OrderBy = 'i.Created DESC' THEN NULL
            ELSE NULL
        END ASC,
        CASE
            WHEN @OrderBy = 'i.Created DESC' THEN i.Created
            ELSE i.Created -- Default to i.Created DESC when @OrderBy is invalid
        END DESC
    OFFSET (@PageIndex - 1) * @PageSize ROWS 
    FETCH NEXT @PageSize ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPagedData_Jewelry]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPagedData_Jewelry]
    @PageIndex INT = 1,
    @PageSize INT = 20,
    @SearchContent NVARCHAR(1000) = NULL,
    @OrderBy NVARCHAR(250) = 'j.Created DESC',
    @Statuses VARCHAR(MAX) = NULL,
    @Code VARCHAR(MAX) = NULL,
    @IsPaged BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalItem INT;

    IF (@PageIndex IS NULL OR @PageIndex < 1)
        SET @PageIndex = 1;

    IF (@PageSize IS NULL OR @PageSize < 1)
        SET @PageSize = 20;

    -- Tính tổng số bản ghi nếu cần
    IF (@IsPaged = 1)
    BEGIN
        SELECT
            @TotalItem = COUNT(DISTINCT j.Id)
        FROM Jewelries AS j
        WHERE j.Deleted = 0
            AND (
                @SearchContent IS NULL
            OR j.Code LIKE N'%' + @SearchContent + '%'
            OR j.Name LIKE N'%' + @SearchContent + '%'
              )
            AND (
                @Statuses IS NULL
            OR j.[Status] IN (SELECT value
            FROM STRING_SPLIT(@Statuses, ','))
              )
            AND (
                @Code IS NULL
            OR j.Code IN (SELECT value
            FROM STRING_SPLIT(@Code, ','))
              );
    END
    ELSE
    BEGIN
        SET @TotalItem = 0;
    -- Không cần tính tổng khi không phân trang
    END

    ;
    WITH
        PagedList
        AS
        (
            SELECT DISTINCT j.Id
            FROM Jewelries AS j
            WHERE j.Deleted = 0
                AND (
                @SearchContent IS NULL
                OR j.Code LIKE N'%' + @SearchContent + '%'
                OR j.Name LIKE N'%' + @SearchContent + '%'
              )
                AND (
                @Statuses IS NULL
                OR j.[Status] IN (SELECT value
                FROM STRING_SPLIT(@Statuses, ','))
              )
                AND (
                @Code IS NULL
                OR j.Code IN (SELECT value
                FROM STRING_SPLIT(@Code, ','))
              )
        )
    SELECT
        j.*,
        @TotalItem AS TotalItem
    FROM PagedList AS pl
        LEFT JOIN Jewelries AS j ON j.Id = pl.Id

    -- có thể GROUP BY hoặc chỉ SELECT các trường cần thiết ở đây
    ORDER BY 
        CASE 
            WHEN @OrderBy = 'j.Code ASC' THEN j.Code
            WHEN @OrderBy = 'j.Name ASC' THEN j.Name
            WHEN @OrderBy = 'j.Created ASC' THEN j.Created 
            ELSE NULL
        END ASC,
        CASE
            WHEN @OrderBy = 'j.Code DESC' THEN j.Code
            WHEN @OrderBy = 'j.Name DESC' THEN j.Name
            WHEN @OrderBy = 'j.Created DESC' THEN j.Created 
            ELSE j.Created -- Fallback sắp xếp theo ngày mới nhất
        END DESC
    OFFSET (@PageIndex - 1) * @PageSize ROWS 
    FETCH NEXT @PageSize ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPagedData_Order]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[GetPagedData_Order]
    @PageIndex INT = 1,
    @PageSize INT = 20,
    @SearchContent NVARCHAR(1000) = NULL,
    @OrderBy NVARCHAR(250) = 'u.Created DESC',
    @Ids VARCHAR(MAX) = NULL,
    @IsPaged BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalItem INT;

    IF (@PageIndex IS NULL OR @PageIndex < 1)
        SET @PageIndex = 1;

    IF (@PageSize IS NULL OR @PageSize < 1)
        SET @PageSize = 20;

    -- Tính tổng số bản ghi nếu cần
    IF (@IsPaged = 1)
    BEGIN
        SELECT 
            @TotalItem = COUNT(DISTINCT o.Id)
        FROM Orders AS o
            LEFT JOIN OrderDetails AS od ON od.OrderId = o.Id
            LEFT JOIN Users AS u ON u.Id = o.CustomerId
			LEFT JOIN Jewelries AS j ON j.Id = od.JewelryId
        WHERE u.Deleted = 0
          AND (
                @SearchContent IS NULL
                OR o.Code LIKE N'%' + @SearchContent + '%'
              )
          AND (
                @Ids IS NULL 
                OR o.Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
              );
    END
    ELSE
    BEGIN
        SET @TotalItem = 0; -- Không cần tính tổng khi không phân trang
    END

    ;WITH PagedList AS 
    (
        SELECT DISTINCT o.Id
        FROM Orders AS o
            LEFT JOIN OrderDetails AS od ON od.OrderId = o.Id
            LEFT JOIN Users AS u ON u.Id = o.CustomerId
			LEFT JOIN Jewelries AS j ON j.Id = od.JewelryId
        WHERE o.Deleted = 0
          AND (
                @SearchContent IS NULL
                OR o.Code LIKE N'%' + @SearchContent + '%'
              )
          AND (
                @Ids IS NULL 
                OR o.Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
              )
	)
    SELECT 
        o.Id,
		o.CustomerId, 
		o.Code,
		o.Status,
		o.TotalAmount,
		o.Note,
		o.Created,
		o.CreatedBy,
		o.Updated,
		o.UpdatedBy,

        @TotalItem AS TotalItem
    FROM PagedList AS pl
			JOIN Orders AS o ON pl.Id = o.Id 
            LEFT JOIN OrderDetails AS od ON od.OrderId = o.Id
            LEFT JOIN Users AS u ON u.Id = o.CustomerId
			LEFT JOIN Jewelries AS j ON j.Id = od.JewelryId
    -- Nếu muốn dữ liệu không bị nhân bản dòng (do LEFT JOIN Roles),
    -- có thể GROUP BY hoặc chỉ SELECT các trường cần thiết ở đây
	--GROUP BY 
	--	o.Code
    ORDER BY 
        CASE 
            WHEN @OrderBy = 'u.Code ASC' THEN o.Code
            WHEN @OrderBy = 'u.Created ASC' THEN CONVERT(NVARCHAR(MAX), o.Created)
            ELSE NULL
        END ASC,
        CASE
            WHEN @OrderBy = 'u.Code DESC' THEN o.Code
            WHEN @OrderBy = 'u.Created DESC' THEN CONVERT(NVARCHAR(MAX), o.Created)
            ELSE NULL
        END DESC
    OFFSET (@PageIndex - 1) * @PageSize ROWS 
    FETCH NEXT @PageSize ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPagedData_User]    Script Date: 28/02/2025 11:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[GetPagedData_User]
    @PageIndex INT = 1,
    @PageSize INT = 20,
    @SearchContent NVARCHAR(1000) = NULL,
    @OrderBy NVARCHAR(250) = 'u.Created DESC',
    @Ids VARCHAR(MAX) = NULL,
    @Roles VARCHAR(MAX) = NULL,
    @IsPaged BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalItem INT;

    IF (@PageIndex IS NULL OR @PageIndex < 1)
        SET @PageIndex = 1;

    IF (@PageSize IS NULL OR @PageSize < 1)
        SET @PageSize = 20;

    -- Tính tổng số bản ghi nếu cần
    IF (@IsPaged = 1)
    BEGIN
        SELECT 
            @TotalItem = COUNT(DISTINCT u.Id)
        FROM Users AS u
            -- Dùng LEFT JOIN thay vì INNER JOIN
            LEFT JOIN UserRoles AS ru ON ru.UserId = u.Id
            LEFT JOIN Roles AS r ON ru.RoleId = r.Id
        WHERE u.Deleted = 0
          AND (
                @SearchContent IS NULL
                OR u.Code LIKE N'%' + @SearchContent + '%'
                OR u.FullName LIKE N'%' + @SearchContent + '%'
                OR u.Email LIKE N'%' + @SearchContent + '%'
                OR u.Phone LIKE N'%' + @SearchContent + '%'
              )
          AND (
                @Ids IS NULL 
                OR u.Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
              )
          AND (
                @Roles IS NULL
                OR r.RoleName IN (SELECT value FROM STRING_SPLIT(@Roles, ','))
              );
    END
    ELSE
    BEGIN
        SET @TotalItem = 0; -- Không cần tính tổng khi không phân trang
    END

    ;WITH PagedList AS 
    (
        SELECT DISTINCT u.Id
        FROM Users AS u
            LEFT JOIN UserRoles AS ru ON ru.UserId = u.Id
            LEFT JOIN Roles AS r ON ru.RoleId = r.Id
        WHERE u.Deleted = 0
          AND (
                @SearchContent IS NULL
                OR u.Code LIKE N'%' + @SearchContent + '%'
                OR u.FullName LIKE N'%' + @SearchContent + '%'
                OR u.Email LIKE N'%' + @SearchContent + '%'
                OR u.Phone LIKE N'%' + @SearchContent + '%'
              )
          AND (
                @Ids IS NULL 
                OR u.Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
              )
          AND (
                @Roles IS NULL
                OR r.RoleName IN (SELECT value FROM STRING_SPLIT(@Roles, ','))
              )
    )
    SELECT 
        u.*,
        @TotalItem AS TotalItem
    FROM PagedList AS pl
        LEFT JOIN Users AS u ON u.Id = pl.Id
        LEFT JOIN UserRoles AS ru ON ru.UserId = u.Id
        LEFT JOIN Roles AS r ON ru.RoleId = r.Id
    -- Nếu muốn dữ liệu không bị nhân bản dòng (do LEFT JOIN Roles),
    -- có thể GROUP BY hoặc chỉ SELECT các trường cần thiết ở đây
    ORDER BY 
        CASE 
            WHEN @OrderBy = 'u.Code ASC' THEN u.Code
            WHEN @OrderBy = 'u.FullName ASC' THEN u.FullName
            WHEN @OrderBy = 'u.Created ASC' THEN CONVERT(NVARCHAR(MAX), u.Created)
            ELSE NULL
        END ASC,
        CASE
            WHEN @OrderBy = 'u.Code DESC' THEN u.Code
            WHEN @OrderBy = 'u.FullName DESC' THEN u.FullName
            WHEN @OrderBy = 'u.Created DESC' THEN CONVERT(NVARCHAR(MAX), u.Created)
            ELSE NULL
        END DESC
    OFFSET (@PageIndex - 1) * @PageSize ROWS 
    FETCH NEXT @PageSize ROWS ONLY;
END
GO
