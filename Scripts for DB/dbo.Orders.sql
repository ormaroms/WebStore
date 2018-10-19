CREATE TABLE [dbo].[Orders] (
    [OrderID]       INT      NOT NULL,
    [UserID]        INT      NOT NULL,
    [OrderDate]     DATETIME NOT NULL,
    [ItemID]        INT      NOT NULL,
    [PickUpPointID] INT      NOT NULL,
    [Size]          INT      NOT NULL,
    [Quantity]      INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Shoes] ([ItemID]),
    FOREIGN KEY ([PickUpPointID]) REFERENCES [dbo].[PickUpPoints] ([ID]),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]),
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Shirts] ([ItemID]),
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Trousers] ([ItemID])
);

