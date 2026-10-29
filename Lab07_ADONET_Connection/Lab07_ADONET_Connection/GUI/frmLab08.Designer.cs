namespace Lab07_ADONET_Connection.GUI
{
    partial class frmLab08
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTongSV = new System.Windows.Forms.Label();
            this.btnDemSV = new System.Windows.Forms.Button();
            this.btnDocDS = new System.Windows.Forms.Button();
            this.lstSinhVien = new System.Windows.Forms.ListBox();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtDiemTB = new System.Windows.Forms.TextBox();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhatDiem = new System.Windows.Forms.Button();
            this.btnTimByProc = new System.Windows.Forms.Button();
            this.btnTimByMa = new System.Windows.Forms.Button();
            this.btnMaxDiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThemOutput = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTongSV
            // 
            this.lblTongSV.AutoSize = true;
            this.lblTongSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSV.ForeColor = System.Drawing.Color.Blue;
            this.lblTongSV.Location = new System.Drawing.Point(191, 21);
            this.lblTongSV.Name = "lblTongSV";
            this.lblTongSV.Size = new System.Drawing.Size(144, 19);
            this.lblTongSV.TabIndex = 1;
            this.lblTongSV.Text = "Tổng số sinh viên: --";
            // 
            // btnDemSV
            // 
            this.btnDemSV.Location = new System.Drawing.Point(15, 15);
            this.btnDemSV.Name = "btnDemSV";
            this.btnDemSV.Size = new System.Drawing.Size(170, 30);
            this.btnDemSV.TabIndex = 0;
            this.btnDemSV.Text = "1. Đếm số sinh viên";
            this.btnDemSV.UseVisualStyleBackColor = true;
            this.btnDemSV.Click += new System.EventHandler(this.btnDemSV_Click);
            // 
            // btnDocDS
            // 
            this.btnDocDS.Location = new System.Drawing.Point(15, 55);
            this.btnDocDS.Name = "btnDocDS";
            this.btnDocDS.Size = new System.Drawing.Size(170, 30);
            this.btnDocDS.TabIndex = 2;
            this.btnDocDS.Text = "2. Đọc DS (ListBox)";
            this.btnDocDS.UseVisualStyleBackColor = true;
            this.btnDocDS.Click += new System.EventHandler(this.btnDocDS_Click);
            // 
            // lstSinhVien
            // 
            this.lstSinhVien.FormattingEnabled = true;
            this.lstSinhVien.ItemHeight = 15;
            this.lstSinhVien.Location = new System.Drawing.Point(15, 95);
            this.lstSinhVien.Name = "lstSinhVien";
            this.lstSinhVien.Size = new System.Drawing.Size(280, 334);
            this.lstSinhVien.TabIndex = 3;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.txtEmail);
            this.grpThongTin.Controls.Add(this.lblEmail);
            this.grpThongTin.Controls.Add(this.cboKhoa);
            this.grpThongTin.Controls.Add(this.lblKhoa);
            this.grpThongTin.Controls.Add(this.radNu);
            this.grpThongTin.Controls.Add(this.radNam);
            this.grpThongTin.Controls.Add(this.lblGioiTinh);
            this.grpThongTin.Controls.Add(this.dtpNgaySinh);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.txtDiemTB);
            this.grpThongTin.Controls.Add(this.lblDiemTB);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.txtMaSV);
            this.grpThongTin.Controls.Add(this.lblMaSV);
            this.grpThongTin.Location = new System.Drawing.Point(350, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(460, 180);
            this.grpThongTin.TabIndex = 4;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin Sinh viên";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(290, 105);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 23);
            this.txtEmail.TabIndex = 14;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(235, 108);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email:";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(290, 68);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(150, 23);
            this.cboKhoa.TabIndex = 12;
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(235, 71);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(37, 15);
            this.lblKhoa.TabIndex = 11;
            this.lblKhoa.Text = "Khoa:";
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(340, 31);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(41, 19);
            this.radNu.TabIndex = 10;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Checked = true;
            this.radNam.Location = new System.Drawing.Point(290, 31);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(51, 19);
            this.radNam.TabIndex = 9;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(235, 33);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(55, 15);
            this.lblGioiTinh.TabIndex = 8;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(80, 105);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(140, 23);
            this.dtpNgaySinh.TabIndex = 7;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(15, 108);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(63, 15);
            this.lblNgaySinh.TabIndex = 6;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // txtDiemTB
            // 
            this.txtDiemTB.Location = new System.Drawing.Point(80, 142);
            this.txtDiemTB.Name = "txtDiemTB";
            this.txtDiemTB.Size = new System.Drawing.Size(140, 23);
            this.txtDiemTB.TabIndex = 5;
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Location = new System.Drawing.Point(15, 145);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(55, 15);
            this.lblDiemTB.TabIndex = 4;
            this.lblDiemTB.Text = "Điểm TB:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(80, 68);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(140, 23);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 71);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(46, 15);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(80, 30);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(140, 23);
            this.txtMaSV.TabIndex = 1;
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(15, 33);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(43, 15);
            this.lblMaSV.TabIndex = 0;
            this.lblMaSV.Text = "Mã SV:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(351, 198);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 30);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "3. Thêm SV";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhatDiem
            // 
            this.btnCapNhatDiem.Location = new System.Drawing.Point(466, 198);
            this.btnCapNhatDiem.Name = "btnCapNhatDiem";
            this.btnCapNhatDiem.Size = new System.Drawing.Size(110, 30);
            this.btnCapNhatDiem.TabIndex = 6;
            this.btnCapNhatDiem.Text = "4. Sửa Điểm";
            this.btnCapNhatDiem.UseVisualStyleBackColor = true;
            this.btnCapNhatDiem.Click += new System.EventHandler(this.btnCapNhatDiem_Click);
            // 
            // btnTimByProc
            // 
            this.btnTimByProc.Location = new System.Drawing.Point(581, 198);
            this.btnTimByProc.Name = "btnTimByProc";
            this.btnTimByProc.Size = new System.Drawing.Size(110, 30);
            this.btnTimByProc.TabIndex = 7;
            this.btnTimByProc.Text = "5. Tìm theo Khoa";
            this.btnTimByProc.UseVisualStyleBackColor = true;
            this.btnTimByProc.Click += new System.EventHandler(this.btnTimByProc_Click);
            // 
            // btnTimByMa
            // 
            this.btnTimByMa.Location = new System.Drawing.Point(696, 198);
            this.btnTimByMa.Name = "btnTimByMa";
            this.btnTimByMa.Size = new System.Drawing.Size(115, 30);
            this.btnTimByMa.TabIndex = 8;
            this.btnTimByMa.Text = "6. Tìm theo Mã";
            this.btnTimByMa.UseVisualStyleBackColor = true;
            this.btnTimByMa.Click += new System.EventHandler(this.btnTimByMa_Click);
            // 
            // btnMaxDiem
            // 
            this.btnMaxDiem.Location = new System.Drawing.Point(351, 235);
            this.btnMaxDiem.Name = "btnMaxDiem";
            this.btnMaxDiem.Size = new System.Drawing.Size(110, 30);
            this.btnMaxDiem.TabIndex = 9;
            this.btnMaxDiem.Text = "7. Max Điểm Khoa";
            this.btnMaxDiem.UseVisualStyleBackColor = true;
            this.btnMaxDiem.Click += new System.EventHandler(this.btnMaxDiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(466, 235);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 30);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "8. Xóa SV";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThemOutput
            // 
            this.btnThemOutput.Location = new System.Drawing.Point(581, 235);
            this.btnThemOutput.Name = "btnThemOutput";
            this.btnThemOutput.Size = new System.Drawing.Size(230, 30);
            this.btnThemOutput.TabIndex = 11;
            this.btnThemOutput.Text = "9. Thêm SV + Output Parameter";
            this.btnThemOutput.UseVisualStyleBackColor = true;
            this.btnThemOutput.Click += new System.EventHandler(this.btnThemOutput_Click);
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(351, 273);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(460, 150);
            this.dgvData.TabIndex = 12;
            // 
            // frmLab08
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 451);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnThemOutput);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnMaxDiem);
            this.Controls.Add(this.btnTimByMa);
            this.Controls.Add(this.btnTimByProc);
            this.Controls.Add(this.btnCapNhatDiem);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.lstSinhVien);
            this.Controls.Add(this.btnDocDS);
            this.Controls.Add(this.lblTongSV);
            this.Controls.Add(this.btnDemSV);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLab08";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 08 - SqlCommand, SqlParameter & Các Phương Thức Thực Thi";
            this.Load += new System.EventHandler(this.frmLab08_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDemSV;
        private System.Windows.Forms.Label lblTongSV;
        private System.Windows.Forms.Button btnDocDS;
        private System.Windows.Forms.ListBox lstSinhVien;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtDiemTB;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhatDiem;
        private System.Windows.Forms.Button btnTimByProc;
        private System.Windows.Forms.Button btnTimByMa;
        private System.Windows.Forms.Button btnMaxDiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThemOutput;
        private System.Windows.Forms.DataGridView dgvData;
    }
}