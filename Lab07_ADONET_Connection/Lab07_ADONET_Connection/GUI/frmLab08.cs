using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Lab07_ADONET_Connection.BUS;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmLab08 : Form
    {
        private SinhVienBUS bus = new SinhVienBUS();

        public frmLab08()
        {
            InitializeComponent();
        }

        private void frmLab08_Load(object sender, EventArgs e)
        {
            LoadComboboxKhoa();
        }

        private void LoadComboboxKhoa()
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add("CNTT");
            cboKhoa.Items.Add("OTO");
            cboKhoa.Items.Add("KT");
            cboKhoa.SelectedIndex = 0;
        }

        // Bài 1: Đếm số sinh viên bằng ExecuteScalar
        private void btnDemSV_Click(object sender, EventArgs e)
        {
            try
            {
                int count = bus.DemSoSinhVien();
                lblTongSV.Text = $"Tổng số sinh viên: {count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bài 2: Đọc danh sách bằng ExecuteReader hiển thị ListBox
        private void btnDocDS_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bus.LayDanhSachSinhVien();
                lstSinhVien.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string line = string.Format("{0} - {1} - {2:N2}", row["MaSV"], row["HoTen"], row["DiemTB"]);
                    lstSinhVien.Items.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bài 3: Thêm sinh viên bằng ExecuteNonQuery
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                double diem = double.TryParse(txtDiemTB.Text, out double d) ? d : 0.0;
                int rows = bus.ThemSinhVien(txtMaSV.Text.Trim(), txtHoTen.Text.Trim(), dtpNgaySinh.Value.Date, radNam.Checked, cboKhoa.Text, diem, txtEmail.Text.Trim());
                MessageBox.Show($"Đã thêm thành công {rows} bản ghi.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDocDS_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bài 4: Cập nhật điểm bằng tham số
        private void btnCapNhatDiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(txtDiemTB.Text, out double diem))
                {
                    MessageBox.Show("Điểm không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int rows = bus.CapNhatDiem(txtMaSV.Text.Trim(), diem);
                MessageBox.Show(rows == 1 ? "Cập nhật thành công!" : "Không tìm thấy mã sinh viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDocDS_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bài 5: Gọi Stored Procedure tìm sinh viên theo Khoa
        private void btnTimByProc_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bus.LaySinhVienTheoKhoa(cboKhoa.Text);
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Stored Procedure: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bài 6: Tìm sinh viên theo Mã
        private void btnTimByMa_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bus.TimSinhVienTheoMa(txtMaSV.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    DataRow row = dt.Rows[0];
                    txtHoTen.Text = row["HoTen"].ToString();
                    txtDiemTB.Text = row["DiemTB"].ToString();
                    cboKhoa.Text = row["MaKhoa"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên có mã: " + txtMaSV.Text.Trim(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bài 7: Thống kê điểm cao nhất theo khoa (Xử lý DBNull)
        private void btnMaxDiem_Click(object sender, EventArgs e)
        {
            try
            {
                double maxDiem = bus.ThongKeDiemCaoNhat(cboKhoa.Text);
                MessageBox.Show($"Điểm trung bình cao nhất của Khoa [{cboKhoa.Text}] là: {maxDiem:N2}", "Thống Kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bài 8: Xóa có xác nhận & xử lý lỗi khóa ngoại
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên [{maSV}] không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int rows = bus.XoaSinhVien(maSV);
                    MessageBox.Show(rows > 0 ? "Xóa sinh viên thành công!" : "Không tìm thấy mã sinh viên để xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDocDS_Click(sender, e);
                }
                catch (MySqlException ex)
                {
                    // Mã lỗi 1451: Key constraint constraint fails
                    if (ex.Number == 1451)
                    {
                        MessageBox.Show($"Không thể xóa sinh viên [{maSV}] vì đang có dữ liệu đăng ký học phần liên quan!", "Lỗi Ràng Buộc Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi MySQL: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Bài 9: Thêm sinh viên & Nhận tham số OUTPUT
        private void btnThemOutput_Click(object sender, EventArgs e)
        {
            try
            {
                double diem = double.TryParse(txtDiemTB.Text, out double d) ? d : 0.0;
                int rows = bus.ThemSinhVienCoOutput(txtMaSV.Text.Trim(), txtHoTen.Text.Trim(), dtpNgaySinh.Value.Date, radNam.Checked, cboKhoa.Text, diem, txtEmail.Text.Trim(), out int tongSoSV);

                MessageBox.Show($"Đã thêm {rows} sinh viên thành công!\nTổng số sinh viên hiện có trong CSDL: {tongSoSV}", "Thông Báo (OUTPUT Parameter)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTongSV.Text = $"Tổng số sinh viên: {tongSoSV}";
                btnDocDS_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Stored Procedure Output: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}