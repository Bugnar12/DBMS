go

begin tran
update Antivirus
set antivirusRating = 10
where antivirusId = 10
waitfor delay '00:00:10'
rollback tran