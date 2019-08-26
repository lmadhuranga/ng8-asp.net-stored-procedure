using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace webform_empty1
{
    public partial class Contact : System.Web.UI.Page
    {
        webform_empty1.ContactModel contactModel = new webform_empty1.ContactModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridView();
        } 

        public void ClearForm()
        {
            hfContactID.Value = "";
            txtName.Text = txtMobile.Text = txtAddress.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ContactID = hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value);
            contactModel.Create(ContactID, txtName.Text, txtMobile.Text, txtAddress.Text);
            // Clear form input values
            ClearForm();
            lblSuccessMessage.Text = "Update Successfuly.";
            contactFormDiv.Visible = false;
            // Update Gride view
            FillGridView();
        }
         
        protected void FillGridView( )
        {
            DataTable contactsData = new DataTable();
            // Get contact details from db
            contactsData = contactModel.GetAll();
            // Update gride view
            gvContact.DataSource = contactsData; 
            gvContact.DataBind();
            if((gvContact.DataSource as DataTable).Rows.Count == 0)
            {
                contactFormDiv.Visible = true;
                gridViewDiv.Visible = false;
            }
            else
            {
                contactFormDiv.Visible = false;
                gridViewDiv.Visible = true;
            }
        } 

        protected void link_View(object sender, EventArgs e)
        {
            gridViewDiv.Visible = false;
            contactFormDiv.Visible = true;

            // Get contact id
            int ContactID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            IDictionary<string, string> contactData = new Dictionary<string, string>();

            // Get contact details from db
            contactData = contactModel.GetByID(ContactID);

            // Selected record Assign to input fields
            hfContactID.Value = ContactID.ToString();
            txtName.Text = contactData["Name"];
            txtMobile.Text = contactData["Mobile"];
            txtAddress.Text = contactData["Address"];
            btnSave.Text = "Update";

            // Clean error messages
            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = ""; 
        }

        protected void link_Delete(object sender, EventArgs e)
        {
            int ContactID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            // Get contact details from db
            if (contactModel.DeleteByID(ContactID))
            {
                ClearForm();
                lblSuccessMessage.Text = "Deleted Successfuly.";
            }
        }

        protected void link_Create(object sender, EventArgs e)
        {
            contactFormDiv.Visible = true;
            gridViewDiv.Visible = false;
            ClearForm();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            contactFormDiv.Visible = false;
            gridViewDiv.Visible = true;
            ClearForm();
        }
    }
}