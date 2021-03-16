using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin
{
    class BookDB
    {
        string strConnection = @"server=SE140638;database=BookStore;uid=sa;pwd=123456";
        SqlConnection cnn = null;
        public DataTable getListBook()
        {
            string SQL = "select * from Books";
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtPro = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                da.Fill(dtPro);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                con.Close();
            }
            return dtPro;

        }
        public bool CheckUpdate(Book b)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "update Books set BookName = @BookName, BookPrice = @BookPrice where BookID = @BookID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@BookName", b.BookName);
            cmd.Parameters.AddWithValue("@BookPrice", b.BookPrice);
            cmd.Parameters.AddWithValue("@BookID", b.BookID);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
        public bool DeleteBook(int BookID)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Delete From Books where BookID = @BookID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@BookID", BookID);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
        public bool InsertBook(Book b)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert Books values(@BookID, @BookName, @BookPrice)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@BookID", b.BookID);
            cmd.Parameters.AddWithValue("@BookName", b.BookName);
            cmd.Parameters.AddWithValue("@BookPrice", b.BookPrice);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
        public DataTable FilterBook(string keySearch)
        {
            string SQL = "select * from Books where BookName like  '%' + @Filter + '%'";
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@Filter", keySearch);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtPro = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                da.Fill(dtPro);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                con.Close();
            }
            return dtPro;
        }
    }
}
