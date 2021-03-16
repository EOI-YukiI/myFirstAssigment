using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin
{
    class LoginDB
    {
        SqlConnection cnn = null;

        string strConnection = @"server=SE140638;database=BookStore;uid=sa;pwd=123456";
        public bool checkLogin(string username, string password)
        {

            string SQL = "select * from Employee where EmpID = @EmpID AND EmpPassword = @EmpPassword";
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            SqlDataReader reader = null;
            cmd.Parameters.AddWithValue("@EmpID", username);
            cmd.Parameters.AddWithValue("@EmpPassword", password);
            reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetBoolean(2);

        }

        public bool ChangePassword(string username, string password)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "update Employee set EmpPassword = @EmpPassword, EmpRole = @EmpRole where EmpID = @EmpID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@EmpPassword", password);
            cmd.Parameters.AddWithValue("@EmpRole", true);
            cmd.Parameters.AddWithValue("@EmpID", username);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
    }
}
