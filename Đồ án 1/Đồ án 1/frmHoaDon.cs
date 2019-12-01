using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Đồ_án_1.BS_Layer;
namespace Đồ_án_1
{
    public partial class frmHoaDon : Form
    {
        BLQLHoaDon dbHD = new BLQLHoaDon();
        private string MaKH;
        public frmHoaDon(string MaKH)
        {
            InitializeComponent();
            this.MaKH = MaKH;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLXeDataSet.QLHoaDon' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'QLXeDataSet1.QLKhachHang' table. You can move, or remove it, as needed.
            //// TODO: This line of code loads data into the 'QLXeDataSet.QLHoaDon' table. You can move, or remove it, as needed.
            //// TODO: This line of code loads data into the 'QLXeDataSet1.QLKhachHang' table. You can move, or remove it, as needed.
            ReportDataSource datasource = new ReportDataSource("HoaDon", dbHD.LayHD());
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);

            this.reportViewer1.RefreshReport();
        }
    }
}
