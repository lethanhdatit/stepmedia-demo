USE [stepmedia-demo]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([ID], [FullName], [Email], [DoB], [CreatedDate]) VALUES (1, N'Lê Thành Đạt', N'thanhdat.it.mmo@gmail.com', CAST(N'1997-09-18' AS Date), CAST(N'2023-05-07T09:29:42.4524309' AS DateTime2))
INSERT [dbo].[Customers] ([ID], [FullName], [Email], [DoB], [CreatedDate]) VALUES (2, N'Ngô Thị Hồng', N'nthong@gmail.com', CAST(N'2023-05-07' AS Date), CAST(N'2023-05-07T11:59:13.6749744' AS DateTime2))
INSERT [dbo].[Customers] ([ID], [FullName], [Email], [DoB], [CreatedDate]) VALUES (3, N'Đào Hoàng Minh Tâm', N'mtdaohoang@gmail.com', CAST(N'2023-05-07' AS Date), CAST(N'2023-05-07T11:59:35.3650839' AS DateTime2))
INSERT [dbo].[Customers] ([ID], [FullName], [Email], [DoB], [CreatedDate]) VALUES (4, N'Huỳnh Lê Xuân Mai', N'xmaihuynh@gmail.com', CAST(N'2023-05-07' AS Date), CAST(N'2023-05-07T12:00:37.8555717' AS DateTime2))
INSERT [dbo].[Customers] ([ID], [FullName], [Email], [DoB], [CreatedDate]) VALUES (5, N'Nguyễn Thị Bảo Ngọc', N'bngocnt@gmail.com', CAST(N'2023-05-07' AS Date), CAST(N'2023-05-07T12:00:57.5419656' AS DateTime2))
INSERT [dbo].[Customers] ([ID], [FullName], [Email], [DoB], [CreatedDate]) VALUES (6, N'Trần Thị Xuân Hương', N'xhtranthi@gmail.com', CAST(N'2023-05-07' AS Date), CAST(N'2023-05-07T12:01:16.9588695' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Shops] ON 

INSERT [dbo].[Shops] ([ID], [Name], [Location], [CreatedDate]) VALUES (1, N'Infinity Shop', N'242/11 Tây Thạnh, Tân Phú, HCM', CAST(N'2023-05-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Shops] ([ID], [Name], [Location], [CreatedDate]) VALUES (2, N'Mai Thúy Store', N'198/11 Tôn Đãn, Q1, HCM', CAST(N'2023-05-07T13:03:14.6066722' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Shops] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [CustomerID], [ShopID], [CreatedDate]) VALUES (1, 1, 1, CAST(N'2023-05-07T13:12:14.3934397' AS DateTime2))
INSERT [dbo].[Orders] ([ID], [CustomerID], [ShopID], [CreatedDate]) VALUES (2, 1, 1, CAST(N'2023-05-07T13:28:25.7687144' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [ShopID], [Name], [UnitPrice], [CreatedDate]) VALUES (1, 1, N'Sầu Riêng Hạt Lép', 85000, CAST(N'2023-05-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ID], [ShopID], [Name], [UnitPrice], [CreatedDate]) VALUES (2, 1, N'Thanh long hạt vàng', 15000, CAST(N'2023-05-07T12:54:49.0399655' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_Details] ON 

INSERT [dbo].[Order_Details] ([ID], [ProductID], [OrderID], [UnitPrice], [Quantity]) VALUES (1, 1, 2, 23, 2)
SET IDENTITY_INSERT [dbo].[Order_Details] OFF
GO
