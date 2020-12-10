using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Primark.Pages.DatabaseConnection
{
    public class DatabaseConnect
    {
        public string DatabaseString()
        {
            string DbString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\source\repos\Primark\Primark\Data\Login_Session.mdf;Integrated Security=Truee";  // Connect Data String to Login_Session.mdf
            return DbString;
        }
    }
}
