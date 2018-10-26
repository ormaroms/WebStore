CREATE TABLE [dbo].[PickUpPoints] (
    [ID]                INT        NOT NULL,
    [Name]              NCHAR (10) NOT NULL,
    [LcationLongitude ] FLOAT (53) NOT NULL,
    [LcationLatitude ]  FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

