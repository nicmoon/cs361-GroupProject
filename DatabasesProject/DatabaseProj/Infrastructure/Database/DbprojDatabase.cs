using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DynamicMySQLDb;
using Infrastructure.Classes;
using System.Data.SqlClient;
namespace Infrastructure.Database
{
    public class DbprojDatabase : MySQLDynamicDb
    {
        public Student GetStudentByFirstAndLastName(string firstName, string lastName)
        {
            try
            {
                return RunProcedure<Student>("GetStudentIdByFirstAndLastName", new { firstName, lastName }).First();
            }
            catch(SqlException e)
            {
                throw;
            }
        }

        public List<CriteriaResult> AssessmentSemesterAverageByCriteria(int assessmentId, int semesterId)
        {
            try
            {
                return RunProcedure<CriteriaResult>("AssessmentSemesterAverageByCriteria", new { assessment = assessmentId, semester = semesterId }).ToList();
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

        public List<CriteriaResult> AllScoresForStudent(int studentId)
        {
            try
            {
                return RunProcedure<CriteriaResult>("AllScoresForStudent", new { studentId }).ToList();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public List<Student> GetStudentLikeFirstAndLastNameAndEmphasis(string firstName, string lastName,
                                                                       string emphasis)
        {
            try
            {
                List<Student> students = new List<Student>();
                IEnumerable<dynamic> rows = this.RunProcedure<dynamic>("GetStudentsLikeFirstAndLastName",
                                                                       new {firstName, lastName, emphasis});
                foreach (dynamic row in rows)
                {
                    students.Add(new Student
                    {
                        UniversityId = row.UniversityId,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        MiddleName = row.MiddleName,
                        Status = (Status)row.Status,
                        Emphasis = new Emphasis()
                            {
                                Name = row.Name,
                                Id = row.Id
                            }
                    });
                }
                return students;
            }
            catch (SqlException e)
            {
                
                throw e;
            }  
        }

        public Student GetStudentInfoByFirstAndLastNameAndEmhpasis(string firstName, string lastName)
        {
            try
            {
                IEnumerable<dynamic> rows = this.RunProcedure<dynamic>("GetStudentInfoByFirstAndLastName", new { firstName, lastName});
                //just up and running to pass a unit test, will make better later.
                Student s = new Student { AssessmentItems = new List<AssessmentItem>() };
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

		public bool InsertCriteria(Criteria c)
		{
			try
			{
				return ExecuteQuery("AddCriteria", new { name = c.Name, maxScore = c.MaxScore });
			}
			catch (SqlException e)
			{
				throw e;
			}
		}

        public bool InsertStudent(Student s)
        {
            try
            {
                return ExecuteQuery("AddStudent", new { firstName = s.FirstName, lastName = s.LastName, middleName = s.MiddleName, status = (int)s.Status, emphasisId = s.Emphasis.Id });
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

		public bool InsertAssessmentItem ( AssessmentItem ai )
		{
			RawQuery( ai.AddQuery );
			return true;
		}

        public List<AssessmentItem> AssessmetAverageMaxMinByEmhpasis()
        {
            try
            {
                return RunProcedure<AssessmentItem>("AssessmentAverageMaxMinByEmphasis", new {}).ToList();
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
                return RunProcedure<AssessmentItem>("MaxMinAvgForStudent", new { studentId }).FirstOrDefault();
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
                return RunProcedure<AssessmentItem>("AllScoresForStudent", new { studentId }).ToList();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

		public List<Criteria> GetAllCriteria()
		{
			try
			{
				return RunProcedure<Criteria>("GetAllCriteria", new {}).ToList();
			}
			catch (SqlException e)
			{
				throw e;
			}
		}

        public bool UpdateStudent(Student s)
        {
            try
            {
                return ExecuteQuery("EditStudent",
                                    new
                                        {
                                            studentId = s.UniversityId,
                                            firstName = s.FirstName,
                                            lastName = s.LastName,
                                            middleName = s.MiddleName,
                                            statusType = (int)s.Status,
                                            emphasisId = s.Emphasis.Id
                                        });
            }
            catch (SqlException e)
            {
                
                throw e;
            }
        }

		public dynamic RawQuery (string query)
		{
			try
			{
				return base.RawQuery( query );
			}
			catch ( Exception )
			{
				throw;
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
