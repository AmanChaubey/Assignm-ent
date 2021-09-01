 
/****** Object:  User [eportal]    Script Date: 09/01/2021 4.45.29 PM ******/
CREATE USER [eportal] FOR LOGIN [eportal] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[TblDiscount]    Script Date: 09/01/2021 4.45.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDiscount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mode] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblDiscount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblEventPrice]    Script Date: 09/01/2021 4.45.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEventPrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TblEventPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblSalesEvent]    Script Date: 09/01/2021 4.45.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblSalesEvent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiscountId] [int] NOT NULL,
	[DiscountAmount] [decimal](18, 2) NOT NULL,
	[EventPrice] [decimal](18, 2) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblSalesEvent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblDiscount] ON 
GO
INSERT [dbo].[TblDiscount] ([Id], [Mode], [IsActive]) VALUES (1, N'Dollar', 1)
GO
INSERT [dbo].[TblDiscount] ([Id], [Mode], [IsActive]) VALUES (2, N'Percentage', 1)
GO
SET IDENTITY_INSERT [dbo].[TblDiscount] OFF
GO
/****** Object:  StoredProcedure [dbo].[PR_GetDiscountList]    Script Date: 09/01/2021 4.45.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_GetDiscountList]
AS
	select Id, Mode from TblDiscount WHERE IsActive = 1
GO
/****** Object:  StoredProcedure [dbo].[PR_SaveSalesEvent]    Script Date: 09/01/2021 4.45.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_SaveSalesEvent]
@DiscountId INT,
@DiscountAmount DECIMAL(18, 2),
@EventPrice DECIMAL(18, 2),
@StartDate DATETIME,
@EndDate DATETIME,
@IsActive BIT,
@ReturnValue INT = NULL OUT
AS
	SET @ReturnValue = 0;
	INSERT INTO TblSalesEvent
	SELECT @DiscountId,@DiscountAmount, @EventPrice, @StartDate, @EndDate, @IsActive

	SET @ReturnValue = IDENT_CURRENT('TblSalesEvent')
GO
 