using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderClasses;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class CustomerDAL
    {
        public static List<Customers> CustomerList()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-698P2MHO\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT CustomerID, CompanyName FROM Customers", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customers> klanten = new List<Customers>();


            try
            {
                while (reader.Read())
                {
                    Customers klant = new Customers();
                    if (!reader.IsDBNull(0)) klant.customerId = reader.GetString(0);
                    if (!reader.IsDBNull(1)) klant.companyName = reader.GetString(1);
                    
                    klanten.Add(klant);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return klanten;
        }

        public void EditCustomer(Customers customer)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-698P2MHO\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("UPDATE Customers SET ContactName = @contactName, ContactTitle = @contactTitle WHERE customerID = @customerId", con);
            con.Open();
            cmd.Parameters.AddWithValue("@contactName", customer.contactName);
            cmd.Parameters.AddWithValue("@contactTitle", customer.contactTitle);
            cmd.Parameters.AddWithValue("@customerId", customer.customerId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<Customers> GetContactNames()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-698P2MHO\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT CompanyName, CustomerID FROM Customers", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customers> cnames = new List<Customers>();

            try
            {
                while (reader.Read())
                {
                    Customers customer = new Customers();
                    if (!reader.IsDBNull(0)) customer.customerId = reader.GetString(0);
                    if (!reader.IsDBNull(1)) customer.contactName = reader.GetString(1);
                    cnames.Add(customer);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return cnames;
        }

        public static string GetContactName(Customers customer)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-698P2MHO\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT ContactName FROM Customers WHERE customerID = @customerId", con);
            con.Open();
            cmd.Parameters.AddWithValue("@custoemrId", customer.customerId);
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {                  
                    if (!reader.IsDBNull(0)) customer.contactName = reader.GetString(0);                   
                }
                reader.Close();
            }
           
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return customer.contactName;
        }

        public static string GetContactTitle(Customers customer)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-698P2MHO\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT ContactTitle FROM Customers WHERE CustomerID = @customerId", con);
            con.Open();
            cmd.Parameters.AddWithValue("@customerId", customer.customerId);
            SqlDataReader reader = cmd.ExecuteReader();
            

            try
            {
                while (reader.Read())
                {                    
                    if (!reader.IsDBNull(0)) customer.contactTitle = reader.GetString(0);                    
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return customer.contactTitle;
        }

        public static List<Customers> GetCustomerDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-698P2MHO\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City FROM Customers", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customers> customers = new List<Customers>();

            try
            {
                while(reader.Read())
                {
                    Customers customer = new Customers();
                    if (!reader.IsDBNull(0)) customer.customerId = reader.GetString(0);
                    if (!reader.IsDBNull(1)) customer.companyName = reader.GetString(1);
                    if (!reader.IsDBNull(2)) customer.contactName = reader.GetString(2);
                    if (!reader.IsDBNull(3)) customer.contactTitle = reader.GetString(3);
                    if (!reader.IsDBNull(4)) customer.address = reader.GetString(4);
                    if (!reader.IsDBNull(5)) customer.city = reader.GetString(5);
                    customers.Add(customer);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return customers;
        }

        public static List<Orders> GetOrders(Customers customer)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-698P2MHO\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT OrderID, OrderDate, RequiredDate, ShippedDate FROM Orders WHERE CustomerID = @customerID", con);
            
            cmd.Parameters.AddWithValue("@customerID", customer.customerId);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Orders> factuur = new List<Orders>();
            

            try
            {
                while (reader.Read())
                {
                    Orders bestelling = new Orders();
                    if (!reader.IsDBNull(0)) bestelling.orderId = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) bestelling.orderDate = reader.GetDateTime(1);
                    if (!reader.IsDBNull(2)) bestelling.requiredDate = reader.GetDateTime(2);
                    if (!reader.IsDBNull(3)) bestelling.shippedDate = reader.GetDateTime(3);

                    factuur.Add(bestelling);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return factuur;
        }
    }

}
