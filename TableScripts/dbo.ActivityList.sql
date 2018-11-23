USE [hasslefreedev]
GO

/****** Object: Table [dbo].[ActivityList] Script Date: 11/16/2018 10:33:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[ActivityList];


GO
CREATE TABLE [dbo].[ActivityList] (
    [ActivityId]        INT           IDENTITY (1, 1) NOT NULL,
    [ActivityTitle] [nvarchar](max)  NULL,
    [ActivityLocation] [nvarchar](max)  NULL,
    [ActivityOwner] [int] NULL,
    [TypeSubtypeId]     SMALLINT      NOT NULL,
    [ActivityStartTime] SMALLDATETIME NOT NULL,
    [ActivityEndTime]   SMALLDATETIME NOT NULL,
    [StatusId]          SMALLINT      NOT NULL,
    [KM]                NVARCHAR (50) NULL,
    [Type]              VARCHAR (50)  NULL,
    [Source]            VARCHAR (50)  NULL,
    [ReferenceId]       INT           NULL,
    [CreatedBy]         INT           NOT NULL,
    [CreatedDateTime]   SMALLDATETIME NOT NULL,
    [ModifiedBy]        INT           NOT NULL,
    [ModifiedDateTime]  SMALLDATETIME NOT NULL
);


