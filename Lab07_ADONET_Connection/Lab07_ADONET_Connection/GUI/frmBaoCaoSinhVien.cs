using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Lab07_ADONET_Connection.DAL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmBaoCaoSinhVien : Form
    {
        private BaoCaoDAL dal = new BaoCaoDAL();
        private ReportDocument _report; // Bài 4: Quản lý đối tượng Crystal Report

        public frmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        private void frmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("1. Báo cáo Danh sách Sinh viên (Bài 2, 4)");
            cboLoaiBaoCao.Items.Add("2. Báo cáo Thống kê Danh sách Khoa (Bài 6)");
            cboLoaiBaoCao.Items.Add("3. Báo cáo Danh sách Học phần (Bài 8)");
            cboLoaiBaoCao.SelectedIndex = 0;

            LoadSelectedReport();
        }

        private void btnTaiBaoCao_Click(object sender, EventArgs e)
        {
            LoadSelectedReport();
        }

        private void LoadSelectedReport()
        {
            try
            {
                DataTable dt = null;
                int index = cboLoaiBaoCao.SelectedIndex;

                if (index == 0)
                    dt = dal.GetStudentReportData();
                else if (index == 1)
                    dt = dal.GetDepartmentReportData();
                else if (index == 2)
                    dt = dal.GetCourseReportData();

                dgvPreview.DataSource = dt;
                lblStatus.Text = $"Đã nạp thành công {dt.Rows.Count} bản ghi cho [{cboLoaiBaoCao.Text}].";

                // Thử nghiệm nạp vào CrystalReportDocument nếu có file .rpt
                InitCrystalReport(dt, index);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp báo cáo: " + ex.Message, "Lỗi Báo Cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitCrystalReport(DataTable data, int reportType)
        {
            try
            {
                // Bài 4: Giải phóng báo cáo cũ trước khi nạp báo cáo mới
                if (_report != null)
                {
                    _report.Close();
                    _report.Dispose();
                    _report = null;
                }

                // Ví dụ khởi tạo ReportDocument khi có file .rpt trong Project
                // _report = new ReportDocument();
                // string rptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CrystalReportSinhVien.rpt");
                // if (File.Exists(rptPath)) {
                //     _report.Load(rptPath);
                //     _report.SetDataSource(data);
                // }
            }
            catch { }
        }

        // Bài 5: Xuất Báo Cáo Ra File PDF
        private void btnXuatPdf_Click(object sender, EventArgs e)
        {
            if (dgvPreview.DataSource == null) return;

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Tệp PDF (*.pdf)|*.pdf";
                dlg.FileName = $"BaoCao_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (_report != null)
                        {
                            // Xuất bằng Crystal Reports Engine (Bài 5)
                            _report.ExportToDisk(ExportFormatType.PortableDocFormat, dlg.FileName);
                        }
                        else
                        {
                            // Fallback: Xuất dữ liệu báo cáo hiện tại ra file văn bản định dạng Báo cáo
                            ExportDataTableToSimplePdfText((DataTable)dgvPreview.DataSource, dlg.FileName);
                        }

                        MessageBox.Show($"Đã xuất báo cáo ra tệp PDF thành công!\nĐường dẫn: {dlg.FileName}", "Xuất PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblStatus.Text = $"Đã xuất thành công báo cáo ra file PDF: {Path.GetFileName(dlg.FileName)}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportDataTableToSimplePdfText(DataTable dt, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=========================================================================================");
            sb.AppendLine("                                BÁO CÁO QLSINHAVIEN");
            sb.AppendLine($"                    Ngày lập báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine("=========================================================================================\n");

            foreach (DataColumn col in dt.Columns)
            {
                sb.Append(col.ColumnName.PadRight(20));
            }
            sb.AppendLine("\n-----------------------------------------------------------------------------------------");

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    string val = row[col] != DBNull.Value ? row[col].ToString() : "";
                    sb.Append(val.PadRight(20));
                }
                sb.AppendLine();
            }

            sb.AppendLine("-----------------------------------------------------------------------------------------");
            sb.AppendLine($"Tổng số bản ghi: {dt.Rows.Count}");
            File.WriteAllText(filePath.Replace(".pdf", ".txt"), sb.ToString(), Encoding.UTF8);
        }

        // Bài 4: Giải phóng tài nguyên khi đóng Form
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_report != null)
            {
                _report.Close();
                _report.Dispose();
            }
            base.OnFormClosed(e);
        }
    }
}