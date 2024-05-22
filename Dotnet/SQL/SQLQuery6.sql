use Practice;

create table sql_server_char(
	val char(3)
);

INSERT INTO sql_server_char (val)
VALUES
    ('A');

select * from sql_server_char;

select val, LEN(val) len,
DATALENGTH(val) data_length
from sql_server_char;

create table sql_server_nchar(
	val nchar(3) not null
);

INSERT INTO sql_server_nchar (val)
VALUES (N'あ');

select * from sql_server_nchar;

SELECT
    val,
    len(val) length,
    DATALENGTH(val) data_length
FROM
   sql_server_nchar;

 SELECT 
    COALESCE(NULL, null, 'Hello', NULL) result;


CREATE TABLE salaries (
staff_id INT PRIMARY KEY,
hourly_rate decimal,
weekly_rate decimal,
monthly_rate decimal,
    CHECK(
        hourly_rate IS NOT NULL OR 
        weekly_rate IS NOT NULL OR 
        monthly_rate IS NOT NULL)
);

INSERT INTO 
    salaries(
        staff_id, 
        hourly_rate, 
        weekly_rate, 
        monthly_rate
    )
VALUES
    (1,20, NULL,NULL),
    (2,30, NULL,NULL),
    (3,NULL, 1000,NULL),
    (4,NULL, NULL,6000),
    (5,NULL, NULL,6500);

SELECT
    staff_id, 
    hourly_rate, 
    weekly_rate, 
    monthly_rate
FROM
    salaries
ORDER BY
    staff_id ;

select 
	staff_id,
	Coalesce(
		hourly_rate*22*8,
		weekly_rate*4,
		monthly_rate
	) monthly_salary
from 
	salaries
order by
	monthly_salary 
Offset 2 rows
fetch first 10 rows only;

select distinct hourly_rate from salaries;


