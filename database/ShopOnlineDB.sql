
use master
go

create database ShopOnline
go

use ShopOnline
go

CREATE TABLE [dbo].[AccountType](
	[id] [int] primary key,
	[name] [varchar](200) NULL
)
Go

INSERT [dbo].[AccountType] ([id], [name]) VALUES (1, N'admin')
INSERT [dbo].[AccountType] ([id], [name]) VALUES (2, N'endUser')
go

CREATE TABLE [dbo].[Account](
	[userName] [varchar](200) NOT NULL primary key,
	[passWord] [varchar](100) not NULL,
	[typeId] [int]  references AccountType(id) ,
	name nvarchar(200) null,
	dateOfBirth datetime null,
	email nvarchar(200) null,
	phone varchar(10) null
)
go

INSERT [dbo].[Account] ([userName], [passWord], [typeId]) VALUES (N'admin ', N'123456', 1)
INSERT [dbo].[Account] ([userName], [passWord], [typeId]) VALUES (N'user', N'123456', 2)
GO

CREATE TABLE [dbo].[ProductType](
	[id] [int] primary key,
	[name] [varchar](100) NULL,
)
go

INSERT [dbo].[ProductType] ([id], [name]) VALUES (1, N'ao')
INSERT [dbo].[ProductType] ([id], [name]) VALUES (2, N'quan')
go

CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) primary key,
	[name] [varchar](100) NULL,
	[quantity] [int] default (1),
	[price] [float] default (1),
	[supplier] [nvarchar](200) null,
	[productTypeId] [int] references ProductType(id),
	[img0] [varchar](100) NULL,
	[img1] [varchar](100) NULL,
	[img2] [varchar](100) NULL,
	[textInfo] [nvarchar](1000) NULL,
	discount float default 0,
)
GO

INSERT [dbo].[Product] ( [name], [quantity], [price], [supplier], [productTypeId], [img0], [img1], [img2], [textInfo]) 
VALUES 
	( N'aoTrang', 1, 400000, NULL, 1, N'vang1.jpg', N'trang1.jpg', N'trang2.jpg', NULL),
	( N'quanDen', 1, 500000, NULL, 2, N'quanDen0.jpg', N'quanDen1.jpg', N'quanDen2.jpg', NULL),
	(N'quanxanh', 3, 100000, N'abc', 2, N'quanXanh0.jpg', N'quanXanh1.jpg', N'quanXanh2.jpg', NULL),
	 ( N'aovang', 4, 300000, N'bcd', 1, N'vang0.jpg', N'vang1.jpg', N'vang2.jpg', NULL),
	( N'trung', 2, 10, NULL, 1, N'do0.jpg', N'do1.jpg', N'do2.jpg', N'abc'),
	( N'qu?n dùi', 3, 3, N'ad', 2, N'quanDen1.jpg', N'quanDen2.jpg', N'quanDen1.jpg', N'abc')
go

create table TransactionStatus(
	id int primary key,
	name nvarchar(200) null
)
go

insert into TransactionStatus (id,name) 
values
	(1,'chua chuyen'),
	(2,'dang chuyen'),
	(3,'da chuyen')
go

create table Transactions(
	id int identity (1,1) not null primary key,
	createAt dateTime default getdate() not null,
	statusId int references TransactionStatus(id) default(1),
	note nvarchar (500),
	accountId int null,
	name nvarchar(200),
	orderAddress nvarchar(200),
	phone varchar(10),
	email varchar(200),
)
go

create table Orders(
	idProduct int references Product(id),
	idTransaction int references Transactions(id),
	quantity int default 1,
	discount float default 0,
	primary key(idProduct, idTransaction),
)
go

CREATE proc [dbo].[Login]
	@userName varchar(200),
	@passWord varchar(100)
as
begin
	select t.name
	from Account ac
	join AccountType t
		on ac.typeId = t.id
	where ac.userName = @userName and ac.passWord = @passWord
end
go