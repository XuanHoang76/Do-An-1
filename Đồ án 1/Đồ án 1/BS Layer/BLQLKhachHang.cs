using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_1.BS_Layer
{
    class BLQLKhachHang
    {
        //Lay du lieu tu bang QLKhachHang
        public System.Data.Linq.Table<QLKhachHang> LayKH()
        {
            DataSet ds = new DataSet();
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            return qlNX.QLKhachHangs;
        }

        //Them du lieu khach hang tu bang du lieu QLKhachHang
        public bool ThemKH(string MaKH, string TenKhachHang, string DiaChi, string DienThoai, ref string err)
        {
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            QLKhachHang kh = new QLKhachHang();
            kh.MaKH = MaKH;
            kh.HoTen = TenKhachHang;
            kh.DiaChi = DiaChi;
            kh.SoDienThoai = DienThoai;
            qlNX.QLKhachHangs.InsertOnSubmit(kh);
            qlNX.QLKhachHangs.Context.SubmitChanges();
            return true;
        }

        //Xoa du lieu khach hang tu bang du lieu QLKhachHang
        public bool XoaKH(ref string err, string MaKH)
        {
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            var khQuery = from kh in qlNX.QLKhachHangs
                          where kh.MaKH == MaKH
                          select kh;
            qlNX.QLKhachHangs.DeleteAllOnSubmit(khQuery);
            qlNX.SubmitChanges();
            return true;
        }

        //Cap nhat du lieu khach hang tu bang du lieu QLKhachHang
        public bool CapNhatKH(string MaKH, string TenKhachHang, string DiaChi, string DienThoai, ref string err)
        {
            try
            {
                QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
                var khQuery = (from kh in qlNX.QLKhachHangs
                               where kh.MaKH == MaKH
                               select kh).SingleOrDefault();
                if (khQuery != null)
                {
                    khQuery.MaKH = MaKH;
                    khQuery.HoTen = TenKhachHang;
                    khQuery.DiaChi = DiaChi;
                    khQuery.SoDienThoai = DienThoai;
                }
                return true;
            }
            catch (ExecutionEngineException e)
            {
                MessageBox.Show("e");
                return false;
            }
        }

        //Tim du lieu khach hang
        public void TimKH(string MaKH, DataGridView dgv)
        {
            DataSet ds = new DataSet();
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            var khQuery = (from kh in qlNX.QLKhachHangs
                           where kh.MaKH == MaKH
                           select kh).ToList();
            dgv.DataSource = khQuery;
        }
    }
}
