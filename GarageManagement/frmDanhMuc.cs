using GarageManagement.GarageManagement_DAL;
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
        BindingSource khoList = new BindingSource();
        BindingSource xeList = new BindingSource();
        public frmDanhMuc()
        {
            InitializeComponent();
            LoadMethod();
        }

        #region method
        void LoadMethod()
        {
            dgvKhachHang.DataSource = khachhangList;
            dgvKho.DataSource = khoList;
            dgvXe.DataSource = xeList;
            LoadListKhachHang();
            AddBindingKhachHang();
            LoadKho();
            AddBindingKho();
            LoadListXe();
            AddBindingXe();
        }
        void LoadListKhachHang()
        {
            khachhangList.DataSource = KhachHangDAL.Instance.GetListKhachHang();
        }

        void LoadKho()
        {
            khoList.DataSource = KhoGaraDAL.Instance.GetListKho();
        }

        void LoadListXe()
        {
            xeList.DataSource = XeDAL.Instance.GetListXe();
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
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "Address", true, DataSourceUpdateMode.Never));
            txtDienThoai.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "PHONE", true, DataSourceUpdateMode.Never));
            dtpNgayGui.DataBindings.Add(new Binding("Value", dgvKhachHang.DataSource, "CREATEDDATE", true, DataSourceUpdateMode.Never));
            txtTienNo.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "DEBT", true, DataSourceUpdateMode.Never));           
        }

        void AddBindingKho()
        {
            
            txtMaSoVatLieu.DataBindings.Add(new Binding("Text", dgvKho.DataSource, "Mã số vật liệu", true, DataSourceUpdateMode.Never));
            txtVatLieu.DataBindings.Add(new Binding("Text", dgvKho.DataSource, "Tên vật liệu", true, DataSourceUpdateMode.Never));
            nmSoLuongVatLieu.DataBindings.Add(new Binding("Text", dgvKho.DataSource, "Số lượng vật liệu", true, DataSourceUpdateMode.Never));
            dtpNgayNhap.DataBindings.Add(new Binding("Value", dgvKho.DataSource, "Ngày nhập", true, DataSourceUpdateMode.Never));
            dtpNgayXuat.DataBindings.Add(new Binding("Value", dgvKho.DataSource, "Ngày xuất", true, DataSourceUpdateMode.Never));

        }

        void AddBindingXe()
        {
            txtMaXe.DataBindings.Add(new Binding("Text", dgvXe.DataSource, "carnumber", true, DataSourceUpdateMode.Never));
            txtHieuXe.DataBindings.Add(new Binding("Text", dgvXe.DataSource, "carbrand", true, DataSourceUpdateMode.Never));
            txtIDKH_XE.DataBindings.Add(new Binding("Text", dgvXe.DataSource, "idkh", true, DataSourceUpdateMode.Never));
        }
        #endregion
        
        #region events
        

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDKhachHang.Text);
            string name = txtTenKhachHang.Text;
            string DiaChi = txtDiaChi.Text;
            int DienThoai = Convert.ToInt32(txtDienThoai.Text);
            DateTime Ngaygui = dtpNgayGui.Value;
            float Tienno = (float)Convert.ToDouble(txtTienNo.Text);
            if (KhachHangDAL.Instance.InsertKhachHang(id, name, DiaChi, DienThoai, Ngaygui, Tienno))
            {
                MessageBox.Show("Thêm Khách Hàng thành công");
                LoadListKhachHang();
                LoadListXe();
            }
            else
            {
                MessageBox.Show("Thêm Khách Hàng lỗi !!");
            }
        }

        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDKhachHang.Text);
            if (KhachHangDAL.Instance.DeleteKhachHang(id))
            {
                MessageBox.Show("Xóa Khách Hàng thành công");
                LoadListKhachHang();
                LoadListXe();
            }
            else
            {
                MessageBox.Show("Xóa Khách Hàng lỗi !!");
            }
        }

        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDKhachHang.Text);
            string name = txtTenKhachHang.Text;
            string DiaChi = txtDiaChi.Text;
            int DienThoai = Convert.ToInt32(txtDienThoai.Text);
            DateTime Ngaygui = dtpNgayGui.Value;
            float Tienno = (float)Convert.ToDouble(txtTienNo.Text);
            if (KhachHangDAL.Instance.UpdateKhachHang(name, DiaChi, DienThoai, Ngaygui, Tienno, id))
            {
                MessageBox.Show("Sửa Khách Hàng thành công");
                LoadListKhachHang();
                LoadListXe();
            }
            else
            {
                MessageBox.Show("Sửa Khách Hàng lỗi !!");
            }
        }
        private void btnXemKhachHang_Click_1(object sender, EventArgs e)
        {
            LoadListKhachHang();
        }

        private void btnTimKhachHang_Click(object sender, EventArgs e)
        {
            khachhangList.DataSource = SearchKhachHang(txtTimKhachHang.Text);
        }

   
        private void btnXemXe_Click(object sender, EventArgs e)
        {
            LoadListXe();
        }

        private void btxSuaXe_Click(object sender, EventArgs e)
        {
            int maxe = Convert.ToInt32(txtMaXe.Text);
            string hieuxe = txtHieuXe.Text;
            if (XeDAL.Instance.UpdateXe(hieuxe, maxe))
            {
                MessageBox.Show("Cập nhật xe thành công");
                LoadListXe();
            }
            else
            {
                MessageBox.Show("Cập nhật xe lỗi !!");
            }
        }

        private void btnXoaXe_Click(object sender, EventArgs e)
        {
            int maxe = Convert.ToInt32(txtMaXe.Text);           
            if (XeDAL.Instance.DeleteXe(maxe))
            {
                MessageBox.Show("Xóa xe thành công");
                LoadListXe();
            }
            else
            {
                MessageBox.Show("xóa xe lỗi !!");
            }
        }

        private void btnThemXe_Click(object sender, EventArgs e)
        {
            int maxe = Convert.ToInt32(txtMaXe.Text);
            string hieuxe = txtHieuXe.Text;
            int idkh = Convert.ToInt32(txtIDKH_XE.Text);
            if (XeDAL.Instance.InsertXe(maxe, hieuxe,idkh))
            {
                MessageBox.Show("Thêm xe thành công");
                LoadListXe();
            }
            else
            {
                MessageBox.Show("Thêm xe lỗi !!");
            }
        }

        private void btnThemKho_Click_1(object sender, EventArgs e)
        {
            int iditem = Convert.ToInt32(txtMaSoVatLieu.Text);
            string item = txtVatLieu.Text;
            int slitem = Convert.ToInt32(nmSoLuongVatLieu.Text);
            DateTime importteddate = dtpNgayNhap.Value;
            DateTime exportteddate = dtpNgayXuat.Value;
            if (KhoGaraDAL.Instance.InsertKho(iditem, item , slitem, importteddate, exportteddate))
            {
                MessageBox.Show("Thêm vào kho thành công");
                LoadKho();
            }
            else
            {
                MessageBox.Show("Thêm vào kho lỗi !!");
            }
        }


        private void btnXemKho_Click(object sender, EventArgs e)
        {
            LoadKho();
        }

        private void btnXoaKho_Click(object sender, EventArgs e)
        {
            int iditem = Convert.ToInt32(txtMaSoVatLieu.Text);
         
            if (KhoGaraDAL.Instance.DeleteKho(iditem))
            {
                MessageBox.Show("Xóa vật liệu kho thành công");
                LoadKho();
            }
            else
            {
                MessageBox.Show("Xóa vật liệu kho kho lỗi !!");
            }
        }

        private void btnTimKho_Click(object sender, EventArgs e)
        {
            khoList.DataSource = KhoGaraDAL.Instance.SearchKhoByNameAndID(txtTimKho.Text);
        }
        private void btnSuaKho_Click(object sender, EventArgs e)
        {
            int iditem = Convert.ToInt32(txtMaSoVatLieu.Text);
            string item = txtVatLieu.Text;
            int slitem = Convert.ToInt32(nmSoLuongVatLieu.Text);
            DateTime importteddate = dtpNgayNhap.Value;
            DateTime exportteddate = dtpNgayXuat.Value;
            if (KhoGaraDAL.Instance.UpdateKho(iditem, item, slitem, importteddate, exportteddate))
            {
                MessageBox.Show("Cập nhật kho thành công");
                LoadKho();
            }
            else
            {
                MessageBox.Show("Cập nhật kho lỗi !!");
            }
        }
        #endregion


    }
}
