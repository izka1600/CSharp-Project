CREATE TABLE [library].[DataCarriers] (
    [DataCarrierID] INT           NOT NULL IDENTITY(1,1),
    [Name]            NVARCHAR (15) NOT NULL,
    [CreationDate]   DATETIME      DEFAULT (getdate()) NULL,
    [EditDate]       DATETIME      NULL,
    [DeleteDate]     DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([DataCarrierID] ASC),
	constraint CHK_NAME check ( Name in ('CD', 'DVD', 'Ksiazka'))
);

