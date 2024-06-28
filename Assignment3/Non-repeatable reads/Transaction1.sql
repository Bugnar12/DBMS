insert into Antivirus(antivirusName, antivirusCreator, antivirusRating)
values ('Kaspersky', 'Michael', 8)

begin tran
waitfor delay '00:00:06'
update Antivirus
set antivirusRating = 9
where antivirusName = 'Kaspersky'
commit tran