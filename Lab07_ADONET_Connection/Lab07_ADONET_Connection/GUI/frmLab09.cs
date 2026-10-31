using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lab07_ADONET_Connection.BUS;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmLab09 : Form
    {
        private SinhVienBUS bus = new SinhVienBUS();
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;

        public frmLab09()
        {
            InitializeComponent();
        }

        private void frmLab09_Load(object sender, EventArgs e)
        {
            InitControlData();
            ExecuteSearchAndLoadData();
        }

        private void InitControlData()
        {
            // Init ComboBox Khoa Filter
            cboKhoaFilter.Items.Clear();
            cboKhoaFilter.Items.Add(new { Text = "--- Tất cả Khoa ---", Value = "ALL" });
            cboKhoaFilter.Items.Add(new { Text = "Công nghệ Thông tin", Value = "CNTT" });
            cboKhoaFilter.Items.Add(new { Text = "Công nghệ Ô tô", Value = "OTO" });
            cboKhoaFilter.Items.Add(new { Text = "Kinh tế", Value = "KT" });
            cboKhoaFilter.DisplayMember = "Text";
            cboKhoaFilter.ValueMember = "Value";
            cboKhoaFilter.SelectedIndex = 0;

            // Init ComboBox Giới tính Filter
            cboGioiTinhFilter.Items.Clear();
            cboGioiTinhFilter.Items.Add("Tất cả");
            cboGioiTinhFilter.Items.Add("Nam");
            cboGioiTinhFilter.Items.Add("Nữ");
            cboGioiTinhFilter.SelectedIndex = 0;

            // Init ComboBox Sắp xếp
            cboSortColumn.Items.Clear();
            cboSortColumn.Items.Add(new { Text = "Mã Sinh Viên", Value = "MaSV" });
            cboSortColumn.Items.Add(new { Text = "Họ và Tên", Value = "HoTen" });
            cboSortColumn.Items.Add(new { Text = "Điểm TB", Value = "DiemTB" });
            cboSortColumn.Items.Add(new { Text = "Ngày sinh", Value = "NgaySinh" });
            cboSortColumn.DisplayMember = "Text";
            cboSortColumn.ValueMember = "Value";
            cboSortColumn.SelectedIndex = 0;

            // Page Size Selector
            cboPageSize.Items.Clear();
            cboPageSize.Items.Add(5);
            cboPageSize.Items.Add(10);
            cboPageSize.Items.Add(20);
            cboPageSize.SelectedIndex = 1;
        }

        // Thực thi bộ lọc đa tiêu chí (Bài 2, 3, 4, 6, 7, 8)
        private void ExecuteSearchAndLoadData()
        {
            try
            {
                string maSV = txtMaSVFilter.Text.Trim();
                string hoTen = txtTimKiemTen.Text.Trim();
                dynamic selKhoa = cboKhoaFilter.SelectedItem;
                string maKhoa = selKhoa != null ? selKhoa.Value : "ALL";

                int? gioiTinh = null;
                if (cboGioiTinhFilter.SelectedIndex == 1) gioiTinh = 1;
                else if (cboGioiTinhFilter.SelectedIndex == 2) gioiTinh = 0;

                double? minDiem = double.TryParse(txtMinDiem.Text, out double minD) ? minD : (double?)null;
                double? maxDiem = double.TryParse(txtMaxDiem.Text, out double maxD) ? maxD : (double?)null;

                int? minTuoi = (int)numMinTuoi.Value;
                int? maxTuoi = (int)numMaxTuoi.Value;

                dynamic selSort = cboSortColumn.SelectedItem;
                string sortCol = selSort != null ? selSort.Value : "MaSV";
                bool isAsc = radAsc.Checked;

                DataTable dt = bus.SearchMultiCriteria(maSV, hoTen, maKhoa, gioiTinh, minDiem, maxDiem,
                                                       minTuoi, maxTuoi, sortCol, isAsc,
                                                       currentPage, pageSize, out totalRecords);

                dgvSinhVien.DataSource = dt;
                ConfigureDataGridViewHeaders();

                // Tính toán số trang
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                if (totalPages < 1) totalPages = 1;

                lblPhanTrangInfo.Text = $"Trang {currentPage} / {totalPages} (Tổng số: {totalRecords} bản ghi)";
                btnTrangTruoc.Enabled = currentPage > 1;
                btnTrangSau.Enabled = currentPage < totalPages;

                lblStatus.Text = $"Đã tải {dt.Rows.Count} dòng dữ liệu trên trang {currentPage}. Tổng số bản ghi thỏa mãn: {totalRecords}.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc dữ liệu: " + ex.Message, "Lỗi Query", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViewHeaders()
        {
            if (dgvSinhVien.Columns.Contains("MaSV")) dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvSinhVien.Columns.Contains("HoTen")) dgvSinhVien.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvSinhVien.Columns.Contains("NgaySinh"))
            {
                dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvSinhVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvSinhVien.Columns.Contains("GioiTinhText")) dgvSinhVien.Columns["GioiTinhText"].HeaderText = "Giới Tính";
            if (dgvSinhVien.Columns.Contains("TenKhoa")) dgvSinhVien.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            if (dgvSinhVien.Columns.Contains("DiemTB"))
            {
                dgvSinhVien.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvSinhVien.Columns["DiemTB"].DefaultCellStyle.Format = "N2";
            }
            if (dgvSinhVien.Columns.Contains("Email")) dgvSinhVien.Columns["Email"].HeaderText = "Email";

            // Ẩn các cột bổ trợ
            if (dgvSinhVien.Columns.Contains("MaKhoa")) dgvSinhVien.Columns["MaKhoa"].Visible = false;
            if (dgvSinhVien.Columns.Contains("GioiTinh")) dgvSinhVien.Columns["GioiTinh"].Visible = false;
            if (dgvSinhVien.Columns.Contains("Tuoi")) dgvSinhVien.Columns["Tuoi"].HeaderText = "Tuổi";
        }

        // Bài 5: Đồng bộ dữ liệu dòng chọn lên vùng chi tiết
        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null || dgvSinhVien.CurrentRow.Index < 0) return;

            DataGridViewRow row = dgvSinhVien.CurrentRow;
            txtDetailMaSV.Text = Convert.ToString(row.Cells["MaSV"].Value);
            txtDetailHoTen.Text = Convert.ToString(row.Cells["HoTen"].Value);

            if (row.Cells["NgaySinh"].Value != DBNull.Value && row.Cells["NgaySinh"].Value != null)
                dtpDetailNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            string gioiTinh = Convert.ToString(row.Cells["GioiTinhText"].Value);
            radDetailNam.Checked = (gioiTinh == "Nam");
            radDetailNu.Checked = (gioiTinh == "Nữ");

            txtDetailDiemTB.Text = string.Format("{0:N2}", row.Cells["DiemTB"].Value);
            cboDetailKhoa.Text = Convert.ToString(row.Cells["TenKhoa"].Value);
            txtDetailEmail.Text = Convert.ToString(row.Cells["Email"].Value);

            lblStatus.Text = $"Đang chọn Sinh viên: [{txtDetailMaSV.Text}] - {txtDetailHoTen.Text} - Khoa {cboDetailKhoa.Text}";
        }

        // Bài 9: Tô màu định dạng điều kiện trên DataGridView
        private void dgvSinhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSinhVien.Columns[e.ColumnIndex].Name == "DiemTB" && e.Value != null)
            {
                if (double.TryParse(e.Value.ToString(), out double diem))
                {
                    if (diem < 5.0)
                    {
                        e.CellStyle.BackColor = Color.MistyRose;
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(dgvSinhVien.Font, FontStyle.Bold);
                    }
                    else if (diem >= 8.0)
                    {
                        e.CellStyle.BackColor = Color.Honeydew;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.Font = new Font(dgvSinhVien.Font, FontStyle.Bold);
                    }
                }
            }
        }

        // Nút Tìm Kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            ExecuteSearchAndLoadData();
        }

        // Nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSVFilter.Clear();
            txtTimKiemTen.Clear();
            cboKhoaFilter.SelectedIndex = 0;
            cboGioiTinhFilter.SelectedIndex = 0;
            txtMinDiem.Text = "0.0";
            txtMaxDiem.Text = "10.0";
            numMinTuoi.Value = 17;
            numMaxTuoi.Value = 30;
            cboSortColumn.SelectedIndex = 0;
            radAsc.Checked = true;
            currentPage = 1;
            ExecuteSearchAndLoadData();
        }

        // Chuyển trang Phân trang (Bài 4)
        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ExecuteSearchAndLoadData();
            }
        }

        private void btnTrangSau_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                ExecuteSearchAndLoadData();
            }
        }

        private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPageSize.SelectedItem != null)
            {
                pageSize = (int)cboPageSize.SelectedItem;
                currentPage = 1;
                ExecuteSearchAndLoadData();
            }
        }

        // Bài 10: Xuất kết quả tìm kiếm ra tệp CSV hỗ trợ tiếng Việt UTF-8 BOM
        private void btnXuatCSV_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất CSV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV File (*.csv)|*.csv",
                FileName = $"DanhSachSinhVien_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        // Ghi tiêu đề cột
                        var headers = dgvSinhVien.Columns.Cast<DataGridViewColumn>()
                            .Where(c => c.Visible)
                            .Select(c => "\"" + c.HeaderText.Replace("\"", "\"\"") + "\"");
                        sw.WriteLine(string.Join(",", headers));

                        // Ghi dữ liệu từng dòng
                        foreach (DataGridViewRow row in dgvSinhVien.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var cells = dgvSinhVien.Columns.Cast<DataGridViewColumn>()
                                .Where(c => c.Visible)
                                .Select(c => "\"" + (row.Cells[c.Index].Value ?? "").ToString().Replace("\"", "\"\"") + "\"");
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }

                    MessageBox.Show("Xuất tệp CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất tệp: " + ex.Message, "Lỗi File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}