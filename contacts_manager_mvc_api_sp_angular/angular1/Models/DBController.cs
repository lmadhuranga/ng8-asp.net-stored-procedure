using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace angular1.Models
{
    public class DBConnection
    { 
        SqlConnection sqlCon = new SqlConnection(@"Data Source=MAD-WIN10\SQLEXPRESS;Initial Catalog=mycontacts;Integrated Security=true;");

        public SqlConnection checkDb()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            return sqlCon;
        }

        public bool Close()
        {
            sqlCon.Close();
            return true;
        }
    }
}