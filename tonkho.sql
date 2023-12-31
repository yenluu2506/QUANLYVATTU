--VIEW R-CHUNGTU
CREATE VIEW R_CHUNGTU
AS
SELECT KHOA,NGAY,SCT,SCT2,NGAY2,LCT,TRANGTHAI,SOLUONG,TONGTIEN,GHICHU,MACTY,MADVI,MADVI2,CREATED_BY,CREATED_DATE,UPDATED_BY,UPDATED_DATE,DELETED_BY,DELETED_DATE
FROM tb_CHUNGTU
WHERE (ISNULL(DELETED_BY,0)=0)



CREATE OR alter procedure spNGAY_TINHTON
	@NGAYC DATETIME = NULL OUT,
	@NGAYD DATETIME = NULL OUT,
	@NAM INT = NULL OUT,
	@KY INT = NULL OUT
AS BEGIN
SET NOCOUNT ON;
IF @NGAYC IS NULL AND @NAM IS NOT NULL AND @KY IS NOT NULL
	BEGIN
		SELECT @NGAYD = CAST(@NAM AS VARCHAR(4))+'-'+CAST(@KY AS VARCHAR(2)) +'-01',--ép kiểu ngày:2021-08-01
			@NGAYC = DATEADD(MM,1,@NGAYD)-1 --nếu ngày đầu là 01/08 thì ngayc đc tính trả về 31/08
	END
	ELSE
BEGIN 
	IF @NGAYC IS NULL AND @NGAYD IS NOT NULL
	BEGIN
		SET @NGAYC = DATEADD(MM,DATEDIFF(MM,0,@NGAYD)+1,0)-1--luôn trả về ngày cuối của tháng với bất kỳ @ngayd nào
		SELECT @NAM = YEAR(@NGAYC),@KY = MONTH(@NGAYC)
	END
	ELSE
	BEGIN
		IF @NGAYC IS NULL
			SET @NGAYC = DATEADD(D,DATEDIFF(D,0,GETDATE()),0)--trả về ngày hiện tại
		SELECT @NAM = YEAR(@NGAYC),@KY = MONTH(@NGAYC),
			@NGAYD = CAST(@NAM AS VARCHAR(4)) + '-'+ CAST(@KY AS VARCHAR(2))+'-01'
	END
END
END


CREATE OR ALTER PROCEDURE TINH_TONKHO_DONVI
	@NGAYC DATETIME = NULL,
	@MADVI VARCHAR(10)
AS
DECLARE @NGAYD DATETIME,
		@NAMKY INT,
		@NAM INT,
		@KY INT,
		@XNAM INT,
		@XKY INT,
		@MACTY VARCHAR(10)
BEGIN
	SET NOCOUNT ON;
	IF(@NGAYC IS NULL)
		SET @NGAYC = GETDATE()
	EXEC spNGAY_TINHTON @NGAYC,@NGAYD OUT,@NAM OUT,@KY OUT
	SET @NAMKY = @NAM *100 + @KY
	IF NOT EXISTS (SELECT 1 FROM tb_TONKHO WHERE NAMKY = @NAMKY AND MADVI = @MADVI)
	BEGIN
		DECLARE
		@tmpNAM INT,
		@tmpKY INT,
		@tmpNGAYD DATETIME,
		@tmpNGAYC DATETIME
		
		IF @KY = 1
			SELECT @tmpNGAYC = NULL,@tmpKY =12,@tmpNAM=@NAM-1
		ELSE
			SELECT @tmpNGAYC = NULL,@tmpKY = @KY-1,@tmpNAM=@NAM
		EXEC spNGAY_TINHTON @tmpNGAYC OUT,@tmpNGAYD OUT,@tmpNAM OUT,@tmpKY OUT
		EXEC TINH_TONKHO_DONVI @NGAYC = @tmpNGAYC,@MADVI=@MADVI
	END
--tháng kế tiếp
IF @KY = 12
BEGIN 
	SET @XKY =1 
	SET @XNAM = @NAM +1
END
ELSE
BEGIN
	SET @XKY = @KY + 1
	SET @XNAM = @NAM
