using System;
using System.Data;
using Lab07_ADONET_Connection.DAL;
using Lab07_ADONET_Connection.DTO;

namespace Lab07_ADONET_Connection.BUS
{
    public class KhoaBUS
    {
        private KhoaDAL dal = new KhoaDAL();

        public DataTable GetAllKhoa() => dal.GetAllKhoa();

        public void AddKhoa(KhoaDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MaKhoa)) throw new ArgumentException("Mã khoa không được rỗng.");
            if (string.IsNullOrWhiteSpace(dto.TenKhoa)) throw new ArgumentException("Tên khoa không được rỗng.");
            dal.InsertKhoa(dto);
        }

        public void UpdateKhoa(KhoaDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MaKhoa)) throw new ArgumentException("Mã khoa không được rỗng.");
            if (string.IsNullOrWhiteSpace(dto.TenKhoa)) throw new ArgumentException("Tên khoa không được rỗng.");
            dal.UpdateKhoa(dto);
        }

        public void DeleteKhoa(string maKhoa)
        {
            if (string.IsNullOrWhiteSpace(maKhoa)) throw new ArgumentException("Mã khoa không được rỗng.");
            dal.DeleteKhoa(maKhoa);
        }
    }
}