USE [master]
GO

WHILE EXISTS(select NULL from sys.databases where name='QLGARA')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'QLGARA') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [QLGARA]
END
GO


CREATE DATABASE [QLGARA]
GO

USE [QLGARA]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create table chuxe(
	
	machuxe int identity primary key not null,
	name nvarchar(1000) not null,
	dienthoai int not null,
	diachi nvarchar (1000),
	email nvarchar (1000)
)
go

create table hieuxe
(
	mahieuxe int identity primary key not null,
	tenhieuxe nvarchar (1000) not null
) 
go

create table xe
(
	maxe int identity primary key not null,
	bienso int not null,
	ngaytiepnhan Datetime not null,
	mahieuxe int foreign key references hieuxe(mahieuxe),
	machuxe int foreign key references chuxe(machuxe),
)
go


create table phieutiepnhan(
	maphieutiepnhan int identity primary key not null,
	maxe int foreign key references xe(maxe),
	ngaynhan Datetime not null 
)
go


create table phutung(
	maphutung int identity primary key not null,
	tenphutung nvarchar(1000) not null,
	soluong int not null,
	dongia float not null,
)
go

create table tiencong(
	matiencong int identity primary key not null,
	tentiencong nvarchar(1000) not null,
	muctien int not null
)
go

create table phieuthutien(
	maphieuthutien int identity primary key not null,
	ngaythutien Datetime not null,
	sotienthu int null,
	maphieutiepnhan int foreign key references phieutiepnhan(maphieutiepnhan)
)
go

create table doanhso(
	thangdoanhso int identity primary key not null,
	tongdoanhthu float not null,
	soluotsua int  null ,
	mahieuxe int foreign key references hieuxe(mahieuxe),
)
go

create table tonkho(
	thangtonkho int identity primary key not null,
	tondau Datetime not null,
	phatsinh Datetime not null,
	toncuoi Datetime not null,
	maphutung int foreign key references phutung(maphutung),
)
go


create table phieusuachua(
	maphieusuachua int identity primary key not null,
	ngaysuachua Datetime not null,
	noidung nvarchar (1000) not null,
	sothutu int not null,
	tiencong int not null,
	maphutung int foreign key references phutung(maphutung),
	maphieutiepnhan int foreign key references phieutiepnhan(maphieutiepnhan),
	matiencong int foreign key references tiencong(matiencong)
)
go



