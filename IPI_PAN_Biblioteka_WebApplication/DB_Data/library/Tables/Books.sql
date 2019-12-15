CREATE TABLE [library].[Books] (
    [BookId]          INT            NOT NULL IDENTITY(1,1),
    [CoverId]         INT            NULL,
    [AuthorsId]       INT            NULL,
    [DataCarrierID]  INT            NULL,
    [Name]             NVARCHAR (100) NOT NULL,
    [PublicationDate] DATE           NOT NULL,
    [CreationDate]    DATETIME       DEFAULT (getdate()) NULL,
    [EditDate]        DATETIME       NULL,
    [DeleteDate]      DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([BookId] ASC),
    CONSTRAINT [FKAuthor] FOREIGN KEY ([AuthorsId]) REFERENCES [library].[Authors] ([AuthorId]),
    CONSTRAINT [FKCarrier] FOREIGN KEY ([DataCarrierID]) REFERENCES [library].[DataCarriers] ([DataCarrierID]),
    CONSTRAINT [FKCover] FOREIGN KEY ([CoverId]) REFERENCES [library].[BookCovers] ([CoverId])
);

