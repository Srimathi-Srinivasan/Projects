create database ClinicManagementSystem
use ClinicManagementSystem

--User details table

create table UserDetails(username varchar(10),FirstName varchar(20),LastName varchar(20),Password varchar(15))
alter table UserDetails add constraint chkpassword check(Password like '%@%' and len(Password) >= 8 and len(Password) <= 15)
--alter table UserDetails drop constraint chkpassword

alter table UserDetails add constraint chkusername check(len(username) <= 10)

insert into UserDetails values('AB101','Srimathi','Srinivasan','Sri1930217@')
insert into UserDetails values('AB102','Arun','Prakash','Arun@123')
insert into UserDetails values('AB103','Sathya','K','@sat756*')
insert into UserDetails values('AB104','Shruthi','Narayanan','abc@12345')

select * from UserDetails 
create proc spuserdetails(@username varchar(10),@password varchar(15))
as 
select * from UserDetails where username = @username and Password = @password

exec spuserdetails 'aB101','sri1930217@'

select SERVERPROPERTY('collation')

alter proc spuserdetails(@username varchar(10),@password varchar(15))
as 
select * from UserDetails where username = @username and Password  = @password collate SQL_Latin1_General_CP1_CI_AS 

--Doctors table

create table Doctors(DoctorID int identity(1001,1),FirstName varchar(20),LastName varchar(20),Sex varchar(6),Specialization varchar(20),_From DateTime,_To DateTime)
alter table Doctors alter column _From Time
alter table Doctors alter column _To Time

create proc spviewdoctors
as
select * from Doctors

--select datediff(hour,select _To from Doctors where DoctorID = 1001,select _From from Doctors where DoctorID = 1001)
select DATEDIFF(hour,'07:00','09:00')
alter table Doctors add TotalHrs int


update Doctors set TotalHrs = Datediff(hour,_From,_To)
insert into Doctors values('Joseph','Alan','M','Pediatrics','05:00','08:00',3)
--timestampdiff(second,select _To from Doctors where DoctorID = 1001,select _From from Doctors where DoctorID = 1001) as difference

--Patient table

create table Patients(PatientID int identity(2001,1),FirstName varchar(20),LastName varchar(20),Sex varchar(6),Age int,DOB Date)

select * from Patients
alter table Patients alter column PatientID int not null
alter table Patients add primary key(PatientID) 

create proc spaddpatients(@FirstName varchar(20),@LastName varchar(20),@Sex varchar(6),@Age int,@DOB Date)
as
insert into Patients values(@FirstName,@LastName,@Sex,@Age,@DOB)

--Appointment Table

create table AppointmentSchedule(AppointmentID int identity(1,1) primary key,PatientID int,SpecializationRequired varchar(20),Doctor varchar(30),VisitDate Date,AppointmentTime Time)

select * from AppointmentSchedule
alter table AppointmentSchedule add foreign key(PatientID) references Patients(PatientID)

create proc spschappointment
(
@PatientID int,
@SpecializationRequired varchar(20),
@Doctor varchar(30),
@VisitDate Date,
@AppointmentTime Time)
as
insert into AppointmentSchedule values(@PatientID,@SpecializationRequired,@Doctor,@VisitDate,@AppointmentTime)

exec spschappointment 1,'General','Joseph T','08/27/2022','5:00'

select * from AppointmentSchedule
Truncate table AppointmentSchedule

alter table AppointmentSchedule add DoctorID int

--get doctors

create proc spgetdoctors(@Specialization varchar(20))
as
select * from Doctors where Specialization = @Specialization

create proc sptotalhrs(@DoctorID int)
as
select TotalHrs from Doctors where DoctorID = @DoctorID

exec sptotalhrs 1001

alter proc sptotalhrs(@DoctorID int)
as
select TotalHrs,_From from Doctors where DoctorID = @DoctorID

select * from AppointmentSchedule where DoctorID = 1002 and VisitDate = '08/27/2022'

alter table AppointmentSchedule alter column AppointmentTime varchar(10)
alter table AppointmentSchedule alter column AppointmentTime Time

alter table AppointmentSchedule add SlotNumber int

create proc spgetslots(@DoctorID int,@VisitDate date)
as
select SlotNumber from AppointmentSchedule where DoctorID = @DoctorID and VisitDate = @VisitDate

insert into AppointmentSchedule values(2002,'General',(select FirstName + ' ' + LastName from Doctors where DoctorID = 1001),'08/29/2022','07:00',1001,1)

alter proc spschappointment(@PatientID int,@Specialization varchar(20),@VisitDate Date,@AppointmentTime Time,@DoctorID int,@SlotNumber int)
as
insert into AppointmentSchedule values(@PatientID,@Specialization,(select FirstName + ' ' + LastName from Doctors where DoctorID = @DoctorID),@VisitDate,@AppointmentTime,@DoctorID,@SlotNumber)

exec spschappointment 2001,'General','08/28/2022','09:00',1001,5


--Check patient 

create proc spchkpatient(@PatientID int)
as
select * from Patients where PatientID = @PatientID

exec spchkpatient 2001

--Check Appointment
create proc spchkappointment(@PatientID int,@AppointmentDate Date) 
as
select * from AppointmentSchedule where PatientID = @PatientID and VisitDate = @AppointmentDate

exec spchkappointment 2001,'08/27/2022'

--cancel Appointment
create proc spcancelappointment(@AppointmentID int)
as
delete from AppointmentSchedule where AppointmentID = @AppointmentID

exec spcancelappointment 1