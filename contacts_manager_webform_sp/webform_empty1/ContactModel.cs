using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webform_empty1
{
    public class ContactModel
    {
        DBConnection dbCon = new DBConnection();
        SqlConnection sqlCon = new SqlConnection();
        public bool Create(int ContactID, string Name, string Mobile, string Address)
        {
            sqlCon = dbCon.checkDb();
            SqlCommand sqlCmd = new SqlCommand("ContactCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ContactID", ContactID);
            sqlCmd.Parameters.AddWithValue("@Name", Name.Trim());
            sqlCmd.Parameters.AddWithValue("@Mobile", Mobile.Trim());
            sqlCmd.Parameters.AddWithValue("@Address", Address.Trim());
            sqlCmd.ExecuteNonQuery();
            dbCon.Close();
            return true;
        }

        public IDictionary<string, string> GetByID(int contactID)
        {
            // Check database connection is open 
            sqlCon = dbCon.checkDb();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ContactID", contactID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();

            IDictionary<string, string> contact = new Dictionary<string, string>();
            contact.Add("Name", dtbl.Rows[0]["Name"].ToString());
            contact.Add("Mobile", dtbl.Rows[0]["Mobile"].ToString());
            contact.Add("Address", dtbl.Rows[0]["Address"].ToString());

            return contact;
        }

        public bool DeleteByID(int ContactID)
        {
            // Check database connection is open 
            sqlCon = dbCon.checkDb();
            SqlCommand sqlCmd = new SqlCommand("ContactDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ContactID", ContactID);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            return true;
        }

        public DataTable GetAll()
        {
            sqlCon = dbCon.checkDb();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewAll", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            return dtbl;
        }
    }
}