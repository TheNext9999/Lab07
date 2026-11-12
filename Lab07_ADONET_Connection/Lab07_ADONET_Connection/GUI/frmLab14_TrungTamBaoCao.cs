using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Lab07_ADONET_Connection.BUS;
using Lab07_ADONET_Connection.DAL;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmLab14_TrungTamBaoCao : Form
    {
        private BaoCaoDAL baoCaoDal = new BaoCaoDAL();
        private KhoaBUS khoaBus = new KhoaBUS();
        private ReportDocument _report;
        private DataTable _chartData;

        public frmLab14_TrungTamBaoCao()
        {
            InitializeComponent();
        }

        private void frmLab14_TrungTamBaoCao_Load(object sender, EventArgs e)
        {
            // Nạp danh sách loại báo cáo (Bài 10)
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("1. Báo cáo Sinh viên theo Khoa (Bài 1, 2, 3)");
            cboLoaiBaoCao.Items.Add("2. Báo cáo Sinh viên theo Khoảng điểm (Bài 4)");
            cboLoaiBaoCao.Items.Add("3. Báo cáo Top N Sinh viên xuất sắc (Bài 6)");
            cboLoaiBaoCao.Items.Add("4. Báo cáo Thống kê Đăng ký theo Học kỳ (Bài 7)");
            cboLoaiBaoCao.Items.Add("5. Báo cáo Tổng hợp Thống kê theo Khoa (Bài 2, 3)");
            cboLoaiBaoCao.SelectedIndex = 0;

            // Nạp danh sách Khoa kèm lựa chọn Tất cả
            LoadKhoaComboBox();

            // Nạp danh sách Học kỳ
            cboHocKy.Items.Clear();
            cboHocKy.Items.Add("Tất cả học kỳ");
            cboHocKy.Items.Add("Học kỳ 1");
            cboHocKy.Items.Add("Học kỳ 2");
            cboHocKy.Items.Add("Học kỳ 3");
            cboHocKy.SelectedIndex = 0;

            // Nạp loại biểu đồ (Bài 8)
            cboLoaiBieuDo.Items.Clear();
            cboLoaiBieuDo.Items.Add("Số lượng Sinh viên theo Khoa");
            cboLoaiBieuDo.Items.Add("Phân bố Xếp loại học lực");
            cboLoaiBieuDo.SelectedIndex = 0;

            LoadReportData();
            LoadChartData();
        }

        private void LoadKhoaComboBox()
        {
            try
            {
                DataTable dtKhoa = khoaBus.GetAllKhoa();
                DataRow allRow = dtKhoa.NewRow();
                allRow["MaKhoa"] = "";
                allRow["TenKhoa"] = "-- Tất cả các khoa --";
                dtKhoa.Rows.InsertAt(allRow, 0);

                cboKhoa.DataSource = dtKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi nạp danh sách khoa: " + ex.Message;
            }
        }

        private void cboLoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cboLoaiBaoCao.SelectedIndex;
            cboKhoa.Enabled = (idx == 0 || idx == 2);
            numDiemMin.Enabled = (idx == 1);
            numDiemMax.Enabled = (idx == 1);
            numTopN.Enabled = (idx == 2);
            cboHocKy.Enabled = (idx == 3);
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadReportData();
            LoadChartData();
        }

        private void LoadReportData()
        {
            try
            {
                int idx = cboLoaiBaoCao.SelectedIndex;
                DataTable dt = null;
                string tieuDePhu = "";

                if (idx == 0) // Bài 1: Theo tham số Khoa
                {
                    string maKhoa = Convert.ToString(cboKhoa.SelectedValue);
                    dt = baoCaoDal.GetStudentsByDepartment(maKhoa);
                    tieuDePhu = "Khoa: " + cboKhoa.Text;
                }
                else if (idx == 1) // Bài 4: Theo khoảng điểm [Min, Max]
                {
                    decimal min = numDiemMin.Value;
                    decimal max = numDiemMax.Value;
                    if (min > max)
                    {
                        MessageBox.Show("Điểm Min không được lớn hơn Điểm Max!", "Lỗi Tham Số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dt = baoCaoDal.GetByScoreRange(min, max);
                    tieuDePhu = $"Khoảng điểm từ {min:0.0} đến {max:0.0}";
                }
                else if (idx == 2) // Bài 6: Top N sinh viên
                {
                    int topN = (int)numTopN.Value;
                    string maKhoa = Convert.ToString(cboKhoa.SelectedValue);
                    dt = baoCaoDal.GetTopStudents(topN, maKhoa);
                    tieuDePhu = $"Top {topN} sinh viên - {cboKhoa.Text}";
                }
                else if (idx == 3) // Bài 7: Đăng ký theo học kỳ
                {
                    int hocKy = cboHocKy.SelectedIndex; // 0 = Tất cả, 1 = HK1, 2 = HK2...
                    dt = baoCaoDal.GetEnrollmentStatsBySemester(hocKy);
                    tieuDePhu = cboHocKy.Text;
                }
                else if (idx == 4) // Bài 2 & 3: Tổng hợp nhóm theo Khoa
                {
                    dt = baoCaoDal.GetDepartmentSummaryStats();
                    tieuDePhu = "Thống kê tổng hợp toàn trường";
                }

                dgvBaoCao.DataSource = dt;
                FormatGridColumns();
                UpdateSummaryStatistics(dt, idx);
                PrepareCrystalReport(dt, tieuDePhu);

                lblStatus.Text = $"Đã nạp {dt.Rows.Count} bản ghi | {tieuDePhu}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp báo cáo: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridColumns()
        {
            if (dgvBaoCao.Columns.Contains("NgaySinh"))
                dgvBaoCao.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvBaoCao.Columns.Contains("DiemTB"))
                dgvBaoCao.Columns["DiemTB"].DefaultCellStyle.Format = "0.00";
            if (dgvBaoCao.Columns.Contains("DiemTB_Chung"))
                dgvBaoCao.Columns["DiemTB_Chung"].DefaultCellStyle.Format = "0.00";
            if (dgvBaoCao.Columns.Contains("DiemTrungBinh"))
                dgvBaoCao.Columns["DiemTrungBinh"].DefaultCellStyle.Format = "0.00";
        }

        // Bài 2 & 3: Tính toán thống kê tổng hợp (Count, Average, Max, Min)
        private void UpdateSummaryStatistics(DataTable dt, int reportIdx)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                lblThongKeTongHop.Text = "Thống kê tổng hợp: Không có dữ liệu phù hợp với điều kiện lọc.";
                return;
            }

            if (reportIdx == 0 || reportIdx == 1 || reportIdx == 2)
            {
                var scores = dt.AsEnumerable()
                               .Where(r => r["DiemTB"] != DBNull.Value)
                               .Select(r => Convert.ToDouble(r["DiemTB"]))
                               .ToList();

                double avg = scores.Any() ? scores.Average() : 0;
                double max = scores.Any() ? scores.Max() : 0;
                double min = scores.Any() ? scores.Min() : 0;

                lblThongKeTongHop.Text = $"Thống kê nhóm: Tổng SV: {dt.Rows.Count} | Điểm TB chung: {avg:0.00} | Cao nhất: {max:0.00} | Thấp nhất: {min:0.00}";
            }
            else if (reportIdx == 3)
            {
                int tongLuot = dt.AsEnumerable().Sum(r => Convert.ToInt32(r["SoLuotDangKy"]));
                lblThongKeTongHop.Text = $"Thống kê học phần: Số môn mở lớp: {dt.Rows.Count} | Tổng lượt đăng ký: {tongLuot}";
            }
            else if (reportIdx == 4)
            {
                int tongSV = dt.AsEnumerable().Sum(r => Convert.ToInt32(r["SoLuongSV"]));
                lblThongKeTongHop.Text = $"Thống kê toàn trường: Tổng số Khoa: {dt.Rows.Count} | Tổng số Sinh viên đang học: {tongSV}";
            }
        }

        // Bài 1: Nạp dữ liệu & truyền tham số vào ReportDocument
        private void PrepareCrystalReport(DataTable data, string tieuDePhu)
        {
            try
            {
                if (_report != null)
                {
                    _report.Close();
                    _report.Dispose();
                    _report = null;
                }

                string rptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "CrystalReportSinhVienTheoKhoa.rpt");
                if (File.Exists(rptPath))
                {
                    _report = new ReportDocument();
                    _report.Load(rptPath);
                    _report.SetDataSource(data);
                    _report.SetParameterValue("pTenKhoa", cboKhoa.Text);
                    _report.SetParameterValue("pNgayLap", DateTime.Now);
                    _report.SetParameterValue("pTieuDePhu", tieuDePhu);
                }
            }
            catch { }
        }

        #region BÀI 8: BIỂU ĐỒ THỐNG KÊ TRỰC QUAN
        private void cboLoaiBieuDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChartData();
        }

        private void LoadChartData()
        {
            try
            {
                if (cboLoaiBieuDo.SelectedIndex == 0)
                    _chartData = baoCaoDal.GetDepartmentReportData(); // MaKhoa, TenKhoa, SoLuongSinhVien
                else
                    _chartData = baoCaoDal.GetGradeDistribution();   // XepLoai, SoLuong

                picBieuDo.Invalidate(); // Vẽ lại biểu đồ
            }
            catch { }
        }

        private void picBieuDo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (_chartData == null || _chartData.Rows.Count == 0) return;

            string title = cboLoaiBieuDo.Text;
            using (Font titleFont = new Font("Segoe UI", 10F, FontStyle.Bold))
            using (Brush titleBrush = new SolidBrush(Color.FromArgb(15, 44, 89)))
            {
                g.DrawString(title, titleFont, titleBrush, new PointF(12, 10));
            }

            int marginLeft = 45, marginRight = 20, marginTop = 45, marginBottom = 60;
            int chartWidth = picBieuDo.Width - marginLeft - marginRight;
            int chartHeight = picBieuDo.Height - marginTop - marginBottom;
            if (chartWidth <= 20 || chartHeight <= 20) return;

            // Vẽ trục tọa độ
            using (Pen axisPen = new Pen(Color.Gray, 1.5f))
            {
                g.DrawLine(axisPen, marginLeft, marginTop, marginLeft, marginTop + chartHeight);
                g.DrawLine(axisPen, marginLeft, marginTop + chartHeight, marginLeft + chartWidth, marginTop + chartHeight);
            }

            List<string> labels = new List<string>();
            List<int> values = new List<int>();
            foreach (DataRow row in _chartData.Rows)
            {
                labels.Add(row[cboLoaiBieuDo.SelectedIndex == 0 ? "MaKhoa" : "XepLoai"].ToString());
                values.Add(Convert.ToInt32(row[cboLoaiBieuDo.SelectedIndex == 0 ? "SoLuongSinhVien" : "SoLuong"]));
            }

            int maxVal = Math.Max(1, values.Max());
            int count = values.Count;
            int slotWidth = chartWidth / count;
            int barWidth = Math.Max(18, (int)(slotWidth * 0.55));

            Color[] palette = {
                Color.FromArgb(31, 110, 140),
                Color.FromArgb(46, 125, 50),
                Color.FromArgb(21, 101, 192),
                Color.FromArgb(239, 108, 0),
                Color.FromArgb(198, 40, 40)
            };

            using (Font labelFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (Font valFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            {
                for (int i = 0; i < count; i++)
                {
                    int barHeight = (int)((double)values[i] / maxVal * (chartHeight - 15));
                    int x = marginLeft + i * slotWidth + (slotWidth - barWidth) / 2;
                    int y = marginTop + chartHeight - barHeight;

                    using (Brush barBrush = new SolidBrush(palette[i % palette.Length]))
                    {
                        g.FillRectangle(barBrush, x, y, barWidth, barHeight);
                    }

                    // Giá trị trên đỉnh cột
                    string valStr = values[i].ToString();
                    SizeF valSize = g.MeasureString(valStr, valFont);
                    g.DrawString(valStr, valFont, Brushes.Black, x + (barWidth - valSize.Width) / 2, y - valSize.Height - 2);

                    // Nhãn dưới trục X
                    SizeF lblSize = g.MeasureString(labels[i], labelFont);
                    g.DrawString(labels[i], labelFont, Brushes.DimGray, x + (barWidth - lblSize.Width) / 2, marginTop + chartHeight + 6);
                }
            }
        }
        #endregion

        #region BÀI 5, 9, 10: XUẤT EXCEL & PDF (KIỂM TRA FILE ĐANG MỞ)
        private bool IsFileLocked(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }

        // Bài 5: Xuất Crystal Report sang Excel Workbook
        private void btnXuatExcelCrystal_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Workbook (*.xls)|*.xls";
                dlg.FileName = $"BaoCaoSinhVien_{DateTime.Now:yyyyMMdd_HHmm}.xls";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (IsFileLocked(dlg.FileName))
                    {
                        MessageBox.Show("Tệp Excel này đang được mở bởi chương trình khác. Vui lòng đóng Excel trước khi xuất!", "Cảnh Báo Tệp Đang Mở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        if (_report != null)
                        {
                            _report.ExportToDisk(ExportFormatType.ExcelWorkbook, dlg.FileName);
                        }
                        else
                        {
                            ExportDataGridViewToExcelHtml(dgvBaoCao, dlg.FileName, cboLoaiBaoCao.Text);
                        }

                        MessageBox.Show("Đã xuất báo cáo sang Excel thành công!\n" + dlg.FileName, "Xuất Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblStatus.Text = "Xuất Excel thành công: " + Path.GetFileName(dlg.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Bài 9: Xuất trực tiếp DataGridView sang Excel giữ tiêu đề cột, định dạng ngày & số
        private void btnXuatExcelGrid_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trên lưới để xuất!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel File (*.xls)|*.xls";
                dlg.FileName = $"DuLieuLoc_{DateTime.Now:yyyyMMdd_HHmm}.xls";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (IsFileLocked(dlg.FileName))
                    {
                        MessageBox.Show("Tệp đích đang mở trong Excel. Vui lòng đóng tệp trước khi ghi đè!", "Tệp Đang Bị Khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        ExportDataGridViewToExcelHtml(dgvBaoCao, dlg.FileName, cboLoaiBaoCao.Text);
                        MessageBox.Show("Đã xuất DataGridView sang Excel thành công (giữ nguyên định dạng ngày & số)!", "Xuất Grid Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblStatus.Text = "Đã xuất Grid sang Excel: " + Path.GetFileName(dlg.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất DataGridView: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportDataGridViewToExcelHtml(DataGridView dgv, string filePath, string reportTitle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            sb.AppendLine("<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head>");
            sb.AppendLine("<body>");
            sb.AppendLine($"<h2 style='font-family:Calibri;color:#0F2C59;'>{reportTitle}</h2>");
            sb.AppendLine($"<p style='font-family:Calibri;'>Ngày lập báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | {lblThongKeTongHop.Text}</p>");
            sb.AppendLine("<table border='1' cellspacing='0' cellpadding='5' style='border-collapse:collapse;font-family:Calibri;font-size:11pt;'>");

            // Tiêu đề cột
            sb.AppendLine("<tr style='background-color:#0F2C59;color:#FFFFFF;font-weight:bold;'>");
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Visible)
                    sb.AppendLine($"<th>{col.HeaderText}</th>");
            }
            sb.AppendLine("</tr>");

            // Dữ liệu từng dòng giữ nguyên định dạng ngày và số
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                sb.AppendLine("<tr>");
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (!col.Visible) continue;
                    object val = row.Cells[col.Index].Value;

                    if (val is DateTime dtVal)
                    {
                        sb.AppendLine($"<td style='mso-number-format:\"dd\\/MM\\/yyyy\";'>{dtVal:dd/MM/yyyy}</td>");
                    }
                    else if (val is decimal || val is double || val is float)
                    {
                        sb.AppendLine($"<td style='mso-number-format:\"0\\.00\";'>{Convert.ToDouble(val):0.00}</td>");
                    }
                    else
                    {
                        sb.AppendLine($"<td>{val}</td>");
                    }
                }
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table></body></html>");
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        // Bài 10: Xuất PDF từ Trung tâm báo cáo
        private void btnXuatPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF File (*.pdf)|*.pdf";
                dlg.FileName = $"BaoCaoTongHop_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (_report != null)
                        {
                            _report.ExportToDisk(ExportFormatType.PortableDocFormat, dlg.FileName);
                            MessageBox.Show("Đã xuất báo cáo sang PDF thành công!", "Xuất PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Lưu bản báo cáo dạng HTML/Print nếu chưa tạo tệp .rpt vật lý
                            string htmlFallback = Path.ChangeExtension(dlg.FileName, ".html");
                            ExportDataGridViewToExcelHtml(dgvBaoCao, htmlFallback, cboLoaiBaoCao.Text);
                            MessageBox.Show($"Chưa tìm thấy tệp thiết kế .rpt vật lý trong thư mục chạy.\nHệ thống đã xuất bản báo cáo định dạng in ấn tại:\n{htmlFallback}", "Thông Báo Xuất Báo Cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

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