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


----------------------------
-- Full Outer Join Example : 
----------------------------

create table projects(
	id int primary key identity,
	title varchar(255) not null
);

create table members(
	id int primary key identity,
	name varchar(255) not null,
	project_id int,
	Foreign key(project_id) references projects(id)
);

INSERT INTO 
    projects(title)
VALUES
    ('New CRM for Project Sales'),
    ('ERP Implementation'),
    ('Develop Mobile Sales Platform');


INSERT INTO
    members(name, project_id)
VALUES
    ('John Doe', 1),
    ('Lily Bush', 1),
    ('Jane Doe', 2),
    ('Jack Daniel', null);

select * from projects; 
select * from members;

select 
	m.name member,
	p.title project
from 
	members m FULL OUTER JOIN projects p
on 
	m.project_id = p.id;


select 
	m.name member,
	p.title project
from 
	members m FULL OUTER JOIN projects p
on 
	m.project_id = p.id
where 
	m.id IS NULL OR p.id IS NULL;


----------------------------------------------------------------------------------
--Cross Join (combine rows from the first table with every row of the second table)
----------------------------------------------------------------------------------

select 
	m.name member,
	p.title project
from 
	 projects p CROSS JOIN members m ;
	 --// projects p , members m ;

----------------------------------------------------------------------------------
--Self Join (A self join allows you to join a table to itself. It helps query hierarchical data or compare rows within the same table.)
----------------------------------------------------------------------------------

CREATE TABLE staff (
    staff_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(50),
    last_name NVARCHAR(50),
    email NVARCHAR(100),
    phone NVARCHAR(20),
    active BIT,
    store_id INT,
    manager_id INT
);

INSERT INTO staff (first_name, last_name, email, phone, active, store_id, manager_id) VALUES
('Fabiola', 'Jackson', 'fabiola.jackson@bikes.shop', '(831) 555-5554', 1, 1, NULL),
('Mireya', 'Copeland', 'mireya.copeland@bikes.shop', '(831) 555-5555', 1, 1, 1),
('Genna', 'Serrano', 'genna.serrano@bikes.shop', '(831) 555-5556', 1, 1, 2),
('Virgie', 'Wiggins', 'virgie.wiggins@bikes.shop', '(831) 555-5557', 1, 1, 2),
('Jannette', 'David', 'jannette.david@bikes.shop', '(516) 379-4444', 1, 2, 4),
('Marcelene', 'Boyer', 'marcelene.boyer@bikes.shop', '(516) 379-4445', 1, 2, 5),
('Venita', 'Daniel', 'venita.daniel@bikes.shop', '(516) 379-4446', 1, 2, 5),
('Kali', 'Vargas', 'kali.vargas@bikes.shop', '(972) 530-5555', 1, 3, 6),
('Layla', 'Terrell', 'layla.terrell@bikes.shop', '(972) 530-5556', 1, 3, 7),
('Bernardine', 'Houston', 'bernardine.houston@bikes.shop', '(972) 530-5557', 1, 3, NULL);

select * from staff;

select 
	e.first_name + ' ' + e.last_name employee,
	m.first_name + ' ' + m.last_name manager
From
	staff e, staff m
where
	m.staff_id = e.manager_id;

select	
	e.first_name + ' ' + e.last_name employee,
	m.first_name + ' ' + m.last_name manager
From
	staff e INNER JOIN staff m
on
	e.manager_id = m.staff_id;

select	
	e.first_name + ' ' + e.last_name employee,
	m.first_name + ' ' + m.last_name manager
From
	staff e LEFT JOIN staff m
on
	e.manager_id = m.staff_id;

------------------------
--SELF JOIN Example
------------------------

CREATE TABLE customers (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(50),
    last_name NVARCHAR(50),
    phone NVARCHAR(20),
    email NVARCHAR(100),
    street NVARCHAR(100),
    city NVARCHAR(50),
    state NVARCHAR(50),
    zip_code NVARCHAR(10)
);

INSERT INTO customers (first_name, last_name, phone, email, street, city, state, zip_code) VALUES
('John', 'Doe', '(123) 456-7890', 'john.doe@example.com', '123 Main St', 'Springfield', 'IL', '62701'),
('Jane', 'Smith', '(234) 567-8901', 'jane.smith@example.com', '456 Elm St', 'Greenville', 'TX', '75401'),
('Michael', 'Brown', '(345) 678-9012', 'michael.brown@example.com', '789 Oak St', 'Fairview', 'CA', '94501'),
('Emily', 'Davis', '(456) 789-0123', 'emily.davis@example.com', '321 Pine St', 'Riverside', 'FL', '32001'),
('David', 'Wilson', '(567) 890-1234', 'david.wilson@example.com', '654 Maple St', 'Lincoln', 'NE', '68501');

INSERT INTO customers (first_name, last_name, phone, email, street, city, state, zip_code) VALUES
('Alice', 'Johnson', '(678) 901-2345', 'alice.johnson@example.com', '987 Cedar St', 'Hometown', 'NY', '10001'),
('Robert', 'Lee', '(789) 012-3456', 'robert.lee@example.com', '123 Birch St', 'Oldtown', 'VA', '22001'),
('Linda', 'Martinez', '(890) 123-4567', 'linda.martinez@example.com', '456 Aspen St', 'Newtown', 'MA', '02101'),
('Charles', 'Garcia', '(901) 234-5678', 'charles.garcia@example.com', '789 Redwood St', 'Anytown', 'CO', '80001'),
('Susan', 'Clark', '(012) 345-6789', 'susan.clark@example.com', '321 Spruce St', 'Everytown', 'WA', '98001'),
('James', 'Rodriguez', '(123) 456-7891', 'james.rodriguez@example.com', '654 Pine St', 'Somewhere', 'OR', '97001'),
('Patricia', 'Lewis', '(234) 567-8902', 'patricia.lewis@example.com', '987 Oak St', 'Anywhere', 'AZ', '85001'),
('Christopher', 'Walker', '(345) 678-9013', 'christopher.walker@example.com', '123 Elm St', 'Everywhere', 'UT', '84101'),
('Jessica', 'Hall', '(456) 789-0124', 'jessica.hall@example.com', '456 Maple St', 'Nowhere', 'NM', '87001'),
('Daniel', 'Allen', '(567) 890-1235', 'daniel.allen@example.com', '789 Birch St', 'Uptown', 'NV', '89001');

select * from customers;


select 
	c1.city,
	c1.first_name + ' ' + c1.last_name customer_1,
	c2.first_name + ' ' + c2.last_name customer_2
from 
	customers c1 INNER JOIN customers c2
on 
	c1.city = c2.city
order by
	city,
	customer_1,
	customer_2;
