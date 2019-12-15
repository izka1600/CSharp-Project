CREATE TABLE [library].[Authors] (
    [AuthorId]     INT           NOT NULL IDENTITY(1,1),
    [FirstName]    NVARCHAR (30) NOT NULL,
    [LastName]     NVARCHAR (30) NOT NULL,
    [CreationDate] DATETIME      DEFAULT (getdate()) NULL,
    [EditDate]     DATETIME      NULL,
    [DeleteDate]   DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([AuthorId] ASC)
);
