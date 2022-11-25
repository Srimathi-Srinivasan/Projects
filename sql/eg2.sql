create database student
use student
create table student_details(name varchar(30),regno int,dept varchar(10),cgpa decimal(4,2),company_placed varchar(20))
select * from student_details
alter table student_details add ctc decimal(4,1)
alter table student_details drop column ctc

insert into student_details values('Nila',112,'EEE',7.5,'CTS')
insert into student_details values('Neha',145,'CS',8.36,'Eurofins'),('Naveen',105,'ECE',9.12,'TCS'),('Santhosh',125,'IT',8.2,'Wipro')

update student_details set cgpa = 8.5 where cgpa > 8.1 and cgpa < 8.5
delete from student_details where cgpa < 8

select name,company_placed from student_details where cgpa > 9
select company_placed,count(*) as no_of_students from student_details group by company_placed having count(*) > 1



