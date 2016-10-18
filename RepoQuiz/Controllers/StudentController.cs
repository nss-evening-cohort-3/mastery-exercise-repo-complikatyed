using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoQuiz.DAL;
using RepoQuiz.Models;

namespace RepoQuiz.Controllers
{
    public class StudentController : Controller
    {
       
        private StudentRepository repo = new StudentRepository();

        // GET: Student
        public ActionResult Index()
        {
            List<Student> list_of_students = repo.GetStudents();
            ViewBag.Students = list_of_students;

            return View();
        }
 
    }
}
