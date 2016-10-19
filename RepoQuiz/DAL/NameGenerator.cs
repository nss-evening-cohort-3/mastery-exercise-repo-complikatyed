using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;

namespace RepoQuiz.DAL
{
    public class NameGenerator
    {

        List<string> firstnames = new List<string> { "Ahab", "Alejandro", "Alexandra", "Ahmad", "Anita", "Alyssa", "Andre", "Amit", "Anja", "Alice", "Alexa", "Alan" };
        List<string> lastnames = new List<string> { "Bellisarius", "Bertram", "Bell", "Ballard", "Boone", "Beck", "Bellingham", "Ballustrade", "Beech", "Buckingham" };
        List<string> majors = new List<string> { "Women's Studies", "Anthropology", "Economics", "Art History", "Biology", "Psychology", "Archeology", "Classics" };

        public string ChooseRandomString(List<string> list)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(list.Count);
            var chosenString = list[randomIndex];

            return chosenString;
        }                                                                                               

        public Student MakeRandomStudent()
        {
            var randomFirst = ChooseRandomString(firstnames);
            var randomLast = ChooseRandomString(lastnames);
            var randomMajor = ChooseRandomString(majors);

            Student randomizedStudent = new Student { FirstName = randomFirst, LastName = randomLast, Major = randomMajor };

            return randomizedStudent;
        }

    }
}