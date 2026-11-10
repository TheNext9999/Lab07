using System;
using System.Windows.Forms;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        // Bài 9: Mở Form Báo Cáo Singleton tránh mở trùng
        public void OpenReportForm()
        {
            foreach (Form child in MdiChildren)
            {
                if (child is frmBaoCaoSinhVien)
                {
                    child.Activate();
                    return;
                }
            }

            frmBaoCaoSinhVien frm = new frmBaoCaoSinhVien();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}