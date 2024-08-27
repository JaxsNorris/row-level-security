/*Create tables*/
CREATE TABLE [dbo].[Tenant](
	[TenantId] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Path] [varchar](200) NOT NULL,
 CONSTRAINT [PK_DboTenant_TenantId] PRIMARY KEY (TenantId));

CREATE TABLE [dbo].[User](
	[UserId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
CONSTRAINT [PK_DboUser_UserId] PRIMARY KEY (UserId));
ALTER TABLE  [dbo].[User] ADD CONSTRAINT [FK_DboUser_TenantId] FOREIGN KEY (TenantId) REFERENCES [dbo].[Tenant](TenantId);

CREATE TABLE [dbo].[Application](
	[ApplicationId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[Description] [varchar](200) NOT NULL
 CONSTRAINT [PK_DboApplication_ApplicationId] PRIMARY KEY (ApplicationId)); 
 ALTER TABLE  [dbo].[Application] ADD CONSTRAINT [FK_DboApplication_TenantId] FOREIGN KEY (TenantId) REFERENCES [dbo].[Tenant](TenantId)

 CREATE TABLE [dbo].[ApplicationFile](
	[ApplicationFileId] [int] NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[Filename] [varchar](200) NOT NULL
 CONSTRAINT [PK_DboApplicationFile_ApplicationFileId] PRIMARY KEY (ApplicationFileId)); 

 ALTER TABLE  [dbo].[ApplicationFile] ADD CONSTRAINT [FK_DboApplicationFile_ApplicationId] FOREIGN KEY (ApplicationId) REFERENCES [dbo].[Application](ApplicationId);

-- Simple view to return application id and tenant path
CREATE VIEW dbo.TenantApplicationView 
WITH SCHEMABINDING AS
SELECT a.ApplicationId, t.Path AS TenantPath
FROM dbo.Application a
INNER JOIN dbo.Tenant t ON t.TenantId = a.TenantId

