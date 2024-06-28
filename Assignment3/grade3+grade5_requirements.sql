create or alter proc addRowAntivirus(@antivirusName varchar(100), @antivirusCreator varchar(100), @antivirusRating int) as
		if(@antivirusName is null)
		begin
			raiserror('Antivirus name cannot be null!', 24, 1)
		end
		if(@antivirusCreator is null)
		begin
			raiserror('Antivirus creator cannot be null!', 24, 1)
		end
		if(@antivirusRating < 1)
		begin
			raiserror('Rating can''t go lower than 1!', 24, 1)
		end
		insert into Antivirus(antivirusName, antivirusCreator, antivirusRating)
			values(@antivirusName, @antivirusCreator, @antivirusRating)
	exec sp_log_changes null, @antivirusName, 'Added row to antivirus!'
go

CREATE OR ALTER PROCEDURE addRowOperatingSystem(
    @osName VARCHAR(100),
    @osKernel VARCHAR(50),
    @osVersion INT
)
AS
BEGIN

    IF (@osName IS NULL)
    BEGIN
        RAISERROR('Operating system name cannot be null!', 24, 1);
        RETURN;
    END

    IF (@osKernel IS NULL)
    BEGIN
        RAISERROR('Operating system kernel cannot be null!', 24, 1);
        RETURN;
    END

    IF (@osVersion < 0)
    BEGIN
        RAISERROR('Operating system version cannot be negative!', 24, 1);
        RETURN;
    END

    INSERT INTO OperatingSystem(osName, osKernel, osVersion)
    VALUES (@osName, @osKernel, @osVersion);

    EXEC sp_log_changes NULL, @osName, 'Added row to OperatingSystem!';
END
GO

create or alter proc addRowAntivirusOnOS(@antivirusName varchar(100), @osName varchar(100))
as
begin
    -- Validate input parameters
    if(@antivirusName is null)
    begin
        raiserror('Antivirus name cannot be null!', 16, 1)
        return
    end
    if(@osName is null)
    begin
        raiserror('Operating system name cannot be null!', 16, 1)
        return
    end

    declare @antivirusId int
    declare @osId int

    -- Ensure subqueries return a single value
    select top 1 @antivirusId = antivirusId from Antivirus where antivirusName = @antivirusName order by antivirusId

    if(@antivirusId is null)
    begin
        raiserror('Antivirus with name %s does not exist!', 16, 1, @antivirusName)
        return
    end

    select top 1 @osId = osId from OperatingSystem where osName = @osName order by osId

    if(@osId is null)
    begin
        raiserror('Operating system with name %s does not exist!', 16, 1, @osName)
        return
    end

    -- Insert into AntivirusOnOS table
    insert into AntivirusOnOs(antivirusId, osId) values (@antivirusId, @osId)

    -- Log the change
    declare @newData varchar(200)
    set @newData = @antivirusName + ' ' + @osName
    exec sp_log_changes null, @newData, 'Many-to-many Antivirus and OS connected'
end
go

create or alter proc rollbackWithNoFailure
as
	begin tran
	begin try
		exec addRowAntivirus 'Bitdefender', 'Florin Talpes', 9
		exec addRowOperatingSystem 'Windows', 'Windows NT', 11
		exec addRowAntivirusOnOS 'Bitdefender', 'Windows'
	end try
	begin catch
		rollback tran
		return
	end catch
	commit tran
go

create or alter proc rollbackWithFailure
as
	begin tran
	begin try
		exec addRowAntivirus 'Bitdefender', 'Florin Talpes', 9
		exec addRowOperatingSystem 'Windows', 'Windows NT', 11
		exec addRowAntivirusOnOS 'Bitdefender', 'Linux'
	end try
	begin catch
		rollback tran
		return
	end catch
	commit tran
go

create or alter proc noRollbackScenarioManyToManyNoFailure
as
	declare @errors int
	set @errors = 0
	begin try
		exec addRowAntivirus 'Bitdefender', 'Florin Talpes', 9
	end try
	begin catch
		set @errors = @errors + 1
	end catch

	begin try
		exec addRowOperatingSystem 'Windows', 'Windows NT', 11
	end try
	begin catch
		set @errors = @errors + 1
	end catch

	if (@errors = 0) begin
		begin try
			exec addRowAntivirusOnOS 'Bitdefender', 'Windows'
		end try
		begin catch
		end catch
	end
go

create or alter proc noRollbackScenarioManyToManyFailure
as
	declare @errors int
	set @errors = 0
	begin try
		exec addRowAntivirus 'Bitdefender', 'Florin Talpes', 9
	end try
	begin catch
		set @errors = @errors + 1
	end catch

	begin try
		exec addRowOperatingSystem 'Windows', 'Windows NT', 11
	end try
	begin catch
		set @errors = @errors + 1
	end catch

	if (@errors = 0) begin
		begin try
			exec addRowAntivirusOnOS 'Bitdefender', 'Linux'
		end try
		begin catch
		end catch
	end
go




exec addRowAntivirus 'Bitdefender', 'Florin Talpes', 9
exec addRowOperatingSystem 'Windows', 'Windows NT', 11
exec addRowAntivirusOnOS 'Bitdefender', 'Linux'

exec addRowAntivirus 'Bitdefender', 'Florin Talpes', 9
exec addRowOperatingSystem 'Windows', 'Windows NT', 11
exec addRowAntivirusOnOS 'Bitdefender', 'Windows'


exec rollbackWithNoFailure
exec rollbackWithFailure

exec noRollbackScenarioManyToManyNoFailure
exec noRollbackScenarioManyToManyFailure

select * from Antivirus
select * from OperatingSystem
select * from AntivirusOnOS
select * from LogChanges
select * from LogLocks

delete from AntivirusOnOS
delete from Antivirus
delete from OperatingSystem
delete from LogChanges
