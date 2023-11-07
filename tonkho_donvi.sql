create procedure rep_tonkho_dvi
	@NGAYD datetime,
	@NGAYC datetime,
	@MADVI nvarchar(10)
as
declare @SQL nvarchar(500)
declare @NAMKY int
set @NAMKY = year(@NGAYC)*100+month(@NGAYC)
begin
	set nocount on;
	set @SQL='SELECT A.NAMKY,A.NAM,A.KY,A.BARCODE,B.TENHH,B.DVT,A.LG_DAU,A.LG_NHAPMUA,A.LG_NHAPNB,A.LG_XUATNB,A.LG_XUATNB,A.LG_XUATSI,A.LG_BANLE,A.LG_CUOI,A.TRIGIA,A.TIEN_CUOI,A.MACTY,C.TENCTY,A.MADVI,D.TENDVI
FROM tb_TONKHO A, tb_HANGHOA B, tb_CONGTY C, tb_DONVI D
WHERE A.BARCODE = B.BARCODE AND A.MACTY = C.MACTY AND A.MADVI = D.MADVI
AND A.MADVI='''+@MADVI+''' AND A.NAMKY='+cast(@NAMKY as nvarchar)+'
ORDER BY A.BARCODE'

exec (@SQL)
end
go

