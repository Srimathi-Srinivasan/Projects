create database StateBankDB
use StateBankDB

create table SBAccount(Account_Number int,Customer_Name varchar(30),Customer_Address varchar(40),Current_Balance decimal,Date_Of_Creation DateTime)

alter table SBAccount alter column Account_Number int not null
alter table SBAccount add primary key(Account_Number)

select * from SBAccount

create proc spnewaccount(@Account_Number int,@Customer_Name varchar(30),@Customer_Address varchar(40),@Current_Balance decimal,@Date_Of_Creation DateTime)
as
insert into SBAccount values(@Account_Number,@Customer_Name,@Customer_Address,@Current_Balance,@Date_Of_Creation)

create proc spgetaccountdetails @Account_Number int
as
select * from SBAccount where Account_Number = @Account_Number

create proc spgetallaccounts
as
select * from SBAccount

create proc spdepositamt @Account_Number int,@amount decimal
as
update SBAccount set Current_Balance = Current_Balance + @amount where Account_Number = @Account_Number

create proc spwithdrawamt @Account_Number int,@amount decimal
as
update SBAccount set Current_Balance = Current_Balance - @amount where Account_Number = @Account_Number


create proc spnewbalance @Account_Number int
as 
select Current_Balance from SBAccount where Account_Number = @Account_Number

create table SBTransaction(Transaction_ID int,Transaction_Date DateTime,Account_Number int,Amount decimal,Transaction_Type varchar(30))


select * from SBTransaction

create proc sptransaction(@Transaction_ID int,@Transaction_Date DateTime,@Account_Number int,@Amount decimal,@Transaction_Type varchar(30))
as
insert into SBTransaction values(@Transaction_ID,@Transaction_Date,@Account_Number,@Amount,@Transaction_Type)

create proc sptransactiondetails(@Account_Number int)
as
select Transaction_ID,Transaction_Date,Amount,Transaction_Type from SBTransaction where Account_Number = @Account_Number

exec sptransactiondetails 1750463771

alter proc sptransactiondetails(@Account_Number int)
as
select Transaction_ID,Transaction_Date,Amount,Transaction_Type from SBTransaction where Account_Number = @Account_Number order by Transaction_Date desc

exec sptransactiondetails 1196243924