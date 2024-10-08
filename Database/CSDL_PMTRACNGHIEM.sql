create database tracnghiem
go
use tracnghiem1
go
create table monhoc
(
MAMONHOC CHAR(20),
TENMONHOC NVARCHAR(100),
TGTHI INT,
CONSTRAINT PK_MAMH PRIMARY KEY(MAMONHOC)
)
go
create table iddethi
(
madethi CHAR(20),
constraint pk_madethi_ndch primary key(madethi)
)
create table cauhoi
(
noidung nvarchar(100),
DA1 NVARCHAR(100),
DA2 NVARCHAR(100),
DA3 NVARCHAR(100),
DA4 NVARCHAR(100),
DA NVARCHAR(100),
MAMONHOC CHAR(20) NOT NULL,
DAPAN nvarchar(100) not null,
madethi CHAR(20) not null,
CONSTRAINT PK_ND PRIMARY KEY(noidung,MAMONHOC,madethi),
CONSTRAINT FK_MAMH_CAUHOI FOREIGN KEY(MAMONHOC) REFERENCES monhoc(MAMONHOC),
CONSTRAINT FK_MAdethi_CAUHOI FOREIGN KEY(MADETHI) REFERENCES iddethi(madethi)
)
go
create table cauhoidachon
(
noidungdachon nvarchar(100),
DA nvarchar(100) default('0'),
MAMONHOC CHAR(20) NOT NULL,
DAPAN nvarchar(100) not null,
madethi char(20) not null
constraint pk_noidungdachon primary key(noidungdachon,MAMONHOC,madethi),
constraint fk_madethicauhoidachon foreign key(madethi) references iddethi(madethi)
)
go
-- thêm sau: câu hỏi của giáo viên nào ?
create table giaovien
(
MAGV CHAR(20),
TENGIAOVIEN NVARCHAR(100),
GIOITINH NCHAR(3),
NGAYSINH DATETIME,
MAMONHOC CHAR(20),
CONSTRAINT PK_MAGV PRIMARY KEY(MAGV),
CONSTRAINT FK_MAMONHOC FOREIGN KEY(MAMONHOC) REFERENCES monhoc(MAMONHOC) 
)
go
create table hinhgv
(
IDHINH int identity(1,1),
HINH image,
MAGV CHAR(20),
CONSTRAINT PK_IDHINH PRIMARY KEY(IDHINH),
CONSTRAINT FK_HINHGV FOREIGN KEY(MAGV) REFERENCES giaovien(MAGV)
)
go
create table thisinh
(
MATS CHAR(20),
TENTHISINH NVARCHAR(100),
GIOITINH NCHAR(3),
NGAYSINH DATETIME
CONSTRAINT PK_MATS PRIMARY KEY(MATS),
)
go
create table hinhts
(
IDHINH int identity(1,1),
HINH image,
MATS CHAR(20),
CONSTRAINT PK_IDHINHTS PRIMARY KEY(IDHINH),
CONSTRAINT FK_HINHTS FOREIGN KEY(MATS) REFERENCES thisinh(MATS)
)
go
create table taikhoan
(
TENTK VARCHAR(30),
MATKHAU VARCHAR(30),
IDTAIKHOAN CHAR(20),
QUYEN NVARCHAR(50) CHECK(QUYEN='GV' OR QUYEN='TS'),
CONSTRAINT PK_TENTK PRIMARY KEY(TENTK)
)
GO
create table phieudiem
(
maphieudiem int identity(1,1),
monthi nvarchar(50),
madethi char(20) not null,
tongsocau int,
socaudung int,
socausai int,
tongdiem float,
MATS CHAR(20),
MAGV CHAR(20),
CONSTRAINT PK_MAPHIEUDIEM PRIMARY KEY(maphieudiem),
constraint fk_matsPD foreign key(MATS) REFERENCES thisinh(MATS),
constraint fk_gvPD foreign key(MAGV) REFERENCES giaovien(MAGV),
)
GO
--Trigger tự động update
create trigger TG_Update on cauhoi
for insert
as
begin
declare @noidung nvarchar(100),@da nvarchar(100),@MAMONHOC CHAR(20),@DAPAN NVARCHAR(50),@madethi char(20)
set @noidung=(select noidung from inserted)
set @da='0'
set @MAMONHOC=(select MAMONHOC FROM inserted)
set @DAPAN=(select DAPAN from inserted)
set @madethi=(select madethi from inserted)
insert into cauhoidachon(noidungdachon,DA,MAMONHOC,DAPAN,madethi) values(@noidung,@da,@MAMONHOC,@DAPAN,@madethi)
end
go

