using GarageManagement.GarageManagement_DAL;
using GarageManagement.GarageManagement_DTO;
using GarageManagement_DAL;
using GarageManagement_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GarageManagement
{
    public partial class frmDanhMuc : Form
    {
        BindingSource khachhangList = new BindingSource();
        BindingSource khoList = new BindingSource();
        BindingSource xeList = new BindingSource();
        BindingSource pscList = new BindingSource();
        BindingSource pttList = new BindingSource();
        public frmDanhMuc(AccountDTO loginAccount)
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
            dgvPSC.DataSource = pscList;
            dgvPTT.DataSource = pttList;
            LoadListKhachHang();
            AddBindingKhachHang();
            LoadKho();
            AddBindingKho();
            LoadListXe();
            AddBindingXe();
            LoadListPSC();
            LoadListPTT();
            AddBindingPSC();
            AddBindingPTT();
            LoadComboboxVatLieu(cbVatLieu);
            LoadComboboxHieuXe(cbHieuXe_PTT);
        }
        void LoadListKhachHang()
        {
            khachhangList.DataSource = KhachHangDAL.Instance.GetListKhachHang();
        }
    
        void LoadKho()
        {
            khoList.DataSource = VatLieuDAL.Instance.GetListKho();

        }

        void LoadListXe()
        {
            xeList.DataSource = XeDAL.Instance.GetListXe();
        }

        void LoadListPSC()
        {          
            pscList.DataSource = PhieuSuaChuaDAL.Instance.GetListPhieuSuaChua();
        }

        void LoadListPTT()
        {
            pttList.DataSource = PhieuThuTienDAL.Instance.GetListPhieuThuTien();
        }

        void LoadComboboxHieuXe(ComboBox cb)
        {
            cb.DataSource = XeDAL.Instance.GetListXe();
            cb.DisplayMember = "carbrand";
        }

        void LoadComboboxVatLieu(ComboBox cb)
        {
            cb.DataSource = VatLieuDAL.Instance.GetListKho();
            cb.DisplayMember = "item";
        }


        bool CheckIntValue(string id)
        {
            int parsedValue;
            if (!int.TryParse(id, out parsedValue))
            {
                MessageBox.Show("Id sai số , xin vui lòng nhập lại !");
                return false;
            }
            return true;
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
            
            txtMaSoVatLieu.DataBindings.Add(new Binding("Text", dgvKho.DataSource, "iditem", true, DataSourceUpdateMode.Never));
            txtVatLieu.DataBindings.Add(new Binding("Text", dgvKho.DataSource, "item", true, DataSourceUpdateMode.Never));
            nmSoLuongVatLieu.DataBindings.Add(new Binding("Text", dgvKho.DataSource, "slitem", true, DataSourceUpdateMode.Never));
            dtpNgayNhap.DataBindings.Add(new Binding("Value", dgvKho.DataSource, "importeddate", true, DataSourceUpdateMode.Never));
            dtpNgayXuat.DataBindings.Add(new Binding("Value", dgvKho.DataSource, "exporteddate", true, DataSourceUpdateMode.Never));

        }

        void AddBindingXe()
        {
            txtMaXe.DataBindings.Add(new Binding("Text", dgvXe.DataSource, "carnumber", true, DataSourceUpdateMode.Never));
            txtHieuXe.DataBindings.Add(new Binding("Text", dgvXe.DataSource, "carbrand", true, DataSourceUpdateMode.Never));
            txtIDKH_XE.DataBindings.Add(new Binding("Text", dgvXe.DataSource, "idkh", true, DataSourceUpdateMode.Never));
        }

        void AddBindingPSC()
        {
            txtIDPSC.DataBindings.Add(new Binding("Text", dgvPSC.DataSource, "idpsc", true, DataSourceUpdateMode.Never));
            txtNoiDungPSC.DataBindings.Add(new Binding("Text", dgvPSC.DataSource, "detail", true, DataSourceUpdateMode.Never));
            dtpNgayTaoPSC.DataBindings.Add(new Binding("Value", dgvPSC.DataSource, "createddate", true, DataSourceUpdateMode.Never));
            txtDonGiaPSC.DataBindings.Add(new Binding("Text", dgvPSC.DataSource, "dongia", true, DataSourceUpdateMode.Never));
            txtTienCongPSC.DataBindings.Add(new Binding("Text", dgvPSC.DataSource, "tiencong", true, DataSourceUpdateMode.Never));
            txtTotalPricePSC.DataBindings.Add(new Binding("Text", dgvPSC.DataSource, "totalprice", true, DataSourceUpdateMode.Never));         
        }

        void AddBindingPTT()
        {
            txtIDPTT.DataBindings.Add(new Binding("Text", dgvPTT.DataSource, "idptt", true, DataSourceUpdateMode.Never));
            txtMaKH_PTT.DataBindings.Add(new Binding("Text", dgvPTT.DataSource, "idkhachhang", true, DataSourceUpdateMode.Never));
            dtpNgayTao_PTT.DataBindings.Add(new Binding("Value", dgvPTT.DataSource, "createddate", true, DataSourceUpdateMode.Never));
            txtSoTienThu.DataBindings.Add(new Binding("Text", dgvPTT.DataSource, "sotienthu", true, DataSourceUpdateMode.Never));
        }
        #endregion
        
        #region events
        

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtIDKhachHang.Text) == true)
            {
                try
                {
                    int id = Convert.ToInt32(txtIDKhachHang.Text);
                    string name = txtTenKhachHang.Text;
                    string DiaChi = txtDiaChi.Text;
                    int DienThoai = Convert.ToInt32(txtDienThoai.Text);
                    DateTime? Ngaygui = dtpNgayGui.Value;
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
                catch (Exception ex) { MessageBox.Show("Thêm khách hàng lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }
        }

        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtIDKhachHang.Text) == true)
            {
                try
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
                catch (Exception ex) { MessageBox.Show("Xóa khách hàng lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }   
        }   


        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtIDKhachHang.Text) == true)
            {
                try
                {
                    int id = Convert.ToInt32(txtIDKhachHang.Text);
                    string name = txtTenKhachHang.Text;
                    string DiaChi = txtDiaChi.Text;
                    int DienThoai = Convert.ToInt32(txtDienThoai.Text);
                    DateTime? Ngaygui = dtpNgayGui.Value;
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
                catch (Exception ex) { MessageBox.Show("Sửa khách hàng lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
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
            if (CheckIntValue(txtMaXe.Text) == true)
            {
                try
                {
                    int maxe = Convert.ToInt32(txtMaXe.Text);
                    string hieuxe = txtHieuXe.Text;
                    int idkh = Convert.ToInt32(txtIDKH_XE.Text);
                    if (XeDAL.Instance.UpdateXe(hieuxe, maxe, idkh))
                    {
                        MessageBox.Show("Cập nhật xe thành công");
                        LoadListXe();
                        LoadComboboxHieuXe(cbHieuXe_PTT);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật xe lỗi !!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Cập nhật xe lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }
        }

        private void btnXoaXe_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtMaXe.Text) == true)
            {
                try
                {
                    int maxe = Convert.ToInt32(txtMaXe.Text);
                    if (XeDAL.Instance.DeleteXe(maxe))
                    {
                        MessageBox.Show("Xóa xe thành công");
                        LoadListXe();
                        LoadComboboxHieuXe(cbHieuXe_PTT);
                    }
                    else
                    {
                        MessageBox.Show("xóa xe lỗi !!");
                    }
                }
                catch (Exception ex){ MessageBox.Show("xóa xe lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
        } }

        private void btnThemXe_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtMaXe.Text) == true)
            {
                try
                {
                    int maxe = Convert.ToInt32(txtMaXe.Text);
                    string hieuxe = txtHieuXe.Text;
                    int idkh = Convert.ToInt32(txtIDKH_XE.Text);
                    if (XeDAL.Instance.InsertXe(maxe, hieuxe, idkh))
                    {
                        MessageBox.Show("Thêm xe thành công");
                        LoadListXe();
                        LoadComboboxHieuXe(cbHieuXe_PTT);
                    }
                    else
                    {
                        MessageBox.Show("Thêm xe lỗi !!");
                    }
                }
                catch(Exception ex) { MessageBox.Show("Thêm xe lỗi !!  "+ex.Message + "\n" + ex.StackTrace); }
            }
        }

        private void btnThemKho_Click_1(object sender, EventArgs e)
        {
            if (CheckIntValue(txtMaSoVatLieu.Text) == true)
            {
                try
                {
                    int iditem = Convert.ToInt32(txtMaSoVatLieu.Text);
                    string item = txtVatLieu.Text;
                    int slitem = Convert.ToInt32(nmSoLuongVatLieu.Text);
                    DateTime? importteddate = dtpNgayNhap.Value;
                    DateTime? exportteddate = dtpNgayXuat.Value;
                    if (VatLieuDAL.Instance.InsertVatLieu(iditem, item, slitem, importteddate, exportteddate))
                    {
                        MessageBox.Show("Thêm vào kho thành công");
                        LoadKho();
                        LoadComboboxVatLieu(cbVatLieu);


                    }
                    else
                    {
                        MessageBox.Show("Thêm vào kho lỗi !!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Thêm vào kho lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }
        } 

        private void btnXemKho_Click(object sender, EventArgs e)
        {
            LoadKho();
        }

        private void btnXoaKho_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtMaSoVatLieu.Text) == true)
            {
                try
                {
                    int iditem = Convert.ToInt32(txtMaSoVatLieu.Text);

                    if (VatLieuDAL.Instance.DeleteVatLieu(iditem))
                    {
                        MessageBox.Show("Xóa vật liệu kho thành công");
                        LoadKho();
                        LoadComboboxVatLieu(cbVatLieu);
                    }
                    else
                    {
                        MessageBox.Show("Xóa vật liệu kho kho lỗi !!");
                    }
                }
                catch (Exception ex) { MessageBox.Show(" Xóa vật liệu trong kho lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }
        }

        private void btnTimKho_Click(object sender, EventArgs e)
        {
            khoList.DataSource = VatLieuDAL.Instance.SearchVatLieuByNameAndID(txtTimKho.Text);
        }
        private void btnSuaKho_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtMaSoVatLieu.Text) == true)
            {
                try
                {
                    int iditem = Convert.ToInt32(txtMaSoVatLieu.Text);
                    string item = txtVatLieu.Text;
                    int slitem = Convert.ToInt32(nmSoLuongVatLieu.Text);
                    DateTime? importteddate = dtpNgayNhap.Value;
                    DateTime? exportteddate = dtpNgayXuat.Value;
                    if (VatLieuDAL.Instance.UpdateVatLieu(iditem, item, slitem, importteddate, exportteddate))
                    {
                        MessageBox.Show("Cập nhật kho thành công");
                        LoadKho();
                        LoadComboboxVatLieu(cbVatLieu);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật kho lỗi !!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Cập nhật vật liệu kho lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            } }

        private void btnXemPSC_Click(object sender, EventArgs e)
        {
            LoadListPSC();
        }

        private void btnSuaPSC_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtIDPSC.Text) && CheckIntValue(txtCarnumber_PSC.Text)  == true)
            {
                try
                {
                    int idpsc = Convert.ToInt32(txtIDPSC.Text);
                    int carnumber = Convert.ToInt32(txtCarnumber_PSC.Text);
                    int iditem = (cbVatLieu.SelectedItem as VatLieuDTO).Iditem;
                    string detail = txtNoiDungPSC.Text;
                    DateTime? createddate = dtpNgayTaoPSC.Value;
                    float dongia = (float)Convert.ToDouble(txtDonGiaPSC.Text);
                    float tiencong = (float)Convert.ToDouble(txtTienCongPSC.Text);
                    float totalprice = dongia + tiencong;
                    if (PhieuSuaChuaDAL.Instance.UpdatePhieuSuaChua(idpsc, carnumber, iditem, detail, createddate, dongia, tiencong, totalprice))
                    {
                        MessageBox.Show("Cập nhật phiếu sửa chữa thành công");
                        LoadListPSC();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật phiếu lỗi !!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Cập nhật phiếu lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }
        }

        private void btnXoaPSC_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtIDPSC.Text))
            {try
                {
                    int idpsc = Convert.ToInt32(txtIDPSC.Text);
                    if (PhieuSuaChuaDAL.Instance.DeletePhieuSuaChua(idpsc))
                    {
                        MessageBox.Show("xóa phiếu sửa chữa thành công");
                        LoadListPSC();
                    }
                    else
                    {
                        MessageBox.Show("xóa phiếu lỗi !!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Xóa phiếu lỗi !! " + ex.Message  + "\n" + ex.StackTrace); }
            }
        }

        private void btnThemPSC_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtIDPSC.Text) && CheckIntValue(txtCarnumber_PSC.Text) == true)
            {
                try
                {
                    int idpsc = Convert.ToInt32(txtIDPSC.Text);
                    int carnumber = Convert.ToInt32(txtCarnumber_PSC.Text);
                    int iditem = (cbVatLieu.SelectedItem as VatLieuDTO).Iditem;
                    string detail = txtNoiDungPSC.Text;
                    DateTime? createddate = dtpNgayTaoPSC.Value;
                    float dongia = (float)Convert.ToDouble(txtDonGiaPSC.Text);
                    float tiencong = (float)Convert.ToDouble(txtTienCongPSC.Text);
                    float totalprice = dongia + tiencong;
                    if (PhieuSuaChuaDAL.Instance.InsertPhieuSuaChua(idpsc, carnumber, iditem, detail, createddate, dongia, tiencong, totalprice))
                    {
                        MessageBox.Show("Thêm vào phiếu sửa chữa thành công");
                        LoadListPSC();
                    }
                    else
                    {
                        MessageBox.Show("Thêm vào phiếu lỗi !!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Thêm vào phiếu lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }
        }


        private void txtIDPSC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPSC.SelectedCells.Count > 0)
                {
                    int carnumber = (int)dgvPSC.SelectedCells[0].OwningRow.Cells["Carnumber"].Value;
                    int iditem = (int)dgvPSC.SelectedCells[0].OwningRow.Cells["iditem"].Value;

                    XeDTO xe = XeDAL.Instance.GetListXeById(carnumber);
                    VatLieuDTO kho = VatLieuDAL.Instance.GetListKhoById(iditem);

                    //cbHieuXe.SelectedItem = xe;
                    cbVatLieu.SelectedItem = kho;
                    

                    int indexcar = -1;
                    int indexkho = -1;
                    int i1 = 0;
                    int i2 = 0;
                    //foreach (XeDTO item in cbHieuXe.Items)
                    //{
                    //    if (item.Carnumber == xe.Carnumber)
                    //    {
                    //        indexcar = i1;
                    //        break;
                    //    }
                    //    i1++;
                    //}
                    foreach (VatLieuDTO item in cbVatLieu.Items)
                    {
                        if (item.Iditem == kho.Iditem)
                        {
                            indexkho = i2;
                            break;
                        }
                        i2++;
                    }
                    //cbHieuXe.SelectedIndex = indexcar;
                    cbVatLieu.SelectedIndex = indexkho;
                }
            }
            catch { }
        }

        private void btnXemPhieuThuTien_Click(object sender, EventArgs e)
        {
            LoadListPTT();
        }

        private void btnSuaPhieuThuTien_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtIDPTT.Text))
            {
                try
                {
                    int idptt = Convert.ToInt32(txtIDPTT.Text);
                    int idkhachhang = Convert.ToInt32(txtMaKH_PTT.Text);
                    int carnumber = (cbHieuXe_PTT.SelectedItem as XeDTO).Carnumber;
                    DateTime? createddate = dtpNgayTao_PTT.Value;
                    float sotienthu = (float)Convert.ToDouble(txtSoTienThu.Text);
                    if (PhieuThuTienDAL.Instance.UpdatePhieuThuTien(idptt, idkhachhang, carnumber, createddate, sotienthu))
                    {
                        MessageBox.Show("Sửa phiếu thu tiền thành công");
                        LoadListPTT();
                    }
                    else
                    {
                        MessageBox.Show("Sửa phiếu lỗi !!");
                    }

                }
                catch (Exception ex) { MessageBox.Show("Sửa phiếu lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }
        }

        private void btnXoaPhieuThuTien_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtIDPTT.Text))
            {
                try
                {
                    int idptt = Convert.ToInt32(txtIDPTT.Text);
                  
                    if (PhieuThuTienDAL.Instance.DeletePhieuThuTien(idptt))
                    {
                        MessageBox.Show("Xóa phiếu thu tiền thành công");
                        LoadListPTT();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu lỗi !!");
                    }

                }
                catch (Exception ex) { MessageBox.Show("Xóa phiếu lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }
        }

        private void btnThemPhieuThuTien_Click(object sender, EventArgs e)
        {
            if (CheckIntValue(txtIDPTT.Text))
            {
                try
                {
                    int idptt = Convert.ToInt32(txtIDPTT.Text);
                    int idkhachhang = Convert.ToInt32(txtMaKH_PTT.Text);
                    int carnumber = (cbHieuXe_PTT.SelectedItem as XeDTO).Carnumber;
                    DateTime? createddate = dtpNgayTao_PTT.Value;
                    float sotienthu = (float)Convert.ToDouble(txtSoTienThu.Text);
                    if (PhieuThuTienDAL.Instance.InsertPhieuThuTien(idptt, idkhachhang, carnumber, createddate, sotienthu))
                    {
                        MessageBox.Show("Thêm vào phiếu thu tiền thành công");
                        LoadListPTT();
                    }
                    else
                    {
                        MessageBox.Show("Thêm vào phiếu lỗi !!");
                    }

                }
                catch (Exception ex) { MessageBox.Show("Thêm vào phiếu lỗi !! " + ex.Message + "\n" + ex.StackTrace); }
            }
        }

        private void txtIDPTT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPTT.SelectedCells.Count > 0)
                {
                    int carnumber = (int)dgvPTT.SelectedCells[0].OwningRow.Cells["Carnumber"].Value;

                    XeDTO xe = XeDAL.Instance.GetListXeById(carnumber);
                    cbHieuXe_PTT.SelectedItem = xe;
                    int index = -1;
                    int i = 0;
                    foreach (XeDTO item in cbHieuXe_PTT.Items)
                    {
                        if (item.Carnumber == xe.Carnumber)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbHieuXe_PTT.SelectedIndex = index;
                }
            }
            catch { }

        }

      

        #endregion


    }
}
