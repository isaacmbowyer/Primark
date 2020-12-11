using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Primark.Pages
{
    public class DBConnection
    {
        public string DbString()
        {
            string dbString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\source\repos\Primark\Primark\Data\Customer_Files.mdf;Integrated Security=True";  // Database Connection String goes here 
            return dbString;
        }
    }
}
