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
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Customer CusRec { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zairu\source\repos\Week8A\DatabaseConnection1\Data\DatabaseConnection1.mdf;Integrated Security=True;Connect Timeout=30";  // Replace with DB with connection string 

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"INSERT INTO Customer (CustomerID, CustomerFirstName, CustomerLastLevel, CustomerEmail) VALUES (@CID, @CFName, @CLName, @CEmail)";

                command.Parameters.AddWithValue("@CID", CusRec.CustomerID);
                command.Parameters.AddWithValue("@CFName", CusRec.CustomerFirstName);
                command.Parameters.AddWithValue("@CLName", CusRec.CustomerLastName);
                command.Parameters.AddWithValue("@CEmail", CusRec.CustomerEmail);

                command.ExecuteNonQuery();
            }



            return RedirectToPage("/Index");
        }
    }
}
