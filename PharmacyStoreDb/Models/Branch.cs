using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyStoreDb.Models
{
    public class Branch
    {

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public string BranchAddress { get; set; }
        public Manager Manager { get; set; }

        public Cleaner Cleaner { get; set; }

    }
}