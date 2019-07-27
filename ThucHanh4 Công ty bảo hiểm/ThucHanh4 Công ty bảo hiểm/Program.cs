using System;
using ThucHanh4_Công_ty_bảo_hiểm.Class;
using ThucHanh4_Công_ty_bảo_hiểm.Interface;
using System.Collections.Generic;

namespace ThucHanh4_Công_ty_bảo_hiểm
{
    class Program
    {
        static void Main(string[] args)
        {
            INhanVien nhanvien = new NhanVien();

            NhapNhanVien(nhanvien);
            ThongTinNhanVien(nhanvien);
            ThongTinTienHoaHong(nhanvien);
            Console.ReadKey();
        }

        
        static void NhapNhanVien(INhanVien _nhanvien) {
            Console.WriteLine("Nhap so luong nhan vien");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++) {

                Console.WriteLine("ten nhan vien");
                string tenNV = Console.ReadLine();
                Console.WriteLine("he so luong");
                double HeSoLuong = double.Parse(Console.ReadLine());
                List<BaoHiem> baohiem = BaoHiemBanDuoc();

                NhanVien nhanvien = new NhanVien(tenNV, HeSoLuong, baohiem);

                //Thêm vào danh sách nhân viên
                _nhanvien.DanhSachNhanVien.Add(nhanvien);
            }

        }

        //Nhập danh sách bảo hiểm bán được của mỗi nhân viên
        static List<BaoHiem> BaoHiemBanDuoc() {
            List<BaoHiem> danhsach = new List<BaoHiem>();

            Console.WriteLine("So luong bao hiem");
            int soluong = int.Parse(Console.ReadLine());

            for (int i = 0; i < soluong; i++) {
                BaoHiem baohiem = NhapBaoHiem();
                danhsach.Add(baohiem);
            }

            return danhsach;
        }

        //Phân loại bảo hiểm dài hạn hay ngắn hạn
        static BaoHiem NhapBaoHiem() {
            Console.WriteLine("1 bao hiem dai han, 2 bao hiem ngan han");
            int loaiBH = int.Parse(Console.ReadLine());
            switch (loaiBH) {
                case 1:
                    return NhapBaoHiemDaiHan();
                case 2:
                    return NhapBaoHiemNganHan();

                default: return null;
            }
        }

        //Nhập thông tin bảo hiểm ngắn hạn
        static BaoHiem NhapBaoHiemNganHan()
        {
            Console.WriteLine("Ten nguoi mua");
            string TenNguoiMua = Console.ReadLine();
            Console.WriteLine("Thoi han ban");
            int ThoiHanban = int.Parse(Console.ReadLine());
            Console.WriteLine("so tien phai donng");
            double SoTienPhaiDong = double.Parse(Console.ReadLine());

            return new BaoHiemNganHan(TenNguoiMua, ThoiHanban, SoTienPhaiDong); ;
        }

        //Nhập tông tin bảo hiểm dài hạn.
        static BaoHiem NhapBaoHiemDaiHan()
        {
            Console.WriteLine("Ten nguoi mua");
            string TenNguoiMua = Console.ReadLine();
            Console.WriteLine("Thoi Han ban");
            int ThoiHanban = int.Parse(Console.ReadLine());
            Console.WriteLine("so tien phai dong");
            double SoTienPhaiDong = double.Parse(Console.ReadLine());
            Console.WriteLine("so tien hang thang");
            double SoTienHangThang = double.Parse(Console.ReadLine());

            return new BaoHiemDaiHan(TenNguoiMua, ThoiHanban, SoTienPhaiDong, SoTienHangThang);
        }

        //In thông thông nhân viên và bảo bảo hiểm
        static void ThongTinNhanVien(INhanVien _nhanvien) {
            
            foreach (NhanVien nhanvien in _nhanvien.DanhSachNhanVien) {
                Console.WriteLine(nhanvien);
                foreach(var baohiem in nhanvien.BaoHiemBanDuoc) {

                    if (baohiem is BaoHiemNganHan)
                        Console.WriteLine("loai bao hiem ngan hang");
                    else Console.WriteLine("loai bao hiem dai han");

                    Console.WriteLine(baohiem);
                }
            }
            //Hiển thị lương
            ThongTinLuong(_nhanvien);
        }

        //Tính lương
        static void ThongTinLuong(INhanVien _nhanvien)
        {
          
            foreach (var nhanvien in _nhanvien.DanhSachNhanVien) {
                double TongLuongNhanVien = 0;
                foreach (var baohiem in nhanvien.BaoHiemBanDuoc) {

                    double LuongNhanVien = _nhanvien.Luong(baohiem);
                    TongLuongNhanVien += LuongNhanVien;

                }

                Console.WriteLine("luong: {0}", TongLuongNhanVien);
            }
          
        }

        static void ThongTinTienHoaHong(INhanVien _nhanvien) {
    
            foreach (var nhanvien in DanhSachTienHoaHong(_nhanvien)) {
                Console.WriteLine(nhanvien);
            }
        }

        static IEnumerable<NhanVien> DanhSachTienHoaHong(INhanVien _nhanvien) {
            foreach (var nhanvien in _nhanvien.DanhSachNhanVien) {
                int dem = 0;
                //vì trong danh sách 1 nhần viên có thể bán được nhiều bao hiểm 
                //nên nêu add trực trong "foreach (var baoHiem in nhanvien.BaoHiemBanDuoc)"
                //thì có trường hợp trùng nhân viên. Nên cần biên đếm để trành trường hợp đó.
                // (thêm nhân viên ngoài vòng "foreach (var baoHiem in nhanvien.BaoHiemBanDuoc)")

                foreach (var baoHiem in nhanvien.BaoHiemBanDuoc) {
                    double TienHoaHong = nhanvien.TienHoaHong(baoHiem);

                    if (TienHoaHong > 50) dem += 1;
                }

                if (dem > 1) yield return nhanvien;
            }    
        }
    }
}
