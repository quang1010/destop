using QLNV.Domain;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System;
using System.Collections.Generic;

namespace QLNV.BAL.Interface
{
    public interface INhanVienService
    {
        IList<NhanVien> DanhSachNhanVienTheoPhongBan(int phongbanId);
        NhanVien LayNhanVienTheoID(int maNV);
        int TaoNhanVien(TaoNhanVien request);
        int SuaNhanVien(SuaNhanVien request);
        bool XoaNhanVien(int maNV);

    }
}
