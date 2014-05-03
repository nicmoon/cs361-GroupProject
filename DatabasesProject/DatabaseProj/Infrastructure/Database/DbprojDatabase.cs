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
                return this.RunProcedure<Student>("GetStudentIdByFirstAndLastName", new { firstName, lastName }).First();
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

        public List<CriteriaResult> AllScoresForStudent(int studentId)
        {
            try
            {
                return this.RunProcedure<CriteriaResult>("AllScoresForStudent", new { studentId }).ToList();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public Student GetStudentInfoByFirstAndLastName(string firstName, string lastName)
        {
            try
            {
                IEnumerable<dynamic> rows = this.RunProcedure<dynamic>("GetStudentInfoByFirstAndLastName", new { firstName, lastName });
                //just up and running to pass a unit test, will make better later.
                Student s = new Student();
                s.AssessmentItems = new List<AssessmentItem>();
                foreach (dynamic row in rows)
                {
                    s.UniversityId = row.UniversityId;
                    s.FirstName = row.FirstName;
                    s.LastName = row.LastName;
                    s.MiddleName = row.MiddleName;
                    s.Status = (Status)row.Status;
                    s.Emphasis = new Emphasis
                    {
                        Id = row.EmphasisId,
                        Name = row.EmphasisName
                    };
                    s.AssessmentItems.Add(new AssessmentItem
                    {
                        Id = row.AssessmentId,
                        Name = row.AssessmentName
                    });
                }

                return s;
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public List<AssessmentItem> AssessmetAverageMaxMinByEmhpasis()
        {
            try
            {
                return this.RunProcedure<AssessmentItem>("AssessmentAverageMaxMinByEmphasis", new {}).ToList();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public AssessmentItem GetMinMaxAvgForStudent(int studentId)
        {
            try
            {
                return this.RunProcedure<AssessmentItem>("MaxMinAvgForStudent", new { studentId }).FirstOrDefault();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public List<AssessmentItem> GetAllScoresForStudent(int studentId)
        {
            try
            {
                return this.RunProcedure<AssessmentItem>("AllScoresForStudent", new { studentId }).ToList();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        //public List<AssessmentItem>GetAllScoresForStudentByFirstAndLastName(string firstName, string lastName)
        //{
        //    try
        //    {
        //        return this.RunProcedure<AssessmentItem>("AllScoresForStudentByFirstAndLastName", new { firstName, lastName }).ToList();
        //    }
        //    catch(SqlException e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
