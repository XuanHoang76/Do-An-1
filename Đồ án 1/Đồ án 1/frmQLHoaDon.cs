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
    public partial class frmQLHoaDon : Form
    {
        bool Them;
        string err;
        BLQLHoaDon dbHD = new BLQLHoaDon();
        BLQLKhachHang dbKH = new BLQLKhachHang();
        BLQLXe dbX = new BLQLXe();
        void LoadData()
        {
            try
            {
                dgvHD.DataSource = dbHD.LayHD();
                this.txtMaKH.ResetText();
                this.txtTenKH.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDienThoai.ResetText();
                this.txtBienSo.ResetText();
                this.cmbLX.ResetText();
                this.mskNgayGui.ResetText();
                this.cmbHinhThuc.ResetText();
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
        public frmQLHoaDon()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvHD.AllowUserToAddRows = false;
            dgvHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Chuc nang them du lieu
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtBienSo.ResetText();
            this.cmbLX.ResetText();
            this.mskNgayGui.ResetText();
            this.cmbHinhThuc.ResetText();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (Them)
            {
                try
                {
                    if (this.txtTongTien.Text.Length == 0)
                    {
                        if (this.cmbHinhThuc.Text == "Tạm Thời")
                        {
                            if (this.cmbLX.Text == "Xe Đạp")
                            {
                                this.txtTongTien.Text = "3000 Đồng";
                            }
                            else if(this.cmbLX.Text == "Xe Máy")
                            {
                                this.txtTongTien.Text = "5000 Đồng";
                            }
                            else
                            {
                                this.txtTongTien.Text = "20000 Đồng";
                            }
                        }
                        else
                        {
                            if (this.cmbLX.Text == "Xe Đạp")
                            {
                                this.txtTongTien.Text = "80000 Đồng";
                            }
                            else if (this.cmbLX.Text == "Xe Máy")
                            {
                                this.txtTongTien.Text = "100000 Đồng";
                            }
                            else
                            {
                                this.txtTongTien.Text = "500000 Đồng";
                            }
                        }
                    }
                    BLQLHoaDon blHD = new BLQLHoaDon();
                    blHD.ThemHD(this.txtMaKH.Text, this.txtTenKH.Text, this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtBienSo.Text, this.cmbLX.Text, this.mskNgayGui.Text, this.cmbHinhThuc.Text, this.txtTongTien.Text, ref err);
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
                    int r = dgvHD.CurrentCell.RowIndex;
                    string strHD = dgvHD.Rows[r].Cells[0].Value.ToString();
                    BLQLHoaDon blHD = new BLQLHoaDon();
                    blHD.CapNhatHD(this.txtMaKH.Text, this.txtTenKH.Text, this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtBienSo.Text, this.cmbLX.Text, this.mskNgayGui.Text, this.cmbHinhThuc.Text, this.txtTongTien.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã lưu xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không lưu được!");
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.txtBienSo.ResetText();
            this.cmbLX.ResetText();
            this.mskNgayGui.ResetText();
            this.cmbHinhThuc.ResetText();
            //
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            //
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            dgvHD_CellClick(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvHD.CurrentCell.RowIndex;
                string strHD = dgvHD.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Có chắc xóa dữ liệu này không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbHD.XoaHD(ref err, strHD);
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
                MessageBox.Show("Không xóa được.");
            }
        }

        //Chuc nang tat Form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dbHD.TimHD(this.txtMaKH.Text, dgvHD);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHD.CurrentCell.RowIndex;
            this.txtMaKH.Text = dgvHD.Rows[r].Cells[0].Value.ToString();
            this.txtTenKH.Text = dgvHD.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text = dgvHD.Rows[r].Cells[2].Value.ToString();
            this.txtDienThoai.Text = dgvHD.Rows[r].Cells[3].Value.ToString();
            this.txtBienSo.Text = dgvHD.Rows[r].Cells[4].Value.ToString();
            this.cmbLX.Text = dgvHD.Rows[r].Cells[5].Value.ToString();
            this.mskNgayGui.Text = dgvHD.Rows[r].Cells[6].Value.ToString();
            this.cmbHinhThuc.Text = dgvHD.Rows[r].Cells[7].Value.ToString();
            this.txtTongTien.Text = dgvHD.Rows[r].Cells[8].Value.ToString();
        }

        private void btnLHD_Click(object sender, EventArgs e)
        {
            frmHoaDon qlhd = new frmHoaDon(this.txtMaKH.Text);
            qlhd.Show();
        }
    }
}
