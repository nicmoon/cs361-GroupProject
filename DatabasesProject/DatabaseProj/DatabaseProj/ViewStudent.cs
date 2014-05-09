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
            //populateAssessmentTree();
        }

        private void populateAssessmentTree()
        {
            TreeView assessmentTree = AssessmentTree;
            
            foreach(KeyValuePair<SemesterAssessment, ResultList> key in s.StudentAssessmentItems)
            {
                assessmentTree.Nodes.Add(key.Key.AssessmentItem.Name);
            }
            
        }
    }
}
