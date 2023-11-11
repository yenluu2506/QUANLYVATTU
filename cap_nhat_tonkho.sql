create or alter trigger trg_tonkho
on tb_CHUNGTU_CT
for insert,update
as begin
	declare @madvi nvarchar(50);
	declare @madvi2  nvarchar(50);

	declare @namky int;
	declare @nam int;
	declare @ky int;
	declare @ngayd datetime;
	declare @ngayc datetime;

	select @ngayc = b.ngay,@madvi=MADVI from inserted a, tb_CHUNGTU b where a.KHOA = b.KHOA
	exec spNGAY_TINHTON @ngayc out,@ngayd out,@nam out, @ky out
	exec TINH_TONKHO_DONVI @ngayc,@madvi
	if(isnull(@madvi2,'')<>'')
		begin
			select @ngayc = b.ngay2,@madvi=MADVI2 from inserted a, tb_CHUNGTU b where a.KHOA = b.KHOA
			exec spNGAY_TINHTON @ngayc out,@ngayd out,@nam out, @ky out
			exec TINH_TONKHO_DONVI @ngayc,@madvi
		end
end
