using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace EFCoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Neue Schule mit Schülern hinzufügen
                var school = new School
                {
                    Name = "HTL Dornbirn",
                    Students = new List<Student>
                    {
                        new Student { Name = "Onur", Age = 17 },
                        new Student { Name = "Maylin", Age = 16 }
                    }
                };

                context.Schools.Add(school);
                context.SaveChanges();

                // Schulen mit ihren Studenten anzeigen
                var schools = context.Schools.Include(s => s.Students).ToList();

                foreach (var sch in schools)
                {
                    Console.WriteLine($"Schule: {sch.Name}");
                    foreach (var stud in sch.Students)
                    {
                        Console.WriteLine($"  Student: {stud.Name}, Alter: {stud.Age}");
                    }
                }
            }
        }
    }
}
