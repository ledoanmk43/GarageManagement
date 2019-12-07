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

create table danhsachxe(
	stt		int,
	bienso	nvarchar(20) primary key,
	hieuxe	nvarchar(50) ,
	chuxe	varchar(50),
	tienno	money
);

create table tiepnhansuaxe(
	tenchuxe	varchar(50),
	bienso		nvarchar(20) foreign key references danhsachxe(bienso),
	hieuxe		nvarchar(50) primary key,
	diachi		nvarchar(50),
	dienthoai	int,
	ngaytiepnhan smalldatetime
);

create table phieusuachua(
	biensoxe		nvarchar(20) foreign key references danhsachxe(bienso),
	ngaysuachua		smalldatetime,
	stt				int,
	noidung			nvarchar(50),
	vattuphutung	nvarchar(50) primary key,
	soluong			int,
	dongia			money,
	tiencong		money,
	thanhtien		money
);

create table phieuthutien(
	hotenchuxe		nvarchar(50),
	bienso			nvarchar(20) foreign key references danhsachxe(bienso),
	dienthoai		int,
	email			nvarchar(50),
	ngaythutien		smalldatetime,
	sothutien		int
);

create table doanhso(
	stt			int,
	hieuxe		nvarchar(50) foreign key references tiepnhansuaxe(hieuxe),
	soluotsua	int,
	thanhtien	money,
	tile		nvarchar(10)
);

create table baocaoton(
	stt				int,
	vattuphutung	nvarchar(50) foreign key references phieusuachua(vattuphutung),
	tondau			nvarchar(50),
	phatsinh		nvarchar(50),
	toncuoi			nvarchar(50)
);