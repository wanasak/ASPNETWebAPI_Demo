Create Database EmployeeDB
Go

Use EmployeeDB
Go

Create table tblEmployee
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     Salary int
)
Go

Insert into tblEmployee values ('Mark', 'Hastings', 'Male', 60000)
Insert into tblEmployee values ('Steve', 'Pound', 'Male', 45000)
Insert into tblEmployee values ('Ben', 'Hoskins', 'Male', 70000)
Insert into tblEmployee values ('Philip', 'Hastings', 'Male', 45000)
Insert into tblEmployee values ('Mary', 'Lambeth', 'Female', 30000)
Insert into tblEmployee values ('Valarie', 'Vikings', 'Female', 35000)
Insert into tblEmployee values ('John', 'Stanmore', 'Male', 80000)
Go