using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DynamicMySQLDb;
using Infrastructure.Classes;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Infrastructure.Database
{
    public class DbprojDatabase : MySQLDynamicDb
    {
        public Student GetStudentByFirstAndLastName(string firstName, string lastName)
        {
            try
            {
                return this.RunProcedure<Student>("GetStudentIdByFirstNameAndLastName", new { firstName, lastName }).First();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public List<CriteriaResult> AssessmentSemesterAverageByCriteria(int assessmentId, int semesterId)
        {
            try
            {
                return this.RunProcedure<CriteriaResult>("AssessmentSemesterAverageByCriteria", new { assessment = assessmentId, semester = semesterId }).ToList();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        //public List<AssessmentItem> AssessmetAverageMaxMinByEmhpasis()
        //{

        //}
    }
}
