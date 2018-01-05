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

insert into Medicines values(1,N'牛黄清心丸',N'口服',N'3g/丸',N'北京同仁堂',0,0,1,0,300,100,6);




select * from MedicineAlias;
-- 别名表

insert into MedicineAlias values('AMXL',3);
insert into MedicineAlias values('AMoXiLin',3);
insert into MedicineAlias values('NHQXW', 6);


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

insert into MedicinePackings values(N'丸',0,0,6);
insert into MedicinePackings values(N'瓶',10,5,6);



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

select * from RecipeDetails;

delete from RecipeDetails;


select * from MedicalRecords;

delete from MedicalRecords;


select * from TherapyItems;

insert into TherapyItems values(N'氧气吸入', 'YQXR', null, 1.6);

update TherapyItems set Unit  = N'小时';

select * from Therapies;

select * from TherapyDetails;

select * from AssayItems;
--insert into AssayItems values(N'血浆黏度测定','XJNDCD', NULL, 6.4, 1, N'项');

--delete from AssayItems;
insert into AssayItems values(N'血细胞分析','XXBFX', NULL, 0.8000, 1, N'项');
insert into AssayItems values(N'血流变','XLB', NULL, 56.0000	, 1, N'次');
insert into AssayItems values(N'血沉	','XC', NULL, 16.0000, 1, N'次');
insert into AssayItems values(N'血脂四项','XZSX', NULL, 25.6000, 1, N'次');
insert into AssayItems values(N'血型','XX', NULL, 9.6000	, 1, N'次');
insert into AssayItems values(N'血栓性外痔切除术','XSXWZQCS', NULL, 192.0000, 1, N'次');
insert into AssayItems values(N'血细胞分析（11项以上每增一项指标加收）','XXBFX11XYSMZYXZBJS', NULL, 	0.4800, 1, N'项');
insert into AssayItems values(N'血浆粘度测定','XJZDCD', NULL, 	6.4000, 1, N'项');
insert into AssayItems values(N'血清直接胆红素测定干化学法	','XQZJDHSCDGHXF', NULL, 6.4000, 1, N'次');
insert into AssayItems values(N'血清总胆红素测定干化学法','XQZDHSCDGHXF', NULL, 6.4000	, 1, N'次');
insert into AssayItems values(N'血清丙氨酸氨基转移酶测定干化学法','XQBASAJZYMCDGHXF', NULL, 6.4000	, 1, N'次');
insert into AssayItems values(N'血清天门冬氨酸氨基转移酶测定干化学法','XQTMDASAJZYMCDGHXF', NULL, 6.4000	, 1, N'次');
insert into AssayItems values(N'血清总蛋白测定干化学法','XQZDBCDGHXF', NULL, 4.8000	, 1, N'次');
insert into AssayItems values(N'血清白蛋白测定干化学法','XQBDBCDGHXF', NULL, 4.8000	, 1, N'次');
insert into AssayItems values(N'血清总胆汁酸测定干化学法','XQZDZSCDGHXF', NULL, 9.6000	, 1, N'次');
insert into AssayItems values(N'血清尿酸测定','XQNSCD', NULL, 	3.2000	, 1, N'次');
insert into AssayItems values(N'血清总胆固醇测定干化学法','XQZDGCCDGHXF', NULL, 6.4000	, 1, N'次');
insert into AssayItems values(N'血清甘油三酯测定干化学法','XQGYSZCDGHXF', NULL, 6.4000	, 1, N'次');
insert into AssayItems values(N'血清高密度脂蛋白胆固醇测定','XQGMDZDBDGCCD	', NULL, 6.4000	, 1, N'次');
insert into AssayItems values(N'血清低密度脂蛋白胆固醇测定干化学法','XQDMDZDBDGCCDGHXF', NULL, 6.4000	, 1, N'次');
insert into AssayItems values(N'血浆凝血酶原时间测定(PT)（仪器法）','XJNXMYSJCDPTYQF', NULL, 15.0000	, 1, N'次');
insert into AssayItems values(N'血浆纤维蛋白原测定（仪器法）','XJXWDBYCDYQF', NULL, 12.8000	, 1, N'次');
insert into AssayItems values(N'血浆纤维蛋白原测定','XJXWDBYCD', NULL, 12.0000	, 1, N'次');
insert into AssayItems values(N'血小板粘附功能测定(PAdT)（流式细胞仪法）','	XXBZFGNCDPADTLSXBYF', NULL, 12.8000	, 1, N'次');

insert into AssayItems values(N'尿常规检查','NCGJC', NULL, 2.4000, 2, N'次');
insert into AssayItems values(N'尿素测定干化学法','NSCDGHXF', NULL, 4.8000, 2, N'次');
insert into AssayItems values(N'尿液分析','NYFX', NULL, 4.8000, 2, N'次');
insert into AssayItems values(N'尿妊娠','NRS', NULL, 9.0000, 2, N'次');
insert into AssayItems values(N'尿道狭窄扩张术','	NDXZKZS', NULL, 20.0000, 2, N'次');

insert into AssayItems values(N'便常规','BCG', NULL, 5.0000, 3, N'次');

select * from Assays;
select * from AssayDetails;

select * from Specimen;

insert into Specimen values(N'血液', 'XY', NULL);
insert into Specimen values(N'尿液', 'NY', NULL);
insert into Specimen values(N'粪便', 'FB', NULL);
insert into Specimen values(N'唾液', 'TY', NULL);

select * from BodyRegions;
--delete from BodyRegions;
insert into BodyRegions values(N'腹部','FB',NULL);
insert into BodyRegions values(N'胃肠道', 'WCD', NULL);

select * from InspectItems;
delete from InspectItems;
insert into InspectItems values(N'B超常规检查（腹部）','BCCGJCFB', NULL, 20.8000, N'次',2);
insert into InspectItems values(N'B超常规检查（胃肠道、泌尿系）','BCCGJCWCDMNX', NULL, 20.8000, N'次', 3);



select * from Inspects;
select * from InspectDetails;

select * from Patients;
select * from Inpatients;

insert into Inpatients values('001',1,GETDATE(), 1);
insert into Inpatients values('002',2,GETDATE(), 1);
insert into Inpatients values('003',3,GETDATE(), 1);

select * from Employees;
select * from Responsibilities;
insert into Responsibilities values(1,4, GETDATE());
insert into Responsibilities values(2,4, GETDATE());
insert into Responsibilities values(3,4, GETDATE());

select * from MaterialBills;

select * from OtherServices;

select * from medicineInStores;
delete from medicineInStores;

select * from MedicineInStoreDetails;

select * from MedicineBatches;

select * from Suppliers;

insert into Suppliers values(N'中国制药','ZGZY',NULL, NULL, NULL,NULL,NULL);

select * from StoreRooms;

insert into StoreRooms values(N'总药库',NULL,NULL,NULL,0,NULL,NULL,NULL);

select * from StoreRoomMedicineNums;
update StoreRoomMedicineNums set SupplierID = 1;
