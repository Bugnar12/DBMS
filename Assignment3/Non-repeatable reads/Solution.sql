--Solution : increase the isolation level and restrict the concurrency
--once again; set the respective to repeatable read

--delete from Antivirus where antivirusName = 'Kaspersky'

set tran isolation level repeatable read
begin tran 
select * from Antivirus
waitfor delay '00:00:06'
--now we can observe the value BEFORE the update
select * from Antivirus
commit tran