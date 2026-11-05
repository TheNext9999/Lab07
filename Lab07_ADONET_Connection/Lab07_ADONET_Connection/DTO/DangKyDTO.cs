// DangKyDTO.cs
using System;

namespace Lab07_ADONET_Connection.DTO
{
    public class DangKyDTO
    {
        public string MaSV { get; set; }
        public string MaHP { get; set; }
        public int HocKy { get; set; }
        public double? Diem { get; set; }
        public string TenHP { get; set; }     // Dùng hiển thị Master-Detail
        public int SoTinChi { get; set; }    // Dùng hiển thị Master-Detail
        public DateTime? UpdatedAt { get; set; } // Kiểm soát xung đột Optimistic Concurrency

        public DangKyDTO() { }
        public DangKyDTO(string maSV, string maHP, int hocKy, double? diem)
        {
            MaSV = maSV;
            MaHP = maHP;
            HocKy = hocKy;
            Diem = diem;
        }
    }
}