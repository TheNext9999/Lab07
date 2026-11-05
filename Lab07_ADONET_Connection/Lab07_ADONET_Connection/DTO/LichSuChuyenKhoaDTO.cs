// LichSuChuyenKhoaDTO.cs
using System;

namespace Lab07_ADONET_Connection.DTO
{
    public class LichSuChuyenKhoaDTO
    {
        public int Id { get; set; }
        public string MaSV { get; set; }
        public string MaKhoaCu { get; set; }
        public string MaKhoaMoi { get; set; }
        public DateTime NgayChuyen { get; set; }
        public string LyDo { get; set; }
    }
}