CREATE TABLE [dbo].[Users]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    [IsAdmin] BINARY(50) NOT NULL, 
    [UserName] NCHAR(10) NOT NULL, 
    [Password] NCHAR(10) NOT NULL
)
