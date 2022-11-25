create database eurofins

select name from master.sys.databases order by name

use eurofins

create table employee(eid int,ename varchar(30),gender varchar(30),location varchar(20))

alter table employee add dept varchar(20),salary decimal(8,2)

alter table employee alter column location varchar(30)

alter table employee drop column gender

select * from employee

truncate table employee

drop table employee

select * from employee

insert into employee(eid,ename,gender,location,dept,salary) values(1234,'Vijay','M','banglore','IT',12000)

select eid,ename from employee

insert into employee values(1235,'Arun','M','banglore','IT',12000)

insert into employee(eid,ename,dept,salary) values(1236,'pooja','IT',12000)

insert into employee values(1238,'Peter','M','banglore','IT',12000),(1237,'Sri','F','Chennai','IT',52000)

insert into employee values(1235,'Arun','M','Chennai','developer',12000)


select * from employee

select eid,ename from employee where gender = 'M'

update employee set salary=20000 where eid>1235

select * from employee

delete from employee where eid = 1235

select eid,ename from employee where salary > 15000 and gender = 'F'


select eid,ename from employee where salary > 15000 or gender = 'F'

select * from employee where salary between 15000 and 60000 order by ename

select * from employee order by ename

select * from employee order by salary desc

select * from employee where location in ('chennai','banglore')

select * from employee where location not in ('chennai','banglore')

--select * from employee where location in (NULL)

-- like operator
select ename,dept,salary from employee where ename like '%i' --ending with i

select ename,dept,salary from employee where ename like 'v%y' --start with v and ending with i

select ename,dept,salary from employee where ename like 's___i' --start with s,have 3 char between s and i,ending with i

select ename,dept,salary from employee where ename like '_r%' --second char should be r

select ename,dept,salary from employee where ename like '%r_' 


select * from employee where location <> 'chennai' -- records other than location chennai

select count(*) as no_of_employees from employee
select Min(salary) as Min_salary, Max(salary) as max_salary from employee
select Max(salary) as max_salary from employee
select Sum(salary) as Total_salary from employee
select Avg(salary) as Avg_salary from employee

select location,count(*) as No_of_employees from employee group by location
select gender,count(*) as no_of_employees from employee group by gender

-- select * from employee group by location -- error because group by fn should be used along with aggregate functions

select gender,location,count(*) from employee group by gender,location

select gender,location,count(*) from employee group by gender,location having count(*)>1

select gender,location,count(*) from employee where salary>20000 group by gender,location having count(*)>1

select gender,location,count(*) from employee group by gender,location having count(*)>1 order by gender

select * from employee

select distinct * from employee order by ename

select distinct ename from employee order by ename

select SERVERPROPERTY('collation')
--select name,description from sys.fn_helpcollations

alter table employee add joiningdate date

--select 

delete from employee where eid = 1237

select * from employee

--case sensitive collate

select SERVERPROPERTY('collation')

select ename,location from employee where location in ('Chennai','Banglore')

select ename,location from employee where location collate SQL_Latin1_General_CP1_CS_AS in ('Chennai','Banglore')

--date time
select getdate() as date
select CURRENT_TIMESTAMP as date
select GETUTCDATE() as date

select GETDATE(),CURRENT_TIMESTAMP,GETUTCDATE() as date

insert into employee values(1239,'Neha','F','chennai','Testing',40000,'5/9/2021') --mm/dd/yyyy
insert into employee values(1240,'John','M','Pune','Developer',60000,'2022/7/18')

select * from employee order by eid

select * from employee where month(joiningdate) = 7

select * from employee where year(joiningdate) > 2021

select * ,datediff(month,joiningdate,getdate())from employee
select ename from employee where datediff(month,joiningdate,getdate())>1

select REPLACE('srimathi','s','a')
select len('srimathi')



