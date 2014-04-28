using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.DynamicMySQLDb;
using Infrastructure.Classes;
using Infrastructure.Database;
using System.Collections.Generic;
namespace DbProjUnitTests
{
    [TestClass]
    public class StoredProcedureUnitTest
    {
        DbprojDatabase db = new DbprojDatabase();

        [TestMethod]
        public void GetStudentByFirstAndLastNameTest()
        {
            Student s = db.GetStudentInfoByFirstAndLastName("Wade", "Andrews");
            Console.WriteLine(s.UniversityId);
            Assert.IsNotNull(s);
        }

        public void GetAssessmentSemesterAverageByCriteria()
        {
            List<CriteriaResult> results = db.AssessmentSemesterAverageByCriteria(1, 1);
            Assert.IsNotNull(results);
        }
    }
}
