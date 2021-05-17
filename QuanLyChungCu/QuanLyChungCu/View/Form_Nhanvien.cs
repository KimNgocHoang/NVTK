using QuanLyChungCu.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChungCu.View
{
    public partial class Form_Nhanvien : Form
    {
        qlchungcuEntities db = new qlchungcuEntities();
        BLL_Nhanvien nv_BLL = new BLL_Nhanvien();
        BLL_TaiKhoan tk_BLL = new BLL_TaiKhoan();
        
        public Form_Nhanvien()
        {
            InitializeComponent();
            SetCBB();
        }
        public void SetCBB()
        {
            foreach (chucvu i in db.chucvus)
            {
                cbxChucvu.Items.Add(new CBBItem
                {
                    Value = i.machucvu,
                    Text = i.tenchucvu
                });
            }
        }
        private void Form_Nhanvien_Load(object sender, EventArgs e)
        {
            DSNV();
        }
        void DSNV()
        {
            dgvDanhSachNhanVien.DataSource = nv_BLL.LayDSNV(); 
        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            DSNV();
        }

        //private void btnDong_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        private void dgvDanhSachNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            txtMaNhanVien.Text = dgvDanhSachNhanVien.Rows[dong].Cells[0].Value.ToString();
            txtHoTen.Text = dgvDanhSachNhanVien.Rows[dong].Cells[1].Value.ToString();
            if (dgvDanhSachNhanVien.Rows[dong].Cells[2].Value.ToString() == "Nữ")
                rdbtnNu.Checked = true;
            else if (dgvDanhSachNhanVien.Rows[dong].Cells[2].Value.ToString() == "Nam")
                rdbtnNam.Checked = true;
            txtSoDienThoai.Text = dgvDanhSachNhanVien.Rows[dong].Cells[3].Value.ToString();
            dtpNgaySinh.Text = dgvDanhSachNhanVien.Rows[dong].Cells[4].Value.ToString();
            txtSoCMND.Text = dgvDanhSachNhanVien.Rows[dong].Cells[5].Value.ToString();
            cbxChucvu.Text = dgvDanhSachNhanVien.Rows[dong].Cells[6].Value.ToString();
            txtTenDangNhap.Text = dgvDanhSachNhanVien.Rows[dong].Cells[7].Value.ToString();
            txtMatKhau.Text = dgvDanhSachNhanVien.Rows[dong].Cells[8].Value.ToString();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            nhanvien nv = new nhanvien();
            taikhoan tk = new taikhoan();
            nv.manhanvien = Convert.ToInt32(txtMaNhanVien.Text);
            nv.tennhanvien = txtHoTen.Text;
            if(rdbtnNam.Checked == true)
            nv.gioitinh = "Nam";
            if (rdbtnNu.Checked == true)
                nv.gioitinh = "Nữ";
            nv.sdt = txtSoDienThoai.Text;
            nv.cmnd = txtSoCMND.Text;
            nv.ngaysinh = dtpNgaySinh.Value;
            nv.machucvu = ((CBBItem)cbxChucvu.SelectedItem).Value;
            tk.manhanvien = Convert.ToInt32(txtMaNhanVien.Text);
            tk.tendangnhap = txtTenDangNhap.Text;
            tk.matkhau = txtMatKhau.Text;

            if (nv_BLL.Add_NV(nv)==true && tk_BLL.Add_TK(tk) == true)
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DSNV();
            }
            else
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachNhanVien.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgvDanhSachNhanVien.SelectedRows.Count; i++)
                {
                    tk_BLL.Delete_TK(Convert.ToInt32(dgvDanhSachNhanVien.SelectedRows[i].Cells["manhanvien"].Value));
                    nv_BLL.Delete_NV(Convert.ToInt32(dgvDanhSachNhanVien.SelectedRows[i].Cells["manhanvien"].Value));
                    
                }
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DSNV();
            }
            else
                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            nhanvien nv = new nhanvien();
            taikhoan tk = new taikhoan();
            nv.manhanvien = Convert.ToInt32(txtMaNhanVien.Text);
            nv.tennhanvien = txtHoTen.Text;
            if (rdbtnNam.Checked == true)
                nv.gioitinh = "Nam";
            if (rdbtnNu.Checked == true)
                nv.gioitinh = "Nữ";
            nv.sdt = txtSoDienThoai.Text;
            nv.cmnd = txtSoCMND.Text;
            nv.ngaysinh = dtpNgaySinh.Value;
            nv.machucvu = ((CBBItem)cbxChucvu.SelectedItem).Value;
            tk.tendangnhap = txtTenDangNhap.Text;
            tk.matkhau = txtMatKhau.Text;
            
            if (nv_BLL.Edit_NV(nv) == true && tk_BLL.Edit_TK (tk) == true)
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DSNV();
            }
            else
                MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhSachNhanVien.DataSource = nv_BLL.GetListNVByTen(txbSearch.Text);
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txtMaNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtSoCMND.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            cbxChucvu.Text = "";
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSachNhanVien.DataSource = nv_BLL.GetListNVByTen(txbSearch.Text);
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }
    }
}
