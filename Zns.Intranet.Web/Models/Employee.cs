using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zns.Intranet.Web.Models
{
    public class Employee
    {
        public Employee()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int FieldExperience { get; set; }
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}