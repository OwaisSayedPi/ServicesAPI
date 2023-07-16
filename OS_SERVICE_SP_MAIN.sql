------------COMPANY CREATION
ALTER PROCEDURE [dbo].[OS_COMPANY_CREATION]
	@COMPANY NVARCHAR(50)
AS
BEGIN
BEGIN TRANSACTION
BEGIN TRY

INSERT INTO OS_Company (CompanyName)
VALUES (@COMPANY)

Commit;
End Try
Begin Catch
	Rollback;
	Print 'ERROR OCCURED. KINDLY CHECK VALUES PASSED TO SP'
End Catch
END

-------------BRANCH CREATION
ALTER PROCEDURE [dbo].[OS_BRANCH_CREATION]
	@Branch NVARCHAR(50),@CompanyID INT
AS
BEGIN
DECLARE
@ID INT;

BEGIN TRANSACTION
BEGIN TRY

SET @ID = ISNULL((SELECT MAX(ID) FROM OS_BRANCH),1)

INSERT INTO OS_Branch (ID,BranchName,CompanyID)
VALUES (@ID+1, @Branch, @CompanyID)

INSERT INTO OS_TOKEN 
VALUES (SUBSTRING(@Branch,1,1),0)

Commit;
End Try
Begin Catch
	Rollback;
	Print 'ERROR OCCURED. KINDLY CHECK VALUES PASSED TO SP'
End Catch
END
------------------COUNTER CREATION
ALTER PROCEDURE [dbo].[OS_COUNTER_CREATION]
@Counter NVARCHAR(50),@BranchID INT
AS
BEGIN
	DECLARE

@ID INT;

BEGIN TRANSACTION
BEGIN TRY

SET @ID = ISNULL((SELECT MAX(ID) FROM OS_Counter),0)

INSERT INTO OS_Counter (ID,Counter,BranchID)
VALUES (@ID+1, @Counter, @BranchID)

Commit;
End Try
Begin Catch
	Rollback;
	Print 'ERROR OCCURED. KINDLY CHECK VALUES PASSED TO SP'
End Catch
END

---------SERVICE CREATION
ALTER PROCEDURE [dbo].[OS_SERVICE_CREATION]
	@ServiceName NVARCHAR(50), @CounterID INT
AS
BEGIN
DECLARE
@ID INT;

BEGIN TRANSACTION
BEGIN TRY

SET @ID = ISNULL((SELECT COUNT(ID) FROM Owais_Service),0)

INSERT INTO Owais_Service (ID, ServiceName, CounterID)
VALUES (@ID+1, @ServiceName, @CounterID)

Commit;
End Try
Begin Catch
	Rollback;
	Print 'ERROR OCCURED. KINDLY CHECK VALUES PASSED TO SP'
End Catch
END

---------Agent CREATION
ALTER PROCEDURE OS_AGENT_CREATION
	@AgentName NVARCHAR(50), @BranchID INT
AS
BEGIN
DECLARE
@ID INT;

BEGIN TRANSACTION
BEGIN TRY

SET @ID = ISNULL((SELECT COUNT(ID) FROM OS_Service_Agent),0)

INSERT INTO OS_Service_Agent (ID, Name, BranchID)
VALUES (@ID+1, @AgentName, @BranchID)

Commit;
End Try
Begin Catch
	Rollback;
	Print 'ERROR OCCURED. KINDLY CHECK VALUES PASSED TO SP'
End Catch
END

----------QUESTION CREATION
ALTER PROCEDURE [dbo].[OS_QUESTION_CREATION]
	@ServiceId int  = null,
	@Questions varchar(max) = null
AS
BEGIN
DECLARE
@ID INT;

BEGIN TRAN AddQuestions
	BEGIN TRY
		Declare @QuestionTemp as table (Question varchar(255))
		Declare @Qxml XML

		SET @Qxml  = @Questions
		Insert into @QuestionTemp
		Select 
			Tbl.Col.value('Question[1]','VARCHAR(MAX)')
		from
			@Qxml.nodes('//root') Tbl(Col)

		Insert into Owais_Questions Select *,@ServiceId from @QuestionTemp
		COMMIT TRAN
