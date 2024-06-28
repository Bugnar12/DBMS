create table Antivirus(
	antivirusId int primary key identity(1,1),
	antivirusName varchar(100),
	antivirusCreator varchar(100),
	antivirusRating int
)

create table OperatingSystem(
	osId int primary key identity(1,1),
	osName varchar(100),
	osKernel varchar(50),
	osVersion int,
)

create table AntivirusOnOS(
	antivirusId int foreign key references Antivirus(antivirusId),
	osId int foreign key references OperatingSystem(osId),
	primary key(antivirusId, osId)
)

drop table AntivirusOnOS
drop table Antivirus
drop table OperatingSystem

select * from Antivirus
insert into Antivirus(antivirusName, antivirusCreator, antivirusRating) values
('Bitdefender', 'Florin Talpes', 9)