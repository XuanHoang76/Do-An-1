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
    public partial class FrmQLXe : Form
    {
        bool Them;
        string err;
        BLQLXe dbX = new BLQLXe();

        //Ham tai du lieu
        void LoadData()
        {
            try
            {
                dgvXE.DataSource = dbX.LayXe();
                this.txtBienSo.ResetText();
                this.cmbLX.ResetText();
                this.mskNgayGui.ResetText();
                this.cmbHinhThuc.ResetText();
                this.txtMaKH.ResetText();
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
        public FrmQLXe()
        {
            InitializeComponent();
        }

        private void FrmQLXe_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvXE.AllowUserToAddRows = false;
            dgvXE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        //Chuc nang tim du lieu
        private void btnTim_Click(object sender, EventArgs e)
        {
            dbX.TimXe(this.txtBienSo.Text, dgvXE);
        }


        private void dgvXE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvXE.CurrentCell.RowIndex;
            this.txtBienSo.Text = dgvXE.Rows[r].Cells[0].Value.ToString();
            this.cmbLX.Text = dgvXE.Rows[r].Cells[1].Value.ToString();
            this.mskNgayGui.Text = dgvXE.Rows[r].Cells[2].Value.ToString();
            this.cmbHinhThuc.Text = dgvXE.Rows[r].Cells[3].Value.ToString();
            this.txtMaKH.Text = dgvXE.Rows[r].Cells[4].Value.ToString();
        }

        //Chuc nang them du lieu
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtBienSo.ResetText();
            this.cmbLX.ResetText();
            this.mskNgayGui.ResetText();
            this.cmbHinhThuc.ResetText();
            this.txtMaKH.ResetText();
            //
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            //
            this.btnHuyBo.Enabled = true;
            this.btnLuu.Enabled = true;
            this.txtBienSo.Focus();
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
            //
            this.txtBienSo.ResetText();
            this.cmbLX.ResetText();
            this.mskNgayGui.ResetText();
            this.cmbHinhThuc.ResetText();
            this.txtMaKH.ResetText();
        }

        //Chuc nang tat Form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) this.Close();
        }

        //Chuc nang Luu du lieu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLQLXe blX = new BLQLXe();
                    blX.ThemXe(this.txtBienSo.Text, this.cmbLX.Text, this.mskNgayGui.Text, this.cmbHinhThuc.Text, this.txtMaKH.Text, ref err);
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
                    int r = dgvXE.CurrentCell.RowIndex;
                    string strXE = dgvXE.Rows[r].Cells[0].Value.ToString();
                    BLQLXe blX = new BLQLXe();
                    blX.CapNhatXe(this.txtBienSo.Text, this.cmbLX.Text, this.mskNgayGui.Text, this.cmbHinhThuc.Text, this.txtMaKH.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được!");
                }
            }
        }

        //Chuc nang huy thao tac dang lam
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.txtBienSo.ResetText();
            this.cmbLX.ResetText();
            this.mskNgayGui.ResetText();
            this.cmbHinhThuc.ResetText();
            this.txtMaKH.ResetText();
            //
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            //
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            dgvXE_CellClick(null, null);
        }

        //Chuc nang xoa du lieu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvXE.CurrentCell.RowIndex;
                string strXE = dgvXE.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Có chắc xóa dữ liệu này không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbX.XoaXe(ref err, strXE);
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

        //Chuc nang cap nhat lai du lieu trong form
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTenNG_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
