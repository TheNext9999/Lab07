using System;
using System.Collections.Generic;
using System.Data;
using Lab07_ADONET_Connection.Common;
using Lab07_ADONET_Connection.DAL;
using Lab07_ADONET_Connection.DTO;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.BUS
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAL _dal = new SinhVienDAL();

        // =========================================================================
        // 1. TRUY VẤN & THỐNG KÊ (LAB 08 - LAB 15)
        // =========================================================================
        public DataTable GetAllSinhVien() => _dal.GetAllSinhVien();
        public DataTable GetAll() => _dal.GetAllSinhVien();
        public DataTable LayDanhSachSinhVien() => _dal.GetAllSinhVien();
        public int DemSoSinhVien() => _dal.DemSoSinhVien();
        public double ThongKeDiemCaoNhat() => _dal.ThongKeDiemCaoNhat();
        public double ThongKeDiemCaoNhat(string maKhoa) => _dal.ThongKeDiemCaoNhat(maKhoa);
        public DataTable LaySinhVienTheoKhoa(string maKhoa) => GetSinhVienByKhoa(maKhoa);
        public DataTable TimSinhVienTheoMa(string maSV) => _dal.TimSinhVienTheoMa(maSV);

        public DataTable SearchSinhVien(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAllSinhVien();
            return _dal.SearchSinhVien(keyword.Trim());
        }

        public DataTable Search(string keyword) => SearchSinhVien(keyword);

        public DataTable Search(object keyword, object maKhoa)
        {
            string kw = keyword != null ? keyword.ToString() : string.Empty;
            string khoa = maKhoa != null ? maKhoa.ToString() : string.Empty;
            return _dal.SearchMultiCriteria(kw, kw, khoa, null, null);
        }

        public DataTable GetSinhVienByKhoa(string maKhoa)
        {
            if (string.IsNullOrWhiteSpace(maKhoa)) return GetAllSinhVien();
            return _dal.GetSinhVienByKhoa(maKhoa.Trim());
        }

        // Lab 09: Tìm kiếm đa tiêu chí (hỗ trợ bản 4 tham số, 5 tham số và 13 tham số có out)
        public DataTable SearchMultiCriteria(string maSV, string hoTen, string maKhoa, double? diemMin, double? diemMax)
        {
            return _dal.SearchMultiCriteria(maSV, hoTen, maKhoa, diemMin, diemMax);
        }

        public DataTable SearchMultiCriteria(string keyword, string maKhoa, double diemMin, double diemMax)
        {
            return _dal.SearchMultiCriteria(keyword, keyword, maKhoa, diemMin, diemMax);
        }

        public DataTable SearchMultiCriteria(
            object p1, object p2, object p3, object p4, object p5, object p6,
            object p7, object p8, object p9, object p10, object p11, object p12, out int totalRecords)
        {
            string maSV = p1 as string;
            string hoTen = p2 as string;
            string maKhoa = (p4 as string) ?? (p3 as string);
            double? diemMin = p5 is double d1 ? (double?)d1 : (p6 is double d1b ? (double?)d1b : null);
            double? diemMax = p6 is double d2 ? (double?)d2 : (p7 is double d2b ? (double?)d2b : null);

            DataTable dt = _dal.SearchMultiCriteria(maSV, hoTen, maKhoa, diemMin, diemMax);
            totalRecords = dt.Rows.Count;
            return dt;
        }

        public DataTable SearchMultiCriteria(
            object p1, object p2, object p3, object p4, object p5, object p6,
            object p7, object p8, object p9, object p10, object p11, object p12, out string debugInfo)
        {
            int total;
            DataTable dt = SearchMultiCriteria(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, out total);
            debugInfo = $"Tìm thấy {total} bản ghi.";
            return dt;
        }

        // =========================================================================
        // 2. THÊM / SỬA / XÓA & KIỂM TRA NGHIỆP VỤ (LAB 08 & LAB 15)
        // =========================================================================
        public bool Add(SinhVienDTO dto)
        {
            ValidationResult validation = SinhVienValidator.Validate(dto);
            if (!validation.IsValid)
            {
                throw new BusinessException("Dữ liệu thêm mới không hợp lệ:\n- " + validation.GetSummaryMessage());
            }

            dto.MaSV = dto.MaSV.Trim().ToUpper();
            dto.HoTen = dto.HoTen.Trim();
            dto.MaKhoa = dto.MaKhoa.Trim();
            if (!string.IsNullOrWhiteSpace(dto.Email))
                dto.Email = dto.Email.Trim();

            if (_dal.Exists(dto.MaSV))
            {
                throw new BusinessException($"Mã sinh viên '{dto.MaSV}' đã tồn tại trong hệ thống.");
            }

            bool result = _dal.Insert(dto) > 0;
            if (result)
            {
                Logger.Info($"Thêm mới sinh viên thành công: {dto.MaSV} - {dto.HoTen}.");
            }
            return result;
        }

        public bool Insert(SinhVienDTO dto) => Add(dto);

        public int ThemSinhVien(SinhVienDTO dto)
        {
            return Add(dto) ? 1 : 0;
        }

        public int ThemSinhVien(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string maKhoa, double diemTB, string email)
        {
            SinhVienDTO dto = new SinhVienDTO
            {
                MaSV = maSV,
                HoTen = hoTen,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                MaKhoa = maKhoa,
                DiemTB = diemTB,
                Email = email
            };
            return Add(dto) ? 1 : 0;
        }

        public int ThemSinhVien(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string maKhoa, double diemTB, string email)
        {
            bool gt = !string.IsNullOrWhiteSpace(gioiTinh) &&
                      (gioiTinh.Trim().Equals("Nam", StringComparison.OrdinalIgnoreCase) ||
                       gioiTinh.Trim() == "1" ||
                       gioiTinh.Trim().Equals("true", StringComparison.OrdinalIgnoreCase));
            return ThemSinhVien(maSV, hoTen, ngaySinh, gt, maKhoa, diemTB, email);
        }

        public int ThemSinhVienCoOutput(SinhVienDTO dto, out int tongSinhVien)
        {
            int rows = ThemSinhVien(dto);
            tongSinhVien = DemSoSinhVien();
            return rows;
        }

        public int ThemSinhVienCoOutput(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string maKhoa, double diemTB, string email, out int tongSinhVien)
        {
            int rows = ThemSinhVien(maSV, hoTen, ngaySinh, gioiTinh, maKhoa, diemTB, email);
            tongSinhVien = DemSoSinhVien();
            return rows;
        }

        public int ThemSinhVienCoOutput(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string maKhoa, double diemTB, string email, out int tongSinhVien)
        {
            int rows = ThemSinhVien(maSV, hoTen, ngaySinh, gioiTinh, maKhoa, diemTB, email);
            tongSinhVien = DemSoSinhVien();
            return rows;
        }

        public bool Update(SinhVienDTO dto)
        {
            ValidationResult validation = SinhVienValidator.Validate(dto);
            if (!validation.IsValid)
            {
                throw new BusinessException("Dữ liệu cập nhật không hợp lệ:\n- " + validation.GetSummaryMessage());
            }

            dto.MaSV = dto.MaSV.Trim().ToUpper();
            dto.HoTen = dto.HoTen.Trim();
            dto.MaKhoa = dto.MaKhoa.Trim();
            if (!string.IsNullOrWhiteSpace(dto.Email))
                dto.Email = dto.Email.Trim();

            if (!_dal.Exists(dto.MaSV))
            {
                throw new BusinessException($"Không tìm thấy sinh viên có mã '{dto.MaSV}' để cập nhật.");
            }

            bool result = _dal.Update(dto) > 0;
            if (result)
            {
                Logger.Info($"Cập nhật sinh viên: {dto.MaSV} - {dto.HoTen} (Điểm TB: {dto.DiemTB:0.00}).");
            }
            return result;
        }

        public int CapNhatDiem(string maSV, double diemMoi)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new BusinessException("Thiếu mã sinh viên cần cập nhật điểm.");
            if (diemMoi < 0 || diemMoi > 10)
                throw new BusinessException("Điểm trung bình phải thuộc khoảng [0, 10].");

            int rows = _dal.CapNhatDiem(maSV.Trim().ToUpper(), diemMoi);
            if (rows > 0)
            {
                Logger.Info($"Cập nhật điểm SV {maSV}: {diemMoi:0.00}");
            }
            return rows;
        }

        public bool Delete(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new BusinessException("Vui lòng chọn hoặc nhập mã sinh viên cần xóa.");

            string cleanMaSV = maSV.Trim().ToUpper();
            if (!_dal.Exists(cleanMaSV))
                throw new BusinessException($"Sinh viên có mã '{cleanMaSV}' không tồn tại.");

            bool result = _dal.Delete(cleanMaSV);
            if (result)
            {
                Logger.Info($"Đã xóa sinh viên: {cleanMaSV}");
            }
            return result;
        }

        public bool Delete(string maSV, object rowVersion)
        {
            return Delete(maSV);
        }

        public int XoaSinhVien(string maSV)
        {
            return Delete(maSV) ? 1 : 0;
        }

        // =========================================================================
        // 3. DISCONNECTED DATASET & ADAPTER (LAB 10)
        // =========================================================================
        public DataTable GetStudentTableDisconnected() => _dal.GetAllSinhVien();
        public DataSet GetQLSVDataSet() => _dal.GetQLSVDataSet();
        public MySqlDataAdapter GetStudentAdapterForUpdate() => _dal.GetStudentAdapterForUpdate();

        public MySqlDataAdapter GetStudentAdapterForUpdate(MySqlConnection conn, out MySqlCommandBuilder builder)
        {
            MySqlDataAdapter da = _dal.GetStudentAdapterForUpdate(conn);
            builder = new MySqlCommandBuilder(da);
            return da;
        }

        public MySqlDataAdapter GetStudentAdapterForUpdate(object arg1, object arg2)
        {
            return _dal.GetStudentAdapterForUpdate(arg1 as MySqlConnection);
        }

        // =========================================================================
        // 4. GIAO DỊCH TRANSACTIONS (LAB 11)
        // =========================================================================
        public bool AddStudentWithEnrollments(SinhVienDTO sv, List<DangKyDTO> dangKys)
        {
            ValidationResult validation = SinhVienValidator.Validate(sv);
            if (!validation.IsValid)
                throw new BusinessException("Dữ liệu sinh viên không hợp lệ:\n- " + validation.GetSummaryMessage());

            bool ok = _dal.AddStudentWithEnrollments(sv, dangKys);
            if (ok) Logger.Info($"Thêm SV kèm đăng ký học phần (Transaction): {sv.MaSV}");
            return ok;
        }

        public bool TransferDepartment(string maSV, string maKhoaMoi)
        {
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maKhoaMoi))
                throw new BusinessException("Thiếu mã sinh viên hoặc mã khoa mới.");

            bool ok = _dal.TransferDepartment(maSV.Trim().ToUpper(), maKhoaMoi.Trim());
            if (ok) Logger.Info($"Chuyển khoa SV {maSV} sang {maKhoaMoi}");
            return ok;
        }

        public bool TransferDepartment(object maSV, object maKhoaCu, object maKhoaMoi, object lyDo)
        {
            string sv = maSV != null ? maSV.ToString() : string.Empty;
            string targetKhoa = maKhoaMoi != null ? maKhoaMoi.ToString() : string.Empty;
            return TransferDepartment(sv, targetKhoa);
        }

        public int BulkUpdateGrades(List<DangKyDTO> danhSachDiem)
        {
            int count = _dal.BulkUpdateGrades(danhSachDiem);
            Logger.Info($"Cập nhật điểm hàng loạt: {count} bản ghi.");
            return count;
        }
    }
}