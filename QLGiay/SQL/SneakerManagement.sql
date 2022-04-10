------------------------------SneakerManagement-------------------------------------

CREATE DATABASE SneakerManagement
GO

USE SneakerManagement
GO

select * from ChiTietDonHang
------------------------------------TABLE--------------------------------------------

CREATE TABLE LoaiGiay
(
	ID_LG INT NOT NULL IDENTITY(1,1),
	Ten_LG NVARCHAR(100) NOT NULL,
	Is_Alive BIT NOT NULL DEFAULT 1
)
GO
--delete from LoaiGiay

--select * from HinhG
--select * from Giay

CREATE TABLE HinhG
(
	ID_HG INT NOT NULL IDENTITY(1,1),
	HinhG IMAGE NOT NULL,
	HinhGP NVARCHAR(MAX) NOT NULL,
	ID_G INT NOT NULL
)
GO
--select * from HinhG
--delete from HinhG
CREATE TABLE Giay
(
	ID_G INT NOT NULL IDENTITY(1,1),
	Ten_G NVARCHAR(100) NOT NULL,
	Size CHAR(5) NOT NULL,
	ID_LG INT NOT NULL,
	GiaBan FLOAT NOT NULL,
	SoLuong INT NOT NULL,
	GhiChu NVARCHAR(MAX) NULL,
	Is_Alive BIT NOT NULL DEFAULT 1
)
GO

CREATE TABLE Boss
(
	ID_Boss INT NOT NULL IDENTITY(1,1),
	TenDangNhap NVARCHAR(50) NOT NULL,
	MatKhau NVARCHAR(50) NOT NULL,
)
GO

CREATE TABLE KhachHang
(
	ID_KH INT NOT NULL IDENTITY(1,1),
	HoTen NVARCHAR(50) NOT NULL,
	SDT NVARCHAR(50) NOT NULL,
	DiaChi NVARCHAR(MAX) NULL
)
GO

CREATE TABLE DonHang
(
	ID_DH INT NOT NULL IDENTITY(1,1),
	ID_KH INT NOT NULL,
	ID_GD NVARCHAR(50) DEFAULT NULL, -- NULL: Khách hàng chưa thanh toán tiền OR 'yyyyddmmhhMMss': thời gian hóa đơn được thanh toán
	NgayBanHang DATETIME DEFAULT GETDATE(),
	Discount FLOAT DEFAULT 0
)
GO

CREATE TABLE ChiTietDonHang
(
	ID_CTDH INT NOT NULL IDENTITY(1,1),
	ID_G INT NOT NULL,
	ID_DH INT NOT NULL,
	SoLuongSanPham INT NOT NULL,
)
GO

CREATE TABLE DoanhThu
(
	ID_DH INT NOT NULL ,
	ID_G INT NOT NULL,
	ID_CTDH INT NOT NULL,
	TongTien FLOAT NOT NULL
)
GO
delete DoanhThu
-------------------------------Add Primarykey-------------------------------------
ALTER TABLE LoaiGiay WITH NOCHECK ADD CONSTRAINT PK_LoaiGiay PRIMARY KEY CLUSTERED 
(
	ID_LG ASC 
)
GO

ALTER TABLE HinhG WITH NOCHECK ADD CONSTRAINT PK_HinhG PRIMARY KEY CLUSTERED 
(
	ID_HG ASC 
)
GO

ALTER TABLE Giay WITH NOCHECK ADD CONSTRAINT PK_Giay PRIMARY KEY CLUSTERED 
(
	ID_G ASC 
)
GO

ALTER TABLE Boss WITH NOCHECK ADD CONSTRAINT PK_Boss PRIMARY KEY CLUSTERED 
(
	ID_Boss ASC 
)
GO

ALTER TABLE KhachHang WITH NOCHECK ADD CONSTRAINT PK_KhachHang PRIMARY KEY CLUSTERED 
(
	ID_KH ASC 
)
GO

ALTER TABLE ChiTietDonHang WITH NOCHECK ADD CONSTRAINT PK_ChiTietDonHang PRIMARY KEY CLUSTERED 
(
	ID_CTDH ASC 
)
GO

