// HocPhanDTO.cs
namespace Lab07_ADONET_Connection.DTO
{
    public class HocPhanDTO
    {
        public string MaHP { get; set; }
        public string TenHP { get; set; }
        public int SoTinChi { get; set; }

        public HocPhanDTO() { }
        public HocPhanDTO(string maHP, string tenHP, int soTinChi)
        {
            MaHP = maHP;
            TenHP = tenHP;
            SoTinChi = soTinChi;
        }
    }
}