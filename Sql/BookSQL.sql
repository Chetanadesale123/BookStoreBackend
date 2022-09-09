use BookStore

create table Books(
BookId int primary key identity,
BookName varchar(255) unique not null,
Author varchar(255) unique not null,
Description varchar(255) not null,
Quantity int not null,
Price money not null,
DiscountPrice money not null,
TotalRating float,
RatingCount int,
BookImg varchar(255)
)
Exec sp_help Books
select * from Books

----------------------stored procedure for AddBook------------------------------------------
alter procedure SPAddBook(
@BookName varchar(255),
@Author varchar(255),
@Description Nvarchar(255),
@Quantity int,
@Price money,
@DiscountPrice money,
@TotalRating float,
@RatingCount int,
@BookImg varchar(255)
)
As
Begin try
insert into Books(BookName,Author,Description,Quantity,Price,DiscountPrice,TotalRating,RatingCount,BookImg) values(@BookName,@Author,@Description,@Quantity,@Price,@DiscountPrice,@TotalRating,@RatingCount,@BookImg)
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


--------------------------------======================================================================------------------------------------------------