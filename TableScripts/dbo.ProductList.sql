USE [hasslefreedev]
GO

/****** Object: Table [dbo].[ProductList] Script Date: 11/16/2018 10:34:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[ProductList];


GO
CREATE TABLE [dbo].[ProductList] (
    [ProductListId]    INT           NOT NULL,
    [ProductId]        INT           NOT NULL,
    [Quantity]         SMALLINT      NOT NULL,
    [UOM]              SMALLINT      NULL,
    [Rate]             MONEY         NULL,
    [Discount]         FLOAT (53)    NULL,
    [TaxAmount]        MONEY         NULL,
    [Amount]           MONEY         NULL,
    [Source]           INT   NULL,
    [ReferenceId]      INT           NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedDateTime]  SMALLDATETIME NOT NULL,
    [ModifiedBy]       INT           NOT NULL,
    [ModifiedDateTime] SMALLDATETIME NOT NULL
);


