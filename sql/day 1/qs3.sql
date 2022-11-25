create database cars
use cars

create table cars(car_id varchar(10),car_name varchar(20), car_type varchar(20),owner_name varchar(20))
select * from cars

--query

select car_id,car_name,owner_name from cars where car_type in ('Hatchback','SUV') order by car_id
select car_id,car_name,owner_name from cars where car_type collate SQL_Latin1_General_CP1_CS_AS in ('Hatchback','SUV') order by car_id

select SERVERPROPERTY('collation')

select car_id,car_name,car_type from cars where car_name collate SQL_Latin1_General_CP1_CS_AS in('Maruti Swift') and car_type collate SQL_Latin1_General_CP1_CS_AS in ('Sedan') order by car_id