using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmLogin
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            LoginDB db = new LoginDB();
            try
            {
                if (db.checkLogin(username, password))
                {
                    frmMaintainBooks frm = new frmMaintainBooks();
                    frm.ShowDialog();
                    
                }
                else
                {
                    frmChangeAccount frm = new frmChangeAccount(username);
                    frm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("sai tai khoan hoac mat khau");
            }
        }
    }
}
