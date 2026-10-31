using System;
using System.Data;
using Lab07_ADONET_Connection.DAL;

namespace Lab07_ADONET_Connection.BUS
{
    public class SinhVienBUS
    {
        private SinhVienDAL dal = new SinhVienDAL();

        #region HÀM XỬ LÝ CHO LAB 08
        public int DemSoSinhVien() => dal.DemSoSinhVien();
        public DataTable LayDanhSachSinhVien() => dal.LayDanhSachSinhVien();
        public int ThemSinhVien(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string maKhoa, double diemTB, string email)
            => dal.ThemSinhVien(maSV, hoTen, ngaySinh, gioiTinh, maKhoa, diemTB, email);
        public int CapNhatDiem(string maSV, double diemTB) => dal.CapNhatDiem(maSV, diemTB);
        public DataTable LaySinhVienTheoKhoa(string maKhoa) => dal.LaySinhVienTheoKhoa(maKhoa);
        public DataTable TimSinhVienTheoMa(string maSV) => dal.TimSinhVienTheoMa(maSV);
        public double ThongKeDiemCaoNhat(string maKhoa) => dal.ThongKeDiemCaoNhat(maKhoa);
        public int XoaSinhVien(string maSV) => dal.XoaSinhVien(maSV);
        public int ThemSinhVienCoOutput(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string maKhoa, double diemTB, string email, out int tongSoSV)
            => dal.ThemSinhVienCoOutput(maSV, hoTen, ngaySinh, gioiTinh, maKhoa, diemTB, email, out tongSoSV);
        #endregion

        #region HÀM XỬ LÝ CHO LAB 09
        public DataTable LoadStudents() => dal.LoadStudents();
        public DataTable SearchByName(string keyword) => dal.SearchByName(keyword);
        public DataTable FilterByKhoaAndDiem(string maKhoa, double min, double max) => dal.FilterByKhoaAndDiem(maKhoa, min, max);
        public DataTable GetStudentsPaged(int pageIndex, int pageSize, out int totalRecords) => dal.GetStudentsPaged(pageIndex, pageSize, out totalRecords);
        public DataTable SearchMultiCriteria(string maSV, string hoTen, string maKhoa, int? gioiTinh,
                                             double? minDiem, double? maxDiem, int? minTuoi, int? maxTuoi,
                                             string sortColumn, bool isAsc, int pageIndex, int pageSize, out int totalRecords)
        {
            return dal.SearchMultiCriteria(maSV, hoTen, maKhoa, gioiTinh, minDiem, maxDiem, minTuoi, maxTuoi, sortColumn, isAsc, pageIndex, pageSize, out totalRecords);
        }
        #endregion
    }
}