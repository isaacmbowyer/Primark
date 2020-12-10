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
            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\source\repos\Primark\Primark\Data\Customer_Database.mdf;Integrated Security=True";  

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"INSERT INTO Customer (CustomerID, CustomerFName, CustomerLname, CustomerEmail, CustomerAge, CustomerTelephone) VALUES (@CID, @CFName, @CLName, @CEmail, @CAge, @CTel)";

                command.Parameters.AddWithValue("@CID", CusRec.CustomerID);
                command.Parameters.AddWithValue("@CFName", CusRec.CustomerFName);
                command.Parameters.AddWithValue("@CLName", CusRec.CustomerLName);
                command.Parameters.AddWithValue("@CEmail", CusRec.CustomerEmail);
                command.Parameters.AddWithValue("@CAge", CusRec.CustomerAge);
                command.Parameters.AddWithValue("@CTel", CusRec.CustomerTelephone);

                command.ExecuteNonQuery();
            }



            return RedirectToPage("/Index");
        }
    }
}
