using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Lab07_ADONET_Connection.BUS;
using Lab07_ADONET_Connection.DAL;
using Lab07_ADONET_Connection.DTO;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmLab12 : Form
    {
        private KhoaBUS khoaBus = new KhoaBUS();
        private SinhVienBUS svBus = new SinhVienBUS();
        private DangKyDAL dangKyDal = new DangKyDAL();
        private DateTime? _selectedRowTimestamp = null;

        public frmLab12()
        {
            InitializeComponent();
        }

        private void frmLab12_Load(object sender, EventArgs e)
        {
            LoadKhoaMaster();
            LoadKhoaComboBox();
            LoadBulkGradesData();
        }

        #region BÀI 1 & 2: MASTER-DETAIL 2 CẤP (KHOA -> SINH VIÊN -> ĐĂNG KÝ)
        private void LoadKhoaMaster()
        {
            try
            {
                DataTable dt = khoaBus.GetAllKhoa();
                dgvKhoaMaster.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Khoa: " + ex.Message, "Lỗi Master", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhoaMaster_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoaMaster.CurrentRow == null) return;

            string maKhoa = Convert.ToString(dgvKhoaMaster.CurrentRow.Cells["MaKhoa"].Value);
            lblDetailSV.Text = $"Detail 1: Danh sách Sinh viên thuộc khoa [{maKhoa}]";

            try
            {
                DataTable dtSV = svBus.Search("", maKhoa);
                dgvSinhVienDetail.DataSource = dtSV;

                if (dtSV.Rows.Count == 0)
                {
                    dgvDangKyDetail.DataSource = null;
                    lblDetailDangKy.Text = "Detail 2: Không có đăng ký môn học.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi tải sinh viên: " + ex.Message;
            }
        }

        private void dgvSinhVienDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVienDetail.CurrentRow == null) return;

            string maSV = Convert.ToString(dgvSinhVienDetail.CurrentRow.Cells["MaSV"].Value);
            string hoTen = Convert.ToString(dgvSinhVienDetail.CurrentRow.Cells["HoTen"].Value);
            lblDetailDangKy.Text = $"Detail 2: Môn học đăng ký của SV [{maSV} - {hoTen}]";

            try
            {
                DataTable dtDK = dangKyDal.GetByStudent(maSV);
                dgvDangKyDetail.DataSource = dtDK;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi tải đăng ký: " + ex.Message;
            }
        }
        #endregion

        #region BÀI 3 & 4: THỰC THI TRANSACTION VÀ KIỂM CHỨNG ROLLBACK
        // Bài 4: Cố ý truyền mã môn sai để kiểm chứng ROLLBACK 100%
        private void btnTestRollbackFail_Click(object sender, EventArgs e)
        {
            string maSVSauTest = "SV_TEST_FAIL";
            SinhVienDTO svDto = new SinhVienDTO
            {
                MaSV = maSVSauTest,
                HoTen = "Sinh Viên Test Rollback",
                NgaySinh = new DateTime(2003, 5, 10),
                GioiTinh = true,
                MaKhoa = "CNTT",
                DiemTB = 8.0,
                Email = "test_fail@eaut.edu.vn"
            };

            // Danh sách đăng ký chứa 1 mã học phần KHÔNG TỒN TẠI ('HP_KHONG_TON_TAI')
            List<DangKyDTO> dsDangKySai = new List<DangKyDTO>
            {
                new DangKyDTO(maSVSauTest, "IT3212", 1, 8.5),
                new DangKyDTO(maSVSauTest, "HP_KHONG_TON_TAI", 1, 9.0) // Gây ra lỗi Khóa ngoại
            };

            try
            {
                lblStatus.Text = "Đang chạy giao dịch cố ý gây lỗi...";
                svBus.AddStudentWithEnrollments(svDto, dsDangKySai);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n--> Đã kiểm chứng: Sinh viên ['" + maSVSauTest + "'] đã bị hoàn tác (Rollback) hoàn toàn khỏi CSDL MySQL!", "Kiểm Chứng Rollback Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Re-Query để chứng minh sinh viên không bị lưu dở dang
                DataTable checkTable = svBus.Search(maSVSauTest, "");
                if (checkTable.Rows.Count == 0)
                {
                    lblStatus.Text = $"XÁC NHẬN: Mã sinh viên [{maSVSauTest}] KHÔNG TỒN TẠI trong hệ thống sau khi Rollback.";
                }
            }
        }

        // Bài 3: Giao dịch HỢP LỆ (Commit thành công)
        private void btnTestRollbackSuccess_Click(object sender, EventArgs e)
        {
            string maSVTest = "SV_TX_" + DateTime.Now.ToString("HHmmss");
            SinhVienDTO svDto = new SinhVienDTO
            {
                MaSV = maSVTest,
                HoTen = "Sinh Viên Transaction Hợp Lệ",
                NgaySinh = new DateTime(2004, 8, 20),
                GioiTinh = true,
                MaKhoa = "CNTT",
                DiemTB = 8.5,
                Email = $"{maSVTest.ToLower()}@eaut.edu.vn"
            };

            List<DangKyDTO> dsDangKyHopLe = new List<DangKyDTO>
            {
                new DangKyDTO(maSVTest, "IT3212", 1, 8.5),
                new DangKyDTO(maSVTest, "IT3100", 1, 9.0)
            };

            try
            {
                bool ok = svBus.AddStudentWithEnrollments(svDto, dsDangKyHopLe);
                if (ok)
                {
                    MessageBox.Show($"Thêm thành công sinh viên [{maSVTest}] và 2 môn đăng ký trong 1 Transaction!", "Giao Dịch Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKhoaMaster();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Transaction: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region BÀI 6: CHUYỂN KHOA VÀ GHI NẠP LỊCH SỬ (TRANSACTION)
        private void LoadKhoaComboBox()
        {
            try
            {
                cboKhoaMoi.DataSource = khoaBus.GetAllKhoa();
                cboKhoaMoi.DisplayMember = "TenKhoa";
                cboKhoaMoi.ValueMember = "MaKhoa";
            }
            catch { }
        }

        private void btnChuyenKhoaTx_Click(object sender, EventArgs e)
        {
            if (dgvSinhVienDetail.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 Sinh viên ở Tab Master-Detail trước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = Convert.ToString(dgvSinhVienDetail.CurrentRow.Cells["MaSV"].Value);
            string maKhoaCu = Convert.ToString(dgvSinhVienDetail.CurrentRow.Cells["MaKhoa"].Value);
            string maKhoaMoi = Convert.ToString(cboKhoaMoi.SelectedValue);
            string lyDo = txtLyDoChuyen.Text.Trim();

            if (maKhoaCu == maKhoaMoi)
            {
                MessageBox.Show("Khoa mới phải khác khoa hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                svBus.TransferDepartment(maSV, maKhoaCu, maKhoaMoi, lyDo);
                MessageBox.Show($"Đã chuyển sinh viên [{maSV}] từ khoa [{maKhoaCu}] sang [{maKhoaMoi}] và ghi nhật ký vào 'LichSuChuyenKhoa'!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhoaMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển khoa Transaction: " + ex.Message, "Lỗi Rollback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region BÀI 8: CẬP NHẬT ĐIỂM HÀNG LOẠT TRONG TRANSACTION (BATCH UPDATE)
        private void LoadBulkGradesData()
        {
            try
            {
                // Nạp danh sách đăng ký cho phép sửa điểm trực tiếp
                DataTable dt = dangKyDal.GetByStudent("SV001");
                dgvBulkGrades.DataSource = dt;
            }
            catch { }
        }

        private void btnBulkUpdateGrades_Click(object sender, EventArgs e)
        {
            if (dgvBulkGrades.Rows.Count == 0) return;

            List<DangKyDTO> dsCapNhat = new List<DangKyDTO>();
            try
            {
                foreach (DataGridViewRow row in dgvBulkGrades.Rows)
                {
                    if (row.IsNewRow) continue;
                    string maSV = Convert.ToString(row.Cells["MaSV"].Value);
                    string maHP = Convert.ToString(row.Cells["MaHP"].Value);
                    int hocKy = Convert.ToInt32(row.Cells["HocKy"].Value);
                    double diem = Convert.ToDouble(row.Cells["Diem"].Value);

                    dsCapNhat.Add(new DangKyDTO(maSV, maHP, hocKy, diem));
                }

                svBus.BulkUpdateGrades(dsCapNhat);
                MessageBox.Show($"Cập nhật điểm hàng loạt thành công cho {dsCapNhat.Count} bản ghi!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật điểm hàng loạt (Đã Rollback): " + ex.Message, "Lỗi Batch Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadBulkGradesData(); // Reset lại bảng điểm
            }
        }
        #endregion

        #region BÀI 9: KIỂM SOÁT XUNG ĐỘT ĐỒNG THỜI (OPTIMISTIC CONCURRENCY)
        private void btnSuaDiemConcurrency_Click(object sender, EventArgs e)
        {
            if (dgvDangKyDetail.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng môn học đăng ký bên Tab Master-Detail!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvDangKyDetail.CurrentRow;
            string maSV = Convert.ToString(row.Cells["MaSV"].Value);
            string maHP = Convert.ToString(row.Cells["MaHP"].Value);
            int hocKy = Convert.ToInt32(row.Cells["HocKy"].Value);
            DateTime timestampBanDau = Convert.ToDateTime(row.Cells["UpdatedAt"].Value);

            if (!double.TryParse(txtDiemConcurrency.Text, out double diemMoi))
            {
                MessageBox.Show("Điểm nhập vào không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = dangKyDal.UpdateGradeWithConcurrency(maSV, maHP, hocKy, diemMoi, timestampBanDau);
            if (success)
            {
                MessageBox.Show("Cập nhật điểm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSinhVienDetail_SelectionChanged(sender, e); // Reload lại dữ liệu và timestamp mới
            }
            else
            {
                MessageBox.Show("PHÁT HIỆN XUNG ĐỘT (Concurrency Conflict):\nBản ghi này vừa bị người dùng khác sửa đổi hoặc thay đổi dữ liệu!\nHệ thống sẽ tải lại dữ liệu mới nhất.", "Xung Đột Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvSinhVienDetail_SelectionChanged(sender, e);
            }
        }
        #endregion
    }
}