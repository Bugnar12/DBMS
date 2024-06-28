begin tran
--gain an exclusive lock on OS table
update OperatingSystem set osKernel = 'LinuxKernel' where osName = 'Windows'

waitfor delay '00:00:08'
--block here because Transaction1 has an exclusive
update Antivirus set antivirusRating = 10 where antivirusName = 'Bitdefender'
commit tran

select * from Antivirus
select * from OperatingSystem