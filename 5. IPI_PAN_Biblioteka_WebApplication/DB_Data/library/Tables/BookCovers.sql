CREATE TABLE [library].[BookCovers] (
    [CoverId]      INT            NOT NULL IDENTITY(1,1),
    [Name]          NVARCHAR (100) NOT NULL,
    [CreationDate] DATETIME       DEFAULT (getdate()) NULL,
    [EditDate]     DATETIME       NULL,
    [DeleteDate]   DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([CoverId] ASC)
);

