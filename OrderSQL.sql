use Bookstore

create table OrderTables
(
	OrderId int identity(1,1) not null primary key,
	Price int not null,
	Quantity int not null,
	OrderDate Date not null,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
	BookId INT NOT NULL FOREIGN KEY REFERENCES Books(BookId),
	AddressId int not null FOREIGN KEY REFERENCES Address(AddressId)
);
select * from OrderTables;

