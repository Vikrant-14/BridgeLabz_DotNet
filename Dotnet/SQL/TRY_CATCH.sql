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