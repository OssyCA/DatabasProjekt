using System;
using System.Collections.Generic;

namespace DatabasProjekt.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string PersonalNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int FkClassId { get; set; }

    public string Gender { get; set; } = null!;

    public DateOnly BirthDay { get; set; }

    public virtual SchoolClass FkClass { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
