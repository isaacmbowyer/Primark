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

        public void OnGet()
        {
        }
        public IActionResult OnGet(int? id)
        {

            string DbConnection = "";  // Database conencition string goes here 

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();


            CusRec = new Customer();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Customer WHERE Id = @ID";

                command.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CusRec.Id = reader.GetInt32(0);
                    CusRec.CustomerID = reader.GetString(1);
                    CusRec.CustomerFirstName = reader.GetString(2);
                    CusRec.CustomerLastName = reader.GetString(3);
                    CusRec.CustomerEmail = reader.GetString(4);
                }


            }

            conn.Close();

            return Page();


        }



    }
}
