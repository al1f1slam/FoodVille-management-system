using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Foodville
{
    class Connection
    {
        public static SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-LPTMJF3;Initial Catalog=Foodvile;User ID=sa;Password=3473;Pooling=False");

        public static void Open()
        {
            sqlCon.Open();

        }

        public static void Close()
        {
            sqlCon.Close();
        }
    }
}
