create database CRMDb
go
use CRMDb
go
create table Products
(Id int identity,
Name nvarchar(50),
Price money,
Stock int,
Constraint Pk_Id Primary key(Id)
)
go
Create procedure SP_Select
as
begin
    select * from Products
end
go
Create procedure SP_Update
@id int,
@name nvarchar(50),
@price money,
@stock int
as
Update Products set Name=@name,Price=@price,Stock=@stock
where Id=@id
go
Create procedure SP_Delete
@id int 
as
DELETE From Products where Id=@id
go
Create procedure SP_Insert
(
@name nvarchar(50),
@price money,
@stock int
)
as 
begin Insert into Products(Name,Price,Stock) Values (@name,@price,@stock)
end