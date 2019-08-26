using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ContactsApi.Database;   

namespace ContactsApi.Models
{
    public class ContactModel
    {
        DBConnection dbCon = new DBConnection();
        SqlConnection sqlCon = new SqlConnection(); 
        public DataSet getByID(int id)
        {
            // Check database connection is open 
            sqlCon = dbCon.checkDb();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ContactsViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            dbCon.Close();
            return ds;
        } 
        public bool createOrUpdate(Contact updateContact)
        {
            sqlCon = dbCon.checkDb();
            SqlCommand sqlCmd = new SqlCommand("ContactsCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@id", updateContact.id);
            sqlCmd.Parameters.AddWithValue("@name", updateContact.name.Trim());
            sqlCmd.Parameters.AddWithValue("@mobile", updateContact.mobile.Trim());
            sqlCmd.Parameters.AddWithValue("@email", updateContact.email.Trim());
            sqlCmd.ExecuteNonQuery();
            dbCon.Close();
            return true;
        }

        public DataSet getAll()
        {
            sqlCon = dbCon.checkDb();
            SqlCommand sqlCmd = new SqlCommand("ContactsViewAll", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure; 
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            return ds;
        }

        public bool deleteByID(int id)
        {
            // Check database connection is open 
            sqlCon = dbCon.checkDb();
            SqlCommand sqlCmd = new SqlCommand("ContactsDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@id", id);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            return true;
        }
    }
}