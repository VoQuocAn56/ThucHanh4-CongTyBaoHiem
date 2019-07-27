using System;
using System.Collections.Generic;
using System.Text;

namespace ThucHanh4_Công_ty_bảo_hiểm.Class
{
    class BaoHiemNganHan:BaoHiem
    {
        public BaoHiemNganHan() : base() {
            SoTienPhaiDong = 10;
        }
        public BaoHiemNganHan(string TenNguoiMua, int ThoiHan, double SoTienPhaiDong) :
            base(TenNguoiMua, ThoiHan, SoTienPhaiDong)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
