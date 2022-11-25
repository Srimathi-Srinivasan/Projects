create database ElectronicsShopping
use ElectronicsShopping

create table Categories(CategoryID int primary key,CategoryName varchar(20),Count int)
select * from Categories
alter table Categories drop column CategoryID
alter table Categories alter CategoryID int identity(1,1)

create table Products(ProdID int Primary key,ProdName varchar(20),Price float,SellerID int)
select * from Products
alter table Products drop column SellerID
alter table Products add Count int

create table Seller(SellerID int primary key,SellerName varchar(20),ProdID int references Products(ProdID),ContactAddress varchar(30))
alter table Seller drop constraint 'PK__Seller__7FE3DBA1E44288FA'
alter table Seller drop column SellerID
select * from Seller

create table Customer(CustomerID int primary key,CustomerName varchar(20),CustomerAddress varchar(30))
select * from Customer

create table ShoppingOrder(OrderID int primary key,CustomerID int references Customer(CustomerID),ProdID int references Products(ProdID),Date Date)
select * from ShoppingOrder

create table Payment(PaymentID int primary key,CustomerID int references Customer(CustomerID),ProdID int references Products(ProdID),Date Date)
select * from Payment

create table TelevisionCategory(CategoryID int identity(1,1) primary key, CategoryName varchar(20))
select * from TelevisionCategory
drop table TelevisionCategory

create table Television(Id int identity(101,1) primary key,CategoryID int references TelevisionCategory(CategoryID),Brand varchar(20),Model varchar(30),Price float,Count int)
drop table Television
select * from Television

alter table Television alter column URL varchar(200)
alter table Television add ProdId int

exec sp_rename 'ElectronicsShopping.Television','Product'
