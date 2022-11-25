create database company
use company

create table worker(worker_id int,first_name varchar(20),last_name varchar(20),salary int,joining_date datetime,department varchar(20))
insert into worker values(001,'Monika','Arora',100000,'2014/02/20 09:00:00','HR')
insert into worker values(002,'Niharika','Verma',80000,'2014/06/11 09:00:00','Admin'),
(003,'Vishal','Singhal',300000,'2014/02/20 09:00:00','HR'),
(004,'Amitabh','Singh',500000,'2014/02/20 09:00:00','Admin'),
(005,'Vivek','Bhati',500000,'2014-06-11 09:00:00','Admin'),
(006,'Vipul','Diwan',200000,'2014-06-11 09:00:00','Account'),
(007,'Satish','Kumar',75000,'2014/01/20 09:00:00','Account'),
(008,'Geetika','Chauhan',90000,'2014-04-11 09:00:00','Admin')

select * from worker

create table bonus(worker_ref_id int,bonus_date datetime,bonus_amount int)
insert into bonus values(1,'2016/02/20',5000)


select * from bonus 

create table title(worker_ref_id int,worker_title varchar(20),affected_from datetime)
insert into title values(1,'Manager','2016/02/20'),
(2,'Executive','2016/06/11'),
(8,'Executive','2016/06/11'),
(5,'Manager','2016/06/11'),
(4,'Asst.Manager','2016/06/11'),
(7,'Executive','2016/06/11'),
(6,'Lead','2016/06/11'),
(3,'Lead','2016/06/11')

select * from title

--query 1
select upper(first_name) from worker

--q2
select SUBSTRING(first_name,1,3) from worker

--q3
select rtrim(first_name) from worker

--q4
select ltrim(department) from worker

--q5
select replace(first_name,'a','A') from worker

--q6
select concat(first_name,' ',last_name) as complete_name from worker

--q7
select * from worker order by first_name, department desc

--q8
select * from worker where first_name not in('Vipul','Satish')

--q9
select * from worker where first_name like '%h' and len(first_name)=6

--q10
select * from worker where month(joining_date)=2 and year(joining_date)=2014

--q11
select concat(first_name,' ',last_name) from worker where salary between 50000 and 100000

--q12
select department,count(*) as no_of_workers from worker group by department order by no_of_workers desc

--q13
select * from worker w join title t on w.worker_id = t.worker_ref_id where t.worker_title = 'Manager'

--q14
select department,count(*) from worker group by department having count(*)>1
select worker_ref_id,count(*) from bonus group by worker_ref_id having count(*)>1

--q15
select ROW_NUMBER() from worker 

--q16
select top 3 * from worker
select * from worker limit 3;

--q17
select max(salary) from worker where salary < (select max(salary) from worker)

select max(salary) from worker where salary < (select max(salary) from worker where salary < (select max(salary) from worker))

SELECT salary FROM worker e1 WHERE 4 = (SELECT COUNT(DISTINCT salary) FROM worker e2 WHERE e2.salary > e1.salary)










