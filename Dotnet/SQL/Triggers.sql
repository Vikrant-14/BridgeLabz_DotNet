-- TRIGGERS : 
-------------
/*
SQL Server triggers are special stored procedures that are executed automatically in response to the database object, database, and server events. 

SQL Server provides three type of triggers:
--------------------------------------------
1. Data manipulation language (DML) triggers which are invoked automatically in response to INSERT, UPDATE, and DELETE events against tables.

2. Data definition language (DDL) triggers which fire in response to CREATE, ALTER, and DROP statements. DDL triggers also fire in response to some system stored procedures that perform DDL-like operations.

3. Logon triggers which fire in response to LOGON events
*/

--------------------------------------------
-- CREATE TRIGGER STATEMENT :
---------------------------------------------
/*
-- SYNTAX : 
-----------
	CREATE TRIGGER [schema_name.]trigger_name
	ON table_name
	AFTER  {[INSERT],[UPDATE],[DELETE]}
	[NOT FOR REPLICATION]
	AS
	{sql_statements}

*/

-- SQL Server CREATE TRIGGER example :
---------------------------------------
CREATE TABLE products (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_name NVARCHAR(255),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10, 2)
);


INSERT INTO products (product_name, brand_id, category_id, model_year, list_price)
VALUES 
    ('Product A', 1, 1, 2020, 100.00),
    ('Product B', 2, 2, 2019, 150.00),
    ('Product C', 3, 3, 2018, 200.00),
    ('Product D', 4, 4, 2021, 250.00),
    ('Product E', 5, 5, 2020, 300.00),
    ('Product F', 6, 6, 2019, 350.00),
    ('Product G', 7, 7, 2018, 400.00),
    ('Product H', 8, 8, 2021, 450.00),
    ('Product I', 9, 9, 2020, 500.00),
    ('Product J', 10, 0, 2019, 550.00);

SELECT * FROM products;

-- 1) Create a table for logging the changes.
----------------------------------------------
CREATE TABLE product_audits(
	change_id INT IDENTITY PRIMARY KEY,
	product_id INT NOT NULL,
	product_name VARCHAR(max) NOT NULL,
	brand_id INT NOT NULL,
	category_id INT NOT NULL,
	model_year SMALLINT NOT NULL,
	list_price DEC(10,2) NOT NULL,
	updated_at DATETIME NOT NULL,
	operation CHAR(3) NOT NULL,
	CHECK(operation = 'INS' or operation = 'DEL')
);

SELECT * FROM product_audits;

-- 2) Creating a AFTER DML Trigger.
-----------------------------------
CREATE TRIGGER trg_product_audit
ON products
AFTER INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO 
		product_audits(
			product_id,
			product_name,
			brand_id,
			category_id,
			model_year,
			list_price,
			updated_at,
			operation
		)
	SELECT
		i.product_id,
		product_name,
		brand_id,
		category_id,
		model_year,
		i.list_price,
		GETDATE(),
		'INS'
	FROM 
		inserted i
	UNION ALL
    SELECT
        d.product_id,
        product_name,
        brand_id,
        category_id,
        model_year,
        d.list_price,
        getdate(),
        'DEL'
    FROM
        deleted AS d;
END	

-- 3) Testing the Trigger.
--------------------------
-- i. INSERT :
-------------
INSERT INTO products (product_name, brand_id, category_id, model_year, list_price)
VALUES 
    ('Product Test', 11, 11, 2023, 500.00);

SELECT 
	*
FROM
	product_audits;

-- ii. DELETE :
-----------------
DELETE FROM
	products
WHERE
	product_id = 11;


SELECT 
	*
FROM
	product_audits;