--------------------------------------------------------------
--Procedure table cauhoi
create procedure Load_CauHoi
@MAMONHOC CHAR(20),@MADETHI CHAR(20)
as
begin
 SELECT * FROM cauhoi WHERE MAMONHOC=@MAMONHOC AND madethi=@MADETHI
end
go
create procedure Insert_CauHoi
@NOIDUNG NVARCHAR(100),@DA1 NVARCHAR(100),@DA2 NVARCHAR(100),@DA3 NVARCHAR(100),@DA4 NVARCHAR(100),@DA NVARCHAR(100),@MAMONHOC CHAR(20),@DAPAN NVARCHAR(100),@MADETHI CHAR(20)
as
begin
 INSERT INTO cauhoi(noidung,DA1,DA2,DA3,DA4,DA,MAMONHOC,DAPAN,madethi) VALUES(@NOIDUNG,@DA1,@DA2,@DA3,@DA4,@DA,@MAMONHOC,@DAPAN,@MADETHI)
end
go
create procedure Update_CauHoi
@NOIDUNG NVARCHAR(100),@NOIDUNGOLD NVARCHAR(100),@DA1 NVARCHAR(100),@DA2 NVARCHAR(100),@DA3 NVARCHAR(100),@DA4 NVARCHAR(100),@DA NVARCHAR(100) ,@DAPAN CHAR(20)
as
begin
 UPDATE cauhoi SET noidung=@NOIDUNG,DA1=@DA1,DA2=@DA2,DA3=@DA3,DA4=@DA4,DA=@DA,DAPAN=@DAPAN WHERE noidung=@NOIDUNGOLD
end
go


create procedure Delete_CauHoi
@NOIDUNG NVARCHAR(100)
as
begin
 DELETE cauhoi WHERE noidung=@NOIDUNG
end
go
--------------------------------------------------
--Procedure table thisinh
create procedure Load_ThiSinh
as
begin
 SELECT * FROM thisinh
end
go

create procedure Insert_ThiSinh
@MATS CHAR(20),@TENTHISINH NVARCHAR(100),@GIOITINH NCHAR(3),@NGAYSINH DATE
as
begin
 INSERT INTO thisinh(MATS,TENTHISINH,GIOITINH,NGAYSINH) VALUES(@MATS,@TENTHISINH,@GIOITINH,@NGAYSINH)
end
go

create procedure Update_ThiSinh
@MATS CHAR(20),@MATSOLD CHAR(20),@TENTHISINH NVARCHAR(100),@GIOITINH NCHAR(3),@NGAYSINH DATE
as
begin
 UPDATE thisinh SET MATS=@MATS,TENTHISINH=@TENTHISINH,GIOITINH=@GIOITINH,NGAYSINH=@NGAYSINH WHERE MATS=@MATSOLD
end
go

create procedure Delete_ThiSinh
@MATS CHAR(20)
as
begin
 DELETE FROM thisinh WHERE MATS=@MATS
end
go

create procedure Insert_HinhThiSinh
@HINH IMAGE,@MATS CHAR(20)
as
begin
 INSERT INTO hinhts(HINH,MATS) VALUES(@HINH,@MATS)
end
go

create procedure Update_HinhThiSinh
@ID int,@HINH IMAGE,@MATS CHAR(20)
as
begin
 UPDATE hinhts SET HINH=@HINH,MATS=@MATS WHERE IDHINH=@ID
end
go

create procedure Delete_HinhThiSinh
@ID INT
as
begin
 DELETE FROM hinhts where IDHINH=@ID
end
go
---------------------------------------------------------
--Procedure table giaovien
create procedure Load_GiaoVien
as
begin
 SELECT * FROM giaovien
end
go
create procedure Insert_GiaoVien
@MAGV CHAR(20),@TENGIAOVIEN NVARCHAR(100),@GIOITINH NCHAR(3),@NGAYSINH DATE,@MAMONHOC CHAR(20)
as
begin
 INSERT INTO giaovien(MAGV,TENGIAOVIEN,GIOITINH,NGAYSINH,MAMONHOC) VALUES(@MAGV,@TENGIAOVIEN,@GIOITINH,@NGAYSINH,@MAMONHOC)
