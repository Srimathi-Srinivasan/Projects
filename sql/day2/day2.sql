use eurofins
create table student(regno int,sname varchar(20),age int,city varchar(20))

create table fees(regno int,dept varchar(20),amountpaid int)

--inner join
select s.regno,s.sname,s.city,f.dept,f.amountpaid from student s inner join fees f on s.regno = f.regno

select s.regno,s.sname,s.city,f.dept,f.amountpaid from student s join fees f on s.regno = f.regno

--loj
select s.regno,s.sname,s.city,f.dept,f.amountpaid from student s left outer join fees f on s.regno = f.regno

--roj
select s.regno,s.sname,s.city,f.dept,f.amountpaid from student s right outer join fees f on s.regno = f.regno

--full o j
select s.regno,s.sname,s.city,f.dept,f.amountpaid from student s full outer join fees f on s.regno = f.regno

select s.regno,s.sname,s.city,f.dept,f.amountpaid from student s full join fees f on s.regno = f.regno

--pk fk

create table course(cid int primary key,cname varchar(20))
alter table student add courseid int foreign key references course(cid)


select * from student

alter table student alter column regno int not null
alter table student add primary key(regno)
exec sp_rename '[PK__student__184A22100CBA53A6]','pkregno'