---------------------------
-- INSTEAD OF Trigger : 
---------------------------
/*
An INSTEAD OF trigger is a trigger that allows you to skip an INSERT, DELETE, or UPDATE statement to a table or a view and execute other statements defined in the trigger instead. The actual insert, delete, or update operation does not occur at all.

In other words, an INSTEAD OF trigger skips a DML statement and execute other statements.

-- Syntax :
-----------
	CREATE TRIGGER [schema_name.] trigger_name
	ON {table_name | view_name }
	INSTEAD OF {[INSERT] [,] [UPDATE] [,] [DELETE] }
	AS
	{sql_statements}

*/


-- INSTEAD OF trigger example :
-------------------------------

CREATE TABLE brands (
    brand_id INT IDENTITY(1,1) PRIMARY KEY,
    brand_name NVARCHAR(255)
);

INSERT INTO .brands (brand_name)
VALUES 
    ('Brand A'),
    ('Brand B'),
    ('Brand C'),
    ('Brand D'),
    ('Brand E');

SELECT * FROM brands;
------

CREATE TABLE brand_approvals(
	brand_id INT PRIMARY KEY,
	brand_name VARCHAR(max) NOT NULL
);

-- ADDING IDENTITY in existing table.
-- Step 1: Create a new table with the IDENTITY property
CREATE TABLE brand_approvals_new (
    brand_id INT IDENTITY(1,1) PRIMARY KEY,
    brand_name VARCHAR(MAX) NOT NULL
);

-- Step 2: Copy data from the existing table to the new table
INSERT INTO brand_approvals_new (brand_name)
SELECT brand_name FROM brand_approvals;

-- Step 3: Drop the original table
DROP TABLE brand_approvals;

-- Step 4: Rename the new table to the original table name
EXEC sp_rename 'brand_approvals_new', 'brand_approvals';

------

CREATE VIEW vw_brands
AS
SELECT	
	brand_name,
	'Approved' approval_status
FROM 
	brands

UNION

SELECT 
	brand_name,
	'Pending Approval' approval_status
FROM
	brand_approvals;
--
SELECT * FROM vw_brands;
------

	CREATE TRIGGER trg_vw_brands
	ON vw_brands
	INSTEAD OF INSERT
	AS
	BEGIN
		SET NOCOUNT ON;

		INSERT INTO brand_approvals(
			brand_name
		)
		SELECT
			i.brand_name
		FROM 
			inserted i
		WHERE
			i.brand_name NOT IN (
				SELECT 
					brand_name
				FROM 
					brands
			);
	END
---------------

INSERT INTO vw_brands(brand_name)
VALUES('Eddy Merckx');

SELECT * FROM brand_approvals;

-------------------------------------------------

----------------------------
-- SQL Server DDL triggers :
----------------------------
/*
SQL Server DDL triggers respond to server or database events rather than to table data modifications. 
These events created by the Transact-SQL statement that normally starts with one of the following keywords CREATE, ALTER, DROP, GRANT, DENY, REVOKE, or UPDATE STATISTICS.

--Syntax :
----------
	CREATE TRIGGER trigger_name
	ON { DATABASE |  ALL SERVER}
	[WITH ddl_trigger_option]
	FOR {event_type | event_group }
	AS {sql_statement}

DATABASE | ALL SERVER : 
------------------------
Use DATABASE if the trigger respond to database-scoped events or ALL SERVER if the trigger responds to the server-scoped events.

 ddl_trigger_option : 
----------------------
The ddl_trigger_option specifies ENCRYPTION and/or EXECUTE AS clause. ENCRYPTION encrypts the definition of the trigger. EXECUTE AS defines the security context under which the trigger is executed.

 event_type | event_group : 
----------------------------
i. The event_type indicates a DDL event that causes the trigger to fire e.g., CREATE_TABLE, ALTER_TABLE, etc.

ii. The event_group is a group of event_type event such as DDL_TABLE_EVENTS.

*/

-- Creating a SQL Server DDL Trigger Example:
---------------------------------------------
CREATE TABLE index_logs(
	log_id INT PRIMARY KEY IDENTITY,
	event_data XML NOT NULL,
	changed_by SYSNAME NOT NULL
);
-------

