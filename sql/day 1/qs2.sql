create database fooddelivery
use fooddelivery

create table delivery_partners(partner_id varchar(10),partner_name varchar(20),phone_no bigint,rating int)

select * from delivery_partners

--query

select partner_id,partner_name,phone_no from delivery_partners where rating between 3 and 5
order by partner_id

