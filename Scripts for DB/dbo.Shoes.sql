CREATE TABLE [dbo].[Shoes] (
    [ItemID]   INT        NOT NULL,
    [Price]    FLOAT (53) NOT NULL,
    [Color]    NCHAR (10) NOT NULL,
    [Size]     INT        NOT NULL,
    [Quantity] INT        NOT NULL,
    [Brand]    NCHAR (10) NOT NULL,
    [Gender]   NCHAR (10) NOT NULL,
    [ImgPath]  NCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([ItemID] ASC, [Size] ASC)
);

