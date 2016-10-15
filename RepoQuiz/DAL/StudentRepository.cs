using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;

namespace RepoQuiz.DAL
{
    public class StudentRepository
    {
        public StudentContext Context { get; set; }

        public StudentRepository()
        {
            Context = new StudentContext();
        }

        public StudentRepository(StudentContext _context)
        {
            Context = _context;
        }

        public List<Student> GetStudents()
        {
            int i = 1;
            return Context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            Student selected_student = Context.Students.First(s => s.StudentId == id);
            return selected_student;
        }

        public void AddStudent(Student student)
        {
            Context.Students.Add(student);
            Context.SaveChanges();
        }
    }
}