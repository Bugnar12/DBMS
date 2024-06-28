insert into Antivirus values('Spyware', 'Alex', 6)
alter database Assignment3 set ALLOW_SNAPSHOT_ISOLATION ON

waitfor delay '00:00:05'
begin tran
update Antivirus set antivirusRating = 7 where antivirusName = 'Spyware'

waitfor delay '00:00:05'
commit tran