ALTER TABLE DonHang WITH NOCHECK ADD CONSTRAINT PK_DonHang PRIMARY KEY CLUSTERED 
(
	ID_DH ASC 
)
GO

ALTER TABLE DoanhThu WITH NOCHECK ADD CONSTRAINT Pk_DoanhThu PRIMARY KEY CLUSTERED
(
	ID_CTDH ASC
)
GO

------------------------------Foreign Key----------------------------------------
ALTER TABLE HinhG
ADD CONSTRAINT FK_Giay_HinhG
FOREIGN KEY (ID_G) REFERENCES Giay(ID_G)
GO

ALTER TABLE Giay
ADD CONSTRAINT FK_LoaiGiay_Giay
FOREIGN KEY (ID_LG) REFERENCES LoaiGiay(ID_LG)
GO

ALTER TABLE ChiTietDonHang
ADD CONSTRAINT FK_Giay_ChiTietDonHang
FOREIGN KEY (ID_G) REFERENCES Giay(ID_G)
GO

ALTER TABLE ChiTietDonHang
ADD CONSTRAINT FK_DonHang_ChiTietDonHang
FOREIGN KEY (ID_DH) REFERENCES DonHang(ID_DH)
GO

ALTER TABLE DonHang
ADD CONSTRAINT FK_KhachHang_DonHang
FOREIGN KEY (ID_KH) REFERENCES KhachHang(ID_KH)
GO

ALTER TABLE DoanhThu
ADD CONSTRAINT FK_DonHang_DoanhThu
FOREIGN KEY (ID_DH) REFERENCES DonHang(ID_DH)
GO

ALTER TABLE DoanhThu
ADD CONSTRAINT FK_ChiTietDonHang_DoanhThu
FOREIGN KEY (ID_CTDH) REFERENCES ChiTietDonHang(ID_CTDH)
GO

ALTER TABLE DoanhThu
ADD CONSTRAINT FK_Giay_DoanhThu
FOREIGN KEY (ID_G) REFERENCES Giay(ID_G)
GO

-------------------------------Output Data-------------------------------------

INSERT LoaiGiay(Ten_LG)
VALUES 
	(N'Nike'),
	(N'Adidas'),
	(N'New Balance'),
	(N'ASICS'),
	(N'Fila')
GO
--Select * from LoaiGiay
--DELETE FROM Giay
--WHERE Ten_G = N'Test'

INSERT Giay(Ten_G, ID_LG, Size, SoLuong, GiaBan, GhiChu)
VALUES
	(N'Air Huarache', 1, '41', 100, 88, N'If you good at something, dont do it for free'),
	(N'Nike Flyknit', 1, '36', 100, 59, N'Kneel, you puny creature'),
	(N'Yeezy boot 350 V2', 2, '41', 100, 1000, N'Im not crazy, you are crazy'),
	(N'New Balance 850 Lifestyle Running', 3, '37', 100, 800, N'Why so serious sir'),
	(N'ASICS tiger', 4, '41', 100, 50, N'Smile, even you have to cry'),
	(N'Unisex Fila Filaray Tapey Tape', 5, '41', 100, 150, N'DoucheBag wanna get a free score'),
	(N'Unisex Fila Oakmont Tr', 5, '41', 100, 125, N'Retarder thinks that he is central of the universe'),
	(N'Yeezy boot 700', 2, '41', 100, 1000, N'Keep asking them you will know the true, Master')
GO

--Select * from Giay

--INSERT HinhG(ID_G, HinhGP, HinhG)
--VALUES
--	(1, N'D:/image1.jpg', 0x89504E470D0A1A0A00000),
--	(2, N'D:/image2.jpg', 0x89504E470D0A1A0A00000),
--	(3, N'D:/image3.jpg', 0x89504E470D0A1A0A00000),
--	(4, N'D:/image4.jpg', 0x89504E470D0A1A0A00000),
--	(5, N'D:/image5.jpg', 0x89504E470D0A1A0A00000),
--	(6, N'D:/image6.jpg', 0x89504E470D0A1A0A00000),
--	(7, N'D:/image7.jpg', 0x89504E470D0A1A0A00000),
--	(8, N'D:/image8.jpg', 0x89504E470D0A1A0A00000)
--GO

