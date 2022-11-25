create database libraryDB
use libraryDB

create table books
(
book_id int primary key identity(1,1),
book_title varchar(30),
author_id int,
price int,
genre varchar(20),
rating decimal(2,1),
available_copies int
)

alter table books alter column book_title varchar(40)

select * from books

create proc spinsert(@book_title varchar(30),@author_id int,@price int,@genre varchar(20),@rating decimal(2,1),@available_copies int)
as
insert into books values(@book_title,@author_id,@price,@genre,@rating,@available_copies)

execute spinsert 'Adventures of Tom Sawyer',3,600,'Adventure',3.5,4
execute spinsert 'Alice in Wonderland',6,500,'Fantasy',4.5,3


create table authors
(
aid int primary key identity(11,1),
author_name varchar(30),
books_written varchar(60)
)

insert into authors values('H.G.Wells','Time machine')
insert into authors values('G.B.Shaw','Arms and the Man'),
('Mark Twain','Adventure of Tom Sawyer,The Mysterious Stranger'),
('Rabindranath Tagore','Geetanjali,The Astronomer'),
('George Orwell','Animal Farm,Nineteen eighty four'),
('Lewis Carol','Alice in Wonderland'),
('Thomas Hardy','Far from the madding crowd')

select * from authors

update books set author_id = 17 where author_id=7
exec sp_rename '[authors.authors.aid]','author_id'
--exec sp_rename 'authors.authors.author_id','author_id'
--alter table authors drop column author_id


create table members
(
member_id int primary key identity(100,1),
member_name varchar(30),
address varchar(30)
)

select * from members

create table rent_details(
reader_id int,
book_id int,
book_title varchar(40),
borrow_date date,
return_date date
)

select * from rent_details

alter table rent_details drop column book_title

insert into rent_details values(102,13,'2022/7/1','2022/7/10'),
(105,12,'2022/7/3','2022/7/13'),
(102,14,'2022/7/5','2022/7/15'),
(107,13,'2022/8/6','2022/8/16'),
(101,11,'2022/8/6','2022/8/16'),
(103,17,'2022/10/25','2022/11/5'),
(107,12,'2022/10/25','2022/11/5')

alter table books add constraint fkauthorid foreign key(author_id) references authors([authors.author_id])

alter table rent_details add constraint fkreaderid foreign key(reader_id) references members(member_id)

alter table rent_details add constraint fkbookid foreign key(book_id) references books(book_id)

select * from books
select * from rent_details

update rent_details set book_id =7 where book_id = 17

