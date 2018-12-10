TRUNCATE TABLE dbo.Member
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (1, N'Stefanie', N'Buckley', N'36 West Fabien St.', N'Lincoln', N'KY', N'59898', N'4517', 0)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (2, N'Sandy', N'Mc Gee', N'935 Nobel Way', N'Arlington', N'IA', N'47471', N'8855', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (3, N'Lee', N'Warren', N'91 Hague Parkway', N'Newark', N'IN', N'51737', N'6986', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (4, N'Regina', N'Forbes', N'50 Cowley Avenue', N'Sacramento', N'NY', N'66301', N'1575', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (5, N'Daniel', N'Kim', N'525 North Old Parkway', N'Los Angeles', N'MS', N'30429', N'4368', 0)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (6, N'Dennis', N'Nunez', N'48 Old Freeway', N'San Diego', N'WA', N'07170', N'7121', 0)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (7, N'Myra', N'Zuniga', N'545 New Way', N'Anchorage', N'DE', N'43313', N'1488', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (8, N'Teddy', N'Ingram', N'80 White New St.', N'Honolulu', N'WV', N'90035', N'9590', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (9, N'Annie', N'Larson', N'16 Nobel St.', N'Fresno', N'NJ', N'01497', N'8609', 0)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (10, N'Herman', N'Anderson', N'361 Milton Way', N'Raleigh', N'CO', N'55855', N'8710', 1)

SET IDENTITY_INSERT [dbo].[Member] OFF

------------------------------------------------------------------------------------
USE [TechNetData]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 12/9/2018 10:53:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nchar](2) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[PIN] [nvarchar](4) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Member] ON 

GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (1, N'Stefanie', N'Buckley', N'36 West Fabien St.', N'Lincoln', N'KY', N'59898', N'4517', 0)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (2, N'Sandy', N'Mc Gee', N'935 Nobel Way', N'Arlington', N'IA', N'47471', N'8855', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (3, N'Lee', N'Warren', N'91 Hague Parkway', N'Newark', N'IN', N'51737', N'6986', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (4, N'Regina', N'Forbes', N'50 Cowley Avenue', N'Sacramento', N'NY', N'66301', N'1575', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (5, N'Daniel', N'Kim', N'525 North Old Parkway', N'Los Angeles', N'MS', N'30429', N'4368', 0)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (6, N'Dennis', N'Nunez', N'48 Old Freeway', N'San Diego', N'WA', N'07170', N'7121', 0)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (7, N'Myra', N'Zuniga', N'545 New Way', N'Anchorage', N'DE', N'43313', N'1488', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (8, N'Teddy', N'Ingram', N'80 White New St.', N'Honolulu', N'WV', N'90035', N'9590', 1)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (9, N'Annie', N'Larson', N'16 Nobel St.', N'Fresno', N'NJ', N'01497', N'8609', 0)
GO
INSERT [dbo].[Member] ([Id], [FirstName], [LastName], [Street], [City], [State], [PostalCode], [PIN], [Status]) VALUES (10, N'Herman', N'Anderson', N'361 Milton Way', N'Raleigh', N'CO', N'55855', N'8710', 1)
GO
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'First' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Street' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'Street'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'City' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Postal' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PIN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'PIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Active' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'Status'
GO

--------------------------------------------------------------------------------------------------
USE [TechNetData]
GO
/****** Object:  Table [dbo].[UsStates]    Script Date: 12/9/2018 10:55:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsStates](
	[State] [nchar](2) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'CO')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'DE')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'IA')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'IN')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'KY')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'MS')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'NJ')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'NY')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'WA')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'WV')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'AL')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'AK')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'AR')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'CA')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'CT')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'OR')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'DC')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'FL')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'GA')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'HI')
GO
INSERT [dbo].[UsStates] ([State]) VALUES (N'NE')
GO










