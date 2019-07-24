
-- Tạo thủ tục Login tài khoản:
-- Type trả vể kiểu tài khoản
CREATE PROCEDURE sp_Login(@username varchar(20), @password varchar(20) )
AS
BEGIN
	declare @type int
	set @type=-1
	select @type=LoaiTK from dbo.TaiKhoan where TenDangNhap=@username and MatKhau=@password
END

exec sp_Login 'admin','admin'

CREATE PROCEDURE sp_Login_Test(@username varchar(20), @password varchar(20) )
AS
BEGIN
	select * from dbo.TaiKhoan where TenDangNhap=@username and MatKhau=@password
END

exec sp_Login_Test 'admin','admin'

-- Tạo thủ tục lây ra danh sách người dùng
create proc sp_Nguoidung_ListAll
as
select * from NguoiDung
order by [HoTenKH] asc

exec sp_Nguoidung_ListAll

create proc sp_Users_ListAll
as
select * from NguoiDung 
order by [HoTenKH] asc

exec sp_Users_ListAll


create proc sp_GetUserByUsername(@username varchar(20))
as
begin
select * from NguoiDung,TaiKhoan where NguoiDung.MaKH=TaiKhoan.MaKH and TaiKhoan.TenDangNhap=@username
end
exec sp_GetUserByUsername 'admin'

create proc sp_GetUserByUsername2(@username varchar(20))
as
begin
select * from NguoiDung,TaiKhoan where NguoiDung.MaKH=TaiKhoan.MaKH and TaiKhoan.TenDangNhap=@username
order by [HoTenKH] asc
end
exec sp_GetUserByUsername2 'admin'

create proc sp_GetUserByUsername4
as
begin
select * from NguoiDung,TaiKhoan where NguoiDung.MaKH=TaiKhoan.MaKH and TaiKhoan.TenDangNhap='admin'
order by [HoTenKH] asc
end
exec sp_GetUserByUsername4


-- Lấy ra tất cả các lĩnh vực
create proc sp_Categories_ListAll
as
select * from LinhVuc
order by [TenLinhVuc] asc


exec sp_Categories_ListAll


create proc sp_Publishers_ListAll
as
select * from NhaXuatBan
order by [TenNXB] asc

exec sp_Publishers_ListAll


Alter table SanPham add foreign key(MaTTCT) references ThongTinChiTiet(MaTTCT)


create proc sp_Products_ListAll
as
select * from SanPham,ThongTinChiTiet where SanPham.MaTTCT=ThongTinChiTiet.MaTTCT

exec sp_Products_ListAll