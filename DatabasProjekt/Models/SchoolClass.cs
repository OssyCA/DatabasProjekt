using System;
using System.Collections.Generic;

namespace DatabasProjekt.Models;

public partial class SchoolClass
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