--Select * from HinhG

INSERT Boss(TenDangNhap, MatKhau)
VALUES
	(N'NGUYENMINHCUONG', N'0'),
	(N'LEPHAMMINHKHOI', N'2'),
	(N'NGUYENTRANVIETANH', N'3'),
	(N'LEDANGKHOA', N'4'),
	(N'Lazy', N'1')
GO

--SELECT * FROM Boss

INSERT KhachHang(HoTen, SDT, DiaChi)
VALUES
	(N'Nguyễn Ngọc Quang', '0798677236', N'Đà Lạt'),
	(N'Nguyễn Danh', '0798677237', N'Đà Lạt'),
	(N'Trần Khánh Ly', '0798677238', N'Đà Lạt')
GO
--SELECT * FROM KhachHang

INSERT DonHang(ID_KH, ID_GD, Discount, NgayBanHang)
VALUES
	(1, '202001121054', 80, GETDATE()),
	(2, '202002121055', 20, GETDATE()),
	(3, '202003122054', 50, GETDATE())
GO
--SELECT * FROM DonHang
--Select * from Giay

INSERT ChiTietDonHang(ID_DH, ID_G, SoLuongSanPham)
VALUES
	(1, 1, 2),
	(1, 2, 2),
	(1, 3, 1),
	(2, 4, 1),
	(2, 5, 2),
	(1, 6, 3),
	(3, 7, 5),
	(3, 8, 1)
GO
--SELECT * FROM DoanhThu
--select * from KhachHang
--SELECT * FROM DonHang
--SELECT * FROM Giay
--SELECT * FROM ChiTietDonHang



INSERT DoanhThu(ID_DH, ID_G, ID_CTDH,TongTien)
VALUES
	(1, 1, 2, 176),--2
	(1, 1, 1, 176),--2
	(1, 3, 3, 3000),--3
	(2, 4, 4, 800),--1
	(2, 5, 5, 100),--2
	(1, 6, 6, 450)--3
GO
------------------------------Procedure------------------------------------

------------------------------Loai-----------------------------------------

CREATE PROCEDURE sp_select_LoaiGiay_All
AS
	BEGIN
		SELECT * FROM dbo.LoaiGiay WHERE Is_Alive = 1
	END
GO
-- EXEC sp_select_LoaiGiay_All
-- GO

CREATE PROCEDURE sp_select_LoaiGiay_by_ID
@ID_LG INT
AS
	BEGIN
		SELECT * FROM dbo.LoaiGiay WHERE [ID_LG] = @ID_LG AND Is_Alive = 1
	END
GO
-- EXEC sp_select_LoaiGiay_by_ID 1
-- EXEC sp_select_LoaiGiay_by_ID 2
-- EXEC sp_select_LoaiGiay_by_ID 3
-- EXEC sp_select_LoaiGiay_by_ID 4
-- EXEC sp_select_LoaiGiay_by_ID 5
-- GO

CREATE PROCEDURE sp_select_Master_LoaiGiay
AS
BEGIN
	SELECT LoaiGiay.ID_LG, COUNT(Giay.SoLuong)  AS SoLuongSanPham, Ten_LG
	FROM Giay JOIN LoaiGiay ON Giay.ID_LG = LoaiGiay.ID_LG
	WHERE Giay.ID_LG = LoaiGiay.ID_LG
	GROUP BY LoaiGiay.ID_LG,Ten_LG
END
GO

-- EXEC sp_select_Master_LoaiGiay
-- GO

CREATE PROCEDURE sp_insert_LoaiGiay
@Ten_LG NVARCHAR(30)
AS
BEGIN
	IF (NOT EXISTS (SELECT * FROM dbo.LoaiGiay WHERE Ten_LG = @Ten_LG))
		INSERT INTO dbo.LoaiGiay (Ten_LG) VALUES (@Ten_LG)
END
GO

