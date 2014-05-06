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

        public HomeScreen()
        {
            InitializeComponent();
            Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width / 1.5), (int)(Screen.PrimaryScreen.Bounds.Height / 1.5));
			Database = new DbprojDatabase();
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
    }
}
