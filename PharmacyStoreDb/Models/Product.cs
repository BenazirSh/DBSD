using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PharmacyStoreDb.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Release Form")]
        public string ReleaseForm { get; set; }

        [DisplayName("Production Date")]
        public DateTime ProductionDate { get; set; }

        [DisplayName("Store Condition")]
        public string StoreCondition { get; set; }
        public string Manufacturer { get; set; }

        [DisplayName("Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        public string Volume { get; set; }

        [DisplayName("Product Type")]
        public ProductType ProductType { get; set; }

        [DisplayName("Price")]
        public string price { get; set; }




    }
    public enum ProductType
    {
        Medicine,
        Vitamin,
        HerbalTea,
        BodyCare
    }
}