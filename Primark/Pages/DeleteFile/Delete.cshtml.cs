using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Primark.Models;

namespace Primark.Pages.DeleteFile
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public CustomerFile CusFileRec { get; set; }

        public readonly IWebHostEnvironment _env;

        //a constructor for the class
        public DeleteModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult OnGet(int? Id)
        {
            DBConnection DBCon = new DBConnection();
            string DbString = DBCon.DbString();
            SqlConnection conn = new SqlConnection(DbString);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT * FROM CustomerFile WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", Id);

                var reader = command.ExecuteReader();

                CusFileRec = new CustomerFile();
                while (reader.Read())
                {
                    CusFileRec.Id = reader.GetInt32(0);
                    CusFileRec.CustomerName = reader.GetString(1);
                    CusFileRec.FileName = reader.GetString(2);
                }

                Console.WriteLine("File name : " + CusFileRec.FileName);


            }

            return Page();
        }


        public IActionResult OnPost()
        {

            deletePicture(CusFileRec.Id, CusFileRec.FileName);
            return RedirectToPage("/ViewFile/View");
        }



        public void deletePicture(int Id, string FileName)
        {
            Console.WriteLine("Record Id : " + Id);
            Console.WriteLine("File Name : " + FileName);

            DBConnection DBCon = new DBConnection();
            string DbString = DBCon.DbString();
            SqlConnection conn = new SqlConnection(DbString);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"DELETE FROM CustomerFile WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", Id);

                command.ExecuteNonQuery();
            }
            Console.WriteLine(FileName);
            string RetrieveImage = Path.Combine(_env.WebRootPath, "Files", FileName);
            System.IO.File.Delete(RetrieveImage);
            Console.WriteLine("File has been deleted");


        }









    }
}
