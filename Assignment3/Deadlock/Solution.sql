-- Solution: set deadlock priority to high for the second transaction
-- now, Transaction1 will be chosen as the deadlock victim, as it has a lower priority
-- default priority is normal (0)

set deadlock_priority HIGH
begin tran
update OperatingSystem set osKernel = 'LinuxKernel' where osName = 'Windows'

waitfor delay '00:00:08'
--block here because Transaction1 has an exclusive
update Antivirus set antivirusRating = 10 where antivirusName = 'Bitdefender'
commit tran