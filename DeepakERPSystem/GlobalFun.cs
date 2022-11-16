using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using System.Configuration;

namespace DeepakERPSystem
{
   
    class GlobalFun
    {
        SqlConnection conn1 = SqlconnMain.GetCurrentPayrollDBConnection();
        private void getdeptname()
        {
            if (conn1.State == ConnectionState.Closed)
                conn1.Open();
            SqlCommand cmd1 = new SqlCommand("select *from department");
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            sda.Fill(ds);

        }
    }

}
