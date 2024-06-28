set tran isolation level read committed

begin tran
--here we should see the first insert
select * from Antivirus
waitfor delay '00:00:06'
select * from Antivirus
commit tran

--delete from Antivirus where antivirusName = 'Kaspersky'