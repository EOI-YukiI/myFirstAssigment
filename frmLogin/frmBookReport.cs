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
    public partial class frmBookReport : Form
    {

        public frmBookReport()
        {
            InitializeComponent();
            loadAndSort();
        }
        public void loadAndSort()
        {
            BookDB db = new BookDB();
            GridView.DataSource = db.getListBook();
            GridView.Sort(GridView.Columns[2], ListSortDirection.Descending);
        }

        private void frmBookReport_Load(object sender, EventArgs e)
        {

        }
    }
}
