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
	