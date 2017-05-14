create database EmployeeDB_WebAPITokenBaseAuthen
go

use EmployeeDB_WebAPITokenBaseAuthen
go 

create table Employees
(
	ID int primary key identity,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Gender nvarchar(10),
	Salary int
)
Insert into Employees values ('Mark', 'Hastings', 'Male', 60000)
Insert into Employees values ('Steve', 'Pound', 'Male', 45000)
Insert into Employees values ('Ben', 'Hoskins', 'Male', 70000)
Insert into Employees values ('Philip', 'Hastings', 'Male', 45000)
Insert into Employees values ('Mary', 'Lambeth', 'Female', 30000)
Insert into Employees values ('Valarie', 'Vikings', 'Female', 35000)
Insert into Employees values ('John', 'Stanmore', 'Male', 80000)
go