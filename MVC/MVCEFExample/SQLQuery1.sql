create database Shop
use Shop

create table Supplier(sid int primary key,sname varchar(20))

create table Product(pid int primary key,pname varchar(20),price decimal,suppid int foreign key references Supplier(sid))

create table Userdata(uid int primary key,uname varchar(20), password varchar(10))

select * from Userdata