﻿CREATE TABLE [dbo].[Users] (
    [UserID]   INT        NOT NULL,
    [UserName] NCHAR (10) NOT NULL,
    [Passwod]  NCHAR (10) NOT NULL,
    [isAdmin]  BIT        NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