--TẠO BẢNG TẠM
CREATE TABLE #TAM1(
	MADVI NVARCHAR(15) NOT NULL,
	MACTY NVARCHAR(15) NOT NULL,
	BARCODE VARCHAR(13) NOT NULL,
	LG_DAU FLOAT NULL,
	LG_NHAPMUA FLOAT NULL,
	LG_NHAPNB FLOAT NULL,
	LG_XUATNB FLOAT NULL,
	LG_XUATSI FLOAT NULL,
	LG_BANLE FLOAT NULL)
	SELECT @MACTY = MACTY FROM tb_DONVI
	WHERE MADVI = @MADVI
		EXEC spNGAY_TINHTON @NGAYC,@NGAYD OUT, @NAM OUT, @KY OUT
		--DAUKY
		INSERT INTO #TAM1(MADVI,MACTY,BARCODE,LG_DAU)
		SELECT MADVI,MACTY,BARCODE,LG_DAU FROM tb_TONKHO A WHERE A.MADVI=@MADVI AND A.NAMKY=@NAMKY

		--NHAPMUA
		INSERT INTO #TAM1(MADVI,MACTY,BARCODE,LG_NHAPMUA)
		SELECT @MADVI,@MACTY,B.BARCODE,ISNULL(B.SOLUONG,0)
		FROM R_CHUNGTU A , tb_CHUNGTU_CT B
		WHERE A.KHOA = B.KHOA
		AND A.NGAY >=@NGAYD
		AND A.NGAY<@NGAYC+1
		AND A.TRANGTHAI <>1
		AND A.MADVI = @MADVI
		AND A.LCT = 1

		--NHAP NOI BO
		INSERT INTO #TAM1(MADVI,MACTY,BARCODE,LG_NHAPNB)
		SELECT @MADVI,@MACTY,B.BARCODE,ISNULL(B.SOLUONG,0)
		FROM R_CHUNGTU A , tb_CHUNGTU_CT B
		WHERE A.KHOA = B.KHOA
		AND A.NGAY2 >=@NGAYD
		AND A.NGAY2<@NGAYC+1
		AND ISNULL(A.SCT2,'')<>''
		AND A.MADVI2 = @MADVI
		AND A.LCT = 2

		--XUATNOIBO
		INSERT INTO #TAM1(MADVI,MACTY,BARCODE,LG_XUATNB)
		SELECT @MADVI,@MACTY,B.BARCODE,ISNULL(B.SOLUONG,0)
		FROM R_CHUNGTU A , tb_CHUNGTU_CT B,tb_DONVI C
		WHERE A.KHOA = B.KHOA
		AND A.NGAY >=@NGAYD
		AND A.NGAY<@NGAYC+1
		AND A.TRANGTHAI <>1
		AND A.MADVI = @MADVI
		AND A.MADVI = C.MADVI
		--AND C.KHO=1
		AND A.LCT = 2

		--XUAT SI
		INSERT INTO #TAM1(MADVI,MACTY,BARCODE,LG_XUATSI)
		SELECT @MADVI,@MACTY,B.BARCODE,ISNULL(B.SOLUONG,0)
		FROM R_CHUNGTU A , tb_CHUNGTU_CT B,tb_DONVI C
		WHERE A.KHOA = B.KHOA
		AND A.NGAY >=@NGAYD
		AND A.NGAY<@NGAYC+1
		AND A.TRANGTHAI <>1
		AND A.MADVI = @MADVI
		AND A.MADVI = C.MADVI
		--AND C.KHO=1
		AND A.LCT = 3

		--XUATBANLE
		INSERT INTO #TAM1(MADVI,MACTY,BARCODE,LG_BANLE)
		SELECT @MADVI,@MACTY,B.BARCODE,ISNULL(B.SOLUONG,0)
		FROM R_CHUNGTU A , tb_CHUNGTU_CT B,tb_DONVI C
		WHERE A.KHOA = B.KHOA
		AND A.NGAY >=@NGAYD
		AND A.NGAY<@NGAYC+1
		AND A.TRANGTHAI <>1
		AND A.MADVI = @MADVI
		AND A.MADVI = C.MADVI
		--AND C.KHO=1
		AND A.LCT = 4

		--select * from #TAM1 where barcode = '2017208000600'
		--TONG HOP
		SELECT MADVI,MACTY,BARCODE
		,SUM(ISNULL(LG_DAU,0)) AS LG_DAU
		,SUM(ISNULL(LG_NHAPMUA,0)) AS LG_NHAPMUA
		,SUM(ISNULL(LG_NHAPNB,0)) AS LG_NHAPNB
		,SUM(ISNULL(LG_XUATNB,0)) AS LG_XUATNB
		,SUM(ISNULL(LG_XUATSI,0)) AS LG_XUATSI
		,SUM(ISNULL(LG_BANLE,0)) AS LG_BANLE
		,CAST (0 AS FLOAT) AS LG_CUOI
		,CAST(0 AS FLOAT) AS TRIGIA
		,CAST(0 AS FLOAT) AS TIEN_CUOI
		INTO #TAM
		FROM #TAM1
		GROUP BY MADVI,MACTY,BARCODE
		DROP TABLE #TAM1

		--UPDATE CUOI KY
		UPDATE A
		SET A.LG_CUOI	=A.LG_DAU + A.LG_NHAPMUA + A.LG_NHAPNB - A.LG_XUATNB -A.LG_XUATSI - A.LG_BANLE
		,A.TIEN_CUOI=(A.LG_DAU + A.LG_NHAPMUA + A.LG_NHAPNB - A.LG_XUATNB -A.LG_XUATSI - A.LG_BANLE)*B.DONGIA
		,A.TRIGIA=B.DONGIA
		FROM #TAM A,tb_HANGHOA B
		WHERE A.BARCODE=B.BARCODE

		--SELECT * FROM #TAM
		--INSERT VAO BANG TON KHO
		MERGE INTO tb_TONKHO AS TK
		USING(
			SELECT @NAMKY NAMKY,@NAM NAM, @KY KY,MADVI,MACTY,BARCODE,ISNULL(LG_DAU,0) LG_DAU,
			ISNULL(LG_NHAPMUA,0) LG_NHAPMUA,ISNULL(LG_NHAPNB,0) LG_NHAPNB
			,ISNULL(LG_XUATNB,0) LG_XUATNB, ISNULL(LG_XUATSI,0) LG_XUATSI,ISNULL(LG_BANLE,0) LG_BANLE,ISNULL(LG_CUOI,0) LG_CUOI,TRIGIA,TIEN_CUOI
			FROM #TAM
		) AS SRC
		ON TK.NAMKY = SRC.NAMKY AND TK.MADVI= SRC.MADVI AND TK.MACTY=SRC.MACTY AND TK.BARCODE = SRC.BARCODE
		--NEU DA CO TRONG BANG TON KHO
		WHEN MATCHED THEN
			UPDATE SET
				TK.LG_DAU =SRC.LG_DAU
				,TK.LG_NHAPMUA = SRC.LG_NHAPMUA
				,TK.LG_NHAPNB = SRC.LG_NHAPNB
				,TK.LG_XUATNB = SRC.LG_XUATNB
				,TK.LG_XUATSI = SRC.LG_XUATSI
				,TK.LG_BANLE = SRC.LG_BANLE
				,TK.LG_CUOI = SRC.LG_CUOI
				,TK.TRIGIA=SRC.TRIGIA
				,TK.TIEN_CUOI = SRC.TIEN_CUOI
		WHEN NOT MATCHED BY TARGET THEN
			INSERT(
				NAMKY,NAM,KY,MADVI,MACTY,BARCODE,LG_DAU,LG_NHAPMUA,LG_NHAPNB,LG_XUATNB,LG_XUATSI,LG_BANLE,LG_CUOI,TRIGIA,TIEN_CUOI
			)
			VALUES(
				NAMKY,NAM,KY,MADVI,MACTY,BARCODE,LG_DAU,LG_NHAPMUA,LG_NHAPNB,LG_XUATNB,LG_XUATSI,LG_BANLE,LG_CUOI,TRIGIA,TIEN_CUOI
			)
			WHEN NOT MATCHED BY SOURCE AND TK.NAMKY = @NAMKY AND TK.MADVI = @MADVI THEN DELETE;

			--INSERT KY KE TIEP
			IF(DAY(DATEADD(DAY,1,@NGAYC))=1)
			BEGIN
				--NEXT PERIOD
				SET @NAMKY = @XNAM * 100 + @XKY
				MERGE INTO tb_TONKHO AS TK
				USING(
					SELECT @NAMKY NAMKY,@XNAM NAM,@XKY KY,MADVI,MACTY,BARCODE,LG_CUOI,TRIGIA,TIEN_CUOI
					FROM #TAM
					WHERE LG_CUOI <>0
					)AS SRC
			ON TK.NAMKY = @NAMKY AND TK.MADVI = SRC.MADVI AND TK.MACTY = SRC.MACTY AND TK.BARCODE = SRC.BARCODE
			WHEN MATCHED THEN
			UPDATE SET
				TK.LG_DAU =SRC.LG_CUOI
				,TK.LG_NHAPMUA = NULL
				,TK.LG_NHAPNB = NULL
				,TK.LG_XUATNB = NULL
				,TK.LG_XUATSI = NULL
				,TK.LG_BANLE = NULL
				,TK.LG_CUOI = SRC.LG_CUOI
				,TK.TRIGIA=SRC.TRIGIA
				,TK.TIEN_CUOI = SRC.TIEN_CUOI
			WHEN NOT MATCHED BY TARGET THEN
				INSERT(NAMKY,NAM,KY,MADVI,MACTY,BARCODE,LG_DAU,LG_CUOI,TRIGIA,TIEN_CUOI)
				VALUES(@NAMKY,@XNAM,@XKY,MADVI,MACTY,BARCODE,LG_CUOI,LG_CUOI,TRIGIA,TIEN_CUOI)
			WHEN NOT MATCHED BY SOURCE AND TK.NAMKY = @NAMKY AND TK.MADVI = @MADVI THEN
			DELETE;
		END
		DROP TABLE #TAM
	END
END