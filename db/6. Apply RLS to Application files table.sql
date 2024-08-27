EXECUTE('ALTER SECURITY POLICY security.TenantAccessFilter
	ADD FILTER PREDICATE security.CheckAccessForApplicationId(ApplicationId)
        ON dbo.ApplicationFile,
    ADD BLOCK PREDICATE security.CheckAccessForApplicationId(ApplicationId)
        ON dbo.ApplicationFile AFTER INSERT');