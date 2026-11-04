using System;

namespace Lab07_ADONET_Connection.DTO
{
    public class SinhVienDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string MaKhoa { get; set; }
        public double DiemTB { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;

        public SinhVienDTO() { }

        public SinhVienDTO(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string maKhoa, double diemTB, string email)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            MaKhoa = maKhoa;
            DiemTB = diemTB;
            Email = email;
        }
    }

    public class KhoaDTO
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }

        public KhoaDTO() { }
        public KhoaDTO(string maKhoa, string tenKhoa)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
        }
    }
}