CREATE TRIGGER trg_index_changes
ON DATABASE
FOR
	CREATE_INDEX,
	ALTER_INDEX,
	DROP_INDEX
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO index_logs(
		event_data,
		changed_by
	)
	VALUES(
		EVENTDATA(),
		USER
	);
END
------------

CREATE NONCLUSTERED INDEX nidx_firstname
ON customer_copy(first_name);

CREATE NONCLUSTERED INDEX nidx_lastname
ON customer_copy(last_name);
-------------

SELECT 
    *
FROM
    index_logs;


-------------------------------------------
-- DISABLE Trigger :
--------------------------------------------
-- Syntax : 
------------
/*
	DISABLE TRIGGER [schema_name.][trigger_name] 
	ON [object_name | DATABASE | ALL SERVER]
*/

CREATE TABLE members(
	member_id INT IDENTITY PRIMARY KEY,
	customer_id INT NOT NULL,
	member_level CHAR(10) NOT NULL
);

CREATE TRIGGER trg_member_insert
ON members
AFTER INSERT
AS
BEGIN
	PRINT 'A new member has been inserted';
END

INSERT INTO members(customer_id,member_level)
VALUES (1, 'SILVER');


-- Disable all trigger on a table :
------------------------------------
-- Syntax : DISABLE TRIGGER ALL ON table_name;
-------------
CREATE TRIGGER trg_member_delete
ON members
AFTER DELETE
AS
BEGIN
	PRINT 'A new member has been deleted';
END
-----

DISABLE TRIGGER ALL ON members;


-- Disable all triggers on a database :
-----------------------------------------
/*
To disable all triggers on the current database, you use the following statement:

	DISABLE TRIGGER ALL ON DATABASE;

*/

----------------------
-- ENABLE TRIGGER :
----------------------
-- Syntax : 
------------
/*
	ENABLE TRIGGER [schema_name.][trigger_name] 
	ON [object_name | DATABASE | ALL SERVER]

*/

ENABLE TRIGGER trg_member_insert
ON members;


-- Enable All Triggers of a table :
------------------------------------
--Syntax :
----------
/*
	ENABLE TRIGGER ALL ON table_name;
*/

-- Enable All Triggers Of a Database :
---------------------------------------
--Syntax :
----------
/*
	ENABLE TRIGGER ALL ON DATABASE;
*/



---------------------------------------------
-- SQL Server View Trigger Definition :
---------------------------------------------
/*
1. Getting trigger definition by querying from a system view

You can get the definition of a trigger by querying data against the sys.sql_modules view:
*/

SELECT 
	definition
FROM
	sys.sql_modules
WHERE
	object_id = OBJECT_ID('production.dbo.trg_member_insert');


-- 2. Getting trigger definition using OBJECT_DEFINITION function.
SELECT
	OBJECT_DEFINITION(
		OBJECT_ID('production.dbo.trg_member_insert')
	) As trigger_defn;


-- 3. Getting trigger definition using sp_helptext stored procedure.
EXEC sp_helptext 'production.dbo.trg_member_insert';



-------------------------------
-- List All Triggers:
-------------------------------
-- To list all triggers in a SQL Server, you query data from the sys.triggers view:

SELECT 
	name,
	is_instead_of_trigger
FROM
	sys.triggers
WHERE
	type = 'TR';


----------------------------
-- DROP TRIGGER :
----------------------------
--Syntax :
-----------
/*
	DROP TRIGGER [ IF EXISTS ] [schema_name.]trigger_name [ ,...n ];

If you want to remove multiple triggers at once, you need to separate triggers by commas.
*/
-----------------------------

--To remove one or more DDL triggers, you use the following form of the DROP TRIGGER statement:
--Syntax :
----------
/*
	DROP TRIGGER [ IF EXISTS ] trigger_name [ ,...n ]   
	ON { DATABASE | ALL SERVER };
*/
