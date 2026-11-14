namespace Lab07_ADONET_Connection.GUI
{
    partial class frmLab15_HeThongVaCauHinh
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.grpPreFlight = new System.Windows.Forms.GroupBox();
            this.btnKiemTraHeThong = new System.Windows.Forms.Button();
            this.dgvKiemTra = new System.Windows.Forms.DataGridView();
            this.grpCauHinh = new System.Windows.Forms.GroupBox();
            this.btnGiaiMaConfig = new System.Windows.Forms.Button();
            this.btnMaHoaConfig = new System.Windows.Forms.Button();
            this.lblTrangThaiMaHoa = new System.Windows.Forms.Label();
            this.txtConnStrPreview = new System.Windows.Forms.TextBox();
            this.lblConnStr = new System.Windows.Forms.Label();
            this.grpTestLoi = new System.Windows.Forms.GroupBox();
            this.btnMoTrungTamBaoCao = new System.Windows.Forms.Button();
            this.btnTaiLaiLog = new System.Windows.Forms.Button();
            this.btnTestDbError = new System.Windows.Forms.Button();
            this.btnTestBusinessEx = new System.Windows.Forms.Button();
            this.txtLogViewer = new System.Windows.Forms.TextBox();
            this.grpPreFlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemTra)).BeginInit();
            this.grpCauHinh.SuspendLayout();
            this.grpTestLoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPreFlight
            // 
            this.grpPreFlight.Controls.Add(this.btnKiemTraHeThong);
            this.grpPreFlight.Controls.Add(this.dgvKiemTra);
            this.grpPreFlight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpPreFlight.Location = new System.Drawing.Point(12, 12);
            this.grpPreFlight.Name = "grpPreFlight";
            this.grpPreFlight.Size = new System.Drawing.Size(960, 210);
            this.grpPreFlight.TabIndex = 0;
            this.grpPreFlight.TabStop = false;
            this.grpPreFlight.Text = "1. KIỂM TRA SẴN SÀNG TRƯỚC KHI CHẠY (PRE-FLIGHT CHECK - BÀI 9)";
            // 
            // dgvKiemTra
            // 
            this.dgvKiemTra.AllowUserToAddRows = false;
            this.dgvKiemTra.AllowUserToDeleteRows = false;
            this.dgvKiemTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKiemTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKiemTra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvKiemTra.Location = new System.Drawing.Point(15, 25);
            this.dgvKiemTra.Name = "dgvKiemTra";
            this.dgvKiemTra.ReadOnly = true;
            this.dgvKiemTra.Size = new System.Drawing.Size(760, 170);
            this.dgvKiemTra.TabIndex = 0;
            // 
            // btnKiemTraHeThong
            // 
            this.btnKiemTraHeThong.BackColor = System.Drawing.Color.Navy;
            this.btnKiemTraHeThong.ForeColor = System.Drawing.Color.White;
            this.btnKiemTraHeThong.Location = new System.Drawing.Point(790, 25);
            this.btnKiemTraHeThong.Name = "btnKiemTraHeThong";
            this.btnKiemTraHeThong.Size = new System.Drawing.Size(155, 45);
            this.btnKiemTraHeThong.TabIndex = 1;
            this.btnKiemTraHeThong.Text = "🔍 CHẠY KIỂM TRA";
            this.btnKiemTraHeThong.UseVisualStyleBackColor = false;
            this.btnKiemTraHeThong.Click += new System.EventHandler(this.btnKiemTraHeThong_Click);
            // 
            // grpCauHinh
            // 
            this.grpCauHinh.Controls.Add(this.btnGiaiMaConfig);
            this.grpCauHinh.Controls.Add(this.btnMaHoaConfig);
            this.grpCauHinh.Controls.Add(this.lblTrangThaiMaHoa);
            this.grpCauHinh.Controls.Add(this.txtConnStrPreview);
            this.grpCauHinh.Controls.Add(this.lblConnStr);
            this.grpCauHinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCauHinh.Location = new System.Drawing.Point(12, 232);
            this.grpCauHinh.Name = "grpCauHinh";
            this.grpCauHinh.Size = new System.Drawing.Size(960, 105);
            this.grpCauHinh.TabIndex = 1;
            this.grpCauHinh.TabStop = false;
            this.grpCauHinh.Text = "2. QUẢN LÝ CẤU HÌNH APP.CONFIG & MÃ HÓA CONNECTION STRING (BÀI 5 & 8)";
            // 
            // lblConnStr
            // 
            this.lblConnStr.AutoSize = true;
            this.lblConnStr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConnStr.Location = new System.Drawing.Point(15, 30);
            this.lblConnStr.Name = "lblConnStr";
            this.lblConnStr.Size = new System.Drawing.Size(113, 15);
            this.lblConnStr.TabIndex = 0;
            this.lblConnStr.Text = "Chuỗi kết nối (che):";
            // 
            // txtConnStrPreview
            // 
            this.txtConnStrPreview.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtConnStrPreview.Location = new System.Drawing.Point(135, 27);
            this.txtConnStrPreview.Name = "txtConnStrPreview";
            this.txtConnStrPreview.ReadOnly = true;
            this.txtConnStrPreview.Size = new System.Drawing.Size(490, 22);
            this.txtConnStrPreview.TabIndex = 1;
            // 
            // lblTrangThaiMaHoa
            // 
            this.lblTrangThaiMaHoa.AutoSize = true;
            this.lblTrangThaiMaHoa.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTrangThaiMaHoa.Location = new System.Drawing.Point(15, 65);
            this.lblTrangThaiMaHoa.Name = "lblTrangThaiMaHoa";
            this.lblTrangThaiMaHoa.Size = new System.Drawing.Size(185, 15);
            this.lblTrangThaiMaHoa.TabIndex = 2;
            this.lblTrangThaiMaHoa.Text = "Trạng thái bảo mật: Đang kiểm tra...";
            // 
            // btnMaHoaConfig
            // 
            this.btnMaHoaConfig.BackColor = System.Drawing.Color.DarkGreen;
            this.btnMaHoaConfig.ForeColor = System.Drawing.Color.White;
            this.btnMaHoaConfig.Location = new System.Drawing.Point(640, 25);
            this.btnMaHoaConfig.Name = "btnMaHoaConfig";
            this.btnMaHoaConfig.Size = new System.Drawing.Size(145, 55);
            this.btnMaHoaConfig.TabIndex = 3;
            this.btnMaHoaConfig.Text = "🔒 Mã hóa Config";
            this.btnMaHoaConfig.UseVisualStyleBackColor = false;
            this.btnMaHoaConfig.Click += new System.EventHandler(this.btnMaHoaConfig_Click);
            // 
            // btnGiaiMaConfig
            // 
            this.btnGiaiMaConfig.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGiaiMaConfig.ForeColor = System.Drawing.Color.White;
            this.btnGiaiMaConfig.Location = new System.Drawing.Point(795, 25);
            this.btnGiaiMaConfig.Name = "btnGiaiMaConfig";
            this.btnGiaiMaConfig.Size = new System.Drawing.Size(150, 55);
            this.btnGiaiMaConfig.TabIndex = 4;
            this.btnGiaiMaConfig.Text = "🔓 Giải mã Config";
            this.btnGiaiMaConfig.UseVisualStyleBackColor = false;
            this.btnGiaiMaConfig.Click += new System.EventHandler(this.btnGiaiMaConfig_Click);
            // 
            // grpTestLoi
            // 
            this.grpTestLoi.Controls.Add(this.btnMoTrungTamBaoCao);
            this.grpTestLoi.Controls.Add(this.btnTaiLaiLog);
            this.grpTestLoi.Controls.Add(this.btnTestDbError);
            this.grpTestLoi.Controls.Add(this.btnTestBusinessEx);
            this.grpTestLoi.Controls.Add(this.txtLogViewer);
            this.grpTestLoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTestLoi.Location = new System.Drawing.Point(12, 347);
            this.grpTestLoi.Name = "grpTestLoi";
            this.grpTestLoi.Size = new System.Drawing.Size(960, 235);
            this.grpTestLoi.TabIndex = 2;
            this.grpTestLoi.TabStop = false;
            this.grpTestLoi.Text = "3. KIỂM THỬ XỬ LÝ LỖI THEO TẦNG & NHẬT KÝ LOGGING (BÀI 1, 2, 3, 4, 7)";
            // 
            // txtLogViewer
            // 
            this.txtLogViewer.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtLogViewer.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLogViewer.ForeColor = System.Drawing.Color.LightGreen;
            this.txtLogViewer.Location = new System.Drawing.Point(15, 25);
            this.txtLogViewer.Multiline = true;
            this.txtLogViewer.Name = "txtLogViewer";
            this.txtLogViewer.ReadOnly = true;
            this.txtLogViewer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogViewer.Size = new System.Drawing.Size(760, 195);
            this.txtLogViewer.TabIndex = 0;
            // 
            // btnTestBusinessEx
            // 
            this.btnTestBusinessEx.BackColor = System.Drawing.Color.Teal;
            this.btnTestBusinessEx.ForeColor = System.Drawing.Color.White;
            this.btnTestBusinessEx.Location = new System.Drawing.Point(790, 25);
            this.btnTestBusinessEx.Name = "btnTestBusinessEx";
            this.btnTestBusinessEx.Size = new System.Drawing.Size(155, 42);
            this.btnTestBusinessEx.TabIndex = 1;
            this.btnTestBusinessEx.Text = "🧪 Test Lỗi Nghiệp Vụ";
            this.btnTestBusinessEx.UseVisualStyleBackColor = false;
            this.btnTestBusinessEx.Click += new System.EventHandler(this.btnTestBusinessEx_Click);
            // 
            // btnTestDbError
            // 
            this.btnTestDbError.BackColor = System.Drawing.Color.Firebrick;
            this.btnTestDbError.ForeColor = System.Drawing.Color.White;
            this.btnTestDbError.Location = new System.Drawing.Point(790, 75);
            this.btnTestDbError.Name = "btnTestDbError";
            this.btnTestDbError.Size = new System.Drawing.Size(155, 42);
            this.btnTestDbError.TabIndex = 2;
            this.btnTestDbError.Text = "⚠️ Test Lỗi CSDL";
            this.btnTestDbError.UseVisualStyleBackColor = false;
            this.btnTestDbError.Click += new System.EventHandler(this.btnTestDbError_Click);
            // 
            // btnTaiLaiLog
            // 
            this.btnTaiLaiLog.BackColor = System.Drawing.Color.SlateGray;
            this.btnTaiLaiLog.ForeColor = System.Drawing.Color.White;
            this.btnTaiLaiLog.Location = new System.Drawing.Point(790, 125);
            this.btnTaiLaiLog.Name = "btnTaiLaiLog";
            this.btnTaiLaiLog.Size = new System.Drawing.Size(155, 42);
            this.btnTaiLaiLog.TabIndex = 3;
            this.btnTaiLaiLog.Text = "🔄 Tải Lại File Log";
            this.btnTaiLaiLog.UseVisualStyleBackColor = false;
            this.btnTaiLaiLog.Click += new System.EventHandler(this.btnTaiLaiLog_Click);
            // 
            // btnMoTrungTamBaoCao
            // 
            this.btnMoTrungTamBaoCao.BackColor = System.Drawing.Color.Indigo;
            this.btnMoTrungTamBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnMoTrungTamBaoCao.Location = new System.Drawing.Point(790, 175);
            this.btnMoTrungTamBaoCao.Name = "btnMoTrungTamBaoCao";
            this.btnMoTrungTamBaoCao.Size = new System.Drawing.Size(155, 45);
            this.btnMoTrungTamBaoCao.TabIndex = 4;
            this.btnMoTrungTamBaoCao.Text = "📊 Mở Báo Cáo Lab 14";
            this.btnMoTrungTamBaoCao.UseVisualStyleBackColor = false;
            this.btnMoTrungTamBaoCao.Click += new System.EventHandler(this.btnMoTrungTamBaoCao_Click);
            // 
            // frmLab15_HeThongVaCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 594);
            this.Controls.Add(this.grpTestLoi);
            this.Controls.Add(this.grpCauHinh);
            this.Controls.Add(this.grpPreFlight);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmLab15_HeThongVaCauHinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 15 - Kiểm Tra Hệ Thống, Cấu Hình Bảo Mật & Xử Lý Lỗi Nâng Cao";
            this.Load += new System.EventHandler(this.frmLab15_HeThongVaCauHinh_Load);
            this.grpPreFlight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemTra)).EndInit();
            this.grpCauHinh.ResumeLayout(false);
            this.grpCauHinh.PerformLayout();
            this.grpTestLoi.ResumeLayout(false);
            this.grpTestLoi.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.GroupBox grpPreFlight;
        private System.Windows.Forms.DataGridView dgvKiemTra;
        private System.Windows.Forms.Button btnKiemTraHeThong;
        private System.Windows.Forms.GroupBox grpCauHinh;
        private System.Windows.Forms.Label lblConnStr;
        private System.Windows.Forms.TextBox txtConnStrPreview;
        private System.Windows.Forms.Label lblTrangThaiMaHoa;
        private System.Windows.Forms.Button btnMaHoaConfig;
        private System.Windows.Forms.Button btnGiaiMaConfig;
        private System.Windows.Forms.GroupBox grpTestLoi;
        private System.Windows.Forms.TextBox txtLogViewer;
        private System.Windows.Forms.Button btnTestBusinessEx;
        private System.Windows.Forms.Button btnTestDbError;
        private System.Windows.Forms.Button btnTaiLaiLog;
        private System.Windows.Forms.Button btnMoTrungTamBaoCao;
    }
}