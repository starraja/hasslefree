USE [hasslefreedev]
GO

/****** Object: Table [dbo].[DocumentList] Script Date: 11/16/2018 10:34:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[DocumentList];


GO
CREATE TABLE [dbo].[DocumentList] (
    [DocumentId]       INT            IDENTITY (1, 1) NOT NULL,
    [FileName]         NVARCHAR (MAX) NOT NULL,
    [Source]           INT   NULL,
    [ReferenceId]      INT            NULL,
    [CreatedBy]        INT            NOT NULL,
    [CreatedDateTime]  SMALLDATETIME  NOT NULL,
    [ModifiedBy]       INT            NOT NULL,
    [ModifiedDateTime] SMALLDATETIME  NOT NULL,
    [Type]             NVARCHAR (50)  NULL
);


