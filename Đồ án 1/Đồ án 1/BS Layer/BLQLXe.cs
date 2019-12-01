using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_1.BS_Layer
{
    class BLQLXe
    {
        //Lay du lieu tu bang QLXe
        public System.Data.Linq.Table<QLXe> LayXe()
        {
            DataSet ds = new DataSet();
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            return qlNX.QLXes;
        }

        //Them du lieu xe tu bang du lieu QLXe
        public bool ThemXe(string Bienso, string LoaiXe, string NgayGui, string HinhThucGui, string MaKH,ref string err)
        {
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            QLXe xe = new QLXe();
            xe.Bienso = Bienso;
            xe.LoaiXe = LoaiXe;
            xe.NgayGui = NgayGui;
            xe.HinhThucGui = HinhThucGui;
            xe.MaKH = MaKH;
            qlNX.QLXes.InsertOnSubmit(xe);
            qlNX.QLXes.Context.SubmitChanges();
            return true;
        }

        //Xoa du lieu xe tu bang du lieu QLXe
        public bool XoaXe(ref string err, string BienSo)
        {
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            var xeQuery = from xe in qlNX.QLXes
                          where xe.Bienso == BienSo
                          select xe;
            qlNX.QLXes.DeleteAllOnSubmit(xeQuery);
            qlNX.SubmitChanges();
            return true;
        }

        //Cap nhat du lieu xe tu bang du lieu QLXe
        public bool CapNhatXe(string Bienso, string LoaiXe, string NgayGui, string HinhThucGui, string MaKH,ref string err)
        {
            try
            {
                QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
                var xeQuery = (from xe in qlNX.QLXes
                               where xe.Bienso == Bienso
                               select xe).SingleOrDefault();
                if (xeQuery != null)
                {
                    xeQuery.Bienso = Bienso;
                    xeQuery.LoaiXe = LoaiXe;
                    xeQuery.NgayGui = NgayGui;
                    xeQuery.HinhThucGui = HinhThucGui;
                    xeQuery.NgayGui = NgayGui;
                    xeQuery.MaKH = MaKH;
                }
                return true;
            }
            catch (ExecutionEngineException e)
            {
                MessageBox.Show("e");
                return false;
            }
        }

        //Tim du lieu nhan vien
        public void TimXe(string BienSo, DataGridView dgv)
        {
            DataSet ds = new DataSet();
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            var xeQuery = (from xe in qlNX.QLXes
                           where xe.Bienso == BienSo
                           select xe).ToList();
            dgv.DataSource = xeQuery;
        }
    }
}
