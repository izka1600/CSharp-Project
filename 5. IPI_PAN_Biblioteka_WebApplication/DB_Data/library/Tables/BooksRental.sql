CREATE TABLE [library].[BooksRental] (
    [RentalId]   INT      NOT NULL IDENTITY(1,1),
    [ReaderId]   INT      NULL,
    [BookId]     INT      NULL,
	[Comment] nvarchar(100) NULL,
    [RentalDate] DATETIME DEFAULT (getdate()) NULL,
    [ReturnDate] DATETIME NULL,
    [EditDate]   DATETIME NULL,
    [DeleteDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
    CONSTRAINT [FKBook] FOREIGN KEY ([BookId]) REFERENCES [library].[Books] ([BookId]),
    CONSTRAINT [FKReader] FOREIGN KEY ([ReaderId]) REFERENCES [library].[Readers] ([ReaderId])
);