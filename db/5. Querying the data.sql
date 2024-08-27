/*
EXEC sys.sp_set_session_context @key = N'UserId', @value = '1'; -- Iron man with \Marvel expect to see 4 application (1-4)
EXEC sys.sp_set_session_context @key = N'UserId', @value = '13'; -- The Thing with \Marvel\FantasticFour should see 1 (4)
EXEC sys.sp_set_session_context @key = N'UserId', @value = '52'; -- Wonder woman with \DC should see 2 (5-6)
*/

SELECT *  FROM [dbo].[User]
SELECT *  FROM [dbo].[Tenant]
SELECT *  FROM [dbo].[Application]
SELECT *  FROM [dbo].[ApplicationFile]


SELECT u.UserId,u.name, t.path   FROM [dbo].[User] u
INNER JOIN [dbo].[Tenant] t on t.TenantId = u.TenantId
WHERE u.UserId in (1,13,52)

SELECT a.ApplicationId,a.Description,t.Path  FROM [dbo].[Application] a 
INNER JOIN [dbo].[Tenant] t on t.TenantId = a.TenantId
/*
-- Acting as Hulk trying to add a new avengers application
EXEC sys.sp_set_session_context @key = N'UserId', @value = '5';
INSERT INTO [dbo].[Application]
           ([ApplicationId]
           ,[TenantId]
           ,[Description])
     VALUES
           (7,
		   5, -- DC tenant Id
		   'DC 3');
*/
/*
-- Acting as Flash trying delete the fanastic four application
EXEC sys.sp_set_session_context @key = N'UserId', @value = '53'; 
DELETE FROM [dbo].[Application]
WHERE ApplicationId = 4

EXEC sys.sp_set_session_context @key = N'UserId', @value = '10'; 
SELECT *FROM [dbo].[Application]
WHERE ApplicationId = 4
*/