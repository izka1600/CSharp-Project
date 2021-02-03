CREATE FUNCTION [utils].[uf_LoadDataFromCsv] (@path nvarchar(100), @separator nvarchar(1))
RETURNS nvarchar(max) WITH EXECUTE AS CALLER, RETURNS NULL ON NULL INPUT
AS
EXTERNAL NAME [DatabaseFunctions].[UserDefinedFunctions].[uf_LoadDataFromCsv]
Go  

--SqlString = nvarchar

--https://www.sqlshack.com/impact-clr-strict-security-configuration-setting-sql-server-2017/

-- 1. Sign Assembly in Visual Studio with strong name
-- 2. Add Permissions to bin/debug folder for SQLServerUser (NT Service\MSSQL$SQLEXPRESS)
-- 3. Create Asymmetric Key from Assembly File
		--USE master;
		--GO
		--CREATE ASYMMETRIC KEY CLRStringSplitKey FROM EXECUTABLE FILE = 'C:\CLRStringSplit.dll';
		--GO

--4. Step 2: Create SQL Server Login linked to the Asymmetric Key
		--USE master;
		--GO
		--CREATE LOGIN CLRStringSplitKeyLogin FROM ASYMMETRIC KEY CLRStringSplitKey;
		--GO

--5. Step 3: Grant UNSAFE assembly permission to the login created in Step 2
		--USE master;
		--GO
		--GRANT UNSAFE ASSEMBLY TO CLRStringSplitKeyLogin;
		--GO

--6. Step 4: Create a SQL Server database user for the SQL Server login created in Step 2
		--USE DbExercises;
		--GO
		--CREATE USER CLRStringSplitKeyLogin FOR LOGIN CLRStringSplitKeyLogin;
		--GO

--7. Step 5: Create CLR Assembly
		--USE DbExercises;
		--GO
		--CREATE ASSEMBLY DatabaseFunctions FROM 'C:\CLRStringSplit.dll' WITH PERMISSION_SET = SAFE;
		--GO

--8. Run Function
		--Select [utils].[uf_LoadDataFromCsv] ('C:\Users\Admin\OneDrive\Dokumenty\csv.csv',',')
		--important! NT Service\MSSQL$SQLEXPRESS has to have permission to folder Documents