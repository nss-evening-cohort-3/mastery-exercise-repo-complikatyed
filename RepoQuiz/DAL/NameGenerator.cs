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

        public string ChooseFirstName(List<string> firstnames)
        {
            string firstname = ChooseRandomString(firstnames);
            return firstname;
        }

        public string ChooseLastName(List<string> lastnames)
        {
            string lastname = ChooseRandomString(lastnames);
            return lastname;
        }

        public string ChooseMajor(List<string> majors)
        {
            string major = ChooseRandomString(majors);
            return major;
        }

        public Student MakeRandomStudent()
        {
            string randomFirst = ChooseFirstName(firstnames);
            string randomLast = ChooseLastName(lastnames);
            string randomMajor = ChooseMajor(majors);

            Student randomizedStudent = new Student { FirstName = randomFirst, LastName = randomLast, Major = randomMajor };
                 
            return randomizedStudent;
        }


    }
}