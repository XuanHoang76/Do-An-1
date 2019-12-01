using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace Đồ_án_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chkbHMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbHMK.Checked == true)
            {
                txtMK.UseSystemPasswordChar = false;
            }
            else
                txtMK.UseSystemPasswordChar = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao;
            ThongBao = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBao == DialogResult.OK) this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            var user = (from Account in qlNX.Accounts
                        where txtTK.Text == Account.TK && txtMK.Text == Account.Pass && cmbQuyen.Text == Account.quyen
                        select Account).SingleOrDefault();
            if (user != null && cmbQuyen.Text == "Admin")
            {
                quảnLýNhânViênToolStripMenuItem.Enabled = true;
                quảnLýXeToolStripMenuItem.Enabled = true;
                quảnLýHóaĐơnToolStripMenuItem.Enabled = true;
                quảnLýKháchHàngToolStripMenuItem.Enabled = true;
                MessageBox.Show("Đăng nhập thành công", "Thông Báo");
            }
            else if (user != null && cmbQuyen.Text == "Nhân Viên")
            {
                quảnLýNhânViênToolStripMenuItem.Enabled = false;
                quảnLýXeToolStripMenuItem.Enabled = true;
                quảnLýHóaĐơnToolStripMenuItem.Enabled = true;
                quảnLýKháchHàngToolStripMenuItem.Enabled = true;
                MessageBox.Show("Đăng nhập thành công", "Thông Báo");
            }
            else
            {
                quảnLýNhânViênToolStripMenuItem.Enabled = false;
                quảnLýXeToolStripMenuItem.Enabled = false;
                quảnLýHóaĐơnToolStripMenuItem.Enabled = false;
                quảnLýKháchHàngToolStripMenuItem.Enabled = false;
                MessageBox.Show("Đăng nhập không thành công", "Thông Báo");
            }

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhanVien qlnv = new FrmNhanVien();
            qlnv.Show();
        }

        private void quảnLýXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQLXe qLx = new FrmQLXe();
            qLx.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKhachHang qlkh = new FrmKhachHang();
            qlkh.Show();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLHoaDon qlhd = new frmQLHoaDon();
            qlhd.Show();
        }
    }
}
