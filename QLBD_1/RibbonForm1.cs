using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBD_1
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        QLBDEntities db = new QLBDEntities();
        public RibbonForm1()
        {
            InitializeComponent();
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLBDDataSet.PHIEUTHUE' table. You can move, or remove it, as needed.
            this.pHIEUTHUETableAdapter.Fill(this.qLBDDataSet.PHIEUTHUE);
            // TODO: This line of code loads data into the 'qLBDDataSet.CHITIETPHIEUTHUE' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'qLBDDataSet.PHIEUTHUE' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'qLBDDataSet.CHITIETPHIEUTHUE' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'qLBDDataSet.CHITIETPHIEUTHUE' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'qLBDDataSet.PHIM' table. You can move, or remove it, as needed.
            this.pHIMTableAdapter.Fill(this.qLBDDataSet.PHIM);
            // TODO: This line of code loads data into the 'qLBDDataSet.BANG' table. You can move, or remove it, as needed.
            this.bANGTableAdapter.Fill(this.qLBDDataSet.BANG);
            // TODO: This line of code loads data into the 'qLBDDataSet.PHIM' table. You can move, or remove it, as needed.
            this.bANGTableAdapter.Fill(this.qLBDDataSet.BANG);
            // TODO: This line of code loads data into the 'qLBDDataSet.KHACH' table. You can move, or remove it, as needed.
            this.kHACHTableAdapter.Fill(this.qLBDDataSet.KHACH);
            // TODO: This line of code loads data into the 'qLBDDataSet.BANG' table. You can move, or remove it, as needed.
            this.bANGTableAdapter.Fill(this.qLBDDataSet.BANG);
            // TODO: This line of code loads data into the 'qLBDDataSet.BANG' table. You can move, or remove it, as needed.
            this.bANGTableAdapter.Fill(this.qLBDDataSet.BANG);
            // TODO: This line of code loads data into the 'qLBDDataSet.KHACH' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'qLBDDataSet1.BANG' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'qLBDDataSet.PHIM' table. You can move, or remove it, as needed.

            getMaKhach();
            LoadData();
        }


        //__________________________________________________________________________________________________________________________________________________________

        // Nếu thanh Nav bar đang trỏ vào đâu thì chọn nav page tương tự 
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)    
        {
            navigationFrame1.SelectedPage = navigationPage1;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage4;

        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage3;

        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage5;
            LoadData();
            gridControl5.RefreshDataSource();

        }
        //__________________________________________________________________________________________________________________________________________________________
        





        private void getMaKhach()
        {
            cboMaKhach.DisplayMember = "MAKHACH";
            cboMaKhach.ValueMember = "MAKHACH";


            cboMaKhach.DataSource = db.KHACH.ToList();
        }

        private void LoadData()
        {
            int i = 0;
            List<PHIEUTHUE> lst = db.PHIEUTHUE.ToList();
            var columns = from t in lst
                          orderby t.SOPHIEUTHUE
                          select new
                          {
                              No = ++i,
                              SoPhieuThue = t.SOPHIEUTHUE,
                              MaKhach = t.MAKHACH,
                              NgayThue = t.NGAYTHUE,
                          };
            gridControl5.DataSource = columns.ToList();


        }


        /*##################################################################################################################################################################################
*/
        //    nút Thêm 

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (navigationFrame1.SelectedPage == navigationPage1)
            {
                var k = new KHACH
                {
                    MAKHACH = txt_maKhach.Text.Trim(),
                    TENKHACH = txt_TenKhach.Text.Trim(),
                    DIACHI = txt_DiaChi.Text.Trim(),
                    SDT = txt_SDT.Text.Trim(),
                };
                db.KHACH.Add(k);
                db.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
                RibbonForm1_Load(sender, e);
            }

            if (navigationFrame1.SelectedPage == navigationPage4)
            {
                var k = new BANG
                {
                    MABANG = txt_maBang.Text.Trim(),
                    MAPHIM = txt_MaPhim.Text.Trim(),
                };
                db.BANG.Add(k);
                db.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
                RibbonForm1_Load(sender, e);
            }

            if (navigationFrame1.SelectedPage == navigationPage3)
            {
                var k = new PHIM
                {
                    MAPHIM = txt_MaPhim_Phim.Text.Trim(),
                    TENPHIM = txt_TenPhim.Text.Trim(),
                    NUOCSX = txt_NuocSanXuat.Text.Trim(),
                    GIAVON = int.Parse(Txt_GiaVon.Text.Trim()),
                    MATHELOAI = txt_MaTheLoai.Text.Trim(),
                };
                db.PHIM.Add(k);
                db.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
                RibbonForm1_Load(sender, e);
            }


            if (navigationFrame1.SelectedPage == navigationPage5)
            {
                var k = new PHIEUTHUE
                {
                    SOPHIEUTHUE = txt_soPhieuThue.Text.Trim(),
                    MAKHACH = cboMaKhach.SelectedValue.ToString(),
                    NGAYTHUE = DateTime.Parse(dateNgayThue.Value.ToString("MM/dd/yyyy")),
                };
                db.PHIEUTHUE.Add(k);
                db.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
                LoadData();
            }
        }

        /*##################################################################################################################################################################################
*/
        //   nút sửa
        private void btn_Sua_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (navigationFrame1.SelectedPage == navigationPage1)       // Nếu nav frame đang chọn thông tin khách hàng thì thực hiện chức năng
            {
                var del = db.KHACH.Where(x => x.MAKHACH == txt_maKhach.Text.Trim()).FirstOrDefault();
                del.MAKHACH = txt_maKhach.Text.Trim();
                del.DIACHI = txt_DiaChi.Text.Trim();
                del.TENKHACH = txt_TenKhach.Text.Trim();
                del.SDT = txt_SDT.Text.Trim();
                db.SaveChanges();
                RibbonForm1_Load(sender, e);
            }

            if (navigationFrame1.SelectedPage == navigationPage4)       // Nếu nav frame đang chọn thông tin băng  thì thực hiện chức năng
            {
                var del = db.BANG.Where(x => x.MABANG == txt_maBang.Text.Trim()).FirstOrDefault();
                del.MABANG = txt_maBang.Text.Trim();
                del.MAPHIM = txt_MaPhim.Text.Trim();

                db.SaveChanges();
                RibbonForm1_Load(sender, e);
            }

            if (navigationFrame1.SelectedPage == navigationPage3)       // Nếu nav frame đang chọn thông tin phim thì thực hiện chức năng
            {
                var del = db.PHIM.Where(x => x.MAPHIM == txt_MaPhim.Text.Trim()).FirstOrDefault();
                del.MAPHIM = txt_MaPhim.Text.Trim();
                del.TENPHIM = txt_TenPhim.Text.Trim();
                del.NUOCSX = txt_NuocSanXuat.Text.Trim();
                del.GIAVON = int.Parse(Txt_GiaVon.Text.Trim()); db.SaveChanges();
                del.MATHELOAI = txt_MaTheLoai.Text.Trim();


                RibbonForm1_Load(sender, e);
            }

            if (navigationFrame1.SelectedPage == navigationPage5)       // Nếu nav frame đang chọn thông tin phiếu thuê thì thực hiện chức năng
            {
                var del = db.PHIM.Where(x => x.MAPHIM == txt_MaPhim.Text.Trim()).FirstOrDefault();
                del.MAPHIM = txt_MaPhim.Text.Trim();
                del.TENPHIM = txt_TenPhim.Text.Trim();
                del.NUOCSX = txt_NuocSanXuat.Text.Trim();
                del.GIAVON = int.Parse(Txt_GiaVon.Text.Trim()); db.SaveChanges();
                del.MATHELOAI = txt_MaTheLoai.Text.Trim();


                RibbonForm1_Load(sender, e);
            }
        }


        /*##################################################################################################################################################################################
*/
        // nút xóa 
        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (navigationFrame1.SelectedPage == navigationPage1)       // Nếu nav frame đang là thông tin khách 
            {
                if (MessageBox.Show("Bạn có chắc không ? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var sv = db.KHACH
                            .Where(x => x.MAKHACH == txt_maKhach.Text.Trim())
                            .FirstOrDefault();
                    var s = db.KHACH.FirstOrDefault(x => x.MAKHACH == txt_maKhach.Text.Trim());
                    db.KHACH.Remove(sv);
                    db.SaveChanges();
                    RibbonForm1_Load(sender, e);
                }
            }

            if (navigationFrame1.SelectedPage == navigationPage4)       // Nếu nav frame đang là thông tin băng 
            {
                if (navigationFrame1.SelectedPage == navigationPage4)
                {
                    if (MessageBox.Show("bạn có chắc muốn xóa không ? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var bang = db.BANG
                                .Where(x => x.MABANG == txt_maBang.Text.Trim())
                                .FirstOrDefault();
                        var s = db.BANG.FirstOrDefault(x => x.MABANG == txt_maBang.Text.Trim());
                        db.BANG.Remove(bang);
                        db.SaveChanges();
                        RibbonForm1_Load(sender, e);
                    }
                }
            }

            if (navigationFrame1.SelectedPage == navigationPage3)       // Nếu nav frame đang là thông tin phim
            {
                if (MessageBox.Show("Are you sure? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var sv = db.PHIM
                            .Where(x => x.MAPHIM == txt_MaPhim.Text.Trim())
                            .FirstOrDefault();
                    db.PHIM.Remove(sv);
                    db.SaveChanges();
                    RibbonForm1_Load(sender, e);
                }
            }

            if (navigationFrame1.SelectedPage == navigationPage5)       // Nếu nav frame đang là thông tin phiếu thuê
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không ? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var sv = db.PHIEUTHUE
                            .Where(x => x.SOPHIEUTHUE == txt_soPhieuThue.Text.Trim())
                            .FirstOrDefault();
                    db.PHIEUTHUE.Remove(sv);
                    db.SaveChanges();
                    LoadData();
                }
            }


        }
        /*##################################################################################################################################################################################
        */
        private void cbo_MaPhim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_clear_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (navigationFrame1.SelectedPage == navigationPage1)
            {
                txt_maKhach.Clear();
                txt_DiaChi.Clear();
                txt_TenKhach.Clear();
                txt_SDT.Clear();
            }

            if (navigationFrame1.SelectedPage == navigationPage5)
            {
                txt_soPhieuThue.ReadOnly = false;
                txt_soPhieuThue.Clear();
                cboMaKhach.ResetText();
                dateNgayThue.Refresh();
            }

        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com");
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();

        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Restart();

        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không  ? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                frm_dangnhap frm = new frm_dangnhap();
                frm.Show();
                this.Hide();
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Form1 frm = new Reports.Form1();
            frm.Show(); 
        }


    }
}