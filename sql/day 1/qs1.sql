create database department
use department

create table department(Department_id int,Department_name varchar(5), department_block_number int)
insert into department values(3,'SE',3)

select * from department

--query

select Department_name from department where department_block_number = 3 order by Department_name