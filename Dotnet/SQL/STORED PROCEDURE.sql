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
