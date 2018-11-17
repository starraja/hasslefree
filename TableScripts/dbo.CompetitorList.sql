USE [hasslefreedev]
GO

/****** Object: Table [dbo].[CompetitorList] Script Date: 11/16/2018 10:33:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[CompetitorList];


GO
CREATE TABLE [dbo].[CompetitorList] (
    [CompetitorId]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (MAX) NULL,
    [Amount]           MONEY         NULL,
    [Remarks]          VARCHAR (MAX) NULL,
    [Source]           VARCHAR (50)  NULL,
    [ReferenceId]      INT           NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedDateTime]  SMALLDATETIME NOT NULL,
    [ModifiedBy]       INT           NOT NULL,
    [ModifiedDateTime] SMALLDATETIME NOT NULL
);


