--Solution : set the isolation level to be more restrictive
--more precisely set it to read committed

set tran isolation level read committed
begin tran
select * from Antivirus
waitfor delay '00:00:10'
select * from Antivirus
commit tran