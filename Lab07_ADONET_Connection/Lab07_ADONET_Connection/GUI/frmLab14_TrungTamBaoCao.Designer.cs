namespace Lab07_ADONET_Connection.GUI
{
    partial class frmLab14_TrungTamBaoCao
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
            this.btnXuatPdf = new System.Windows.Forms.Button();
            this.btnXuatExcelGrid = new System.Windows.Forms.Button();
            this.btnXuatExcelCrystal = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.numTopN = new System.Windows.Forms.NumericUpDown();
            this.lblTopN = new System.Windows.Forms.Label();
            this.numDiemMax = new System.Windows.Forms.NumericUpDown();
            this.lblDiemMax = new System.Windows.Forms.Label();
            this.numDiemMin = new System.Windows.Forms.NumericUpDown();
            this.lblDiemMin = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.lblLoaiBaoCao = new System.Windows.Forms.Label();
            this.pnlThongKe = new System.Windows.Forms.Panel();
            this.lblThongKeTongHop = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.cboLoaiBieuDo = new System.Windows.Forms.ComboBox();
            this.lblBieuDo = new System.Windows.Forms.Label();
            this.picBieuDo = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTopN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemMin)).BeginInit();
            this.pnlThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBieuDo)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.btnXuatPdf);
            this.grpBoLoc.Controls.Add(this.btnXuatExcelGrid);
            this.grpBoLoc.Controls.Add(this.btnXuatExcelCrystal);
            this.grpBoLoc.Controls.Add(this.btnXemBaoCao);
            this.grpBoLoc.Controls.Add(this.cboHocKy);
            this.grpBoLoc.Controls.Add(this.lblHocKy);
            this.grpBoLoc.Controls.Add(this.numTopN);
            this.grpBoLoc.Controls.Add(this.lblTopN);
            this.grpBoLoc.Controls.Add(this.numDiemMax);
            this.grpBoLoc.Controls.Add(this.lblDiemMax);
            this.grpBoLoc.Controls.Add(this.numDiemMin);
            this.grpBoLoc.Controls.Add(this.lblDiemMin);
            this.grpBoLoc.Controls.Add(this.cboKhoa);
            this.grpBoLoc.Controls.Add(this.lblKhoa);
            this.grpBoLoc.Controls.Add(this.cboLoaiBaoCao);
            this.grpBoLoc.Controls.Add(this.lblLoaiBaoCao);
            this.grpBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpBoLoc.Location = new System.Drawing.Point(0, 0);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(1124, 115);
            this.grpBoLoc.TabIndex = 0;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "TRUNG TÂM BÁO CÁO & THAM SỐ LỌC DỮ LIỆU (BÀI 1 - 10)";
            // 
            // lblLoaiBaoCao
            // 
            this.lblLoaiBaoCao.AutoSize = true;
            this.lblLoaiBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoaiBaoCao.Location = new System.Drawing.Point(15, 28);
            this.lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            this.lblLoaiBaoCao.Size = new System.Drawing.Size(79, 15);
            this.lblLoaiBaoCao.TabIndex = 0;
            this.lblLoaiBaoCao.Text = "Loại báo cáo:";
            // 
            // cboLoaiBaoCao
            // 
            this.cboLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLoaiBaoCao.FormattingEnabled = true;
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(100, 25);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(340, 23);
            this.cboLoaiBaoCao.TabIndex = 1;
            this.cboLoaiBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBaoCao_SelectedIndexChanged);
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhoa.Location = new System.Drawing.Point(460, 28);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(65, 15);
            this.lblKhoa.TabIndex = 2;
            this.lblKhoa.Text = "Chọn Khoa:";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(530, 25);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(210, 23);
            this.cboKhoa.TabIndex = 3;
            // 
            // lblDiemMin
            // 
            this.lblDiemMin.AutoSize = true;
            this.lblDiemMin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiemMin.Location = new System.Drawing.Point(15, 68);
            this.lblDiemMin.Name = "lblDiemMin";
            this.lblDiemMin.Size = new System.Drawing.Size(61, 15);
            this.lblDiemMin.TabIndex = 4;
            this.lblDiemMin.Text = "Điểm Min:";
            // 
            // numDiemMin
            // 
            this.numDiemMin.DecimalPlaces = 1;
            this.numDiemMin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numDiemMin.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numDiemMin.Location = new System.Drawing.Point(100, 65);
            this.numDiemMin.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numDiemMin.Name = "numDiemMin";
            this.numDiemMin.Size = new System.Drawing.Size(75, 23);
            this.numDiemMin.TabIndex = 5;
            // 
            // lblDiemMax
            // 
            this.lblDiemMax.AutoSize = true;
            this.lblDiemMax.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiemMax.Location = new System.Drawing.Point(190, 68);
            this.lblDiemMax.Name = "lblDiemMax";
            this.lblDiemMax.Size = new System.Drawing.Size(64, 15);
            this.lblDiemMax.TabIndex = 6;
            this.lblDiemMax.Text = "Điểm Max:";
            // 
            // numDiemMax
            // 
            this.numDiemMax.DecimalPlaces = 1;
            this.numDiemMax.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numDiemMax.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numDiemMax.Location = new System.Drawing.Point(260, 65);
            this.numDiemMax.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numDiemMax.Name = "numDiemMax";
            this.numDiemMax.Size = new System.Drawing.Size(75, 23);
            this.numDiemMax.TabIndex = 7;
            this.numDiemMax.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblTopN
            // 
            this.lblTopN.AutoSize = true;
            this.lblTopN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTopN.Location = new System.Drawing.Point(355, 68);
            this.lblTopN.Name = "lblTopN";
            this.lblTopN.Size = new System.Drawing.Size(55, 15);
            this.lblTopN.TabIndex = 8;
            this.lblTopN.Text = "Top N SV:";
            // 
            // numTopN
            // 
            this.numTopN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numTopN.Location = new System.Drawing.Point(415, 65);
            this.numTopN.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numTopN.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numTopN.Name = "numTopN";
            this.numTopN.Size = new System.Drawing.Size(65, 23);
            this.numTopN.TabIndex = 9;
            this.numTopN.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHocKy.Location = new System.Drawing.Point(500, 68);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(47, 15);
            this.lblHocKy.TabIndex = 10;
            this.lblHocKy.Text = "Học kỳ:";
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(555, 65);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(185, 23);
            this.cboHocKy.TabIndex = 11;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.Navy;
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(760, 22);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(165, 34);
            this.btnXemBaoCao.TabIndex = 12;
            this.btnXemBaoCao.Text = "🔍 XEM BÁO CÁO";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // btnXuatExcelCrystal
            // 
            this.btnXuatExcelCrystal.BackColor = System.Drawing.Color.DarkGreen;
            this.btnXuatExcelCrystal.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcelCrystal.Location = new System.Drawing.Point(935, 22);
            this.btnXuatExcelCrystal.Name = "btnXuatExcelCrystal";
            this.btnXuatExcelCrystal.Size = new System.Drawing.Size(175, 34);
            this.btnXuatExcelCrystal.TabIndex = 13;
            this.btnXuatExcelCrystal.Text = "📊 Xuất Excel (Bài 5)";
            this.btnXuatExcelCrystal.UseVisualStyleBackColor = false;
            this.btnXuatExcelCrystal.Click += new System.EventHandler(this.btnXuatExcelCrystal_Click);
            // 
            // btnXuatExcelGrid
            // 
            this.btnXuatExcelGrid.BackColor = System.Drawing.Color.SeaGreen;
            this.btnXuatExcelGrid.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcelGrid.Location = new System.Drawing.Point(760, 62);
            this.btnXuatExcelGrid.Name = "btnXuatExcelGrid";
            this.btnXuatExcelGrid.Size = new System.Drawing.Size(165, 34);
            this.btnXuatExcelGrid.TabIndex = 14;
            this.btnXuatExcelGrid.Text = "📑 Xuất Grid Excel (Bài 9)";
            this.btnXuatExcelGrid.UseVisualStyleBackColor = false;
            this.btnXuatExcelGrid.Click += new System.EventHandler(this.btnXuatExcelGrid_Click);
            // 
            // btnXuatPdf
            // 
            this.btnXuatPdf.BackColor = System.Drawing.Color.Firebrick;
            this.btnXuatPdf.ForeColor = System.Drawing.Color.White;
            this.btnXuatPdf.Location = new System.Drawing.Point(935, 62);
            this.btnXuatPdf.Name = "btnXuatPdf";
            this.btnXuatPdf.Size = new System.Drawing.Size(175, 34);
            this.btnXuatPdf.TabIndex = 15;
            this.btnXuatPdf.Text = "📄 Xuất PDF (Bài 10)";
            this.btnXuatPdf.UseVisualStyleBackColor = false;
            this.btnXuatPdf.Click += new System.EventHandler(this.btnXuatPdf_Click);
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlThongKe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongKe.Controls.Add(this.lblThongKeTongHop);
            this.pnlThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongKe.Location = new System.Drawing.Point(0, 115);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Size = new System.Drawing.Size(1124, 36);
            this.pnlThongKe.TabIndex = 1;
            // 
            // lblThongKeTongHop
            // 
            this.lblThongKeTongHop.AutoSize = true;
            this.lblThongKeTongHop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblThongKeTongHop.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblThongKeTongHop.Location = new System.Drawing.Point(15, 8);
            this.lblThongKeTongHop.Name = "lblThongKeTongHop";
            this.lblThongKeTongHop.Size = new System.Drawing.Size(392, 17);
            this.lblThongKeTongHop.TabIndex = 0;
            this.lblThongKeTongHop.Text = "Thống kê tổng hợp: Tổng bản ghi: 0 | Điểm TB: 0.00 | Cao nhất: 0.00 | Thấp nhất: 0.00";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 151);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvBaoCao);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.picBieuDo);
            this.splitContainer1.Panel2.Controls.Add(this.cboLoaiBieuDo);
            this.splitContainer1.Panel2.Controls.Add(this.lblBieuDo);
            this.splitContainer1.Size = new System.Drawing.Size(1124, 448);
            this.splitContainer1.SplitterDistance = 710;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.Location = new System.Drawing.Point(0, 0);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.Size = new System.Drawing.Size(710, 448);
            this.dgvBaoCao.TabIndex = 0;
            // 
            // lblBieuDo
            // 
            this.lblBieuDo.AutoSize = true;
            this.lblBieuDo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBieuDo.Location = new System.Drawing.Point(10, 12);
            this.lblBieuDo.Name = "lblBieuDo";
            this.lblBieuDo.Size = new System.Drawing.Size(115, 15);
            this.lblBieuDo.TabIndex = 0;
            this.lblBieuDo.Text = "Biểu đồ thống kê:";
            // 
            // cboLoaiBieuDo
            // 
            this.cboLoaiBieuDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBieuDo.FormattingEnabled = true;
            this.cboLoaiBieuDo.Location = new System.Drawing.Point(130, 8);
            this.cboLoaiBieuDo.Name = "cboLoaiBieuDo";
            this.cboLoaiBieuDo.Size = new System.Drawing.Size(265, 23);
            this.cboLoaiBieuDo.TabIndex = 1;
            this.cboLoaiBieuDo.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBieuDo_SelectedIndexChanged);
            // 
            // picBieuDo
            // 
            this.picBieuDo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBieuDo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picBieuDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBieuDo.Location = new System.Drawing.Point(10, 38);
            this.picBieuDo.Name = "picBieuDo";
            this.picBieuDo.Size = new System.Drawing.Size(388, 400);
            this.picBieuDo.TabIndex = 2;
            this.picBieuDo.TabStop = false;
            this.picBieuDo.Paint += new System.Windows.Forms.PaintEventHandler(this.picBieuDo_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 599);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1124, 22);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(288, 17);
            this.lblStatus.Text = "Trạng thái: Trung tâm Báo cáo Lab 14 đã sẵn sàng.";
            // 
            // frmLab14_TrungTamBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 621);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlThongKe);
            this.Controls.Add(this.grpBoLoc);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmLab14_TrungTamBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 14 - Trung Tâm Báo Cáo Tham Số, Nhóm, Thống Kê & Xuất Excel";
            this.Load += new System.EventHandler(this.frmLab14_TrungTamBaoCao_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTopN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemMin)).EndInit();
            this.pnlThongKe.ResumeLayout(false);
            this.pnlThongKe.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBieuDo)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.Label lblLoaiBaoCao;
        private System.Windows.Forms.ComboBox cboLoaiBaoCao;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label lblDiemMin;
        private System.Windows.Forms.NumericUpDown numDiemMin;
        private System.Windows.Forms.Label lblDiemMax;
        private System.Windows.Forms.NumericUpDown numDiemMax;
        private System.Windows.Forms.Label lblTopN;
        private System.Windows.Forms.NumericUpDown numTopN;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnXuatExcelCrystal;
        private System.Windows.Forms.Button btnXuatExcelGrid;
        private System.Windows.Forms.Button btnXuatPdf;
        private System.Windows.Forms.Panel pnlThongKe;
        private System.Windows.Forms.Label lblThongKeTongHop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Label lblBieuDo;
        private System.Windows.Forms.ComboBox cboLoaiBieuDo;
        private System.Windows.Forms.PictureBox picBieuDo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}