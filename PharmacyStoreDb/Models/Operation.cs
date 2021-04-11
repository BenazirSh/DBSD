using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyStoreDb.Models
{
    public class Operation
    {

        public int OperationID { get; set; }
        public string OperationType { get; set; }

        public DateTime OperationDate { get; set; }

        public Pharmacist Pharmacist { get; set; }

        public int Quantity { get; set; }
        public Product Product { get; set; } //ask
     



    }
}