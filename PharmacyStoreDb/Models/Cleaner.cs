using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyStoreDb.Models
{
    public class Cleaner : Employee
    {
        public Manager Manager { get; set; }

      
    }
}