end
go
create procedure Update_GiaoVien
@MAGV CHAR(20),@MAGVOLD CHAR(20),@TENGIAOVIEN NVARCHAR(100),@GIOITINH NCHAR(3),@NGAYSINH DATE,@MAMONHOC CHAR(20)
as
begin
 UPDATE giaovien SET MAGV=@MAGV,TENGIAOVIEN=@TENGIAOVIEN,GIOITINH=@GIOITINH,NGAYSINH=@NGAYSINH,MAMONHOC=@MAMONHOC WHERE MAGV=@MAGVOLD
end
go
create procedure Delete_GiaoVien
@MAGV CHAR(20)
as
begin
 DELETE FROM giaovien WHERE MAGV=@MAGV
end
go
create procedure Insert_HinhGiaoVien
@HINH IMAGE,@MAGV CHAR(20)
as
begin
 INSERT INTO hinhgv(HINH,MAGV) VALUES(@HINH,@MAGV)
end
go
create procedure Update_HinhGiaoVien
@ID int,@HINH IMAGE,@MAGV CHAR(20)
as
begin
 UPDATE hinhgv SET HINH=@HINH,MAGV=@MAGV WHERE IDHINH=@ID
end
go
create procedure Delete_HinhGiaoVien
@ID int
as
begin
 DELETE FROM hinhgv WHERE IDHINH=@ID
end
go

---------------------------------------------------------
--Procedure table MONHOC
create procedure Load_MonHoc
as
begin
 select * from monhoc
end
go
create procedure Load_MonHocWith_Where
@MAMONHOC CHAR(20)
as
begin
 select distinct monhoc.MAMONHOC,monhoc.TENMONHOC,monhoc.TGTHI,iddethi.madethi from iddethi inner join cauhoi on iddethi.madethi=cauhoi.madethi inner join monhoc on cauhoi.MAMONHOC=monhoc.MAMONHOC WHERE monhoc.MAMONHOC=@MAMONHOC
end
go
create procedure Insert_MonHoc
@MAMONHOC CHAR(20),@TENMONHOC NVARCHAR(100)
as
begin
 INSERT INTO monhoc(MAMONHOC,TENMONHOC) VALUES(@MAMONHOC,@TENMONHOC)
end
go
create procedure Update_MonHoc
@MAMONHOC CHAR(20),@MAMONHOCOLD CHAR(20),@TENMONHOC NVARCHAR(100)
as
begin
 UPDATE monhoc SET MAMONHOC=@MAMONHOC,TENMONHOC=@TENMONHOC WHERE MAMONHOC=@MAMONHOCOLD
end
go
create procedure Delete_MonHoc
@MAMONHOC CHAR(20)
as
begin
 DELETE FROM monhoc WHERE MAMONHOC=@MAMONHOC
end
go
-------------------------------------------------------------------
--Procedure table TAIKHOAN
create procedure Load_TaiKhoan
as
begin
 SELECT * FROM taikhoan
end
go
create procedure Insert_TaiKhoan
@TENTK VARCHAR(30),@MATKHAU VARCHAR(30),@IDTAIKHOAN CHAR(20),@QUYEN NVARCHAR(50)
as
begin
 INSERT INTO taikhoan(TENTK,MATKHAU,IDTAIKHOAN,QUYEN) VALUES(@TENTK,@MATKHAU,@IDTAIKHOAN,@QUYEN)
end
go
create procedure Update_TaiKhoan
@TENTK VARCHAR(30),@MATKHAU VARCHAR(30),@IDTAIKHOAN CHAR(20),@QUYEN NVARCHAR(50)
as
begin
 UPDATE taikhoan SET MATKHAU=@MATKHAU,IDTAIKHOAN=@IDTAIKHOAN,QUYEN=@QUYEN WHERE TENTK=@TENTK
end
go
create procedure Delete_TaiKhoan
@TENTK VARCHAR(30)
as
begin
 DELETE FROM taikhoan WHERE TENTK=@TENTK
end
go
-------------------------------------
--Procedure table cauhoidachon
create procedure Load_CauHoiDaChon
@MAMONHOC CHAR(20),@MADETHI CHAR(20)
as
begin
 SELECT * FROM cauhoidachon WHERE MAMONHOC=@MAMONHOC and madethi=@MADETHI
