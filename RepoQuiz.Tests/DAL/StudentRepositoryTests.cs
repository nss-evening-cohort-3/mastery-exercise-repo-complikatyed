using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using System.Collections.Generic;
using RepoQuiz.Models;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace RepoQuiz.Tests.DAL
{
    
    [TestClass]
    public class StudentRepositoryTests
    {

        Mock<StudentContext> mock_context { get; set; }
        Mock<DbSet<Student>> mock_student_table { get; set; }
        List<Student> student_list { get; set; }
        StudentRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = student_list.AsQueryable();

            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(c => c.Students).Returns(mock_student_table.Object);

            mock_student_table.Setup(t => t.Add(It.IsAny<Student>())).Callback((Student s) => student_list.Add(s));
            mock_student_table.Setup(t => t.Remove(It.IsAny<Student>())).Callback((Student s) => student_list.Remove(s));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<StudentContext>();
            mock_student_table = new Mock<DbSet<Student>>();
            student_list = new List<Student>();
            repo = new StudentRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void RepoEnsureCanCreateInstance()
        {
            StudentRepository repo = new StudentRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureRepoHasContext()
        {
            StudentRepository repo = new StudentRepository();

            StudentContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(StudentContext));

        }

        [TestMethod]
        public void EnsureEmptyRepo()
        {

            List<Student> actual_students = repo.GetStudents();

            int expected_students_count = 0;
            int actual_students_count = actual_students.Count();

            Assert.AreEqual(expected_students_count, actual_students_count);

        }

        [TestMethod]
        public void EnsureCanAddStudentToDatabase()
        {
            Student first_student = new Student { FirstName = "Joe", LastName = "Monkeybutt", Major = "Communications" };

            repo.AddStudent(first_student);

            int actual_student_count = repo.GetStudents().Count;

            int expected_student_count = 1;

            // Assert
            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void EnsureCanFindStudentById()
        {
            Student first_student = new Student { StudentId = 1, FirstName = "Joe", LastName = "Monkeybutt", Major = "Communications" };
            Student second_student = new Student { StudentId = 2, FirstName = "Steve", LastName = "Goldenrod", Major = "Evolution of Software Instruction" };
            Student third_student = new Student { StudentId = 3, FirstName = "Jurnell", LastName = "NotionOf", Major = "MVC Whiteboard Examples" };

            repo.AddStudent(first_student);
            repo.AddStudent(second_student);
            repo.AddStudent(third_student);

            int student_id = 2;
            Student chosen_student = repo.GetStudentById(student_id);


            string expected_student_lastname = "Goldenrod";

            string actual_student_lastname = chosen_student.LastName;

            Assert.AreEqual(expected_student_lastname, actual_student_lastname);
        }
    }
}

