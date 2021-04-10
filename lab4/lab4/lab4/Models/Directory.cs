using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab4.Models
{
    public class Directory
    {
  
        public string last_name { get; set; }
        [Key]
        public string phone_number { get; set; }

       

       
    }
}