-- EXEC sp_insert_LoaiGiay N'Dép tổ ong'
-- EXEC sp_insert_LoaiGiay N'Giày Tabi'
-- EXEC sp_insert_LoaiGiay N'Berserkers Greaves'
-- EXEC sp_insert_LoaiGiay N'Mobility Boots'
-- EXEC sp_insert_LoaiGiay N'Plated Steelcaps'
-- EXEC sp_insert_LoaiGiay N'Sorcerers Shoes'
-- EXEC sp_insert_LoaiGiay N'Mercurys Treads'
-- EXEC sp_insert_LoaiGiay N'Ionian Boots of Lucidity'
-- EXEC sp_insert_LoaiGiay N'Boots of Swiftness'
-- EXEC sp_insert_LoaiGiay N'Slightly Magical Boots'


-- GO
-- SELECT * FROM LoaiGiay
-- GO

CREATE PROCEDURE sp_update_LoaiGiay
@ID_LG INT, @Ten_LG NVARCHAR(30)
AS
BEGIN
	UPDATE dbo.LoaiGiay
	SET
		[Ten_LG] = @Ten_LG
	WHERE ID_LG = @ID_LG AND Is_Alive = 1
END
GO

CREATE PROCEDURE sp_delete_LoaiGiay
@ID_LG INT
AS
BEGIN
	UPDATE LoaiGiay
	SET 
		Is_Alive = 0
	WHERE ID_LG = @ID_LG
END
GO

-- SELECT * FROM LoaiGiay

-- EXEC sp_update_LoaiGiay 6, N'Dép tổ ong'
-- GO
--------------------------------- Hinh Giay ---------------------------------

-- exec sp_select_HinhSanPham 12
-- select * from HinhSanPham

CREATE PROCEDURE sp_select_HinhSanPham
@ID_HG INT
AS
BEGIN
	SELECT *
	FROM HinhG
	WHERE ID_HG = @ID_HG
END
GO

CREATE PROCEDURE sp_select_HinhSanPham_By_ID_Giay
@ID_Giay INT
AS
BEGIN
	SELECT *
	FROM HinhG
	WHERE ID_G = @ID_Giay
END
GO

--select * from Giay
--join HinhG on Giay.ID_G = HinhG.ID_HG

----------------------------------- Giay ------------------------------------

CREATE PROCEDURE sp_select_Giay
AS
BEGIN
	SELECT *
	FROM Giay
	JOIN LoaiGiay ON Giay.ID_LG = LoaiGiay.ID_LG
	WHERE Giay.Is_Alive = 1
END
GO

-- EXEC sp_select_Giay

CREATE PROCEDURE sp_select_Giay_by_ID
@ID_G INT
AS
BEGIN
	SELECT *
	FROM Giay
	JOIN LoaiGiay ON Giay.ID_LG = LoaiGiay.ID_LG
	WHERE Giay.ID_G = @ID_G AND Giay.Is_Alive = 1 AND LoaiGiay.Is_Alive = 1
END
GO

-- EXEC sp_select_Giay_by_ID 1
-- EXEC sp_select_Giay_by_ID 2
-- EXEC sp_select_Giay_by_ID 3
-- EXEC sp_select_Giay_by_ID 4
-- EXEC sp_select_Giay_by_ID 5
-- EXEC sp_select_Giay_by_ID 6

CREATE PROCEDURE sp_select_Giay_by_ID_LG
@ID_LG INT
AS
BEGIN
	SELECT *
	FROM Giay
	JOIN LoaiGiay ON Giay.ID_LG = LoaiGiay.ID_LG
	WHERE LoaiGiay.ID_LG = @ID_LG AND Giay.Is_Alive = 1 AND LoaiGiay.Is_Alive = 1
END
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO

CREATE PROCEDURE sp_select_search_Giay
@TieuChuanTim NVARCHAR(255)
AS
BEGIN
	SELECT *
	FROM Giay
	JOIN LoaiGiay ON Giay.ID_LG = LoaiGiay.ID_LG
	WHERE
		Giay.Is_Alive = 1 AND LoaiGiay.Is_Alive = 1 AND (
			dbo.fuConvertToUnsign1(Ten_LG) LIKE '%' + dbo.fuConvertToUnsign1(@TieuChuanTim) + '%' OR
			dbo.fuConvertToUnsign1(Ten_G) LIKE '%' + dbo.fuConvertToUnsign1(@TieuChuanTim) + '%' OR
			dbo.fuConvertToUnsign1(GhiChu) LIKE '%' + dbo.fuConvertToUnsign1(@TieuChuanTim) + '%'
		)
