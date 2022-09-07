Create database BookStore

use BookStore

Create Table Users
(
UserId int identity(1,1) Primary key,
FullName varchar(250) not null,
Email varchar(180) not null,
Password varchar(50) not null,
MobileNumber bigint not null
)

Select * from Users


-------------- Store procedure for registeration -------------
Create proc UserRegister
(
@FullName varchar(250),
@Email varchar(180),
@Password varchar(50),
@MobileNumber bigint
)
As
Begin
	insert Users
	values (@FullName, @Email, @Password, @MobileNumber)
End;