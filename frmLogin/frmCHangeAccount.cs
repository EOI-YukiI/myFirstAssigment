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
    public partial class frmChangeAccount : Form
    {
        public frmChangeAccount(string username)
        {
            InitializeComponent();
            txtTaiKhoan.Text = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhauMoi.Text;
            LoginDB db = new LoginDB();
            try
            {
               if(db.ChangePassword(username, password))
                {
                    MessageBox.Show("Thay doi thanh cong");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Thay doi mat khau that bai");
            }
        }
    }
}
