--Solution : increase the isolation level once again to serializable;
--the highest isolation level possible

set tran isolation level serializable
begin tran
select * from Antivirus
waitfor delay '00:00:06'
select * from Antivirus
commit tran
