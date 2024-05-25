-- CURSOR : 
------------
/*
What is a database cursor ?
-->	A database cursor is an object that enables traversal over the rows of a result set. It allows you to process individual row returned by a query.
*/
--------------------------

Select * from product;

---------------------------
--Steps to execute cursor : 
---------------------------
--1. Declare Variable to hold the records
DECLARE
	@product_name Varchar(max),
	@list_price DECIMAL;

--2. Declare a Cursor
DECLARE cursor_product CURSOR
FOR 
	SELECT
		name,
		price
	FROM
		Product;


--3. Open  Cursor
OPEN cursor_product;

--4. fetch a row from the cursor into one or more variables
FETCH NEXT FROM cursor_product INTO
	@product_name,
	@list_price;

WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @product_name + ' - ' + CAST(@list_price as Varchar(max));

		FETCH NEXT FROM cursor_product INTO
			@product_name,
			@list_price;
	END

--5. Close the Cursor
CLOSE cursor_product;

--6. Finally, deallocate the cursor
DEALLOCATE cursor_product;