using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Primark.Models;

namespace Primark.Pages.Customers
{
    public class ViewModel : PageModel
    {
        [BindProperty]
        public List<Customer> CusRec { get; set; }

        public void OnGet()
        {
            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\source\repos\Primark\Primark\Data\Customer_Database.mdf;Integrated Security=True"; // Add database connection stirng 

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();


            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT * FROM Customer";

                SqlDataReader reader = command.ExecuteReader();

                CusRec = new List<Customer>();

                while (reader.Read())
                {
                    Customer record = new Customer();
                    record.Id = reader.GetInt32(0);
                    record.CustomerID = reader.GetString(1);
                    record.CustomerFName = reader.GetString(2);
                    record.CustomerLName = reader.GetString(3);
                    record.CustomerEmail = reader.GetString(4);
                    record.CustomerAge = reader.GetInt32(5);
                    record.CustomerTelephone= reader.GetString(6);

                    CusRec.Add(record);
                }

                // Call Close when done reading.
                reader.Close();


            }
        }
    }
}
