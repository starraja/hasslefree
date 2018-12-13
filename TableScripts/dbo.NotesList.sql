USE [hasslefreedev]
GO

/****** Object: Table [dbo].[NotesList] Script Date: 11/16/2018 10:34:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[NotesList];


GO
CREATE TABLE [dbo].[NotesList] (
    [NotesId]          INT            NOT NULL,
    [NotesDescription] NVARCHAR (MAX) NOT NULL,
    [Source]           INT   NULL,
    [ReferenceId]      INT            NULL,
    [CreatedBy]        INT            NOT NULL,
    [CreatedDateTime]  SMALLDATETIME  NOT NULL,
    [ModifiedBy]       INT            NOT NULL,
    [ModifiedDateTime] SMALLDATETIME  NOT NULL
);


