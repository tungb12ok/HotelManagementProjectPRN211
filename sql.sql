USE [HotelManagement]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/25/2024 5:20:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[AccountNumber] [varchar](10) NOT NULL,
	[FirstName] [varchar](25) NULL,
	[LastName] [varchar](25) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[EmergencyName] [varchar](50) NULL,
	[EmergencyPhone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2/25/2024 5:20:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeNumber] [varchar](20) NOT NULL,
	[FirstName] [varchar](25) NULL,
	[LastName] [varchar](25) NULL,
	[Title] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Occupancies]    Script Date: 2/25/2024 5:20:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occupancies](
	[OccupancyNumber] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber] [varchar](20) NULL,
	[DateOccupied] [date] NULL,
	[AccountNumber] [varchar](10) NULL,
	[RoomNumber] [varchar](10) NULL,
	[RateApplied] [float] NULL,
	[PhoneCharge] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[OccupancyNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 2/25/2024 5:20:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[ReceiptNumber] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber] [varchar](20) NULL,
	[PaymentDate] [datetime] NULL,
	[AccountNumber] [varchar](10) NULL,
	[AmountCharged] [float] NULL,
	[TaxRate] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReceiptNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 2/25/2024 5:20:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomNumber] [varchar](10) NOT NULL,
	[RoomType] [varchar](10) NULL,
	[BedType] [varchar](10) NULL,
	[Rate] [float] NULL,
	[RoomStatus] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customers] ([AccountNumber], [FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyPhone]) VALUES (N'1', N'Lưu', N'Tùng', N'+84972074620', N'eqwe', N'3123123123')
GO
INSERT [dbo].[Employees] ([EmployeeNumber], [FirstName], [LastName], [Title]) VALUES (N'1', N'Lưu', N'Tùng', N'Sale')
GO
SET IDENTITY_INSERT [dbo].[Occupancies] ON 

INSERT [dbo].[Occupancies] ([OccupancyNumber], [EmployeeNumber], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge]) VALUES (4, N'1', CAST(N'2024-02-24' AS Date), N'1', N'1', 5, 21313123)
SET IDENTITY_INSERT [dbo].[Occupancies] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([ReceiptNumber], [EmployeeNumber], [PaymentDate], [AccountNumber], [AmountCharged], [TaxRate]) VALUES (1, N'1', NULL, N'1', 123, 0.01)
INSERT [dbo].[Payments] ([ReceiptNumber], [EmployeeNumber], [PaymentDate], [AccountNumber], [AmountCharged], [TaxRate]) VALUES (2, N'1', CAST(N'2024-02-25T17:11:43.907' AS DateTime), N'1', 123, 0.01)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
INSERT [dbo].[Rooms] ([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus]) VALUES (N'1', N'Bedroom', N'Queen', 5, N'Occupied')
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT ((0.01)) FOR [TaxRate]
GO
ALTER TABLE [dbo].[Occupancies]  WITH CHECK ADD FOREIGN KEY([AccountNumber])
REFERENCES [dbo].[Customers] ([AccountNumber])
GO
ALTER TABLE [dbo].[Occupancies]  WITH CHECK ADD FOREIGN KEY([EmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
ALTER TABLE [dbo].[Occupancies]  WITH CHECK ADD FOREIGN KEY([RoomNumber])
REFERENCES [dbo].[Rooms] ([RoomNumber])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([AccountNumber])
REFERENCES [dbo].[Customers] ([AccountNumber])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([EmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
