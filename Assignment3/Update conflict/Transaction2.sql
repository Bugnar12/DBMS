set tran isolation level snapshot
begin tran

waitfor delay '00:00:05'

--Transaction1 has now updated and obtained a lock on this table
-- trying to update the same row will result in an error
update Antivirus set antivirusRating = 8 where antivirusName = 'Spyware'
commit tran