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
    public partial class frmMaintainBooks : Form
    {
        DataTable dt;
        public frmMaintainBooks()
        {
            InitializeComponent();
            loadBook();
        }
        public void loadBook()
        {
            BookDB db = new BookDB();
            dt = db.getListBook();
            bsBooks.DataSource = dt;
            bnBooks.BindingSource = bsBooks;
            GridView.DataSource = bsBooks;

            txtBookID.DataBindings.Clear();
            txtBookName.DataBindings.Clear();
            txtBookPrice.DataBindings.Clear();

            txtBookID.DataBindings.Add("Text", bsBooks, "BookID");
            txtBookName.DataBindings.Add("Text", bsBooks, "BookName");
            txtBookPrice.DataBindings.Add("Text", bsBooks, "BookPrice");

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BookID = int.Parse(txtBookID.Text);
            b.BookName = txtBookName.Text;
            b.BookPrice = float.Parse(txtBookPrice.Text);

            try
            {
                BookDB db = new BookDB();
                if (db.CheckUpdate(b))
                {
                    
                    bsBooks.DataSource = db.getListBook();
                    MessageBox.Show("Thanh cong");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int BookID = int.Parse(txtBookID.Text);
            BookDB db = new BookDB();
            try
            {
                if (db.DeleteBook(BookID))
                {
                    bsBooks.DataSource = db.getListBook();
                    MessageBox.Show("Thanh cong");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Delete that bai");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BookDB db = new BookDB();
            frmDetail frm = new frmDetail();
             frm.ShowDialog();
             bsBooks.DataSource = db.getListBook();
            

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            BookDB db = new BookDB();
            
            try
            {
                bsBooks.DataSource = db.FilterBook(txtFilter.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Ko tim thay");
            }
            decimal sum = 0;
            for(int i=0; i < GridView.Rows.Count; i++)
            {
                sum += Convert.ToDecimal(GridView.Rows[i].Cells[2].Value);
            }
            
            txtTotalPrice.Text = sum.ToString();

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmBookReport frm = new frmBookReport();
            frm.ShowDialog();
        }

    }
}
