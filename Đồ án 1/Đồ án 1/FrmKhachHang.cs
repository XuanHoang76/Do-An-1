using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Đồ_án_1.BS_Layer;

namespace Đồ_án_1
{
    public partial class FrmKhachHang : Form
    {
        bool Them;
        string err;
        BLQLKhachHang dbKH = new BLQLKhachHang();

        //Ham tai du lieu
        void LoadData()
        {
            try
            {
                dgvKH.DataSource = dbKH.LayKH();
                this.txtMaKH.ResetText();
                this.txtTenKH.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDienThoai.ResetText();
                //
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu!!!");
            }
        }

        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvKH.AllowUserToAddRows = false;
            dgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Chuc nang them du lieu
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            //
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            this.txtMaKH.Focus();
        }
        
        //Chuc nang sua du lieu
        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            this.txtMaKH.Focus();
            this.txtTenKH.Focus();
            this.txtDiaChi.Focus();
            this.txtDienThoai.Focus();
        }

        //Chuc nang tat Form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) this.Close();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKH.CurrentCell.RowIndex;
            this.txtMaKH.Text = dgvKH.Rows[r].Cells[0].Value.ToString();
            this.txtTenKH.Text = dgvKH.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text = dgvKH.Rows[r].Cells[2].Value.ToString();
            this.txtDienThoai.Text = dgvKH.Rows[r].Cells[3].Value.ToString();
        }

        //Chuc nang huy thao tac dang lam
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            //
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            //
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            dgvKH_CellClick(null, null);
        }

        //Chuc nang Luu du lieu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLQLKhachHang blKH = new BLQLKhachHang();
                    blKH.ThemKH(this.txtMaKH.Text, this.txtTenKH.Text, this.txtDiaChi.Text, this.txtDienThoai.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được!");
                }
            }
            else
            {
                try
                {
                    int r = dgvKH.CurrentCell.RowIndex;
                    string strKH = dgvKH.Rows[r].Cells[0].Value.ToString();
                    BLQLKhachHang blKH = new BLQLKhachHang();
                    blKH.CapNhatKH(this.txtMaKH.Text, this.txtTenKH.Text, this.txtDiaChi.Text, this.txtDienThoai.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được!");
                }
            }
        }

        //Chuc nang xoa du lieu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvKH.CurrentCell.RowIndex;
                string strKH = dgvKH.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Có chắc xóa dữ liệu này không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbKH.XoaKH(ref err, strKH);
                    LoadData();
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        //Chuc nang tim du lieu
        private void btnTim_Click(object sender, EventArgs e)
        {
            dbKH.TimKH(this.txtMaKH.Text, dgvKH);
        }
    }
}
