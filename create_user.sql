USE master;
GO

CREATE LOGIN techstore_user
WITH PASSWORD = 'TechStore123!';
GO

ALTER SERVER ROLE dbcreator ADD MEMBER techstore_user;
GO