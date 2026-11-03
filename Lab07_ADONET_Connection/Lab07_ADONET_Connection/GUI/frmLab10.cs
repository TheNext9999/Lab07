using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Lab07_ADONET_Connection.BUS;
using Lab07_ADONET_Connection.DAL;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmLab10 : Form
    {
        private SinhVienBUS bus = new SinhVienBUS();
        private DataSet _dsQLSV;
        private MySqlConnection _connUpdate;
        private MySqlDataAdapter _adapterUpdate;
        private MySqlCommandBuilder _builderUpdate;
        private DataTable _tableUpdate;
        private DataTable _manualTable;

        public frmLab10()
        {
            InitializeComponent();
        }

        private void frmLab10_Load(object sender, EventArgs e)
        {
            InitControlData();
        }

        private void InitControlData()
        {
            cboKhoaDataView.Items.Clear();
            cboKhoaDataView.Items.Add("CNTT");
            cboKhoaDataView.Items.Add("OTO");
            cboKhoaDataView.Items.Add("KT");
            cboKhoaDataView.SelectedIndex = 0;
        }

        #region BÀI 1: FILL DATATABLE BẰNG MYSQLDATAADAPTER
        private void btnFillDataTable_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bus.GetStudentTableDisconnected();
                dgvSinhVienCoBan.DataSource = dt;
                lblStatus.Text = $"Bài 1: Đã Fill {dt.Rows.Count} sinh viên vào DataTable ngắt kết nối thành công!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Fill DataTable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region BÀI 2 & 3: DATASET CHỨA NHIỀU BẢNG & DATARELATION
        private void btnFillDataSet_Click(object sender, EventArgs e)
        {
            try
            {
                _dsQLSV = bus.GetQLSVDataSet();
                dgvKhoaCoBan.DataSource = _dsQLSV.Tables["Khoa"];
                dgvSinhVienCoBan.DataSource = _dsQLSV.Tables["SinhVien"];
                lblStatus.Text = "Bài 2: Đã Fill thành công DataSet 'QLSinhVien' chứa 2 bảng [Khoa] và [SinhVien].";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Fill DataSet: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemRelation_Click(object sender, EventArgs e)
        {
            if (_dsQLSV == null) btnFillDataSet_Click(sender, e);

            try
            {
                if (dgvKhoaCoBan.CurrentRow != null)
                {
                    DataRowView drv = dgvKhoaCoBan.CurrentRow.DataBoundItem as DataRowView;
                    if (drv != null)
                    {
                        DataRow khoaRow = drv.Row;
                        DataRow[] childRows = khoaRow.GetChildRows("FK_Khoa_SinhVien");

                        lstChildRows.Items.Clear();
                        lstChildRows.Items.Add($"=== DANH SÁCH CON CỦA KHOA [{khoaRow["TenKhoa"]}] (GetChildRows) ===");
                        foreach (DataRow child in childRows)
                        {
                            lstChildRows.Items.Add($"• Mã SV: {child["MaSV"]} - Họ tên: {child["HoTen"]} - Điểm TB: {child["DiemTB"]}");
                        }
                        lblStatus.Text = $"Bài 3: Đã lấy {childRows.Length} sinh viên qua DataRelation 'FK_Khoa_SinhVien'.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi DataRelation: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhoaCoBan_SelectionChanged(object sender, EventArgs e)
        {
            if (_dsQLSV != null && _dsQLSV.Relations.Contains("FK_Khoa_SinhVien"))
            {
                btnXemRelation_Click(sender, e);
            }
        }
        #endregion

        #region BÀI 4: LỌC VÀ SẮP XẾP BẰNG DATAVIEW
        private void btnLocDataView_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dsQLSV == null) _dsQLSV = bus.GetQLSVDataSet();

                DataView dv = new DataView(_dsQLSV.Tables["SinhVien"]);
                string maKhoa = cboKhoaDataView.Text.Replace("'", "''");
                double minDiem = double.TryParse(txtMinDiemDV.Text, out double d) ? d : 0.0;

                dv.RowFilter = string.Format("MaKhoa = '{0}' AND DiemTB >= {1}", maKhoa, minDiem.ToString(System.Globalization.CultureInfo.InvariantCulture));
                dv.Sort = "DiemTB DESC, HoTen ASC";

                dgvDataView.DataSource = dv;
                lblStatus.Text = $"Bài 4: DataView đã lọc Khoa [{maKhoa}], Điểm >= {minDiem}. Số kết quả trong bộ nhớ: {dv.Count}.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi DataView Filter: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region BÀI 5: CẬP NHẬT BẰNG MYSQLCOMMANDBUILDER
        private void btnLoadForUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_connUpdate == null) _connUpdate = DbConnectionFactory.Create();
                _adapterUpdate = bus.GetStudentAdapterForUpdate(_connUpdate, out _builderUpdate);
                _tableUpdate = new DataTable();
                _adapterUpdate.Fill(_tableUpdate);

                dgvDataView.DataSource = _tableUpdate;
                lblStatus.Text = "Bài 5: Đã nạp bảng cho phép chỉnh sửa trực tiếp trên lưới (Editable Grid).";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp bảng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (_adapterUpdate == null || _tableUpdate == null)
                {
                    MessageBox.Show("Vui lòng bấm 'Nạp Bảng Cho Phép Sửa' trước khi lưu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvDataView.EndEdit();
                int rows = _adapterUpdate.Update(_tableUpdate);
                MessageBox.Show($"Đã cập nhật thành công {rows} thay đổi về CSDL MySQL!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = $"Bài 5: Đã lưu {rows} bản ghi thay đổi về CSDL thành công.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Cập nhật MySQL: " + ex.Message, "Lỗi Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region BÀI 6: TẠO DATATABLE THỦ CÔNG & CỘT TÍNH TOÁN XEPLOAI
        private void btnTaoTableThuCong_Click(object sender, EventArgs e)
        {
            _manualTable = new DataTable("BangDiemThuCong");

            // Tạo các cột
            _manualTable.Columns.Add("MaSV", typeof(string));
            _manualTable.Columns.Add("HoTen", typeof(string));
            _manualTable.Columns.Add("DiemTB", typeof(double));

            // Cột tính toán XepLoai bằng Expression
            DataColumn colXepLoai = new DataColumn("XepLoai", typeof(string));
            colXepLoai.Expression = "IIF(DiemTB >= 8.0, 'Giỏi', IIF(DiemTB >= 6.5, 'Khá', IIF(DiemTB >= 5.0, 'Trung Bình', 'Yếu')))";
            _manualTable.Columns.Add(colXepLoai);

            // Thêm dữ liệu mẫu
            _manualTable.Rows.Add("SV901", "Nguyễn Văn Nam", 8.5);
            _manualTable.Rows.Add("SV902", "Trần Thị Mai", 7.2);
            _manualTable.Rows.Add("SV903", "Lê Hoàng Long", 5.5);
            _manualTable.Rows.Add("SV904", "Phạm Quốc Bảo", 3.8);

            dgvRowState.DataSource = _manualTable;
            lblStatus.Text = "Bài 6: Đã tạo DataTable thủ công và tự động tính cột Xếp Loại bằng Expression.";
        }
        #endregion

        #region BÀI 7 & 8: THEO DÕI ROWSTATE, GETCHANGES, ACCEPT/REJECTCHANGES
        private void btnTheoDoiRowState_Click(object sender, EventArgs e)
        {
            if (_manualTable == null) btnTaoTableThuCong_Click(sender, e);

            rtbLogState.Clear();
            rtbLogState.AppendText("=== KIỂM TRA TRẠNG THÁI TỪNG DÒNG (DataRowState) ===\n\n");

            foreach (DataRow row in _manualTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    rtbLogState.AppendText($"[MaSV: {row["MaSV"]}] -> State: {row.RowState}\n");
                }
                else
                {
                    rtbLogState.AppendText($"[Dòng đã bị xóa] -> State: {row.RowState}\n");
                }
            }

            DataTable changes = _manualTable.GetChanges();
            if (changes != null)
            {
                rtbLogState.AppendText($"\n-> Tổng số dòng có thay đổi (GetChanges): {changes.Rows.Count}\n");
            }
            else
            {
                rtbLogState.AppendText("\n-> Không có dòng nào thay đổi (GetChanges = null).\n");
            }
        }

        private void btnAcceptChanges_Click(object sender, EventArgs e)
        {
            if (_manualTable != null)
            {
                _manualTable.AcceptChanges();
                btnTheoDoiRowState_Click(sender, e);
                MessageBox.Show("Đã chấp nhận các thay đổi cục bộ (AcceptChanges)! Trạng thái các dòng chuyển về Unchanged.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRejectChanges_Click(object sender, EventArgs e)
        {
            if (_manualTable != null)
            {
                _manualTable.RejectChanges();
                btnTheoDoiRowState_Click(sender, e);
                MessageBox.Show("Đã hoàn tác các thay đổi cục bộ (RejectChanges)! Dữ liệu trở về trạng thái ban đầu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region BÀI 9: LƯU VÀ ĐỌC DATASET DẠNG XML SCHEMA
        private string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QLSinhVien_Data.xml");

        private void btnLuuXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dsQLSV == null) _dsQLSV = bus.GetQLSVDataSet();

                // Lưu dữ liệu kèm Schema
                _dsQLSV.WriteXml(xmlPath, XmlWriteMode.WriteSchema);
                MessageBox.Show($"Đã xuất DataSet ra tệp XML kèm Schema thành công!\nĐường dẫn: {xmlPath}", "Lưu XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Bài 9: Đã ghi cấu trúc và dữ liệu DataSet thành công ra XML.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi XML: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDocXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(xmlPath))
                {
                    MessageBox.Show("Chưa có tệp XML! Bấm 'Lưu DataSet Ra File XML Schema' trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet dsOffline = new DataSet();
                dsOffline.ReadXml(xmlPath);

                dgvXmlMerge.DataSource = dsOffline.Tables["SinhVien"];
                MessageBox.Show($"Đọc tệp XML thành công ở chế độ ngắt kết nối (Offline)!\nTổng số sinh viên trong tệp: {dsOffline.Tables["SinhVien"].Rows.Count}", "Đọc XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Bài 9: Đã đọc DataSet offline từ tệp XML thành công.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc XML: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region BÀI 10: HỢP NHẤT DỮ LIỆU (MERGE DATATABLE)
        private void btnMergeData_Click(object sender, EventArgs e)
        {
            try
            {
                // Bảng gốc 1
                DataTable dt1 = new DataTable("Table1");
                dt1.Columns.Add("MaSV", typeof(string));
                dt1.Columns.Add("HoTen", typeof(string));
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["MaSV"] };
                dt1.Rows.Add("SV001", "Nguyễn Văn An");
                dt1.Rows.Add("SV002", "Trần Thị Bình");

                // Bảng mới 2 (chứa 1 dòng cập nhật SV001 và 1 dòng mới SV003)
                DataTable dt2 = new DataTable("Table2");
                dt2.Columns.Add("MaSV", typeof(string));
                dt2.Columns.Add("HoTen", typeof(string));
                dt2.PrimaryKey = new DataColumn[] { dt2.Columns["MaSV"] };
                dt2.Rows.Add("SV001", "Nguyễn Văn An (Đã cập nhật)");
                dt2.Rows.Add("SV003", "Lê Văn Cường (Mới thêm)");

                // Thực hiện hợp nhất
                dt1.Merge(dt2);

                dgvXmlMerge.DataSource = dt1;
                MessageBox.Show("Đã hợp nhất thành công 2 DataTable (Merge)! SV001 được cập nhật tên mới và SV003 được thêm vào.", "Thông Báo Merge", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Bài 10: Đã Merge thành công 2 DataTable dựa trên khóa chính MaSV.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Merge: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}