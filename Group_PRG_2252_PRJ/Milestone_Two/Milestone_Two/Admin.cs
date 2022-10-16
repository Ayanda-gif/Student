using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_Two
{
    class Admin
    {
        string username;
        string password;
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public Admin()
        {

        }

    }
}
