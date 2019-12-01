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
using Đồ_án_1.BS_Layer;
using System.Data.SqlClient;

namespace Đồ_án_1
{
    public partial class FrmNhanVien : Form
    {
        bool Them;
        string err;
        BLQLNhanVien dbNV = new BLQLNhanVien();

        //Ham tai du lieu
        void LoadData()
        {
            try
            {
                dgvNHANVIEN.DataSource = dbNV.LayNV();
                this.txtMaNV.ResetText();
                this.txtHoTen.ResetText();
                this.txtDiaChi.ResetText();
                this.cmbGioiTinh.ResetText();
                this.mskNgaySinh.ResetText();
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
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvNHANVIEN.AllowUserToAddRows = false;
            dgvNHANVIEN.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Chuc nang them du lieu
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.txtDiaChi.ResetText();
            this.cmbGioiTinh.ResetText();
            this.mskNgaySinh.ResetText();
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            //
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            this.txtMaNV.Focus();
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
            this.txtMaNV.Focus();
            this.txtHoTen.Focus();
            this.txtDiaChi.Focus();
            this.mskNgaySinh.Focus();
        }

        //Chuc nang tat Form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) this.Close();
        }

        private void dgvNHANVIEN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNHANVIEN.CurrentCell.RowIndex;
            this.txtMaNV.Text = dgvNHANVIEN.Rows[r].Cells[0].Value.ToString();
            this.txtHoTen.Text = dgvNHANVIEN.Rows[r].Cells[1].Value.ToString();
            this.mskNgaySinh.Text = dgvNHANVIEN.Rows[r].Cells[2].Value.ToString();
            this.cmbGioiTinh.Text = dgvNHANVIEN.Rows[r].Cells[3].Value.ToString();
            this.txtDiaChi.Text = dgvNHANVIEN.Rows[r].Cells[4].Value.ToString();
        }

        //Chuc nang huy thao tac dang lam
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.txtDiaChi.ResetText();
            this.cmbGioiTinh.ResetText();
            this.mskNgaySinh.ResetText();
            //
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            //
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            dgvNHANVIEN_CellClick(null, null);
        }

        //Chuc nang Luu du lieu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLQLNhanVien blNV = new BLQLNhanVien();
                    blNV.ThemNV(this.txtMaNV.Text, this.txtHoTen.Text, this.mskNgaySinh.Text, this.cmbGioiTinh.Text, this.txtDiaChi.Text, ref err);
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
                    int r = dgvNHANVIEN.CurrentCell.RowIndex;
                    string strSINHVIEN = dgvNHANVIEN.Rows[r].Cells[0].Value.ToString();
                    BLQLNhanVien blNV = new BLQLNhanVien();
                    blNV.CapNhatNhanVien(strSINHVIEN, this.txtHoTen.Text, this.mskNgaySinh.Text, this.cmbGioiTinh.Text, this.txtDiaChi.Text, ref err);
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
                int r = dgvNHANVIEN.CurrentCell.RowIndex;
                string strNHANVIEN = dgvNHANVIEN.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Có chắc xóa dữ liệu này không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbNV.XoaNhanVien(ref err, strNHANVIEN);
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
            dbNV.TimNV(this.txtMaNV.Text, dgvNHANVIEN);
        }
    }
}