END
GO


--EXEC sp_select_search_Giay N'a'
-- EXEC sp_select_search_Giay N'b'

CREATE PROCEDURE sp_select_Giay_By_Gia
@GiaThap FLOAT, 
@GiaCao FLOAT
AS
BEGIN
	SELECT *
	FROM Giay
	WHERE (@GiaThap <= GiaBan AND GiaBan <= @GiaCao) AND Giay.Is_Alive = 1
END
GO

-- EXEC sp_select_Giay_By_Gia 100000, 200000

CREATE PROCEDURE sp_insert_Giay
@Ten_G NVARCHAR(100),
@Size CHAR(5),
@GiaBan FLOAT,
@SoLuong INT,
@GhiChu NVARCHAR(MAX),
@ID_LG INT,
@HinhG IMAGE,
@HinhGP NVARCHAR(MAX)
AS
BEGIN
	IF (@ID_LG = NULL OR @ID_LG = '')
		RETURN

	IF (NOT EXISTS(SELECT * FROM LoaiGiay WHERE LoaiGiay.ID_LG = @ID_LG))
		RETURN

	IF (EXISTS (SELECT * FROM Giay WHERE Giay.Ten_G = @Ten_G))
		RETURN

	INSERT Giay(Ten_G, ID_LG, Size, SoLuong, GiaBan, GhiChu)
	VALUES (@Ten_G, @ID_LG, @Size, @SoLuong, @GiaBan, @GhiChu)

	DECLARE @ID_MAX INT
	SELECT @ID_MAX = MAX(ID_G) FROM Giay
	
	INSERT HinhG(ID_G, HinhG, HinhGP)
	VALUES (@ID_MAX, @HinhG, @HinhGP)
END
GO

-- EXEC sp_insert_Giay N'Dép cho mẹ đánh', '36', 20000, 10, 'Damage: 999999', 1, 0x089504E470D0A1A0A00000, 'd:/image24142.jp'

--Cần chỉnh lại
CREATE PROCEDURE sp_update_Giay
@ID_G INT,
@Ten_G NVARCHAR(100),
@Size CHAR(5),
@GiaBan FLOAT,
@SoLuong INT,
@GhiChu NVARCHAR(MAX),
@ID_LG INT,
@ID_HG INT,
@HinhG IMAGE,
@HinhGP NVARCHAR(MAX)
AS
BEGIN
	IF (@ID_LG = NULL OR @ID_LG = '')
		RETURN

	IF (NOT EXISTS(SELECT * FROM LoaiGiay WHERE LoaiGiay.ID_LG = @ID_LG AND LoaiGiay.Is_Alive = 1))
		RETURN

	IF (NOT EXISTS (SELECT * FROM Giay WHERE Giay.ID_G = @ID_G AND Giay.Is_Alive = 1))
		RETURN	

	UPDATE Giay
	SET
		Ten_G = @Ten_G,
		Size = @Size,
		GiaBan = @GiaBan,
		SoLuong = @SoLuong,
		GhiChu = @GhiChu,
		ID_LG = @ID_LG
	WHERE ID_G = @ID_G

	UPDATE HinhG
	SET
		HinhG = @HinhG,
		HinhGP = @HinhGP
	WHERE ID_HG = ID_HG
END
GO

-- SELECT * FROM Giay
-- EXEC sp_update_Giay 9
-- GO
--CREATE PROCEDURE sp_Delete_Giay_By_ID
--@Ten_G NVARCHAR(100),
--@Size CHAR(5),
--@GiaBan FLOAT,
--@SoLuong INT,
--@GhiChu NVARCHAR(MAX),
--@ID_LG INT,
--@HinhG IMAGE,
--@HinhGP NVARCHAR(MAX)
--AS
--BEGIN
--	IF (@ID_LG = NULL OR @ID_LG = '')
--		RETURN

