using System;
using System.Collections.Generic;

namespace DatabasProjekt.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int FkTeacherId { get; set; }

    public virtual Employee FkTeacher { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
