using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;

namespace Milestone_Two
{
    class ModuleHandler
    {
        DataAccess da = new DataAccess();
        public void AddModule(Module module)
        {
            string q = "INSERT Module(moduleCode,moduleName,description,youtubeLink)"+
                $"VALUES('{module.ModuleCode}','{module.ModuleName}','{module.ModuleDescription}','{module.Link}')";
            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con);  
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Module Added!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        public List<Module> GetModules()
        {
            string q = "SELECT * FROM Module";
            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con);
            List<Module> data = new List<Module>();
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        Module module = new Module();
                        module.ModuleCode = rdr.GetString(0);
                        module.ModuleName = rdr.GetString(1);
                        module.ModuleDescription = rdr.GetString(2);
                        module.Link= rdr.GetString(3);
                        data.Add(module);
                    }
                    else
                    {
                        MessageBox.Show("No modules found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return data;
        }
        public List<Module> SearchModule(string moduleCode)
        {
            string q = $"SELECT * FROM Module WHERE moduleCode = '{moduleCode}'";
            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con);
            List<Module> data = new List<Module>();
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        Module module = new Module();
                        module.ModuleCode = rdr.GetString(0);
                        module.ModuleName = rdr.GetString(1);
                        module.ModuleDescription = rdr.GetString(2);
                        module.Link = rdr.GetString(3);
                        data.Add(module);
                    }
                    else
                    {
                        MessageBox.Show("Module not found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return data;
        }
        public void UpdateModule(Module updateModule)
        {
            string q = "UPDATE Module SET " +
                $"moduleCode = '{updateModule.ModuleCode}'," +
                $"moduleName = '{updateModule.ModuleName}'," +
                $"description = '{updateModule.ModuleDescription}'," +
                $"youtubeLink = '{updateModule.Link}'" +
                $"WHERE moduleCode = '{updateModule.ModuleCode}'";
            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Module Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }
        public void DeleteModule(string moduleCode)
        {
            string q = $"DELETE FROM StudentModule WHERE moduleCode = '{moduleCode}'";
            string q1 = $"DELETE FROM Module WHERE moduleCode = '{moduleCode}'";

            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con);
            SqlCommand cmd1 = da.Command(q1, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Module Deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
