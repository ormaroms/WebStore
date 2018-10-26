CREATE TABLE [dbo].[Orders] (
    [OrderID]       INT      NOT NULL,
    [UserID]        INT      NOT NULL,
    [OrderDate]     DATETIME NOT NULL,
    [ItemID]        INT      NOT NULL,
    [PickUpPointID] INT      NOT NULL,
    [Size]          INT      NOT NULL,
    [Quantity]      INT      NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC, [ItemID] ASC, [Size] ASC),
    FOREIGN KEY ([ItemID], [Size]) REFERENCES [dbo].[Shoes] ([ItemID], [Size]),
    FOREIGN KEY ([PickUpPointID]) REFERENCES [dbo].[PickUpPoints] ([ID]),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]),
    FOREIGN KEY ([ItemID], [Size]) REFERENCES [dbo].[Shirts] ([ItemID], [Size]),
    FOREIGN KEY ([ItemID], [Size]) REFERENCES [dbo].[Pants] ([ItemID], [Size])
);

