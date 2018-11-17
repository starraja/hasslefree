USE [hasslefreedev]
GO

/****** Object: Table [dbo].[MappingInfo] Script Date: 11/16/2018 10:34:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[MappingInfo];


GO
CREATE TABLE [dbo].[MappingInfo] (
    [MappingId]        INT           IDENTITY (1, 1) NOT NULL,
    [ParentType]       NVARCHAR (50) NOT NULL,
    [ParentTypeId]     INT           NOT NULL,
    [ChildType]        NVARCHAR (50) NOT NULL,
    [ChildTypeId]      INT           NOT NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedDateTime]  SMALLDATETIME NOT NULL,
    [ModifiedBy]       INT           NOT NULL,
    [ModifiedDateTime] SMALLDATETIME NOT NULL
);


