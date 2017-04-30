create table tblUser
(
	ID int identity primary key,
	Username nvarchar(50),
	Password nvarchar(50)
)

insert into tblUser values('admin', 'admin')