using DevExpress.XtraEditors;
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
    public partial class frm_dangnhap : DevExpress.XtraEditors.XtraForm
    {
        public frm_dangnhap()
        {
            InitializeComponent();
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com");

        }

        private void frm_contact_Load(object sender, EventArgs e)
        {

        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if(txt_userName.Text =="admin" && txt_password.Text== "admin")
            {
                RibbonForm1 frm = new RibbonForm1();
                frm.Show(); 
                this.Hide();
            }else if(txt_userName.TextLength == 0 /*&& txt_password.TextLength == 0*/)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu  ? ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            } else 
            {
                MessageBox.Show("Lỗi hãy nhập lại  ? ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}