/*insert tenants*/
INSERT INTO [dbo].[Tenant]
           ([TenantId], [Name],[Path])
     VALUES
           (1, 'ComicHeros','\'),
		   (2,'Marvel','\Marvel'),
		   (3,'Avengers','\Marvel\Avengers'),
		   (4,'FantasticFour','\Marvel\FantasticFour'),
		   (5,'DC','\DC');

/*Insert users*/
INSERT INTO [dbo].[User]
           ([UserId],[TenantId],[Name])
     VALUES
           (1,2,'Iron Man'),
		   (2,2,'Captain America'),
		   (3,2,'Thor'),
		   (4,2,'Spider-Man'),
		   (5,2, 'Hulk'),
           (10,4,  'Mr. Fantastic'),
		   (11,4, 'Invisible Woman'),
		   (12,4, 'Human Torch'),
		   (13,4, 'The Thing'),
           (50,5, 'Superman'),
		   (51,5,'Batman'),
		   (52,5,'Wonder Woman'),
		   (53,5,'The Flash');
GO

/*Application data*/
INSERT INTO [dbo].[Application]
           ([ApplicationId]
           ,[TenantId]
           ,[Description])
     VALUES
           (1 ,2, 'Marvel app 1'),
		   (2 ,2, 'Marvel app 2'),
		   (3 ,3, 'Averager app 1'),
		   (4 ,4, 'Fantastic Four app 1'),
		   (5 ,5, 'DC app 1'),
		   (6 ,5, 'DC app 2');
GO


INSERT INTO [dbo].[ApplicationFile]
           ([ApplicationFileId]
           ,[ApplicationId]
           ,[Filename])
     VALUES
           (1, 1, 'file1'),
		   (2, 5, 'file2'),
		   (3, 5, 'file3'),
		   (4, 6, 'file4'),
		   (5, 6, 'file5'),
		   (6, 6, 'file6');
GO









