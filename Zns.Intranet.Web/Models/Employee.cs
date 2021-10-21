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
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }       
    }
    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}