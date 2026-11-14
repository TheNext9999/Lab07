using System;
using System.Threading;
using System.Windows.Forms;
using Lab07_ADONET_Connection.Common;
using Lab07_ADONET_Connection.GUI;

namespace Lab07_ADONET_Connection
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Bài 6: Đăng ký Global Exception Handler
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Logger.Info("Ứng dụng Quản lý Sinh viên khởi động.");
            Application.Run(new frmLab15_HeThongVaCauHinh());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.Error("Lỗi luồng giao diện chưa được xử lý (ThreadException)", e.Exception);
            MessageBox.Show("Ứng dụng gặp sự cố ngoài ý muốn và đã ghi nhận log. Chương trình sẽ đóng an toàn.",
                "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            Logger.Error("Lỗi nghiêm trọng toàn miền ứng dụng (UnhandledException)", ex);
            MessageBox.Show("Phát hiện lỗi nghiêm trọng. Nhật ký lỗi đã được lưu vào thư mục Logs.",
                "Lỗi Nghiêm Trọng", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}