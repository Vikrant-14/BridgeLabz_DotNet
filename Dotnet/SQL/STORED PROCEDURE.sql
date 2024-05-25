-- STORED PROCEDURE :
-----------------------
select * from customers;

Select
	first_name + ' ' + last_name Fullname,
	email Email,
	phone Phone
From
	customers
Order BY
	first_name,
	last_name;

---------------------------
--Create Stored Procedure :
---------------------------
CREATE PROCEDURE customer_list
AS
BEGIN
	Select
		first_name + ' ' + last_name Full_Name,
		email Email,
		phone Phone
	From
		customers
	Order BY
		first_name,
		last_name;
END;

--------------------------------
-- Executing Stored Procedure : 
--------------------------------
Execute customer_list;

---------------------------------
-- Modifying a Stored Procedure :
---------------------------------
ALTER PROCEDURE customer_list
AS
BEGIN
	Select
		first_name + ' ' + last_name Full_Name,
		email Email,
		phone Phone,
		city City
	From
		customers
	Order BY
		first_name,
		last_name;
END;

---------------------------------
-- Deleting a Stored Procedure :
---------------------------------
DROP PROCEDURE customer_list;

---------------------------------------------------
--Creating a stored procedure with one parameter :
---------------------------------------------------
CREATE PROCEDURE find_customer(@name AS varchar(255))
AS
BEGIN
	SELECT 
		first_name + ' ' + last_name Full_Name,
		email Email,
		phone Phone,
		city City
	From
		customers
	Where
		first_name = @name
	Order BY
		first_name,
		last_name;
END

Execute find_customer 'Alice';

--------------------------------------------------------
--Creating a stored procedure with multiple parameters :
--------------------------------------------------------
CREATE PROCEDURE Search_Customer(@firstname AS varchar(255), @lastname as varchar(255))
AS
BEGIN
	SELECT 
		first_name + ' ' + last_name Full_Name,
		email Email,
		phone Phone,
		city City
	From
		customers
	Where
		first_name = @firstname OR
		last_name = @lastname
	Order BY
		first_name,
		last_name;
END

Execute Search_Customer 'Alice', 'Lewis' ;

--Using Named Parameters :
---------------------------
Execute Search_Customer
	@firstname = 'Alice',
	@lastname = 'Lee';

------------------------------
--Creating text parameters : 
------------------------------
CREATE PROCEDURE Search_Customer_Based_on_City(@firstname AS varchar(max), @lastname as varchar(max), @cityname as varchar(max))
AS
BEGIN
	SELECT 
		first_name + ' ' + last_name Full_Name,
		email Email,
		phone Phone,
		city City
	From
		customers
	Where
		first_name = @firstname OR
		last_name = @lastname OR
		city LIKE '%' + @cityname + '%' 
	Order BY
		first_name,
		last_name;
END

EXECUTE Search_Customer_Based_on_City
	@firstname = 'John',
	@lastname = 'Lewis',
	@cityname = 'Some';

-----------------------------
--Creating Optional Parameter : 
-----------------------------
CREATE PROCEDURE find_products(@min_price as Decimal = 0, @max_price as Decimal = 99999, @name as varchar(max))
AS
BEGIN
	SELECT
		Name,
		Price
	FROM
		Product
	WHERE
		Price >= @min_price AND
		Price <= @max_price AND
		Name LIKE '%' + @name +'%'
	ORDER BY
		Price;
END

EXECUTE find_products  @name = 'c';

Select * from product;
	
------------------------------------------------------
-- Variable :
--------------

--1. Declaring variable :
DECLARE @model_year smallint;

-- 2. Assigning value to a variable : 
SET @model_year = 2020;

SELECT @model_year AS ModelYear;

SELECT 
	ProductID,
	Name,
	price,
	model_year
FROM 
	product
Where
	model_year = @model_year;

----------

Declare @product_count int;

Set @product_count = (
	Select Count(*)
	From product
);

SELECT @product_count; -- o/p in results
PRINT @product_count; -- o/p in messages
PRINT 'The number of products is ' + CAST(@product_count AS VARCHAR(MAX));

--------------------------------------
--Selecting a record into variables :
--------------------------------------
--1.
Declare 
	@product_name varchar(max),
	@product_price Decimal(10,2);

--2.
Select 
	@product_name = name,
	@product_price = price
From
	product
Where
	ProductID = 10;

--3.
SELECT 
    @product_name AS product_name, 
    @product_price AS list_price;

----------------------------------------
-- Accumulating values into a variable :
----------------------------------------
CREATE PROCEDURE GETProduct(@model_year smallint)
AS
BEGIN
	DECLARE @product_list varchar(max);

	SET @product_list = '';

	SELECT 
		@product_list = @product_list + name + char(10)
	FROM
		product
	WHERE
		model_year = @model_year
	ORDER BY
		name

	PRINT @product_list
END

Select * from product;

EXECUTE GETProduct 2023;

--------------------------------------
--Stored Procedure Output Parameters : 
--------------------------------------

ALTER PROCEDURE FindProductByModel (
    @model_year SMALLINT,
    @product_count INT OUTPUT
) AS
BEGIN
    SELECT 
        name,
        price
    FROM
        product
    WHERE
        model_year = @model_year;

    SELECT @product_count = @@ROWCOUNT;
END;

----

Declare @count INT;

EXECUTE FindProductByModel
	@model_year = 2023,
	@product_count = @count OUTPUT;

Select @count as 'Number of Products Found';

----------------------
--IF ELSE:
----------------------
--Syntax: 
---------
/*
IF boolean_expression   
BEGIN
    { statement_block }
END
*/

----------------------
--WHILE statement :
----------------------
--Syntax: 
---------
/*
WHILE Boolean_expression   
     { sql_statement | statement_block}  
*/

DECLARE @counter int = 1;

WHILE @counter <= 10
BEGIN
	PRINT @counter;
	SET @counter = @counter + 1;
END


-- BREAK statement : 
---------------------
DECLARE @countVariable INT = 0;

WHILE @countVariable <= 10
BEGIN
	SET @countVariable = @countVariable + 1;
	
	IF @countVariable = 5
	BEGIN
		PRINT 'BREAKING STATEMENT';
		BREAK;
	END

	PRINT @countVariable;
END

-- CONTINUE statement : 
-----------------------
DECLARE @countVariable1 INT = 0;

WHILE @countVariable1 <= 10
BEGIN
	SET @countVariable1 = @countVariable1 + 1;
	
	IF @countVariable1 = 5
	BEGIN
		PRINT 'CONTINUE STATEMENT';
		CONTINUE;
	END

	PRINT @countVariable1;
END