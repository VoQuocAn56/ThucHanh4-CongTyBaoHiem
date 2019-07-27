using System;
using System.Collections.Generic;
using System.Text;
using ThucHanh4_Công_ty_bảo_hiểm.Interface;

namespace ThucHanh4_Công_ty_bảo_hiểm.Class
{
    public class NhanVien : INhanVien
    {
        public string Ten { get; set; }
        public double HeSoluong { get; set; }

        public List<BaoHiem> BaoHiemBanDuoc { get; set; }

        public List<NhanVien> DanhSachNhanVien { get; set; }

        public NhanVien() {
            this.Ten = "";
            this.HeSoluong = 0;
            this.BaoHiemBanDuoc = new List<BaoHiem>();
            this.DanhSachNhanVien = new List<NhanVien>();
        }

        public NhanVien(string Ten, double HeSoluong, List<BaoHiem> BaoHiemBanDuoc)
        {
            this.Ten = Ten;
            this.HeSoluong = HeSoluong;
            this.BaoHiemBanDuoc = BaoHiemBanDuoc;
        }

        public double Thuong() {

            const double TIEN_THUONG = 100;
            //duyệt qua danh sách bảo hiểm mà nhân viên bán được 
            //nêu tiền bán được trên 10000 thì có tiền thường ngược lại thì ko.
            foreach (var baohiem in BaoHiemBanDuoc)
            {
                if (baohiem.SoTienPhaiDong > 10000)
                {
                    return TIEN_THUONG;
                }
            }

            return 0;
        }

        public double Phat()
        {
            const double TIEN_PHAT = 30;
            double TongTien = 0;

            //duyệt qua danh sách bảo hiểm mà nhân viên bán được 
            //nêu tong tiền bán bảo hiểm nhỏ hơn 10000 thì phạt
            foreach (var baohiem in BaoHiemBanDuoc)
            {
                TongTien += baohiem.SoTienPhaiDong;
            }

            if (TongTien < 10000) return TIEN_PHAT;

            return 0;
        }

        //tính lương
        public double LuongCoBan()
        {           
            return 40 * HeSoluong + 0.01;
        }

        //tiên lương hoa hồng.
        public double Luong(BaoHiem baohiem) {
            double LuongNhanVien = LuongCoBan();
            double TienHoaHongBaoHiem = TienHoaHong(baohiem);

            return LuongNhanVien + TienHoaHongBaoHiem;
        }

        //Tính tiền hoa hồng.
        public double TienHoaHong(BaoHiem baohiem) {
            //từ khóa is dùng để kiểm tra baohiem có là lớp ngắn hạn hay dài hạn ko
            //vì 2 lớp ngắn hạn và dài hạn đều kế thừa từ lớp baohiem.

            //Viết "if (baohiem is BaoHiemNganHan)" là máy ngầm hiểu "if (baohiem is BaoHiemNganHan == true)"

            if (baohiem is BaoHiemNganHan)
            {
                return 0.05 * baohiem.SoTienPhaiDong;
            }
            else return 0.5 * baohiem.SoTienPhaiDong;
        }


        public override string ToString()
        {
            return string.Format("Ten nhan nhien: {0} \nHeSoluong: {1}", new object[] { Ten, HeSoluong });
        }
    }
}
