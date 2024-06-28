begin tran
waitfor delay '00:00:06'
insert into Antivirus(antivirusName, antivirusCreator, antivirusRating)
values ('Avast', 'Andrew', 7)
commit tran

select * from Antivirus
