using Dapper;
using QLNV.DAL.Interface;
using QLNV.Domain;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace QLNV.DAL
{
    public class NhanVienRepository : BaseRepository, INhanVienRepository
    {
        public IList<NhanVien> DanhSachNhanVienTheoPhongBan(int phongbanId)
        {
         
                 IList<NhanVien> danhSachNhanVien = SqlMapper.Query<NhanVien>(con, "DanhSachNhanVienTheoPhongBan", commandType: CommandType.StoredProcedure).ToList();
                return danhSachNhanVien;

        }

      

        public NhanVien LayNhanVienTheoID(int maNV)
        {
            DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaNV", maNV);
         NhanVien nhanvien = SqlMapper.Query<NhanVien>(con, "LayNhanVienTheoMaNV", commandType: CommandType.StoredProcedure).FirstOrDefault();
                return nhanvien;
          
        }

        public int SuaNhanVien(SuaNhanVien request)
        {
           try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaNV",request.MaNV);
                parameters.Add("@Ho", request.Ho);
                parameters.Add("@Ten", request.Ten);
                parameters.Add("@DiaChi", request.DiaChi);
                parameters.Add("@Dienthoai", request.Dienthoai);
                parameters.Add("@Email", request.Email);
                parameters.Add("@PhongBanId", request.PhongBanId);
            
                var id = SqlMapper.ExecuteScalar<int>(con, "SuaNhanVien", commandType: CommandType.StoredProcedure);
                return id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int TaoNhanVien(TaoNhanVien request)
        {

            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Ho", request.Ho);
                parameters.Add("@Ten", request.Ten);
                parameters.Add("@DiaChi", request.DiaChi);
                parameters.Add("@Dienthoai", request.Dienthoai);
                parameters.Add("@Email", request.Email);
                parameters.Add("@PhongBanId", request.PhongBanId);
                var id = SqlMapper.ExecuteScalar<int>(con, "TaoNhanVien", commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaNhanVien(int maNV)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@MaNV", maNV);
              
                var result = SqlMapper.ExecuteScalar<bool>(con, " XoaPh", commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

