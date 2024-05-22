create database hr;

use hr ;

create table candidates(
	id int primary key identity,
	fullname varchar(100) not null
);


create table employees(
	id int primary key identity,
	fullname varchar(100) not null
);

select name from sys.tables;

INSERT INTO 
   candidates(fullname)
VALUES
    ('John Doe'),
    ('Lily Bush'),
    ('Peter Drucker'),
    ('Jane Doe');


INSERT INTO 
    employees(fullname)
VALUES
    ('John Doe'),
    ('Jane Doe'),
    ('Michael Scott'),
    ('Jack Sparrow');

select * from employees;
select * from candidates;


-------------------------------------------
--Inner Join (match rows from both tables)
-------------------------------------------
select 
	c.id Candidate_ID,
	c.fullname Candidate_Name,
	e.id Employee_ID,
	e.fullname Employee_Name
from
	candidates c INNER JOIN  employees e
on
	c.fullname = e.fullname;


----------------------------------------------------------------------------------
--Left Outer Join (All the rows from left table and matching rows of right tables)
----------------------------------------------------------------------------------
select 
	c.id Candidate_ID,
	c.fullname Candidate_Name,
	e.id Employee_ID,
	e.fullname Employee_Name
from
	candidates c LEFT OUTER JOIN  employees e
on
	c.fullname = e.fullname;

---------
--To get the rows that are available only in the left table but not in the right table, you add a WHERE clause to the above query:

select 
	c.id Candidate_ID,
	c.fullname Candidate_Name,
	e.id Employee_ID,
	e.fullname Employee_Name
from
	candidates c LEFT OUTER JOIN  employees e
on
	c.fullname = e.fullname
where
	e.id is NULL;


----------------------------------------------------------------------------------
--Right Outer Join (All the rows from right table and matching rows of left tables)
----------------------------------------------------------------------------------
select 
	c.id Candidate_ID,
	c.fullname Candidate_Name,
	e.id Employee_ID,
	e.fullname Employee_Name
from
	candidates c RIGHT OUTER JOIN  employees e
on
	c.fullname = e.fullname;

---------
--To get rows that are available only in the right table by adding a WHERE clause to the above query:

select 
	c.id Candidate_ID,
	c.fullname Candidate_Name,
	e.id Employee_ID,
	e.fullname Employee_Name
from
	candidates c RIGHT OUTER JOIN  employees e
on
	c.fullname = e.fullname
where
	c.id is NULL;


----------------------------------------------------------------------------------
--FULL Outer Join (all rows from both left and right tables, with the matching rows from both sides. In case there is no match, the missing side will have NULL values.)
----------------------------------------------------------------------------------
select 
	c.id Candidate_ID,
	c.fullname Candidate_Name,
	e.id Employee_ID,
	e.fullname Employee_Name
from
	candidates c FULL OUTER JOIN  employees e
on
	c.fullname = e.fullname;

---------
--To select rows that exist in either the left or right table, you exclude rows that are common to both tables by adding a WHERE clause as shown in the following query:

select
	c.id Candidate_ID,
	c.fullname Candidate_Name,
	e.id Employee_ID,
	e.fullname Employee_Name
from
	candidates c Full OUTER JOIN Employees e
on
	c.fullname = e.fullname
where
	c.id IS NULL OR e.id IS NULL;