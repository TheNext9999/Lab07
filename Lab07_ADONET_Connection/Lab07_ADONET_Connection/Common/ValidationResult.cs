using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lab07_ADONET_Connection.DTO;

namespace Lab07_ADONET_Connection.Common
{
    public class ValidationResult
    {
        public bool IsValid => Errors.Count == 0;
        public List<string> Errors { get; } = new List<string>();

        public string GetSummaryMessage()
        {
            return string.Join("\n- ", Errors);
        }
    }

    public static class SinhVienValidator
    {
        public static ValidationResult Validate(SinhVienDTO dto)
        {
            ValidationResult result = new ValidationResult();

            if (dto == null)
            {
                result.Errors.Add("Dữ liệu sinh viên không được để trống.");
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.MaSV))
                result.Errors.Add("Thiếu mã sinh viên.");

            if (string.IsNullOrWhiteSpace(dto.HoTen))
                result.Errors.Add("Thiếu họ tên sinh viên.");

            if (string.IsNullOrWhiteSpace(dto.MaKhoa))
                result.Errors.Add("Chưa chọn khoa trực thuộc.");

            if (dto.DiemTB < 0 || dto.DiemTB > 10)
                result.Errors.Add("Điểm trung bình phải thuộc khoảng [0, 10].");

            if (!string.IsNullOrWhiteSpace(dto.Email) &&
                !Regex.IsMatch(dto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                result.Errors.Add("Địa chỉ Email không đúng định dạng.");
            }

            return result;
        }
    }
}