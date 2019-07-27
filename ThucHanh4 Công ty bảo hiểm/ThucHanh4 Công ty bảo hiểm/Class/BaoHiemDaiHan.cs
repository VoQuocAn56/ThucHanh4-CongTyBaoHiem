using System;
using System.Collections.Generic;
using System.Text;

namespace ThucHanh4_Công_ty_bảo_hiểm.Class
{
    class BaoHiemDaiHan : BaoHiem
    {
        public double SoTienHangThang { get; set; }

        public BaoHiemDaiHan() : base() { }
        public BaoHiemDaiHan(string TenNguoiMua, int ThoiHan, double SoTienPhaiDong, double SoTienHangThang) :
            base(TenNguoiMua, ThoiHan, SoTienPhaiDong)
        {
            this.SoTienHangThang = SoTienHangThang;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nSo tien hang thang: {0}", SoTienHangThang);
        }

    }
}
