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
			}
			else
			{
				MessageBox.Show( "Adding failure.", "Error" );
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
            dg = dgStudentSearchResults;
            if (dg.Rows.Count > 0)
            {
                dg.Rows.Clear();
            }
            string emph;
            emph = cbEmphasis.SelectedText.Equals("None") ? "" : cbEmphasis.SelectedText;
            List<Student> students = Database.GetStudentLikeFirstAndLastNameAndEmphasis(txtFirstName.Text, txtLastName.Text, emph);
            
            foreach (Student s in students)
            {
                dg.Rows.Add(s.UniversityId, s.FirstName, s.MiddleName, s.LastName, s.Status, s.Emphasis.Id, s.Emphasis.Name, new Button { Text = "Edit" }.Text = "Edit");
                dg.CellClick += new DataGridViewCellEventHandler(dg_EventHandler);
            }
            
        }

        private void dg_EventHandler(object args, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            DataGridViewRow row = dg.Rows[rowIndex];
            //will do stuff wooohoooo
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }
    }
}
