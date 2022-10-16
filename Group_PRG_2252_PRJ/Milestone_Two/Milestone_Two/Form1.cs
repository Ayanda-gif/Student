using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_Two
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        FileHandler fh = new FileHandler();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            ad.Username = txtUsername.Text;
            ad.Password = txtPassword.Text;
            List<Admin> data = fh.readAdmin();
            foreach (Admin admin in data)
            {
                if (ad.Username == admin.Username && ad.Password == admin.Password)
                {
                    this.Hide();
                    Main mf = new Main();
                    mf.Show();
                }
                else
                {
                    MessageBox.Show("User Not Found!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Admin newAdmin = new Admin();
            newAdmin.Username = txtUsername.Text;
            newAdmin.Password = txtPassword.Text;
            fh.writeNewAdmin(newAdmin);
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
