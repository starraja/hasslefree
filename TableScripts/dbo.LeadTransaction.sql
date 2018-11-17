USE [hasslefreedev]
GO

/****** Object: Table [dbo].[LeadTransaction] Script Date: 11/16/2018 10:34:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[LeadTransaction];


GO
CREATE TABLE [dbo].[LeadTransaction] (
    [LeadId]               INT            IDENTITY (1, 1) NOT NULL,
    [Description]          VARCHAR (500)  NULL,
    [LeadDate]             SMALLDATETIME  NOT NULL,
    [ClosingDate]          SMALLDATETIME  NULL,
    [CompanyTypeId]        SMALLINT       NULL,
    [ACCategory]           SMALLINT       NULL,
    [LeadSource]           SMALLINT       NULL,
    [SalesStage]           SMALLINT       NULL,
    [LeadOwnerExecutiveId] INT            NOT NULL,
    [BuyerRef]             VARCHAR (50)   NOT NULL,
    [AccountId]            INT            NOT NULL,
    [ContactId]            INT            NOT NULL,
    [IndustrySubIndId]     SMALLINT       NULL,
    [LeadTypeSubTypeId]    SMALLINT       NULL,
    [Region]               SMALLINT       NULL,
    [ExecutiveId]          INT            NOT NULL,
    [DetailDescription]    NVARCHAR (MAX) NULL,
    [CreatedBy]            INT            NOT NULL,
    [CreatedDateTime]      SMALLDATETIME  NOT NULL,
    [ModifiedBy]           INT            NOT NULL,
    [ModifiedDateTime]     SMALLDATETIME  NOT NULL,
    [Status]               BIT            NULL
);


