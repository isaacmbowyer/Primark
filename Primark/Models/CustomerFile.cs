using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Primark.Models
{
    public class CustomerFile
    {

        public int Id { get; set; }

        [Display(Name = "Customer First Name")]
        public string CustomerFName { get; set; }

        [Display(Name = "Customer Last Name")]
        public string CustomerLName { get; set; }

        [Display(Name = "Customer File")]
        public string FileName { get; set; }
    }
}
