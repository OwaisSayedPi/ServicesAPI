exec  sp_helptext OS_AGENT_CREATION

SELECT s.id as Id ,S.ServiceName FROM OS_Branch LEFT JOIN OS_Counter ON BranchID = OS_Branch.ID 
JOIN Owais_Service s ON CounterID = OS_Counter.ID WHERE OS_Branch.ID = @BRANCHID    


select * from OS_User
select * from Owais_Supplier
select * from OS_Branch
select * from OS_Counter
select * from OS_Company
select * from OS_Service_Agent
select * from Owais_Service
select * from Owais_Questions
create proc OS_Queue_Get_Company_branch

select * from OS_User
select * from Owais_Answers
EXEC OS_ANSWERS_SP '<root><AnswerID>1</AnswerID><Answer>test1</Answer><QuestionID>3</QuestionID></root><root><AnswerID>1</AnswerID><Answer>test2</Answer><QuestionID>3</QuestionID></root>', 6, 3
EXEC OS_Agent_Login 'Ravi','1234567'
EXEC [OS_GET_USER] 'N-7'

@brachid int
as
select b.BranchName,c.CompanyName from OS_Branch b left join OS_Company c on c.ID=b.CompanyID
where b.ID=@brachid 

EXEC OS_GET_QNA 'C-23'

EXEC OS_GET_SERVICES 1
select * from OS_Branch

exec  sp_helptext OS_COMPANY_CREATION
exec  sp_helptext OS_BRANCH_CREATION
exec  sp_helptext OS_COUNTER_CREATION
exec  sp_helptext OS_SERVICE_CREATION