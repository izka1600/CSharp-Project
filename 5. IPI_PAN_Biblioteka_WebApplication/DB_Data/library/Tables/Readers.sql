CREATE TABLE [library].[Readers] (
    [ReaderId]     INT           NOT NULL IDENTITY(1,1),
    [FirstName]    NVARCHAR (30) NOT NULL,
    [LastName]     NVARCHAR (30) NOT NULL,
    [Email]         NVARCHAR (30) NOT NULL,
    [AccessRights] CHAR (1)      NULL,
    [CreationDate] DATETIME      DEFAULT (getdate()) NULL,
    [EditDate]     DATETIME      NULL,
    [DeleteDate]   DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([ReaderId] ASC),
    CONSTRAINT [AccessRights] CHECK ([AccessRights]='w' OR [AccessRights]='r')
);