USE [CMS]
GO

/****** Object:  Table [dbo].[ActivityAttendees]    Script Date: 10/6/2018 11:05:36 PM ******/
DROP TABLE [dbo].[ActivityAttendees]
GO

/****** Object:  Table [dbo].[ActivityAttendees]    Script Date: 10/6/2018 11:05:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ActivityAttendees](
	[ActivityAttendeesId] [int] IDENTITY(1,1) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[ContactID] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] INT NOT NULL,
    [CreatedDateTime] SMALLDATETIME NOT NULL,
    [ModifiedBy] INT NOT NULL,
    [ModifiedDateTime] SMALLDATETIME NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

