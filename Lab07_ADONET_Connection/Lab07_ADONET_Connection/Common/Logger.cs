using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace Lab07_ADONET_Connection.Common
{
    public static class Logger
    {
        private static readonly object Sync = new object();
        private static DateTime _lastCleanupDate = DateTime.MinValue;

        private static string GetLogDirectory()
        {
            string folder = ConfigurationManager.AppSettings["LogFolder"];
            if (string.IsNullOrWhiteSpace(folder)) folder = "Logs";
            return Path.IsPathRooted(folder)
                ? folder
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
        }

        private static long GetMaxLogSizeBytes()
        {
            if (long.TryParse(ConfigurationManager.AppSettings["MaxLogSizeMB"], out long mb) && mb > 0)
                return mb * 1024L * 1024L;
            return 5L * 1024L * 1024L; // Mặc định 5 MB
        }

        private static int GetRetentionDays()
        {
            if (int.TryParse(ConfigurationManager.AppSettings["LogRetentionDays"], out int days) && days > 0)
                return days;
            return 30; // Mặc định lưu giữ 30 ngày
        }

        public static void Info(string message) => WriteLog("INFO", message, null);
        public static void Warn(string message) => WriteLog("WARN", message, null);
        public static void Error(string message, Exception ex = null) => WriteLog("ERROR", message, ex);

        private static void WriteLog(string level, string message, Exception ex)
        {
            try
            {
                string dir = GetLogDirectory();
                Directory.CreateDirectory(dir);

                string file = Path.Combine(dir, DateTime.Now.ToString("yyyyMMdd") + ".log");
                string exText = ex != null ? $"\r\n{ex}" : string.Empty;
                string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} | {level,-5} | {message}{exText}\r\n";

                lock (Sync)
                {
                    // Bài 7: Xoay vòng log theo dung lượng tối đa
                    RotateIfExceedMaxSize(file);
                    File.AppendAllText(file, line, Encoding.UTF8);

                    // Bài 7: Dọn dẹp log cũ quá số ngày quy định (1 lần/ngày)
                    if (_lastCleanupDate.Date != DateTime.Now.Date)
                    {
                        CleanupOldLogs(dir, GetRetentionDays());
                        _lastCleanupDate = DateTime.Now.Date;
                    }
                }
            }
            catch
            {
                // Không để lỗi ghi log làm dừng ứng dụng
            }
        }

        private static void RotateIfExceedMaxSize(string filePath)
        {
            if (!File.Exists(filePath)) return;
            FileInfo info = new FileInfo(filePath);
            if (info.Length >= GetMaxLogSizeBytes())
            {
                string archiveName = Path.Combine(
                    info.DirectoryName ?? "",
                    $"{Path.GetFileNameWithoutExtension(filePath)}_{DateTime.Now:HHmmss}.archive.log");
                File.Move(filePath, archiveName);
            }
        }

        private static void CleanupOldLogs(string dir, int retentionDays)
        {
            DateTime threshold = DateTime.Now.AddDays(-retentionDays);
            foreach (string path in Directory.GetFiles(dir, "*.log"))
            {
                if (File.GetLastWriteTime(path) < threshold)
                {
                    try { File.Delete(path); } catch { }
                }
            }
        }
    }
}