﻿USE [master]
GO

WHILE EXISTS(select NULL from sys.databases where name='GARAGEMANAGEMENT')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'GARAGEMANAGEMENT') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [GARAGEMANAGEMENT]
END
GO

CREATE DATABASE GARAGEMANAGEMENT
GO

USE GARAGEMANAGEMENT
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE KHOGARAGE
(
CARNUMBER NVARCHAR(20) NOT NULL,
IDITEM INT NOT NULL, 
ITEM NVARCHAR(50) NULL,
SLITEM INT DEFAULT 0 NULL
)
ALTER TABLE KHOGARAGE
ADD CONSTRAINT PK_KHOGARAGE PRIMARY KEY (CARNUMBER, IDITEM)

CREATE TABLE HOSOKHACHHANG
(
ID INT NOT NULL,
CUSTOMERNAME NVARCHAR(100) NOT NULL,
CARNUMBER NVARCHAR(20) NOT NULL,
CARBRAND NVARCHAR(50) NOT NULL,
ADDRESS NVARCHAR(100) NOT NULL,
PHONE INT NOT NULL,
CREATEDDATE DATETIME2(7) NOT NULL,
DEBT FlOAT DEFAULT 0 NOT NULL
)
ALTER TABLE HOSOKHACHHANG
ADD CONSTRAINT PK_HOSOKHACHHANG  PRIMARY KEY (ID, CARNUMBER)

insert dbo.HOSOKHACHHANG ( id , CUSTOMERNAME , CARNUMBER , CARBRAND , ADDRESS, PHONE , CREATEDDATE, DEBT)
values (N'123' , N'Tô Minh Khuê' ,  1752064 , 222 , 67/87 , 123456 , N'20191212' , 120000)

CREATE TABLE PHIEUSUACHUA
(
IDPSC INT NOT NULL ,
CARNUMBER NVARCHAR(20) NOT NULL ,
DETAIL NVARCHAR(2000) NOT NULL,	
IDITEM INT NOT NULL, 
SLITEM INT DEFAULT 0 NULL,
CREATEDDATE DATETIME2(7) NOT NULL,
DONGIA FlOAT NULL DEFAULT 0,
TIENCONG FLOAT NOT NULL DEFAULT 0,
TOTAL FLOAT NOT NULL DEFAULT 0
)
ALTER TABLE PHIEUSUACHUA
ADD CONSTRAINT PK_PHIEUSUACHUA PRIMARY KEY (IDPSC, CARNUMBER, IDITEM)
ALTER TABLE PHIEUSUACHUA
ADD CONSTRAINT FK_HOSOKHACHHANG_PHIEUSUACHUA FOREIGN KEY (IDPSC, CARNUMBER) REFERENCES HOSOKHACHHANG(ID, CARNUMBER) on delete cascade
ALTER TABLE PHIEUSUACHUA
ADD CONSTRAINT FK_PHIEUSUACHUA_KHOGARAGE FOREIGN KEY (CARNUMBER, IDITEM) REFERENCES KHOGARAGE(CARNUMBER, IDITEM) on delete cascade

CREATE TABLE PHIEUTHUTIEN
(
IDPTT INT NOT NULL,
CUSTOMERNAME NVARCHAR(100) NOT NULL,
CARNUMBER NVARCHAR(20)NOT NULL ,
IDITEM INT NOT NULL, 
SLITEM INT DEFAULT 0 NULL,
PHONE VARCHAR(20) NOT NULL,
EMAIL NVARCHAR(50) NULL,
CREATEDDATE DATETIME2(7) NOT NULL ,
SOTIENTHU FLOAT NOT NULL DEFAULT 0,
DEBT FLOAT NOT NULL DEFAULT 0
)
ALTER TABLE PHIEUTHUTIEN
ADD CONSTRAINT PK_PHIEUTHUTIEN PRIMARY KEY (IDPTT, CARNUMBER, IDITEM)
ALTER TABLE PHIEUTHUTIEN
ADD CONSTRAINT FK_HOSOKHACHHANG_PHIEUTHUTIEN FOREIGN KEY (IDPTT, CARNUMBER) REFERENCES HOSOKHACHHANG(ID, CARNUMBER) ;
go
ALTER TABLE PHIEUTHUTIEN
ADD CONSTRAINT FK_PHIEUSUACHUA_PHIEUTHUTIEN FOREIGN KEY (IDPTT, CARNUMBER, IDITEM) REFERENCES PHIEUSUACHUA(IDPSC, CARNUMBER, IDITEM);
go

