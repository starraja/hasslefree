USE [hasslefreedev]
GO

/****** Object: Table [dbo].[UserRole] Script Date: 11/16/2018 9:17:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRole] (
    [UserRoleId]       INT           IDENTITY (1, 1) NOT NULL,
    [UserId]           INT           NOT NULL,
    [RoleId]           INT           NOT NULL,
    [Active]           BIT           NOT NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedDateTime]  SMALLDATETIME NOT NULL,
    [ModifiedBy]       INT           NOT NULL,
    [ModifiedDateTime] SMALLDATETIME NOT NULL
);


