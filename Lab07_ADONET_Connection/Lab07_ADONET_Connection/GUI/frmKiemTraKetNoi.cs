using Lab07_ADONET_Connection.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Lab07_ADONET_Connection
{
    public partial class frmKiemTraKetNoi : Form
    {
        public frmKiemTraKetNoi()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CapNhatHienThiChuoiKetNoi();
        }

        private void rdoWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWinAuth.Checked)
            {
                CapNhatHienThiChuoiKetNoi();
            }
        }

        private void rdoSqlAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSqlAuth.Checked)
            {
                CapNhatHienThiChuoiKetNoi();
            }
        }

        private string GetSelectedConnectionKey()
        {
            return (rdoWinAuth != null && rdoWinAuth.Checked) ? "MySqlRootConnection" : "MySqlAppUserConnection";
        }

        private void CapNhatHienThiChuoiKetNoi()
        {
            try
            {
                string key = GetSelectedConnectionKey();
                if (txtConnectionString != null)
                {
                    txtConnectionString.Text = DbConnectionFactory.GetConnectionString(key);
                }
            }
            catch (Exception ex)
            {
                if (txtConnectionString != null)
                {
                    txtConnectionString.Text = "Lỗi đọc App.config: " + ex.Message;
                }
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string connKey = GetSelectedConnectionKey();
            Stopwatch stopwatch = new Stopwatch();

            try
            {
                if (lblStatusMsg != null)
                {
                    lblStatusMsg.Text = "Trạng thái: Đang kết nối tới máy chủ MySQL...";
                    lblStatusMsg.ForeColor = Color.Blue;
                }
                Application.DoEvents();

                stopwatch.Start();

                using (MySqlConnection conn = DbConnectionFactory.Create(connKey))
                {
                    conn.Open();
                    stopwatch.Stop();

                    if (lblState != null)
                    {
                        lblState.Text = "• Trạng thái kết nối (State): SUCCESS - OPEN";
                        lblState.ForeColor = Color.DarkGreen;
                    }
                    if (lblDataSource != null) lblDataSource.Text = "• Máy chủ CSDL (Server Host): " + conn.DataSource;
                    if (lblDatabase != null) lblDatabase.Text = "• Tên Database (Catalog): " + conn.Database;
                    if (lblServerVersion != null) lblServerVersion.Text = "• Phiên bản MySQL Server: " + conn.ServerVersion;
                    if (lblResponseTime != null) lblResponseTime.Text = $"• Thời gian phản hồi (Latency): {stopwatch.ElapsedMilliseconds} ms";
                    if (lblCheckTime != null) lblCheckTime.Text = "• Thời điểm kiểm tra gần nhất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                    if (lblStatusMsg != null)
                    {
                        lblStatusMsg.Text = $"Trạng thái: Kết nối thành công tới CSDL [{conn.Database}]!";
                        lblStatusMsg.ForeColor = Color.DarkGreen;
                    }

                    MessageBox.Show(
                        $"Kết nối thành công tới MySQL Database [{conn.Database}]!\n" +
                        $"Phiên bản Server: {conn.ServerVersion}\n" +
                        $"Thời gian phản hồi: {stopwatch.ElapsedMilliseconds} ms",
                        "Thông Báo Thành Công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (MySqlException ex)
            {
                stopwatch.Stop();
                if (lblState != null)
                {
                    lblState.Text = "• Trạng thái kết nối (State): LỖI KẾT NỐI (FAILED)";
                    lblState.ForeColor = Color.Red;
                }
                if (lblResponseTime != null) lblResponseTime.Text = "• Thời gian phản hồi (Latency): N/A";
                if (lblStatusMsg != null)
                {
                    lblStatusMsg.Text = "Trạng thái: Lỗi kết nối CSDL MySQL!";
                    lblStatusMsg.ForeColor = Color.Red;
                }

                MessageBox.Show(
                    "Lỗi kết nối MySQL Server:\n" + ex.Message +
                    "\nMã lỗi (Error Code): " + ex.Number,
                    "Lỗi Kết Nối MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (lblState != null)
            {
                lblState.Text = "• Trạng thái kết nối (State): --";
                lblState.ForeColor = Color.Black;
            }
            if (lblDataSource != null) lblDataSource.Text = "• Máy chủ CSDL (Server Host): --";
            if (lblDatabase != null) lblDatabase.Text = "• Tên Database (Catalog): --";
            if (lblServerVersion != null) lblServerVersion.Text = "• Phiên bản MySQL Server: --";
            if (lblResponseTime != null) lblResponseTime.Text = "• Thời gian phản hồi (Latency): --";
            if (lblCheckTime != null) lblCheckTime.Text = "• Thời điểm kiểm tra gần nhất: --";

            if (lblStatusMsg != null)
            {
                lblStatusMsg.Text = "Trạng thái: Đã làm mới thông tin.";
                lblStatusMsg.ForeColor = Color.DimGray;
            }
            CapNhatHienThiChuoiKetNoi();
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e) { }
        private void lblState_Click(object sender, EventArgs e) { }
        private void lblDataSource_Click(object sender, EventArgs e) { }
        private void lblDatabase_Click(object sender, EventArgs e) { }
        private void lblServerVersion_Click(object sender, EventArgs e) { }
        private void lblResponseTime_Click(object sender, EventArgs e) { }
        private void lblCheckTime_Click(object sender, EventArgs e) { }
        private void lblStatusMsg_Click(object sender, EventArgs e) { }
    }
}