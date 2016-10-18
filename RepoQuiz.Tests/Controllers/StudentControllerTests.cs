using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.Controllers;
using Moq;
using RepoQuiz.DAL;
using System.Web.Mvc;
using RepoQuiz.Models;
using System.Collections.Generic;

namespace RepoQuiz.Tests.Controllers
{
    [TestClass]
    public class StudentControllerTests
    {
        private Mock<StudentRepository> mockStudentRepo;
        private List<Student> students;

        [TestInitialize]
        public void TestIntialize()
        {
            mockStudentRepo = new Mock<StudentRepository>();
            students = new List<Student>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockStudentRepo = null;
            students = null;
        }

        [TestMethod]
        public void CanMakeInstanceOfStudentController()
        {
            StudentController controller = new StudentController();
            Assert.IsNotNull(controller);
        }

    }
}
