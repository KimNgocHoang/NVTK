using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace QuanLyChungCu.BLL
{
    class BLL_TaiKhoan
    {
        qlchungcuEntities db = new qlchungcuEntities();
        
        public bool Add_TK(taikhoan tk)
        {
            try
            {
                var query = db.taikhoans.Where(p => p.tendangnhap == tk.tendangnhap).Count();
                if (query == 0)
                {
                    db.taikhoans.Add(tk);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public bool Edit_TK(taikhoan tk)
        {
            try
            {
                var l = (from p in db.taikhoans
                         where p.tendangnhap == tk.tendangnhap
                         select p).SingleOrDefault();
                l.tendangnhap = tk.tendangnhap;
                l.matkhau = tk.matkhau;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void Delete_TK(int manv)
        {
            var tk = db.taikhoans.Where(p => p.manhanvien == manv).SingleOrDefault();
            db.taikhoans.Remove(tk);
            db.SaveChanges();
        }
        
    }
}