--	IF (NOT EXISTS(SELECT * FROM LoaiGiay WHERE LoaiGiay.ID_LG = @ID_LG))
--		RETURN

--	IF (EXISTS (SELECT * FROM Giay WHERE Giay.Ten_G = @Ten_G))
--		RETURN

	

--	DECLARE @ID_MAX INT
--	SELECT @ID_MAX = MAX(ID_G) FROM Giay
	
--END
--GO

CREATE PROCEDURE sp_delete_Giay
@ID_G INT
AS
BEGIN
	UPDATE Giay
	SET 
		Is_Alive = 0
	WHERE ID_G = @ID_G
END
GO


----------------------------------- Don Hang -----------------------------------

CREATE PROCEDURE sp_select_DonHang_All
AS
	BEGIN
		SELECT  ID_DH, ID_GD, NgayBanHang, Discount, HoTen, SDT, DiaChi
		FROM dbo.DonHang
		JOIN KhachHang ON DonHang.ID_KH = KhachHang.ID_KH
	END	
GO

--EXEC sp_select_DonHang_All

CREATE PROC sp_select_banHang_FromDateToDate
@fromDate DATETIME, @toDate DATETIME
AS
BEGIN
	SELECT ID_DH, ID_GD, HoTen, SDT, NgayBanHang, Discount FROM DonHang
	JOIN KhachHang ON DonHang.ID_KH = KhachHang.ID_KH
	WHERE 
		ID_GD IS NOT NULL AND 
		@fromDate <= NgayBanHang AND NgayBanHang <= @toDate
END
GO


CREATE PROCEDURE sp_select_DonHang_by_ID
@ID_BH INT
AS
	BEGIN
		SELECT ID_GD, NgayBanHang, Discount, HoTen, SDT, DiaChi
		FROM dbo.DonHang
		JOIN KhachHang ON DonHang.ID_KH = KhachHang.ID_KH
		WHERE DonHang.ID_DH = @ID_BH
	END
GO

-- EXEC sp_select_DonHang_by_ID 1

CREATE PROCEDURE sp_insert_DonHang
@ID_GD NVARCHAR(50),
@Discount FLOAT,
@HoTen NVARCHAR(50),
@SDT NVARCHAR(50),
@DiaChi NVARCHAR(MAX)
AS
BEGIN
	IF (EXISTS (SELECT * FROM DonHang WHERE DonHang.ID_GD = @ID_GD))
		RETURN

	DECLARE @ID_KH INT
	IF (NOT EXISTS (SELECT * FROM KhachHang WHERE KhachHang.SDT = @SDT))
	BEGIN
		INSERT KhachHang(HoTen, SDT, DiaChi)
		VALUES (@HoTen, @SDT, @DiaChi)

		SELECT @ID_KH = MAX(ID_KH) FROM KhachHang
	END
	ELSE
	BEGIN
		SELECT @ID_KH = ID_KH FROM KhachHang WHERE KhachHang.SDT = @SDT
	END

	INSERT DonHang(ID_GD, ID_KH, NgayBanHang, Discount)
	VALUES (@ID_GD, @ID_KH, GETDATE(), @Discount)
END
GO




-- SELECT * FROM DonHang
-- SELECT * FROM KhachHang

-- EXEC sp_insert_DonHang '123423112342', 10, 'Nguyễn Ngọc Hân', '0848987650', 'Da Lat'
-- EXEC sp_insert_DonHang'243211324321', 10, N'Vũ Thị Phi Nhung', '0848987651', 'Sài Gòn'

------------------------------ Chi Tiet Don Hang -------------------------------

