CREATE PROCEDURE sp_insert_email_data  
(  
@sender VARCHAR(50),  
@recipient VARCHAR(50),  
@subject VARCHAR(150),  
@body VARCHAR(MAX),  
@date DATETIME,
@status  BIT
)  
AS  
BEGIN
	BEGIN
	INSERT INTO email (sender, recipient, subject, body, date, status)
		VALUES (@sender, @recipient, @subject, @body, @date, @status)
	END
END
  