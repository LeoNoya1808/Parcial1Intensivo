using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PryUserNoyaL.Models
{
    public class Root
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Escoja otro nombre",MinimumLength =5)]
        public string name { get; set; }
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [Required]
        public Adress address { get; set; }
        [Phone]
        [Required]
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }
}