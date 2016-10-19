namespace RepoQuiz.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RepoQuiz.DAL;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RepoQuiz.DAL.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepoQuiz.DAL.StudentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            NameGenerator randomizer = new NameGenerator();

            var student1 = randomizer.MakeRandomStudent();
            var student2 = randomizer.MakeRandomStudent();
            var student3 = randomizer.MakeRandomStudent();
            var student4 = randomizer.MakeRandomStudent();
            var student5 = randomizer.MakeRandomStudent();
            var student6 = randomizer.MakeRandomStudent();
            var student7 = randomizer.MakeRandomStudent();
            var student8 = randomizer.MakeRandomStudent();
            var student9 = randomizer.MakeRandomStudent();
            var student10 = randomizer.MakeRandomStudent();

            context.Students.AddOrUpdate(

                student1,
                student2,
                student3,
                student4,
                student5,
                student6,
                student7,
                student8,
                student9,
                student10
            );

        }
    }
}
