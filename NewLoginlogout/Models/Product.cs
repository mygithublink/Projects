using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewLoginlogout.Models
{
    [Table("DEEPAK.PRODUCT")]
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int PRODUCTID { get; set; }

        public string PRODUCTNAME { get; set; }
        public string PRODUCTCOMPANY { get; set; }

        public Product()
        {
            //this.PRODUCTID = a;
            //this.PRODUCTNAME = b;
            //this.PRODUCTCOMPANY = c;

        }
       public Product(int a,string b,string c) {
            this.PRODUCTID = a;
            this.PRODUCTNAME = b;
            this.PRODUCTCOMPANY = c;
        
        }

       
    }
}