using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_1.BS_Layer
{
    class BLQLNhanVien
    {
        //Lay du lieu tu bang QLNhanVien
        public System.Data.Linq.Table<QLNhanVien> LayNV()
        {
            DataSet ds = new DataSet();
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            return qlNX.QLNhanViens;
        }

        //Them du lieu nhan vien tu bang du lieu QLNhanVien
        public bool ThemNV(string MaNV, string HoTen, string NgaySinh, string GioiTinh, string DiaChi, ref string err)
        {
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            QLNhanVien nv = new QLNhanVien();
            nv.MaNV = MaNV;
            nv.HoTen = HoTen;
            nv.NgaySinh = NgaySinh;
            nv.GioiTinh = GioiTinh;
            nv.DiaChi = DiaChi;
            qlNX.QLNhanViens.InsertOnSubmit(nv);
            qlNX.QLNhanViens.Context.SubmitChanges();
            return true;
        }

        //Xoa du lieu nhan vien tu bang du lieu QLNhanVien
        public bool XoaNhanVien(ref string err, string MaNV)
        {
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            var nvQuery = from nv in qlNX.QLNhanViens
                          where nv.MaNV == MaNV
                          select nv;
            qlNX.QLNhanViens.DeleteAllOnSubmit(nvQuery);
            qlNX.SubmitChanges();
            return true;
        }
        
        //Cap Nhat du lieu nhan vien tu bang du lieu QLNhanVien
        public bool CapNhatNhanVien(string MaNV, string HoTen, string NgaySinh, string GioiTinh, string DiaChi, ref string err)
        {
            try
            {
                QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
                var nvQuery = (from nv in qlNX.QLNhanViens
                               where nv.MaNV == nv.MaNV
                               select nv).SingleOrDefault();
                if (nvQuery != null)
                {
                    nvQuery.MaNV = MaNV;
                    nvQuery.HoTen = HoTen;
                    nvQuery.NgaySinh = NgaySinh;
                    nvQuery.GioiTinh = GioiTinh;
                    nvQuery.DiaChi = DiaChi;
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
        public void TimNV(string MaNV, DataGridView dgv)
        {
            DataSet ds = new DataSet();
            QLNhaXeDataContext qlNX = new QLNhaXeDataContext();
            var nvQuery = (from nv in qlNX.QLNhanViens
                           where nv.MaNV == MaNV
                           select nv).ToList();
            dgv.DataSource = nvQuery;
        }
    }
}

