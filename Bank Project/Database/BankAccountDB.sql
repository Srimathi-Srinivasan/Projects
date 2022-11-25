create database BankDB

use BankDB

create table SBAccount(Account_Number bigint,Customer_Name varchar(30),Customer_Address varchar(40),Current_Balance float)

alter table SBAccount alter column Account_Number bigint not null
alter table SBAccount add primary key(Account_Number)

select * from SBAccount

create proc spnewaccount(@Account_Number bigint,@Customer_Name varchar(30),@Customer_Address varchar(40),@Current_Balance float)
as
insert into SBAccount values(@Account_Number,@Customer_Name,@Customer_Address,@Current_Balance)

alter proc spnewaccount(@Account_Number bigint,@Customer_Name varchar(30),@Customer_Address varchar(40),@Current_Balance float,@Date_Of_Creation DateTime)
as
insert into SBAccount values(@Account_Number,@Customer_Name,@Customer_Address,@Current_Balance,@Date_Of_Creation)

truncate table SBAccount

alter table SBAccount add Date_Of_Creation DateTime

create proc spgetaccountdetails @Account_Number bigint
as
select * from SBAccount where Account_Number = @Account_Number

--exec spgetaccountdetails 5272167178

create proc spgetallaccounts
as
select * from SBAccount

create proc spdepositamt @Account_Number bigint,@amount decimal
as
update SBAccount set Current_Balance = Current_Balance + @amount where Account_Number = @Account_Number

--exec spdepositamt 5272167178,500

create proc spnewbalance @Account_Number bigint
as 
select Current_Balance from SBAccount where Account_Number = @Account_Number


create proc spwithdrawamt @Account_Number bigint,@amount decimal
as
update SBAccount set Current_Balance = Current_Balance - @amount where Account_Number = @Account_Number

create table SBTransaction(Transaction_ID int,Transaction_Date DateTime,Account_Number bigint,Amount decimal,Transaction_Type varchar(30))

select * from SBTransaction

create proc sptransaction(@Transaction_ID int,@Transaction_Date DateTime,@Account_Number bigint,@Amount decimal,@Transaction_Type varchar(30))
as
insert into SBTransaction values(@Transaction_ID,@Transaction_Date,@Account_Number,@Amount,@Transaction_Type)

create proc sptransactiondetails(@Account_Number bigint)
as
select Transaction_ID,Transaction_Date,Amount,Transaction_Type from SBTransaction where Account_Number = @Account_Number

