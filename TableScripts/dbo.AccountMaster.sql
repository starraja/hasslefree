USE [hasslefreedev]
GO

/****** Object: Table [dbo].[AccountMaster] Script Date: 11/16/2018 10:21:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountMaster] (
    [AccountId]             INT            NOT NULL,
    [Type]                  NVARCHAR (50)  NULL,
    [AccountName]           NVARCHAR (MAX) NOT NULL,
    [TurnOver]              MONEY          NOT NULL,
    [WebSite]               VARCHAR (50)   NOT NULL,
    [IndustryTypeSubTypeId] SMALLINT       NULL,
    [IsCustomer]            BIT            NULL,
    [IsActive]              BIT            NULL,
    [ReferenceId]           INT            NULL,
    [CreatedBy]             INT            NOT NULL,
    [CreatedDateTime]       SMALLDATETIME  NOT NULL,
    [ModifiedBy]            INT            NOT NULL,
    [ModifiedDateTime]      SMALLDATETIME  NOT NULL,
    [Source]                VARCHAR (50)   NULL
);


