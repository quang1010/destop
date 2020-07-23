using QLNV.Domain;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System.Collections.Generic;


namespace QLNV.DAL.Interface
{
    public interface INhanVienRepository
    {
        IList<NhanVien> DanhSachNhanVienTheoPhongBan(int phongbanId);
        NhanVien LayNhanVienTheoID(int maNV);
        int TaoNhanVien(TaoNhanVien request);
        int SuaNhanVien(SuaNhanVien request);
        bool XoaNhanVien(int maNV);
    }
}
