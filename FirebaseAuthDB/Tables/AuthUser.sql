CREATE TABLE [dbo].[AuthUser]
(
	[Id] VARCHAR(256) NOT NULL PRIMARY KEY, 
    [DisplayName] VARCHAR(256) NULL, 
    [Email] VARCHAR(64) NULL, 
    [EmailVerified] BIT NULL, 
    [PhotoURL] VARCHAR(256) NULL, 
    [IsAnonymous] BIT NULL
)
