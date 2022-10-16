using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Milestone_Two
{
    class StudentHandler
    {
        DataAccess da = new DataAccess();
        public void AddStudent(Student s)
        {
            string q = "INSERT Student(studentName,studentSurname,dob,gender,phone,address)"+
                $"VALUES('{s.Name}','{s.Surname}','{s.Dob}','{s.Gender}','{s.Phone}','{s.Address}')";
            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con); 
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Added!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in the StudentHandler"+e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        public List<Student> GetStudents()
        {
            string q = "SELECT * FROM Student";
            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con); 
            List<Student> data = new List<Student>();
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        byte[] temp = new byte[0];
                        Student student = new Student();
                        student.StudentNumber = rdr.GetInt32(0);
                        student.Name = rdr.GetString(1);
                        student.Surname = rdr.GetString(2);
                        student.StudentImage = (rdr.IsDBNull(3))? temp : (byte[])rdr[3];
                        student.Dob = rdr.GetDateTime(4);
                        student.Gender = rdr.GetString(5);
                        student.Phone = rdr.GetString(6);
                        student.Address = rdr.GetString(7);
                        data.Add(student);

                    }
                    else
                    {
                        MessageBox.Show("No students found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public List<Student> SearchStudent(int studentNumber)
        {
            string q = $"SELECT * FROM Student WHERE studentNumber = {studentNumber}";
            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con);
            List<Student> data = new List<Student>();
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        byte[] temp = new byte[0];
                        Student student = new Student();
                        student.StudentNumber = rdr.GetInt32(0);
                        student.Name = rdr.GetString(1);
                        student.Surname = rdr.GetString(2);
                        student.StudentImage = (rdr.IsDBNull(3)) ? temp : (byte[])rdr[3];
                        student.Dob = rdr.GetDateTime(4);
                        student.Gender = rdr.GetString(5);
                        student.Phone = rdr.GetString(6);
                        student.Address = rdr.GetString(7);
                        data.Add(student);

                    }
                    else
                    {
                        MessageBox.Show("Student not found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void UpdateStudent(Student updateStudent)
        {
            string q = "UPDATE Student SET "+
                $" studentName = '{updateStudent.Name}',"+
                $" studentSurname = '{updateStudent.Surname}',"+
                $" dob = '{updateStudent.Dob}',"+
                $" gender = '{updateStudent.Gender}',"+
                $" phone = '{updateStudent.Phone}',"+
                $" address = '{updateStudent.Address}'"+
                $" WHERE studentNumber = {updateStudent.StudentNumber}";
            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con);
            
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void DeleteStudent(int studentNumber)
        {
            string q = $"DELETE FROM StudentModule WHERE StudentNumber = {studentNumber}";
            string q1 = $"DELETE FROM Student WHERE StudentNumber = {studentNumber}";
            
            SqlConnection con = da.Connection();
            SqlCommand cmd = da.Command(q, con);
            SqlCommand cmd1 = da.Command(q1, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Student Deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
