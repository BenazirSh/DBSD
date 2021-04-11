using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyStoreDb.Models
{
    public class Pharmacist : Employee
    {
      public Manager Manager { get; set; }

     public Branch Branch { get; set; }
    }
}