go

set tran isolation level read uncommitted
begin tran
select * from Antivirus
waitfor delay '00:00:10'

--here the update must have been rolled back
select * from Antivirus
commit tran