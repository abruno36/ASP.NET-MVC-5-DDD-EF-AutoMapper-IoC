CREATE TABLE [dbo].[Clientes] (
    [ClienteId] [int] NOT NULL IDENTITY,
    [Nome] varchar(100),
    [Email] varchar(100),
    [DateCreated] smalldatetime NOT NULL,
    [DateUpdated] smalldatetime NOT NULL,
    [Active] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY ([ClienteId])
)