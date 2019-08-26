using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace angular1.Models
{
    public class ContactModel
    {
        DBConnection dbCon = new DBConnection();
        SqlConnection sqlCon = new SqlConnection();
        public bool create(Contact newContact)
        {
            sqlCon = dbCon.checkDb();
            SqlCommand sqlCmd = new SqlCommand("ContactsCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@id", 0);
            sqlCmd.Parameters.AddWithValue("@name", newContact.name.Trim());
            sqlCmd.Parameters.AddWithValue("@mobile", newContact.mobile.Trim());
            sqlCmd.Parameters.AddWithValue("@email", newContact.email.Trim());
            sqlCmd.ExecuteNonQuery();
            dbCon.Close(); 
            return true;
        }

        public bool update(Contact updateContact)
        {
            sqlCon = dbCon.checkDb();
            SqlCommand sqlCmd = new SqlCommand("ContactsCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure; 
            sqlCmd.Parameters.AddWithValue("@id", updateContact.id );
            sqlCmd.Parameters.AddWithValue("@name", updateContact.name.Trim());
            sqlCmd.Parameters.AddWithValue("@mobile", updateContact.mobile.Trim());
            sqlCmd.Parameters.AddWithValue("@email", updateContact.email.Trim());
            sqlCmd.ExecuteNonQuery();
            dbCon.Close();
            return true;
        }

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

        public DataSet getAll()
        {
            sqlCon = dbCon.checkDb();
            SqlCommand cmd = new SqlCommand("ContactsViewAll", sqlCon);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dbCon.Close();
            return ds;
        }
    } 
    public class Contact
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
    }

}