CREATE TABLE [dbo].[Orders]
(
	[OrderID] INT NOT NULL PRIMARY KEY, 
    [UserID] INT NOT NULL, 
    [OrderDate] DATE NOT NULL, 
    [ItemID] INT NOT NULL, 
    [PickUpPointID] INT NOT NULL
)
