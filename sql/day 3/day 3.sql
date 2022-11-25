use Northwind

select * from employees

select employeeid,firstname,reportsto from employees

--self join
select e1.employeeid,e1.firstname,e1.reportsto,e2.firstname from employees e1 join employees e2
on e1.reportsto = e2.employeeid

select e1.employeeid,e1.firstname+'reports to'+e2.firstname from employees e1 join employees e2
on e1.reportsto = e2.employeeid

--primary key foreign key
use eurofins
select * from employee
alter table employee alter column eid int not null
alter table employee add constraint pkeid primary key(eid)

create table department
(
did int primary key identity(201,1)
)
alter table employee add deptid int references department(did)

alter table employee drop constraint FK__employee__deptid__37A5467C

alter table employee add constraint fkdeptid foreign key(deptid) references department(did)

--renaming a constraint
sp_rename 'PK__departme__D877D2168413F433','pkdid'

--default and check constraints
select * from student
alter table student add constraint chkage check(age > 18)
alter table student add constraint chkcourseid check(courseid in (1,2,3,4))
--insert into student values(119,'Harish',17,'Chennai',1) --error because age conflicts
insert into student values(119,'Harish',19,'Chennai',1)
alter table student add constraint defcourseid default 2 for courseid
insert into student values(120,'Mahi',21,'Chennai',default)
insert into student values(126,'Mahi',21,'Chennai',default)

--stored procedure
create proc spselect
as
select * from student

execute spselect

create proc spinsert(@regno int,@sname varchar(20),@age int,@city varchar(20),@courseid int)
as
insert into student values(@regno,@sname,@age,@city,@courseid)

execute spinsert 87,'Varun',21,'Chennai',3

create proc spselect_1(@regno int)
as 
select * from student where regno = @regno

execute spselect_1 87

alter proc spinsert_def(@regno int,@sname varchar(20),@age int,@city varchar(20))
as
insert into student values(@regno,@sname,@age,@city,default)

execute spinsert_def 107,'Sowmya',21,'Pune'

