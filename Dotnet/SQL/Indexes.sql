-- INDEXES :
------------
--1. Clustered Indexes : A clustered index stores data rows in a sorted structure based on its key values. Each table has only one clustered index because data rows can be only sorted in one order. A table that has a clustered index is called a clustered table.

--A clustered index organizes data using a special structured so-called B-tree (or balanced tree) which enables searches, inserts, updates, and deletes in logarithmic amortized time.
------------------------

create database production;
use production;

create table parts(
	part_id int not null,
	part_name varchar(100)
);	

INSERT INTO 
    parts(part_id, part_name)
VALUES
    (1,'Frame'),
    (2,'Head Tube'),
    (3,'Handlebar Grip'),
    (4,'Shock Absorber'),
    (5,'Fork');

select * from parts
where part_id = 5;

CREATE TABLE part_prices(
    part_id int,
    valid_from date,
    price decimal(18,4) not null,
    PRIMARY KEY(part_id, valid_from) 
);

---------------------------------------
-- Create Clustered Index
---------------------------------------
--Syntax : 
----------
/*
	CREATE CLUSTERED INDEX index_name
	ON schema_name.table_name (column_list);  
*/

Create Clustered Index index_part_id
on parts(part_id);


----------------------------------------------
--2. Non Clustered Indexes : A nonclustered index is a data structure that improves the speed of data retrieval from tables. Unlike a clustered index, a nonclustered index sorts and stores data separately from the data rows in the table. It is a copy of selected columns of data from a table with the links to the associated table.
----------------------------------------------
---------------------------------------
-- Create Non Clustered Index
---------------------------------------
--Syntax : 
----------
/*
	CREATE [NONCLUSTERED] INDEX index_name
	ON table_name(column_list);
*/

Select *
INTO customer_copy
from hr.dbo.customers;

select * from customer_copy
where city = 'Lincoln';

Alter table customer_copy
Add primary key(customer_id);

CREATE INDEX index_customer_city
on customer_copy(city);

select 
	customer_id,
	first_name,
	last_name
from
	customer_copy
where
	first_name = 'Robert' AND
	last_name = 'Lee';

CREATE NONCLUSTERED INDEX index_customer_name
on customer_copy(first_name,last_name);

select 
	customer_id,
	first_name,
	last_name
from
	customer_copy
where
	first_name = 'Robert' AND
	last_name = 'Lee';


-------------------
-- Rename Indexes :
-------------------
EXEC sp_rename
	@objname = N'customer_copy.index_customer_city',
	@newname = N'ix_cust_city',
	@objtype = N'INDEX';

-------------------
-- UNIQUE Index :
-------------------
select 
	customer_id,
	email
from
	customer_copy
where
	email = 'david.wilson@example.com';

select
	email,
	COUNT(email) as email_count
from	
	customer_copy
Group By
	email
Having
	COUNT(email) > 1;
----------

Create Unique Index ix_cust_email
on customer_copy(email);

-------------
select
	email,
	COUNT(email) as email_count
from	
	customer_copy
Group By
	email
Having
	COUNT(email) > 1;


-------------------
-- Disable Indexes :
-------------------
--Syntax : 
----------
/*
1. Disable one index : 
----------------------
	ALTER INDEX index_name
	ON table_name
	DISABLE;

2.Disable All Indexes :
------------------------
	ALTER INDEX ALL 
	ON table_name
	DISABLE;

*/
-- NOTE : If you disable a clustered index of a table, you cannot access the table data using data manipulation language such as SELECT, INSERT, UPDATE, and DELETE until you rebuild or drop the index.


-------------------
-- Enable Indexes : 
-------------------
--In SQL Server, you can rebuild an index by using the ALTER INDEX statement or DBCC DBREINDEX command.

--1. Enable index using ALTER INDEX and CREATE INDEX statements : 
-----------------------------------------------------------------
-- i. This statement uses the ALTER INDEX statement to “enable” or rebuild an index on a table:

--Syntax :
----------
/*
	ALTER INDEX index_name 
	ON table_name  
	REBUILD;
*/

-- ii. This statement uses the CREATE INDEX statement to enable the disabled index and recreate it:

--Syntax :
----------
/*
	CREATE INDEX index_name 
	ON table_name(column_list)
	WITH(DROP_EXISTING=ON)
*/

-- iii. Enable all disable indexes using ALTER INDEX statement : 

--Syntax :
----------
/*
	ALTER INDEX ALL 
	ON table_name
	REBUILD;
*/


-- 2. Enable indexes using DBCC DBREINDEX statement :
-----------------------------------------------------

-- i. This statement uses the DBCC DBREINDEX to enable an index on a table:

--Syntax :
----------
/*
	DBCC DBREINDEX (table_name, index_name);
*/

-- ii. This statement uses the DBCC DBREINDEX to enable all indexes on a table:

--Syntax :
----------
/*
	DBCC DBREINDEX (table_name, " ");  
*/


-------------------
-- DROP Indexes : 
-------------------
-- A) Using SQL Server DROP INDEX to remove one index example

Drop Index IF EXISTS ix_cust_city
ON customer_copy;


-- B)Using SQL Server DROP INDEX to remove multiple indexes example

DROP INDEX
	index_customer_name ON customer_copy,
	ix_cust_email ON customer_copy;