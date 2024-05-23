--Views : 
----------
select * from customers;
select * from orders;
select * from staff;

-----------------------------------
-- Create View :
-----------------------------------
create view v2_Orders
as
Select 
	c.first_name + ' ' + c.last_name as fullname,
	c.email,
	o.order_id,
	o.order_date
From
	customers c INNER JOIN orders o
on 
	c.customer_id = o.customer_id;

---------------------------------------
-- Alter View :
---------------------------------------
Alter view v1_Orders
as
Select 
	c.first_name + ' ' + c.last_name as customer_name,
	c.email,
	o.order_id,
	o.order_date,
	s.first_name + ' ' + s.last_name as staff_name ,
	s.phone staff_number
From
	orders o 
INNER JOIN 
	customers c On o.customer_id = c.customer_id
INNER JOIN
	staff s on s.staff_id = o.staff_id;

-------------------------------------
select * from v1_Orders;
select * from v2_Orders;

---------------------------------------
-- Drop View :
---------------------------------------
Drop View v2_Orders;

---------------------------------------
-- Rename View :
---------------------------------------
EXEC sp_rename
	@objname = 'v1_Orders',
	@newname = 'View1_orderDetails';

select * from View1_orderDetails;
