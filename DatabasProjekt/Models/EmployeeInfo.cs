using System;
using System.Collections.Generic;

namespace DatabasProjekt.Models;

public partial class EmployeeInfo
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmployeeRole { get; set; } = null!;

    public int? YearsWorked { get; set; }
}
