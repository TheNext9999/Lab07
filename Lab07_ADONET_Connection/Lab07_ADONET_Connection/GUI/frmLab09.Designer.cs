namespace Lab07_ADONET_Connection.GUI
{
    partial class frmLab09
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.btnXuatCSV = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.radDesc = new System.Windows.Forms.RadioButton();
            this.radAsc = new System.Windows.Forms.RadioButton();
            this.cboSortColumn = new System.Windows.Forms.ComboBox();
            this.lblSapXep = new System.Windows.Forms.Label();
            this.numMaxTuoi = new System.Windows.Forms.NumericUpDown();
            this.numMinTuoi = new System.Windows.Forms.NumericUpDown();
            this.lblTuoi = new System.Windows.Forms.Label();
            this.txtMaxDiem = new System.Windows.Forms.TextBox();
            this.txtMinDiem = new System.Windows.Forms.TextBox();
            this.lblDiem = new System.Windows.Forms.Label();
            this.cboGioiTinhFilter = new System.Windows.Forms.ComboBox();
            this.lblGioiTinhFilter = new System.Windows.Forms.Label();
            this.cboKhoaFilter = new System.Windows.Forms.ComboBox();
            this.lblKhoaFilter = new System.Windows.Forms.Label();
            this.txtTimKiemTen = new System.Windows.Forms.TextBox();
            this.lblTenFilter = new System.Windows.Forms.Label();
            this.txtMaSVFilter = new System.Windows.Forms.TextBox();
            this.lblMaSVFilter = new System.Windows.Forms.Label();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.pnlPhanTrang = new System.Windows.Forms.Panel();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.lblPhanTrangInfo = new System.Windows.Forms.Label();
            this.btnTrangSau = new System.Windows.Forms.Button();
            this.btnTrangTruoc = new System.Windows.Forms.Button();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.txtDetailEmail = new System.Windows.Forms.TextBox();
            this.lblDetailEmail = new System.Windows.Forms.Label();
            this.cboDetailKhoa = new System.Windows.Forms.ComboBox();
            this.lblDetailKhoa = new System.Windows.Forms.Label();
            this.radDetailNu = new System.Windows.Forms.RadioButton();
            this.radDetailNam = new System.Windows.Forms.RadioButton();
            this.lblDetailGioiTinh = new System.Windows.Forms.Label();
            this.dtpDetailNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblDetailNgaySinh = new System.Windows.Forms.Label();
            this.txtDetailDiemTB = new System.Windows.Forms.TextBox();
            this.lblDetailDiem = new System.Windows.Forms.Label();
            this.txtDetailHoTen = new System.Windows.Forms.TextBox();
            this.lblDetailHoTen = new System.Windows.Forms.Label();
            this.txtDetailMaSV = new System.Windows.Forms.TextBox();
            this.lblDetailMaSV = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinTuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.pnlPhanTrang.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.btnXuatCSV);
            this.grpBoLoc.Controls.Add(this.btnLamMoi);
            this.grpBoLoc.Controls.Add(this.btnTimKiem);
            this.grpBoLoc.Controls.Add(this.radDesc);
            this.grpBoLoc.Controls.Add(this.radAsc);
            this.grpBoLoc.Controls.Add(this.cboSortColumn);
            this.grpBoLoc.Controls.Add(this.lblSapXep);
            this.grpBoLoc.Controls.Add(this.numMaxTuoi);
            this.grpBoLoc.Controls.Add(this.numMinTuoi);
            this.grpBoLoc.Controls.Add(this.lblTuoi);
            this.grpBoLoc.Controls.Add(this.txtMaxDiem);
            this.grpBoLoc.Controls.Add(this.txtMinDiem);
            this.grpBoLoc.Controls.Add(this.lblDiem);
            this.grpBoLoc.Controls.Add(this.cboGioiTinhFilter);
            this.grpBoLoc.Controls.Add(this.lblGioiTinhFilter);
            this.grpBoLoc.Controls.Add(this.cboKhoaFilter);
            this.grpBoLoc.Controls.Add(this.lblKhoaFilter);
            this.grpBoLoc.Controls.Add(this.txtTimKiemTen);
            this.grpBoLoc.Controls.Add(this.lblTenFilter);
            this.grpBoLoc.Controls.Add(this.txtMaSVFilter);
            this.grpBoLoc.Controls.Add(this.lblMaSVFilter);
            this.grpBoLoc.Location = new System.Drawing.Point(12, 12);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(960, 130);
            this.grpBoLoc.TabIndex = 0;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Bộ Lọc & Tìm Kiếm Đa Tiêu Chí (Bài 2, 3, 6, 7, 8)";
            // 
            // btnXuatCSV
            // 
            this.btnXuatCSV.BackColor = System.Drawing.Color.DarkGreen;
            this.btnXuatCSV.ForeColor = System.Drawing.Color.White;
            this.btnXuatCSV.Location = new System.Drawing.Point(825, 90);
            this.btnXuatCSV.Name = "btnXuatCSV";
            this.btnXuatCSV.Size = new System.Drawing.Size(120, 30);
            this.btnXuatCSV.TabIndex = 20;
            this.btnXuatCSV.Text = "📁 Xuất CSV (Bài 10)";
            this.btnXuatCSV.UseVisualStyleBackColor = false;
            this.btnXuatCSV.Click += new System.EventHandler(this.btnXuatCSV_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(720, 90);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 30);
            this.btnLamMoi.TabIndex = 19;
            this.btnLamMoi.Text = "🔄 LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(615, 90);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(95, 30);
            this.btnTimKiem.TabIndex = 18;
            this.btnTimKiem.Text = "🔍 TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // radDesc
            // 
            this.radDesc.AutoSize = true;
            this.radDesc.Location = new System.Drawing.Point(495, 95);
            this.radDesc.Name = "radDesc";
            this.radDesc.Size = new System.Drawing.Size(92, 19);
            this.radDesc.TabIndex = 17;
            this.radDesc.Text = "Giảm (DESC)";
            this.radDesc.UseVisualStyleBackColor = true;
            // 
            // radAsc
            // 
            this.radAsc.AutoSize = true;
            this.radAsc.Checked = true;
            this.radAsc.Location = new System.Drawing.Point(415, 95);
            this.radAsc.Name = "radAsc";
            this.radAsc.Size = new System.Drawing.Size(84, 19);
            this.radAsc.TabIndex = 16;
            this.radAsc.TabStop = true;
            this.radAsc.Text = "Tăng (ASC)";
            this.radAsc.UseVisualStyleBackColor = true;
            // 
            // cboSortColumn
            // 
            this.cboSortColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortColumn.FormattingEnabled = true;
            this.cboSortColumn.Location = new System.Drawing.Point(275, 92);
            this.cboSortColumn.Name = "cboSortColumn";
            this.cboSortColumn.Size = new System.Drawing.Size(130, 23);
            this.cboSortColumn.TabIndex = 15;
            // 
            // lblSapXep
            // 
            this.lblSapXep.AutoSize = true;
            this.lblSapXep.Location = new System.Drawing.Point(215, 95);
            this.lblSapXep.Name = "lblSapXep";
            this.lblSapXep.Size = new System.Drawing.Size(50, 15);
            this.lblSapXep.TabIndex = 14;
            this.lblSapXep.Text = "Sắp xếp:";
            // 
            // numMaxTuoi
            // 
            this.numMaxTuoi.Location = new System.Drawing.Point(140, 91);
            this.numMaxTuoi.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMaxTuoi.Name = "numMaxTuoi";
            this.numMaxTuoi.Size = new System.Drawing.Size(55, 23);
            this.numMaxTuoi.TabIndex = 13;
            this.numMaxTuoi.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numMinTuoi
            // 
            this.numMinTuoi.Location = new System.Drawing.Point(79, 92);
            this.numMinTuoi.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMinTuoi.Name = "numMinTuoi";
            this.numMinTuoi.Size = new System.Drawing.Size(55, 23);
            this.numMinTuoi.TabIndex = 12;
            this.numMinTuoi.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            // 
            // lblTuoi
            // 
            this.lblTuoi.AutoSize = true;
            this.lblTuoi.Location = new System.Drawing.Point(15, 95);
            this.lblTuoi.Name = "lblTuoi";
            this.lblTuoi.Size = new System.Drawing.Size(70, 15);
            this.lblTuoi.TabIndex = 11;
            this.lblTuoi.Text = "Tuổi (Bài 8):";
            // 
            // txtMaxDiem
            // 
            this.txtMaxDiem.Location = new System.Drawing.Point(825, 57);
            this.txtMaxDiem.Name = "txtMaxDiem";
            this.txtMaxDiem.Size = new System.Drawing.Size(50, 23);
            this.txtMaxDiem.TabIndex = 10;
            this.txtMaxDiem.Text = "10.0";
            // 
            // txtMinDiem
            // 
            this.txtMinDiem.Location = new System.Drawing.Point(765, 57);
            this.txtMinDiem.Name = "txtMinDiem";
            this.txtMinDiem.Size = new System.Drawing.Size(50, 23);
            this.txtMinDiem.TabIndex = 9;
            this.txtMinDiem.Text = "0.0";
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Location = new System.Drawing.Point(710, 60);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(55, 15);
            this.lblDiem.TabIndex = 8;
            this.lblDiem.Text = "Điểm TB:";
            // 
            // cboGioiTinhFilter
            // 
            this.cboGioiTinhFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinhFilter.FormattingEnabled = true;
            this.cboGioiTinhFilter.Location = new System.Drawing.Point(565, 57);
            this.cboGioiTinhFilter.Name = "cboGioiTinhFilter";
            this.cboGioiTinhFilter.Size = new System.Drawing.Size(125, 23);
            this.cboGioiTinhFilter.TabIndex = 7;
            // 
            // lblGioiTinhFilter
            // 
            this.lblGioiTinhFilter.AutoSize = true;
            this.lblGioiTinhFilter.Location = new System.Drawing.Point(505, 60);
            this.lblGioiTinhFilter.Name = "lblGioiTinhFilter";
            this.lblGioiTinhFilter.Size = new System.Drawing.Size(55, 15);
            this.lblGioiTinhFilter.TabIndex = 6;
            this.lblGioiTinhFilter.Text = "Giới tính:";
            // 
            // cboKhoaFilter
            // 
            this.cboKhoaFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaFilter.FormattingEnabled = true;
            this.cboKhoaFilter.Location = new System.Drawing.Point(325, 57);
            this.cboKhoaFilter.Name = "cboKhoaFilter";
            this.cboKhoaFilter.Size = new System.Drawing.Size(160, 23);
            this.cboKhoaFilter.TabIndex = 5;
            // 
            // lblKhoaFilter
            // 
            this.lblKhoaFilter.AutoSize = true;
            this.lblKhoaFilter.Location = new System.Drawing.Point(280, 60);
            this.lblKhoaFilter.Name = "lblKhoaFilter";
            this.lblKhoaFilter.Size = new System.Drawing.Size(37, 15);
            this.lblKhoaFilter.TabIndex = 4;
            this.lblKhoaFilter.Text = "Khoa:";
            // 
            // txtTimKiemTen
            // 
            this.txtTimKiemTen.Location = new System.Drawing.Point(325, 25);
            this.txtTimKiemTen.Name = "txtTimKiemTen";
            this.txtTimKiemTen.Size = new System.Drawing.Size(620, 23);
            this.txtTimKiemTen.TabIndex = 3;
            // 
            // lblTenFilter
            // 
            this.lblTenFilter.AutoSize = true;
            this.lblTenFilter.Location = new System.Drawing.Point(215, 28);
            this.lblTenFilter.Name = "lblTenFilter";
            this.lblTenFilter.Size = new System.Drawing.Size(107, 15);
            this.lblTenFilter.TabIndex = 2;
            this.lblTenFilter.Text = "Họ tên (Bài 2 LIKE):";
            // 
            // txtMaSVFilter
            // 
            this.txtMaSVFilter.Location = new System.Drawing.Point(75, 25);
            this.txtMaSVFilter.Name = "txtMaSVFilter";
            this.txtMaSVFilter.Size = new System.Drawing.Size(120, 23);
            this.txtMaSVFilter.TabIndex = 1;
            // 
            // lblMaSVFilter
            // 
            this.lblMaSVFilter.AutoSize = true;
            this.lblMaSVFilter.Location = new System.Drawing.Point(15, 28);
            this.lblMaSVFilter.Name = "lblMaSVFilter";
            this.lblMaSVFilter.Size = new System.Drawing.Size(43, 15);
            this.lblMaSVFilter.TabIndex = 0;
            this.lblMaSVFilter.Text = "Mã SV:";
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AllowUserToAddRows = false;
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(12, 148);
            this.dgvSinhVien.MultiSelect = false;
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.ReadOnly = true;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(960, 220);
            this.dgvSinhVien.TabIndex = 1;
            this.dgvSinhVien.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSinhVien_CellFormatting);
            this.dgvSinhVien.SelectionChanged += new System.EventHandler(this.dgvSinhVien_SelectionChanged);
            // 
            // pnlPhanTrang
            // 
            this.pnlPhanTrang.Controls.Add(this.cboPageSize);
            this.pnlPhanTrang.Controls.Add(this.lblPageSize);
            this.pnlPhanTrang.Controls.Add(this.lblPhanTrangInfo);
            this.pnlPhanTrang.Controls.Add(this.btnTrangSau);
            this.pnlPhanTrang.Controls.Add(this.btnTrangTruoc);
            this.pnlPhanTrang.Location = new System.Drawing.Point(12, 374);
            this.pnlPhanTrang.Name = "pnlPhanTrang";
            this.pnlPhanTrang.Size = new System.Drawing.Size(960, 35);
            this.pnlPhanTrang.TabIndex = 2;
            // 
            // cboPageSize
            // 
            this.cboPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPageSize.FormattingEnabled = true;
            this.cboPageSize.Location = new System.Drawing.Point(885, 6);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.Size = new System.Drawing.Size(60, 23);
            this.cboPageSize.TabIndex = 4;
            this.cboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboPageSize_SelectedIndexChanged);
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(795, 9);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(87, 15);
            this.lblPageSize.TabIndex = 3;
            this.lblPageSize.Text = "Số dòng/trang:";
            // 
            // lblPhanTrangInfo
            // 
            this.lblPhanTrangInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhanTrangInfo.Location = new System.Drawing.Point(235, 9);
            this.lblPhanTrangInfo.Name = "lblPhanTrangInfo";
            this.lblPhanTrangInfo.Size = new System.Drawing.Size(200, 18);
            this.lblPhanTrangInfo.TabIndex = 2;
            this.lblPhanTrangInfo.Text = "Trang 1 / 1 (Tổng số: 0 bản ghi)";
            this.lblPhanTrangInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTrangSau
            // 
            this.btnTrangSau.Location = new System.Drawing.Point(120, 4);
            this.btnTrangSau.Name = "btnTrangSau";
            this.btnTrangSau.Size = new System.Drawing.Size(100, 27);
            this.btnTrangSau.TabIndex = 1;
            this.btnTrangSau.Text = "Trang Sau ▶";
            this.btnTrangSau.UseVisualStyleBackColor = true;
            this.btnTrangSau.Click += new System.EventHandler(this.btnTrangSau_Click);
            // 
            // btnTrangTruoc
            // 
            this.btnTrangTruoc.Location = new System.Drawing.Point(5, 4);
            this.btnTrangTruoc.Name = "btnTrangTruoc";
            this.btnTrangTruoc.Size = new System.Drawing.Size(100, 27);
            this.btnTrangTruoc.TabIndex = 0;
            this.btnTrangTruoc.Text = "◀ Trang Trước";
            this.btnTrangTruoc.UseVisualStyleBackColor = true;
            this.btnTrangTruoc.Click += new System.EventHandler(this.btnTrangTruoc_Click);
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.txtDetailEmail);
            this.grpChiTiet.Controls.Add(this.lblDetailEmail);
            this.grpChiTiet.Controls.Add(this.cboDetailKhoa);
            this.grpChiTiet.Controls.Add(this.lblDetailKhoa);
            this.grpChiTiet.Controls.Add(this.radDetailNu);
            this.grpChiTiet.Controls.Add(this.radDetailNam);
            this.grpChiTiet.Controls.Add(this.lblDetailGioiTinh);
            this.grpChiTiet.Controls.Add(this.dtpDetailNgaySinh);
            this.grpChiTiet.Controls.Add(this.lblDetailNgaySinh);
            this.grpChiTiet.Controls.Add(this.txtDetailDiemTB);
            this.grpChiTiet.Controls.Add(this.lblDetailDiem);
            this.grpChiTiet.Controls.Add(this.txtDetailHoTen);
            this.grpChiTiet.Controls.Add(this.lblDetailHoTen);
            this.grpChiTiet.Controls.Add(this.txtDetailMaSV);
            this.grpChiTiet.Controls.Add(this.lblDetailMaSV);
            this.grpChiTiet.Location = new System.Drawing.Point(12, 415);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(960, 100);
            this.grpChiTiet.TabIndex = 3;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Thông Tin Chi Tiết Sinh Viên Được Chọn (Bài 5 Synchronize)";
            // 
            // txtDetailEmail
            // 
            this.txtDetailEmail.Location = new System.Drawing.Point(745, 62);
            this.txtDetailEmail.Name = "txtDetailEmail";
            this.txtDetailEmail.ReadOnly = true;
            this.txtDetailEmail.Size = new System.Drawing.Size(200, 23);
            this.txtDetailEmail.TabIndex = 14;
            // 
            // lblDetailEmail
            // 
            this.lblDetailEmail.AutoSize = true;
            this.lblDetailEmail.Location = new System.Drawing.Point(695, 65);
            this.lblDetailEmail.Name = "lblDetailEmail";
            this.lblDetailEmail.Size = new System.Drawing.Size(39, 15);
            this.lblDetailEmail.TabIndex = 13;
            this.lblDetailEmail.Text = "Email:";
            // 
            // cboDetailKhoa
            // 
            this.cboDetailKhoa.Enabled = false;
            this.cboDetailKhoa.FormattingEnabled = true;
            this.cboDetailKhoa.Location = new System.Drawing.Point(510, 62);
            this.cboDetailKhoa.Name = "cboDetailKhoa";
            this.cboDetailKhoa.Size = new System.Drawing.Size(160, 23);
            this.cboDetailKhoa.TabIndex = 12;
            // 
            // lblDetailKhoa
            // 
            this.lblDetailKhoa.AutoSize = true;
            this.lblDetailKhoa.Location = new System.Drawing.Point(460, 65);
            this.lblDetailKhoa.Name = "lblDetailKhoa";
            this.lblDetailKhoa.Size = new System.Drawing.Size(37, 15);
            this.lblDetailKhoa.TabIndex = 11;
            this.lblDetailKhoa.Text = "Khoa:";
            // 
            // radDetailNu
            // 
            this.radDetailNu.AutoSize = true;
            this.radDetailNu.Enabled = false;
            this.radDetailNu.Location = new System.Drawing.Point(385, 63);
            this.radDetailNu.Name = "radDetailNu";
            this.radDetailNu.Size = new System.Drawing.Size(41, 19);
            this.radDetailNu.TabIndex = 10;
            this.radDetailNu.Text = "Nữ";
            this.radDetailNu.UseVisualStyleBackColor = true;
            // 
            // radDetailNam
            // 
            this.radDetailNam.AutoSize = true;
            this.radDetailNam.Enabled = false;
            this.radDetailNam.Location = new System.Drawing.Point(335, 63);
            this.radDetailNam.Name = "radDetailNam";
            this.radDetailNam.Size = new System.Drawing.Size(51, 19);
            this.radDetailNam.TabIndex = 9;
            this.radDetailNam.Text = "Nam";
            this.radDetailNam.UseVisualStyleBackColor = true;
            // 
            // lblDetailGioiTinh
            // 
            this.lblDetailGioiTinh.AutoSize = true;
            this.lblDetailGioiTinh.Location = new System.Drawing.Point(270, 65);
            this.lblDetailGioiTinh.Name = "lblDetailGioiTinh";
            this.lblDetailGioiTinh.Size = new System.Drawing.Size(55, 15);
            this.lblDetailGioiTinh.TabIndex = 8;
            this.lblDetailGioiTinh.Text = "Giới tính:";
            // 
            // dtpDetailNgaySinh
            // 
            this.dtpDetailNgaySinh.Enabled = false;
            this.dtpDetailNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDetailNgaySinh.Location = new System.Drawing.Point(100, 62);
            this.dtpDetailNgaySinh.Name = "dtpDetailNgaySinh";
            this.dtpDetailNgaySinh.Size = new System.Drawing.Size(140, 23);
            this.dtpDetailNgaySinh.TabIndex = 7;
            // 
            // lblDetailNgaySinh
            // 
            this.lblDetailNgaySinh.AutoSize = true;
            this.lblDetailNgaySinh.Location = new System.Drawing.Point(15, 65);
            this.lblDetailNgaySinh.Name = "lblDetailNgaySinh";
            this.lblDetailNgaySinh.Size = new System.Drawing.Size(63, 15);
            this.lblDetailNgaySinh.TabIndex = 6;
            this.lblDetailNgaySinh.Text = "Ngày sinh:";
            // 
            // txtDetailDiemTB
            // 
            this.txtDetailDiemTB.Location = new System.Drawing.Point(745, 25);
            this.txtDetailDiemTB.Name = "txtDetailDiemTB";
            this.txtDetailDiemTB.ReadOnly = true;
            this.txtDetailDiemTB.Size = new System.Drawing.Size(80, 23);
            this.txtDetailDiemTB.TabIndex = 5;
            // 
            // lblDetailDiem
            // 
            this.lblDetailDiem.AutoSize = true;
            this.lblDetailDiem.Location = new System.Drawing.Point(685, 28);
            this.lblDetailDiem.Name = "lblDetailDiem";
            this.lblDetailDiem.Size = new System.Drawing.Size(55, 15);
            this.lblDetailDiem.TabIndex = 4;
            this.lblDetailDiem.Text = "Điểm TB:";
            // 
            // txtDetailHoTen
            // 
            this.txtDetailHoTen.Location = new System.Drawing.Point(335, 25);
            this.txtDetailHoTen.Name = "txtDetailHoTen";
            this.txtDetailHoTen.ReadOnly = true;
            this.txtDetailHoTen.Size = new System.Drawing.Size(335, 23);
            this.txtDetailHoTen.TabIndex = 3;
            // 
            // lblDetailHoTen
            // 
            this.lblDetailHoTen.AutoSize = true;
            this.lblDetailHoTen.Location = new System.Drawing.Point(270, 28);
            this.lblDetailHoTen.Name = "lblDetailHoTen";
            this.lblDetailHoTen.Size = new System.Drawing.Size(46, 15);
            this.lblDetailHoTen.TabIndex = 2;
            this.lblDetailHoTen.Text = "Họ tên:";
            // 
            // txtDetailMaSV
            // 
            this.txtDetailMaSV.Location = new System.Drawing.Point(100, 25);
            this.txtDetailMaSV.Name = "txtDetailMaSV";
            this.txtDetailMaSV.ReadOnly = true;
            this.txtDetailMaSV.Size = new System.Drawing.Size(140, 23);
            this.txtDetailMaSV.TabIndex = 1;
            // 
            // lblDetailMaSV
            // 
            this.lblDetailMaSV.AutoSize = true;
            this.lblDetailMaSV.Location = new System.Drawing.Point(15, 28);
            this.lblDetailMaSV.Name = "lblDetailMaSV";
            this.lblDetailMaSV.Size = new System.Drawing.Size(43, 15);
            this.lblDetailMaSV.TabIndex = 0;
            this.lblDetailMaSV.Text = "Mã SV:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(135, 17);
            this.lblStatus.Text = "Trạng thái: Đã sẵn sàng.";
            // 
            // frmLab09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 551);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.pnlPhanTrang);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.grpBoLoc);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLab09";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 09 - Đọc, Tìm kiếm và Lọc dữ liệu bằng MySqlDataReader (WinForms ADO.NET)";
            this.Load += new System.EventHandler(this.frmLab09_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinTuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.pnlPhanTrang.ResumeLayout(false);
            this.pnlPhanTrang.PerformLayout();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.TextBox txtMaSVFilter;
        private System.Windows.Forms.Label lblMaSVFilter;
        private System.Windows.Forms.TextBox txtTimKiemTen;
        private System.Windows.Forms.Label lblTenFilter;
        private System.Windows.Forms.ComboBox cboKhoaFilter;
        private System.Windows.Forms.Label lblKhoaFilter;
        private System.Windows.Forms.ComboBox cboGioiTinhFilter;
        private System.Windows.Forms.Label lblGioiTinhFilter;
        private System.Windows.Forms.TextBox txtMaxDiem;
        private System.Windows.Forms.TextBox txtMinDiem;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.NumericUpDown numMaxTuoi;
        private System.Windows.Forms.NumericUpDown numMinTuoi;
        private System.Windows.Forms.Label lblTuoi;
        private System.Windows.Forms.ComboBox cboSortColumn;
        private System.Windows.Forms.Label lblSapXep;
        private System.Windows.Forms.RadioButton radDesc;
        private System.Windows.Forms.RadioButton radAsc;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatCSV;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Panel pnlPhanTrang;
        private System.Windows.Forms.Button btnTrangSau;
        private System.Windows.Forms.Button btnTrangTruoc;
        private System.Windows.Forms.Label lblPhanTrangInfo;
        private System.Windows.Forms.ComboBox cboPageSize;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.TextBox txtDetailMaSV;
        private System.Windows.Forms.Label lblDetailMaSV;
        private System.Windows.Forms.TextBox txtDetailHoTen;
        private System.Windows.Forms.Label lblDetailHoTen;
        private System.Windows.Forms.TextBox txtDetailDiemTB;
        private System.Windows.Forms.Label lblDetailDiem;
        private System.Windows.Forms.DateTimePicker dtpDetailNgaySinh;
        private System.Windows.Forms.Label lblDetailNgaySinh;
        private System.Windows.Forms.RadioButton radDetailNu;
        private System.Windows.Forms.RadioButton radDetailNam;
        private System.Windows.Forms.Label lblDetailGioiTinh;
        private System.Windows.Forms.ComboBox cboDetailKhoa;
        private System.Windows.Forms.Label lblDetailKhoa;
        private System.Windows.Forms.TextBox txtDetailEmail;
        private System.Windows.Forms.Label lblDetailEmail;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}