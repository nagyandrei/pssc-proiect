CREATE TABLE [dbo].[ParcAuto]
(
	[Id] INT NOT NULL IDENTITY ,
	[IdEveniment] NVARCHAR(MAX) NULL, 
    [TipEveniment] VARCHAR(MAX) NULL, 
    [DetaliiEveniment] VARCHAR(MAX) NULL, 
    [IdRadacina] VARCHAR(MAX) NULL,
	PRIMARY KEY ([Id])
);