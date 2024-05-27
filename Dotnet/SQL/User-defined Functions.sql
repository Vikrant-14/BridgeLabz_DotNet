-- SQL Server User-defined Functions :
---------------------------------------

-- SQL Server user-defined functions including scalar-valued functions which return a single value and table-valued function which return rows of data.

-- What are Table Variables?
----------------------------
-- Table variables are kinds of variables that allow you to hold rows of data, which are similar to temporary tables.

-- Syntax for declaring table variable :
----------------------------------------
/*
	DECLARE @table_variable_name TABLE(
		column_list;
	);
*/

-- Example : 
------------
DECLARE @product_table TABLE(
	product_name VARCHAR(max) NOT NULL,
	category VARCHAR(max) NOT NULL,
	price  DECIMAL(10,2) NOT NULL
);

INSERT INTO @product_table
SELECT
	name,
	Category,
	price
FROM
	Product
Where 
	ProductID = 1;

SELECT 
	*
FROM 
	@product_table;

/*
RESTRICTIONS ON TABLE VARIABLE :
---------------------------------
1. Once the structure of table variable is defined , we cannot alter the structure.

2. statistics help the query optimizer to come up with a good query’s execution plan. Unfortunately, table variables do not contain statistics. Therefore, you should use table variables to hold a small number of rows.

3. We cannot use table variable as input/ouput paramneter, but we can return a table variable in user-defined fucntion.

4. We cannot create non-clustered indexes for ta ble variable.
   However, starting with SQL Server 2014, memory-optimized table variables are available with the introduction of the new In-Memory OLTP that allows you to add non-clustered indexes as part of table variable’s declaration.

5. If we are using a table variable with a join, then we need to have alias for the table inorder to execute the query.

NOTE : Temporary Table and Table Variable live in the tempdb, not in the memory
*/
--------------
CREATE OR ALTER FUNCTION udfSplit(
    @string VARCHAR(MAX), 
    @delimiter VARCHAR(50) = ' ')
RETURNS @parts TABLE
(    
idx INT IDENTITY PRIMARY KEY,
val VARCHAR(MAX)   
)
AS
BEGIN

DECLARE @index INT = -1;

WHILE (LEN(@string) > 0) 
BEGIN 
    SET @index = CHARINDEX(@delimiter , @string)  ;
    
    IF (@index = 0) AND (LEN(@string) > 0)  
    BEGIN  
        INSERT INTO @parts 
        VALUES (@string);
        BREAK  
    END 

    IF (@index > 1)  
    BEGIN  
        INSERT INTO @parts 
        VALUES (LEFT(@string, @index - 1));
        
        SET @string = RIGHT(@string, (LEN(@string) - @index));  
    END 
    ELSE
		SET @string = RIGHT(@string, (LEN(@string) - @index)); 
    END
RETURN
END
GO
--------------
SELECT 
    * 
FROM 
    udfSplit('foo,bar,baz',',');



-------------------------
-- A. SCALAR FUNCTIONS : 
-------------------------
-- SQL Server scalar function takes one or more parameters and returns a single value.

--------------------------------
-- Creating a Scalar Function :
--------------------------------
/*
	CREATE FUNCTION [schema_name.]function_name (parameter_list)
	RETURNS data_type AS
	BEGIN
		statements
		RETURN value
	END
*/

-- Example :
-------------
CREATE FUNCTION NetSale(@quantity INT, @price DEC(10,2), @discount DEC(4,2))
RETURNS DEC(10,2)
AS
BEGIN
	RETURN @quantity * @price * (1 - @discount);
END

---
SELECT dbo.NetSale(10,100,0.14) net_sale;


--------------------------------
-- Modifying a Scalar Function :
--------------------------------
/*
	ALTER FUNCTION [schema_name.]function_name (parameter_list)
		RETURN data_type AS
		BEGIN
			statements
			RETURN value
		END

-----------------------
	CREATE OR ALTER FUNCTION [schema_name.]function_name (parameter_list)
			RETURN data_type AS
			BEGIN
				statements
				RETURN value
			END

*/

--------------------------------
-- Removing a Scalar Function :  
--------------------------------
-- DROP FUNCTION [schema_name.]function_name;

----------------------------------------------------------------------------------

--------------------------
-- TABLE-VALUED FUNCTION :
--------------------------
/*
A table-valued function is a user-defined function that returns data of a table type. The return type of a table-valued function is a table, therefore, you can use the table-valued function just like you would use a table.
*/


Select * from Product;
-------------------------------------
-- Creating A Table-Valued Fucntion : 
-------------------------------------

CREATE FUNCTION udfProductInYear(@model_year INT)
RETURNS TABLE
AS
	RETURN
		SELECT
			Name,
			model_year,
			Price
		FROM
			Product
		Where 
			model_year = @model_year;
----------------

SELECT * 
FROM udfProductInYear(2022);



--------------------------------------
--Modifying a Table-Valued Function : 
---------------------------------------
ALTER FUNCTION udfProductInYear(@start_year INT, @end_year INT)
RETURNS TABLE
AS
	RETURN 
		SELECT
			Name,
			model_year,
			Price
		FROM
			Product
		Where 
			model_year BETWEEN @start_year AND @end_year;
------------------
SELECT * 
FROM udfProductInYear(2021,2022);


----------------------------------------------------
-- Multi-statement table-valued functions (MSTVF) :
----------------------------------------------------
/*
A multi-statement table-valued function or MSTVF is a table-valued function that returns the result of multiple statements.

The multi-statement-table-valued function is very useful because you can execute multiple queries within the function and aggregate results into the returned table.

To define a multi-statement table-valued function, you use a table variable as the return value. Inside the function, you execute one or more queries and insert data into this table variable.
*/

SELECT * FROM customers;
SELECT * FROM staff;

CREATE FUNCTION unfContacts()
	RETURNS @contacts TABLE(
		first_name VARCHAR(50),
		last_name VARCHAR(50),
		email VARCHAR(max),
		phone VARCHAR(25),
		contact_type VARCHAR(max)
	)
AS
BEGIN
	INSERT INTO @contacts
	SELECT
		first_name,
		last_name,
		email,
		phone,
		'STAFF'
	FROM
		staff;

	INSERT INTO @contacts
	SELECT
		first_name,
		last_name,
		email,
		phone,
		'CUSTOMER'
	FROM
		customers;

	RETURN;
END;
--------------------------
SELECT
	*
FROM 
	unfContacts();


------------------------
-- DROPING A FUNCTION :
------------------------
/*
-- Syntax :
------------
	DROP FUNCTION [ IF EXISTS ] [ schema_name. ] function_name;

-- To drop multiple user-defined functions :
---------------------------------------------
	DROP FUNCTION [IF EXISTS] 
		schema_name.function_name1, 
		schema_name.function_name2,
		...;

Notes :
--------
1. If the function that you want to remove is referenced by views or other functions created using the WITH SCHEMABINDING option, the DROP FUNCTION will fail.

2. In addition, if there are constraints like CHECK or DEFAULT and computed columns that refer to the function, the DROP FUNCTION statement will also fail.
*/