END TRY
	BEGIN CATCH
		ROLLBACK TRAN AddQuestions
	END CATCH
END

----------------ADD ANSWERS
ALTER PROCEDURE [dbo].[OS_ANSWERS_SP]
	@Answers XML, @ServiceID INT, @BranchID INT
AS
BEGIN
DECLARE
@Token NVARCHAR(5),
@ID INT,
@CID INT;

BEGIN TRANSACTION
BEGIN TRY

SET @Token = (SELECT CONCAT(SUBSTRING(BranchName,1,1),'-',CAST(CustomersAttended+1 AS NVARCHAR))
				FROM OS_Branch B
				WHERE B.ID = @BranchID)
SELECT @TOKEN

UPDATE OS_BRANCH
SET CustomersAttended = CustomersAttended+1
WHERE ID = @BranchID

SET @CID = (SELECT TOP 1 ID
			FROM OS_COUNTER 
			LEFT JOIN (SELECT U.COUNTERID, COUNT(COUNTERID) AS NUM
				  FROM OS_User U
				  WHERE STATUSID<>3
				  GROUP BY U.COUNTERID) AS T
			ON T.COUNTERID = ID
			WHERE BRANCHID = @BranchID
			ORDER BY NUM)

INSERT INTO OS_User (ServiceID, Token, StatusID,CounterID)
Values (@ServiceID, @Token, 1, @CID)

DECLARE @tempData as table (ID INT, Answer NVARCHAR(MAX),QuestionID INT)

INSERT INTO @tempData
SELECT	Tbl.Col.value('ID[1]', 'INT'),
		Tbl.Col.value('Answer[1]', 'NVARCHAR(50)'),
		Tbl.Col.value('QuestionID[1]', 'INT')
FROM   @Answers.nodes('//row') Tbl(Col)

SET @ID = (SELECT MAX(ID) FROM OS_USER)

INSERT INTO Owais_Answers (Answer,QuestionID,UserID)
SELECT Answer, QuestionID, @ID
FROM @tempData 

Commit;
End Try
Begin Catch
	Rollback;
	Print 'ERROR OCCURED. KINDLY CHECK VALUES PASSED TO SP'
End Catch
END

------------------Get Question
ALTER PROCEDURE OS_GET_QUESTION
	@ServiceID INT
AS
BEGIN
BEGIN TRANSACTION
BEGIN TRY

SELECT Question FROM Owais_Questions WHERE ServiceID = @ServiceID

Commit;
End Try
Begin Catch
	Rollback;
	Print 'ERROR OCCURED. KINDLY CHECK VALUES PASSED TO SP'
End Catch
END

----------------GET QNA
CREATE PROC OS_GET_QNA
@TOKEN NVARCHAR(50)
AS
BEGIN
DECLARE
@UID INT,
@ISCHECK INT = 0;

SET @UID = (SELECT ID FROM OS_User WHERE Token = @TOKEN)
SET @ISCHECK = ISNULL(@UID,0)
IF NOT @ISCHECK = 0
	BEGIN
	SELECT Owais_Answers.ID, Answer, Question FROM Owais_Answers JOIN Owais_Questions ON QuestionID = Owais_Questions.ID WHERE UserID = @UID
	END
ELSE
	BEGIN
	SELECT Owais_Answers.ID, Answer, Question FROM Owais_Answers JOIN Owais_Questions ON QuestionID = Owais_Questions.ID
	END
END
GO
------STATUS UPDATE
CREATE PROC OS_STATUS_UPDATE
@TOKEN NVARCHAR(50), @StatusUpdate INT
AS
BEGIN
DECLARE
@UID INT,
@ISCHECK INT = 0;

SET @UID = (SELECT ID FROM OS_User WHERE Token = @TOKEN)
SET @ISCHECK = ISNULL(@UID,0)
IF NOT @ISCHECK = 0
	BEGIN
	UPDATE OS_User
	SET StatusID = @StatusUpdate
	WHERE Token = @TOKEN
	END
END
GO

SELECT * FROM OS_Status