CREATE TABLE STAFF
(
	ID INT NOT NULL ,
	FULLNAME NVARCHAR(100) NOT NULL,
	BIRTHDAY DATETIME2(7) NULL,
	ADDRESS NVARCHAR(100) NOT NULL,
	SEX NVARCHAR(10) CHECK  (SEX = N'NAM' OR SEX = N'NỮ') NOT NULL,
	PHONE VARCHAR(20) NOT NULL,
	BASICSALARY FLOAT NOT NULL,
	ADDITIONALSALARY FLOAT NULL,
	TOTALSALARY FLOAT NULL
)
ALTER TABLE STAFF
ADD CONSTRAINT PK_STAFF PRIMARY KEY (ID)


CREATE TABLE ACCOUNT
(
	ID INT NOT NULL ,
	USERNAME NVARCHAR(20) NOT NULL,
	PASSWORD NVARCHAR(100) NOT NULL,
	ACCESSLEVEL INT NOT NULL 
)
ALTER TABLE ACCOUNT
ADD CONSTRAINT PK_ACCOUNT PRIMARY KEY(ID, USERNAME)
ALTER TABLE ACCOUNT
ADD CONSTRAINT FK_ACCOUNT_STAFF FOREIGN KEY (ID) REFERENCES STAFF(ID) on delete cascade

insert into STAFF values ('1', 'Administrator', '08/07/1999', 'KTXzoneB', N'NAM', '0909545454', 9000000, 3000000, 12000000)
insert into STAFF values ('2', 'Staff user', '12/12/2000', 'Q5', N'NỮ', '0909595959', 6000000, 1500000, 7500000)
delete ACCOUNT
insert into ACCOUNT values ('1', 'admin', '1', 1)
insert into ACCOUNT values ('2', 'user', '2', 0)

GO
CREATE PROC USP_GetAccountByUsername
@userName NVARCHAR(20)
AS 
BEGIN
SELECT * FROM ACCOUNT WHERE USERNAME = @userName 
END
 
GO
CREATE PROC USP_Login
@userName NVARCHAR(20), @password NVARCHAR(100)
AS 
BEGIN
SELECT * FROM ACCOUNT WHERE USERNAME = @userName AND PASSWORD = @password
END


CREATE FUNCTION [dbo].[GetUnsignString](@strInput NVARCHAR(4000)) 
RETURNS NVARCHAR(4000)
AS
BEGIN     
    IF @strInput IS NULL RETURN @strInput
    IF @strInput = '' RETURN @strInput
    DECLARE @RT NVARCHAR(4000)
    DECLARE @SIGN_CHARS NCHAR(136)
    DECLARE @UNSIGN_CHARS NCHAR (136)

    SET @SIGN_CHARS       = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'+NCHAR(272)+ NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'

    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
    SET @COUNTER = 1
 
    WHILE (@COUNTER <=LEN(@strInput))
    BEGIN   
      SET @COUNTER1 = 1
      --Tim trong chuoi mau
       WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
       BEGIN
     IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
     BEGIN           
          IF @COUNTER=1
              SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1)                   
          ELSE
              SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)    
              BREAK         
               END
             SET @COUNTER1 = @COUNTER1 +1
       END
      --Tim tiep
       SET @COUNTER = @COUNTER +1
    END
    RETURN @strInput
END
go

