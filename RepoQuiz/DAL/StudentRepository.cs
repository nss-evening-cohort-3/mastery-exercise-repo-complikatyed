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
    }
}