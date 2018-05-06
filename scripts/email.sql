USE [csharp4]
GO

/****** Object:  Table [dbo].[email]    Script Date: 5/5/2018 8:42:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[email](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sender] [varchar](50) NULL,
	[Recipient] [varchar](50) NULL,
	[Subject] [varchar](150) NULL,
	[Body] [varchar](max) NULL,
	[Date] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_email] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


