--insert into OperatingSystem(osName, osKernel, osVersion)
--values ('Windows', 'Windows NT', 11)

begin tran

--set an exclusive lock on Antivirus table
update Antivirus set antivirusRating = 11 where antivirusName = 'Bitdefender'
waitfor delay '00:00:08'

--here it will block because T2 has an exclusive lock on OS table
update OperatingSystem set osKernel = 'LinuxKernel' where osName = 'Windows'
commit tran

select * from Antivirus
select * from OperatingSystem