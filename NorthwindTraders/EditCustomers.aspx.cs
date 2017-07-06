using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using TraderClasses;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class EditCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadFields();
            }
        }

        private void LoadFields()
        {
            ddlCustomers.DataSource = CustomerDAL.GetContactNames();
            ddlCustomers.DataBind();
            
            gvCustomers.DataSource = CustomerDAL.GetCustomerDetails();
            gvCustomers.DataBind();
        }

        protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customers customer = new Customers();
            customer.customerId = ddlCustomers.SelectedValue;
            tbContactName.Text = CustomerDAL.GetContactName(customer);
            tbContactTitle.Text = CustomerDAL.GetContactTitle(customer);
            
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Customers customer = new Customers();
            if (tbContactName.Text != null && tbContactTitle.Text != null)
            {
                customer.contactName = tbContactName.Text;
                customer.contactTitle = tbContactTitle.Text;
            }
            else
            {
                MessageBox.Show("Velden mogen niet leeg zijn.");
            }
            CustomerDAL.EditCustomer(customer);
        }
    }
}