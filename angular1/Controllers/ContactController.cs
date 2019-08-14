using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using angular1.Models;
using System.Data;

namespace angular1.Controllers
{
    [Route("api/[controller]")] 
    public class ContactController : Controller
    {
        ContactModel contactM = new ContactModel();
          
        // GET: api/Contact
        [HttpGet]
        public List<Dictionary<String, String>> Get()
        {
            DataSet contactsDataset = contactM.getAll();

            List<Dictionary<String, String>> tableRows = new List<Dictionary<String, String>>();
            Dictionary<String, String> row;
            if (contactsDataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in contactsDataset.Tables[0].Rows)
                {
                    row = new Dictionary<String, String>();
                    foreach (DataColumn col in contactsDataset.Tables[0].Columns)
                    {
                        row.Add(col.ColumnName, dr[col].ToString());
                    }
                    tableRows.Add(row);
                }
            }
            else
            {
                row = new Dictionary<String, String>();
                row.Add("data", "Nod");
                tableRows.Add(row);
            }
            return tableRows;
        }

        // GET: api/Contact/5
        [HttpGet("{id}", Name = "Get")]
        public Dictionary<String, String> Get(int id)
        {
            System.Diagnostics.Debug.WriteLine("madhuranga id", id);
            DataSet contactsDataset = contactM.getByID(id);
            Dictionary<String, String> contact = new Dictionary<String, String>();
            contact.Add("id", contactsDataset.Tables[0].Rows[0]["id"].ToString());
            contact.Add("name", contactsDataset.Tables[0].Rows[0]["name"].ToString());
            contact.Add("mobile", contactsDataset.Tables[0].Rows[0]["mobile"].ToString());
            contact.Add("email", contactsDataset.Tables[0].Rows[0]["email"].ToString());
            return contact;
        }

        // POST: api/Contact
        [HttpPost]
        public Boolean Post([FromBody] Contact newContact)
        {
            return contactM.create(newContact);
        }

        // PUT: api/Contact/5
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody] Contact updateContact)
        {
            System.Diagnostics.Debug.WriteLine("madhuranga id", id);
            return contactM.update(updateContact);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            return contactM.deleteByID(id);
        } 
    }
} 