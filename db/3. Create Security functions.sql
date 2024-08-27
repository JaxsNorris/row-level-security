IF NOT EXISTS(SELECT * FROM sys.schemas WHERE name = 'security')
    BEGIN
		EXECUTE('CREATE SCHEMA security');
		/*This create a function that looks at the session context for a property UserID
		It then looks up the Tenant Path of the user and then compares the tenant path 
		to see if the user should be able to view the item
		*/
		EXECUTE('CREATE FUNCTION security.CheckAccessForApplicationId(@ApplicationId int)
		RETURNS TABLE
			WITH SCHEMABINDING
			AS
			RETURN SELECT 1 AS accessResult
				   FROM dbo.[User] u
					INNER JOIN dbo.Tenant t on t.TenantId = u.TenantId
					RIGHT JOIN dbo.TenantApplicationView a on a.TenantPath LIKE t.Path+''%''
					WHERE u.UserId = CAST(SESSION_CONTEXT(N''UserId'') AS int)
					AND a.ApplicationId = @ApplicationId');
		
		/*This is a simplier function that just looks for TenantPath in session context.
	      You could then add the path as a Claim to reduce the number of DB calls and use your claim principel to 
		*/
		EXECUTE('CREATE FUNCTION security.CheckAccessForApplicationIdViaTenantPath(@ApplicationId int)
		RETURNS TABLE
			WITH SCHEMABINDING
			AS
			RETURN SELECT 1 AS accessResult
				   FROM dbo.Application a
				   INNER JOIN dbo.Tenant t ON a.TenantId = t.TenantId
				   WHERE @ApplicationId = a.ApplicationId
					 AND (t.Path LIKE CAST(SESSION_CONTEXT(N''TenantPath'') AS VARCHAR) + ''%'')');
	END