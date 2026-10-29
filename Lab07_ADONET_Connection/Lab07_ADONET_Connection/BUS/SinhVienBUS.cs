using System;
using System.Data;
using Lab07_ADONET_Connection.DAL;

namespace Lab07_ADONET_Connection.BUS
{
    public class SinhVienBUS
    {
        private SinhVienDAL dal = new SinhVienDAL();

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
    }
}