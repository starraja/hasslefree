USE [hasslefreedev]
GO

/****** Object: Table [dbo].[ContactsList] Script Date: 11/16/2018 10:33:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[ContactsList];


GO
CREATE TABLE [dbo].[ContactsList] (
    [ContactId]        INT           IDENTITY (1, 1) NOT NULL,
    [ContactName]      VARCHAR (MAX) NULL,
    [GenderId]         INT           NOT NULL,
    [Designation]      VARCHAR (MAX) NULL,
    [Department]       VARCHAR (MAX) NULL,
    [Email]            VARCHAR (MAX) NULL,
    [OfficePhone]      VARCHAR (50)  NULL,
    [MobileNumber]     VARCHAR (50)  NULL,
    [ContactTypeId]    SMALLINT      NULL,
    [ContactAuthority] SMALLINT      NULL,
    [Source]           VARCHAR (50)  NULL,
    [ReferenceId]      INT           NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedDateTime]  SMALLDATETIME NOT NULL,
    [ModifiedBy]       INT           NOT NULL,
    [ModifiedDateTime] SMALLDATETIME NOT NULL
);


