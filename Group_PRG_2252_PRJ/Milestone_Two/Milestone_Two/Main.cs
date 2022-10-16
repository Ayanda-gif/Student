using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_Two
{
    public partial class Main : Form
    {
        StudentHandler sh = new StudentHandler();
        BindingSource bs = new BindingSource();
        public Main()
        {
            InitializeComponent();
            bs.DataSource = sh.GetStudents();
            dgvViewStudents.DataSource = bs;
            
        }
       
        private void btnViewAllStudents_Click(object sender, EventArgs e)
        {
           
            try
            {
                bs.DataSource = sh.GetStudents();
                dgvViewStudents.DataSource = bs;
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int studentNumber = int.Parse(txtSearchDeleteStudent.Text);
                sh.DeleteStudent(studentNumber);
                bs.DataSource = sh.GetStudents();
                dgvViewStudents.DataSource = bs;
                txtSearchDeleteStudent.Clear();            }
            catch (Exception x)
            {

                MessageBox.Show("Enter a numeric value" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowNo = e.RowIndex;
                DataGridViewRow dgvr = dgvViewStudents.Rows[rowNo];

                //Update student groupbox fields
                txtUpdateStudentNumber.Text = dgvr.Cells["StudentNumber"].Value.ToString();
                txtUpdateStudentName.Text = dgvr.Cells["Name"].Value.ToString();
                txtUpdateSurname.Text = dgvr.Cells["Surname"].Value.ToString();
                //pbUpdateImage.Image = (Image)dgvr.Cells["StudentImage"].Value;
                dtpUpdateDOB.Text = dgvr.Cells["Dob"].Value.ToString();
                cmbUpdateGender.Text = dgvr.Cells["Gender"].Value.ToString();
                txtUpdatePhone.Text = dgvr.Cells["Phone"].Value.ToString();
                txtUpdateAddress.Text = dgvr.Cells["Address"].Value.ToString();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int studentNumber = int.Parse(txtSearchDeleteStudent.Text);
                bs.DataSource = sh.SearchStudent(studentNumber);
                dgvViewStudents.DataSource = bs;
            }
            catch (Exception x)
            {

                MessageBox.Show("Enter a numeric value"+x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                Student updateStudent = new Student();
                updateStudent.StudentNumber = int.Parse(txtUpdateStudentNumber.Text);
                updateStudent.Name = txtUpdateStudentName.Text;
                updateStudent.Surname = txtUpdateSurname.Text;
                //pbUpdateImage.Image = (Image)dgvr.Cells["StudentImage"].Value;
                updateStudent.Dob = (DateTime)dtpUpdateDOB.Value;
                updateStudent.Gender = cmbUpdateGender.Text;
                updateStudent.Phone = txtUpdatePhone.Text;
                updateStudent.Address = txtUpdateAddress.Text;

                sh.UpdateStudent(updateStudent);

                txtUpdateStudentNumber.Clear();
                txtUpdateStudentName.Clear();
                txtUpdateSurname.Clear();
                cmbUpdateGender.ResetText();
                txtUpdatePhone.Clear();
                txtUpdateAddress.Clear();
                bs.DataSource = sh.GetStudents();
                dgvViewStudents.DataSource = bs;
            }
            catch (Exception x)
            {

                MessageBox.Show("Data must be in correct format" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                Student addStudent = new Student();
                addStudent.Name = txtStudentName.Text;
                addStudent.Surname = txtSurname.Text;
                //pbUpdateImage.Image = (Image)dgvr.Cells["StudentImage"].Value;
                addStudent.Dob = (DateTime)dtpDOB.Value;
                addStudent.Gender = cmbGender.Text;
                addStudent.Phone = txtPhone.Text;
                addStudent.Address = txtAddress.Text;

                sh.AddStudent(addStudent);

                txtStudentNumber.Clear();
                txtStudentName.Clear();
                txtSurname.Clear();
                cmbGender.ResetText();
                txtPhone.Clear();
                txtAddress.Clear();
                bs.DataSource = sh.GetStudents();
                dgvViewStudents.DataSource = bs;
            }
            catch (Exception x)
            {
                MessageBox.Show("Data must be in correct format" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        ModuleHandler mh = new ModuleHandler();
        private void btnAddModule_Click(object sender, EventArgs e)
        {
            try
            {
                Module module = new Module();
                module.ModuleCode = txtModuleCode.Text;
                module.ModuleName = txtModuleName.Text;
                module.ModuleDescription = txtDescription.Text;
                module.Link = txtYoutubeLink.Text;

                mh.AddModule(module);

                foreach (Module mod in mh.GetModules())
                {
                    ListViewItem lvi = new ListViewItem(mod.ModuleCode);
                    lvi.SubItems.Add(mod.ModuleName);
                    lvi.SubItems.Add(mod.ModuleDescription);
                    lvi.SubItems.Add(mod.Link);
                    lstModules.Items.Add(lvi);

                }

                txtModuleCode.Clear();
                txtModuleName.Clear();
                txtDescription.Clear();
                txtYoutubeLink.Clear();
            }
            catch (Exception x)
            {
                MessageBox.Show("Data must be in correct format" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnUpdateModule_Click(object sender, EventArgs e)
        {
            try
            {
                Module updateModule = new Module();
                updateModule.ModuleCode = txtUpdateModuleCode.Text;
                updateModule.ModuleName = txtUpdateModuleName.Text;
                updateModule.ModuleDescription = txtUpdateDescription.Text;
                updateModule.Link = txtUpdateyoutubeLink.Text;
                mh.UpdateModule(updateModule);
                lstModules.Items.Clear();
                foreach (Module module in mh.GetModules())
                {
                    ListViewItem lvi = new ListViewItem(module.ModuleCode);
                    lvi.SubItems.Add(module.ModuleName);
                    lvi.SubItems.Add(module.ModuleDescription);
                    lvi.SubItems.Add(module.Link);
                    lstModules.Items.Add(lvi);

                }
                txtUpdateModuleCode.Clear();
                txtUpdateModuleName.Clear();
                txtUpdateDescription.Clear();
                txtUpdateyoutubeLink.Clear();
            }
            catch (Exception x)
            {
                MessageBox.Show("Data must be in correct format" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAllModules_Click(object sender, EventArgs e)
        {
            try
            {
                lstModules.Items.Clear();
                foreach (Module module in mh.GetModules())
                {
                    ListViewItem lvi = new ListViewItem(module.ModuleCode);
                    lvi.SubItems.Add(module.ModuleName);
                    lvi.SubItems.Add(module.ModuleDescription);
                    lvi.SubItems.Add(module.Link);
                    lstModules.Items.Add(lvi);

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Data must be in correct format" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string moduleCode = txtSearchDeleteModule.Text;
                mh.DeleteModule(moduleCode);
                lstModules.Items.Clear();
                foreach (Module module in mh.GetModules())
                {
                    ListViewItem lvi = new ListViewItem(module.ModuleCode);
                    lvi.SubItems.Add(module.ModuleName);
                    lvi.SubItems.Add(module.ModuleDescription);
                    lvi.SubItems.Add(module.Link);
                    lstModules.Items.Add(lvi);

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Data must be in correct format" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSearchModule_Click(object sender, EventArgs e)
        {
            try
            {
                lstModules.Items.Clear();
                string moduleCode = txtSearchDeleteModule.Text;
                foreach (Module module in mh.SearchModule(moduleCode))
                {
                    ListViewItem lvi = new ListViewItem(module.ModuleCode);
                    lvi.SubItems.Add(module.ModuleName);
                    lvi.SubItems.Add(module.ModuleDescription);
                    lvi.SubItems.Add(module.Link);
                    lstModules.Items.Add(lvi);

                }
                txtSearchDeleteModule.Clear();
            }
            catch (Exception x)
            {
                MessageBox.Show("Data must be in correct format" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstModules.SelectedItems.Count > 0)
            {
                
                ListViewItem lvi = lstModules.SelectedItems[0];
                txtUpdateModuleCode.Text = lvi.SubItems[0].Text;
                txtUpdateModuleName.Text = lvi.SubItems[1].Text;
                txtUpdateDescription.Text = lvi.SubItems[2].Text;
                txtUpdateyoutubeLink.Text = lvi.SubItems[3].Text;
            }
        }
    }
}
