namespace Lab07_ADONET_Connection.GUI
{
    partial class frmLab12
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMasterDetail = new System.Windows.Forms.TabPage();
            this.lblDetailDangKy = new System.Windows.Forms.Label();
            this.dgvDangKyDetail = new System.Windows.Forms.DataGridView();
            this.lblDetailSV = new System.Windows.Forms.Label();
            this.dgvSinhVienDetail = new System.Windows.Forms.DataGridView();
            this.lblMasterKhoa = new System.Windows.Forms.Label();
            this.dgvKhoaMaster = new System.Windows.Forms.DataGridView();
            this.tabTransaction = new System.Windows.Forms.TabPage();
            this.grpConcurrency = new System.Windows.Forms.GroupBox();
            this.btnSuaDiemConcurrency = new System.Windows.Forms.Button();
            this.txtDiemConcurrency = new System.Windows.Forms.TextBox();
            this.lblDiemConc = new System.Windows.Forms.Label();
            this.grpChuyenKhoa = new System.Windows.Forms.GroupBox();
            this.txtLyDoChuyen = new System.Windows.Forms.TextBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.btnChuyenKhoaTx = new System.Windows.Forms.Button();
            this.cboKhoaMoi = new System.Windows.Forms.ComboBox();
            this.lblKhoaMoi = new System.Windows.Forms.Label();
            this.grpTransTest = new System.Windows.Forms.GroupBox();
            this.btnTestRollbackSuccess = new System.Windows.Forms.Button();
            this.btnTestRollbackFail = new System.Windows.Forms.Button();
            this.tabBulkGrade = new System.Windows.Forms.TabPage();
            this.btnBulkUpdateGrades = new System.Windows.Forms.Button();
            this.dgvBulkGrades = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabMasterDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKyDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaMaster)).BeginInit();
            this.tabTransaction.SuspendLayout();
            this.grpConcurrency.SuspendLayout();
            this.grpChuyenKhoa.SuspendLayout();
            this.grpTransTest.SuspendLayout();
            this.tabBulkGrade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBulkGrades)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMasterDetail);
            this.tabControl1.Controls.Add(this.tabTransaction);
            this.tabControl1.Controls.Add(this.tabBulkGrade);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 520);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMasterDetail
            // 
            this.tabMasterDetail.Controls.Add(this.lblDetailDangKy);
            this.tabMasterDetail.Controls.Add(this.dgvDangKyDetail);
            this.tabMasterDetail.Controls.Add(this.lblDetailSV);
            this.tabMasterDetail.Controls.Add(this.dgvSinhVienDetail);
            this.tabMasterDetail.Controls.Add(this.lblMasterKhoa);
            this.tabMasterDetail.Controls.Add(this.dgvKhoaMaster);
            this.tabMasterDetail.Location = new System.Drawing.Point(4, 24);
            this.tabMasterDetail.Name = "tabMasterDetail";
            this.tabMasterDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabMasterDetail.Size = new System.Drawing.Size(976, 492);
            this.tabMasterDetail.TabIndex = 0;
            this.tabMasterDetail.Text = "Bài 1-2: Master-Detail 2 Cấp (Khoa ➔ SinhVien ➔ DangKy)";
            this.tabMasterDetail.UseVisualStyleBackColor = true;
            // 
            // lblDetailDangKy
            // 
            this.lblDetailDangKy.AutoSize = true;
            this.lblDetailDangKy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetailDangKy.Location = new System.Drawing.Point(515, 245);
            this.lblDetailDangKy.Name = "lblDetailDangKy";
            this.lblDetailDangKy.Size = new System.Drawing.Size(269, 15);
            this.lblDetailDangKy.TabIndex = 5;
            this.lblDetailDangKy.Text = "Detail 2: Danh Sách Học Phần Đăng Ký (Bài 2)";
            // 
            // dgvDangKyDetail
            // 
            this.dgvDangKyDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDangKyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKyDetail.Location = new System.Drawing.Point(515, 265);
            this.dgvDangKyDetail.Name = "dgvDangKyDetail";
            this.dgvDangKyDetail.ReadOnly = true;
            this.dgvDangKyDetail.Size = new System.Drawing.Size(445, 215);
            this.dgvDangKyDetail.TabIndex = 4;
            // 
            // lblDetailSV
            // 
            this.lblDetailSV.AutoSize = true;
            this.lblDetailSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetailSV.Location = new System.Drawing.Point(15, 245);
            this.lblDetailSV.Name = "lblDetailSV";
            this.lblDetailSV.Size = new System.Drawing.Size(256, 15);
            this.lblDetailSV.TabIndex = 3;
            this.lblDetailSV.Text = "Detail 1: Danh Sách Sinh Viên Thuộc Khoa (Bài 1)";
            // 
            // dgvSinhVienDetail
            // 
            this.dgvSinhVienDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVienDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVienDetail.Location = new System.Drawing.Point(15, 265);
            this.dgvSinhVienDetail.MultiSelect = false;
            this.dgvSinhVienDetail.Name = "dgvSinhVienDetail";
            this.dgvSinhVienDetail.ReadOnly = true;
            this.dgvSinhVienDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVienDetail.Size = new System.Drawing.Size(485, 215);
            this.dgvSinhVienDetail.TabIndex = 2;
            this.dgvSinhVienDetail.SelectionChanged += new System.EventHandler(this.dgvSinhVienDetail_SelectionChanged);
            // 
            // lblMasterKhoa
            // 
            this.lblMasterKhoa.AutoSize = true;
            this.lblMasterKhoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMasterKhoa.Location = new System.Drawing.Point(15, 10);
            this.lblMasterKhoa.Name = "lblMasterKhoa";
            this.lblMasterKhoa.Size = new System.Drawing.Size(155, 15);
            this.lblMasterKhoa.TabIndex = 1;
            this.lblMasterKhoa.Text = "Master 1: Danh Sách Khoa";
            // 
            // dgvKhoaMaster
            // 
            this.dgvKhoaMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoaMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoaMaster.Location = new System.Drawing.Point(15, 30);
            this.dgvKhoaMaster.MultiSelect = false;
            this.dgvKhoaMaster.Name = "dgvKhoaMaster";
            this.dgvKhoaMaster.ReadOnly = true;
            this.dgvKhoaMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoaMaster.Size = new System.Drawing.Size(945, 200);
            this.dgvKhoaMaster.TabIndex = 0;
            this.dgvKhoaMaster.SelectionChanged += new System.EventHandler(this.dgvKhoaMaster_SelectionChanged);
            // 
            // tabTransaction
            // 
            this.tabTransaction.Controls.Add(this.grpConcurrency);
            this.tabTransaction.Controls.Add(this.grpChuyenKhoa);
            this.tabTransaction.Controls.Add(this.grpTransTest);
            this.tabTransaction.Location = new System.Drawing.Point(4, 24);
            this.tabTransaction.Name = "tabTransaction";
            this.tabTransaction.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransaction.Size = new System.Drawing.Size(976, 492);
            this.tabTransaction.TabIndex = 1;
            this.tabTransaction.Text = "Bài 3-6, 9: MySqlTransaction, Kiểm Chứng Rollback & Concurrency";
            this.tabTransaction.UseVisualStyleBackColor = true;
            // 
            // grpConcurrency
            // 
            this.grpConcurrency.Controls.Add(this.btnSuaDiemConcurrency);
            this.grpConcurrency.Controls.Add(this.txtDiemConcurrency);
            this.grpConcurrency.Controls.Add(this.lblDiemConc);
            this.grpConcurrency.Location = new System.Drawing.Point(15, 330);
            this.grpConcurrency.Name = "grpConcurrency";
            this.grpConcurrency.Size = new System.Drawing.Size(945, 140);
            this.grpConcurrency.TabIndex = 2;
            this.grpConcurrency.TabStop = false;
            this.grpConcurrency.Text = "Bài 9: Kiểm Soát Xung Đột Cập Nhật Đồng Thời (Optimistic Concurrency Control)";
            // 
            // btnSuaDiemConcurrency
            // 
            this.btnSuaDiemConcurrency.Location = new System.Drawing.Point(240, 42);
            this.btnSuaDiemConcurrency.Name = "btnSuaDiemConcurrency";
            this.btnSuaDiemConcurrency.Size = new System.Drawing.Size(260, 32);
            this.btnSuaDiemConcurrency.TabIndex = 2;
            this.btnSuaDiemConcurrency.Text = "Thử Cập Nhật Điểm (Check UpdatedAt)";
            this.btnSuaDiemConcurrency.UseVisualStyleBackColor = true;
            this.btnSuaDiemConcurrency.Click += new System.EventHandler(this.btnSuaDiemConcurrency_Click);
            // 
            // txtDiemConcurrency
            // 
            this.txtDiemConcurrency.Location = new System.Drawing.Point(120, 47);
            this.txtDiemConcurrency.Name = "txtDiemConcurrency";
            this.txtDiemConcurrency.Size = new System.Drawing.Size(100, 23);
            this.txtDiemConcurrency.TabIndex = 1;
            this.txtDiemConcurrency.Text = "9.5";
            // 
            // lblDiemConc
            // 
            this.lblDiemConc.AutoSize = true;
            this.lblDiemConc.Location = new System.Drawing.Point(20, 50);
            this.lblDiemConc.Name = "lblDiemConc";
            this.lblDiemConc.Size = new System.Drawing.Size(94, 15);
            this.lblDiemConc.TabIndex = 0;
            this.lblDiemConc.Text = "Nhập Điểm Mới:";
            // 
            // grpChuyenKhoa
            // 
            this.grpChuyenKhoa.Controls.Add(this.txtLyDoChuyen);
            this.grpChuyenKhoa.Controls.Add(this.lblLyDo);
            this.grpChuyenKhoa.Controls.Add(this.btnChuyenKhoaTx);
            this.grpChuyenKhoa.Controls.Add(this.cboKhoaMoi);
            this.grpChuyenKhoa.Controls.Add(this.lblKhoaMoi);
            this.grpChuyenKhoa.Location = new System.Drawing.Point(15, 170);
            this.grpChuyenKhoa.Name = "grpChuyenKhoa";
            this.grpChuyenKhoa.Size = new System.Drawing.Size(945, 140);
            this.grpChuyenKhoa.TabIndex = 1;
            this.grpChuyenKhoa.TabStop = false;
            this.grpChuyenKhoa.Text = "Bài 6: Chuyển Sinh Viên Sang Khoa Khác & Ghi Lịch Sử Chuyển Khoa (Transaction)";
            // 
            // txtLyDoChuyen
            // 
            this.txtLyDoChuyen.Location = new System.Drawing.Point(100, 75);
            this.txtLyDoChuyen.Name = "txtLyDoChuyen";
            this.txtLyDoChuyen.Size = new System.Drawing.Size(400, 23);
            this.txtLyDoChuyen.TabIndex = 4;
            this.txtLyDoChuyen.Text = "Chuyển ngành theo nguyện vọng cá nhân.";
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(20, 78);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(39, 15);
            this.lblLyDo.TabIndex = 3;
            this.lblLyDo.Text = "Lý do:";
            // 
            // btnChuyenKhoaTx
            // 
            this.btnChuyenKhoaTx.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnChuyenKhoaTx.ForeColor = System.Drawing.Color.White;
            this.btnChuyenKhoaTx.Location = new System.Drawing.Point(520, 30);
            this.btnChuyenKhoaTx.Name = "btnChuyenKhoaTx";
            this.btnChuyenKhoaTx.Size = new System.Drawing.Size(260, 68);
            this.btnChuyenKhoaTx.TabIndex = 2;
            this.btnChuyenKhoaTx.Text = "🔄 THỰC THI CHUYỂN KHOA BẰNG TRANSACTION";
            this.btnChuyenKhoaTx.UseVisualStyleBackColor = false;
            this.btnChuyenKhoaTx.Click += new System.EventHandler(this.btnChuyenKhoaTx_Click);
            // 
            // cboKhoaMoi
            // 
            this.cboKhoaMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaMoi.FormattingEnabled = true;
            this.cboKhoaMoi.Location = new System.Drawing.Point(100, 35);
            this.cboKhoaMoi.Name = "cboKhoaMoi";
            this.cboKhoaMoi.Size = new System.Drawing.Size(400, 23);
            this.cboKhoaMoi.TabIndex = 1;
            // 
            // lblKhoaMoi
            // 
            this.lblKhoaMoi.AutoSize = true;
            this.lblKhoaMoi.Location = new System.Drawing.Point(20, 38);
            this.lblKhoaMoi.Name = "lblKhoaMoi";
            this.lblKhoaMoi.Size = new System.Drawing.Size(61, 15);
            this.lblKhoaMoi.TabIndex = 0;
            this.lblKhoaMoi.Text = "Khoa mới:";
            // 
            // grpTransTest
            // 
            this.grpTransTest.Controls.Add(this.btnTestRollbackSuccess);
            this.grpTransTest.Controls.Add(this.btnTestRollbackFail);
            this.grpTransTest.Location = new System.Drawing.Point(15, 15);
            this.grpTransTest.Name = "grpTransTest";
            this.grpTransTest.Size = new System.Drawing.Size(945, 140);
            this.grpTransTest.TabIndex = 0;
            this.grpTransTest.TabStop = false;
            this.grpTransTest.Text = "Bài 3-4: Kiểm Chứng MySqlTransaction (Commit / Rollback khi thêm SV + Đăng ký ban đầu)";
            // 
            // btnTestRollbackSuccess
            // 
            this.btnTestRollbackSuccess.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTestRollbackSuccess.ForeColor = System.Drawing.Color.White;
            this.btnTestRollbackSuccess.Location = new System.Drawing.Point(400, 40);
            this.btnTestRollbackSuccess.Name = "btnTestRollbackSuccess";
            this.btnTestRollbackSuccess.Size = new System.Drawing.Size(350, 60);
            this.btnTestRollbackSuccess.TabIndex = 1;
            this.btnTestRollbackSuccess.Text = "✅ Thử Giao Dịch HỢP LỆ (Commit Toàn Bộ)";
            this.btnTestRollbackSuccess.UseVisualStyleBackColor = false;
            this.btnTestRollbackSuccess.Click += new System.EventHandler(this.btnTestRollbackSuccess_Click);
            // 
            // btnTestRollbackFail
            // 
            this.btnTestRollbackFail.BackColor = System.Drawing.Color.Firebrick;
            this.btnTestRollbackFail.ForeColor = System.Drawing.Color.White;
            this.btnTestRollbackFail.Location = new System.Drawing.Point(25, 40);
            this.btnTestRollbackFail.Name = "btnTestRollbackFail";
            this.btnTestRollbackFail.Size = new System.Drawing.Size(350, 60);
            this.btnTestRollbackFail.TabIndex = 0;
            this.btnTestRollbackFail.Text = "💥 Bài 4: Cố Ý Thêm Mã Học Phần Sai\n(Kiểm chứng ROLLBACK 100%)";
            this.btnTestRollbackFail.UseVisualStyleBackColor = false;
            this.btnTestRollbackFail.Click += new System.EventHandler(this.btnTestRollbackFail_Click);
            // 
            // tabBulkGrade
            // 
            this.tabBulkGrade.Controls.Add(this.btnBulkUpdateGrades);
            this.tabBulkGrade.Controls.Add(this.dgvBulkGrades);
            this.tabBulkGrade.Location = new System.Drawing.Point(4, 24);
            this.tabBulkGrade.Name = "tabBulkGrade";
            this.tabBulkGrade.Padding = new System.Windows.Forms.Padding(3);
            this.tabBulkGrade.Size = new System.Drawing.Size(976, 492);
            this.tabBulkGrade.TabIndex = 2;
            this.tabBulkGrade.Text = "Bài 8: Cập Nhật Điểm Hàng Loạt Trong Transaction (Batch Update)";
            this.tabBulkGrade.UseVisualStyleBackColor = true;
            // 
            // btnBulkUpdateGrades
            // 
            this.btnBulkUpdateGrades.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnBulkUpdateGrades.ForeColor = System.Drawing.Color.White;
            this.btnBulkUpdateGrades.Location = new System.Drawing.Point(15, 12);
            this.btnBulkUpdateGrades.Name = "btnBulkUpdateGrades";
            this.btnBulkUpdateGrades.Size = new System.Drawing.Size(350, 35);
            this.btnBulkUpdateGrades.TabIndex = 1;
            this.btnBulkUpdateGrades.Text = "💾 LƯU ĐIỂM HÀNG LOẠT BẰNG TRANSACTION";
            this.btnBulkUpdateGrades.UseVisualStyleBackColor = false;
            this.btnBulkUpdateGrades.Click += new System.EventHandler(this.btnBulkUpdateGrades_Click);
            // 
            // dgvBulkGrades
            // 
            this.dgvBulkGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBulkGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBulkGrades.Location = new System.Drawing.Point(15, 55);
            this.dgvBulkGrades.Name = "dgvBulkGrades";
            this.dgvBulkGrades.Size = new System.Drawing.Size(945, 425);
            this.dgvBulkGrades.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(232, 17);
            this.lblStatus.Text = "Trạng thái: Đã sẵn sàng thử nghiệm Lab 12.";
            // 
            // frmLab12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 551);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLab12";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 12 - Master-Detail, MySqlTransaction & Hoàn Thiện Mô Hình 3 Lớp ADO.NET";
            this.Load += new System.EventHandler(this.frmLab12_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabMasterDetail.ResumeLayout(false);
            this.tabMasterDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKyDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaMaster)).EndInit();
            this.tabTransaction.ResumeLayout(false);
            this.grpConcurrency.ResumeLayout(false);
            this.grpConcurrency.PerformLayout();
            this.grpChuyenKhoa.ResumeLayout(false);
            this.grpChuyenKhoa.PerformLayout();
            this.grpTransTest.ResumeLayout(false);
            this.tabBulkGrade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBulkGrades)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMasterDetail;
        private System.Windows.Forms.TabPage tabTransaction;
        private System.Windows.Forms.TabPage tabBulkGrade;
        private System.Windows.Forms.DataGridView dgvKhoaMaster;
        private System.Windows.Forms.DataGridView dgvSinhVienDetail;
        private System.Windows.Forms.DataGridView dgvDangKyDetail;
        private System.Windows.Forms.Label lblMasterKhoa;
        private System.Windows.Forms.Label lblDetailSV;
        private System.Windows.Forms.Label lblDetailDangKy;
        private System.Windows.Forms.GroupBox grpTransTest;
        private System.Windows.Forms.Button btnTestRollbackFail;
        private System.Windows.Forms.Button btnTestRollbackSuccess;
        private System.Windows.Forms.GroupBox grpChuyenKhoa;
        private System.Windows.Forms.Label lblKhoaMoi;
        private System.Windows.Forms.ComboBox cboKhoaMoi;
        private System.Windows.Forms.Button btnChuyenKhoaTx;
        private System.Windows.Forms.TextBox txtLyDoChuyen;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.GroupBox grpConcurrency;
        private System.Windows.Forms.Label lblDiemConc;
        private System.Windows.Forms.TextBox txtDiemConcurrency;
        private System.Windows.Forms.Button btnSuaDiemConcurrency;
        private System.Windows.Forms.DataGridView dgvBulkGrades;
        private System.Windows.Forms.Button btnBulkUpdateGrades;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}