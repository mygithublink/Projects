//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class ProductTable
    {
        [ReadOnly(true)]
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }
        [ReadOnly(true)]
        [DisplayName("Available Stock Quantity")]
        public Nullable<int> StockQty { get; set; }
        [ReadOnly(true)]
        [DisplayName("Unit Price")]
        public Nullable<int> Price { get; set; }
        [ReadOnly(true)]
        public Nullable<int> SKU { get; set; }
        [DisplayName("Enter Quantity")]
        public Nullable<int> SaleQty { get; set; }
    }
}
