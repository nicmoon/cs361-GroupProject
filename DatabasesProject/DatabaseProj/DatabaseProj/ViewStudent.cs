using Infrastructure.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProj
{
    public partial class ViewStudent : Form
    {
        private Student s;
        public ViewStudent(Student stud)
        {
            InitializeComponent();
            s = stud;
            populateAssessmentTree();
            txtFirstName.Text = s.FirstName;
            txtMiddleName.Text = s.MiddleName;
            txtLastName.Text = s.LastName;
            txtStatus.Text = s.Status.ToString();
            txtEmphasis.Text = s.Emphasis.Name;
        }

        private void populateAssessmentTree()
        {
            TreeView assessmentTree = AssessmentTree;
            
            foreach(KeyValuePair<SemesterAssessment, ResultList> key in s.StudentAssessmentItems)
            {
                TreeNode node = assessmentTree.Nodes.Add(key.Key.AssessmentItem.Name);

                foreach(int score in key.Value.Scores)
                {
                    if(key.Value.FacultyName.Equals(""))
                    {
                        key.Value.FacultyName = "N/A";
                    }
                    node.Nodes.Add(key.Value.FacultyName + " - " + score);
                }
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
