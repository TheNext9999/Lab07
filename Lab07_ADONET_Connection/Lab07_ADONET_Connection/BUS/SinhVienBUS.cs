using System;
using System.Data;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Lab07_ADONET_Connection.DAL;
using Lab07_ADONET_Connection.DTO;

namespace Lab07_ADONET_Connection.BUS
{
    public class SinhVienBUS
    {
        private SinhVienDAL dal = new SinhVienDAL();

        #region LAB 08 - PHƯƠNG THỨC MÔ HÌNH KẾT NỐI (CONNECTED)
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

        #region LAB 09 - TÌM KIẾM DATAREADER, LỌC & PHÂN TRANG
        public DataTable LoadStudents() => dal.LoadStudents();

        public DataTable SearchByName(string keyword) => dal.SearchByName(keyword);

        public DataTable FilterByKhoaAndDiem(string maKhoa, double min, double max) => dal.FilterByKhoaAndDiem(maKhoa, min, max);

        public DataTable GetStudentsPaged(int pageIndex, int pageSize, out int totalRecords)
            => dal.GetStudentsPaged(pageIndex, pageSize, out totalRecords);

        public DataTable SearchMultiCriteria(string maSV, string hoTen, string maKhoa, int? gioiTinh,
                                             double? minDiem, double? maxDiem, int? minTuoi, int? maxTuoi,
                                             string sortColumn, bool isAsc, int pageIndex, int pageSize, out int totalRecords)
        {
            return dal.SearchMultiCriteria(maSV, hoTen, maKhoa, gioiTinh, minDiem, maxDiem, minTuoi, maxTuoi, sortColumn, isAsc, pageIndex, pageSize, out totalRecords);
        }
        #endregion

        #region LAB 10 - MÔ HÌNH NGẮT KẾT NỐI (DISCONNECTED)
        public DataTable GetStudentTableDisconnected() => dal.GetStudentTableDisconnected();

        public DataSet GetQLSVDataSet() => dal.GetQLSVDataSet();

        public MySqlDataAdapter GetStudentAdapterForUpdate(MySqlConnection conn, out MySqlCommandBuilder builder)
            => dal.GetStudentAdapterForUpdate(conn, out builder);
        #endregion

        #region LAB 11 - KIẾN TRÚC 3 LỚP STORED PROCEDURE & KIỂM TRA NGHIỆP VỤ
        public void Add(SinhVienDTO dto)
        {
            Validate(dto);
            dal.Insert(dto);
        }

        public void Update(SinhVienDTO dto)
        {
            Validate(dto);
            dal.Update(dto);
        }

        public void Delete(string maSV, bool isSoftDelete = true)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new ArgumentException("Mã sinh viên không được để rỗng.");

            if (isSoftDelete)
                dal.SoftDelete(maSV);
            else
                dal.DeletePhysical(maSV);
        }

        public DataTable Search(string keyword, string maKhoa)
        {
            return dal.Search(keyword, maKhoa);
        }

        private void Validate(SinhVienDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Dữ liệu sinh viên không hợp lệ.");

            if (string.IsNullOrWhiteSpace(dto.MaSV))
                throw new ArgumentException("Mã sinh viên không được để rỗng.");

            if (string.IsNullOrWhiteSpace(dto.HoTen))
                throw new ArgumentException("Họ tên sinh viên không được để rỗng.");

            if (dto.NgaySinh > DateTime.Today.AddYears(-15))
                throw new ArgumentException("Tuổi sinh viên chưa đủ 15 tuổi.");

            if (dto.DiemTB < 0 || dto.DiemTB > 10)
                throw new ArgumentException("Điểm trung bình phải nằm trong khoảng [0.0, 10.0].");

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(dto.Email, emailPattern))
                    throw new ArgumentException("Định dạng email không hợp lệ.");
            }
        }
        #endregion
    }
}