CREATE PROCEDURE sp_insert_ChiTietDonHang
@ID_G INT,
@ID_DH INT,
@SoLuongSanPham INT
AS
BEGIN
	IF (NOT EXISTS (SELECT * FROM Giay WHERE Giay.ID_G = @ID_G))
		RETURN

	IF (NOT EXISTS (SELECT * FROM DonHang WHERE DonHang.ID_DH = @ID_DH))
		RETURN

	DECLARE @isBillCheckout INT = -1
	SELECT @isBillCheckout = @ID_DH FROM DonHang WHERE DonHang.ID_DH = @ID_DH AND DonHang.ID_GD <> NULL

	IF (@isBillCheckout > -1)
		RETURN

	DECLARE @isExistsChiTietDonHang INT = -1
	DECLARE @SLSanPhamCoSan INT = 0
	SELECT @isExistsChiTietDonHang = ID_CTDH, @SLSanPhamCoSan = SoLuongSanPham FROM ChiTietDonHang WHERE ID_DH = @ID_DH AND ID_G = @ID_G

	IF (@isExistsChiTietDonHang > 0)
	BEGIN
		DECLARE @SLSanPhamMoi INT = @SLSanPhamCoSan + @SoLuongSanPham
		IF (@SLSanPhamMoi > 0)
			UPDATE ChiTietDonHang
			SET SoLuongSanPham = @SLSanPhamMoi
			WHERE ID_DH = @ID_DH AND ID_G = @ID_G
		ELSE
			DELETE ChiTietDonHang WHERE ID_DH = @ID_DH AND ID_G = @ID_G
	END
	ELSE
	BEGIN
		INSERT ChiTietDonHang(ID_DH, ID_G, SoLuongSanPham)
		VALUES (@ID_DH, @ID_G, @SoLuongSanPham)
	END
END
GO

-- SELECT * FROM KhachHang

-- INSERT DonHang(ID_KH, NgayBanHang, Discount)
 --VALUES (3, '20200212', 10)

-- SELECT * FROM DonHang

-- EXEC sp_insert_ChiTietDonHang 2, 6, 2
-- EXEC sp_insert_ChiTietDonHang 2, 3, 1
-- EXEC sp_insert_ChiTietDonHang 2, 4, 3
-- EXEC sp_insert_ChiTietDonHang 2, 2, -1

-- EXEC sp_select_DonHang_All

-- SELECT * FROM ChiTietDonHang

-- SELECT * FROM DonHang
-- SELECT * FROM ChiTietDonHang
-- GO



--Cần xem lại
CREATE PROCEDURE sp_select_ChiTietDonHang
@ID_DH INT
AS
BEGIN
	SELECT Ten_G, GiaBan, SoLuongSanPham
	FROM ChiTietDonHang 
	INNER JOIN Giay ON Giay.ID_G = ChiTietDonHang.ID_G
	WHERE ID_DH = @ID_DH
END
GO

-- EXEC sp_select_ChiTietDonHang 5

---------------------------------- Doanh Thu -----------------------------------
--select *from DoanhThu
CREATE PROCEDURE sp_select_DoanhThu
AS
BEGIN
	SELECT ChiTietDonHang.ID_CTDH,DonHang.ID_DH,DoanhThu.ID_G,NgayBanHang,SoLuongSanPham,TongTien
	FROM DoanhThu ,DonHang, ChiTietDonHang, Giay
	WHERE ChiTietDonHang.ID_CTDH =DoanhThu.ID_CTDH AND DonHang.ID_DH = DoanhThu.ID_DH AND Giay.ID_G = DoanhThu.ID_G
END
GO
--EXEC sp_select_DoanhThu

---------------------------------- Login -----------------------------------

CREATE PROCEDURE sp_Login
@TenDangNhap NVARCHAR(50),
@MatKhau NVARCHAR(50)
AS
BEGIN
	SELECT * FROM dbo.Boss WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau
END
GO

--select * from DonHang
--select * from ChiTietDonHang
--select * from LoaiGiay
--select * from Giay

-- EXEC sp_Login N'Lazy', N'1'

--select * from DonHang
--select * from ChiTietDonHang
--select * from Giay
--select * from LoaiGiay
--select * from Boss
--go
CREATE PROC USP_Login
@username nvarchar(100), @password nvarchar(100)
as
begin
	select * from Boss where boss.TenDangNhap = @username and boss.MatKhau = @password
end
go


-- exec USP_Login N'lazy', N'1'