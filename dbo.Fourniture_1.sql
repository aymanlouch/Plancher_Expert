CREATE TABLE [dbo].[Fourniture] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FloorType]    VARCHAR (50)    NOT NULL,
    [MaterialRate] FLOAT (53)      NOT NULL,
    [LaborRate]    FLOAT (53)      NOT NULL,
    [Image]        VARBINARY(MAX) NULL,
    [nomID] VARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

