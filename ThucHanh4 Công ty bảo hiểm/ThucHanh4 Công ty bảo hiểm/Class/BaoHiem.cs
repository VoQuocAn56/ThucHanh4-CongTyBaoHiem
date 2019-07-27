using System;
using System.Collections.Generic;
using System.Text;
using ThucHanh4_Công_ty_bảo_hiểm.Interface;

namespace ThucHanh4_Công_ty_bảo_hiểm.Class
{
    public class BaoHiem:IBaoHiem
    {
        public string TenNguoiMua { get; set; }
        public int ThoiHanBan { get; set; }
        public double SoTienPhaiDong { get; set; }

        public List<BaoHiem> DanhSachBaoHiem { get; set ; }

        public BaoHiem()
        {
            this.TenNguoiMua = "";
            this.ThoiHanBan = 0;
            this.SoTienPhaiDong = 0;
        }

        public BaoHiem(string TenNguoiMua, int ThoiHanBan, double SoTienPhaiDong)
        {
            this.TenNguoiMua = TenNguoiMua;
            this.ThoiHanBan = ThoiHanBan;
            this.SoTienPhaiDong = SoTienPhaiDong;
        }

        public override string ToString()
        {
            return string.Format("Ten nguoi mua: {0} \nThoi gian ban {1} \nSo tien phai dong: {2}",
                new object[] { TenNguoiMua, ThoiHanBan, SoTienPhaiDong });
        }

    }
}
