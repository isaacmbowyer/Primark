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
            string DbString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Isaac Bowyer\Desktop\Week-9B-Solution---Login_Session-master\Login_Session\Data\Login_Session.mdf;Integrated Security=True;Connect Timeout=30";  // Connect Data String to Login_Session.mdf
            return DbString;
        }
    }
}
