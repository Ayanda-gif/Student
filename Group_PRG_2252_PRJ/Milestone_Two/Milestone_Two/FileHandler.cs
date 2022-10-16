using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Milestone_Two
{
    class FileHandler
    {
        string folder = @"C:\adminData";
        StreamWriter sw;
        public void writeNewAdmin(Admin newAdmin)
        {
            if(newAdmin.Username.Length == 0 || newAdmin.Password.Length == 0)
            {
                MessageBox.Show("Enter username and password", "Caution", MessageBoxButtons.OK);
            }
            else
            {
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string file = Path.Combine(folder, "admin.txt");
                using (sw = File.AppendText(file))
                {
                    string username = newAdmin.Username;
                    string password = newAdmin.Password;
                    string up = username + ' ' + password;
                    sw.WriteLine(up);
                    MessageBox.Show("User registred successfully!", "Alert", MessageBoxButtons.OK);

                }
            }   
        }
        public List<Admin> readAdmin()
        {
            List<Admin> data = new List<Admin>();
            try
            {
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string file = Path.Combine(folder, "admin.txt");
                bool found = false;
                if (File.Exists(file))
                {
                    string[] readAdmin = File.ReadAllLines(file);
                    foreach (string admin in readAdmin)
                    {
                        found = true;
                        Admin ad = new Admin();
                        string[] temp = admin.Split(' ');
                        ad.Username = temp[0];
                        ad.Password = temp[1];
                        data.Add(ad);
                    }
                }
                if (!found)
                {
                    throw new UnregisteredAdminException();
                }
            }
            catch (UnregisteredAdminException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.RetryCancel);
            } 
            return data;
        }
    }
}
