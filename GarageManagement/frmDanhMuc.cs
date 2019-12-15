using GarageManagement_DAL;
using GarageManagement_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagement
{
    public partial class frmDanhMuc : Form
    {
        BindingSource khachhangList = new BindingSource();
        public frmDanhMuc()
        {
            InitializeComponent();
            LoadMethod();
        }

        #region method
        void LoadMethod()
        {
            dgvKhachHang.DataSource = khachhangList;
            LoadListKhachHang();
            AddBindingKhachHang();
        }
        void LoadListKhachHang()
        {
            khachhangList.DataSource = KhachHangDAL.Instance.GetListKhachHang();
        }
        List<KhachHangDTO> SearchKhachHang(string text)
        {
            List<KhachHangDTO> list = KhachHangDAL.Instance.SearchKhachHangByNameAndID(text);
            return list;
        }

        void AddBindingKhachHang()
        {
            txtIDKhachHang.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtTenKhachHang.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "customername", true, DataSourceUpdateMode.Never));
            txtSoXe.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "carnumber", true, DataSourceUpdateMode.Never));
            txtHieuXe.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "carbrand", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "Address", true, DataSourceUpdateMode.Never));
            txtDienThoai.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "PHONE", true, DataSourceUpdateMode.Never));
            dtpNgayGui.DataBindings.Add(new Binding("Value", dgvKhachHang.DataSource, "CREATEDDATE", true, DataSourceUpdateMode.Never));
            txtTienNo.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "DEBT", true, DataSourceUpdateMode.Never));           
        }
        #endregion
        
        #region events
        private void btnXemKhachHang_Click(object sender, EventArgs e)
        {
            LoadListKhachHang();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDKhachHang.Text);
            string carnumber = txtSoXe.Text;
            string name = txtTenKhachHang.Text;
            string HieuXe = txtHieuXe.Text;
            string DiaChi = txtDiaChi.Text;
            int DienThoai = Convert.ToInt32(txtDienThoai.Text);
            DateTime Ngaygui = dtpNgayGui.Value;
            float Tienno = (float)Convert.ToDouble(txtTienNo.Text);           
            if (KhachHangDAL.Instance.InsertKhachHang(id, carnumber ,name, HieuXe, DiaChi, DienThoai, Ngaygui, Tienno))
            {
                MessageBox.Show("Thêm Khách Hàng thành công");
                LoadListKhachHang();
            }
            else
            {
                MessageBox.Show("Thêm Khách Hàng lỗi !!");
            }
        }
        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDKhachHang.Text);
            string carnumber = txtSoXe.Text;
            if (KhachHangDAL.Instance.DeleteKhachHang(id, carnumber))
            {
                MessageBox.Show("Xóa Khách Hàng thành công");
                LoadListKhachHang();
            }
            else
            {
                MessageBox.Show("Xóa Khách Hàng lỗi !!");
            }
        }

        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDKhachHang.Text);
            string carnumber = txtSoXe.Text;
            string name = txtTenKhachHang.Text;
            string HieuXe = txtHieuXe.Text;
            string DiaChi = txtDiaChi.Text;
            int DienThoai = Convert.ToInt32(txtDienThoai.Text);
            DateTime Ngaygui = dtpNgayGui.Value;
            float Tienno = (float)Convert.ToDouble(txtTienNo.Text);
            if (KhachHangDAL.Instance.UpdateKhachHang(name, HieuXe, DiaChi, DienThoai, Ngaygui, Tienno, id, carnumber))
            {
                MessageBox.Show("Sửa Khách Hàng thành công");
                LoadListKhachHang();
            }
            else
            {
                MessageBox.Show("Sửa Khách Hàng lỗi !!");
            }
        }
  
        private void btnTimFood_Click(object sender, EventArgs e)
        {           
            khachhangList.DataSource = SearchKhachHang(txtTimKhachHang.Text);
        }



        #endregion


    }
}
