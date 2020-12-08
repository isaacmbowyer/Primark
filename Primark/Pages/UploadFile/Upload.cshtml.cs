using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Primark.Models;

namespace Primark.Pages.UploadFile
{
    public class UploadModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public IFormFile CusFile { get; set; }

        [BindProperty(SupportsGet = true)]
        public CustomerFile CusFileRec { get; set; }

        public readonly IWebHostEnvironment _env;

        //a constructor for the class
        public UploadModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            var FileToUpload = Path.Combine(_env.WebRootPath, "Files", CusFile.FileName);//this variable consists of file path
            Console.WriteLine("File Name : " + FileToUpload);



            using (var FStream = new FileStream(FileToUpload, FileMode.Create))
            {
                CusFile.CopyTo(FStream);//copy the file into FStream variable
            }

            DBConnection DBCon = new DBConnection();
            string DbString = DBCon.DbString();
            SqlConnection conn = new SqlConnection(DbString);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"INSERT CustomerFile (CustomerName, FileName) VALUES (@CusName, @FName)";
                command.Parameters.AddWithValue("@CusName", CusFileRec.CustomerName);
                command.Parameters.AddWithValue("@FName", CusFile.FileName);
                Console.WriteLine("File name : " + CusFileRec.CustomerName);
                Console.WriteLine("File name : " + CusFile.FileName);
                command.ExecuteNonQuery();
            }



            return RedirectToPage("/index");
        }

    


    }
}
