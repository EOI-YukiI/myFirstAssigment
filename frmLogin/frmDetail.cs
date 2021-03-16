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
    public partial class frmDetail : Form
    {
        Book book = new Book();
        public frmDetail()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            book.BookID = int.Parse(txtBookID.Text);
            book.BookName = txtBookName.Text;
            book.BookPrice = float.Parse(txtBookPrice.Text);
            BookDB db = new BookDB();
            try
            {
                if (db.InsertBook(book))
                {
                    MessageBox.Show("Insert thanh cong");
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Save that bai");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetail_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
