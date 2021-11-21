using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalDataGridTest.Models;
public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public bool IsMale { get; set; }
    public EmployeeType Type { get; set; }
    public Uri SiteID { get; set; }
    public DateTime BirthDate { get; set; }
    public double Volume { get; set; }

    public enum EmployeeType
    {
        Normal,
        Supervisor,
        Manager
    }
}