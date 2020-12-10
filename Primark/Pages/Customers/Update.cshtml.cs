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
    public class UpdateModel : PageModel
    { 
        
        [BindProperty]
        public Customer CusRec { get; set; }

        public IActionResult OnGet(int? id)
        {
            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\source\repos\Primark\Primark\Data\Customer_Database.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();



            CusRec = new Customer();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Customer WHERE Id = @ID";

                command.Parameters.AddWithValue("@ID", id);
                Console.WriteLine("The id : " + id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CusRec.Id = reader.GetInt32(0);
                    CusRec.CustomerID = reader.GetString(1);
                    CusRec.CustomerFName = reader.GetString(2);
                    CusRec.CustomerLName = reader.GetString(3);
                    CusRec.CustomerEmail = reader.GetString(4);
                    CusRec.CustomerAge = reader.GetInt32(5);
                    CusRec.CustomerTelephone = reader.GetString(6);

                }


            }

            conn.Close();

            return Page();

        }


        public IActionResult OnPost()
        {
            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\source\repos\Primark\Primark\Data\Customer_Database.mdf;Integrated Security=True";

        SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "UPDATE Customer SET CustomerId = @CusID, CustomerFName = @CusFName, CustomerLName = @CusLName, CustomerEmail = @CusEmail, CustomerAge = @CusAge, CustomerTelephone = @CusTel WHERE Id = @ID";

                command.Parameters.AddWithValue("@ID", CusRec.Id);
                command.Parameters.AddWithValue("@CusID", CusRec.CustomerID);
                command.Parameters.AddWithValue("@CusFName", CusRec.CustomerFName);
                command.Parameters.AddWithValue("@CusLName", CusRec.CustomerLName);
                command.Parameters.AddWithValue("@CusEmail", CusRec.CustomerEmail);
                command.Parameters.AddWithValue("@CusAge", CusRec.CustomerAge);
                command.Parameters.AddWithValue("@CusTel", CusRec.CustomerTelephone);

                command.ExecuteNonQuery();
            }

            conn.Close();

            return RedirectToPage("/Index");
        }
    }
}
