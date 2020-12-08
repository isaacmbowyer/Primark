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

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        public string FileName { get; set; }
    }
}
