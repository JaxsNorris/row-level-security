EXECUTE('CREATE SECURITY POLICY security.TenantAccessFilter
	ADD FILTER PREDICATE security.CheckAccessForApplicationId(ApplicationId)
        ON dbo.Application,
    ADD BLOCK PREDICATE security.CheckAccessForApplicationId(ApplicationId)
        ON dbo.Application AFTER INSERT
	WITH (STATE = ON)');