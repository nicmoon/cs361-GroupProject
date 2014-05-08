using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infrastructure.Classes;
using Infrastructure.Database;

namespace DatabaseProj
{
    public partial class HomeScreen : Form
    {
		public DbprojDatabase Database { get; set; }
        private DataGridView dg;
        public HomeScreen()
        {
            InitializeComponent();
			Database = new DbprojDatabase();
            cbEmphasis.SelectedIndex = 0;
            CenterToScreen();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
        }

		private void tsmiStudent_Click(object sender, EventArgs e)
		{
			Student student = FrmAddStudent.ShowAndReturnObject();
			if (student != null && Database.InsertStudent( student ))
			{
				// go to db
				MessageBox.Show( "Successfully added the student.", "Success" );
                if (!cbEmphasis.SelectedItem.ToString().Equals("None"))
                {
                    populateDataGridView();
                }
			}
			else if (student != null)
			{
				MessageBox.Show( "Adding student failure.", "Error" );
			}
           
		}

		private void tsmiAddCriteria_Click(object sender, EventArgs e)
		{
			Criteria crit  = FrmAddCriteria.ShowAndReturnObject();
			if (crit != null && Database.InsertCriteria(crit))
			{
				// go to db
				MessageBox.Show("Successfully added the criteria.", "Success");
			}
			else if (crit != null)
			{
				MessageBox.Show("Adding criteria failure.", "Error");
			}
		}

		private void tsmiAddAssessmentItem_Click(object sender, EventArgs e)
		{
			AssessmentItem ai = FrmAddAssessmentItem.ShowAndReturnObject( Database.GetAllCriteria() );
			if (ai != null /*&& Database.InsertCriteria(crit)*/)
			{
				// go to db
				MessageBox.Show("Successfully added the criteria.", "Success");
			}
			else /*if (ai != null)*/
			{
				MessageBox.Show("Adding criteria failure.", "Error");
			}
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            cbEmphasis.SelectedIndex = 0;
            dg.Rows.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            populateDataGridView();
        }

        private void populateDataGridView()
        {
            dg = dgStudentSearchResults;
            if (dg.Rows.Count > 0)
            {
                dg.RowCount = 0;
            }
            string emph = cbEmphasis.SelectedItem.ToString().Equals("All") ? "" : cbEmphasis.SelectedItem.ToString();
            List<Student> students = Database.GetStudentLikeFirstAndLastNameAndEmphasis(txtFirstName.Text, txtLastName.Text, emph);

            foreach (Student s in students)
            {
                dg.Rows.Add(s.UniversityId, s.FirstName, s.MiddleName, s.LastName, s.Status, s.Emphasis.Id, s.Emphasis.Name, new Button { Text = "Edit" }.Text = "Edit");
                dg.CellClick += dg_EventHandler;
            }
        }

        private void dg_EventHandler(object args, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dg.Rows[rowIndex];
            //edit button
            if (colIndex == 7)
            {
                Student s = EditStudent.ShowAndReturnObject(new Student 
                { 
                    UniversityId = (int)row.Cells[0].Value,
                    FirstName = (string)row.Cells[1].Value, 
                    MiddleName = (string)row.Cells[2].Value, 
                    LastName = (string)row.Cells[3].Value,                      
                    Status = (Status)row.Cells[4].Value, 
                    Emphasis = new Emphasis 
                    { 
                        Id = (int)row.Cells[5].Value 
                    } 
                });
                    bool success = Database.UpdateStudent(s);
                if (!success)
                {
                    MessageBox.Show("An error occurred while updating student " + s.FirstName + " " + s.LastName +
                                    ".", "Error");
                }
            }
        }

		private void tsmiExit_Click(object sender, EventArgs e)
		{
			Dispose();
			Application.Exit();
		}
    }
}
