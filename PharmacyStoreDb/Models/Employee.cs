using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyStoreDb.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DoB { get; set; }

        public string Salary { get; set; }

        public string EducationLevel { get; set; }
        public string MobilePhone { get; set; }

 

    }
}