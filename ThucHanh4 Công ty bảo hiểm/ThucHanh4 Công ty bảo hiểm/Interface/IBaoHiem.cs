using System;
using System.Collections.Generic;
using System.Text;
using ThucHanh4_Công_ty_bảo_hiểm.Class;

namespace ThucHanh4_Công_ty_bảo_hiểm.Interface
{
    interface IBaoHiem
    {
        List<BaoHiem> DanhSachBaoHiem { get; set; }
    }
}
