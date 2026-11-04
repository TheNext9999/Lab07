using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Lab07_ADONET_Connection.BUS;
using Lab07_ADONET_Connection.DTO;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmLab11 : Form
    {
        private SinhVienBUS svBus = new SinhVienBUS();
        private KhoaBUS khoaBus = new KhoaBUS();

        public frmLab11()
        {
            InitializeComponent();
        }

        private void frmLab11_Load(object sender, EventArgs e)
        {
            LoadKhoaComboBox();
            LoadStudents();
            LoadKhoaGrid();
        }

        private void LoadKhoaComboBox()
        {
            try
            {
                DataTable dtKhoa = khoaBus.GetAllKhoa();

                // Nạp cho CBO thông tin
                cboKhoa.DataSource = dtKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";

                // Nạp cho CBO Tìm kiếm (Thêm lựa chọn "Tất cả")
                DataTable dtSearchKhoa = dtKhoa.Copy();
                DataRow drAll = dtSearchKhoa.NewRow();
                drAll["MaKhoa"] = "ALL";
                drAll["TenKhoa"] = "-- Tất cả các Khoa --";
                dtSearchKhoa.Rows.InsertAt(drAll, 0);

                cboTimKhoa.DataSource = dtSearchKhoa;
                cboTimKhoa.DisplayMember = "TenKhoa";
                cboTimKhoa.ValueMember = "MaKhoa";
                cboTimKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                HandleError(ex, "Lỗi Nạp Danh Sách Khoa");
            }
        }

        private void LoadStudents()
        {
            try
            {
                DataTable dt = svBus.Search(txtTimTuKhoa.Text, cboTimKhoa.SelectedValue?.ToString());
                dgvSinhVien.DataSource = dt;
                lblStatus.Text = $"Đã tải {dt.Rows.Count} sinh viên đang hoạt động (IsActive = 1).";
            }
            catch (Exception ex)
            {
                HandleError(ex, "Lỗi Tải Sinh Viên");
            }
        }

        private void LoadKhoaGrid()
        {
            try
            {
                DataTable dt = khoaBus.GetAllKhoa();
                dgvKhoa.DataSource = dt;
            }
            catch (Exception ex)
            {
                HandleError(ex, "Lỗi Tải Bảng Khoa");
            }
        }

        private SinhVienDTO GetSinhVienFromForm()
        {
            return new SinhVienDTO
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = radNam.Checked,
                MaKhoa = cboKhoa.SelectedValue?.ToString(),
                DiemTB = double.TryParse(txtDiemTB.Text.Trim(), out double d) ? d : -1,
                Email = txtEmail.Text.Trim()
            };
        }

        #region EVENT SINH VIÊN (BÀI 1 - 5, 7 - 10)
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVienDTO dto = GetSinhVienFromForm();
                svBus.Add(dto);
                LoadStudents();
                ClearSinhVienForm();
                MessageBox.Show("Thêm sinh viên mới thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HandleError(ex, "Thêm Sinh Viên Thất Bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVienDTO dto = GetSinhVienFromForm();
                svBus.Update(dto);
                LoadStudents();
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HandleError(ex, "Cập Nhật Sinh Viên Thất Bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã Sinh Viên cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loaiXoa = chkXoaMem.Checked ? "XÓA MỀM (Khôi phục được)" : "XÓA VẬT LÝ (Xóa vĩnh viễn)";
            if (MessageBox.Show($"Bạn có chắc chắn muốn {loaiXoa} sinh viên [{maSV}]?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    svBus.Delete(maSV, chkXoaMem.Checked);
                    LoadStudents();
                    ClearSinhVienForm();
                    MessageBox.Show($"Đã {loaiXoa} thành công sinh viên [{maSV}]!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    HandleError(ex, "Xóa Sinh Viên Thất Bại");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearSinhVienForm();
            txtTimTuKhoa.Clear();
            cboTimKhoa.SelectedIndex = 0;
            LoadStudents();
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSinhVien.CurrentRow != null)
            {
                DataGridViewRow row = dgvSinhVien.CurrentRow;
                txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ns))
                    dtpNgaySinh.Value = ns;

                string gioiTinhText = row.Cells["GioiTinhText"].Value?.ToString();
                if (gioiTinhText == "Nam") radNam.Checked = true;
                else radNu.Checked = true;

                cboKhoa.SelectedValue = row.Cells["MaKhoa"].Value?.ToString();
                txtDiemTB.Text = row.Cells["DiemTB"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
            }
        }

        private void ClearSinhVienForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Today.AddYears(-18);
            radNam.Checked = true;
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            txtDiemTB.Clear();
            txtEmail.Clear();
            txtMaSV.Focus();
        }
        #endregion

        #region EVENT KHOA (BÀI 6)
        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                KhoaDTO dto = new KhoaDTO(txtMaKhoa.Text.Trim(), txtTenKhoa.Text.Trim());
                khoaBus.AddKhoa(dto);
                LoadKhoaGrid();
                LoadKhoaComboBox();
                txtMaKhoa.Clear();
                txtTenKhoa.Clear();
                MessageBox.Show("Thêm Khoa mới thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HandleError(ex, "Thêm Khoa Thất Bại");
            }
        }

        private void btnSuaKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                KhoaDTO dto = new KhoaDTO(txtMaKhoa.Text.Trim(), txtTenKhoa.Text.Trim());
                khoaBus.UpdateKhoa(dto);
                LoadKhoaGrid();
                LoadKhoaComboBox();
                MessageBox.Show("Cập nhật tên Khoa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HandleError(ex, "Sửa Khoa Thất Bại");
            }
        }

        private void btnXoaKhoa_Click(object sender, EventArgs e)
        {
            string maKhoa = txtMaKhoa.Text.Trim();
            if (string.IsNullOrEmpty(maKhoa))
            {
                MessageBox.Show("Vui lòng chọn Mã Khoa cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa Khoa [{maKhoa}]?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    khoaBus.DeleteKhoa(maKhoa);
                    LoadKhoaGrid();
                    LoadKhoaComboBox();
                    txtMaKhoa.Clear();
                    txtTenKhoa.Clear();
                    MessageBox.Show($"Đã xóa Khoa [{maKhoa}] thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    HandleError(ex, "Xóa Khoa Thất Bại");
                }
            }
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvKhoa.CurrentRow != null)
            {
                txtMaKhoa.Text = dgvKhoa.CurrentRow.Cells["MaKhoa"].Value?.ToString();
                txtTenKhoa.Text = dgvKhoa.CurrentRow.Cells["TenKhoa"].Value?.ToString();
            }
        }
        #endregion

        #region BÀI 10: CHUẨN HÓA XỬ LÝ LỖI TẬP TRUNG
        private void HandleError(Exception ex, string title)
        {
            if (ex is ArgumentException)
            {
                MessageBox.Show($"[Lỗi Nhập Liệu / Nghiệp Vụ]: {ex.Message}", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ex is MySqlException myEx)
            {
                if (myEx.Number == 1062) // Trùng Khóa
                {
                    MessageBox.Show("[Lỗi CSDL]: Dữ liệu (Mã hoặc Email) đã tồn tại trong CSDL.", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (myEx.Number == 1451) // Ràng buộc khóa ngoại
                {
                    MessageBox.Show("[Lỗi Ràng Buộc Khóa Ngoại]: Không thể xóa do dữ liệu đang được sử dụng ở bảng khác.", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"[Lỗi MySQL Database - Mã {myEx.Number}]: {myEx.Message}", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"[Lỗi Nạn Hệ Thống]: {ex.Message}", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblStatus.Text = $"Trạng thái: {title} - {ex.Message}";
        }
        #endregion
    }
}