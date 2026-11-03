namespace Lab07_ADONET_Connection.GUI
{
    partial class frmLab10
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
            this.tabCoBan = new System.Windows.Forms.TabPage();
            this.btnXemRelation = new System.Windows.Forms.Button();
            this.btnFillDataSet = new System.Windows.Forms.Button();
            this.btnFillDataTable = new System.Windows.Forms.Button();
            this.lstChildRows = new System.Windows.Forms.ListBox();
            this.lblChildRows = new System.Windows.Forms.Label();
            this.lblTableSV = new System.Windows.Forms.Label();
            this.dgvSinhVienCoBan = new System.Windows.Forms.DataGridView();
            this.lblTableKhoa = new System.Windows.Forms.Label();
            this.dgvKhoaCoBan = new System.Windows.Forms.DataGridView();
            this.tabDataViewUpdate = new System.Windows.Forms.TabPage();
            this.grpUpdateCommand = new System.Windows.Forms.GroupBox();
            this.btnLuuChanges = new System.Windows.Forms.Button();
            this.btnLoadForUpdate = new System.Windows.Forms.Button();
            this.grpDataView = new System.Windows.Forms.GroupBox();
            this.cboKhoaDataView = new System.Windows.Forms.ComboBox();
            this.lblKhoaDV = new System.Windows.Forms.Label();
            this.btnLocDataView = new System.Windows.Forms.Button();
            this.txtMinDiemDV = new System.Windows.Forms.TextBox();
            this.lblMinDiemDV = new System.Windows.Forms.Label();
            this.dgvDataView = new System.Windows.Forms.DataGridView();
            this.tabRowState = new System.Windows.Forms.TabPage();
            this.rtbLogState = new System.Windows.Forms.RichTextBox();
            this.btnRejectChanges = new System.Windows.Forms.Button();
            this.btnAcceptChanges = new System.Windows.Forms.Button();
            this.btnTheoDoiRowState = new System.Windows.Forms.Button();
            this.btnTaoTableThuCong = new System.Windows.Forms.Button();
            this.dgvRowState = new System.Windows.Forms.DataGridView();
            this.tabXmlMerge = new System.Windows.Forms.TabPage();
            this.btnMergeData = new System.Windows.Forms.Button();
            this.btnDocXML = new System.Windows.Forms.Button();
            this.btnLuuXML = new System.Windows.Forms.Button();
            this.dgvXmlMerge = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabCoBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienCoBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaCoBan)).BeginInit();
            this.tabDataViewUpdate.SuspendLayout();
            this.grpUpdateCommand.SuspendLayout();
            this.grpDataView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataView)).BeginInit();
            this.tabRowState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRowState)).BeginInit();
            this.tabXmlMerge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXmlMerge)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCoBan);
            this.tabControl1.Controls.Add(this.tabDataViewUpdate);
            this.tabControl1.Controls.Add(this.tabRowState);
            this.tabControl1.Controls.Add(this.tabXmlMerge);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 520);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCoBan
            // 
            this.tabCoBan.Controls.Add(this.btnXemRelation);
            this.tabCoBan.Controls.Add(this.btnFillDataSet);
            this.tabCoBan.Controls.Add(this.btnFillDataTable);
            this.tabCoBan.Controls.Add(this.lstChildRows);
            this.tabCoBan.Controls.Add(this.lblChildRows);
            this.tabCoBan.Controls.Add(this.lblTableSV);
            this.tabCoBan.Controls.Add(this.dgvSinhVienCoBan);
            this.tabCoBan.Controls.Add(this.lblTableKhoa);
            this.tabCoBan.Controls.Add(this.dgvKhoaCoBan);
            this.tabCoBan.Location = new System.Drawing.Point(4, 24);
            this.tabCoBan.Name = "tabCoBan";
            this.tabCoBan.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoBan.Size = new System.Drawing.Size(976, 492);
            this.tabCoBan.TabIndex = 0;
            this.tabCoBan.Text = "Bài 1-3: Fill DataTable, DataSet & DataRelation";
            this.tabCoBan.UseVisualStyleBackColor = true;
            // 
            // btnXemRelation
            // 
            this.btnXemRelation.Location = new System.Drawing.Point(375, 12);
            this.btnXemRelation.Name = "btnXemRelation";
            this.btnXemRelation.Size = new System.Drawing.Size(220, 30);
            this.btnXemRelation.TabIndex = 8;
            this.btnXemRelation.Text = "3. Thử DataRelation (GetChildRows)";
            this.btnXemRelation.UseVisualStyleBackColor = true;
            this.btnXemRelation.Click += new System.EventHandler(this.btnXemRelation_Click);
            // 
            // btnFillDataSet
            // 
            this.btnFillDataSet.Location = new System.Drawing.Point(185, 12);
            this.btnFillDataSet.Name = "btnFillDataSet";
            this.btnFillDataSet.Size = new System.Drawing.Size(180, 30);
            this.btnFillDataSet.TabIndex = 7;
            this.btnFillDataSet.Text = "2. Fill DataSet (Khoa + SV)";
            this.btnFillDataSet.UseVisualStyleBackColor = true;
            this.btnFillDataSet.Click += new System.EventHandler(this.btnFillDataSet_Click);
            // 
            // btnFillDataTable
            // 
            this.btnFillDataTable.Location = new System.Drawing.Point(15, 12);
            this.btnFillDataTable.Name = "btnFillDataTable";
            this.btnFillDataTable.Size = new System.Drawing.Size(160, 30);
            this.btnFillDataTable.TabIndex = 6;
            this.btnFillDataTable.Text = "1. Fill DataTable";
            this.btnFillDataTable.UseVisualStyleBackColor = true;
            this.btnFillDataTable.Click += new System.EventHandler(this.btnFillDataTable_Click);
            // 
            // lstChildRows
            // 
            this.lstChildRows.FormattingEnabled = true;
            this.lstChildRows.ItemHeight = 15;
            this.lstChildRows.Location = new System.Drawing.Point(15, 340);
            this.lstChildRows.Name = "lstChildRows";
            this.lstChildRows.Size = new System.Drawing.Size(945, 139);
            this.lstChildRows.TabIndex = 5;
            // 
            // lblChildRows
            // 
            this.lblChildRows.AutoSize = true;
            this.lblChildRows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChildRows.Location = new System.Drawing.Point(15, 320);
            this.lblChildRows.Name = "lblChildRows";
            this.lblChildRows.Size = new System.Drawing.Size(328, 15);
            this.lblChildRows.TabIndex = 4;
            this.lblChildRows.Text = "Danh Sách Sinh Viên Thuộc Khoa Chọn (DataRelation):";
            // 
            // lblTableSV
            // 
            this.lblTableSV.AutoSize = true;
            this.lblTableSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTableSV.Location = new System.Drawing.Point(340, 52);
            this.lblTableSV.Name = "lblTableSV";
            this.lblTableSV.Size = new System.Drawing.Size(123, 15);
            this.lblTableSV.TabIndex = 3;
            this.lblTableSV.Text = "Bảng Data: SinhVien";
            // 
            // dgvSinhVienCoBan
            // 
            this.dgvSinhVienCoBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVienCoBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVienCoBan.Location = new System.Drawing.Point(340, 72);
            this.dgvSinhVienCoBan.Name = "dgvSinhVienCoBan";
            this.dgvSinhVienCoBan.ReadOnly = true;
            this.dgvSinhVienCoBan.Size = new System.Drawing.Size(620, 235);
            this.dgvSinhVienCoBan.TabIndex = 2;
            // 
            // lblTableKhoa
            // 
            this.lblTableKhoa.AutoSize = true;
            this.lblTableKhoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTableKhoa.Location = new System.Drawing.Point(15, 52);
            this.lblTableKhoa.Name = "lblTableKhoa";
            this.lblTableKhoa.Size = new System.Drawing.Size(100, 15);
            this.lblTableKhoa.TabIndex = 1;
            this.lblTableKhoa.Text = "Bảng Data: Khoa";
            // 
            // dgvKhoaCoBan
            // 
            this.dgvKhoaCoBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoaCoBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoaCoBan.Location = new System.Drawing.Point(15, 72);
            this.dgvKhoaCoBan.Name = "dgvKhoaCoBan";
            this.dgvKhoaCoBan.ReadOnly = true;
            this.dgvKhoaCoBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoaCoBan.Size = new System.Drawing.Size(310, 235);
            this.dgvKhoaCoBan.TabIndex = 0;
            this.dgvKhoaCoBan.SelectionChanged += new System.EventHandler(this.dgvKhoaCoBan_SelectionChanged);
            // 
            // tabDataViewUpdate
            // 
            this.tabDataViewUpdate.Controls.Add(this.grpUpdateCommand);
            this.tabDataViewUpdate.Controls.Add(this.grpDataView);
            this.tabDataViewUpdate.Controls.Add(this.dgvDataView);
            this.tabDataViewUpdate.Location = new System.Drawing.Point(4, 24);
            this.tabDataViewUpdate.Name = "tabDataViewUpdate";
            this.tabDataViewUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataViewUpdate.Size = new System.Drawing.Size(976, 492);
            this.tabDataViewUpdate.TabIndex = 1;
            this.tabDataViewUpdate.Text = "Bài 4-5: DataView & Cập nhật MySqlCommandBuilder";
            this.tabDataViewUpdate.UseVisualStyleBackColor = true;
            // 
            // grpUpdateCommand
            // 
            this.grpUpdateCommand.Controls.Add(this.btnLuuChanges);
            this.grpUpdateCommand.Controls.Add(this.btnLoadForUpdate);
            this.grpUpdateCommand.Location = new System.Drawing.Point(620, 12);
            this.grpUpdateCommand.Name = "grpUpdateCommand";
            this.grpUpdateCommand.Size = new System.Drawing.Size(340, 75);
            this.grpUpdateCommand.TabIndex = 2;
            this.grpUpdateCommand.TabStop = false;
            this.grpUpdateCommand.Text = "Bài 5: Cập nhật bằng MySqlCommandBuilder";
            // 
            // btnLuuChanges
            // 
            this.btnLuuChanges.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLuuChanges.ForeColor = System.Drawing.Color.White;
            this.btnLuuChanges.Location = new System.Drawing.Point(175, 28);
            this.btnLuuChanges.Name = "btnLuuChanges";
            this.btnLuuChanges.Size = new System.Drawing.Size(150, 32);
            this.btnLuuChanges.TabIndex = 1;
            this.btnLuuChanges.Text = "💾 LƯU BẰNG ADAPTER";
            this.btnLuuChanges.UseVisualStyleBackColor = false;
            this.btnLuuChanges.Click += new System.EventHandler(this.btnLuuChanges_Click);
            // 
            // btnLoadForUpdate
            // 
            this.btnLoadForUpdate.Location = new System.Drawing.Point(15, 28);
            this.btnLoadForUpdate.Name = "btnLoadForUpdate";
            this.btnLoadForUpdate.Size = new System.Drawing.Size(150, 32);
            this.btnLoadForUpdate.TabIndex = 0;
            this.btnLoadForUpdate.Text = "Nạp Bảng Cho Phép Sửa";
            this.btnLoadForUpdate.UseVisualStyleBackColor = true;
            this.btnLoadForUpdate.Click += new System.EventHandler(this.btnLoadForUpdate_Click);
            // 
            // grpDataView
            // 
            this.grpDataView.Controls.Add(this.cboKhoaDataView);
            this.grpDataView.Controls.Add(this.lblKhoaDV);
            this.grpDataView.Controls.Add(this.btnLocDataView);
            this.grpDataView.Controls.Add(this.txtMinDiemDV);
            this.grpDataView.Controls.Add(this.lblMinDiemDV);
            this.grpDataView.Location = new System.Drawing.Point(15, 12);
            this.grpDataView.Name = "grpDataView";
            this.grpDataView.Size = new System.Drawing.Size(590, 75);
            this.grpDataView.TabIndex = 1;
            this.grpDataView.TabStop = false;
            this.grpDataView.Text = "Bài 4: Lọc & Sắp xếp Trong Bộ Nhớ bằng DataView";
            // 
            // cboKhoaDataView
            // 
            this.cboKhoaDataView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaDataView.FormattingEnabled = true;
            this.cboKhoaDataView.Location = new System.Drawing.Point(60, 30);
            this.cboKhoaDataView.Name = "cboKhoaDataView";
            this.cboKhoaDataView.Size = new System.Drawing.Size(130, 23);
            this.cboKhoaDataView.TabIndex = 4;
            // 
            // lblKhoaDV
            // 
            this.lblKhoaDV.AutoSize = true;
            this.lblKhoaDV.Location = new System.Drawing.Point(15, 33);
            this.lblKhoaDV.Name = "lblKhoaDV";
            this.lblKhoaDV.Size = new System.Drawing.Size(37, 15);
            this.lblKhoaDV.TabIndex = 3;
            this.lblKhoaDV.Text = "Khoa:";
            // 
            // btnLocDataView
            // 
            this.btnLocDataView.Location = new System.Drawing.Point(400, 28);
            this.btnLocDataView.Name = "btnLocDataView";
            this.btnLocDataView.Size = new System.Drawing.Size(175, 30);
            this.btnLocDataView.TabIndex = 2;
            this.btnLocDataView.Text = "🔍 Lọc DataView (In-Memory)";
            this.btnLocDataView.UseVisualStyleBackColor = true;
            this.btnLocDataView.Click += new System.EventHandler(this.btnLocDataView_Click);
            // 
            // txtMinDiemDV
            // 
            this.txtMinDiemDV.Location = new System.Drawing.Point(310, 30);
            this.txtMinDiemDV.Name = "txtMinDiemDV";
            this.txtMinDiemDV.Size = new System.Drawing.Size(70, 23);
            this.txtMinDiemDV.TabIndex = 1;
            this.txtMinDiemDV.Text = "6.5";
            // 
            // lblMinDiemDV
            // 
            this.lblMinDiemDV.AutoSize = true;
            this.lblMinDiemDV.Location = new System.Drawing.Point(210, 33);
            this.lblMinDiemDV.Name = "lblMinDiemDV";
            this.lblMinDiemDV.Size = new System.Drawing.Size(89, 15);
            this.lblMinDiemDV.TabIndex = 0;
            this.lblMinDiemDV.Text = "Điểm Tối Thống:";
            // 
            // dgvDataView
            // 
            this.dgvDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataView.Location = new System.Drawing.Point(15, 98);
            this.dgvDataView.Name = "dgvDataView";
            this.dgvDataView.Size = new System.Drawing.Size(945, 380);
            this.dgvDataView.TabIndex = 0;
            // 
            // tabRowState
            // 
            this.tabRowState.Controls.Add(this.rtbLogState);
            this.tabRowState.Controls.Add(this.btnRejectChanges);
            this.tabRowState.Controls.Add(this.btnAcceptChanges);
            this.tabRowState.Controls.Add(this.btnTheoDoiRowState);
            this.tabRowState.Controls.Add(this.btnTaoTableThuCong);
            this.tabRowState.Controls.Add(this.dgvRowState);
            this.tabRowState.Location = new System.Drawing.Point(4, 24);
            this.tabRowState.Name = "tabRowState";
            this.tabRowState.Padding = new System.Windows.Forms.Padding(3);
            this.tabRowState.Size = new System.Drawing.Size(976, 492);
            this.tabRowState.TabIndex = 2;
            this.tabRowState.Text = "Bài 6-8: DataTable Thủ công, RowState & Accept/RejectChanges";
            this.tabRowState.UseVisualStyleBackColor = true;
            // 
            // rtbLogState
            // 
            this.rtbLogState.Location = new System.Drawing.Point(540, 52);
            this.rtbLogState.Name = "rtbLogState";
            this.rtbLogState.ReadOnly = true;
            this.rtbLogState.Size = new System.Drawing.Size(420, 425);
            this.rtbLogState.TabIndex = 5;
            this.rtbLogState.Text = "";
            // 
            // btnRejectChanges
            // 
            this.btnRejectChanges.Location = new System.Drawing.Point(740, 12);
            this.btnRejectChanges.Name = "btnRejectChanges";
            this.btnRejectChanges.Size = new System.Drawing.Size(220, 30);
            this.btnRejectChanges.TabIndex = 4;
            this.btnRejectChanges.Text = "8. RejectChanges (Hoàn Tác Cục Bộ)";
            this.btnRejectChanges.UseVisualStyleBackColor = true;
            this.btnRejectChanges.Click += new System.EventHandler(this.btnRejectChanges_Click);
            // 
            // btnAcceptChanges
            // 
            this.btnAcceptChanges.Location = new System.Drawing.Point(510, 12);
            this.btnAcceptChanges.Name = "btnAcceptChanges";
            this.btnAcceptChanges.Size = new System.Drawing.Size(220, 30);
            this.btnAcceptChanges.TabIndex = 3;
            this.btnAcceptChanges.Text = "8. AcceptChanges (Chấp Nhận Cục Bộ)";
            this.btnAcceptChanges.UseVisualStyleBackColor = true;
            this.btnAcceptChanges.Click += new System.EventHandler(this.btnAcceptChanges_Click);
            // 
            // btnTheoDoiRowState
            // 
            this.btnTheoDoiRowState.Location = new System.Drawing.Point(260, 12);
            this.btnTheoDoiRowState.Name = "btnTheoDoiRowState";
            this.btnTheoDoiRowState.Size = new System.Drawing.Size(240, 30);
            this.btnTheoDoiRowState.TabIndex = 2;
            this.btnTheoDoiRowState.Text = "7. Kiểm Tra RowState & GetChanges()";
            this.btnTheoDoiRowState.UseVisualStyleBackColor = true;
            this.btnTheoDoiRowState.Click += new System.EventHandler(this.btnTheoDoiRowState_Click);
            // 
            // btnTaoTableThuCong
            // 
            this.btnTaoTableThuCong.Location = new System.Drawing.Point(15, 12);
            this.btnTaoTableThuCong.Name = "btnTaoTableThuCong";
            this.btnTaoTableThuCong.Size = new System.Drawing.Size(235, 30);
            this.btnTaoTableThuCong.TabIndex = 1;
            this.btnTaoTableThuCong.Text = "6. Tạo Table Thủ Công + Cột XepLoai";
            this.btnTaoTableThuCong.UseVisualStyleBackColor = true;
            this.btnTaoTableThuCong.Click += new System.EventHandler(this.btnTaoTableThuCong_Click);
            // 
            // dgvRowState
            // 
            this.dgvRowState.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRowState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRowState.Location = new System.Drawing.Point(15, 52);
            this.dgvRowState.Name = "dgvRowState";
            this.dgvRowState.Size = new System.Drawing.Size(510, 425);
            this.dgvRowState.TabIndex = 0;
            // 
            // tabXmlMerge
            // 
            this.tabXmlMerge.Controls.Add(this.btnMergeData);
            this.tabXmlMerge.Controls.Add(this.btnDocXML);
            this.tabXmlMerge.Controls.Add(this.btnLuuXML);
            this.tabXmlMerge.Controls.Add(this.dgvXmlMerge);
            this.tabXmlMerge.Location = new System.Drawing.Point(4, 24);
            this.tabXmlMerge.Name = "tabXmlMerge";
            this.tabXmlMerge.Padding = new System.Windows.Forms.Padding(3);
            this.tabXmlMerge.Size = new System.Drawing.Size(976, 492);
            this.tabXmlMerge.TabIndex = 3;
            this.tabXmlMerge.Text = "Bài 9-10: Lưu/Đọc DataSet XML & Merge Data";
            this.tabXmlMerge.UseVisualStyleBackColor = true;
            // 
            // btnMergeData
            // 
            this.btnMergeData.Location = new System.Drawing.Point(465, 12);
            this.btnMergeData.Name = "btnMergeData";
            this.btnMergeData.Size = new System.Drawing.Size(220, 32);
            this.btnMergeData.TabIndex = 3;
            this.btnMergeData.Text = "10. Hợp Nhất Dữ Liệu (Merge Table)";
            this.btnMergeData.UseVisualStyleBackColor = true;
            this.btnMergeData.Click += new System.EventHandler(this.btnMergeData_Click);
            // 
            // btnDocXML
            // 
            this.btnDocXML.Location = new System.Drawing.Point(235, 12);
            this.btnDocXML.Name = "btnDocXML";
            this.btnDocXML.Size = new System.Drawing.Size(220, 32);
            this.btnDocXML.TabIndex = 2;
            this.btnDocXML.Text = "9. Đọc DataSet Từ XML (Offline)";
            this.btnDocXML.UseVisualStyleBackColor = true;
            this.btnDocXML.Click += new System.EventHandler(this.btnDocXML_Click);
            // 
            // btnLuuXML
            // 
            this.btnLuuXML.Location = new System.Drawing.Point(15, 12);
            this.btnLuuXML.Name = "btnLuuXML";
            this.btnLuuXML.Size = new System.Drawing.Size(210, 32);
            this.btnLuuXML.TabIndex = 1;
            this.btnLuuXML.Text = "9. Lưu DataSet Ra File XML Schema";
            this.btnLuuXML.UseVisualStyleBackColor = true;
            this.btnLuuXML.Click += new System.EventHandler(this.btnLuuXML_Click);
            // 
            // dgvXmlMerge
            // 
            this.dgvXmlMerge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXmlMerge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXmlMerge.Location = new System.Drawing.Point(15, 55);
            this.dgvXmlMerge.Name = "dgvXmlMerge";
            this.dgvXmlMerge.Size = new System.Drawing.Size(945, 425);
            this.dgvXmlMerge.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(232, 17);
            this.lblStatus.Text = "Trạng thái: Đã sẵn sàng thử nghiệm Lab 10.";
            // 
            // frmLab10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 551);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLab10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 10 - DataAdapter, DataTable, DataSet và Dữ liệu ngắt kết nối (Disconnected Model)";
            this.Load += new System.EventHandler(this.frmLab10_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabCoBan.ResumeLayout(false);
            this.tabCoBan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienCoBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaCoBan)).EndInit();
            this.tabDataViewUpdate.ResumeLayout(false);
            this.grpUpdateCommand.ResumeLayout(false);
            this.grpDataView.ResumeLayout(false);
            this.grpDataView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataView)).EndInit();
            this.tabRowState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRowState)).EndInit();
            this.tabXmlMerge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXmlMerge)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCoBan;
        private System.Windows.Forms.TabPage tabDataViewUpdate;
        private System.Windows.Forms.TabPage tabRowState;
        private System.Windows.Forms.TabPage tabXmlMerge;
        private System.Windows.Forms.Button btnFillDataTable;
        private System.Windows.Forms.Button btnFillDataSet;
        private System.Windows.Forms.Button btnXemRelation;
        private System.Windows.Forms.DataGridView dgvKhoaCoBan;
        private System.Windows.Forms.DataGridView dgvSinhVienCoBan;
        private System.Windows.Forms.Label lblTableKhoa;
        private System.Windows.Forms.Label lblTableSV;
        private System.Windows.Forms.ListBox lstChildRows;
        private System.Windows.Forms.Label lblChildRows;
        private System.Windows.Forms.GroupBox grpDataView;
        private System.Windows.Forms.ComboBox cboKhoaDataView;
        private System.Windows.Forms.Label lblKhoaDV;
        private System.Windows.Forms.TextBox txtMinDiemDV;
        private System.Windows.Forms.Label lblMinDiemDV;
        private System.Windows.Forms.Button btnLocDataView;
        private System.Windows.Forms.DataGridView dgvDataView;
        private System.Windows.Forms.GroupBox grpUpdateCommand;
        private System.Windows.Forms.Button btnLoadForUpdate;
        private System.Windows.Forms.Button btnLuuChanges;
        private System.Windows.Forms.DataGridView dgvRowState;
        private System.Windows.Forms.Button btnTaoTableThuCong;
        private System.Windows.Forms.Button btnTheoDoiRowState;
        private System.Windows.Forms.Button btnAcceptChanges;
        private System.Windows.Forms.Button btnRejectChanges;
        private System.Windows.Forms.RichTextBox rtbLogState;
        private System.Windows.Forms.DataGridView dgvXmlMerge;
        private System.Windows.Forms.Button btnLuuXML;
        private System.Windows.Forms.Button btnDocXML;
        private System.Windows.Forms.Button btnMergeData;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}