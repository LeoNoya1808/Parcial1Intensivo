using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PryUserNoyaL.Models
{
    public class Company
    {
        [Key]
        [Required]
        public string name { get; set; }
        public string catchPhrase { get; set; }
    }
}