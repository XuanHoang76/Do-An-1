using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_1.BS_Layer
{
    class BLQLHoaDon
    {
        //Lay du lieu tu bang QLHoaDon
        public System.Data.Linq.Table<QLHoaDon> LayHD()
        {
            DataSet ds = new DataSet();
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            return qlNX.QLHoaDons;
        }

        //Them du lieu hoa don tu bang du lieu QLHoaDon
        public bool ThemHD(string MaKH, string TenKhachHang, string DiaChi, string DienThoai, string BienSo, string LoaiXe, string NgayGui, string HinhThucGui, string ThanhTien, ref string err)
        {
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            QLHoaDon hd = new QLHoaDon();
            hd.MaKH = MaKH;
            hd.TenKhachHang = TenKhachHang;
            hd.DiaChi = DiaChi;
            hd.DienThoai = DienThoai;
            hd.BienSo = BienSo;
            hd.LoaiXe = LoaiXe;
            hd.NgayGui = NgayGui;
            hd.HinhThucGui = HinhThucGui;
            hd.NgayGui = NgayGui;
            hd.ThanhTien = ThanhTien;
            qlNX.QLHoaDons.InsertOnSubmit(hd);
            qlNX.QLHoaDons.Context.SubmitChanges();
            return true;
        }

        //Xoa du lieu hoa don tu bang du lieu QLHoaDon
        public bool XoaHD(ref string err, string BienSo)
        {
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            var hdQuery = from hd in qlNX.QLHoaDons
                          where hd.BienSo == BienSo
                          select hd;
            qlNX.QLHoaDons.DeleteAllOnSubmit(hdQuery);
            qlNX.SubmitChanges();
            return true;
        }

        //Cap nhat du lieu hoa don tu bang du lieu QLHoaDon
        public bool CapNhatHD(string MaKH, string TenKhachHang, string DiaChi, string DienThoai, string BienSo, string LoaiXe, string NgayGui, string HinhThucGui, string ThanhTien, ref string err)
        {
            try
            {
                QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
                var hdQuery = (from hd in qlNX.QLHoaDons
                               where hd.BienSo == BienSo
                               select hd).SingleOrDefault();
                if (hdQuery != null)
                {
                    hdQuery.MaKH = MaKH;
                    hdQuery.TenKhachHang = TenKhachHang;
                    hdQuery.DiaChi = DiaChi;
                    hdQuery.DienThoai = DienThoai;
                    hdQuery.BienSo = BienSo;
                    hdQuery.LoaiXe = LoaiXe;
                    hdQuery.NgayGui = NgayGui;
                    hdQuery.HinhThucGui = HinhThucGui;
                    hdQuery.ThanhTien = ThanhTien;
                }
                return true;
            }
            catch (ExecutionEngineException e)
            {
                MessageBox.Show("e");
                return false;
            }
        }

        //Tim du lieu hoa don
        public void TimHD(string MaKH, DataGridView dgv)
        {
            DataSet ds = new DataSet();
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            var hdQuery = (from hd in qlNX.QLHoaDons
                           where hd.MaKH == MaKH
                           select hd).ToList();
            dgv.DataSource = hdQuery;
        }

        
    }
}
