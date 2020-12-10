using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Primark.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }

        [Display(Name = "Customer First Name")]
        public string CustomerFName{ get; set; }

        [Display(Name = "Customer Last Name")]
        public string CustomerLName { get; set; }

        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Customer Age")]
        public int CustomerAge { get; set; }

        [Display(Name = "Customer Telephone")]
        public string CustomerTelephone { get; set; }
    }
}
