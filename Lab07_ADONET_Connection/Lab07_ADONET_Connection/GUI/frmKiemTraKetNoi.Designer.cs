namespace Lab07_ADONET_Connection
{
    partial class frmKiemTraKetNoi
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
            this.grpCauHinh = new System.Windows.Forms.GroupBox();
            this.lblChuoiKetNoi = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.rdoSqlAuth = new System.Windows.Forms.RadioButton();
            this.rdoWinAuth = new System.Windows.Forms.RadioButton();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpTrangThai = new System.Windows.Forms.GroupBox();
            this.lblCheckTime = new System.Windows.Forms.Label();
            this.lblResponseTime = new System.Windows.Forms.Label();
            this.lblServerVersion = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblStatusMsg = new System.Windows.Forms.Label();
            this.grpCauHinh.SuspendLayout();
            this.grpTrangThai.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCauHinh
            // 
            this.grpCauHinh.Controls.Add(this.lblChuoiKetNoi);
            this.grpCauHinh.Controls.Add(this.txtConnectionString);
            this.grpCauHinh.Controls.Add(this.rdoSqlAuth);
            this.grpCauHinh.Controls.Add(this.rdoWinAuth);
            this.grpCauHinh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpCauHinh.Location = new System.Drawing.Point(16, 15);
            this.grpCauHinh.Name = "grpCauHinh";
            this.grpCauHinh.Size = new System.Drawing.Size(650, 115);
            this.grpCauHinh.TabIndex = 0;
            this.grpCauHinh.TabStop = false;
            this.grpCauHinh.Text = "Cấu hình Chuỗi kết nối (App.config)";
            // 
            // lblChuoiKetNoi
            // 
            this.lblChuoiKetNoi.AutoSize = true;
            this.lblChuoiKetNoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChuoiKetNoi.Location = new System.Drawing.Point(15, 73);
            this.lblChuoiKetNoi.Name = "lblChuoiKetNoi";
            this.lblChuoiKetNoi.Size = new System.Drawing.Size(79, 15);
            this.lblChuoiKetNoi.TabIndex = 3;
            this.lblChuoiKetNoi.Text = "Chuỗi kết nối:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.BackColor = System.Drawing.SystemColors.Window;
            this.txtConnectionString.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtConnectionString.Location = new System.Drawing.Point(105, 70);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ReadOnly = true;
            this.txtConnectionString.Size = new System.Drawing.Size(525, 22);
            this.txtConnectionString.TabIndex = 2;
            this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
            // 
            // rdoSqlAuth
            // 
            this.rdoSqlAuth.AutoSize = true;
            this.rdoSqlAuth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoSqlAuth.Location = new System.Drawing.Point(230, 32);
            this.rdoSqlAuth.Name = "rdoSqlAuth";
            this.rdoSqlAuth.Size = new System.Drawing.Size(262, 19);
            this.rdoSqlAuth.TabIndex = 1;
            this.rdoSqlAuth.Text = "Tài khoản QLSV_AppUser (User riêng Bài 7)";
            this.rdoSqlAuth.UseVisualStyleBackColor = true;
            this.rdoSqlAuth.CheckedChanged += new System.EventHandler(this.rdoSqlAuth_CheckedChanged);
            // 
            // rdoWinAuth
            // 
            this.rdoWinAuth.AutoSize = true;
            this.rdoWinAuth.Checked = true;
            this.rdoWinAuth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoWinAuth.Location = new System.Drawing.Point(18, 32);
            this.rdoWinAuth.Name = "rdoWinAuth";
            this.rdoWinAuth.Size = new System.Drawing.Size(193, 19);
            this.rdoWinAuth.TabIndex = 0;
            this.rdoWinAuth.TabStop = true;
            this.rdoWinAuth.Text = "Tài khoản Root (Administrator)";
            this.rdoWinAuth.UseVisualStyleBackColor = true;
            this.rdoWinAuth.CheckedChanged += new System.EventHandler(this.rdoWinAuth_CheckedChanged);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnKiemTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTra.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnKiemTra.ForeColor = System.Drawing.Color.White;
            this.btnKiemTra.Location = new System.Drawing.Point(16, 142);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(200, 38);
            this.btnKiemTra.TabIndex = 1;
            this.btnKiemTra.Text = "⚡ KIỂM TRA KẾT NỐI";
            this.btnKiemTra.UseVisualStyleBackColor = false;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.Location = new System.Drawing.Point(230, 142);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(160, 38);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "🔄 LÀM MỚI TÌNH TRẠNG";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // grpTrangThai
            // 
            this.grpTrangThai.Controls.Add(this.lblCheckTime);
            this.grpTrangThai.Controls.Add(this.lblResponseTime);
            this.grpTrangThai.Controls.Add(this.lblServerVersion);
            this.grpTrangThai.Controls.Add(this.lblDatabase);
            this.grpTrangThai.Controls.Add(this.lblDataSource);
            this.grpTrangThai.Controls.Add(this.lblState);
            this.grpTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpTrangThai.Location = new System.Drawing.Point(16, 195);
            this.grpTrangThai.Name = "grpTrangThai";
            this.grpTrangThai.Size = new System.Drawing.Size(650, 190);
            this.grpTrangThai.TabIndex = 3;
            this.grpTrangThai.TabStop = false;
            this.grpTrangThai.Text = "Trang Trạng Thái Hệ Thống & Kết Nối (Bài 9)";
            // 
            // lblCheckTime
            // 
            this.lblCheckTime.AutoSize = true;
            this.lblCheckTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckTime.Location = new System.Drawing.Point(18, 155);
            this.lblCheckTime.Name = "lblCheckTime";
            this.lblCheckTime.Size = new System.Drawing.Size(175, 15);
            this.lblCheckTime.TabIndex = 5;
            this.lblCheckTime.Text = "• Thời điểm kiểm tra gần nhất: --";
            this.lblCheckTime.Click += new System.EventHandler(this.lblCheckTime_Click);
            // 
            // lblResponseTime
            // 
            this.lblResponseTime.AutoSize = true;
            this.lblResponseTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResponseTime.Location = new System.Drawing.Point(18, 130);
            this.lblResponseTime.Name = "lblResponseTime";
            this.lblResponseTime.Size = new System.Drawing.Size(164, 15);
            this.lblResponseTime.TabIndex = 4;
            this.lblResponseTime.Text = "• Thời gian phản hồi (Latency): --";
            this.lblResponseTime.Click += new System.EventHandler(this.lblResponseTime_Click);
            // 
            // lblServerVersion
            // 
            this.lblServerVersion.AutoSize = true;
            this.lblServerVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblServerVersion.Location = new System.Drawing.Point(18, 105);
            this.lblServerVersion.Name = "lblServerVersion";
            this.lblServerVersion.Size = new System.Drawing.Size(149, 15);
            this.lblServerVersion.TabIndex = 3;
            this.lblServerVersion.Text = "• Phiên bản MySQL Server: --";
            this.lblServerVersion.Click += new System.EventHandler(this.lblServerVersion_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDatabase.Location = new System.Drawing.Point(18, 80);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(146, 15);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "• Tên Database (Catalog): --";
            this.lblDatabase.Click += new System.EventHandler(this.lblDatabase_Click);
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDataSource.Location = new System.Drawing.Point(18, 55);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(155, 15);
            this.lblDataSource.TabIndex = 1;
            this.lblDataSource.Text = "• Máy chủ CSDL (Server Host): --";
            this.lblDataSource.Click += new System.EventHandler(this.lblDataSource_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblState.Location = new System.Drawing.Point(18, 30);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(140, 15);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "• Trạng thái kết nối (State): --";
            this.lblState.Click += new System.EventHandler(this.lblState_Click);
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.AutoSize = true;
            this.lblStatusMsg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatusMsg.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatusMsg.Location = new System.Drawing.Point(16, 395);
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(306, 15);
            this.lblStatusMsg.TabIndex = 4;
            this.lblStatusMsg.Text = "Trạng thái: Sẵn sàng kiểm tra kết nối CSDL MySQL QLSinhVien.";
            this.lblStatusMsg.Click += new System.EventHandler(this.lblStatusMsg_Click);
            // 
            // frmKiemTraKetNoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 425);
            this.Controls.Add(this.lblStatusMsg);
            this.Controls.Add(this.grpTrangThai);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.grpCauHinh);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmKiemTraKetNoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab07 - Kiểm Tra & Trang Trạng Thái Kết Nối CSDL MySQL (ADO.NET)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpCauHinh.ResumeLayout(false);
            this.grpCauHinh.PerformLayout();
            this.grpTrangThai.ResumeLayout(false);
            this.grpTrangThai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCauHinh;
        private System.Windows.Forms.RadioButton rdoSqlAuth;
        private System.Windows.Forms.RadioButton rdoWinAuth;
        private System.Windows.Forms.Label lblChuoiKetNoi;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpTrangThai;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblServerVersion;
        private System.Windows.Forms.Label lblResponseTime;
        private System.Windows.Forms.Label lblCheckTime;
        private System.Windows.Forms.Label lblStatusMsg;
    }
}