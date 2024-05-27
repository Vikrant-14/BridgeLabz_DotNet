-- EXCEPTION HANDLING IN SQL SERVER : 
-------------------------------------
--SQL Server TRY CATCH : 
-------------------------
/*
The TRY CATCH construct allows you to gracefully handle exceptions in SQL Server. To use the TRY CATCH construct, you first place a group of Transact-SQL statements that could cause an exception in a BEGIN TRY...END TRY block as follows:

	The following illustrates a complete TRY CATCH construct:

	BEGIN TRY  
	   -- statements that may cause exceptions
	END TRY 
	BEGIN CATCH  
	   -- statements that handle exception
	END CATCH  

The CATCH block functions :
---------------------------
Inside the CATCH block, you can use the following functions to get the detailed information on the error that occurred:

1. ERROR_LINE() returns the line number on which the exception occurred.
2. ERROR_MESSAGE() returns the complete text of the generated error message.
3. ERROR_PROCEDURE() returns the name of the stored procedure or trigger where the error occurred.
4. ERROR_NUMBER() returns the number of the error that occurred.
5. ERROR_SEVERITY() returns the severity level of the error that occurred.
6. ERROR_STATE() returns the state number of the error that occurred.

Note that you only use these functions in the CATCH block. 
If you use them outside of the CATCH block, all of these functions will return NULL.

*/

--------------------------------------------
--Exception Example : 
---------------------
CREATE PROCEDURE divide_number(
	@a as DECIMAL,
	@b as DECIMAL, 
	@c as DECIMAL OUTPUT
)AS
BEGIN
	BEGIN TRY
		SET @c = @a / @b;
	END TRY
	BEGIN CATCH
		SELECT
			ERROR_NUMBER() AS ErrorNumbe,
			ERROR_SEVERITY() AS ErrorSeverity,  
            ERROR_STATE() AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,  
            ERROR_LINE() AS ErrorLine,  
            ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END

DECLARE @result Decimal;
EXECUTE divide_number 10,0, @result output;
PRINT @result;

-----------------------------------------------------
--TRY CATCH with transactions :
-------------------------------
/*
Inside a CATCH block, you can test the state of transactions by using the XACT_STATE() function.

1. If the XACT_STATE() function returns -1, it means that an uncommittable transaction is pending, you should issue a ROLLBACK TRANSACTION statement.
2. In case the XACT_STATE() function returns 1, it means that a committable transaction is pending. You can issue a COMMIT TRANSACTION statement in this case.
3. If the XACT_STATE() function return 0, it means no transaction is pending, therefore, you don’t need to take any action.
*/
----------
CREATE DATABASE SALES;
USE Sales;

CREATE TABLE persons(
	person_id INT PRIMARY KEY IDENTITY,
	first_name VARCHAR(max) NOT NULL,
	last_name VARCHAR(max) NOT NULL
);

CREATE TABLE deals(
	deal_id INT PRIMARY KEY IDENTITY,
	person_id INT NOT NULL,
	deal_note VARCHAR(max),
	FOREIGN KEY(person_id) REFERENCES persons(person_id)
);

insert into 
	persons(first_name, last_name)
values
    ('John','Doe'),
    ('Jane','Doe');

insert into 
    deals(person_id, deal_note)
values
    (1,'Deal for John Doe');

SELECT * FROM persons;
SELECT * FROM deals;

------
-- Create a new stored procedure named report_error that will be used in a CATCH block to report the detailed information of an error:

CREATE PROCEDURE report_error
AS
BEGIN
	SELECT
		ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_LINE () AS ErrorLine  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_MESSAGE() AS ErrorMessage;
END

-- Develop a new stored procedure that deletes a row from the sales.persons table:

CREATE PROCEDURE Delete_person(@person_id AS INT)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		-- delete person
		DELETE FROM persons
		WHERE person_id = @person_id;

		-- if DELETE is successful, commit the transactions
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		-- report exception
		EXEC report_error;

		-- check if the transaction is uncommittable
		IF (XACT_STATE()) = -1
		BEGIN
			PRINT N'The transaction is in an uncommittable state.' +  
                    'Rolling back transaction.' 
			ROLLBACK TRANSACTION
		END

		-- check if the transaction is committable
		IF (XACT_STATE()) = 1
		BEGIN
			PRINT N'The transaction is in an committable state.' +  
                    'Committing back transaction.' 
			COMMIT TRANSACTION
		END
	END CATCH
END

EXEC Delete_person 2; -- NO execption occurred

EXEC Delete_person 1; -- Exception Occurred
-- The DELETE statement conflicted with the REFERENCE constraint "FK__deals__person_id__38996AB5". The conflict occurred in database "SALES", table "dbo.deals", column 'person_id'.



