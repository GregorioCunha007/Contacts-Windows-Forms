create table Employee (
	ID int identity (1,1) primary key,
	Name nvarchar(255) not null
)

create table Company (
	ID int identity (1,1) primary key,
	Name nvarchar(255) not null
)

create table Employee_Company (
	EmployeeID int,
	CompanyID int,
	Mobile nvarchar(12),
	Phone nvarchar(12),
	Fax nvarchar(12),
	Email nvarchar(255),

	Foreign key (EmployeeID) references Employee(ID),
	Foreign key (CompanyID) references Company(ID),
	Primary key (EmployeeID, CompanyID)
)

go

create view vw_Companies
as
select * from Company

go

create proc sp_GetEmployees
@CompanyId int
as
begin 
	select * from Employee
	inner join Employee_Company on Employee.ID = Employee_Company.EmployeeID
	Where Employee_Company.CompanyID = @CompanyId
end

go

create proc sp_GetEmployeesInfo
@EmployeeId int,
@CompanyId int
as
begin 
	-- Return employees info. If Employee ID is provided, return single employee info
	if (@EmployeeId <> 0 AND @EmployeeId IS NOT NULL)
		begin
			select Employee = Employee.Name, 
				   Employee_Company.Mobile,
				   Employee_Company.Phone,
				   Employee_Company.Fax,
				   Employee_Company.Email
			from Employee_Company inner join Employee on Employee.ID = Employee_Company.EmployeeID 
			Where Employee_Company.EmployeeID = @EmployeeId and Employee_Company.CompanyID = @CompanyId
		end
	else 
		begin 
			select Employee = Employee.Name, 
				   Employee_Company.Mobile,
				   Employee_Company.Phone,
				   Employee_Company.Fax,
				   Employee_Company.Email 
			from Employee_Company inner join Employee on Employee.ID = Employee_Company.EmployeeID 
			Where Employee_Company.CompanyID = @CompanyId
		end
end

