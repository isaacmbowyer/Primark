using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Primark.Models;

namespace Primark.Pages.ViewFile
{
    public class ViewModel : PageModel
    {

        public List<CustomerFile> FileRec { get; set; }
        public void OnGet()
        {
            DBConnection DBCon = new DBConnection();
            string DbString = DBCon.DbString();
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
                    rec.CustomerName = reader.GetString(1);
                    rec.FileName = reader.GetString(2);
                    FileRec.Add(rec);
                }
            }

        }
    }
}
