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
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Customer CustomerRec { get; set; }

        public IActionResult OnGet(int? id)
        {

            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\source\repos\Primark\Primark\Data\Customer_Database.mdf;Integrated Security=True";  

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Customer WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = command.ExecuteReader();
                CustomerRec = new Customer();
                while (reader.Read())
                {
                    CustomerRec.Id = reader.GetInt32(0);
                    CustomerRec.CustomerID = reader.GetString(1);
                    CustomerRec.CustomerFName = reader.GetString(2);
                    CustomerRec.CustomerLName = reader.GetString(3);
                    CustomerRec.CustomerEmail = reader.GetString(4);
                    CustomerRec.CustomerAge = reader.GetInt32(5);
                    CustomerRec.CustomerTelephone = reader.GetString(6);


                }
            }
                conn.Close();

                return Page();
            
        }

        public IActionResult OnPost()
        {
            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\source\repos\Primark\Primark\Data\Customer_Database.mdf;Integrated Security=True"; // Datbase connection string 

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "DELETE Customer WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", CustomerRec.Id);
                command.ExecuteNonQuery();
            }

            conn.Close();
            return RedirectToPage("/Index");
        }




    }
}
