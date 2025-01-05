using System;
using System.Collections.Generic;

namespace DatabasProjekt.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string PersonalNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmployeeRole { get; set; } = null!;

    public decimal Salary { get; set; }

    public DateOnly? HireDate { get; set; }

    public byte[] EmployeePassword { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
