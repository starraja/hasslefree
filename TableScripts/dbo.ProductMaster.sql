USE [hasslefreedev]
GO

/****** Object: Table [dbo].[ProductMaster] Script Date: 11/16/2018 10:35:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[ProductMaster];


GO
CREATE TABLE [dbo].[ProductMaster] (
    [ProductId]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (MAX) NULL,
    [Rate]             MONEY         NULL,
    [UOM]              SMALLINT      NULL,
    [IsActive]         BIT           NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedDateTime]  SMALLDATETIME NOT NULL,
    [ModifiedBy]       INT           NOT NULL,
    [ModifiedDateTime] SMALLDATETIME NOT NULL
);


