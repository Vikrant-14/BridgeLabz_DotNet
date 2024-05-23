use hr;

EXEC sp_help 'staff';

EXEC sp_help 'customers';

Select * from customers;

CREATE TABLE orders (
  order_id int NOT NULL PRIMARY KEY,
  customer_id int NOT NULL,
  order_status varchar(255) NOT NULL,
  order_date date NOT NULL,
  required_date date NOT NULL,
  shipped_date date,
  store_id int NOT NULL,
  staff_id int NOT NULL,
  FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
  FOREIGN KEY (staff_id) REFERENCES staff(staff_id)
);

INSERT INTO orders (order_id, customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
VALUES (5001, 1, 'Open', '2024-05-20', '2024-05-27', NULL, 1, 1),
       (5002, 2, 'In Progress', '2024-05-21', '2024-05-30', NULL, 2, 2),
       (5003, 3, 'Shipped', '2024-05-18', '2024-05-25', '2024-05-22', 3, 3),
       (5004, 4, 'Open', '2024-05-22', '2024-05-29', NULL, 1, 4),
       (5005, 5, 'Shipped', '2024-05-15', '2024-05-20', '2024-05-18', 2, 2);

select * from orders;
select * from customers;

select
	order_id,
	order_date,
	customer_id
from
	orders
where
	customer_id IN (
		select 
			customer_id
		from
			customers
		where
			city IN ('Springfield','Lincoln','Greenville','Hometown')
	)
Order By
	order_date DESC;


create table sales(
	id int primary key identity,
	product_name varchar(255) not null,
	region varchar(255) not null,
	amount int 
);

insert into sales(product_name,region,amount)
values  ('A','East',100),
		('B','West',150), 
		('A','East',200),
		('B','East',50),
		('C','West',300);

select * from sales;

--- Grouping Set

select 
	product_name,
	region,
	SUM(amount) as total_sales
from
	sales
Group By
	--product_name,
	--region
	Grouping Sets(
		(product_name),
		(region),
		()
	)
order by
	product_name;
-----------------------------

select 
	product_name,
	region,
	SUM(amount) as total_sales
from
	sales
Group By
	--product_name,
	--region
	Grouping Sets(
		(product_name),
		(region),
		(product_name, region)
	)
;

------------------------------
--ROLLUP : (Generates groupings by progressively including columns, ending with a grand total.)
-------------------------------
select 
	product_name,
	region,
	SUM(amount) as total_sales
from
	sales
Group By
	Rollup (product_name,region);

----------------------------------
--CUBE: Generates all possible combinations of the columns.
----------------------------------
select 
	product_name,
	region,
	SUM(amount) as total_sales
from
	sales
Group By
	CUBE (product_name,region);
	
---------------------------------
