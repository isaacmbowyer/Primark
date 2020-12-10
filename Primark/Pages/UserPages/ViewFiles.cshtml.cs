using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Primark.Models;

namespace Primark.Pages.UserPages
{
    public class ViewFilesModel : PageModel
    {

        public List<CustomerFile> FileRec { get; set; }
        public void OnGet()
        {
            //DBConnection DBCon = new DBConnection();
            string DbString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\source\repos\Primark\Primark\Data\Customer_Files.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(DbString);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT * FROM CustomerFile";

                var reader = command.ExecuteReader();

                FileRec = new List<CustomerFile>();

                while (reader.Read())
                {
                    CustomerFile rec = new CustomerFile();
                    rec.Id = reader.GetInt32(0);
                    rec.CustomerFName = reader.GetString(1);
                    rec.CustomerLName = reader.GetString(2);
                    rec.FileName = reader.GetString(3);
                    FileRec.Add(rec);
                }
            }

        }
    }
}
