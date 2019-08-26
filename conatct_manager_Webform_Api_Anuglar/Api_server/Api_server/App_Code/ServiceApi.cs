using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using ContactsApi.Models;
using System.Web.Script.Services;

/// <summary>
/// Summary description for ServiceApi
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ServiceApi : System.Web.Services.WebService
{  
    ContactModel contactM = new ContactModel();
    JavaScriptSerializer js = new JavaScriptSerializer();
     

    //for getPolicyBenefiLimitsDetails
    [WebMethod]
    [ScriptMethod(UseHttpGet = false)]
    public void contacts()
    {
        List<Contact> contactList = new List<Contact>();
        DataSet contactsDs = contactM.getAll();
        foreach (DataRow r in contactsDs.Tables[0].Rows)
        {
            Contact contact = new Contact();
            contact.id = (int) r["id"];
            contact.name = r["name"].ToString();
            contact.mobile = r["mobile"].ToString();
            contact.email = r["email"].ToString();
            contactList.Add(contact);
        } 

        Context.Response.Write(js.Serialize(contactList));
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false)]
    public void contact(int id)
    {
        DataSet contactsDataset = contactM.getByID(id);

        Dictionary<String, String> contact = new Dictionary<String, String>();

        contact.Add("id", contactsDataset.Tables[0].Rows[0]["id"].ToString());
        contact.Add("name", contactsDataset.Tables[0].Rows[0]["name"].ToString());
        contact.Add("mobile", contactsDataset.Tables[0].Rows[0]["mobile"].ToString());
        contact.Add("email", contactsDataset.Tables[0].Rows[0]["email"].ToString());

        Context.Response.Write(js.Serialize(contact)); 
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false)]
    public void updateAndCreate(int id, string name, string email, string mobile)
    {
        Contact newContact = new Contact();

        newContact.id = id;
        newContact.name = name.Trim();
        newContact.email = email.Trim();
        newContact.mobile = mobile.Trim();

        if (contactM.createOrUpdate(newContact))
        {
            Context.Response.Write(js.Serialize("update_done"));
        }
        else
        {
            Context.Response.Write(js.Serialize("update_error"));
        }

        
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = false)]
    public void contactDeleteById(int id)
    { 
        if (contactM.deleteByID(id))
        {
            Context.Response.Write(js.Serialize("delete_done"));
        }
        else
        {
            Context.Response.Write(js.Serialize("delete_error"));
        }
        
    }
     
}