---------------------------------------------------------------
-- RAISERROR : 
---------------
SELECT * FROM sys.messages;

-- message_id : 
---------------
/*
The message_id is a user-defined error message number stored in the sys.messages catalog view.

To add a new user-defined error message number, you use the stored procedure sp_addmessage. 
A user-defined error message number should be greater than 50,000. By default, the RAISERROR statement uses the message_id 50,000 for raising an error.
*/

-- Adding custom error messages to the sys.messages :
EXEC sp_addmessage
	@msgnum = 50005,
	@severity = 1,
	@msgtext = 'A custom error has occurred.';

SELECT * 
FROM sys.messages
WHERE message_id = 50005;

-- Raise Error :
RAISERROR(50005,1,1);

-- To message from the sys.messages,  you use the stored procedure sp_dropmessage.
EXEC sp_dropmessage
	@msgnum = 50005;


-- message_text : 
-----------------
/*
The message_text is a user-defined message with formatting like the printf function in C standard library. The message_text can be up to 2,047 characters, 3 last characters are reserved for ellipsis (…). If the message_text contains 2048 or more, it will be truncated and is padded with an ellipsis.

When you specify the message_text, the RAISERROR statement uses message_id 50000 to raise the error message.
*/
--Example :
------------
RAISERROR('Custom error has occurred!!!', 1, 1);


-- Severity :
-------------
/*
The severity level is an integer between 0 and 25, with each level representing the seriousness of the error.

	0–10 Informational messages
	11–18 Errors
	19–25 Fatal errors
*/

--State :
---------
/*
The state is an integer from 0 through 255. If you raise the same user-defined error at multiple locations, you can use a unique state number for each location to make it easier to find which section of the code is causing the errors. For most implementations, you can use 1.
*/


-- RAISERROR examples :
------------------------
-- A) Using SQL Server RAISERROR with TRY CATCH block example.

DECLARE 
    @ErrorMessage  NVARCHAR(4000), 
    @ErrorSeverity INT, 
    @ErrorState    INT;

BEGIN TRY
    RAISERROR('Error occurred in the TRY block.', 17, 1);
END TRY
BEGIN CATCH
    SELECT 
        @ErrorMessage = ERROR_MESSAGE(), 
        @ErrorSeverity = ERROR_SEVERITY(), 
        @ErrorState = ERROR_STATE();

    -- return the error inside the CATCH block
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH;

--------
-- B) Using SQL Server RAISERROR statement with a dynamic message text example.

DECLARE @MessageText NVARCHAR(100);
SET @MessageText = N'Cannot delete the sales order %s';

RAISERROR(
    @MessageText, -- Message text
    16, -- severity
    1, -- state
    N'2001' -- first argument to the message text
);



--------------------
-- THROW statement :
---------------------
/*
The THROW statement raises an exception and transfers execution to a CATCH block of a TRY CATCH construct.

The following illustrates the syntax of the THROW statement:
--------------------------------------------------------------
THROW [ error_number ,  message ,  state ];


RAISERROR V/S	THROW :
-------------------------
1. The message_id that you pass to RAISERROR must be defined in sys.messages view.	
-- The error_number parameter does not have to be defined in the sys.messages view.

2. The message parameter can contain printf formatting styles such as %s and %d.	
-- The message parameter does not accept printf style formatting. Use FORMATMESSAGE() function to substitute parameters.

3. The severity parameter indicates the severity of the exception.	
-- The severity of the exception is always set to 16.
*/

-- THROW statement examples :
--------------------------------

-- A) Using THROW statement to raise an exception.

THROW 50005, N'A Custom Exception has occurred!!!!', 1;

-----
-- B) Using THROW statement to rethrow an exception.

CREATE TABLE t1(
	id INT PRIMARY KEY
);

BEGIN TRY
	INSERT INTO t1(id) VALUES(1);

	--CAUSE ERROR
	INSERT INTO t1(id) VALUES(1);
END TRY
BEGIN CATCH
	PRINT('Raise the caught error again.');
	THROW
END CATCH

-------
-- C) Using THROW statement to rethrow an exception.
/*
Unlike the RAISERROR statement, the THROW statement does not allow you to substitute parameters in the message text. Therefore, to mimic this function, you use the FORMATMESSAGE() function.

The following statement adds a custom message to the sys.messages catalog view:
*/

EXEC sys.sp_addmessage
	@msgnum = 50010,
	@severity = 17,
	@msgtext = N'The order number %s cannot be deleted because it does not exist.';

SELECT * FROM sys.messages
WHERE message_id = 50010;

DECLARE @msgText NVARCHAR(max);
SET @msgText = FORMATMESSAGE(50010,N'2001');

THROW 50010, @msgText, 1;