end
go
create procedure Delete_CauHoiDaChon
@NOIDUNG NVARCHAR(100)
as
begin
DELETE FROM cauhoidachon WHERE noidungdachon=@NOIDUNG
end
go
create procedure Update_CauHoiDaChon
@MAMONHOC CHAR(20),@MADETHI CHAR(20)
as
begin
 UPDATE cauhoidachon SET DA='0' WHERE MAMONHOC=@MAMONHOC AND madethi=@MADETHI
end
go
create procedure Update_CauHoiDaChonRD
@noidung nvarchar(100),@DA NVARCHAR(100)
as
begin
 UPDATE cauhoidachon SET DA=@DA WHERE noidungdachon=@noidung
end
go
---------------------------------
--Procedure table PhieuDiem
create procedure Load_PhieuDiem
@MATS CHAR(20)
as
begin
SELECT phieudiem.MATS,thisinh.TENTHISINH,phieudiem.monthi,phieudiem.madethi,phieudiem.tongsocau,phieudiem.socaudung,phieudiem.socausai,phieudiem.tongdiem  FROM phieudiem inner join thisinh on phieudiem.MATS=thisinh.MATS WHERE phieudiem.MATS=@MATS
end
go
create procedure Insert_PhieuDiem
@monthi nvarchar(50),@tongsocau int,@socaudung int ,@socausai int,@tongdiem float,@MATS CHAR(20),@madethi char(20)
as
begin
 INSERT INTO phieudiem(monthi,tongsocau,socaudung,socausai,tongdiem,MATS,madethi) values(@monthi,@tongsocau,@socaudung,@socausai,@tongdiem,@MATS,@madethi)
end
go

create procedure Delete_PhieuDiem
@MATS CHAR(20)
as
begin
 DELETE FROM phieudiem WHERE MATS=@MATS
end
go
------------------
--Procedure table iddethi
create procedure Insert_Iddethi
@MADETHI CHAR(20)
AS
BEGIN
INSERT INTO iddethi(madethi) values(@MADETHI)
END
GO

create table DSNOPBAI
(
MATHISINH CHAR(20),
MAMONHOC CHAR(20),
TENMONHOC NVARCHAR(100),
SOCAUDUNG INT,
SOCAUSAI INT,
MADETHI CHAR(20),
)
go
create procedure Load_Dsnopbai
as
begin
select thisinh.TENTHISINH,DSNOPBAI.MATHISINH,DSNOPBAI.MAMONHOC,DSNOPBAI.TENMONHOC,DSNOPBAI.SOCAUDUNG,DSNOPBAI.SOCAUSAI,DSNOPBAI.MADETHI,hinhts.HINH from DSNOPBAI inner join hinhts on DSNOPBAI.MATHISINH=hinhts.MATS inner join thisinh on thisinh.MATS=DSNOPBAI.MATHISINH
end
go
--drop procedure Load_Dsnopbai
create procedure Insert_Dsnopbai
@MATHISINH CHAR(20),@MAMONHOC CHAR(20),@TENMONHOC NVARCHAR(100),@SOCAUDUNG INT,@SOCAUSAI INT,@MADETHI CHAR(20)
AS
BEGIN
INSERT INTO DSNOPBAI(MATHISINH,MAMONHOC,TENMONHOC,SOCAUDUNG,SOCAUSAI,MADETHI) VALUES(@MATHISINH,@MAMONHOC,@TENMONHOC,@SOCAUDUNG,@SOCAUSAI,@MADETHI)
END
GO

create procedure Delete_Dsnopbai
@MATHISINH CHAR(20),@madethi char(20),@mamonhoc char(20)
AS
BEGIN
delete from DSNOPBAI where MATHISINH=@MATHISINH and MADETHI=@madethi and mamonhoc=@mamonhoc
END
GO

CREATE PROCEDURE Dem_TongDSNOPBAI
AS
BEGIN
SELECT COUNT(*) FROM DSNOPBAI
END
GO

insert into monhoc(MAMONHOC,TENMONHOC,TGTHI) values('CSDL',N'Cơ sở dữ liệu',60);
insert into monhoc(MAMONHOC,TENMONHOC,TGTHI) values('LTCB',N'Lập trình C',45);
insert into monhoc(MAMONHOC,TENMONHOC,TGTHI) values('LTNC',N'Lập trình C#',90);

insert into iddethi values('001');
insert into iddethi values('002');
insert into iddethi values('003');