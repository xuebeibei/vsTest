select * from jobs;

insert into Jobs values(N'主任医师',1);
insert into Jobs values(N'副主任医师',1);
insert into Jobs values(N'主治医师',1);
insert into Jobs values(N'医师',1);
insert into Jobs values(N'医士',1);

insert into Jobs values(N'主任药师',1);
insert into Jobs values(N'副主任药师',1);
insert into Jobs values(N'主管药师',1);
insert into Jobs values(N'药师',1);
insert into Jobs values(N'药士',1);

insert into Jobs values(N'主任护师',1);
insert into Jobs values(N'副主任护师',1);
insert into Jobs values(N'主管护师',1);
insert into Jobs values(N'护师',1);
insert into Jobs values(N'护士',1);

insert into Jobs values(N'主任技师',1);
insert into Jobs values(N'副主任技师',1);
insert into Jobs values(N'主管技师',1);
insert into Jobs values(N'技师',1);
insert into Jobs values(N'技士',1);

update Jobs set JobEnum = 0;
update Jobs set JobEnum = 2 where Name like N'主任%';
update Jobs set JobEnum = 2 where Name like N'副主任%';

update Jobs set JobEnum = 1 where Name like N'主管%';
update Jobs set JobEnum = 1 where Name like N'主治%';


select * from Departments; 

-- 一级医院必备	临床科室
insert into Departments values(N'急诊科','JZK', 0, 1);
insert into Departments values(N'内科','NK', 0, 1);
insert into Departments values(N'外科','WK', 0, 1);
insert into Departments values(N'妇产科','FCK', 0, 1);
insert into Departments values(N'预防保健科','YFBJK', 0, 1);

-- 一级医院必备 医技科室
insert into Departments values(N'药房','YF', 0, 2);
insert into Departments values(N'化验室','HYS', 0, 2);
insert into Departments values(N'X光室','XGS', 0, 2);
insert into Departments values(N'消毒供应室','XDGYS', 0, 2);

select * from Employees;

insert into Employees values(N'张主任', 2,  1, 0, 'ZZR');
insert into Employees values(N'王主任', 2,  1, 0, 'WZR');
insert into Employees values(N'李主任', 2,  1, 1, 'LZR');
insert into Employees values(N'孙医生', 2,  1, 1, 'SZR');


select * from Medicines;

insert into Medicines values(0,N'阿莫西林', N'口服',N'1.33g/片',N'新华制药',0,0,1,0,300,100,1);
insert into Medicines values(0,N'感冒胶囊', N'口服',N'1.33g/粒',N'新华制药',0,0,1,0,300,100,2);
insert into Medicines values(0,N'板蓝根冲剂', N'口服',N'1.33g/包',N'新华制药',0,0,1,0,300,100,8);

select * from MedicineAlias;
-- 别名表

insert into MedicineAlias values('AMXL',3);
insert into MedicineAlias values('AMoXiLin',3);


select * from DosageForms; -- 0 西药，1中成药
-- 剂型表
insert into DosageForms values(N'片剂',0);
insert into DosageForms values(N'胶囊',0);
insert into DosageForms values(N'粉针剂',0);
insert into DosageForms values(N'水剂',0);
insert into DosageForms values(N'颗粒冲剂',0);

insert into DosageForms values(N'大蜜丸',1);
insert into DosageForms values(N'小蜜丸',1);
insert into DosageForms values(N'丹剂',1);


-- 包装表
select * from MedicinePackings;

insert into MedicinePackings values(N'片',0, 0, 3);
insert into MedicinePackings values(N'板',6, 1, 3);
insert into MedicinePackings values(N'盒',2, 2, 3);
insert into MedicinePackings values(N'箱',150, 3, 3);


select * from Patients;
insert into Patients values(N'张三',0,'2000-1-1 00:00:00', 0);
insert into Patients values(N'李四',0,'2000-1-1 00:00:00', 0);
insert into Patients values(N'王五',0,'2000-1-1 00:00:00', 0);
insert into Patients values(N'孙六',0,'2000-1-1 00:00:00', 0);
insert into Patients values(N'赵七',0,'2000-1-1 00:00:00', 0);

select * from SignalSources;
insert into SignalSources values(50, DATEADD(day, 1, GETDATE()), 1, 1, 0 , 20, 0, 0 , 1, N'备注');
insert into SignalSources values(50, DATEADD(day, 1, GETDATE()), 1, 2, 0 , 20, 0, 0 , 1, N'备注');
insert into SignalSources values(50, DATEADD(day, 1, GETDATE()), 1, 3, 0 , 20, 0, 0 , 1, N'备注');
insert into SignalSources values(50, DATEADD(day, 1, GETDATE()), 1, 4, 0 , 20, 0, 0 , 1, N'备注');
insert into SignalSources values(50, DATEADD(day, 1, GETDATE()), 1, 5, 0 , 20, 0, 0 , 1, N'备注');

insert into SignalSources values(50, DATEADD(day, 2, GETDATE()), 0, 1, 0 , 20, 0, 0 , 1, N'备注');
insert into SignalSources values(50, DATEADD(day, 2, GETDATE()), 0, 2, 0 , 20, 0, 0 , 1, N'备注');
insert into SignalSources values(50, DATEADD(day, 2, GETDATE()), 0, 3, 0 , 20, 0, 0 , 1, N'备注');
insert into SignalSources values(50, DATEADD(day, 2, GETDATE()), 0, 4, 0 , 20, 0, 0 , 1, N'备注');
insert into SignalSources values(50, DATEADD(day, 2, GETDATE()), 0, 5, 0 , 20, 0, 0 , 1, N'备注');


select * from Users;
insert into Users values(N'张主任', '111', 0, GETDATE(), 1);
insert into Users values(N'王主任', '111', 0, GETDATE(), 1);
insert into Users values(N'李主任', '111', 0, GETDATE(), 1);
insert into Users values(N'孙医生', '111', 0, GETDATE(), 1);

select * from Recipes;

select * from RecipeDetails;

select * from Registrations;
insert into Registrations values(1, 1, 1, 50, GETDATE(), 0, 0);
insert into Registrations values(2, 1, 1, 50, GETDATE(), 0, 0);
insert into Registrations values(3, 1, 1, 50, GETDATE(), 0, 0);
insert into Registrations values(4, 1, 1, 50, GETDATE(), 0, 0);
insert into Registrations values(5, 1, 1, 50, GETDATE(), 0, 0);

-- 挂号之后要同步挂号表中的号源
update SignalSources set HasUsedNum = 5 where ID = 1;

select * from Triages;
-- 分诊表

select * from Recipes;

delete from Recipes;


