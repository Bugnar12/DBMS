set tran isolation level repeatable read
begin tran

select * from Antivirus
waitfor delay '00:00:06'
select * from Antivirus
commit tran