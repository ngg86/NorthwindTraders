using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using TraderClasses;


namespace NorthwindTraders
{
    public partial class CustomersAndOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropBox();
            }
        }

        private void LoadDropBox()
        {
            ddlCompName.DataSource = CustomerDAL.CustomerList();
            ddlCompName.DataValueField = "customerId";
            ddlCompName.DataTextField = "companyName";
            ddlCompName.DataBind();
        }

        protected void ddlCompName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customers customer = new Customers();
            customer.customerId = ddlCompName.SelectedValue;
            
            gvCustomerOrders.DataSource = CustomerDAL.GetOrders(customer);
            gvCustomerOrders.DataBind();
            gvCustomerOrders.Visible = true;
        }
    }
}