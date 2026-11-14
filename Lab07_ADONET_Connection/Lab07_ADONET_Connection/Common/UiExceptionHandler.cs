using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.Common
{
    public static class UiExceptionHandler
    {
        public static void Handle(Exception ex, string contextAction)
        {
            if (ex is BusinessException bizEx)
            {
                Logger.Warn($"Vi phạm nghiệp vụ [{contextAction}]: {bizEx.Message}");
                MessageBox.Show(bizEx.Message, "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ex is MySqlException sqlEx)
            {
                Logger.Error($"Lỗi CSDL MySQL ({sqlEx.Number}) khi {contextAction}", sqlEx);
                string friendlyMsg = GetFriendlyMySqlMessage(sqlEx);
                MessageBox.Show(friendlyMsg, "Lỗi Cơ Sở Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Logger.Error($"Lỗi không xác định khi {contextAction}", ex);
                MessageBox.Show("Ứng dụng gặp lỗi hệ thống. Chi tiết sự cố đã được ghi nhận vào nhật ký (Logs).",
                    "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetFriendlyMySqlMessage(MySqlException ex)
        {
            switch (ex.Number)
            {
                case 1062: return "Mã dữ liệu đã tồn tại trong hệ thống. Vui lòng kiểm tra lại.";
                case 1451: return "Không thể xóa bản ghi này vì đang có dữ liệu liên kết ở bảng khác.";
                case 1042:
                case 0: return "Không thể kết nối đến máy chủ MySQL. Vui lòng kiểm tra dịch vụ CSDL.";
                default: return "Không thể cập nhật dữ liệu. Vui lòng thử lại sau.";
            }
        }
    }
}