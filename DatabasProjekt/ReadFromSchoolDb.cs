using DatabasProjekt.Models;
using Microsoft.EntityFrameworkCore;
using MySchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasProjekt
{
    internal class ReadFromSchoolDb
    {
        public void ReadMenu()
        {
            Menu menu = new(["Visa Anställda", "Visa elever", "Visa kurser"], "Visa Info");
            switch (menu.MenuRun())
            {
                case 0:
                    ReadEmpoyee();
                    break;
                case 1:
                    ReadStudents();
                    break;
                case 2:
                    ReadCourses();
                    break;
                case 3:
                    break;
            }
        }
        private void ReadEmpoyee()
        {
            using (SchoolDbContext context = new()) // using dbContext
            {
                var employees = context.Employees; // Get list of employees 
                foreach (var employee in employees)
                {
                    Console.WriteLine($"Namn: {employee.FirstName} {employee.LastName} Roll: {employee.EmployeeRole}"); // Print out employee info
                }
                var roleCount = employees.GroupBy(x => x.EmployeeRole).Select(x => new { Role = x.Key, Count = x.Count() }); // Group by role and count
                foreach (var role in roleCount)
                {
                    Console.WriteLine($"\nRoll: {role.Role} Antal: {role.Count}");
                }

            }
            Console.ReadKey();
        }
        private void ReadStudents()
        {
            using (SchoolDbContext context = new())
            {
                var students = context.Students
                        .Include(s => s.FkClass) // Include the class for the student
                        .OrderBy(s => s.LastName)
                        .GroupBy(s => s.FkClass.ClassName); // Group by class name
                foreach (var studentGroup in students)
                {
                    Console.WriteLine("---------------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Class: {studentGroup.Key}"); // Print out class name
                    Console.ResetColor();
                    foreach (var student in studentGroup)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}, Personnummer: {student.PersonalNumber} ");
                    }
                }
            }
            Console.ReadKey();
        }
        private void ReadCourses()
        {
            using (SchoolDbContext context = new())
            {
                var courses = context.Courses
                    .Include(c => c.FkTeacher) // Include the teacher for the course
                    .OrderBy(c => c.CourseName)
                    .GroupBy(c => c.FkTeacher.FirstName); // Group by teacher name
                foreach (var courseGroup in courses)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine($"Lärare: {courseGroup.Key}"); // Print out teacher name
                    foreach (var course in courseGroup)
                    {
                        Console.WriteLine($"{course.CourseName}");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
