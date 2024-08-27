/*RSL*/
DROP SECURITY POLICY security.TenantAccessFilter 
DROP FUNCTION security.CheckAccessForApplicationId 
DROP FUNCTION security.CheckAccessForApplicationIdViaTenantPath 
DROP SCHEMA security

DROP VIEW dbo.TenantApplicationView
/*DROP TABLE */ DELETE FROM [dbo].[ApplicationFile]
/*DROP TABLE */ DELETE FROM [dbo].[Application]
/*DROP TABLE */ DELETE FROM [dbo].[User]
/*DROP TABLE */ DELETE FROM [dbo].[Tenant]





