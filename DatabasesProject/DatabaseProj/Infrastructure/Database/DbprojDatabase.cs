﻿using System;
using System.Collections;
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
                IEnumerable<dynamic> rows = RunProcedure<dynamic>("GetStudentsLikeFirstAndLastName",
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

        public Student GetStudentByStudentId(int studentId)
        {
            try
            {
                return RunProcedure<Student>("GetStudentInfoByStudentId", new { studentId }).FirstOrDefault();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public Student GetStudentInfoByStudentId(int studentId)
        {
            try
            {
                Student s = GetStudentByStudentId(studentId);
                s.StudentAssessmentItems = DBAssessmentItem.ToCriteria(RunProcedure<DBAssessmentItem>("GetStudentAssessmentsById", new { studentId }));
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
    }
}
