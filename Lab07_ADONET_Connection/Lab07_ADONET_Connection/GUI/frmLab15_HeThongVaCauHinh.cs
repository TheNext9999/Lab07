using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Lab07_ADONET_Connection.Common;
using Lab07_ADONET_Connection.DAL;
using Lab07_ADONET_Connection.DTO;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmLab15_HeThongVaCauHinh : Form
    {
        public frmLab15_HeThongVaCauHinh()
        {
            InitializeComponent();
        }

        private void frmLab15_HeThongVaCauHinh_Load(object sender, EventArgs e)
        {
            RefreshConfigStatus();
            RunPreFlightChecks();
            LoadTodayLog();
        }

        private void btnKiemTraHeThong_Click(object sender, EventArgs e)
        {
            RunPreFlightChecks();
            LoadTodayLog();
        }

        private void RunPreFlightChecks()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Hạng mục kiểm tra");
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Chi tiết kết quả");

            // 1. Kiểm tra kết nối MySQL Server & Database QLSinhVien
            try
            {
                using (MySqlConnection conn = DbConnectionFactory.Create())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM SinhVien", conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        dt.Rows.Add(
                            "1. Máy chủ MySQL & CSDL QLSinhVien",
                            "✅ SẴN SÀNG",
                            $"Kết nối thành công (MySQL {conn.ServerVersion} - {count} sinh viên).");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Pre-flight check thất bại ở bước kiểm tra MySQL", ex);
                dt.Rows.Add("1. Máy chủ MySQL & CSDL QLSinhVien", "❌ LỖI KẾT NỐI", ex.Message);
            }

            // 2. Kiểm tra thư mục Logs và quyền ghi tệp
            try
            {
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                Directory.CreateDirectory(logDir);
                string probeFile = Path.Combine(logDir, ".write_test");
                File.WriteAllText(probeFile, "OK");
                File.Delete(probeFile);
                dt.Rows.Add("2. Thư mục Logs & Quyền ghi tệp", "✅ SẴN SÀNG", $"Có quyền đọc/ghi tại: {logDir}");
            }
            catch (Exception ex)
            {
                dt.Rows.Add("2. Thư mục Logs & Quyền ghi tệp", "❌ THIẾU QUYỀN", ex.Message);
            }

            // 3. Kiểm tra Crystal Reports Runtime & tệp .rpt
            try
            {
                using (ReportDocument rpt = new ReportDocument())
                {
                    string rptPath = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Reports",
                        "CrystalReportSinhVienTheoKhoa.rpt");

                    string rptDetail = "Đã nạp SDK (chưa copy tệp .rpt vào thư mục chạy).";
                    if (File.Exists(rptPath))
                    {
                        rptDetail = "Đã nạp SDK & tìm thấy tệp mẫu .rpt.";
                    }

                    dt.Rows.Add("3. Crystal Reports Runtime SP40", "✅ SẴN SÀNG", rptDetail);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Pre-flight check thất bại ở bước kiểm tra Crystal Reports", ex);
                dt.Rows.Add("3. Crystal Reports Runtime SP40", "❌ CHƯA CÀI ĐẶT", ex.Message);
            }

            // 4. Kiểm tra trạng thái mã hóa App.config
            bool isEncrypted = ConfigSecurityHelper.IsConnectionStringProtected();
            string configStatus = "⚠️ CHƯA MÃ HÓA";
            string configDetail = "Nên mã hóa connectionStrings trước khi triển khai.";
            if (isEncrypted)
            {
                configStatus = "🔒 ĐÃ MÃ HÓA";
                configDetail = "Mục connectionStrings đã được bảo vệ bằng DPAPI.";
            }
            dt.Rows.Add("4. Bảo mật tệp cấu hình App.config", configStatus, configDetail);

            dgvKiemTra.DataSource = dt;
        }

        private void RefreshConfigStatus()
        {
            string raw = DbConnectionFactory.GetConnectionString();
            txtConnStrPreview.Text = Regex.Replace(raw, @"(Pwd|Password)=[^;]*", "$1=******", RegexOptions.IgnoreCase);

            bool protectedFlag = ConfigSecurityHelper.IsConnectionStringProtected();
            if (protectedFlag)
            {
                lblTrangThaiMaHoa.Text = "Trạng thái bảo mật: 🔒 ĐÃ MÃ HÓA (ProtectedConfiguration - DPAPI)";
                lblTrangThaiMaHoa.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblTrangThaiMaHoa.Text = "Trạng thái bảo mật: ⚠️ CHƯA MÃ HÓA (Plain-text trên máy phát triển)";
                lblTrangThaiMaHoa.ForeColor = Color.DarkRed;
            }
        }

        private void btnMaHoaConfig_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigSecurityHelper.EncryptConnectionStrings();
                RefreshConfigStatus();
                RunPreFlightChecks();
                LoadTodayLog();
                MessageBox.Show("Đã mã hóa mục connectionStrings thành công!", "Bảo Mật Cấu Hình", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UiExceptionHandler.Handle(ex, "mã hóa cấu hình App.config");
            }
        }

        private void btnGiaiMaConfig_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigSecurityHelper.DecryptConnectionStrings();
                RefreshConfigStatus();
                RunPreFlightChecks();
                LoadTodayLog();
                MessageBox.Show("Đã giải mã mục connectionStrings thành công!", "Bảo Mật Cấu Hình", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UiExceptionHandler.Handle(ex, "giải mã cấu hình App.config");
            }
        }

        private void btnTestBusinessEx_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVienDTO invalidDto = new SinhVienDTO
                {
                    MaSV = "",
                    HoTen = "",
                    DiemTB = 12.5,
                    Email = "sai-dinh-dang-email"
                };

                ValidationResult res = SinhVienValidator.Validate(invalidDto);
                if (!res.IsValid)
                {
                    throw new BusinessException("Phát hiện nhiều lỗi nhập liệu cùng lúc:\n- " + res.GetSummaryMessage());
                }
            }
            catch (Exception ex)
            {
                UiExceptionHandler.Handle(ex, "kiểm tra dữ liệu SinhVienDTO");
                LoadTodayLog();
            }
        }

        private void btnTestDbError_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DbConnectionFactory.Create())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM BangKhongTonTai_TestLog", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                UiExceptionHandler.Handle(ex, "truy vấn kiểm thử lỗi CSDL");
                LoadTodayLog();
            }
        }

        private void btnTaiLaiLog_Click(object sender, EventArgs e)
        {
            LoadTodayLog();
        }

        private void LoadTodayLog()
        {
            try
            {
                string logFile = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Logs",
                    DateTime.Now.ToString("yyyyMMdd") + ".log");

                if (File.Exists(logFile))
                {
                    txtLogViewer.Text = File.ReadAllText(logFile, Encoding.UTF8);
                    txtLogViewer.SelectionStart = txtLogViewer.TextLength;
                    txtLogViewer.ScrollToCaret();
                }
                else
                {
                    txtLogViewer.Text = "Chưa có bản ghi log nào trong ngày hôm nay.";
                }
            }
            catch (Exception ex)
            {
                txtLogViewer.Text = "Không thể đọc tệp log: " + ex.Message;
            }
        }

        private void btnMoTrungTamBaoCao_Click(object sender, EventArgs e)
        {
            using (frmLab14_TrungTamBaoCao frm = new frmLab14_TrungTamBaoCao())
            {
                frm.ShowDialog();
            }
        }
    }
}